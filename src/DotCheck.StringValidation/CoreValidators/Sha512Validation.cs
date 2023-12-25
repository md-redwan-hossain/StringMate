using DotCheck.StringValidation.CoreValidators.Abstracts;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.CoreValidators;

public class Sha512Validation : HashValidation, IValidation
{
    public bool Validate(object? value) =>
        Sha512Regex.IsMatch(Transformation.MakeValidString(value));
}