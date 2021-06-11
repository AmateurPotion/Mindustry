// Decompiled with JetBrains decompiler
// Type: rhino.ast.ObjectProperty
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class ObjectProperty : InfixExpression
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 190, 232, 46, 232, 83})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectProperty()
    {
      ObjectProperty objectProperty = this;
      this.type = 104;
    }

    [LineNumberTable(new byte[] {2, 233, 42, 232, 87})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectProperty(int pos)
      : base(pos)
    {
      ObjectProperty objectProperty = this;
      this.type = 104;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIsGetterMethod() => this.type = 152;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIsSetterMethod() => this.type = 153;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIsNormalMethod() => this.type = 164;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isGetterMethod() => this.type == 152;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isSetterMethod() => this.type == 153;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNormalMethod() => this.type == 164;

    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isMethod() => this.isGetterMethod() || this.isSetterMethod() || this.isNormalMethod();

    [LineNumberTable(new byte[] {159, 181, 221, 159, 6, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setNodeType(int nodeType)
    {
      if (nodeType != 104 && nodeType != 152 && (nodeType != 153 && nodeType != 164))
      {
        string str = new StringBuilder().append("invalid node type: ").append(nodeType).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.setType(nodeType);
    }

    [LineNumberTable(new byte[] {6, 234, 38, 232, 91})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectProperty(int pos, int len)
      : base(pos, len)
    {
      ObjectProperty objectProperty = this;
      this.type = 104;
    }

    [LineNumberTable(new byte[] {51, 102, 108, 112, 104, 110, 104, 140, 127, 1, 106, 140, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append("\n");
      stringBuilder.append(this.makeIndent(depth + 1));
      if (this.isGetterMethod())
        stringBuilder.append("get ");
      else if (this.isSetterMethod())
        stringBuilder.append("set ");
      stringBuilder.append(this.left.toSource(this.getType() != 104 ? depth : 0));
      if (this.type == 104)
        stringBuilder.append(": ");
      stringBuilder.append(this.right.toSource(this.getType() != 104 ? depth + 1 : 0));
      return stringBuilder.toString();
    }

    [HideFromJava]
    static ObjectProperty() => InfixExpression.__\u003Cclinit\u003E();
  }
}
