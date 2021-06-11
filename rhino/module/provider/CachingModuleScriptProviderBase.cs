// Decompiled with JetBrains decompiler
// Type: rhino.module.provider.CachingModuleScriptProviderBase
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.net;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace rhino.module.provider
{
  public abstract class CachingModuleScriptProviderBase : Object, ModuleScriptProvider
  {
    [Modifiers]
    private static int loadConcurrencyLevel;
    [Modifiers]
    private static int loadLockShift;
    [Modifiers]
    private static int loadLockMask;
    [Modifiers]
    private static int loadLockCount;
    [Modifiers]
    private object[] loadLocks;
    [Modifiers]
    private ModuleSourceProvider moduleSourceProvider;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static void __\u003Cclinit\u003E()
    {
    }

    protected internal abstract CachingModuleScriptProviderBase.CachedModuleScript getLoadedModule(
      string str);

    [LineNumberTable(147)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object getValidator(
      [In] CachingModuleScriptProviderBase.CachedModuleScript obj0)
    {
      return obj0?.getValidator();
    }

    [LineNumberTable(151)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool equal([In] object obj0, [In] object obj1)
    {
      if (obj0 != null)
        return Object.instancehelper_equals(obj0, obj1);
      return obj1 == null;
    }

    protected internal abstract void putLoadedModule(string str, ModuleScript ms, object obj);

    [LineNumberTable(new byte[] {2, 232, 49, 176, 108, 45, 230, 77, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal CachingModuleScriptProviderBase(ModuleSourceProvider moduleSourceProvider)
    {
      CachingModuleScriptProviderBase scriptProviderBase = this;
      this.loadLocks = new object[CachingModuleScriptProviderBase.loadLockCount];
      for (int index = 0; index < this.loadLocks.Length; ++index)
        this.loadLocks[index] = (object) new Object();
      this.moduleSourceProvider = moduleSourceProvider;
    }

    [Throws(new string[] {"java.lang.Exception"})]
    [LineNumberTable(new byte[] {9, 104, 103, 109, 113, 102, 109, 135, 99, 130, 106, 104, 127, 1, 105, 100, 111, 255, 20, 76, 95, 42, 255, 21, 52, 163, 104, 100, 103, 37, 136, 108, 101, 37, 133, 159, 7, 95, 37, 31, 21, 107, 123, 255, 32, 46, 238, 82})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ModuleScript getModuleScript(
      Context cx,
      string moduleId,
      URI moduleUri,
      URI baseUri,
      Scriptable paths)
    {
      CachingModuleScriptProviderBase.CachedModuleScript loadedModule1 = this.getLoadedModule(moduleId);
      object validator = CachingModuleScriptProviderBase.getValidator(loadedModule1);
      ModuleSource moduleSource = moduleUri != null ? this.moduleSourceProvider.loadSource(moduleUri, baseUri, validator) : this.moduleSourceProvider.loadSource(moduleId, paths, validator);
      if (object.ReferenceEquals((object) moduleSource, (object) ModuleSourceProvider.NOT_MODIFIED))
        return loadedModule1.getModule();
      if (moduleSource == null)
        return (ModuleScript) null;
      Reader reader = moduleSource.getReader();
      Exception exception1 = (Exception) null;
      object loadLock;
      ModuleScript module;
      Exception exception2;
      Exception exception3;
      // ISSUE: fault handler
      try
      {
        int num = String.instancehelper_hashCode(moduleId);
        Monitor.Enter(loadLock = this.loadLocks[(int) ((uint) num >> CachingModuleScriptProviderBase.loadLockShift) & CachingModuleScriptProviderBase.loadLockMask]);
        try
        {
          CachingModuleScriptProviderBase.CachedModuleScript loadedModule2 = this.getLoadedModule(moduleId);
          if (loadedModule2 != null)
          {
            if (!CachingModuleScriptProviderBase.equal(validator, CachingModuleScriptProviderBase.getValidator(loadedModule2)))
            {
              module = loadedModule2.getModule();
              Monitor.Exit(loadLock);
              goto label_20;
            }
            else
              goto label_27;
          }
          else
            goto label_27;
        }
        catch (Exception ex)
        {
          exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (Exception ex)
      {
        exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_19;
      }
      __fault
      {
        if (reader != null)
        {
          if (exception1 != null)
          {
            Exception exception4;
            try
            {
              reader.close();
              goto label_17;
            }
            catch (Exception ex)
            {
              exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            Exception exception5 = exception4;
            Throwable.instancehelper_addSuppressed(exception1, exception5);
          }
          else
            reader.close();
        }
label_17:;
      }
      Exception exception6 = exception2;
      goto label_46;
label_19:
      Exception exception7 = exception3;
      goto label_58;
label_20:
      if (reader != null)
      {
        if (null != null)
        {
          Exception exception4;
          try
          {
            reader.close();
            goto label_26;
          }
          catch (Exception ex)
          {
            exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
          Throwable.instancehelper_addSuppressed((Exception) null, exception4);
        }
        else
          reader.close();
      }
label_26:
      return module;
label_27:
      ModuleScript moduleScript;
      Exception exception8;
      Exception exception9;
      // ISSUE: fault handler
      try
      {
        try
        {
          URI uri = moduleSource.getUri();
          ModuleScript ms = new ModuleScript(cx.compileReader(reader, uri.toString(), 1, moduleSource.getSecurityDomain()), uri, moduleSource.getBase());
          this.putLoadedModule(moduleId, ms, moduleSource.getValidator());
          moduleScript = ms;
          Monitor.Exit(loadLock);
          goto label_39;
        }
        catch (Exception ex)
        {
          exception8 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (Exception ex)
      {
        exception9 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_38;
      }
      __fault
      {
        if (reader != null)
        {
          if (exception1 != null)
          {
            Exception exception4;
            try
            {
              reader.close();
              goto label_36;
            }
            catch (Exception ex)
            {
              exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            Exception exception5 = exception4;
            Throwable.instancehelper_addSuppressed(exception1, exception5);
          }
          else
            reader.close();
        }
label_36:;
      }
      exception6 = exception8;
      goto label_46;
label_38:
      exception7 = exception9;
      goto label_58;
label_39:
      if (reader != null)
      {
        if (null != null)
        {
          Exception exception4;
          try
          {
            reader.close();
            goto label_45;
          }
          catch (Exception ex)
          {
            exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
          Throwable.instancehelper_addSuppressed((Exception) null, exception4);
        }
        else
          reader.close();
      }
label_45:
      return moduleScript;
label_46:
      Exception exception10 = exception6;
      Exception exception11;
      // ISSUE: fault handler
      try
      {
        exception11 = exception10;
        try
        {
          Exception exception4 = exception11;
          Monitor.Exit(loadLock);
          throw Throwable.__\u003Cunmap\u003E(exception4);
        }
        catch (Exception ex)
        {
          exception11 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      __fault
      {
        if (reader != null)
        {
          if (exception1 != null)
          {
            Exception exception4;
            try
            {
              reader.close();
              goto label_56;
            }
            catch (Exception ex)
            {
              exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            Exception exception5 = exception4;
            Throwable.instancehelper_addSuppressed(exception1, exception5);
          }
          else
            reader.close();
        }
label_56:;
      }
      exception7 = exception11;
label_58:
      Exception exception12 = exception7;
      Exception exception13;
      // ISSUE: fault handler
      try
      {
        Exception exception4 = exception12;
        exception13 = exception4;
        throw Throwable.__\u003Cunmap\u003E(exception4);
      }
      __fault
      {
        if (reader != null)
        {
          if (exception13 != null)
          {
            Exception exception4;
            try
            {
              reader.close();
              goto label_66;
            }
            catch (Exception ex)
            {
              exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            Exception exception5 = exception4;
            Throwable.instancehelper_addSuppressed(exception13, exception5);
          }
          else
            reader.close();
        }
label_66:;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static int getConcurrencyLevel() => CachingModuleScriptProviderBase.loadLockCount;

    [LineNumberTable(new byte[] {159, 137, 77, 241, 70, 98, 98, 104, 100, 134, 105, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static CachingModuleScriptProviderBase()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.module.provider.CachingModuleScriptProviderBase"))
        return;
      CachingModuleScriptProviderBase.loadConcurrencyLevel = java.lang.Runtime.getRuntime().availableProcessors() * 8;
      int num1 = 0;
      int num2;
      for (num2 = 1; num2 < CachingModuleScriptProviderBase.loadConcurrencyLevel; num2 <<= 1)
        ++num1;
      CachingModuleScriptProviderBase.loadLockShift = 32 - num1;
      CachingModuleScriptProviderBase.loadLockMask = num2 - 1;
      CachingModuleScriptProviderBase.loadLockCount = num2;
    }

    public class CachedModuleScript : Object
    {
      [Modifiers]
      private ModuleScript moduleScript;
      [Modifiers]
      private object validator;

      [LineNumberTable(new byte[] {74, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public CachedModuleScript(ModuleScript moduleScript, object validator)
      {
        CachingModuleScriptProviderBase.CachedModuleScript cachedModuleScript = this;
        this.moduleScript = moduleScript;
        this.validator = validator;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual ModuleScript getModule() => this.moduleScript;

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual object getValidator() => this.validator;
    }
  }
}
