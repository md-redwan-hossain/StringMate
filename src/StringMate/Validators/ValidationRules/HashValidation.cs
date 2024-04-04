using System.ComponentModel;
using System.Text.RegularExpressions;
using StringMate.Enums;

namespace StringMate.Validators.ValidationRules
{
    internal static class HashValidation
    {
        private static readonly Regex Md5Regex = RegexMaker(Md5Length);
        private static readonly Regex Md4Regex = RegexMaker(Md4Length);
        private static readonly Regex Sha1Regex = RegexMaker(Sha1Length);
        private static readonly Regex Sha256Regex = RegexMaker(Sha256Length);
        private static readonly Regex Sha384Regex = RegexMaker(Sha384Length);
        private static readonly Regex Sha512Regex = RegexMaker(Sha512Length);
        private static readonly Regex RipeMd128Regex = RegexMaker(RipeMd128Length);
        private static readonly Regex RipeMd160Regex = RegexMaker(RipeMd160Length);
        private static readonly Regex Tiger128Regex = RegexMaker(Tiger128Length);
        private static readonly Regex Tiger160Regex = RegexMaker(Tiger160Length);
        private static readonly Regex Tiger192Regex = RegexMaker(Tiger192Length);
        private static readonly Regex Crc32Regex = RegexMaker(Crc32Length);
        private static readonly Regex Crc32BRegex = RegexMaker(Crc32BLength);

        private const byte Md5Length = 32;
        private const byte Md4Length = 32;
        private const byte Sha1Length = 40;
        private const byte Sha256Length = 64;
        private const byte Sha384Length = 96;
        private const byte Sha512Length = 128;
        private const byte RipeMd128Length = 32;
        private const byte RipeMd160Length = 40;
        private const byte Tiger128Length = 32;
        private const byte Tiger160Length = 40;
        private const byte Tiger192Length = 48;
        private const byte Crc32Length = 8;
        private const byte Crc32BLength = 8;
        
        internal static bool Validate(string value, HashingAlgorithm algorithm)
        {
            return algorithm switch
            {
                HashingAlgorithm.Md4 => Md4Regex.IsMatch(value),
                HashingAlgorithm.Md5 => Md5Regex.IsMatch(value),
                HashingAlgorithm.Sha1 => Sha1Regex.IsMatch(value),
                HashingAlgorithm.Sha256 => Sha256Regex.IsMatch(value),
                HashingAlgorithm.Sha384 => Sha384Regex.IsMatch(value),
                HashingAlgorithm.Sha512 => Sha512Regex.IsMatch(value),
                HashingAlgorithm.RipeMd128 => RipeMd128Regex.IsMatch(value),
                HashingAlgorithm.RipeMd160 => RipeMd160Regex.IsMatch(value),
                HashingAlgorithm.Tiger128 => Tiger128Regex.IsMatch(value),
                HashingAlgorithm.Tiger160 => Tiger160Regex.IsMatch(value),
                HashingAlgorithm.Tiger192 => Tiger192Regex.IsMatch(value),
                HashingAlgorithm.Crc32 => Crc32Regex.IsMatch(value),
                HashingAlgorithm.Crc32B => Crc32BRegex.IsMatch(value),
                _ => throw new InvalidEnumArgumentException()
            };
        }
        
        private static Regex RegexMaker(byte size) => new Regex($"^[a-fA-F0-9]{{{size}}}$");
    }
}