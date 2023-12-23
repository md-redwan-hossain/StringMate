using DotCheck.StringValidation.StringExtensions;

namespace DotCheck.Test.StringExtensions;

public class HexadecimalTest
{
    private readonly string[] _valid =
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

    private readonly string[] _invalid =
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


    [Fact]
    public void IsHexadecimal() =>
        Assert.True(_valid.All(x => x.IsHexadecimal()));

    [Fact]
    public void IsNotHexadecimal() =>
        Assert.False(_invalid.All(x => x.IsHexadecimal()));
}