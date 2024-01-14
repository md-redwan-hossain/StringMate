using System;

namespace DotCheck.StringValidation.Exceptions
{
    public class WhiteSpaceOnlyStringException: Exception
    {
        public WhiteSpaceOnlyStringException() : base("The provided string contains only whitespace.")
        {
        }
    }
}