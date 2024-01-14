using DotCheck.Test.StringValidation.TestData;
using DotCheck.StringValidation;
using Shouldly;
using Xunit;

namespace DotCheck.Test.StringValidation
{
    public class SlugTest
    {
        [Fact]
        public void IsSlug() =>
            SlugData.Valid.All(DotCheckStringValidation.IsSlug).ShouldBeTrue();

        [Fact]
        public void IsNotSlug() =>
            SlugData.Invalid.All(DotCheckStringValidation.IsSlug).ShouldBeFalse();
    }
}