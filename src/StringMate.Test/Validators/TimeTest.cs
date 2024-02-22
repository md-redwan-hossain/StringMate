using StringMate.Test.Validators.TestData;

namespace StringMate.Test.Validators;

public class TimeTest
{
    [Fact]
    public void IsTime12HourWithoutSecond() =>
        StringMate.Validators.StringValidation.Is12HourTime
            (TimeData.Time12HourWithoutSecond, includeSecond: false).ShouldBeTrue();

    [Fact]
    public void IsTime12HourWithSecond() =>
        StringMate.Validators.StringValidation.Is12HourTime
            (TimeData.Time12HourWithSecond, includeSecond: true).ShouldBeTrue();

    [Fact]
    public void IsTime24HourWithoutSecond() =>
        StringMate.Validators.StringValidation.Is24HourTime
            (TimeData.Time24HourWithoutSecond, includeSecond: false).ShouldBeTrue();

    [Fact]
    public void IsTime24HourWithSecond() =>
        StringMate.Validators.StringValidation.Is24HourTime
            (TimeData.Time24HourWithSecond, includeSecond: true).ShouldBeTrue();
}