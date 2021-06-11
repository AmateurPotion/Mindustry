// Decompiled with JetBrains decompiler
// Type: rhino.typedarrays.NativeUint8ClampedArray
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
  [Signature("Lrhino/typedarrays/NativeTypedArrayView<Ljava/lang/Integer;>;")]
  public class NativeUint8ClampedArray : NativeTypedArrayView
  {
    private const string CLASS_NAME = "Uint8ClampedArray";

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 161, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeUint8ClampedArray(NativeArrayBuffer ab, int off, int len)
      : base(ab, off, len, len)
    {
    }

    [LineNumberTable(new byte[] {159, 157, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeUint8ClampedArray()
    {
    }

    [LineNumberTable(new byte[] {6, 105, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object js_get(int index) => this.checkIndex(index) ? Undefined.__\u003C\u003Einstance : ByteIo.readUint8(this.__\u003C\u003EarrayBuffer.buffer, index + this.__\u003C\u003Eoffset);

    [LineNumberTable(new byte[] {14, 105, 134, 103, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object js_set(int index, object c)
    {
      if (this.checkIndex(index))
        return Undefined.__\u003C\u003Einstance;
      int uint8Clamp = Conversions.toUint8Clamp(c);
      ByteIo.writeUint8(this.__\u003C\u003EarrayBuffer.buffer, index + this.__\u003C\u003Eoffset, uint8Clamp);
      return (object) null;
    }

    [LineNumberTable(new byte[] {159, 190, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual NativeUint8ClampedArray realThis(
      Scriptable thisObj,
      IdFunctionObject f)
    {
      return thisObj is NativeUint8ClampedArray ? (NativeUint8ClampedArray) thisObj : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(f));
    }

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual NativeUint8ClampedArray construct(
      NativeArrayBuffer ab,
      int off,
      int len)
    {
      return new NativeUint8ClampedArray(ab, off, len);
    }

    [LineNumberTable(new byte[] {32, 105, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Integer set(int i, Integer aByte)
    {
      if (this.checkIndex(i))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException();
      }
      return (Integer) this.js_set(i, (object) aByte);
    }

    [LineNumberTable(new byte[] {24, 105, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Integer get(int i)
    {
      if (this.checkIndex(i))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException();
      }
      return (Integer) this.js_get(i);
    }

    [LineNumberTable(new byte[] {159, 165, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeUint8ClampedArray(int len)
      : this(new NativeArrayBuffer((double) len), 0, len)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Uint8ClampedArray";

    [LineNumberTable(new byte[] {159, 134, 66, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void init(Context cx, Scriptable scope, bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      new NativeUint8ClampedArray().exportAsJSClass(6, scope, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getBytesPerElement() => 1;

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    NativeTypedArrayView NativeTypedArrayView.\u003Cbridge\u003ErealThis(
      Scriptable s,
      IdFunctionObject ifo)
    {
      return (NativeTypedArrayView) this.realThis(s, ifo);
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(11)]
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
    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object set(int i, object obj) => (object) this.set(i, (Integer) obj);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object \u003Cbridge\u003Eget(int i) => (object) this.get(i);

    [HideFromJava]
    static NativeUint8ClampedArray() => NativeTypedArrayView.__\u003Cclinit\u003E();
  }
}
