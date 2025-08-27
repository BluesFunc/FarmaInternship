using System.Linq.Expressions;
using System.Text;
using Dapper;

namespace Auth.Infrastructure.Services;

public class SqlExpressionVisitor : ExpressionVisitor
{
    private readonly StringBuilder _sb = new();
    private readonly DynamicParameters _parameters = new();
    private int _paramIndex = 0;

    public (string sql, DynamicParameters parameters) Translate(Expression expression)
    {
        Visit(expression);
        return (_sb.ToString(), _parameters);
    }

    protected override Expression VisitBinary(BinaryExpression node)
    {
        _sb.Append("(");
        Visit(node.Left);

        switch (node.NodeType)
        {
            case ExpressionType.Equal: _sb.Append(" = "); break;
            case ExpressionType.NotEqual: _sb.Append(" <> "); break;
            case ExpressionType.GreaterThan: _sb.Append(" > "); break;
            case ExpressionType.GreaterThanOrEqual: _sb.Append(" >= "); break;
            case ExpressionType.LessThan: _sb.Append(" < "); break;
            case ExpressionType.LessThanOrEqual: _sb.Append(" <= "); break;
            case ExpressionType.AndAlso: _sb.Append(" AND "); break;
            case ExpressionType.OrElse: _sb.Append(" OR "); break;
            default: throw new NotSupportedException($"Операция {node.NodeType} не поддерживается");
        }

        Visit(node.Right);
        _sb.Append(")");
        return node;
    }

    protected override Expression VisitMember(MemberExpression node)
    {
        if (node.Expression != null && node.Expression.NodeType == ExpressionType.Parameter)
        {
            _sb.Append(node.Member.Name);
            return node;
        }

        throw new NotSupportedException($"Член {node.Member.Name} не поддерживается");
    }

    protected override Expression VisitConstant(ConstantExpression node)
    {
        var paramName = $"@p{_paramIndex++}";
        _sb.Append(paramName);
        _parameters.Add(paramName, node.Value);
        return node;
    }
}