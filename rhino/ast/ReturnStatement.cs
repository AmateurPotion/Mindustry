// Decompiled with JetBrains decompiler
// Type: rhino.ast.ReturnStatement
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class ReturnStatement : AstNode
  {
    private AstNode returnValue;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 173, 234, 49, 231, 80, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ReturnStatement(int pos, int len, AstNode returnValue)
      : base(pos, len)
    {
      ReturnStatement returnStatement = this;
      this.type = 4;
      this.setReturnValue(returnValue);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getReturnValue() => this.returnValue;

    [LineNumberTable(new byte[] {159, 189, 103, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setReturnValue(AstNode returnValue)
    {
      this.returnValue = returnValue;
      returnValue?.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {159, 161, 232, 61, 199})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ReturnStatement()
    {
      ReturnStatement returnStatement = this;
      this.type = 4;
    }

    [LineNumberTable(new byte[] {159, 165, 233, 57, 231, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ReturnStatement(int pos)
      : base(pos)
    {
      ReturnStatement returnStatement = this;
      this.type = 4;
    }

    [LineNumberTable(new byte[] {159, 169, 234, 53, 231, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ReturnStatement(int pos, int len)
      : base(pos, len)
    {
      ReturnStatement returnStatement = this;
      this.type = 4;
    }

    [LineNumberTable(new byte[] {4, 102, 110, 108, 104, 108, 147, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(this.makeIndent(depth));
      stringBuilder.append("return");
      if (this.returnValue != null)
      {
        stringBuilder.append(" ");
        stringBuilder.append(this.returnValue.toSource(0));
      }
      stringBuilder.append(";\n");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {20, 113, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this) || this.returnValue == null)
        return;
      this.returnValue.visit(v);
    }

    [HideFromJava]
    static ReturnStatement() => AstNode.__\u003Cclinit\u003E();
  }
}
