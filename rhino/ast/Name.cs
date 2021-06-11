// Decompiled with JetBrains decompiler
// Type: rhino.ast.Name
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class Name : AstNode
  {
    private string identifier;
    private Scope scope;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getIdentifier() => this.identifier;

    [LineNumberTable(129)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int length() => this.identifier == null ? 0 : String.instancehelper_length(this.identifier);

    [LineNumberTable(new byte[] {159, 188, 233, 38, 232, 91, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Name(int pos, string name)
      : base(pos)
    {
      Name name1 = this;
      this.type = 39;
      this.setIdentifier(name);
      this.setLength(String.instancehelper_length(name));
    }

    [LineNumberTable(new byte[] {159, 165, 232, 61, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Name()
    {
      Name name = this;
      this.type = 39;
    }

    [LineNumberTable(new byte[] {13, 103, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIdentifier(string identifier)
    {
      this.assertNotNull((object) identifier);
      this.identifier = identifier;
      this.setLength(String.instancehelper_length(identifier));
    }

    [LineNumberTable(134)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth) => new StringBuilder().append(this.makeIndent(depth)).append(this.identifier != null ? this.identifier : "<null>").toString();

    [LineNumberTable(new byte[] {92, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v) => v.visit((AstNode) this);

    [LineNumberTable(new byte[] {50, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scope getDefiningScope() => this.getEnclosingScope()?.getDefiningScope(this.getIdentifier());

    [LineNumberTable(new byte[] {159, 169, 233, 57, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Name(int pos)
      : base(pos)
    {
      Name name = this;
      this.type = 39;
    }

    [LineNumberTable(new byte[] {159, 173, 234, 53, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Name(int pos, int len)
      : base(pos, len)
    {
      Name name = this;
      this.type = 39;
    }

    [LineNumberTable(new byte[] {159, 183, 234, 43, 232, 86, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Name(int pos, int len, string name)
      : base(pos, len)
    {
      Name name1 = this;
      this.type = 39;
      this.setIdentifier(name);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setScope(Scope s) => this.scope = s;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Scope getScope() => this.scope;

    [LineNumberTable(new byte[] {68, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLocalName()
    {
      Scope definingScope = this.getDefiningScope();
      return definingScope != null && definingScope.getParentScope() != null;
    }

    [HideFromJava]
    static Name() => AstNode.__\u003Cclinit\u003E();
  }
}
