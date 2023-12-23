using System.Text.RegularExpressions;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.CoreValidators;

public class Md5Validation : IValidation
{
    private static readonly Regex Md5Regex = new("^[a-fA-F0-9]{32}$");

    public bool Validate(object? value) =>
        Md5Regex.IsMatch(Transformation.MakeValidString(value));
}