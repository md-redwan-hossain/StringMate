using DotCheck.StringValidation.StringExtensions;
using DotCheck.Test.StringValidation.TestData;

namespace DotCheck.Test.StringValidation;

public class JwtTest
{
    [Fact]
    public void IsJwt() =>
        JwtData.Valid.All(x => x.IsJwt()).ShouldBeTrue();

    [Fact]
    public void IsNotJwt() =>
        JwtData.Invalid.All(x => x.IsJwt()).ShouldBeFalse();
}