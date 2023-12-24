// using System.ComponentModel.DataAnnotations;
// using DotCheck.StringValidation.CoreValidators.Enums;
// using DotCheck.StringValidation.DataAnnotations;
// using DotCheck.Test.StringValidation.TestData;
//
// namespace DotCheck.Test.StringValidation.DataAnnotations;
//
// public class JsonWebTokenAttributeTest
// {
//     [Theory]
//     [InlineData(JwtData)]
//     public void V1Test(object input)
//     {
//         //Arrange
//         var validationContext = new ValidationContext(input);
//
//         //Act
//         var attribute = new UuidAttribute(UuidVersion.V1);
//         var validationResult = attribute.GetValidationResult(input, validationContext);
//
//         //Assert
//         validationResult.ShouldBe(ValidationResult.Success);
//     }
// }