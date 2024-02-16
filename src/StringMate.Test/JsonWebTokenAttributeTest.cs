// using System.ComponentModel.DataAnnotations;
// using StringMate.ValidationRules.Enums;
// using StringMate.DataAnnotations;
// using StringMate.Test.StringValidation.TestData;
//
// namespace StringMate.Test.StringValidation.DataAnnotations;
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