// Decompiled with JetBrains decompiler
// Type: rhino.NativeJavaArray
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.lang.reflect;
using System;
using System.Runtime.CompilerServices;

namespace rhino
{
  [Implements(new string[] {"rhino.SymbolScriptable"})]
  public class NativeJavaArray : NativeJavaObject, SymbolScriptable
  {
    internal object array;
    internal int length;
    [Signature("Ljava/lang/Class<*>;")]
    internal Class cls;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 173, 111, 103, 104, 144, 103, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeJavaArray(Scriptable scope, object array)
      : base(scope, (object) null, ScriptRuntime.__\u003C\u003EObjectClass)
    {
      NativeJavaArray nativeJavaArray = this;
      Class @class = Object.instancehelper_getClass(array);
      if (!@class.isArray())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("Array expected");
      }
      this.array = array;
      this.length = Array.getLength(array);
      this.cls = @class.getComponentType();
    }

    [LineNumberTable(new byte[] {91, 104, 98, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Scriptable getPrototype()
    {
      if (this.prototype == null)
        this.prototype = ScriptableObject.getArrayPrototype(this.getParentScope());
      return this.prototype;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "JavaArray";

    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static NativeJavaArray wrap(Scriptable scope, object array) => new NativeJavaArray(scope, array);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object unwrap() => this.array;

    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool has(string id, Scriptable start) => String.instancehelper_equals(id, (object) "length") || base.has(id, start);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool has(int index, Scriptable start) => 0 <= index && index < this.length;

    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool has(Symbol key, Scriptable start) => SymbolKey.__\u003C\u003EIS_CONCAT_SPREADABLE.equals((object) key);

    [LineNumberTable(new byte[] {8, 109, 108, 105, 110, 109, 107, 43, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object get(string id, Scriptable start)
    {
      if (String.instancehelper_equals(id, (object) "length"))
        return (object) Integer.valueOf(this.length);
      object objA = base.get(id, start);
      if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND) && !ScriptableObject.hasProperty(this.getPrototype(), id))
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError2("msg.java.member.not.found", (object) Object.instancehelper_getClass(this.array).getName(), (object) id));
      return objA;
    }

    [LineNumberTable(new byte[] {21, 109, 102, 109, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object get(int index, Scriptable start)
    {
      if (0 > index || index >= this.length)
        return Undefined.__\u003C\u003Einstance;
      Context context = Context.getContext();
      object obj = Array.get(this.array, index);
      return context.getWrapFactory().wrap(context, (Scriptable) this, obj, this.cls);
    }

    [LineNumberTable(new byte[] {31, 109, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object get(Symbol key, Scriptable start) => SymbolKey.__\u003C\u003EIS_CONCAT_SPREADABLE.equals((object) key) ? (object) Boolean.valueOf(true) : Scriptable.NOT_FOUND;

    [LineNumberTable(new byte[] {40, 109, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void put(string id, Scriptable start, object value)
    {
      if (!String.instancehelper_equals(id, (object) "length"))
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.java.array.member.not.found", (object) id));
    }

    [LineNumberTable(new byte[] {47, 109, 154, 102, 109, 5, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void put(int index, Scriptable start, object value)
    {
      if (0 > index || index >= this.length)
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError2("msg.java.array.index.out.of.bounds", (object) String.valueOf(index), (object) String.valueOf(this.length - 1)));
      Array.set(this.array, index, Context.jsToJava(value, this.cls));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void delete(Symbol key)
    {
    }

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {63, 112, 108, 109, 102, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object getDefaultValue(Class hint)
    {
      if (hint == null || object.ReferenceEquals((object) hint, (object) ScriptRuntime.__\u003C\u003EStringClass))
        return (object) Object.instancehelper_toString(this.array);
      if (object.ReferenceEquals((object) hint, (object) ScriptRuntime.__\u003C\u003EBooleanClass))
        return (object) Boolean.TRUE;
      return object.ReferenceEquals((object) hint, (object) ScriptRuntime.__\u003C\u003ENumberClass) ? (object) ScriptRuntime.__\u003C\u003ENaNobj : (object) this;
    }

    [LineNumberTable(new byte[] {74, 108, 103, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object[] getIds()
    {
      object[] objArray = new object[this.length];
      int length = this.length;
      while (true)
      {
        length += -1;
        if (length >= 0)
          objArray[length] = (object) Integer.valueOf(length);
        else
          break;
      }
      return objArray;
    }

    [LineNumberTable(new byte[] {83, 104, 98, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool hasInstance(Scriptable value) => value is Wrapper && this.cls.isInstance(((Wrapper) value).unwrap());

    [HideFromJava]
    static NativeJavaArray() => NativeJavaObject.__\u003Cclinit\u003E();
  }
}
