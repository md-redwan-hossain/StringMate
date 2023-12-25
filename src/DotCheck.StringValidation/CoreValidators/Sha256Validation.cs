using DotCheck.StringValidation.CoreValidators.Abstracts;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.CoreValidators;

public class Sha256Validation : HashValidation, IValidation
{
    public bool Validate(object? value) =>
        Sha256Regex.IsMatch(Transformation.MakeValidString(value));
}