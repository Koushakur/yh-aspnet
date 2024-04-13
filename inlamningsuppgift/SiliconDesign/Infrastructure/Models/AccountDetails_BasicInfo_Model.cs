using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;
public class AccountDetails_BasicInfo_Model {

    [DataType(DataType.ImageUrl)]
    public string? ProfileImageURL { get; set; }

    [Display(Name = "First name", Prompt = "Enter your first name")]
    [Required(ErrorMessage = "Required field")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last name", Prompt = "Enter your last name")]
    [Required(ErrorMessage = "Required field")]
    public string LastName { get; set; } = null!;

    public string FullName {
        get { return $"{FirstName} {LastName}"; }
    }

    [Display(Name = "Email address", Prompt = "Enter your email-address")]
    [Required(ErrorMessage = "Required field")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(pattern: @"^[^\.\s][\w\-\.\{2,\}]+@([\w-]+\.)+[\w-]{2,}$", ErrorMessage = "Invalid email")]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone", Prompt = "Enter your phone number")]
    //[Required(ErrorMessage = "Required field")]
    //[DataType(DataType.PhoneNumber)]
    public string? Phone { get; set; }

    [Display(Name = "Bio", Prompt = "Add a short bio...")]
    [DataType(DataType.MultilineText)]
    public string? Bio { get; set; }
}
