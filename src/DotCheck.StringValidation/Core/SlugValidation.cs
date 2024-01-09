using System.Text.RegularExpressions;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.Core;

public static class SlugValidation 
{
    private static readonly Regex CharsetRegex =
        new(@"^[^\s-_](?!.*?[-_]{2,})[a-z0-9-\\][^\s]*[^-_\s]$");

    public static bool IsSlug(this IDotCheckStringValidation _,string value) =>
        CharsetRegex.IsMatch(Transformation.MakeValidString(value));
}