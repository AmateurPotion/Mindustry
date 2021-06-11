// Decompiled with JetBrains decompiler
// Type: rhino.typedarrays.NativeInt8Array
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace rhino.typedarrays
{
  [Signature("Lrhino/typedarrays/NativeTypedArrayView<Ljava/lang/Byte;>;")]
  public class NativeInt8Array : NativeTypedArrayView
  {
    private const string CLASS_NAME = "Int8Array";

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 160, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeInt8Array(NativeArrayBuffer ab, int off, int len)
      : base(ab, off, len, len)
    {
    }

    [LineNumberTable(new byte[] {159, 156, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeInt8Array()
    {
    }

    [LineNumberTable(new byte[] {5, 105, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object js_get(int index) => this.checkIndex(index) ? Undefined.__\u003C\u003Einstance : ByteIo.readInt8(this.__\u003C\u003EarrayBuffer.buffer, index + this.__\u003C\u003Eoffset);

    [LineNumberTable(new byte[] {13, 105, 134, 103, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object js_set(int index, object c)
    {
      if (this.checkIndex(index))
        return Undefined.__\u003C\u003Einstance;
      int int8 = Conversions.toInt8(c);
      ByteIo.writeInt8(this.__\u003C\u003EarrayBuffer.buffer, index + this.__\u003C\u003Eoffset, int8);
      return (object) null;
    }

    [LineNumberTable(new byte[] {159, 189, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual NativeInt8Array realThis(
      Scriptable thisObj,
      IdFunctionObject f)
    {
      return thisObj is NativeInt8Array ? (NativeInt8Array) thisObj : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(f));
    }

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual NativeInt8Array construct(
      NativeArrayBuffer ab,
      int off,
      int len)
    {
      return new NativeInt8Array(ab, off, len);
    }

    [LineNumberTable(new byte[] {33, 105, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Byte set(int i, Byte aByte)
    {
      if (this.checkIndex(i))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException();
      }
      return (Byte) this.js_set(i, (object) aByte);
    }

    [LineNumberTable(new byte[] {25, 105, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Byte get(int i)
    {
      if (this.checkIndex(i))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException();
      }
      return (Byte) this.js_get(i);
    }

    [LineNumberTable(new byte[] {159, 164, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeInt8Array(int len)
      : this(new NativeArrayBuffer((double) len), 0, len)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Int8Array";

    [LineNumberTable(new byte[] {159, 135, 162, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void init(Context cx, Scriptable scope, bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      new NativeInt8Array().exportAsJSClass(6, scope, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getBytesPerElement() => 1;

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    NativeTypedArrayView NativeTypedArrayView.\u003Cbridge\u003ErealThis(
      Scriptable s,
      IdFunctionObject ifo)
    {
      return (NativeTypedArrayView) this.realThis(s, ifo);
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    NativeTypedArrayView NativeTypedArrayView.\u003Cbridge\u003Econstruct(
      NativeArrayBuffer nab,
      int i1,
      int i2)
    {
      return (NativeTypedArrayView) this.construct(nab, i1, i2);
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object set(int i, object obj) => (object) this.set(i, (Byte) obj);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object \u003Cbridge\u003Eget(int i) => (object) this.get(i);

    [HideFromJava]
    static NativeInt8Array() => NativeTypedArrayView.__\u003Cclinit\u003E();
  }
}
