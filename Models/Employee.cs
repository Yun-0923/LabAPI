using System;
using System.Collections.Generic;

namespace LabAPI.Models;

public partial class Employee
{
    public string EmployeeID { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string password { get; set; } = null!;

    public int Role { get; set; }

    public string Email { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<ChemicalRecords> ChemicalRecords { get; set; } = new List<ChemicalRecords>();

    public virtual ICollection<ConsumableRecords> ConsumableRecords { get; set; } = new List<ConsumableRecords>();

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();

    public virtual ICollection<SampleRecords> SampleRecords { get; set; } = new List<SampleRecords>();
}
