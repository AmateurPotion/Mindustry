// Decompiled with JetBrains decompiler
// Type: rhino.ast.VariableDeclaration
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class VariableDeclaration : AstNode
  {
    [Modifiers]
    [Signature("Ljava/util/List<Lrhino/ast/VariableInitializer;>;")]
    private List variables;
    private bool isStatement;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Signature("()Ljava/util/List<Lrhino/ast/VariableInitializer;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getVariables() => this.variables;

    [LineNumberTable(new byte[] {159, 175, 233, 53, 203, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VariableDeclaration(int pos)
      : base(pos)
    {
      VariableDeclaration variableDeclaration = this;
      this.variables = (List) new ArrayList();
      this.type = 123;
    }

    [LineNumberTable(new byte[] {26, 181, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Node setType(int type)
    {
      if (type != 123 && type != 155 && type != 154)
      {
        string str = new StringBuilder().append("invalid decl type: ").append(type).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return base.setType(type);
    }

    [LineNumberTable(new byte[] {15, 103, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addVariable(VariableInitializer v)
    {
      this.assertNotNull((object) v);
      this.variables.add((object) v);
      v.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIsStatement(bool isStatement) => this.isStatement = isStatement;

    [LineNumberTable(new byte[] {97, 105, 127, 1, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      Iterator iterator = this.variables.iterator();
      while (iterator.hasNext())
        ((AstNode) iterator.next()).visit(v);
    }

    [LineNumberTable(121)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string declTypeName() => String.instancehelper_toLowerCase(Token.typeToName(this.type), (Locale) Locale.ROOT);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isStatement() => this.isStatement;

    [LineNumberTable(new byte[] {159, 171, 232, 57, 203, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VariableDeclaration()
    {
      VariableDeclaration variableDeclaration = this;
      this.variables = (List) new ArrayList();
      this.type = 123;
    }

    [LineNumberTable(new byte[] {159, 179, 234, 49, 203, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VariableDeclaration(int pos, int len)
      : base(pos, len)
    {
      VariableDeclaration variableDeclaration = this;
      this.variables = (List) new ArrayList();
      this.type = 123;
    }

    [Signature("(Ljava/util/List<Lrhino/ast/VariableInitializer;>;)V")]
    [LineNumberTable(new byte[] {2, 103, 107, 123, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVariables(List variables)
    {
      this.assertNotNull((object) variables);
      this.variables.clear();
      Iterator iterator = variables.iterator();
      while (iterator.hasNext())
        this.addVariable((VariableInitializer) iterator.next());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isVar() => this.type == 123;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isConst() => this.type == 155;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLet() => this.type == 154;

    [LineNumberTable(new byte[] {76, 102, 110, 109, 108, 109, 104, 140, 104, 127, 0, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder sb = new StringBuilder();
      sb.append(this.makeIndent(depth));
      sb.append(this.declTypeName());
      sb.append(" ");
      this.printList(this.variables, sb);
      if (this.isStatement())
        sb.append(";");
      if (this.getInlineComment() != null)
        sb.append(this.getInlineComment().toSource(depth)).append("\n");
      else if (this.isStatement())
        sb.append("\n");
      return sb.toString();
    }

    [HideFromJava]
    static VariableDeclaration() => AstNode.__\u003Cclinit\u003E();
  }
}
