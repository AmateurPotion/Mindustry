// Decompiled with JetBrains decompiler
// Type: rhino.ast.ConditionalExpression
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class ConditionalExpression : AstNode
  {
    private AstNode testExpression;
    private AstNode trueExpression;
    private AstNode falseExpression;
    private int questionMarkPosition;
    private int colonPosition;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 181, 234, 49, 103, 167, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConditionalExpression(int pos, int len)
      : base(pos, len)
    {
      ConditionalExpression conditionalExpression = this;
      this.questionMarkPosition = -1;
      this.colonPosition = -1;
      this.type = 103;
    }

    [LineNumberTable(new byte[] {5, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTestExpression(AstNode testExpression)
    {
      this.assertNotNull((object) testExpression);
      this.testExpression = testExpression;
      testExpression.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {24, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTrueExpression(AstNode trueExpression)
    {
      this.assertNotNull((object) trueExpression);
      this.trueExpression = trueExpression;
      trueExpression.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {44, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFalseExpression(AstNode falseExpression)
    {
      this.assertNotNull((object) falseExpression);
      this.falseExpression = falseExpression;
      falseExpression.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setQuestionMarkPosition(int questionMarkPosition) => this.questionMarkPosition = questionMarkPosition;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColonPosition(int colonPosition) => this.colonPosition = colonPosition;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getTestExpression() => this.testExpression;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getTrueExpression() => this.trueExpression;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getFalseExpression() => this.falseExpression;

    [LineNumberTable(new byte[] {159, 173, 232, 57, 103, 167, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConditionalExpression()
    {
      ConditionalExpression conditionalExpression = this;
      this.questionMarkPosition = -1;
      this.colonPosition = -1;
      this.type = 103;
    }

    [LineNumberTable(new byte[] {159, 177, 233, 53, 103, 167, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConditionalExpression(int pos)
      : base(pos)
    {
      ConditionalExpression conditionalExpression = this;
      this.questionMarkPosition = -1;
      this.colonPosition = -1;
      this.type = 103;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getQuestionMarkPosition() => this.questionMarkPosition;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getColonPosition() => this.colonPosition;

    [LineNumberTable(new byte[] {81, 152, 102, 115, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool hasSideEffects()
    {
      if (this.testExpression == null || this.trueExpression == null || this.falseExpression == null)
        AstNode.codeBug();
      return this.trueExpression.hasSideEffects() && this.falseExpression.hasSideEffects();
    }

    [LineNumberTable(new byte[] {90, 120, 155, 155, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth) => new StringBuilder().append(this.makeIndent(depth)).append(this.testExpression.toSource(depth)).append(" ? ").append(this.trueExpression.toSource(0)).append(" : ").append(this.falseExpression.toSource(0)).toString();

    [LineNumberTable(new byte[] {105, 105, 108, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.testExpression.visit(v);
      this.trueExpression.visit(v);
      this.falseExpression.visit(v);
    }

    [HideFromJava]
    static ConditionalExpression() => AstNode.__\u003Cclinit\u003E();
  }
}
