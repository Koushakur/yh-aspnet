using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Helpers;

public class CheckboxValidation : ValidationAttribute {
    public override bool IsValid(object? value) => value is bool b && b;
}
