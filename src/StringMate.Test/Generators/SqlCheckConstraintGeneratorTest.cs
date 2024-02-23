using StringMate.Enums;
using StringMate.Generators;

namespace StringMate.Test.Generators;

public class SqlCheckConstraintGeneratorTest
{
    [Fact]
    public void InCheck_String()
    {
        var cc = new SqlCheckConstrainGenerator(RelationalDatabase.PostgreSql, delimitStringGlobal: false);
        const string sql = "JobTitle IN ('Design Engineer', 'Tool Designer')";
        var testSql = cc.In("JobTitle", ["Design Engineer", "Tool Designer"]);
        testSql.ShouldBe(sql);
    }

    [Fact]
    public void BetweenCheck_String_GlobalDelimitFalse()
    {
        var cc = new SqlCheckConstrainGenerator(RelationalDatabase.MySql, delimitStringGlobal: false);
        const string sql = "buy_price BETWEEN 90 AND 100";
        var testSql = cc.Between("buy_price", 90, 100);
        testSql.ShouldBe(sql);
    }

    [Fact]
    public void BetweenCheck_String_MethodDelimitTrue()
    {
        var cc = new SqlCheckConstrainGenerator(RelationalDatabase.MySql, delimitStringGlobal: false);
        const string sql = "`buy_price` BETWEEN 90 AND 100";
        var testSql = cc.Between("buy_price", 90, 100, delimitColumnName: true);
        testSql.ShouldBe(sql);
    }

    [Fact]
    public void GreaterThanCheck_String_As_Value()
    {
        var cc = new SqlCheckConstrainGenerator(RelationalDatabase.MySql);
        const string sql = "`sell_price` > 100";
        var testSql = cc.GreaterThan("sell_price", 100);
        testSql.ShouldBe(sql);
    }

    [Fact]
    public void GreaterThanCheck_String_As_Column_DelimitLeftOperand()
    {
        var cc = new SqlCheckConstrainGenerator(RelationalDatabase.MySql);
        const string sql = "sell_price > `buy_price`";
        var testSql = cc.GreaterThan("sell_price", "buy_price", SqlOperandType.Column, delimitLeftOperand: false);
        testSql.ShouldBe(sql);
    }
}