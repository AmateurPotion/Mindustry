// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Building
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
using mindustry.entities;
using mindustry.entities.comp;
using mindustry.game;
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

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Healthc", "mindustry.gen.Posc", "mindustry.gen.Teamc", "mindustry.gen.Timerc", "mindustry.gen.Entityc", "mindustry.gen.Buildingc"})]
  public class Building : 
    Object,
    Healthc,
    Posc,
    Position,
    Entityc,
    Teamc,
    Timerc,
    Buildingc,
    QuadTree.QuadTreeObject,
    Displayable,
    Senseable,
    Controllable,
    Sized
  {
    public const float hitDuration = 9f;
    public const float timeToSleep = 60f;
    public const float timeToUncontrol = 360f;
    [Signature("Larc/struct/ObjectSet<Lmindustry/gen/Building;>;")]
    internal static ObjectSet __\u003C\u003EtmpTiles;
    [Signature("Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    internal static Seq __\u003C\u003EtempTileEnts;
    [Signature("Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    internal static Seq __\u003C\u003EtempTiles;
    public static int sleepingEntities;
    public float health;
    [NonSerialized]
    public float hitTime;
    [NonSerialized]
    public float maxHealth;
    [NonSerialized]
    public bool dead;
    public float x;
    public float y;
    public Team team;
    [NonSerialized]
    public Interval timer;
    [NonSerialized]
    public bool added;
    [NonSerialized]
    public int id;
    [NonSerialized]
    public Tile tile;
    [NonSerialized]
    public Block block;
    [Signature("Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    [NonSerialized]
    public Seq proximity;
    [NonSerialized]
    public bool updateFlow;
    [NonSerialized]
    public byte cdump;
    [NonSerialized]
    public int rotation;
    [NonSerialized]
    public bool enabled;
    [NonSerialized]
    public float enabledControlTime;
    [NonSerialized]
    public string lastAccessed;
    public PowerModule power;
    public ItemModule items;
    public LiquidModule liquids;
    public ConsumeModule cons;
    [NonSerialized]
    public float timeScale;
    [NonSerialized]
    public float timeScaleDuration;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [NonSerialized]
    public SoundLoop sound;
    [NonSerialized]
    public bool sleeping;
    [NonSerialized]
    public float sleepTime;
    [NonSerialized]
    public bool initialized;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("()Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq proximity() => this.proximity;

    [LineNumberTable(307)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isValid() => object.ReferenceEquals((object) this.tile.build, (object) this) && !this.dead();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool damaged() => (double) this.health < (double) (this.maxHealth - 1f / 1000f);

    [LineNumberTable(657)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int pos() => this.tile.pos();

    [HideFromJava]
    public virtual float dst([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst((Position) this, obj0, obj1);

    [LineNumberTable(512)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float hitSize() => (float) (this.tile.block().size * 8);

    [HideFromJava]
    public virtual float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

    [LineNumberTable(new byte[] {164, 163, 127, 14, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int acceptStack(Item item, int amount, Teamc source) => this.acceptItem(this, item) && this.block.hasItems && (source == null || object.ReferenceEquals((object) source.team(), (object) this.team)) ? Math.min(this.getMaximumAccepted(item) - this.items.get(item), amount) : 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float healthf() => this.health / this.maxHealth;

    [LineNumberTable(new byte[] {165, 106, 127, 24, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      Draw.rect(this.block.region, this.x, this.y, !this.block.rotate ? 0.0f : this.rotdeg());
      this.drawTeamTop();
    }

    [LineNumberTable(1452)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion getDisplayIcon() => this.block.icon(Cicon.__\u003C\u003Emedium);

    [LineNumberTable(781)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getDisplayName() => this.block.localizedName;

    [LineNumberTable(1545)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Building create() => new Building();

    [LineNumberTable(1427)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileX() => (int) this.tile.x;

    [LineNumberTable(1065)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileY() => (int) this.tile.y;

    [HideFromJava]
    public virtual bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tile() => this.tile;

    [HideFromJava]
    public virtual float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

    [LineNumberTable(new byte[] {165, 78, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building front()
    {
      int num = this.block.size / 2 + 1;
      return this.nearby(Geometry.d4(this.rotation).x * num, Geometry.d4(this.rotation).y * num);
    }

    [LineNumberTable(new byte[] {161, 89, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building back()
    {
      int num = this.block.size / 2 + 1;
      return this.nearby(Geometry.d4(this.rotation + 2).x * num, Geometry.d4(this.rotation + 2).y * num);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPowerProduction() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float timeScale() => this.timeScale;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float maxHealth() => this.maxHealth;

    [LineNumberTable(new byte[] {163, 152, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void heal(float amount)
    {
      this.health += amount;
      this.clampHealth();
    }

    [LineNumberTable(new byte[] {162, 14, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool collision(Bullet other)
    {
      this.damage(other.damage() * other.type().buildingDamageMultiplier);
      return true;
    }

    [LineNumberTable(561)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building nearby(int dx, int dy) => Vars.world.build((int) this.tile.x + dx, (int) this.tile.y + dy);

    [LineNumberTable(new byte[] {162, 75, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float efficiency()
    {
      if (!this.enabled)
        return 0.0f;
      return this.power != null && this.block.__\u003C\u003Econsumes.has(ConsumeType.__\u003C\u003Epower) && !this.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ebuffered ? this.power.status : 1f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool collide(Bullet other) => true;

    [LineNumberTable(new byte[] {162, 147, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void configureAny(object value) => Call.tileConfig((Player) null, this, value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

    [LineNumberTable(new byte[] {161, 230, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void kill() => Call.tileDestroyed(this);

    [LineNumberTable(new byte[] {158, 18, 98, 127, 36, 98, 127, 0, 125, 108, 137, 161, 119, 102, 115, 117, 127, 9, 111, 226, 60, 235, 72, 127, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addPlan(bool checkPrevious)
    {
      int num = checkPrevious ? 1 : 0;
      if (!this.block.rebuildable || object.ReferenceEquals((object) this.team, (object) Vars.state.rules.defaultTeam) && Vars.state.isCampaign() && !this.block.isVisible())
        return;
      object obj = (object) null;
      Building building = this;
      ConstructBlock.ConstructBuild constructBuild;
      if (building is ConstructBlock.ConstructBuild && object.ReferenceEquals((object) (constructBuild = (ConstructBlock.ConstructBuild) building), (object) (ConstructBlock.ConstructBuild) building))
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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte version() => 0;

    [LineNumberTable(new byte[] {159, 7, 131, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readAll(Reads read, byte revision)
    {
      int num = (int) (sbyte) revision;
      this.readBase(read);
      this.read(read, (byte) num);
    }

    [LineNumberTable(new byte[] {161, 149, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeAll(Writes write)
    {
      this.writeBase(write);
      this.write(write);
    }

    [LineNumberTable(new byte[] {163, 55, 105, 107, 139, 167, 104, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      if (!this.added)
        return;
      Groups.all.remove((Entityc) this);
      Groups.build.remove((Entityc) this);
      this.added = false;
      if (this.sound == null)
        return;
      this.sound.stop();
    }

    [LineNumberTable(new byte[] {162, 83, 106, 108, 113, 115, 127, 19, 122, 112, 141, 237, 58, 233, 72, 127, 4, 109, 98, 102, 102, 127, 4, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateProximity()
    {
      Building.__\u003C\u003EtmpTiles.clear();
      this.proximity.clear();
      Point2[] edges = Edges.getEdges(this.block.size);
      int length = edges.Length;
      for (int index = 0; index < length; ++index)
      {
        Point2 point2 = edges[index];
        Building building = Vars.world.build((int) this.tile.x + point2.x, (int) this.tile.y + point2.y);
        if (building != null && building.tile.interactable(this.team))
        {
          if (!building.proximity.contains((object) this, true))
            building.proximity.add((object) this);
          Building.__\u003C\u003EtmpTiles.add((object) building);
        }
      }
      ObjectSet.ObjectSetIterator objectSetIterator1 = Building.__\u003C\u003EtmpTiles.iterator();
      while (((Iterator) objectSetIterator1).hasNext())
        this.proximity.add((object) (Building) ((Iterator) objectSetIterator1).next());
      this.onProximityAdded();
      this.onProximityUpdate();
      ObjectSet.ObjectSetIterator objectSetIterator2 = Building.__\u003C\u003EtmpTiles.iterator();
      while (((Iterator) objectSetIterator2).hasNext())
        ((Building) ((Iterator) objectSetIterator2).next()).onProximityUpdate();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void team(Team team) => this.team = team;

    [LineNumberTable(new byte[] {160, 197, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onProximityUpdate() => this.noSleep();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool checkSolid() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onRemoved()
    {
    }

    [LineNumberTable(new byte[] {162, 35, 102, 106, 113, 112, 127, 19, 100, 237, 61, 230, 70, 127, 4, 111, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeFromProximity()
    {
      this.onProximityRemoved();
      Building.__\u003C\u003EtmpTiles.clear();
      Point2[] edges = Edges.getEdges(this.block.size);
      int length = edges.Length;
      for (int index = 0; index < length; ++index)
      {
        Point2 point2 = edges[index];
        Building building = Vars.world.build((int) this.tile.x + point2.x, (int) this.tile.y + point2.y);
        if (building != null)
          Building.__\u003C\u003EtmpTiles.add((object) building);
      }
      ObjectSet.ObjectSetIterator objectSetIterator = Building.__\u003C\u003EtmpTiles.iterator();
      while (((Iterator) objectSetIterator).hasNext())
      {
        Building building = (Building) ((Iterator) objectSetIterator).next();
        building.proximity.remove((object) this, true);
        building.onProximityUpdate();
      }
    }

    [LineNumberTable(new byte[] {158, 84, 66, 104, 144, 109, 171, 104, 103, 116, 99, 134, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building init(Tile tile, Team team, bool shouldAdd, int rotation)
    {
      int num = shouldAdd ? 1 : 0;
      if (!this.initialized)
        this.create(tile.block(), team);
      else if (this.block.hasPower)
        new PowerGraph().add(this);
      this.rotation = rotation;
      this.tile = tile;
      this.set(tile.drawx(), tile.drawy());
      if (num != 0)
        this.add();
      this.created();
      return this;
    }

    [LineNumberTable(new byte[] {161, 178, 112, 119, 102, 107, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void killed()
    {
      Events.fire((object) new EventType.BlockDestroyEvent(this.tile));
      this.block.breakSound.at((Position) this.tile);
      this.onDestroyed();
      this.tile.remove();
      this.remove();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void liquids(LiquidModule liquids) => this.liquids = liquids;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void power(PowerModule power) => this.power = power;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object config() => (object) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cons(ConsumeModule cons) => this.cons = cons;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tile(Tile tile) => this.tile = tile;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void block(Block block) => this.block = block;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float rotdeg() => (float) (this.rotation * 90);

    [LineNumberTable(new byte[] {161, 66, 105, 118, 145, 149, 119, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void damage(float damage)
    {
      if (this.dead())
        return;
      if (Mathf.zero(Vars.state.rules.blockHealthMultiplier))
        damage = this.health + 1f;
      else
        damage /= Vars.state.rules.blockHealthMultiplier;
      Call.tileDamage(this, this.health - this.handleDamage(damage));
      if ((double) this.health > 0.0)
        return;
      Call.tileDestroyed(this);
    }

    [LineNumberTable(740)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool interactable(Team team) => Vars.state.teams.canInteract(team, this.team());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool dead() => this.dead;

    [HideFromJava]
    public virtual float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float health() => this.health;

    [LineNumberTable(new byte[] {159, 26, 162, 103, 104, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void damage(float amount, bool withEffect)
    {
      int num = withEffect ? 1 : 0;
      float hitTime = this.hitTime;
      this.damage(amount);
      if (num != 0)
        return;
      this.hitTime = hitTime;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool acceptPayload(Building source, Payload payload) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handlePayload(Building source, Payload payload)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building getLiquidDestination(Building from, Liquid liquid) => this;

    [LineNumberTable(1159)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool acceptLiquid(Building source, Liquid liquid) => this.block.hasLiquids && this.block.__\u003C\u003Econsumes.__\u003C\u003Eliquidfilters.get((int) liquid.__\u003C\u003Eid);

    [LineNumberTable(new byte[] {164, 76, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleLiquid(Building source, Liquid liquid, float amount) => this.liquids.add(liquid, amount);

    [LineNumberTable(1456)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool acceptItem(Building source, Item item) => this.block.__\u003C\u003Econsumes.__\u003C\u003EitemFilters.get((int) item.__\u003C\u003Eid) && this.items.get(item) < this.getMaximumAccepted(item);

    [LineNumberTable(new byte[] {160, 227, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleItem(Building source, Item item) => this.items.add(item, 1);

    [LineNumberTable(1206)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool conductsTo(Building other) => !this.block.insulated;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canPickup() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void pickedUp()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unitOn(Unit unit)
    {
    }

    [LineNumberTable(303)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BlockStatus status() => this.cons.status();

    [LineNumberTable(new byte[] {162, 105, 107, 104, 102, 103, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void noSleep()
    {
      this.sleepTime = 0.0f;
      if (!this.sleeping)
        return;
      this.add();
      this.sleeping = false;
      --Building.sleepingEntities;
    }

    [LineNumberTable(395)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLocal() => object.ReferenceEquals((object) this, (object) Vars.player) || this is Unitc && object.ReferenceEquals((object) ((Unitc) this).controller(), (object) Vars.player);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float x, float y)
    {
      this.x = x;
      this.y = y;
    }

    [LineNumberTable(new byte[] {161, 79, 127, 9, 107, 126, 127, 32, 127, 65, 229, 59})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object senseObject(LAccess sensor)
    {
      switch (Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[sensor.ordinal()])
      {
        case 1:
          return (object) this.block;
        case 2:
          return this.items == null ? (object) null : (object) this.items.first();
        case 3:
          return this.block.configurations.containsKey((object) ClassLiteral<Item>.Value) || this.block.configurations.containsKey((object) ClassLiteral<Liquid>.Value) ? this.config() : (object) null;
        case 4:
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

    [LineNumberTable(new byte[] {164, 96, 127, 12, 110, 110, 110, 107, 145, 115, 127, 0, 127, 0, 103, 107, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void configured(Unit builder, object value)
    {
      Class @class = value != null ? (!Object.instancehelper_getClass(value).isAnonymousClass() ? Object.instancehelper_getClass(value) : Object.instancehelper_getClass(value).getSuperclass()) : (Class) Void.TYPE;
      if (value is Item)
        @class = (Class) ClassLiteral<Item>.Value;
      if (value is Block)
        @class = (Class) ClassLiteral<Block>.Value;
      if (value is Liquid)
        @class = (Class) ClassLiteral<Liquid>.Value;
      if (builder != null && builder.isPlayer())
        this.lastAccessed = builder.getPlayer().name;
      if (this.block.configurations.containsKey((object) @class))
      {
        ((Cons2) this.block.configurations.get((object) @class)).get((object) this, value);
      }
      else
      {
        object obj1 = value;
        Building building;
        if (!(obj1 is Building) || !object.ReferenceEquals((object) (building = (Building) obj1), (object) (Building) obj1))
          return;
        object obj2 = building.config();
        if (obj2 == null || obj2 is Building)
          return;
        this.configured(builder, obj2);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canDump(Building to, Item item) => true;

    [LineNumberTable(new byte[] {161, 18, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void incrementDump(int prox)
    {
      int num1 = (int) (sbyte) this.cdump + 1;
      int num2 = prox;
      this.cdump = num2 != -1 ? (byte) (num1 % num2) : (byte) 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float handleDamage(float amount) => amount;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Payload getPayload() => (Payload) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shouldConsume() => this.enabled;

    [LineNumberTable(new byte[] {161, 218, 108, 114, 113, 103, 114, 116, 116, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeBase(Writes write)
    {
      write.f(this.health);
      write.b(this.rotation | 128);
      write.b(this.team.__\u003C\u003Eid);
      write.b(1);
      write.b(!this.enabled ? 0 : 1);
      if (this.items != null)
        this.items.write(write);
      if (this.power != null)
        this.power.write(write);
      if (this.liquids != null)
        this.liquids.write(write);
      if (this.cons == null)
        return;
      this.cons.write(write);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Writes write)
    {
    }

    [LineNumberTable(1112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte relativeTo(Tile tile) => this.relativeTo((int) tile.x, (int) tile.y);

    [LineNumberTable(new byte[] {160, 139, 109, 104, 114, 106, 98, 105, 104, 100, 104, 106, 104, 171, 130, 117, 117, 117, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readBase(Reads read)
    {
      this.health = read.f();
      int num1 = (int) (sbyte) read.b();
      this.team = Team.get((int) (sbyte) read.b());
      this.rotation = num1 & (int) sbyte.MaxValue;
      int num2 = 1;
      if ((num1 & 128) != 0)
      {
        if (read.b() == (byte) 1)
        {
          this.enabled = read.b() == (byte) 1;
          if (!this.enabled)
            this.enabledControlTime = 360f;
        }
        num2 = 0;
      }
      if (this.items != null)
        this.items.read(read, num2 != 0);
      if (this.power != null)
        this.power.read(read, num2 != 0);
      if (this.liquids != null)
        this.liquids.read(read, num2 != 0);
      if (this.cons == null)
        return;
      this.cons.read(read, num2 != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Reads read, byte revision)
    {
    }

    [LineNumberTable(new byte[] {162, 222, 108, 102, 102, 112, 127, 9, 111, 112, 112, 119, 133, 109, 122, 154, 127, 10, 159, 7, 126, 246, 76, 127, 32, 122, 156})]
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
        flammability += this.liquids.sum((LiquidModule.LiquidCalculator) new Building.__\u003C\u003EAnon0());
        baseExplosiveness += this.liquids.sum((LiquidModule.LiquidCalculator) new Building.__\u003C\u003EAnon1());
      }
      if (this.block.__\u003C\u003Econsumes.hasPower() && this.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ebuffered)
        power += this.power.status * this.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ecapacity;
      if (this.block.hasLiquids && Vars.state.rules.damageExplosions)
        this.liquids.each((LiquidModule.LiquidConsumer) new Building.__\u003C\u003EAnon2(this));
      Damage.dynamicExplosion(this.x, this.y, flammability, baseExplosiveness * 3.5f, power, (float) (8 * this.block.size) / 2f, Vars.state.rules.damageExplosions);
      if (this.floor().solid || this.floor().isLiquid)
        return;
      Effect.rubble(this.x, this.y, this.block.size);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canDumpLiquid(Building to, Liquid liquid) => true;

    [LineNumberTable(new byte[] {164, 136, 127, 4, 106, 105, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void transferLiquid(Building next, float amount, Liquid liquid)
    {
      float amount1 = Math.min(next.block.liquidCapacity - next.liquids.get(liquid), amount);
      if (!next.acceptLiquid(this, liquid))
        return;
      next.handleLiquid(this, liquid, amount1);
      this.liquids.remove(liquid, amount1);
    }

    [LineNumberTable(new byte[] {162, 19, 127, 41})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void produced(Item item, int amount)
    {
      if (Vars.state.rules.sector == null || !object.ReferenceEquals((object) this.team, (object) Vars.state.rules.defaultTeam))
        return;
      Vars.state.rules.sector.info.handleProduction(item, amount);
    }

    [LineNumberTable(1484)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tileOn() => Vars.world.tileWorld(this.x, this.y);

    [LineNumberTable(new byte[] {165, 45, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onProximityRemoved()
    {
      if (this.power == null)
        return;
      this.powerGraphRemoved();
    }

    [LineNumberTable(new byte[] {164, 35, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onProximityAdded()
    {
      if (!this.block.hasPower)
        return;
      this.updatePowerGraph();
    }

    [LineNumberTable(new byte[] {162, 68, 106, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add()
    {
      if (this.added)
        return;
      Groups.all.add((Entityc) this);
      Groups.build.add((Entityc) this);
      this.added = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Team team() => this.team;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterRead()
    {
    }

    [LineNumberTable(319)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor floor() => this.tile.floor();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void maxHealth(float maxHealth) => this.maxHealth = maxHealth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void timer(Interval timer) => this.timer = timer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shouldActiveSound() => false;

    [LineNumberTable(475)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shouldAmbientSound() => this.shouldConsume();

    [LineNumberTable(649)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float ambientVolume() => this.efficiency();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateTile()
    {
    }

    [LineNumberTable(new byte[] {162, 139, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clampHealth() => this.health = Mathf.clamp(this.health, 0.0f, this.maxHealth);

    [Signature("(Larc/struct/Seq<Lmindustry/gen/Building;>;)Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    [LineNumberTable(new byte[] {163, 196, 103, 106, 127, 4, 127, 102, 135, 101, 120, 124, 31, 29, 201})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getPowerConnections(Seq @out)
    {
      @out.clear();
      if (this.power == null)
        return @out;
      Iterator iterator = this.proximity.iterator();
      while (iterator.hasNext())
      {
        Building other = (Building) iterator.next();
        if (other != null && other.power != null && object.ReferenceEquals((object) other.team, (object) this.team) && (!this.block.consumesPower || !other.block.consumesPower || (this.block.outputsPower || other.block.outputsPower)) && (this.conductsTo(other) && other.conductsTo(this) && !this.power.links.contains(other.pos())))
          @out.add((object) other);
      }
      for (int index = 0; index < this.power.links.size; ++index)
      {
        Tile tile = Vars.world.tile(this.power.links.get(index));
        if (tile != null && tile.build != null && (tile.build.power != null && object.ReferenceEquals((object) tile.build.team, (object) this.team)))
          @out.add((object) tile.build);
      }
      return @out;
    }

    [LineNumberTable(1074)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte relativeTo(int cx, int cy) => this.tile.absoluteRelativeTo(cx, cy);

    [LineNumberTable(new byte[] {162, 159, 105, 106, 127, 30, 123, 127, 9, 127, 12, 127, 3, 118, 105, 109, 98, 127, 15, 118, 119, 109, 127, 23, 114, 114, 123, 146, 127, 23, 127, 12, 116, 237, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float moveLiquid(Building next, Liquid liquid)
    {
      if (next == null)
        return 0.0f;
      next = next.getLiquidDestination(this, liquid);
      if (object.ReferenceEquals((object) next.team, (object) this.team) && next.block.hasLiquids && (double) this.liquids.get(liquid) > 0.0)
      {
        float num1 = next.liquids.get(liquid) / next.block.liquidCapacity;
        float num2 = this.liquids.get(liquid) / this.block.liquidCapacity * this.block.liquidPressure;
        float amount = Math.min(Math.min(Mathf.clamp(num2 - num1) * this.block.liquidCapacity, this.liquids.get(liquid)), next.block.liquidCapacity - next.liquids.get(liquid));
        if ((double) amount > 0.0 && (double) num1 <= (double) num2 && next.acceptLiquid(this, liquid))
        {
          next.handleLiquid(this, liquid, amount);
          this.liquids.remove(liquid, amount);
          return amount;
        }
        if ((double) (next.liquids.currentAmount() / next.block.liquidCapacity) > 0.100000001490116 && (double) num2 > 0.100000001490116)
        {
          float x = (this.x + next.x) / 2f;
          float y = (this.y + next.y) / 2f;
          Liquid liquid1 = next.liquids.current();
          if ((double) liquid1.flammability > 0.300000011920929 && (double) liquid.temperature > 0.699999988079071 || (double) liquid.flammability > 0.300000011920929 && (double) liquid1.temperature > 0.699999988079071)
          {
            this.damage(1f * Time.delta);
            next.damage(1f * Time.delta);
            if (Mathf.chance(0.1 * (double) Time.delta))
              Fx.__\u003C\u003Efire.at(x, y);
          }
          else if ((double) liquid.temperature > 0.699999988079071 && (double) liquid1.temperature < 0.550000011920929 || (double) liquid1.temperature > 0.699999988079071 && (double) liquid.temperature < 0.550000011920929)
          {
            this.liquids.remove(liquid, Math.min(this.liquids.get(liquid), 0.7f * Time.delta));
            if (Mathf.chance((double) (0.2f * Time.delta)))
              Fx.__\u003C\u003Esteam.at(x, y);
          }
        }
      }
      return 0.0f;
    }

    [LineNumberTable(new byte[] {161, 202, 104, 117, 127, 27, 115, 113, 127, 10, 105, 127, 34, 123, 124, 255, 4, 57, 233, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dumpLiquid(Liquid liquid, float scaling)
    {
      int cdump = (int) (sbyte) this.cdump;
      if ((double) this.liquids.get(liquid) <= 9.99999974737875E-05)
        return;
      if (!Vars.net.client() && Vars.state.isCampaign() && object.ReferenceEquals((object) this.team, (object) Vars.state.rules.defaultTeam))
        liquid.unlock();
      for (int index1 = 0; index1 < this.proximity.size; ++index1)
      {
        this.incrementDump(this.proximity.size);
        Seq proximity = this.proximity;
        int num1 = index1 + cdump;
        int size = this.proximity.size;
        int index2 = size != -1 ? num1 % size : 0;
        Building liquidDestination = ((Building) proximity.get(index2)).getLiquidDestination(this, liquid);
        if (liquidDestination != null && object.ReferenceEquals((object) liquidDestination.team, (object) this.team) && (liquidDestination.block.hasLiquids && this.canDumpLiquid(liquidDestination, liquid)) && liquidDestination.liquids != null)
        {
          float num2 = liquidDestination.liquids.get(liquid) / liquidDestination.block.liquidCapacity;
          float num3 = this.liquids.get(liquid) / this.block.liquidCapacity;
          if ((double) num2 < (double) num3)
            this.transferLiquid(liquidDestination, (num3 - num2) * this.block.liquidCapacity / scaling, liquid);
        }
      }
    }

    [LineNumberTable(new byte[] {163, 157, 127, 6, 104, 155, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updatePowerGraph()
    {
      Iterator iterator = this.getPowerConnections(Building.__\u003C\u003EtempTileEnts).iterator();
      while (iterator.hasNext())
      {
        Building building = (Building) iterator.next();
        if (building.power != null)
          building.power.graph.addGraph(this.power.graph);
      }
    }

    [LineNumberTable(new byte[] {164, 183, 105, 103, 102, 106, 104, 191, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawLiquidLight(Liquid liquid, float amount)
    {
      if ((double) amount <= 0.00999999977648258)
        return;
      Color lightColor = liquid.lightColor;
      float num = 1f;
      float opacity = lightColor.a * num;
      if ((double) opacity <= 1.0 / 1000.0)
        return;
      Drawf.light(this.team, this.x, this.y, (float) this.block.size * 30f * num, lightColor, opacity);
    }

    [LineNumberTable(1210)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float delta() => Time.delta * this.timeScale;

    [LineNumberTable(new byte[] {165, 51, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(float x, float y) => this.set(this.x + x, this.y + y);

    [LineNumberTable(new byte[] {163, 7, 107, 103, 103, 114, 151, 109, 109, 113, 108, 115, 115, 104, 107, 145, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building create(Block block, Team team)
    {
      this.tile = Vars.emptyTile;
      this.block = block;
      this.team = team;
      if (!object.ReferenceEquals((object) block.loopSound, (object) Sounds.none))
        this.sound = new SoundLoop(block.loopSound, block.loopSoundVolume);
      this.health = (float) block.health;
      this.maxHealth((float) block.health);
      this.timer(new Interval(block.timers));
      this.cons = new ConsumeModule(this);
      if (block.hasItems)
        this.items = new ItemModule();
      if (block.hasLiquids)
        this.liquids = new LiquidModule();
      if (block.hasPower)
      {
        this.power = new PowerModule();
        this.power.graph.add(this);
      }
      this.initialized = true;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void created()
    {
    }

    [LineNumberTable(1191)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float edelta() => this.efficiency() * this.delta();

    [LineNumberTable(1218)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getMaximumAccepted(Item item) => this.block.itemCapacity;

    [LineNumberTable(1297)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getProgressIncrease(float baseTime) => 1f / baseTime * this.edelta();

    [LineNumberTable(new byte[] {163, 38, 105, 113, 117, 124, 120, 252, 61, 233, 70, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void powerGraphRemoved()
    {
      if (this.power == null)
        return;
      this.power.graph.remove(this);
      for (int index = 0; index < this.power.links.size; ++index)
      {
        Tile tile = Vars.world.tile(this.power.links.get(index));
        if (tile != null && tile.build != null && tile.build.power != null)
          tile.build.power.links.removeValue(this.pos());
      }
      this.power.links.clear();
    }

    [LineNumberTable(new byte[] {159, 69, 130, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void damagePierce(float amount, bool withEffect)
    {
      int num = withEffect ? 1 : 0;
      this.damage(amount, num != 0);
    }

    [LineNumberTable(new byte[] {164, 194, 114, 127, 26, 127, 9, 133})]
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

    [LineNumberTable(new byte[] {161, 37, 127, 14, 104, 111, 115, 127, 10, 102, 119, 109, 127, 25, 105, 110, 113, 226, 58, 235, 74, 127, 8, 104, 109, 113, 162, 241, 44, 233, 86})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool dump(Item todump)
    {
      if (!this.block.hasItems || this.items.total() == 0 || todump != null && !this.items.has(todump))
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
        Building to = (Building) proximity.get(index2);
        if (todump == null)
        {
          for (int id = 0; id < Vars.content.items().size; ++id)
          {
            Item obj = Vars.content.item(id);
            if (object.ReferenceEquals((object) to.team, (object) this.team) && this.items.has(obj) && (to.acceptItem(this, obj) && this.canDump(to, obj)))
            {
              to.handleItem(this, obj);
              this.items.remove(obj, 1);
              this.incrementDump(this.proximity.size);
              return true;
            }
          }
        }
        else if (object.ReferenceEquals((object) to.team, (object) this.team) && to.acceptItem(this, todump) && this.canDump(to, todump))
        {
          to.handleItem(this, todump);
          this.items.remove(todump, 1);
          this.incrementDump(this.proximity.size);
          return true;
        }
        this.incrementDump(this.proximity.size);
      }
      return false;
    }

    [LineNumberTable(new byte[] {160, 126, 232, 5, 235, 76, 139, 204, 235, 70, 236, 72, 231, 78, 235, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Building()
    {
      Building building = this;
      this.maxHealth = 1f;
      this.team = Team.__\u003C\u003Ederelict;
      this.timer = new Interval(6);
      this.id = EntityGroup.nextId();
      this.proximity = new Seq(8);
      this.enabled = true;
      this.timeScale = 1f;
    }

    [LineNumberTable(new byte[] {163, 172, 159, 11, 120, 188, 2, 97, 130, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void displayBars(Table table)
    {
      Iterator iterator = this.block.__\u003C\u003Ebars.list().iterator();
      while (iterator.hasNext())
      {
        Func func = (Func) iterator.next();
        try
        {
          table.add((Element) func.get((object) this)).growX();
          table.row();
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

    [Modifiers]
    [LineNumberTable(860)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024onDestroyed\u00240([In] Liquid obj0, [In] float obj1) => obj0.flammability * obj1 / 2f;

    [Modifiers]
    [LineNumberTable(861)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024onDestroyed\u00241([In] Liquid obj0, [In] float obj1) => obj0.explosiveness * obj1 / 2f;

    [Modifiers]
    [LineNumberTable(new byte[] {162, 242, 122, 127, 0, 59, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024onDestroyed\u00243([In] Liquid obj0, [In] float obj1)
    {
      float num = Mathf.clamp(obj1 / 4f, 0.0f, 10f);
      for (int index = 0; (double) index < (double) Mathf.clamp(obj1 / 5f, 0.0f, 30f); ++index)
        Time.run((float) index / 2f, (Runnable) new Building.__\u003C\u003EAnon16(this, obj0, num));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 175, 120, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024placed\u00244([In] Building obj0)
    {
      if (obj0.power.links.contains(this.pos()))
        return;
      obj0.configureAny((object) Integer.valueOf(this.pos()));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 219, 103, 127, 8, 127, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00245([In] Table obj0)
    {
      obj0.left();
      obj0.add((Element) new Image(this.block.getDisplayIcon(this.tile))).size(32f);
      obj0.labelWrap(this.block.getDisplayName(this.tile)).left().width(190f).padLeft(5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 226, 127, 1, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00246([In] Table obj0)
    {
      obj0.defaults().growX().height(18f).pad(4f);
      this.displayBars(obj0);
    }

    [LineNumberTable(new byte[] {161, 117, 103, 126, 114, 8, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void displayConsumption(Table table)
    {
      table.left();
      Consume[] consumeArray = this.block.__\u003C\u003Econsumes.all();
      int length = consumeArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Consume consume = consumeArray[index];
        if (!consume.isOptional() || !consume.isBoost())
          consume.build(this, table);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 238, 102, 238, 75, 102, 244, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u002410([In] string obj0, [In] Table obj1)
    {
      Bits bits = new Bits();
      Runnable runnable = (Runnable) new Building.__\u003C\u003EAnon13(this, obj1, obj0);
      runnable.run();
      obj1.update((Runnable) new Building.__\u003C\u003EAnon14(this, bits, runnable));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 8, 107, 238, 70, 244, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u002415([In] string obj0, [In] Table obj1)
    {
      bool[] flagArray = new bool[1]{ false };
      Runnable runnable = (Runnable) new Building.__\u003C\u003EAnon9(this, obj1, obj0);
      obj1.update((Runnable) new Building.__\u003C\u003EAnon10(this, flagArray, runnable));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 10, 102, 103, 124, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u002413([In] Table obj0, [In] string obj1)
    {
      obj0.clearChildren();
      obj0.left();
      obj0.image((Prov) new Building.__\u003C\u003EAnon11(this)).padRight(3f);
      obj0.label((Prov) new Building.__\u003C\u003EAnon12(this, obj1)).color(Color.__\u003C\u003ElightGray);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {165, 16, 114, 100, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u002414([In] bool[] obj0, [In] Runnable obj1)
    {
      if (obj0[0] || !this.liquids.hadFlow())
        return;
      obj0[0] = true;
      obj1.run();
    }

    [Modifiers]
    [LineNumberTable(1406)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private TextureRegion lambda\u0024display\u002411() => this.liquids.current().icon(Cicon.__\u003C\u003Esmall);

    [Modifiers]
    [LineNumberTable(1407)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private CharSequence lambda\u0024display\u002412([In] string obj0)
    {
      object obj = (double) this.liquids.getFlowRate() >= 0.0 ? (object) new StringBuilder().append(Strings.@fixed(this.liquids.getFlowRate(), 2)).append(obj0).toString() : (object) "...";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 240, 102, 103, 127, 5, 110, 124, 126, 135, 98})]
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
          obj0.label((Prov) new Building.__\u003C\u003EAnon15(this, obj, obj1)).color(Color.__\u003C\u003ElightGray);
          obj0.row();
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 252, 127, 5, 124, 108, 134, 98})]
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
    [LineNumberTable(1383)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private CharSequence lambda\u0024display\u00247([In] Item obj0, [In] string obj1)
    {
      object obj = (double) this.items.getFlowRate(obj0) >= 0.0 ? (object) new StringBuilder().append(Strings.@fixed(this.items.getFlowRate(obj0), 1)).append(obj1).toString() : (object) "...";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 245, 127, 30, 99, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024onDestroyed\u00242([In] Liquid obj0, [In] float obj1)
    {
      Tile tile = Vars.world.tile(this.tileX() + Mathf.range(this.block.size / 2), this.tileY() + Mathf.range(this.block.size / 2));
      if (tile == null)
        return;
      Puddles.deposit(tile, obj0, obj1);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool serialize() => false;

    [LineNumberTable(249)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("Building#").append(this.id).toString();

    [LineNumberTable(new byte[] {160, 162, 127, 6, 123, 127, 16, 127, 16, 106, 106, 116, 112, 116, 133})]
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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool productionValid() => true;

    [LineNumberTable(new byte[] {160, 184, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building right()
    {
      int num = this.block.size / 2 + 1;
      return this.nearby(Geometry.d4(this.rotation + 3).x * num, Geometry.d4(this.rotation + 3).y * num);
    }

    [LineNumberTable(new byte[] {160, 209, 106, 148, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void applyBoost(float intensity, float duration)
    {
      if ((double) intensity >= (double) this.timeScale)
        this.timeScaleDuration = Math.max(this.timeScaleDuration, duration);
      this.timeScale = Math.max(this.timeScale, intensity);
    }

    [LineNumberTable(330)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRemote() => this is Unitc && ((Unitc) this).isPlayer() && !this.isLocal();

    [LineNumberTable(new byte[] {160, 220, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Position pos) => this.set(pos.getX(), pos.getY());

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object @as() => (object) this;

    [LineNumberTable(new byte[] {160, 239, 115, 117, 102, 103, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sleep()
    {
      this.sleepTime += Time.delta;
      if (this.sleeping || (double) this.sleepTime < 60.0)
        return;
      this.remove();
      this.sleeping = true;
      ++Building.sleepingEntities;
    }

    [LineNumberTable(new byte[] {160, 248, 103, 127, 1, 104, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool moveForward(Item item)
    {
      Building building = this.front();
      if (building == null || !object.ReferenceEquals((object) building.team, (object) this.team) || !building.acceptItem(this, item))
        return false;
      building.handleItem(this, item);
      return true;
    }

    [LineNumberTable(new byte[] {161, 1, 127, 3, 115, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void control(LAccess type, object p1, double p2, double p3, double p4)
    {
      if (!object.ReferenceEquals((object) type, (object) LAccess.__\u003C\u003Econfigure) || !this.block.logicConfigurable || (p1 is LogicBlock.LogicBuild || object.ReferenceEquals(this.senseObject(LAccess.__\u003C\u003Econfig), p1)))
        return;
      this.configured((Unit) null, p1);
    }

    [LineNumberTable(new byte[] {161, 9, 120, 103, 127, 33, 127, 7, 127, 3, 101})]
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

    [LineNumberTable(new byte[] {161, 29, 127, 7, 127, 8, 127, 8, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building nearby(int rotation)
    {
      switch (rotation)
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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tapped()
    {
    }

    [LineNumberTable(495)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canUnload() => this.block.unloadable;

    [LineNumberTable(new byte[] {161, 137, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void configure(object value)
    {
      this.block.lastConfig = value;
      Call.tileConfig(Vars.player, this, value);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getStackOffset(Item item, Vec2 trns)
    {
    }

    [LineNumberTable(524)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte relativeToEdge(Tile other) => this.relativeTo(Edges.getFacingEdge(other, this.tile));

    [LineNumberTable(new byte[] {161, 158, 112, 127, 17, 127, 19, 109, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool movePayload(Payload todump)
    {
      int num = this.block.size / 2 + 1;
      Tile tile = this.tile.nearby(Geometry.d4(this.rotation).x * num, Geometry.d4(this.rotation).y * num);
      if (tile == null || tile.build == null || (!object.ReferenceEquals((object) tile.build.team, (object) this.team) || !tile.build.acceptPayload(this, todump)))
        return false;
      tile.build.handlePayload(this, todump);
      return true;
    }

    [LineNumberTable(538)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Graphics.Cursor getCursor() => this.block.configurable && this.interactable(Vars.player.team()) ? (Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Ehand : (Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Earrow;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shouldHideConfigure(Player player) => false;

    [LineNumberTable(new byte[] {161, 234, 104, 115, 113, 127, 10, 127, 8, 104, 226, 59, 233, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool put(Item item)
    {
      int cdump = (int) (sbyte) this.cdump;
      for (int index1 = 0; index1 < this.proximity.size; ++index1)
      {
        this.incrementDump(this.proximity.size);
        Seq proximity = this.proximity;
        int num = index1 + cdump;
        int size = this.proximity.size;
        int index2 = size != -1 ? num % size : 0;
        Building to = (Building) proximity.get(index2);
        if (object.ReferenceEquals((object) to.team, (object) this.team) && to.acceptItem(this, item) && this.canDump(to, item))
        {
          to.handleItem(this, item);
          return true;
        }
      }
      return false;
    }

    [LineNumberTable(new byte[] {161, 247, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building left()
    {
      int num = this.block.size / 2 + 1;
      return this.nearby(Geometry.d4(this.rotation + 1).x * num, Geometry.d4(this.rotation + 1).y * num);
    }

    [LineNumberTable(new byte[] {161, 252, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void produced(Item item) => this.produced(item, 1);

    [LineNumberTable(new byte[] {162, 4, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor floorOn()
    {
      Tile tile = this.tileOn();
      return tile == null || !object.ReferenceEquals((object) tile.block(), (object) Blocks.air) ? (Floor) Blocks.air : tile.floor();
    }

    [LineNumberTable(new byte[] {162, 9, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block blockOn()
    {
      Tile tile = this.tileOn();
      return tile == null ? Blocks.air : tile.block();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void itemTaken(Item item)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Payload takePayload() => (Payload) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawSelect()
    {
    }

    [LineNumberTable(new byte[] {162, 118, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Reads read) => this.afterRead();

    [LineNumberTable(new byte[] {162, 122, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool timer(int index, float time) => !Float.isInfinite(time) && this.timer.get(index, time);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool onConfigureTileTapped(Building other) => !object.ReferenceEquals((object) this, (object) other);

    [LineNumberTable(757)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building closestEnemyCore() => (Building) Vars.state.teams.closestEnemyCore(this.x, this.y, this.team);

    [LineNumberTable(761)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool cheating() => this.team.rules().cheat;

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Entityc self() => (Entityc) this;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAdded() => this.added;

    [LineNumberTable(new byte[] {162, 192, 127, 89, 114, 114, 124, 113, 108, 108, 109, 108, 127, 27, 108, 127, 4, 127, 5, 127, 75, 127, 9, 127, 9, 127, 24, 127, 17, 127, 17, 127, 10, 127, 10, 124, 127, 15, 118, 110, 233, 39})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double sense(LAccess sensor)
    {
      switch (Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[sensor.ordinal()])
      {
        case 5:
          return (double) World.conv(this.x);
        case 6:
          return (double) World.conv(this.y);
        case 7:
          return !this.isValid() ? 1.0 : 0.0;
        case 8:
          return (double) this.team.__\u003C\u003Eid;
        case 9:
          return (double) this.health;
        case 10:
          return (double) this.maxHealth;
        case 11:
          return (double) this.efficiency();
        case 12:
          return (double) this.timeScale;
        case 13:
          Building building1 = this;
          Ranged ranged;
          return !(building1 is Ranged) || !object.ReferenceEquals((object) (ranged = (Ranged) building1), (object) (Ranged) building1) ? 0.0 : (double) (ranged.range() / 8f);
        case 14:
          return (double) this.rotation;
        case 15:
          return this.items == null ? 0.0 : (double) this.items.total();
        case 16:
          return this.liquids == null ? 0.0 : (double) this.liquids.total();
        case 17:
          return this.power == null || !this.block.__\u003C\u003Econsumes.hasPower() ? 0.0 : (double) this.power.status * (!this.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ebuffered ? 1.0 : (double) this.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ecapacity);
        case 18:
          return this.block.hasItems ? (double) this.block.itemCapacity : 0.0;
        case 19:
          return this.block.hasLiquids ? (double) this.block.liquidCapacity : 0.0;
        case 20:
          return this.block.__\u003C\u003Econsumes.hasPower() ? (double) this.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Ecapacity : 0.0;
        case 21:
          return this.power == null ? 0.0 : (double) (this.power.graph.getLastScaledPowerIn() * 60f);
        case 22:
          return this.power == null ? 0.0 : (double) (this.power.graph.getLastScaledPowerOut() * 60f);
        case 23:
          return this.power == null ? 0.0 : (double) this.power.graph.getLastPowerStored();
        case 24:
          return this.power == null ? 0.0 : (double) this.power.graph.getLastCapacity();
        case 25:
          return this.enabled ? 1.0 : 0.0;
        case 26:
          Building building2 = this;
          ControlBlock controlBlock;
          return !(building2 is ControlBlock) || !object.ReferenceEquals((object) (controlBlock = (ControlBlock) building2), (object) (ControlBlock) building2) || !controlBlock.isControlled() ? 0.0 : 2.0;
        case 27:
          return this.getPayload() != null ? 1.0 : 0.0;
        case 28:
          return (double) this.block.size;
        default:
          return double.NaN;
      }
    }

    [LineNumberTable(new byte[] {163, 28, 127, 9, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void deselect()
    {
      if (Vars.headless || !object.ReferenceEquals((object) Vars.control.input.__\u003C\u003Efrag.__\u003C\u003Econfig.getSelectedTile(), (object) this))
        return;
      Vars.control.input.__\u003C\u003Efrag.__\u003C\u003Econfig.hideConfig();
    }

    [LineNumberTable(916)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte relativeTo(Building tile) => this.relativeTo(tile.tile());

    [LineNumberTable(new byte[] {163, 69, 106, 116, 102, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int removeStack(Item item, int amount)
    {
      if (this.items == null)
        return 0;
      amount = Math.min(amount, this.items.get(item));
      this.noSleep();
      this.items.remove(item, amount);
      return amount;
    }

    [LineNumberTable(new byte[] {163, 81, 111, 104, 115, 127, 10, 125, 104, 113, 130, 241, 57, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool dumpPayload(Payload todump)
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
        if (object.ReferenceEquals((object) building.team, (object) this.team) && building.acceptPayload(this, todump))
        {
          building.handlePayload(this, todump);
          this.incrementDump(this.proximity.size);
          return true;
        }
        this.incrementDump(this.proximity.size);
      }
      return false;
    }

    [LineNumberTable(new byte[] {163, 97, 186, 113, 115, 122, 139, 117, 102, 115, 109, 167, 114, 135, 103, 104, 157, 127, 0, 191, 16, 117, 134, 104, 145, 104, 145, 104, 139, 104, 144, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      this.hitTime -= Time.delta / 9f;
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
          Vars.control.sound.loop(this.block.ambientSound, (Position) this, this.block.ambientSoundVolume * this.ambientVolume());
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

    [LineNumberTable(new byte[] {163, 143, 127, 22, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateTableAlign(Table table)
    {
      Vec2 vec2 = Core.input.mouseScreen(this.x, this.y - (float) (this.block.size * 8) / 2f - 1f);
      table.setPosition(vec2.x, vec2.y, 2);
    }

    [LineNumberTable(1030)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool consValid() => this.cons.valid();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNull() => false;

    [LineNumberTable(new byte[] {163, 187, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool onSolid()
    {
      Tile tile = this.tileOn();
      return tile == null || tile.solid();
    }

    [LineNumberTable(new byte[] {163, 211, 104, 104, 127, 27, 115, 113, 127, 10, 127, 8, 104, 225, 59, 233, 72, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void offload(Item item)
    {
      this.produced(item, 1);
      int cdump = (int) (sbyte) this.cdump;
      if (!Vars.net.client() && Vars.state.isCampaign() && object.ReferenceEquals((object) this.team, (object) Vars.state.rules.defaultTeam))
        item.unlock();
      for (int index1 = 0; index1 < this.proximity.size; ++index1)
      {
        this.incrementDump(this.proximity.size);
        Seq proximity = this.proximity;
        int num = index1 + cdump;
        int size = this.proximity.size;
        int index2 = size != -1 ? num % size : 0;
        Building to = (Building) proximity.get(index2);
        if (object.ReferenceEquals((object) to.team, (object) this.team) && to.acceptItem(this, item) && this.canDump(to, item))
        {
          to.handleItem(this, item);
          return;
        }
      }
      this.handleItem(this, item);
    }

    [LineNumberTable(1108)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building closestCore() => (Building) Vars.state.teams.closestCore(this.x, this.y, this.team);

    [LineNumberTable(new byte[] {158, 119, 66, 114, 105, 104, 111, 125, 117, 110, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float moveLiquidForward(bool leaks, Liquid liquid)
    {
      int num = leaks ? 1 : 0;
      Tile tile = this.tile.nearby(this.rotation);
      if (tile == null)
        return 0.0f;
      if (tile.build != null)
        return this.moveLiquid(tile.build, liquid);
      if (num != 0 && !tile.block().solid && !tile.block().hasLiquids)
      {
        float amount = this.liquids.get(liquid) / 1.5f;
        Puddles.deposit(tile, this.tile, liquid, amount);
        this.liquids.remove(liquid, amount);
      }
      return 0.0f;
    }

    [LineNumberTable(new byte[] {163, 251, 127, 22, 127, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double sense(Content content)
    {
      Content content1 = content;
      Item obj;
      if (content1 is Item && object.ReferenceEquals((object) (obj = (Item) content1), (object) (Item) content1) && this.items != null)
        return (double) this.items.get(obj);
      Content content2 = content;
      Liquid liquid;
      return content2 is Liquid && object.ReferenceEquals((object) (liquid = (Liquid) content2), (object) (Liquid) content2) && this.liquids != null ? (double) this.liquids.get(liquid) : double.NaN;
    }

    [LineNumberTable(new byte[] {164, 5, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dumpLiquid(Liquid liquid) => this.dumpLiquid(liquid, 2f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dropped()
    {
    }

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [LineNumberTable(new byte[] {164, 12, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object with(Cons cons)
    {
      cons.get((object) this);
      return (object) this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool configTapped() => true;

    [LineNumberTable(new byte[] {164, 25, 112, 127, 51, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawTeam()
    {
      Draw.color(this.team.__\u003C\u003Ecolor);
      Draw.rect("block-border", this.x - (float) (this.block.size * 8) / 2f + 4f, this.y - (float) (this.block.size * 8) / 2f + 4f);
      Draw.color();
    }

    [LineNumberTable(new byte[] {164, 31, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hitbox(Rect @out) => @out.setCentered(this.x, this.y, (float) (this.block.size * 8), (float) (this.block.size * 8));

    [LineNumberTable(new byte[] {164, 39, 106, 106, 102, 125, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawDisabled()
    {
      Draw.color(Color.__\u003C\u003Escarlet);
      Draw.alpha(0.8f);
      float num = 6f;
      Draw.rect(Icon.cancel.getRegion(), this.x, this.y, num, num);
      Draw.reset();
    }

    [LineNumberTable(new byte[] {164, 47, 127, 23, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawLight()
    {
      if (!this.block.hasLiquids || !this.block.drawLiquidLight || (double) this.liquids.current().lightColor.a <= 1.0 / 1000.0)
        return;
      this.drawLiquidLight(this.liquids.current(), this.liquids.smoothAmount());
    }

    [LineNumberTable(new byte[] {164, 57, 106, 106, 127, 14, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawConfigure()
    {
      Draw.color(Pal.accent);
      Lines.stroke(1f);
      Lines.square(this.x, this.y, (float) (this.block.size * 8) / 2f + 1f);
      Draw.reset();
    }

    [LineNumberTable(new byte[] {164, 64, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void healFract(float amount) => this.heal(amount * this.maxHealth);

    [LineNumberTable(new byte[] {164, 84, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(Position pos) => this.trns(pos.getX(), pos.getY());

    [LineNumberTable(new byte[] {164, 144, 109, 116, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void control(LAccess type, double p1, double p2, double p3, double p4)
    {
      if (!object.ReferenceEquals((object) type, (object) LAccess.__\u003C\u003Eenabled))
        return;
      this.enabled = !Mathf.zero((float) p1);
      this.enabledControlTime = 360f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void playerPlaced(object config)
    {
    }

    [LineNumberTable(new byte[] {164, 172, 109, 127, 8, 255, 3, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void placed()
    {
      if (Vars.net.client() || !this.block.consumesPower && !this.block.outputsPower || !this.block.hasPower)
        return;
      PowerNode.getNodeLinks(this.tile, this.block, this.team, (Cons) new Building.__\u003C\u003EAnon3(this));
    }

    [LineNumberTable(1340)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getDisplayEfficiency() => this.getProgressIncrease(1f) / this.edelta();

    [LineNumberTable(new byte[] {164, 206, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void damageContinuous(float amount) => this.damage(amount * Time.delta, (double) this.hitTime <= -1.0);

    [LineNumberTable(new byte[] {164, 218, 209, 107, 103, 122, 177, 102, 103, 119, 127, 50, 102, 127, 5, 104, 103, 103, 242, 86, 134, 104, 103, 242, 78, 166, 116, 103, 159, 37, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table)
    {
      table.table((Cons) new Building.__\u003C\u003EAnon4(this)).growX().left();
      table.row();
      if (!object.ReferenceEquals((object) this.team, (object) Vars.player.team()))
        return;
      table.table((Cons) new Building.__\u003C\u003EAnon5(this)).growX();
      table.row();
      table.table((Cons) new Building.__\u003C\u003EAnon6(this)).growX();
      if ((!object.ReferenceEquals((object) this.block.category, (object) Category.__\u003C\u003Edistribution) && !object.ReferenceEquals((object) this.block.category, (object) Category.__\u003C\u003Eliquid) || (!Core.settings.getBool("flow") || !this.block.displayFlow) ? 0 : 1) != 0)
      {
        string str = new StringBuilder().append(" ").append(StatUnit.__\u003C\u003EperSecond.localized()).toString();
        if (this.items != null)
        {
          table.row();
          table.left();
          table.table((Cons) new Building.__\u003C\u003EAnon7(this, str)).left();
        }
        if (this.liquids != null)
        {
          table.row();
          table.table((Cons) new Building.__\u003C\u003EAnon8(this, str)).left();
        }
      }
      if (Vars.net.active() && this.lastAccessed != null)
      {
        table.row();
        Table table1 = table;
        object obj = (object) Core.bundle.format("lastaccessed", (object) this.lastAccessed);
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table1.add(text).growX().wrap().left();
      }
      table.marginBottom(-5f);
    }

    [LineNumberTable(1435)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building core() => (Building) this.team.core();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void buildConfiguration(Table table)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shouldShowConfigure(Player player) => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleString(object value)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void heal()
    {
      this.dead = false;
      this.health = this.maxHealth;
    }

    [Signature("(Larc/struct/Seq<Lmindustry/gen/Building;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void overwrote(Seq previous)
    {
    }

    [LineNumberTable(new byte[] {165, 94, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void damageContinuousPierce(float amount) => this.damagePierce(amount * Time.delta, (double) this.hitTime <= -11.0);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unitRemoved(Unit unit)
    {
    }

    [LineNumberTable(new byte[] {165, 101, 102, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleStack(Item item, int amount, Teamc source)
    {
      this.noSleep();
      this.items.add(item, amount);
    }

    [LineNumberTable(1505)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool dump() => this.dump((Item) null);

    [LineNumberTable(new byte[] {165, 119, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void consume() => this.cons.trigger();

    [LineNumberTable(new byte[] {165, 123, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void damagePierce(float amount) => this.damagePierce(amount, true);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int classId() => 6;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void health(float health) => this.health = health;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float hitTime() => this.hitTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hitTime(float hitTime) => this.hitTime = hitTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dead(bool dead) => this.dead = dead;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float x() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void x(float x) => this.x = x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float y() => this.y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void y(float y) => this.y = y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Interval timer() => this.timer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int id() => this.id;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void id(int id) => this.id = id;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block block() => this.block;

    [Signature("(Larc/struct/Seq<Lmindustry/gen/Building;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void proximity(Seq proximity) => this.proximity = proximity;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool updateFlow() => this.updateFlow;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateFlow(bool updateFlow) => this.updateFlow = updateFlow;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte cdump() => this.cdump;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cdump(byte cdump) => this.cdump = cdump;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int rotation() => this.rotation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rotation(int rotation) => this.rotation = rotation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool enabled() => this.enabled;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void enabled(bool enabled) => this.enabled = enabled;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float enabledControlTime() => this.enabledControlTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void enabledControlTime(float enabledControlTime) => this.enabledControlTime = enabledControlTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string lastAccessed() => this.lastAccessed;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lastAccessed(string lastAccessed) => this.lastAccessed = lastAccessed;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual PowerModule power() => this.power;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ItemModule items() => this.items;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void items(ItemModule items) => this.items = items;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LiquidModule liquids() => this.liquids;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ConsumeModule cons() => this.cons;

    [LineNumberTable(new byte[] {159, 100, 109, 138, 138, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Building()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.gen.Building"))
        return;
      Building.__\u003C\u003EtmpTiles = new ObjectSet();
      Building.__\u003C\u003EtempTileEnts = new Seq();
      Building.__\u003C\u003EtempTiles = new Seq();
      Building.sleepingEntities = 0;
    }

    [HideFromJava]
    public virtual float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float dst2([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst2((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

    [Modifiers]
    public static ObjectSet tmpTiles
    {
      [HideFromJava] get => Building.__\u003C\u003EtmpTiles;
    }

    [Modifiers]
    public static Seq tempTileEnts
    {
      [HideFromJava] get => Building.__\u003C\u003EtempTileEnts;
    }

    [Modifiers]
    public static Seq tempTiles
    {
      [HideFromJava] get => Building.__\u003C\u003EtempTiles;
    }

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

      [LineNumberTable(449)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.gen.Building$1"))
          return;
        Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess = new int[LAccess.values().Length];
        try
        {
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Etype.ordinal()] = 1;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EfirstItem.ordinal()] = 2;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Econfig.ordinal()] = 3;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpayloadType.ordinal()] = 4;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Ex.ordinal()] = 5;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Ey.ordinal()] = 6;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Edead.ordinal()] = 7;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eteam.ordinal()] = 8;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Ehealth.ordinal()] = 9;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EmaxHealth.ordinal()] = 10;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eefficiency.ordinal()] = 11;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Etimescale.ordinal()] = 12;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Erange.ordinal()] = 13;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Erotation.ordinal()] = 14;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EtotalItems.ordinal()] = 15;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EtotalLiquids.ordinal()] = 16;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EtotalPower.ordinal()] = 17;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EitemCapacity.ordinal()] = 18;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EliquidCapacity.ordinal()] = 19;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpowerCapacity.ordinal()] = 20;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpowerNetIn.ordinal()] = 21;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpowerNetOut.ordinal()] = 22;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpowerNetStored.ordinal()] = 23;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpowerNetCapacity.ordinal()] = 24;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eenabled.ordinal()] = 25;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Econtrolled.ordinal()] = 26;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpayloadCount.ordinal()] = 27;
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
          Building.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Esize.ordinal()] = 28;
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
    private sealed class __\u003C\u003EAnon0 : LiquidModule.LiquidCalculator
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public float get([In] Liquid obj0, [In] float obj1) => Building.lambda\u0024onDestroyed\u00240(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : LiquidModule.LiquidCalculator
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public float get([In] Liquid obj0, [In] float obj1) => Building.lambda\u0024onDestroyed\u00241(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : LiquidModule.LiquidConsumer
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon2([In] Building obj0) => this.arg\u00241 = obj0;

      public void accept([In] Liquid obj0, [In] float obj1) => this.arg\u00241.lambda\u0024onDestroyed\u00243(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon3([In] Building obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024placed\u00244((Building) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon4([In] Building obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u00245((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon5([In] Building obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u00246((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon6([In] Building obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.displayConsumption((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly Building arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon7([In] Building obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u002410(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      private readonly Building arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon8([In] Building obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u002415(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly Building arg\u00241;
      private readonly Table arg\u00242;
      private readonly string arg\u00243;

      internal __\u003C\u003EAnon9([In] Building obj0, [In] Table obj1, [In] string obj2)
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
      private readonly Building arg\u00241;
      private readonly bool[] arg\u00242;
      private readonly Runnable arg\u00243;

      internal __\u003C\u003EAnon10([In] Building obj0, [In] bool[] obj1, [In] Runnable obj2)
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
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon11([In] Building obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024display\u002411();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Prov
    {
      private readonly Building arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon12([In] Building obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) this.arg\u00241.lambda\u0024display\u002412(this.arg\u00242).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly Building arg\u00241;
      private readonly Table arg\u00242;
      private readonly string arg\u00243;

      internal __\u003C\u003EAnon13([In] Building obj0, [In] Table obj1, [In] string obj2)
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
      private readonly Building arg\u00241;
      private readonly Bits arg\u00242;
      private readonly Runnable arg\u00243;

      internal __\u003C\u003EAnon14([In] Building obj0, [In] Bits obj1, [In] Runnable obj2)
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
      private readonly Building arg\u00241;
      private readonly Item arg\u00242;
      private readonly string arg\u00243;

      internal __\u003C\u003EAnon15([In] Building obj0, [In] Item obj1, [In] string obj2)
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
      private readonly Building arg\u00241;
      private readonly Liquid arg\u00242;
      private readonly float arg\u00243;

      internal __\u003C\u003EAnon16([In] Building obj0, [In] Liquid obj1, [In] float obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024onDestroyed\u00242(this.arg\u00242, this.arg\u00243);
    }
  }
}
