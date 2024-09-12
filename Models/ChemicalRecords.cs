using System;
using System.Collections.Generic;

namespace LabAPI.Models;

public partial class ChemicalRecords
{
    public int RecordID { get; set; }

    public string? EmployeeID { get; set; }

    public int? ChemicalID { get; set; }

    public double Quantity { get; set; }

    public DateTime Date { get; set; }

    public string? Notes { get; set; }

    public virtual Chemicals? Chemical { get; set; }

    public virtual Employee? Employee { get; set; }
}
