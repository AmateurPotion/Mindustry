// Decompiled with JetBrains decompiler
// Type: mindustry.entities.effect.WaveEffect
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.entities.effect
{
  public class WaveEffect : Effect
  {
    public Color colorFrom;
    public Color colorTo;
    public float sizeFrom;
    public float sizeTo;
    public int sides;
    public float rotation;
    public float strokeFrom;
    public float strokeTo;
    public Interp interp;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 151, 104, 127, 1, 118, 103, 107, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WaveEffect()
    {
      WaveEffect waveEffect = this;
      this.colorFrom = Color.__\u003C\u003Ewhite.cpy();
      this.colorTo = Color.__\u003C\u003Ewhite.cpy();
      this.sizeFrom = 0.0f;
      this.sizeTo = 100f;
      this.sides = -1;
      this.rotation = 0.0f;
      this.strokeFrom = 2f;
      this.strokeTo = 0.0f;
      this.interp = Interp.linear;
    }

    [LineNumberTable(new byte[] {159, 161, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init() => this.clip = Math.max(this.clip, Math.max(this.sizeFrom, this.sizeTo) + Math.max(this.strokeFrom, this.strokeTo));

    [LineNumberTable(new byte[] {159, 166, 104, 142, 114, 158, 122, 127, 24})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void render(Effect.EffectContainer e)
    {
      float a = e.fin();
      Draw.color(this.colorFrom, this.colorTo, e.fin(this.interp));
      Lines.stroke(this.interp.apply(this.strokeFrom, this.strokeTo, a));
      float num = this.interp.apply(this.sizeFrom, this.sizeTo, a);
      Lines.poly(e.x, e.y, this.sides > 0 ? this.sides : Lines.circleVertices(num), num, this.rotation + e.rotation);
    }

    [HideFromJava]
    static WaveEffect() => Effect.__\u003Cclinit\u003E();
  }
}
