using Shouldly;
using StringMate.Test.Warden.TestData;
using Xunit;

namespace StringMate.Test.Warden;

public class HexadecimalTest
{
    [Fact]
    public void IsHexadecimal() =>
        HexadecimalData.Valid.All(Validation.Warden.IsHexadecimal).ShouldBeTrue();

    [Fact]
    public void IsNotHexadecimal() =>
        HexadecimalData.Invalid.All(Validation.Warden.IsHexadecimal).ShouldBeFalse();
}