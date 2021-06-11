// Decompiled with JetBrains decompiler
// Type: mindustry.world.draw.DrawAnimation
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.world.blocks.production;
using System.Runtime.CompilerServices;

namespace mindustry.world.draw
{
  public class DrawAnimation : DrawBlock
  {
    public int frameCount;
    public float frameSpeed;
    public bool sine;
    public TextureRegion[] frames;
    public TextureRegion liquid;
    public TextureRegion top;

    [LineNumberTable(new byte[] {159, 152, 104, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DrawAnimation()
    {
      DrawAnimation drawAnimation = this;
      this.frameCount = 3;
      this.frameSpeed = 5f;
      this.sine = true;
    }

    [LineNumberTable(new byte[] {159, 161, 156, 104, 127, 15, 255, 16, 61, 229, 69, 127, 20, 119, 101, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(GenericCrafter.GenericCrafterBuild entity)
    {
      Draw.rect(entity.block.region, entity.x, entity.y);
      Draw.rect(!this.sine ? this.frames[ByteCodeHelper.f2i(entity.totalProgress / this.frameSpeed % (float) this.frameCount)] : this.frames[ByteCodeHelper.f2i(Mathf.absin(entity.totalProgress, this.frameSpeed, (float) this.frameCount - 1f / 1000f))], entity.x, entity.y);
      Draw.color(Color.__\u003C\u003Eclear, entity.liquids.current().color, entity.liquids.total() / entity.block.liquidCapacity);
      Draw.rect(this.liquid, entity.x, entity.y);
      Draw.color();
      Draw.rect(this.top, entity.x, entity.y);
    }

    [LineNumberTable(new byte[] {159, 175, 113, 107, 63, 24, 198, 127, 16, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load(Block block)
    {
      this.frames = new TextureRegion[this.frameCount];
      for (int index = 0; index < this.frameCount; ++index)
        this.frames[index] = (TextureRegion) Core.atlas.find(new StringBuilder().append(block.__\u003C\u003Ename).append("-frame").append(index).toString());
      this.liquid = (TextureRegion) Core.atlas.find(new StringBuilder().append(block.__\u003C\u003Ename).append("-liquid").toString());
      this.top = (TextureRegion) Core.atlas.find(new StringBuilder().append(block.__\u003C\u003Ename).append("-top").toString());
    }

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons(Block block) => new TextureRegion[2]
    {
      block.region,
      this.top
    };
  }
}
