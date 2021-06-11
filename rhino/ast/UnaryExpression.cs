// Decompiled with JetBrains decompiler
// Type: rhino.ast.UnaryExpression
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class UnaryExpression : AstNode
  {
    private AstNode operand;
    private bool isPostfix;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 183, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UnaryExpression(int @operator, int operatorPosition, AstNode operand)
      : this(@operator, operatorPosition, operand, false)
    {
    }

    [LineNumberTable(new byte[] {159, 129, 163, 104, 103, 141, 137, 109, 104, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UnaryExpression(int @operator, int operatorPosition, AstNode operand, bool postFix)
    {
      int num = postFix ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      UnaryExpression unaryExpression = this;
      this.assertNotNull((object) operand);
      this.setBounds(num == 0 ? operatorPosition : operand.getPosition(), num == 0 ? operand.getPosition() + operand.getLength() : operatorPosition + 2);
      this.setOperator(@operator);
      this.setOperand(operand);
      this.isPostfix = num != 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getOperand() => this.operand;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPrefix() => !this.isPostfix;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPostfix() => this.isPostfix;

    [LineNumberTable(new byte[] {32, 104, 127, 6, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOperator(int @operator)
    {
      if (!Token.isValidToken(@operator))
      {
        string str = new StringBuilder().append("Invalid token: ").append(@operator).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.setType(@operator);
    }

    [LineNumberTable(new byte[] {46, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOperand(AstNode operand)
    {
      this.assertNotNull((object) operand);
      this.operand = operand;
      operand.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {159, 164, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UnaryExpression()
    {
    }

    [LineNumberTable(new byte[] {159, 168, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UnaryExpression(int pos)
      : base(pos)
    {
    }

    [LineNumberTable(new byte[] {159, 175, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UnaryExpression(int pos, int len)
      : base(pos, len)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getOperator() => this.type;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIsPostfix(bool isPostfix) => this.isPostfix = isPostfix;

    [LineNumberTable(new byte[] {74, 102, 110, 103, 104, 109, 111, 172, 114, 104, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(this.makeIndent(depth));
      int type = this.getType();
      if (!this.isPostfix)
      {
        stringBuilder.append(AstNode.operatorToString(type));
        if (type == 32 || type == 31 || type == (int) sbyte.MaxValue)
          stringBuilder.append(" ");
      }
      stringBuilder.append(this.operand.toSource());
      if (this.isPostfix)
        stringBuilder.append(AstNode.operatorToString(type));
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {95, 105, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.operand.visit(v);
    }

    [HideFromJava]
    static UnaryExpression() => AstNode.__\u003Cclinit\u003E();
  }
}
