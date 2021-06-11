// Decompiled with JetBrains decompiler
// Type: rhino.ast.RegExpLiteral
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class RegExpLiteral : AstNode
  {
    private string value;
    private string flags;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 168, 234, 53, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RegExpLiteral(int pos, int len)
      : base(pos, len)
    {
      RegExpLiteral regExpLiteral = this;
      this.type = 48;
    }

    [LineNumberTable(new byte[] {159, 183, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(string value)
    {
      this.assertNotNull((object) value);
      this.value = value;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFlags(string flags) => this.flags = flags;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getValue() => this.value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getFlags() => this.flags;

    [LineNumberTable(new byte[] {159, 160, 232, 61, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RegExpLiteral()
    {
      RegExpLiteral regExpLiteral = this;
      this.type = 48;
    }

    [LineNumberTable(new byte[] {159, 164, 233, 57, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RegExpLiteral(int pos)
      : base(pos)
    {
      RegExpLiteral regExpLiteral = this;
      this.type = 48;
    }

    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth) => new StringBuilder().append(this.makeIndent(depth)).append("/").append(this.value).append("/").append(this.flags != null ? this.flags : "").toString();

    [LineNumberTable(new byte[] {20, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v) => v.visit((AstNode) this);

    [HideFromJava]
    static RegExpLiteral() => AstNode.__\u003Cclinit\u003E();
  }
}
