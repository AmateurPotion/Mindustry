// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.liquid.LiquidJunction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using IKVM.Attributes;
using mindustry.gen;
using mindustry.type;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.liquid
{
  public class LiquidJunction : LiquidBlock
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 153, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LiquidJunction(string name)
      : base(name)
    {
    }

    [LineNumberTable(new byte[] {159, 158, 102, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.remove(Stat.__\u003C\u003EliquidCapacity);
    }

    [LineNumberTable(new byte[] {159, 164, 102, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.remove("liquid");
    }

    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[1]
    {
      this.region
    };

    [HideFromJava]
    static LiquidJunction() => LiquidBlock.__\u003Cclinit\u003E();

    public class LiquidJunctionBuild : Building
    {
      [Modifiers]
      internal LiquidJunction this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(31)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LiquidJunctionBuild(LiquidJunction _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 176, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw() => Draw.rect(this.this\u00240.region, this.x, this.y);

      [LineNumberTable(new byte[] {159, 181, 138, 126, 111, 104, 122, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Building getLiquidDestination(Building source, Liquid liquid)
      {
        if (!this.enabled)
          return (Building) this;
        int num1 = (int) (sbyte) source.relativeTo((int) this.tile.x, (int) this.tile.y) + 4;
        int num2 = 4;
        Building building = this.nearby(num2 != -1 ? num1 % num2 : 0);
        return building == null || !building.acceptLiquid((Building) this, liquid) && !(building.block is LiquidJunction) ? (Building) this : building.getLiquidDestination((Building) this, liquid);
      }

      [HideFromJava]
      static LiquidJunctionBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
