using System.Text.RegularExpressions;
using DotCheck.StringValidation.CoreValidators.Interfaces;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.CoreValidators;

public class SlugValidation : IValidation
{
    private static readonly Regex CharsetRegex =
        new(@"^[^\s-_](?!.*?[-_]{2,})[a-z0-9-\\][^\s]*[^-_\s]$");

    public bool Validate(object? value) =>
        CharsetRegex.IsMatch(Transformation.MakeValidString(value));
}