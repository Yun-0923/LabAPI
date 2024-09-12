using System;
using System.Collections.Generic;

namespace LabAPI.Models;

public partial class Supplier
{
    public int SupplierID { get; set; }

    public string CompanyName { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public string ContactTel { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<Chemicals> Chemicals { get; set; } = new List<Chemicals>();

    public virtual ICollection<Consumables> Consumables { get; set; } = new List<Consumables>();
}
