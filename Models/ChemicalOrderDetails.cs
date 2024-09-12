using System;
using System.Collections.Generic;

namespace LabAPI.Models;

public partial class ChemicalOrderDetails
{
    public int OrderID { get; set; }

    public int ChemicalID { get; set; }

    public double Quantity { get; set; }

    public virtual Chemicals Chemical { get; set; } = null!;

    public virtual Orders Order { get; set; } = null!;
}
