// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4Exception
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace net.jpountz.lz4
{
  public class LZ4Exception : RuntimeException
  {
    private const long serialVersionUID = 1;

    [LineNumberTable(new byte[] {159, 171, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4Exception(string msg)
      : base(msg)
    {
    }

    [LineNumberTable(new byte[] {159, 175, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4Exception()
    {
    }

    [LineNumberTable(new byte[] {159, 167, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4Exception(string msg, Exception t)
      : base(msg, t)
    {
    }
  }
}
