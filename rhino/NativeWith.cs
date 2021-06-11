// Decompiled with JetBrains decompiler
// Type: rhino.NativeWith
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [Implements(new string[] {"rhino.Scriptable", "rhino.SymbolScriptable", "rhino.IdFunctionCall"})]
  public class NativeWith : Object, Scriptable, SymbolScriptable, IdFunctionCall
  {
    [Modifiers]
    private static object FTAG;
    private const int Id_constructor = 1;
    protected internal Scriptable prototype;
    protected internal Scriptable parent;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 167, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeWith()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setParentScope(Scriptable parent) => this.parent = parent;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPrototype(Scriptable prototype) => this.prototype = prototype;

    [LineNumberTable(new byte[] {159, 140, 162, 134, 103, 140, 153, 103, 99, 134, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      NativeWith nativeWith = new NativeWith();
      nativeWith.setParentScope(obj0);
      nativeWith.setPrototype(ScriptableObject.getObjectPrototype(obj0));
      IdFunctionObject.__\u003Cclinit\u003E();
      IdFunctionObject idFunctionObject = new IdFunctionObject((IdFunctionCall) nativeWith, NativeWith.FTAG, 1, "With", 0, obj0);
      idFunctionObject.markAsConstructor((Scriptable) nativeWith);
      if (num != 0)
        idFunctionObject.sealObject();
      idFunctionObject.exportAsScopeProperty();
    }

    [LineNumberTable(new byte[] {159, 170, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal NativeWith(Scriptable parent, Scriptable prototype)
    {
      NativeWith nativeWith = this;
      this.parent = parent;
      this.prototype = prototype;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getClassName() => "With";

    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(string id, Scriptable start) => this.prototype.has(id, this.prototype);

    [LineNumberTable(new byte[] {159, 187, 109, 152})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(Symbol key, Scriptable start) => this.prototype is SymbolScriptable && ((SymbolScriptable) this.prototype).has(key, this.prototype);

    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(int index, Scriptable start) => this.prototype.has(index, this.prototype);

    [LineNumberTable(new byte[] {8, 105, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(string id, Scriptable start)
    {
      if (object.ReferenceEquals((object) start, (object) this))
        start = this.prototype;
      return this.prototype.get(id, start);
    }

    [LineNumberTable(new byte[] {16, 105, 136, 109, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(Symbol key, Scriptable start)
    {
      if (object.ReferenceEquals((object) start, (object) this))
        start = this.prototype;
      return this.prototype is SymbolScriptable ? ((SymbolScriptable) this.prototype).get(key, start) : Scriptable.NOT_FOUND;
    }

    [LineNumberTable(new byte[] {27, 105, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(int index, Scriptable start)
    {
      if (object.ReferenceEquals((object) start, (object) this))
        start = this.prototype;
      return this.prototype.get(index, start);
    }

    [LineNumberTable(new byte[] {35, 105, 104, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(string id, Scriptable start, object value)
    {
      if (object.ReferenceEquals((object) start, (object) this))
        start = this.prototype;
      this.prototype.put(id, start, value);
    }

    [LineNumberTable(new byte[] {42, 105, 136, 109, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(Symbol symbol, Scriptable start, object value)
    {
      if (object.ReferenceEquals((object) start, (object) this))
        start = this.prototype;
      if (!(this.prototype is SymbolScriptable))
        return;
      ((SymbolScriptable) this.prototype).put(symbol, start, value);
    }

    [LineNumberTable(new byte[] {52, 105, 104, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(int index, Scriptable start, object value)
    {
      if (object.ReferenceEquals((object) start, (object) this))
        start = this.prototype;
      this.prototype.put(index, start, value);
    }

    [LineNumberTable(new byte[] {59, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void delete(string id) => this.prototype.delete(id);

    [LineNumberTable(new byte[] {64, 109, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void delete(Symbol key)
    {
      if (!(this.prototype is SymbolScriptable))
        return;
      ((SymbolScriptable) this.prototype).delete(key);
    }

    [LineNumberTable(new byte[] {72, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void delete(int index) => this.prototype.delete(index);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable getPrototype() => this.prototype;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable getParentScope() => this.parent;

    [LineNumberTable(147)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] getIds() => this.prototype.getIds();

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(152)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getDefaultValue(Class typeHint) => this.prototype.getDefaultValue(typeHint);

    [LineNumberTable(157)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasInstance(Scriptable value) => this.prototype.hasInstance(value);

    [LineNumberTable(165)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual object updateDotQuery(bool value)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalStateException();
    }

    [LineNumberTable(new byte[] {121, 109, 105, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (f.hasTag(NativeWith.FTAG) && f.methodId() == 1)
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.cant.call.indirect", (object) "With"));
      throw Throwable.__\u003Cunmap\u003E((Exception) f.unknown());
    }

    [LineNumberTable(new byte[] {160, 66, 104, 103, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isWithFunction([In] object obj0)
    {
      if (!(obj0 is IdFunctionObject))
        return false;
      IdFunctionObject idFunctionObject = (IdFunctionObject) obj0;
      return idFunctionObject.hasTag(NativeWith.FTAG) && idFunctionObject.methodId() == 1;
    }

    [LineNumberTable(new byte[] {160, 74, 107, 104, 102, 102, 108, 5, 165, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object newWithSpecial([In] Context obj0, [In] Scriptable obj1, [In] object[] obj2)
    {
      ScriptRuntime.checkDeprecated(obj0, "With");
      obj1 = ScriptableObject.getTopLevelScope(obj1);
      NativeWith nativeWith = new NativeWith();
      nativeWith.setPrototype(obj2.Length != 0 ? ScriptRuntime.toObject(obj0, obj1, obj2[0]) : ScriptableObject.getObjectPrototype(obj1));
      nativeWith.setParentScope(obj1);
      return (object) nativeWith;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeWith()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeWith"))
        return;
      NativeWith.FTAG = (object) "With";
    }
  }
}
