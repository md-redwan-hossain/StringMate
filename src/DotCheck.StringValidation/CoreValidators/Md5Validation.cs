using DotCheck.StringValidation.CoreValidators.Abstracts;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.CoreValidators;

public class Md5Validation : HashValidation, IValidation
{
    public bool Validate(object? value) =>
        Md5Regex.IsMatch(Transformation.MakeValidString(value));
}