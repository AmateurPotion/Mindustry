// Decompiled with JetBrains decompiler
// Type: arc.files.FiStream
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.io;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.files
{
  public abstract class FiStream : Fi
  {
    [LineNumberTable(new byte[] {159, 159, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FiStream(string path)
      : base(new File(path), Files.FileType.__\u003C\u003Eabsolute)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isDirectory() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override long length() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool exists() => true;

    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Fi child(string name)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Fi sibling(string name)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Fi parent()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override InputStream read()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(49)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override OutputStream write(bool overwrite)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Fi[] list()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool mkdirs()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool delete()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(65)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool deleteDirectory()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(69)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void copyTo(Fi dest)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(73)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void moveTo(Fi dest)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }
  }
}
