// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.environment.DoubleOverlayFloor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using arc.math;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.environment
{
  public class DoubleOverlayFloor : OverlayFloor
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 152, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DoubleOverlayFloor(string name)
      : base(name)
    {
    }

    [LineNumberTable(new byte[] {159, 157, 106, 127, 30, 101, 127, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawBase(Tile tile)
    {
      Draw.colorl(0.4f);
      Draw.rect(this.variantRegions[Mathf.randomSeed((long) tile.pos(), 0, Math.max(0, this.variantRegions.Length - 1))], tile.worldx(), tile.worldy() - 0.75f);
      Draw.color();
      Draw.rect(this.variantRegions[Mathf.randomSeed((long) tile.pos(), 0, Math.max(0, this.variantRegions.Length - 1))], tile.worldx(), tile.worldy());
    }

    [HideFromJava]
    static DoubleOverlayFloor() => OverlayFloor.__\u003Cclinit\u003E();
  }
}
