// Decompiled with JetBrains decompiler
// Type: mindustry.entities.effect.ParticleEffect
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.effect
{
  public class ParticleEffect : Effect
  {
    public Color colorFrom;
    public Color colorTo;
    public int particles;
    public float cone;
    public float length;
    public float baseLength;
    public Interp interp;
    public float sizeFrom;
    public float sizeTo;
    public float offset;
    public string region;
    public bool line;
    public float strokeFrom;
    public float strokeTo;
    public float lenFrom;
    public float lenTo;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private TextureRegion tex;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 190, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024render\u00240(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3)
    {
      Lines.lineAngle(obj0.x + obj2, obj0.y + obj3, Mathf.angle(obj2, obj3), obj1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {2, 127, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024render\u00241(
      [In] Effect.EffectContainer obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3)
    {
      Draw.rect(this.tex, obj0.x + obj2, obj0.y + obj3, obj1, obj1, obj0.rotation + this.offset);
    }

    [LineNumberTable(new byte[] {159, 153, 104, 127, 1, 103, 127, 2, 171, 118, 107, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ParticleEffect()
    {
      ParticleEffect particleEffect = this;
      this.colorFrom = Color.__\u003C\u003Ewhite.cpy();
      this.colorTo = Color.__\u003C\u003Ewhite.cpy();
      this.particles = 6;
      this.cone = 180f;
      this.length = 20f;
      this.baseLength = 0.0f;
      this.interp = Interp.linear;
      this.sizeFrom = 2f;
      this.sizeTo = 0.0f;
      this.offset = 0.0f;
      this.region = "circle";
      this.strokeFrom = 2f;
      this.strokeTo = 0.0f;
      this.lenFrom = 4f;
      this.lenTo = 2f;
    }

    [LineNumberTable(new byte[] {159, 172, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init() => this.clip = Math.max(this.clip, this.length + Math.max(this.sizeFrom, this.sizeTo));

    [LineNumberTable(new byte[] {159, 177, 158, 104, 110, 159, 2, 146, 107, 126, 154, 191, 28, 98, 223, 29})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void render(Effect.EffectContainer e)
    {
      if (this.tex == null)
        this.tex = (TextureRegion) Core.atlas.find(this.region);
      float a = e.fin();
      float s = e.fin(this.interp);
      float num1 = this.interp.apply(this.sizeFrom, this.sizeTo, a) * 2f;
      Draw.color(this.colorFrom, this.colorTo, s);
      if (this.line)
      {
        Lines.stroke(this.interp.apply(this.strokeFrom, this.strokeTo, a));
        float num2 = this.interp.apply(this.lenFrom, this.lenTo, a);
        Angles.randLenVectors((long) e.id, this.particles, this.length * s + this.baseLength, e.rotation, this.cone, (Floatc2) new ParticleEffect.__\u003C\u003EAnon0(e, num2));
      }
      else
        Angles.randLenVectors((long) e.id, this.particles, this.length * s + this.baseLength, e.rotation, this.cone, (Floatc2) new ParticleEffect.__\u003C\u003EAnon1(this, e, num1));
    }

    [HideFromJava]
    static ParticleEffect() => Effect.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Floatc2
    {
      private readonly Effect.EffectContainer arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon0([In] Effect.EffectContainer obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] float obj0, [In] float obj1) => ParticleEffect.lambda\u0024render\u00240(this.arg\u00241, this.arg\u00242, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatc2
    {
      private readonly ParticleEffect arg\u00241;
      private readonly Effect.EffectContainer arg\u00242;
      private readonly float arg\u00243;

      internal __\u003C\u003EAnon1([In] ParticleEffect obj0, [In] Effect.EffectContainer obj1, [In] float obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] float obj0, [In] float obj1) => this.arg\u00241.lambda\u0024render\u00241(this.arg\u00242, this.arg\u00243, obj0, obj1);
    }
  }
}
