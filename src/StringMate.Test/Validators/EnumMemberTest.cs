namespace StringMate.Test.Validators;

public class EnumMemberTest
{
    [Fact]
    public void IsEnumMember() =>
        StringMate.Validators.StringValidation.IsEnumMember<DayOfWeek>("Sunday").ShouldBeTrue();

    [Fact]
    public void IsNotEnumMember() =>
        StringMate.Validators.StringValidation.IsEnumMember<DayOfWeek>("NoDay").ShouldBeFalse();
}