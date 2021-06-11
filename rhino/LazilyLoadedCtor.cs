// Decompiled with JetBrains decompiler
// Type: rhino.LazilyLoadedCtor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using java.security;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace rhino
{
  public sealed class LazilyLoadedCtor : Object
  {
    private const int STATE_BEFORE_INIT = 0;
    private const int STATE_INITIALIZING = 1;
    private const int STATE_WITH_VALUE = 2;
    [Modifiers]
    private ScriptableObject scope;
    [Modifiers]
    private string propertyName;
    [Modifiers]
    private string className;
    [Modifiers]
    private bool @sealed;
    [Modifiers]
    private bool privileged;
    private object initializedValue;
    private int state;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [LineNumberTable(new byte[] {159, 186, 104, 105, 159, 11, 104, 167, 134, 150, 103, 103, 18, 105, 103, 143, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void init()
    {
      LazilyLoadedCtor lazilyLoadedCtor;
      Monitor.Enter((object) (lazilyLoadedCtor = this));
      object obj;
      Exception exception1;
      // ISSUE: fault handler
      try
      {
        if (this.state == 1)
        {
          string str = new StringBuilder().append("Recursive initialization for ").append(this.propertyName).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException(str);
        }
        if (this.state == 0)
        {
          this.state = 1;
          obj = Scriptable.NOT_FOUND;
          try
          {
            obj = this.buildValue();
          }
          catch (Exception ex)
          {
            exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            goto label_9;
          }
          this.initializedValue = obj;
          this.state = 2;
          goto label_12;
        }
        else
          goto label_12;
      }
      __fault
      {
        Monitor.Exit((object) lazilyLoadedCtor);
      }
label_9:
      Exception exception2 = exception1;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception2;
        this.initializedValue = obj;
        this.state = 2;
        throw Throwable.__\u003Cunmap\u003E(exception3);
      }
      __fault
      {
        Monitor.Exit((object) lazilyLoadedCtor);
      }
label_12:
      // ISSUE: fault handler
      try
      {
        Monitor.Exit((object) lazilyLoadedCtor);
      }
      __fault
      {
        Monitor.Exit((object) lazilyLoadedCtor);
      }
    }

    [LineNumberTable(new byte[] {14, 105, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object getValue()
    {
      if (this.state != 2)
      {
        string propertyName = this.propertyName;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException(propertyName);
      }
      return this.initializedValue;
    }

    [LineNumberTable(new byte[] {159, 135, 134, 136, 103, 103, 103, 103, 103, 135, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal LazilyLoadedCtor(
      [In] ScriptableObject obj0,
      [In] string obj1,
      [In] string obj2,
      [In] bool obj3,
      [In] bool obj4)
    {
      int num1 = obj3 ? 1 : 0;
      int num2 = obj4 ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      LazilyLoadedCtor lazilyLoadedCtor = this;
      this.scope = obj0;
      this.propertyName = obj1;
      this.className = obj2;
      this.@sealed = num1 != 0;
      this.privileged = num2 != 0;
      this.state = 0;
      obj0.addLazilyInitializedValue(obj1, 0, this, 2);
    }

    [LineNumberTable(new byte[] {20, 104, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object buildValue() => this.privileged ? AccessController.doPrivileged((PrivilegedAction) new LazilyLoadedCtor.__\u003C\u003EAnon0(this), LazilyLoadedCtor.__\u003CGetCallerID\u003E()) : this.buildValue0();

    [LineNumberTable(new byte[] {27, 114, 134, 148, 99, 223, 31, 121, 110, 255, 22, 71, 226, 58, 98, 105, 105, 173, 34, 161})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object buildValue0()
    {
      Class @class = this.cast(Kit.classOrNull(this.className));
      if (@class != null)
      {
        BaseFunction baseFunction1;
        InvocationTargetException invocationTargetException1;
        try
        {
          try
          {
            try
            {
              try
              {
                try
                {
                  BaseFunction baseFunction2 = ScriptableObject.buildClassCtor((Scriptable) this.scope, @class, this.@sealed, false);
                  if (baseFunction2 != null)
                    baseFunction1 = baseFunction2;
                  else
                    goto label_14;
                }
                catch (InvocationTargetException ex)
                {
                  invocationTargetException1 = (InvocationTargetException) ByteCodeHelper.MapException<InvocationTargetException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
                  goto label_9;
                }
              }
              catch (RhinoException ex)
              {
                goto label_10;
              }
            }
            catch (SecurityException ex)
            {
              goto label_11;
            }
          }
          catch (IllegalAccessException ex)
          {
            goto label_12;
          }
        }
        catch (InstantiationException ex)
        {
          goto label_13;
        }
        return (object) baseFunction1;
label_9:
        InvocationTargetException invocationTargetException2 = invocationTargetException1;
        goto label_27;
label_10:
        // ISSUE: variable of the null type
        __Null local = null;
        goto label_29;
label_11:
        local = null;
        goto label_29;
label_12:
        local = null;
        goto label_29;
label_13:
        local = null;
        goto label_29;
label_14:
        object obj;
        InvocationTargetException invocationTargetException3;
        try
        {
          try
          {
            try
            {
              try
              {
                try
                {
                  object objA = this.scope.get(this.propertyName, (Scriptable) this.scope);
                  if (!object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
                    obj = objA;
                  else
                    goto label_30;
                }
                catch (InvocationTargetException ex)
                {
                  invocationTargetException3 = (InvocationTargetException) ByteCodeHelper.MapException<InvocationTargetException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
                  goto label_22;
                }
              }
              catch (RhinoException ex)
              {
                goto label_23;
              }
            }
            catch (SecurityException ex)
            {
              goto label_24;
            }
          }
          catch (IllegalAccessException ex)
          {
            goto label_25;
          }
        }
        catch (InstantiationException ex)
        {
          goto label_26;
        }
        return obj;
label_22:
        invocationTargetException2 = invocationTargetException3;
        goto label_27;
label_23:
        local = null;
        goto label_29;
label_24:
        local = null;
        goto label_29;
label_25:
        local = null;
        goto label_29;
label_26:
        local = null;
        goto label_29;
label_27:
        Exception targetException = invocationTargetException2.getTargetException();
        if (targetException is RuntimeException)
          throw Throwable.__\u003Cunmap\u003E(targetException);
        goto label_30;
label_29:;
      }
label_30:
      return Scriptable.NOT_FOUND;
    }

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Class<+Lrhino/Scriptable;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Class cast([In] Class obj0) => obj0;

    [Modifiers]
    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object lambda\u0024buildValue\u00240() => this.buildValue0();

    [LineNumberTable(new byte[] {159, 136, 131, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LazilyLoadedCtor(
      ScriptableObject scope,
      string propertyName,
      string className,
      bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(scope, propertyName, className, num != 0, false);
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (LazilyLoadedCtor.__\u003CcallerID\u003E == null)
        LazilyLoadedCtor.__\u003CcallerID\u003E = (CallerID) new LazilyLoadedCtor.__\u003CCallerID\u003E();
      return LazilyLoadedCtor.__\u003CcallerID\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : PrivilegedAction
    {
      private readonly LazilyLoadedCtor arg\u00241;

      internal __\u003C\u003EAnon0([In] LazilyLoadedCtor obj0) => this.arg\u00241 = obj0;

      public object run() => this.arg\u00241.lambda\u0024buildValue\u00240();
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
