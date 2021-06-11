// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.production.Pump
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics;
using arc.graphics.g2d;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using mindustry.world.blocks.liquid;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.production
{
  public class Pump : LiquidBlock
  {
    public float pumpAmount;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool canPump(Tile tile) => tile != null && tile.floor().liquidDrop != null;

    [LineNumberTable(new byte[] {159, 163, 233, 61, 203, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pump(string name)
      : base(name)
    {
      Pump pump = this;
      this.pumpAmount = 0.2f;
      this.group = BlockGroup.__\u003C\u003Eliquids;
      this.floating = true;
    }

    [LineNumberTable(new byte[] {159, 170, 102, 127, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003Eoutput, 60f * this.pumpAmount * (float) this.size * (float) this.size, StatUnit.__\u003C\u003EliquidSecond);
    }

    [LineNumberTable(new byte[] {159, 134, 131, 138, 109, 132, 102, 130, 127, 11, 106, 109, 144, 130, 102, 127, 13, 127, 40, 111, 123, 101, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid)
    {
      int num1 = valid ? 1 : 0;
      base.drawPlace(x, y, rotation, num1 != 0);
      Tile tile1 = Vars.world.tile(x, y);
      if (tile1 == null)
        return;
      float num2 = 0.0f;
      Liquid liquid = (Liquid) null;
      Iterator iterator = tile1.getLinkedTilesAs((Block) this, Block.__\u003C\u003EtempTiles).iterator();
      while (iterator.hasNext())
      {
        Tile tile2 = (Tile) iterator.next();
        if (this.canPump(tile2))
        {
          liquid = tile2.floor().liquidDrop;
          num2 += tile2.floor().liquidMultiplier;
        }
      }
      if (liquid == null)
        return;
      float num3 = this.drawPlaceText(Core.bundle.formatFloat("bar.pumpspeed", num2 * this.pumpAmount * 60f, 0), x, y, num1 != 0);
      float x1 = (float) (x * 8) + this.offset - num3 / 2f - 4f;
      float y1 = (float) (y * 8) + this.offset + (float) (this.size * 8) / 2f + 5f;
      Draw.mixcol(Color.__\u003C\u003EdarkGray, 1f);
      Draw.rect(liquid.icon(Cicon.__\u003C\u003Esmall), x1, y1 - 1f);
      Draw.reset();
      Draw.rect(liquid.icon(Cicon.__\u003C\u003Esmall), x1, y1);
    }

    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[1]
    {
      this.region
    };

    [LineNumberTable(new byte[] {16, 107, 98, 127, 7, 111, 120, 108, 98, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool canPlaceOn(Tile tile, Team team)
    {
      if (!this.isMultiblock())
        return this.canPump(tile);
      Liquid liquid = (Liquid) null;
      Iterator iterator = tile.getLinkedTilesAs((Block) this, Block.__\u003C\u003EtempTiles).iterator();
      while (iterator.hasNext())
      {
        Tile tile1 = (Tile) iterator.next();
        if (tile1.floor().liquidDrop != null)
        {
          if (!object.ReferenceEquals((object) tile1.floor().liquidDrop, (object) liquid) && liquid != null)
            return false;
          liquid = tile1.floor().liquidDrop;
        }
      }
      return liquid != null;
    }

    [HideFromJava]
    static Pump() => LiquidBlock.__\u003Cclinit\u003E();

    public class PumpBuild : LiquidBlock.LiquidBuild
    {
      public float amount;
      public Liquid liquidDrop;
      [Modifiers]
      internal Pump this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {33, 112, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PumpBuild(Pump _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((LiquidBlock) _param1);
        Pump.PumpBuild pumpBuild = this;
        this.amount = 0.0f;
        this.liquidDrop = (Liquid) null;
      }

      [LineNumberTable(new byte[] {39, 156, 127, 38})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.__\u003C\u003Ename, this.x, this.y);
        Drawf.liquid(this.this\u00240.liquidRegion, this.x, this.y, this.liquids.total() / this.this\u00240.liquidCapacity, this.liquids.current().color);
      }

      [LineNumberTable(new byte[] {46, 134, 107, 135, 127, 11, 110, 113, 153, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onProximityUpdate()
      {
        base.onProximityUpdate();
        this.amount = 0.0f;
        this.liquidDrop = (Liquid) null;
        Iterator iterator = this.tile.getLinkedTiles(Building.__\u003C\u003EtempTiles).iterator();
        while (iterator.hasNext())
        {
          Tile tile = (Tile) iterator.next();
          if (this.this\u00240.canPump(tile))
          {
            this.liquidDrop = tile.floor().liquidDrop;
            this.amount += tile.floor().liquidMultiplier;
          }
        }
      }

      [LineNumberTable(111)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldConsume() => this.liquidDrop != null && (double) this.liquids.get(this.liquidDrop) < (double) (this.this\u00240.liquidCapacity - 0.01f) && this.enabled;

      [LineNumberTable(new byte[] {66, 112, 127, 29, 178, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (this.consValid() && this.liquidDrop != null)
          this.liquids.add(this.liquidDrop, Math.min(this.this\u00240.liquidCapacity - this.liquids.total(), this.amount * this.this\u00240.pumpAmount * this.edelta()));
        this.dumpLiquid(this.liquids.current());
      }

      [HideFromJava]
      static PumpBuild() => LiquidBlock.LiquidBuild.__\u003Cclinit\u003E();
    }
  }
}
