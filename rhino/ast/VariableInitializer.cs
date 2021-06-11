// Decompiled with JetBrains decompiler
// Type: rhino.ast.VariableInitializer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class VariableInitializer : AstNode
  {
    private AstNode target;
    private AstNode initializer;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 185, 234, 40, 232, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VariableInitializer(int pos, int len)
      : base(pos, len)
    {
      VariableInitializer variableInitializer = this;
      this.type = 123;
    }

    [LineNumberTable(new byte[] {22, 99, 112, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTarget(AstNode target)
    {
      if (target == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("invalid target arg");
      }
      this.target = target;
      target.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {40, 103, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setInitializer(AstNode initializer)
    {
      this.initializer = initializer;
      initializer?.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getTarget() => this.target;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getInitializer() => this.initializer;

    [LineNumberTable(54)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDestructuring() => !(this.target is Name);

    [LineNumberTable(new byte[] {159, 170, 181, 112, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setNodeType(int nodeType)
    {
      if (nodeType != 123 && nodeType != 155 && nodeType != 154)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("invalid node type");
      }
      this.setType(nodeType);
    }

    [LineNumberTable(new byte[] {159, 177, 232, 48, 232, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VariableInitializer()
    {
      VariableInitializer variableInitializer = this;
      this.type = 123;
    }

    [LineNumberTable(new byte[] {159, 181, 233, 44, 232, 85})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VariableInitializer(int pos)
      : base(pos)
    {
      VariableInitializer variableInitializer = this;
      this.type = 123;
    }

    [LineNumberTable(new byte[] {47, 102, 110, 115, 104, 108, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(this.makeIndent(depth));
      stringBuilder.append(this.target.toSource(0));
      if (this.initializer != null)
      {
        stringBuilder.append(" = ");
        stringBuilder.append(this.initializer.toSource(0));
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {63, 105, 108, 104, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.target.visit(v);
      if (this.initializer == null)
        return;
      this.initializer.visit(v);
    }

    [HideFromJava]
    static VariableInitializer() => AstNode.__\u003Cclinit\u003E();
  }
}
