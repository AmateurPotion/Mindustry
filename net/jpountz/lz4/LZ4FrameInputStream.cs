// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4FrameInputStream
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.nio;
using java.util;
using net.jpountz.xxhash;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.lz4
{
  public class LZ4FrameInputStream : FilterInputStream
  {
    internal const string PREMATURE_EOS = "Stream ended prematurely";
    internal const string NOT_SUPPORTED = "Stream unsupported";
    internal const string BLOCK_HASH_MISMATCH = "Block checksum mismatch";
    internal const string DESCRIPTOR_HASH_MISMATCH = "Stream frame descriptor corrupted";
    internal const int MAGIC_SKIPPABLE_BASE = 407710288;
    [Modifiers]
    private LZ4SafeDecompressor decompressor;
    [Modifiers]
    private XXHash32 checksum;
    [Modifiers]
    private byte[] headerArray;
    [Modifiers]
    private ByteBuffer headerBuffer;
    private byte[] compressedBuffer;
    private ByteBuffer buffer;
    private byte[] rawBuffer;
    private int maxBlockSize;
    private long expectedContentSize;
    private long totalContentSize;
    private LZ4FrameOutputStream.FrameInfo frameInfo;
    [Modifiers]
    private ByteBuffer readNumberBuff;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {33, 233, 30, 109, 155, 103, 103, 103, 104, 136, 231, 160, 122, 246, 159, 160, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4FrameInputStream(
      InputStream @in,
      LZ4SafeDecompressor decompressor,
      XXHash32 checksum)
      : base(@in)
    {
      LZ4FrameInputStream frameInputStream = this;
      this.headerArray = new byte[15];
      this.headerBuffer = ByteBuffer.wrap(this.headerArray).order((ByteOrder) ByteOrder.LITTLE_ENDIAN);
      this.buffer = (ByteBuffer) null;
      this.rawBuffer = (byte[]) null;
      this.maxBlockSize = -1;
      this.expectedContentSize = -1L;
      this.totalContentSize = 0L;
      this.frameInfo = (LZ4FrameOutputStream.FrameInfo) null;
      this.readNumberBuff = ByteBuffer.allocate(8).order((ByteOrder) ByteOrder.LITTLE_ENDIAN);
      this.decompressor = decompressor;
      this.checksum = checksum;
      this.nextFrameInfo();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {48, 130, 125, 100, 130, 100, 100, 109, 104, 102, 98, 106, 136, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool nextFrameInfo()
    {
      while (true)
      {
        int num1 = 0;
        do
        {
          int num2 = ((InputStream) this.@in).read(this.readNumberBuff.array(), num1, 4 - num1);
          if (num2 < 0)
            return false;
          num1 += num2;
        }
        while (num1 < 4);
        int num3 = this.readNumberBuff.getInt(0);
        if (num3 != 407708164)
        {
          if ((uint) num3 >> 4 == 25481893U)
            this.skippableFrame();
          else
            goto label_8;
        }
        else
          break;
      }
      this.readHeader();
      return true;
label_8:
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IOException("Stream unsupported");
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {86, 140, 110, 100, 144, 110, 100, 176, 105, 103, 109, 106, 105, 142, 142, 109, 116, 146, 168, 127, 10, 111, 101, 176, 109, 176, 118, 113, 113, 113, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readHeader()
    {
      ((Buffer) this.headerBuffer).rewind();
      int num1 = ((InputStream) this.@in).read();
      if (num1 < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException("Stream ended prematurely");
      }
      int num2 = ((InputStream) this.@in).read();
      if (num2 < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException("Stream ended prematurely");
      }
      int num3 = (int) (sbyte) (num1 & (int) byte.MaxValue);
      LZ4FrameOutputStream.FLG flg = LZ4FrameOutputStream.FLG.fromByte((byte) num3);
      this.headerBuffer.put((byte) num3);
      int num4 = (int) (sbyte) (num2 & (int) byte.MaxValue);
      LZ4FrameOutputStream.BD bd = LZ4FrameOutputStream.BD.fromByte((byte) num4);
      this.headerBuffer.put((byte) num4);
      this.frameInfo = new LZ4FrameOutputStream.FrameInfo(flg, bd);
      if (flg.isEnabled(LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_SIZE))
      {
        this.expectedContentSize = this.readLong((InputStream) this.@in);
        this.headerBuffer.putLong(this.expectedContentSize);
      }
      this.totalContentSize = 0L;
      int num5 = (int) (sbyte) (this.checksum.hash(this.headerArray, 0, ((Buffer) this.headerBuffer).position(), 0) >> 8 & (int) byte.MaxValue);
      int num6 = ((InputStream) this.@in).read();
      if (num6 < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException("Stream ended prematurely");
      }
      if (num5 != (int) (sbyte) (num6 & (int) byte.MaxValue))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException("Stream frame descriptor corrupted");
      }
      this.maxBlockSize = this.frameInfo.getBD().getBlockMaximumSize();
      this.compressedBuffer = new byte[this.maxBlockSize];
      this.rawBuffer = new byte[this.maxBlockSize];
      this.buffer = ByteBuffer.wrap(this.rawBuffer);
      ((Buffer) this.buffer).limit(0);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {69, 111, 107, 100, 120, 100, 144, 100, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void skippableFrame()
    {
      int num1 = this.readInt((InputStream) this.@in);
      byte[] numArray = new byte[1024];
      int num2;
      for (; num1 > 0; num1 -= num2)
      {
        num2 = ((InputStream) this.@in).read(numArray, 0, Math.min(num1, numArray.Length));
        if (num2 < 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException("Stream ended prematurely");
        }
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 81, 130, 118, 100, 144, 100, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int readInt([In] InputStream obj0)
    {
      int num1 = 0;
      do
      {
        int num2 = obj0.read(this.readNumberBuff.array(), num1, 4 - num1);
        if (num2 < 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException("Stream ended prematurely");
        }
        num1 += num2;
      }
      while (num1 < 4);
      return this.readNumberBuff.getInt(0);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 69, 130, 118, 100, 144, 100, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private long readLong([In] InputStream obj0)
    {
      int num1 = 0;
      do
      {
        int num2 = obj0.read(this.readNumberBuff.array(), num1, 8 - num1);
        if (num2 < 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException("Stream ended prematurely");
        }
        num1 += num2;
      }
      while (num1 < 8);
      return this.readNumberBuff.getLong(0);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 99, 111, 110, 168, 102, 114, 111, 110, 176, 127, 1, 144, 107, 193, 99, 137, 135, 105, 191, 24, 99, 101, 118, 101, 144, 103, 162, 114, 112, 115, 240, 69, 131, 191, 19, 2, 98, 173, 131, 114, 148, 112, 110, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readBlock()
    {
      int num1 = this.readInt((InputStream) this.@in);
      int num2 = (num1 & int.MinValue) != 0 ? 0 : 1;
      int i2 = num1 & int.MaxValue;
      if (i2 == 0)
      {
        if (this.frameInfo.isEnabled(LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_CHECKSUM) && this.readInt((InputStream) this.@in) != this.frameInfo.currentStreamHash())
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException("Content checksum mismatch");
        }
        if (this.frameInfo.isEnabled(LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_SIZE) && this.expectedContentSize != this.totalContentSize)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException("Size check mismatch");
        }
        this.frameInfo.finish();
      }
      else
      {
        byte[] numArray = num2 == 0 ? this.rawBuffer : this.compressedBuffer;
        if (i2 > this.maxBlockSize)
        {
          string str = String.format((Locale) Locale.ROOT, "Block size %s exceeded max: %s", new object[2]
          {
            (object) Integer.valueOf(i2),
            (object) Integer.valueOf(this.maxBlockSize)
          });
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException(str);
        }
        int num3;
        for (int index = 0; index < i2; index += num3)
        {
          num3 = ((InputStream) this.@in).read(numArray, index, i2 - index);
          if (num3 < 0)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IOException("Stream ended prematurely");
          }
        }
        if (this.frameInfo.isEnabled(LZ4FrameOutputStream.FLG.Bits.__\u003C\u003EBLOCK_CHECKSUM) && this.readInt((InputStream) this.@in) != this.checksum.hash(numArray, 0, i2, 0))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException("Block checksum mismatch");
        }
        int num4;
        if (num2 != 0)
        {
          LZ4Exception lz4Exception1;
          try
          {
            num4 = this.decompressor.decompress(numArray, 0, i2, this.rawBuffer, 0, this.rawBuffer.Length);
            goto label_20;
          }
          catch (LZ4Exception ex)
          {
            lz4Exception1 = (LZ4Exception) ByteCodeHelper.MapException<LZ4Exception>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
          LZ4Exception lz4Exception2 = lz4Exception1;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException((Exception) lz4Exception2);
        }
        num4 = i2;
label_20:
        if (this.frameInfo.isEnabled(LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_CHECKSUM))
          this.frameInfo.updateStreamHash(this.rawBuffer, 0, num4);
        this.totalContentSize += (long) num4;
        ((Buffer) this.buffer).limit(num4);
        ((Buffer) this.buffer).rewind();
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {21, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4FrameInputStream(InputStream @in)
      : this(@in, LZ4Factory.fastestInstance().safeDecompressor(), XXHashFactory.fastestInstance().hash32())
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 165, 109, 109, 104, 162, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int read()
    {
      while (((Buffer) this.buffer).remaining() == 0)
      {
        if (this.frameInfo.isFinished() && !this.nextFrameInfo())
          return -1;
        this.readBlock();
      }
      return (int) (sbyte) this.buffer.get() & (int) byte.MaxValue;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 178, 111, 139, 109, 109, 104, 162, 136, 115, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int read(byte[] b, int off, int len)
    {
      if (off < 0 || len < 0 || off + len > b.Length)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException();
      }
      while (((Buffer) this.buffer).remaining() == 0)
      {
        if (this.frameInfo.isFinished() && !this.nextFrameInfo())
          return -1;
        this.readBlock();
      }
      len = Math.min(len, ((Buffer) this.buffer).remaining());
      this.buffer.get(b, off, len);
      return len;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 196, 101, 131, 109, 109, 104, 163, 136, 116, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long skip(long n)
    {
      if (n <= 0L)
        return 0;
      while (((Buffer) this.buffer).remaining() == 0)
      {
        if (this.frameInfo.isFinished() && !this.nextFrameInfo())
          return 0;
        this.readBlock();
      }
      n = Math.min(n, (long) ((Buffer) this.buffer).remaining());
      ((Buffer) this.buffer).position(((Buffer) this.buffer).position() + (int) n);
      return n;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(328)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int available() => ((Buffer) this.buffer).remaining();

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 219, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void close() => base.close();

    [LineNumberTable(338)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void mark(int readlimit)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException("mark not supported");
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(343)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException("reset not supported");
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool markSupported() => false;
  }
}
