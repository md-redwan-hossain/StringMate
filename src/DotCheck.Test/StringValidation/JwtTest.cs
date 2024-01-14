using DotCheck.Test.StringValidation.TestData;
using DotCheck.StringValidation;
using Shouldly;
using Xunit;

namespace DotCheck.Test.StringValidation
{
    public class JwtTest
    {
        [Fact]
        public void IsJwt() =>
            JwtData.Valid.All(DotCheckStringValidation.IsJwt).ShouldBeTrue();

        [Fact]
        public void IsNotJwt() =>
            JwtData.Invalid.All(DotCheckStringValidation.IsJwt).ShouldBeFalse();
    }
}