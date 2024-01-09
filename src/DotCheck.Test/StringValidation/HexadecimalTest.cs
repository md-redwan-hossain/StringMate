using DotCheck.Test.StringValidation.TestData;

namespace DotCheck.Test.StringValidation;

public class HexadecimalTest
{
    [Fact]
    public void IsHexadecimal() =>
        HexadecimalData.Valid.All(x => 
            Instance.DotCheckStringValidationInstance.IsHexadecimal(x)).ShouldBeTrue();

    [Fact]
    public void IsNotHexadecimal() =>
        HexadecimalData.Invalid.All(x => 
            Instance.DotCheckStringValidationInstance.IsHexadecimal(x)).ShouldBeFalse();
}