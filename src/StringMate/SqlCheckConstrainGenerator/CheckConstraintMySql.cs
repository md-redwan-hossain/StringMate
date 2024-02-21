namespace StringMate.SqlCheckConstrainGenerator
{
    public class CheckConstraintMySql : CheckConstraintBase
    {
        protected override string PreserveCase(string text) => $"`{text}`";
    }
}