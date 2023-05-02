using System.Linq.Expressions;
using System.Reflection;

namespace Sound_VoiceStudio.BLL.Infrastructure.Utils;

public class ParameterReplaceVisitor : ExpressionVisitor
{
    public ParameterExpression Target { get; set; }
    public ParameterExpression Replacement { get; set; }

    protected override Expression VisitMember(MemberExpression node)
    {
        if (node.Expression == this.Target)
        {
            // Try and find a property with the same name on the target type
            var members = this.Replacement.Type.GetMember(node.Member.Name, node.Member.MemberType, BindingFlags.Public | BindingFlags.Instance);
            if (members.Length != 1)
            {
                throw new ArgumentException($"Unable to find a single member {node.Member.Name} of type {node.Member.MemberType} on {this.Target.Type}");
            }
            return Expression.MakeMemberAccess(this.Replacement, members[0]);
        }

        return base.VisitMember(node);
    }
}