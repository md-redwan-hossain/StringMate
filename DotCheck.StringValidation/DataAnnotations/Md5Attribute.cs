using System.ComponentModel.DataAnnotations;
using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.DataAnnotations;

public class Md5Attribute : ValidationAttribute
{
    public override bool IsValid(object? value) =>
        new Md5Validation().Validate(value);
}