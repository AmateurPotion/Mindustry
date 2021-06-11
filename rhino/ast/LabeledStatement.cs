// Decompiled with JetBrains decompiler
// Type: rhino.ast.LabeledStatement
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class LabeledStatement : AstNode
  {
    [Modifiers]
    [Signature("Ljava/util/List<Lrhino/ast/Label;>;")]
    private List labels;
    private AstNode statement;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {41, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStatement(AstNode statement)
    {
      this.assertNotNull((object) statement);
      this.statement = statement;
      statement.setParent((AstNode) this);
    }

    [LineNumberTable(97)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Label getFirstLabel() => (Label) this.labels.get(0);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getStatement() => this.statement;

    [LineNumberTable(new byte[] {28, 127, 1, 110, 130, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Label getLabelByName(string name)
    {
      Iterator iterator = this.labels.iterator();
      while (iterator.hasNext())
      {
        Label label = (Label) iterator.next();
        if (String.instancehelper_equals(name, (object) label.getName()))
          return label;
      }
      return (Label) null;
    }

    [LineNumberTable(new byte[] {10, 103, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addLabel(Label label)
    {
      this.assertNotNull((object) label);
      this.labels.add((object) label);
      label.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {159, 169, 233, 53, 203, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LabeledStatement(int pos)
      : base(pos)
    {
      LabeledStatement labeledStatement = this;
      this.labels = (List) new ArrayList();
      this.type = 134;
    }

    [Signature("()Ljava/util/List<Lrhino/ast/Label;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getLabels() => this.labels;

    [LineNumberTable(new byte[] {159, 165, 232, 57, 203, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LabeledStatement()
    {
      LabeledStatement labeledStatement = this;
      this.labels = (List) new ArrayList();
      this.type = 134;
    }

    [LineNumberTable(new byte[] {159, 173, 234, 49, 203, 235, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LabeledStatement(int pos, int len)
      : base(pos, len)
    {
      LabeledStatement labeledStatement = this;
      this.labels = (List) new ArrayList();
      this.type = 134;
    }

    [Signature("(Ljava/util/List<Lrhino/ast/Label;>;)V")]
    [LineNumberTable(new byte[] {159, 189, 103, 104, 107, 123, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLabels(List labels)
    {
      this.assertNotNull((object) labels);
      if (this.labels != null)
        this.labels.clear();
      Iterator iterator = labels.iterator();
      while (iterator.hasNext())
        this.addLabel((Label) iterator.next());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool hasSideEffects() => true;

    [LineNumberTable(new byte[] {58, 102, 127, 1, 110, 98, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Iterator iterator = this.labels.iterator();
      while (iterator.hasNext())
      {
        Label label = (Label) iterator.next();
        stringBuilder.append(label.toSource(depth));
      }
      stringBuilder.append(this.statement.toSource(depth + 1));
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {72, 105, 127, 1, 103, 98, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      Iterator iterator = this.labels.iterator();
      while (iterator.hasNext())
        ((AstNode) iterator.next()).visit(v);
      this.statement.visit(v);
    }

    [HideFromJava]
    static LabeledStatement() => AstNode.__\u003Cclinit\u003E();
  }
}
