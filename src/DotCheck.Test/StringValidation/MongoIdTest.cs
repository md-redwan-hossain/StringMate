using DotCheck.StringValidation.StringExtensions;
using DotCheck.Test.StringValidation.TestData;

namespace DotCheck.Test.StringValidation;

public class MongoIdTest
{
    [Fact]
    public void IsJwt() =>
        MongoIdData.Valid.All(x => x.DotCheck().IsMongoId()).ShouldBeTrue();

    [Fact]
    public void IsNotJwt() =>
        MongoIdData.Invalid.All(x => x.DotCheck().IsMongoId()).ShouldBeFalse();
}