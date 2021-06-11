// Decompiled with JetBrains decompiler
// Type: arc.util.io.Writes
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
  public class Writes : Object, Closeable, AutoCloseable
  {
    private static Writes instance;
    public DataOutput output;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 153, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Writes(DataOutput output)
    {
      Writes writes = this;
      this.output = output;
    }

    [LineNumberTable(new byte[] {159, 158, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Writes get(DataOutput output)
    {
      Writes.instance.output = output;
      return Writes.instance;
    }

    [LineNumberTable(new byte[] {28, 191, 0, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void f(float f)
    {
      IOException ioException1;
      try
      {
        this.output.writeFloat(f);
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

    [LineNumberTable(new byte[] {159, 183, 190, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void b(int i)
    {
      IOException ioException1;
      try
      {
        this.output.writeByte(i);
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

    [LineNumberTable(new byte[] {37, 191, 0, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void d(double d)
    {
      IOException ioException1;
      try
      {
        this.output.writeDouble(d);
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

    [LineNumberTable(new byte[] {159, 127, 162, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void @bool(bool b) => this.b(!b ? 0 : 1);

    [LineNumberTable(new byte[] {159, 174, 190, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void i(int i)
    {
      IOException ioException1;
      try
      {
        this.output.writeInt(i);
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

    [LineNumberTable(new byte[] {19, 190, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void s(int i)
    {
      IOException ioException1;
      try
      {
        this.output.writeShort(i);
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

    [LineNumberTable(new byte[] {159, 165, 190, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void l(long i)
    {
      IOException ioException1;
      try
      {
        this.output.writeLong(i);
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

    [LineNumberTable(new byte[] {8, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void b(byte[] array) => this.b(array, 0, array.Length);

    [LineNumberTable(new byte[] {46, 190, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void str(string str)
    {
      IOException ioException1;
      try
      {
        this.output.writeUTF(str);
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

    [LineNumberTable(new byte[] {0, 191, 1, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void b(byte[] array, int offset, int length)
    {
      IOException ioException1;
      try
      {
        this.output.write(array, 0, length);
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

    [LineNumberTable(new byte[] {54, 141, 191, 3, 2, 97, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void close()
    {
      if (this.output is Closeable)
      {
        IOException ioException1;
        try
        {
          ((Closeable) this.output).close();
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
    static Writes()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.io.Writes"))
        return;
      Writes.instance = new Writes((DataOutput) null);
    }

    void IDisposable.__\u003Coverridestub\u003Ejava\u002Elang\u002EAutoCloseable\u003A\u003Aclose() => this.close();
  }
}
