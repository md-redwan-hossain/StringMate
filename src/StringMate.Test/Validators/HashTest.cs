using StringMate.Enums;
using StringMate.Test.Validators.TestData;
using StringMate.Validators;

namespace StringMate.Test.Validators;

public class HashTest
{
    [Fact]
    public void IsMd5() =>
        HashData.ValidMd5.All(x => StringValidation.IsHash(x, HashingAlgorithm.Md5)).ShouldBeTrue();

    [Fact]
    public void IsSha256() =>
        HashData.ValidSha256.All(x => StringValidation.IsHash(x, HashingAlgorithm.Sha256)).ShouldBeTrue();

    [Fact]
    public void IsSha512() =>
        HashData.ValidSha512.All(x => StringValidation.IsHash(x, HashingAlgorithm.Sha512)).ShouldBeTrue();
}