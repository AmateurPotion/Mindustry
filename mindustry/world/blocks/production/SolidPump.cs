// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.production.SolidPump
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.entities;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.production
{
  public class SolidPump : Pump
  {
    public Liquid result;
    public Effect updateEffect;
    public float updateEffectChance;
    public float rotateSpeed;
    public float baseEfficiency;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Attribute attribute;
    public TextureRegion rotatorRegion;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(73)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override bool canPump(Tile tile) => tile != null && !tile.floor().isLiquid;

    [Modifiers]
    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static mindustry.ui.Bar lambda\u0024setBars\u00243([In] SolidPump.SolidPumpBuild obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar((Prov) new SolidPump.__\u003C\u003EAnon2(obj0), (Prov) new SolidPump.__\u003C\u003EAnon3(), (Floatp) new SolidPump.__\u003C\u003EAnon4(obj0));
    }

    [Modifiers]
    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024canPlaceOn\u00244([In] Tile obj0) => this.canPump(obj0) ? this.baseEfficiency + (this.attribute == null ? 0.0f : obj0.floor().attributes.get(this.attribute)) : 0.0f;

    [Modifiers]
    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setBars\u00240([In] SolidPump.SolidPumpBuild obj0) => Core.bundle.formatFloat("bar.pumpspeed", obj0.lastPump / Time.delta * 60f, 1);

    [Modifiers]
    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u00241() => Pal.ammo;

    [Modifiers]
    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024setBars\u00242([In] SolidPump.SolidPumpBuild obj0) => obj0.warmup;

    [LineNumberTable(new byte[] {159, 174, 233, 53, 107, 107, 107, 107, 235, 72, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SolidPump(string name)
      : base(name)
    {
      SolidPump solidPump = this;
      this.result = Liquids.water;
      this.updateEffect = Fx.__\u003C\u003Enone;
      this.updateEffectChance = 0.02f;
      this.rotateSpeed = 1f;
      this.baseEfficiency = 1f;
      this.hasPower = true;
    }

    [LineNumberTable(new byte[] {159, 133, 131, 136, 104, 159, 66})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid)
    {
      int num1 = valid ? 1 : 0;
      this.drawPotentialLinks(x, y);
      if (this.attribute == null)
        return;
      double num2 = (double) this.drawPlaceText(Core.bundle.formatFloat("bar.efficiency", Math.max(this.sumAttribute(this.attribute, x, y) / (float) this.size / (float) this.size + this.baseEfficiency, 0.0f) * 100f * this.percentSolid(x, y), 1), x, y, num1 != 0);
    }

    [LineNumberTable(new byte[] {159, 189, 102, 218})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.add("efficiency", (Func) new SolidPump.__\u003C\u003EAnon0());
    }

    [LineNumberTable(new byte[] {6, 134, 112, 127, 5, 104, 159, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.remove(Stat.__\u003C\u003Eoutput);
      this.stats.add(Stat.__\u003C\u003Eoutput, this.result, 60f * this.pumpAmount, true);
      if (this.attribute == null)
        return;
      this.stats.add((double) this.baseEfficiency <= 9.99999974737875E-05 ? Stat.__\u003C\u003Etiles : Stat.__\u003C\u003Eaffinities, this.attribute, this.floating, 1f, (double) this.baseEfficiency <= 1.0 / 1000.0);
    }

    [LineNumberTable(new byte[] {17, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool canPlaceOn(Tile tile, Team team) => (double) tile.getLinkedTilesAs((Block) this, Block.__\u003C\u003EtempTiles).sumf((Floatf) new SolidPump.__\u003C\u003EAnon1(this)) > 9.99999974737875E-06;

    [LineNumberTable(78)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[3]
    {
      this.region,
      this.rotatorRegion,
      this.topRegion
    };

    [HideFromJava]
    static SolidPump() => Pump.__\u003Cclinit\u003E();

    public class SolidPumpBuild : Pump.PumpBuild
    {
      public float warmup;
      public float pumpTime;
      public float boost;
      public float validTiles;
      public float lastPump;
      [Modifiers]
      internal SolidPump this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(136)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float typeLiquid() => this.liquids.total();

      [LineNumberTable(81)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SolidPumpBuild(SolidPump _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((Pump) _param1);
      }

      [LineNumberTable(new byte[] {40, 124, 127, 38, 127, 16, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.region, this.x, this.y);
        Drawf.liquid(this.this\u00240.liquidRegion, this.x, this.y, this.liquids.total() / this.this\u00240.liquidCapacity, this.liquids.current().color);
        Draw.rect(this.this\u00240.rotatorRegion, this.x, this.y, this.pumpTime * this.this\u00240.rotateSpeed);
        Draw.rect(this.this\u00240.topRegion, this.x, this.y);
      }

      [LineNumberTable(98)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldConsume() => (double) this.liquids.get(this.this\u00240.result) < (double) (this.this\u00240.liquidCapacity - 0.01f) && this.enabled;

      [LineNumberTable(new byte[] {53, 159, 34, 127, 15, 127, 28, 119, 103, 124, 124, 127, 53, 98, 124, 171, 157, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        float num = Math.max(this.validTiles + this.boost + (this.this\u00240.attribute != null ? this.this\u00240.attribute.env() : 0.0f), 0.0f);
        if (this.cons.valid() && (double) this.typeLiquid() < (double) (this.this\u00240.liquidCapacity - 1f / 1000f))
        {
          float amount = Math.min(this.this\u00240.liquidCapacity - this.typeLiquid(), this.this\u00240.pumpAmount * this.delta() * num * this.efficiency());
          this.liquids.add(this.this\u00240.result, amount);
          this.lastPump = amount;
          this.warmup = Mathf.lerpDelta(this.warmup, 1f, 0.02f);
          if (Mathf.chance((double) (this.delta() * this.this\u00240.updateEffectChance)))
            this.this\u00240.updateEffect.at(this.getX() + Mathf.range((float) this.this\u00240.size * 2f), this.getY() + Mathf.range((float) this.this\u00240.size * 2f));
        }
        else
        {
          this.warmup = Mathf.lerpDelta(this.warmup, 0.0f, 0.02f);
          this.lastPump = 0.0f;
        }
        this.pumpTime += this.warmup * this.delta();
        this.dumpLiquid(this.this\u00240.result);
      }

      [LineNumberTable(new byte[] {74, 134, 127, 48, 107, 127, 11, 110, 159, 20, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onProximityUpdate()
      {
        this.onProximityAdded();
        this.boost = this.this\u00240.sumAttribute(this.this\u00240.attribute, (int) this.tile.x, (int) this.tile.y) / (float) this.this\u00240.size / (float) this.this\u00240.size;
        this.validTiles = 0.0f;
        Iterator iterator = this.tile.getLinkedTiles(Building.__\u003C\u003EtempTiles).iterator();
        while (iterator.hasNext())
        {
          if (this.this\u00240.canPump((Tile) iterator.next()))
            this.validTiles += this.this\u00240.baseEfficiency / (float) (this.this\u00240.size * this.this\u00240.size);
        }
      }

      [HideFromJava]
      static SolidPumpBuild() => Pump.PumpBuild.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Func
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get([In] object obj0) => (object) SolidPump.lambda\u0024setBars\u00243((SolidPump.SolidPumpBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Floatf
    {
      private readonly SolidPump arg\u00241;

      internal __\u003C\u003EAnon1([In] SolidPump obj0) => this.arg\u00241 = obj0;

      public float get([In] object obj0) => this.arg\u00241.lambda\u0024canPlaceOn\u00244((Tile) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Prov
    {
      private readonly SolidPump.SolidPumpBuild arg\u00241;

      internal __\u003C\u003EAnon2([In] SolidPump.SolidPumpBuild obj0) => this.arg\u00241 = obj0;

      public object get() => (object) SolidPump.lambda\u0024setBars\u00240(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Prov
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public object get() => (object) SolidPump.lambda\u0024setBars\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Floatp
    {
      private readonly SolidPump.SolidPumpBuild arg\u00241;

      internal __\u003C\u003EAnon4([In] SolidPump.SolidPumpBuild obj0) => this.arg\u00241 = obj0;

      public float get() => SolidPump.lambda\u0024setBars\u00242(this.arg\u00241);
    }
  }
}
