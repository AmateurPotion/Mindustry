// Decompiled with JetBrains decompiler
// Type: rhino.ast.Yield
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class Yield : AstNode
  {
    private AstNode value;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 135, 163, 106, 114, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Yield(int pos, int len, AstNode value, bool isStar)
    {
      int num = isStar ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(pos, len);
      Yield yield = this;
      this.type = num == 0 ? 73 : 166;
      this.setValue(value);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getValue() => this.value;

    [LineNumberTable(new byte[] {159, 190, 103, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(AstNode expr)
    {
      this.value = expr;
      expr?.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {159, 158, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Yield()
    {
      Yield yield = this;
      this.type = 73;
    }

    [LineNumberTable(new byte[] {159, 163, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Yield(int pos)
      : base(pos)
    {
      Yield yield = this;
      this.type = 73;
    }

    [LineNumberTable(new byte[] {159, 168, 106, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Yield(int pos, int len)
      : base(pos, len)
    {
      Yield yield = this;
      this.type = 73;
    }

    [LineNumberTable(new byte[] {5, 159, 6, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth) => this.value == null ? "yield" : new StringBuilder().append("yield ").append(this.value.toSource(0)).toString();

    [LineNumberTable(new byte[] {15, 113, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this) || this.value == null)
        return;
      this.value.visit(v);
    }

    [HideFromJava]
    static Yield() => AstNode.__\u003Cclinit\u003E();
  }
}
