using System;

namespace DotCheck.StringValidation.Exceptions
{
    [Serializable]
    public class NotStringException : Exception
    {
        public NotStringException() : base("The provided value is not a string.")
        {
        }
    }
}