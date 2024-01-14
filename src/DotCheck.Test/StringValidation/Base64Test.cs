using DotCheck.Test.StringValidation.TestData;
using DotCheck.StringValidation;
using Shouldly;
using Xunit;

namespace DotCheck.Test.StringValidation
{
    public class Base64Test
    {
        [Fact]
        public void IsBase64WithUrlSafetyCheck() =>
            Base64Data.ValidUrlSafe.All(x => DotCheckStringValidation
                .IsBase64(x, checkUrlSafety: true)).ShouldBeTrue();

        [Fact]
        public void IsNotBase64WithUrlSafetyCheck() =>
            Base64Data.InvalidUrlSafe.All(x => DotCheckStringValidation
                .IsBase64(x, checkUrlSafety: true)).ShouldBeFalse();

        [Fact]
        public void IsBase64WithoutUrlSafetyCheck() =>
            Base64Data.Valid.All(x => DotCheckStringValidation
                .IsBase64(x, checkUrlSafety: false)).ShouldBeTrue();

        [Fact]
        public void IsNotBase64WithoutUrlSafetyCheck() =>
            Base64Data.Invalid.All(x => DotCheckStringValidation
                .IsBase64(x, checkUrlSafety: false)).ShouldBeFalse();
    }
}