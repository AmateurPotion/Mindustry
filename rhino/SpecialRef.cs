// Decompiled with JetBrains decompiler
// Type: rhino.SpecialRef
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  internal class SpecialRef : Ref
  {
    private const int SPECIAL_NONE = 0;
    private const int SPECIAL_PROTO = 1;
    private const int SPECIAL_PARENT = 2;
    [Modifiers]
    private Scriptable target;
    [Modifiers]
    private int type;
    [Modifiers]
    private string name;

    [LineNumberTable(new byte[] {159, 162, 105, 99, 205, 109, 100, 109, 132, 172, 137, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Ref createSpecial([In] Context obj0, [In] Scriptable obj1, [In] object obj2, [In] string obj3)
    {
      Scriptable objectOrNull = ScriptRuntime.toObjectOrNull(obj0, obj2, obj1);
      if (objectOrNull == null)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.undefReadError(obj2, (object) obj3));
      int num;
      if (String.instancehelper_equals(obj3, (object) "__proto__"))
        num = 1;
      else if (String.instancehelper_equals(obj3, (object) "__parent__"))
      {
        num = 2;
      }
      else
      {
        string str = obj3;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (!obj0.hasFeature(5))
        num = 0;
      return (Ref) new SpecialRef(objectOrNull, num, obj3);
    }

    [LineNumberTable(new byte[] {159, 154, 104, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private SpecialRef([In] Scriptable obj0, [In] int obj1, [In] string obj2)
    {
      SpecialRef specialRef = this;
      this.target = obj0;
      this.type = obj1;
      this.name = obj2;
    }

    [LineNumberTable(new byte[] {159, 186, 153, 147, 140, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object get([In] Context obj0)
    {
      switch (this.type)
      {
        case 0:
          return ScriptRuntime.getObjectProp(this.target, this.name, obj0);
        case 1:
          return (object) this.target.getPrototype();
        case 2:
          return (object) this.target.getParentScope();
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
    }

    [LineNumberTable(new byte[] {8, 156, 180, 105, 163, 130, 110, 182, 105, 137, 135, 131, 105, 109, 174, 140, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object set([In] Context obj0, [In] Scriptable obj1, [In] object obj2)
    {
      switch (this.type)
      {
        case 0:
          return ScriptRuntime.setObjectProp(this.target, this.name, obj2, obj0);
        case 1:
        case 2:
          Scriptable objectOrNull = ScriptRuntime.toObjectOrNull(obj0, obj2, obj1);
          if (objectOrNull != null)
          {
            Scriptable scriptable = objectOrNull;
            while (!object.ReferenceEquals((object) scriptable, (object) this.target))
            {
              scriptable = this.type != 1 ? scriptable.getParentScope() : scriptable.getPrototype();
              if (scriptable == null)
                goto label_7;
            }
            throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.cyclic.value", (object) this.name));
          }
label_7:
          if (this.type == 1)
          {
            if (!(this.target is BaseFunction))
              this.target.setPrototype(objectOrNull);
          }
          else
            this.target.setParentScope(objectOrNull);
          return (object) objectOrNull;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
    }

    [LineNumberTable(new byte[] {46, 104, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool has([In] Context obj0) => this.type != 0 || ScriptRuntime.hasObjectElem(this.target, (object) this.name, obj0);

    [LineNumberTable(new byte[] {54, 104, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool delete([In] Context obj0) => this.type == 0 && ScriptRuntime.deleteObjectElem(this.target, (object) this.name, obj0);
  }
}
