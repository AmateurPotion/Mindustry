// Decompiled with JetBrains decompiler
// Type: rhino.ast.ArrayComprehension
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class ArrayComprehension : Scope
  {
    private AstNode result;
    [Modifiers]
    [Signature("Ljava/util/List<Lrhino/ast/ArrayComprehensionLoop;>;")]
    private List loops;
    private AstNode filter;
    private int ifPosition;
    private int lp;
    private int rp;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 175, 234, 45, 171, 103, 103, 167, 235, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArrayComprehension(int pos, int len)
      : base(pos, len)
    {
      ArrayComprehension arrayComprehension = this;
      this.loops = (List) new ArrayList();
      this.ifPosition = -1;
      this.lp = -1;
      this.rp = -1;
      this.type = 158;
    }

    [LineNumberTable(new byte[] {159, 190, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setResult(AstNode result)
    {
      this.assertNotNull((object) result);
      this.result = result;
      result.setParent((AstNode) this);
    }

    [Signature("(Ljava/util/List<Lrhino/ast/ArrayComprehensionLoop;>;)V")]
    [LineNumberTable(new byte[] {15, 103, 107, 123, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLoops(List loops)
    {
      this.assertNotNull((object) loops);
      this.loops.clear();
      Iterator iterator = loops.iterator();
      while (iterator.hasNext())
        this.addLoop((ArrayComprehensionLoop) iterator.next());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIfPosition(int ifPosition) => this.ifPosition = ifPosition;

    [LineNumberTable(new byte[] {44, 103, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFilter(AstNode filter)
    {
      this.filter = filter;
      filter?.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFilterLp(int lp) => this.lp = lp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFilterRp(int rp) => this.rp = rp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getResult() => this.result;

    [Signature("()Ljava/util/List<Lrhino/ast/ArrayComprehensionLoop;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getLoops() => this.loops;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getFilter() => this.filter;

    [LineNumberTable(new byte[] {27, 103, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addLoop(ArrayComprehensionLoop acl)
    {
      this.assertNotNull((object) acl);
      this.loops.add((object) acl);
      acl.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {159, 167, 232, 53, 171, 103, 103, 167, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArrayComprehension()
    {
      ArrayComprehension arrayComprehension = this;
      this.loops = (List) new ArrayList();
      this.ifPosition = -1;
      this.lp = -1;
      this.rp = -1;
      this.type = 158;
    }

    [LineNumberTable(new byte[] {159, 171, 233, 49, 171, 103, 103, 167, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArrayComprehension(int pos)
      : base(pos)
    {
      ArrayComprehension arrayComprehension = this;
      this.loops = (List) new ArrayList();
      this.ifPosition = -1;
      this.lp = -1;
      this.rp = -1;
      this.type = 158;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getIfPosition() => this.ifPosition;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFilterLp() => this.lp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFilterRp() => this.rp;

    [LineNumberTable(new byte[] {93, 107, 108, 115, 127, 1, 110, 98, 104, 108, 115, 140, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder(250);
      stringBuilder.append("[");
      stringBuilder.append(this.result.toSource(0));
      Iterator iterator = this.loops.iterator();
      while (iterator.hasNext())
      {
        ArrayComprehensionLoop comprehensionLoop = (ArrayComprehensionLoop) iterator.next();
        stringBuilder.append(comprehensionLoop.toSource(0));
      }
      if (this.filter != null)
      {
        stringBuilder.append(" if (");
        stringBuilder.append(this.filter.toSource(0));
        stringBuilder.append(")");
      }
      stringBuilder.append("]");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {114, 105, 129, 108, 127, 1, 103, 98, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.result.visit(v);
      Iterator iterator = this.loops.iterator();
      while (iterator.hasNext())
        ((ArrayComprehensionLoop) iterator.next()).visit(v);
      if (this.filter == null)
        return;
      this.filter.visit(v);
    }

    [HideFromJava]
    static ArrayComprehension() => Scope.__\u003Cclinit\u003E();
  }
}
