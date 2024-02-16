namespace StringMate.Enums
{
    public enum HashingAlgorithm : byte
    {
        Md5 = 32,
        Md4 = 32,
        Sha1 = 40,
        Sha256 = 64,
        Sha384 = 96,
        Sha512 = 128,
        RipeMd128 = 32,
        RipeMd160 = 40,
        Tiger128 = 32,
        Tiger160 = 40,
        Tiger192 = 48,
        Crc32 = 8,
        Crc32B = 8
    }
}