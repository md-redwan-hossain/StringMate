using StringMate.Test.Validators.TestData;

namespace StringMate.Test.Validators;

public class MongoIdTest
{
    [Fact]
    public void IsJwt() =>
        MongoIdData.Valid.All(StringMate.Validators.StringValidation.IsMongoId).ShouldBeTrue();

    [Fact]
    public void IsNotJwt() =>
        MongoIdData.Invalid.All(StringMate.Validators.StringValidation.IsMongoId).ShouldBeFalse();
}