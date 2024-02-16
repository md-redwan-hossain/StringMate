using Shouldly;
using Xunit;

namespace StringMate.Test;

public class EnumMemberTest
{
    [Fact]
    public void IsEnumMember() =>
        StrWarden.IsEnumMember<DayOfWeek>("Sunday").ShouldBeTrue();

    [Fact]
    public void IsNotEnumMember() =>
        StrWarden.IsEnumMember<DayOfWeek>("NoDay").ShouldBeFalse();
}