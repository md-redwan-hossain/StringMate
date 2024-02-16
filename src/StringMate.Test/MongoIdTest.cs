using Shouldly;
using StringMate.Test.TestData;
using Xunit;

namespace StringMate.Test;

public class MongoIdTest
{
    [Fact]
    public void IsJwt() =>
        MongoIdData.Valid.All(StrWarden.IsMongoId).ShouldBeTrue();

    [Fact]
    public void IsNotJwt() =>
        MongoIdData.Invalid.All(StrWarden.IsMongoId).ShouldBeFalse();
}