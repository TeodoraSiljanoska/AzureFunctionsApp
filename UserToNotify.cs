using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1234567890
{
    public class UserToNotify
    {
        public int UserId { get; set; }
        public string Message { get; set; }
    }
}
