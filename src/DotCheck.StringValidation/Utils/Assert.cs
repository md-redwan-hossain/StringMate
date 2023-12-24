namespace DotCheck.StringValidation.Utils;

public static class Assert
{
    public static bool IsString(object? data) =>
        data is string;

    public static bool IsWhiteSpaceOnlyString(string text) =>
        text.Trim().Length == 0;

    public static bool IsEmptyString(string text) =>
        text == string.Empty;
}