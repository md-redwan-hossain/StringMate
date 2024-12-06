using System;
using System.Collections.Generic;
using System.Text;
using Humanizer;
using StringMate.Enums;

namespace StringMate.Generators
{
    /// <summary>
    /// <c>SqlCheckConstrainGenerator</c> is a utility class for generating raw sql code for check-constrains in a type-safe manner.
    /// It can be useful with Entity Framework Core since it doesn't have strongly-typed check-constrain support and requires raw sql code.
    /// </summary>
    public class SqlCheckConstrainGenerator
    {
        private readonly bool _delimitStringGlobalLevel;
        private readonly StringCase _stringCase;
        private readonly RDBMS _rdbms;


        /// <param name="rdbms">determines the delimitStringGlobalLevel symbols based on database.</param>
        /// <param name="stringCase">denotes the case of the generated SQL</param>
        /// <param name="delimitStringGlobalLevel">any method parameter of this class which is related to string delimitation will override <c>delimitStringGlobal</c>. By default, <c>delimitStringGlobal</c> is set to true. </param>
        public SqlCheckConstrainGenerator(RDBMS rdbms, StringCase stringCase = StringCase.SameAsInput,
            bool delimitStringGlobalLevel = true)
        {
            _rdbms = rdbms;
            _stringCase = stringCase;
            _delimitStringGlobalLevel = delimitStringGlobalLevel;
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
        private const string NotSign = " NOT ";
        private const string NotInSign = " NOT IN ";
        private const string BetweenSign = " BETWEEN ";
        private const string NotBetweenSign = " NOT BETWEEN ";

        public string And(string leftOperand, string rightOperand)
        {
            return WrapWithParentheses(string.Concat(leftOperand, AndSign, rightOperand));
        }

        public string Or(string leftOperand, string rightOperand)
        {
            return WrapWithParentheses(string.Concat(leftOperand, OrSign, rightOperand));
        }

        public string Not(string leftOperand, string rightOperand)
        {
            return WrapWithParentheses(string.Concat(leftOperand, NotSign, rightOperand));
        }

        private (string left, string right) TransformCase(string left, string right)
        {
            if (_stringCase == StringCase.SnakeCase)
            {
                return (left.Underscore(), right.Underscore());
            }

            return (right, left);
        }

        private string TransformCase(string columnOrOperand)
        {
            if (_stringCase == StringCase.SnakeCase)
            {
                return (columnOrOperand.Underscore());
            }

            return columnOrOperand;
        }

        public string In(string leftOperand, ICollection<int> rightOperands, bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand);
            return string.Concat(OperandHandler(transformed, delimitLeftOperand ?? _delimitStringGlobalLevel), InSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }

        public string In(string leftOperand, ICollection<string> rightOperands, bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand);
            return string.Concat(OperandHandler(transformed, delimitLeftOperand ?? _delimitStringGlobalLevel), InSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }

        public string In(string leftOperand, ICollection<Enum> rightOperands, bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand);
            return string.Concat(OperandHandler(transformed, delimitLeftOperand ?? _delimitStringGlobalLevel), InSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }

        public string NotIn(string leftOperand, ICollection<int> rightOperands, bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand);
            return string.Concat(OperandHandler(transformed, delimitLeftOperand ?? _delimitStringGlobalLevel),
                NotInSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }


        public string NotIn(string leftOperand, ICollection<string> rightOperands, bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand);
            return string.Concat(OperandHandler(transformed, delimitLeftOperand ?? _delimitStringGlobalLevel),
                NotInSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }

        public string NotIn(string leftOperand, ICollection<Enum> rightOperands, bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand);
            return string.Concat(OperandHandler(transformed, delimitLeftOperand ?? _delimitStringGlobalLevel),
                NotInSign,
                WrapWithParentheses(CommaSeparatedCollectionData(rightOperands)));
        }

        public string NotEqualTo(string leftOperand, string rightOperand, SqlOperandType rightOperandType,
            bool? delimitLeftOperand = null, bool? delimitRightOperand = null)
        {
            var transformed = TransformCase(leftOperand, rightOperand);

            return string.Concat(
                OperandHandler(transformed.left, delimitLeftOperand ?? _delimitStringGlobalLevel),
                NotEqualSign,
                rightOperandType == SqlOperandType.Column
                    ? OperandHandler(transformed.right, delimitRightOperand ?? _delimitStringGlobalLevel)
                    : SqlString(transformed.right)
            );
        }


        public string NotEqualTo(string leftOperand, Enum rightOperand, bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand, EnumValueToString(rightOperand));

            return string.Concat(OperandHandler(transformed.left, delimitLeftOperand ?? _delimitStringGlobalLevel),
                NotEqualSign,
                transformed.right);
        }

        public string NotEqualTo(string leftOperand, int rightOperand, SqlDataType leftOperandSqlDataType,
            bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand);

            var leftOperandWithLogic = OperandHandler(transformed, delimitLeftOperand ?? _delimitStringGlobalLevel);
            if (leftOperandSqlDataType == SqlDataType.VarChar || leftOperandSqlDataType == SqlDataType.Text)
            {
                leftOperandWithLogic = LengthOperatorHandler(leftOperandWithLogic);
            }

            return string.Concat(leftOperandWithLogic, NotEqualSign, rightOperand);
        }


        public string EqualTo(string leftOperand, string rightOperand, SqlOperandType rightOperandType,
            bool? delimitLeftOperand = null, bool? delimitRightOperand = null)
        {
            var transformed = TransformCase(leftOperand, rightOperand);
            return string.Concat(
                OperandHandler(transformed.left, delimitLeftOperand ?? _delimitStringGlobalLevel),
                EqualSign,
                rightOperandType == SqlOperandType.Column
                    ? OperandHandler(transformed.right, delimitRightOperand ?? _delimitStringGlobalLevel)
                    : SqlString(transformed.right)
            );
        }


        public string EqualTo(string leftOperand, int rightOperand, SqlDataType leftOperandSqlDataType,
            bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand);
            var leftOperandWithLogic = OperandHandler(transformed, delimitLeftOperand ?? _delimitStringGlobalLevel);
            if (leftOperandSqlDataType == SqlDataType.VarChar || leftOperandSqlDataType == SqlDataType.Text)
            {
                leftOperandWithLogic = LengthOperatorHandler(leftOperandWithLogic);
            }

            return string.Concat(leftOperandWithLogic, EqualSign, rightOperand);
        }


        public string EqualTo(string leftOperand, Enum rightOperand, bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand, EnumValueToString(rightOperand));

            return string.Concat(
                OperandHandler(transformed.left, delimitLeftOperand ?? _delimitStringGlobalLevel),
                EqualSign,
                transformed.right
            );
        }


        public string GreaterThan(string leftOperand, string rightOperand, SqlOperandType rightOperandType,
            bool? delimitLeftOperand = null, bool? delimitRightOperand = null)
        {
            var transformed = TransformCase(leftOperand, rightOperand);

            return string.Concat(
                OperandHandler(transformed.left, delimitLeftOperand ?? _delimitStringGlobalLevel),
                GreaterThanSign,
                rightOperandType == SqlOperandType.Column
                    ? OperandHandler(rightOperand, delimitRightOperand ?? _delimitStringGlobalLevel)
                    : SqlString(transformed.right)
            );
        }


        public string GreaterThan(string leftOperand, Enum rightOperand, bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand, EnumValueToString(rightOperand));
            return string.Concat(
                OperandHandler(transformed.left, delimitLeftOperand ?? _delimitStringGlobalLevel),
                GreaterThanSign,
                transformed.right
            );
        }

        public string GreaterThan(string leftOperand, int rightOperand, SqlDataType leftOperandSqlDataType,
            bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand);
            var leftOperandWithLogic = OperandHandler(transformed, delimitLeftOperand ?? _delimitStringGlobalLevel);
            if (leftOperandSqlDataType == SqlDataType.VarChar || leftOperandSqlDataType == SqlDataType.Text)
            {
                leftOperandWithLogic = LengthOperatorHandler(leftOperandWithLogic);
            }

            return string.Concat(leftOperandWithLogic, GreaterThanSign, rightOperand);
        }


        public string GreaterThanOrEqual(string leftOperand, string rightOperand, SqlOperandType rightOperandType,
            bool? delimitLeftOperand = null, bool? delimitRightOperand = null)
        {
            var transformed = TransformCase(leftOperand, rightOperand);
            return string.Concat(
                OperandHandler(transformed.left, delimitLeftOperand ?? _delimitStringGlobalLevel),
                GreaterThanOrEqualSign,
                rightOperandType == SqlOperandType.Column
                    ? OperandHandler(transformed.right, delimitRightOperand ?? _delimitStringGlobalLevel)
                    : SqlString(transformed.right)
            );
        }


        public string GreaterThanOrEqual(string leftOperand, Enum rightOperand, bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand, EnumValueToString(rightOperand));
            return string.Concat(
                OperandHandler(transformed.left, delimitLeftOperand ?? _delimitStringGlobalLevel),
                GreaterThanOrEqualSign,
                transformed.right
            );
        }

        public string GreaterThanOrEqual(string leftOperand, int rightOperand, SqlDataType leftOperandSqlDataType,
            bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand);
            var leftOperandWithLogic = OperandHandler(transformed, delimitLeftOperand ?? _delimitStringGlobalLevel);
            if (leftOperandSqlDataType == SqlDataType.VarChar || leftOperandSqlDataType == SqlDataType.Text)
            {
                leftOperandWithLogic = LengthOperatorHandler(leftOperandWithLogic);
            }

            return string.Concat(leftOperandWithLogic, GreaterThanOrEqualSign, rightOperand);
        }


        public string LessThan(string leftOperand, string rightOperand, SqlOperandType rightOperandType,
            bool? delimitLeftOperand = null, bool? delimitRightOperand = null)
        {
            var transformed = TransformCase(leftOperand, rightOperand);
            return string.Concat(
                OperandHandler(transformed.left, delimitLeftOperand ?? _delimitStringGlobalLevel),
                LessThanSign,
                rightOperandType == SqlOperandType.Column
                    ? OperandHandler(transformed.right, delimitRightOperand ?? _delimitStringGlobalLevel)
                    : SqlString(transformed.right)
            );
        }


        public string LessThan(string leftOperand, Enum rightOperand, bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand, EnumValueToString(rightOperand));
            return string.Concat(
                OperandHandler(transformed.left, delimitLeftOperand ?? _delimitStringGlobalLevel),
                LessThanSign,
                transformed.right
            );
        }

        public string LessThan(string leftOperand, int rightOperand, SqlDataType leftOperandSqlDataType,
            bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand);
            var leftOperandWithLogic = OperandHandler(transformed, delimitLeftOperand ?? _delimitStringGlobalLevel);
            if (leftOperandSqlDataType == SqlDataType.VarChar || leftOperandSqlDataType == SqlDataType.Text)
            {
                leftOperandWithLogic = LengthOperatorHandler(leftOperandWithLogic);
            }

            return string.Concat(leftOperandWithLogic, LessThanSign, rightOperand);
        }


        public string LessThanOrEqual(string leftOperand, string rightOperand, SqlOperandType rightOperandType,
            bool? delimitLeftOperand = null, bool? delimitRightOperand = null)
        {
            var transformed = TransformCase(leftOperand, rightOperand);
            return string.Concat(
                OperandHandler(transformed.left, delimitLeftOperand ?? _delimitStringGlobalLevel),
                LessThanOrEqualSign,
                rightOperandType == SqlOperandType.Column
                    ? OperandHandler(transformed.right, delimitRightOperand ?? _delimitStringGlobalLevel)
                    : SqlString(transformed.right)
            );
        }

        public string LessThanOrEqual(string leftOperand, Enum rightOperand, bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand, EnumValueToString(rightOperand));
            return string.Concat(
                OperandHandler(transformed.left, delimitLeftOperand ?? _delimitStringGlobalLevel),
                LessThanOrEqualSign,
                transformed.right
            );
        }

        public string LessThanOrEqual(string leftOperand, int rightOperand, SqlDataType leftOperandSqlDataType,
            bool? delimitLeftOperand = null)
        {
            var transformed = TransformCase(leftOperand);
            var leftOperandWithLogic = OperandHandler(transformed, delimitLeftOperand ?? _delimitStringGlobalLevel);
            if (leftOperandSqlDataType == SqlDataType.VarChar || leftOperandSqlDataType == SqlDataType.Text)
            {
                leftOperandWithLogic = LengthOperatorHandler(leftOperandWithLogic);
            }

            return string.Concat(leftOperandWithLogic, LessThanOrEqualSign, rightOperand);
        }


        public string Between(string columnName, string leftOperand,
            string rightOperand, bool? delimitColumnName = null)
        {
            return string.Concat(OperandHandler(columnName, delimitColumnName ?? _delimitStringGlobalLevel),
                BetweenSign, SqlString(leftOperand), AndSign, SqlString(rightOperand));
        }


        public string Between(string columnName, int leftOperand,
            int rightOperand, bool? delimitColumnName = null)
        {
            var transformed = TransformCase(columnName);
            return string.Concat(
                OperandHandler(transformed, delimitColumnName ?? _delimitStringGlobalLevel),
                BetweenSign, leftOperand, AndSign, rightOperand);
        }

        public string Between(string columnName, double leftOperand,
            double rightOperand, bool? delimitColumnName = null)
        {
            var transformed = TransformCase(columnName);
            return string.Concat(OperandHandler(transformed, delimitColumnName ?? _delimitStringGlobalLevel),
                BetweenSign, leftOperand, AndSign, rightOperand);
        }

        public string NotBetween(string columnName, string leftOperand,
            string rightOperand, bool? delimitColumnName = null)
        {
            var transformed = TransformCase(columnName);
            return string.Concat(OperandHandler(transformed, delimitColumnName ?? _delimitStringGlobalLevel),
                NotBetweenSign, SqlString(leftOperand), AndSign, SqlString(rightOperand));
        }


        public string NotBetween(string columnName, int leftOperand,
            int rightOperand, bool? delimitColumnName = null)
        {
            var transformed = TransformCase(columnName);
            return string.Concat(OperandHandler(transformed, delimitColumnName ?? _delimitStringGlobalLevel),
                NotBetweenSign, leftOperand, AndSign, rightOperand);
        }

        public string NotBetween(string columnName, double leftOperand,
            double rightOperand, bool? delimitColumnName = null)
        {
            var transformed = TransformCase(columnName);
            return string.Concat(OperandHandler(transformed, delimitColumnName ?? _delimitStringGlobalLevel),
                NotBetweenSign, leftOperand, AndSign, rightOperand);
        }

        private string LengthOperatorHandler(string data)
        {
            return _rdbms switch
            {
                RDBMS.SqlServer => $"LEN({data})",
                RDBMS.PostgreSql => $"length({data})",
                RDBMS.MySql => $"CHAR_LENGTH({data})",
                _ => data
            };
        }


        private string OperandHandler(string value, bool delimit) =>
            delimit ? DelimitString(value) : value;

        private static string EnumValueToString(IFormattable value) =>
            Convert.ToInt32(value).ToString();


        private static string CommaSeparatedCollectionData(ICollection<Enum> collection) =>
            CommaSeparatedCollectionDataMaker(collection, Convert.ToInt32);


        private static string CommaSeparatedCollectionData(ICollection<int> collection) =>
            CommaSeparatedCollectionDataMaker<int, int>(collection);


        private static string CommaSeparatedCollectionData(ICollection<string> collection) =>
            CommaSeparatedCollectionDataMaker(collection, SqlString);


        private static string CommaSeparatedCollectionDataMaker<TCollection, TValue>(
            ICollection<TCollection> collection,
            Func<TCollection, TValue>? logic = null)
        {
            var builder = new StringBuilder();
            var size = collection.Count;
            var counter = 0;

            foreach (var item in collection)
            {
                if (counter >= 1 && counter != size)
                {
                    builder.Append(", ");
                }

                if (logic != null)
                {
                    builder.Append(logic(item));
                }
                else
                {
                    builder.Append(item);
                }

                counter += 1;
            }

            return builder.ToString();
        }


        private static string WrapWithParentheses(string text) => $"({text})";

        private static string SqlString(string text) => $"\'{text}\'";

        private string DelimitString(string text)
        {
            return _rdbms switch
            {
                RDBMS.PostgreSql => $"\"{text}\"",
                RDBMS.MySql => $"`{text}`",
                RDBMS.SqlServer => $"[{text}]",
                _ => text
            };
        }
    }
}