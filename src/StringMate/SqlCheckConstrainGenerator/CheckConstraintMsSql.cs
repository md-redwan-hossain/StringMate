namespace StringMate.SqlCheckConstrainGenerator
{
    public class CheckConstraintMsSql : CheckConstraintBase
    {
        protected override string PreserveCase(string text) => $"[{text}]";
    }
}