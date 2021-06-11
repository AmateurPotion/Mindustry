// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.environment.StaticTree
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using arc.util;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.environment
{
  public class StaticTree : StaticWall
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StaticTree(string name)
      : base(name)
    {
    }

    [LineNumberTable(new byte[] {159, 159, 102, 108, 113, 102, 134, 107, 159, 5, 100, 110, 114, 101, 110, 111, 101, 110, 143, 110, 237, 50, 235, 82, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawBase(Tile tile)
    {
      TextureRegion tr1 = Tmp.__\u003C\u003Etr1;
      tr1.set(this.region);
      int num1 = (this.region.width - 32) / 2;
      float num2 = 0.0f;
      float num3 = 0.0f;
      for (int rotation = 0; rotation < 4; ++rotation)
      {
        if (tile.nearby(rotation) != null && tile.nearby(rotation).block() is StaticWall)
        {
          switch (rotation)
          {
            case 0:
              tr1.setWidth(tr1.width - num1);
              num2 -= (float) num1 / 2f;
              continue;
            case 1:
              tr1.setY(tr1.getY() + num1);
              num3 -= (float) num1 / 2f;
              continue;
            case 2:
              tr1.setX(tr1.getX() + num1);
              num2 += (float) num1 / 2f;
              continue;
            default:
              tr1.setHeight(tr1.height - num1);
              num3 += (float) num1 / 2f;
              continue;
          }
        }
      }
      Draw.rect(tr1, tile.drawx() + num2 * Draw.scl, tile.drawy() + num3 * Draw.scl);
    }

    [HideFromJava]
    static StaticTree() => StaticWall.__\u003Cclinit\u003E();
  }
}
