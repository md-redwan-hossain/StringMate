namespace DotCheck.Exception;

[Serializable]
public class NotAStringException : System.Exception
{
    public NotAStringException() : base("The provided value is not a string.")
    {
    }
}