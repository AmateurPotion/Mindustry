﻿// Decompiled with JetBrains decompiler
// Type: arc.net.ArcNetException
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace arc.net
{
  public class ArcNetException : RuntimeException
  {
    [LineNumberTable(new byte[] {159, 161, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArcNetException(Exception cause)
      : base(cause)
    {
    }

    [LineNumberTable(new byte[] {159, 149, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArcNetException()
    {
    }

    [LineNumberTable(new byte[] {159, 153, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArcNetException(string message, Exception cause)
      : base(message, cause)
    {
    }

    [LineNumberTable(new byte[] {159, 157, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArcNetException(string message)
      : base(message)
    {
    }
  }
}
