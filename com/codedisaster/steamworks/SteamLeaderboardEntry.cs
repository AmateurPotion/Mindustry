// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamLeaderboardEntry
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace com.codedisaster.steamworks
{
  public class SteamLeaderboardEntry : Object
  {
    internal long steamIDUser;
    internal int globalRank;
    internal int score;
    internal int details;

    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamLeaderboardEntry()
    {
    }

    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamID getSteamIDUser()
    {
      SteamID.__\u003Cclinit\u003E();
      return new SteamID(this.steamIDUser);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getGlobalRank() => this.globalRank;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getScore() => this.score;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getNumDetails() => this.details;
  }
}
