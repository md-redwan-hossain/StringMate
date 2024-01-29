using DotCheck.StringValidation;
using Shouldly;
using Xunit;

namespace DotCheck.Test.StringValidation;

public class EnumMemberTest
{
    [Fact]
    public void IsEnumMember() =>
        DotCheckStringValidation.IsEnumMember<DayOfWeek>("Sunday").ShouldBeTrue();

    [Fact]
    public void IsNotEnumMember() =>
        DotCheckStringValidation.IsEnumMember<DayOfWeek>("NoDay").ShouldBeFalse();
}