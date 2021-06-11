// Decompiled with JetBrains decompiler
// Type: rhino.ContextFactory
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.security;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace rhino
{
  public class ContextFactory : Object
  {
    private static volatile bool hasCustomGlobal;
    private static ContextFactory global;
    private volatile bool @sealed;
    [Modifiers]
    private object listenersLock;
    private volatile object listeners;
    private bool disabledListening;
    private ClassLoader applicationClassLoader;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ContextFactory getGlobal() => ContextFactory.global;

    [LineNumberTable(202)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Context makeContext() => new Context(this);

    [LineNumberTable(new byte[] {160, 246, 105, 98, 109, 99, 98, 231, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void onContextCreated(Context cx)
    {
      object listeners = this.listeners;
      int index = 0;
      while (true)
      {
        ContextFactory.Listener listener = (ContextFactory.Listener) Kit.getListener(listeners, index);
        if (listener != null)
        {
          listener.contextCreated(cx);
          ++index;
        }
        else
          break;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isSealed() => this.@sealed;

    [LineNumberTable(new byte[] {161, 0, 105, 98, 109, 99, 98, 231, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void onContextReleased(Context cx)
    {
      object listeners = this.listeners;
      int index = 0;
      while (true)
      {
        ContextFactory.Listener listener = (ContextFactory.Listener) Kit.getListener(listeners, index);
        if (listener != null)
        {
          listener.contextReleased(cx);
          ++index;
        }
        else
          break;
      }
    }

    [LineNumberTable(new byte[] {160, 98, 255, 62, 77, 103, 244, 89, 226, 73, 162, 103, 166, 103, 213, 177, 177})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool hasFeature(Context cx, int featureIndex)
    {
      switch (featureIndex)
      {
        case 1:
          switch (cx.getLanguageVersion())
          {
            case 100:
            case 110:
            case 120:
              return true;
            default:
              return false;
          }
        case 2:
        case 7:
        case 8:
        case 9:
        case 10:
        case 11:
        case 12:
        case 13:
        case 17:
        case 18:
        case 19:
          return false;
        case 3:
        case 5:
        case 14:
        case 20:
          return true;
        case 4:
          return cx.getLanguageVersion() == 120;
        case 6:
          int languageVersion = cx.getLanguageVersion();
          return languageVersion == 200 || languageVersion >= 160;
        case 15:
          return cx.getLanguageVersion() <= 170;
        case 16:
          return cx.getLanguageVersion() >= 200;
        default:
          string str = String.valueOf(featureIndex);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void observeInstructionCount(Context cx, int instructionCount)
    {
    }

    [LineNumberTable(304)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual GeneratedClassLoader createClassLoader(
      ClassLoader parent)
    {
      return (GeneratedClassLoader) AccessController.doPrivileged((PrivilegedAction) new ContextFactory.__\u003C\u003EAnon1(parent), ContextFactory.__\u003CGetCallerID\u003E());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public ClassLoader getApplicationClassLoader() => this.applicationClassLoader;

    [LineNumberTable(new byte[] {52, 232, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ContextFactory()
    {
      ContextFactory contextFactory = this;
      this.listenersLock = (object) new Object();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static ContextFactory access\u0024002([In] ContextFactory obj0) => ContextFactory.global = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static ContextFactory access\u0024000() => ContextFactory.global;

    [LineNumberTable(new byte[] {161, 60, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal void checkNotSealed()
    {
      if (this.@sealed)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
    }

    [LineNumberTable(525)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Context enterContext(Context cx) => Context.enter(cx, this);

    [Modifiers]
    [LineNumberTable(304)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static DefiningClassLoader lambda\u0024createClassLoader\u00240(
      [In] ClassLoader obj0)
    {
      return new DefiningClassLoader(obj0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool hasExplicitGlobal() => ContextFactory.hasCustomGlobal;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 103, 108, 99, 139, 105, 139, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void initGlobal(ContextFactory factory)
    {
      lock ((object) ClassLiteral<ContextFactory>.Value)
      {
        if (factory == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException();
        }
        if (ContextFactory.hasCustomGlobal)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException();
        }
        ContextFactory.hasCustomGlobal = true;
        Thread.MemoryBarrier();
        ContextFactory.global = factory;
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 99, 140, 105, 139, 237, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ContextFactory.GlobalSetter getGlobalSetter()
    {
      lock ((object) ClassLiteral<ContextFactory>.Value)
      {
        if (ContextFactory.hasCustomGlobal)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException();
        }
        ContextFactory.hasCustomGlobal = true;
        Thread.MemoryBarrier();
        return (ContextFactory.GlobalSetter) new ContextFactory.\u0031GlobalSetterImpl();
      }
    }

    [LineNumberTable(new byte[] {160, 168, 107, 197, 127, 0, 112, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool isDom3Present()
    {
      Class @class = Kit.classOrNull("org.w3c.dom.Node");
      if (@class == null)
        return false;
      int num;
      try
      {
        @class.getMethod("getUserData", new Class[1]
        {
          (Class) ClassLiteral<String>.Value
        }, ContextFactory.__\u003CGetCallerID\u003E());
        num = 1;
      }
      catch (NoSuchMethodException ex)
      {
        goto label_5;
      }
      return num != 0;
label_5:
      return false;
    }

    [LineNumberTable(new byte[] {160, 208, 99, 112, 104, 176, 104, 144, 134, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void initApplicationClassLoader(ClassLoader loader)
    {
      if (loader == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("loader is null");
      }
      if (!Kit.testIfCanLoadRhinoClasses(loader))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Loader can not resolve Rhino classes");
      }
      if (this.applicationClassLoader != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("applicationClassLoader can only be set once");
      }
      this.checkNotSealed();
      this.applicationClassLoader = loader;
    }

    [LineNumberTable(new byte[] {160, 232, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual object doTopCall(
      Callable callable,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      object obj = callable.call(cx, scope, thisObj, args);
      return obj is ConsString ? (object) Object.instancehelper_toString(obj) : obj;
    }

    [LineNumberTable(new byte[] {161, 10, 102, 109, 104, 139, 123, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void addListener(ContextFactory.Listener listener)
    {
      this.checkNotSealed();
      lock (this.listenersLock)
      {
        if (this.disabledListening)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException();
        }
        this.listeners = Kit.addListener(this.listeners, (object) listener);
        Thread.MemoryBarrier();
      }
    }

    [LineNumberTable(new byte[] {161, 20, 102, 109, 104, 139, 123, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void removeListener(ContextFactory.Listener listener)
    {
      this.checkNotSealed();
      lock (this.listenersLock)
      {
        if (this.disabledListening)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException();
        }
        this.listeners = Kit.removeListener(this.listeners, (object) listener);
        Thread.MemoryBarrier();
      }
    }

    [LineNumberTable(new byte[] {161, 34, 102, 109, 103, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal void disableContextListening()
    {
      this.checkNotSealed();
      lock (this.listenersLock)
      {
        this.disabledListening = true;
        this.listeners = (object) null;
        Thread.MemoryBarrier();
      }
    }

    [LineNumberTable(new byte[] {161, 55, 102, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void seal()
    {
      this.checkNotSealed();
      this.@sealed = true;
      Thread.MemoryBarrier();
    }

    [Signature("<T:Ljava/lang/Object;>(Lrhino/ContextAction<TT;>;)TT;")]
    [LineNumberTable(446)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public object call(ContextAction action) => Context.call(this, action);

    [LineNumberTable(489)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Context enterContext() => this.enterContext((Context) null);

    [Obsolete]
    [LineNumberTable(498)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Context enter() => this.enterContext((Context) null);

    [Obsolete]
    [LineNumberTable(new byte[] {161, 136, 101})]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void exit() => Context.exit();

    [LineNumberTable(104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ContextFactory()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.ContextFactory"))
        return;
      ContextFactory.global = new ContextFactory();
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (ContextFactory.__\u003CcallerID\u003E == null)
        ContextFactory.__\u003CcallerID\u003E = (CallerID) new ContextFactory.__\u003CCallerID\u003E();
      return ContextFactory.__\u003CcallerID\u003E;
    }

    [InnerClass]
    [EnclosingMethod(null, "getGlobalSetter", "()Lrhino.ContextFactory$GlobalSetter;")]
    [SpecialName]
    internal class \u0031GlobalSetterImpl : Object, ContextFactory.GlobalSetter
    {
      [LineNumberTable(178)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031GlobalSetterImpl()
      {
      }

      [LineNumberTable(new byte[] {160, 67, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setContextFactoryGlobal([In] ContextFactory obj0) => ContextFactory.access\u0024002(obj0 != null ? obj0 : new ContextFactory());

      [LineNumberTable(186)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual ContextFactory getContextFactoryGlobal() => ContextFactory.access\u0024000();
    }

    public interface GlobalSetter
    {
      void setContextFactoryGlobal(ContextFactory cf);

      ContextFactory getContextFactoryGlobal();
    }

    public interface Listener
    {
      void contextCreated(Context c);

      void contextReleased(Context c);
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : PrivilegedAction
    {
      private readonly ClassLoader arg\u00241;

      internal __\u003C\u003EAnon1([In] ClassLoader obj0) => this.arg\u00241 = obj0;

      public object run() => (object) ContextFactory.lambda\u0024createClassLoader\u00240(this.arg\u00241);
    }
  }
}
