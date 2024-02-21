using Shouldly;
using StringMate.Test.Warden.TestData;
using Xunit;

namespace StringMate.Test.Warden;

public class MongoIdTest
{
    [Fact]
    public void IsJwt() =>
        MongoIdData.Valid.All(Validation.Warden.IsMongoId).ShouldBeTrue();

    [Fact]
    public void IsNotJwt() =>
        MongoIdData.Invalid.All(Validation.Warden.IsMongoId).ShouldBeFalse();
}