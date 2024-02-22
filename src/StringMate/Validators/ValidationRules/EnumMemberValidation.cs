using System;

namespace StringMate.Validators.ValidationRules
{
    internal static class EnumMemberValidation
    {
        internal static bool Validate<TEnum>(string value) =>
            Enum.IsDefined(typeof(TEnum), value);
    }
}