// Decompiled with JetBrains decompiler
// Type: rhino.ast.KeywordLiteral
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class KeywordLiteral : AstNode
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 175, 106, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public KeywordLiteral(int pos, int len, int nodeType)
      : base(pos, len)
    {
      KeywordLiteral keywordLiteral = this;
      this.setType(nodeType);
    }

    [LineNumberTable(new byte[] {159, 185, 252, 69, 159, 6, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual KeywordLiteral setType(int nodeType)
    {
      if (nodeType != 43 && nodeType != 42 && (nodeType != 45 && nodeType != 44) && nodeType != 161)
      {
        string str = new StringBuilder().append("Invalid node type: ").append(nodeType).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.type = nodeType;
      return this;
    }

    [LineNumberTable(new byte[] {159, 159, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public KeywordLiteral()
    {
    }

    [LineNumberTable(new byte[] {159, 163, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public KeywordLiteral(int pos)
      : base(pos)
    {
    }

    [LineNumberTable(new byte[] {159, 167, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public KeywordLiteral(int pos, int len)
      : base(pos, len)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isBooleanLiteral() => this.type == 45 || this.type == 44;

    [LineNumberTable(new byte[] {14, 102, 110, 159, 21, 108, 130, 108, 130, 108, 130, 108, 130, 108, 130, 112, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(this.makeIndent(depth));
      switch (this.getType())
      {
        case 42:
          stringBuilder.append("null");
          break;
        case 43:
          stringBuilder.append("this");
          break;
        case 44:
          stringBuilder.append("false");
          break;
        case 45:
          stringBuilder.append("true");
          break;
        case 161:
          stringBuilder.append("debugger;\n");
          break;
        default:
          string str = new StringBuilder().append("Invalid keyword literal type: ").append(this.getType()).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException(str);
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {44, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v) => v.visit((AstNode) this);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Node \u003Cbridge\u003EsetType(int i) => (Node) this.setType(i);

    [HideFromJava]
    static KeywordLiteral() => AstNode.__\u003Cclinit\u003E();
  }
}
