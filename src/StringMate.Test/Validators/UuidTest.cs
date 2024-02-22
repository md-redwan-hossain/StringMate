using System.ComponentModel.DataAnnotations;
using StringMate.Enums;
using StringMate.Test.Validators.TestData;
using StringMate.Validators.DataAnnotations;

namespace StringMate.Test.Validators;

public class UuidTest
{
    [Fact]
    public void V1Check()
    {
        StringMate.Validators.StringValidation.IsUuid(UuidData.V1, UuidVersion.V1).ShouldBeTrue();

        var validationContext = new ValidationContext(UuidData.V1);
        var attribute = new UuidAttribute(UuidVersion.V1);
        var validationResult = attribute.GetValidationResult(UuidData.V1, validationContext);
        validationResult.ShouldBe(ValidationResult.Success);
    }

    [Fact]
    public void V2Check() =>
        StringMate.Validators.StringValidation.IsUuid(UuidData.V2, UuidVersion.V2).ShouldBeTrue();

    [Fact]
    public void V3Check() =>
        StringMate.Validators.StringValidation.IsUuid(UuidData.V3, UuidVersion.V3).ShouldBeTrue();

    [Fact]
    public void V4Check() =>
        StringMate.Validators.StringValidation.IsUuid(UuidData.V4, UuidVersion.V4).ShouldBeTrue();

    [Fact]
    public void V5Check() =>
        StringMate.Validators.StringValidation.IsUuid(UuidData.V5, UuidVersion.V5).ShouldBeTrue();

    [Fact]
    public void AllCheck() =>
        CheckAll().ShouldBeTrue();

    [Fact]
    public void NotUuidCheck() =>
        StringMate.Validators.StringValidation.IsUuid("1", UuidVersion.V4).ShouldBeFalse();

    private static bool CheckAll()
    {
        var storage = new[] { UuidData.V1, UuidData.V2, UuidData.V3, UuidData.V4, UuidData.V5 };
        return storage.All(x => StringMate.Validators.StringValidation.IsUuid(x, UuidVersion.All));
    }
}