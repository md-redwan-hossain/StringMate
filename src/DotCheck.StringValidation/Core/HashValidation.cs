using System.ComponentModel;
using System.Text.RegularExpressions;
using DotCheck.StringValidation.Core.Enums;

namespace DotCheck.StringValidation.Core;

public static class HashValidation
{
    private static readonly Regex Md5Regex = RegexMaker(HashingAlgorithm.Md5);
    private static readonly Regex Md4Regex = RegexMaker(HashingAlgorithm.Md4);
    private static readonly Regex Sha1Regex = RegexMaker(HashingAlgorithm.Sha1);
    private static readonly Regex Sha256Regex = RegexMaker(HashingAlgorithm.Sha256);
    private static readonly Regex Sha384Regex = RegexMaker(HashingAlgorithm.Sha384);
    private static readonly Regex Sha512Regex = RegexMaker(HashingAlgorithm.Sha512);
    private static readonly Regex RipeMd128Regex = RegexMaker(HashingAlgorithm.RipeMd128);
    private static readonly Regex RipeMd160Regex = RegexMaker(HashingAlgorithm.RipeMd160);
    private static readonly Regex Tiger128Regex = RegexMaker(HashingAlgorithm.Tiger128);
    private static readonly Regex Tiger160Regex = RegexMaker(HashingAlgorithm.Tiger160);
    private static readonly Regex Tiger192Regex = RegexMaker(HashingAlgorithm.Tiger192);
    private static readonly Regex Crc32Regex = RegexMaker(HashingAlgorithm.Crc32);
    private static readonly Regex Crc32BRegex = RegexMaker(HashingAlgorithm.Crc32B);
    
    private static Regex RegexMaker(HashingAlgorithm algorithm) =>
        new($"^[a-fA-F0-9]{{{(byte)algorithm}}}$");

    public static bool IsHash(this IDotCheckStringValidation _, string value, HashingAlgorithm algorithm)
        => algorithm.ToString() switch
        {
            nameof(HashingAlgorithm.Md4) => Md4Regex.IsMatch(value),
            nameof(HashingAlgorithm.Md5) => Md5Regex.IsMatch(value),
            nameof(HashingAlgorithm.Sha1) => Sha1Regex.IsMatch(value),
            nameof(HashingAlgorithm.Sha256) => Sha256Regex.IsMatch(value),
            nameof(HashingAlgorithm.Sha384) => Sha384Regex.IsMatch(value),
            nameof(HashingAlgorithm.Sha512) => Sha512Regex.IsMatch(value),
            nameof(HashingAlgorithm.RipeMd128) => RipeMd128Regex.IsMatch(value),
            nameof(HashingAlgorithm.RipeMd160) => RipeMd160Regex.IsMatch(value),
            nameof(HashingAlgorithm.Tiger128) => Tiger128Regex.IsMatch(value),
            nameof(HashingAlgorithm.Tiger160) => Tiger160Regex.IsMatch(value),
            nameof(HashingAlgorithm.Tiger192) => Tiger192Regex.IsMatch(value),
            nameof(HashingAlgorithm.Crc32) => Crc32Regex.IsMatch(value),
            nameof(HashingAlgorithm.Crc32B) => Crc32BRegex.IsMatch(value),
            _ => throw new InvalidEnumArgumentException()
        };
}