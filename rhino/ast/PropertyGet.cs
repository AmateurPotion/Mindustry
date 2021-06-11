// Decompiled with JetBrains decompiler
// Type: rhino.ast.PropertyGet
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class PropertyGet : InfixExpression
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 180, 237, 37, 232, 92})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PropertyGet(AstNode target, Name property, int dotPosition)
      : base(33, target, (AstNode) property, dotPosition)
    {
      PropertyGet propertyGet = this;
      this.type = 33;
    }

    [LineNumberTable(new byte[] {159, 156, 232, 61, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PropertyGet()
    {
      PropertyGet propertyGet = this;
      this.type = 33;
    }

    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Name getProperty() => (Name) this.getRight();

    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getTarget() => this.getLeft();

    [LineNumberTable(new byte[] {159, 160, 233, 57, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PropertyGet(int pos)
      : base(pos)
    {
      PropertyGet propertyGet = this;
      this.type = 33;
    }

    [LineNumberTable(new byte[] {159, 164, 234, 53, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PropertyGet(int pos, int len)
      : base(pos, len)
    {
      PropertyGet propertyGet = this;
      this.type = 33;
    }

    [LineNumberTable(new byte[] {159, 168, 237, 49, 232, 80})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PropertyGet(int pos, int len, AstNode target, Name property)
      : base(pos, len, target, (AstNode) property)
    {
      PropertyGet propertyGet = this;
      this.type = 33;
    }

    [LineNumberTable(new byte[] {159, 176, 234, 41, 232, 88})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PropertyGet(AstNode target, Name property)
      : base(target, (AstNode) property)
    {
      PropertyGet propertyGet = this;
      this.type = 33;
    }

    [LineNumberTable(new byte[] {6, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTarget(AstNode target) => this.setLeft(target);

    [LineNumberTable(new byte[] {21, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setProperty(Name property) => this.setRight((AstNode) property);

    [LineNumberTable(new byte[] {26, 114, 155, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth) => new StringBuilder().append(this.makeIndent(depth)).append(this.getLeft().toSource(0)).append(".").append(this.getRight().toSource(0)).toString();

    [LineNumberTable(new byte[] {38, 105, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.getTarget().visit(v);
      this.getProperty().visit(v);
    }

    [HideFromJava]
    static PropertyGet() => InfixExpression.__\u003Cclinit\u003E();
  }
}
