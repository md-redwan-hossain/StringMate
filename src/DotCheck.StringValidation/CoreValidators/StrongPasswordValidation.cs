using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DotCheck.StringValidation.CoreValidators
{
    internal static class StrongPasswordValidation
    {
        private static readonly Regex UpperCaseRegex = new("^[A-Z]$");
        private static readonly Regex LowerCaseRegex = new("^[a-z]$");
        private static readonly Regex NumberRegex = new("^[0-9]$");

        private static readonly Regex SymbolRegex =
            new(@"^[-#!$@£%^&*()_+|~=`{}\[\]:""';<>?,.\/ ]$");


        private static Dictionary<char, int> CountChars(string text)
        {
            var charMap = new Dictionary<char, int>();
            foreach (var item in text)
            {
                var exists = charMap.ContainsKey(item);
                if (exists) charMap[item] += 1;
                else charMap[item] = 1;
            }

            return charMap;
        }


        private static (int uppercaseCount, int lowercaseCount, int numberCount,
            int symbolCount, int length, int uniqueChars) AnalyzePassword(string text)
        {
            var charMap = CountChars(text);

            var analysisReport = (
                uppercaseCount: 0,
                lowercaseCount: 0,
                numberCount: 0,
                symbolCount: 0,
                length: text.Length,
                uniqueChars: charMap.Count
            );

            foreach (var item in charMap)
            {
                var converted = item.Key.ToString();

                if (UpperCaseRegex.IsMatch(converted))
                {
                    analysisReport.uppercaseCount += charMap[item.Key];
                }
                else if (LowerCaseRegex.IsMatch(converted))
                {
                    analysisReport.lowercaseCount += charMap[item.Key];
                }
                else if (NumberRegex.IsMatch(converted))
                {
                    analysisReport.numberCount += charMap[item.Key];
                }
                else if (SymbolRegex.IsMatch(converted))
                {
                    analysisReport.symbolCount += charMap[item.Key];
                }
            }

            return analysisReport;
        }


        internal static bool Validate(string value, int minLength = 8, int minLowercase = 1,
            int minUppercase = 1, int minNumbers = 1, int minSymbols = 1, int minUniqueChars = 0)
        {
            var analysisReport = AnalyzePassword(value);

            return analysisReport.length >= minLength
                   && analysisReport.uniqueChars >= minUniqueChars
                   && analysisReport.uppercaseCount >= minUppercase
                   && analysisReport.lowercaseCount >= minLowercase
                   && analysisReport.numberCount >= minNumbers
                   && analysisReport.symbolCount >= minSymbols;
        }
    }
}