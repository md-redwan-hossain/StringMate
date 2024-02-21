namespace StringMate.SqlCheckConstrainGenerator
{
    public class CheckConstraintPg : CheckConstraintBase
    {
        protected override string PreserveCase(string text) => $"\"{text}\"";
    }
}