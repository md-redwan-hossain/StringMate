namespace DotCheck.Test.StringValidation.TestData
{
    public class SlugData
    {
        public static readonly string[] Valid =
        [
            "foo",
            "foo-bar",
            "foo_bar",
            "foo-bar-foo",
            "foo-bar_foo",
            "foo-bar_foo*75-b4r-**_foo",
            "foo-bar_foo*75-b4r-**_foo-&&"
        ];

        public static readonly string[] Invalid =
        [
            "not-----------slug",
            "@#_$@",
            "-not-slug",
            "not-slug-",
            "_not-slug",
            "not-slug_",
            "not slug"
        ];
    }
}