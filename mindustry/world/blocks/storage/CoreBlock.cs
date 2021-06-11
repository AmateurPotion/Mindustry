// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.storage.CoreBlock
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
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.core;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.logic;
using mindustry.type;
using mindustry.world.blocks.units;
using mindustry.world.meta;
using mindustry.world.modules;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.storage
{
  public class CoreBlock : StorageBlock
  {
    private static ItemModule nextItems;
    public UnitType unitType;
    internal int __\u003C\u003EtimerResupply;
    public int ammoAmount;
    public float resupplyRate;
    public float resupplyRange;
    public Item resupplyItem;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {63, 101, 135, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool canPlaceOn(Tile tile, Team team)
    {
      if (tile == null)
        return false;
      CoreBlock.CoreBuild coreBuild = team.core();
      return coreBuild != null && (Vars.state.rules.infiniteResources || coreBuild.items.has(this.requirements, Vars.state.rules.buildCostMultiplier)) && (tile.block() is CoreBlock && this.size > tile.block().size);
    }

    [Modifiers]
    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static mindustry.ui.Bar lambda\u0024setBars\u00244([In] CoreBlock.CoreBuild obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar((Prov) new CoreBlock.__\u003C\u003EAnon1(obj0), (Prov) new CoreBlock.__\u003C\u003EAnon2(), (Floatp) new CoreBlock.__\u003C\u003EAnon3(obj0));
    }

    [Modifiers]
    [LineNumberTable(94)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setBars\u00240([In] CoreBlock.CoreBuild obj0) => Core.bundle.format("bar.capacity", (object) UI.formatAmount(obj0.storageCapacity));

    [Modifiers]
    [LineNumberTable(95)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u00241() => Pal.items;

    [Modifiers]
    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024setBars\u00243([In] CoreBlock.CoreBuild obj0) => (float) obj0.items.total() / ((float) obj0.storageCapacity * (float) Vars.content.items().count((Boolf) new CoreBlock.__\u003C\u003EAnon4()));

    [Modifiers]
    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024setBars\u00242([In] Item obj0) => obj0.unlockedNow();

    [LineNumberTable(new byte[] {159, 185, 233, 54, 139, 153, 103, 107, 107, 235, 69, 103, 103, 103, 107, 127, 2, 104, 107, 107, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CoreBlock(string name)
      : base(name)
    {
      CoreBlock coreBlock1 = this;
      this.unitType = UnitTypes.alpha;
      CoreBlock coreBlock2 = this;
      int timers = coreBlock2.timers;
      CoreBlock coreBlock3 = coreBlock2;
      int num = timers;
      coreBlock3.timers = timers + 1;
      this.__\u003C\u003EtimerResupply = num;
      this.ammoAmount = 5;
      this.resupplyRate = 10f;
      this.resupplyRange = 60f;
      this.resupplyItem = Items.copper;
      this.solid = true;
      this.update = true;
      this.hasItems = true;
      this.priority = TargetPriority.__\u003C\u003Ecore;
      this.flags = EnumSet.of((Enum[]) new BlockFlag[2]
      {
        BlockFlag.__\u003C\u003Ecore,
        BlockFlag.__\u003C\u003EunitModifier
      });
      this.unitCapModifier = 10;
      this.loopSound = Sounds.respawning;
      this.loopSoundVolume = 1f;
      this.drawDisabled = false;
      this.canOverdrive = false;
      this.replaceable = false;
    }

    [LineNumberTable(new byte[] {10, 159, 12, 108, 139, 135, 108, 114, 103, 107, 112, 103, 103, 166, 121, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void playerSpawn(Tile tile, Player player)
    {
      if (player == null || tile == null)
        return;
      Building build = tile.build;
      CoreBlock.CoreBuild coreBuild;
      if (!(build is CoreBlock.CoreBuild) || !object.ReferenceEquals((object) (coreBuild = (CoreBlock.CoreBuild) build), (object) (CoreBlock.CoreBuild) build))
        return;
      CoreBlock coreBlock = (CoreBlock) tile.block();
      Fx.__\u003C\u003Espawn.at((Position) coreBuild);
      player.set((Position) coreBuild);
      if (!Vars.net.client())
      {
        Unit unit = coreBlock.unitType.create(tile.team());
        unit.set((Position) coreBuild);
        unit.rotation(90f);
        unit.impulse(0.0f, 3f);
        unit.controller((UnitController) player);
        unit.spawnedByCore(true);
        unit.add();
      }
      if (!Vars.state.isCampaign() || !object.ReferenceEquals((object) player, (object) Vars.player))
        return;
      coreBlock.unitType.unlock();
    }

    [LineNumberTable(new byte[] {34, 134, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.remove(Stat.__\u003C\u003EbuildTime);
    }

    [LineNumberTable(new byte[] {41, 134, 250, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.add("capacity", (Func) new CoreBlock.__\u003C\u003EAnon0());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool canBreak(Tile tile) => false;

    [LineNumberTable(108)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool canReplace(Block other) => base.canReplace(other) || other is CoreBlock && this.size > other.size;

    [LineNumberTable(new byte[] {73, 104, 109, 119, 183, 135, 109, 186, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void placeBegan(Tile tile, Block previous)
    {
      if (!(previous is CoreBlock))
        return;
      tile.setBlock((Block) this, tile.team());
      Fx.__\u003C\u003EplaceBlock.at((Position) tile, (float) tile.block().size);
      Fx.__\u003C\u003EupgradeCore.at((Position) tile, (float) tile.block().size);
      if (CoreBlock.nextItems == null)
        return;
      if (tile.team().core() != null)
        tile.team().core().items.set(CoreBlock.nextItems);
      CoreBlock.nextItems = (ItemModule) null;
    }

    [LineNumberTable(new byte[] {92, 141, 113, 113, 191, 1, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void beforePlaceBegan(Tile tile, Block previous)
    {
      if (!(tile.build is CoreBlock.CoreBuild))
        return;
      ItemModule itemModule = tile.build.items.copy();
      if (!Vars.state.rules.infiniteResources)
        itemModule.remove(ItemStack.mult(this.requirements, Vars.state.rules.buildCostMultiplier));
      CoreBlock.nextItems = itemModule;
    }

    [LineNumberTable(new byte[] {159, 104, 163, 143, 159, 2, 127, 57, 103, 5, 239, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid)
    {
      int num1 = valid ? 1 : 0;
      if (Vars.world.tile(x, y) == null || this.canPlaceOn(Vars.world.tile(x, y), Vars.player.team()))
        return;
      double num2 = (double) this.drawPlaceText(Core.bundle.get(Vars.player.team().core() != null && Vars.player.team().core().items.has(this.requirements, Vars.state.rules.buildCostMultiplier) || Vars.state.rules.infiniteResources ? "bar.corereq" : "bar.noresources"), x, y, num1 != 0);
    }

    [HideFromJava]
    static CoreBlock() => StorageBlock.__\u003Cclinit\u003E();

    [Modifiers]
    public int timerResupply
    {
      [HideFromJava] get => this.__\u003C\u003EtimerResupply;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerResupply = value;
    }

    [Implements(new string[] {"mindustry.world.blocks.ControlBlock"})]
    public class CoreBuild : Building, ControlBlock
    {
      public int storageCapacity;
      public BlockUnitc unit;
      public bool noEffect;
      [Modifiers]
      internal CoreBlock this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 77, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void requestSpawn(Player player) => Call.playerSpawn(this.tile, player);

      [LineNumberTable(236)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int getMaximumAccepted(Item item) => Vars.state.rules.coreIncinerates ? this.storageCapacity * 2 : this.storageCapacity;

      [LineNumberTable(318)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool owns(Building core, Building tile)
      {
        Building building = tile;
        StorageBlock.StorageBuild storageBuild;
        return building is StorageBlock.StorageBuild && object.ReferenceEquals((object) (storageBuild = (StorageBlock.StorageBuild) building), (object) (StorageBlock.StorageBuild) building) && (object.ReferenceEquals((object) storageBuild.linkedCore, (object) core) || storageBuild.linkedCore == null);
      }

      [LineNumberTable(new byte[] {160, 127, 127, 16, 115, 140, 98, 144, 127, 9, 255, 2, 69, 127, 16, 117, 127, 17, 162, 108, 127, 5, 127, 4, 162, 127, 16, 108, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onProximityUpdate()
      {
        Iterator iterator1 = Vars.state.teams.cores(this.team).iterator();
        while (iterator1.hasNext())
        {
          Building building = (Building) iterator1.next();
          if (!object.ReferenceEquals((object) building.tile(), (object) this.tile))
            this.items = building.items;
        }
        Vars.state.teams.registerCore(this);
        this.storageCapacity = this.this\u00240.itemCapacity + this.proximity().sum((Intf) new CoreBlock.CoreBuild.__\u003C\u003EAnon0(this));
        this.proximity.each((Boolf) new CoreBlock.CoreBuild.__\u003C\u003EAnon1(this), (Cons) new CoreBlock.CoreBuild.__\u003C\u003EAnon2(this));
        Iterator iterator2 = Vars.state.teams.cores(this.team).iterator();
        while (iterator2.hasNext())
        {
          Building building = (Building) iterator2.next();
          if (!object.ReferenceEquals((object) building.tile(), (object) this.tile))
            this.storageCapacity += building.block.itemCapacity + building.proximity().sum((Intf) new CoreBlock.CoreBuild.__\u003C\u003EAnon3(this, building));
        }
        if (!Vars.world.isGenerating())
        {
          Iterator iterator3 = Vars.content.items().iterator();
          while (iterator3.hasNext())
          {
            Item obj = (Item) iterator3.next();
            this.items.set(obj, Math.min(this.items.get(obj), this.storageCapacity));
          }
        }
        Iterator iterator4 = Vars.state.teams.cores(this.team).iterator();
        while (iterator4.hasNext())
          ((CoreBlock.CoreBuild) iterator4.next()).storageCapacity = this.storageCapacity;
      }

      [LineNumberTable(314)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool owns(Building tile) => this.owns((Building) this, tile);

      [Modifiers]
      [LineNumberTable(248)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int lambda\u0024onProximityUpdate\u00240([In] Building obj0) => this.owns(obj0) ? obj0.block.itemCapacity : 0;

      [Modifiers]
      [LineNumberTable(249)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024onProximityUpdate\u00241([In] Building obj0) => this.owns(obj0);

      [Modifiers]
      [LineNumberTable(new byte[] {160, 136, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024onProximityUpdate\u00242([In] Building obj0)
      {
        obj0.items = this.items;
        ((StorageBlock.StorageBuild) obj0).linkedCore = (Building) this;
      }

      [Modifiers]
      [LineNumberTable(256)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int lambda\u0024onProximityUpdate\u00243([In] Building obj0, [In] Building obj1) => this.owns(obj0, obj1) ? obj1.block.itemCapacity : 0;

      [Modifiers]
      [LineNumberTable(new byte[] {160, 186, 105, 104, 127, 5, 255, 20, 61, 233, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024drawSelect\u00244([In] Building obj0)
      {
        for (int index = 0; index < 4; ++index)
        {
          Point2 point2 = Geometry.__\u003C\u003Ed8edge[index];
          float num = (float) -Math.max(obj0.block.size - 1, 0) / 2f * 8f;
          Draw.rect("block-select", obj0.x + num * (float) point2.x, obj0.y + num * (float) point2.y, (float) (index * 90));
        }
      }

      [Modifiers]
      [LineNumberTable(new byte[] {160, 193, 103, 119})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024drawSelect\u00246([In] Cons obj0, [In] CoreBlock.CoreBuild obj1)
      {
        obj0.get((object) obj1);
        obj1.proximity.each((Boolf) new CoreBlock.CoreBuild.__\u003C\u003EAnon9(this), obj0);
      }

      [Modifiers]
      [LineNumberTable(331)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024onRemoved\u00247([In] Building obj0) => obj0.items != null && object.ReferenceEquals((object) obj0.items, (object) this.items);

      [Modifiers]
      [LineNumberTable(334)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024onRemoved\u00248([In] Building obj0) => this.owns(obj0) && object.ReferenceEquals((object) obj0.items, (object) this.items) && this.owns(obj0);

      [Modifiers]
      [LineNumberTable(new byte[] {160, 221, 103, 103, 107, 127, 5, 127, 3, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024onRemoved\u00249([In] float obj0, [In] Building obj1)
      {
        StorageBlock.StorageBuild storageBuild = (StorageBlock.StorageBuild) obj1;
        storageBuild.linkedCore = (Building) null;
        storageBuild.items = new ItemModule();
        Iterator iterator = Vars.content.items().iterator();
        while (iterator.hasNext())
        {
          Item obj = (Item) iterator.next();
          storageBuild.items.set(obj, ByteCodeHelper.f2i(obj0 * (float) this.items.get(obj)));
        }
      }

      [Modifiers]
      [LineNumberTable(308)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024drawSelect\u00245([In] Building obj0) => object.ReferenceEquals((object) obj0.items, (object) this.items);

      [LineNumberTable(new byte[] {117, 175, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public CoreBuild(CoreBlock _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        CoreBlock.CoreBuild coreBuild = this;
        this.unit = Nulls.__\u003C\u003EblockUnit;
        this.noEffect = false;
      }

      [LineNumberTable(new byte[] {125, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override double sense(LAccess sensor) => object.ReferenceEquals((object) sensor, (object) LAccess.__\u003C\u003EitemCapacity) ? (double) this.storageCapacity : base.sense(sensor);

      [LineNumberTable(new byte[] {160, 67, 123, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void created()
      {
        this.unit = (BlockUnitc) UnitTypes.block.create(this.team);
        this.unit.tile((Building) this);
      }

      [LineNumberTable(187)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Unit unit() => (Unit) this.unit;

      [LineNumberTable(new byte[] {160, 84, 127, 70, 151})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (!this.items.has(this.this\u00240.resupplyItem) || !this.timer(this.this\u00240.__\u003C\u003EtimerResupply, this.this\u00240.resupplyRate) || !ResupplyPoint.resupply((Building) this, this.this\u00240.resupplyRange, (float) this.this\u00240.ammoAmount, this.this\u00240.resupplyItem.color))
          return;
        this.items.remove(this.this\u00240.resupplyItem, 1);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool canPickup() => false;

      [LineNumberTable(new byte[] {160, 97, 166, 159, 28, 144, 119, 181})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onDestroyed()
      {
        base.onDestroyed();
        if (!Vars.state.isCampaign() || !object.ReferenceEquals((object) this.team, (object) Vars.state.rules.waveTeam) || this.team.cores().size > 1)
          return;
        this.tile.setOverlayQuiet(Blocks.spawn);
        if (Vars.spawner.getSpawns().contains((object) this.tile))
          return;
        Vars.spawner.getSpawns().add((object) this.tile);
      }

      [LineNumberTable(new byte[] {160, 112, 127, 46})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawLight() => Drawf.light(this.team, this.x, this.y, 30f + 20f * (float) this.this\u00240.size, Pal.accent, 0.65f + Mathf.absin(20f, 0.1f));

      [LineNumberTable(231)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => this.items.get(item) < this.getMaximumAccepted(item);

      [LineNumberTable(new byte[] {160, 159, 122, 137, 127, 9, 155, 99, 182})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleStack(Item item, int amount, Teamc source)
      {
        int amount1 = Math.min(amount, this.storageCapacity - this.items.get(item));
        base.handleStack(item, amount1, source);
        if (!object.ReferenceEquals((object) this.team, (object) Vars.state.rules.defaultTeam) || !Vars.state.isCampaign())
          return;
        Vars.state.rules.sector.info.handleCoreItem(item, amount);
        if (amount1 != 0)
          return;
        Fx.__\u003C\u003EcoreBurn.at(this.x, this.y);
      }

      [LineNumberTable(new byte[] {160, 173, 137, 127, 9, 188})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int removeStack(Item item, int amount)
      {
        int num = base.removeStack(item, amount);
        if (object.ReferenceEquals((object) this.team, (object) Vars.state.rules.defaultTeam) && Vars.state.isCampaign())
          Vars.state.rules.sector.info.handleCoreItem(item, -num);
        return num;
      }

      [LineNumberTable(new byte[] {160, 184, 111, 235, 71, 220, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawSelect()
      {
        Lines.stroke(1f, Pal.accent);
        Cons cons = (Cons) new CoreBlock.CoreBuild.__\u003C\u003EAnon4();
        this.team.cores().each((Cons) new CoreBlock.CoreBuild.__\u003C\u003EAnon5(this, cons));
        Draw.reset();
      }

      [LineNumberTable(new byte[] {160, 209, 126, 138})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float handleDamage(float amount)
      {
        if (Vars.player != null && object.ReferenceEquals((object) this.team, (object) Vars.player.team()))
          Events.fire((object) EventType.Trigger.__\u003C\u003EteamCoreDamage);
        return amount;
      }

      [LineNumberTable(new byte[] {160, 217, 119, 159, 8, 255, 3, 73, 144, 127, 8, 127, 6, 127, 1, 130, 127, 17, 103, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onRemoved()
      {
        this.proximity.each((Boolf) new CoreBlock.CoreBuild.__\u003C\u003EAnon7(this), (Cons) new CoreBlock.CoreBuild.__\u003C\u003EAnon8(this, 1f / (float) this.proximity.count((Boolf) new CoreBlock.CoreBuild.__\u003C\u003EAnon6(this)) / (float) Vars.state.teams.cores(this.team).size));
        Vars.state.teams.unregisterCore(this);
        int num = this.this\u00240.itemCapacity * Vars.state.teams.cores(this.team).size;
        Iterator iterator1 = Vars.content.items().iterator();
        while (iterator1.hasNext())
        {
          Item obj = (Item) iterator1.next();
          this.items.set(obj, Math.min(this.items.get(obj), num));
        }
        Iterator iterator2 = Vars.state.teams.cores(this.team).iterator();
        while (iterator2.hasNext())
          ((CoreBlock.CoreBuild) iterator2.next()).onProximityUpdate();
      }

      [LineNumberTable(new byte[] {160, 243, 102, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void placed()
      {
        base.placed();
        Vars.state.teams.registerCore(this);
      }

      [LineNumberTable(new byte[] {160, 249, 159, 9, 155})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void itemTaken(Item item)
      {
        if (!Vars.state.isCampaign() || !object.ReferenceEquals((object) this.team, (object) Vars.state.rules.defaultTeam))
          return;
        Vars.state.rules.sector.info.handleCoreItem(item, -1);
      }

      [LineNumberTable(new byte[] {161, 1, 123, 127, 9, 187, 148, 104, 135, 137, 138, 159, 14, 103, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleItem(Building source, Item item)
      {
        if (Vars.net.server() || !Vars.net.active())
        {
          if (object.ReferenceEquals((object) this.team, (object) Vars.state.rules.defaultTeam) && Vars.state.isCampaign())
            Vars.state.rules.sector.info.handleCoreItem(item, 1);
          if (this.items.get(item) >= this.storageCapacity)
          {
            if (!this.noEffect)
              StorageBlock.incinerateEffect((Building) this, source);
            this.noEffect = false;
          }
          else
            base.handleItem(source, item);
        }
        else
        {
          if (!Vars.state.rules.coreIncinerates || this.items.get(item) < this.storageCapacity || this.noEffect)
            return;
          StorageBlock.incinerateEffect((Building) this, source);
          this.noEffect = false;
        }
      }

      [HideFromJava]
      public virtual bool isControlled() => ControlBlock.\u003Cdefault\u003EisControlled((ControlBlock) this);

      [HideFromJava]
      public virtual bool canControl() => ControlBlock.\u003Cdefault\u003EcanControl((ControlBlock) this);

      [HideFromJava]
      public virtual bool shouldAutoTarget() => ControlBlock.\u003Cdefault\u003EshouldAutoTarget((ControlBlock) this);

      [HideFromJava]
      static CoreBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Intf
      {
        private readonly CoreBlock.CoreBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] CoreBlock.CoreBuild obj0) => this.arg\u00241 = obj0;

        public int get([In] object obj0) => this.arg\u00241.lambda\u0024onProximityUpdate\u00240((Building) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Boolf
      {
        private readonly CoreBlock.CoreBuild arg\u00241;

        internal __\u003C\u003EAnon1([In] CoreBlock.CoreBuild obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024onProximityUpdate\u00241((Building) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Cons
      {
        private readonly CoreBlock.CoreBuild arg\u00241;

        internal __\u003C\u003EAnon2([In] CoreBlock.CoreBuild obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024onProximityUpdate\u00242((Building) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Intf
      {
        private readonly CoreBlock.CoreBuild arg\u00241;
        private readonly Building arg\u00242;

        internal __\u003C\u003EAnon3([In] CoreBlock.CoreBuild obj0, [In] Building obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public int get([In] object obj0) => this.arg\u00241.lambda\u0024onProximityUpdate\u00243(this.arg\u00242, (Building) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Cons
      {
        internal __\u003C\u003EAnon4()
        {
        }

        public void get([In] object obj0) => CoreBlock.CoreBuild.lambda\u0024drawSelect\u00244((Building) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon5 : Cons
      {
        private readonly CoreBlock.CoreBuild arg\u00241;
        private readonly Cons arg\u00242;

        internal __\u003C\u003EAnon5([In] CoreBlock.CoreBuild obj0, [In] Cons obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024drawSelect\u00246(this.arg\u00242, (CoreBlock.CoreBuild) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon6 : Boolf
      {
        private readonly CoreBlock.CoreBuild arg\u00241;

        internal __\u003C\u003EAnon6([In] CoreBlock.CoreBuild obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024onRemoved\u00247((Building) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon7 : Boolf
      {
        private readonly CoreBlock.CoreBuild arg\u00241;

        internal __\u003C\u003EAnon7([In] CoreBlock.CoreBuild obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024onRemoved\u00248((Building) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon8 : Cons
      {
        private readonly CoreBlock.CoreBuild arg\u00241;
        private readonly float arg\u00242;

        internal __\u003C\u003EAnon8([In] CoreBlock.CoreBuild obj0, [In] float obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024onRemoved\u00249(this.arg\u00242, (Building) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon9 : Boolf
      {
        private readonly CoreBlock.CoreBuild arg\u00241;

        internal __\u003C\u003EAnon9([In] CoreBlock.CoreBuild obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024drawSelect\u00245((Building) obj0) ? 1 : 0) != 0;
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Func
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get([In] object obj0) => (object) CoreBlock.lambda\u0024setBars\u00244((CoreBlock.CoreBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Prov
    {
      private readonly CoreBlock.CoreBuild arg\u00241;

      internal __\u003C\u003EAnon1([In] CoreBlock.CoreBuild obj0) => this.arg\u00241 = obj0;

      public object get() => (object) CoreBlock.lambda\u0024setBars\u00240(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) CoreBlock.lambda\u0024setBars\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Floatp
    {
      private readonly CoreBlock.CoreBuild arg\u00241;

      internal __\u003C\u003EAnon3([In] CoreBlock.CoreBuild obj0) => this.arg\u00241 = obj0;

      public float get() => CoreBlock.lambda\u0024setBars\u00243(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Boolf
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public bool get([In] object obj0) => (CoreBlock.lambda\u0024setBars\u00242((Item) obj0) ? 1 : 0) != 0;
    }
  }
}
