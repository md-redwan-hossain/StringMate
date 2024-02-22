using System;

namespace StringMate.Validators.ValidationRules
{
    internal static class JsonWebTokenValidation
    {
        internal static bool Validate(string value)
        {
            var dotSeparated = value.Split('.');

            return dotSeparated.Length == 3 &&
                   Array.TrueForAll(dotSeparated, 
                       x => Base64Validation.Validate(x, checkUrlSafety: true));
        }
    }
}