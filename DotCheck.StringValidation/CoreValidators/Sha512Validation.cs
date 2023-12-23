using System.Text.RegularExpressions;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.CoreValidators;

public class Sha512Validation : IValidation
{
    private static readonly Regex Sha512Regex = new("^[a-fA-F0-9]{128}$");

    public bool Validate(object? value) =>
        Sha512Regex.IsMatch(Transformation.MakeValidString(value));
}