namespace DotCheck.StringValidation.Helpers
{
    public interface IDateFormatBuilder
    {
        public IDateFormatBuilder AddDayWithLeadingZero();
        public IDateFormatBuilder AddDayWithoutLeadingZero();
        public IDateFormatBuilder AddMonthWithLeadingZero();
        public IDateFormatBuilder AddMonthWithoutLeadingZero();
        public IDateFormatBuilder AddYearWithLastTwoDigit();
        public IDateFormatBuilder AddYearWithFourDigit();
        public IDateFormatBuilder AddForwardSlashDelimiter();
        public IDateFormatBuilder AddHyphenDelimiter();
        public IDateFormatBuilder MakeYearFirstDayLast();
        public string Build();
    }
}