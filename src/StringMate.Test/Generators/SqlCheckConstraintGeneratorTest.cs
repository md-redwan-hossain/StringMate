using StringMate.Enums;
using StringMate.Generators;

namespace StringMate.Test.Generators;

public class SqlCheckConstraintGeneratorTest
{
    [Fact]
    public void InStringCheck()
    {
        var cc = new SqlCheckConstrainGenerator(RelationalDatabase.PostgreSql, preserveCase: false);
        const string sql = "JobTitle IN ('Design Engineer', 'Tool Designer')";
        var testSql = cc.In("JobTitle", ["Design Engineer", "Tool Designer"]);
        testSql.ShouldBe(sql);
    }
}