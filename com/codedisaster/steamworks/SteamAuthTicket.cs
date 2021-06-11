// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamAuthTicket
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  public class SteamAuthTicket : SteamNativeHandle
  {
    internal const long AuthTicketInvalid = 0;

    [LineNumberTable(new byte[] {159, 150, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamAuthTicket([In] long obj0)
      : base(obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isValid() => this.handle != 0L;
  }
}
