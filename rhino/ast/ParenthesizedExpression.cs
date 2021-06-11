// Decompiled with JetBrains decompiler
// Type: rhino.ast.ParenthesizedExpression
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class ParenthesizedExpression : AstNode
  {
    private AstNode expression;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getExpression() => this.expression;

    [LineNumberTable(new byte[] {159, 177, 234, 43, 232, 86, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ParenthesizedExpression(int pos, int len, AstNode expr)
      : base(pos, len)
    {
      ParenthesizedExpression parenthesizedExpression = this;
      this.type = 88;
      this.setExpression(expr);
    }

    [LineNumberTable(new byte[] {3, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setExpression(AstNode expression)
    {
      this.assertNotNull((object) expression);
      this.expression = expression;
      expression.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {159, 159, 232, 61, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ParenthesizedExpression()
    {
      ParenthesizedExpression parenthesizedExpression = this;
      this.type = 88;
    }

    [LineNumberTable(new byte[] {159, 163, 233, 57, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ParenthesizedExpression(int pos)
      : base(pos)
    {
      ParenthesizedExpression parenthesizedExpression = this;
      this.type = 88;
    }

    [LineNumberTable(new byte[] {159, 167, 234, 53, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ParenthesizedExpression(int pos, int len)
      : base(pos, len)
    {
      ParenthesizedExpression parenthesizedExpression = this;
      this.type = 88;
    }

    [LineNumberTable(new byte[] {159, 171, 113, 41, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ParenthesizedExpression(AstNode expr)
      : this(expr == null ? 0 : expr.getPosition(), expr == null ? 1 : expr.getLength(), expr)
    {
    }

    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth) => new StringBuilder().append(this.makeIndent(depth)).append("(").append(this.expression.toSource(0)).append(")").toString();

    [LineNumberTable(new byte[] {18, 105, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.expression.visit(v);
    }

    [HideFromJava]
    static ParenthesizedExpression() => AstNode.__\u003Cclinit\u003E();
  }
}
