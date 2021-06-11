// Decompiled with JetBrains decompiler
// Type: rhino.ast.ElementGet
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class ElementGet : AstNode
  {
    private AstNode target;
    private AstNode element;
    private int lb;
    private int rb;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 177, 234, 49, 103, 167, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ElementGet(int pos, int len)
      : base(pos, len)
    {
      ElementGet elementGet = this;
      this.lb = -1;
      this.rb = -1;
      this.type = 36;
    }

    [LineNumberTable(new byte[] {7, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTarget(AstNode target)
    {
      this.assertNotNull((object) target);
      this.target = target;
      target.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {24, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setElement(AstNode element)
    {
      this.assertNotNull((object) element);
      this.element = element;
      element.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setParens(int lb, int rb)
    {
      this.lb = lb;
      this.rb = rb;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getTarget() => this.target;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getElement() => this.element;

    [LineNumberTable(new byte[] {159, 169, 232, 57, 103, 167, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ElementGet()
    {
      ElementGet elementGet = this;
      this.lb = -1;
      this.rb = -1;
      this.type = 36;
    }

    [LineNumberTable(new byte[] {159, 173, 233, 53, 103, 167, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ElementGet(int pos)
      : base(pos)
    {
      ElementGet elementGet = this;
      this.lb = -1;
      this.rb = -1;
      this.type = 36;
    }

    [LineNumberTable(new byte[] {159, 180, 232, 46, 103, 167, 232, 79, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ElementGet(AstNode target, AstNode element)
    {
      ElementGet elementGet = this;
      this.lb = -1;
      this.rb = -1;
      this.type = 36;
      this.setTarget(target);
      this.setElement(element);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLb() => this.lb;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLb(int lb) => this.lb = lb;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getRb() => this.rb;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRb(int rb) => this.rb = rb;

    [LineNumberTable(new byte[] {64, 120, 155, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth) => new StringBuilder().append(this.makeIndent(depth)).append(this.target.toSource(0)).append("[").append(this.element.toSource(0)).append("]").toString();

    [LineNumberTable(new byte[] {77, 105, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.target.visit(v);
      this.element.visit(v);
    }

    [HideFromJava]
    static ElementGet() => AstNode.__\u003Cclinit\u003E();
  }
}
