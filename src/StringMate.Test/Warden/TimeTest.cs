using Shouldly;
using StringMate.Test.Warden.TestData;
using Xunit;

namespace StringMate.Test.Warden;

public class TimeTest
{
    [Fact]
    public void IsTime12HourWithoutSecond() =>
        Validation.Warden.Is12HourTime
            (TimeData.Time12HourWithoutSecond, includeSecond: false).ShouldBeTrue();

    [Fact]
    public void IsTime12HourWithSecond() =>
        Validation.Warden.Is12HourTime
            (TimeData.Time12HourWithSecond, includeSecond: true).ShouldBeTrue();

    [Fact]
    public void IsTime24HourWithoutSecond() =>
        Validation.Warden.Is24HourTime
            (TimeData.Time24HourWithoutSecond, includeSecond: false).ShouldBeTrue();

    [Fact]
    public void IsTime24HourWithSecond() =>
        Validation.Warden.Is24HourTime
            (TimeData.Time24HourWithSecond, includeSecond: true).ShouldBeTrue();
}