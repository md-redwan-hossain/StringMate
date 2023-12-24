using DotCheck.StringValidation.StringExtensions;
using DotCheck.Test.StringValidation.TestData;

namespace DotCheck.Test.StringValidation;

public class TimeTest
{
    [Fact]
    public void IsTimeDefault() =>
        TimeData.Default.IsTime().ShouldBeTrue();

    [Fact]
    public void IsTime12HourWithoutSecond() =>
        TimeData.Time12HourWithoutSecond
            .IsTime(use24HourClock: false, useSecond: false).ShouldBeTrue();

    [Fact]
    public void IsTime12HourWithSecond() =>
        TimeData.Time12HourWithSecond
            .IsTime(use24HourClock: false, useSecond: true).ShouldBeTrue();

    [Fact]
    public void IsTime24HourWithoutSecond() =>
        TimeData.Time24HourWithoutSecond
            .IsTime(use24HourClock: true, useSecond: false).ShouldBeTrue();

    [Fact]
    public void IsTime24HourWithSecond() =>
        TimeData.Time24HourWithSecond
            .IsTime(use24HourClock: true, useSecond: true).ShouldBeTrue();
}