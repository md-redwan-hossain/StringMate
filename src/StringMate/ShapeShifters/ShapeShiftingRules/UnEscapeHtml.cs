using System.Text;

namespace StringMate.ShapeShifters.ShapeShiftingRules
{
    internal static class UnEscapeHtml
    {
        public static string Transform(string text)
        {
            var sb = new StringBuilder(text);

            sb.Replace("&quot;", "\"");
            sb.Replace("&#x27;", "'");
            sb.Replace("&lt;", "<");
            sb.Replace("&gt;", ">");
            sb.Replace("&#x2F;", "/");
            sb.Replace("&#x5C;", "\\");
            sb.Replace("&#96;", "`");
            sb.Replace("&amp;", "&");

            return sb.ToString();
        }
    }
}