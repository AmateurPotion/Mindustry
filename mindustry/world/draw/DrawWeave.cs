// Decompiled with JetBrains decompiler
// Type: mindustry.world.draw.DrawWeave
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics.g2d;
using arc.math;
using IKVM.Attributes;
using java.lang;
using mindustry.graphics;
using mindustry.world.blocks.production;
using System.Runtime.CompilerServices;

namespace mindustry.world.draw
{
  public class DrawWeave : DrawBlock
  {
    public TextureRegion weave;
    public TextureRegion bottom;

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DrawWeave()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 119, 157, 106, 139, 127, 5, 63, 9, 229, 70, 133, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(GenericCrafter.GenericCrafterBuild entity)
    {
      Draw.rect(this.bottom, entity.x, entity.y);
      Draw.rect(this.weave, entity.x, entity.y, entity.totalProgress);
      Draw.color(Pal.accent);
      Draw.alpha(entity.warmup);
      Lines.lineAngleCenter(entity.x + Mathf.sin(entity.totalProgress, 6f, 2.666667f * (float) entity.block.size), entity.y, 90f, (float) (entity.block.size * 8) / 2f);
      Draw.reset();
      Draw.rect(entity.block.region, entity.x, entity.y);
    }

    [LineNumberTable(new byte[] {159, 177, 127, 16, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load(Block block)
    {
      this.weave = (TextureRegion) Core.atlas.find(new StringBuilder().append(block.__\u003C\u003Ename).append("-weave").toString());
      this.bottom = (TextureRegion) Core.atlas.find(new StringBuilder().append(block.__\u003C\u003Ename).append("-bottom").toString());
    }

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons(Block block) => new TextureRegion[3]
    {
      this.bottom,
      block.region,
      this.weave
    };
  }
}
