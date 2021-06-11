// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.production.Drill
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using java.util.function;
using mindustry.content;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using mindustry.world.blocks.environment;
using mindustry.world.meta;
using mindustry.world.meta.values;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.production
{
  public class Drill : Block
  {
    public float hardnessDrillMultiplier;
    [Signature("Larc/struct/ObjectIntMap<Lmindustry/type/Item;>;")]
    internal ObjectIntMap __\u003C\u003EoreCount;
    [Signature("Larc/struct/Seq<Lmindustry/type/Item;>;")]
    internal Seq __\u003C\u003EitemArray;
    public int tier;
    public float drillTime;
    public float liquidBoostIntensity;
    public float warmupSpeed;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    protected internal Item returnItem;
    protected internal int returnCount;
    public bool drawMineItem;
    public Effect drillEffect;
    public float rotateSpeed;
    public Effect updateEffect;
    public float updateEffectChance;
    public bool drawRim;
    public Color heatColor;
    public TextureRegion rimRegion;
    public TextureRegion rotatorRegion;
    public TextureRegion topRegion;
    public TextureRegion itemRegion;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {113, 103, 135, 107, 140, 127, 7, 105, 149, 130, 127, 6, 108, 130, 247, 72, 109, 161, 118, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void countOre([In] Tile obj0)
    {
      this.returnItem = (Item) null;
      this.returnCount = 0;
      this.__\u003C\u003EoreCount.clear();
      this.__\u003C\u003EitemArray.clear();
      Iterator iterator = obj0.getLinkedTilesAs((Block) this, Block.__\u003C\u003EtempTiles).iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        if (this.canMine(tile))
          this.__\u003C\u003EoreCount.increment((object) this.getDrop(tile), 0, 1);
      }
      ObjectIntMap.Keys keys = this.__\u003C\u003EoreCount.keys().iterator();
      while (((Iterator) keys).hasNext())
        this.__\u003C\u003EitemArray.add((object) (Item) ((Iterator) keys).next());
      this.__\u003C\u003EitemArray.sort((Comparator) new Drill.__\u003C\u003EAnon3(this));
      if (this.__\u003C\u003EitemArray.size == 0)
        return;
      this.returnItem = (Item) this.__\u003C\u003EitemArray.peek();
      this.returnCount = this.__\u003C\u003EoreCount.get((object) (Item) this.__\u003C\u003EitemArray.peek(), 0);
    }

    [LineNumberTable(new byte[] {160, 82, 101, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canMine(Tile tile)
    {
      if (tile == null)
        return false;
      Item obj = tile.drop();
      return obj != null && obj.hardness <= this.tier;
    }

    [LineNumberTable(97)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Item getDrop(Tile tile) => tile.drop();

    [Modifiers]
    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static mindustry.ui.Bar lambda\u0024setBars\u00243([In] Drill.DrillBuild obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar((Prov) new Drill.__\u003C\u003EAnon4(obj0), (Prov) new Drill.__\u003C\u003EAnon5(), (Floatp) new Drill.__\u003C\u003EAnon6(obj0));
    }

    [Modifiers]
    [LineNumberTable(137)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024drawPlace\u00244([In] Tile obj0) => obj0.drop() != null && obj0.drop().hardness > this.tier;

    [Modifiers]
    [LineNumberTable(149)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setStats\u00245([In] Block obj0)
    {
      Block block = obj0;
      Floor floor;
      return block is Floor && object.ReferenceEquals((object) (floor = (Floor) block), (object) (Floor) block) && (floor.itemDrop != null && floor.itemDrop.hardness <= this.tier);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 66, 126, 101, 127, 1, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int lambda\u0024countOre\u00246([In] Item obj0, [In] Item obj1)
    {
      int num1 = Boolean.compare(!obj0.lowPriority, !obj1.lowPriority);
      if (num1 != 0)
        return num1;
      int num2 = Integer.compare(this.__\u003C\u003EoreCount.get((object) obj0, 0), this.__\u003C\u003EoreCount.get((object) obj1, 0));
      return num2 != 0 ? num2 : Integer.compare((int) obj0.__\u003C\u003Eid, (int) obj1.__\u003C\u003Eid);
    }

    [Modifiers]
    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setBars\u00240([In] Drill.DrillBuild obj0) => Core.bundle.format("bar.drillspeed", (object) Strings.@fixed(obj0.lastDrillSpeed * 60f * obj0.timeScale, 2));

    [Modifiers]
    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u00241() => Pal.ammo;

    [Modifiers]
    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024setBars\u00242([In] Drill.DrillBuild obj0) => obj0.warmup;

    [LineNumberTable(new byte[] {13, 233, 27, 139, 107, 235, 69, 139, 139, 235, 71, 135, 139, 139, 139, 139, 103, 240, 72, 103, 103, 107, 103, 107, 103, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Drill(string name)
      : base(name)
    {
      Drill drill = this;
      this.hardnessDrillMultiplier = 50f;
      this.__\u003C\u003EoreCount = new ObjectIntMap();
      this.__\u003C\u003EitemArray = new Seq();
      this.drillTime = 300f;
      this.liquidBoostIntensity = 1.6f;
      this.warmupSpeed = 0.02f;
      this.drawMineItem = true;
      this.drillEffect = Fx.__\u003C\u003Emine;
      this.rotateSpeed = 2f;
      this.updateEffect = Fx.__\u003C\u003EpulverizeSmall;
      this.updateEffectChance = 0.02f;
      this.drawRim = false;
      this.heatColor = Color.valueOf("ff5512");
      this.update = true;
      this.solid = true;
      this.group = BlockGroup.__\u003C\u003Edrills;
      this.hasLiquids = true;
      this.liquidCapacity = 5f;
      this.hasItems = true;
      this.ambientSound = Sounds.drill;
      this.ambientSoundVolume = 0.018f;
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {26, 105, 103, 132, 103, 145, 112, 121, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestConfigTop(BuildPlan req, Eachable list)
    {
      if (!req.worldContext)
        return;
      Tile tile = req.tile();
      if (tile == null)
        return;
      this.countOre(tile);
      if (this.returnItem == null || !this.drawMineItem)
        return;
      Draw.color(this.returnItem.color);
      Draw.rect(this.itemRegion, req.drawx(), req.drawy());
      Draw.color();
    }

    [LineNumberTable(new byte[] {40, 134, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.add("drillspeed", (Func) new Drill.__\u003C\u003EAnon0());
    }

    [LineNumberTable(new byte[] {52, 104, 127, 7, 105, 130, 98, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool canPlaceOn(Tile tile, Team team)
    {
      if (!this.isMultiblock())
        return this.canMine(tile);
      Iterator iterator = tile.getLinkedTilesAs((Block) this, Block.__\u003C\u003EtempTiles).iterator();
      while (iterator.hasNext())
      {
        if (this.canMine((Tile) iterator.next()))
          return true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {159, 113, 67, 138, 109, 132, 135, 107, 127, 40, 127, 38, 111, 127, 0, 101, 152, 104, 112, 127, 10, 133, 98, 127, 4, 112, 100, 186})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid)
    {
      int num1 = valid ? 1 : 0;
      base.drawPlace(x, y, rotation, num1 != 0);
      Tile tile = Vars.world.tile(x, y);
      if (tile == null)
        return;
      this.countOre(tile);
      if (this.returnItem != null)
      {
        float num2 = this.drawPlaceText(Core.bundle.formatFloat("bar.drillspeed", 60f / (this.drillTime + this.hardnessDrillMultiplier * (float) this.returnItem.hardness) * (float) this.returnCount, 2), x, y, num1 != 0);
        float x1 = (float) (x * 8) + this.offset - num2 / 2f - 4f;
        float y1 = (float) (y * 8) + this.offset + (float) (this.size * 8) / 2f + 5f;
        Draw.mixcol(Color.__\u003C\u003EdarkGray, 1f);
        Draw.rect(this.returnItem.icon(Cicon.__\u003C\u003Esmall), x1, y1 - 1f);
        Draw.reset();
        Draw.rect(this.returnItem.icon(Cicon.__\u003C\u003Esmall), x1, y1);
        if (!this.drawMineItem)
          return;
        Draw.color(this.returnItem.color);
        Draw.rect(this.itemRegion, tile.worldx() + this.offset, tile.worldy() + this.offset);
        Draw.color();
      }
      else
      {
        if (((Tile) tile.getLinkedTilesAs((Block) this, Block.__\u003C\u003EtempTiles).find((Boolf) new Drill.__\u003C\u003EAnon1(this)))?.drop() == null)
          return;
        double num2 = (double) this.drawPlaceText(Core.bundle.get("bar.drilltierreq"), x, y, num1 != 0);
      }
    }

    [LineNumberTable(new byte[] {97, 134, 159, 1, 127, 21, 109, 159, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003EdrillTier, (StatValue) new BlockFilterValue((Boolf) new Drill.__\u003C\u003EAnon2(this)));
      this.stats.add(Stat.__\u003C\u003EdrillSpeed, 60f / this.drillTime * (float) this.size * (float) this.size, StatUnit.__\u003C\u003EitemsSecond);
      if ((double) this.liquidBoostIntensity == 1.0)
        return;
      this.stats.add(Stat.__\u003C\u003EboostEffect, this.liquidBoostIntensity * this.liquidBoostIntensity, StatUnit.__\u003C\u003EtimesSpeed);
    }

    [LineNumberTable(159)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[3]
    {
      this.region,
      this.rotatorRegion,
      this.topRegion
    };

    [Modifiers]
    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int access\u0024000([In] Drill obj0) => obj0.__\u003C\u003EtimerDump;

    [HideFromJava]
    static Drill() => Block.__\u003Cclinit\u003E();

    [Modifiers]
    protected internal ObjectIntMap oreCount
    {
      [HideFromJava] get => this.__\u003C\u003EoreCount;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EoreCount = value;
    }

    [Modifiers]
    protected internal Seq itemArray
    {
      [HideFromJava] get => this.__\u003C\u003EitemArray;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EitemArray = value;
    }

    public class DrillBuild : Building
    {
      public float progress;
      public int index;
      public float warmup;
      public float timeDrilled;
      public float lastDrillSpeed;
      public int dominantItems;
      public Item dominantItem;
      [Modifiers]
      internal Drill this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(201)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DrillBuild(Drill _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(213)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldConsume() => this.items.total() < this.this\u00240.itemCapacity && this.enabled;

      [LineNumberTable(218)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldAmbientSound() => (double) this.efficiency() > 0.00999999977648258 && this.items.total() < this.this\u00240.itemCapacity;

      [LineNumberTable(223)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float ambientVolume() => this.efficiency() * (float) (this.this\u00240.size * this.this\u00240.size) / 4f;

      [LineNumberTable(new byte[] {160, 114, 107, 127, 29, 111, 126, 101, 151})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawSelect()
      {
        if (this.dominantItem == null)
          return;
        float x = this.x - (float) (this.this\u00240.size * 8) / 2f;
        float y = this.y + (float) (this.this\u00240.size * 8) / 2f;
        Draw.mixcol(Color.__\u003C\u003EdarkGray, 1f);
        Draw.rect(this.dominantItem.icon(Cicon.__\u003C\u003Esmall), x, y - 1f);
        Draw.reset();
        Draw.rect(this.dominantItem.icon(Cicon.__\u003C\u003Esmall), x, y);
      }

      [LineNumberTable(new byte[] {160, 125, 113, 113, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onProximityUpdate()
      {
        this.this\u00240.countOre(this.tile);
        this.dominantItem = this.this\u00240.returnItem;
        this.dominantItems = this.this\u00240.returnCount;
      }

      [LineNumberTable(new byte[] {160, 132, 104, 161, 120, 173, 157, 159, 19, 134, 109, 172, 139, 127, 33, 126, 159, 10, 123, 127, 51, 98, 107, 127, 3, 161, 159, 8, 127, 17, 140, 110, 143, 159, 46})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (this.dominantItem == null)
          return;
        if (this.timer(Drill.access\u0024000(this.this\u00240), 5f))
          this.dump(this.dominantItem);
        this.timeDrilled += this.warmup * this.delta();
        if (this.items.total() < this.this\u00240.itemCapacity && this.dominantItems > 0 && this.consValid())
        {
          float num1 = 1f;
          if (this.cons.optionalValid())
            num1 = this.this\u00240.liquidBoostIntensity;
          float toValue = num1 * this.efficiency();
          this.lastDrillSpeed = toValue * (float) this.dominantItems * this.warmup / (this.this\u00240.drillTime + this.this\u00240.hardnessDrillMultiplier * (float) this.dominantItem.hardness);
          this.warmup = Mathf.lerpDelta(this.warmup, toValue, this.this\u00240.warmupSpeed);
          this.progress += this.delta() * (float) this.dominantItems * toValue * this.warmup;
          if (Mathf.chanceDelta((double) (this.this\u00240.updateEffectChance * this.warmup)))
            this.this\u00240.updateEffect.at(this.x + Mathf.range((float) this.this\u00240.size * 2f), this.y + Mathf.range((float) this.this\u00240.size * 2f));
          float num2 = this.this\u00240.drillTime + this.this\u00240.hardnessDrillMultiplier * (float) this.dominantItem.hardness;
          if (this.dominantItems <= 0 || (double) this.progress < (double) num2 || this.items.total() >= this.this\u00240.itemCapacity)
            return;
          this.offload(this.dominantItem);
          ++this.index;
          this.progress %= num2;
          this.this\u00240.drillEffect.at(this.x + (float) Mathf.range(this.this\u00240.size), this.y + (float) Mathf.range(this.this\u00240.size), this.dominantItem.color);
        }
        else
        {
          this.lastDrillSpeed = 0.0f;
          this.warmup = Mathf.lerpDelta(this.warmup, 0.0f, this.this\u00240.warmupSpeed);
        }
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawCracks()
      {
      }

      [LineNumberTable(new byte[] {160, 181, 102, 134, 124, 134, 109, 112, 127, 12, 106, 124, 101, 165, 159, 16, 156, 117, 112, 124, 133})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        float mag = 0.3f;
        float num = 0.6f;
        Draw.rect(this.this\u00240.region, this.x, this.y);
        base.drawCracks();
        if (this.this\u00240.drawRim)
        {
          Draw.color(this.this\u00240.heatColor);
          Draw.alpha(this.warmup * num * (1f - mag + Mathf.absin(Time.time, 3f, mag)));
          Draw.blend(Blending.__\u003C\u003Eadditive);
          Draw.rect(this.this\u00240.rimRegion, this.x, this.y);
          Draw.blend();
          Draw.color();
        }
        Draw.rect(this.this\u00240.rotatorRegion, this.x, this.y, this.timeDrilled * this.this\u00240.rotateSpeed);
        Draw.rect(this.this\u00240.topRegion, this.x, this.y);
        if (this.dominantItem == null || !this.this\u00240.drawMineItem)
          return;
        Draw.color(this.dominantItem.color);
        Draw.rect(this.this\u00240.itemRegion, this.x, this.y);
        Draw.color();
      }

      [HideFromJava]
      static DrillBuild() => Building.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Func
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get([In] object obj0) => (object) Drill.lambda\u0024setBars\u00243((Drill.DrillBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Boolf
    {
      private readonly Drill arg\u00241;

      internal __\u003C\u003EAnon1([In] Drill obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024drawPlace\u00244((Tile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Boolf
    {
      private readonly Drill arg\u00241;

      internal __\u003C\u003EAnon2([In] Drill obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024setStats\u00245((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Comparator
    {
      private readonly Drill arg\u00241;

      internal __\u003C\u003EAnon3([In] Drill obj0) => this.arg\u00241 = obj0;

      public int compare([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024countOre\u00246((Item) obj0, (Item) obj1);

      [SpecialName]
      public Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public bool equals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

      [SpecialName]
      public Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Prov
    {
      private readonly Drill.DrillBuild arg\u00241;

      internal __\u003C\u003EAnon4([In] Drill.DrillBuild obj0) => this.arg\u00241 = obj0;

      public object get() => (object) Drill.lambda\u0024setBars\u00240(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Prov
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public object get() => (object) Drill.lambda\u0024setBars\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Floatp
    {
      private readonly Drill.DrillBuild arg\u00241;

      internal __\u003C\u003EAnon6([In] Drill.DrillBuild obj0) => this.arg\u00241 = obj0;

      public float get() => Drill.lambda\u0024setBars\u00242(this.arg\u00241);
    }
  }
}
