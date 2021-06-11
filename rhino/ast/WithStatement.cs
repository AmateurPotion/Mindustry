// Decompiled with JetBrains decompiler
// Type: rhino.ast.WithStatement
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class WithStatement : AstNode
  {
    private AstNode expression;
    private AstNode statement;
    private int lp;
    private int rp;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 168, 233, 53, 103, 167, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WithStatement(int pos)
      : base(pos)
    {
      WithStatement withStatement = this;
      this.lp = -1;
      this.rp = -1;
      this.type = 124;
    }

    [LineNumberTable(new byte[] {159, 187, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setExpression(AstNode expression)
    {
      this.assertNotNull((object) expression);
      this.expression = expression;
      expression.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {12, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStatement(AstNode statement)
    {
      this.assertNotNull((object) statement);
      this.statement = statement;
      statement.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setParens(int lp, int rp)
    {
      this.lp = lp;
      this.rp = rp;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getExpression() => this.expression;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getStatement() => this.statement;

    [LineNumberTable(new byte[] {159, 164, 232, 57, 103, 167, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WithStatement()
    {
      WithStatement withStatement = this;
      this.lp = -1;
      this.rp = -1;
      this.type = 124;
    }

    [LineNumberTable(new byte[] {159, 172, 234, 49, 103, 167, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WithStatement(int pos, int len)
      : base(pos, len)
    {
      WithStatement withStatement = this;
      this.lp = -1;
      this.rp = -1;
      this.type = 124;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLp() => this.lp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLp(int lp) => this.lp = lp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getRp() => this.rp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRp(int rp) => this.rp = rp;

    [LineNumberTable(new byte[] {55, 102, 110, 108, 115, 108, 104, 149, 114, 104, 140, 120, 142, 159, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(this.makeIndent(depth));
      stringBuilder.append("with (");
      stringBuilder.append(this.expression.toSource(0));
      stringBuilder.append(") ");
      if (this.getInlineComment() != null)
        stringBuilder.append(this.getInlineComment().toSource(depth + 1));
      if (this.statement.getType() == 130)
      {
        if (this.getInlineComment() != null)
          stringBuilder.append("\n");
        stringBuilder.append(String.instancehelper_trim(this.statement.toSource(depth)));
        stringBuilder.append("\n");
      }
      else
        stringBuilder.append("\n").append(this.statement.toSource(depth + 1));
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {80, 105, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.expression.visit(v);
      this.statement.visit(v);
    }

    [HideFromJava]
    static WithStatement() => AstNode.__\u003Cclinit\u003E();
  }
}
