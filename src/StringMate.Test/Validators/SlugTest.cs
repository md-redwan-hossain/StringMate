using StringMate.Test.Validators.TestData;

namespace StringMate.Test.Validators;

public class SlugTest
{
    [Fact]
    public void IsSlug() =>
        SlugData.Valid.All(StringMate.Validators.StringValidation.IsSlug).ShouldBeTrue();

    [Fact]
    public void IsNotSlug() =>
        SlugData.Invalid.All(StringMate.Validators.StringValidation.IsSlug).ShouldBeFalse();
}