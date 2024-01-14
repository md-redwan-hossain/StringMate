using DotCheck.Test.StringValidation.TestData;
using DotCheck.StringValidation;
using Shouldly;
using Xunit;

namespace DotCheck.Test.StringValidation
{
    public class HexadecimalTest
    {
        [Fact]
        public void IsHexadecimal() =>
            HexadecimalData.Valid.All(DotCheckStringValidation.IsHexadecimal).ShouldBeTrue();

        [Fact]
        public void IsNotHexadecimal() =>
            HexadecimalData.Invalid.All(DotCheckStringValidation.IsHexadecimal).ShouldBeFalse();
    }
}