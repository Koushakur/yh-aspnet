namespace SiliconAppMVC.Models.Views;

public class AccountDetailsViewModel {
    public AccountDetailsBasicInfoModel FormBasicInfo { get; set; } = new() {
        ProfileImageURL = "images/profile.png",
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@domain.com",
    };
    public AccountDetailsAddressInfoModel FormAddressInfo { get; set; } = new();
}
