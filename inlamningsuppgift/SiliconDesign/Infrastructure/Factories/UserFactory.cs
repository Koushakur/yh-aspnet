﻿using Infrastructure.Entities;
using Infrastructure.Helpers;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class UserFactory {
    public static UserEntity Create(string firstName, string lastName, string email, string password) {

        var (tPassword, tSecKey) = PasswordSecurity.GenerateHashAndKey(password);

        return new UserEntity {
            Id = Guid.NewGuid().ToString(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = tPassword,
            SecurityKey = tSecKey,
            Created = DateTime.Now,
        };
    }

    public static UserEntity Create(SignUpModel model) {

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
}