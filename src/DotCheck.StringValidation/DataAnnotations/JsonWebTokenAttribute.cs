using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DotCheck.StringValidation.Core;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.DataAnnotations;

public class JsonWebTokenAttribute : ValidationAttribute
{
    public override bool IsValid(object? value) =>
        new DotCheckStringValidation().IsJsonWebToken(Transformation.MakeValidString(value));

    public override string FormatErrorMessage(string name) =>
        string.Format(CultureInfo.CurrentCulture, "The field is not a valid json web token.");
}