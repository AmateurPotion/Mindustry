// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.production.Incinerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using IKVM.Attributes;
using mindustry.content;
using mindustry.entities;
using mindustry.gen;
using mindustry.type;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.production
{
  public class Incinerator : Block
  {
    public Effect effect;
    public Color flameColor;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 160, 233, 60, 107, 208, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Incinerator(string name)
      : base(name)
    {
      Incinerator incinerator = this;
      this.effect = Fx.__\u003C\u003Efuelburn;
      this.flameColor = Color.valueOf("ffad9d");
      this.hasPower = true;
      this.hasLiquids = true;
      this.update = true;
      this.solid = true;
    }

    [HideFromJava]
    static Incinerator() => Block.__\u003Cclinit\u003E();

    public class IncineratorBuild : Building
    {
      public float heat;
      [Modifiers]
      internal Incinerator this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(25)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public IncineratorBuild(Incinerator _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 172, 118, 158, 156})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (this.consValid() && (double) this.efficiency() > 0.899999976158142)
          this.heat = Mathf.lerpDelta(this.heat, 1f, 0.04f);
        else
          this.heat = Mathf.lerpDelta(this.heat, 0.0f, 0.02f);
      }

      [LineNumberTable(new byte[] {159, 181, 134, 112, 102, 134, 159, 21, 112, 118, 122, 150, 133})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        if ((double) this.heat <= 0.0)
          return;
        float mag = 0.3f;
        float range = 0.06f;
        Draw.alpha((1f - mag + Mathf.absin(Time.time, 8f, mag) + Mathf.random(range) - range) * this.heat);
        Draw.tint(this.this\u00240.flameColor);
        Fill.circle(this.x, this.y, 2f);
        Draw.color(1f, 1f, 1f, this.heat);
        Fill.circle(this.x, this.y, 1f);
        Draw.color();
      }

      [LineNumberTable(new byte[] {8, 112, 156})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleItem(Building source, Item item)
      {
        if (!Mathf.chance(0.3))
          return;
        this.this\u00240.effect.at(this.x, this.y);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => (double) this.heat > 0.5;

      [LineNumberTable(new byte[] {20, 112, 156})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleLiquid(Building source, Liquid liquid, float amount)
      {
        if (!Mathf.chance(0.02))
          return;
        this.this\u00240.effect.at(this.x, this.y);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptLiquid(Building source, Liquid liquid) => (double) this.heat > 0.5;

      [HideFromJava]
      static IncineratorBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
