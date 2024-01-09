using DotCheck.Test.StringValidation.TestData;

namespace DotCheck.Test.StringValidation;

public class MongoIdTest
{
    [Fact]
    public void IsJwt() =>
        MongoIdData.Valid.All(x =>
            Instance.DotCheckStringValidationInstance.IsMongoId(x)).ShouldBeTrue();

    [Fact]
    public void IsNotJwt() =>
        MongoIdData.Invalid.All(x =>
            Instance.DotCheckStringValidationInstance.IsMongoId(x)).ShouldBeFalse();
}