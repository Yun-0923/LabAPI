using System;
using System.Collections.Generic;

namespace LabAPI.Models;

public partial class Orders
{
    public int OrderID { get; set; }

    public string? EmployeeID { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public bool Status { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<ChemicalOrderDetails> ChemicalOrderDetails { get; set; } = new List<ChemicalOrderDetails>();

    public virtual ICollection<ConsumableOrderDetails> ConsumableOrderDetails { get; set; } = new List<ConsumableOrderDetails>();

    public virtual Employee? Employee { get; set; }
}
