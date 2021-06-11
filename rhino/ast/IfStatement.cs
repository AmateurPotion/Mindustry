// Decompiled with JetBrains decompiler
// Type: rhino.ast.IfStatement
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class IfStatement : AstNode
  {
    private AstNode condition;
    private AstNode thenPart;
    private int elsePosition;
    private AstNode elsePart;
    private AstNode elseKeyWordInlineComment;
    private int lp;
    private int rp;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 172, 233, 50, 167, 103, 167, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IfStatement(int pos)
      : base(pos)
    {
      IfStatement ifStatement = this;
      this.elsePosition = -1;
      this.lp = -1;
      this.rp = -1;
      this.type = 113;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setElseKeyWordInlineComment(AstNode elseKeyWordInlineComment) => this.elseKeyWordInlineComment = elseKeyWordInlineComment;

    [LineNumberTable(new byte[] {159, 191, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCondition(AstNode condition)
    {
      this.assertNotNull((object) condition);
      this.condition = condition;
      condition.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setParens(int lp, int rp)
    {
      this.lp = lp;
      this.rp = rp;
    }

    [LineNumberTable(new byte[] {16, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setThenPart(AstNode thenPart)
    {
      this.assertNotNull((object) thenPart);
      this.thenPart = thenPart;
      thenPart.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {34, 103, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setElsePart(AstNode elsePart)
    {
      this.elsePart = elsePart;
      elsePart?.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setElsePosition(int elsePosition) => this.elsePosition = elsePosition;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getCondition() => this.condition;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getThenPart() => this.thenPart;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getElsePart() => this.elsePart;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getElseKeyWordInlineComment() => this.elseKeyWordInlineComment;

    [LineNumberTable(new byte[] {159, 168, 232, 54, 167, 103, 167, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IfStatement()
    {
      IfStatement ifStatement = this;
      this.elsePosition = -1;
      this.lp = -1;
      this.rp = -1;
      this.type = 113;
    }

    [LineNumberTable(new byte[] {159, 176, 234, 46, 167, 103, 167, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IfStatement(int pos, int len)
      : base(pos, len)
    {
      IfStatement ifStatement = this;
      this.elsePosition = -1;
      this.lp = -1;
      this.rp = -1;
      this.type = 113;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getElsePosition() => this.elsePosition;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLp() => this.lp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLp(int lp) => this.lp = lp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getRp() => this.rp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRp(int rp) => this.rp = rp;

    [LineNumberTable(new byte[] {91, 104, 104, 104, 108, 115, 108, 104, 159, 7, 114, 104, 140, 144, 120, 107, 114, 158, 140, 104, 159, 7, 120, 105, 104, 140, 144, 152, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      string str = this.makeIndent(depth);
      StringBuilder stringBuilder = new StringBuilder(32);
      stringBuilder.append(str);
      stringBuilder.append("if (");
      stringBuilder.append(this.condition.toSource(0));
      stringBuilder.append(") ");
      if (this.getInlineComment() != null)
        stringBuilder.append("    ").append(this.getInlineComment().toSource()).append("\n");
      if (this.thenPart.getType() != 130)
      {
        if (this.getInlineComment() == null)
          stringBuilder.append("\n");
        stringBuilder.append(this.makeIndent(depth + 1));
      }
      stringBuilder.append(String.instancehelper_trim(this.thenPart.toSource(depth)));
      if (this.elsePart != null)
      {
        if (this.thenPart.getType() != 130)
          stringBuilder.append("\n").append(str).append("else ");
        else
          stringBuilder.append(" else ");
        if (this.getElseKeyWordInlineComment() != null)
          stringBuilder.append("    ").append(this.getElseKeyWordInlineComment().toSource()).append("\n");
        if (this.elsePart.getType() != 130 && this.elsePart.getType() != 113)
        {
          if (this.getElseKeyWordInlineComment() == null)
            stringBuilder.append("\n");
          stringBuilder.append(this.makeIndent(depth + 1));
        }
        stringBuilder.append(String.instancehelper_trim(this.elsePart.toSource(depth)));
      }
      stringBuilder.append("\n");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {160, 71, 105, 108, 108, 104, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.condition.visit(v);
      this.thenPart.visit(v);
      if (this.elsePart == null)
        return;
      this.elsePart.visit(v);
    }

    [HideFromJava]
    static IfStatement() => AstNode.__\u003Cclinit\u003E();
  }
}
