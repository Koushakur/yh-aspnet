using Infrastructure.Entities;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Factories;

public class UserFactory() {

    public static UserEntity CreateUserEntity(SignUpModel model) {

        var (tPassword, tSecKey) = PasswordSecurity.GenerateHashAndKey(model.Password);

        return new UserEntity {
            Id = Guid.NewGuid().ToString(),
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Password = tPassword,
            SecurityKey = tSecKey,
            Created = DateTime.Now,
        };
    }

    public static AppUser CreateAppUser(SignUpModel model) {

        return new AppUser {
            Id = Guid.NewGuid().ToString(),
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.Email,
            Email = model.Email,
            Created = DateTime.Now,
        };
    }
}
