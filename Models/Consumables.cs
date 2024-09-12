using System;
using System.Collections.Generic;

namespace LabAPI.Models;

public partial class Consumables
{
    public int ConsumableID { get; set; }

    public string? ConsumableName { get; set; }

    public string QuantityPerUnit { get; set; } = null!;

    public short UnitInStock { get; set; }

    public short? SafetyLevel { get; set; }

    public DateTime? ExpireDate { get; set; }

    public short Room { get; set; }

    public string? Cabinet { get; set; }

    public string? Shelf { get; set; }

    public string? Description { get; set; }

    public int? SupplierID { get; set; }

    public byte[]? Photo { get; set; }

    public string? PhotoType { get; set; }

    public virtual ICollection<ConsumableOrderDetails> ConsumableOrderDetails { get; set; } = new List<ConsumableOrderDetails>();

    public virtual ICollection<ConsumableRecords> ConsumableRecords { get; set; } = new List<ConsumableRecords>();

    public virtual Supplier? Supplier { get; set; }
}
