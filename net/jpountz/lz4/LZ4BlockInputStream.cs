// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4BlockInputStream
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
  public sealed class LZ4BlockInputStream : FilterInputStream
  {
    [Modifiers]
    private LZ4FastDecompressor decompressor;
    [Modifiers]
    private Checksum checksum;
    [Modifiers]
    private bool stopOnEmptyBlock;
    private byte[] buffer;
    private byte[] compressedBuffer;
    private int originalLen;
    private int o;
    private bool finished;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 126, 99, 105, 103, 103, 103, 108, 112, 114, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4BlockInputStream(
      InputStream @in,
      LZ4FastDecompressor decompressor,
      Checksum checksum,
      bool stopOnEmptyBlock)
    {
      int num1 = stopOnEmptyBlock ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(@in);
      LZ4BlockInputStream blockInputStream1 = this;
      this.decompressor = decompressor;
      this.checksum = checksum;
      this.stopOnEmptyBlock = num1 != 0;
      this.buffer = new byte[0];
      this.compressedBuffer = new byte[LZ4BlockOutputStream.HEADER_LENGTH];
      LZ4BlockInputStream blockInputStream2 = this;
      int num2 = 0;
      int num3 = num2;
      this.originalLen = num2;
      this.o = num3;
      this.finished = false;
    }

    [LineNumberTable(new byte[] {52, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4BlockInputStream(InputStream @in, LZ4FastDecompressor decompressor)
      : this(@in, decompressor, XXHashFactory.fastestInstance().newStreamingHash32(-1756908916).asChecksum(), true)
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 77, 255, 4, 72, 226, 57, 97, 104, 137, 135, 129, 106, 113, 16, 230, 69, 109, 104, 105, 106, 144, 116, 120, 117, 127, 2, 255, 37, 70, 144, 108, 100, 144, 104, 136, 135, 129, 111, 159, 2, 151, 114, 133, 107, 157, 142, 127, 2, 102, 223, 3, 2, 98, 210, 139, 107, 120, 112, 144, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void refill()
    {
      EOFException eofException1;
      try
      {
        this.readFully(this.compressedBuffer, LZ4BlockOutputStream.HEADER_LENGTH);
        goto label_5;
      }
      catch (EOFException ex)
      {
        eofException1 = (EOFException) ByteCodeHelper.MapException<EOFException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      EOFException eofException2 = eofException1;
      if (this.stopOnEmptyBlock)
        throw Throwable.__\u003Cunmap\u003E((Exception) eofException2);
      this.finished = true;
      return;
label_5:
      for (int index = 0; index < LZ4BlockOutputStream.MAGIC_LENGTH; ++index)
      {
        if ((int) (sbyte) this.compressedBuffer[index] != (int) (sbyte) LZ4BlockOutputStream.MAGIC[index])
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException("Stream is corrupted");
        }
      }
      int num1 = (int) this.compressedBuffer[LZ4BlockOutputStream.MAGIC_LENGTH];
      int num2 = num1 & 240;
      int num3 = 10 + (num1 & 15);
      if (num2 != 16 && num2 != 32)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException("Stream is corrupted");
      }
      int num4 = SafeUtils.readIntLE(this.compressedBuffer, LZ4BlockOutputStream.MAGIC_LENGTH + 1);
      this.originalLen = SafeUtils.readIntLE(this.compressedBuffer, LZ4BlockOutputStream.MAGIC_LENGTH + 5);
      int num5 = SafeUtils.readIntLE(this.compressedBuffer, LZ4BlockOutputStream.MAGIC_LENGTH + 9);
      if (!LZ4BlockInputStream.\u0024assertionsDisabled && LZ4BlockOutputStream.HEADER_LENGTH != LZ4BlockOutputStream.MAGIC_LENGTH + 13)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      if (this.originalLen > 1 << num3 || this.originalLen < 0 || num4 < 0 || (this.originalLen == 0 && num4 != 0 || this.originalLen != 0 && num4 == 0) || num2 == 16 && this.originalLen != num4)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException("Stream is corrupted");
      }
      if (this.originalLen == 0 && num4 == 0)
      {
        if (num5 != 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException("Stream is corrupted");
        }
        if (!this.stopOnEmptyBlock)
          this.refill();
        else
          this.finished = true;
      }
      else
      {
        if (this.buffer.Length < this.originalLen)
          this.buffer = new byte[Math.max(this.originalLen, this.buffer.Length * 3 / 2)];
        switch (num2)
        {
          case 16:
            this.readFully(this.buffer, this.originalLen);
            break;
          case 32:
            if (this.compressedBuffer.Length < num4)
              this.compressedBuffer = new byte[Math.max(num4, this.compressedBuffer.Length * 3 / 2)];
            this.readFully(this.compressedBuffer, num4);
            LZ4Exception lz4Exception1;
            try
            {
              int num6 = this.decompressor.decompress(this.compressedBuffer, 0, this.buffer, 0, this.originalLen);
              if (num4 != num6)
              {
                Throwable.__\u003CsuppressFillInStackTrace\u003E();
                throw new IOException("Stream is corrupted");
              }
              break;
            }
            catch (LZ4Exception ex)
            {
              lz4Exception1 = (LZ4Exception) ByteCodeHelper.MapException<LZ4Exception>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            }
            LZ4Exception lz4Exception2 = lz4Exception1;
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IOException("Stream is corrupted", (Exception) lz4Exception2);
          default:
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new AssertionError();
        }
        this.checksum.reset();
        this.checksum.update(this.buffer, 0, this.originalLen);
        if ((int) this.checksum.getValue() != num5)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException("Stream is corrupted");
        }
        this.o = 0;
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {102, 104, 104, 130, 110, 134, 104, 130, 117, 116, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int read(byte[] b, int off, int len)
    {
      SafeUtils.checkRange(b, off, len);
      if (this.finished)
        return -1;
      if (this.o == this.originalLen)
        this.refill();
      if (this.finished)
        return -1;
      len = Math.min(len, this.originalLen - this.o);
      ByteCodeHelper.arraycopy_primitive_1((Array) this.buffer, this.o, (Array) b, off, len);
      this.o += len;
      return len;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 153, 98, 100, 115, 100, 144, 100, 98, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readFully([In] byte[] obj0, [In] int obj1)
    {
      int num1;
      int num2;
      for (num1 = 0; num1 < obj1; num1 += num2)
      {
        num2 = ((InputStream) this.@in).read(obj0, num1, obj1 - num1);
        if (num2 < 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new EOFException("Stream ended prematurely");
        }
      }
      if (!LZ4BlockInputStream.\u0024assertionsDisabled && obj1 != num1)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
    }

    [LineNumberTable(new byte[] {38, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4BlockInputStream(
      InputStream @in,
      LZ4FastDecompressor decompressor,
      Checksum checksum)
      : this(@in, decompressor, checksum, true)
    {
    }

    [LineNumberTable(new byte[] {159, 113, 66, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4BlockInputStream(InputStream @in, bool stopOnEmptyBlock)
    {
      int num = stopOnEmptyBlock ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(@in, LZ4Factory.fastestInstance().fastDecompressor(), XXHashFactory.fastestInstance().newStreamingHash32(-1756908916).asChecksum(), num != 0);
    }

    [LineNumberTable(new byte[] {78, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4BlockInputStream(InputStream @in)
      : this(@in, LZ4Factory.fastestInstance().fastDecompressor())
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int available() => this.originalLen - this.o;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {88, 104, 130, 110, 134, 104, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int read()
    {
      if (this.finished)
        return -1;
      if (this.o == this.originalLen)
        this.refill();
      if (this.finished)
        return -1;
      byte[] buffer = this.buffer;
      LZ4BlockInputStream blockInputStream1 = this;
      int o = blockInputStream1.o;
      LZ4BlockInputStream blockInputStream2 = blockInputStream1;
      int index = o;
      blockInputStream2.o = o + 1;
      return (int) buffer[index];
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(170)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int read(byte[] b) => this.read(b, 0, b.Length);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {125, 109, 131, 110, 134, 104, 131, 118, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long skip(long n)
    {
      if (n <= 0L || this.finished)
        return 0;
      if (this.o == this.originalLen)
        this.refill();
      if (this.finished)
        return 0;
      int num = (int) Math.min(n, (long) (this.originalLen - this.o));
      this.o += num;
      return (long) num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool markSupported() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void mark(int readlimit)
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(292)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IOException("mark/reset not supported");
    }

    [LineNumberTable(297)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append(Object.instancehelper_getClass((object) this).getSimpleName()).append("(in=").append((object) this.@in).append(", decompressor=").append((object) this.decompressor).append(", checksum=").append((object) this.checksum).append(")").toString();

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LZ4BlockInputStream()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4BlockInputStream"))
        return;
      LZ4BlockInputStream.\u0024assertionsDisabled = !((Class) ClassLiteral<LZ4BlockInputStream>.Value).desiredAssertionStatus();
    }
  }
}
