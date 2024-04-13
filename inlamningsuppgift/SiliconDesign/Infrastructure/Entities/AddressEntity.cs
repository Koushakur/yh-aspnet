using Infrastructure.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class AddressEntity {
    public string StreetName { get; set; } = null!;
    public string? StreetName2 { get; set; }
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;

    [Key]
    public string UserId { get; set; } = null!;
    public AppUser User { get; set; } = null!;
}

