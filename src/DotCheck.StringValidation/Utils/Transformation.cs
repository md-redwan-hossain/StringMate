using DotCheck.StringValidation.Exceptions;

namespace DotCheck.StringValidation.Utils;

public static class Transformation
{
    public static string MakeValidString(object? value)
    {
        if (value is string castedValue)
        {
            return Assert.IsEmptyString(castedValue) ? "" : castedValue.Trim();
        }
        
        throw new NotStringException();
    }
}