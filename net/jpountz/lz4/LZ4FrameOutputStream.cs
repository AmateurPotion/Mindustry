// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4FrameOutputStream
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
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
  public class LZ4FrameOutputStream : FilterOutputStream
  {
    internal const int INTEGER_BYTES = 4;
    internal const int LONG_BYTES = 8;
    internal const int MAGIC = 407708164;
    internal const int LZ4_MAX_HEADER_LENGTH = 15;
    internal const int LZ4_FRAME_INCOMPRESSIBLE_MASK = -2147483648;
    [Modifiers]
    internal static LZ4FrameOutputStream.FLG.Bits[] DEFAULT_FEATURES;
    internal const string CLOSED_STREAM = "The stream is already closed";
    [Modifiers]
    private LZ4Compressor compressor;
    [Modifiers]
    private XXHash32 checksum;
    [Modifiers]
    private ByteBuffer buffer;
    [Modifiers]
    private byte[] compressedBuffer;
    [Modifiers]
    private int maxBlockSize;
    [Modifiers]
    private long knownSize;
    [Modifiers]
    private ByteBuffer intLEBuffer;
    private LZ4FrameOutputStream.FrameInfo frameInfo;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {66, 233, 35, 150, 231, 92, 112, 112, 122, 118, 123, 124, 124, 144, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4FrameOutputStream(
      OutputStream @out,
      LZ4FrameOutputStream.BLOCKSIZE blockSize,
      long knownSize,
      params LZ4FrameOutputStream.FLG.Bits[] bits)
      : base(@out)
    {
      LZ4FrameOutputStream frameOutputStream = this;
      this.intLEBuffer = ByteBuffer.allocate(4).order((ByteOrder) ByteOrder.LITTLE_ENDIAN);
      this.frameInfo = (LZ4FrameOutputStream.FrameInfo) null;
      this.compressor = LZ4Factory.fastestInstance().fastCompressor();
      this.checksum = XXHashFactory.fastestInstance().hash32();
      this.frameInfo = new LZ4FrameOutputStream.FrameInfo(new LZ4FrameOutputStream.FLG(1, bits), new LZ4FrameOutputStream.BD(blockSize, (LZ4FrameOutputStream.\u0031) null));
      this.maxBlockSize = this.frameInfo.getBD().getBlockMaximumSize();
      this.buffer = ByteBuffer.allocate(this.maxBlockSize).order((ByteOrder) ByteOrder.LITTLE_ENDIAN);
      this.compressedBuffer = new byte[this.compressor.maxCompressedLength(this.maxBlockSize)];
      if (this.frameInfo.getFLG().isEnabled(LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_SIZE) && knownSize < 0L)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Known size must be greater than zero in order to use the known size feature");
      }
      this.knownSize = knownSize;
      this.writeHeader();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {111, 114, 108, 120, 120, 114, 173, 127, 5, 137, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void writeHeader()
    {
      ByteBuffer byteBuffer = ByteBuffer.allocate(15).order((ByteOrder) ByteOrder.LITTLE_ENDIAN);
      byteBuffer.putInt(407708164);
      byteBuffer.put(this.frameInfo.getFLG().toByte());
      byteBuffer.put(this.frameInfo.getBD().toByte());
      if (this.frameInfo.isEnabled(LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_SIZE))
        byteBuffer.putLong(this.knownSize);
      int num = this.checksum.hash(byteBuffer.array(), 4, ((Buffer) byteBuffer).position() - 4, 0) >> 8 & (int) byte.MaxValue;
      byteBuffer.put((byte) num);
      ((OutputStream) this.@out).write(byteBuffer.array(), 0, ((Buffer) byteBuffer).position());
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {53, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4FrameOutputStream(
      OutputStream @out,
      LZ4FrameOutputStream.BLOCKSIZE blockSize,
      params LZ4FrameOutputStream.FLG.Bits[] bits)
      : this(@out, blockSize, -1L, bits)
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {90, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4FrameOutputStream(OutputStream @out, LZ4FrameOutputStream.BLOCKSIZE blockSize)
      : this(@out, blockSize, LZ4FrameOutputStream.DEFAULT_FEATURES)
    {
    }

    [LineNumberTable(new byte[] {160, 169, 109, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void ensureNotFinished()
    {
      if (this.frameInfo.isFinished())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("The stream is already closed");
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 68, 109, 161, 140, 255, 11, 69, 110, 108, 114, 136, 103, 194, 112, 118, 174, 114, 124, 150, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void writeBlock()
    {
      if (((Buffer) this.buffer).position() == 0)
        return;
      Arrays.fill(this.compressedBuffer, (byte) 0);
      int i2 = this.compressor.compress(this.buffer.array(), 0, ((Buffer) this.buffer).position(), this.compressedBuffer, 0);
      byte[] barr;
      int num;
      if (i2 >= ((Buffer) this.buffer).position())
      {
        i2 = ((Buffer) this.buffer).position();
        barr = Arrays.copyOf(this.buffer.array(), i2);
        num = int.MinValue;
      }
      else
      {
        barr = this.compressedBuffer;
        num = 0;
      }
      this.intLEBuffer.putInt(0, i2 | num);
      ((OutputStream) this.@out).write(this.intLEBuffer.array());
      ((OutputStream) this.@out).write(barr, 0, i2);
      if (this.frameInfo.isEnabled(LZ4FrameOutputStream.FLG.Bits.__\u003C\u003EBLOCK_CHECKSUM))
      {
        this.intLEBuffer.putInt(0, this.checksum.hash(barr, 0, i2, 0));
        ((OutputStream) this.@out).write(this.intLEBuffer.array());
      }
      ((Buffer) this.buffer).rewind();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 159, 109, 134, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void flush()
    {
      if (!this.frameInfo.isFinished())
        this.writeBlock();
      base.flush();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 108, 110, 118, 114, 120, 150, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void writeEndMark()
    {
      this.intLEBuffer.putInt(0, 0);
      ((OutputStream) this.@out).write(this.intLEBuffer.array());
      if (this.frameInfo.isEnabled(LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_CHECKSUM))
      {
        this.intLEBuffer.putInt(0, this.frameInfo.currentStreamHash());
        ((OutputStream) this.@out).write(this.intLEBuffer.array());
      }
      this.frameInfo.finish();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4FrameOutputStream(OutputStream @out)
      : this(@out, LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_4MB)
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 119, 102, 115, 134, 142, 114, 152})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(int b)
    {
      this.ensureNotFinished();
      if (((Buffer) this.buffer).position() == this.maxBlockSize)
        this.writeBlock();
      this.buffer.put((byte) b);
      if (!this.frameInfo.isEnabled(LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_CHECKSUM))
        return;
      this.frameInfo.updateStreamHash(new byte[1]
      {
        (byte) b
      }, 0, 1);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 132, 111, 139, 166, 110, 140, 111, 114, 142, 134, 101, 101, 98, 143, 114, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(byte[] b, int off, int len)
    {
      if (off < 0 || len < 0 || off + len > b.Length)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException();
      }
      this.ensureNotFinished();
      int num;
      for (; len > ((Buffer) this.buffer).remaining(); len -= num)
      {
        num = ((Buffer) this.buffer).remaining();
        this.buffer.put(b, off, num);
        if (this.frameInfo.isEnabled(LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_CHECKSUM))
          this.frameInfo.updateStreamHash(b, off, num);
        this.writeBlock();
        off += num;
      }
      this.buffer.put(b, off, len);
      if (!this.frameInfo.isEnabled(LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_CHECKSUM))
        return;
      this.frameInfo.updateStreamHash(b, off, len);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 176, 109, 102, 134, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void close()
    {
      if (!this.frameInfo.isFinished())
      {
        this.flush();
        this.writeEndMark();
      }
      base.close();
    }

    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LZ4FrameOutputStream()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4FrameOutputStream"))
        return;
      LZ4FrameOutputStream.DEFAULT_FEATURES = new LZ4FrameOutputStream.FLG.Bits[1]
      {
        LZ4FrameOutputStream.FLG.Bits.__\u003C\u003EBLOCK_INDEPENDENCE
      };
    }

    [InnerClass]
    [EnclosingMethod("net.jpountz.lz4.LZ4FrameOutputStream", null, null)]
    [Modifiers]
    internal class \u0031 : Object
    {
      \u0031() => throw null;
    }

    public class BD : Object
    {
      private const int RESERVED_MASK = 143;
      [Modifiers]
      private LZ4FrameOutputStream.BLOCKSIZE blockSizeValue;

      [LineNumberTable(new byte[] {159, 48, 99, 102, 106, 176})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static LZ4FrameOutputStream.BD fromByte(byte bd)
      {
        int num = (int) (sbyte) bd;
        int indicator = (int) ((uint) num >> 4) & 7;
        if ((num & 143) > 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Reserved fields must be 0");
        }
        return new LZ4FrameOutputStream.BD(LZ4FrameOutputStream.BLOCKSIZE.valueOf(indicator));
      }

      [LineNumberTable(387)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getBlockMaximumSize() => 1 << 2 * this.blockSizeValue.getIndicator() + 8;

      [Modifiers]
      [LineNumberTable(367)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal BD([In] LZ4FrameOutputStream.BLOCKSIZE obj0, [In] LZ4FrameOutputStream.\u0031 obj1)
        : this(obj0)
      {
      }

      [LineNumberTable(391)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual byte toByte() => (byte) ((this.blockSizeValue.getIndicator() & 7) << 4);

      [LineNumberTable(new byte[] {161, 2, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private BD([In] LZ4FrameOutputStream.BLOCKSIZE obj0)
      {
        LZ4FrameOutputStream.BD bd = this;
        this.blockSizeValue = obj0;
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lnet/jpountz/lz4/LZ4FrameOutputStream$BLOCKSIZE;>;")]
    [Modifiers]
    [Serializable]
    public sealed class BLOCKSIZE : Enum
    {
      [Modifiers]
      internal static LZ4FrameOutputStream.BLOCKSIZE __\u003C\u003ESIZE_64KB;
      [Modifiers]
      internal static LZ4FrameOutputStream.BLOCKSIZE __\u003C\u003ESIZE_256KB;
      [Modifiers]
      internal static LZ4FrameOutputStream.BLOCKSIZE __\u003C\u003ESIZE_1MB;
      [Modifiers]
      internal static LZ4FrameOutputStream.BLOCKSIZE __\u003C\u003ESIZE_4MB;
      [Modifiers]
      private int indicator;
      [Modifiers]
      private static LZ4FrameOutputStream.BLOCKSIZE[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {21, 122, 102, 102, 102, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static LZ4FrameOutputStream.BLOCKSIZE valueOf(int indicator)
      {
        switch (indicator)
        {
          case 4:
            return LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_64KB;
          case 5:
            return LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_256KB;
          case 6:
            return LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_1MB;
          case 7:
            return LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_4MB;
          default:
            string str = String.format((Locale) Locale.ROOT, "Block size must be 4-7. Cannot use value of [%d]", new object[1]
            {
              (object) Integer.valueOf(indicator)
            });
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str);
        }
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getIndicator() => this.indicator;

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {14, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private BLOCKSIZE([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        LZ4FrameOutputStream.BLOCKSIZE blocksize = this;
        this.indicator = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(61)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static LZ4FrameOutputStream.BLOCKSIZE[] values() => (LZ4FrameOutputStream.BLOCKSIZE[]) LZ4FrameOutputStream.BLOCKSIZE.\u0024VALUES.Clone();

      [LineNumberTable(61)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static LZ4FrameOutputStream.BLOCKSIZE valueOf(string name) => (LZ4FrameOutputStream.BLOCKSIZE) Enum.valueOf((Class) ClassLiteral<LZ4FrameOutputStream.BLOCKSIZE>.Value, name);

      [LineNumberTable(new byte[] {159, 127, 141, 63, 37})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static BLOCKSIZE()
      {
        if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4FrameOutputStream$BLOCKSIZE"))
          return;
        LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_64KB = new LZ4FrameOutputStream.BLOCKSIZE(nameof (SIZE_64KB), 0, 4);
        LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_256KB = new LZ4FrameOutputStream.BLOCKSIZE(nameof (SIZE_256KB), 1, 5);
        LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_1MB = new LZ4FrameOutputStream.BLOCKSIZE(nameof (SIZE_1MB), 2, 6);
        LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_4MB = new LZ4FrameOutputStream.BLOCKSIZE(nameof (SIZE_4MB), 3, 7);
        LZ4FrameOutputStream.BLOCKSIZE.\u0024VALUES = new LZ4FrameOutputStream.BLOCKSIZE[4]
        {
          LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_64KB,
          LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_256KB,
          LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_1MB,
          LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_4MB
        };
      }

      [Modifiers]
      public static LZ4FrameOutputStream.BLOCKSIZE SIZE_64KB
      {
        [HideFromJava] get => LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_64KB;
      }

      [Modifiers]
      public static LZ4FrameOutputStream.BLOCKSIZE SIZE_256KB
      {
        [HideFromJava] get => LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_256KB;
      }

      [Modifiers]
      public static LZ4FrameOutputStream.BLOCKSIZE SIZE_1MB
      {
        [HideFromJava] get => LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_1MB;
      }

      [Modifiers]
      public static LZ4FrameOutputStream.BLOCKSIZE SIZE_4MB
      {
        [HideFromJava] get => LZ4FrameOutputStream.BLOCKSIZE.__\u003C\u003ESIZE_4MB;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        SIZE_64KB,
        SIZE_256KB,
        SIZE_1MB,
        SIZE_4MB,
      }
    }

    public class FLG : Object
    {
      private const int DEFAULT_VERSION = 1;
      [Modifiers]
      private BitSet bitSet;
      [Modifiers]
      private int version;

      [LineNumberTable(new byte[] {159, 59, 163, 105})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static LZ4FrameOutputStream.FLG fromByte(byte flg)
      {
        int num1 = (int) (sbyte) flg;
        int num2 = (int) (sbyte) (num1 & 192);
        return new LZ4FrameOutputStream.FLG((int) ((uint) num2 >> 6), (byte) (num1 ^ num2));
      }

      [LineNumberTable(359)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isEnabled(LZ4FrameOutputStream.FLG.Bits bit) => this.bitSet.get(LZ4FrameOutputStream.FLG.Bits.access\u0024100(bit));

      [LineNumberTable(new byte[] {160, 203, 104, 108, 103, 99, 112, 50, 198, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FLG(int version, params LZ4FrameOutputStream.FLG.Bits[] bits)
      {
        LZ4FrameOutputStream.FLG flg = this;
        this.bitSet = new BitSet(8);
        this.version = version;
        if (bits != null)
        {
          LZ4FrameOutputStream.FLG.Bits[] bitsArray = bits;
          int length = bitsArray.Length;
          for (int index = 0; index < length; ++index)
            this.bitSet.set(LZ4FrameOutputStream.FLG.Bits.access\u0024100(bitsArray[index]));
        }
        this.validate();
      }

      [LineNumberTable(340)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual byte toByte() => (byte) ((int) (sbyte) this.bitSet.toByteArray()[0] | (this.version & 3) << 6);

      [LineNumberTable(new byte[] {160, 230, 119, 144, 119, 144, 119, 144, 105, 159, 15})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void validate()
      {
        if (this.bitSet.get(LZ4FrameOutputStream.FLG.Bits.access\u0024100(LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ERESERVED_0)))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Reserved0 field must be 0");
        }
        if (this.bitSet.get(LZ4FrameOutputStream.FLG.Bits.access\u0024100(LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ERESERVED_1)))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Reserved1 field must be 0");
        }
        if (!this.bitSet.get(LZ4FrameOutputStream.FLG.Bits.access\u0024100(LZ4FrameOutputStream.FLG.Bits.__\u003C\u003EBLOCK_INDEPENDENCE)))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Dependent block stream is unsupported (BLOCK_INDEPENDENCE must be set)");
        }
        if (this.version != 1)
        {
          string str = String.format((Locale) Locale.ROOT, "Version %d is unsupported", new object[1]
          {
            (object) Integer.valueOf(this.version)
          });
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException(str);
        }
      }

      [LineNumberTable(new byte[] {159, 60, 67, 104, 117, 103, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private FLG([In] int obj0, [In] byte obj1)
      {
        int num = (int) (sbyte) obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        LZ4FrameOutputStream.FLG flg = this;
        this.bitSet = BitSet.valueOf(new byte[1]
        {
          (byte) num
        });
        this.version = obj0;
        this.validate();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getVersion() => this.version;

      [InnerClass]
      [Signature("Ljava/lang/Enum<Lnet/jpountz/lz4/LZ4FrameOutputStream$FLG$Bits;>;")]
      [Modifiers]
      [Serializable]
      public sealed class Bits : Enum
      {
        [Modifiers]
        internal static LZ4FrameOutputStream.FLG.Bits __\u003C\u003ERESERVED_0;
        [Modifiers]
        internal static LZ4FrameOutputStream.FLG.Bits __\u003C\u003ERESERVED_1;
        [Modifiers]
        internal static LZ4FrameOutputStream.FLG.Bits __\u003C\u003ECONTENT_CHECKSUM;
        [Modifiers]
        internal static LZ4FrameOutputStream.FLG.Bits __\u003C\u003ECONTENT_SIZE;
        [Modifiers]
        internal static LZ4FrameOutputStream.FLG.Bits __\u003C\u003EBLOCK_CHECKSUM;
        [Modifiers]
        internal static LZ4FrameOutputStream.FLG.Bits __\u003C\u003EBLOCK_INDEPENDENCE;
        [Modifiers]
        private int position;
        [Modifiers]
        private static LZ4FrameOutputStream.FLG.Bits[] \u0024VALUES;

        [SpecialName]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void __\u003Cclinit\u003E()
        {
        }

        [Signature("(I)V")]
        [LineNumberTable(new byte[] {160, 198, 106, 103})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        private Bits([In] string obj0, [In] int obj1, [In] int obj2)
          : base(obj0, obj1)
        {
          LZ4FrameOutputStream.FLG.Bits bits = this;
          this.position = obj2;
          GC.KeepAlive((object) this);
        }

        [LineNumberTable(303)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static LZ4FrameOutputStream.FLG.Bits[] values() => (LZ4FrameOutputStream.FLG.Bits[]) LZ4FrameOutputStream.FLG.Bits.\u0024VALUES.Clone();

        [LineNumberTable(303)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static LZ4FrameOutputStream.FLG.Bits valueOf(string name) => (LZ4FrameOutputStream.FLG.Bits) Enum.valueOf((Class) ClassLiteral<LZ4FrameOutputStream.FLG.Bits>.Value, name);

        [Modifiers]
        [LineNumberTable(303)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static int access\u0024100([In] LZ4FrameOutputStream.FLG.Bits obj0) => obj0.position;

        [LineNumberTable(new byte[] {159, 66, 77, 113, 113, 113, 113, 113, 241, 58})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        static Bits()
        {
          if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4FrameOutputStream$FLG$Bits"))
            return;
          LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ERESERVED_0 = new LZ4FrameOutputStream.FLG.Bits(nameof (RESERVED_0), 0, 0);
          LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ERESERVED_1 = new LZ4FrameOutputStream.FLG.Bits(nameof (RESERVED_1), 1, 1);
          LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_CHECKSUM = new LZ4FrameOutputStream.FLG.Bits(nameof (CONTENT_CHECKSUM), 2, 2);
          LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_SIZE = new LZ4FrameOutputStream.FLG.Bits(nameof (CONTENT_SIZE), 3, 3);
          LZ4FrameOutputStream.FLG.Bits.__\u003C\u003EBLOCK_CHECKSUM = new LZ4FrameOutputStream.FLG.Bits(nameof (BLOCK_CHECKSUM), 4, 4);
          LZ4FrameOutputStream.FLG.Bits.__\u003C\u003EBLOCK_INDEPENDENCE = new LZ4FrameOutputStream.FLG.Bits(nameof (BLOCK_INDEPENDENCE), 5, 5);
          LZ4FrameOutputStream.FLG.Bits.\u0024VALUES = new LZ4FrameOutputStream.FLG.Bits[6]
          {
            LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ERESERVED_0,
            LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ERESERVED_1,
            LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_CHECKSUM,
            LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_SIZE,
            LZ4FrameOutputStream.FLG.Bits.__\u003C\u003EBLOCK_CHECKSUM,
            LZ4FrameOutputStream.FLG.Bits.__\u003C\u003EBLOCK_INDEPENDENCE
          };
        }

        [Modifiers]
        public static LZ4FrameOutputStream.FLG.Bits RESERVED_0
        {
          [HideFromJava] get => LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ERESERVED_0;
        }

        [Modifiers]
        public static LZ4FrameOutputStream.FLG.Bits RESERVED_1
        {
          [HideFromJava] get => LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ERESERVED_1;
        }

        [Modifiers]
        public static LZ4FrameOutputStream.FLG.Bits CONTENT_CHECKSUM
        {
          [HideFromJava] get => LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_CHECKSUM;
        }

        [Modifiers]
        public static LZ4FrameOutputStream.FLG.Bits CONTENT_SIZE
        {
          [HideFromJava] get => LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_SIZE;
        }

        [Modifiers]
        public static LZ4FrameOutputStream.FLG.Bits BLOCK_CHECKSUM
        {
          [HideFromJava] get => LZ4FrameOutputStream.FLG.Bits.__\u003C\u003EBLOCK_CHECKSUM;
        }

        [Modifiers]
        public static LZ4FrameOutputStream.FLG.Bits BLOCK_INDEPENDENCE
        {
          [HideFromJava] get => LZ4FrameOutputStream.FLG.Bits.__\u003C\u003EBLOCK_INDEPENDENCE;
        }

        [HideFromJava]
        [Serializable]
        public enum __Enum
        {
          RESERVED_0,
          RESERVED_1,
          CONTENT_CHECKSUM,
          CONTENT_SIZE,
          BLOCK_CHECKSUM,
          BLOCK_INDEPENDENCE,
        }
      }
    }

    internal class FrameInfo : Object
    {
      [Modifiers]
      private LZ4FrameOutputStream.FLG flg;
      [Modifiers]
      private LZ4FrameOutputStream.BD bd;
      [Modifiers]
      private StreamingXXHash32 streamHash;
      private bool finished;

      [LineNumberTable(new byte[] {161, 31, 8, 167, 103, 103, 127, 2})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FrameInfo([In] LZ4FrameOutputStream.FLG obj0, [In] LZ4FrameOutputStream.BD obj1)
      {
        LZ4FrameOutputStream.FrameInfo frameInfo = this;
        this.finished = false;
        this.flg = obj0;
        this.bd = obj1;
        this.streamHash = !obj0.isEnabled(LZ4FrameOutputStream.FLG.Bits.__\u003C\u003ECONTENT_CHECKSUM) ? (StreamingXXHash32) null : XXHashFactory.fastestInstance().newStreamingHash32(0);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual LZ4FrameOutputStream.BD getBD() => this.bd;

      [LineNumberTable(408)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isEnabled([In] LZ4FrameOutputStream.FLG.Bits obj0) => this.flg.isEnabled(obj0);

      [LineNumberTable(424)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int currentStreamHash() => this.streamHash.getValue();

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void finish() => this.finished = true;

      [LineNumberTable(new byte[] {161, 50, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void updateStreamHash([In] byte[] obj0, [In] int obj1, [In] int obj2) => this.streamHash.update(obj0, obj1, obj2);

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isFinished() => this.finished;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual LZ4FrameOutputStream.FLG getFLG() => this.flg;
    }
  }
}
