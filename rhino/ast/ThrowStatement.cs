// Decompiled with JetBrains decompiler
// Type: rhino.ast.ThrowStatement
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class ThrowStatement : AstNode
  {
    private AstNode expression;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 177, 239, 45, 232, 84, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ThrowStatement(int pos, AstNode expr)
      : base(pos, expr.getLength())
    {
      ThrowStatement throwStatement = this;
      this.type = 50;
      this.setExpression(expr);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getExpression() => this.expression;

    [LineNumberTable(new byte[] {7, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setExpression(AstNode expression)
    {
      this.assertNotNull((object) expression);
      this.expression = expression;
      expression.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {159, 161, 232, 61, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ThrowStatement()
    {
      ThrowStatement throwStatement = this;
      this.type = 50;
    }

    [LineNumberTable(new byte[] {159, 165, 233, 57, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ThrowStatement(int pos)
      : base(pos)
    {
      ThrowStatement throwStatement = this;
      this.type = 50;
    }

    [LineNumberTable(new byte[] {159, 169, 234, 53, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ThrowStatement(int pos, int len)
      : base(pos, len)
    {
      ThrowStatement throwStatement = this;
      this.type = 50;
    }

    [LineNumberTable(new byte[] {159, 172, 232, 50, 232, 79, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ThrowStatement(AstNode expr)
    {
      ThrowStatement throwStatement = this;
      this.type = 50;
      this.setExpression(expr);
    }

    [LineNumberTable(new byte[] {159, 182, 234, 40, 232, 89, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ThrowStatement(int pos, int len, AstNode expr)
      : base(pos, len)
    {
      ThrowStatement throwStatement = this;
      this.type = 50;
      this.setExpression(expr);
    }

    [LineNumberTable(new byte[] {14, 191, 3, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth) => new StringBuilder().append(this.makeIndent(depth)).append("throw ").append(this.expression.toSource(0)).append(";\n").toString();

    [LineNumberTable(new byte[] {27, 105, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.expression.visit(v);
    }

    [HideFromJava]
    static ThrowStatement() => AstNode.__\u003Cclinit\u003E();
  }
}
