namespace DotCheck.Exception;

public class WhiteSpaceOnlyStringException: System.Exception
{
    public WhiteSpaceOnlyStringException() : base("The provided string contains only whitespace.")
    {
    }
}