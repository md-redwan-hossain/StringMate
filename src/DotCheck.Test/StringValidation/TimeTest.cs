using DotCheck.Test.StringValidation.TestData;
using DotCheck.StringValidation;
using Shouldly;
using Xunit;

namespace DotCheck.Test.StringValidation
{
    public class TimeTest
    {
        [Fact]
        public void IsTime12HourWithoutSecond() =>
            DotCheckStringValidation.Is12HourTime
            (TimeData.Time12HourWithoutSecond, includeSecond: false).ShouldBeTrue();

        [Fact]
        public void IsTime12HourWithSecond() =>
            DotCheckStringValidation.Is12HourTime
            (TimeData.Time12HourWithSecond, includeSecond: true).ShouldBeTrue();

        [Fact]
        public void IsTime24HourWithoutSecond() =>
            DotCheckStringValidation.Is24HourTime
            (TimeData.Time24HourWithoutSecond, includeSecond: false).ShouldBeTrue();

        [Fact]
        public void IsTime24HourWithSecond() =>
            DotCheckStringValidation.Is24HourTime
            (TimeData.Time24HourWithSecond, includeSecond: true).ShouldBeTrue();
    }
}