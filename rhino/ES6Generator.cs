// Decompiled with JetBrains decompiler
// Type: rhino.ES6Generator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public sealed class ES6Generator : IdScriptableObject
  {
    [Modifiers]
    private static object GENERATOR_TAG;
    private const int Id_next = 1;
    private const int Id_return = 2;
    private const int Id_throw = 3;
    private const int SymbolId_iterator = 4;
    private const int MAX_PROTOTYPE_ID = 4;
    private NativeFunction function;
    private object savedState;
    private string lineSource;
    private int lineNumber;
    private ES6Generator.State state;
    private object delegee;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 174, 232, 161, 134, 235, 158, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ES6Generator()
    {
      ES6Generator es6Generator = this;
      this.state = ES6Generator.State.SUSPENDED_START;
    }

    [LineNumberTable(new byte[] {160, 175, 114, 144, 146, 171, 105, 114, 100, 158, 113, 162, 139, 99, 100, 105, 168, 105, 111, 105, 239, 69, 118, 140, 255, 5, 89, 114, 103, 145, 243, 60, 117, 103, 250, 39, 97, 239, 86, 114, 103, 145, 227, 60, 117, 103, 250, 41, 98, 107, 110, 104, 47, 167, 109, 109, 110, 146, 234, 74, 114, 103, 145, 227, 60, 117, 103, 247, 54, 98, 107, 109, 109, 200, 114, 103, 145, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Scriptable resumeAbruptLocal(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] int obj2,
      [In] object obj3)
    {
      if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.EXECUTING))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.generator.executing"));
      if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.SUSPENDED_START))
        this.state = ES6Generator.State.COMPLETED;
      Scriptable scriptable = ES6Iterator.makeIteratorResult(obj0, obj1, false);
      if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
      {
        if (obj2 == 1)
        {
          JavaScriptException.__\u003Cclinit\u003E();
          object obj = obj3;
          string lineSource = this.lineSource;
          int lineNumber = this.lineNumber;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new JavaScriptException(obj, lineSource, lineNumber);
        }
        ScriptableObject.putProperty(scriptable, "done", (object) Boolean.valueOf(true));
        return scriptable;
      }
      this.state = ES6Generator.State.EXECUTING;
      object obj4 = obj3;
      if (obj2 == 2)
      {
        if (!(obj3 is NativeGenerator.GeneratorClosedException))
          obj4 = (object) new NativeGenerator.GeneratorClosedException();
      }
      else
      {
        switch (obj3)
        {
          case JavaScriptException _:
            obj4 = ((JavaScriptException) obj3).getValue();
            break;
          case RhinoException _:
            obj4 = (object) ScriptRuntime.wrapException((Exception) obj3, obj1, obj0);
            break;
        }
      }
      JavaScriptException javaScriptException1;
      RhinoException rhinoException1;
      // ISSUE: fault handler
      try
      {
        try
        {
          try
          {
            object obj5 = this.function.resumeGenerator(obj0, obj1, obj2, this.savedState, obj4);
            ScriptableObject.putProperty(scriptable, "value", obj5);
            this.state = ES6Generator.State.SUSPENDED_YIELD;
            goto label_24;
          }
          catch (NativeGenerator.GeneratorClosedException ex)
          {
          }
        }
        catch (JavaScriptException ex)
        {
          javaScriptException1 = (JavaScriptException) ByteCodeHelper.MapException<JavaScriptException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_22;
        }
      }
      catch (RhinoException ex)
      {
        rhinoException1 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_23;
      }
      __fault
      {
        if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
        {
          this.delegee = (object) null;
          ScriptableObject.putProperty(scriptable, "done", (object) Boolean.valueOf(true));
        }
      }
      // ISSUE: fault handler
      try
      {
        this.state = ES6Generator.State.COMPLETED;
      }
      __fault
      {
        if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
        {
          this.delegee = (object) null;
          ScriptableObject.putProperty(scriptable, "done", (object) Boolean.valueOf(true));
        }
      }
      if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
      {
        this.delegee = (object) null;
        ScriptableObject.putProperty(scriptable, "done", (object) Boolean.valueOf(true));
        goto label_46;
      }
      else
        goto label_46;
label_22:
      JavaScriptException javaScriptException2 = javaScriptException1;
      // ISSUE: fault handler
      try
      {
        JavaScriptException javaScriptException3 = javaScriptException2;
        this.state = ES6Generator.State.COMPLETED;
        if (javaScriptException3.getValue() is NativeIterator.StopIteration)
        {
          ScriptableObject.putProperty(scriptable, "value", ((NativeIterator.StopIteration) javaScriptException3.getValue()).getValue());
        }
        else
        {
          this.lineNumber = javaScriptException3.lineNumber();
          this.lineSource = javaScriptException3.lineSource();
          if (javaScriptException3.getValue() is RhinoException)
            throw Throwable.__\u003Cunmap\u003E((Exception) javaScriptException3.getValue());
          throw Throwable.__\u003Cunmap\u003E((Exception) javaScriptException3);
        }
      }
      __fault
      {
        if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
        {
          this.delegee = (object) null;
          ScriptableObject.putProperty(scriptable, "done", (object) Boolean.valueOf(true));
        }
      }
      if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
      {
        this.delegee = (object) null;
        ScriptableObject.putProperty(scriptable, "done", (object) Boolean.valueOf(true));
        goto label_46;
      }
      else
        goto label_46;
label_23:
      RhinoException rhinoException2 = rhinoException1;
      // ISSUE: fault handler
      try
      {
        RhinoException rhinoException3 = rhinoException2;
        this.state = ES6Generator.State.COMPLETED;
        this.lineNumber = rhinoException3.lineNumber();
        this.lineSource = rhinoException3.lineSource();
        throw Throwable.__\u003Cunmap\u003E((Exception) rhinoException3);
      }
      __fault
      {
        if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
        {
          this.delegee = (object) null;
          ScriptableObject.putProperty(scriptable, "done", (object) Boolean.valueOf(true));
        }
      }
label_24:
      if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
      {
        this.delegee = (object) null;
        ScriptableObject.putProperty(scriptable, "done", (object) Boolean.valueOf(true));
      }
label_46:
      return scriptable;
    }

    [LineNumberTable(new byte[] {160, 76, 106, 99, 137, 135, 108, 37, 200, 233, 69, 103, 159, 5, 161, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Scriptable resumeDelegeeReturn([In] Context obj0, [In] Scriptable obj1, [In] object obj2)
    {
      Scriptable scriptable;
      RhinoException rhinoException1;
      try
      {
        object result = this.callReturnOptionally(obj0, obj1, obj2);
        if (result != null)
        {
          if (!ScriptRuntime.isIteratorDone(obj0, result))
            return ScriptableObject.ensureScriptable(result);
          this.delegee = (object) null;
          return this.resumeAbruptLocal(obj0, obj1, 2, ScriptRuntime.getObjectPropNoWarn(result, "value", obj0, obj1));
        }
        this.delegee = (object) null;
        scriptable = this.resumeAbruptLocal(obj0, obj1, 2, obj2);
      }
      catch (RhinoException ex)
      {
        rhinoException1 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_7;
      }
      return scriptable;
label_7:
      RhinoException rhinoException2 = rhinoException1;
      this.delegee = (object) null;
      return this.resumeAbruptLocal(obj0, obj1, 1, (object) rhinoException2);
    }

    [LineNumberTable(new byte[] {160, 103, 114, 137, 114, 176, 105, 171, 182, 136, 107, 135, 255, 3, 69, 252, 102, 114, 147, 139, 255, 19, 17, 130, 255, 8, 104, 114, 147, 139, 247, 59, 114, 147, 235, 21, 227, 72, 255, 20, 96, 114, 147, 139, 254, 29, 107, 250, 93, 114, 147, 139, 255, 11, 29, 109, 254, 93, 114, 147, 139, 245, 31, 106, 139, 254, 89, 114, 147, 139, 247, 59, 114, 147, 235, 36, 163, 255, 7, 86, 114, 147, 139, 244, 59, 114, 150, 139, 233, 39, 97, 239, 83, 114, 147, 139, 227, 59, 114, 150, 139, 233, 41, 98, 107, 110, 104, 47, 167, 109, 109, 110, 146, 234, 71, 114, 147, 139, 227, 59, 114, 150, 139, 230, 54, 98, 109, 109, 136, 114, 147, 139, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Scriptable resumeLocal([In] Context obj0, [In] Scriptable obj1, [In] object obj2)
    {
      if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
        return ES6Iterator.makeIteratorResult(obj0, obj1, true);
      if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.EXECUTING))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.generator.executing"));
      Scriptable scriptable1 = ES6Iterator.makeIteratorResult(obj0, obj1, false);
      this.state = ES6Generator.State.EXECUTING;
      object obj;
      RhinoException rhinoException1;
      JavaScriptException javaScriptException1;
      RhinoException rhinoException2;
      // ISSUE: fault handler
      try
      {
        try
        {
          try
          {
            obj = this.function.resumeGenerator(obj0, obj1, 0, this.savedState, obj2);
            if (obj is ES6Generator.YieldStarResult)
            {
              this.state = ES6Generator.State.SUSPENDED_YIELD;
              ES6Generator.YieldStarResult yieldStarResult = (ES6Generator.YieldStarResult) obj;
              try
              {
                this.delegee = ScriptRuntime.callIterator(yieldStarResult.getResult(), obj0, obj1);
                goto label_38;
              }
              catch (RhinoException ex)
              {
                rhinoException1 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
              }
            }
            else
              goto label_93;
          }
          catch (NativeGenerator.GeneratorClosedException ex)
          {
            goto label_17;
          }
        }
        catch (JavaScriptException ex)
        {
          javaScriptException1 = (JavaScriptException) ByteCodeHelper.MapException<JavaScriptException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_18;
        }
      }
      catch (RhinoException ex)
      {
        rhinoException2 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_19;
      }
      __fault
      {
        if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
          ScriptableObject.putProperty(scriptable1, "done", (object) Boolean.valueOf(true));
        else
          this.state = ES6Generator.State.SUSPENDED_YIELD;
      }
      RhinoException rhinoException3 = rhinoException1;
      RhinoException rhinoException4;
      Scriptable scriptable2;
      JavaScriptException javaScriptException2;
      // ISSUE: fault handler
      try
      {
        RhinoException rhinoException5 = rhinoException3;
        try
        {
          RhinoException rhinoException6 = rhinoException5;
          try
          {
            rhinoException4 = rhinoException6;
            try
            {
              RhinoException rhinoException7 = rhinoException4;
              scriptable2 = this.resumeAbruptLocal(obj0, obj1, 1, (object) rhinoException7);
              goto label_34;
            }
            catch (NativeGenerator.GeneratorClosedException ex)
            {
            }
          }
          catch (JavaScriptException ex)
          {
            javaScriptException2 = (JavaScriptException) ByteCodeHelper.MapException<JavaScriptException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            goto label_32;
          }
        }
        catch (RhinoException ex)
        {
          rhinoException4 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_33;
        }
      }
      __fault
      {
        if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
          ScriptableObject.putProperty(scriptable1, "done", (object) Boolean.valueOf(true));
        else
          this.state = ES6Generator.State.SUSPENDED_YIELD;
      }
      // ISSUE: variable of the null type
      __Null local = null;
      goto label_107;
label_32:
      JavaScriptException javaScriptException3 = javaScriptException2;
      goto label_116;
label_33:
      RhinoException rhinoException8 = rhinoException4;
      goto label_129;
label_34:
      if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
        ScriptableObject.putProperty(scriptable1, "done", (object) Boolean.valueOf(true));
      else
        this.state = ES6Generator.State.SUSPENDED_YIELD;
      return scriptable2;
label_17:
      local = null;
      goto label_107;
label_18:
      javaScriptException3 = javaScriptException1;
      goto label_116;
label_19:
      rhinoException8 = rhinoException2;
      goto label_129;
label_38:
      Scriptable scriptable3;
      Exception exception1;
      JavaScriptException javaScriptException4;
      RhinoException rhinoException9;
      // ISSUE: fault handler
      try
      {
        try
        {
          try
          {
            try
            {
              scriptable3 = this.resumeDelegee(obj0, obj1, Undefined.__\u003C\u003Einstance);
              goto label_51;
            }
            catch (Exception ex)
            {
              exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
          }
          catch (NativeGenerator.GeneratorClosedException ex)
          {
            goto label_48;
          }
        }
        catch (JavaScriptException ex)
        {
          javaScriptException4 = (JavaScriptException) ByteCodeHelper.MapException<JavaScriptException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_49;
        }
      }
      catch (RhinoException ex)
      {
        rhinoException9 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_50;
      }
      __fault
      {
        if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
          ScriptableObject.putProperty(scriptable1, "done", (object) Boolean.valueOf(true));
        else
          this.state = ES6Generator.State.SUSPENDED_YIELD;
      }
      Exception exception2 = exception1;
      JavaScriptException javaScriptException5;
      RhinoException rhinoException10;
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
            try
            {
              Exception exception6 = exception5;
              this.state = ES6Generator.State.EXECUTING;
              throw Throwable.__\u003Cunmap\u003E(exception6);
            }
            catch (NativeGenerator.GeneratorClosedException ex)
            {
            }
          }
          catch (JavaScriptException ex)
          {
            javaScriptException5 = (JavaScriptException) ByteCodeHelper.MapException<JavaScriptException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            goto label_74;
          }
        }
        catch (RhinoException ex)
        {
          rhinoException10 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_75;
        }
      }
      __fault
      {
        if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
          ScriptableObject.putProperty(scriptable1, "done", (object) Boolean.valueOf(true));
        else
          this.state = ES6Generator.State.SUSPENDED_YIELD;
      }
      local = null;
      goto label_107;
label_74:
      javaScriptException3 = javaScriptException5;
      goto label_116;
label_75:
      rhinoException8 = rhinoException10;
      goto label_129;
label_48:
      local = null;
      goto label_107;
label_49:
      javaScriptException3 = javaScriptException4;
      goto label_116;
label_50:
      rhinoException8 = rhinoException9;
      goto label_129;
label_51:
      JavaScriptException javaScriptException6;
      RhinoException rhinoException11;
      // ISSUE: fault handler
      try
      {
        try
        {
          try
          {
            this.state = ES6Generator.State.EXECUTING;
            goto label_76;
          }
          catch (NativeGenerator.GeneratorClosedException ex)
          {
          }
        }
        catch (JavaScriptException ex)
        {
          javaScriptException6 = (JavaScriptException) ByteCodeHelper.MapException<JavaScriptException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_60;
        }
      }
      catch (RhinoException ex)
      {
        rhinoException11 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_61;
      }
      __fault
      {
        if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
          ScriptableObject.putProperty(scriptable1, "done", (object) Boolean.valueOf(true));
        else
          this.state = ES6Generator.State.SUSPENDED_YIELD;
      }
      local = null;
      goto label_107;
label_60:
      javaScriptException3 = javaScriptException6;
      goto label_116;
label_61:
      rhinoException8 = rhinoException11;
      goto label_129;
label_76:
      Scriptable scriptable4;
      JavaScriptException javaScriptException7;
      RhinoException rhinoException12;
      // ISSUE: fault handler
      try
      {
        try
        {
          try
          {
            if (ScriptRuntime.isIteratorDone(obj0, (object) scriptable3))
              this.state = ES6Generator.State.COMPLETED;
            scriptable4 = scriptable3;
            goto label_89;
          }
          catch (NativeGenerator.GeneratorClosedException ex)
          {
          }
        }
        catch (JavaScriptException ex)
        {
          javaScriptException7 = (JavaScriptException) ByteCodeHelper.MapException<JavaScriptException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_87;
        }
      }
      catch (RhinoException ex)
      {
        rhinoException12 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_88;
      }
      __fault
      {
        if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
          ScriptableObject.putProperty(scriptable1, "done", (object) Boolean.valueOf(true));
        else
          this.state = ES6Generator.State.SUSPENDED_YIELD;
      }
      local = null;
      goto label_107;
label_87:
      javaScriptException3 = javaScriptException7;
      goto label_116;
label_88:
      rhinoException8 = rhinoException12;
      goto label_129;
label_89:
      if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
        ScriptableObject.putProperty(scriptable1, "done", (object) Boolean.valueOf(true));
      else
        this.state = ES6Generator.State.SUSPENDED_YIELD;
      return scriptable4;
label_93:
      JavaScriptException javaScriptException8;
      RhinoException rhinoException13;
      // ISSUE: fault handler
      try
      {
        try
        {
          try
          {
            ScriptableObject.putProperty(scriptable1, "value", obj);
            goto label_104;
          }
          catch (NativeGenerator.GeneratorClosedException ex)
          {
          }
        }
        catch (JavaScriptException ex)
        {
          javaScriptException8 = (JavaScriptException) ByteCodeHelper.MapException<JavaScriptException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_102;
        }
      }
      catch (RhinoException ex)
      {
        rhinoException13 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_103;
      }
      __fault
      {
        if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
          ScriptableObject.putProperty(scriptable1, "done", (object) Boolean.valueOf(true));
        else
          this.state = ES6Generator.State.SUSPENDED_YIELD;
      }
      local = null;
      goto label_107;
label_102:
      javaScriptException3 = javaScriptException8;
      goto label_116;
label_103:
      rhinoException8 = rhinoException13;
      goto label_129;
label_104:
      if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
      {
        ScriptableObject.putProperty(scriptable1, "done", (object) Boolean.valueOf(true));
        goto label_135;
      }
      else
      {
        this.state = ES6Generator.State.SUSPENDED_YIELD;
        goto label_135;
      }
label_107:
      // ISSUE: fault handler
      try
      {
        this.state = ES6Generator.State.COMPLETED;
      }
      __fault
      {
        if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
          ScriptableObject.putProperty(scriptable1, "done", (object) Boolean.valueOf(true));
        else
          this.state = ES6Generator.State.SUSPENDED_YIELD;
      }
      if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
      {
        ScriptableObject.putProperty(scriptable1, "done", (object) Boolean.valueOf(true));
        goto label_135;
      }
      else
      {
        this.state = ES6Generator.State.SUSPENDED_YIELD;
        goto label_135;
      }
label_116:
      JavaScriptException javaScriptException9 = javaScriptException3;
      // ISSUE: fault handler
      try
      {
        JavaScriptException javaScriptException10 = javaScriptException9;
        this.state = ES6Generator.State.COMPLETED;
        if (javaScriptException10.getValue() is NativeIterator.StopIteration)
        {
          ScriptableObject.putProperty(scriptable1, "value", ((NativeIterator.StopIteration) javaScriptException10.getValue()).getValue());
        }
        else
        {
          this.lineNumber = javaScriptException10.lineNumber();
          this.lineSource = javaScriptException10.lineSource();
          if (javaScriptException10.getValue() is RhinoException)
            throw Throwable.__\u003Cunmap\u003E((Exception) javaScriptException10.getValue());
          throw Throwable.__\u003Cunmap\u003E((Exception) javaScriptException10);
        }
      }
      __fault
      {
        if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
          ScriptableObject.putProperty(scriptable1, "done", (object) Boolean.valueOf(true));
        else
          this.state = ES6Generator.State.SUSPENDED_YIELD;
      }
      if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
      {
        ScriptableObject.putProperty(scriptable1, "done", (object) Boolean.valueOf(true));
        goto label_135;
      }
      else
      {
        this.state = ES6Generator.State.SUSPENDED_YIELD;
        goto label_135;
      }
label_129:
      RhinoException rhinoException14 = rhinoException8;
      // ISSUE: fault handler
      try
      {
        RhinoException rhinoException5 = rhinoException14;
        this.lineNumber = rhinoException5.lineNumber();
        this.lineSource = rhinoException5.lineSource();
        throw Throwable.__\u003Cunmap\u003E((Exception) rhinoException5);
      }
      __fault
      {
        if (object.ReferenceEquals((object) this.state, (object) ES6Generator.State.COMPLETED))
          ScriptableObject.putProperty(scriptable1, "done", (object) Boolean.valueOf(true));
        else
          this.state = ES6Generator.State.SUSPENDED_YIELD;
      }
label_135:
      return scriptable1;
    }

    [LineNumberTable(new byte[] {73, 159, 0, 115, 103, 139, 104, 138, 135, 184, 159, 1, 162, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Scriptable resumeDelegee([In] Context obj0, [In] Scriptable obj1, [In] object obj2)
    {
      Scriptable scriptable1;
      RhinoException rhinoException1;
      try
      {
        object[] objArray;
        if (Object.instancehelper_equals(Undefined.__\u003C\u003Einstance, obj2))
          objArray = ScriptRuntime.__\u003C\u003EemptyArgs;
        else
          objArray = new object[1]{ obj2 };
        object[] objarr = objArray;
        Callable propFunctionAndThis = ScriptRuntime.getPropFunctionAndThis(this.delegee, "next", obj0, obj1);
        Scriptable s2 = ScriptRuntime.lastStoredScriptable(obj0);
        Scriptable scriptable2 = ScriptableObject.ensureScriptable(propFunctionAndThis.call(obj0, obj1, s2, objarr));
        if (ScriptRuntime.isIteratorDone(obj0, (object) scriptable2))
        {
          this.delegee = (object) null;
          return this.resumeLocal(obj0, obj1, ScriptableObject.getProperty(scriptable2, "value"));
        }
        scriptable1 = scriptable2;
      }
      catch (RhinoException ex)
      {
        rhinoException1 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_8;
      }
      return scriptable1;
label_8:
      RhinoException rhinoException2 = rhinoException1;
      this.delegee = (object) null;
      return this.resumeAbruptLocal(obj0, obj1, 1, (object) rhinoException2);
    }

    [LineNumberTable(new byte[] {98, 162, 115, 103, 148, 201, 98, 158, 103, 63, 7, 105, 118, 107, 37, 218, 159, 2, 162, 131, 190, 164, 103, 235, 58, 98, 209, 103, 35, 226, 60, 195, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Scriptable resumeDelegeeThrow([In] Context obj0, [In] Scriptable obj1, [In] object obj2)
    {
      int num = 0;
      object result;
      Exception exception1;
      RhinoException rhinoException1;
      try
      {
        Callable propFunctionAndThis = ScriptRuntime.getPropFunctionAndThis(this.delegee, "throw", obj0, obj1);
        Scriptable s2 = ScriptRuntime.lastStoredScriptable(obj0);
        result = propFunctionAndThis.call(obj0, obj1, s2, new object[1]
        {
          obj2
        });
        if (ScriptRuntime.isIteratorDone(obj0, result))
        {
          try
          {
            num = 1;
            this.callReturnOptionally(obj0, obj1, Undefined.__\u003C\u003Einstance);
          }
          catch (Exception ex)
          {
            exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            goto label_6;
          }
          this.delegee = (object) null;
          goto label_11;
        }
        else
          goto label_14;
      }
      catch (RhinoException ex)
      {
        rhinoException1 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_7;
      }
label_6:
      Exception exception2 = exception1;
      RhinoException rhinoException2;
      try
      {
        Exception exception3 = exception2;
        this.delegee = (object) null;
        throw Throwable.__\u003Cunmap\u003E(exception3);
      }
      catch (RhinoException ex)
      {
        rhinoException2 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      RhinoException rhinoException3 = rhinoException2;
      goto label_18;
label_7:
      rhinoException3 = rhinoException1;
      goto label_18;
label_11:
      RhinoException rhinoException4;
      try
      {
        return this.resumeLocal(obj0, obj1, ScriptRuntime.getObjectProp(result, "value", obj0, obj1));
      }
      catch (RhinoException ex)
      {
        rhinoException4 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      rhinoException3 = rhinoException4;
      goto label_18;
label_14:
      Scriptable scriptable;
      RhinoException rhinoException5;
      try
      {
        scriptable = ScriptableObject.ensureScriptable(result);
      }
      catch (RhinoException ex)
      {
        rhinoException5 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_17;
      }
      return scriptable;
label_17:
      rhinoException3 = rhinoException5;
label_18:
      RhinoException rhinoException6 = rhinoException3;
      RhinoException rhinoException7;
      // ISSUE: fault handler
      try
      {
        if (num == 0)
        {
          try
          {
            this.callReturnOptionally(obj0, obj1, Undefined.__\u003C\u003Einstance);
            goto label_26;
          }
          catch (RhinoException ex)
          {
            rhinoException7 = (RhinoException) ByteCodeHelper.MapException<RhinoException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
        }
        else
          goto label_26;
      }
      __fault
      {
        this.delegee = (object) null;
      }
      RhinoException rhinoException8 = rhinoException7;
      try
      {
        RhinoException rhinoException9 = rhinoException8;
        return this.resumeAbruptLocal(obj0, obj1, 1, (object) rhinoException9);
      }
      finally
      {
        this.delegee = (object) null;
      }
label_26:
      this.delegee = (object) null;
      return this.resumeAbruptLocal(obj0, obj1, 1, (object) rhinoException6);
    }

    [LineNumberTable(new byte[] {160, 245, 191, 0, 147, 109, 104, 107, 37, 171, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object callReturnOptionally([In] Context obj0, [In] Scriptable obj1, [In] object obj2)
    {
      object[] objArray;
      if (Object.instancehelper_equals(Undefined.__\u003C\u003Einstance, obj2))
        objArray = ScriptRuntime.__\u003C\u003EemptyArgs;
      else
        objArray = new object[1]{ obj2 };
      object[] objarr = objArray;
      object objectPropNoWarn = ScriptRuntime.getObjectPropNoWarn(this.delegee, "return", obj0, obj1);
      if (Object.instancehelper_equals(Undefined.__\u003C\u003Einstance, objectPropNoWarn))
        return (object) null;
      if (!(objectPropNoWarn is Callable))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError2("msg.isnt.function", (object) "return", (object) ScriptRuntime.@typeof(objectPropNoWarn)));
      return ((Callable) objectPropNoWarn).call(obj0, obj1, ScriptableObject.ensureScriptable(this.delegee), objarr);
    }

    [LineNumberTable(new byte[] {159, 140, 66, 102, 99, 103, 140, 103, 99, 230, 71, 99, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static ES6Generator init([In] ScriptableObject obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      ES6Generator es6Generator = new ES6Generator();
      if (obj0 != null)
      {
        es6Generator.setParentScope((Scriptable) obj0);
        es6Generator.setPrototype(ScriptableObject.getObjectPrototype((Scriptable) obj0));
      }
      es6Generator.activatePrototypeMap(4);
      if (num != 0)
        es6Generator.sealObject();
      obj0?.associateValue(ES6Generator.GENERATOR_TAG, (object) es6Generator);
      return es6Generator;
    }

    [LineNumberTable(new byte[] {159, 178, 232, 161, 130, 235, 158, 127, 103, 199, 103, 103, 102, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ES6Generator(Scriptable scope, NativeFunction function, object savedState)
    {
      ES6Generator es6Generator = this;
      this.state = ES6Generator.State.SUSPENDED_START;
      this.function = function;
      this.savedState = savedState;
      Scriptable topLevelScope = ScriptableObject.getTopLevelScope(scope);
      this.setParentScope(topLevelScope);
      this.setPrototype((Scriptable) ScriptableObject.getTopScopeValue(topLevelScope, ES6Generator.GENERATOR_TAG));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Generator";

    [LineNumberTable(new byte[] {6, 100, 120, 225, 69, 150, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      int arity;
      string name;
      switch (id)
      {
        case 1:
          arity = 1;
          name = "next";
          break;
        case 2:
          arity = 1;
          name = "return";
          break;
        case 3:
          arity = 1;
          name = "throw";
          break;
        case 4:
          this.initPrototypeMethod(ES6Generator.GENERATOR_TAG, id, (Symbol) SymbolKey.__\u003C\u003EITERATOR, "[Symbol.iterator]", 0);
          return;
        default:
          string str = String.valueOf(id);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.initPrototypeMethod(ES6Generator.GENERATOR_TAG, id, name, arity);
    }

    [LineNumberTable(new byte[] {35, 109, 142, 135, 105, 172, 104, 146, 157, 104, 139, 138, 104, 138, 138, 104, 139, 138, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag(ES6Generator.GENERATOR_TAG))
        return base.execIdCall(f, cx, scope, thisObj, args);
      int num = f.methodId();
      ES6Generator es6Generator = thisObj is ES6Generator ? (ES6Generator) thisObj : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(f));
      object obj = args.Length < 1 ? Undefined.__\u003C\u003Einstance : args[0];
      switch (num)
      {
        case 1:
          return es6Generator.delegee == null ? (object) es6Generator.resumeLocal(cx, scope, obj) : (object) es6Generator.resumeDelegee(cx, scope, obj);
        case 2:
          return es6Generator.delegee == null ? (object) es6Generator.resumeAbruptLocal(cx, scope, 2, obj) : (object) es6Generator.resumeDelegeeReturn(cx, scope, obj);
        case 3:
          return es6Generator.delegee == null ? (object) es6Generator.resumeAbruptLocal(cx, scope, 1, obj) : (object) es6Generator.resumeDelegeeThrow(cx, scope, obj);
        case 4:
          return (object) thisObj;
        default:
          string str = String.valueOf(num);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {161, 6, 109, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(Symbol k) => SymbolKey.__\u003C\u003EITERATOR.equals((object) k) ? 4 : 0;

    [LineNumberTable(new byte[] {161, 20, 98, 98, 103, 100, 102, 100, 100, 102, 100, 100, 102, 130, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 4:
          str = "next";
          num = 1;
          break;
        case 5:
          str = "throw";
          num = 3;
          break;
        case 6:
          str = "return";
          num = 2;
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
        num = 0;
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static ES6Generator()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.ES6Generator"))
        return;
      ES6Generator.GENERATOR_TAG = (object) "Generator";
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lrhino/ES6Generator$State;>;")]
    [Modifiers]
    [Serializable]
    internal sealed class State : Enum
    {
      [Modifiers]
      public static ES6Generator.State SUSPENDED_START;
      [Modifiers]
      public static ES6Generator.State SUSPENDED_YIELD;
      [Modifiers]
      public static ES6Generator.State EXECUTING;
      [Modifiers]
      public static ES6Generator.State COMPLETED;
      [Modifiers]
      private static ES6Generator.State[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(425)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private State([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(425)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static ES6Generator.State[] values() => (ES6Generator.State[]) ES6Generator.State.\u0024VALUES.Clone();

      [LineNumberTable(425)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static ES6Generator.State valueOf([In] string obj0) => (ES6Generator.State) Enum.valueOf((Class) ClassLiteral<ES6Generator.State>.Value, obj0);

      [LineNumberTable(425)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static State()
      {
        if (ByteCodeHelper.isAlreadyInited("rhino.ES6Generator$State"))
          return;
        ES6Generator.State.SUSPENDED_START = new ES6Generator.State(nameof (SUSPENDED_START), 0);
        ES6Generator.State.SUSPENDED_YIELD = new ES6Generator.State(nameof (SUSPENDED_YIELD), 1);
        ES6Generator.State.EXECUTING = new ES6Generator.State(nameof (EXECUTING), 2);
        ES6Generator.State.COMPLETED = new ES6Generator.State(nameof (COMPLETED), 3);
        ES6Generator.State.\u0024VALUES = new ES6Generator.State[4]
        {
          ES6Generator.State.SUSPENDED_START,
          ES6Generator.State.SUSPENDED_YIELD,
          ES6Generator.State.EXECUTING,
          ES6Generator.State.COMPLETED
        };
      }
    }

    public sealed class YieldStarResult : Object
    {
      [Modifiers]
      private object result;

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual object getResult() => this.result;

      [LineNumberTable(new byte[] {161, 60, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public YieldStarResult(object result)
      {
        ES6Generator.YieldStarResult yieldStarResult = this;
        this.result = result;
      }
    }
  }
}
