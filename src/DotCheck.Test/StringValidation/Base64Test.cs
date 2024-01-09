using DotCheck.Test.StringValidation.TestData;

namespace DotCheck.Test.StringValidation;

public class Base64Test
{
    [Fact]
    public void IsBase64WithUrlSafetyCheck() =>
        Base64Data.ValidUrlSafe.All(x => Instance.DotCheckStringValidationInstance
            .IsBase64(x, checkUrlSafety: true)).ShouldBeTrue();

    [Fact]
    public void IsNotBase64WithUrlSafetyCheck() =>
        Base64Data.InvalidUrlSafe.All(x => Instance.DotCheckStringValidationInstance
            .IsBase64(x, checkUrlSafety: true)).ShouldBeFalse();

    [Fact]
    public void IsBase64WithoutUrlSafetyCheck() =>
        Base64Data.Valid.All(x => Instance.DotCheckStringValidationInstance
            .IsBase64(x, checkUrlSafety: false)).ShouldBeTrue();

    [Fact]
    public void IsNotBase64WithoutUrlSafetyCheck() =>
        Base64Data.Invalid.All(x => Instance.DotCheckStringValidationInstance
            .IsBase64(x, checkUrlSafety: false)).ShouldBeFalse();
}