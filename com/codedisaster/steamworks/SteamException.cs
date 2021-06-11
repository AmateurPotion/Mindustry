// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamException
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace com.codedisaster.steamworks
{
  public class SteamException : Exception
  {
    [LineNumberTable(new byte[] {159, 153, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamException(string message)
      : base(message)
    {
    }

    [LineNumberTable(new byte[] {159, 149, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamException()
    {
    }

    [LineNumberTable(new byte[] {159, 157, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamException(string message, Exception throwable)
      : base(message, throwable)
    {
    }

    [LineNumberTable(new byte[] {159, 161, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamException(Exception throwable)
      : base(throwable)
    {
    }
  }
}
