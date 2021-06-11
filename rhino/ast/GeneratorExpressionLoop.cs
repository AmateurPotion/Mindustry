// Decompiled with JetBrains decompiler
// Type: rhino.ast.GeneratorExpressionLoop
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class GeneratorExpressionLoop : ForInLoop
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GeneratorExpressionLoop(int pos)
      : base(pos)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isForEach() => false;

    [LineNumberTable(new byte[] {159, 179, 156, 159, 10, 107, 127, 0, 249, 58})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth) => new StringBuilder().append(this.makeIndent(depth)).append(" for ").append(!this.isForEach() ? "" : "each ").append("(").append(this.iterator.toSource(0)).append(!this.isForOf() ? " in " : " of ").append(this.iteratedObject.toSource(0)).append(")").toString();

    [LineNumberTable(new byte[] {3, 105, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.iterator.visit(v);
      this.iteratedObject.visit(v);
    }

    [LineNumberTable(new byte[] {159, 150, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GeneratorExpressionLoop()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GeneratorExpressionLoop(int pos, int len)
      : base(pos, len)
    {
    }

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setIsForEach(bool isForEach)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException("this node type does not support for each");
    }

    [HideFromJava]
    static GeneratorExpressionLoop() => ForInLoop.__\u003Cclinit\u003E();
  }
}
