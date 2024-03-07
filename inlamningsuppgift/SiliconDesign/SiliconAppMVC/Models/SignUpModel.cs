using SiliconAppMVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace SiliconAppMVC.Models;
public class SignUpModel {

    [Display(Name = "First name", Prompt = "Enter your first name")]
    [Required(ErrorMessage = "Required field")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last name", Prompt = "Enter your last name")]
    [Required(ErrorMessage = "Required field")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Email address", Prompt = "Enter your email-address")]
    [Required(ErrorMessage = "Required field")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(pattern: @"^[^\.\s][\w\-\.\{2,\}]+@([\w-]+\.)+[\w-]{2,}$", ErrorMessage = "Invalid email")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password", Prompt = "********")]
    [Required(ErrorMessage = "Required field")]
    [DataType(DataType.Password)]
    [RegularExpression(pattern: @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[\d\W]).{6,}$", ErrorMessage = "Pasword needs upper, lower and digit or special character")]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm password", Prompt = "********")]
    [Required(ErrorMessage = "Required field")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Does not match password")]
    public string PasswordConfirm { get; set; } = null!;

    [CheckboxValidation(ErrorMessage = "You must accept to continue")]
    public bool AcceptTerms { get; set; } = false;

}
