// Decompiled with JetBrains decompiler
// Type: rhino.ast.LetNode
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class LetNode : Scope
  {
    private VariableDeclaration variables;
    private AstNode body;
    private int lp;
    private int rp;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 176, 233, 53, 103, 167, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LetNode(int pos)
      : base(pos)
    {
      LetNode letNode = this;
      this.lp = -1;
      this.rp = -1;
      this.type = 159;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLp(int lp) => this.lp = lp;

    [LineNumberTable(new byte[] {3, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVariables(VariableDeclaration variables)
    {
      this.assertNotNull((object) variables);
      this.variables = variables;
      variables.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRp(int rp) => this.rp = rp;

    [LineNumberTable(new byte[] {26, 103, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBody(AstNode body)
    {
      this.body = body;
      body?.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VariableDeclaration getVariables() => this.variables;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getBody() => this.body;

    [LineNumberTable(new byte[] {159, 172, 232, 57, 103, 167, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LetNode()
    {
      LetNode letNode = this;
      this.lp = -1;
      this.rp = -1;
      this.type = 159;
    }

    [LineNumberTable(new byte[] {159, 180, 234, 49, 103, 167, 235, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LetNode(int pos, int len)
      : base(pos, len)
    {
      LetNode letNode = this;
      this.lp = -1;
      this.rp = -1;
      this.type = 159;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLp() => this.lp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getRp() => this.rp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setParens(int lp, int rp)
    {
      this.lp = lp;
      this.rp = rp;
    }

    [LineNumberTable(new byte[] {69, 104, 102, 104, 108, 114, 108, 104, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      string str = this.makeIndent(depth);
      StringBuilder sb = new StringBuilder();
      sb.append(str);
      sb.append("let (");
      this.printList(this.variables.getVariables(), sb);
      sb.append(") ");
      if (this.body != null)
        sb.append(this.body.toSource(depth));
      return sb.toString();
    }

    [LineNumberTable(new byte[] {87, 105, 108, 104, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.variables.visit(v);
      if (this.body == null)
        return;
      this.body.visit(v);
    }

    [HideFromJava]
    static LetNode() => Scope.__\u003Cclinit\u003E();
  }
}
