namespace DotCheck.StringValidation.Core;

public static class JsonWebTokenValidation 
{
    public static bool IsJsonWebToken(this IDotCheckStringValidation lib, string value)
    {
        var dotSeparated = value.Split('.');

        return dotSeparated.Length == 3 && dotSeparated
            .All(x => lib.IsBase64(x, checkUrlSafety: true));
    }
}