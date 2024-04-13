using Infrastructure.Models;

namespace SiliconAppMVC.Models.Views;

public class AccountDetailsViewModel {
    public AccountDetails_BasicInfo_Model FormBasicInfo { get; set; } = new();
    public AccountDetails_AddressInfo_Model FormAddressInfo { get; set; } = new();
}
