// Decompiled with JetBrains decompiler
// Type: rhino.ast.FunctionCall
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class FunctionCall : AstNode
  {
    [Signature("Ljava/util/List<Lrhino/ast/AstNode;>;")]
    internal static List __\u003C\u003ENO_ARGS;
    protected internal AstNode target;
    [Signature("Ljava/util/List<Lrhino/ast/AstNode;>;")]
    protected internal List arguments;
    protected internal int lp;
    protected internal int rp;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 191, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTarget(AstNode target)
    {
      this.assertNotNull((object) target);
      this.target = target;
      target.setParent((AstNode) this);
    }

    [Signature("(Ljava/util/List<Lrhino/ast/AstNode;>;)V")]
    [LineNumberTable(new byte[] {19, 99, 137, 104, 107, 123, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setArguments(List arguments)
    {
      if (arguments == null)
      {
        this.arguments = (List) null;
      }
      else
      {
        if (this.arguments != null)
          this.arguments.clear();
        Iterator iterator = arguments.iterator();
        while (iterator.hasNext())
          this.addArgument((AstNode) iterator.next());
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setParens(int lp, int rp)
    {
      this.lp = lp;
      this.rp = rp;
    }

    [LineNumberTable(new byte[] {159, 170, 233, 53, 103, 167, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FunctionCall(int pos)
      : base(pos)
    {
      FunctionCall functionCall = this;
      this.lp = -1;
      this.rp = -1;
      this.type = 38;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLp(int lp) => this.lp = lp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRp(int rp) => this.rp = rp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getTarget() => this.target;

    [Signature("()Ljava/util/List<Lrhino/ast/AstNode;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getArguments() => this.arguments != null ? this.arguments : FunctionCall.__\u003C\u003ENO_ARGS;

    [LineNumberTable(new byte[] {36, 103, 104, 139, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addArgument(AstNode arg)
    {
      this.assertNotNull((object) arg);
      if (this.arguments == null)
        this.arguments = (List) new ArrayList();
      this.arguments.add((object) arg);
      arg.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {159, 166, 232, 57, 103, 167, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FunctionCall()
    {
      FunctionCall functionCall = this;
      this.lp = -1;
      this.rp = -1;
      this.type = 38;
    }

    [LineNumberTable(new byte[] {159, 174, 234, 49, 103, 167, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FunctionCall(int pos, int len)
      : base(pos, len)
    {
      FunctionCall functionCall = this;
      this.lp = -1;
      this.rp = -1;
      this.type = 38;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLp() => this.lp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getRp() => this.rp;

    [LineNumberTable(new byte[] {83, 102, 110, 115, 108, 104, 141, 108, 104, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder sb = new StringBuilder();
      sb.append(this.makeIndent(depth));
      sb.append(this.target.toSource(0));
      sb.append("(");
      if (this.arguments != null)
        this.printList(this.arguments, sb);
      sb.append(")");
      if (this.getInlineComment() != null)
        sb.append(this.getInlineComment().toSource(depth)).append("\n");
      return sb.toString();
    }

    [LineNumberTable(new byte[] {102, 105, 108, 127, 1, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.target.visit(v);
      Iterator iterator = this.getArguments().iterator();
      while (iterator.hasNext())
        ((AstNode) iterator.next()).visit(v);
    }

    [LineNumberTable(new byte[] {159, 139, 82, 101, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static FunctionCall()
    {
      AstNode.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.ast.FunctionCall"))
        return;
      FunctionCall.__\u003C\u003ENO_ARGS = Collections.unmodifiableList((List) new ArrayList());
    }

    [Modifiers]
    protected internal static List NO_ARGS
    {
      [HideFromJava] get => FunctionCall.__\u003C\u003ENO_ARGS;
    }
  }
}
