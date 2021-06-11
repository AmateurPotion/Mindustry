// Decompiled with JetBrains decompiler
// Type: rhino.ast.EmptyStatement
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class EmptyStatement : AstNode
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 164, 234, 53, 235, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EmptyStatement(int pos, int len)
      : base(pos, len)
    {
      EmptyStatement emptyStatement = this;
      this.type = 129;
    }

    [LineNumberTable(new byte[] {159, 156, 232, 61, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EmptyStatement()
    {
      EmptyStatement emptyStatement = this;
      this.type = 129;
    }

    [LineNumberTable(new byte[] {159, 160, 233, 57, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EmptyStatement(int pos)
      : base(pos)
    {
      EmptyStatement emptyStatement = this;
      this.type = 129;
    }

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth) => new StringBuilder().append(this.makeIndent(depth)).append(";\n").toString();

    [LineNumberTable(new byte[] {159, 177, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v) => v.visit((AstNode) this);

    [HideFromJava]
    static EmptyStatement() => AstNode.__\u003Cclinit\u003E();
  }
}
