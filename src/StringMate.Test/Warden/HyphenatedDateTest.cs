using Shouldly;
using StringMate.Helpers;
using StringMate.Test.Warden.TestData;
using Xunit;

namespace StringMate.Test.Warden;

public class HyphenatedDateTest
{
    [Fact]
    public void IsDateWithDayMonthYearHyphen()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithoutLeadingZero()
            .AddMonthWithoutLeadingZero()
            .AddYearWithLastTwoDigit()
            .AddHyphenDelimiter()
            .Build();

        Validation.Warden.IsDate(DateData.DayMonthYearHyphen, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDay0MonthYearHyphen()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithLeadingZero()
            .AddMonthWithoutLeadingZero()
            .AddYearWithLastTwoDigit()
            .AddHyphenDelimiter()
            .Build();

        Validation.Warden.IsDate(DateData.Day0MonthYearHyphen, dateFormat).ShouldBeTrue();
    }

    [Fact]
    public void IsDateWithDayMonth0YearHyphen()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithoutLeadingZero()
            .AddMonthWithLeadingZero()
            .AddYearWithLastTwoDigit()
            .AddHyphenDelimiter()
            .Build();

        Validation.Warden.IsDate(DateData.DayMonth0YearHyphen, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDay0Month0YearHyphen()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithLeadingZero()
            .AddMonthWithLeadingZero()
            .AddYearWithLastTwoDigit()
            .AddHyphenDelimiter()
            .Build();

        Validation.Warden.IsDate(DateData.Day0Month0YearHyphen, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDayMonthYear4Hyphen()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithoutLeadingZero()
            .AddMonthWithoutLeadingZero()
            .AddYearWithFourDigit()
            .AddHyphenDelimiter()
            .Build();

        Validation.Warden.IsDate(DateData.DayMonthYear4Hyphen, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDay0MonthYear4Hyphen()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithLeadingZero()
            .AddMonthWithoutLeadingZero()
            .AddYearWithFourDigit()
            .AddHyphenDelimiter()
            .Build();

        Validation.Warden.IsDate(DateData.Day0MonthYear4Hyphen, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDayMonth0Year4Hyphen()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithoutLeadingZero()
            .AddMonthWithLeadingZero()
            .AddYearWithFourDigit()
            .AddHyphenDelimiter()
            .Build();

        Validation.Warden.IsDate(DateData.DayMonth0Year4Hyphen, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDay0Month0Year4Hyphen()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithLeadingZero()
            .AddMonthWithLeadingZero()
            .AddYearWithFourDigit()
            .AddHyphenDelimiter()
            .Build();

        Validation.Warden.IsDate(DateData.Day0Month0Year4Hyphen, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDayMonthYearHyphenYearFirst()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithoutLeadingZero()
            .AddMonthWithoutLeadingZero()
            .AddYearWithLastTwoDigit()
            .AddHyphenDelimiter()
            .MakeYearFirstDayLast()
            .Build();

        Validation.Warden.IsDate(DateData.DayMonthYearHyphenYearFirst, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDay0MonthYearHyphenYearFirst()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithLeadingZero()
            .AddMonthWithoutLeadingZero()
            .AddYearWithLastTwoDigit()
            .AddHyphenDelimiter()
            .MakeYearFirstDayLast()
            .Build();

        Validation.Warden.IsDate(DateData.Day0MonthYearHyphenYearFirst, dateFormat).ShouldBeTrue();
    }

    [Fact]
    public void IsDateWithDayMonth0YearHyphenYearFirst()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithoutLeadingZero()
            .AddMonthWithLeadingZero()
            .AddYearWithLastTwoDigit()
            .AddHyphenDelimiter()
            .MakeYearFirstDayLast()
            .Build();

        Validation.Warden.IsDate(DateData.DayMonth0YearHyphenYearFirst, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDay0Month0YearHyphenYearFirst()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithLeadingZero()
            .AddMonthWithLeadingZero()
            .AddYearWithLastTwoDigit()
            .AddHyphenDelimiter()
            .MakeYearFirstDayLast()
            .Build();

        Validation.Warden.IsDate(DateData.Day0Month0YearHyphenYearFirst, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDayMonthYear4HyphenYearFirst()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithoutLeadingZero()
            .AddMonthWithoutLeadingZero()
            .AddYearWithFourDigit()
            .AddHyphenDelimiter()
            .MakeYearFirstDayLast()
            .Build();

        Validation.Warden.IsDate(DateData.DayMonthYear4HyphenYearFirst, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDay0MonthYear4HyphenYearFirst()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithLeadingZero()
            .AddMonthWithoutLeadingZero()
            .AddYearWithFourDigit()
            .AddHyphenDelimiter()
            .MakeYearFirstDayLast()
            .Build();

        Validation.Warden.IsDate(DateData.Day0MonthYear4HyphenYearFirst, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDayMonth0Year4HyphenYearFirst()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithoutLeadingZero()
            .AddMonthWithLeadingZero()
            .AddYearWithFourDigit()
            .AddHyphenDelimiter()
            .MakeYearFirstDayLast()
            .Build();

        Validation.Warden.IsDate(DateData.DayMonth0Year4HyphenYearFirst, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDay0Month0Year4HyphenYearFirst()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithLeadingZero()
            .AddMonthWithLeadingZero()
            .AddYearWithFourDigit()
            .AddHyphenDelimiter()
            .MakeYearFirstDayLast()
            .Build();

        Validation.Warden.IsDate(DateData.Day0Month0Year4HyphenYearFirst, dateFormat).ShouldBeTrue();
    }
}