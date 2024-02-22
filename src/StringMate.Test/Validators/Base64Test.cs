using StringMate.Test.Validators.TestData;

namespace StringMate.Test.Validators;

public class Base64Test
{
    [Fact]
    public void IsBase64WithUrlSafetyCheck() =>
        Base64Data.ValidUrlSafe.All(x => StringMate.Validators.StringValidation
            .IsBase64(x, checkUrlSafety: true)).ShouldBeTrue();

    [Fact]
    public void IsNotBase64WithUrlSafetyCheck() =>
        Base64Data.InvalidUrlSafe.All(x => StringMate.Validators.StringValidation
            .IsBase64(x, checkUrlSafety: true)).ShouldBeFalse();

    [Fact]
    public void IsBase64WithoutUrlSafetyCheck() =>
        Base64Data.Valid.All(x => StringMate.Validators.StringValidation
            .IsBase64(x, checkUrlSafety: false)).ShouldBeTrue();

    [Fact]
    public void IsNotBase64WithoutUrlSafetyCheck() =>
        Base64Data.Invalid.All(x => StringMate.Validators.StringValidation
            .IsBase64(x, checkUrlSafety: false)).ShouldBeFalse();
}