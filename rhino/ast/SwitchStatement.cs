// Decompiled with JetBrains decompiler
// Type: rhino.ast.SwitchStatement
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
  public class SwitchStatement : Jump
  {
    [Modifiers]
    [Signature("Ljava/util/List<Lrhino/ast/SwitchCase;>;")]
    private static List NO_CASES;
    private AstNode expression;
    [Signature("Ljava/util/List<Lrhino/ast/SwitchCase;>;")]
    private List cases;
    private int lp;
    private int rp;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 183, 232, 54, 103, 167, 232, 72, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SwitchStatement(int pos)
    {
      SwitchStatement switchStatement = this;
      this.lp = -1;
      this.rp = -1;
      this.type = 115;
      this.position = pos;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLp(int lp) => this.lp = lp;

    [LineNumberTable(new byte[] {14, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setExpression(AstNode expression)
    {
      this.assertNotNull((object) expression);
      this.expression = expression;
      expression.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRp(int rp) => this.rp = rp;

    [LineNumberTable(new byte[] {48, 103, 104, 139, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addCase(SwitchCase switchCase)
    {
      this.assertNotNull((object) switchCase);
      if (this.cases == null)
        this.cases = (List) new ArrayList();
      this.cases.add((object) switchCase);
      switchCase.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getExpression() => this.expression;

    [Signature("()Ljava/util/List<Lrhino/ast/SwitchCase;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getCases() => this.cases != null ? this.cases : SwitchStatement.NO_CASES;

    [LineNumberTable(new byte[] {159, 180, 232, 57, 103, 167, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SwitchStatement()
    {
      SwitchStatement switchStatement = this;
      this.lp = -1;
      this.rp = -1;
      this.type = 115;
    }

    [LineNumberTable(new byte[] {159, 188, 232, 49, 103, 167, 232, 76, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SwitchStatement(int pos, int len)
    {
      SwitchStatement switchStatement = this;
      this.lp = -1;
      this.rp = -1;
      this.type = 115;
      this.position = pos;
      this.length = len;
    }

    [Signature("(Ljava/util/List<Lrhino/ast/SwitchCase;>;)V")]
    [LineNumberTable(new byte[] {33, 99, 137, 104, 107, 123, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCases(List cases)
    {
      if (cases == null)
      {
        this.cases = (List) null;
      }
      else
      {
        if (this.cases != null)
          this.cases.clear();
        Iterator iterator = cases.iterator();
        while (iterator.hasNext())
          this.addCase((SwitchCase) iterator.next());
      }
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

    [LineNumberTable(new byte[] {94, 104, 102, 104, 108, 115, 108, 104, 127, 1, 112, 130, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      string str = this.makeIndent(depth);
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(str);
      stringBuilder.append("switch (");
      stringBuilder.append(this.expression.toSource(0));
      stringBuilder.append(") {\n");
      if (this.cases != null)
      {
        Iterator iterator = this.cases.iterator();
        while (iterator.hasNext())
        {
          SwitchCase switchCase = (SwitchCase) iterator.next();
          stringBuilder.append(switchCase.toSource(depth + 1));
        }
      }
      stringBuilder.append(str);
      stringBuilder.append("}\n");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {116, 105, 108, 127, 1, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.expression.visit(v);
      Iterator iterator = this.getCases().iterator();
      while (iterator.hasNext())
        ((SwitchCase) iterator.next()).visit(v);
    }

    [LineNumberTable(new byte[] {159, 136, 146, 101, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SwitchStatement()
    {
      Jump.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.ast.SwitchStatement"))
        return;
      SwitchStatement.NO_CASES = Collections.unmodifiableList((List) new ArrayList());
    }
  }
}
