using System;
using System.Collections.Generic;
using System.Text;
using StringMate.Enums;

namespace StringMate.Generators
{
    public class SqlCheckConstrainGenerator
    {
        private readonly bool? _preserveCase;
        private readonly RelationalDatabase _relationalDatabase;

        public SqlCheckConstrainGenerator(RelationalDatabase relationalDatabase, bool? preserveCase = null)
        {
            _relationalDatabase = relationalDatabase;
            _preserveCase = preserveCase;
        }

        private const string EqualSign = " = ";
        private const string GreaterThanSign = " > ";
        private const string LessThanSign = " < ";
        private const string GreaterThanOrEqualSign = " >= ";
        private const string LessThanOrEqualSign = " <= ";
        private const string NotEqualSign = " <> ";
        private const string OrSign = " OR ";
        private const string AndSign = " AND ";
        private const string InSign = " IN ";
        private const string NotInSign = " NOT IN ";

        public string And(string leftOperand, string rightOperand)
        {
            return WrapWithParentheses(string.Concat(leftOperand, AndSign, rightOperand));
        }

        public string Or(string leftOperand, string rightOperand)
        {
            return WrapWithParentheses(string.Concat(leftOperand, OrSign, rightOperand));
        }

        public string In(string leftOperand, ICollection<int> rightOperands,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), InSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }


        public string In(string leftOperand, ICollection<string> rightOperands,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), InSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }

        public string In(string leftOperand, ICollection<Enum> rightOperands,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), InSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }


        public string NotIn(string leftOperand, ICollection<int> rightOperands,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), NotInSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }


        public string NotIn(string leftOperand, ICollection<string> rightOperands,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), NotInSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }

        public string NotIn(string leftOperand, ICollection<Enum> rightOperands,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), NotInSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }

        public string NotEqualTo(
            string leftOperand,
            string rightOperand,
            bool preserveLeftOperandCase = true,
            bool preserveRightOperandCase = true
        )
        {
            return string.Concat(
                OperandHandler(leftOperand, preserveLeftOperandCase), NotEqualSign,
                OperandHandler(rightOperand, preserveRightOperandCase));
        }


        public string NotEqualTo(string leftOperand, Enum rightOperand, bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), NotEqualSign,
                EnumValueToString(rightOperand));
        }

        public string NotEqualTo(string leftOperand, int rightOperand, bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), NotEqualSign, rightOperand);
        }


        public string EqualTo(string leftOperand, string rightOperand,
            bool preserveLeftOperandCase = true, bool preserveRightOperandCase = true
        )
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), EqualSign,
                OperandHandler(rightOperand, preserveRightOperandCase));
        }


        public string EqualTo(string leftOperand, int rightOperand, bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), EqualSign, rightOperand);
        }


        public string EqualTo(string leftOperand, Enum rightOperand, bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), EqualSign,
                EnumValueToString(rightOperand));
        }


        public string GreaterThan(string leftOperand, string rightOperand,
            bool preserveLeftOperandCase = true, bool preserveRightOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), GreaterThanSign,
                OperandHandler(rightOperand, preserveRightOperandCase));
        }


        public string GreaterThan(string leftOperand, Enum rightOperand,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), GreaterThanSign,
                EnumValueToString(rightOperand));
        }

        public string GreaterThan(string leftOperand, int rightOperand, bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), GreaterThanSign, rightOperand);
        }


        public string GreaterThanOrEqual(string leftOperand, string rightOperand,
            bool preserveLeftOperandCase = true, bool preserveRightOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), GreaterThanOrEqualSign,
                OperandHandler(rightOperand, preserveRightOperandCase));
        }


        public string GreaterThanOrEqual(string leftOperand, Enum rightOperand,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), GreaterThanOrEqualSign,
                EnumValueToString(rightOperand));
        }

        public string GreaterThanOrEqual(string leftOperand, int rightOperand,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), GreaterThanOrEqualSign,
                rightOperand);
        }


        public string LessThan(string leftOperand, string rightOperand,
            bool preserveLeftOperandCase = true, bool preserveRightOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), LessThanSign,
                OperandHandler(rightOperand, preserveRightOperandCase));
        }


        public string LessThan(string leftOperand, Enum rightOperand,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), LessThanSign,
                EnumValueToString(rightOperand));
        }

        public string LessThan(string leftOperand, int rightOperand, bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), LessThanSign, rightOperand);
        }


        public string LessThanOrEqual(string leftOperand, string rightOperand,
            bool preserveLeftOperandCase = true, bool preserveRightOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), LessThanOrEqualSign,
                OperandHandler(rightOperand, preserveRightOperandCase));
        }


        public string LessThanOrEqual(string leftOperand, Enum rightOperand,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), LessThanOrEqualSign,
                EnumValueToString(rightOperand));
        }

        public string LessThanOrEqual(string leftOperand, int rightOperand,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), LessThanOrEqualSign,
                rightOperand);
        }


        private string OperandHandler(string value, bool preserveCase)
        {
            if (_preserveCase is not null)
                return (bool)_preserveCase ? PreserveCase(value) : value;
            return preserveCase ? PreserveCase(value) : value;
        }

        private static string EnumValueToString(IFormattable value) =>
            Convert.ToInt32(value).ToString();


        private string CommaSeparatedCollectionData(ICollection<Enum> collection) =>
            CommaSeparatedCollectionDataMaker(collection, Convert.ToInt32);


        private string CommaSeparatedCollectionData(ICollection<int> collection) =>
            CommaSeparatedCollectionDataMaker<int, int>(collection);


        private string CommaSeparatedCollectionData(ICollection<string> collection) =>
            CommaSeparatedCollectionDataMaker(collection, PreserveCase);


        private static string CommaSeparatedCollectionDataMaker<TCollection, TValue>(
            ICollection<TCollection> collection,
            Func<TCollection, TValue>? logic = null)
        {
            var builder = new StringBuilder();
            var size = collection.Count;
            var counter = 0;

            foreach (var x in collection)
            {
                if (counter >= 1 && counter != size)
                {
                    builder.Append(',');
                }

                if (logic is not null)
                {
                    builder.Append(logic(x));
                }
                else
                {
                    builder.Append(x);
                }

                counter += 1;
            }

            return builder.ToString();
        }


        private static string WrapWithParentheses(string text) => $"({text})";

        private string PreserveCase(string text) =>
            _relationalDatabase switch
            {
                RelationalDatabase.PostgreSql => $"\"{text}\"",
                RelationalDatabase.MySql => $"`{text}`",
                RelationalDatabase.SqlServer => $"[{text}]",
                _ => text
            };
    }
}