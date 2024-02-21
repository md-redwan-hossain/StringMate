using Shouldly;
using Xunit;

namespace StringMate.Test.Warden;

public class EnumMemberTest
{
    [Fact]
    public void IsEnumMember() =>
        Validation.Warden.IsEnumMember<DayOfWeek>("Sunday").ShouldBeTrue();

    [Fact]
    public void IsNotEnumMember() =>
        Validation.Warden.IsEnumMember<DayOfWeek>("NoDay").ShouldBeFalse();
}