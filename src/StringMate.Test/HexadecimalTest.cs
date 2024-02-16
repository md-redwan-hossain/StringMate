using Shouldly;
using StringMate.Test.TestData;
using Xunit;

namespace StringMate.Test;

public class HexadecimalTest
{
    [Fact]
    public void IsHexadecimal() =>
        HexadecimalData.Valid.All(StrWarden.IsHexadecimal).ShouldBeTrue();

    [Fact]
    public void IsNotHexadecimal() =>
        HexadecimalData.Invalid.All(StrWarden.IsHexadecimal).ShouldBeFalse();
}