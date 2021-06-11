// Decompiled with JetBrains decompiler
// Type: arc.util.ArcRuntimeException
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace arc.util
{
  public class ArcRuntimeException : RuntimeException
  {
    private const long serialVersionUID = 6735854402467673117;

    [LineNumberTable(new byte[] {159, 149, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArcRuntimeException(string message)
      : base(message)
    {
    }

    [LineNumberTable(new byte[] {159, 157, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArcRuntimeException(string message, Exception t)
      : base(message, t)
    {
    }

    [LineNumberTable(new byte[] {159, 153, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArcRuntimeException(Exception t)
      : base(t)
    {
    }
  }
}
