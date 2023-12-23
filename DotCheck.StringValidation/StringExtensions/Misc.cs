using DotCheck.StringValidation.CoreValidators;
using DotCheck.StringValidation.CoreValidators.Enums;

namespace DotCheck.StringValidation.StringExtensions;

public static class Misc
{
    public static bool IsTime(this string text) =>
        new TimeValidation().Validate(text);

    public static bool IsTime(this string text, bool useHour24, bool useSecond) =>
        new TimeValidation().Validate(text, useHour24, useSecond);

    public static bool IsJwt(this string text) =>
        new JsonWebTokenValidation().Validate(text);

    public static bool IsSlug(this string text) =>
        new SlugValidation().Validate(text);

    public static bool IsHexadecimal(this string text) =>
        new HexadecimalValidation().Validate(text);

    public static bool IsMongoId(this string text) =>
        new MongoIdValidation().Validate(text);

    public static bool IsUuid(this string text) =>
        new UuidValidation().Validate(text);

    public static bool IsUuid(this string text, UuidVersion version) =>
        new UuidValidation().Validate(text, version);

    public static bool IsBase64(this string text) =>
        new Base64Validation().Validate(text);

    public static bool IsBase64(this string text, bool checkUrlSafety) =>
        new Base64Validation().Validate(text, checkUrlSafety);
}