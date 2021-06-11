// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.BuildingComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.scene;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.audio;
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.logic;
using mindustry.type;
using mindustry.ui;
using mindustry.world;
using mindustry.world.blocks;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.logic;
using mindustry.world.blocks.payloads;
using mindustry.world.blocks.power;
using mindustry.world.consumers;
using mindustry.world.meta;
using mindustry.world.modules;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Posc", "mindustry.gen.Teamc", "mindustry.gen.Healthc", "mindustry.gen.Buildingc", "mindustry.gen.Timerc", "arc.math.geom.QuadTree$QuadTreeObject", "mindustry.ui.Displayable", "mindustry.logic.Senseable", "mindustry.logic.Controllable", "mindustry.entities.comp.Sized"})]
  internal abstract class BuildingComp : 
    Object,
    Posc,
    Position,
    Entityc,
    Teamc,
    Healthc,
    Buildingc,
    QuadTree.QuadTreeObject,
    Displayable,
    Senseable,
    Controllable,
    Sized,
    Timerc
  {
    internal const float timeToSleep = 60f;
    internal const float timeToUncontrol = 360f;
    [Modifiers]
    [Signature("Larc/struct/ObjectSet<Lmindustry/gen/Building;>;")]
    internal static ObjectSet tmpTiles;
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    internal static Seq tempTileEnts;
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    internal static Seq tempTiles;
    internal static int sleepingEntities;
    internal float x;
    internal float y;
    internal float health;
    internal float maxHealth;
    internal Team team;
    [NonSerialized]
    internal Tile tile;
    [NonSerialized]
    internal Block block;
    [Signature("Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    [NonSerialized]
    internal Seq proximity;
    [NonSerialized]
    internal bool updateFlow;
    [NonSerialized]
    internal byte cdump;
    [NonSerialized]
    internal int rotation;
    [NonSerialized]
    internal bool enabled;
    [NonSerialized]
    internal float enabledControlTime;
    [NonSerialized]
    internal string lastAccessed;
    internal PowerModule power;
    internal ItemModule items;
    internal LiquidModule liquids;
    internal ConsumeModule cons;
    [NonSerialized]
    private float timeScale;
    [NonSerialized]
    private float timeScaleDuration;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [NonSerialized]
    private SoundLoop sound;
    [NonSerialized]
    private bool sleeping;
    [NonSerialized]
    private float sleepTime;
    [NonSerialized]
    private bool initialized;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {57, 107, 103, 135, 114, 183, 109, 109, 145, 118, 115, 115, 104, 107, 187, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building create([In] Block obj0, [In] Team obj1)
    {
      this.tile = Vars.emptyTile;
      this.block = obj0;
      this.team = obj1;
      if (!object.ReferenceEquals((object) obj0.loopSound, (object) Sounds.none))
        this.sound = new SoundLoop(obj0.loopSound, obj0.loopSoundVolume);
      this.health = (float) obj0.health;
      this.maxHealth((float) obj0.health);
      this.timer(new Interval(obj0.timers));
      this.cons = new ConsumeModule((Building) this.self());
      if (obj0.hasItems)
        this.items = new ItemModule();
      if (obj0.hasLiquids)
        this.liquids = new LiquidModule();
      if (obj0.hasPower)
      {
        this.power = new PowerModule();
        this.power.graph.add((Building) this.self());
      }
      this.initialized = true;
      return (Building) this.self();
    }

    [HideFromJava]
    public abstract Entityc self();

    [HideFromJava]
    public abstract void set([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void add();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void created()
    {
    }

    [HideFromJava]
    public abstract void maxHealth([In] float obj0);

    [HideFromJava]
    public abstract void timer([In] Interval obj0);

    [LineNumberTable(new byte[] {98, 108, 114, 113, 103, 114, 116, 116, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void writeBase([In] Writes obj0)
    {
      obj0.f(this.health);
      obj0.b(this.rotation | 128);
      obj0.b(this.team.__\u003C\u003Eid);
      obj0.b(1);
      obj0.b(!this.enabled ? 0 : 1);
      if (this.items != null)
        this.items.write(obj0);
      if (this.power != null)
        this.power.write(obj0);
      if (this.liquids != null)
        this.liquids.write(obj0);
      if (this.cons == null)
        return;
      this.cons.write(obj0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write([In] Writes obj0)
    {
    }

    [LineNumberTable(new byte[] {110, 109, 104, 146, 106, 98, 105, 104, 100, 104, 106, 104, 171, 162, 117, 117, 117, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void readBase([In] Reads obj0)
    {
      this.health = obj0.f();
      int num1 = (int) (sbyte) obj0.b();
      this.team = Team.get((int) (sbyte) obj0.b());
      this.rotation = num1 & (int) sbyte.MaxValue;
      int num2 = 1;
      if ((num1 & 128) != 0)
      {
        if (obj0.b() == (byte) 1)
        {
          this.enabled = obj0.b() == (byte) 1;
          if (!this.enabled)
            this.enabledControlTime = 360f;
        }
        num2 = 0;
      }
      if (this.items != null)
        this.items.read(obj0, num2 != 0);
      if (this.power != null)
        this.power.read(obj0, num2 != 0);
      if (this.liquids != null)
        this.liquids.read(obj0, num2 != 0);
      if (this.cons == null)
        return;
      this.cons.read(obj0, num2 != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read([In] Reads obj0, [In] byte obj1)
    {
    }

    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object config() => (object) null;

    [LineNumberTable(298)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte relativeTo([In] int obj0, [In] int obj1) => this.tile.absoluteRelativeTo(obj0, obj1);

    [LineNumberTable(286)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte relativeTo([In] Tile obj0) => this.relativeTo((int) obj0.x, (int) obj0.y);

    [LineNumberTable(274)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building nearby([In] int obj0, [In] int obj1) => Vars.world.build((int) this.tile.x + obj0, (int) this.tile.y + obj1);

    [HideFromJava]
    public abstract Team team();

    [LineNumberTable(new byte[] {160, 252, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float efficiency()
    {
      if (!this.enabled)
        return 0.0f;
      return this.power != null && this.block.__\u003C\u003Econsumes.has(ConsumeType.__\u003C\u003Epower) && !this.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ebuffered ? this.power.status : 1f;
    }

    [LineNumberTable(355)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float delta() => Time.delta * this.timeScale;

    [LineNumberTable(new byte[] {164, 237, 104, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      if (this.sound == null)
        return;
      this.sound.stop();
    }

    [LineNumberTable(528)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool acceptItem([In] Building obj0, [In] Item obj1) => this.block.__\u003C\u003Econsumes.__\u003C\u003EitemFilters.get((int) obj1.__\u003C\u003Eid) && this.items.get(obj1) < this.getMaximumAccepted(obj1);

    [LineNumberTable(445)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getMaximumAccepted([In] Item obj0) => this.block.itemCapacity;

    [LineNumberTable(new byte[] {161, 16, 107, 104, 102, 103, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void noSleep()
    {
      this.sleepTime = 0.0f;
      if (!this.sleeping)
        return;
      this.add();
      this.sleeping = false;
      --BuildingComp.sleepingEntities;
    }

    [LineNumberTable(new byte[] {162, 110, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void incrementDump([In] int obj0)
    {
      int num1 = (int) (sbyte) this.cdump + 1;
      int num2 = obj0;
      this.cdump = num2 != -1 ? (byte) (num1 % num2) : (byte) 0;
    }

    [LineNumberTable(new byte[] {161, 174, 136, 149, 159, 27, 115, 113, 127, 10, 147, 127, 34, 123, 156, 255, 4, 55, 233, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dumpLiquid([In] Liquid obj0, [In] float obj1)
    {
      int cdump = (int) (sbyte) this.cdump;
      if ((double) this.liquids.get(obj0) <= 9.99999974737875E-05)
        return;
      if (!Vars.net.client() && Vars.state.isCampaign() && object.ReferenceEquals((object) this.team, (object) Vars.state.rules.defaultTeam))
        obj0.unlock();
      for (int index1 = 0; index1 < this.proximity.size; ++index1)
      {
        this.incrementDump(this.proximity.size);
        Seq proximity = this.proximity;
        int num1 = index1 + cdump;
        int size = this.proximity.size;
        int index2 = size != -1 ? num1 % size : 0;
        Building liquidDestination = ((Building) proximity.get(index2)).getLiquidDestination((Building) this.self(), obj0);
        if (liquidDestination != null && object.ReferenceEquals((object) liquidDestination.team, (object) this.team) && (liquidDestination.block.hasLiquids && this.canDumpLiquid(liquidDestination, obj0)) && liquidDestination.liquids != null)
        {
          float num2 = liquidDestination.liquids.get(obj0) / liquidDestination.block.liquidCapacity;
          float num3 = this.liquids.get(obj0) / this.block.liquidCapacity;
          if ((double) num2 < (double) num3)
            this.transferLiquid(liquidDestination, (num3 - num2) * this.block.liquidCapacity / obj1, obj0);
        }
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canDumpLiquid([In] Building obj0, [In] Liquid obj1) => true;

    [LineNumberTable(new byte[] {161, 199, 159, 4, 116, 115, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void transferLiquid([In] Building obj0, [In] float obj1, [In] Liquid obj2)
    {
      float amount = Math.min(obj0.block.liquidCapacity - obj0.liquids.get(obj2), obj1);
      if (!obj0.acceptLiquid((Building) this.self(), obj2))
        return;
      obj0.handleLiquid((Building) this.self(), obj2, amount);
      this.liquids.remove(obj2, amount);
    }

    [LineNumberTable(new byte[] {161, 223, 137, 148, 127, 30, 123, 127, 9, 127, 12, 159, 3, 127, 1, 115, 109, 98, 159, 15, 159, 14, 109, 127, 23, 114, 114, 123, 146, 127, 23, 127, 12, 116, 237, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float moveLiquid([In] Building obj0, [In] Liquid obj1)
    {
      if (obj0 == null)
        return 0.0f;
      obj0 = obj0.getLiquidDestination((Building) this.self(), obj1);
      if (object.ReferenceEquals((object) obj0.team, (object) this.team) && obj0.block.hasLiquids && (double) this.liquids.get(obj1) > 0.0)
      {
        float num1 = obj0.liquids.get(obj1) / obj0.block.liquidCapacity;
        float num2 = this.liquids.get(obj1) / this.block.liquidCapacity * this.block.liquidPressure;
        float amount = Math.min(Math.min(Mathf.clamp(num2 - num1) * this.block.liquidCapacity, this.liquids.get(obj1)), obj0.block.liquidCapacity - obj0.liquids.get(obj1));
        if ((double) amount > 0.0 && (double) num1 <= (double) num2 && obj0.acceptLiquid((Building) this.self(), obj1))
        {
          obj0.handleLiquid((Building) this.self(), obj1, amount);
          this.liquids.remove(obj1, amount);
          return amount;
        }
        if ((double) (obj0.liquids.currentAmount() / obj0.block.liquidCapacity) > 0.100000001490116 && (double) num2 > 0.100000001490116)
        {
          float x = (this.x + obj0.x) / 2f;
          float y = (this.y + obj0.y) / 2f;
          Liquid liquid = obj0.liquids.current();
          if ((double) liquid.flammability > 0.300000011920929 && (double) obj1.temperature > 0.699999988079071 || (double) obj1.flammability > 0.300000011920929 && (double) liquid.temperature > 0.699999988079071)
          {
            this.damage(1f * Time.delta);
            obj0.damage(1f * Time.delta);
            if (Mathf.chance(0.1 * (double) Time.delta))
              Fx.__\u003C\u003Efire.at(x, y);
          }
          else if ((double) obj1.temperature > 0.699999988079071 && (double) liquid.temperature < 0.550000011920929 || (double) liquid.temperature > 0.699999988079071 && (double) obj1.temperature < 0.550000011920929)
          {
            this.liquids.remove(obj1, Math.min(this.liquids.get(obj1), 0.7f * Time.delta));
            if (Mathf.chance((double) (0.2f * Time.delta)))
              Fx.__\u003C\u003Esteam.at(x, y);
          }
        }
      }
      return 0.0f;
    }

    [LineNumberTable(new byte[] {164, 152, 137, 118, 145, 181, 159, 2, 109, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void damage([In] float obj0)
    {
      if (this.dead())
        return;
      if (Mathf.zero(Vars.state.rules.blockHealthMultiplier))
        obj0 = this.health + 1f;
      else
        obj0 /= Vars.state.rules.blockHealthMultiplier;
      Call.tileDamage((Building) this.self(), this.health - this.handleDamage(obj0));
      if ((double) this.health > 0.0)
        return;
      Call.tileDestroyed((Building) this.self());
    }

    [LineNumberTable(new byte[] {162, 60, 127, 41})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void produced([In] Item obj0, [In] int obj1)
    {
      if (Vars.state.rules.sector == null || !object.ReferenceEquals((object) this.team, (object) Vars.state.rules.defaultTeam))
        return;
      Vars.state.rules.sector.info.handleProduction(obj0, obj1);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canDump([In] Building obj0, [In] Item obj1) => true;

    [LineNumberTable(new byte[] {161, 154, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleItem([In] Building obj0, [In] Item obj1) => this.items.add(obj1, 1);

    [LineNumberTable(new byte[] {162, 73, 159, 14, 136, 143, 115, 159, 10, 134, 119, 141, 127, 38, 115, 110, 113, 226, 57, 235, 75, 127, 18, 114, 109, 113, 194, 241, 40, 233, 91})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool dump([In] Item obj0)
    {
      if (!this.block.hasItems || this.items.total() == 0 || obj0 != null && !this.items.has(obj0))
        return false;
      int cdump = (int) (sbyte) this.cdump;
      if (this.proximity.size == 0)
        return false;
      for (int index1 = 0; index1 < this.proximity.size; ++index1)
      {
        Seq proximity = this.proximity;
        int num = index1 + cdump;
        int size = this.proximity.size;
        int index2 = size != -1 ? num % size : 0;
        Building building = (Building) proximity.get(index2);
        if (obj0 == null)
        {
          for (int id = 0; id < Vars.content.items().size; ++id)
          {
            Item obj = Vars.content.item(id);
            if (object.ReferenceEquals((object) building.team, (object) this.team) && this.items.has(obj) && (building.acceptItem((Building) this.self(), obj) && this.canDump(building, obj)))
            {
              building.handleItem((Building) this.self(), obj);
              this.items.remove(obj, 1);
              this.incrementDump(this.proximity.size);
              return true;
            }
          }
        }
        else if (object.ReferenceEquals((object) building.team, (object) this.team) && building.acceptItem((Building) this.self(), obj0) && this.canDump(building, obj0))
        {
          building.handleItem((Building) this.self(), obj0);
          this.items.remove(obj0, 1);
          this.incrementDump(this.proximity.size);
          return true;
        }
        this.incrementDump(this.proximity.size);
      }
      return false;
    }

    [LineNumberTable(new byte[] {160, 189, 112})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building front()
    {
      int num = this.block.size / 2 + 1;
      return this.nearby(Geometry.d4(this.rotation).x * num, Geometry.d4(this.rotation).y * num);
    }

    [LineNumberTable(new byte[] {162, 148, 137, 123, 117, 124, 120, 252, 61, 233, 70, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void powerGraphRemoved()
    {
      if (this.power == null)
        return;
      this.power.graph.remove((Building) this.self());
      for (int index = 0; index < this.power.links.size; ++index)
      {
        Tile tile = Vars.world.tile(this.power.links.get(index));
        if (tile != null && tile.build != null && tile.build.power != null)
          tile.build.power.links.removeValue(this.pos());
      }
      this.power.links.clear();
    }

    [LineNumberTable(new byte[] {162, 140, 127, 6, 104, 155, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updatePowerGraph()
    {
      Iterator iterator = this.getPowerConnections(BuildingComp.tempTileEnts).iterator();
      while (iterator.hasNext())
      {
        Building building = (Building) iterator.next();
        if (building.power != null)
          building.power.graph.addGraph(this.power.graph);
      }
    }

    [Signature("(Larc/struct/Seq<Lmindustry/gen/Building;>;)Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    [LineNumberTable(new byte[] {162, 165, 103, 138, 127, 4, 191, 62, 127, 19, 135, 133, 120, 124, 31, 29, 201})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getPowerConnections([In] Seq obj0)
    {
      obj0.clear();
      if (this.power == null)
        return obj0;
      Iterator iterator = this.proximity.iterator();
      while (iterator.hasNext())
      {
        Building building = (Building) iterator.next();
        if (building != null && building.power != null && object.ReferenceEquals((object) building.team, (object) this.team) && (!this.block.consumesPower || !building.block.consumesPower || (this.block.outputsPower || building.block.outputsPower)) && (this.conductsTo(building) && building.conductsTo((Building) this.self()) && !this.power.links.contains(building.pos())))
          obj0.add((object) building);
      }
      for (int index = 0; index < this.power.links.size; ++index)
      {
        Tile tile = Vars.world.tile(this.power.links.get(index));
        if (tile != null && tile.build != null && (tile.build.power != null && object.ReferenceEquals((object) tile.build.team, (object) this.team)))
          obj0.add((object) tile.build);
      }
      return obj0;
    }

    [LineNumberTable(326)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int pos() => this.tile.pos();

    [LineNumberTable(787)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool conductsTo([In] Building obj0) => !this.block.insulated;

    [LineNumberTable(360)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float edelta() => this.efficiency() * this.delta();

    [LineNumberTable(811)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getProgressIncrease([In] float obj0) => 1f / obj0 * this.edelta();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shouldConsume() => this.enabled;

    [LineNumberTable(371)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BlockStatus status() => this.cons.status();

    [HideFromJava]
    public abstract bool damaged();

    [HideFromJava]
    public abstract float healthf();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float rotdeg() => (float) (this.rotation * 90);

    [LineNumberTable(new byte[] {162, 247, 114, 127, 26, 127, 9, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawTeamTop()
    {
      if (!this.block.teamRegion.found())
        return;
      if (object.ReferenceEquals((object) this.block.teamRegions[this.team.__\u003C\u003Eid], (object) this.block.teamRegion))
        Draw.color(this.team.__\u003C\u003Ecolor);
      Draw.rect(this.block.teamRegions[this.team.__\u003C\u003Eid], this.x, this.y);
      Draw.color();
    }

    [LineNumberTable(new byte[] {163, 5, 105, 103, 102, 106, 104, 191, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawLiquidLight([In] Liquid obj0, [In] float obj1)
    {
      if ((double) obj1 <= 0.00999999977648258)
        return;
      Color lightColor = obj0.lightColor;
      float num = 1f;
      float opacity = lightColor.a * num;
      if ((double) opacity <= 1.0 / 1000.0)
        return;
      Drawf.light(this.team, this.x, this.y, (float) this.block.size * 30f * num, lightColor, opacity);
    }

    [LineNumberTable(new byte[] {163, 62, 159, 12, 110, 110, 142, 107, 177, 115, 127, 0, 159, 0, 103, 107, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void configured([arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] Unit _param1, [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] object _param2)
    {
      Class @class = _param2 != null ? (!Object.instancehelper_getClass(_param2).isAnonymousClass() ? Object.instancehelper_getClass(_param2) : Object.instancehelper_getClass(_param2).getSuperclass()) : (Class) Void.TYPE;
      if (_param2 is Item)
        @class = (Class) ClassLiteral<Item>.Value;
      if (_param2 is Block)
        @class = (Class) ClassLiteral<Block>.Value;
      if (_param2 is Liquid)
        @class = (Class) ClassLiteral<Liquid>.Value;
      if (_param1 != null && _param1.isPlayer())
        this.lastAccessed = _param1.getPlayer().name;
      if (this.block.configurations.containsKey((object) @class))
      {
        ((Cons2) this.block.configurations.get((object) @class)).get((object) this, _param2);
      }
      else
      {
        object obj1 = _param2;
        Building building;
        if (!(obj1 is Building) || !object.ReferenceEquals((object) (building = (Building) obj1), (object) (Building) obj1))
          return;
        object obj2 = building.config();
        if (obj2 == null || obj2 is Building)
          return;
        this.configured(_param1, obj2);
      }
    }

    [LineNumberTable(334)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor floor() => this.tile.floor();

    [LineNumberTable(338)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool interactable([In] Team obj0) => Vars.state.teams.canInteract(obj0, this.team());

    [LineNumberTable(new byte[] {162, 129, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onProximityRemoved()
    {
      if (this.power == null)
        return;
      this.powerGraphRemoved();
    }

    [LineNumberTable(new byte[] {162, 135, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onProximityAdded()
    {
      if (!this.block.hasPower)
        return;
      this.updatePowerGraph();
    }

    [LineNumberTable(new byte[] {161, 99, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onProximityUpdate() => this.noSleep();

    [HideFromJava]
    public abstract bool dead();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float handleDamage([In] float obj0) => obj0;

    [LineNumberTable(1273)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isValid() => object.ReferenceEquals((object) this.tile.build, (object) this.self()) && !this.dead();

    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Payload getPayload() => (Payload) null;

    [LineNumberTable(new byte[] {164, 200, 127, 10, 107, 126, 127, 32, 127, 65, 229, 59})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object senseObject([In] LAccess obj0)
    {
      switch (BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[obj0.ordinal()])
      {
        case 25:
          return (object) this.block;
        case 26:
          return this.items == null ? (object) null : (object) this.items.first();
        case 27:
          return this.block.configurations.containsKey((object) ClassLiteral<Item>.Value) || this.block.configurations.containsKey((object) ClassLiteral<Liquid>.Value) ? this.config() : (object) null;
        case 28:
          Payload payload1 = this.getPayload();
          UnitPayload unitPayload;
          if (payload1 is UnitPayload && object.ReferenceEquals((object) (unitPayload = (UnitPayload) payload1), (object) (UnitPayload) payload1))
            return (object) unitPayload.unit.type;
          Payload payload2 = this.getPayload();
          BuildPayload buildPayload;
          return payload2 is BuildPayload && object.ReferenceEquals((object) (buildPayload = (BuildPayload) payload2), (object) (BuildPayload) payload2) ? (object) buildPayload.block() : (object) null;
        default:
          return Senseable.noSensed;
      }
    }

    [LineNumberTable(new byte[] {163, 90, 108, 102, 134, 112, 127, 9, 111, 112, 112, 119, 165, 109, 122, 186, 127, 10, 191, 7, 158, 246, 78, 159, 32, 122, 156})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onDestroyed()
    {
      float baseExplosiveness = this.block.baseExplosiveness;
      float flammability = 0.0f;
      float power = 0.0f;
      if (this.block.hasItems)
      {
        Iterator iterator = Vars.content.items().iterator();
        while (iterator.hasNext())
        {
          Item obj = (Item) iterator.next();
          int num = this.items.get(obj);
          baseExplosiveness += obj.explosiveness * (float) num;
          flammability += obj.flammability * (float) num;
          power += obj.charge * (float) num * 100f;
        }
      }
      if (this.block.hasLiquids)
      {
        flammability += this.liquids.sum((LiquidModule.LiquidCalculator) new BuildingComp.__\u003C\u003EAnon1());
        baseExplosiveness += this.liquids.sum((LiquidModule.LiquidCalculator) new BuildingComp.__\u003C\u003EAnon2());
      }
      if (this.block.__\u003C\u003Econsumes.hasPower() && this.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ebuffered)
        power += this.power.status * this.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ecapacity;
      if (this.block.hasLiquids && Vars.state.rules.damageExplosions)
        this.liquids.each((LiquidModule.LiquidConsumer) new BuildingComp.__\u003C\u003EAnon3(this));
      Damage.dynamicExplosion(this.x, this.y, flammability, baseExplosiveness * 3.5f, power, (float) (8 * this.block.size) / 2f, Vars.state.rules.damageExplosions);
      if (this.floor().solid || this.floor().isLiquid)
        return;
      Effect.rubble(this.x, this.y, this.block.size);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shouldActiveSound() => false;

    [LineNumberTable(825)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shouldAmbientSound() => this.shouldConsume();

    [LineNumberTable(1258)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float ambientVolume() => this.efficiency();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateTile()
    {
    }

    [LineNumberTable(new byte[] {163, 240, 191, 11, 127, 3, 188, 2, 97, 130, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void displayBars([In] Table obj0)
    {
      Iterator iterator = this.block.__\u003C\u003Ebars.list().iterator();
      while (iterator.hasNext())
      {
        Func func = (Func) iterator.next();
        try
        {
          obj0.add((Element) func.get((object) (Building) this.self())).growX();
          obj0.row();
          continue;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<ClassCastException>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
        break;
      }
    }

    [LineNumberTable(135)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileX() => (int) this.tile.x;

    [LineNumberTable(141)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileY() => (int) this.tile.y;

    [Modifiers]
    [LineNumberTable(new byte[] {163, 34, 120, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024placed\u00240([In] Building obj0)
    {
      if (obj0.power.links.contains(this.pos()))
        return;
      obj0.configureAny((object) Integer.valueOf(this.pos()));
    }

    [Modifiers]
    [LineNumberTable(986)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024onDestroyed\u00241([In] Liquid obj0, [In] float obj1) => obj0.flammability * obj1 / 2f;

    [Modifiers]
    [LineNumberTable(987)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024onDestroyed\u00242([In] Liquid obj0, [In] float obj1) => obj0.explosiveness * obj1 / 2f;

    [Modifiers]
    [LineNumberTable(new byte[] {163, 115, 154, 127, 0, 59, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024onDestroyed\u00244([In] Liquid obj0, [In] float obj1)
    {
      float num = Mathf.clamp(obj1 / 4f, 0.0f, 10f);
      for (int index = 0; (double) index < (double) Mathf.clamp(obj1 / 5f, 0.0f, 30f); ++index)
        Time.run((float) index / 2f, (Runnable) new BuildingComp.__\u003C\u003EAnon16(this, obj0, num));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 148, 103, 127, 8, 127, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00245([In] Table obj0)
    {
      obj0.left();
      obj0.add((Element) new Image(this.block.getDisplayIcon(this.tile))).size(32f);
      obj0.labelWrap(this.block.getDisplayName(this.tile)).left().width(190f).padLeft(5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 158, 159, 1, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00246([In] Table obj0)
    {
      obj0.defaults().growX().height(18f).pad(4f);
      this.displayBars(obj0);
    }

    [LineNumberTable(new byte[] {163, 232, 103, 126, 114, 18, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void displayConsumption([In] Table obj0)
    {
      obj0.left();
      Consume[] consumeArray = this.block.__\u003C\u003Econsumes.all();
      int length = consumeArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Consume consume = consumeArray[index];
        if (!consume.isOptional() || !consume.isBoost())
          consume.build((Building) this.self(), obj0);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 174, 134, 238, 76, 102, 244, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u002410([In] string obj0, [In] Table obj1)
    {
      Bits bits = new Bits();
      Runnable runnable = (Runnable) new BuildingComp.__\u003C\u003EAnon13(this, obj1, obj0);
      runnable.run();
      obj1.update((Runnable) new BuildingComp.__\u003C\u003EAnon14(this, bits, runnable));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 203, 139, 238, 71, 244, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u002415([In] string obj0, [In] Table obj1)
    {
      bool[] flagArray = new bool[1]{ false };
      Runnable runnable = (Runnable) new BuildingComp.__\u003C\u003EAnon9(this, obj1, obj0);
      obj1.update((Runnable) new BuildingComp.__\u003C\u003EAnon10(this, flagArray, runnable));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 206, 102, 103, 124, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u002413([In] Table obj0, [In] string obj1)
    {
      obj0.clearChildren();
      obj0.left();
      obj0.image((Prov) new BuildingComp.__\u003C\u003EAnon11(this)).padRight(3f);
      obj0.label((Prov) new BuildingComp.__\u003C\u003EAnon12(this, obj1)).color(Color.__\u003C\u003ElightGray);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 213, 114, 100, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u002414([In] bool[] obj0, [In] Runnable obj1)
    {
      if (obj0[0] || !this.liquids.hadFlow())
        return;
      obj0[0] = true;
      obj1.run();
    }

    [Modifiers]
    [LineNumberTable(1090)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private TextureRegion lambda\u0024display\u002411() => this.liquids.current().icon(Cicon.__\u003C\u003Esmall);

    [Modifiers]
    [LineNumberTable(1091)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private CharSequence lambda\u0024display\u002412([In] string obj0)
    {
      object obj = (double) this.liquids.getFlowRate() >= 0.0 ? (object) new StringBuilder().append(Strings.@fixed(this.liquids.getFlowRate(), 2)).append(obj0).toString() : (object) "...";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 177, 102, 103, 127, 5, 110, 124, 126, 135, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00248([In] Table obj0, [In] string obj1)
    {
      obj0.clearChildren();
      obj0.left();
      Iterator iterator = Vars.content.items().iterator();
      while (iterator.hasNext())
      {
        Item obj = (Item) iterator.next();
        if (this.items.hasFlowItem(obj))
        {
          obj0.image(obj.icon(Cicon.__\u003C\u003Esmall)).padRight(3f);
          obj0.label((Prov) new BuildingComp.__\u003C\u003EAnon15(this, obj, obj1)).color(Color.__\u003C\u003ElightGray);
          obj0.row();
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 190, 127, 5, 124, 108, 134, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00249([In] Bits obj0, [In] Runnable obj1)
    {
      Iterator iterator = Vars.content.items().iterator();
      while (iterator.hasNext())
      {
        Item obj = (Item) iterator.next();
        if (this.items.hasFlowItem(obj) && !obj0.get((int) obj.__\u003C\u003Eid))
        {
          obj0.set((int) obj.__\u003C\u003Eid);
          obj1.run();
        }
      }
    }

    [Modifiers]
    [LineNumberTable(1064)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private CharSequence lambda\u0024display\u00247([In] Item obj0, [In] string obj1)
    {
      object obj = (double) this.items.getFlowRate(obj0) >= 0.0 ? (object) new StringBuilder().append(Strings.@fixed(this.items.getFlowRate(obj0), 1)).append(obj1).toString() : (object) "...";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {163, 119, 127, 30, 99, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024onDestroyed\u00243([In] Liquid obj0, [In] float obj1)
    {
      Tile tile = Vars.world.tile(this.tileX() + Mathf.range(this.block.size / 2), this.tileY() + Mathf.range(this.block.size / 2));
      if (tile == null)
        return;
      Puddles.deposit(tile, obj0, obj1);
    }

    [LineNumberTable(new byte[] {159, 189, 232, 77, 204, 231, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal BuildingComp()
    {
      BuildingComp buildingComp = this;
      this.proximity = new Seq(8);
      this.enabled = true;
      this.timeScale = 1f;
    }

    [LineNumberTable(new byte[] {159, 122, 162, 104, 144, 141, 181, 104, 135, 148, 99, 166, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building init([In] Tile obj0, [In] Team obj1, [In] bool obj2, [In] int obj3)
    {
      int num = obj2 ? 1 : 0;
      if (!this.initialized)
        this.create(obj0.block(), obj1);
      else if (this.block.hasPower)
        new PowerGraph().add((Building) this.self());
      this.rotation = obj3;
      this.tile = obj0;
      this.set(obj0.drawx(), obj0.drawy());
      if (num != 0)
        this.add();
      this.created();
      return (Building) this.self();
    }

    [LineNumberTable(new byte[] {160, 71, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeAll([In] Writes obj0)
    {
      this.writeBase(obj0);
      this.write(obj0);
    }

    [LineNumberTable(new byte[] {159, 95, 131, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readAll([In] Reads obj0, [In] byte obj1)
    {
      int num = (int) (sbyte) obj1;
      this.readBase(obj0);
      this.read(obj0, (byte) num);
    }

    [LineNumberTable(new byte[] {159, 90, 66, 159, 36, 130, 159, 5, 125, 108, 169, 193, 151, 166, 115, 117, 127, 9, 111, 226, 60, 235, 73, 127, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addPlan([In] bool obj0)
    {
      int num = obj0 ? 1 : 0;
      if (!this.block.rebuildable || object.ReferenceEquals((object) this.team, (object) Vars.state.rules.defaultTeam) && Vars.state.isCampaign() && !this.block.isVisible())
        return;
      object obj = (object) null;
      Entityc entityc = this.self();
      ConstructBlock.ConstructBuild constructBuild;
      if (entityc is ConstructBlock.ConstructBuild && object.ReferenceEquals((object) (constructBuild = (ConstructBlock.ConstructBuild) entityc), (object) (ConstructBlock.ConstructBuild) entityc))
      {
        if (constructBuild.cblock == null || !constructBuild.cblock.synthetic() || !constructBuild.wasConstructing)
          return;
        this.block = constructBuild.cblock;
        obj = constructBuild.lastConfig;
      }
      Teams.TeamData teamData = Vars.state.teams.get(this.team);
      if (num != 0)
      {
        for (int index = 0; index < teamData.blocks.size; ++index)
        {
          Teams.BlockPlan blockPlan = (Teams.BlockPlan) teamData.blocks.get(index);
          if ((int) blockPlan.__\u003C\u003Ex == (int) this.tile.x && (int) blockPlan.__\u003C\u003Ey == (int) this.tile.y)
          {
            teamData.blocks.removeIndex(index);
            break;
          }
        }
      }
      teamData.blocks.addFirst((object) new Teams.BlockPlan((int) this.tile.x, (int) this.tile.y, (short) this.rotation, this.block.__\u003C\u003Eid, obj ?? this.config()));
    }

    [LineNumberTable(new byte[] {160, 129, 108, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void configure([In] object obj0)
    {
      this.block.lastConfig = obj0;
      Call.tileConfig(Vars.player, (Building) this.self(), obj0);
    }

    [LineNumberTable(new byte[] {160, 135, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void configureAny([In] object obj0) => Call.tileConfig((Player) null, (Building) this.self(), obj0);

    [LineNumberTable(new byte[] {160, 140, 127, 14, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void deselect()
    {
      if (Vars.headless || !object.ReferenceEquals((object) Vars.control.input.__\u003C\u003Efrag.__\u003C\u003Econfig.getSelectedTile(), (object) this.self()))
        return;
      Vars.control.input.__\u003C\u003Efrag.__\u003C\u003Econfig.hideConfig();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool configTapped() => true;

    [LineNumberTable(new byte[] {160, 153, 106, 148, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void applyBoost([In] float obj0, [In] float obj1)
    {
      if ((double) obj0 >= (double) this.timeScale)
        this.timeScaleDuration = Math.max(this.timeScaleDuration, obj1);
      this.timeScale = Math.max(this.timeScale, obj0);
    }

    [LineNumberTable(new byte[] {160, 164, 127, 7, 127, 8, 127, 8, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building nearby([In] int obj0)
    {
      switch (obj0)
      {
        case 0:
          return Vars.world.build((int) this.tile.x + 1, (int) this.tile.y);
        case 1:
          return Vars.world.build((int) this.tile.x, (int) this.tile.y + 1);
        case 2:
          return Vars.world.build((int) this.tile.x - 1, (int) this.tile.y);
        case 3:
          return Vars.world.build((int) this.tile.x, (int) this.tile.y - 1);
        default:
          return (Building) null;
      }
    }

    [LineNumberTable(290)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte relativeTo([In] Building obj0) => this.relativeTo(obj0.tile());

    [LineNumberTable(294)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte relativeToEdge([In] Tile obj0) => this.relativeTo(Edges.getFacingEdge(obj0, this.tile));

    [LineNumberTable(new byte[] {160, 195, 112})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building back()
    {
      int num = this.block.size / 2 + 1;
      return this.nearby(Geometry.d4(this.rotation + 2).x * num, Geometry.d4(this.rotation + 2).y * num);
    }

    [LineNumberTable(new byte[] {160, 201, 112})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building left()
    {
      int num = this.block.size / 2 + 1;
      return this.nearby(Geometry.d4(this.rotation + 1).x * num, Geometry.d4(this.rotation + 1).y * num);
    }

    [LineNumberTable(new byte[] {160, 207, 112})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building right()
    {
      int num = this.block.size / 2 + 1;
      return this.nearby(Geometry.d4(this.rotation + 3).x * num, Geometry.d4(this.rotation + 3).y * num);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float timeScale() => this.timeScale;

    [LineNumberTable(346)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool consValid() => this.cons.valid();

    [LineNumberTable(new byte[] {160, 236, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void consume() => this.cons.trigger();

    [LineNumberTable(new byte[] {161, 6, 115, 117, 102, 103, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sleep()
    {
      this.sleepTime += Time.delta;
      if (this.sleeping || (double) this.sleepTime < 60.0)
        return;
      this.remove();
      this.sleeping = true;
      ++BuildingComp.sleepingEntities;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte version() => 0;

    [LineNumberTable(403)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canUnload() => this.block.unloadable;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void itemTaken([In] Item obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dropped()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleString([In] object obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool productionValid() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPowerProduction() => 0.0f;

    [LineNumberTable(new byte[] {161, 67, 127, 24, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int acceptStack([In] Item obj0, [In] int obj1, [In] Teamc obj2) => this.acceptItem((Building) this.self(), obj0) && this.block.hasItems && (obj2 == null || object.ReferenceEquals((object) obj2.team(), (object) this.team)) ? Math.min(this.getMaximumAccepted(obj0) - this.items.get(obj0), obj1) : 0;

    [LineNumberTable(new byte[] {161, 80, 106, 116, 102, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int removeStack([In] Item obj0, [In] int obj1)
    {
      if (this.items == null)
        return 0;
      obj1 = Math.min(obj1, this.items.get(obj0));
      this.noSleep();
      this.items.remove(obj0, obj1);
      return obj1;
    }

    [LineNumberTable(new byte[] {161, 89, 102, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleStack(Item _param1, int _param2, [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] Teamc _param3)
    {
      this.noSleep();
      this.items.add(_param1, _param2);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getStackOffset([In] Item obj0, [In] Vec2 obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool acceptPayload([In] Building obj0, [In] Payload obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handlePayload([In] Building obj0, [In] Payload obj1)
    {
    }

    [LineNumberTable(new byte[] {161, 117, 112, 159, 17, 127, 29, 119, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool movePayload([In] Payload obj0)
    {
      int num = this.block.size / 2 + 1;
      Tile tile = this.tile.nearby(Geometry.d4(this.rotation).x * num, Geometry.d4(this.rotation).y * num);
      if (tile == null || tile.build == null || (!object.ReferenceEquals((object) tile.build.team, (object) this.team) || !tile.build.acceptPayload((Building) this.self(), obj0)))
        return false;
      tile.build.handlePayload((Building) this.self(), obj0);
      return true;
    }

    [LineNumberTable(new byte[] {161, 134, 143, 136, 115, 159, 10, 127, 8, 114, 113, 162, 241, 55, 233, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool dumpPayload([In] Payload obj0)
    {
      if (this.proximity.size == 0)
        return false;
      int cdump = (int) (sbyte) this.cdump;
      for (int index1 = 0; index1 < this.proximity.size; ++index1)
      {
        Seq proximity = this.proximity;
        int num = index1 + cdump;
        int size = this.proximity.size;
        int index2 = size != -1 ? num % size : 0;
        Building building = (Building) proximity.get(index2);
        if (object.ReferenceEquals((object) building.team, (object) this.team) && building.acceptPayload((Building) this.self(), obj0))
        {
          building.handlePayload((Building) this.self(), obj0);
          this.incrementDump(this.proximity.size);
          return true;
        }
        this.incrementDump(this.proximity.size);
      }
      return false;
    }

    [LineNumberTable(532)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool acceptLiquid([In] Building obj0, [In] Liquid obj1) => this.block.hasLiquids && this.block.__\u003C\u003Econsumes.__\u003C\u003Eliquidfilters.get((int) obj1.__\u003C\u003Eid);

    [LineNumberTable(new byte[] {161, 166, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleLiquid([In] Building obj0, [In] Liquid obj1, [In] float obj2) => this.liquids.add(obj1, obj2);

    [LineNumberTable(new byte[] {161, 170, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dumpLiquid([In] Liquid obj0) => this.dumpLiquid(obj0, 2f);

    [LineNumberTable(new byte[] {158, 254, 130, 146, 137, 104, 111, 125, 117, 110, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float moveLiquidForward([In] bool obj0, [In] Liquid obj1)
    {
      int num = obj0 ? 1 : 0;
      Tile tile = this.tile.nearby(this.rotation);
      if (tile == null)
        return 0.0f;
      if (tile.build != null)
        return this.moveLiquid(tile.build, obj1);
      if (num != 0 && !tile.block().solid && !tile.block().hasLiquids)
      {
        float amount = this.liquids.get(obj1) / 1.5f;
        Puddles.deposit(tile, this.tile, obj1, amount);
        this.liquids.remove(obj1, amount);
      }
      return 0.0f;
    }

    [LineNumberTable(630)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building getLiquidDestination([In] Building obj0, [In] Liquid obj1) => (Building) this.self();

    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Payload takePayload() => (Payload) null;

    [LineNumberTable(new byte[] {162, 21, 104, 104, 159, 27, 115, 113, 127, 10, 127, 18, 114, 225, 59, 233, 73, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void offload([In] Item obj0)
    {
      this.produced(obj0, 1);
      int cdump = (int) (sbyte) this.cdump;
      if (!Vars.net.client() && Vars.state.isCampaign() && object.ReferenceEquals((object) this.team, (object) Vars.state.rules.defaultTeam))
        obj0.unlock();
      for (int index1 = 0; index1 < this.proximity.size; ++index1)
      {
        this.incrementDump(this.proximity.size);
        Seq proximity = this.proximity;
        int num = index1 + cdump;
        int size = this.proximity.size;
        int index2 = size != -1 ? num % size : 0;
        Building building = (Building) proximity.get(index2);
        if (object.ReferenceEquals((object) building.team, (object) this.team) && building.acceptItem((Building) this.self(), obj0) && this.canDump(building, obj0))
        {
          building.handleItem((Building) this.self(), obj0);
          return;
        }
      }
      this.handleItem((Building) this.self(), obj0);
    }

    [LineNumberTable(new byte[] {162, 41, 136, 115, 113, 127, 10, 127, 18, 114, 226, 59, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool put([In] Item obj0)
    {
      int cdump = (int) (sbyte) this.cdump;
      for (int index1 = 0; index1 < this.proximity.size; ++index1)
      {
        this.incrementDump(this.proximity.size);
        Seq proximity = this.proximity;
        int num = index1 + cdump;
        int size = this.proximity.size;
        int index2 = size != -1 ? num % size : 0;
        Building building = (Building) proximity.get(index2);
        if (object.ReferenceEquals((object) building.team, (object) this.team) && building.acceptItem((Building) this.self(), obj0) && this.canDump(building, obj0))
        {
          building.handleItem((Building) this.self(), obj0);
          return true;
        }
      }
      return false;
    }

    [LineNumberTable(new byte[] {162, 56, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void produced([In] Item obj0) => this.produced(obj0, 1);

    [LineNumberTable(691)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool dump() => this.dump((Item) null);

    [LineNumberTable(new byte[] {162, 120, 103, 127, 11, 114, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool moveForward([In] Item obj0)
    {
      Building building = this.front();
      if (building == null || !object.ReferenceEquals((object) building.team, (object) this.team) || !building.acceptItem((Building) this.self(), obj0))
        return false;
      building.handleItem((Building) this.self(), obj0);
      return true;
    }

    [LineNumberTable(815)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getDisplayEfficiency() => this.getProgressIncrease(1f) / this.edelta();

    [LineNumberTable(new byte[] {162, 203, 127, 6, 123, 127, 16, 159, 16, 106, 106, 116, 112, 116, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawStatus()
    {
      if (!this.block.enableDrawStatus || !this.block.__\u003C\u003Econsumes.any())
        return;
      float num = this.block.size <= 1 ? 0.64f : 1f;
      float x = this.x + (float) (this.block.size * 8) / 2f - 8f * num / 2f;
      float y = this.y - (float) (this.block.size * 8) / 2f + 8f * num / 2f;
      Draw.z(71f);
      Draw.color(Pal.gray);
      Fill.square(x, y, 2.5f * num, 45f);
      Draw.color(this.status().__\u003C\u003Ecolor);
      Fill.square(x, y, 1.5f * num, 45f);
      Draw.color();
    }

    [LineNumberTable(new byte[] {162, 218, 120, 103, 127, 33, 127, 7, 127, 3, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawCracks()
    {
      if (!this.damaged() || this.block.size > 9)
        return;
      int num1 = this.pos();
      TextureRegion textureRegion = Vars.renderer.__\u003C\u003Eblocks.cracks[this.block.size - 1][Mathf.clamp(ByteCodeHelper.f2i((1f - this.healthf()) * 8f), 0, 7)];
      Draw.colorl(0.2f, 0.1f + (1f - this.healthf()) * 0.6f);
      TextureRegion region = textureRegion;
      double x = (double) this.x;
      double y = (double) this.y;
      int num2 = num1;
      int num3 = 4;
      double num4 = (double) ((num3 != -1 ? num2 % num3 : 0) * 90);
      Draw.rect(region, (float) x, (float) y, (float) num4);
      Draw.color();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawSelect()
    {
    }

    [LineNumberTable(new byte[] {162, 231, 106, 138, 102, 157, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawDisabled()
    {
      Draw.color(Color.__\u003C\u003Escarlet);
      Draw.alpha(0.8f);
      float num = 6f;
      Draw.rect(Icon.cancel.getRegion(), this.x, this.y, num, num);
      Draw.reset();
    }

    [LineNumberTable(new byte[] {162, 241, 159, 24, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      Draw.rect(this.block.region, this.x, this.y, !this.block.rotate ? 0.0f : this.rotdeg());
      this.drawTeamTop();
    }

    [LineNumberTable(new byte[] {162, 255, 127, 23, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawLight()
    {
      if (!this.block.hasLiquids || !this.block.drawLiquidLight || (double) this.liquids.current().lightColor.a <= 1.0 / 1000.0)
        return;
      this.drawLiquidLight(this.liquids.current(), this.liquids.smoothAmount());
    }

    [LineNumberTable(new byte[] {163, 16, 112, 127, 51, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawTeam()
    {
      Draw.color(this.team.__\u003C\u003Ecolor);
      Draw.rect("block-border", this.x - (float) (this.block.size * 8) / 2f + 4f, this.y - (float) (this.block.size * 8) / 2f + 4f);
      Draw.color();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void playerPlaced([In] object obj0)
    {
    }

    [LineNumberTable(new byte[] {163, 30, 141, 127, 8, 255, 3, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void placed()
    {
      if (Vars.net.client() || !this.block.consumesPower && !this.block.outputsPower || !this.block.hasPower)
        return;
      PowerNode.getNodeLinks(this.tile, this.block, this.team, (Cons) new BuildingComp.__\u003C\u003EAnon0(this));
    }

    [Signature("(Larc/struct/Seq<Lmindustry/gen/Building;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void overwrote([In] Seq obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onRemoved()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unitOn([In] Unit obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unitRemoved([In] Unit obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tapped()
    {
    }

    [LineNumberTable(1018)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getDisplayName() => this.block.localizedName;

    [LineNumberTable(1022)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion getDisplayIcon() => this.block.icon(Cicon.__\u003C\u003Emedium);

    [LineNumberTable(new byte[] {163, 147, 209, 139, 167, 122, 209, 102, 103, 151, 159, 50, 102, 159, 5, 104, 103, 103, 242, 88, 166, 104, 103, 242, 80, 198, 116, 103, 191, 37, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display([In] Table obj0)
    {
      obj0.table((Cons) new BuildingComp.__\u003C\u003EAnon4(this)).growX().left();
      obj0.row();
      if (!object.ReferenceEquals((object) this.team, (object) Vars.player.team()))
        return;
      obj0.table((Cons) new BuildingComp.__\u003C\u003EAnon5(this)).growX();
      obj0.row();
      obj0.table((Cons) new BuildingComp.__\u003C\u003EAnon6(this)).growX();
      if ((!object.ReferenceEquals((object) this.block.category, (object) Category.__\u003C\u003Edistribution) && !object.ReferenceEquals((object) this.block.category, (object) Category.__\u003C\u003Eliquid) || (!Core.settings.getBool("flow") || !this.block.displayFlow) ? 0 : 1) != 0)
      {
        string str = new StringBuilder().append(" ").append(StatUnit.__\u003C\u003EperSecond.localized()).toString();
        if (this.items != null)
        {
          obj0.row();
          obj0.left();
          obj0.table((Cons) new BuildingComp.__\u003C\u003EAnon7(this, str)).left();
        }
        if (this.liquids != null)
        {
          obj0.row();
          obj0.table((Cons) new BuildingComp.__\u003C\u003EAnon8(this, str)).left();
        }
      }
      if (Vars.net.active() && this.lastAccessed != null)
      {
        obj0.row();
        Table table = obj0;
        object obj = (object) Core.bundle.format("lastaccessed", (object) this.lastAccessed);
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table.add(text).growX().wrap().left();
      }
      obj0.marginBottom(-5f);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void buildConfiguration([In] Table obj0)
    {
    }

    [LineNumberTable(new byte[] {164, 2, 127, 22, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateTableAlign([In] Table obj0)
    {
      Vec2 vec2 = Core.input.mouseScreen(this.x, this.y - (float) (this.block.size * 8) / 2f - 1f);
      obj0.setPosition(vec2.x, vec2.y, 2);
    }

    [LineNumberTable(1146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Graphics.Cursor getCursor() => this.block.configurable && this.interactable(Vars.player.team()) ? (Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Ehand : (Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Earrow;

    [LineNumberTable(1154)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool onConfigureTileTapped([In] Building obj0) => !object.ReferenceEquals((object) this.self(), (object) obj0);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shouldShowConfigure([In] Player obj0) => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shouldHideConfigure([In] Player obj0) => false;

    [LineNumberTable(new byte[] {164, 30, 106, 106, 127, 14, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawConfigure()
    {
      Draw.color(Pal.accent);
      Lines.stroke(1f);
      Lines.square(this.x, this.y, (float) (this.block.size * 8) / 2f + 1f);
      Draw.reset();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool checkSolid() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool collide([In] Bullet obj0) => true;

    [LineNumberTable(new byte[] {164, 51, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool collision([In] Bullet obj0)
    {
      this.damage(obj0.damage() * obj0.type().buildingDamageMultiplier);
      return true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canPickup() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void pickedUp()
    {
    }

    [LineNumberTable(new byte[] {164, 65, 102, 138, 113, 112, 159, 19, 100, 237, 60, 230, 72, 127, 4, 121, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeFromProximity()
    {
      this.onProximityRemoved();
      BuildingComp.tmpTiles.clear();
      Point2[] edges = Edges.getEdges(this.block.size);
      int length = edges.Length;
      for (int index = 0; index < length; ++index)
      {
        Point2 point2 = edges[index];
        Building building = Vars.world.build((int) this.tile.x + point2.x, (int) this.tile.y + point2.y);
        if (building != null)
          BuildingComp.tmpTiles.add((object) building);
      }
      ObjectSet.ObjectSetIterator objectSetIterator = BuildingComp.tmpTiles.iterator();
      while (((Iterator) objectSetIterator).hasNext())
      {
        Building building = (Building) ((Iterator) objectSetIterator).next();
        building.proximity.remove((object) (Building) this.self(), true);
        building.onProximityUpdate();
      }
    }

    [LineNumberTable(new byte[] {164, 84, 106, 140, 113, 115, 159, 19, 186, 122, 183, 237, 54, 233, 78, 127, 4, 109, 130, 102, 134, 127, 4, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateProximity()
    {
      BuildingComp.tmpTiles.clear();
      this.proximity.clear();
      Point2[] edges = Edges.getEdges(this.block.size);
      int length = edges.Length;
      for (int index = 0; index < length; ++index)
      {
        Point2 point2 = edges[index];
        Building building = Vars.world.build((int) this.tile.x + point2.x, (int) this.tile.y + point2.y);
        if (building != null && building.tile.interactable(this.team))
        {
          if (!building.proximity.contains((object) (Building) this.self(), true))
            building.proximity.add((object) (Building) this.self());
          BuildingComp.tmpTiles.add((object) building);
        }
      }
      ObjectSet.ObjectSetIterator objectSetIterator1 = BuildingComp.tmpTiles.iterator();
      while (((Iterator) objectSetIterator1).hasNext())
        this.proximity.add((object) (Building) ((Iterator) objectSetIterator1).next());
      this.onProximityAdded();
      this.onProximityUpdate();
      ObjectSet.ObjectSetIterator objectSetIterator2 = BuildingComp.tmpTiles.iterator();
      while (((Iterator) objectSetIterator2).hasNext())
        ((Building) ((Iterator) objectSetIterator2).next()).onProximityUpdate();
    }

    [LineNumberTable(1278)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float hitSize() => (float) (this.tile.block().size * 8);

    [LineNumberTable(new byte[] {164, 146, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void kill() => Call.tileDestroyed((Building) this.self());

    [LineNumberTable(new byte[] {164, 169, 127, 89, 114, 114, 124, 113, 108, 108, 109, 108, 127, 27, 108, 127, 4, 127, 5, 127, 75, 127, 9, 127, 9, 127, 24, 127, 17, 127, 17, 127, 10, 127, 10, 124, 127, 15, 118, 110, 233, 39})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double sense([In] LAccess obj0)
    {
      switch (BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[obj0.ordinal()])
      {
        case 1:
          return (double) World.conv(this.x);
        case 2:
          return (double) World.conv(this.y);
        case 3:
          return !this.isValid() ? 1.0 : 0.0;
        case 4:
          return (double) this.team.__\u003C\u003Eid;
        case 5:
          return (double) this.health;
        case 6:
          return (double) this.maxHealth;
        case 7:
          return (double) this.efficiency();
        case 8:
          return (double) this.timeScale;
        case 9:
          BuildingComp buildingComp1 = this;
          Ranged ranged;
          return !(buildingComp1 is Ranged) || !object.ReferenceEquals((object) (ranged = (Ranged) buildingComp1), (object) (Ranged) buildingComp1) ? 0.0 : (double) (ranged.range() / 8f);
        case 10:
          return (double) this.rotation;
        case 11:
          return this.items == null ? 0.0 : (double) this.items.total();
        case 12:
          return this.liquids == null ? 0.0 : (double) this.liquids.total();
        case 13:
          return this.power == null || !this.block.__\u003C\u003Econsumes.hasPower() ? 0.0 : (double) this.power.status * (!this.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ebuffered ? 1.0 : (double) this.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ecapacity);
        case 14:
          return this.block.hasItems ? (double) this.block.itemCapacity : 0.0;
        case 15:
          return this.block.hasLiquids ? (double) this.block.liquidCapacity : 0.0;
        case 16:
          return this.block.__\u003C\u003Econsumes.hasPower() ? (double) this.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ecapacity : 0.0;
        case 17:
          return this.power == null ? 0.0 : (double) (this.power.graph.getLastScaledPowerIn() * 60f);
        case 18:
          return this.power == null ? 0.0 : (double) (this.power.graph.getLastScaledPowerOut() * 60f);
        case 19:
          return this.power == null ? 0.0 : (double) this.power.graph.getLastPowerStored();
        case 20:
          return this.power == null ? 0.0 : (double) this.power.graph.getLastCapacity();
        case 21:
          return this.enabled ? 1.0 : 0.0;
        case 22:
          BuildingComp buildingComp2 = this;
          ControlBlock controlBlock;
          return !(buildingComp2 is ControlBlock) || !object.ReferenceEquals((object) (controlBlock = (ControlBlock) buildingComp2), (object) (ControlBlock) buildingComp2) || !controlBlock.isControlled() ? 0.0 : 2.0;
        case 23:
          return this.getPayload() != null ? 1.0 : 0.0;
        case 24:
          return (double) this.block.size;
        default:
          return double.NaN;
      }
    }

    [LineNumberTable(new byte[] {164, 211, 127, 22, 127, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double sense([In] Content obj0)
    {
      Content content1 = obj0;
      Item obj;
      if (content1 is Item && object.ReferenceEquals((object) (obj = (Item) content1), (object) (Item) content1) && this.items != null)
        return (double) this.items.get(obj);
      Content content2 = obj0;
      Liquid liquid;
      return content2 is Liquid && object.ReferenceEquals((object) (liquid = (Liquid) content2), (object) (Liquid) content2) && this.liquids != null ? (double) this.liquids.get(liquid) : double.NaN;
    }

    [LineNumberTable(new byte[] {164, 218, 109, 116, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void control([In] LAccess obj0, [In] double obj1, [In] double obj2, [In] double obj3, [In] double obj4)
    {
      if (!object.ReferenceEquals((object) obj0, (object) LAccess.__\u003C\u003Eenabled))
        return;
      this.enabled = !Mathf.zero((float) obj1);
      this.enabledControlTime = 360f;
    }

    [LineNumberTable(new byte[] {164, 227, 159, 3, 115, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void control([In] LAccess obj0, [In] object obj1, [In] double obj2, [In] double obj3, [In] double obj4)
    {
      if (!object.ReferenceEquals((object) obj0, (object) LAccess.__\u003C\u003Econfigure) || !this.block.logicConfigurable || (obj1 is LogicBlock.LogicBuild || object.ReferenceEquals(this.senseObject(LAccess.__\u003C\u003Econfig), obj1)))
        return;
      this.configured((Unit) null, obj1);
    }

    [LineNumberTable(new byte[] {164, 244, 112, 119, 102, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void killed()
    {
      Events.fire((object) new EventType.BlockDestroyEvent(this.tile));
      this.block.breakSound.at((Position) this.tile);
      this.onDestroyed();
      this.tile.remove();
      this.remove();
    }

    [LineNumberTable(new byte[] {164, 254, 141, 115, 122, 171, 117, 102, 147, 109, 199, 114, 167, 106, 104, 189, 127, 0, 223, 26, 117, 166, 104, 177, 104, 177, 104, 171, 104, 176, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (Vars.state.isEditor())
        return;
      this.timeScaleDuration -= Time.delta;
      if ((double) this.timeScaleDuration <= 0.0 || !this.block.canOverdrive)
        this.timeScale = 1f;
      if (!this.enabled && this.block.autoResetEnabled)
      {
        this.noSleep();
        this.enabledControlTime -= Time.delta;
        if ((double) this.enabledControlTime <= 0.0)
          this.enabled = true;
      }
      if (object.ReferenceEquals((object) this.team, (object) Team.__\u003C\u003Ederelict))
        this.enabled = false;
      if (!Vars.headless)
      {
        if (this.sound != null)
          this.sound.update(this.x, this.y, this.shouldActiveSound());
        if (!object.ReferenceEquals((object) this.block.ambientSound, (object) Sounds.none) && this.shouldAmbientSound())
          Vars.control.sound.loop(this.block.ambientSound, (Position) this.self(), this.block.ambientSoundVolume * this.ambientVolume());
      }
      if (this.enabled || !this.block.noUpdateDisabled)
        this.updateTile();
      if (this.items != null)
        this.items.update(this.updateFlow);
      if (this.liquids != null)
        this.liquids.update(this.updateFlow);
      if (this.cons != null)
        this.cons.update();
      if (this.power != null)
        this.power.graph.update();
      this.updateFlow = false;
    }

    [LineNumberTable(new byte[] {165, 53, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hitbox([In] Rect obj0) => obj0.setCentered(this.x, this.y, (float) (this.block.size * 8), (float) (this.block.size * 8));

    [LineNumberTable(new byte[] {159, 130, 141, 106, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static BuildingComp()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.comp.BuildingComp"))
        return;
      BuildingComp.tmpTiles = new ObjectSet();
      BuildingComp.tempTileEnts = new Seq();
      BuildingComp.tempTiles = new Seq();
      BuildingComp.sleepingEntities = 0;
    }

    [HideFromJava]
    public abstract float getX();

    [HideFromJava]
    public abstract float getY();

    [HideFromJava]
    public virtual float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

    [HideFromJava]
    public virtual float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

    [HideFromJava]
    public virtual float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

    [HideFromJava]
    public virtual float dst([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float dst2([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst2((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

    [HideFromJava]
    public abstract bool isAdded();

    [HideFromJava]
    public abstract bool isLocal();

    [HideFromJava]
    public abstract bool isRemote();

    [HideFromJava]
    public abstract bool isNull();

    [HideFromJava]
    public abstract object @as();

    [HideFromJava]
    public abstract object with([In] Cons obj0);

    [HideFromJava]
    public abstract int classId();

    [HideFromJava]
    public abstract bool serialize();

    [HideFromJava]
    public abstract void read([In] Reads obj0);

    [HideFromJava]
    public abstract void afterRead();

    [HideFromJava]
    public abstract int id();

    [HideFromJava]
    public abstract void id([In] int obj0);

    [HideFromJava]
    public abstract void set([In] Position obj0);

    [HideFromJava]
    public abstract void trns([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void trns([In] Position obj0);

    [HideFromJava]
    public abstract Floor floorOn();

    [HideFromJava]
    public abstract Block blockOn();

    [HideFromJava]
    public abstract bool onSolid();

    [HideFromJava]
    public abstract Tile tileOn();

    [HideFromJava]
    public abstract float x();

    [HideFromJava]
    public abstract void x([In] float obj0);

    [HideFromJava]
    public abstract float y();

    [HideFromJava]
    public abstract void y([In] float obj0);

    [HideFromJava]
    public abstract bool cheating();

    [HideFromJava]
    public abstract Building core();

    [HideFromJava]
    public abstract Building closestCore();

    [HideFromJava]
    public abstract Building closestEnemyCore();

    [HideFromJava]
    public abstract void team([In] Team obj0);

    [HideFromJava]
    public abstract void heal();

    [HideFromJava]
    public abstract void damagePierce([In] float obj0, [In] bool obj1);

    [HideFromJava]
    public abstract void damagePierce([In] float obj0);

    [HideFromJava]
    public abstract void damage([In] float obj0, [In] bool obj1);

    [HideFromJava]
    public abstract void damageContinuous([In] float obj0);

    [HideFromJava]
    public abstract void damageContinuousPierce([In] float obj0);

    [HideFromJava]
    public abstract void clampHealth();

    [HideFromJava]
    public abstract void heal([In] float obj0);

    [HideFromJava]
    public abstract void healFract([In] float obj0);

    [HideFromJava]
    public abstract float health();

    [HideFromJava]
    public abstract void health([In] float obj0);

    [HideFromJava]
    public abstract float hitTime();

    [HideFromJava]
    public abstract void hitTime([In] float obj0);

    [HideFromJava]
    public abstract float maxHealth();

    [HideFromJava]
    public abstract void dead([In] bool obj0);

    [HideFromJava]
    public abstract bool timer([In] int obj0, [In] float obj1);

    [HideFromJava]
    public abstract Interval timer();

    [HideFromJava]
    public abstract Tile tile();

    [HideFromJava]
    public abstract void tile([In] Tile obj0);

    [HideFromJava]
    public abstract Block block();

    [HideFromJava]
    public abstract void block([In] Block obj0);

    [HideFromJava]
    public abstract Seq proximity();

    [HideFromJava]
    public abstract void proximity([In] Seq obj0);

    [HideFromJava]
    public abstract bool updateFlow();

    [HideFromJava]
    public abstract void updateFlow([In] bool obj0);

    [HideFromJava]
    public abstract byte cdump();

    [HideFromJava]
    public abstract void cdump([In] byte obj0);

    [HideFromJava]
    public abstract int rotation();

    [HideFromJava]
    public abstract void rotation([In] int obj0);

    [HideFromJava]
    public abstract bool enabled();

    [HideFromJava]
    public abstract void enabled([In] bool obj0);

    [HideFromJava]
    public abstract float enabledControlTime();

    [HideFromJava]
    public abstract void enabledControlTime([In] float obj0);

    [HideFromJava]
    public abstract string lastAccessed();

    [HideFromJava]
    public abstract void lastAccessed([In] string obj0);

    [HideFromJava]
    public abstract PowerModule power();

    [HideFromJava]
    public abstract void power([In] PowerModule obj0);

    [HideFromJava]
    public abstract ItemModule items();

    [HideFromJava]
    public abstract void items([In] ItemModule obj0);

    [HideFromJava]
    public abstract LiquidModule liquids();

    [HideFromJava]
    public abstract void liquids([In] LiquidModule obj0);

    [HideFromJava]
    public abstract ConsumeModule cons();

    [HideFromJava]
    public abstract void cons([In] ConsumeModule obj0);

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(1307)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.entities.comp.BuildingComp$1"))
          return;
        BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess = new int[LAccess.values().Length];
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Ex.ordinal()] = 1;
          goto label_6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_6:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Ey.ordinal()] = 2;
          goto label_10;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_10:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Edead.ordinal()] = 3;
          goto label_14;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_14:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eteam.ordinal()] = 4;
          goto label_18;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_18:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Ehealth.ordinal()] = 5;
          goto label_22;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_22:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EmaxHealth.ordinal()] = 6;
          goto label_26;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_26:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eefficiency.ordinal()] = 7;
          goto label_30;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_30:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Etimescale.ordinal()] = 8;
          goto label_34;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_34:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Erange.ordinal()] = 9;
          goto label_38;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_38:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Erotation.ordinal()] = 10;
          goto label_42;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_42:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EtotalItems.ordinal()] = 11;
          goto label_46;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_46:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EtotalLiquids.ordinal()] = 12;
          goto label_50;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_50:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EtotalPower.ordinal()] = 13;
          goto label_54;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_54:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EitemCapacity.ordinal()] = 14;
          goto label_58;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_58:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EliquidCapacity.ordinal()] = 15;
          goto label_62;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_62:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpowerCapacity.ordinal()] = 16;
          goto label_66;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_66:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpowerNetIn.ordinal()] = 17;
          goto label_70;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_70:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpowerNetOut.ordinal()] = 18;
          goto label_74;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_74:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpowerNetStored.ordinal()] = 19;
          goto label_78;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_78:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpowerNetCapacity.ordinal()] = 20;
          goto label_82;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_82:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eenabled.ordinal()] = 21;
          goto label_86;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_86:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Econtrolled.ordinal()] = 22;
          goto label_90;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_90:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpayloadCount.ordinal()] = 23;
          goto label_94;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_94:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Esize.ordinal()] = 24;
          goto label_98;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_98:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Etype.ordinal()] = 25;
          goto label_102;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_102:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EfirstItem.ordinal()] = 26;
          goto label_106;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_106:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Econfig.ordinal()] = 27;
          goto label_110;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_110:
        try
        {
          BuildingComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpayloadType.ordinal()] = 28;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly BuildingComp arg\u00241;

      internal __\u003C\u003EAnon0([In] BuildingComp obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024placed\u00240((Building) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : LiquidModule.LiquidCalculator
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public float get([In] Liquid obj0, [In] float obj1) => BuildingComp.lambda\u0024onDestroyed\u00241(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : LiquidModule.LiquidCalculator
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public float get([In] Liquid obj0, [In] float obj1) => BuildingComp.lambda\u0024onDestroyed\u00242(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : LiquidModule.LiquidConsumer
    {
      private readonly BuildingComp arg\u00241;

      internal __\u003C\u003EAnon3([In] BuildingComp obj0) => this.arg\u00241 = obj0;

      public void accept([In] Liquid obj0, [In] float obj1) => this.arg\u00241.lambda\u0024onDestroyed\u00244(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly BuildingComp arg\u00241;

      internal __\u003C\u003EAnon4([In] BuildingComp obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u00245((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly BuildingComp arg\u00241;

      internal __\u003C\u003EAnon5([In] BuildingComp obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u00246((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly BuildingComp arg\u00241;

      internal __\u003C\u003EAnon6([In] BuildingComp obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.displayConsumption((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly BuildingComp arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon7([In] BuildingComp obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u002410(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      private readonly BuildingComp arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon8([In] BuildingComp obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u002415(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly BuildingComp arg\u00241;
      private readonly Table arg\u00242;
      private readonly string arg\u00243;

      internal __\u003C\u003EAnon9([In] BuildingComp obj0, [In] Table obj1, [In] string obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024display\u002413(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Runnable
    {
      private readonly BuildingComp arg\u00241;
      private readonly bool[] arg\u00242;
      private readonly Runnable arg\u00243;

      internal __\u003C\u003EAnon10([In] BuildingComp obj0, [In] bool[] obj1, [In] Runnable obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024display\u002414(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Prov
    {
      private readonly BuildingComp arg\u00241;

      internal __\u003C\u003EAnon11([In] BuildingComp obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024display\u002411();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Prov
    {
      private readonly BuildingComp arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon12([In] BuildingComp obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) this.arg\u00241.lambda\u0024display\u002412(this.arg\u00242).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly BuildingComp arg\u00241;
      private readonly Table arg\u00242;
      private readonly string arg\u00243;

      internal __\u003C\u003EAnon13([In] BuildingComp obj0, [In] Table obj1, [In] string obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024display\u00248(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      private readonly BuildingComp arg\u00241;
      private readonly Bits arg\u00242;
      private readonly Runnable arg\u00243;

      internal __\u003C\u003EAnon14([In] BuildingComp obj0, [In] Bits obj1, [In] Runnable obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024display\u00249(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Prov
    {
      private readonly BuildingComp arg\u00241;
      private readonly Item arg\u00242;
      private readonly string arg\u00243;

      internal __\u003C\u003EAnon15([In] BuildingComp obj0, [In] Item obj1, [In] string obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public object get() => (object) this.arg\u00241.lambda\u0024display\u00247(this.arg\u00242, this.arg\u00243).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly BuildingComp arg\u00241;
      private readonly Liquid arg\u00242;
      private readonly float arg\u00243;

      internal __\u003C\u003EAnon16([In] BuildingComp obj0, [In] Liquid obj1, [In] float obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024onDestroyed\u00243(this.arg\u00242, this.arg\u00243);
    }
  }
}
