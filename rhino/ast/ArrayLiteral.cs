// Decompiled with JetBrains decompiler
// Type: rhino.ast.ArrayLiteral
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
  [Implements(new string[] {"rhino.ast.DestructuringForm"})]
  public class ArrayLiteral : AstNode, DestructuringForm
  {
    [Modifiers]
    [Signature("Ljava/util/List<Lrhino/ast/AstNode;>;")]
    private static List NO_ELEMS;
    [Signature("Ljava/util/List<Lrhino/ast/AstNode;>;")]
    private List elements;
    private int destructuringLength;
    private int skipCount;
    private bool isDestructuring;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 185, 233, 57, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArrayLiteral(int pos)
      : base(pos)
    {
      ArrayLiteral arrayLiteral = this;
      this.type = 66;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDestructuringLength(int destructuringLength) => this.destructuringLength = destructuringLength;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSkipCount(int count) => this.skipCount = count;

    [LineNumberTable(new byte[] {32, 103, 104, 107, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addElement(AstNode element)
    {
      this.assertNotNull((object) element);
      if (this.elements == null)
        this.elements = (List) new ArrayList();
      this.elements.add((object) element);
      element.setParent((AstNode) this);
    }

    [Signature("()Ljava/util/List<Lrhino/ast/AstNode;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getElements() => this.elements != null ? this.elements : ArrayLiteral.NO_ELEMS;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDestructuring() => this.isDestructuring;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getDestructuringLength() => this.destructuringLength;

    [LineNumberTable(new byte[] {159, 181, 232, 61, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArrayLiteral()
    {
      ArrayLiteral arrayLiteral = this;
      this.type = 66;
    }

    [LineNumberTable(new byte[] {159, 189, 234, 53, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArrayLiteral(int pos, int len)
      : base(pos, len)
    {
      ArrayLiteral arrayLiteral = this;
      this.type = 66;
    }

    [Signature("(Ljava/util/List<Lrhino/ast/AstNode;>;)V")]
    [LineNumberTable(new byte[] {15, 99, 137, 104, 107, 123, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setElements(List elements)
    {
      if (elements == null)
      {
        this.elements = (List) null;
      }
      else
      {
        if (this.elements != null)
          this.elements.clear();
        Iterator iterator = elements.iterator();
        while (iterator.hasNext())
          this.addElement((AstNode) iterator.next());
      }
    }

    [LineNumberTable(94)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getSize() => this.elements == null ? 0 : this.elements.size();

    [LineNumberTable(new byte[] {54, 104, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getElement(int index)
    {
      if (this.elements == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException("no elements");
      }
      return (AstNode) this.elements.get(index);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getSkipCount() => this.skipCount;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIsDestructuring(bool destructuring) => this.isDestructuring = destructuring;

    [LineNumberTable(new byte[] {115, 102, 110, 108, 104, 141, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder sb = new StringBuilder();
      sb.append(this.makeIndent(depth));
      sb.append("[");
      if (this.elements != null)
        this.printList(this.elements, sb);
      sb.append("]");
      return sb.toString();
    }

    [LineNumberTable(new byte[] {160, 68, 105, 127, 1, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      Iterator iterator = this.getElements().iterator();
      while (iterator.hasNext())
        ((AstNode) iterator.next()).visit(v);
    }

    [LineNumberTable(new byte[] {159, 136, 178, 101, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ArrayLiteral()
    {
      AstNode.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.ast.ArrayLiteral"))
        return;
      ArrayLiteral.NO_ELEMS = Collections.unmodifiableList((List) new ArrayList());
    }
  }
}
