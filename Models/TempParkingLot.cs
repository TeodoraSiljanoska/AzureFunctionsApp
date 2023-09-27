using System;
using System.Collections.Generic;

namespace IWParkingAPI.Models;

public partial class TempParkingLot
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

    public int? ParkingLotId { get; set; }

    public virtual AspNetUser User { get; set; } = null!;
}
