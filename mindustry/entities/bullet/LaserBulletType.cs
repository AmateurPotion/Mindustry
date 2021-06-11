// Decompiled with JetBrains decompiler
// Type: mindustry.entities.bullet.LaserBulletType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.bullet
{
  public class LaserBulletType : BulletType
  {
    public Color[] colors;
    public Effect laserEffect;
    public float length;
    public float width;
    public float lengthFalloff;
    public float sideLength;
    public float sideWidth;
    public float sideAngle;
    public float lightningSpacing;
    public float lightningDelay;
    public float lightningAngleRand;
    public bool largeHit;

    [LineNumberTable(new byte[] {159, 166, 239, 53, 127, 35, 107, 107, 107, 107, 118, 107, 118, 231, 69, 107, 110, 107, 107, 107, 107, 107, 103, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LaserBulletType(float damage)
      : base(0.01f, damage)
    {
      LaserBulletType laserBulletType = this;
      this.colors = new Color[3]
      {
        Pal.lancerLaser.cpy().mul(1f, 1f, 1f, 0.4f),
        Pal.lancerLaser,
        Color.__\u003C\u003Ewhite
      };
      this.laserEffect = Fx.__\u003C\u003ElancerLaserShootSmoke;
      this.length = 160f;
      this.width = 15f;
      this.lengthFalloff = 0.5f;
      this.sideLength = 29f;
      this.sideWidth = 0.7f;
      this.sideAngle = 90f;
      this.lightningSpacing = -1f;
      this.lightningDelay = 0.1f;
      this.largeHit = false;
      this.hitEffect = Fx.__\u003C\u003EhitLaserBlast;
      this.hitColor = this.colors[2];
      this.despawnEffect = Fx.__\u003C\u003Enone;
      this.shootEffect = Fx.__\u003C\u003EhitLancer;
      this.smokeEffect = Fx.__\u003C\u003Enone;
      this.hitSize = 4f;
      this.lifetime = 16f;
      this.keepVelocity = false;
      this.collides = false;
      this.pierce = true;
      this.hittable = false;
      this.absorbable = false;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {28, 118, 103, 127, 17, 116, 230, 61, 229, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024init\u00240(
      [In] Bullet obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] int obj4)
    {
      if (!obj0.isAdded() || !object.ReferenceEquals((object) obj0.type, (object) this))
        return;
      Lightning.create(obj0, this.lightningColor, (double) this.lightningDamage >= 0.0 ? this.lightningDamage : this.damage, obj1, obj2, obj3 + (float) (90 * obj4) + Mathf.range(this.lightningAngleRand), this.lightningLength + Mathf.random(this.lightningLengthRand));
    }

    [LineNumberTable(new byte[] {159, 183, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LaserBulletType()
      : this(1f)
    {
    }

    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float estimateDPS() => base.estimateDPS() * 3f;

    [LineNumberTable(new byte[] {2, 134, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      base.init();
      this.drawSize = Math.max(this.drawSize, this.length * 2f);
    }

    [LineNumberTable(59)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float range() => Math.max(this.length, this.maxRange);

    [LineNumberTable(new byte[] {14, 156, 159, 6, 112, 98, 109, 114, 146, 135, 124, 63, 4, 232, 58, 239, 82})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init(Bullet b)
    {
      float num1 = Damage.collideLaser(b, this.length, this.largeHit);
      float num2 = b.rotation();
      this.laserEffect.at(b.x, b.y, num2, (object) Float.valueOf(num1 * 0.75f));
      if ((double) this.lightningSpacing <= 0.0)
        return;
      int num3 = 0;
      for (float len = 0.0f; (double) len <= (double) num1; len += this.lightningSpacing)
      {
        float num4 = b.x + Angles.trnsx(num2, len);
        float num5 = b.y + Angles.trnsy(num2, len);
        int num6 = num3;
        ++num3;
        int num7 = num6;
        int[] signs = Mathf.__\u003C\u003Esigns;
        int length = signs.Length;
        for (int index = 0; index < length; ++index)
        {
          int num8 = signs[index];
          Time.run((float) num7 * this.lightningDelay, (Runnable) new LaserBulletType.__\u003C\u003EAnon0(this, b, num4, num5, num2, num8));
        }
      }
    }

    [LineNumberTable(new byte[] {42, 135, 120, 101, 103, 135, 121, 127, 1, 103, 121, 122, 115, 159, 53, 127, 3, 124, 63, 34, 200, 236, 52, 235, 78, 133, 122, 127, 63})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(Bullet b)
    {
      float num1 = b.fdata * Mathf.curve(b.fin(), 0.0f, 0.2f);
      float width = this.width;
      float num2 = 1f;
      Lines.lineAngle(b.x, b.y, b.rotation(), num1);
      Color[] colors = this.colors;
      int length1 = colors.Length;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        Draw.color(colors[index1]);
        Lines.stroke((width *= this.lengthFalloff) * b.fout());
        Lines.lineAngle(b.x, b.y, b.rotation(), num1, false);
        Tmp.__\u003C\u003Ev1.trns(b.rotation(), num1);
        Drawf.tri(b.x + Tmp.__\u003C\u003Ev1.x, b.y + Tmp.__\u003C\u003Ev1.y, Lines.getStroke() * 1.22f, width * 2f + this.width / 2f, b.rotation());
        Fill.circle(b.x, b.y, 1f * width * b.fout());
        int[] signs = Mathf.__\u003C\u003Esigns;
        int length2 = signs.Length;
        for (int index2 = 0; index2 < length2; ++index2)
        {
          int num3 = signs[index2];
          Drawf.tri(b.x, b.y, this.sideWidth * b.fout() * width, this.sideLength * num2, b.rotation() + this.sideAngle * (float) num3);
        }
        num2 *= this.lengthFalloff;
      }
      Draw.reset();
      Tmp.__\u003C\u003Ev1.trns(b.rotation(), num1 * 1.1f);
      Drawf.light(b.team, b.x, b.y, b.x + Tmp.__\u003C\u003Ev1.x, b.y + Tmp.__\u003C\u003Ev1.y, this.width * 1.4f * b.fout(), this.colors[0], 0.6f);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawLight(Bullet b)
    {
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly LaserBulletType arg\u00241;
      private readonly Bullet arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;
      private readonly int arg\u00246;

      internal __\u003C\u003EAnon0(
        [In] LaserBulletType obj0,
        [In] Bullet obj1,
        [In] float obj2,
        [In] float obj3,
        [In] float obj4,
        [In] int obj5)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
      }

      public void run() => this.arg\u00241.lambda\u0024init\u00240(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246);
    }
  }
}
