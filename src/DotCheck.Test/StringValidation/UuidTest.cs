using System.ComponentModel.DataAnnotations;
using DotCheck.StringValidation.CoreValidators.Enums;
using DotCheck.StringValidation.DataAnnotations;
using DotCheck.StringValidation.StringExtensions;
using DotCheck.Test.StringValidation.TestData;

namespace DotCheck.Test.StringValidation;

public class UuidTest
{
    [Fact]
    public void V1Check()
    {
        UuidData.V1.IsUuid(UuidVersion.V1).ShouldBeTrue();

        var validationContext = new ValidationContext(UuidData.V1);
        var attribute = new UuidAttribute(UuidVersion.V1);
        var validationResult = attribute.GetValidationResult(UuidData.V1, validationContext);
        validationResult.ShouldBe(ValidationResult.Success);
    }

    [Fact]
    public void V2Check() =>
        UuidData.V2.IsUuid(UuidVersion.V2).ShouldBeTrue();

    [Fact]
    public void V3Check() =>
        UuidData.V3.IsUuid(UuidVersion.V3).ShouldBeTrue();

    [Fact]
    public void V4Check() =>
        UuidData.V4.IsUuid(UuidVersion.V4).ShouldBeTrue();

    [Fact]
    public void V5Check() =>
        UuidData.V5.IsUuid(UuidVersion.V5).ShouldBeTrue();

    [Fact]
    public void AllCheck() =>
        CheckAll().ShouldBeTrue();

    [Fact]
    public void NotUuidCheck() =>
        "1".IsUuid(UuidVersion.V4).ShouldBeFalse();

    private static bool CheckAll()
    {
        var storage = new[] { UuidData.V1, UuidData.V2, UuidData.V3, UuidData.V4, UuidData.V5 };
        return storage.All(x => x.IsUuid(UuidVersion.All));
    }
}