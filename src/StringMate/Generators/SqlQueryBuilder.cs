using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Humanizer;
using StringMate.Enums;

namespace StringMate.Generators
{
    public class SqlQueryBuilder
    {
        private readonly RDBMS _databaseVendor;
        private readonly List<string> _conditions = new();
        private readonly List<string> _orderByClauses = new();
        private readonly SqlNamingConvention _namingConvention;
        private readonly bool _pluralizeTableName;
        private readonly Dictionary<string, object?> _parameters = new();
        private readonly Queue<string> _joinStatementQueue = new();
        private readonly Queue<string> _selectStatementQueue = new();
        private readonly Queue<string> _groupByStatementQueue = new();
        private readonly Queue<string> _aggregateStatementQueue = new();
        private int _paramCounter;
        private int? _page = 1;
        private int? _limit = 1;

        public SqlQueryBuilder(RDBMS databaseVendor, SqlNamingConvention namingConvention, bool pluralizeTableName)
        {
            _namingConvention = namingConvention;
            _pluralizeTableName = pluralizeTableName;
            _databaseVendor = databaseVendor;
        }

        public SqlQueryBuilder SelectAll()
        {
            _selectStatementQueue.Clear();
            _selectStatementQueue.Enqueue("*");
            return this;
        }

        public SqlQueryBuilder Select<TEntity, TValue>(Expression<Func<TEntity, TValue>> selector, string? alias = null)
        {
            var tableName = GetTableName(typeof(TEntity));
            var columnName = ConvertName(ExtractPropertyName(selector), _namingConvention);

            var final = string.IsNullOrEmpty(alias)
                ? $"{tableName}.{columnName}"
                : $"{tableName}.{columnName} as {DelimitString(alias)}";

            _selectStatementQueue.Enqueue(final);
            return this;
        }

        public SqlQueryBuilder Count<TEntity, TValue>(Expression<Func<TEntity, TValue>> selector, string? alias = null)
        {
            var tableName = GetTableName(typeof(TEntity));
            var columnName = ConvertName(ExtractPropertyName(selector), _namingConvention);

            var final = string.IsNullOrEmpty(alias)
                ? $"COUNT({tableName}.{columnName})"
                : $"COUNT({tableName}.{columnName}) as {DelimitString(alias)}";

            _aggregateStatementQueue.Enqueue(final);
            return this;
        }

        public SqlQueryBuilder Max<TEntity, TValue>(Expression<Func<TEntity, TValue>> selector, string? alias = null)
        {
            var tableName = GetTableName(typeof(TEntity));
            var columnName = ConvertName(ExtractPropertyName(selector), _namingConvention);

            var final = string.IsNullOrEmpty(alias)
                ? $"MAX({tableName}.{columnName})"
                : $"MAX({tableName}.{columnName}) as {DelimitString(alias)}";

            _aggregateStatementQueue.Enqueue(final);
            return this;
        }

        public SqlQueryBuilder Sum<TEntity, TValue>(Expression<Func<TEntity, TValue>> selector, string? alias = null,
            bool useCoalesce = false, TValue? coalesceValue = default)
        {
            var tableName = GetTableName(typeof(TEntity));
            var columnName = ConvertName(ExtractPropertyName(selector), _namingConvention);

            var transform = useCoalesce && coalesceValue is not null
                ? $"COALESCE(SUM({tableName}.{columnName}), {AddParameter(coalesceValue)})"
                : $"SUM({tableName}.{columnName})";

            if (string.IsNullOrEmpty(alias) is false)
            {
                transform = $"{transform} as {DelimitString(alias)}";
            }

            _aggregateStatementQueue.Enqueue(transform);
            return this;
        }

        public SqlQueryBuilder GroupBy<TEntity, TValue>(Expression<Func<TEntity, TValue>> selector)
        {
            var tableName = GetTableName(typeof(TEntity));
            var columnName = ConvertName(ExtractPropertyName(selector), _namingConvention);
            _groupByStatementQueue.Enqueue($"{tableName}.{columnName}");
            return this;
        }


        public SqlQueryBuilder WhereIn<TEntity, TValue>(Expression<Func<TEntity, TValue>> selector,
            params TValue[] values)
        {
            var tableName = GetTableName(typeof(TEntity));
            var propertyName = ExtractPropertyName(selector);
            var columnName = ConvertName(propertyName, _namingConvention);

            var parameters = new StringBuilder();

            var upperBound = values.Length;
            var counter = 0;

            foreach (var elem in values)
            {
                counter += 1;
                var paramName = AddParameter(elem);
                parameters.Append(counter < upperBound ? $"{paramName}, " : paramName);
            }

            _conditions.Add($"{tableName}.{columnName} IN ({parameters})");
            return this;
        }

        public SqlQueryBuilder Where<TEntity, TValue>(Expression<Func<TEntity, TValue>> selector, SqlOperator op,
            TValue value, bool ignoreIfValueIsNull = true)
        {
            if (ignoreIfValueIsNull && value is null)
            {
                return this;
            }

            var tableName = GetTableName(typeof(TEntity));
            var propertyName = ExtractPropertyName(selector);
            var columnName = ConvertName(propertyName, _namingConvention);

            var sqlOperator = op switch
            {
                SqlOperator.Equal => "=",
                SqlOperator.GreaterThan => ">",
                SqlOperator.LessThan => "<",
                SqlOperator.GreaterThanOrEqual => ">=",
                SqlOperator.LessThanOrEqual => "<=",
                SqlOperator.NotEqual => "<>",
                _ => throw new NotSupportedException($"Operator {op} is not supported.")
            };

            var paramName = AddParameter(value);
            _conditions.Add($"{tableName}.{columnName} {sqlOperator} {paramName}");
            return this;
        }

        public SqlQueryBuilder OrderBy<TEntity, TValue>(Expression<Func<TEntity, TValue>> selector)
        {
            var tableName = GetTableName(typeof(TEntity));
            var propertyName = ExtractPropertyName(selector);
            var columnName = ConvertName(propertyName, _namingConvention);
            _orderByClauses.Add(tableName + "." + columnName + " ASC");
            return this;
        }

        public SqlQueryBuilder OrderByDesc<TEntity, TValue>(Expression<Func<TEntity, TValue>> selector)
        {
            var tableName = GetTableName(typeof(TEntity));
            var propertyName = ExtractPropertyName(selector);
            var columnName = ConvertName(propertyName, _namingConvention);
            _orderByClauses.Add(tableName + "." + columnName + " DESC");
            return this;
        }

        public SqlQueryBuilder Paginate(int page, int limit)
        {
            if (page <= 0)
            {
                page = 1;
            }

            if (limit <= 0)
            {
                limit = 1;
            }

            _page = (page - 1) * limit;
            _limit = limit;
            return this;
        }

        public SqlQueryBuilder CursorPaginate(int limit)
        {
            _page = null;
            _limit = limit;
            return this;
        }

        public SqlQueryBuilder Join<TParent, TChild, TParenTValue, TChildValue>(SqlJoinType sqlJoinType,
            Expression<Func<TParent, TParenTValue>> fromKey, Expression<Func<TChild, TChildValue>> toKey)
        {
            var joinTypeString = sqlJoinType switch
            {
                SqlJoinType.Inner => "INNER JOIN",
                SqlJoinType.Left => "LEFT JOIN",
                SqlJoinType.Right => "RIGHT JOIN",
                SqlJoinType.Full => "FULL JOIN",
                _ => throw new ArgumentException("Invalid join type")
            };

            var fromTable = GetTableName(typeof(TParent));
            var toTable = GetTableName(typeof(TChild));

            var fromColumn =
                ConvertName(ExtractPropertyName(fromKey), _namingConvention);
            var toColumn = ConvertName(ExtractPropertyName(toKey), _namingConvention);

            _joinStatementQueue.Enqueue($" {joinTypeString} ON {fromTable}.{fromColumn} = {toTable}.{toColumn} ");

            return this;
        }

        public (string Sql, Dictionary<string, object?> Parameters) Build<TEntity>(bool excludeSemicolon = false)
        {
            var sql = new StringBuilder();
            sql.Append("SELECT ");

            var upperBound = _selectStatementQueue.Count + _aggregateStatementQueue.Count;
            var counter = 0;

            foreach (var item in _selectStatementQueue)
            {
                counter += 1;
                sql.Append(counter < upperBound ? $"{item}, " : item);
            }

            foreach (var item in _aggregateStatementQueue)
            {
                counter += 1;
                sql.Append(counter < upperBound ? $"{item}, " : item);
            }

            if (_joinStatementQueue.Count > 0)
            {
                foreach (var item in _joinStatementQueue)
                {
                    sql.Append(item);
                }
            }

            var tableName = GetTableName(typeof(TEntity));

            sql.Append($" FROM {tableName}");

            if (_conditions.Count != 0)
            {
                sql.Append(" WHERE ").Append(string.Join(" AND ", _conditions));
            }

            upperBound = _groupByStatementQueue.Count;
            counter = 0;
            if (upperBound > 0)
            {
                sql.Append(" GROUP BY ");
                foreach (var item in _groupByStatementQueue)
                {
                    counter += 1;
                    sql.Append(counter < upperBound ? $"{item}, " : item);
                }
            }


            if (_orderByClauses.Count != 0)
            {
                sql.Append(" ORDER BY ").Append(string.Join(", ", _orderByClauses));
            }

            if (_page.HasValue && _limit.HasValue)
            {
                sql.Append(" LIMIT ").Append(_limit).Append(" OFFSET ").Append(_page);
            }

            if (_page.HasValue is false && _limit.HasValue)
            {
                sql.Append(" LIMIT ").Append(_limit);
            }

            if (excludeSemicolon is false)
            {
                sql.Append(';');
            }

            return (sql.ToString(), _parameters);
        }

        private string AddParameter<TValue>(TValue value)
        {
            var paramName = $"@param{_paramCounter += 1}";
            _parameters[paramName] = value;
            return paramName;
        }

        private string GetTableName(Type type)
        {
            var tableName = type.Name;

            if (_pluralizeTableName)
            {
                tableName = tableName.Pluralize();
            }

            return ConvertName(tableName, _namingConvention);
        }

        private static string ExtractPropertyName<TEntity, TValue>(Expression<Func<TEntity, TValue>> expression)
        {
            return expression.Body switch
            {
                MemberExpression member => member.Member.Name,
                UnaryExpression { Operand: MemberExpression unaryMember } => unaryMember.Member.Name,
                _ => throw new InvalidOperationException("Invalid expression format.")
            };
        }

        private string DelimitString(string text)
        {
            return _databaseVendor switch
            {
                RDBMS.PostgreSql => $"\"{text}\"",
                RDBMS.MySql => $"`{text}`",
                RDBMS.SqlServer => $"[{text}]",
                _ => text
            };
        }

        private static string ConvertName(string propertyName, SqlNamingConvention convention)
        {
            return convention switch
            {
                SqlNamingConvention.PascalCase => propertyName.Pascalize(),
                SqlNamingConvention.LowerSnakeCase => propertyName.Underscore().ToLowerInvariant(),
                SqlNamingConvention.UpperSnakeCase => propertyName.Underscore().ToUpperInvariant(),
                _ => throw new NotSupportedException($"Naming convention {convention} is not supported.")
            };
        }
    }
}