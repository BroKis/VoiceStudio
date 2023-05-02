using System.Linq.Expressions;
using AutoMapper.Execution;

namespace Sound_VoiceStudio.BLL.Infrastructure.Utils;

public static class FunctionReplacer
{
    public static Expression<Func<T, bool>> ReplaceParameter<T>(LambdaExpression expr)
    {
        if (expr.Parameters.Count != 1)
            throw new ArgumentException("Expected 1 parameter", nameof(expr));

        var newParameter = Expression.Parameter(typeof(T), expr.Parameters[0].Name);
        var visitor = new ParameterReplaceVisitor()
        {
            Target = expr.Parameters[0],
            Replacement = newParameter,
        };
        var rewrittenBody = visitor.Visit(expr.Body);
        return Expression.Lambda<Func<T, bool>>(rewrittenBody, newParameter);
    }
}