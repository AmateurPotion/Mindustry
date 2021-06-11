// Decompiled with JetBrains decompiler
// Type: rhino.ast.ForLoop
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class ForLoop : Loop
  {
    private AstNode initializer;
    private AstNode condition;
    private AstNode increment;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 168, 233, 57, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ForLoop(int pos)
      : base(pos)
    {
      ForLoop forLoop = this;
      this.type = 120;
    }

    [LineNumberTable(new byte[] {2, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setInitializer(AstNode initializer)
    {
      this.assertNotNull((object) initializer);
      this.initializer = initializer;
      initializer.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {21, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCondition(AstNode condition)
    {
      this.assertNotNull((object) condition);
      this.condition = condition;
      condition.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {41, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIncrement(AstNode increment)
    {
      this.assertNotNull((object) increment);
      this.increment = increment;
      increment.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getInitializer() => this.initializer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getCondition() => this.condition;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getIncrement() => this.increment;

    [LineNumberTable(new byte[] {159, 164, 232, 61, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ForLoop()
    {
      ForLoop forLoop = this;
      this.type = 120;
    }

    [LineNumberTable(new byte[] {159, 172, 234, 53, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ForLoop(int pos, int len)
      : base(pos, len)
    {
      ForLoop forLoop = this;
      this.type = 120;
    }

    [LineNumberTable(new byte[] {48, 102, 110, 108, 115, 108, 115, 108, 115, 108, 104, 156, 114, 109, 104, 135, 114, 98, 104, 140, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(this.makeIndent(depth));
      stringBuilder.append("for (");
      stringBuilder.append(this.initializer.toSource(0));
      stringBuilder.append("; ");
      stringBuilder.append(this.condition.toSource(0));
      stringBuilder.append("; ");
      stringBuilder.append(this.increment.toSource(0));
      stringBuilder.append(") ");
      if (this.getInlineComment() != null)
        stringBuilder.append(this.getInlineComment().toSource()).append("\n");
      if (this.body.getType() == 130)
      {
        string str = this.body.toSource(depth);
        if (this.getInlineComment() == null)
          str = String.instancehelper_trim(str);
        stringBuilder.append(str).append("\n");
      }
      else
      {
        if (this.getInlineComment() == null)
          stringBuilder.append("\n");
        stringBuilder.append(this.body.toSource(depth + 1));
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {81, 105, 108, 108, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.initializer.visit(v);
      this.condition.visit(v);
      this.increment.visit(v);
      this.body.visit(v);
    }

    [HideFromJava]
    static ForLoop() => Loop.__\u003Cclinit\u003E();
  }
}
