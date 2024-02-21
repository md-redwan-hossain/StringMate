using Shouldly;
using StringMate.Test.Warden.TestData;
using Xunit;

namespace StringMate.Test.Warden;

public class SlugTest
{
    [Fact]
    public void IsSlug() =>
        SlugData.Valid.All(Validation.Warden.IsSlug).ShouldBeTrue();

    [Fact]
    public void IsNotSlug() =>
        SlugData.Invalid.All(Validation.Warden.IsSlug).ShouldBeFalse();
}