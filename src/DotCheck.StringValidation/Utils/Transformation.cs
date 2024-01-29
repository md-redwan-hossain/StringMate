using DotCheck.StringValidation.Exceptions;

namespace DotCheck.StringValidation.Utils
{
    internal static class Transformation
    {
        internal static string MakeValidString(object? value)
        {
            if (value is string castedValue)
            {
                return Assert.IsEmptyString(castedValue) ? "" : castedValue;
            }

            throw new NotStringException();
        }
    }
}