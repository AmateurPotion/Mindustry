// Decompiled with JetBrains decompiler
// Type: rhino.ast.Symbol
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class Symbol : Object
  {
    private int declType;
    private int index;
    private string name;
    private Node node;
    private Scope containingTable;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getDeclType() => this.declType;

    [LineNumberTable(new byte[] {159, 168, 232, 51, 231, 78, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Symbol(int declType, string name)
    {
      Symbol symbol = this;
      this.index = -1;
      this.setName(name);
      this.setDeclType(declType);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setContainingTable(Scope containingTable) => this.containingTable = containingTable;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getName() => this.name;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getIndex() => this.index;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scope getContainingTable() => this.containingTable;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIndex(int index) => this.index = index;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setName(string name) => this.name = name;

    [LineNumberTable(new byte[] {159, 184, 255, 0, 69, 127, 6, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDeclType(int declType)
    {
      if (declType != 110 && declType != 88 && (declType != 123 && declType != 154) && declType != 155)
      {
        string str = new StringBuilder().append("Invalid declType: ").append(declType).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.declType = declType;
    }

    [LineNumberTable(108)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getDeclTypeName() => Token.typeToName(this.declType);

    [LineNumberTable(new byte[] {159, 160, 232, 59, 231, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Symbol()
    {
      Symbol symbol = this;
      this.index = -1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Node getNode() => this.node;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setNode(Node node) => this.node = node;

    [LineNumberTable(new byte[] {63, 102, 108, 109, 108, 109, 104, 108, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append("Symbol (");
      stringBuilder.append(this.getDeclTypeName());
      stringBuilder.append(") name=");
      stringBuilder.append(this.name);
      if (this.node != null)
      {
        stringBuilder.append(" line=");
        stringBuilder.append(this.node.getLineno());
      }
      return stringBuilder.toString();
    }
  }
}
