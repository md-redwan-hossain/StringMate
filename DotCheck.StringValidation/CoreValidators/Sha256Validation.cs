using System.Text.RegularExpressions;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.CoreValidators;

public class Sha256Validation : IValidation
{
    private static readonly Regex Sha256Regex = new("^[a-fA-F0-9]{64}$");

    public bool Validate(object? value) =>
        Sha256Regex.IsMatch(Transformation.MakeValidString(value));
}