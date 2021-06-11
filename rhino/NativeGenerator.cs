// Decompiled with JetBrains decompiler
// Type: rhino.NativeGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace rhino
{
  public sealed class NativeGenerator : IdScriptableObject
  {
    [Modifiers]
    private static object GENERATOR_TAG;
    public const int GENERATOR_SEND = 0;
    public const int GENERATOR_THROW = 1;
    public const int GENERATOR_CLOSE = 2;
    private const int Id_close = 1;
    private const int Id_next = 2;
    private const int Id_send = 3;
    private const int Id_throw = 4;
    private const int Id___iterator__ = 5;
    private const int MAX_PROTOTYPE_ID = 5;
    private NativeFunction function;
    private object savedState;
    private string lineSource;
    private int lineNumber;
    private bool firstTime;
    private bool locked;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 186, 232, 160, 195, 231, 159, 62, 103, 199, 103, 103, 102, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeGenerator(Scriptable scope, NativeFunction function, object savedState)
    {
      NativeGenerator nativeGenerator = this;
      this.firstTime = true;
      this.function = function;
      this.savedState = savedState;
      Scriptable topLevelScope = ScriptableObject.getTopLevelScope(scope);
      this.setParentScope(topLevelScope);
      this.setPrototype((Scriptable) ScriptableObject.getTopScopeValue(topLevelScope, NativeGenerator.GENERATOR_TAG));
    }

    [LineNumberTable(new byte[] {159, 182, 232, 160, 199, 231, 159, 58})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeGenerator()
    {
      NativeGenerator nativeGenerator = this;
      this.firstTime = true;
    }

    [LineNumberTable(new byte[] {95, 104, 100, 134, 100, 133, 135, 189, 200, 104, 112, 103, 255, 5, 78, 105, 103, 112, 100, 103, 255, 30, 59, 105, 103, 112, 100, 103, 238, 46, 255, 8, 77, 105, 103, 112, 100, 103, 237, 59, 105, 103, 119, 100, 231, 47, 134, 193, 235, 71, 105, 103, 112, 100, 103, 227, 59, 105, 103, 119, 100, 231, 53, 103, 98, 109, 109, 103, 136, 105, 103, 112, 100, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object resume([In] Context obj0, [In] Scriptable obj1, [In] int obj2, [In] object obj3)
    {
      if (this.savedState == null)
      {
        object obj4;
        switch (obj2)
        {
          case 1:
            obj4 = obj3;
            break;
          case 2:
            return Undefined.__\u003C\u003Einstance;
          default:
            obj4 = NativeIterator.getStopIterationObject(obj1);
            break;
        }
        JavaScriptException.__\u003Cclinit\u003E();
        object obj5 = obj4;
        string lineSource = this.lineSource;
        int lineNumber = this.lineNumber;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new JavaScriptException(obj5, lineSource, lineNumber);
      }
      NativeGenerator nativeGenerator1;
      Exception exception1;
      RhinoException rhinoException1;
      // ISSUE: fault handler
      try
      {
        try
        {
          Monitor.Enter((object) (nativeGenerator1 = this));
          try
          {
            this.locked = !this.locked ? true : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.already.exec.gen"));
            Monitor.Exit((object) nativeGenerator1);
            goto label_35;
          }
          catch (Exception ex)
          {
            exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
        }
        catch (NativeGenerator.GeneratorClosedException ex)
        {
          goto label_20;
        }
      }
      catch (RhinoException ex)
      {
        rhinoException1 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_21;
      }
      __fault
      {
        lock (this)
          this.locked = false;
        if (obj2 == 2)
          this.savedState = (object) null;
      }
      Exception exception2 = exception1;
      RhinoException rhinoException2;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception2;
        try
        {
          Exception exception4 = exception3;
          try
          {
            Exception exception5 = exception4;
            Monitor.Exit((object) nativeGenerator1);
            throw Throwable.__\u003Cunmap\u003E(exception5);
          }
          catch (NativeGenerator.GeneratorClosedException ex)
          {
          }
        }
        catch (RhinoException ex)
        {
          rhinoException2 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_34;
        }
      }
      __fault
      {
        lock (this)
          this.locked = false;
        if (obj2 == 2)
          this.savedState = (object) null;
      }
      // ISSUE: variable of the null type
      __Null local = null;
      goto label_52;
label_34:
      RhinoException rhinoException3 = rhinoException2;
      goto label_66;
label_20:
      local = null;
      goto label_52;
label_21:
      rhinoException3 = rhinoException1;
      goto label_66;
label_35:
      object obj;
      RhinoException rhinoException4;
      // ISSUE: fault handler
      try
      {
        try
        {
          obj = this.function.resumeGenerator(obj0, obj1, obj2, this.savedState, obj3);
          goto label_46;
        }
        catch (NativeGenerator.GeneratorClosedException ex)
        {
        }
      }
      catch (RhinoException ex)
      {
        rhinoException4 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_45;
      }
      __fault
      {
        lock (this)
          this.locked = false;
        if (obj2 == 2)
          this.savedState = (object) null;
      }
      local = null;
      goto label_52;
label_45:
      rhinoException3 = rhinoException4;
      goto label_66;
label_46:
      NativeGenerator nativeGenerator2;
      Monitor.Enter((object) (nativeGenerator2 = this));
      // ISSUE: fault handler
      try
      {
        this.locked = false;
        Monitor.Exit((object) nativeGenerator2);
      }
      __fault
      {
        Monitor.Exit((object) nativeGenerator2);
      }
      if (obj2 == 2)
        this.savedState = (object) null;
      return obj;
label_52:
      object instance;
      // ISSUE: fault handler
      try
      {
        instance = Undefined.__\u003C\u003Einstance;
      }
      __fault
      {
        lock (this)
          this.locked = false;
        if (obj2 == 2)
          this.savedState = (object) null;
      }
      NativeGenerator nativeGenerator3;
      Monitor.Enter((object) (nativeGenerator3 = this));
      // ISSUE: fault handler
      try
      {
        this.locked = false;
        Monitor.Exit((object) nativeGenerator3);
      }
      __fault
      {
        Monitor.Exit((object) nativeGenerator3);
      }
      if (obj2 == 2)
        this.savedState = (object) null;
      return instance;
label_66:
      RhinoException rhinoException5 = rhinoException3;
      // ISSUE: fault handler
      try
      {
        RhinoException rhinoException6 = rhinoException5;
        this.lineNumber = rhinoException6.lineNumber();
        this.lineSource = rhinoException6.lineSource();
        this.savedState = (object) null;
        throw Throwable.__\u003Cunmap\u003E((Exception) rhinoException6);
      }
      __fault
      {
        lock (this)
          this.locked = false;
        if (obj2 == 2)
          this.savedState = (object) null;
      }
    }

    [LineNumberTable(new byte[] {159, 138, 66, 102, 99, 103, 140, 103, 99, 230, 71, 99, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static NativeGenerator init([In] ScriptableObject obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      NativeGenerator nativeGenerator = new NativeGenerator();
      if (obj0 != null)
      {
        nativeGenerator.setParentScope((Scriptable) obj0);
        nativeGenerator.setPrototype(ScriptableObject.getObjectPrototype((Scriptable) obj0));
      }
      nativeGenerator.activatePrototypeMap(5);
      if (num != 0)
        nativeGenerator.sealObject();
      obj0?.associateValue(NativeGenerator.GENERATOR_TAG, (object) nativeGenerator);
      return nativeGenerator;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Generator";

    [LineNumberTable(new byte[] {20, 158, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      int arity;
      string name;
      switch (id)
      {
        case 1:
          arity = 1;
          name = "close";
          break;
        case 2:
          arity = 1;
          name = "next";
          break;
        case 3:
          arity = 0;
          name = "send";
          break;
        case 4:
          arity = 0;
          name = "throw";
          break;
        case 5:
          arity = 1;
          name = "__iterator__";
          break;
        default:
          string str = String.valueOf(id);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.initPrototypeMethod(NativeGenerator.GENERATOR_TAG, id, name, arity);
    }

    [LineNumberTable(new byte[] {50, 109, 142, 135, 105, 140, 136, 223, 2, 239, 69, 103, 207, 114, 117, 144, 203, 219, 163})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag(NativeGenerator.GENERATOR_TAG))
        return base.execIdCall(f, cx, scope, thisObj, args);
      int num = f.methodId();
      NativeGenerator nativeGenerator = thisObj is NativeGenerator ? (NativeGenerator) thisObj : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(f));
      switch (num)
      {
        case 1:
          return nativeGenerator.resume(cx, scope, 2, (object) new NativeGenerator.GeneratorClosedException());
        case 2:
          nativeGenerator.firstTime = false;
          return nativeGenerator.resume(cx, scope, 0, Undefined.__\u003C\u003Einstance);
        case 3:
          object obj = args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0];
          if (nativeGenerator.firstTime && !Object.instancehelper_equals(obj, Undefined.__\u003C\u003Einstance))
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.send.newborn"));
          return nativeGenerator.resume(cx, scope, 0, obj);
        case 4:
          return nativeGenerator.resume(cx, scope, 1, args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0]);
        case 5:
          return (object) thisObj;
        default:
          string str = String.valueOf(num);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {160, 80, 98, 130, 103, 100, 104, 101, 102, 103, 104, 102, 132, 100, 104, 101, 102, 100, 101, 102, 132, 101, 102, 130, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 4:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'n':
              str = "next";
              num = 2;
              break;
            case 's':
              str = "send";
              num = 3;
              break;
          }
          break;
        case 5:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'c':
              str = "close";
              num = 1;
              break;
            case 't':
              str = "throw";
              num = 4;
              break;
          }
          break;
        case 12:
          str = "__iterator__";
          num = 5;
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
        num = 0;
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeGenerator()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeGenerator"))
        return;
      NativeGenerator.GENERATOR_TAG = (object) "Generator";
    }

    public class GeneratorClosedException : RuntimeException
    {
      [LineNumberTable(242)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public GeneratorClosedException()
      {
      }
    }
  }
}
