using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DotCheck.StringValidation.Core;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.DataAnnotations;

public class MongoIdAttribute : ValidationAttribute
{
    public override bool IsValid(object? value) =>
        new DotCheckStringValidation().IsMongoId(Transformation.MakeValidString(value));

    public override string FormatErrorMessage(string name) =>
        string.Format(CultureInfo.CurrentCulture, "The field is not a valid mongodb id.");
}