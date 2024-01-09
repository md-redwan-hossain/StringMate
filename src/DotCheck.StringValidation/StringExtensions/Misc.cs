using DotCheck.StringValidation.CoreValidators;
using DotCheck.StringValidation.CoreValidators.Enums;

namespace DotCheck.StringValidation.StringExtensions;

public static class Misc
{
    public static bool IsHash(this IDotCheckStringValidation instance, HashingAlgorithm algo) =>
        new HashValidation().Validate(instance.TextDataForValidation, algo);

    public static bool IsSlug(this IDotCheckStringValidation instance) =>
        new SlugValidation().Validate(instance.TextDataForValidation);

    public static bool IsMongoId(this IDotCheckStringValidation instance) =>
        new MongoIdValidation().Validate(instance.TextDataForValidation);

    public static bool IsUuid(this IDotCheckStringValidation instance, UuidVersion version) =>
        new UuidValidation().Validate(instance.TextDataForValidation, version);
}