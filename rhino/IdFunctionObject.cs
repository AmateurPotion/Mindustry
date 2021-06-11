// Decompiled with JetBrains decompiler
// Type: rhino.IdFunctionObject
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class IdFunctionObject : BaseFunction
  {
    [Modifiers]
    private IdFunctionCall idcall;
    [Modifiers]
    private object tag;
    [Modifiers]
    private int methodId;
    [Modifiers]
    private int arity;
    private bool useCallAsConstructor;
    private string functionName;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(135)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RuntimeException unknown() => (RuntimeException) new IllegalArgumentException(new StringBuilder().append("BAD FUNCTION ID=").append(this.methodId).append(" MASTER=").append((object) this.idcall).toString());

    [LineNumberTable(new byte[] {13, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void exportAsScopeProperty() => this.addAsProperty(this.getParentScope());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int methodId() => this.methodId;

    [LineNumberTable(new byte[] {8, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void addAsProperty(Scriptable target) => ScriptableObject.defineProperty(target, this.functionName, (object) this, 2);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getFunctionName() => this.functionName == null ? "" : this.functionName;

    [LineNumberTable(new byte[] {159, 161, 139, 101, 107, 100, 139, 103, 103, 103, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IdFunctionObject(
      IdFunctionCall idcall,
      object tag,
      int id,
      string name,
      int arity,
      Scriptable scope)
      : base(scope, (Scriptable) null)
    {
      IdFunctionObject idFunctionObject = this;
      if (arity < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (name == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      this.idcall = idcall;
      this.tag = tag;
      this.methodId = id;
      this.arity = arity;
      this.functionName = name;
    }

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool hasTag(object tag)
    {
      if (tag != null)
        return Object.instancehelper_equals(tag, this.tag);
      return this.tag == null;
    }

    [LineNumberTable(140)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool equalObjectGraphs(
      [In] IdFunctionObject obj0,
      [In] IdFunctionObject obj1,
      [In] EqualObjectGraphs obj2)
    {
      return obj0.methodId == obj1.methodId && obj0.hasTag(obj1.tag) && obj2.equalGraphs((object) obj0.idcall, (object) obj1.idcall);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getArity() => this.arity;

    [LineNumberTable(new byte[] {159, 149, 104, 101, 139, 103, 103, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IdFunctionObject(IdFunctionCall idcall, object tag, int id, int arity)
    {
      IdFunctionObject idFunctionObject = this;
      if (arity < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      this.idcall = idcall;
      this.tag = tag;
      this.methodId = id;
      this.arity = arity;
    }

    [LineNumberTable(new byte[] {159, 176, 110, 110, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void initFunction(string name, Scriptable scope)
    {
      if (name == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (scope == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      this.functionName = name;
      this.setParentScope(scope);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getTag() => this.tag;

    [LineNumberTable(new byte[] {3, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void markAsConstructor(Scriptable prototypeProperty)
    {
      this.useCallAsConstructor = true;
      this.setImmunePrototypeProperty((object) prototypeProperty);
    }

    [LineNumberTable(new byte[] {20, 103, 99, 108, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Scriptable getPrototype()
    {
      Scriptable m = base.getPrototype();
      if (m == null)
      {
        m = ScriptableObject.getFunctionPrototype(this.getParentScope());
        this.setPrototype(m);
      }
      return m;
    }

    [LineNumberTable(81)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object call(Context cx, Scriptable scope, Scriptable thisObj, object[] args) => this.idcall.execIdCall(this, cx, scope, thisObj, args);

    [LineNumberTable(new byte[] {36, 104, 226, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Scriptable createObject(Context cx, Scriptable scope)
    {
      if (this.useCallAsConstructor)
        return (Scriptable) null;
      throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.not.ctor", (object) this.functionName));
    }

    [LineNumberTable(new byte[] {48, 102, 106, 99, 108, 109, 140, 108, 109, 108, 109, 137, 109, 108, 109, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal override string decompile([In] int obj0, [In] int obj1)
    {
      StringBuilder stringBuilder = new StringBuilder();
      int num = 0 != (obj1 & 1) ? 1 : 0;
      if (num == 0)
      {
        stringBuilder.append("function ");
        stringBuilder.append(this.getFunctionName());
        stringBuilder.append("() { ");
      }
      stringBuilder.append("[native code for ");
      if (this.idcall is Scriptable)
      {
        Scriptable idcall = (Scriptable) this.idcall;
        stringBuilder.append(idcall.getClassName());
        stringBuilder.append('.');
      }
      stringBuilder.append(this.getFunctionName());
      stringBuilder.append(", arity=");
      stringBuilder.append(this.getArity());
      stringBuilder.append(num == 0 ? "] }\n" : "]\n");
      return stringBuilder.toString();
    }

    [LineNumberTable(125)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getLength() => this.getArity();

    [HideFromJava]
    static IdFunctionObject() => BaseFunction.__\u003Cclinit\u003E();
  }
}
