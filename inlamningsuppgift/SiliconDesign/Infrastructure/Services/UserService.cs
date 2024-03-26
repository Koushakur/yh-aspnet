using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Shared.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;
public class UserService(UserRepository userRepository, AddressService addressService) {
    private readonly UserRepository _userRepository = userRepository;
    //private readonly AddressService _addressService = addressService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns>Null if user exists or exception is triggered, otherwise the created UserEntity</returns>
    public async Task<UserEntity> CreateUserAsync(SignUpModel model) {
        try {
            var tUser = UserFactory.Create(model);

            if (await _userRepository.Exists(x => x.Email == model.Email))
                return null!;

            return await _userRepository.Create(tUser);

        } catch (Exception e) { Debug.WriteLine(e); }

        return null!;
    }

    public async Task<bool> SignInAsync(SignInModel model) {
        try {

            var tUser = await _userRepository.GetOne(x => x.Email == model.Email);
            if (tUser != null) {
                return PasswordSecurity.ValidatePassword(model.Password, tUser.Password, tUser.SecurityKey);
            }

        } catch (Exception e) { Debug.WriteLine(e); }

        return false;
    }
}
