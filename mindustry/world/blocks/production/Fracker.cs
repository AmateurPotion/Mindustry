// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.production.Fracker
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using IKVM.Attributes;
using mindustry.gen;
using mindustry.graphics;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.production
{
  public class Fracker : SolidPump
  {
    public float itemUseTime;
    public new TextureRegion liquidRegion;
    public new TextureRegion rotatorRegion;
    public new TextureRegion topRegion;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 159, 233, 57, 235, 72, 103, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Fracker(string name)
      : base(name)
    {
      Fracker fracker = this;
      this.itemUseTime = 100f;
      this.hasItems = true;
      this.ambientSound = Sounds.drill;
      this.ambientSoundVolume = 0.03f;
    }

    [LineNumberTable(new byte[] {159, 167, 134, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003EproductionTime, this.itemUseTime / 60f, StatUnit.__\u003C\u003Eseconds);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => false;

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[3]
    {
      this.region,
      this.rotatorRegion,
      this.topRegion
    };

    [HideFromJava]
    static Fracker() => SolidPump.__\u003Cclinit\u003E();

    public class FrackerBuild : SolidPump.SolidPumpBuild
    {
      public float accumulator;
      [Modifiers]
      internal Fracker this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(40)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FrackerBuild(Fracker _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((SolidPump) _param1);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawCracks()
      {
      }

      [LineNumberTable(new byte[] {159, 190, 124, 134, 159, 49, 127, 3, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.region, this.x, this.y);
        base.drawCracks();
        Drawf.liquid(this.this\u00240.liquidRegion, this.x, this.y, this.liquids.get(this.this\u00240.result) / this.this\u00240.liquidCapacity, this.this\u00240.result.color);
        Draw.rect(this.this\u00240.rotatorRegion, this.x, this.y, this.pumpTime);
        Draw.rect(this.this\u00240.topRegion, this.x, this.y);
      }

      [LineNumberTable(new byte[] {9, 104, 115, 102, 185, 102, 159, 1, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (this.consValid())
        {
          if ((double) this.accumulator >= (double) this.this\u00240.itemUseTime)
          {
            this.consume();
            this.accumulator -= this.this\u00240.itemUseTime;
          }
          base.updateTile();
          this.accumulator += this.delta() * this.efficiency();
        }
        else
          this.dumpLiquid(this.this\u00240.result);
      }

      [LineNumberTable(74)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float typeLiquid() => this.liquids.get(this.this\u00240.result);

      [HideFromJava]
      static FrackerBuild() => SolidPump.SolidPumpBuild.__\u003Cclinit\u003E();
    }
  }
}
