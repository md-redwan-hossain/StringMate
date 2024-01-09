namespace DotCheck.StringValidation.StringExtensions;

public static class Scaffold
{
    public static IDotCheckStringValidation DotCheck(this string text) =>
        new DotCheckStringValidation(text);
}