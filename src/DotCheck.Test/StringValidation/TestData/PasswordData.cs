namespace DotCheck.Test.StringValidation.TestData;

public static class PasswordData
{
    public static readonly string[] Valid =
    [
        // """%2%k{7BsL"M%Kd6e""",
        "EXAMPLE of very long_password123!",
        "mxH_+2vs&54_+H3P",
        "+&DxJ=X7-4L8jRCD",
        "etV*p%Nr6w&H%FeF",
        "£3.ndSau_7"
    ];

    public static readonly string[] Invalid =
    [
        "",
        "password",
        "hunter2",
        "hello world",
        "passw0rd",
        "password!",
        "PASSWORD!"
    ];

    public const string SuperStrong = "123456ABCDefg!@#$%^&*()";
}