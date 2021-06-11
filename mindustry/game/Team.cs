// Decompiled with JetBrains decompiler
// Type: mindustry.game.Team
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.graphics;
using arc.math;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.graphics;
using mindustry.world.blocks.storage;
using mindustry.world.modules;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.game
{
  [Signature("Ljava/lang/Object;Ljava/lang/Comparable<Lmindustry/game/Team;>;")]
  [Implements(new string[] {"java.lang.Comparable"})]
  public class Team : Object, Comparable
  {
    internal int __\u003C\u003Eid;
    internal Color __\u003C\u003Ecolor;
    internal Color[] __\u003C\u003Epalette;
    public bool hasPalette;
    public string name;
    internal static Team[] __\u003C\u003Eall;
    internal static Team[] __\u003C\u003EbaseTeams;
    internal static Team __\u003C\u003Ederelict;
    internal static Team __\u003C\u003Esharded;
    internal static Team __\u003C\u003Ecrux;
    internal static Team __\u003C\u003Egreen;
    internal static Team __\u003C\u003Epurple;
    internal static Team __\u003C\u003Eblue;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("()Larc/struct/Seq<Lmindustry/world/blocks/storage/CoreBlock$CoreBuild;>;")]
    [LineNumberTable(104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq cores() => Vars.state.teams.cores(this);

    [LineNumberTable(83)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rules.TeamRule rules() => Vars.state.rules.teams.get(this);

    [LineNumberTable(92)]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CoreBlock.CoreBuild core() => this.data().core();

    [LineNumberTable(87)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Teams.TeamData data() => Vars.state.teams.get(this);

    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool active() => Vars.state.teams.isActive(this);

    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Team get(int id) => Team.__\u003C\u003Eall[(int) (sbyte) id & (int) byte.MaxValue];

    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEnemy(Team other) => Vars.state.teams.areEnemies(this, other);

    [LineNumberTable(new byte[] {1, 104, 103, 103, 135, 108, 136, 108, 105, 120, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Team(int id, string name, Color color)
    {
      Team team = this;
      this.name = name;
      this.__\u003C\u003Ecolor = color;
      this.__\u003C\u003Eid = id;
      if (id < 6)
        Team.__\u003C\u003EbaseTeams[id] = this;
      Team.__\u003C\u003Eall[id] = this;
      this.__\u003C\u003Epalette = new Color[3];
      this.__\u003C\u003Epalette[0] = color;
      this.__\u003C\u003Epalette[1] = color.cpy().mul(0.75f);
      this.__\u003C\u003Epalette[2] = color.cpy().mul(0.5f);
    }

    [LineNumberTable(113)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int compareTo(Team team) => Integer.compare(this.__\u003C\u003Eid, team.__\u003C\u003Eid);

    [LineNumberTable(new byte[] {17, 139, 106, 106, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Team(
      int id,
      string name,
      Color color,
      Color pal1,
      Color pal2,
      Color pal3)
      : this(id, name, color)
    {
      Team team = this;
      this.__\u003C\u003Epalette[0] = pal1;
      this.__\u003C\u003Epalette[1] = pal2;
      this.__\u003C\u003Epalette[2] = pal3;
      this.hasPalette = true;
    }

    [LineNumberTable(78)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ItemModule items() => this.core() == null ? ItemModule.__\u003C\u003Eempty : this.core().items;

    [LineNumberTable(108)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string localized() => Core.bundle.get(new StringBuilder().append("team.").append(this.name).append(".name").toString(), this.name);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.name;

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int compareTo(object obj) => this.compareTo((Team) obj);

    [LineNumberTable(new byte[] {159, 136, 77, 143, 171, 122, 117, 127, 4, 117, 127, 4, 122, 122, 186, 140, 107, 63, 71, 169, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Team()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.game.Team"))
        return;
      Team.__\u003C\u003Eall = new Team[256];
      Team.__\u003C\u003EbaseTeams = new Team[6];
      Team.__\u003C\u003Ederelict = new Team(0, nameof (derelict), Color.valueOf("4d4e58"));
      Team.__\u003C\u003Esharded = new Team(1, nameof (sharded), Pal.accent.cpy(), Color.valueOf("ffd37f"), Color.valueOf("eab678"), Color.valueOf("d4816b"));
      Team.__\u003C\u003Ecrux = new Team(2, nameof (crux), Color.valueOf("f25555"), Color.valueOf("fc8e6c"), Color.valueOf("f25555"), Color.valueOf("a04553"));
      Team.__\u003C\u003Egreen = new Team(3, nameof (green), Color.valueOf("54d67d"));
      Team.__\u003C\u003Epurple = new Team(4, nameof (purple), Color.valueOf("995bb0"));
      Team.__\u003C\u003Eblue = new Team(5, nameof (blue), Color.valueOf("5a4deb"));
      Mathf.rand.setSeed(8L);
      for (int id = 6; id < Team.__\u003C\u003Eall.Length; ++id)
      {
        Team team = new Team(id, new StringBuilder().append("team#").append(id).toString(), Color.HSVtoRGB(360f * Mathf.random(), 100f * Mathf.random(0.6f, 1f), 100f * Mathf.random(0.8f, 1f), 1f));
      }
      Mathf.rand.setSeed(new Rand().nextLong());
    }

    int IComparable.__\u003Coverridestub\u003Ejava\u002Elang\u002EComparable\u003A\u003AcompareTo(
      [In] object obj0)
    {
      return this.compareTo(obj0);
    }

    [Modifiers]
    public int id
    {
      [HideFromJava] get => this.__\u003C\u003Eid;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eid = value;
    }

    [Modifiers]
    public Color color
    {
      [HideFromJava] get => this.__\u003C\u003Ecolor;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ecolor = value;
    }

    [Modifiers]
    public Color[] palette
    {
      [HideFromJava] get => this.__\u003C\u003Epalette;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Epalette = value;
    }

    [Modifiers]
    public static Team[] all
    {
      [HideFromJava] get => Team.__\u003C\u003Eall;
    }

    [Modifiers]
    public static Team[] baseTeams
    {
      [HideFromJava] get => Team.__\u003C\u003EbaseTeams;
    }

    [Modifiers]
    public static Team derelict
    {
      [HideFromJava] get => Team.__\u003C\u003Ederelict;
    }

    [Modifiers]
    public static Team sharded
    {
      [HideFromJava] get => Team.__\u003C\u003Esharded;
    }

    [Modifiers]
    public static Team crux
    {
      [HideFromJava] get => Team.__\u003C\u003Ecrux;
    }

    [Modifiers]
    public static Team green
    {
      [HideFromJava] get => Team.__\u003C\u003Egreen;
    }

    [Modifiers]
    public static Team purple
    {
      [HideFromJava] get => Team.__\u003C\u003Epurple;
    }

    [Modifiers]
    public static Team blue
    {
      [HideFromJava] get => Team.__\u003C\u003Eblue;
    }
  }
}
