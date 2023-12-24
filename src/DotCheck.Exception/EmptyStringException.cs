namespace DotCheck.Exception;

public class EmptyStringException: System.Exception
{
    public EmptyStringException() : base("The provided value is an empty string.")
    {
    }
}