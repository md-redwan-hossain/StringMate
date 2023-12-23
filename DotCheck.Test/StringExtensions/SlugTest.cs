using DotCheck.StringValidation.StringExtensions;

namespace DotCheck.Test.StringExtensions;

public class SlugTest
{
    private readonly string[] _valid =
    {
        "foo",
        "foo-bar",
        "foo_bar",
        "foo-bar-foo",
        "foo-bar_foo",
        "foo-bar_foo*75-b4r-**_foo",
        "foo-bar_foo*75-b4r-**_foo-&&"
    };

    private readonly string[] _invalid =
    {
        "not-----------slug",
        "@#_$@",
        "-not-slug",
        "not-slug-",
        "_not-slug",
        "not-slug_",
        "not slug"
    };

    [Fact]
    public void IsSlug() =>
        Assert.True(_valid.All(x => x.IsSlug()));

    [Fact]
    public void IsNotSlug() =>
        Assert.False(_invalid.All(x => x.IsSlug()));
}