using System;
using System.Collections.Generic;

namespace IWParkingAPI.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public TimeSpan StartTime { get; set; }

    public DateTime EndDate { get; set; }

    public TimeSpan EndTime { get; set; }

    public int Amount { get; set; }

    public bool IsPaid { get; set; }

    public int UserId { get; set; }

    public int ParkingLotId { get; set; }

    public DateTime TimeCreated { get; set; }

    public DateTime? TimeModified { get; set; }

    public int VehicleId { get; set; }

    public virtual ParkingLot ParkingLot { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual AspNetUser User { get; set; } = null!;

    public virtual Vehicle Vehicle { get; set; } = null!;
}
