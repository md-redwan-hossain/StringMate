using StringMate.Enums;
using StringMate.Generators;

namespace StringMate.Test.Generators;

public class SqlCheckConstraintGeneratorTest
{
    [Fact]
    public void TrueStringCheck_String()
    {
        var cc = new SqlCheckConstrainGenerator(RDBMS.PostgreSql, delimitStringGlobalLevel: false);
        var sql = $"address = {bool.TrueString}";
        var testSql = cc.EqualTo("address", true);
        testSql.ShouldBe(sql);
    }
    
    [Fact]
    public void FalseStringCheck_String()
    {
        var cc = new SqlCheckConstrainGenerator(RDBMS.PostgreSql, delimitStringGlobalLevel: false);
        var sql = $"address = {bool.FalseString}";
        var testSql = cc.EqualTo("address", false);
        testSql.ShouldBe(sql);
    }
    
    [Fact]
    public void NotTrueCheck_String()
    {
        var cc = new SqlCheckConstrainGenerator(RDBMS.PostgreSql, delimitStringGlobalLevel: false);
        var sql = $"address <> {bool.TrueString}";
        var testSql = cc.NotEqualTo("address", true);
        testSql.ShouldBe(sql);
    }

    [Fact]
    public void IsNullCheck_String()
    {
        var cc = new SqlCheckConstrainGenerator(RDBMS.PostgreSql, delimitStringGlobalLevel: false);
        const string sql = "address IS NULL";
        var testSql = cc.IsNull("address");
        testSql.ShouldBe(sql);
    }

    [Fact]
    public void IsNotNullCheck_String()
    {
        var cc = new SqlCheckConstrainGenerator(RDBMS.PostgreSql, delimitStringGlobalLevel: false);
        const string sql = "address IS NOT NULL";
        var testSql = cc.IsNotNull("address");
        testSql.ShouldBe(sql);
    }

    [Fact]
    public void InCheck_String()
    {
        var cc = new SqlCheckConstrainGenerator(RDBMS.PostgreSql, delimitStringGlobalLevel: false);
        const string sql = "JobTitle IN ('Design Engineer', 'Tool Designer')";
        var testSql = cc.In("JobTitle", ["Design Engineer", "Tool Designer"]);
        testSql.ShouldBe(sql);
    }

    [Fact]
    public void BetweenCheck_String_GlobalDelimitFalse()
    {
        var cc = new SqlCheckConstrainGenerator(RDBMS.MySql, delimitStringGlobalLevel: false);
        const string sql = "buy_price BETWEEN 90 AND 100";
        var testSql = cc.Between("buy_price", 90, 100);
        testSql.ShouldBe(sql);
    }

    [Fact]
    public void BetweenCheck_String_MethodDelimitTrue()
    {
        var cc = new SqlCheckConstrainGenerator(RDBMS.MySql, delimitStringGlobalLevel: false);
        const string sql = "`buy_price` BETWEEN 90 AND 100";
        var testSql = cc.Between("buy_price", 90, 100, delimitColumnName: true);
        testSql.ShouldBe(sql);
    }

    [Fact]
    public void GreaterThanCheck_String_As_Value()
    {
        var cc = new SqlCheckConstrainGenerator(RDBMS.MySql);
        const string sql = "CHAR_LENGTH(`sell_price`) > 100";
        var testSql = cc.GreaterThan("sell_price", 100, SqlDataType.VarChar);
        testSql.ShouldBe(sql);
    }


    [Fact]
    public void GreaterThanCheck_Int_As_Value()
    {
        var cc = new SqlCheckConstrainGenerator(RDBMS.MySql, StringCase.SnakeCase);
        const string sql = "`sell_price` > 100";
        var testSql = cc.GreaterThan("SellPrice", 100, SqlDataType.Int);
        testSql.ShouldBe(sql);
    }

    [Fact]
    public void GreaterThanCheck_String_As_Column_DelimitLeftOperand()
    {
        var cc = new SqlCheckConstrainGenerator(RDBMS.MySql, StringCase.SnakeCase);
        const string sql = "sell_price > `buy_price`";
        var testSql = cc.GreaterThan("sell_price", "buy_price", SqlOperandType.Column, delimitLeftOperand: false);
        testSql.ShouldBe(sql);
    }
}