// Decompiled with JetBrains decompiler
// Type: rhino.ast.Comment
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class Comment : AstNode
  {
    private string value;
    private Token.CommentType commentType;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {2, 234, 53, 235, 76, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Comment(int pos, int len, Token.CommentType type, string value)
      : base(pos, len)
    {
      Comment comment = this;
      this.type = 162;
      this.commentType = type;
      this.value = value;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getValue() => this.value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Token.CommentType getCommentType() => this.commentType;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCommentType(Token.CommentType type) => this.commentType = type;

    [LineNumberTable(new byte[] {34, 103, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(string commentString)
    {
      this.value = commentString;
      this.setLength(String.instancehelper_length(this.value));
    }

    [LineNumberTable(new byte[] {40, 111, 110, 109, 114, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder(this.getLength() + 10);
      stringBuilder.append(this.makeIndent(depth));
      stringBuilder.append(this.value);
      if (object.ReferenceEquals((object) Token.CommentType.__\u003C\u003EBLOCK_COMMENT, (object) this.getCommentType()))
        stringBuilder.append("\n");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {55, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v) => v.visit((AstNode) this);

    [HideFromJava]
    static Comment() => AstNode.__\u003Cclinit\u003E();
  }
}
