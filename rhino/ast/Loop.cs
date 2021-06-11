// Decompiled with JetBrains decompiler
// Type: rhino.ast.Loop
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public abstract class Loop : Scope
  {
    protected internal AstNode body;
    protected internal int lp;
    protected internal int rp;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setParens(int lp, int rp)
    {
      this.lp = lp;
      this.rp = rp;
    }

    [LineNumberTable(new byte[] {159, 178, 103, 110, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBody(AstNode body)
    {
      this.body = body;
      this.setLength(body.getPosition() + body.getLength() - this.getPosition());
      body.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getBody() => this.body;

    [LineNumberTable(new byte[] {159, 154, 232, 61, 103, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Loop()
    {
      Loop loop = this;
      this.lp = -1;
      this.rp = -1;
    }

    [LineNumberTable(new byte[] {159, 158, 233, 57, 103, 231, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Loop(int pos)
      : base(pos)
    {
      Loop loop = this;
      this.lp = -1;
      this.rp = -1;
    }

    [LineNumberTable(new byte[] {159, 162, 234, 53, 103, 231, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Loop(int pos, int len)
      : base(pos, len)
    {
      Loop loop = this;
      this.lp = -1;
      this.rp = -1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLp() => this.lp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLp(int lp) => this.lp = lp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getRp() => this.rp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRp(int rp) => this.rp = rp;

    [HideFromJava]
    static Loop() => Scope.__\u003Cclinit\u003E();
  }
}
