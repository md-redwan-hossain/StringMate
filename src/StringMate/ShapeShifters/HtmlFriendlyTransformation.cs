using StringMate.ShapeShifters.ShapeShiftingRules;

namespace StringMate.ShapeShifters
{
    public static class HtmlFriendlyTransformation
    {
        public static string Sanitize(string text) =>
            Escape.Transform(text);

        public static string UnSanitize(string text) =>
            UnEscape.Transform(text);
    }
}