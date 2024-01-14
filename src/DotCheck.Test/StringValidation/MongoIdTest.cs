using DotCheck.Test.StringValidation.TestData;
using DotCheck.StringValidation;
using Shouldly;
using Xunit;

namespace DotCheck.Test.StringValidation
{
    public class MongoIdTest
    {
        [Fact]
        public void IsJwt() =>
            MongoIdData.Valid.All(DotCheckStringValidation.IsMongoId).ShouldBeTrue();

        [Fact]
        public void IsNotJwt() =>
            MongoIdData.Invalid.All(DotCheckStringValidation.IsMongoId).ShouldBeFalse();
    }
}