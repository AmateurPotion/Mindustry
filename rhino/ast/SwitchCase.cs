// Decompiled with JetBrains decompiler
// Type: rhino.ast.SwitchCase
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class SwitchCase : AstNode
  {
    private AstNode expression;
    [Signature("Ljava/util/List<Lrhino/ast/AstNode;>;")]
    private List statements;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 178, 233, 57, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SwitchCase(int pos)
      : base(pos)
    {
      SwitchCase switchCase = this;
      this.type = 116;
    }

    [LineNumberTable(new byte[] {8, 103, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setExpression(AstNode expression)
    {
      this.expression = expression;
      expression?.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {50, 103, 104, 139, 110, 110, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addStatement(AstNode statement)
    {
      this.assertNotNull((object) statement);
      if (this.statements == null)
        this.statements = (List) new ArrayList();
      this.setLength(statement.getPosition() + statement.getLength() - this.getPosition());
      this.statements.add((object) statement);
      statement.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getExpression() => this.expression;

    [Signature("()Ljava/util/List<Lrhino/ast/AstNode;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getStatements() => this.statements;

    [LineNumberTable(new byte[] {159, 174, 232, 61, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SwitchCase()
    {
      SwitchCase switchCase = this;
      this.type = 116;
    }

    [LineNumberTable(new byte[] {159, 182, 234, 53, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SwitchCase(int pos, int len)
      : base(pos, len)
    {
      SwitchCase switchCase = this;
      this.type = 116;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDefault() => this.expression == null;

    [Signature("(Ljava/util/List<Lrhino/ast/AstNode;>;)V")]
    [LineNumberTable(new byte[] {33, 104, 139, 123, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStatements(List statements)
    {
      if (this.statements != null)
        this.statements.clear();
      Iterator iterator = statements.iterator();
      while (iterator.hasNext())
        this.addStatement((AstNode) iterator.next());
    }

    [LineNumberTable(new byte[] {62, 102, 110, 104, 142, 108, 115, 108, 104, 149, 140, 107, 127, 1, 112, 127, 5, 140, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(this.makeIndent(depth));
      if (this.expression == null)
      {
        stringBuilder.append("default:\n");
      }
      else
      {
        stringBuilder.append("case ");
        stringBuilder.append(this.expression.toSource(0));
        stringBuilder.append(":");
        if (this.getInlineComment() != null)
          stringBuilder.append(this.getInlineComment().toSource(depth + 1));
        stringBuilder.append("\n");
      }
      if (this.statements != null)
      {
        Iterator iterator = this.statements.iterator();
        while (iterator.hasNext())
        {
          AstNode astNode = (AstNode) iterator.next();
          stringBuilder.append(astNode.toSource(depth + 1));
          if (astNode.getType() == 162 && object.ReferenceEquals((object) ((Comment) astNode).getCommentType(), (object) Token.CommentType.__\u003C\u003ELINE))
            stringBuilder.append("\n");
        }
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {92, 105, 104, 140, 104, 127, 1, 103, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      if (this.expression != null)
        this.expression.visit(v);
      if (this.statements == null)
        return;
      Iterator iterator = this.statements.iterator();
      while (iterator.hasNext())
        ((AstNode) iterator.next()).visit(v);
    }

    [HideFromJava]
    static SwitchCase() => AstNode.__\u003Cclinit\u003E();
  }
}
