namespace StringMate.Test.Warden.TestData;

public class MongoIdData
{
    public static readonly string[] Valid =
    [
        "507f1f77bcf86cd799439011",
        "657906348f7d2ec2dd44f414"
    ];

    public static readonly string[] Invalid =
    [
        "507f1f77bcf86cd7994390",
        "507f1f77bcf86cd79943901z",
        "",
        "507f1f77bcf86cd799439011 "
    ];
}