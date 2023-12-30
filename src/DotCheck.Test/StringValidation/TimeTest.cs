using DotCheck.StringValidation.StringExtensions;
using DotCheck.Test.StringValidation.TestData;

namespace DotCheck.Test.StringValidation;

public class TimeTest
{
    [Fact]
    public void IsTime12HourWithoutSecond() =>
        TimeData.Time12HourWithoutSecond
            .Is12HourTime(includeSecond: false).ShouldBeTrue();

    [Fact]
    public void IsTime12HourWithSecond() =>
        TimeData.Time12HourWithSecond
            .Is12HourTime(includeSecond: true).ShouldBeTrue();

    [Fact]
    public void IsTime24HourWithoutSecond() =>
        TimeData.Time24HourWithoutSecond
            .Is24HourTime(includeSecond: false).ShouldBeTrue();

    [Fact]
    public void IsTime24HourWithSecond() =>
        TimeData.Time24HourWithSecond
            .Is24HourTime(includeSecond: true).ShouldBeTrue();
}