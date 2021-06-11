// Decompiled with JetBrains decompiler
// Type: mindustry.world.draw.DrawMixer
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
  public class DrawMixer : DrawBlock
  {
    public TextureRegion liquid;
    public TextureRegion top;
    public TextureRegion bottom;

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DrawMixer()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 156, 152, 115, 127, 0, 127, 20, 120, 165, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(GenericCrafter.GenericCrafterBuild entity)
    {
      float rotation = !entity.block.rotate ? 0.0f : entity.rotdeg();
      Draw.rect(this.bottom, entity.x, entity.y, rotation);
      if ((double) entity.liquids.total() > 1.0 / 1000.0)
      {
        Draw.color(((GenericCrafter) entity.block).outputLiquid.liquid.color);
        Draw.alpha(entity.liquids.get(((GenericCrafter) entity.block).outputLiquid.liquid) / entity.block.liquidCapacity);
        Draw.rect(this.liquid, entity.x, entity.y, rotation);
        Draw.color();
      }
      Draw.rect(this.top, entity.x, entity.y, rotation);
    }

    [LineNumberTable(new byte[] {159, 172, 127, 16, 127, 16, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load(Block block)
    {
      this.liquid = (TextureRegion) Core.atlas.find(new StringBuilder().append(block.__\u003C\u003Ename).append("-liquid").toString());
      this.top = (TextureRegion) Core.atlas.find(new StringBuilder().append(block.__\u003C\u003Ename).append("-top").toString());
      this.bottom = (TextureRegion) Core.atlas.find(new StringBuilder().append(block.__\u003C\u003Ename).append("-bottom").toString());
    }

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons(Block block) => new TextureRegion[2]
    {
      this.bottom,
      this.top
    };
  }
}
