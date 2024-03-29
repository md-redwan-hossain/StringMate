using StringMate.Enums;
using StringMate.Validators.ValidationRules;

namespace StringMate.Validators
{
    public static class StringValidation
    {
        public static bool IsStrongPassword(string text, int minLength = 8, int minLowercase = 1,
            int minUppercase = 1, int minNumbers = 1, int minSymbols = 1, int minUniqueChars = 0) =>
            StrongPasswordValidation.Validate(text, minLength, minLowercase,
                minUppercase, minNumbers, minSymbols, minUniqueChars);

        public static bool IsEnumMember<TEnum>(string text) =>
            EnumMemberValidation.Validate<TEnum>(text);

        public static bool IsDate(string text, string dateFormat) =>
            DateValidation.Validate(text, dateFormat);

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