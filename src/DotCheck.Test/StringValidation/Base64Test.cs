using DotCheck.StringValidation.StringExtensions;
using DotCheck.Test.StringValidation.TestData;

namespace DotCheck.Test.StringValidation;

public class Base64Test
{
    [Fact]
    public void IsBase64WithUrlSafetyCheck() =>
        Base64Data.ValidUrlSafe.All(x => x.DotCheck()
            .IsBase64(checkUrlSafety: true)).ShouldBeTrue();

    [Fact]
    public void IsNotBase64WithUrlSafetyCheck() =>
        Base64Data.InvalidUrlSafe.All(x => x.DotCheck()
            .IsBase64(checkUrlSafety: true)).ShouldBeFalse();

    [Fact]
    public void IsBase64WithoutUrlSafetyCheck() =>
        Base64Data.Valid.All(x => x.DotCheck()
            .IsBase64(checkUrlSafety: false)).ShouldBeTrue();

    [Fact]
    public void IsNotBase64WithoutUrlSafetyCheck() =>
        Base64Data.Invalid.All(x => x.DotCheck()
            .IsBase64(checkUrlSafety: false)).ShouldBeFalse();
}