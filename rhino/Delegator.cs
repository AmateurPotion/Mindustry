// Decompiled with JetBrains decompiler
// Type: rhino.Delegator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace rhino
{
  [Implements(new string[] {"rhino.Function", "rhino.SymbolScriptable"})]
  public class Delegator : Object, Function, Scriptable, Callable, SymbolScriptable
  {
    protected internal Scriptable obj;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable getDelegee() => this.obj;

    [LineNumberTable(new byte[] {1, 127, 17, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Delegator newInstance()
    {
      Delegator delegator;
      Exception exception;
      try
      {
        delegator = (Delegator) Object.instancehelper_getClass((object) this).newInstance(Delegator.__\u003CGetCallerID\u003E());
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
          goto label_5;
        }
      }
      return delegator;
label_5:
      throw Throwable.__\u003Cunmap\u003E((Exception) Context.throwAsScriptRuntimeEx((Exception) exception));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDelegee(Scriptable obj) => this.obj = obj;

    [LineNumberTable(new byte[] {159, 173, 232, 55, 231, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Delegator()
    {
      Delegator delegator = this;
      this.obj = (Scriptable) null;
    }

    [LineNumberTable(new byte[] {159, 182, 232, 46, 231, 83, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Delegator(Scriptable obj)
    {
      Delegator delegator = this;
      this.obj = (Scriptable) null;
      this.obj = obj;
    }

    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getClassName() => this.getDelegee().getClassName();

    [LineNumberTable(87)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(string name, Scriptable start) => this.getDelegee().get(name, start);

    [LineNumberTable(new byte[] {42, 103, 104, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(Symbol key, Scriptable start)
    {
      Scriptable delegee = this.getDelegee();
      return delegee is SymbolScriptable ? ((SymbolScriptable) delegee).get(key, start) : Scriptable.NOT_FOUND;
    }

    [LineNumberTable(104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(int index, Scriptable start) => this.getDelegee().get(index, start);

    [LineNumberTable(112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(string name, Scriptable start) => this.getDelegee().has(name, start);

    [LineNumberTable(new byte[] {67, 103, 104, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(Symbol key, Scriptable start)
    {
      Scriptable delegee = this.getDelegee();
      return delegee is SymbolScriptable && ((SymbolScriptable) delegee).has(key, start);
    }

    [LineNumberTable(129)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(int index, Scriptable start) => this.getDelegee().has(index, start);

    [LineNumberTable(new byte[] {87, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(string name, Scriptable start, object value) => this.getDelegee().put(name, start, value);

    [LineNumberTable(new byte[] {95, 103, 104, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(Symbol symbol, Scriptable start, object value)
    {
      Scriptable delegee = this.getDelegee();
      if (!(delegee is SymbolScriptable))
        return;
      ((SymbolScriptable) delegee).put(symbol, start, value);
    }

    [LineNumberTable(new byte[] {106, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(int index, Scriptable start, object value) => this.getDelegee().put(index, start, value);

    [LineNumberTable(new byte[] {114, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void delete(string name) => this.getDelegee().delete(name);

    [LineNumberTable(new byte[] {119, 103, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void delete(Symbol key)
    {
      Scriptable delegee = this.getDelegee();
      if (!(delegee is SymbolScriptable))
        return;
      ((SymbolScriptable) delegee).delete(key);
    }

    [LineNumberTable(new byte[] {160, 66, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void delete(int index) => this.getDelegee().delete(index);

    [LineNumberTable(188)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable getPrototype() => this.getDelegee().getPrototype();

    [LineNumberTable(new byte[] {160, 82, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPrototype(Scriptable prototype) => this.getDelegee().setPrototype(prototype);

    [LineNumberTable(204)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable getParentScope() => this.getDelegee().getParentScope();

    [LineNumberTable(new byte[] {160, 98, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setParentScope(Scriptable parent) => this.getDelegee().setParentScope(parent);

    [LineNumberTable(220)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] getIds() => this.getDelegee().getIds();

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {160, 121, 191, 2, 235, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getDefaultValue(Class hint) => hint == null || object.ReferenceEquals((object) hint, (object) ScriptRuntime.__\u003C\u003EScriptableClass) || object.ReferenceEquals((object) hint, (object) ScriptRuntime.__\u003C\u003EFunctionClass) ? (object) this : this.getDelegee().getDefaultValue(hint);

    [LineNumberTable(246)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasInstance(Scriptable instance) => this.getDelegee().hasInstance(instance);

    [LineNumberTable(255)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object call(Context cx, Scriptable scope, Scriptable thisObj, object[] args) => ((Function) this.getDelegee()).call(cx, scope, thisObj, args);

    [LineNumberTable(new byte[] {160, 159, 103, 131, 135, 100, 136, 139, 122, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable construct(Context cx, Scriptable scope, object[] args)
    {
      Scriptable delegee = this.getDelegee();
      if (delegee != null)
        return ((Function) delegee).construct(cx, scope, args);
      Delegator delegator1 = this.newInstance();
      object obj1 = args.Length != 0 ? (object) ScriptRuntime.toObject(cx, scope, args[0]) : (object) new NativeObject();
      Delegator delegator2 = delegator1;
      object obj2 = obj1;
      Scriptable scriptable1;
      if (obj2 != null)
        scriptable1 = obj2 is Scriptable scriptable3 ? scriptable3 : throw new IncompatibleClassChangeError();
      else
        scriptable1 = (Scriptable) null;
      delegator2.setDelegee(scriptable1);
      return (Scriptable) delegator1;
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (Delegator.__\u003CcallerID\u003E == null)
        Delegator.__\u003CcallerID\u003E = (CallerID) new Delegator.__\u003CCallerID\u003E();
      return Delegator.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
