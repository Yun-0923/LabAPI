using System;
using System.Collections.Generic;

namespace LabAPI.Models;

public partial class Chemicals
{
    public int ChemicalID { get; set; }

    public string ChineseName { get; set; } = null!;

    public string EnglishName { get; set; } = null!;

    public string? CASNo { get; set; }

    public double? Concentration { get; set; }

    public bool Unit { get; set; }

    public double Stock { get; set; }

    public double? SafetyLevel { get; set; }

    public bool StorageCondition { get; set; }

    public string CabinetName { get; set; } = null!;

    public short? CabinetNumber { get; set; }

    public int? SupplierID { get; set; }

    public int CategoryID { get; set; }

    public virtual Categories Category { get; set; } = null!;

    public virtual ICollection<ChemicalOrderDetails> ChemicalOrderDetails { get; set; } = new List<ChemicalOrderDetails>();

    public virtual ICollection<ChemicalRecords> ChemicalRecords { get; set; } = new List<ChemicalRecords>();

    public virtual Supplier? Supplier { get; set; }
}
