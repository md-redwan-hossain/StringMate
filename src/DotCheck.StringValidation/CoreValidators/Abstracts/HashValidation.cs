using System.Text.RegularExpressions;

namespace DotCheck.StringValidation.CoreValidators.Abstracts;

public abstract class HashValidation
{
    protected static readonly Regex Md5Regex = RegexMaker(HashingAlgorithm.Md5);
    protected static readonly Regex Md4Regex = RegexMaker(HashingAlgorithm.Md4);
    protected static readonly Regex Sha1Regex = RegexMaker(HashingAlgorithm.Sha1);
    protected static readonly Regex Sha256Regex = RegexMaker(HashingAlgorithm.Sha256);
    protected static readonly Regex Sha384Regex = RegexMaker(HashingAlgorithm.Sha384);
    protected static readonly Regex Sha512Regex = RegexMaker(HashingAlgorithm.Sha512);
    protected static readonly Regex Ripemd128Regex = RegexMaker(HashingAlgorithm.Ripemd128);
    protected static readonly Regex Ripemd160Regex = RegexMaker(HashingAlgorithm.Ripemd160);
    protected static readonly Regex Tiger128Regex = RegexMaker(HashingAlgorithm.Tiger128);
    protected static readonly Regex Tiger160Regex = RegexMaker(HashingAlgorithm.Tiger160);
    protected static readonly Regex Tiger192Regex = RegexMaker(HashingAlgorithm.Tiger192);
    protected static readonly Regex Crc32Regex = RegexMaker(HashingAlgorithm.Crc32);
    protected static readonly Regex Crc32bRegex = RegexMaker(HashingAlgorithm.Crc32b);

    private static Regex RegexMaker(HashingAlgorithm hashingAlgorithm) =>
        new($"^[a-fA-F0-9]{{{(byte)hashingAlgorithm}}}$");
    
    private enum HashingAlgorithm : byte
    {
        Md5 = 32,
        Md4 = 32,
        Sha1 = 40,
        Sha256 = 64,
        Sha384 = 96,
        Sha512 = 128,
        Ripemd128 = 32,
        Ripemd160 = 40,
        Tiger128 = 32,
        Tiger160 = 40,
        Tiger192 = 48,
        Crc32 = 8,
        Crc32b = 8
    }
    
    
}