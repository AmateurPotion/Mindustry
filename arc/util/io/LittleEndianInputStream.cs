// Decompiled with JetBrains decompiler
// Type: arc.util.io.LittleEndianInputStream
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using System.Runtime.CompilerServices;

namespace arc.util.io
{
  [Implements(new string[] {"java.io.DataInput"})]
  public class LittleEndianInputStream : FilterInputStream, DataInput
  {
    private DataInputStream din;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {8, 103, 102, 46, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int readInt()
    {
      int[] numArray = new int[4];
      for (int index = 3; index >= 0; index += -1)
        numArray[index] = ((FilterInputStream) this.din).read();
      return (numArray[0] & (int) byte.MaxValue) << 24 | (numArray[1] & (int) byte.MaxValue) << 16 | (numArray[2] & (int) byte.MaxValue) << 8 | numArray[3] & (int) byte.MaxValue;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {16, 103, 102, 46, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long readLong()
    {
      int[] numArray = new int[8];
      for (int index = 7; index >= 0; index += -1)
        numArray[index] = ((FilterInputStream) this.din).read();
      return (long) (numArray[0] & (int) byte.MaxValue) << 56 | (long) (numArray[1] & (int) byte.MaxValue) << 48 | (long) (numArray[2] & (int) byte.MaxValue) << 40 | (long) (numArray[3] & (int) byte.MaxValue) << 32 | (long) (numArray[4] & (int) byte.MaxValue) << 24 | (long) (numArray[5] & (int) byte.MaxValue) << 16 | (long) (numArray[6] & (int) byte.MaxValue) << 8 | (long) (numArray[7] & (int) byte.MaxValue);
    }

    [LineNumberTable(new byte[] {159, 155, 105, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LittleEndianInputStream(InputStream @in)
      : base(@in)
    {
      LittleEndianInputStream endianInputStream = this;
      this.din = new DataInputStream(@in);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 160, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readFully(byte[] b) => this.din.readFully(b);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 164, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readFully(byte[] b, int off, int len) => this.din.readFully(b, off, len);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int skipBytes(int n) => this.din.skipBytes(n);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool readBoolean() => this.din.readBoolean();

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte readByte() => this.din.readByte();

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int readUnsignedByte() => this.din.readUnsignedByte();

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 184, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short readShort()
    {
      int num = ((FilterInputStream) this.din).read();
      return (short) (((FilterInputStream) this.din).read() << 8 | num & (int) byte.MaxValue);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 190, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int readUnsignedShort()
    {
      int num = ((FilterInputStream) this.din).read();
      return (((FilterInputStream) this.din).read() & (int) byte.MaxValue) << 8 | num & (int) byte.MaxValue;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(54)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual char readChar() => this.din.readChar();

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float readFloat()
    {
      FloatConverter floatConverter;
      return FloatConverter.ToFloat(this.readInt(), ref floatConverter);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double readDouble()
    {
      DoubleConverter doubleConverter;
      return DoubleConverter.ToDouble(this.readLong(), ref doubleConverter);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public string readLine() => this.din.readLine();

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(89)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string readUTF() => this.din.readUTF();
  }
}
