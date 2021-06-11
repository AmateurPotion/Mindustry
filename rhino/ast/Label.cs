// Decompiled with JetBrains decompiler
// Type: rhino.ast.Label
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class Label : Jump
  {
    private string name;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getName() => this.name;

    [LineNumberTable(new byte[] {159, 167, 232, 54, 235, 76, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Label(int pos, int len)
    {
      Label label = this;
      this.type = 131;
      this.position = pos;
      this.length = len;
    }

    [LineNumberTable(new byte[] {159, 191, 110, 112, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setName(string name)
    {
      name = name != null ? String.instancehelper_trim(name) : (string) null;
      if (name == null || String.instancehelper_equals("", (object) name))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("invalid label name");
      }
      this.name = name;
    }

    [LineNumberTable(new byte[] {159, 160, 232, 61, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Label()
    {
      Label label = this;
      this.type = 131;
    }

    [LineNumberTable(new byte[] {159, 164, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Label(int pos)
      : this(pos, -1)
    {
    }

    [LineNumberTable(new byte[] {159, 174, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Label(int pos, int len, string name)
      : this(pos, len)
    {
      Label label = this;
      this.setName(name);
    }

    [LineNumberTable(new byte[] {7, 191, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth) => new StringBuilder().append(this.makeIndent(depth)).append(this.name).append(":\n").toString();

    [LineNumberTable(new byte[] {18, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v) => v.visit((AstNode) this);

    [HideFromJava]
    static Label() => Jump.__\u003Cclinit\u003E();
  }
}
