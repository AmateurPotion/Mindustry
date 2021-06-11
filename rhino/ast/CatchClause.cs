// Decompiled with JetBrains decompiler
// Type: rhino.ast.CatchClause
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class CatchClause : AstNode
  {
    private Name varName;
    private AstNode catchCondition;
    private Block body;
    private int ifPosition;
    private int lp;
    private int rp;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 171, 233, 52, 103, 103, 167, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CatchClause(int pos)
      : base(pos)
    {
      CatchClause catchClause = this;
      this.ifPosition = -1;
      this.lp = -1;
      this.rp = -1;
      this.type = 125;
    }

    [LineNumberTable(new byte[] {0, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVarName(Name varName)
    {
      this.assertNotNull((object) varName);
      this.varName = varName;
      varName.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {18, 103, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCatchCondition(AstNode catchCondition)
    {
      this.catchCondition = catchCondition;
      catchCondition?.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {35, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBody(Block body)
    {
      this.assertNotNull((object) body);
      this.body = body;
      body.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIfPosition(int ifPosition) => this.ifPosition = ifPosition;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setParens(int lp, int rp)
    {
      this.lp = lp;
      this.rp = rp;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Name getVarName() => this.varName;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getCatchCondition() => this.catchCondition;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block getBody() => this.body;

    [LineNumberTable(new byte[] {159, 167, 232, 56, 103, 103, 167, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CatchClause()
    {
      CatchClause catchClause = this;
      this.ifPosition = -1;
      this.lp = -1;
      this.rp = -1;
      this.type = 125;
    }

    [LineNumberTable(new byte[] {159, 175, 234, 48, 103, 103, 167, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CatchClause(int pos, int len)
      : base(pos, len)
    {
      CatchClause catchClause = this;
      this.ifPosition = -1;
      this.lp = -1;
      this.rp = -1;
      this.type = 125;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLp() => this.lp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLp(int lp) => this.lp = lp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getRp() => this.rp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRp(int rp) => this.rp = rp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getIfPosition() => this.ifPosition;

    [LineNumberTable(new byte[] {94, 102, 110, 108, 115, 104, 108, 147, 108, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(this.makeIndent(depth));
      stringBuilder.append("catch (");
      stringBuilder.append(this.varName.toSource(0));
      if (this.catchCondition != null)
      {
        stringBuilder.append(" if ");
        stringBuilder.append(this.catchCondition.toSource(0));
      }
      stringBuilder.append(") ");
      stringBuilder.append(this.body.toSource(0));
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {113, 105, 108, 104, 140, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.varName.visit(v);
      if (this.catchCondition != null)
        this.catchCondition.visit(v);
      this.body.visit(v);
    }

    [HideFromJava]
    static CatchClause() => AstNode.__\u003Cclinit\u003E();
  }
}
