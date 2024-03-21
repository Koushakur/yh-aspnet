using Infrastructure.Models;

namespace SiliconAppMVC.Models.Views;

public class SignInViewModel {
    public SignInModel FormSignIn { get; set; } = new();
    public string? ErrorMessage { get; set; }
}
