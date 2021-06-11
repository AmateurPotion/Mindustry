// Decompiled with JetBrains decompiler
// Type: rhino.ast.ErrorNode
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class ErrorNode : AstNode
  {
    private string message;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 167, 234, 53, 231, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ErrorNode(int pos, int len)
      : base(pos, len)
    {
      ErrorNode errorNode = this;
      this.type = -1;
    }

    [LineNumberTable(new byte[] {159, 159, 232, 61, 199})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ErrorNode()
    {
      ErrorNode errorNode = this;
      this.type = -1;
    }

    [LineNumberTable(new byte[] {159, 163, 233, 57, 231, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ErrorNode(int pos)
      : base(pos)
    {
      ErrorNode errorNode = this;
      this.type = -1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getMessage() => this.message;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMessage(string message) => this.message = message;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth) => "";

    [LineNumberTable(new byte[] {3, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v) => v.visit((AstNode) this);

    [HideFromJava]
    static ErrorNode() => AstNode.__\u003Cclinit\u003E();
  }
}
