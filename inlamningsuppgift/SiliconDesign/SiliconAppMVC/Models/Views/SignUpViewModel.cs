using Infrastructure.Models;

namespace SiliconAppMVC.Models.Views;

public class SignUpViewModel {
    public SignUpModel FormSignUp { get; set; } = new();
    public string? ErrorMessage { get; set; }
}
