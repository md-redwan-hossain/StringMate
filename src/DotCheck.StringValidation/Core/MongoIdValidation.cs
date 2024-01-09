using DotCheck.StringValidation.Utils;

namespace DotCheck.StringValidation.Core;

public static class MongoIdValidation
{
    public static bool IsMongoId(this IDotCheckStringValidation lib, string value)
    {
        var validString = Transformation.MakeValidString(value);
        return lib.IsHexadecimal(validString) && validString.Length == 24;
    }
}