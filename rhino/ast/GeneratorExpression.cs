// Decompiled with JetBrains decompiler
// Type: rhino.ast.GeneratorExpression
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class GeneratorExpression : Scope
  {
    private AstNode result;
    [Modifiers]
    [Signature("Ljava/util/List<Lrhino/ast/GeneratorExpressionLoop;>;")]
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

    [LineNumberTable(new byte[] {159, 174, 234, 45, 171, 103, 103, 167, 235, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GeneratorExpression(int pos, int len)
      : base(pos, len)
    {
      GeneratorExpression generatorExpression = this;
      this.loops = (List) new ArrayList();
      this.ifPosition = -1;
      this.lp = -1;
      this.rp = -1;
      this.type = 163;
    }

    [LineNumberTable(new byte[] {159, 189, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setResult(AstNode result)
    {
      this.assertNotNull((object) result);
      this.result = result;
      result.setParent((AstNode) this);
    }

    [Signature("(Ljava/util/List<Lrhino/ast/GeneratorExpressionLoop;>;)V")]
    [LineNumberTable(new byte[] {14, 103, 107, 123, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLoops(List loops)
    {
      this.assertNotNull((object) loops);
      this.loops.clear();
      Iterator iterator = loops.iterator();
      while (iterator.hasNext())
        this.addLoop((GeneratorExpressionLoop) iterator.next());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIfPosition(int ifPosition) => this.ifPosition = ifPosition;

    [LineNumberTable(new byte[] {43, 103, 99, 103})]
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

    [Signature("()Ljava/util/List<Lrhino/ast/GeneratorExpressionLoop;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getLoops() => this.loops;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getFilter() => this.filter;

    [LineNumberTable(new byte[] {26, 103, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addLoop(GeneratorExpressionLoop acl)
    {
      this.assertNotNull((object) acl);
      this.loops.add((object) acl);
      acl.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {159, 166, 232, 53, 171, 103, 103, 167, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GeneratorExpression()
    {
      GeneratorExpression generatorExpression = this;
      this.loops = (List) new ArrayList();
      this.ifPosition = -1;
      this.lp = -1;
      this.rp = -1;
      this.type = 163;
    }

    [LineNumberTable(new byte[] {159, 170, 233, 49, 171, 103, 103, 167, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GeneratorExpression(int pos)
      : base(pos)
    {
      GeneratorExpression generatorExpression = this;
      this.loops = (List) new ArrayList();
      this.ifPosition = -1;
      this.lp = -1;
      this.rp = -1;
      this.type = 163;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getIfPosition() => this.ifPosition;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFilterLp() => this.lp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFilterRp() => this.rp;

    [LineNumberTable(new byte[] {92, 107, 108, 115, 127, 1, 110, 98, 104, 108, 115, 140, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder(250);
      stringBuilder.append("(");
      stringBuilder.append(this.result.toSource(0));
      Iterator iterator = this.loops.iterator();
      while (iterator.hasNext())
      {
        GeneratorExpressionLoop generatorExpressionLoop = (GeneratorExpressionLoop) iterator.next();
        stringBuilder.append(generatorExpressionLoop.toSource(0));
      }
      if (this.filter != null)
      {
        stringBuilder.append(" if (");
        stringBuilder.append(this.filter.toSource(0));
        stringBuilder.append(")");
      }
      stringBuilder.append(")");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {113, 105, 129, 108, 127, 1, 103, 98, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.result.visit(v);
      Iterator iterator = this.loops.iterator();
      while (iterator.hasNext())
        ((GeneratorExpressionLoop) iterator.next()).visit(v);
      if (this.filter == null)
        return;
      this.filter.visit(v);
    }

    [HideFromJava]
    static GeneratorExpression() => Scope.__\u003Cclinit\u003E();
  }
}
