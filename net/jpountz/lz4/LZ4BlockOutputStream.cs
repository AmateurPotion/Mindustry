// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4BlockOutputStream
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util.zip;
using net.jpountz.util;
using net.jpountz.xxhash;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.lz4
{
  public sealed class LZ4BlockOutputStream : FilterOutputStream
  {
    [Modifiers]
    internal static byte[] MAGIC;
    [Modifiers]
    internal static int MAGIC_LENGTH;
    [Modifiers]
    internal static int HEADER_LENGTH;
    internal const int COMPRESSION_LEVEL_BASE = 10;
    internal const int MIN_BLOCK_SIZE = 64;
    internal const int MAX_BLOCK_SIZE = 33554432;
    internal const int COMPRESSION_METHOD_RAW = 16;
    internal const int COMPRESSION_METHOD_LZ4 = 32;
    internal const int DEFAULT_SEED = -1756908916;
    [Modifiers]
    private int blockSize;
    [Modifiers]
    private int compressionLevel;
    [Modifiers]
    private LZ4Compressor compressor;
    [Modifiers]
    private Checksum checksum;
    [Modifiers]
    private byte[] buffer;
    [Modifiers]
    private byte[] compressedBuffer;
    [Modifiers]
    private bool syncFlush;
    private bool finished;
    private int o;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {7, 101, 127, 6, 104, 159, 6, 108, 123, 125, 107, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int compressionLevel([In] int obj0)
    {
      if (obj0 < 64)
      {
        string str = new StringBuilder().append("blockSize must be >= 64, got ").append(obj0).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (obj0 > 33554432)
      {
        string str = new StringBuilder().append("blockSize must be <= 33554432, got ").append(obj0).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      int num1 = 32 - Integer.numberOfLeadingZeros(obj0 - 1);
      if (!LZ4BlockOutputStream.\u0024assertionsDisabled && 1 << num1 < obj0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      if (!LZ4BlockOutputStream.\u0024assertionsDisabled && obj0 * 2 <= 1 << num1)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      int num2 = Math.max(0, num1 - 10);
      if (!LZ4BlockOutputStream.\u0024assertionsDisabled && (num2 < 0 || num2 > 15))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      return num2;
    }

    [LineNumberTable(new byte[] {159, 119, 163, 105, 103, 103, 104, 108, 108, 110, 108, 103, 103, 103, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4BlockOutputStream(
      OutputStream @out,
      int blockSize,
      LZ4Compressor compressor,
      Checksum checksum,
      bool syncFlush)
    {
      int num = syncFlush ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(@out);
      LZ4BlockOutputStream blockOutputStream = this;
      this.blockSize = blockSize;
      this.compressor = compressor;
      this.checksum = checksum;
      this.compressionLevel = LZ4BlockOutputStream.compressionLevel(blockSize);
      this.buffer = new byte[blockSize];
      this.compressedBuffer = new byte[LZ4BlockOutputStream.HEADER_LENGTH + compressor.maxCompressedLength(blockSize)];
      this.syncFlush = num != 0;
      this.o = 0;
      this.finished = false;
      ByteCodeHelper.arraycopy_primitive_1((Array) LZ4BlockOutputStream.MAGIC, 0, (Array) this.compressedBuffer, 0, LZ4BlockOutputStream.MAGIC_LENGTH);
    }

    [LineNumberTable(new byte[] {73, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4BlockOutputStream(OutputStream @out, int blockSize, LZ4Compressor compressor)
      : this(@out, blockSize, compressor, XXHashFactory.fastestInstance().newStreamingHash32(-1756908916).asChecksum(), false)
    {
    }

    [LineNumberTable(new byte[] {88, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4BlockOutputStream(OutputStream @out, int blockSize)
      : this(@out, blockSize, LZ4Factory.fastestInstance().fastCompressor())
    {
    }

    [LineNumberTable(new byte[] {103, 104, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void ensureNotFinished()
    {
      if (this.finished)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("This stream is already closed");
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 88, 104, 129, 107, 120, 109, 159, 5, 105, 99, 103, 159, 0, 163, 117, 115, 120, 116, 127, 2, 121, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void flushBufferedData()
    {
      if (this.o == 0)
        return;
      this.checksum.reset();
      this.checksum.update(this.buffer, 0, this.o);
      int num1 = (int) this.checksum.getValue();
      int num2 = this.compressor.compress(this.buffer, 0, this.o, this.compressedBuffer, LZ4BlockOutputStream.HEADER_LENGTH);
      int num3;
      if (num2 >= this.o)
      {
        num3 = 16;
        num2 = this.o;
        ByteCodeHelper.arraycopy_primitive_1((Array) this.buffer, 0, (Array) this.compressedBuffer, LZ4BlockOutputStream.HEADER_LENGTH, this.o);
      }
      else
        num3 = 32;
      this.compressedBuffer[LZ4BlockOutputStream.MAGIC_LENGTH] = (byte) (num3 | this.compressionLevel);
      LZ4BlockOutputStream.writeIntLE(num2, this.compressedBuffer, LZ4BlockOutputStream.MAGIC_LENGTH + 1);
      LZ4BlockOutputStream.writeIntLE(this.o, this.compressedBuffer, LZ4BlockOutputStream.MAGIC_LENGTH + 5);
      LZ4BlockOutputStream.writeIntLE(num1, this.compressedBuffer, LZ4BlockOutputStream.MAGIC_LENGTH + 9);
      if (!LZ4BlockOutputStream.\u0024assertionsDisabled && LZ4BlockOutputStream.MAGIC_LENGTH + 13 != LZ4BlockOutputStream.HEADER_LENGTH)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      ((OutputStream) this.@out).write(this.compressedBuffer, 0, LZ4BlockOutputStream.HEADER_LENGTH + num2);
      this.o = 0;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {119, 104, 134, 112, 110, 127, 1, 108, 102, 101, 101, 98, 116, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(byte[] b, int off, int len)
    {
      SafeUtils.checkRange(b, off, len);
      this.ensureNotFinished();
      int num;
      for (; this.o + len > this.blockSize; len -= num)
      {
        num = this.blockSize - this.o;
        ByteCodeHelper.arraycopy_primitive_1((Array) b, off, (Array) this.buffer, this.o, this.blockSize - this.o);
        this.o = this.blockSize;
        this.flushBufferedData();
        off += num;
      }
      ByteCodeHelper.arraycopy_primitive_1((Array) b, off, (Array) this.buffer, this.o, len);
      this.o += len;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 140, 102, 102, 118, 115, 115, 116, 127, 2, 119, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void finish()
    {
      this.ensureNotFinished();
      this.flushBufferedData();
      this.compressedBuffer[LZ4BlockOutputStream.MAGIC_LENGTH] = (byte) (16 | this.compressionLevel);
      LZ4BlockOutputStream.writeIntLE(0, this.compressedBuffer, LZ4BlockOutputStream.MAGIC_LENGTH + 1);
      LZ4BlockOutputStream.writeIntLE(0, this.compressedBuffer, LZ4BlockOutputStream.MAGIC_LENGTH + 5);
      LZ4BlockOutputStream.writeIntLE(0, this.compressedBuffer, LZ4BlockOutputStream.MAGIC_LENGTH + 9);
      if (!LZ4BlockOutputStream.\u0024assertionsDisabled && LZ4BlockOutputStream.MAGIC_LENGTH + 13 != LZ4BlockOutputStream.HEADER_LENGTH)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      ((OutputStream) this.@out).write(this.compressedBuffer, 0, LZ4BlockOutputStream.HEADER_LENGTH);
      this.finished = true;
      ((OutputStream) this.@out).flush();
    }

    [LineNumberTable(new byte[] {160, 153, 106, 108, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void writeIntLE([In] int obj0, [In] byte[] obj1, [In] int obj2)
    {
      byte[] numArray1 = obj1;
      int index1 = obj2;
      ++obj2;
      int num1 = (int) (sbyte) obj0;
      numArray1[index1] = (byte) num1;
      byte[] numArray2 = obj1;
      int index2 = obj2;
      ++obj2;
      int num2 = (int) (sbyte) ((uint) obj0 >> 8);
      numArray2[index2] = (byte) num2;
      byte[] numArray3 = obj1;
      int index3 = obj2;
      ++obj2;
      int num3 = (int) (sbyte) ((uint) obj0 >> 16);
      numArray3[index3] = (byte) num3;
      byte[] numArray4 = obj1;
      int index4 = obj2;
      ++obj2;
      int num4 = (int) (sbyte) ((uint) obj0 >> 24);
      numArray4[index4] = (byte) num4;
    }

    [LineNumberTable(new byte[] {99, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4BlockOutputStream(OutputStream @out)
      : this(@out, 65536)
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {110, 102, 110, 134, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(int b)
    {
      this.ensureNotFinished();
      if (this.o == this.blockSize)
        this.flushBufferedData();
      byte[] buffer = this.buffer;
      LZ4BlockOutputStream blockOutputStream1 = this;
      int o = blockOutputStream1.o;
      LZ4BlockOutputStream blockOutputStream2 = blockOutputStream1;
      int index = o;
      blockOutputStream2.o = o + 1;
      int num = (int) (sbyte) b;
      buffer[index] = (byte) num;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 72, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(byte[] b)
    {
      this.ensureNotFinished();
      this.write(b, 0, b.Length);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 78, 104, 134, 104, 107, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void close()
    {
      if (!this.finished)
        this.finish();
      if (this.@out == null)
        return;
      ((OutputStream) this.@out).close();
      this.@out = null;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 125, 104, 104, 134, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void flush()
    {
      if (this.@out == null)
        return;
      if (this.syncFlush)
        this.flushBufferedData();
      ((OutputStream) this.@out).flush();
    }

    [LineNumberTable(275)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append(Object.instancehelper_getClass((object) this).getSimpleName()).append("(out=").append((object) this.@out).append(", blockSize=").append(this.blockSize).append(", compressor=").append((object) this.compressor).append(", checksum=").append((object) this.checksum).append(")").toString();

    [LineNumberTable(new byte[] {159, 134, 173, 149, 127, 20, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LZ4BlockOutputStream()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4BlockOutputStream"))
        return;
      LZ4BlockOutputStream.\u0024assertionsDisabled = !((Class) ClassLiteral<LZ4BlockOutputStream>.Value).desiredAssertionStatus();
      LZ4BlockOutputStream.MAGIC = new byte[8]
      {
        (byte) 76,
        (byte) 90,
        (byte) 52,
        (byte) 66,
        (byte) 108,
        (byte) 111,
        (byte) 99,
        (byte) 107
      };
      LZ4BlockOutputStream.MAGIC_LENGTH = LZ4BlockOutputStream.MAGIC.Length;
      LZ4BlockOutputStream.HEADER_LENGTH = LZ4BlockOutputStream.MAGIC_LENGTH + 1 + 4 + 4 + 4;
    }
  }
}
