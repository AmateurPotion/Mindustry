// Decompiled with JetBrains decompiler
// Type: arc.util.io.ByteBufferOutput
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
  public class ByteBufferOutput : Object, DataOutput
  {
    public ByteBuffer buffer;

    [LineNumberTable(new byte[] {159, 154, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ByteBufferOutput(ByteBuffer buffer)
    {
      ByteBufferOutput byteBufferOutput = this;
      this.buffer = buffer;
    }

    [LineNumberTable(new byte[] {159, 159, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ByteBufferOutput()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBuffer(ByteBuffer buffer) => this.buffer = buffer;

    [LineNumberTable(new byte[] {159, 168, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(int i) => this.buffer.put((byte) i);

    [LineNumberTable(new byte[] {159, 173, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(byte[] bytes) => this.buffer.put(bytes);

    [LineNumberTable(new byte[] {159, 178, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(byte[] bytes, int i, int i1) => this.buffer.put(bytes, i, i1);

    [LineNumberTable(new byte[] {159, 132, 98, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeBoolean(bool b) => this.buffer.put(!b ? (byte) 0 : (byte) 1);

    [LineNumberTable(new byte[] {159, 188, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeByte(int i) => this.buffer.put((byte) i);

    [LineNumberTable(new byte[] {1, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeShort(int i) => this.buffer.putShort((short) i);

    [LineNumberTable(new byte[] {6, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeChar(int i) => this.buffer.putChar((char) i);

    [LineNumberTable(new byte[] {11, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeInt(int i) => this.buffer.putInt(i);

    [LineNumberTable(new byte[] {16, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeLong(long l) => this.buffer.putLong(l);

    [LineNumberTable(new byte[] {21, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeFloat(float v) => this.buffer.putFloat(v);

    [LineNumberTable(new byte[] {26, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeDouble(double v) => this.buffer.putDouble(v);

    [LineNumberTable(81)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeBytes(string s)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException("Stub!");
    }

    [LineNumberTable(86)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeChars(string s)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException("Stub!");
    }

    [LineNumberTable(new byte[] {42, 108, 121, 111, 191, 0, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeUTF(string s)
    {
      UnsupportedEncodingException encodingException1;
      try
      {
        byte[] bytes = String.instancehelper_getBytes(s, "UTF-8");
        if (bytes.Length >= (int) short.MaxValue)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("Input string is too long!");
        }
        this.buffer.putShort((short) bytes.Length);
        this.buffer.put(bytes);
        return;
      }
      catch (UnsupportedEncodingException ex)
      {
        encodingException1 = (UnsupportedEncodingException) ByteCodeHelper.MapException<UnsupportedEncodingException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      UnsupportedEncodingException encodingException2 = encodingException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) encodingException2);
    }
  }
}
