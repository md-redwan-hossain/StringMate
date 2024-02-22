using StringMate.Enums;
using StringMate.Generators;

namespace StringMate.Test.Generators;

public class SqlCheckConstraintGeneratorTest
{
    [Fact]
    public void InCheck_String()
    {
        var cc = new SqlCheckConstrainGenerator(RelationalDatabase.PostgreSql, preserveCase: false);
        const string sql = "JobTitle IN ('Design Engineer', 'Tool Designer')";
        var testSql = cc.In("JobTitle", ["Design Engineer", "Tool Designer"]);
        testSql.ShouldBe(sql);
    }

    [Fact]
    public void BetweenCheck_String()
    {
        var cc = new SqlCheckConstrainGenerator(RelationalDatabase.MySql, preserveCase: false);
        const string sql = "buy_price BETWEEN 90 AND 100";
        var testSql = cc.Between("buy_price", 90, 100);
        testSql.ShouldBe(sql);
    }
}