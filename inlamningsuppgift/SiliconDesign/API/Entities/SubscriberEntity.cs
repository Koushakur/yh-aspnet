using SiliconAppMVC.Models.Sections;
using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class SubscriberEntity {
    [Key]
    [EmailAddress]
    public string Email { get; set; } = null!;

    public static implicit operator SubscriberEntity(NewsletterModel model) {
        return new SubscriberEntity { Email = model.Email };
    }
}
