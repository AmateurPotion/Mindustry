// Decompiled with JetBrains decompiler
// Type: mindustry.world.draw.DrawRotator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics.g2d;
using IKVM.Attributes;
using java.lang;
using mindustry.world.blocks.production;
using System.Runtime.CompilerServices;

namespace mindustry.world.draw
{
  public class DrawRotator : DrawBlock
  {
    public TextureRegion rotator;

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DrawRotator()
    {
    }

    [LineNumberTable(new byte[] {159, 155, 124, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(GenericCrafter.GenericCrafterBuild entity)
    {
      Draw.rect(entity.block.region, entity.x, entity.y);
      Draw.rect(this.rotator, entity.x, entity.y, entity.totalProgress * 2f);
    }

    [LineNumberTable(new byte[] {159, 161, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load(Block block) => this.rotator = (TextureRegion) Core.atlas.find(new StringBuilder().append(block.__\u003C\u003Ename).append("-rotator").toString());

    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons(Block block) => new TextureRegion[2]
    {
      block.region,
      this.rotator
    };
  }
}
