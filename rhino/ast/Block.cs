// Decompiled with JetBrains decompiler
// Type: rhino.ast.Block
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class Block : AstNode
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 165, 233, 57, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Block(int pos)
      : base(pos)
    {
      Block block = this;
      this.type = 130;
    }

    [LineNumberTable(new byte[] {159, 176, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addStatement(AstNode statement) => this.addChild(statement);

    [LineNumberTable(new byte[] {159, 161, 232, 61, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Block()
    {
      Block block = this;
      this.type = 130;
    }

    [LineNumberTable(new byte[] {159, 169, 234, 53, 235, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Block(int pos, int len)
      : base(pos, len)
    {
      Block block = this;
      this.type = 130;
    }

    [LineNumberTable(new byte[] {159, 181, 102, 110, 108, 123, 103, 112, 109, 140, 98, 110, 108, 104, 147, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(this.makeIndent(depth));
      stringBuilder.append("{\n");
      Iterator iterator = this.iterator();
      while (iterator.hasNext())
      {
        AstNode astNode = (AstNode) iterator.next();
        stringBuilder.append(astNode.toSource(depth + 1));
        if (astNode.getType() == 162)
          stringBuilder.append("\n");
      }
      stringBuilder.append(this.makeIndent(depth));
      stringBuilder.append("}");
      if (this.getInlineComment() != null)
        stringBuilder.append(this.getInlineComment().toSource(depth));
      stringBuilder.append("\n");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {10, 105, 123, 108, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      Iterator iterator = this.iterator();
      while (iterator.hasNext())
        ((AstNode) iterator.next()).visit(v);
    }

    [HideFromJava]
    static Block() => AstNode.__\u003Cclinit\u003E();
  }
}
