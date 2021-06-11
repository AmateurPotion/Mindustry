// Decompiled with JetBrains decompiler
// Type: rhino.SecureCaller
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.lang.@ref;
using java.lang.reflect;
using java.net;
using java.security;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace rhino
{
  public abstract class SecureCaller : Object
  {
    [Modifiers]
    private static byte[] secureCallerImplBytecode;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/security/CodeSource;Ljava/util/Map<Ljava/lang/ClassLoader;Ljava/lang/ref/SoftReference<Lrhino/SecureCaller;>;>;>;")]
    private static Map callers;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static byte[] access\u0024000() => SecureCaller.secureCallerImplBytecode;

    public abstract object call(
      Callable c1,
      Context c2,
      Scriptable s1,
      Scriptable s2,
      object[] objarr);

    [LineNumberTable(new byte[] {53, 144, 135, 159, 13, 104, 101, 250, 69, 255, 4, 59, 131, 104, 159, 6, 104, 118, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static byte[] loadBytecodePrivileged()
    {
      URL resource = ((Class) ClassLiteral<SecureCaller>.Value).getResource("SecureCallerImpl.clazz");
      InputStream inputStream;
      ByteArrayOutputStream arrayOutputStream;
      Exception exception1;
      IOException ioException1;
      try
      {
        inputStream = resource.openStream();
        try
        {
          arrayOutputStream = new ByteArrayOutputStream();
          goto label_7;
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_6;
      }
      Exception exception2 = exception1;
      goto label_20;
label_6:
      IOException ioException2 = ioException1;
      goto label_24;
label_7:
      byte[] byteArray;
      Exception exception3;
      IOException ioException3;
      Exception exception4;
      IOException ioException4;
      while (true)
      {
        int num;
        try
        {
          try
          {
            num = inputStream.read();
            if (num == -1)
              byteArray = arrayOutputStream.toByteArray();
            else
              goto label_15;
          }
          catch (Exception ex)
          {
            exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            break;
          }
          inputStream.close();
          goto label_14;
        }
        catch (IOException ex)
        {
          ioException3 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_13;
        }
label_15:
        try
        {
          try
          {
            arrayOutputStream.write(num);
          }
          catch (Exception ex)
          {
            exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            goto label_18;
          }
        }
        catch (IOException ex)
        {
          ioException4 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_19;
        }
      }
      exception2 = exception3;
      goto label_20;
label_13:
      ioException2 = ioException3;
      goto label_24;
label_14:
      return byteArray;
label_18:
      exception2 = exception4;
      goto label_20;
label_19:
      ioException2 = ioException4;
      goto label_24;
label_20:
      Exception exception5 = exception2;
      IOException ioException5;
      try
      {
        inputStream.close();
        throw Throwable.__\u003Cunmap\u003E(exception5);
      }
      catch (IOException ex)
      {
        ioException5 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      ioException2 = ioException5;
label_24:
      IOException ioException6 = ioException2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UndeclaredThrowableException((Exception) ioException6);
    }

    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static byte[] loadBytecode() => (byte[]) AccessController.doPrivileged((PrivilegedAction) new SecureCaller.__\u003C\u003EAnon2(), SecureCaller.__\u003CGetCallerID\u003E());

    [Modifiers]
    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object lambda\u0024callSecurely\u00240([In] Thread obj0) => (object) obj0.getContextClassLoader();

    [Modifiers]
    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object lambda\u0024loadBytecode\u00241() => (object) SecureCaller.loadBytecodePrivileged();

    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SecureCaller()
    {
    }

    [LineNumberTable(new byte[] {159, 175, 166, 187, 108, 113, 104, 102, 146, 149, 105, 127, 6, 100, 144, 131, 199, 248, 83, 191, 27, 22, 98, 186, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object callSecurely(
      [In] CodeSource obj0,
      [In] Callable obj1,
      [In] Context obj2,
      [In] Scriptable obj3,
      [In] Scriptable obj4,
      [In] object[] obj5)
    {
      ClassLoader classLoader1 = (ClassLoader) AccessController.doPrivileged((PrivilegedAction) new SecureCaller.__\u003C\u003EAnon0(Thread.currentThread()), SecureCaller.__\u003CGetCallerID\u003E());
      Map callers;
      Monitor.Enter((object) (callers = SecureCaller.callers));
      object obj6;
      // ISSUE: fault handler
      try
      {
        obj6 = (object) (Map) SecureCaller.callers.get((object) obj0);
        if ((Map) obj6 == null)
        {
          obj6 = (object) new WeakHashMap();
          SecureCaller.callers.put((object) obj0, (object) (WeakHashMap) obj6);
        }
        Monitor.Exit((object) callers);
      }
      __fault
      {
        Monitor.Exit((object) callers);
      }
      object obj7;
      Monitor.Enter(obj7 = obj6);
      SecureCaller secureCaller;
      PrivilegedActionException privilegedActionException1;
      // ISSUE: fault handler
      try
      {
        object obj8 = obj6;
        object obj9 = (object) classLoader1;
        Map map1;
        if (obj8 != null)
          map1 = obj8 is Map map12 ? map12 : throw new IncompatibleClassChangeError();
        else
          map1 = (Map) null;
        object obj10 = obj9;
        SoftReference softReference = (SoftReference) map1.get(obj10);
        secureCaller = softReference == null ? (SecureCaller) null : (SecureCaller) ((Reference) softReference).get();
        if (secureCaller == null)
        {
          try
          {
            secureCaller = (SecureCaller) AccessController.doPrivileged((PrivilegedExceptionAction) new SecureCaller.\u0031(classLoader1, obj0), SecureCaller.__\u003CGetCallerID\u003E());
            object obj11 = obj6;
            ClassLoader classLoader2 = classLoader1;
            object obj12 = (object) new SoftReference((object) secureCaller);
            object obj13 = (object) classLoader2;
            Map map4;
            if (obj11 != null)
              map4 = obj11 is Map map13 ? map13 : throw new IncompatibleClassChangeError();
            else
              map4 = (Map) null;
            object obj14 = obj13;
            object obj15 = obj12;
            map4.put(obj14, obj15);
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
        Monitor.Exit(obj7);
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
        Monitor.Exit(obj7);
      }
label_22:
      // ISSUE: fault handler
      try
      {
        Monitor.Exit(obj7);
      }
      __fault
      {
        Monitor.Exit(obj7);
      }
      return secureCaller.call(obj1, obj2, obj3, obj4, obj5);
    }

    [LineNumberTable(new byte[] {159, 139, 141, 234, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SecureCaller()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.SecureCaller"))
        return;
      SecureCaller.secureCallerImplBytecode = SecureCaller.loadBytecode();
      SecureCaller.callers = (Map) new WeakHashMap();
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (SecureCaller.__\u003CcallerID\u003E == null)
        SecureCaller.__\u003CcallerID\u003E = (CallerID) new SecureCaller.__\u003CCallerID\u003E();
      return SecureCaller.__\u003CcallerID\u003E;
    }

    [Signature("Ljava/lang/Object;Ljava/security/PrivilegedExceptionAction<Ljava/lang/Object;>;")]
    [EnclosingMethod(null, "callSecurely", "(Ljava.security.CodeSource;Lrhino.Callable;Lrhino.Context;Lrhino.Scriptable;Lrhino.Scriptable;[Ljava.lang.Object;)Ljava.lang.Object;")]
    [SpecialName]
    internal sealed class \u0031 : Object, PrivilegedExceptionAction
    {
      [Modifiers]
      internal ClassLoader val\u0024classLoader;
      [Modifiers]
      internal CodeSource val\u0024codeSource;
      [SpecialName]
      private static CallerID __\u003CcallerID\u003E;

      [LineNumberTable(59)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] ClassLoader obj0, [In] CodeSource obj1)
      {
        this.val\u0024classLoader = obj0;
        this.val\u0024codeSource = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [Throws(new string[] {"java.lang.Exception"})]
      [LineNumberTable(new byte[] {13, 103, 121, 142, 135, 135, 107, 121, 11, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object run()
      {
        Class @class = Object.instancehelper_getClass((object) this);
        return new SecureCaller.SecureClassLoaderImpl(object.ReferenceEquals((object) this.val\u0024classLoader.loadClass(@class.getName()), (object) @class) ? this.val\u0024classLoader : @class.getClassLoader(SecureCaller.\u0031.__\u003CGetCallerID\u003E())).defineAndLinkClass(new StringBuilder().append(((Class) ClassLiteral<SecureCaller>.Value).getName()).append("Impl").toString(), SecureCaller.access\u0024000(), this.val\u0024codeSource).newInstance(SecureCaller.\u0031.__\u003CGetCallerID\u003E());
      }

      static CallerID __\u003CGetCallerID\u003E()
      {
        if (SecureCaller.\u0031.__\u003CcallerID\u003E == null)
          SecureCaller.\u0031.__\u003CcallerID\u003E = (CallerID) new SecureCaller.\u0031.__\u003CCallerID\u003E();
        return SecureCaller.\u0031.__\u003CcallerID\u003E;
      }

      private sealed class __\u003CCallerID\u003E : CallerID
      {
        internal __\u003CCallerID\u003E()
        {
        }
      }
    }

    [InnerClass]
    internal class SecureClassLoaderImpl : SecureClassLoader
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {38, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal SecureClassLoaderImpl([In] ClassLoader obj0)
        : base(obj0)
      {
      }

      [Signature("(Ljava/lang/String;[BLjava/security/CodeSource;)Ljava/lang/Class<*>;")]
      [LineNumberTable(new byte[] {42, 109, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual Class defineAndLinkClass([In] string obj0, [In] byte[] obj1, [In] CodeSource obj2)
      {
        Class @class = this.defineClass(obj0, obj1, 0, obj1.Length, obj2);
        ((ClassLoader) this).resolveClass(@class);
        return @class;
      }

      [HideFromJava]
      static SecureClassLoaderImpl() => SecureClassLoader.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : PrivilegedAction
    {
      private readonly Thread arg\u00241;

      internal __\u003C\u003EAnon0([In] Thread obj0) => this.arg\u00241 = obj0;

      public object run() => SecureCaller.lambda\u0024callSecurely\u00240(this.arg\u00241);
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
      internal __\u003C\u003EAnon2()
      {
      }

      public object run() => SecureCaller.lambda\u0024loadBytecode\u00241();
    }
  }
}
