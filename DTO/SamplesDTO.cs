using System.ComponentModel.DataAnnotations;

namespace LabAPI.DTO
{
    public class SamplesDTO
    {
        [Display(Name = "編號")]
        public long SampleID { get; set; }
        [Display(Name = "名稱")]
        [Required(ErrorMessage = "必填")]
        [StringLength(60, ErrorMessage = "請勿超過60個字")]
        public string SampleName { get; set; } = null!;
        [Display(Name = "物種")]
        [StringLength(40, ErrorMessage = "最多40個字")]
        public string? Species { get; set; }
        [Display(Name = "基因型")]
        [StringLength(40, ErrorMessage = "最多40個字")]
        public string? Genotype { get; set; }
        [Display(Name = "血清型")]
        public short? Serotype { get; set; }
        [Display(Name = "數量")]
        [Required(ErrorMessage = "必填")]
        [RegularExpression(@"^\d+$", ErrorMessage = "只能填寫正整數")]
        public short Quantity { get; set; }
        
    }
}
