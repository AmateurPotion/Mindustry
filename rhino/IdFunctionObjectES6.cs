// Decompiled with JetBrains decompiler
// Type: rhino.IdFunctionObjectES6
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino
{
  public class IdFunctionObjectES6 : IdFunctionObject
  {
    private const int Id_length = 1;
    private const int Id_name = 3;
    private bool myLength;
    private bool myName;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 148, 209, 103, 231, 60})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IdFunctionObjectES6(
      IdFunctionCall idcall,
      object tag,
      int id,
      string name,
      int arity,
      Scriptable scope)
      : base(idcall, tag, id, name, arity, scope)
    {
      IdFunctionObjectES6 functionObjectEs6 = this;
      this.myLength = true;
      this.myName = true;
    }

    [LineNumberTable(new byte[] {159, 157, 117, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findInstanceIdInfo(string s)
    {
      if (String.instancehelper_equals(s, (object) "length"))
        return IdScriptableObject.instanceIdInfo(3, 1);
      return String.instancehelper_equals(s, (object) "name") ? IdScriptableObject.instanceIdInfo(3, 3) : base.findInstanceIdInfo(s);
    }

    [LineNumberTable(new byte[] {159, 164, 108, 102, 108, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object getInstanceIdValue(int id) => id == 1 && !this.myLength || id == 3 && !this.myName ? Scriptable.NOT_FOUND : base.getInstanceIdValue(id);

    [LineNumberTable(new byte[] {159, 174, 113, 103, 97, 113, 103, 129, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setInstanceIdValue(int id, object value)
    {
      if (id == 1 && object.ReferenceEquals(value, Scriptable.NOT_FOUND))
        this.myLength = false;
      else if (id == 3 && object.ReferenceEquals(value, Scriptable.NOT_FOUND))
        this.myName = false;
      else
        base.setInstanceIdValue(id, value);
    }

    [HideFromJava]
    static IdFunctionObjectES6() => IdFunctionObject.__\u003Cclinit\u003E();
  }
}
