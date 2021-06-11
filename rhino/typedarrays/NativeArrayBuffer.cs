// Decompiled with JetBrains decompiler
// Type: rhino.typedarrays.NativeArrayBuffer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.typedarrays
{
  public class NativeArrayBuffer : IdScriptableObject
  {
    public const string CLASS_NAME = "ArrayBuffer";
    [Modifiers]
    private static byte[] EMPTY_BUF;
    [Modifiers]
    internal byte[] buffer;
    private const int Id_constructor = 1;
    private const int Id_slice = 2;
    private const int MAX_PROTOTYPE_ID = 2;
    private const int ConstructorId_isView = -1;
    private const int Id_byteLength = 1;
    private const int MAX_INSTANCE_ID = 1;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 173, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeArrayBuffer()
    {
      NativeArrayBuffer nativeArrayBuffer = this;
      this.buffer = NativeArrayBuffer.EMPTY_BUF;
    }

    [LineNumberTable(new byte[] {159, 180, 104, 109, 159, 22, 109, 191, 12, 104, 100, 159, 12, 99, 141, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeArrayBuffer(double len)
    {
      NativeArrayBuffer nativeArrayBuffer = this;
      if (len >= (double) int.MaxValue)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", new StringBuilder().append("length parameter (").append(len).append(") is too large ").toString()));
      int length = len != double.NegativeInfinity ? ScriptRuntime.toInt32(len) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", new StringBuilder().append("Negative array length ").append(len).toString()));
      if (length < 0)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", new StringBuilder().append("Negative array length ").append(len).toString()));
      if (length == 0)
        this.buffer = NativeArrayBuffer.EMPTY_BUF;
      else
        this.buffer = new byte[length];
    }

    [LineNumberTable(128)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isArg([In] object[] obj0, [In] int obj1) => obj0.Length > obj1 && !Object.instancehelper_equals(Undefined.__\u003C\u003Einstance, obj0[obj1]);

    [LineNumberTable(new byte[] {72, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static NativeArrayBuffer realThis(
      [In] Scriptable obj0,
      [In] IdFunctionObject obj1)
    {
      return obj0 is NativeArrayBuffer ? (NativeArrayBuffer) obj0 : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));
    }

    [LineNumberTable(new byte[] {36, 127, 25, 127, 19, 132, 104, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual NativeArrayBuffer slice(double s, double e)
    {
      int int32_1 = ScriptRuntime.toInt32(Math.max(0.0, Math.min((double) this.buffer.Length, e >= 0.0 ? e : (double) this.buffer.Length + e)));
      int int32_2 = ScriptRuntime.toInt32(Math.min((double) int32_1, Math.max(0.0, s >= 0.0 ? s : (double) this.buffer.Length + s)));
      int num = int32_1 - int32_2;
      NativeArrayBuffer nativeArrayBuffer = new NativeArrayBuffer((double) num);
      ByteCodeHelper.arraycopy_primitive_1((Array) this.buffer, int32_2, (Array) nativeArrayBuffer.buffer, 0, num);
      return nativeArrayBuffer;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "ArrayBuffer";

    [LineNumberTable(new byte[] {159, 136, 66, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void init(Context cx, Scriptable scope, bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      new NativeArrayBuffer().exportAsJSClass(2, scope, num != 0);
    }

    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLength() => this.buffer.Length;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte[] getBuffer() => this.buffer;

    [LineNumberTable(new byte[] {50, 109, 142, 103, 157, 191, 0, 125, 167, 105, 125, 127, 2, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag((object) "ArrayBuffer"))
        return base.execIdCall(f, cx, scope, thisObj, args);
      int num = f.methodId();
      switch (num)
      {
        case -1:
          return (object) Boolean.valueOf(NativeArrayBuffer.isArg(args, 0) && args[0] is NativeArrayBufferView);
        case 1:
          return (object) new NativeArrayBuffer(!NativeArrayBuffer.isArg(args, 0) ? 0.0 : ScriptRuntime.toNumber(args[0]));
        case 2:
          NativeArrayBuffer nativeArrayBuffer = NativeArrayBuffer.realThis(thisObj, f);
          double s = !NativeArrayBuffer.isArg(args, 0) ? 0.0 : ScriptRuntime.toNumber(args[0]);
          double e = !NativeArrayBuffer.isArg(args, 1) ? (double) nativeArrayBuffer.buffer.Length : ScriptRuntime.toNumber(args[1]);
          return (object) nativeArrayBuffer.slice(s, e);
        default:
          string str = String.valueOf(num);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {85, 146, 98, 102, 130, 98, 102, 130, 145, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      int arity;
      string name;
      switch (id)
      {
        case 1:
          arity = 1;
          name = "constructor";
          break;
        case 2:
          arity = 1;
          name = "slice";
          break;
        default:
          string str = String.valueOf(id);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.initPrototypeMethod((object) "ArrayBuffer", id, name, arity);
    }

    [LineNumberTable(new byte[] {108, 98, 98, 103, 100, 102, 100, 101, 102, 130, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 5:
          str = "slice";
          num = 2;
          break;
        case 11:
          str = "constructor";
          num = 1;
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
        num = 0;
      return num;
    }

    [LineNumberTable(new byte[] {160, 74, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void fillConstructorProperties(IdFunctionObject ctor) => this.addIdFunctionProperty((Scriptable) ctor, (object) "ArrayBuffer", -1, "isView", 1);

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int getMaxInstanceId() => 1;

    [LineNumberTable(new byte[] {160, 86, 100, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override string getInstanceIdName(int id) => id == 1 ? "byteLength" : base.getInstanceIdName(id);

    [LineNumberTable(new byte[] {160, 94, 100, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object getInstanceIdValue(int id) => id == 1 ? (object) ScriptRuntime.wrapInt(this.buffer.Length) : base.getInstanceIdValue(id);

    [LineNumberTable(new byte[] {160, 102, 109, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findInstanceIdInfo(string s) => String.instancehelper_equals("byteLength", (object) s) ? IdScriptableObject.instanceIdInfo(5, 1) : base.findInstanceIdInfo(s);

    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeArrayBuffer()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.typedarrays.NativeArrayBuffer"))
        return;
      NativeArrayBuffer.EMPTY_BUF = new byte[0];
    }
  }
}
