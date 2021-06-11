// Decompiled with JetBrains decompiler
// Type: rhino.InterfaceAdapter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.lang.reflect;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class InterfaceAdapter : Object
  {
    [Modifiers]
    private object proxyHelper;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [LineNumberTable(new byte[] {19, 115, 114, 177, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isFunctionalMethodCandidate([In] Method obj0) => !String.instancehelper_equals(obj0.getName(), (object) "equals") && !String.instancehelper_equals(obj0.getName(), (object) "hashCode") && !String.instancehelper_equals(obj0.getName(), (object) "toString") && Modifier.isAbstract(obj0.getModifiers());

    [Signature("(Lrhino/ContextFactory;Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {30, 104, 113, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private InterfaceAdapter([In] ContextFactory obj0, [In] Class obj1)
    {
      InterfaceAdapter interfaceAdapter = this;
      this.proxyHelper = VMBridge.instance.getInterfaceProxyHelper(obj0, new Class[1]
      {
        obj1
      });
    }

    [LineNumberTable(new byte[] {52, 104, 140, 103, 104, 104, 205, 144, 105, 110, 130, 137, 104, 177, 135, 104, 100, 137, 110, 135, 155, 241, 59, 232, 73, 142, 109, 105, 110, 132, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object invokeImpl(
      [In] Context obj0,
      [In] object obj1,
      [In] Scriptable obj2,
      [In] object obj3,
      [In] Method obj4,
      [In] object[] obj5)
    {
      Callable callable;
      if (obj1 is Callable)
      {
        callable = (Callable) obj1;
      }
      else
      {
        Scriptable scriptable = (Scriptable) obj1;
        string name = obj4.getName();
        object property = ScriptableObject.getProperty(scriptable, name);
        if (object.ReferenceEquals(property, Scriptable.NOT_FOUND))
        {
          Context.reportWarning(ScriptRuntime.getMessage1("msg.undefined.function.interface", (object) name));
          Class returnType = obj4.getReturnType();
          return object.ReferenceEquals((object) returnType, (object) Void.TYPE) ? (object) null : Context.jsToJava((object) null, returnType);
        }
        callable = property is Callable ? (Callable) property : throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.not.function.interface", (object) name));
      }
      WrapFactory wrapFactory = obj0.getWrapFactory();
      if (obj5 == null)
      {
        obj5 = ScriptRuntime.__\u003C\u003EemptyArgs;
      }
      else
      {
        int index = 0;
        for (int length = obj5.Length; index != length; ++index)
        {
          object obj = obj5[index];
          switch (obj)
          {
            case string _:
            case Number _:
            case Boolean _:
              continue;
            default:
              obj5[index] = wrapFactory.wrap(obj0, obj2, obj, (Class) null);
              continue;
          }
        }
      }
      Scriptable s2 = wrapFactory.wrapAsJavaObject(obj0, obj2, obj3, (Class) null);
      object obj6 = callable.call(obj0, obj2, s2, obj5);
      Class returnType1 = obj4.getReturnType();
      return !object.ReferenceEquals((object) returnType1, (object) Void.TYPE) ? Context.jsToJava(obj6, returnType1) : (object) null;
    }

    [Modifiers]
    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object lambda\u0024invoke\u00240(
      [In] object obj0,
      [In] Scriptable obj1,
      [In] object obj2,
      [In] Method obj3,
      [In] object[] obj4,
      [In] Context obj5)
    {
      return this.invokeImpl(obj5, obj0, obj1, obj2, obj3, obj4);
    }

    [Signature("(Lrhino/Context;Ljava/lang/Class<*>;Lrhino/ScriptableObject;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {159, 162, 147, 103, 135, 109, 103, 102, 109, 235, 69, 101, 100, 102, 37, 171, 104, 99, 185, 105, 100, 107, 112, 134, 5, 235, 57, 232, 79, 104, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object create([In] Context obj0, [In] Class obj1, [In] ScriptableObject obj2)
    {
      if (!obj1.isInterface())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      Scriptable topCallScope = ScriptRuntime.getTopCallScope(obj0);
      ClassCache classCache = ClassCache.get(topCallScope);
      InterfaceAdapter ia = (InterfaceAdapter) classCache.getInterfaceAdapter(obj1);
      ContextFactory factory = obj0.getFactory();
      if (ia == null)
      {
        Method[] methods = obj1.getMethods(InterfaceAdapter.__\u003CGetCallerID\u003E());
        if (obj2 is Callable)
        {
          int length1 = methods.Length;
          if (length1 == 0)
            throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.no.empty.interface.conversion", (object) obj1.getName()));
          if (length1 > 1)
          {
            string str = (string) null;
            Method[] methodArray = methods;
            int length2 = methodArray.Length;
            for (int index = 0; index < length2; ++index)
            {
              Method method = methodArray[index];
              if (InterfaceAdapter.isFunctionalMethodCandidate(method))
              {
                if (str == null)
                  str = method.getName();
                else if (!String.instancehelper_equals(str, (object) method.getName()))
                  throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.no.function.interface.conversion", (object) obj1.getName()));
              }
            }
          }
        }
        ia = new InterfaceAdapter(factory, obj1);
        classCache.cacheInterfaceAdapter(obj1, (object) ia);
      }
      return VMBridge.instance.newInterfaceProxy(ia.proxyHelper, factory, ia, (object) obj2, topCallScope);
    }

    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object invoke(
      ContextFactory cf,
      object target,
      Scriptable topScope,
      object thisObject,
      Method method,
      object[] args)
    {
      return cf.call((ContextAction) new InterfaceAdapter.__\u003C\u003EAnon1(this, target, topScope, thisObject, method, args));
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (InterfaceAdapter.__\u003CcallerID\u003E == null)
        InterfaceAdapter.__\u003CcallerID\u003E = (CallerID) new InterfaceAdapter.__\u003CCallerID\u003E();
      return InterfaceAdapter.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : ContextAction
    {
      private readonly InterfaceAdapter arg\u00241;
      private readonly object arg\u00242;
      private readonly Scriptable arg\u00243;
      private readonly object arg\u00244;
      private readonly Method arg\u00245;
      private readonly object[] arg\u00246;

      internal __\u003C\u003EAnon1(
        [In] InterfaceAdapter obj0,
        [In] object obj1,
        [In] Scriptable obj2,
        [In] object obj3,
        [In] Method obj4,
        [In] object[] obj5)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
      }

      public object run([In] Context obj0) => this.arg\u00241.lambda\u0024invoke\u00240(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, obj0);
    }
  }
}
