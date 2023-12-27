using System.Text.RegularExpressions;
using DotCheck.StringValidation.CoreValidators.Interfaces;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.CoreValidators;

public class Base64Validation : IValidation
{
    private static readonly Regex NotBase64Regex =
        new("[^A-Z0-9+\\/=]", RegexOptions.IgnoreCase);

    private static readonly Regex UrlSafeBase64Regex =
        new("^[A-Z0-9_\\-]*$", RegexOptions.IgnoreCase);

    public bool Validate(object? value)
    {
        var validString = Transformation.MakeValidString(value);
        return SharedValidation(validString);
    }

    public bool Validate(object? value, bool checkUrlSafety)
    {
        var validString = Transformation.MakeValidString(value);

        return checkUrlSafety
            ? UrlSafeBase64Regex.IsMatch(validString)
            : SharedValidation(validString);
    }

    private bool SharedValidation(string validString)
    {
        var length = validString.Length;
        if (length % 4 != 0 || NotBase64Regex.IsMatch(validString)) return false;

        var firstPaddingChar = validString.IndexOf('=');

        return firstPaddingChar == -1 || firstPaddingChar == length - 1 ||
               (firstPaddingChar == length - 2 && validString[length - 1] == '=');
    }
}