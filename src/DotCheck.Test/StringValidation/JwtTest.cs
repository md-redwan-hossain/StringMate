using DotCheck.Test.StringValidation.TestData;

namespace DotCheck.Test.StringValidation;

public class JwtTest
{
    [Fact]
    public void IsJwt() =>
        JwtData.Valid.All(x =>
            Instance.DotCheckStringValidationInstance.IsJsonWebToken(x)).ShouldBeTrue();

    [Fact]
    public void IsNotJwt() =>
        JwtData.Invalid.All(x =>
            Instance.DotCheckStringValidationInstance.IsJsonWebToken(x)).ShouldBeFalse();
}