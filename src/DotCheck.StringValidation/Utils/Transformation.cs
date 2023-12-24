using DotCheck.Exception;

namespace DotCheck.StringValidation.Utils;

public static class Transformation
{
    public static string MakeValidString(object? value)
    {
        if (value is not string castedValue)
            throw new NotStringException();

        return Assert.IsEmptyString(castedValue) ? "" : castedValue.Trim();
    }
}