using System.ComponentModel.DataAnnotations;
using System.Globalization;
using StringMate.Enums;
using StringMate.Validators.ValidationRules;

namespace StringMate.Validators.DataAnnotations
{
    public class UuidAttribute : ValidationAttribute
    {
        public UuidAttribute() => _version = UuidVersion.All;
        public UuidAttribute(UuidVersion version) => _version = version;

        private readonly UuidVersion _version;

        public override bool IsValid(object? value)
        {
            if (value == null) return true;
            return value is string str && UuidValidation.Validate(str, _version);
        }

        public override string FormatErrorMessage(string name)
        {
            var errorMsg = (_version == UuidVersion.All)
                ? "The field is not a valid uuid."
                : $"The field is not a valid uuid of version {(byte)_version}.";

            return string.Format(CultureInfo.CurrentCulture, errorMsg);
        }
    }
}