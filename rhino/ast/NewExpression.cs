// Decompiled with JetBrains decompiler
// Type: rhino.ast.NewExpression
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class NewExpression : FunctionCall
  {
    private ObjectLiteral initializer;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 170, 233, 57, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NewExpression(int pos)
      : base(pos)
    {
      NewExpression newExpression = this;
      this.type = 30;
    }

    [LineNumberTable(new byte[] {3, 103, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setInitializer(ObjectLiteral initializer)
    {
      this.initializer = initializer;
      initializer?.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectLiteral getInitializer() => this.initializer;

    [LineNumberTable(new byte[] {159, 166, 232, 61, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NewExpression()
    {
      NewExpression newExpression = this;
      this.type = 30;
    }

    [LineNumberTable(new byte[] {159, 174, 234, 53, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NewExpression(int pos, int len)
      : base(pos, len)
    {
      NewExpression newExpression = this;
      this.type = 30;
    }

    [LineNumberTable(new byte[] {10, 102, 110, 108, 115, 108, 104, 141, 108, 104, 108, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder sb = new StringBuilder();
      sb.append(this.makeIndent(depth));
      sb.append("new ");
      sb.append(this.target.toSource(0));
      sb.append("(");
      if (this.arguments != null)
        this.printList(this.arguments, sb);
      sb.append(")");
      if (this.initializer != null)
      {
        sb.append(" ");
        sb.append(this.initializer.toSource(0));
      }
      return sb.toString();
    }

    [LineNumberTable(new byte[] {32, 105, 108, 127, 1, 103, 98, 104, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.target.visit(v);
      Iterator iterator = this.getArguments().iterator();
      while (iterator.hasNext())
        ((AstNode) iterator.next()).visit(v);
      if (this.initializer == null)
        return;
      this.initializer.visit(v);
    }

    [HideFromJava]
    static NewExpression() => FunctionCall.__\u003Cclinit\u003E();
  }
}
