using StringMate.Test.Validators.TestData;

namespace StringMate.Test.Validators;

public class JwtTest
{
    [Fact]
    public void IsJwt() =>
        JwtData.Valid.All(StringMate.Validators.StringValidation.IsJwt).ShouldBeTrue();

    [Fact]
    public void IsNotJwt() =>
        JwtData.Invalid.All(StringMate.Validators.StringValidation.IsJwt).ShouldBeFalse();
}