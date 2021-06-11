// Decompiled with JetBrains decompiler
// Type: mindustry.world.draw.DrawGlow
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics.g2d;
using arc.math;
using IKVM.Attributes;
using java.lang;
using mindustry.world.blocks.production;
using System.Runtime.CompilerServices;

namespace mindustry.world.draw
{
  public class DrawGlow : DrawBlock
  {
    public float glowAmount;
    public float glowScale;
    public TextureRegion top;

    [LineNumberTable(new byte[] {159, 151, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DrawGlow()
    {
      DrawGlow drawGlow = this;
      this.glowAmount = 0.9f;
      this.glowScale = 3f;
    }

    [LineNumberTable(new byte[] {159, 157, 124, 127, 6, 119, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(GenericCrafter.GenericCrafterBuild entity)
    {
      Draw.rect(entity.block.region, entity.x, entity.y);
      Draw.alpha(Mathf.absin(entity.totalProgress, this.glowScale, this.glowAmount) * entity.warmup);
      Draw.rect(this.top, entity.x, entity.y);
      Draw.reset();
    }

    [LineNumberTable(new byte[] {159, 165, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load(Block block) => this.top = (TextureRegion) Core.atlas.find(new StringBuilder().append(block.__\u003C\u003Ename).append("-top").toString());
  }
}
