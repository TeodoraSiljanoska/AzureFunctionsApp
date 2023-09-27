using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
//using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Sql;
using IWParkingAPI.Models;

namespace FunctionApp1234567890
{
    public static class Functions
    {
        [FunctionName("negotiate")]
        public static SignalRConnectionInfo Negotiate(
            [HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest req,
            [SignalRConnectionInfo(ConnectionStringSetting = "AzureSignalRConnectionString",
            HubName = "reservations")] SignalRConnectionInfo connectionInfo)//, ILogger log)
        {
            //log.LogInformation("Returning connection: " + connectionInfo.Url + " " + connectionInfo.AccessToken);
            return connectionInfo;
        }

        [FunctionName("requestNotifications")]
        public static async Task Run(
        [SqlTrigger("[dbo].[ParkingLotRequest]", "DefaultConnection")]
        IReadOnlyList<SqlChange<ParkingLotRequest>> requestChanges,
       // ILogger logger,
        [SignalR(ConnectionStringSetting = "AzureSignalRConnectionString", HubName = "reservations")]
        IAsyncCollector<SignalRMessage> signalRMessages)
        {
            foreach (var request in requestChanges)
            {
                var requestItem = request.Item;
              //  logger.LogInformation($"Change operation: {request.Operation}");
              //  logger.LogInformation($"Id: {requestItem.Id} + {requestItem.Status}");

                string message;

                if (request.Operation.ToString() == "Insert")
                    message = "A new Request is created. Go to Requests to view more details.";

                else if (request.Operation.ToString() == "Update")
                    message = "A Request is updated.";

                else
                    message = "A Request is deleted.";

                await signalRMessages.AddAsync(new SignalRMessage
                {
                    Target = "NewRequest",
                    Arguments = new string[] { message }
                });
            }
        }


        [FunctionName("reservationNotifications")]
        public static async Task Test([TimerTrigger("0 */15 * * * *")] TimerInfo myTimer,// ILogger log,
         [SignalR(ConnectionStringSetting = "AzureSignalRConnectionString", HubName = "reservations")]
        IAsyncCollector<SignalRMessage> signalRMessages)
        {
            List<UserToNotify> Users = new List<UserToNotify>();
            //log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            string connectionString = Environment.GetEnvironmentVariable("DefaultConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string vehicleTable = "Vehicle";
                string reservationTable = "Reservation";

                TimeZoneInfo cetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
                DateTime serverTime = DateTime.UtcNow;
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(serverTime, cetTimeZone);
                TimeSpan time = localTime.TimeOfDay;
                TimeSpan timePlus15 = localTime.AddMinutes(15).TimeOfDay;


                TimeSpan newTimeSpan = new TimeSpan(time.Hours, time.Minutes, 0);
                TimeSpan newTimeSpan59 = new TimeSpan(timePlus15.Hours, timePlus15.Minutes, 59);

                string s1 = new DateTime(newTimeSpan.Ticks).ToString(@"HH\:mm\:ss");
                string s2 = new DateTime(newTimeSpan59.Ticks).ToString(@"HH\:mm\:ss");


                string reservationQuery = $"SELECT Reservation.User_Id, Reservation.Vehicle_Id, Plate_Number FROM {reservationTable} \n" +
                    $"LEFT JOIN {vehicleTable} ON Reservation.Vehicle_Id = Vehicle.Id " +
                    $"WHERE CAST(End_Date AS DATE) = CAST(GETDATE() AS DATE)" +
                    $" AND CAST(End_Time AS TIME) >= '{s1}' AND CAST(End_Time as TIME) <= '{s2}'";


                int userId;
                string plateNumber;

                UserToNotify user = new UserToNotify();

                using (SqlCommand command = new SqlCommand(reservationQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                userId = reader.GetInt32(reader.GetOrdinal("User_Id"));
                                plateNumber = reader.GetString(reader.GetOrdinal("Plate_Number"));

                                //log.LogInformation($"Test message for User with ID {userId}");

                                user = new UserToNotify();
                                user.UserId = userId;
                                user.Message = "Reservation with plate number " + plateNumber + " is about to expire";

                                Users.Add(user);
                            }
                        }
                    }
                }

                await signalRMessages.AddAsync(
                    new SignalRMessage
                    {
                        Target = "reservations",
                        Arguments = new object[] { Users }
                    });
            }
        }
    }
}