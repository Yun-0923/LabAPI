using System;
using System.Collections.Generic;

namespace LabAPI.Models;

public partial class Categories
{
    public int CategoryID { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Chemicals> Chemicals { get; set; } = new List<Chemicals>();
}
