namespace DotCheck.Test.StringValidation.TestData;

public static class HexadecimalData
{
    public static readonly string[] Valid =
    {
        "deadBEEF",
        "ff0044",
        "0xff0044",
        "0XfF0044",
        "0x0123456789abcDEF",
        "0X0123456789abcDEF",
        "0hfedCBA9876543210",
        "0HfedCBA9876543210",
        "0123456789abcDEF"
    };

    public static readonly string[] Invalid =
    {
        "abcdefg",
        "",
        "..",
        "0xa2h",
        "0xa20x",
        "0x0123456789abcDEFq",
        "0hfedCBA9876543210q",
        "01234q56789abcDEF"
    };
}