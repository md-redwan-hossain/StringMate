using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.StringExtensions;

public static class EncodingBased
{
    public static bool IsJwt(this string text) =>
        new JsonWebTokenValidation().Validate(text);
    
    public static bool IsBase64(this string text) =>
        new Base64Validation().Validate(text);

    public static bool IsBase64(this string text, bool checkUrlSafety) =>
        new Base64Validation().Validate(text, checkUrlSafety);
}