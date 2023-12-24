using DotCheck.StringValidation.CoreValidators;

namespace DotCheck.StringValidation.StringExtensions;

public static class HashingAlgorithm
{
    public static bool IsMd5(this string text) =>
        new Md5Validation().Validate(text);

    public static bool IsSha256(this string text) =>
        new Sha256Validation().Validate(text);

    public static bool IsSha512(this string text) =>
        new Sha512Validation().Validate(text);
}