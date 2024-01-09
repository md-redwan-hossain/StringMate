using DotCheck.Test.StringValidation.TestData;

namespace DotCheck.Test.StringValidation;

public class TimeTest
{
    [Fact]
    public void IsTime12HourWithoutSecond() =>
        Instance.DotCheckStringValidationInstance
            .IsTimeOf12Hour(TimeData.Time12HourWithoutSecond, includeSecond: false)
            .ShouldBeTrue();

    [Fact]
    public void IsTime12HourWithSecond() =>
        Instance.DotCheckStringValidationInstance
            .IsTimeOf12Hour(TimeData.Time12HourWithSecond, includeSecond: true)
            .ShouldBeTrue();

    [Fact]
    public void IsTime24HourWithoutSecond() =>
        Instance.DotCheckStringValidationInstance
            .IsTimeOf24Hour(TimeData.Time24HourWithoutSecond, includeSecond: false)
            .ShouldBeTrue();


    [Fact]
    public void IsTime24HourWithSecond() =>
        Instance.DotCheckStringValidationInstance
            .IsTimeOf24Hour(TimeData.Time24HourWithSecond, includeSecond: true)
            .ShouldBeTrue();
}