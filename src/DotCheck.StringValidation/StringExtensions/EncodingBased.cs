using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.StringExtensions;

public static class EncodingBased
{
    public static bool IsJwt(this IDotCheckStringValidation instance) =>
        new JsonWebTokenValidation().Validate(instance.TextDataForValidation);

    public static bool IsBase64(this IDotCheckStringValidation instance, bool checkUrlSafety) =>
        new Base64Validation().Validate(instance.TextDataForValidation, checkUrlSafety);
}