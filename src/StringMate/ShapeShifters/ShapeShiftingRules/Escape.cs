using System.Text;

namespace StringMate.ShapeShifters.ShapeShiftingRules
{
    internal static class Escape
    {
        public static string Transform(string text)
        {
            var sb = new StringBuilder(text);

            sb.Replace("&", "&amp;");
            sb.Replace("\"", "&quot;");
            sb.Replace("'", "&#x27;");
            sb.Replace("<", "&lt;");
            sb.Replace(">", "&gt;");
            sb.Replace("/", "&#x2F;");
            sb.Replace("`", "&#96;");

            return sb.ToString();
        }
    }
}