using System.ComponentModel.DataAnnotations;

namespace SiliconAppMVC.Models;

public class SignInModel {
    [Display(Name = "Email address", Prompt = "Enter your email-address")]
    [Required(ErrorMessage = "Required field")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Password", Prompt = "********")]
    [Required(ErrorMessage = "Required field")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; } = false;
}
