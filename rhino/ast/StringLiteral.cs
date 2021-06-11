// Decompiled with JetBrains decompiler
// Type: rhino.ast.StringLiteral
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class StringLiteral : AstNode
  {
    private string value;
    private char quoteChar;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getValue() => this.value;

    [LineNumberTable(new byte[] {159, 172, 234, 49, 232, 80})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StringLiteral(int pos, int len)
      : base(pos, len)
    {
      StringLiteral stringLiteral = this;
      this.type = 41;
    }

    [LineNumberTable(new byte[] {7, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(string value)
    {
      this.assertNotNull((object) value);
      this.value = value;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setQuoteCharacter(char c) => this.quoteChar = c;

    [LineNumberTable(new byte[] {159, 131, 130, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getValue(bool includeQuotes) => !includeQuotes ? this.value : new StringBuilder().append(this.quoteChar).append(this.value).append(this.quoteChar).toString();

    [LineNumberTable(new byte[] {159, 160, 232, 61, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StringLiteral()
    {
      StringLiteral stringLiteral = this;
      this.type = 41;
    }

    [LineNumberTable(new byte[] {159, 164, 233, 57, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StringLiteral(int pos)
      : base(pos)
    {
      StringLiteral stringLiteral = this;
      this.type = 41;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual char getQuoteCharacter() => this.quoteChar;

    [LineNumberTable(new byte[] {24, 159, 9, 26})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth) => new StringBuilder().append(this.makeIndent(depth)).append(this.quoteChar).append(ScriptRuntime.escapeString(this.value, this.quoteChar)).append(this.quoteChar).toString();

    [LineNumberTable(new byte[] {35, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v) => v.visit((AstNode) this);

    [HideFromJava]
    static StringLiteral() => AstNode.__\u003Cclinit\u003E();
  }
}
