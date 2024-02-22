using System.ComponentModel.DataAnnotations;
using Shouldly;
using StringMate.Enums;
using StringMate.Test.Warden.TestData;
using StringMate.Validation.DataAnnotations;
using Xunit;

namespace StringMate.Test.Warden;

public class UuidTest
{
    [Fact]
    public void V1Check()
    {
        Validation.Warden.IsUuid(UuidData.V1, UuidVersion.V1).ShouldBeTrue();

        var validationContext = new ValidationContext(UuidData.V1);
        var attribute = new UuidAttribute(UuidVersion.V1);
        var validationResult = attribute.GetValidationResult(UuidData.V1, validationContext);
        validationResult.ShouldBe(ValidationResult.Success);
    }

    [Fact]
    public void V2Check() =>
        Validation.Warden.IsUuid(UuidData.V2, UuidVersion.V2).ShouldBeTrue();

    [Fact]
    public void V3Check() =>
        Validation.Warden.IsUuid(UuidData.V3, UuidVersion.V3).ShouldBeTrue();

    [Fact]
    public void V4Check() =>
        Validation.Warden.IsUuid(UuidData.V4, UuidVersion.V4).ShouldBeTrue();

    [Fact]
    public void V5Check() =>
        Validation.Warden.IsUuid(UuidData.V5, UuidVersion.V5).ShouldBeTrue();

    [Fact]
    public void AllCheck() =>
        CheckAll().ShouldBeTrue();

    [Fact]
    public void NotUuidCheck() =>
        Validation.Warden.IsUuid("1", UuidVersion.V4).ShouldBeFalse();

    private static bool CheckAll()
    {
        var storage = new[] { UuidData.V1, UuidData.V2, UuidData.V3, UuidData.V4, UuidData.V5 };
        return storage.All(x => Validation.Warden.IsUuid(x, UuidVersion.All));
    }
}