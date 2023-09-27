using System;
using System.Collections.Generic;

namespace IWParkingAPI.Models;

public partial class AspNetUser
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? NormalizedUserName { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool? EmailConfirmed { get; set; }

    public bool? IsDeactivated { get; set; }

    public DateTime TimeCreated { get; set; }

    public DateTime? TimeModified { get; set; }

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; } = new List<AspNetUserToken>();

    public virtual ICollection<ParkingLotRequest> ParkingLotRequests { get; set; } = new List<ParkingLotRequest>();

    public virtual ICollection<ParkingLot> ParkingLots { get; set; } = new List<ParkingLot>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<TempParkingLot> TempParkingLots { get; set; } = new List<TempParkingLot>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    public virtual ICollection<ParkingLot> ParkingLotsNavigation { get; set; } = new List<ParkingLot>();

    public virtual ICollection<AspNetRole> Roles { get; set; } = new List<AspNetRole>();
}
