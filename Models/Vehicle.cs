using System;
using System.Collections.Generic;

namespace IWParkingAPI.Models;

public partial class Vehicle
{
    public int Id { get; set; }

    public string PlateNumber { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime TimeCreated { get; set; }

    public DateTime? TimeModified { get; set; }

    public bool? IsPrimary { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual AspNetUser User { get; set; } = null!;
}
