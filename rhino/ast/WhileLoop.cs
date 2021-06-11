// Decompiled with JetBrains decompiler
// Type: rhino.ast.WhileLoop
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class WhileLoop : Loop
  {
    private AstNode condition;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 165, 233, 57, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WhileLoop(int pos)
      : base(pos)
    {
      WhileLoop whileLoop = this;
      this.type = 118;
    }

    [LineNumberTable(new byte[] {159, 184, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCondition(AstNode condition)
    {
      this.assertNotNull((object) condition);
      this.condition = condition;
      condition.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getCondition() => this.condition;

    [LineNumberTable(new byte[] {159, 161, 232, 61, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WhileLoop()
    {
      WhileLoop whileLoop = this;
      this.type = 118;
    }

    [LineNumberTable(new byte[] {159, 169, 234, 53, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WhileLoop(int pos, int len)
      : base(pos, len)
    {
      WhileLoop whileLoop = this;
      this.type = 118;
    }

    [LineNumberTable(new byte[] {159, 191, 102, 110, 108, 115, 108, 104, 159, 0, 114, 120, 142, 104, 140, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(this.makeIndent(depth));
      stringBuilder.append("while (");
      stringBuilder.append(this.condition.toSource(0));
      stringBuilder.append(") ");
      if (this.getInlineComment() != null)
        stringBuilder.append(this.getInlineComment().toSource(depth + 1)).append("\n");
      if (this.body.getType() == 130)
      {
        stringBuilder.append(String.instancehelper_trim(this.body.toSource(depth)));
        stringBuilder.append("\n");
      }
      else
      {
        if (this.getInlineComment() == null)
          stringBuilder.append("\n");
        stringBuilder.append(this.body.toSource(depth + 1));
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {24, 105, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.condition.visit(v);
      this.body.visit(v);
    }

    [HideFromJava]
    static WhileLoop() => Loop.__\u003Cclinit\u003E();
  }
}
