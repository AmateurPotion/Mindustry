// Decompiled with JetBrains decompiler
// Type: rhino.module.Require
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.net;
using java.util;
using java.util.concurrent;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace rhino.module
{
  public class Require : BaseFunction
  {
    [Modifiers]
    private ModuleScriptProvider moduleScriptProvider;
    [Modifiers]
    private Scriptable nativeScope;
    [Modifiers]
    private Scriptable paths;
    [Modifiers]
    private bool sandboxed;
    [Modifiers]
    private Script preExec;
    [Modifiers]
    private Script postExec;
    private string mainModuleId;
    private Scriptable mainExports;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/String;Lrhino/Scriptable;>;")]
    private Map exportedModuleInterfaces;
    [Modifiers]
    private object loadLock;
    [Modifiers]
    [Signature("Ljava/lang/ThreadLocal<Ljava/util/Map<Ljava/lang/String;Lrhino/Scriptable;>;>;")]
    private static ThreadLocal loadingModuleInterfaces;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void install(Scriptable scope) => ScriptableObject.putProperty(scope, "require", (object) this);

    [LineNumberTable(new byte[] {160, 222, 104, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void defineReadOnlyProperty([In] ScriptableObject obj0, [In] string obj1, [In] object obj2)
    {
      ScriptableObject.putProperty((Scriptable) obj0, obj1, obj2);
      obj0.setAttributes(obj1, 5);
    }

    [LineNumberTable(new byte[] {159, 89, 131, 114, 99, 99, 176, 194, 101, 107, 104, 114, 99, 226, 75, 173, 114, 99, 174, 109, 113, 191, 23, 141, 110, 100, 102, 240, 74, 223, 5, 142, 106, 127, 6, 255, 3, 71, 228, 71, 127, 0, 255, 15, 51, 130, 127, 0, 159, 2, 230, 71, 127, 0, 139, 111, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Scriptable getExportedModuleInterface(
      [In] Context obj0,
      [In] string obj1,
      [In] URI obj2,
      [In] URI obj3,
      [In] bool obj4)
    {
      int num1 = obj4 ? 1 : 0;
      Scriptable scriptable1 = (Scriptable) this.exportedModuleInterfaces.get((object) obj1);
      if (scriptable1 != null)
      {
        if (num1 != 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("Attempt to set main module after it was loaded");
        }
        return scriptable1;
      }
      object obj5 = (object) (Map) Require.loadingModuleInterfaces.get();
      if ((Map) obj5 != null)
      {
        scriptable1 = (Scriptable) ((Map) obj5).get((object) obj1);
        if (scriptable1 != null)
          return scriptable1;
      }
      object loadLock;
      Monitor.Enter(loadLock = this.loadLock);
      int num2;
      RuntimeException runtimeException1;
      Exception exception1;
      // ISSUE: fault handler
      try
      {
        scriptable1 = (Scriptable) this.exportedModuleInterfaces.get((object) obj1);
        if (scriptable1 != null)
        {
          Scriptable scriptable2 = scriptable1;
          Monitor.Exit(loadLock);
          return scriptable2;
        }
        ModuleScript module = this.getModule(obj0, obj1, obj2, obj3);
        if (this.sandboxed && !module.isSandboxed())
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.throwError(obj0, this.nativeScope, new StringBuilder().append("Module \"").append(obj1).append("\" is not contained in sandbox.").toString()));
        scriptable1 = obj0.newObject(this.nativeScope);
        num2 = (Map) obj5 != null ? 0 : 1;
        if (num2 != 0)
        {
          obj5 = (object) new HashMap();
          Require.loadingModuleInterfaces.set((object) (HashMap) obj5);
        }
        object obj6 = obj5;
        string str1 = obj1;
        object obj7 = (object) scriptable1;
        object obj8 = (object) str1;
        Map map1;
        if (obj6 != null)
          map1 = obj6 is Map map18 ? map18 : throw new IncompatibleClassChangeError();
        else
          map1 = (Map) null;
        object obj9 = obj8;
        object obj10 = obj7;
        map1.put(obj9, obj10);
        try
        {
          try
          {
            Scriptable scriptable2 = this.executeModuleScript(obj0, obj1, scriptable1, module, num1 != 0);
            if (!object.ReferenceEquals((object) scriptable1, (object) scriptable2))
            {
              object obj11 = obj5;
              string str2 = obj1;
              object obj12 = (object) scriptable2;
              object obj13 = (object) str2;
              Map map4;
              if (obj11 != null)
                map4 = obj11 is Map map19 ? map19 : throw new IncompatibleClassChangeError();
              else
                map4 = (Map) null;
              object obj14 = obj13;
              object obj15 = obj12;
              map4.put(obj14, obj15);
              scriptable1 = scriptable2;
            }
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
            {
              throw;
            }
            else
            {
              runtimeException1 = (RuntimeException) m0;
              goto label_38;
            }
          }
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_39;
        }
        if (num2 != 0)
        {
          Map moduleInterfaces = this.exportedModuleInterfaces;
          object obj11 = obj5;
          Map map4;
          if (obj11 != null)
            map4 = obj11 is Map map20 ? map20 : throw new IncompatibleClassChangeError();
          else
            map4 = (Map) null;
          moduleInterfaces.putAll(map4);
          Require.loadingModuleInterfaces.set((object) null);
          goto label_58;
        }
        else
          goto label_58;
      }
      __fault
      {
        Monitor.Exit(loadLock);
      }
label_38:
      RuntimeException runtimeException2 = runtimeException1;
      Exception exception2;
      // ISSUE: fault handler
      try
      {
        RuntimeException runtimeException3 = runtimeException2;
        try
        {
          RuntimeException runtimeException4 = runtimeException3;
          object obj6 = obj5;
          object obj7 = (object) obj1;
          Map map1;
          if (obj6 != null)
            map1 = obj6 is Map map22 ? map22 : throw new IncompatibleClassChangeError();
          else
            map1 = (Map) null;
          object obj8 = obj7;
          map1.remove(obj8);
          throw Throwable.__\u003Cunmap\u003E((Exception) runtimeException4);
        }
        catch (Exception ex)
        {
          exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      __fault
      {
        Monitor.Exit(loadLock);
      }
      Exception exception3 = exception2;
      goto label_49;
label_39:
      exception3 = exception1;
label_49:
      Exception exception4 = exception3;
      // ISSUE: fault handler
      try
      {
        Exception exception5 = exception4;
        if (num2 != 0)
        {
          Map moduleInterfaces = this.exportedModuleInterfaces;
          object obj6 = obj5;
          Map map1;
          if (obj6 != null)
            map1 = obj6 is Map map24 ? map24 : throw new IncompatibleClassChangeError();
          else
            map1 = (Map) null;
          moduleInterfaces.putAll(map1);
          Require.loadingModuleInterfaces.set((object) null);
        }
        throw Throwable.__\u003Cunmap\u003E(exception5);
      }
      __fault
      {
        Monitor.Exit(loadLock);
      }
label_58:
      // ISSUE: fault handler
      try
      {
        Monitor.Exit(loadLock);
      }
      __fault
      {
        Monitor.Exit(loadLock);
      }
      return scriptable1;
    }

    [LineNumberTable(new byte[] {160, 229, 113, 102, 99, 191, 23, 127, 14, 98, 104, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ModuleScript getModule([In] Context obj0, [In] string obj1, [In] URI obj2, [In] URI obj3)
    {
      ModuleScript moduleScript;
      RuntimeException runtimeException;
      Exception exception;
      try
      {
        try
        {
          moduleScript = this.moduleScriptProvider.getModuleScript(obj0, obj1, obj2, obj3, this.paths) ?? throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.throwError(obj0, this.nativeScope, new StringBuilder().append("Module \"").append(obj1).append("\" not found.").toString()));
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            runtimeException = (RuntimeException) m0;
            goto label_10;
          }
        }
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception = (Exception) m0;
          goto label_11;
        }
      }
      return moduleScript;
label_10:
      throw Throwable.__\u003Cunmap\u003E((Exception) runtimeException);
label_11:
      throw Throwable.__\u003Cunmap\u003E((Exception) Context.throwAsScriptRuntimeEx((Exception) exception));
    }

    [LineNumberTable(new byte[] {159, 67, 67, 146, 104, 104, 108, 104, 145, 244, 69, 111, 111, 109, 104, 99, 140, 110, 112, 110, 109, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Scriptable executeModuleScript(
      [In] Context obj0,
      [In] string obj1,
      [In] Scriptable obj2,
      [In] ModuleScript obj3,
      [In] bool obj4)
    {
      int num = obj4 ? 1 : 0;
      ScriptableObject scriptableObject = (ScriptableObject) obj0.newObject(this.nativeScope);
      URI uri = obj3.getUri();
      URI @base = obj3.getBase();
      Require.defineReadOnlyProperty(scriptableObject, "id", (object) obj1);
      if (!this.sandboxed)
        Require.defineReadOnlyProperty(scriptableObject, "uri", (object) uri.toString());
      ModuleScope.__\u003Cclinit\u003E();
      ModuleScope moduleScope = new ModuleScope(this.nativeScope, uri, @base);
      moduleScope.put("exports", (Scriptable) moduleScope, (object) obj2);
      moduleScope.put("module", (Scriptable) moduleScope, (object) scriptableObject);
      scriptableObject.put("exports", (Scriptable) scriptableObject, (object) obj2);
      this.install((Scriptable) moduleScope);
      if (num != 0)
        Require.defineReadOnlyProperty((ScriptableObject) this, "main", (object) scriptableObject);
      Require.executeOptionalScript(this.preExec, obj0, (Scriptable) moduleScope);
      obj3.getScript().exec(obj0, (Scriptable) moduleScope);
      Require.executeOptionalScript(this.postExec, obj0, (Scriptable) moduleScope);
      return ScriptRuntime.toObject(obj0, this.nativeScope, ScriptableObject.getProperty((Scriptable) scriptableObject, "exports"));
    }

    [LineNumberTable(new byte[] {160, 215, 99, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void executeOptionalScript([In] Script obj0, [In] Context obj1, [In] Scriptable obj2) => obj0?.exec(obj1, obj2);

    [LineNumberTable(new byte[] {159, 125, 99, 232, 32, 199, 139, 235, 91, 103, 103, 103, 104, 104, 108, 99, 110, 147, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Require(
      Context cx,
      Scriptable nativeScope,
      ModuleScriptProvider moduleScriptProvider,
      Script preExec,
      Script postExec,
      bool sandboxed)
    {
      int num = sandboxed ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      Require require = this;
      this.mainModuleId = (string) null;
      this.exportedModuleInterfaces = (Map) new ConcurrentHashMap();
      this.loadLock = (object) new Object();
      this.moduleScriptProvider = moduleScriptProvider;
      this.nativeScope = nativeScope;
      this.sandboxed = num != 0;
      this.preExec = preExec;
      this.postExec = postExec;
      this.setPrototype(ScriptableObject.getFunctionPrototype(nativeScope));
      if (num == 0)
      {
        this.paths = cx.newArray(nativeScope, 0);
        Require.defineReadOnlyProperty((ScriptableObject) this, nameof (paths), (object) this.paths);
      }
      else
        this.paths = (Scriptable) null;
    }

    [LineNumberTable(new byte[] {52, 104, 110, 191, 11, 231, 70, 255, 31, 70, 226, 60, 97, 103, 98, 173, 99, 150, 139, 195, 179, 2, 225, 69, 109, 104, 105, 191, 23, 137, 216, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable requireMain(Context cx, string mainModuleId)
    {
      if (this.mainModuleId != null)
      {
        if (!String.instancehelper_equals(this.mainModuleId, (object) mainModuleId))
        {
          string str = new StringBuilder().append("Main module already set to ").append(this.mainModuleId).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException(str);
        }
        return this.mainExports;
      }
      ModuleScript moduleScript;
      RuntimeException runtimeException;
      Exception exception1;
      try
      {
        try
        {
          moduleScript = this.moduleScriptProvider.getModuleScript(cx, mainModuleId, (URI) null, (URI) null, this.paths);
          goto label_13;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            runtimeException = (RuntimeException) m0;
        }
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_12;
        }
      }
      throw Throwable.__\u003Cunmap\u003E((Exception) runtimeException);
label_12:
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) exception2);
label_13:
      if (moduleScript != null)
        this.mainExports = this.getExportedModuleInterface(cx, mainModuleId, (URI) null, (URI) null, true);
      else if (!this.sandboxed)
      {
        URI uri = (URI) null;
        try
        {
          uri = new URI(mainModuleId);
          goto label_20;
        }
        catch (URISyntaxException ex)
        {
        }
label_20:
        if (uri == null || !uri.isAbsolute())
        {
          File file = new File(mainModuleId);
          uri = file.isFile() ? file.toURI() : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.throwError(cx, this.nativeScope, new StringBuilder().append("Module \"").append(mainModuleId).append("\" not found.").toString()));
        }
        this.mainExports = this.getExportedModuleInterface(cx, uri.toString(), uri, (URI) null, true);
      }
      this.mainModuleId = mainModuleId;
      return this.mainExports;
    }

    [LineNumberTable(new byte[] {114, 106, 210, 116, 98, 98, 125, 104, 255, 18, 69, 103, 103, 104, 137, 163, 169, 116, 171, 104, 191, 18, 199})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object call(Context cx, Scriptable scope, Scriptable thisObj, object[] args)
    {
      string str = args != null && args.Length >= 1 ? (string) Context.jsToJava(args[0], (Class) ClassLiteral<String>.Value) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.throwError(cx, scope, "require() needs one argument"));
      URI uri1 = (URI) null;
      URI uri2 = (URI) null;
      if (String.instancehelper_startsWith(str, "./") || String.instancehelper_startsWith(str, "../"))
      {
        ModuleScope moduleScope = thisObj is ModuleScope ? (ModuleScope) thisObj : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.throwError(cx, scope, new StringBuilder().append("Can't resolve relative module ID \"").append(str).append("\" when require() is used outside of a module").toString()));
        uri2 = moduleScope.getBase();
        URI uri3 = moduleScope.getUri();
        uri1 = uri3.resolve(str);
        if (uri2 == null)
        {
          str = uri1.toString();
        }
        else
        {
          str = uri2.relativize(uri3).resolve(str).toString();
          if (String.instancehelper_charAt(str, 0) == '.')
          {
            if (this.sandboxed)
              throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.throwError(cx, scope, new StringBuilder().append("Module \"").append(str).append("\" is not contained in sandbox.").toString()));
            str = uri1.toString();
          }
        }
      }
      return (object) this.getExportedModuleInterface(cx, str, uri1, uri2, false);
    }

    [LineNumberTable(207)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Scriptable construct(Context cx, Scriptable scope, object[] args) => throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.throwError(cx, scope, "require() can not be invoked as a constructor"));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getFunctionName() => "require";

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getArity() => 1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getLength() => 1;

    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Require()
    {
      BaseFunction.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.module.Require"))
        return;
      Require.loadingModuleInterfaces = (ThreadLocal) new Require.__\u003Ctls\u003E_0();
    }

    private sealed class __\u003Ctls\u003E_0 : IntrinsicThreadLocal
    {
      [ThreadStatic]
      private static object field;

      public virtual object get() => Require.__\u003Ctls\u003E_0.field;

      public virtual void set([In] object obj0) => Require.__\u003Ctls\u003E_0.field = obj0;

      internal __\u003Ctls\u003E_0()
      {
      }
    }
  }
}
