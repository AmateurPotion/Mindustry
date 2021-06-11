// Decompiled with JetBrains decompiler
// Type: rhino.PolicySecurityController
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.@ref;
using java.lang.reflect;
using java.security;
using java.util;
using rhino.classfile;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace rhino
{
  public class PolicySecurityController : SecurityController
  {
    [Modifiers]
    private static byte[] secureCallerImplBytecode;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/security/CodeSource;Ljava/util/Map<Ljava/lang/ClassLoader;Ljava/lang/ref/SoftReference<Lrhino/PolicySecurityController$SecureCaller;>;>;>;")]
    private static Map callers;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {75, 107, 191, 12, 113, 103, 150, 107, 103, 230, 70, 223, 8, 102, 39, 166, 191, 16, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static byte[] loadBytecode()
    {
      string name = ((Class) ClassLiteral<PolicySecurityController.SecureCaller>.Value).getName();
      ClassFileWriter.__\u003Cclinit\u003E();
      ClassFileWriter classFileWriter = new ClassFileWriter(new StringBuilder().append(name).append("Impl").toString(), name, "<generated>");
      classFileWriter.startMethod("<init>", "()V", (short) 1);
      classFileWriter.addALoad(0);
      classFileWriter.addInvoke(183, name, "<init>", "()V");
      classFileWriter.add(177);
      classFileWriter.stopMethod((short) 1);
      string str = "Lrhino/Context;Lrhino/Scriptable;Lrhino/Scriptable;[Ljava/lang/Object;)Ljava/lang/Object;";
      classFileWriter.startMethod("call", new StringBuilder().append("(Lrhino/Callable;").append(str).toString(), (short) 17);
      for (int local = 1; local < 6; ++local)
        classFileWriter.addALoad(local);
      classFileWriter.addInvoke(185, "rhino/Callable", "call", new StringBuilder().append("(").append(str).toString());
      classFileWriter.add(176);
      classFileWriter.stopMethod((short) 6);
      return classFileWriter.toByteArray();
    }

    [Modifiers]
    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object lambda\u0024createClassLoader\u00240([In] ClassLoader obj0, [In] object obj1)
    {
      PolicySecurityController.Loader.__\u003Cclinit\u003E();
      return (object) new PolicySecurityController.Loader(obj0, (CodeSource) obj1);
    }

    [Modifiers]
    [LineNumberTable(78)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object lambda\u0024callWithDomain\u00241([In] Context obj0) => (object) obj0.getApplicationClassLoader();

    [Throws(new string[] {"java.lang.Exception"})]
    [Modifiers]
    [LineNumberTable(new byte[] {52, 136, 107, 62, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object lambda\u0024callWithDomain\u00242([In] ClassLoader obj0, [In] CodeSource obj1) => new PolicySecurityController.Loader(obj0, obj1).defineClass(new StringBuilder().append(((Class) ClassLiteral<PolicySecurityController.SecureCaller>.Value).getName()).append("Impl").toString(), PolicySecurityController.secureCallerImplBytecode).newInstance(PolicySecurityController.__\u003CGetCallerID\u003E());

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PolicySecurityController()
    {
    }

    [Signature("()Ljava/lang/Class<*>;")]
    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Class getStaticSecurityDomainClassInternal() => (Class) ClassLiteral<CodeSource>.Value;

    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override GeneratedClassLoader createClassLoader(
      ClassLoader parent,
      object securityDomain)
    {
      return (GeneratedClassLoader) AccessController.doPrivileged((PrivilegedAction) new PolicySecurityController.__\u003C\u003EAnon0(parent, securityDomain), PolicySecurityController.__\u003CGetCallerID\u003E());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object getDynamicSecurityDomain(object securityDomain) => securityDomain;

    [LineNumberTable(new byte[] {27, 155, 135, 108, 113, 104, 102, 146, 149, 105, 127, 6, 100, 144, 131, 199, 253, 73, 191, 27, 22, 98, 186, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object callWithDomain(
      object securityDomain,
      Context cx,
      Callable callable,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      ClassLoader classLoader1 = (ClassLoader) AccessController.doPrivileged((PrivilegedAction) new PolicySecurityController.__\u003C\u003EAnon2(cx), PolicySecurityController.__\u003CGetCallerID\u003E());
      CodeSource codeSource = (CodeSource) securityDomain;
      Map callers;
      Monitor.Enter((object) (callers = PolicySecurityController.callers));
      object obj1;
      // ISSUE: fault handler
      try
      {
        obj1 = (object) (Map) PolicySecurityController.callers.get((object) codeSource);
        if ((Map) obj1 == null)
        {
          obj1 = (object) new WeakHashMap();
          PolicySecurityController.callers.put((object) codeSource, (object) (WeakHashMap) obj1);
        }
        Monitor.Exit((object) callers);
      }
      __fault
      {
        Monitor.Exit((object) callers);
      }
      object obj2;
      Monitor.Enter(obj2 = obj1);
      PolicySecurityController.SecureCaller secureCaller;
      PrivilegedActionException privilegedActionException1;
      // ISSUE: fault handler
      try
      {
        object obj3 = obj1;
        object obj4 = (object) classLoader1;
        Map map1;
        if (obj3 != null)
          map1 = obj3 is Map map12 ? map12 : throw new IncompatibleClassChangeError();
        else
          map1 = (Map) null;
        object obj5 = obj4;
        SoftReference softReference = (SoftReference) map1.get(obj5);
        secureCaller = softReference == null ? (PolicySecurityController.SecureCaller) null : (PolicySecurityController.SecureCaller) ((Reference) softReference).get();
        if (secureCaller == null)
        {
          try
          {
            secureCaller = (PolicySecurityController.SecureCaller) AccessController.doPrivileged((PrivilegedExceptionAction) new PolicySecurityController.__\u003C\u003EAnon3(classLoader1, codeSource), PolicySecurityController.__\u003CGetCallerID\u003E());
            object obj6 = obj1;
            ClassLoader classLoader2 = classLoader1;
            object obj7 = (object) new SoftReference((object) secureCaller);
            object obj8 = (object) classLoader2;
            Map map4;
            if (obj6 != null)
              map4 = obj6 is Map map13 ? map13 : throw new IncompatibleClassChangeError();
            else
              map4 = (Map) null;
            object obj9 = obj8;
            object obj10 = obj7;
            map4.put(obj9, obj10);
            goto label_22;
          }
          catch (PrivilegedActionException ex)
          {
            privilegedActionException1 = (PrivilegedActionException) ByteCodeHelper.MapException<PrivilegedActionException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
        }
        else
          goto label_22;
      }
      __fault
      {
        Monitor.Exit(obj2);
      }
      PrivilegedActionException privilegedActionException2 = privilegedActionException1;
      // ISSUE: fault handler
      try
      {
        Exception cause = privilegedActionException2.getCause();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UndeclaredThrowableException(cause);
      }
      __fault
      {
        Monitor.Exit(obj2);
      }
label_22:
      // ISSUE: fault handler
      try
      {
        Monitor.Exit(obj2);
      }
      __fault
      {
        Monitor.Exit(obj2);
      }
      return secureCaller.call(callable, cx, scope, thisObj, args);
    }

    [LineNumberTable(new byte[] {159, 137, 141, 234, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static PolicySecurityController()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.PolicySecurityController"))
        return;
      PolicySecurityController.secureCallerImplBytecode = PolicySecurityController.loadBytecode();
      PolicySecurityController.callers = (Map) new WeakHashMap();
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (PolicySecurityController.__\u003CcallerID\u003E == null)
        PolicySecurityController.__\u003CcallerID\u003E = (CallerID) new PolicySecurityController.__\u003CCallerID\u003E();
      return PolicySecurityController.__\u003CcallerID\u003E;
    }

    [InnerClass]
    [Implements(new string[] {"rhino.GeneratedClassLoader"})]
    internal class Loader : SecureClassLoader, GeneratedClassLoader
    {
      [Modifiers]
      private CodeSource codeSource;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 184, 105, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Loader([In] ClassLoader obj0, [In] CodeSource obj1)
        : base(obj0)
      {
        PolicySecurityController.Loader loader = this;
        this.codeSource = obj1;
      }

      [Signature("(Ljava/lang/String;[B)Ljava/lang/Class<*>;")]
      [LineNumberTable(48)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Class defineClass([In] string obj0, [In] byte[] obj1) => this.defineClass(obj0, obj1, 0, obj1.Length, this.codeSource);

      [Signature("(Ljava/lang/Class<*>;)V")]
      [LineNumberTable(new byte[] {3, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void linkClass([In] Class obj0) => ((ClassLoader) this).resolveClass(obj0);

      [HideFromJava]
      static Loader() => SecureClassLoader.__\u003Cclinit\u003E();
    }

    public abstract class SecureCaller : Object
    {
      public abstract object call(
        Callable c1,
        Context c2,
        Scriptable s1,
        Scriptable s2,
        object[] objarr);

      [LineNumberTable(118)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SecureCaller()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : PrivilegedAction
    {
      private readonly ClassLoader arg\u00241;
      private readonly object arg\u00242;

      internal __\u003C\u003EAnon0([In] ClassLoader obj0, [In] object obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object run() => PolicySecurityController.lambda\u0024createClassLoader\u00240(this.arg\u00241, this.arg\u00242);
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : PrivilegedAction
    {
      private readonly Context arg\u00241;

      internal __\u003C\u003EAnon2([In] Context obj0) => this.arg\u00241 = obj0;

      public object run() => PolicySecurityController.lambda\u0024callWithDomain\u00241(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : PrivilegedExceptionAction
    {
      private readonly ClassLoader arg\u00241;
      private readonly CodeSource arg\u00242;

      internal __\u003C\u003EAnon3([In] ClassLoader obj0, [In] CodeSource obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object run() => PolicySecurityController.lambda\u0024callWithDomain\u00242(this.arg\u00241, this.arg\u00242);
    }
  }
}
