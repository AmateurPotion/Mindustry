// Decompiled with JetBrains decompiler
// Type: rhino.ast.DoLoop
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class DoLoop : Loop
  {
    private AstNode condition;
    private int whilePosition;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 233, 54, 167, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DoLoop(int pos)
      : base(pos)
    {
      DoLoop doLoop = this;
      this.whilePosition = -1;
      this.type = 119;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWhilePosition(int whilePosition) => this.whilePosition = whilePosition;

    [LineNumberTable(new byte[] {159, 185, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCondition(AstNode condition)
    {
      this.assertNotNull((object) condition);
      this.condition = condition;
      condition.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getCondition() => this.condition;

    [LineNumberTable(new byte[] {159, 162, 232, 58, 167, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DoLoop()
    {
      DoLoop doLoop = this;
      this.whilePosition = -1;
      this.type = 119;
    }

    [LineNumberTable(new byte[] {159, 170, 234, 50, 167, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DoLoop(int pos, int len)
      : base(pos, len)
    {
      DoLoop doLoop = this;
      this.whilePosition = -1;
      this.type = 119;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getWhilePosition() => this.whilePosition;

    [LineNumberTable(new byte[] {14, 102, 110, 108, 104, 159, 0, 120, 108, 115, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(this.makeIndent(depth));
      stringBuilder.append("do ");
      if (this.getInlineComment() != null)
        stringBuilder.append(this.getInlineComment().toSource(depth + 1)).append("\n");
      stringBuilder.append(String.instancehelper_trim(this.body.toSource(depth)));
      stringBuilder.append(" while (");
      stringBuilder.append(this.condition.toSource(0));
      stringBuilder.append(");\n");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {32, 105, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.body.visit(v);
      this.condition.visit(v);
    }

    [HideFromJava]
    static DoLoop() => Loop.__\u003Cclinit\u003E();
  }
}
