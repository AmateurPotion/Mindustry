// Decompiled with JetBrains decompiler
// Type: rhino.ast.BreakStatement
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class BreakStatement : Jump
  {
    private Name breakLabel;
    private AstNode target;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 170, 232, 53, 232, 76, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BreakStatement(int pos, int len)
    {
      BreakStatement breakStatement = this;
      this.type = 121;
      this.position = pos;
      this.length = len;
    }

    [LineNumberTable(new byte[] {159, 191, 103, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBreakLabel(Name label)
    {
      this.breakLabel = label;
      label?.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {19, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBreakTarget(Jump target)
    {
      this.assertNotNull((object) target);
      this.target = (AstNode) target;
      this.setJumpStatement(target);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Name getBreakLabel() => this.breakLabel;

    [LineNumberTable(new byte[] {159, 162, 232, 61, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BreakStatement()
    {
      BreakStatement breakStatement = this;
      this.type = 121;
    }

    [LineNumberTable(new byte[] {159, 165, 232, 58, 232, 72, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BreakStatement(int pos)
    {
      BreakStatement breakStatement = this;
      this.type = 121;
      this.position = pos;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getBreakTarget() => this.target;

    [LineNumberTable(new byte[] {26, 102, 110, 108, 104, 108, 147, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(this.makeIndent(depth));
      stringBuilder.append("break");
      if (this.breakLabel != null)
      {
        stringBuilder.append(" ");
        stringBuilder.append(this.breakLabel.toSource(0));
      }
      stringBuilder.append(";\n");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {42, 113, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this) || this.breakLabel == null)
        return;
      this.breakLabel.visit(v);
    }

    [HideFromJava]
    static BreakStatement() => Jump.__\u003Cclinit\u003E();
  }
}
