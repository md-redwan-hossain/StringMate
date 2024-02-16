using Shouldly;
using StringMate.Test.TestData;
using Xunit;

namespace StringMate.Test;

public class SlugTest
{
    [Fact]
    public void IsSlug() =>
        SlugData.Valid.All(StrWarden.IsSlug).ShouldBeTrue();

    [Fact]
    public void IsNotSlug() =>
        SlugData.Invalid.All(StrWarden.IsSlug).ShouldBeFalse();
}