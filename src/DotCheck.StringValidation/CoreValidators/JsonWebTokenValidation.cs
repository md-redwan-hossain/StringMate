using DotCheck.StringValidation.CoreValidators.Interfaces;

namespace DotCheck.StringValidation.CoreValidators;

public class JsonWebTokenValidation : IValidation
{
    public bool Validate(string value)
    {
        var dotSeparated = value.Split('.');

        return dotSeparated.Length == 3 &&
               dotSeparated.All(x => new Base64Validation()
                   .Validate(x, checkUrlSafety: true));
    }
}