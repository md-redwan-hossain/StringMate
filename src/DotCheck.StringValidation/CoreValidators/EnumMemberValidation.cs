using System;

namespace DotCheck.StringValidation.CoreValidators
{
    internal static class EnumMemberValidation
    {
        internal static bool Validate<TEnum>(string value) =>
            Enum.IsDefined(typeof(TEnum), value);
    }
}