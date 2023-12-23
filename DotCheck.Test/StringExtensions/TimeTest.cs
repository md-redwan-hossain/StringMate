using DotCheck.StringValidation.StringExtensions;

namespace DotCheck.Test.StringExtensions;

public class TimeTest
{
    [Fact]
    public void IsTimeDefault() =>
        Assert.True(TimeOnly.FromDateTime(DateTime.Now).ToString().IsTime());

    [Fact]
    public void IsTime12HourWithoutSecond() =>
        Assert.True(TimeOnly.FromDateTime(DateTime.Now)
            .ToShortTimeString().IsTime(useHour24: false, useSecond: false));

    [Fact]
    public void IsTime12HourWithSecond() =>
        Assert.True(TimeOnly.FromDateTime(DateTime.Now)
            .ToLongTimeString().IsTime(useHour24: false, useSecond: true));

    [Fact]
    public void IsTime24HourWithoutSecond() =>
        Assert.True(TimeOnly.FromDateTime(DateTime.Now)
            .ToString("HH:mm").IsTime(useHour24: true, useSecond: false));

    [Fact]
    public void IsTime24HourWithSecond() =>
        Assert.True(TimeOnly.FromDateTime(DateTime.Now)
            .ToString("HH:mm:ss").IsTime(useHour24: true, useSecond: true));
}