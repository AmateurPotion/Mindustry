// Decompiled with JetBrains decompiler
// Type: rhino.ast.ContinueStatement
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class ContinueStatement : Jump
  {
    private Name label;
    private Loop target;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 170, 232, 54, 232, 76, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ContinueStatement(int pos, int len)
    {
      ContinueStatement continueStatement = this;
      this.type = 122;
      this.position = pos;
      this.length = len;
    }

    [LineNumberTable(new byte[] {12, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTarget(Loop target)
    {
      this.assertNotNull((object) target);
      this.target = target;
      this.setJumpStatement((Jump) target);
    }

    [LineNumberTable(new byte[] {32, 103, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLabel(Name label)
    {
      this.label = label;
      label?.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Name getLabel() => this.label;

    [LineNumberTable(new byte[] {159, 167, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ContinueStatement(int pos)
      : this(pos, -1)
    {
    }

    [LineNumberTable(new byte[] {159, 163, 232, 61, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ContinueStatement()
    {
      ContinueStatement continueStatement = this;
      this.type = 122;
    }

    [LineNumberTable(new byte[] {159, 176, 232, 48, 232, 81, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ContinueStatement(Name label)
    {
      ContinueStatement continueStatement = this;
      this.type = 122;
      this.setLabel(label);
    }

    [LineNumberTable(new byte[] {159, 181, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ContinueStatement(int pos, Name label)
      : this(pos)
    {
      ContinueStatement continueStatement = this;
      this.setLabel(label);
    }

    [LineNumberTable(new byte[] {159, 186, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ContinueStatement(int pos, int len, Name label)
      : this(pos, len)
    {
      ContinueStatement continueStatement = this;
      this.setLabel(label);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Loop getTarget() => this.target;

    [LineNumberTable(new byte[] {39, 102, 110, 108, 104, 108, 147, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(this.makeIndent(depth));
      stringBuilder.append("continue");
      if (this.label != null)
      {
        stringBuilder.append(" ");
        stringBuilder.append(this.label.toSource(0));
      }
      stringBuilder.append(";\n");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {55, 113, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this) || this.label == null)
        return;
      this.label.visit(v);
    }

    [HideFromJava]
    static ContinueStatement() => Jump.__\u003Cclinit\u003E();
  }
}
