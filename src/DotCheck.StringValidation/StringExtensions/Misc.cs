using DotCheck.StringValidation.CoreValidators;
using DotCheck.StringValidation.CoreValidators.Enums;

namespace DotCheck.StringValidation.StringExtensions;

public static class Misc
{
    public static bool IsHash(this string text, HashingAlgorithm algo) =>
        new HashValidation().Validate(text, algo);
    
    public static bool IsSlug(this string text) =>
        new SlugValidation().Validate(text);
    
    public static bool IsMongoId(this string text) =>
        new MongoIdValidation().Validate(text);

    public static bool IsUuid(this string text) =>
        new UuidValidation().Validate(text);

    public static bool IsUuid(this string text, UuidVersion version) =>
        new UuidValidation().Validate(text, version);
}