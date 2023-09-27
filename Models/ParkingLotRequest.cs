using System;
using System.Collections.Generic;

namespace IWParkingAPI.Models;

public partial class ParkingLotRequest
{
    public int Id { get; set; }

    public int Status { get; set; }

    public int UserId { get; set; }

    public int ParkingLotId { get; set; }

    public DateTime TimeCreated { get; set; }

    public int Type { get; set; }

    public virtual AspNetUser User { get; set; } = null!;
}
