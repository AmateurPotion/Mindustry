// Decompiled with JetBrains decompiler
// Type: rhino.NativeBoolean
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  internal sealed class NativeBoolean : IdScriptableObject
  {
    [Modifiers]
    private static object BOOLEAN_TAG;
    private const int Id_constructor = 1;
    private const int Id_toString = 2;
    private const int Id_toSource = 3;
    private const int Id_valueOf = 4;
    private const int MAX_PROTOTYPE_ID = 4;
    [Modifiers]
    private bool booleanValue;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 138, 66, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NativeBoolean([In] bool obj0)
    {
      int num = obj0 ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      NativeBoolean nativeBoolean = this;
      this.booleanValue = num != 0;
    }

    [LineNumberTable(new byte[] {159, 139, 66, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      new NativeBoolean(false).exportAsJSClass(4, obj0, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Boolean";

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {159, 171, 109, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object getDefaultValue([In] Class obj0) => object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EBooleanClass) ? (object) ScriptRuntime.wrapBoolean(this.booleanValue) : base.getDefaultValue(obj0);

    [LineNumberTable(new byte[] {159, 180, 154, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId([In] int obj0)
    {
      int arity;
      string name;
      switch (obj0)
      {
        case 1:
          arity = 1;
          name = "constructor";
          break;
        case 2:
          arity = 0;
          name = "toString";
          break;
        case 3:
          arity = 0;
          name = "toSource";
          break;
        case 4:
          arity = 0;
          name = "valueOf";
          break;
        default:
          string str = String.valueOf(obj0);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.initPrototypeMethod(NativeBoolean.BOOLEAN_TAG, obj0, name, arity);
    }

    [LineNumberTable(new byte[] {14, 109, 142, 135, 132, 101, 228, 70, 116, 151, 132, 167, 231, 69, 105, 108, 141, 182, 176, 176, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      [In] IdFunctionObject obj0,
      [In] Context obj1,
      [In] Scriptable obj2,
      [In] Scriptable obj3,
      [In] object[] obj4)
    {
      if (!obj0.hasTag(NativeBoolean.BOOLEAN_TAG))
        return base.execIdCall(obj0, obj1, obj2, obj3, obj4);
      int num1 = obj0.methodId();
      if (num1 == 1)
      {
        int num2 = obj4.Length != 0 ? (obj4[0] is ScriptableObject && ((ScriptableObject) obj4[0]).avoidObjectDetection() || !ScriptRuntime.toBoolean(obj4[0]) ? 0 : 1) : 0;
        return obj3 == null ? (object) new NativeBoolean(num2 != 0) : (object) ScriptRuntime.wrapBoolean(num2 != 0);
      }
      if (!(obj3 is NativeBoolean))
        throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj0));
      int num3 = ((NativeBoolean) obj3).booleanValue ? 1 : 0;
      switch (num1)
      {
        case 2:
          return num3 != 0 ? (object) "true" : (object) "false";
        case 3:
          return num3 != 0 ? (object) "(new Boolean(true))" : (object) "(new Boolean(false))";
        case 4:
          return (object) ScriptRuntime.wrapBoolean(num3 != 0);
        default:
          string str = String.valueOf(num1);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {67, 98, 130, 103, 100, 102, 100, 100, 104, 101, 102, 100, 101, 102, 132, 101, 102, 130, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId([In] string obj0)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(obj0))
      {
        case 7:
          str = "valueOf";
          num = 4;
          break;
        case 8:
          switch (String.instancehelper_charAt(obj0, 3))
          {
            case 'o':
              str = "toSource";
              num = 3;
              break;
            case 't':
              str = "toString";
              num = 2;
              break;
          }
          break;
        case 11:
          str = "constructor";
          num = 1;
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) obj0) && !String.instancehelper_equals(str, (object) obj0))
        num = 0;
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeBoolean()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeBoolean"))
        return;
      NativeBoolean.BOOLEAN_TAG = (object) "Boolean";
    }
  }
}
