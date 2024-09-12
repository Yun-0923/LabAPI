using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LabAPI.Models;

public partial class SampleType
{
    [Key]
    
    public int TypeID { get; set; }
    [Display(Name = "名稱")]
    [StringLength(10, ErrorMessage = "最多輸入10個字")]
    public string TypeName { get; set; } = null!;
    [JsonIgnore]
    public virtual List<Samples>? Samples { get; set; }
}
