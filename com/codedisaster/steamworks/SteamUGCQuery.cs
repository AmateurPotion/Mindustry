// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamUGCQuery
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace com.codedisaster.steamworks
{
  public class SteamUGCQuery : SteamNativeHandle
  {
    [LineNumberTable(new byte[] {159, 148, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamUGCQuery(long handle)
      : base(handle)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isValid() => this.handle != -1L;
  }
}
