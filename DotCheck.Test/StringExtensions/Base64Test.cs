using System.Text;
using DotCheck.StringValidation;
using DotCheck.StringValidation.StringExtensions;

namespace DotCheck.Test.StringExtensions;

public class Base64Test
{
    private const string UrlSafeInputString = "Hello DotCheck";
    private const string UrlUnsafeInputString = "Hello+DotCheck";

    [Fact]
    public void IsBase64WithoutUrlSafetyCheck()
    {
        var storage = new[] { MakeBase64(UrlSafeInputString), MakeBase64(UrlSafeInputString) };
        Assert.True(storage.All(x => x.IsBase64()));
    }

    [Fact]
    public void IsUrlSafeBase64() =>
        Assert.False(MakeBase64(UrlSafeInputString).IsBase64(checkUrlSafety: true));

    [Fact]
    public void IsNotUrlSafeBase64() =>
        Assert.False(MakeBase64(UrlUnsafeInputString).IsBase64(checkUrlSafety: true));

    [Fact]
    public void IsNotBase64() =>
        Assert.False(UrlSafeInputString.IsBase64(true));

    private static string MakeBase64(string text)
    {
        var bytesToEncode = Encoding.UTF8.GetBytes(text);
        return Convert.ToBase64String(bytesToEncode);
    }
}