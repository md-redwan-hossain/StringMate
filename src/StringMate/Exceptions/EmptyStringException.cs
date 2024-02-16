using System;

namespace StringMate.Exceptions
{
    public class EmptyStringException: Exception
    {
        public EmptyStringException() : base("The provided value is an empty string.")
        {
        }
    }
}