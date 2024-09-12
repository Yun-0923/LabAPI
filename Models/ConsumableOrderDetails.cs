using System;
using System.Collections.Generic;

namespace LabAPI.Models;

public partial class ConsumableOrderDetails
{
    public int OrderID { get; set; }

    public int ConsumableID { get; set; }

    public short Quantity { get; set; }

    public virtual Consumables Consumable { get; set; } = null!;

    public virtual Orders Order { get; set; } = null!;
}
