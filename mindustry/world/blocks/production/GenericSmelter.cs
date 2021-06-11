// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.production.GenericSmelter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using IKVM.Attributes;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.production
{
  public class GenericSmelter : GenericCrafter
  {
    public Color flameColor;
    public TextureRegion topRegion;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 159, 233, 60, 240, 69, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GenericSmelter(string name)
      : base(name)
    {
      GenericSmelter genericSmelter = this;
      this.flameColor = Color.valueOf("ffc999");
      this.ambientSound = Sounds.smelter;
      this.ambientSoundVolume = 0.07f;
    }

    [HideFromJava]
    static GenericSmelter() => GenericCrafter.__\u003Cclinit\u003E();

    public class SmelterBuild : GenericCrafter.GenericCrafterBuild
    {
      [Modifiers]
      internal GenericSmelter this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(22)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SmelterBuild(GenericSmelter _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((GenericCrafter) _param1);
      }

      [LineNumberTable(new byte[] {159, 167, 166, 127, 11, 102, 102, 140, 159, 21, 112, 127, 17, 122, 124, 159, 17, 133})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        if ((double) this.warmup <= 0.0 || (double) this.this\u00240.flameColor.a <= 1.0 / 1000.0)
          return;
        float mag = 0.3f;
        float range = 0.06f;
        float num = Mathf.random(0.1f);
        Draw.alpha((1f - mag + Mathf.absin(Time.time, 8f, mag) + Mathf.random(range) - range) * this.warmup);
        Draw.tint(this.this\u00240.flameColor);
        Fill.circle(this.x, this.y, 3f + Mathf.absin(Time.time, 5f, 2f) + num);
        Draw.color(1f, 1f, 1f, this.warmup);
        Draw.rect(this.this\u00240.topRegion, this.x, this.y);
        Fill.circle(this.x, this.y, 1.9f + Mathf.absin(Time.time, 5f, 1f) + num);
        Draw.color();
      }

      [LineNumberTable(new byte[] {159, 189, 127, 53})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawLight() => Drawf.light(this.team, this.x, this.y, (60f + Mathf.absin(10f, 5f)) * this.warmup * (float) this.this\u00240.size, this.this\u00240.flameColor, 0.65f);

      [HideFromJava]
      static SmelterBuild() => GenericCrafter.GenericCrafterBuild.__\u003Cclinit\u003E();
    }
  }
}
