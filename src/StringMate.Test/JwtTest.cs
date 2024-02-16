using Shouldly;
using StringMate.Test.TestData;
using Xunit;

namespace StringMate.Test;

public class JwtTest
{
    [Fact]
    public void IsJwt() =>
        JwtData.Valid.All(StrWarden.IsJwt).ShouldBeTrue();

    [Fact]
    public void IsNotJwt() =>
        JwtData.Invalid.All(StrWarden.IsJwt).ShouldBeFalse();
}