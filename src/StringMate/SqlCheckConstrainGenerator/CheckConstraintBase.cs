using System;
using System.Collections.Generic;
using System.Text;

namespace StringMate.SqlCheckConstrainGenerator
{
    public abstract class CheckConstraintBase
    {
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

        protected string And(string leftOperand, string rightOperand)
        {
            return WrapWithParentheses(string.Concat(leftOperand, AndSign, rightOperand));
        }

        protected string Or(string leftOperand, string rightOperand)
        {
            return WrapWithParentheses(string.Concat(leftOperand, OrSign, rightOperand));
        }

        protected string In(string leftOperand, ICollection<int> rightOperands,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), InSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }


        protected string In(string leftOperand, ICollection<string> rightOperands,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), InSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }

        protected string In(string leftOperand, ICollection<Enum> rightOperands,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), InSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }


        protected string NotIn(string leftOperand, ICollection<int> rightOperands,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), NotInSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }


        protected string NotIn(string leftOperand, ICollection<string> rightOperands,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), NotInSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }

        protected string NotIn(string leftOperand, ICollection<Enum> rightOperands,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), NotInSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }

        protected string NotEqualTo(
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


        protected string NotEqualTo(string leftOperand, Enum rightOperand, bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), NotEqualSign,
                EnumValueToString(rightOperand));
        }

        protected string NotEqualTo(string leftOperand, int rightOperand, bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), NotEqualSign, rightOperand);
        }


        protected string EqualTo(string leftOperand, string rightOperand,
            bool preserveLeftOperandCase = true, bool preserveRightOperandCase = true
        )
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), EqualSign,
                OperandHandler(rightOperand, preserveRightOperandCase));
        }


        protected string EqualTo(string leftOperand, int rightOperand, bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), EqualSign, rightOperand);
        }


        protected string EqualTo(string leftOperand, Enum rightOperand, bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), EqualSign,
                EnumValueToString(rightOperand));
        }


        protected string GreaterThan(string leftOperand, string rightOperand,
            bool preserveLeftOperandCase = true, bool preserveRightOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), GreaterThanSign,
                OperandHandler(rightOperand, preserveRightOperandCase));
        }


        protected string GreaterThan(string leftOperand, Enum rightOperand,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), GreaterThanSign,
                EnumValueToString(rightOperand));
        }

        protected string GreaterThan(string leftOperand, int rightOperand, bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), GreaterThanSign, rightOperand);
        }


        protected string GreaterThanOrEqual(string leftOperand, string rightOperand,
            bool preserveLeftOperandCase = true, bool preserveRightOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), GreaterThanOrEqualSign,
                OperandHandler(rightOperand, preserveRightOperandCase));
        }


        protected string GreaterThanOrEqual(string leftOperand, Enum rightOperand,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), GreaterThanOrEqualSign,
                EnumValueToString(rightOperand));
        }

        protected string GreaterThanOrEqual(string leftOperand, int rightOperand,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), GreaterThanOrEqualSign,
                rightOperand);
        }


        protected string LessThan(string leftOperand, string rightOperand,
            bool preserveLeftOperandCase = true, bool preserveRightOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), LessThanSign,
                OperandHandler(rightOperand, preserveRightOperandCase));
        }


        protected string LessThan(string leftOperand, Enum rightOperand,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), LessThanSign,
                EnumValueToString(rightOperand));
        }

        protected string LessThan(string leftOperand, int rightOperand, bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), LessThanSign, rightOperand);
        }


        protected string LessThanOrEqual(string leftOperand, string rightOperand,
            bool preserveLeftOperandCase = true, bool preserveRightOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), LessThanOrEqualSign,
                OperandHandler(rightOperand, preserveRightOperandCase));
        }


        protected string LessThanOrEqual(string leftOperand, Enum rightOperand,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), LessThanOrEqualSign,
                EnumValueToString(rightOperand));
        }

        protected string LessThanOrEqual(string leftOperand, int rightOperand,
            bool preserveLeftOperandCase = true)
        {
            return string.Concat(OperandHandler(leftOperand, preserveLeftOperandCase), LessThanOrEqualSign,
                rightOperand);
        }


        private string OperandHandler(string value, bool preserveCase) =>
            preserveCase ? PreserveCase(value) : value;

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
        protected abstract string PreserveCase(string text);
    }
}