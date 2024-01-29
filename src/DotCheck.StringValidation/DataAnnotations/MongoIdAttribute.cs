using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.DataAnnotations
{
    public class MongoIdAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return true;
            return value is string str && MongoIdValidation.Validate(str);
        }

        public override string FormatErrorMessage(string name) =>
            string.Format(CultureInfo.CurrentCulture, "The field is not a valid mongodb id.");
    }
}