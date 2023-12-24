namespace DotCheck.Exception;

[Serializable]
public class NotStringException : System.Exception
{
    public NotStringException() : base("The provided value is not a string.")
    {
    }
}