using StringMate.ShapeShifters;

namespace StringMate.Test.ShapeShifters;

public class HtmlFriendlyTransformationTest
{
    [Fact]
    public void Escape()
    {
        const string test = """<script> alert("xss&fun"); </script>""";
        const string target = "&lt;script&gt; alert(&quot;xss&amp;fun&quot;); &lt;&#x2F;script&gt;";
        HtmlFriendlyTransformation.Sanitize(test).ShouldBe(target);
    }


    [Fact]
    public void UnEscape()
    {
        const string target = """<script> alert("xss&fun"); </script>""";
        const string test = "&lt;script&gt; alert(&quot;xss&amp;fun&quot;); &lt;&#x2F;script&gt;";
        HtmlFriendlyTransformation.UnSanitize(test).ShouldBe(target);
    }
}