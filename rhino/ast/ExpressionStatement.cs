// Decompiled with JetBrains decompiler
// Type: rhino.ast.ExpressionStatement
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class ExpressionStatement : AstNode
  {
    private AstNode expr;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getExpression() => this.expr;

    [LineNumberTable(new byte[] {159, 132, 66, 105, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ExpressionStatement(AstNode expr, bool hasResult)
    {
      int num = hasResult ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(expr);
      ExpressionStatement expressionStatement = this;
      if (num == 0)
        return;
      this.setHasResult();
    }

    [LineNumberTable(new byte[] {3, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ExpressionStatement(AstNode expr)
      : this(expr.getPosition(), expr.getLength(), expr)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setHasResult() => this.type = 135;

    [LineNumberTable(new byte[] {18, 234, 11, 235, 118, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ExpressionStatement(int pos, int len, AstNode expr)
      : base(pos, len)
    {
      ExpressionStatement expressionStatement = this;
      this.type = 134;
      this.setExpression(expr);
    }

    [LineNumberTable(new byte[] {34, 103, 103, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setExpression(AstNode expression)
    {
      this.assertNotNull((object) expression);
      this.expr = expression;
      expression.setParent((AstNode) this);
      this.setLineno(expression.getLineno());
    }

    [LineNumberTable(new byte[] {159, 168, 232, 53, 235, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ExpressionStatement()
    {
      ExpressionStatement expressionStatement = this;
      this.type = 134;
    }

    [LineNumberTable(new byte[] {7, 234, 22, 235, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ExpressionStatement(int pos, int len)
      : base(pos, len)
    {
      ExpressionStatement expressionStatement = this;
      this.type = 134;
    }

    [LineNumberTable(97)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool hasSideEffects() => this.type == 135 || this.expr.hasSideEffects();

    [LineNumberTable(new byte[] {52, 102, 115, 108, 104, 147, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(this.expr.toSource(depth));
      stringBuilder.append(";");
      if (this.getInlineComment() != null)
        stringBuilder.append(this.getInlineComment().toSource(depth));
      stringBuilder.append("\n");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {67, 105, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.expr.visit(v);
    }

    [HideFromJava]
    static ExpressionStatement() => AstNode.__\u003Cclinit\u003E();
  }
}
