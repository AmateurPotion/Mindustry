// Decompiled with JetBrains decompiler
// Type: arc.util.io.Reads
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace arc.util.io
{
  [Implements(new string[] {"java.io.Closeable"})]
  public class Reads : Object, Closeable, AutoCloseable
  {
    private static Reads instance;
    public DataInput input;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Reads get(DataInput input)
    {
      Reads.instance.input = input;
      return Reads.instance;
    }

    [LineNumberTable(new byte[] {51, 127, 3, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float f()
    {
      float num;
      IOException ioException1;
      try
      {
        num = this.input.readFloat();
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return num;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {9, 127, 3, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte b()
    {
      int num;
      IOException ioException1;
      try
      {
        num = (int) (sbyte) this.input.readByte();
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return (byte) num;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {159, 183, 127, 2, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short s()
    {
      int num;
      IOException ioException1;
      try
      {
        num = (int) this.input.readShort();
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return (short) num;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {42, 127, 2, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool @bool()
    {
      int num;
      IOException ioException1;
      try
      {
        num = this.input.readBoolean() ? 1 : 0;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return num != 0;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {159, 174, 127, 2, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int i()
    {
      int num;
      IOException ioException1;
      try
      {
        num = this.input.readInt();
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return num;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {60, 127, 3, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double d()
    {
      double num;
      IOException ioException1;
      try
      {
        num = this.input.readDouble();
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return num;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {159, 165, 127, 2, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long l()
    {
      long num;
      IOException ioException1;
      try
      {
        num = this.input.readLong();
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return num;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte[] b(byte[] array) => this.b(array, 0, array.Length);

    [LineNumberTable(new byte[] {78, 191, 0, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void skip(int amount)
    {
      IOException ioException1;
      try
      {
        this.input.skipBytes(amount);
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {0, 127, 2, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int us()
    {
      int num;
      IOException ioException1;
      try
      {
        num = this.input.readUnsignedShort();
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return num;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {69, 127, 2, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string str()
    {
      string str;
      IOException ioException1;
      try
      {
        str = this.input.readUTF();
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return str;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {159, 153, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Reads(DataInput input)
    {
      Reads reads = this;
      this.input = input;
    }

    [LineNumberTable(new byte[] {33, 127, 2, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int ub()
    {
      int num;
      IOException ioException1;
      try
      {
        num = this.input.readUnsignedByte();
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return num;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {23, 110, 119, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte[] b(byte[] array, int offset, int length)
    {
      byte[] numArray;
      IOException ioException1;
      try
      {
        this.input.readFully(array, offset, length);
        numArray = array;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return numArray;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {86, 141, 191, 3, 2, 97, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void close()
    {
      if (this.input is Closeable)
      {
        IOException ioException1;
        try
        {
          ((Closeable) this.input).close();
          return;
        }
        catch (IOException ex)
        {
          ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        IOException ioException2 = ioException1;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException((Exception) ioException2);
      }
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Reads()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.io.Reads"))
        return;
      Reads.instance = new Reads((DataInput) null);
    }

    void IDisposable.__\u003Coverridestub\u003Ejava\u002Elang\u002EAutoCloseable\u003A\u003Aclose() => this.close();
  }
}
