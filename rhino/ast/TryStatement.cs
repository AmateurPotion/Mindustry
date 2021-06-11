// Decompiled with JetBrains decompiler
// Type: rhino.ast.TryStatement
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
  public class TryStatement : AstNode
  {
    [Modifiers]
    [Signature("Ljava/util/List<Lrhino/ast/CatchClause;>;")]
    private static List NO_CATCHES;
    private AstNode tryBlock;
    [Signature("Ljava/util/List<Lrhino/ast/CatchClause;>;")]
    private List catchClauses;
    private AstNode finallyBlock;
    private int finallyPosition;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 179, 233, 54, 167, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TryStatement(int pos)
      : base(pos)
    {
      TryStatement tryStatement = this;
      this.finallyPosition = -1;
      this.type = 82;
    }

    [LineNumberTable(new byte[] {3, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTryBlock(AstNode tryBlock)
    {
      this.assertNotNull((object) tryBlock);
      this.tryBlock = tryBlock;
      tryBlock.setParent((AstNode) this);
    }

    [Signature("(Ljava/util/List<Lrhino/ast/CatchClause;>;)V")]
    [LineNumberTable(new byte[] {22, 99, 137, 104, 107, 123, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCatchClauses(List catchClauses)
    {
      if (catchClauses == null)
      {
        this.catchClauses = (List) null;
      }
      else
      {
        if (this.catchClauses != null)
          this.catchClauses.clear();
        Iterator iterator = catchClauses.iterator();
        while (iterator.hasNext())
          this.addCatchClause((CatchClause) iterator.next());
      }
    }

    [LineNumberTable(new byte[] {59, 103, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFinallyBlock(AstNode finallyBlock)
    {
      this.finallyBlock = finallyBlock;
      finallyBlock?.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFinallyPosition(int finallyPosition) => this.finallyPosition = finallyPosition;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getTryBlock() => this.tryBlock;

    [Signature("()Ljava/util/List<Lrhino/ast/CatchClause;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getCatchClauses() => this.catchClauses != null ? this.catchClauses : TryStatement.NO_CATCHES;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getFinallyBlock() => this.finallyBlock;

    [LineNumberTable(new byte[] {39, 103, 104, 139, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addCatchClause(CatchClause clause)
    {
      this.assertNotNull((object) clause);
      if (this.catchClauses == null)
        this.catchClauses = (List) new ArrayList();
      this.catchClauses.add((object) clause);
      clause.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {159, 175, 232, 58, 167, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TryStatement()
    {
      TryStatement tryStatement = this;
      this.finallyPosition = -1;
      this.type = 82;
    }

    [LineNumberTable(new byte[] {159, 183, 234, 50, 167, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TryStatement(int pos, int len)
      : base(pos, len)
    {
      TryStatement tryStatement = this;
      this.finallyPosition = -1;
      this.type = 82;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFinallyPosition() => this.finallyPosition;

    [LineNumberTable(new byte[] {80, 107, 110, 108, 104, 159, 0, 120, 127, 1, 110, 98, 104, 108, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder(250);
      stringBuilder.append(this.makeIndent(depth));
      stringBuilder.append("try ");
      if (this.getInlineComment() != null)
        stringBuilder.append(this.getInlineComment().toSource(depth + 1)).append("\n");
      stringBuilder.append(String.instancehelper_trim(this.tryBlock.toSource(depth)));
      Iterator iterator = this.getCatchClauses().iterator();
      while (iterator.hasNext())
      {
        CatchClause catchClause = (CatchClause) iterator.next();
        stringBuilder.append(catchClause.toSource(depth));
      }
      if (this.finallyBlock != null)
      {
        stringBuilder.append(" finally ");
        stringBuilder.append(this.finallyBlock.toSource(depth));
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {103, 105, 108, 127, 1, 103, 98, 104, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      this.tryBlock.visit(v);
      Iterator iterator = this.getCatchClauses().iterator();
      while (iterator.hasNext())
        ((CatchClause) iterator.next()).visit(v);
      if (this.finallyBlock == null)
        return;
      this.finallyBlock.visit(v);
    }

    [LineNumberTable(new byte[] {159, 137, 114, 101, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static TryStatement()
    {
      AstNode.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.ast.TryStatement"))
        return;
      TryStatement.NO_CATCHES = Collections.unmodifiableList((List) new ArrayList());
    }
  }
}
