﻿// Decompiled with JetBrains decompiler
// Type: rhino.typedarrays.NativeUint16Array
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
  public class NativeUint16Array : NativeTypedArrayView
  {
    private const string CLASS_NAME = "Uint16Array";
    private const int BYTES_PER_ELEMENT = 2;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 161, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeUint16Array(NativeArrayBuffer ab, int off, int len)
      : base(ab, off, len, len * 2)
    {
    }

    [LineNumberTable(new byte[] {159, 157, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeUint16Array()
    {
    }

    [LineNumberTable(new byte[] {6, 105, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object js_get(int index) => this.checkIndex(index) ? Undefined.__\u003C\u003Einstance : ByteIo.readUint16(this.__\u003C\u003EarrayBuffer.buffer, index * 2 + this.__\u003C\u003Eoffset, NativeArrayBufferView.useLittleEndian());

    [LineNumberTable(new byte[] {14, 105, 134, 103, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object js_set(int index, object c)
    {
      if (this.checkIndex(index))
        return Undefined.__\u003C\u003Einstance;
      int uint16 = Conversions.toUint16(c);
      ByteIo.writeUint16(this.__\u003C\u003EarrayBuffer.buffer, index * 2 + this.__\u003C\u003Eoffset, uint16, NativeArrayBufferView.useLittleEndian());
      return (object) null;
    }

    [LineNumberTable(new byte[] {159, 190, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual NativeUint16Array realThis(
      Scriptable thisObj,
      IdFunctionObject f)
    {
      return thisObj is NativeUint16Array ? (NativeUint16Array) thisObj : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(f));
    }

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual NativeUint16Array construct(
      NativeArrayBuffer ab,
      int off,
      int len)
    {
      return new NativeUint16Array(ab, off, len);
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

    [LineNumberTable(new byte[] {159, 165, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeUint16Array(int len)
      : this(new NativeArrayBuffer((double) (len * 2)), 0, len)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Uint16Array";

    [LineNumberTable(new byte[] {159, 134, 66, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void init(Context cx, Scriptable scope, bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      new NativeUint16Array().exportAsJSClass(6, scope, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getBytesPerElement() => 2;

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
    public override object set(int i, object obj) => (object) this.set(i, (Integer) obj);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object \u003Cbridge\u003Eget(int i) => (object) this.get(i);

    [HideFromJava]
    static NativeUint16Array() => NativeTypedArrayView.__\u003Cclinit\u003E();
  }
}
