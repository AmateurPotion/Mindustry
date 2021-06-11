// Decompiled with JetBrains decompiler
// Type: mindustry.entities.bullet.ContinuousLaserBulletType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;

namespace mindustry.entities.bullet
{
  public class ContinuousLaserBulletType : BulletType
  {
    public float length;
    public float shake;
    public float fadeTime;
    public float lightStroke;
    public float spaceMag;
    public Color[] colors;
    public float[] tscales;
    public float[] strokes;
    public float[] lenscales;
    public float width;
    public float oscScl;
    public float oscMag;
    public bool largeHit;

    [LineNumberTable(new byte[] {159, 168, 239, 51, 107, 107, 107, 107, 107, 127, 28, 127, 13, 127, 13, 127, 13, 127, 2, 231, 69, 107, 107, 107, 107, 107, 110, 103, 107, 107, 107, 103, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ContinuousLaserBulletType(float damage)
      : base(1f / 1000f, damage)
    {
      ContinuousLaserBulletType continuousLaserBulletType = this;
      this.length = 220f;
      this.shake = 1f;
      this.fadeTime = 16f;
      this.lightStroke = 40f;
      this.spaceMag = 35f;
      this.colors = new Color[4]
      {
        Color.valueOf("ec745855"),
        Color.valueOf("ec7458aa"),
        Color.valueOf("ff9c5a"),
        Color.__\u003C\u003Ewhite
      };
      this.tscales = new float[4]{ 1f, 0.7f, 0.5f, 0.2f };
      this.strokes = new float[4]{ 2f, 1.5f, 1f, 0.3f };
      this.lenscales = new float[4]
      {
        1f,
        1.12f,
        1.15f,
        1.17f
      };
      this.width = 9f;
      this.oscScl = 0.8f;
      this.oscMag = 1.5f;
      this.largeHit = true;
      this.hitEffect = Fx.__\u003C\u003EhitBeam;
      this.despawnEffect = Fx.__\u003C\u003Enone;
      this.hitSize = 4f;
      this.drawSize = 420f;
      this.lifetime = 16f;
      this.hitColor = this.colors[2];
      this.incendAmount = 1;
      this.incendSpread = 5f;
      this.incendChance = 0.4f;
      this.lightColor = Color.__\u003C\u003Eorange;
      this.keepVelocity = false;
      this.collides = false;
      this.pierce = true;
      this.hittable = false;
      this.absorbable = false;
    }

    [LineNumberTable(new byte[] {159, 188, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal ContinuousLaserBulletType()
      : this(0.0f)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float continuousDamage() => this.damage / 5f * 60f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float estimateDPS() => this.damage * 100f / 5f * 3f;

    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float range() => Math.max(this.length, this.maxRange);

    [LineNumberTable(new byte[] {18, 134, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      base.init();
      this.drawSize = Math.max(this.drawSize, this.length * 2f);
    }

    [LineNumberTable(new byte[] {27, 110, 191, 18, 109, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Bullet b)
    {
      if (b.timer(1, 5f))
        Damage.collideLine(b, b.team, this.hitEffect, b.x, b.y, b.rotation(), this.length, this.largeHit);
      if ((double) this.shake <= 0.0)
        return;
      Effect.shake(this.shake, this.shake, (Position) b);
    }

    [LineNumberTable(new byte[] {38, 110, 127, 42, 133, 121, 111, 127, 25, 113, 127, 18, 127, 29, 255, 30, 61, 11, 233, 73, 154, 127, 45, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(Bullet b)
    {
      float laserLength = Damage.findLaserLength(b, this.length);
      float num = Mathf.clamp((double) b.time <= (double) (b.lifetime - this.fadeTime) ? 1f : 1f - (b.time - (this.lifetime - this.fadeTime)) / this.fadeTime);
      float length = laserLength * num;
      Lines.lineAngle(b.x, b.y, b.rotation(), length);
      for (int index1 = 0; index1 < this.colors.Length; ++index1)
      {
        Draw.color(Tmp.__\u003C\u003Ec1.set(this.colors[index1]).mul(1f + Mathf.absin(Time.time, 1f, 0.1f)));
        for (int index2 = 0; index2 < this.tscales.Length; ++index2)
        {
          Tmp.__\u003C\u003Ev1.trns(b.rotation() + 180f, (this.lenscales[index2] - 1f) * this.spaceMag);
          Lines.stroke((this.width + Mathf.absin(Time.time, this.oscScl, this.oscMag)) * num * this.strokes[index1] * this.tscales[index2]);
          Lines.lineAngle(b.x + Tmp.__\u003C\u003Ev1.x, b.y + Tmp.__\u003C\u003Ev1.y, b.rotation(), length * this.lenscales[index2], false);
        }
      }
      Tmp.__\u003C\u003Ev1.trns(b.rotation(), length * 1.1f);
      Drawf.light(b.team, b.x, b.y, b.x + Tmp.__\u003C\u003Ev1.x, b.y + Tmp.__\u003C\u003Ev1.y, this.lightStroke, this.lightColor, 0.7f);
      Draw.reset();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawLight(Bullet b)
    {
    }
  }
}
