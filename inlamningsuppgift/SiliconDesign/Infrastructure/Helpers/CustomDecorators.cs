using SiliconAppMVC.Models.Sections;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Helpers;

public class CheckboxValidation : ValidationAttribute {
    public override bool IsValid(object? value) => value is bool b && b;
}

public class NewsletterChosen : ValidationAttribute {
    protected override ValidationResult IsValid(object? value, ValidationContext cont) {
        var model = (NewsletterModel)cont.ObjectInstance;

        if (model != null && (model.Daily || model.Advertising || model.Weekly || model.Event || model.Startup || model.Podcast)) {
            return ValidationResult.Success!;
        }

        return new ValidationResult("");
    }
}