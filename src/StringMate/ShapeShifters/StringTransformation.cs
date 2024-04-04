using StringMate.ShapeShifters.ShapeShiftingRules;

namespace StringMate.ShapeShifters
{
    public static class StringTransformation
    {
        public static string EscapeHtml(string text) =>
            ShapeShiftingRules.EscapeHtml.Transform(text);

        public static string UnescapeHtml(string text) =>
            UnEscapeHtml.Transform(text);
    }
}