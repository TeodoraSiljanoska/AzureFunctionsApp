using System;
using System.Collections.Generic;

namespace IWParkingAPI.Models;

public partial class ParkingLot
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Zone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public TimeSpan WorkingHourFrom { get; set; }

    public TimeSpan WorkingHourTo { get; set; }

    public int CapacityCar { get; set; }

    public int CapacityAdaptedCar { get; set; }

    public int Price { get; set; }

    public int UserId { get; set; }

    public bool? IsDeactivated { get; set; }

    public DateTime TimeCreated { get; set; }

    public DateTime? TimeModified { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual AspNetUser User { get; set; } = null!;

    public virtual ICollection<AspNetUser> Users { get; set; } = new List<AspNetUser>();
}
