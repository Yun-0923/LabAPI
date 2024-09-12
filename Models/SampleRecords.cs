using System;
using System.Collections.Generic;

namespace LabAPI.Models;

public partial class SampleRecords
{
    public int RecordID { get; set; }

    public string? EmployeeID { get; set; }

    public long? SampleID { get; set; }

    public bool TransactionType { get; set; }

    public short Quantity { get; set; }

    public DateTime Date { get; set; }

    public string? Notes { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Samples? Sample { get; set; }
}
