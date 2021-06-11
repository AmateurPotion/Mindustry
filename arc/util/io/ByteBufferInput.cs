// Decompiled with JetBrains decompiler
// Type: arc.util.io.ByteBufferInput
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.nio;
using System;
using System.Runtime.CompilerServices;

namespace arc.util.io
{
  public class ByteBufferInput : Object, DataInput
  {
    public ByteBuffer buffer;

    [LineNumberTable(new byte[] {159, 154, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ByteBufferInput(ByteBuffer buffer)
    {
      ByteBufferInput byteBufferInput = this;
      this.buffer = buffer;
    }

    [LineNumberTable(new byte[] {159, 159, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ByteBufferInput()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBuffer(ByteBuffer buffer) => this.buffer = buffer;

    [LineNumberTable(new byte[] {159, 168, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readFully(byte[] bytes) => this.buffer.get(bytes);

    [LineNumberTable(new byte[] {159, 173, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readFully(byte[] bytes, int f, int to) => this.buffer.get(bytes, f, to);

    [LineNumberTable(new byte[] {159, 178, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int skipBytes(int i)
    {
      ((Buffer) this.buffer).position(((Buffer) this.buffer).position() + i);
      return i;
    }

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool readBoolean() => this.buffer.get() == (byte) 1;

    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte readByte() => this.buffer.get();

    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int readUnsignedByte() => (int) (sbyte) this.buffer.get() + 128;

    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short readShort() => this.buffer.getShort();

    [LineNumberTable(62)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int readUnsignedShort() => (int) this.buffer.getShort() + 32768;

    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual char readChar() => this.buffer.getChar();

    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int readInt() => this.buffer.getInt();

    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long readLong() => this.buffer.getLong();

    [LineNumberTable(82)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float readFloat() => this.buffer.getFloat();

    [LineNumberTable(87)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double readDouble() => this.buffer.getDouble();

    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string readLine()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException("Stub!");
    }

    [LineNumberTable(new byte[] {48, 108, 103, 109, 127, 2, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string readUTF()
    {
      string str;
      UnsupportedEncodingException encodingException1;
      try
      {
        byte[] numArray = new byte[(int) this.buffer.getShort()];
        this.buffer.get(numArray);
        str = String.newhelper(numArray, "UTF-8");
      }
      catch (UnsupportedEncodingException ex)
      {
        encodingException1 = (UnsupportedEncodingException) ByteCodeHelper.MapException<UnsupportedEncodingException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return str;
label_3:
      UnsupportedEncodingException encodingException2 = encodingException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) encodingException2);
    }
  }
}
