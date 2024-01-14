using System.ComponentModel.DataAnnotations;
using DotCheck.StringValidation.CoreValidators.Enums;
using DotCheck.StringValidation.DataAnnotations;
using DotCheck.Test.StringValidation.TestData;
using Shouldly;
using Xunit;

namespace DotCheck.Test.StringValidation
{
    public class UuidAttributeTest
    {
        [Theory]
        [InlineData(UuidData.V1)]
        public void V1Test(object input)
        {
            //Arrange
            var validationContext = new ValidationContext(input);

            //Act
            var attribute = new UuidAttribute(UuidVersion.V1);
            var validationResult = attribute.GetValidationResult(input, validationContext);

            //Assert
            validationResult.ShouldBe(ValidationResult.Success);
        }

        [Theory]
        [InlineData(UuidData.V2)]
        public void V2Test(object input)
        {
            //Arrange
            var validationContext = new ValidationContext(input);

            //Act
            var attribute = new UuidAttribute(UuidVersion.V2);
            var validationResult = attribute.GetValidationResult(input, validationContext);

            //Assert
            validationResult.ShouldBe(ValidationResult.Success);
        }


        [Theory]
        [InlineData(UuidData.V3)]
        public void V3Test(object input)
        {
            //Arrange
            var validationContext = new ValidationContext(input);

            //Act
            var attribute = new UuidAttribute(UuidVersion.V3);
            var validationResult = attribute.GetValidationResult(input, validationContext);

            //Assert
            validationResult.ShouldBe(ValidationResult.Success);
        }

        [Theory]
        [InlineData(UuidData.V4)]
        public void V4Test(object input)
        {
            //Arrange
            var validationContext = new ValidationContext(input);

            //Act
            var attribute = new UuidAttribute(UuidVersion.V4);
            var validationResult = attribute.GetValidationResult(input, validationContext);

            //Assert
            validationResult.ShouldBe(ValidationResult.Success);
        }


        [Theory]
        [InlineData(UuidData.V5)]
        public void V5Test(object input)
        {
            //Arrange
            var validationContext = new ValidationContext(input);

            //Act
            var attribute = new UuidAttribute(UuidVersion.V5);
            var validationResult = attribute.GetValidationResult(input, validationContext);

            //Assert
            validationResult.ShouldBe(ValidationResult.Success);
        }


        [Theory]
        [InlineData(UuidData.V1)]
        [InlineData(UuidData.V2)]
        [InlineData(UuidData.V3)]
        [InlineData(UuidData.V4)]
        [InlineData(UuidData.V5)]
        public void AllTest(object input)
        {
            //Arrange
            var validationContext = new ValidationContext(input);

            //Act
            var attribute = new UuidAttribute(UuidVersion.All);
            var validationResult = attribute.GetValidationResult(input, validationContext);

            //Assert
            validationResult.ShouldBe(ValidationResult.Success);
        }


        [Theory]
        [InlineData("1")]
        public void NotUuid(object input)
        {
            //Arrange
            var validationContext = new ValidationContext(input);

            //Act
            var attribute = new UuidAttribute(UuidVersion.V4);
            var validationResult = attribute.GetValidationResult(input, validationContext);

            //Assert
            validationResult.ShouldNotBe(ValidationResult.Success);
        }
    }
}