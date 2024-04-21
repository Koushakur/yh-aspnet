using Infrastructure.Helpers;
using System.ComponentModel.DataAnnotations;

namespace SiliconAppMVC.Models.Sections;

public class NewsletterModel {

    [Display(Name = "Email address", Prompt = "Your Email")]
    [Required(ErrorMessage = "Required field")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(pattern: @"^[^\.\s][\w\-\.\{2,\}]+@([\w-]+\.)+[\w-]{2,}$", ErrorMessage = "Invalid email")]
    public string Email { get; set; } = null!;

    [Display(Name = "Daily Newsletter")]
    public bool Daily { get; set; }

    [Display(Name = "Advertising Updates")]
    public bool Advertising { get; set; }

    [Display(Name = "Week in Review")]
    public bool Weekly { get; set; }

    [Display(Name = "Event Updates")]
    public bool Event { get; set; }

    [Display(Name = "Startups Weekly")]
    public bool Startup { get; set; }

    [Display(Name = "Podcasts")]
    public bool Podcast { get; set; }

    [NewsletterChosen]
    public bool AnyNewsletterChosen { get; set; }
}
