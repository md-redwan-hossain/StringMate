using DotCheck.StringValidation.CoreValidators;
using DotCheck.StringValidation.CoreValidators.Enums;

namespace DotCheck.StringValidation
{
    public static class DotCheckStringValidation
    {
         public static bool Is12HourTime(string text, bool includeSecond) =>
             TimeOf12HourValidation.Validate(text, includeSecond);

         public static bool Is24HourTime(string text, bool includeSecond) =>
             TimeOf24HourValidation.Validate(text, includeSecond);

         public static bool IsHash(string text, HashingAlgorithm algorithm) =>
              HashValidation.Validate(text, algorithm);

         public static bool IsSlug(string text) =>
              SlugValidation.Validate(text);

         public static bool IsMongoId(string text) =>
              MongoIdValidation.Validate(text);

         public static bool IsUuid(string text, UuidVersion version) =>
              UuidValidation.Validate(text, version);

         public static bool IsJwt(string text) =>
              JsonWebTokenValidation.Validate(text);

         public static bool IsBase64(string text, bool checkUrlSafety) =>
              Base64Validation.Validate(text, checkUrlSafety);

         public static bool IsHexadecimal(string text) =>
             HexadecimalValidation.Validate(text);
    }
}