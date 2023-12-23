using DotCheck.StringValidation.StringExtensions;

namespace DotCheck.Test.StringExtensions;

public class MongoIdTest
{
    private readonly string[] _valid =
    {
        "507f1f77bcf86cd799439011",
        "657906348f7d2ec2dd44f414"
    };

    private readonly string[] _invalid =
    {
        "507f1f77bcf86cd7994390",
        "507f1f77bcf86cd79943901z",
        "",
        "507f1f77bcf86cd799439011 "
    };


    [Fact]
    public void IsJwt() =>
        Assert.True(_valid.All(x => x.IsMongoId()));

    [Fact]
    public void IsNotJwt() =>
        Assert.False(_invalid.All(x => x.IsMongoId()));
}