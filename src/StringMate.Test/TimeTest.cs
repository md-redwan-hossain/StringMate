using Shouldly;
using StringMate.Test.TestData;
using Xunit;

namespace StringMate.Test;

public class TimeTest
{
    [Fact]
    public void IsTime12HourWithoutSecond() =>
        StrWarden.Is12HourTime
            (TimeData.Time12HourWithoutSecond, includeSecond: false).ShouldBeTrue();

    [Fact]
    public void IsTime12HourWithSecond() =>
        StrWarden.Is12HourTime
            (TimeData.Time12HourWithSecond, includeSecond: true).ShouldBeTrue();

    [Fact]
    public void IsTime24HourWithoutSecond() =>
        StrWarden.Is24HourTime
            (TimeData.Time24HourWithoutSecond, includeSecond: false).ShouldBeTrue();

    [Fact]
    public void IsTime24HourWithSecond() =>
        StrWarden.Is24HourTime
            (TimeData.Time24HourWithSecond, includeSecond: true).ShouldBeTrue();
}