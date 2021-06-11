// Decompiled with JetBrains decompiler
// Type: arc.graphics.PixmapIO
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.nio;
using java.util.zip;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics
{
  public class PixmapIO : Object
  {
    [LineNumberTable(new byte[] {159, 169, 159, 6, 103, 151, 102, 55, 104, 182, 2, 98, 159, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writePNG(Fi file, Pixmap pixmap)
    {
      PixmapIO.PNG png;
      Exception exception1;
      IOException ioException1;
      try
      {
        PixmapIO.PNG.__\u003Cclinit\u003E();
        png = new PixmapIO.PNG(ByteCodeHelper.f2i((float) (pixmap.getWidth() * pixmap.getHeight()) * 1.5f));
        try
        {
          png.setFlipY(false);
          png.write(file, pixmap);
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_5;
        }
        png.dispose();
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_6;
      }
label_5:
      Exception exception2 = exception1;
      IOException ioException2;
      try
      {
        Exception exception3 = exception2;
        png.dispose();
        throw Throwable.__\u003Cunmap\u003E(exception3);
      }
      catch (IOException ex)
      {
        ioException2 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException3 = ioException2;
      goto label_10;
label_6:
      ioException3 = ioException1;
label_10:
      IOException ioException4 = ioException3;
      string message = new StringBuilder().append("Error writing PNG: ").append((object) file).toString();
      IOException ioException5 = ioException4;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException(message, (Exception) ioException5);
    }

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PixmapIO()
    {
    }

    public class PNG : Object, Disposable
    {
      [Modifiers]
      private static byte[] SIGNATURE;
      private const int IHDR = 1229472850;
      private const int IDAT = 1229209940;
      private const int IEND = 1229278788;
      private const byte COLOR_ARGB = 6;
      private const byte COMPRESSION_DEFLATE = 0;
      private const byte FILTER_NONE = 0;
      private const byte INTERLACE_NONE = 0;
      private const byte PAETH = 4;
      [Modifiers]
      private PixmapIO.PNG.ChunkBuffer buffer;
      [Modifiers]
      private Deflater deflater;
      private ByteSeq lineOutBytes;
      private ByteSeq curLineBytes;
      private ByteSeq prevLineBytes;
      private bool flipY;
      private int lastLineLen;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {36, 232, 57, 231, 72, 108, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PNG(int initialBufferSize)
      {
        PixmapIO.PNG png = this;
        this.flipY = true;
        this.buffer = new PixmapIO.PNG.ChunkBuffer(initialBufferSize);
        this.deflater = new Deflater();
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {62, 114, 103, 139, 112, 113, 113, 108, 108, 108, 108, 108, 140, 112, 139, 137, 104, 120, 120, 154, 110, 110, 110, 113, 38, 168, 135, 104, 105, 120, 116, 117, 100, 108, 145, 115, 108, 119, 119, 118, 244, 59, 235, 73, 110, 110, 110, 142, 107, 105, 103, 105, 106, 103, 106, 103, 106, 103, 106, 108, 102, 102, 100, 238, 49, 235, 82, 103, 138, 100, 100, 228, 21, 235, 109, 106, 102, 140, 112, 140, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write(OutputStream output, Pixmap pixmap)
      {
        DeflaterOutputStream deflaterOutputStream = new DeflaterOutputStream((OutputStream) this.buffer, this.deflater);
        DataOutputStream dataOutputStream = new DataOutputStream(output);
        ((FilterOutputStream) dataOutputStream).write(PixmapIO.PNG.SIGNATURE);
        this.buffer.writeInt(1229472850);
        this.buffer.writeInt(pixmap.getWidth());
        this.buffer.writeInt(pixmap.getHeight());
        this.buffer.writeByte(8);
        this.buffer.writeByte(6);
        this.buffer.writeByte(0);
        this.buffer.writeByte(0);
        this.buffer.writeByte(0);
        this.buffer.endChunk(dataOutputStream);
        this.buffer.writeInt(1229209940);
        this.deflater.reset();
        int num1 = pixmap.getWidth() * 4;
        byte[] numArray1;
        byte[] numArray2;
        byte[] numArray3;
        if (this.lineOutBytes == null)
        {
          PixmapIO.PNG png1 = this;
          ByteSeq byteSeq1 = new ByteSeq(num1);
          ByteSeq byteSeq2 = byteSeq1;
          this.lineOutBytes = byteSeq1;
          numArray1 = byteSeq2.items;
          PixmapIO.PNG png2 = this;
          ByteSeq byteSeq3 = new ByteSeq(num1);
          ByteSeq byteSeq4 = byteSeq3;
          this.curLineBytes = byteSeq3;
          numArray2 = byteSeq4.items;
          PixmapIO.PNG png3 = this;
          ByteSeq byteSeq5 = new ByteSeq(num1);
          ByteSeq byteSeq6 = byteSeq5;
          this.prevLineBytes = byteSeq5;
          numArray3 = byteSeq6.items;
        }
        else
        {
          numArray1 = this.lineOutBytes.ensureCapacity(num1);
          numArray2 = this.curLineBytes.ensureCapacity(num1);
          numArray3 = this.prevLineBytes.ensureCapacity(num1);
          int index = 0;
          for (int lastLineLen = this.lastLineLen; index < lastLineLen; ++index)
            numArray3[index] = (byte) 0;
        }
        this.lastLineLen = num1;
        ByteBuffer pixels = pixmap.getPixels();
        int num2 = ((Buffer) pixels).position();
        int num3 = !object.ReferenceEquals((object) pixmap.getFormat(), (object) Pixmap.Format.__\u003C\u003Ergba8888) ? 0 : 1;
        int num4 = 0;
        for (int height = pixmap.getHeight(); num4 < height; ++num4)
        {
          int y = !this.flipY ? num4 : height - num4 - 1;
          if (num3 != 0)
          {
            ((Buffer) pixels).position(y * num1);
            pixels.get(numArray2, 0, num1);
          }
          else
          {
            int x = 0;
            int num5 = 0;
            for (; x < pixmap.getWidth(); ++x)
            {
              int pixel = pixmap.getPixel(x, y);
              byte[] numArray4 = numArray2;
              int index1 = num5;
              int num6 = num5 + 1;
              int num7 = (int) (sbyte) (pixel >> 24 & (int) byte.MaxValue);
              numArray4[index1] = (byte) num7;
              byte[] numArray5 = numArray2;
              int index2 = num6;
              int num8 = num6 + 1;
              int num9 = (int) (sbyte) (pixel >> 16 & (int) byte.MaxValue);
              numArray5[index2] = (byte) num9;
              byte[] numArray6 = numArray2;
              int index3 = num8;
              int num10 = num8 + 1;
              int num11 = (int) (sbyte) (pixel >> 8 & (int) byte.MaxValue);
              numArray6[index3] = (byte) num11;
              byte[] numArray7 = numArray2;
              int index4 = num10;
              num5 = num10 + 1;
              int num12 = (int) (sbyte) (pixel & (int) byte.MaxValue);
              numArray7[index4] = (byte) num12;
            }
          }
          numArray1[0] = (byte) ((int) (sbyte) numArray2[0] - (int) (sbyte) numArray3[0]);
          numArray1[1] = (byte) ((int) (sbyte) numArray2[1] - (int) (sbyte) numArray3[1]);
          numArray1[2] = (byte) ((int) (sbyte) numArray2[2] - (int) (sbyte) numArray3[2]);
          numArray1[3] = (byte) ((int) (sbyte) numArray2[3] - (int) (sbyte) numArray3[3]);
          for (int index = 4; index < num1; ++index)
          {
            int num5 = (int) numArray2[index - 4];
            int num6 = (int) numArray3[index];
            int num7 = (int) numArray3[index - 4];
            int num8 = num5 + num6 - num7;
            int num9 = num8 - num5;
            if (num9 < 0)
              num9 = -num9;
            int num10 = num8 - num6;
            if (num10 < 0)
              num10 = -num10;
            int num11 = num8 - num7;
            if (num11 < 0)
              num11 = -num11;
            if (num9 <= num10 && num9 <= num11)
              num7 = num5;
            else if (num10 <= num11)
              num7 = num6;
            numArray1[index] = (byte) ((int) (sbyte) numArray2[index] - num7);
          }
          deflaterOutputStream.write(4);
          deflaterOutputStream.write(numArray1, 0, num1);
          byte[] numArray8 = numArray2;
          numArray2 = numArray3;
          numArray3 = numArray8;
        }
        ((Buffer) pixels).position(num2);
        deflaterOutputStream.finish();
        this.buffer.endChunk(dataOutputStream);
        this.buffer.writeInt(1229278788);
        this.buffer.endChunk(dataOutputStream);
        output.flush();
      }

      [LineNumberTable(new byte[] {33, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PNG()
        : this(16384)
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setFlipY(bool flipY) => this.flipY = flipY;

      [LineNumberTable(new byte[] {48, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setCompression(int level) => this.deflater.setLevel(level);

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {52, 136, 140, 102, 35, 98, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write(Fi file, Pixmap pixmap)
      {
        OutputStream output = file.write(false);
        try
        {
          this.write(output, pixmap);
        }
        finally
        {
          Streams.close((Closeable) output);
        }
      }

      [LineNumberTable(new byte[] {160, 90, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void dispose() => this.deflater.end();

      [LineNumberTable(68)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static PNG()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.graphics.PixmapIO$PNG"))
          return;
        PixmapIO.PNG.SIGNATURE = new byte[8]
        {
          (byte) 137,
          (byte) 80,
          (byte) 78,
          (byte) 71,
          (byte) 13,
          (byte) 10,
          (byte) 26,
          (byte) 10
        };
      }

      [HideFromJava]
      public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

      internal class ChunkBuffer : DataOutputStream
      {
        [Modifiers]
        internal ByteArrayOutputStream buffer;
        [Modifiers]
        internal CRC32 crc;

        [LineNumberTable(new byte[] {160, 102, 111, 103, 103})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        private ChunkBuffer([In] ByteArrayOutputStream obj0, [In] CRC32 obj1)
          : base((OutputStream) new CheckedOutputStream((OutputStream) obj0, (Checksum) obj1))
        {
          PixmapIO.PNG.ChunkBuffer chunkBuffer = this;
          this.buffer = obj0;
          this.crc = obj1;
        }

        [LineNumberTable(new byte[] {160, 98, 113})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal ChunkBuffer([In] int obj0)
          : this(new ByteArrayOutputStream(obj0), new CRC32())
        {
        }

        [Throws(new string[] {"java.io.IOException"})]
        [LineNumberTable(new byte[] {160, 108, 102, 115, 108, 114, 107, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual void endChunk([In] DataOutputStream obj0)
        {
          this.flush();
          obj0.writeInt(this.buffer.size() - 4);
          this.buffer.writeTo((OutputStream) obj0);
          obj0.writeInt((int) this.crc.getValue());
          this.buffer.reset();
          this.crc.reset();
        }
      }
    }
  }
}
