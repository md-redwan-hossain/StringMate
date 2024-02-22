using StringMate.Helpers;
using StringMate.Test.Validators.TestData;

namespace StringMate.Test.Validators;

public class SlashedDateTest
{
    [Fact]
    public void IsDateWithDayMonthYearSlash()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithoutLeadingZero()
            .AddMonthWithoutLeadingZero()
            .AddYearWithLastTwoDigit()
            .AddForwardSlashDelimiter()
            .Build();

        StringMate.Validators.StringValidation.IsDate(DateData.DayMonthYearSlash, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDay0MonthYearSlash()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithLeadingZero()
            .AddMonthWithoutLeadingZero()
            .AddYearWithLastTwoDigit()
            .AddForwardSlashDelimiter()
            .Build();

        StringMate.Validators.StringValidation.IsDate(DateData.Day0MonthYearSlash, dateFormat).ShouldBeTrue();
    }

    [Fact]
    public void IsDateWithDayMonth0YearSlash()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithoutLeadingZero()
            .AddMonthWithLeadingZero()
            .AddYearWithLastTwoDigit()
            .AddForwardSlashDelimiter()
            .Build();

        StringMate.Validators.StringValidation.IsDate(DateData.DayMonth0YearSlash, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDay0Month0YearSlash()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithLeadingZero()
            .AddMonthWithLeadingZero()
            .AddYearWithLastTwoDigit()
            .AddForwardSlashDelimiter()
            .Build();

        StringMate.Validators.StringValidation.IsDate(DateData.Day0Month0YearSlash, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDayMonthYear4Slash()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithoutLeadingZero()
            .AddMonthWithoutLeadingZero()
            .AddYearWithFourDigit()
            .AddForwardSlashDelimiter()
            .Build();

        StringMate.Validators.StringValidation.IsDate(DateData.DayMonthYear4Slash, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDay0MonthYear4Slash()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithLeadingZero()
            .AddMonthWithoutLeadingZero()
            .AddYearWithFourDigit()
            .AddForwardSlashDelimiter()
            .Build();

        StringMate.Validators.StringValidation.IsDate(DateData.Day0MonthYear4Slash, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDayMonth0Year4Slash()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithoutLeadingZero()
            .AddMonthWithLeadingZero()
            .AddYearWithFourDigit()
            .AddForwardSlashDelimiter()
            .Build();

        StringMate.Validators.StringValidation.IsDate(DateData.DayMonth0Year4Slash, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDay0Month0Year4Slash()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithLeadingZero()
            .AddMonthWithLeadingZero()
            .AddYearWithFourDigit()
            .AddForwardSlashDelimiter()
            .Build();

        StringMate.Validators.StringValidation.IsDate(DateData.Day0Month0Year4Slash, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDayMonthYearSlashYearFirst()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithoutLeadingZero()
            .AddMonthWithoutLeadingZero()
            .AddYearWithLastTwoDigit()
            .AddForwardSlashDelimiter()
            .MakeYearFirstDayLast()
            .Build();

        StringMate.Validators.StringValidation.IsDate(DateData.DayMonthYearSlashYearFirst, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDay0MonthYearSlashYearFirst()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithLeadingZero()
            .AddMonthWithoutLeadingZero()
            .AddYearWithLastTwoDigit()
            .AddForwardSlashDelimiter()
            .MakeYearFirstDayLast()
            .Build();

        StringMate.Validators.StringValidation.IsDate(DateData.Day0MonthYearSlashYearFirst, dateFormat).ShouldBeTrue();
    }

    [Fact]
    public void IsDateWithDayMonth0YearSlashYearFirst()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithoutLeadingZero()
            .AddMonthWithLeadingZero()
            .AddYearWithLastTwoDigit()
            .AddForwardSlashDelimiter()
            .MakeYearFirstDayLast()
            .Build();

        StringMate.Validators.StringValidation.IsDate(DateData.DayMonth0YearSlashYearFirst, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDay0Month0YearSlashYearFirst()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithLeadingZero()
            .AddMonthWithLeadingZero()
            .AddYearWithLastTwoDigit()
            .AddForwardSlashDelimiter()
            .MakeYearFirstDayLast()
            .Build();

        StringMate.Validators.StringValidation.IsDate(DateData.Day0Month0YearSlashYearFirst, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDayMonthYear4SlashYearFirst()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithoutLeadingZero()
            .AddMonthWithoutLeadingZero()
            .AddYearWithFourDigit()
            .AddForwardSlashDelimiter()
            .MakeYearFirstDayLast()
            .Build();

        StringMate.Validators.StringValidation.IsDate(DateData.DayMonthYear4SlashYearFirst, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDay0MonthYear4SlashYearFirst()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithLeadingZero()
            .AddMonthWithoutLeadingZero()
            .AddYearWithFourDigit()
            .AddForwardSlashDelimiter()
            .MakeYearFirstDayLast()
            .Build();

        StringMate.Validators.StringValidation.IsDate(DateData.Day0MonthYear4SlashYearFirst, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDayMonth0Year4SlashYearFirst()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithoutLeadingZero()
            .AddMonthWithLeadingZero()
            .AddYearWithFourDigit()
            .AddForwardSlashDelimiter()
            .MakeYearFirstDayLast()
            .Build();

        StringMate.Validators.StringValidation.IsDate(DateData.DayMonth0Year4SlashYearFirst, dateFormat).ShouldBeTrue();
    }


    [Fact]
    public void IsDateWithDay0Month0Year4SlashYearFirst()
    {
        var dateFormat = new DateFormatBuilder()
            .AddDayWithLeadingZero()
            .AddMonthWithLeadingZero()
            .AddYearWithFourDigit()
            .AddForwardSlashDelimiter()
            .MakeYearFirstDayLast()
            .Build();

        StringMate.Validators.StringValidation.IsDate(DateData.Day0Month0Year4SlashYearFirst, dateFormat).ShouldBeTrue();
    }
}