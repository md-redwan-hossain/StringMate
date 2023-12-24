namespace DotCheck.Test.StringValidation.TestData;

public static class TimeData
{
    public static readonly string Default =
        TimeOnly.FromDateTime(DateTime.Now).ToString();

    public static readonly string Time12HourWithoutSecond =
        TimeOnly.FromDateTime(DateTime.Now).ToShortTimeString();

    public static readonly string Time12HourWithSecond =
        TimeOnly.FromDateTime(DateTime.Now).ToLongTimeString();

    public static readonly string Time24HourWithoutSecond =
        TimeOnly.FromDateTime(DateTime.Now).ToString("HH:mm");

    public static readonly string Time24HourWithSecond =
        TimeOnly.FromDateTime(DateTime.Now).ToString("HH:mm:ss");
}