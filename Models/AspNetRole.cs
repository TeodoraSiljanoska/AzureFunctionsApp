using System;
using System.Collections.Generic;

namespace IWParkingAPI.Models;

public partial class AspNetRole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public DateTime TimeCreated { get; set; }

    public DateTime? TimeModified { get; set; }

    public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; } = new List<AspNetRoleClaim>();

    public virtual ICollection<AspNetUser> Users { get; set; } = new List<AspNetUser>();
}
