using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Models.Identity;

public class AppUser : IdentityUser {

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    //public string? PhoneNumber { get; set; }
    public string? Biography { get; set; }
    public DateTime Created { get; set; }

    public AddressEntity Address { get; set; } = null!;
}