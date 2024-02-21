using Shouldly;
using StringMate.Test.Warden.TestData;
using Xunit;

namespace StringMate.Test.Warden;

public class JwtTest
{
    [Fact]
    public void IsJwt() =>
        JwtData.Valid.All(Validation.Warden.IsJwt).ShouldBeTrue();

    [Fact]
    public void IsNotJwt() =>
        JwtData.Invalid.All(Validation.Warden.IsJwt).ShouldBeFalse();
}