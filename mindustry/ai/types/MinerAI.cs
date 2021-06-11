// Decompiled with JetBrains decompiler
// Type: mindustry.ai.types.MinerAI
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math.geom;
using IKVM.Attributes;
using mindustry.content;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ai.types
{
  public class MinerAI : AIController
  {
    internal bool mining;
    internal Item targetItem;
    internal Tile ore;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024updateMovement\u00240([In] Item obj0) => Vars.indexer.hasOre(obj0) && this.unit.canMine(obj0);

    [Modifiers]
    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024updateMovement\u00241([In] Building obj0, [In] Item obj1) => (float) obj0.items.get(obj1);

    [LineNumberTable(new byte[] {159, 153, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MinerAI()
    {
      MinerAI minerAi = this;
      this.mining = true;
    }

    [LineNumberTable(new byte[] {159, 160, 140, 145, 127, 22, 172, 107, 123, 223, 28, 125, 107, 108, 193, 127, 30, 140, 123, 188, 107, 159, 9, 127, 4, 177, 122, 236, 69, 140, 114, 103, 161, 127, 2, 127, 16, 191, 35, 107, 167, 158})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void updateMovement()
    {
      Building build = this.unit.closestCore();
      if (!this.unit.canMine() || build == null)
        return;
      if (this.unit.mineTile != null && !this.unit.mineTile.within((Position) this.unit, this.unit.type.range))
        this.unit.mineTile((Tile) null);
      if (this.mining)
      {
        if (this.timer.get(1, 240f) || this.targetItem == null)
          this.targetItem = (Item) this.unit.team.data().mineItems.min((Boolf) new MinerAI.__\u003C\u003EAnon0(this), (Floatf) new MinerAI.__\u003C\u003EAnon1(build));
        if (this.targetItem != null && build.acceptStack(this.targetItem, 1, (Teamc) this.unit) == 0)
        {
          this.unit.clearItem();
          this.unit.mineTile((Tile) null);
        }
        else if (this.unit.stack.amount >= this.unit.type.itemCapacity || this.targetItem != null && !this.unit.acceptsItem(this.targetItem))
        {
          this.mining = false;
        }
        else
        {
          if (this.timer.get(0, 60f) && this.targetItem != null)
            this.ore = Vars.indexer.findClosestOre(this.unit, this.targetItem);
          if (this.ore == null)
            return;
          this.moveTo((Position) this.ore, this.unit.type.range / 2f, 20f);
          if (this.unit.within((Position) this.ore, this.unit.type.range))
            this.unit.mineTile = this.ore;
          if (object.ReferenceEquals((object) this.ore.block(), (object) Blocks.air))
            return;
          this.mining = false;
        }
      }
      else
      {
        this.unit.mineTile = (Tile) null;
        if (this.unit.stack.amount == 0)
        {
          this.mining = true;
        }
        else
        {
          if (this.unit.within((Position) build, this.unit.type.range))
          {
            if (build.acceptStack(this.unit.stack.item, this.unit.stack.amount, (Teamc) this.unit) > 0)
              Call.transferItemTo(this.unit, this.unit.stack.item, this.unit.stack.amount, this.unit.x, this.unit.y, build);
            this.unit.clearItem();
            this.mining = true;
          }
          this.circle((Position) build, this.unit.type.range / 1.8f);
        }
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void updateTargeting()
    {
    }

    [HideFromJava]
    static MinerAI() => AIController.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly MinerAI arg\u00241;

      internal __\u003C\u003EAnon0([In] MinerAI obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024updateMovement\u00240((Item) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Floatf
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon1([In] Building obj0) => this.arg\u00241 = obj0;

      public float get([In] object obj0) => MinerAI.lambda\u0024updateMovement\u00241(this.arg\u00241, (Item) obj0);
    }
  }
}
