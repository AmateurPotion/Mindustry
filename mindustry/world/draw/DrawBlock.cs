// Decompiled with JetBrains decompiler
// Type: mindustry.world.draw.DrawBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using IKVM.Attributes;
using java.lang;
using mindustry.world.blocks.production;
using System.Runtime.CompilerServices;

namespace mindustry.world.draw
{
  public class DrawBlock : Object
  {
    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DrawBlock()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load(Block block)
    {
    }

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion[] icons(Block block) => new TextureRegion[1]
    {
      block.region
    };

    [LineNumberTable(new byte[] {159, 155, 127, 24})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(GenericCrafter.GenericCrafterBuild entity) => Draw.rect(entity.block.region, entity.x, entity.y, !entity.block.rotate ? 0.0f : entity.rotdeg());
  }
}
