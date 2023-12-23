using System.ComponentModel.DataAnnotations;
using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.DataAnnotations;

public class HexadecimalAttribute : ValidationAttribute
{
    public override bool IsValid(object? value) =>
        new HexadecimalValidation().Validate(value);
}