using System.Linq;

namespace DotCheck.StringValidation.CoreValidators
{
    internal static class JsonWebTokenValidation
    {
        internal static bool Validate(string value)
        {
            var dotSeparated = value.Split('.');

            return dotSeparated.Length == 3 &&
                   dotSeparated.All(x => Base64Validation.Validate(x, checkUrlSafety: true));
        }
    }
}