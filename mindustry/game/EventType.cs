// Decompiled with JetBrains decompiler
// Type: mindustry.game.EventType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.core;
using mindustry.ctype;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.net;
using mindustry.type;
using mindustry.world;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.game
{
  public class EventType : Object
  {
    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EventType()
    {
    }

    public class BlockBuildBeginEvent : Object
    {
      internal Tile __\u003C\u003Etile;
      internal Team __\u003C\u003Eteam;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      internal Unit __\u003C\u003Eunit;
      internal bool __\u003C\u003Ebreaking;

      [LineNumberTable(new byte[] {159, 70, 67, 104, 103, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BlockBuildBeginEvent(Tile tile, Team team, Unit unit, bool breaking)
      {
        int num = breaking ? 1 : 0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        EventType.BlockBuildBeginEvent blockBuildBeginEvent = this;
        this.__\u003C\u003Etile = tile;
        this.__\u003C\u003Eteam = team;
        this.__\u003C\u003Eunit = unit;
        this.__\u003C\u003Ebreaking = num != 0;
      }

      [Modifiers]
      public Tile tile
      {
        [HideFromJava] get => this.__\u003C\u003Etile;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etile = value;
      }

      [Modifiers]
      public Team team
      {
        [HideFromJava] get => this.__\u003C\u003Eteam;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eteam = value;
      }

      [Modifiers]
      public Unit unit
      {
        [HideFromJava] get => this.__\u003C\u003Eunit;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eunit = value;
      }

      [Modifiers]
      public bool breaking
      {
        [HideFromJava] get => this.__\u003C\u003Ebreaking;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ebreaking = value;
      }
    }

    public class BlockBuildEndEvent : Object
    {
      internal Tile __\u003C\u003Etile;
      internal Team __\u003C\u003Eteam;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      internal Unit __\u003C\u003Eunit;
      internal bool __\u003C\u003Ebreaking;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      internal object __\u003C\u003Econfig;

      [LineNumberTable(new byte[] {159, 67, 163, 104, 103, 103, 103, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BlockBuildEndEvent(Tile tile, [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] Unit unit, Team team, bool breaking, [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] object config)
      {
        int num = breaking ? 1 : 0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        EventType.BlockBuildEndEvent blockBuildEndEvent = this;
        this.__\u003C\u003Etile = tile;
        this.__\u003C\u003Eteam = team;
        this.__\u003C\u003Eunit = unit;
        this.__\u003C\u003Ebreaking = num != 0;
        this.__\u003C\u003Econfig = config;
      }

      [Modifiers]
      public Tile tile
      {
        [HideFromJava] get => this.__\u003C\u003Etile;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etile = value;
      }

      [Modifiers]
      public Team team
      {
        [HideFromJava] get => this.__\u003C\u003Eteam;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eteam = value;
      }

      [Modifiers]
      public Unit unit
      {
        [HideFromJava] get => this.__\u003C\u003Eunit;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eunit = value;
      }

      [Modifiers]
      public bool breaking
      {
        [HideFromJava] get => this.__\u003C\u003Ebreaking;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ebreaking = value;
      }

      [Modifiers]
      public object config
      {
        [HideFromJava] get => this.__\u003C\u003Econfig;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Econfig = value;
      }
    }

    public class BlockDestroyEvent : Object
    {
      internal Tile __\u003C\u003Etile;

      [LineNumberTable(new byte[] {160, 221, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BlockDestroyEvent(Tile tile)
      {
        EventType.BlockDestroyEvent blockDestroyEvent = this;
        this.__\u003C\u003Etile = tile;
      }

      [Modifiers]
      public Tile tile
      {
        [HideFromJava] get => this.__\u003C\u003Etile;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etile = value;
      }
    }

    public class BlockInfoEvent : Object
    {
      [LineNumberTable(66)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BlockInfoEvent()
      {
      }
    }

    public class BuildSelectEvent : Object
    {
      internal Tile __\u003C\u003Etile;
      internal Team __\u003C\u003Eteam;
      internal Unit __\u003C\u003Ebuilder;
      internal bool __\u003C\u003Ebreaking;

      [LineNumberTable(new byte[] {159, 62, 131, 104, 103, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BuildSelectEvent(Tile tile, Team team, Unit builder, bool breaking)
      {
        int num = breaking ? 1 : 0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        EventType.BuildSelectEvent buildSelectEvent = this;
        this.__\u003C\u003Etile = tile;
        this.__\u003C\u003Eteam = team;
        this.__\u003C\u003Ebuilder = builder;
        this.__\u003C\u003Ebreaking = num != 0;
      }

      [Modifiers]
      public Tile tile
      {
        [HideFromJava] get => this.__\u003C\u003Etile;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etile = value;
      }

      [Modifiers]
      public Team team
      {
        [HideFromJava] get => this.__\u003C\u003Eteam;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eteam = value;
      }

      [Modifiers]
      public Unit builder
      {
        [HideFromJava] get => this.__\u003C\u003Ebuilder;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ebuilder = value;
      }

      [Modifiers]
      public bool breaking
      {
        [HideFromJava] get => this.__\u003C\u003Ebreaking;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ebreaking = value;
      }
    }

    public class ClientCreateEvent : Object
    {
      [LineNumberTable(52)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ClientCreateEvent()
      {
      }
    }

    public class ClientLoadEvent : Object
    {
      [LineNumberTable(70)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ClientLoadEvent()
      {
      }
    }

    public class ClientPreConnectEvent : Object
    {
      internal Host __\u003C\u003Ehost;

      [LineNumberTable(new byte[] {81, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ClientPreConnectEvent(Host host)
      {
        EventType.ClientPreConnectEvent clientPreConnectEvent = this;
        this.__\u003C\u003Ehost = host;
      }

      [Modifiers]
      public Host host
      {
        [HideFromJava] get => this.__\u003C\u003Ehost;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ehost = value;
      }
    }

    public class CommandIssueEvent : Object
    {
      internal Building __\u003C\u003Etile;
      internal UnitCommand __\u003C\u003Ecommand;

      [LineNumberTable(new byte[] {72, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public CommandIssueEvent(Building tile, UnitCommand command)
      {
        EventType.CommandIssueEvent commandIssueEvent = this;
        this.__\u003C\u003Etile = tile;
        this.__\u003C\u003Ecommand = command;
      }

      [Modifiers]
      public Building tile
      {
        [HideFromJava] get => this.__\u003C\u003Etile;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etile = value;
      }

      [Modifiers]
      public UnitCommand command
      {
        [HideFromJava] get => this.__\u003C\u003Ecommand;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ecommand = value;
      }
    }

    public class ConfigEvent : Object
    {
      internal Building __\u003C\u003Etile;
      internal Player __\u003C\u003Eplayer;
      internal object __\u003C\u003Evalue;

      [LineNumberTable(new byte[] {160, 77, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ConfigEvent(Building tile, Player player, object value)
      {
        EventType.ConfigEvent configEvent = this;
        this.__\u003C\u003Etile = tile;
        this.__\u003C\u003Eplayer = player;
        this.__\u003C\u003Evalue = value;
      }

      [Modifiers]
      public Building tile
      {
        [HideFromJava] get => this.__\u003C\u003Etile;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etile = value;
      }

      [Modifiers]
      public Player player
      {
        [HideFromJava] get => this.__\u003C\u003Eplayer;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eplayer = value;
      }

      [Modifiers]
      public object value
      {
        [HideFromJava] get => this.__\u003C\u003Evalue;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Evalue = value;
      }
    }

    public class ConnectionEvent : Object
    {
      internal NetConnection __\u003C\u003Econnection;

      [LineNumberTable(new byte[] {161, 20, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ConnectionEvent(NetConnection connection)
      {
        EventType.ConnectionEvent connectionEvent = this;
        this.__\u003C\u003Econnection = connection;
      }

      [Modifiers]
      public NetConnection connection
      {
        [HideFromJava] get => this.__\u003C\u003Econnection;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Econnection = value;
      }
    }

    public class ContentInitEvent : Object
    {
      [LineNumberTable(68)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ContentInitEvent()
      {
      }
    }

    public class CoreItemDeliverEvent : Object
    {
      [LineNumberTable(64)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public CoreItemDeliverEvent()
      {
      }
    }

    public class DepositEvent : Object
    {
      internal Building __\u003C\u003Etile;
      internal Player __\u003C\u003Eplayer;
      internal Item __\u003C\u003Eitem;
      internal int __\u003C\u003Eamount;

      [LineNumberTable(new byte[] {127, 104, 103, 103, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DepositEvent(Building tile, Player player, Item item, int amount)
      {
        EventType.DepositEvent depositEvent = this;
        this.__\u003C\u003Etile = tile;
        this.__\u003C\u003Eplayer = player;
        this.__\u003C\u003Eitem = item;
        this.__\u003C\u003Eamount = amount;
      }

      [Modifiers]
      public Building tile
      {
        [HideFromJava] get => this.__\u003C\u003Etile;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etile = value;
      }

      [Modifiers]
      public Player player
      {
        [HideFromJava] get => this.__\u003C\u003Eplayer;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eplayer = value;
      }

      [Modifiers]
      public Item item
      {
        [HideFromJava] get => this.__\u003C\u003Eitem;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eitem = value;
      }

      [Modifiers]
      public int amount
      {
        [HideFromJava] get => this.__\u003C\u003Eamount;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eamount = value;
      }
    }

    public class DisposeEvent : Object
    {
      [LineNumberTable(54)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DisposeEvent()
      {
      }
    }

    public class FileTreeInitEvent : Object
    {
      [LineNumberTable(72)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FileTreeInitEvent()
      {
      }
    }

    public class GameOverEvent : Object
    {
      internal Team __\u003C\u003Ewinner;

      [LineNumberTable(new byte[] {160, 126, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public GameOverEvent(Team winner)
      {
        EventType.GameOverEvent gameOverEvent = this;
        this.__\u003C\u003Ewinner = winner;
      }

      [Modifiers]
      public Team winner
      {
        [HideFromJava] get => this.__\u003C\u003Ewinner;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ewinner = value;
      }
    }

    public class LaunchItemEvent : Object
    {
      internal ItemStack __\u003C\u003Estack;

      [LineNumberTable(new byte[] {47, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LaunchItemEvent(ItemStack stack)
      {
        EventType.LaunchItemEvent launchItemEvent = this;
        this.__\u003C\u003Estack = stack;
      }

      [Modifiers]
      public ItemStack stack
      {
        [HideFromJava] get => this.__\u003C\u003Estack;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Estack = value;
      }
    }

    public class LineConfirmEvent : Object
    {
      [LineNumberTable(60)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LineConfirmEvent()
      {
      }
    }

    public class LoseEvent : Object
    {
      [LineNumberTable(47)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LoseEvent()
      {
      }
    }

    public class MapMakeEvent : Object
    {
      [LineNumberTable(49)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MapMakeEvent()
      {
      }
    }

    public class MapPublishEvent : Object
    {
      [LineNumberTable(50)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MapPublishEvent()
      {
      }
    }

    public class PickupEvent : Object
    {
      internal Unit __\u003C\u003Ecarrier;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      internal Unit __\u003C\u003Eunit;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      internal Building __\u003C\u003Ebuild;

      [LineNumberTable(new byte[] {160, 100, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PickupEvent(Unit carrier, Unit unit)
      {
        EventType.PickupEvent pickupEvent = this;
        this.__\u003C\u003Ecarrier = carrier;
        this.__\u003C\u003Eunit = unit;
        this.__\u003C\u003Ebuild = (Building) null;
      }

      [LineNumberTable(new byte[] {160, 106, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PickupEvent(Unit carrier, Building build)
      {
        EventType.PickupEvent pickupEvent = this;
        this.__\u003C\u003Ecarrier = carrier;
        this.__\u003C\u003Ebuild = build;
        this.__\u003C\u003Eunit = (Unit) null;
      }

      [Modifiers]
      public Unit carrier
      {
        [HideFromJava] get => this.__\u003C\u003Ecarrier;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ecarrier = value;
      }

      [Modifiers]
      public Unit unit
      {
        [HideFromJava] get => this.__\u003C\u003Eunit;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eunit = value;
      }

      [Modifiers]
      public Building build
      {
        [HideFromJava] get => this.__\u003C\u003Ebuild;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ebuild = value;
      }
    }

    public class PlayEvent : Object
    {
      [LineNumberTable(55)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PlayEvent()
      {
      }
    }

    public class PlayerBanEvent : Object
    {
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      internal Player __\u003C\u003Eplayer;
      internal string __\u003C\u003Euuid;

      [LineNumberTable(new byte[] {161, 56, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PlayerBanEvent(Player player, string uuid)
      {
        EventType.PlayerBanEvent playerBanEvent = this;
        this.__\u003C\u003Eplayer = player;
        this.__\u003C\u003Euuid = uuid;
      }

      [Modifiers]
      public Player player
      {
        [HideFromJava] get => this.__\u003C\u003Eplayer;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eplayer = value;
      }

      [Modifiers]
      public string uuid
      {
        [HideFromJava] get => this.__\u003C\u003Euuid;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Euuid = value;
      }
    }

    public class PlayerChatEvent : Object
    {
      internal Player __\u003C\u003Eplayer;
      internal string __\u003C\u003Emessage;

      [LineNumberTable(new byte[] {90, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PlayerChatEvent(Player player, string message)
      {
        EventType.PlayerChatEvent playerChatEvent = this;
        this.__\u003C\u003Eplayer = player;
        this.__\u003C\u003Emessage = message;
      }

      [Modifiers]
      public Player player
      {
        [HideFromJava] get => this.__\u003C\u003Eplayer;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eplayer = value;
      }

      [Modifiers]
      public string message
      {
        [HideFromJava] get => this.__\u003C\u003Emessage;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Emessage = value;
      }
    }

    public class PlayerConnect : Object
    {
      internal Player __\u003C\u003Eplayer;

      [LineNumberTable(new byte[] {161, 38, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PlayerConnect(Player player)
      {
        EventType.PlayerConnect playerConnect = this;
        this.__\u003C\u003Eplayer = player;
      }

      [Modifiers]
      public Player player
      {
        [HideFromJava] get => this.__\u003C\u003Eplayer;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eplayer = value;
      }
    }

    public class PlayerIpBanEvent : Object
    {
      internal string __\u003C\u003Eip;

      [LineNumberTable(new byte[] {161, 76, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PlayerIpBanEvent(string ip)
      {
        EventType.PlayerIpBanEvent playerIpBanEvent = this;
        this.__\u003C\u003Eip = ip;
      }

      [Modifiers]
      public string ip
      {
        [HideFromJava] get => this.__\u003C\u003Eip;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eip = value;
      }
    }

    public class PlayerIpUnbanEvent : Object
    {
      internal string __\u003C\u003Eip;

      [LineNumberTable(new byte[] {161, 84, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PlayerIpUnbanEvent(string ip)
      {
        EventType.PlayerIpUnbanEvent playerIpUnbanEvent = this;
        this.__\u003C\u003Eip = ip;
      }

      [Modifiers]
      public string ip
      {
        [HideFromJava] get => this.__\u003C\u003Eip;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eip = value;
      }
    }

    public class PlayerJoin : Object
    {
      internal Player __\u003C\u003Eplayer;

      [LineNumberTable(new byte[] {161, 29, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PlayerJoin(Player player)
      {
        EventType.PlayerJoin playerJoin = this;
        this.__\u003C\u003Eplayer = player;
      }

      [Modifiers]
      public Player player
      {
        [HideFromJava] get => this.__\u003C\u003Eplayer;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eplayer = value;
      }
    }

    public class PlayerLeave : Object
    {
      internal Player __\u003C\u003Eplayer;

      [LineNumberTable(new byte[] {161, 46, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PlayerLeave(Player player)
      {
        EventType.PlayerLeave playerLeave = this;
        this.__\u003C\u003Eplayer = player;
      }

      [Modifiers]
      public Player player
      {
        [HideFromJava] get => this.__\u003C\u003Eplayer;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eplayer = value;
      }
    }

    public class PlayerUnbanEvent : Object
    {
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      internal Player __\u003C\u003Eplayer;
      internal string __\u003C\u003Euuid;

      [LineNumberTable(new byte[] {161, 67, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PlayerUnbanEvent(Player player, string uuid)
      {
        EventType.PlayerUnbanEvent playerUnbanEvent = this;
        this.__\u003C\u003Eplayer = player;
        this.__\u003C\u003Euuid = uuid;
      }

      [Modifiers]
      public Player player
      {
        [HideFromJava] get => this.__\u003C\u003Eplayer;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eplayer = value;
      }

      [Modifiers]
      public string uuid
      {
        [HideFromJava] get => this.__\u003C\u003Euuid;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Euuid = value;
      }
    }

    public class ResearchEvent : Object
    {
      internal UnlockableContent __\u003C\u003Econtent;

      [LineNumberTable(new byte[] {160, 159, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ResearchEvent(UnlockableContent content)
      {
        EventType.ResearchEvent researchEvent = this;
        this.__\u003C\u003Econtent = content;
      }

      [Modifiers]
      public UnlockableContent content
      {
        [HideFromJava] get => this.__\u003C\u003Econtent;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Econtent = value;
      }
    }

    public class ResetEvent : Object
    {
      [LineNumberTable(56)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ResetEvent()
      {
      }
    }

    public class ResizeEvent : Object
    {
      [LineNumberTable(48)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ResizeEvent()
      {
      }
    }

    public class SaveLoadEvent : Object
    {
      [LineNumberTable(51)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SaveLoadEvent()
      {
      }
    }

    public class SchematicCreateEvent : Object
    {
      internal Schematic __\u003C\u003Eschematic;

      [LineNumberTable(new byte[] {63, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SchematicCreateEvent(Schematic schematic)
      {
        EventType.SchematicCreateEvent schematicCreateEvent = this;
        this.__\u003C\u003Eschematic = schematic;
      }

      [Modifiers]
      public Schematic schematic
      {
        [HideFromJava] get => this.__\u003C\u003Eschematic;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eschematic = value;
      }
    }

    public class SectorCaptureEvent : Object
    {
      internal Sector __\u003C\u003Esector;

      [LineNumberTable(new byte[] {100, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SectorCaptureEvent(Sector sector)
      {
        EventType.SectorCaptureEvent sectorCaptureEvent = this;
        this.__\u003C\u003Esector = sector;
      }

      [Modifiers]
      public Sector sector
      {
        [HideFromJava] get => this.__\u003C\u003Esector;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Esector = value;
      }
    }

    public class SectorInvasionEvent : Object
    {
      internal Sector __\u003C\u003Esector;

      [LineNumberTable(new byte[] {39, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SectorInvasionEvent(Sector sector)
      {
        EventType.SectorInvasionEvent sectorInvasionEvent = this;
        this.__\u003C\u003Esector = sector;
      }

      [Modifiers]
      public Sector sector
      {
        [HideFromJava] get => this.__\u003C\u003Esector;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Esector = value;
      }
    }

    public class SectorLaunchEvent : Object
    {
      internal Sector __\u003C\u003Esector;

      [LineNumberTable(new byte[] {55, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SectorLaunchEvent(Sector sector)
      {
        EventType.SectorLaunchEvent sectorLaunchEvent = this;
        this.__\u003C\u003Esector = sector;
      }

      [Modifiers]
      public Sector sector
      {
        [HideFromJava] get => this.__\u003C\u003Esector;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Esector = value;
      }
    }

    public class SectorLoseEvent : Object
    {
      internal Sector __\u003C\u003Esector;

      [LineNumberTable(new byte[] {30, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SectorLoseEvent(Sector sector)
      {
        EventType.SectorLoseEvent sectorLoseEvent = this;
        this.__\u003C\u003Esector = sector;
      }

      [Modifiers]
      public Sector sector
      {
        [HideFromJava] get => this.__\u003C\u003Esector;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Esector = value;
      }
    }

    public class ServerLoadEvent : Object
    {
      [LineNumberTable(53)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ServerLoadEvent()
      {
      }
    }

    public class StateChangeEvent : Object
    {
      internal GameState.State __\u003C\u003Efrom;
      internal GameState.State __\u003C\u003Eto;

      [LineNumberTable(new byte[] {160, 142, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public StateChangeEvent(GameState.State from, GameState.State to)
      {
        EventType.StateChangeEvent stateChangeEvent = this;
        this.__\u003C\u003Efrom = from;
        this.__\u003C\u003Eto = to;
      }

      [Modifiers]
      public GameState.State from
      {
        [HideFromJava] get => this.__\u003C\u003Efrom;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Efrom = value;
      }

      [Modifiers]
      public GameState.State to
      {
        [HideFromJava] get => this.__\u003C\u003Eto;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eto = value;
      }
    }

    public class TapEvent : Object
    {
      internal Player __\u003C\u003Eplayer;
      internal Tile __\u003C\u003Etile;

      [LineNumberTable(new byte[] {160, 89, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TapEvent(Player player, Tile tile)
      {
        EventType.TapEvent tapEvent = this;
        this.__\u003C\u003Etile = tile;
        this.__\u003C\u003Eplayer = player;
      }

      [Modifiers]
      public Player player
      {
        [HideFromJava] get => this.__\u003C\u003Eplayer;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eplayer = value;
      }

      [Modifiers]
      public Tile tile
      {
        [HideFromJava] get => this.__\u003C\u003Etile;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etile = value;
      }
    }

    public class TileChangeEvent : Object
    {
      internal Tile __\u003C\u003Etile;

      [LineNumberTable(new byte[] {160, 134, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TileChangeEvent(Tile tile)
      {
        EventType.TileChangeEvent tileChangeEvent = this;
        this.__\u003C\u003Etile = tile;
      }

      [Modifiers]
      public Tile tile
      {
        [HideFromJava] get => this.__\u003C\u003Etile;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etile = value;
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/game/EventType$Trigger;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Trigger : Enum
    {
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003Eshock;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EphaseDeflectHit;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EimpactPower;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EthoriumReactorOverheat;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EfireExtinguish;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EacceleratorUse;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EnewGame;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EtutorialComplete;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EflameAmmo;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EturretCool;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EenablePixelation;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EexclusionDeath;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EsuicideBomb;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EopenWiki;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EteamCoreDamage;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EsocketConfigChanged;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003Eupdate;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003Edraw;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EpreDraw;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EpostDraw;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EuiDrawBegin;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EuiDrawEnd;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EuniverseDrawBegin;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EuniverseDraw;
      [Modifiers]
      internal static EventType.Trigger __\u003C\u003EuniverseDrawEnd;
      [Modifiers]
      private static EventType.Trigger[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(15)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Trigger([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(15)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static EventType.Trigger[] values() => (EventType.Trigger[]) EventType.Trigger.\u0024VALUES.Clone();

      [LineNumberTable(15)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static EventType.Trigger valueOf(string name) => (EventType.Trigger) Enum.valueOf((Class) ClassLiteral<EventType.Trigger>.Value, name);

      [LineNumberTable(new byte[] {159, 138, 77, 112, 112, 112, 112, 112, 112, 112, 112, 112, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 145, 145, 145, 241, 36})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Trigger()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.game.EventType$Trigger"))
          return;
        EventType.Trigger.__\u003C\u003Eshock = new EventType.Trigger(nameof (shock), 0);
        EventType.Trigger.__\u003C\u003EphaseDeflectHit = new EventType.Trigger(nameof (phaseDeflectHit), 1);
        EventType.Trigger.__\u003C\u003EimpactPower = new EventType.Trigger(nameof (impactPower), 2);
        EventType.Trigger.__\u003C\u003EthoriumReactorOverheat = new EventType.Trigger(nameof (thoriumReactorOverheat), 3);
        EventType.Trigger.__\u003C\u003EfireExtinguish = new EventType.Trigger(nameof (fireExtinguish), 4);
        EventType.Trigger.__\u003C\u003EacceleratorUse = new EventType.Trigger(nameof (acceleratorUse), 5);
        EventType.Trigger.__\u003C\u003EnewGame = new EventType.Trigger(nameof (newGame), 6);
        EventType.Trigger.__\u003C\u003EtutorialComplete = new EventType.Trigger(nameof (tutorialComplete), 7);
        EventType.Trigger.__\u003C\u003EflameAmmo = new EventType.Trigger(nameof (flameAmmo), 8);
        EventType.Trigger.__\u003C\u003EturretCool = new EventType.Trigger(nameof (turretCool), 9);
        EventType.Trigger.__\u003C\u003EenablePixelation = new EventType.Trigger(nameof (enablePixelation), 10);
        EventType.Trigger.__\u003C\u003EexclusionDeath = new EventType.Trigger(nameof (exclusionDeath), 11);
        EventType.Trigger.__\u003C\u003EsuicideBomb = new EventType.Trigger(nameof (suicideBomb), 12);
        EventType.Trigger.__\u003C\u003EopenWiki = new EventType.Trigger(nameof (openWiki), 13);
        EventType.Trigger.__\u003C\u003EteamCoreDamage = new EventType.Trigger(nameof (teamCoreDamage), 14);
        EventType.Trigger.__\u003C\u003EsocketConfigChanged = new EventType.Trigger(nameof (socketConfigChanged), 15);
        EventType.Trigger.__\u003C\u003Eupdate = new EventType.Trigger(nameof (update), 16);
        EventType.Trigger.__\u003C\u003Edraw = new EventType.Trigger(nameof (draw), 17);
        EventType.Trigger.__\u003C\u003EpreDraw = new EventType.Trigger(nameof (preDraw), 18);
        EventType.Trigger.__\u003C\u003EpostDraw = new EventType.Trigger(nameof (postDraw), 19);
        EventType.Trigger.__\u003C\u003EuiDrawBegin = new EventType.Trigger(nameof (uiDrawBegin), 20);
        EventType.Trigger.__\u003C\u003EuiDrawEnd = new EventType.Trigger(nameof (uiDrawEnd), 21);
        EventType.Trigger.__\u003C\u003EuniverseDrawBegin = new EventType.Trigger(nameof (universeDrawBegin), 22);
        EventType.Trigger.__\u003C\u003EuniverseDraw = new EventType.Trigger(nameof (universeDraw), 23);
        EventType.Trigger.__\u003C\u003EuniverseDrawEnd = new EventType.Trigger(nameof (universeDrawEnd), 24);
        EventType.Trigger.\u0024VALUES = new EventType.Trigger[25]
        {
          EventType.Trigger.__\u003C\u003Eshock,
          EventType.Trigger.__\u003C\u003EphaseDeflectHit,
          EventType.Trigger.__\u003C\u003EimpactPower,
          EventType.Trigger.__\u003C\u003EthoriumReactorOverheat,
          EventType.Trigger.__\u003C\u003EfireExtinguish,
          EventType.Trigger.__\u003C\u003EacceleratorUse,
          EventType.Trigger.__\u003C\u003EnewGame,
          EventType.Trigger.__\u003C\u003EtutorialComplete,
          EventType.Trigger.__\u003C\u003EflameAmmo,
          EventType.Trigger.__\u003C\u003EturretCool,
          EventType.Trigger.__\u003C\u003EenablePixelation,
          EventType.Trigger.__\u003C\u003EexclusionDeath,
          EventType.Trigger.__\u003C\u003EsuicideBomb,
          EventType.Trigger.__\u003C\u003EopenWiki,
          EventType.Trigger.__\u003C\u003EteamCoreDamage,
          EventType.Trigger.__\u003C\u003EsocketConfigChanged,
          EventType.Trigger.__\u003C\u003Eupdate,
          EventType.Trigger.__\u003C\u003Edraw,
          EventType.Trigger.__\u003C\u003EpreDraw,
          EventType.Trigger.__\u003C\u003EpostDraw,
          EventType.Trigger.__\u003C\u003EuiDrawBegin,
          EventType.Trigger.__\u003C\u003EuiDrawEnd,
          EventType.Trigger.__\u003C\u003EuniverseDrawBegin,
          EventType.Trigger.__\u003C\u003EuniverseDraw,
          EventType.Trigger.__\u003C\u003EuniverseDrawEnd
        };
      }

      [Modifiers]
      public static EventType.Trigger shock
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003Eshock;
      }

      [Modifiers]
      public static EventType.Trigger phaseDeflectHit
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EphaseDeflectHit;
      }

      [Modifiers]
      public static EventType.Trigger impactPower
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EimpactPower;
      }

      [Modifiers]
      public static EventType.Trigger thoriumReactorOverheat
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EthoriumReactorOverheat;
      }

      [Modifiers]
      public static EventType.Trigger fireExtinguish
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EfireExtinguish;
      }

      [Modifiers]
      public static EventType.Trigger acceleratorUse
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EacceleratorUse;
      }

      [Modifiers]
      public static EventType.Trigger newGame
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EnewGame;
      }

      [Modifiers]
      public static EventType.Trigger tutorialComplete
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EtutorialComplete;
      }

      [Modifiers]
      public static EventType.Trigger flameAmmo
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EflameAmmo;
      }

      [Modifiers]
      public static EventType.Trigger turretCool
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EturretCool;
      }

      [Modifiers]
      public static EventType.Trigger enablePixelation
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EenablePixelation;
      }

      [Modifiers]
      public static EventType.Trigger exclusionDeath
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EexclusionDeath;
      }

      [Modifiers]
      public static EventType.Trigger suicideBomb
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EsuicideBomb;
      }

      [Modifiers]
      public static EventType.Trigger openWiki
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EopenWiki;
      }

      [Modifiers]
      public static EventType.Trigger teamCoreDamage
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EteamCoreDamage;
      }

      [Modifiers]
      public static EventType.Trigger socketConfigChanged
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EsocketConfigChanged;
      }

      [Modifiers]
      public static EventType.Trigger update
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003Eupdate;
      }

      [Modifiers]
      public static EventType.Trigger draw
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003Edraw;
      }

      [Modifiers]
      public static EventType.Trigger preDraw
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EpreDraw;
      }

      [Modifiers]
      public static EventType.Trigger postDraw
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EpostDraw;
      }

      [Modifiers]
      public static EventType.Trigger uiDrawBegin
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EuiDrawBegin;
      }

      [Modifiers]
      public static EventType.Trigger uiDrawEnd
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EuiDrawEnd;
      }

      [Modifiers]
      public static EventType.Trigger universeDrawBegin
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EuniverseDrawBegin;
      }

      [Modifiers]
      public static EventType.Trigger universeDraw
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EuniverseDraw;
      }

      [Modifiers]
      public static EventType.Trigger universeDrawEnd
      {
        [HideFromJava] get => EventType.Trigger.__\u003C\u003EuniverseDrawEnd;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        shock,
        phaseDeflectHit,
        impactPower,
        thoriumReactorOverheat,
        fireExtinguish,
        acceleratorUse,
        newGame,
        tutorialComplete,
        flameAmmo,
        turretCool,
        enablePixelation,
        exclusionDeath,
        suicideBomb,
        openWiki,
        teamCoreDamage,
        socketConfigChanged,
        update,
        draw,
        preDraw,
        postDraw,
        uiDrawBegin,
        uiDrawEnd,
        universeDrawBegin,
        universeDraw,
        universeDrawEnd,
      }
    }

    public class TurnEvent : Object
    {
      [LineNumberTable(58)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TurnEvent()
      {
      }
    }

    public class TurretAmmoDeliverEvent : Object
    {
      [LineNumberTable(62)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TurretAmmoDeliverEvent()
      {
      }
    }

    public class UnitChangeEvent : Object
    {
      internal Player __\u003C\u003Eplayer;
      internal Unit __\u003C\u003Eunit;

      [LineNumberTable(new byte[] {161, 10, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitChangeEvent(Player player, Unit unit)
      {
        EventType.UnitChangeEvent unitChangeEvent = this;
        this.__\u003C\u003Eplayer = player;
        this.__\u003C\u003Eunit = unit;
      }

      [Modifiers]
      public Player player
      {
        [HideFromJava] get => this.__\u003C\u003Eplayer;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eplayer = value;
      }

      [Modifiers]
      public Unit unit
      {
        [HideFromJava] get => this.__\u003C\u003Eunit;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eunit = value;
      }
    }

    public class UnitControlEvent : Object
    {
      internal Player __\u003C\u003Eplayer;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      internal Unit __\u003C\u003Eunit;

      [LineNumberTable(new byte[] {160, 117, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitControlEvent(Player player, [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] Unit unit)
      {
        EventType.UnitControlEvent unitControlEvent = this;
        this.__\u003C\u003Eplayer = player;
        this.__\u003C\u003Eunit = unit;
      }

      [Modifiers]
      public Player player
      {
        [HideFromJava] get => this.__\u003C\u003Eplayer;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eplayer = value;
      }

      [Modifiers]
      public Unit unit
      {
        [HideFromJava] get => this.__\u003C\u003Eunit;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eunit = value;
      }
    }

    public class UnitCreateEvent : Object
    {
      internal Unit __\u003C\u003Eunit;
      internal Building __\u003C\u003Espawner;

      [LineNumberTable(new byte[] {160, 247, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitCreateEvent(Unit unit, Building spawner)
      {
        EventType.UnitCreateEvent unitCreateEvent = this;
        this.__\u003C\u003Eunit = unit;
        this.__\u003C\u003Espawner = spawner;
      }

      [Modifiers]
      public Unit unit
      {
        [HideFromJava] get => this.__\u003C\u003Eunit;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eunit = value;
      }

      [Modifiers]
      public Building spawner
      {
        [HideFromJava] get => this.__\u003C\u003Espawner;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Espawner = value;
      }
    }

    public class UnitDestroyEvent : Object
    {
      internal Unit __\u003C\u003Eunit;

      [LineNumberTable(new byte[] {160, 229, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitDestroyEvent(Unit unit)
      {
        EventType.UnitDestroyEvent unitDestroyEvent = this;
        this.__\u003C\u003Eunit = unit;
      }

      [Modifiers]
      public Unit unit
      {
        [HideFromJava] get => this.__\u003C\u003Eunit;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eunit = value;
      }
    }

    public class UnitDrownEvent : Object
    {
      internal Unit __\u003C\u003Eunit;

      [LineNumberTable(new byte[] {160, 237, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitDrownEvent(Unit unit)
      {
        EventType.UnitDrownEvent unitDrownEvent = this;
        this.__\u003C\u003Eunit = unit;
      }

      [Modifiers]
      public Unit unit
      {
        [HideFromJava] get => this.__\u003C\u003Eunit;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eunit = value;
      }
    }

    public class UnitUnloadEvent : Object
    {
      internal Unit __\u003C\u003Eunit;

      [LineNumberTable(new byte[] {161, 1, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitUnloadEvent(Unit unit)
      {
        EventType.UnitUnloadEvent unitUnloadEvent = this;
        this.__\u003C\u003Eunit = unit;
      }

      [Modifiers]
      public Unit unit
      {
        [HideFromJava] get => this.__\u003C\u003Eunit;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eunit = value;
      }
    }

    public class UnlockEvent : Object
    {
      internal UnlockableContent __\u003C\u003Econtent;

      [LineNumberTable(new byte[] {160, 151, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnlockEvent(UnlockableContent content)
      {
        EventType.UnlockEvent unlockEvent = this;
        this.__\u003C\u003Econtent = content;
      }

      [Modifiers]
      public UnlockableContent content
      {
        [HideFromJava] get => this.__\u003C\u003Econtent;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Econtent = value;
      }
    }

    public class WaveEvent : Object
    {
      [LineNumberTable(57)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public WaveEvent()
      {
      }
    }

    public class WinEvent : Object
    {
      [LineNumberTable(46)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public WinEvent()
      {
      }
    }

    public class WithdrawEvent : Object
    {
      internal Building __\u003C\u003Etile;
      internal Player __\u003C\u003Eplayer;
      internal Item __\u003C\u003Eitem;
      internal int __\u003C\u003Eamount;

      [LineNumberTable(new byte[] {112, 104, 103, 103, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public WithdrawEvent(Building tile, Player player, Item item, int amount)
      {
        EventType.WithdrawEvent withdrawEvent = this;
        this.__\u003C\u003Etile = tile;
        this.__\u003C\u003Eplayer = player;
        this.__\u003C\u003Eitem = item;
        this.__\u003C\u003Eamount = amount;
      }

      [Modifiers]
      public Building tile
      {
        [HideFromJava] get => this.__\u003C\u003Etile;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etile = value;
      }

      [Modifiers]
      public Player player
      {
        [HideFromJava] get => this.__\u003C\u003Eplayer;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eplayer = value;
      }

      [Modifiers]
      public Item item
      {
        [HideFromJava] get => this.__\u003C\u003Eitem;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eitem = value;
      }

      [Modifiers]
      public int amount
      {
        [HideFromJava] get => this.__\u003C\u003Eamount;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eamount = value;
      }
    }

    public class WorldLoadEvent : Object
    {
      [LineNumberTable(74)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public WorldLoadEvent()
      {
      }
    }
  }
}
