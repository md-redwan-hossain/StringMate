using System.Security.Cryptography;
using System.Text;
using DotCheck.StringValidation;
using DotCheck.StringValidation.StringExtensions;
using HashAlgorithm = System.Security.Cryptography.HashAlgorithm;

namespace DotCheck.Test.StringExtensions;

public class HashAlgorithmTest
{
    private const string InputString = "Hello DotCheck";

    [Fact]
    public void Md5Check() =>
        Assert.True(CalculateHash(InputString, MD5.Create()).IsMd5());

    [Fact]
    public void Sha256Check() =>
        Assert.True(CalculateHash(InputString, SHA256.Create()).IsSha256());


    [Fact]
    public void Sha512Check() =>
        Assert.True(CalculateHash(InputString, SHA512.Create()).IsSha512());

    private static string CalculateHash(string input, HashAlgorithm algorithm)
    {
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = algorithm.ComputeHash(inputBytes);

        var hashStringBuilder = new StringBuilder();

        foreach (var b in hashBytes)
            hashStringBuilder.Append(b.ToString("x2"));

        return hashStringBuilder.ToString();
    }
}