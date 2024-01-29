using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.DataAnnotations
{
    public class JsonWebTokenAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return true;
            return value is string str && JsonWebTokenValidation.Validate(str);
        }


        public override string FormatErrorMessage(string name) =>
            string.Format(CultureInfo.CurrentCulture, "The field is not a valid json web token.");
    }
}