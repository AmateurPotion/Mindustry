﻿// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.liquid.LiquidExtendingBridge
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using IKVM.Attributes;
using mindustry.gen;
using mindustry.type;
using mindustry.world.blocks.distribution;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.liquid
{
  public class LiquidExtendingBridge : ExtendingItemBridge
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 105, 103, 103, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LiquidExtendingBridge(string name)
      : base(name)
    {
      LiquidExtendingBridge liquidExtendingBridge = this;
      this.hasItems = false;
      this.hasLiquids = true;
      this.outputsLiquid = true;
      this.group = BlockGroup.__\u003C\u003Eliquids;
    }

    [HideFromJava]
    static LiquidExtendingBridge() => ExtendingItemBridge.__\u003Cclinit\u003E();

    public class LiquidExtendingBridgeBuild : ExtendingItemBridge.ExtendingItemBridgeBuild
    {
      [Modifiers]
      internal LiquidExtendingBridge this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(21)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LiquidExtendingBridgeBuild(LiquidExtendingBridge _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((ExtendingItemBridge) _param1);
      }

      [LineNumberTable(new byte[] {159, 166, 125, 159, 5, 134, 113, 124, 155, 156, 104, 158, 188, 109, 122, 158, 220})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        this.time += this.cycleSpeed * this.delta();
        this.time2 += (this.cycleSpeed - 1f) * this.delta();
        this.checkIncoming();
        Building next = Vars.world.build(this.link);
        if (next == null || !this.this\u00240.linkValid(this.tile, next.tile()))
        {
          this.dumpLiquid(this.liquids.current(), 1f);
        }
        else
        {
          ((ItemBridge.ItemBridgeBuild) next).incoming.add(this.tile.pos());
          if (this.consValid())
            this.uptime = Mathf.lerpDelta(this.uptime, 1f, 0.04f);
          else
            this.uptime = Mathf.lerpDelta(this.uptime, 0.0f, 0.02f);
          if ((double) this.uptime < 0.5)
            return;
          if ((double) this.moveLiquid(next, this.liquids.current()) > 0.100000001490116)
            this.cycleSpeed = Mathf.lerpDelta(this.cycleSpeed, 4f, 0.05f);
          else
            this.cycleSpeed = Mathf.lerpDelta(this.cycleSpeed, 0.0f, 0.01f);
        }
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => false;

      [HideFromJava]
      static LiquidExtendingBridgeBuild() => ExtendingItemBridge.ExtendingItemBridgeBuild.__\u003Cclinit\u003E();
    }
  }
}
