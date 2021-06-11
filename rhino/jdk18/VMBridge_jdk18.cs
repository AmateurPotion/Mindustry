// Decompiled with JetBrains decompiler
// Type: rhino.jdk18.VMBridge_jdk18
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.jdk18
{
  public class VMBridge_jdk18 : VMBridge
  {
    [Modifiers]
    [Signature("Ljava/lang/ThreadLocal<[Ljava/lang/Object;>;")]
    private ThreadLocal contextLocal;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Throws(new string[] {"java.lang.Throwable"})]
    [Modifiers]
    [LineNumberTable(new byte[] {33, 118, 104, 109, 229, 69, 148, 109, 140, 109, 191, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object lambda\u0024newInterfaceProxy\u00240(
      [In] object obj0,
      [In] InterfaceAdapter obj1,
      [In] ContextFactory obj2,
      [In] Scriptable obj3,
      [In] object obj4,
      [In] Method obj5,
      [In] object[] obj6)
    {
      if (object.ReferenceEquals((object) obj5.getDeclaringClass(), (object) ClassLiteral<Object>.Value))
      {
        string name = obj5.getName();
        if (String.instancehelper_equals(name, (object) "equals"))
        {
          object objB = obj6[0];
          return (object) Boolean.valueOf(object.ReferenceEquals(obj4, objB));
        }
        if (String.instancehelper_equals(name, (object) "hashCode"))
          return (object) Integer.valueOf(Object.instancehelper_hashCode(obj0));
        if (String.instancehelper_equals(name, (object) "toString"))
          return (object) new StringBuilder().append("Proxy[").append(Object.instancehelper_toString(obj0)).append("]").toString();
      }
      return obj1.invoke(obj2, obj0, obj3, obj4, obj5, obj6);
    }

    [LineNumberTable(new byte[] {159, 149, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VMBridge_jdk18()
    {
      VMBridge_jdk18 vmBridgeJdk18 = this;
      this.contextLocal = new ThreadLocal();
    }

    [LineNumberTable(new byte[] {159, 163, 113, 99, 103, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object getThreadContextHelper()
    {
      object[] objArray = (object[]) this.contextLocal.get();
      if (objArray == null)
      {
        objArray = new object[1];
        this.contextLocal.set((object) objArray);
      }
      return (object) objArray;
    }

    [LineNumberTable(new byte[] {159, 173, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override Context getContext(object contextHelper) => (Context) ((object[]) contextHelper)[0];

    [LineNumberTable(new byte[] {159, 179, 108, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setContext(object contextHelper, Context cx) => ((object[]) contextHelper)[0] = (object) cx;

    [LineNumberTable(new byte[] {159, 185, 104, 162, 156, 34, 161})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override bool tryToMakeAccessible(AccessibleObject accessible)
    {
      if (accessible.isAccessible())
        return true;
      try
      {
        accessible.setAccessible(true);
        goto label_6;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
      }
label_6:
      return accessible.isAccessible();
    }

    [Signature("(Lrhino/ContextFactory;[Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {9, 110, 173, 223, 13, 226, 61, 130, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object getInterfaceProxyHelper(
      ContextFactory cf,
      Class[] interfaces)
    {
      Class proxyClass = Proxy.getProxyClass(interfaces[0].getClassLoader(VMBridge_jdk18.__\u003CGetCallerID\u003E()), interfaces, VMBridge_jdk18.__\u003CGetCallerID\u003E());
      NoSuchMethodException suchMethodException1;
      try
      {
        return (object) proxyClass.getConstructor(new Class[1]
        {
          (Class) ClassLiteral<InvocationHandler>.Value
        }, VMBridge_jdk18.__\u003CGetCallerID\u003E());
      }
      catch (NoSuchMethodException ex)
      {
        suchMethodException1 = (NoSuchMethodException) ByteCodeHelper.MapException<NoSuchMethodException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      NoSuchMethodException suchMethodException2 = suchMethodException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalStateException((Exception) suchMethodException2);
    }

    [LineNumberTable(new byte[] {27, 135, 241, 89, 255, 37, 70, 226, 59, 98, 109, 130, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object newInterfaceProxy(
      object proxyHelper,
      ContextFactory cf,
      InterfaceAdapter adapter,
      object target,
      Scriptable topScope)
    {
      Constructor constructor = (Constructor) proxyHelper;
      InvocationHandler invocationHandler = (InvocationHandler) new VMBridge_jdk18.__\u003C\u003EAnon1(target, adapter, cf, topScope);
      InvocationTargetException invocationTargetException;
      IllegalAccessException illegalAccessException1;
      InstantiationException instantiationException;
      try
      {
        try
        {
          try
          {
            return constructor.newInstance(new object[1]
            {
              (object) invocationHandler
            }, VMBridge_jdk18.__\u003CGetCallerID\u003E());
          }
          catch (InvocationTargetException ex)
          {
            invocationTargetException = (InvocationTargetException) ByteCodeHelper.MapException<InvocationTargetException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
        }
        catch (IllegalAccessException ex)
        {
          illegalAccessException1 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_6;
        }
      }
      catch (InstantiationException ex)
      {
        instantiationException = (InstantiationException) ByteCodeHelper.MapException<InstantiationException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_7;
      }
      throw Throwable.__\u003Cunmap\u003E((Exception) Context.throwAsScriptRuntimeEx((Exception) invocationTargetException));
label_6:
      IllegalAccessException illegalAccessException2 = illegalAccessException1;
      goto label_8;
label_7:
      illegalAccessException2 = (IllegalAccessException) instantiationException;
label_8:
      ReflectiveOperationException operationException = (ReflectiveOperationException) illegalAccessException2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalStateException((Exception) operationException);
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (VMBridge_jdk18.__\u003CcallerID\u003E == null)
        VMBridge_jdk18.__\u003CcallerID\u003E = (CallerID) new VMBridge_jdk18.__\u003CCallerID\u003E();
      return VMBridge_jdk18.__\u003CcallerID\u003E;
    }

    [HideFromJava]
    static VMBridge_jdk18() => VMBridge.__\u003Cclinit\u003E();

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : InvocationHandler
    {
      private readonly object arg\u00241;
      private readonly InterfaceAdapter arg\u00242;
      private readonly ContextFactory arg\u00243;
      private readonly Scriptable arg\u00244;

      internal __\u003C\u003EAnon1(
        [In] object obj0,
        [In] InterfaceAdapter obj1,
        [In] ContextFactory obj2,
        [In] Scriptable obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public object invoke([In] object obj0, [In] Method obj1, [In] object[] obj2) => VMBridge_jdk18.lambda\u0024newInterfaceProxy\u00240(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, obj0, obj1, obj2);
    }
  }
}
