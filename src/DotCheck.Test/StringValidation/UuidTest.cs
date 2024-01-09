using System.ComponentModel.DataAnnotations;
using DotCheck.StringValidation.Core.Enums;
using DotCheck.StringValidation.DataAnnotations;
using DotCheck.Test.StringValidation.TestData;

namespace DotCheck.Test.StringValidation;

public class UuidTest
{
    [Fact]
    public void V1Check()
    {
        Instance.DotCheckStringValidationInstance
            .IsUuid(UuidData.V1, UuidVersion.V1)
            .ShouldBeTrue();

        var validationContext = new ValidationContext(UuidData.V1);
        var attribute = new UuidAttribute(UuidVersion.V1);
        var validationResult = attribute.GetValidationResult(UuidData.V1, validationContext);
        validationResult.ShouldBe(ValidationResult.Success);
    }

    [Fact]
    public void V2Check() =>
        Instance.DotCheckStringValidationInstance
            .IsUuid(UuidData.V2, UuidVersion.V2)
            .ShouldBeTrue();


    [Fact]
    public void V3Check() =>
        Instance.DotCheckStringValidationInstance
            .IsUuid(UuidData.V3, UuidVersion.V3)
            .ShouldBeTrue();

    [Fact]
    public void V4Check() =>
        Instance.DotCheckStringValidationInstance
            .IsUuid(UuidData.V4, UuidVersion.V4)
            .ShouldBeTrue();

    [Fact]
    public void V5Check() =>
        Instance.DotCheckStringValidationInstance
            .IsUuid(UuidData.V5, UuidVersion.V5)
            .ShouldBeTrue();

    [Fact]
    public void AllCheck() =>
        CheckAll().ShouldBeTrue();

    [Fact]
    public void NotUuidCheck() =>
        Instance.DotCheckStringValidationInstance
            .IsUuid("1", UuidVersion.V1)
            .ShouldBeFalse();


    private static bool CheckAll()
    {
        var lib = Instance.DotCheckStringValidationInstance;

        var storage = new[] { UuidData.V1, UuidData.V2, UuidData.V3, UuidData.V4, UuidData.V5 };
        return storage.All(x => lib.IsUuid(x, UuidVersion.All));
    }
}