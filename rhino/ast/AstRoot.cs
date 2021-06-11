// Decompiled with JetBrains decompiler
// Type: rhino.ast.AstRoot
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.ast
{
  public class AstRoot : ScriptNode
  {
    [Signature("Ljava/util/SortedSet<Lrhino/ast/Comment;>;")]
    private SortedSet comments;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 171, 233, 57, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AstRoot(int pos)
      : base(pos)
    {
      AstRoot astRoot = this;
      this.type = 137;
    }

    [LineNumberTable(new byte[] {12, 103, 104, 149, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addComment(Comment comment)
    {
      this.assertNotNull((object) comment);
      if (this.comments == null)
      {
        TreeSet.__\u003Cclinit\u003E();
        this.comments = (SortedSet) new TreeSet((Comparator) new AstNode.PositionComparator());
      }
      ((Set) this.comments).add((object) comment);
      comment.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {28, 104, 127, 1, 104, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void visitComments(NodeVisitor visitor)
    {
      if (this.comments == null)
        return;
      Iterator iterator = ((Set) this.comments).iterator();
      while (iterator.hasNext())
      {
        Comment comment = (Comment) iterator.next();
        visitor.visit((AstNode) comment);
      }
    }

    [LineNumberTable(new byte[] {43, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void visitAll(NodeVisitor visitor)
    {
      this.visit(visitor);
      this.visitComments(visitor);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {76, 103, 104, 98, 104, 159, 2, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024checkParentLinks\u00240([In] AstNode obj0)
    {
      if (obj0.getType() == 137 || obj0.getParent() != null)
        return true;
      string str = new StringBuilder().append("No parent for node: ").append((object) obj0).append("\n").append(obj0.toSource(0)).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalStateException(str);
    }

    [LineNumberTable(new byte[] {159, 167, 232, 61, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AstRoot()
    {
      AstRoot astRoot = this;
      this.type = 137;
    }

    [Signature("()Ljava/util/SortedSet<Lrhino/ast/Comment;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SortedSet getComments() => this.comments;

    [Signature("(Ljava/util/SortedSet<Lrhino/ast/Comment;>;)V")]
    [LineNumberTable(new byte[] {159, 188, 99, 137, 104, 107, 123, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setComments(SortedSet comments)
    {
      if (comments == null)
      {
        this.comments = (SortedSet) null;
      }
      else
      {
        if (this.comments != null)
          ((Set) this.comments).clear();
        Iterator iterator = ((Set) comments).iterator();
        while (iterator.hasNext())
          this.addComment((Comment) iterator.next());
      }
    }

    [LineNumberTable(new byte[] {49, 102, 123, 115, 109, 140, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Iterator iterator = this.iterator();
      while (iterator.hasNext())
      {
        Node node = (Node) iterator.next();
        stringBuilder.append(((AstNode) node).toSource(depth));
        if (node.getType() == 162)
          stringBuilder.append("\n");
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {64, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string debugPrint()
    {
      AstNode.DebugPrintVisitor debugPrintVisitor = new AstNode.DebugPrintVisitor(new StringBuilder(1000));
      this.visitAll((NodeVisitor) debugPrintVisitor);
      return debugPrintVisitor.toString();
    }

    [LineNumberTable(new byte[] {75, 240, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void checkParentLinks() => this.visit((NodeVisitor) new AstRoot.__\u003C\u003EAnon0());

    [HideFromJava]
    static AstRoot() => ScriptNode.__\u003Cclinit\u003E();

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : NodeVisitor
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool visit([In] AstNode obj0) => (AstRoot.lambda\u0024checkParentLinks\u00240(obj0) ? 1 : 0) != 0;
    }
  }
}
