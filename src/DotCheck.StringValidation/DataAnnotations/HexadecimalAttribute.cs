using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DotCheck.StringValidation.CoreValidators;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.DataAnnotations;

public class HexadecimalAttribute : ValidationAttribute
{
    public override bool IsValid(object? value) =>
        new HexadecimalValidation().Validate(Transformation.MakeValidString(value));

    public override string FormatErrorMessage(string name) =>
        string.Format(CultureInfo.CurrentCulture, "The field is not a valid hex.");
}