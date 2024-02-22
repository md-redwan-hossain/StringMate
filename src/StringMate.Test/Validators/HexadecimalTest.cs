using StringMate.Test.Validators.TestData;

namespace StringMate.Test.Validators;

public class HexadecimalTest
{
    [Fact]
    public void IsHexadecimal() =>
        HexadecimalData.Valid.All(StringMate.Validators.StringValidation.IsHexadecimal).ShouldBeTrue();

    [Fact]
    public void IsNotHexadecimal() =>
        HexadecimalData.Invalid.All(StringMate.Validators.StringValidation.IsHexadecimal).ShouldBeFalse();
}