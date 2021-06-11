// Decompiled with JetBrains decompiler
// Type: rhino.Undefined
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class Undefined : Object
  {
    internal static object __\u003C\u003Einstance;
    internal static Scriptable __\u003C\u003ESCRIPTABLE_UNDEFINED;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isUndefined(object obj) => object.ReferenceEquals(Undefined.__\u003C\u003Einstance, obj) || object.ReferenceEquals((object) Undefined.__\u003C\u003ESCRIPTABLE_UNDEFINED, obj);

    [LineNumberTable(new byte[] {159, 153, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Undefined()
    {
    }

    [Throws(new string[] {"java.lang.Throwable"})]
    [Modifiers]
    [LineNumberTable(new byte[] {159, 175, 120, 114, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object lambda\u0024static\u00240([In] object obj0, [In] Method obj1, [In] object[] obj2)
    {
      if (String.instancehelper_equals(obj1.getName(), (object) "toString"))
        return (object) "undefined";
      if (String.instancehelper_equals(obj1.getName(), (object) "equals"))
        return (object) Boolean.valueOf(obj2.Length > 0 && Undefined.isUndefined(obj2[0]));
      string str = new StringBuilder().append("undefined doesn't support ").append(obj1.getName()).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException(str);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object readResolve() => Undefined.__\u003C\u003Einstance;

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj) => Undefined.isUndefined(obj) || base.equals(obj);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => 0;

    [LineNumberTable(new byte[] {159, 140, 109, 234, 87, 255, 28, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Undefined()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.Undefined"))
        return;
      Undefined.__\u003C\u003Einstance = (object) new Undefined();
      Undefined.__\u003C\u003ESCRIPTABLE_UNDEFINED = (Scriptable) Proxy.newProxyInstance(((Class) ClassLiteral<Undefined>.Value).getClassLoader(Undefined.__\u003CGetCallerID\u003E()), new Class[1]
      {
        (Class) ClassLiteral<Scriptable>.Value
      }, (InvocationHandler) new Undefined.__\u003C\u003EAnon1(), Undefined.__\u003CGetCallerID\u003E());
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (Undefined.__\u003CcallerID\u003E == null)
        Undefined.__\u003CcallerID\u003E = (CallerID) new Undefined.__\u003CCallerID\u003E();
      return Undefined.__\u003CcallerID\u003E;
    }

    [Modifiers]
    public static object instance
    {
      [HideFromJava] get => Undefined.__\u003C\u003Einstance;
    }

    [Modifiers]
    public static Scriptable SCRIPTABLE_UNDEFINED
    {
      [HideFromJava] get => Undefined.__\u003C\u003ESCRIPTABLE_UNDEFINED;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : InvocationHandler
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object invoke([In] object obj0, [In] Method obj1, [In] object[] obj2) => Undefined.lambda\u0024static\u00240(obj0, obj1, obj2);
    }
  }
}
