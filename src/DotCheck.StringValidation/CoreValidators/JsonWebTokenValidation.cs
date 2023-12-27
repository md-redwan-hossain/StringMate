using DotCheck.StringValidation.CoreValidators.Interfaces;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.CoreValidators;

public class JsonWebTokenValidation : IValidation
{
    public bool Validate(object? value)
    {
        var validString = Transformation.MakeValidString(value);

        var dotSeparated = validString.Split('.');

        if (dotSeparated.Length != 3) return false;

        return dotSeparated.All(x => new Base64Validation().Validate(x, true));
    }
}