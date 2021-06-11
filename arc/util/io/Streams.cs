// Decompiled with JetBrains decompiler
// Type: arc.util.io.Streams
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
  public sealed class Streams : Object
  {
    public const int DEFAULT_BUFFER_SIZE = 4096;
    internal static byte[] __\u003C\u003EEMPTY_BYTES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {70, 131, 151, 34, 161})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void close(Closeable c)
    {
      if (c == null)
        return;
      try
      {
        c.close();
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {34, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] copyBytes(InputStream input, int estimatedSize)
    {
      Streams.OptimizedByteArrayOutputStream arrayOutputStream = new Streams.OptimizedByteArrayOutputStream(Math.max(0, estimatedSize));
      Streams.copy(input, (OutputStream) arrayOutputStream);
      return ((ByteArrayOutputStream) arrayOutputStream).toByteArray();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 160, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void copy(InputStream input, OutputStream output) => Streams.copy(input, output, new byte[4096]);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string copyString(InputStream input, int estimatedSize) => Streams.copyString(input, estimatedSize, (string) null);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 177, 108, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void copy(InputStream input, OutputStream output, byte[] buffer)
    {
      int num;
      while ((num = input.read(buffer)) != -1)
        output.write(buffer, 0, num);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {14, 105, 108, 105, 100, 140, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int copy(InputStream input, ByteBuffer output, byte[] buffer)
    {
      int num1 = ((Buffer) output).position();
      int num2 = 0;
      int numElements;
      while ((numElements = input.read(buffer)) != -1)
      {
        Buffers.copy(buffer, 0, (Buffer) output, numElements);
        num2 += numElements;
        ((Buffer) output).position(num1 + num2);
      }
      ((Buffer) output).position(num1);
      return num2;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {58, 115, 109, 139, 108, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string copyString(InputStream input, int estimatedSize, string charset)
    {
      InputStreamReader inputStreamReader = charset != null ? new InputStreamReader(input, charset) : new InputStreamReader(input);
      StringWriter stringWriter = new StringWriter(Math.max(0, estimatedSize));
      char[] chArray = new char[4096];
      int num;
      while ((num = ((Reader) inputStreamReader).read(chArray)) != -1)
        stringWriter.write(chArray, 0, num);
      return stringWriter.toString();
    }

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Streams()
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 168, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void copy(InputStream input, OutputStream output, int bufferSize) => Streams.copy(input, output, new byte[bufferSize]);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 187, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void copy(InputStream input, ByteBuffer output) => Streams.copy(input, output, new byte[4096]);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {3, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void copy(InputStream input, ByteBuffer output, int bufferSize) => Streams.copy(input, output, new byte[bufferSize]);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] copyBytes(InputStream input) => Streams.copyBytes(input, input.available());

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(94)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string copyString(InputStream input) => Streams.copyString(input, input.available(), (string) null);

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Streams()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.io.Streams"))
        return;
      Streams.__\u003C\u003EEMPTY_BYTES = new byte[0];
    }

    [Modifiers]
    public static byte[] EMPTY_BYTES
    {
      [HideFromJava] get => Streams.__\u003C\u003EEMPTY_BYTES;
    }

    public class OptimizedByteArrayOutputStream : ByteArrayOutputStream
    {
      [LineNumberTable(new byte[] {81, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public OptimizedByteArrayOutputStream(int initialSize)
        : base(initialSize)
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual byte[] getBuffer() => (byte[]) this.buf;

      [LineNumberTable(new byte[] {86, 118})]
      [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
      public virtual byte[] toByteArray() => this.count == this.buf.Length ? (byte[]) this.buf : base.toByteArray();
    }
  }
}
