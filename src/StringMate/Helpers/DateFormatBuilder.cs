namespace StringMate.Helpers
{
    public class DateFormatBuilder : IDateFormatBuilder
    {
        private const string DayWithLeadingZero = "dd";
        private const string DayWithoutLeadingZero = "d";
        private const string MonthWithLeadingZero = "MM";
        private const string MonthWithoutLeadingZero = "M";
        private const string YearWithLastTwoDigit = "y";
        private const string YearWithFourDigit = "yyyy";
        private const char HyphenDelimiter = '-';
        private const char ForwardSlashDelimiter = '/';

        private string _day = DayWithLeadingZero;
        private string _month = MonthWithLeadingZero;
        private string _year = YearWithFourDigit;
        private char _delimiter = HyphenDelimiter;
        private bool _dayFirst = true;


        public IDateFormatBuilder AddDayWithLeadingZero()
        {
            _day = DayWithLeadingZero;
            return this;
        }

        public IDateFormatBuilder AddDayWithoutLeadingZero()
        {
            _day = DayWithoutLeadingZero;
            return this;
        }

        public IDateFormatBuilder AddMonthWithLeadingZero()
        {
            _month = MonthWithLeadingZero;
            return this;
        }

        public IDateFormatBuilder AddMonthWithoutLeadingZero()
        {
            _month = MonthWithoutLeadingZero;
            return this;
        }

        public IDateFormatBuilder AddYearWithLastTwoDigit()
        {
            _year = YearWithLastTwoDigit;
            return this;
        }

        public IDateFormatBuilder AddYearWithFourDigit()
        {
            _year = YearWithFourDigit;
            return this;
        }

        public IDateFormatBuilder AddForwardSlashDelimiter()
        {
            _delimiter = ForwardSlashDelimiter;
            return this;
        }

        public IDateFormatBuilder AddHyphenDelimiter()
        {
            _delimiter = HyphenDelimiter;
            return this;
        }

        public IDateFormatBuilder MakeYearFirstDayLast()
        {
            _dayFirst = false;
            return this;
        }

        public string Build()
        {
            return _dayFirst
                ? string.Concat(_day, _delimiter, _month, _delimiter, _year)
                : string.Concat(_year, _delimiter, _month, _delimiter, _day);
        }
    }
}