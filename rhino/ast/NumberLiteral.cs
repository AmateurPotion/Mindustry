// Decompiled with JetBrains decompiler
// Type: rhino.ast.NumberLiteral
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class NumberLiteral : AstNode
  {
    private string value;
    private double number;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 183, 106, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NumberLiteral(int pos, string value, double number)
      : this(pos, value)
    {
      NumberLiteral numberLiteral = this;
      this.setDouble(number);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double getNumber() => this.number;

    [LineNumberTable(new byte[] {159, 159, 232, 61, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NumberLiteral()
    {
      NumberLiteral numberLiteral = this;
      this.type = 40;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setNumber(double value) => this.number = value;

    [LineNumberTable(new byte[] {12, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(string value)
    {
      this.assertNotNull((object) value);
      this.value = value;
    }

    [LineNumberTable(new byte[] {159, 174, 233, 46, 232, 83, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NumberLiteral(int pos, string value)
      : base(pos)
    {
      NumberLiteral numberLiteral = this;
      this.type = 40;
      this.setValue(value);
      this.setLength(String.instancehelper_length(value));
    }

    [LineNumberTable(new byte[] {159, 163, 233, 57, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NumberLiteral(int pos)
      : base(pos)
    {
      NumberLiteral numberLiteral = this;
      this.type = 40;
    }

    [LineNumberTable(new byte[] {159, 167, 234, 53, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NumberLiteral(int pos, int len)
      : base(pos, len)
    {
      NumberLiteral numberLiteral = this;
      this.type = 40;
    }

    [LineNumberTable(new byte[] {159, 187, 232, 33, 232, 96, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NumberLiteral(double number)
    {
      NumberLiteral numberLiteral = this;
      this.type = 40;
      this.setDouble(number);
      this.setValue(Double.toString(number));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getValue() => this.value;

    [LineNumberTable(82)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth) => new StringBuilder().append(this.makeIndent(depth)).append(this.value != null ? this.value : "<null>").toString();

    [LineNumberTable(new byte[] {40, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v) => v.visit((AstNode) this);

    [HideFromJava]
    static NumberLiteral() => AstNode.__\u003Cclinit\u003E();
  }
}
