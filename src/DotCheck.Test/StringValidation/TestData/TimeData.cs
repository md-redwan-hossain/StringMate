namespace DotCheck.Test.StringValidation.TestData
{
    public static class TimeData
    {
        public static readonly string Time12HourWithoutSecond =
            DateTime.Now.ToString("h:mm tt");

        public static readonly string Time12HourWithSecond =
           DateTime.Now.ToString("h:mm:ss tt");

        public static readonly string Time24HourWithoutSecond =
            TimeOnly.FromDateTime(DateTime.Now).ToString("HH:mm");

        public static readonly string Time24HourWithSecond =
            TimeOnly.FromDateTime(DateTime.Now).ToString("HH:mm:ss");
    }
}