using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DotCheck.StringValidation.CoreValidators;
using DotCheck.StringValidation.CoreValidators.Enums;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.DataAnnotations
{
    public class HashAttribute : ValidationAttribute
    {
        public HashAttribute(HashingAlgorithm algorithm) =>
            _algorithm = algorithm;

        private readonly HashingAlgorithm _algorithm;

        public override bool IsValid(object? value) =>
             HashValidation.Validate(Transformation.MakeValidString(value), _algorithm);

        public override string FormatErrorMessage(string name) =>
            string.Format(CultureInfo.CurrentCulture, "The field is not a valid md5 hash.");
    }
}