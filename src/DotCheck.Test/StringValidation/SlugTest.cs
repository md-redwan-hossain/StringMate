using DotCheck.Test.StringValidation.TestData;

namespace DotCheck.Test.StringValidation;

public class SlugTest
{
    [Fact]
    public void IsSlug() =>
        SlugData.Valid.All(x =>
            Instance.DotCheckStringValidationInstance.IsSlug(x)).ShouldBeTrue();

    [Fact]
    public void IsNotSlug() =>
        SlugData.Invalid.All(x =>
            Instance.DotCheckStringValidationInstance.IsSlug(x)).ShouldBeFalse();
}