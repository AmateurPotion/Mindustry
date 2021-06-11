// Decompiled with JetBrains decompiler
// Type: rhino.ast.ForInLoop
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class ForInLoop : Loop
  {
    protected internal AstNode iterator;
    protected internal AstNode iteratedObject;
    protected internal int inPosition;
    protected internal int eachPosition;
    protected internal bool isForEach;
    protected internal bool isForOf;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 172, 233, 51, 103, 231, 69, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ForInLoop(int pos)
      : base(pos)
    {
      ForInLoop forInLoop = this;
      this.inPosition = -1;
      this.eachPosition = -1;
      this.type = 120;
    }

    [LineNumberTable(new byte[] {0, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIterator(AstNode iterator)
    {
      this.assertNotNull((object) iterator);
      this.iterator = iterator;
      iterator.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {17, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIteratedObject(AstNode @object)
    {
      this.assertNotNull((object) @object);
      this.iteratedObject = @object;
      @object.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setInPosition(int inPosition) => this.inPosition = inPosition;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIsForEach(bool isForEach) => this.isForEach = isForEach;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setEachPosition(int eachPosition) => this.eachPosition = eachPosition;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIsForOf(bool isForOf) => this.isForOf = isForOf;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isForEach() => this.isForEach;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getIterator() => this.iterator;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isForOf() => this.isForOf;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getIteratedObject() => this.iteratedObject;

    [LineNumberTable(new byte[] {84, 102, 110, 108, 104, 140, 108, 115, 104, 142, 140, 115, 108, 114, 159, 5, 159, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(this.makeIndent(depth));
      stringBuilder.append("for ");
      if (this.isForEach())
        stringBuilder.append("each ");
      stringBuilder.append("(");
      stringBuilder.append(this.iterator.toSource(0));
      if (this.isForOf)
        stringBuilder.append(" of ");
      else
        stringBuilder.append(" in ");
      stringBuilder.append(this.iteratedObject.toSource(0));
      stringBuilder.append(") ");
      if (this.body.getType() == 130)
        stringBuilder.append(String.instancehelper_trim(this.body.toSource(depth))).append("\n");
      else
        stringBuilder.append("\n").append(this.body.toSource(depth + 1));
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {112, 105, 108, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.iterator.visit(v);
      this.iteratedObject.visit(v);
      this.body.visit(v);
    }

    [LineNumberTable(new byte[] {159, 168, 232, 55, 103, 231, 69, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ForInLoop()
    {
      ForInLoop forInLoop = this;
      this.inPosition = -1;
      this.eachPosition = -1;
      this.type = 120;
    }

    [LineNumberTable(new byte[] {159, 176, 234, 47, 103, 231, 69, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ForInLoop(int pos, int len)
      : base(pos, len)
    {
      ForInLoop forInLoop = this;
      this.inPosition = -1;
      this.eachPosition = -1;
      this.type = 120;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getInPosition() => this.inPosition;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getEachPosition() => this.eachPosition;

    [HideFromJava]
    static ForInLoop() => Loop.__\u003Cclinit\u003E();
  }
}
