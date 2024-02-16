using System.ComponentModel.DataAnnotations;
using Shouldly;
using StringMate.DataAnnotations;
using StringMate.Test.TestData;
using Xunit;

namespace StringMate.Test;

public class StrongPasswordTest
{
    [Fact]
    public void IsStrongPassword() =>
        PasswordData.Valid.All(x => StrWarden.IsStrongPassword(x)).ShouldBeTrue();

    [Fact]
    public void IsNotStrongPassword() =>
        PasswordData.Invalid.All(x => StrWarden.IsStrongPassword(x)).ShouldBeFalse();

    [Fact]
    public void IsStrongPasswordManualData() =>
        StrWarden
            .IsStrongPassword(PasswordData.SuperStrong, minLength: 20, minUniqueChars: 10, minLowercase: 3,
                minUppercase: 4, minNumbers: 5, minSymbols: 5)
            .ShouldBeTrue();

    [Fact]
    public void IsStrongPasswordAttribute()
    {
        foreach (var item in PasswordData.Valid)
        {
            var validationContext = new ValidationContext(item);
            new StrongPasswordAttribute().GetValidationResult(item, validationContext)
                .ShouldBe(ValidationResult.Success);
        }
    }


    [Fact]
    public void IsNotStrongPasswordAttribute()
    {
        foreach (var item in PasswordData.Invalid)
        {
            var validationContext = new ValidationContext(item);
            new StrongPasswordAttribute().GetValidationResult(item, validationContext)
                .ShouldNotBe(ValidationResult.Success);
        }
    }


    [Fact]
    public void IsStrongPasswordAttributeManualData()
    {
        var validationContext = new ValidationContext(PasswordData.SuperStrong);
        new StrongPasswordAttribute(minLength: 20, minUniqueChars: 10, minLowercase: 3,
                minUppercase: 4, minNumbers: 5, minSymbols: 5)
            .GetValidationResult(PasswordData.SuperStrong, validationContext)
            .ShouldBe(ValidationResult.Success);
    }
}