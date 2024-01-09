using DotCheck.StringValidation.CoreValidators.Interfaces;
using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.CoreValidators;

public class MongoIdValidation : IValidation
{
    public bool Validate(string value)
    {
        var validString = Transformation.MakeValidString(value);
        return new HexadecimalValidation().Validate(validString) && validString.Length == 24;
    }
}