using System;
using System.Collections.Generic;

namespace IWParkingAPI.Models;

public partial class Payment
{
    public int Id { get; set; }

    public DateTime MadeOn { get; set; }

    public string Type { get; set; } = null!;

    public int ReservationId { get; set; }

    public virtual Reservation Reservation { get; set; } = null!;
}
