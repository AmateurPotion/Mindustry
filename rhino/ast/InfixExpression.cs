// Decompiled with JetBrains decompiler
// Type: rhino.ast.InfixExpression
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class InfixExpression : AstNode
  {
    protected internal AstNode left;
    protected internal AstNode right;
    protected internal int operatorPosition;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getLeft() => this.left;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getRight() => this.right;

    [LineNumberTable(new byte[] {159, 189, 232, 30, 231, 99, 104, 111, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public InfixExpression(int @operator, AstNode left, AstNode right, int operatorPos)
    {
      InfixExpression infixExpression = this;
      this.operatorPosition = -1;
      this.setType(@operator);
      this.setOperatorPosition(operatorPos - left.getPosition());
      this.setLeftAndRight(left, right);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOperatorPosition(int operatorPosition) => this.operatorPosition = operatorPosition;

    [LineNumberTable(new byte[] {49, 103, 135, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLeft(AstNode left)
    {
      this.assertNotNull((object) left);
      this.left = left;
      this.setLineno(left.getLineno());
      left.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {72, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRight(AstNode right)
    {
      this.assertNotNull((object) right);
      this.right = right;
      right.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {4, 103, 135, 103, 110, 168, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLeftAndRight(AstNode left, AstNode right)
    {
      this.assertNotNull((object) left);
      this.assertNotNull((object) right);
      this.setBounds(left.getPosition(), right.getPosition() + right.getLength());
      this.setLeft(left);
      this.setRight(right);
    }

    [LineNumberTable(new byte[] {159, 157, 8, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public InfixExpression()
    {
      InfixExpression infixExpression = this;
      this.operatorPosition = -1;
    }

    [LineNumberTable(new byte[] {159, 161, 233, 58, 231, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public InfixExpression(int pos)
      : base(pos)
    {
      InfixExpression infixExpression = this;
      this.operatorPosition = -1;
    }

    [LineNumberTable(new byte[] {159, 165, 234, 54, 231, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public InfixExpression(int pos, int len)
      : base(pos, len)
    {
      InfixExpression infixExpression = this;
      this.operatorPosition = -1;
    }

    [LineNumberTable(new byte[] {159, 171, 234, 48, 231, 81, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public InfixExpression(int pos, int len, AstNode left, AstNode right)
      : base(pos, len)
    {
      InfixExpression infixExpression = this;
      this.operatorPosition = -1;
      this.setLeft(left);
      this.setRight(right);
    }

    [LineNumberTable(new byte[] {159, 180, 232, 39, 231, 90, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public InfixExpression(AstNode left, AstNode right)
    {
      InfixExpression infixExpression = this;
      this.operatorPosition = -1;
      this.setLeftAndRight(left, right);
    }

    [LineNumberTable(70)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getOperator() => this.getType();

    [LineNumberTable(new byte[] {30, 104, 127, 6, 104})]
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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getOperatorPosition() => this.operatorPosition;

    [LineNumberTable(new byte[] {95, 159, 2, 186, 127, 4, 43, 161})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool hasSideEffects()
    {
      switch (this.getType())
      {
        case 90:
          return this.right != null && this.right.hasSideEffects();
        case 105:
        case 106:
          return this.left != null && this.left.hasSideEffects() || this.right != null && this.right.hasSideEffects();
        default:
          return base.hasSideEffects();
      }
    }

    [LineNumberTable(new byte[] {109, 119, 149, 159, 0, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth) => new StringBuilder().append(this.makeIndent(depth)).append(this.left.toSource()).append(" ").append(AstNode.operatorToString(this.getType())).append(" ").append(this.right.toSource()).toString();

    [LineNumberTable(new byte[] {123, 105, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.left.visit(v);
      this.right.visit(v);
    }

    [HideFromJava]
    static InfixExpression() => AstNode.__\u003Cclinit\u003E();
  }
}
