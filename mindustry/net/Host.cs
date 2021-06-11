// Decompiled with JetBrains decompiler
// Type: mindustry.net.Host
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.game;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.net
{
  public class Host : Object
  {
    internal string __\u003C\u003Ename;
    internal string __\u003C\u003Eaddress;
    internal string __\u003C\u003Emapname;
    internal string __\u003C\u003Edescription;
    internal int __\u003C\u003Ewave;
    internal int __\u003C\u003Eplayers;
    internal int __\u003C\u003EplayerLimit;
    internal int __\u003C\u003Eversion;
    internal string __\u003C\u003EversionType;
    internal Gamemode __\u003C\u003Emode;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    internal string __\u003C\u003EmodeName;
    public int ping;
    public int port;

    [LineNumberTable(new byte[] {159, 161, 8, 171, 103, 103, 103, 104, 104, 104, 104, 104, 104, 104, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Host(
      int ping,
      string name,
      string address,
      string mapname,
      int wave,
      int players,
      int version,
      string versionType,
      Gamemode mode,
      int playerLimit,
      string description,
      string modeName)
    {
      Host host = this;
      this.port = 6567;
      this.ping = ping;
      this.__\u003C\u003Ename = name;
      this.__\u003C\u003Eaddress = address;
      this.__\u003C\u003Eplayers = players;
      this.__\u003C\u003Emapname = mapname;
      this.__\u003C\u003Ewave = wave;
      this.__\u003C\u003Eversion = version;
      this.__\u003C\u003EversionType = versionType;
      this.__\u003C\u003EplayerLimit = playerLimit;
      this.__\u003C\u003Emode = mode;
      this.__\u003C\u003Edescription = description;
      this.__\u003C\u003EmodeName = modeName;
    }

    [Modifiers]
    public string name
    {
      [HideFromJava] get => this.__\u003C\u003Ename;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ename = value;
    }

    [Modifiers]
    public string address
    {
      [HideFromJava] get => this.__\u003C\u003Eaddress;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eaddress = value;
    }

    [Modifiers]
    public string mapname
    {
      [HideFromJava] get => this.__\u003C\u003Emapname;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Emapname = value;
    }

    [Modifiers]
    public string description
    {
      [HideFromJava] get => this.__\u003C\u003Edescription;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Edescription = value;
    }

    [Modifiers]
    public int wave
    {
      [HideFromJava] get => this.__\u003C\u003Ewave;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ewave = value;
    }

    [Modifiers]
    public int players
    {
      [HideFromJava] get => this.__\u003C\u003Eplayers;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eplayers = value;
    }

    [Modifiers]
    public int playerLimit
    {
      [HideFromJava] get => this.__\u003C\u003EplayerLimit;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EplayerLimit = value;
    }

    [Modifiers]
    public int version
    {
      [HideFromJava] get => this.__\u003C\u003Eversion;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eversion = value;
    }

    [Modifiers]
    public string versionType
    {
      [HideFromJava] get => this.__\u003C\u003EversionType;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EversionType = value;
    }

    [Modifiers]
    public Gamemode mode
    {
      [HideFromJava] get => this.__\u003C\u003Emode;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Emode = value;
    }

    [Modifiers]
    public string modeName
    {
      [HideFromJava] get => this.__\u003C\u003EmodeName;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EmodeName = value;
    }
  }
}
