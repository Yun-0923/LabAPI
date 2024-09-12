using System.ComponentModel.DataAnnotations;
namespace LabAPI.Models;

public class Cornonavirus
{
    [Display(Name = "編號")]
    public string id { get; set; }
    [Display(Name = "最後統計日期")]
    public string a01 { get; set; }
    [Display(Name = "縣市")]
    public string a02 { get; set; }
    [Display(Name = "鄉鎮")]
    public string a03 { get; set; }
    [Display(Name = "年齡層")]
    public string a04 { get; set; }
    [Display(Name = "累計確診人數")]
    public string a05 { get; set; }

}

//{ "id":"ID","a01":"最後統計日期","a02":"縣市","a03":"鄉鎮","a04":"年齡層","a05":"累計確診人數"}