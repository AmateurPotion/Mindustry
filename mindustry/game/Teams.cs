// Decompiled with JetBrains decompiler
// Type: mindustry.game.Teams
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math.geom;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.ai;
using mindustry.content;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.type;
using mindustry.world.blocks.payloads;
using mindustry.world.blocks.storage;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.game
{
  public class Teams : Object
  {
    private Teams.TeamData[] map;
    [Signature("Larc/struct/Seq<Lmindustry/game/Teams$TeamData;>;")]
    public Seq active;
    [Signature("Larc/struct/Seq<Lmindustry/game/Teams$TeamData;>;")]
    public Seq present;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Unit boss;

    [LineNumberTable(91)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isActive(Team team) => this.get(team).active();

    [Signature("()Larc/struct/Seq<Lmindustry/world/blocks/storage/CoreBlock$CoreBuild;>;")]
    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq playerCores() => this.get(Vars.state.rules.defaultTeam).__\u003C\u003Ecores;

    [LineNumberTable(new byte[] {25, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Teams.TeamData get(Team team)
    {
      if (this.map[team.__\u003C\u003Eid] == null)
        this.map[team.__\u003C\u003Eid] = new Teams.TeamData(team);
      return this.map[team.__\u003C\u003Eid];
    }

    [LineNumberTable(new byte[] {159, 174, 232, 56, 144, 139, 240, 69, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Teams()
    {
      Teams teams = this;
      this.map = new Teams.TeamData[256];
      this.active = new Seq();
      this.present = new Seq((Class) ClassLiteral<Teams.TeamData>.Value);
      this.active.add((object) this.get(Team.__\u003C\u003Ecrux));
    }

    [Signature("()Larc/struct/Seq<Lmindustry/game/Teams$TeamData;>;")]
    [LineNumberTable(new byte[] {55, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getActive()
    {
      this.active.removeAll((Boolf) new Teams.__\u003C\u003EAnon0());
      return this.active;
    }

    [Signature("(Lmindustry/game/Team;)Larc/struct/Seq<Lmindustry/world/blocks/storage/CoreBlock$CoreBuild;>;")]
    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq cores(Team team) => this.get(team).__\u003C\u003Ecores;

    [LineNumberTable(new byte[] {98, 108, 135, 118, 136, 105, 104, 109, 105, 172, 105, 205, 105, 111, 108, 16, 232, 48, 233, 89, 148, 127, 7, 110, 110, 110, 137, 127, 7, 168, 127, 0, 187, 118, 185, 155, 104, 165, 115, 136, 114, 237, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateTeamStats()
    {
      this.present.clear();
      this.boss = (Unit) null;
      Team[] all1 = Team.__\u003C\u003Eall;
      int length1 = all1.Length;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        Teams.TeamData teamData = all1[index1].data();
        Teams.TeamData.access\u0024002(teamData, false);
        teamData.unitCount = 0;
        teamData.units.clear();
        if (teamData.tree != null)
          teamData.tree.clear();
        if (teamData.typeCounts != null)
          Arrays.fill(teamData.typeCounts, 0);
        if (teamData.unitsByType != null)
        {
          for (int index2 = 0; index2 < teamData.unitsByType.Length; ++index2)
          {
            if (teamData.unitsByType[index2] != null)
              teamData.unitsByType[index2].clear();
          }
        }
      }
      Groups.build.each((Cons) new Teams.__\u003C\u003EAnon2());
      Iterator iterator = Groups.unit.iterator();
      while (iterator.hasNext())
      {
        Unit unit = (Unit) iterator.next();
        Teams.TeamData teamData = unit.team.data();
        teamData.tree().insert((QuadTree.QuadTreeObject) unit);
        teamData.units.add((object) unit);
        Teams.TeamData.access\u0024002(teamData, true);
        if (object.ReferenceEquals((object) unit.team, (object) Vars.state.rules.waveTeam) && unit.isBoss())
          this.boss = unit;
        if (teamData.unitsByType == null || teamData.unitsByType.Length <= (int) unit.type.__\u003C\u003Eid)
          teamData.unitsByType = new Seq[Vars.content.units().size];
        if (teamData.unitsByType[(int) unit.type.__\u003C\u003Eid] == null)
          teamData.unitsByType[(int) unit.type.__\u003C\u003Eid] = new Seq();
        teamData.unitsByType[(int) unit.type.__\u003C\u003Eid].add((object) unit);
        this.count(unit);
      }
      Team[] all2 = Team.__\u003C\u003Eall;
      int length2 = all2.Length;
      for (int index = 0; index < length2; ++index)
      {
        Teams.TeamData teamData = all2[index].data();
        if (Teams.TeamData.access\u0024000(teamData) || teamData.active())
          this.present.add((object) teamData);
      }
    }

    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canInteract(Team team, Team other) => object.ReferenceEquals((object) team, (object) other) || object.ReferenceEquals((object) other, (object) Team.__\u003C\u003Ederelict);

    [LineNumberTable(47)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CoreBlock.CoreBuild closestCore(float x, float y, Team team) => (CoreBlock.CoreBuild) Geometry.findClosest(x, y, (Iterable) this.get(team).__\u003C\u003Ecores);

    [LineNumberTable(new byte[] {159, 180, 121, 118, 7, 198})]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CoreBlock.CoreBuild closestEnemyCore(float x, float y, Team team)
    {
      Team[] coreEnemies = team.data().coreEnemies;
      int length = coreEnemies.Length;
      for (int index = 0; index < length; ++index)
      {
        Team team1 = coreEnemies[index];
        CoreBlock.CoreBuild closest = (CoreBlock.CoreBuild) Geometry.findClosest(x, y, (Iterable) team1.cores());
        if (closest != null)
          return closest;
      }
      return (CoreBlock.CoreBuild) null;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool areEnemies(Team team, Team other) => !object.ReferenceEquals((object) team, (object) other);

    [LineNumberTable(new byte[] {160, 98, 127, 20, 191, 1, 127, 4, 134, 127, 2, 117, 141, 130, 118, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updateEnemies()
    {
      if (Vars.state.rules.waves && !this.active.contains((object) this.get(Vars.state.rules.waveTeam)))
        this.active.add((object) this.get(Vars.state.rules.waveTeam));
      Iterator iterator1 = this.active.iterator();
      while (iterator1.hasNext())
      {
        Teams.TeamData teamData1 = (Teams.TeamData) iterator1.next();
        Seq seq = new Seq();
        Iterator iterator2 = this.active.iterator();
        while (iterator2.hasNext())
        {
          Teams.TeamData teamData2 = (Teams.TeamData) iterator2.next();
          if (this.areEnemies(teamData1.__\u003C\u003Eteam, teamData2.__\u003C\u003Eteam))
            seq.add((object) teamData2.__\u003C\u003Eteam);
        }
        teamData1.coreEnemies = (Team[]) seq.toArray((Class) ClassLiteral<Team>.Value);
      }
    }

    [LineNumberTable(new byte[] {86, 151, 127, 0, 246, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void count([In] Unit obj0)
    {
      obj0.team.data().updateCount(obj0.type, 1);
      Unit unit = obj0;
      Payloadc payloadc;
      if (!(unit is Payloadc) || !object.ReferenceEquals((object) (payloadc = (Payloadc) unit), (object) (Payloadc) unit))
        return;
      payloadc.payloads().each((Cons) new Teams.__\u003C\u003EAnon1(this));
    }

    [Modifiers]
    [LineNumberTable(105)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024getActive\u00240([In] Teams.TeamData obj0) => !obj0.active();

    [Modifiers]
    [LineNumberTable(new byte[] {90, 127, 0, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024count\u00241([In] Payload obj0)
    {
      Payload payload = obj0;
      UnitPayload unitPayload;
      if (!(payload is UnitPayload) || !object.ReferenceEquals((object) (unitPayload = (UnitPayload) payload), (object) (UnitPayload) payload))
        return;
      this.count(unitPayload.unit);
    }

    [Modifiers]
    [LineNumberTable(176)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024updateTeamStats\u00242([In] Building obj0) => Teams.TeamData.access\u0024002(obj0.team.data(), true);

    [Signature("(Lmindustry/game/Team;Larc/func/Boolf<Lmindustry/world/blocks/storage/CoreBlock$CoreBuild;>;)Z")]
    [LineNumberTable(new byte[] {1, 127, 1, 111, 127, 1, 105, 130, 130, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool eachEnemyCore(Team team, Boolf ret)
    {
      Iterator iterator1 = this.active.iterator();
label_1:
      while (iterator1.hasNext())
      {
        Teams.TeamData teamData = (Teams.TeamData) iterator1.next();
        if (this.areEnemies(team, teamData.__\u003C\u003Eteam))
        {
          Iterator iterator2 = teamData.__\u003C\u003Ecores.iterator();
          CoreBlock.CoreBuild coreBuild;
          do
          {
            if (iterator2.hasNext())
              coreBuild = (CoreBlock.CoreBuild) iterator2.next();
            else
              goto label_1;
          }
          while (!ret.get((object) coreBuild));
          return true;
        }
      }
      return false;
    }

    [Signature("(Lmindustry/game/Team;Larc/func/Cons<Lmindustry/gen/Building;>;)V")]
    [LineNumberTable(new byte[] {14, 127, 1, 111, 127, 1, 103, 130, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void eachEnemyCore(Team team, Cons ret)
    {
      Iterator iterator1 = this.active.iterator();
label_1:
      while (iterator1.hasNext())
      {
        Teams.TeamData teamData = (Teams.TeamData) iterator1.next();
        if (this.areEnemies(team, teamData.__\u003C\u003Eteam))
        {
          Iterator iterator2 = teamData.__\u003C\u003Ecores.iterator();
          while (true)
          {
            if (iterator2.hasNext())
            {
              Building building = (Building) iterator2.next();
              ret.get((object) building);
            }
            else
              goto label_1;
          }
        }
      }
    }

    [LineNumberTable(new byte[] {60, 141, 110, 204, 118, 108, 102, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void registerCore(CoreBlock.CoreBuild core)
    {
      Teams.TeamData teamData = this.get(core.team);
      if (!teamData.__\u003C\u003Ecores.contains((object) core))
        teamData.__\u003C\u003Ecores.add((object) core);
      if (!teamData.active() || this.active.contains((object) teamData))
        return;
      this.active.add((object) teamData);
      this.updateEnemies();
      Vars.indexer.updateTeamIndex(teamData.__\u003C\u003Eteam);
    }

    [LineNumberTable(new byte[] {75, 141, 141, 104, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unregisterCore(CoreBlock.CoreBuild entity)
    {
      Teams.TeamData teamData = this.get(entity.team);
      teamData.__\u003C\u003Ecores.remove((object) entity);
      if (teamData.active())
        return;
      this.active.remove((object) teamData);
      this.updateEnemies();
    }

    public class BlockPlan : Object
    {
      internal short __\u003C\u003Ex;
      internal short __\u003C\u003Ey;
      internal short __\u003C\u003Erotation;
      internal short __\u003C\u003Eblock;
      internal object __\u003C\u003Econfig;

      [LineNumberTable(new byte[] {159, 61, 101, 104, 104, 104, 103, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BlockPlan(int x, int y, short rotation, short block, object config)
      {
        int num1 = (int) rotation;
        int num2 = (int) block;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Teams.BlockPlan blockPlan = this;
        this.__\u003C\u003Ex = (short) x;
        this.__\u003C\u003Ey = (short) y;
        this.__\u003C\u003Erotation = (short) num1;
        this.__\u003C\u003Eblock = (short) num2;
        this.__\u003C\u003Econfig = config;
      }

      [Modifiers]
      public short x
      {
        [HideFromJava] get => this.__\u003C\u003Ex;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ex = value;
      }

      [Modifiers]
      public short y
      {
        [HideFromJava] get => this.__\u003C\u003Ey;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ey = value;
      }

      [Modifiers]
      public short rotation
      {
        [HideFromJava] get => this.__\u003C\u003Erotation;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Erotation = value;
      }

      [Modifiers]
      public short block
      {
        [HideFromJava] get => this.__\u003C\u003Eblock;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eblock = value;
      }

      [Modifiers]
      public object config
      {
        [HideFromJava] get => this.__\u003C\u003Econfig;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Econfig = value;
      }
    }

    public class TeamData : Object
    {
      [Signature("Larc/struct/Seq<Lmindustry/world/blocks/storage/CoreBlock$CoreBuild;>;")]
      internal Seq __\u003C\u003Ecores;
      internal Team __\u003C\u003Eteam;
      internal BaseAI __\u003C\u003Eai;
      private bool presentFlag;
      public Team[] coreEnemies;
      [Signature("Larc/struct/Queue<Lmindustry/game/Teams$BlockPlan;>;")]
      public Queue blocks;
      public UnitCommand command;
      [Signature("Larc/struct/Seq<Lmindustry/type/Item;>;")]
      public Seq mineItems;
      public int unitCount;
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public int[] typeCounts;
      [Signature("Larc/math/geom/QuadTree<Lmindustry/gen/Unit;>;")]
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public QuadTree tree;
      [Signature("Larc/struct/Seq<Lmindustry/gen/Unit;>;")]
      public Seq units;
      [Signature("[Larc/struct/Seq<Lmindustry/gen/Unit;>;")]
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Seq[] unitsByType;

      [LineNumberTable(293)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasCore() => this.__\u003C\u003Ecores.size > 0;

      [LineNumberTable(302)]
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual CoreBlock.CoreBuild core() => this.__\u003C\u003Ecores.isEmpty() ? (CoreBlock.CoreBuild) null : (CoreBlock.CoreBuild) this.__\u003C\u003Ecores.first();

      [LineNumberTable(285)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int countType(UnitType type) => this.typeCounts == null || this.typeCounts.Length <= (int) type.__\u003C\u003Eid ? 0 : this.typeCounts[(int) type.__\u003C\u003Eid];

      [LineNumberTable(307)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasAI() => this.__\u003C\u003Eteam.rules().ai;

      [LineNumberTable(297)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool noCores() => this.__\u003C\u003Ecores.isEmpty();

      [Signature("()Larc/math/geom/QuadTree<Lmindustry/gen/Unit;>;")]
      [LineNumberTable(new byte[] {160, 166, 127, 3})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual QuadTree tree()
      {
        if (this.tree == null)
          this.tree = new QuadTree(Vars.world.getQuadBounds(new Rect()));
        return this.tree;
      }

      [LineNumberTable(new byte[] {160, 157, 100, 116, 119, 154, 127, 3})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void updateCount(UnitType type, int amount)
      {
        if (type == null)
          return;
        this.unitCount = Math.max(amount + this.unitCount, 0);
        if (this.typeCounts == null || this.typeCounts.Length <= (int) type.__\u003C\u003Eid)
          this.typeCounts = new int[Vars.content.units().size];
        this.typeCounts[(int) type.__\u003C\u003Eid] = Math.max(amount + this.typeCounts[(int) type.__\u003C\u003Eid], 0);
      }

      [LineNumberTable(new byte[] {160, 145, 232, 35, 235, 71, 140, 139, 139, 255, 18, 75, 235, 70, 103, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TeamData(Team team)
      {
        Teams.TeamData teamData = this;
        this.__\u003C\u003Ecores = new Seq();
        this.coreEnemies = new Team[0];
        this.blocks = new Queue();
        this.command = UnitCommand.__\u003C\u003Eattack;
        this.mineItems = Seq.with((object[]) new Item[4]
        {
          Items.copper,
          Items.lead,
          Items.titanium,
          Items.thorium
        });
        this.units = new Seq();
        this.__\u003C\u003Eteam = team;
        this.__\u003C\u003Eai = new BaseAI(this);
      }

      [LineNumberTable(289)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool active() => object.ReferenceEquals((object) this.__\u003C\u003Eteam, (object) Vars.state.rules.waveTeam) && Vars.state.rules.waves || this.__\u003C\u003Ecores.size > 0;

      [Modifiers]
      [LineNumberTable(229)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static bool access\u0024002([In] Teams.TeamData obj0, [In] bool obj1)
      {
        int num1 = obj1 ? 1 : 0;
        Teams.TeamData teamData1 = obj0;
        int num2 = num1;
        Teams.TeamData teamData2 = teamData1;
        int num3 = num2;
        teamData2.presentFlag = num2 != 0;
        return num3 != 0;
      }

      [Modifiers]
      [LineNumberTable(229)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static bool access\u0024000([In] Teams.TeamData obj0) => obj0.presentFlag;

      [Signature("(Lmindustry/type/UnitType;)Larc/struct/Seq<Lmindustry/gen/Unit;>;")]
      [LineNumberTable(new byte[] {160, 152, 127, 9})]
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq unitCache(UnitType type) => this.unitsByType == null || this.unitsByType.Length <= (int) type.__\u003C\u003Eid || this.unitsByType[(int) type.__\u003C\u003Eid] == null ? (Seq) null : this.unitsByType[(int) type.__\u003C\u003Eid];

      [LineNumberTable(312)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => new StringBuilder().append("TeamData{cores=").append((object) this.__\u003C\u003Ecores).append(", team=").append((object) this.__\u003C\u003Eteam).append('}').toString();

      [Modifiers]
      public Seq cores
      {
        [HideFromJava] get => this.__\u003C\u003Ecores;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ecores = value;
      }

      [Modifiers]
      public Team team
      {
        [HideFromJava] get => this.__\u003C\u003Eteam;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eteam = value;
      }

      [Modifiers]
      public BaseAI ai
      {
        [HideFromJava] get => this.__\u003C\u003Eai;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eai = value;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (Teams.lambda\u0024getActive\u00240((Teams.TeamData) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly Teams arg\u00241;

      internal __\u003C\u003EAnon1([In] Teams obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024count\u00241((Payload) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public void get([In] object obj0) => Teams.lambda\u0024updateTeamStats\u00242((Building) obj0);
    }
  }
}
