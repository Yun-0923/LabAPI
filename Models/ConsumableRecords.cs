using System;
using System.Collections.Generic;

namespace LabAPI.Models;

public partial class ConsumableRecords
{
    public int RecordID { get; set; }

    public string? EmployeeID { get; set; }

    public int? ConsumableID { get; set; }

    public short Quantity { get; set; }

    public DateTime Date { get; set; }

    public string? Notes { get; set; }

    public virtual Consumables? Consumable { get; set; }

    public virtual Employee? Employee { get; set; }
}
