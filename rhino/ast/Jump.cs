// Decompiled with JetBrains decompiler
// Type: rhino.ast.Jump
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class Jump : AstNode
  {
    public Node target;
    private Node target2;
    private Jump jumpNode;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {16, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Node getFinally()
    {
      if (this.type != 82)
        AstNode.codeBug();
      return this.target2;
    }

    [LineNumberTable(new byte[] {33, 115, 105, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLoop(Jump loop)
    {
      if (this.type != 131)
        AstNode.codeBug();
      if (loop == null)
        AstNode.codeBug();
      if (this.jumpNode != null)
        AstNode.codeBug();
      this.jumpNode = loop;
    }

    [LineNumberTable(new byte[] {159, 174, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Jump(int type, Node child)
      : this(type)
    {
      Jump jump = this;
      this.addChildToBack(child);
    }

    [LineNumberTable(new byte[] {9, 112, 115, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDefault(Node defaultTarget)
    {
      if (this.type != 115)
        AstNode.codeBug();
      if (defaultTarget.getType() != 132)
        AstNode.codeBug();
      if (this.target2 != null)
        AstNode.codeBug();
      this.target2 = defaultTarget;
    }

    [LineNumberTable(new byte[] {4, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Node getDefault()
    {
      if (this.type != 115)
        AstNode.codeBug();
      return this.target2;
    }

    [LineNumberTable(new byte[] {45, 115, 115, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setContinue(Node continueTarget)
    {
      if (this.type != 133)
        AstNode.codeBug();
      if (continueTarget.getType() != 132)
        AstNode.codeBug();
      if (this.target2 != null)
        AstNode.codeBug();
      this.target2 = continueTarget;
    }

    [LineNumberTable(new byte[] {159, 179, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Jump(int type, Node child, int lineno)
      : this(type, child)
    {
      Jump jump = this;
      this.setLineno(lineno);
    }

    [LineNumberTable(new byte[] {21, 112, 115, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFinally(Node finallyTarget)
    {
      if (this.type != 82)
        AstNode.codeBug();
      if (finallyTarget.getType() != 132)
        AstNode.codeBug();
      if (this.target2 != null)
        AstNode.codeBug();
      this.target2 = finallyTarget;
    }

    [LineNumberTable(new byte[] {159, 164, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Jump(int nodeType)
    {
      Jump jump = this;
      this.type = nodeType;
    }

    [LineNumberTable(new byte[] {159, 184, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Jump getJumpStatement()
    {
      if (this.type != 121 && this.type != 122)
        AstNode.codeBug();
      return this.jumpNode;
    }

    [LineNumberTable(new byte[] {40, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Node getContinue()
    {
      if (this.type != 133)
        AstNode.codeBug();
      return this.target2;
    }

    [LineNumberTable(new byte[] {159, 160, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Jump()
    {
      Jump jump = this;
      this.type = -1;
    }

    [LineNumberTable(new byte[] {159, 169, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Jump(int type, int lineno)
      : this(type)
    {
      Jump jump = this;
      this.setLineno(lineno);
    }

    [LineNumberTable(new byte[] {159, 189, 122, 105, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setJumpStatement(Jump jumpStatement)
    {
      if (this.type != 121 && this.type != 122)
        AstNode.codeBug();
      if (jumpStatement == null)
        AstNode.codeBug();
      if (this.jumpNode != null)
        AstNode.codeBug();
      this.jumpNode = jumpStatement;
    }

    [LineNumberTable(new byte[] {28, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Jump getLoop()
    {
      if (this.type != 131)
        AstNode.codeBug();
      return this.jumpNode;
    }

    [LineNumberTable(107)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor visitor)
    {
      string str = this.toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException(str);
    }

    [LineNumberTable(112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      string str = this.toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException(str);
    }

    [HideFromJava]
    static Jump() => AstNode.__\u003Cclinit\u003E();
  }
}
