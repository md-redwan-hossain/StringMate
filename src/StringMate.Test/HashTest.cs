// using System.ComponentModel.DataAnnotations;
// using StringMate.DataAnnotations;
// using StringMate.StringExtensions;
// using StringMate.Test.StringValidation.TestData;
//
// namespace StringMate.Test.StringValidation;
//
// public class HashTest
// {
//     [Fact]
//     public void IsMd5() =>
//         HashData.ValidMd5.All(x => x.IsMd5()).ShouldBeTrue();
//
//     [Fact]
//     public void IsMd5ForAttribute()
//     {
//         foreach (var x in HashData.ValidMd5)
//         {
//             var validationContext = new ValidationContext(x);
//             new Md5Attribute().GetValidationResult(x, validationContext)
//                 .ShouldBe(ValidationResult.Success);
//         }
//     }
//
//
//     [Fact]
//     public void IsNotMd5()
//     {
//         HashData.InvalidMd5.All(x => x.IsMd5()).ShouldBeFalse();
//
//         foreach (var x in HashData.InvalidMd5)
//         {
//             var validationContext = new ValidationContext(x);
//             new Md5Attribute().GetValidationResult(x, validationContext)
//                 .ShouldNotBe(ValidationResult.Success);
//         }
//     }
//
//     [Fact]
//     public void IsSha256() =>
//         HashData.ValidSha256.All(x => x.IsSha256()).ShouldBeTrue();
//
//     [Fact]
//     public void IsNotSha256() =>
//         HashData.InvalidSha256.All(x => x.IsSha256()).ShouldBeFalse();
//
//     [Fact]
//     public void IsSha512() =>
//         HashData.ValidSha512.All(x => x.IsSha512()).ShouldBeTrue();
//
//     [Fact]
//     public void IsNotSha512() =>
//         HashData.InvalidSha512.All(x => x.IsSha512()).ShouldBeFalse();
// }