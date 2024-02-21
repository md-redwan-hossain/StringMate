namespace StringMate.Validation.ValidationRules
{
    internal static class MongoIdValidation
    {
        internal static bool Validate(string value) =>
            HexadecimalValidation.Validate(value) && value.Length == 24;
    }
}