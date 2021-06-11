// Decompiled with JetBrains decompiler
// Type: rhino.ast.ObjectLiteral
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
  public class ObjectLiteral : AstNode, DestructuringForm
  {
    [Modifiers]
    [Signature("Ljava/util/List<Lrhino/ast/ObjectProperty;>;")]
    private static List NO_ELEMS;
    [Signature("Ljava/util/List<Lrhino/ast/ObjectProperty;>;")]
    private List elements;
    internal bool isDestructuring;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 187, 234, 53, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectLiteral(int pos, int len)
      : base(pos, len)
    {
      ObjectLiteral objectLiteral = this;
      this.type = 67;
    }

    [Signature("(Ljava/util/List<Lrhino/ast/ObjectProperty;>;)V")]
    [LineNumberTable(new byte[] {12, 99, 137, 104, 107, 123, 137})]
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
          this.addElement((ObjectProperty) iterator.next());
      }
    }

    [Signature("()Ljava/util/List<Lrhino/ast/ObjectProperty;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getElements() => this.elements != null ? this.elements : ObjectLiteral.NO_ELEMS;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDestructuring() => this.isDestructuring;

    [LineNumberTable(new byte[] {58, 102, 110, 108, 104, 141, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder sb = new StringBuilder();
      sb.append(this.makeIndent(depth));
      sb.append("{");
      if (this.elements != null)
        this.printList(this.elements, sb);
      sb.append("}");
      return sb.toString();
    }

    [LineNumberTable(new byte[] {74, 105, 127, 1, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      Iterator iterator = this.getElements().iterator();
      while (iterator.hasNext())
        ((InfixExpression) iterator.next()).visit(v);
    }

    [LineNumberTable(new byte[] {28, 103, 104, 139, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addElement(ObjectProperty element)
    {
      this.assertNotNull((object) element);
      if (this.elements == null)
        this.elements = (List) new ArrayList();
      this.elements.add((object) element);
      element.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {159, 179, 232, 61, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectLiteral()
    {
      ObjectLiteral objectLiteral = this;
      this.type = 67;
    }

    [LineNumberTable(new byte[] {159, 183, 233, 57, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectLiteral(int pos)
      : base(pos)
    {
      ObjectLiteral objectLiteral = this;
      this.type = 67;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIsDestructuring(bool destructuring) => this.isDestructuring = destructuring;

    [LineNumberTable(new byte[] {159, 136, 178, 101, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ObjectLiteral()
    {
      AstNode.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.ast.ObjectLiteral"))
        return;
      ObjectLiteral.NO_ELEMS = Collections.unmodifiableList((List) new ArrayList());
    }
  }
}
