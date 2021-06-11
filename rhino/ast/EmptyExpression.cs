// Decompiled with JetBrains decompiler
// Type: rhino.ast.EmptyExpression
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class EmptyExpression : AstNode
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 234, 53, 235, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EmptyExpression(int pos, int len)
      : base(pos, len)
    {
      EmptyExpression emptyExpression = this;
      this.type = 129;
    }

    [LineNumberTable(new byte[] {159, 162, 233, 57, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EmptyExpression(int pos)
      : base(pos)
    {
      EmptyExpression emptyExpression = this;
      this.type = 129;
    }

    [LineNumberTable(new byte[] {159, 158, 232, 61, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EmptyExpression()
    {
      EmptyExpression emptyExpression = this;
      this.type = 129;
    }

    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth) => this.makeIndent(depth);

    [LineNumberTable(new byte[] {159, 179, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v) => v.visit((AstNode) this);

    [HideFromJava]
    static EmptyExpression() => AstNode.__\u003Cclinit\u003E();
  }
}
