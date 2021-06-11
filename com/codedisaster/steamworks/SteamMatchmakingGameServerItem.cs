// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamMatchmakingGameServerItem
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace com.codedisaster.steamworks
{
  public class SteamMatchmakingGameServerItem : Object
  {
    internal SteamMatchmakingServerNetAdr netAdr;
    internal int ping;
    internal bool hadSuccessfulResponse;
    internal bool doNotRefresh;
    internal string gameDir;
    internal string map;
    internal string gameDescription;
    internal int appID;
    internal int players;
    internal int maxPlayers;
    internal int botPlayers;
    internal bool password;
    internal bool secure;
    internal int timeLastPlayed;
    internal int serverVersion;
    internal string serverName;
    internal string gameTags;
    internal long steamID;

    [LineNumberTable(new byte[] {159, 169, 232, 42, 235, 88})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamMatchmakingGameServerItem()
    {
      SteamMatchmakingGameServerItem matchmakingGameServerItem = this;
      this.netAdr = new SteamMatchmakingServerNetAdr();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamMatchmakingServerNetAdr getNetAdr() => this.netAdr;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getPing() => this.ping;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hadSuccessfulResponse() => this.hadSuccessfulResponse;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool doNotRefresh() => this.doNotRefresh;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getGameDir() => this.gameDir;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getMap() => this.map;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getGameDescription() => this.gameDescription;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getAppID() => this.appID;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getPlayers() => this.players;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getMaxPlayers() => this.maxPlayers;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getBotPlayers() => this.botPlayers;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasPassword() => this.password;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isSecure() => this.secure;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getTimeLastPlayed() => this.timeLastPlayed;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getServerVersion() => this.serverVersion;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getServerName() => this.serverName;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getGameTags() => this.gameTags;

    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamID getSteamID()
    {
      SteamID.__\u003Cclinit\u003E();
      return new SteamID(this.steamID);
    }
  }
}
