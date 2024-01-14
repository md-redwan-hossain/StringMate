using System;

namespace DotCheck.StringValidation.Exceptions
{
    public class EmptyStringException: Exception
    {
        public EmptyStringException() : base("The provided value is an empty string.")
        {
        }
    }
}