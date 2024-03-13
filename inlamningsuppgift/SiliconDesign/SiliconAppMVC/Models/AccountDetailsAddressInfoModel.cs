using System.ComponentModel.DataAnnotations;

namespace SiliconAppMVC.Models;
public class AccountDetailsAddressInfoModel {

    [Display(Name = "Address line 1", Prompt = "Enter your address line")]
    [Required(ErrorMessage = "Required field")]
    public string Address1 { get; set; } = null!;

    [Display(Name = "Address line 2", Prompt = "Enter your second address line")]
    public string? Address2 { get; set; }

    [Display(Name = "Postal code", Prompt = "Enter your postal code")]
    [Required(ErrorMessage = "Required field")]
    [DataType(DataType.PostalCode)]
    public string PostalCode { get; set; } = null!;

    [Display(Name = "City", Prompt = "Enter your city")]
    [Required(ErrorMessage = "Required field")]
    public string City { get; set; } = null!;
}
