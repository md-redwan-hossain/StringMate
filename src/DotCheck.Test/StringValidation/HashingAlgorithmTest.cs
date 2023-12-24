using System.ComponentModel.DataAnnotations;
using DotCheck.StringValidation.DataAnnotations;
using DotCheck.StringValidation.StringExtensions;
using DotCheck.Test.StringValidation.TestData;

namespace DotCheck.Test.StringValidation;

public class HashingAlgorithmTest
{
    [Fact]
    public void IsMd5() =>
        HashAlgorithmData.ValidMd5.All(x => x.IsMd5()).ShouldBeTrue();

    [Fact]
    public void IsMd5ForAttribute()
    {
        foreach (var x in HashAlgorithmData.ValidMd5)
        {
            var validationContext = new ValidationContext(x);
            new Md5Attribute().GetValidationResult(x, validationContext)
                .ShouldBe(ValidationResult.Success);
        }
    }


    [Fact]
    public void IsNotMd5()
    {
        HashAlgorithmData.InvalidMd5.All(x => x.IsMd5()).ShouldBeFalse();

        foreach (var x in HashAlgorithmData.InvalidMd5)
        {
            var validationContext = new ValidationContext(x);
            new Md5Attribute().GetValidationResult(x, validationContext)
                .ShouldNotBe(ValidationResult.Success);
        }
    }

    [Fact]
    public void IsSha256() =>
        HashAlgorithmData.ValidSha256.All(x => x.IsSha256()).ShouldBeTrue();

    [Fact]
    public void IsNotSha256() =>
        HashAlgorithmData.InvalidSha256.All(x => x.IsSha256()).ShouldBeFalse();

    [Fact]
    public void IsSha512() =>
        HashAlgorithmData.ValidSha512.All(x => x.IsSha512()).ShouldBeTrue();

    [Fact]
    public void IsNotSha512() =>
        HashAlgorithmData.InvalidSha512.All(x => x.IsSha512()).ShouldBeFalse();
}