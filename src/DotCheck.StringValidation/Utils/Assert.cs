namespace DotCheck.StringValidation.Utils
{
    internal static class Assert
    {
        internal static bool IsString(object? data) =>
            data is string;

        internal static bool IsWhiteSpaceOnlyString(string text) =>
            text.Trim().Length == 0;

        internal static bool IsEmptyString(string text) =>
            text == string.Empty;
    }
}