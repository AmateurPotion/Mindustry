// Decompiled with JetBrains decompiler
// Type: mindustry.entities.bullet.ShrapnelBulletType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;

namespace mindustry.entities.bullet
{
  public class ShrapnelBulletType : BulletType
  {
    public float length;
    public float width;
    public Color fromColor;
    public Color toColor;
    public bool hitLarge;
    public int serrations;
    public float serrationLenScl;
    public float serrationWidth;
    public float serrationSpacing;
    public float serrationSpaceOffset;
    public float serrationFadeOffset;

    [LineNumberTable(new byte[] {159, 163, 232, 56, 107, 107, 118, 135, 103, 191, 24, 107, 107, 118, 107, 107, 103, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ShrapnelBulletType()
    {
      ShrapnelBulletType shrapnelBulletType1 = this;
      this.length = 100f;
      this.width = 20f;
      this.fromColor = Color.__\u003C\u003Ewhite;
      this.toColor = Pal.lancerLaser;
      this.hitLarge = false;
      this.serrations = 7;
      this.serrationLenScl = 10f;
      this.serrationWidth = 4f;
      this.serrationSpacing = 8f;
      this.serrationSpaceOffset = 80f;
      this.serrationFadeOffset = 0.5f;
      this.speed = 0.01f;
      this.hitEffect = Fx.__\u003C\u003EhitLancer;
      ShrapnelBulletType shrapnelBulletType2 = this;
      Effect lightningShoot = Fx.__\u003C\u003ElightningShoot;
      Effect effect = lightningShoot;
      this.smokeEffect = lightningShoot;
      this.shootEffect = effect;
      this.lifetime = 10f;
      this.despawnEffect = Fx.__\u003C\u003Enone;
      this.keepVelocity = false;
      this.collides = false;
      this.pierce = true;
      this.hittable = false;
      this.absorbable = false;
    }

    [LineNumberTable(new byte[] {159, 178, 135, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init(Bullet b)
    {
      base.init(b);
      double num = (double) Damage.collideLaser(b, this.length, this.hitLarge);
    }

    [LineNumberTable(new byte[] {159, 185, 134, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      base.init();
      this.drawSize = Math.max(this.drawSize, this.length * 2f);
    }

    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float range() => Math.max(this.length, this.maxRange);

    [LineNumberTable(new byte[] {5, 135, 120, 127, 0, 124, 127, 11, 127, 31, 255, 31, 60, 233, 70, 127, 16, 127, 20, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(Bullet b)
    {
      float fdata = b.fdata;
      Draw.color(this.fromColor, this.toColor, b.fin());
      for (int index = 0; index < ByteCodeHelper.f2i((float) this.serrations * fdata / this.length); ++index)
      {
        Tmp.__\u003C\u003Ev1.trns(b.rotation(), (float) index * this.serrationSpacing);
        float length = Mathf.clamp(b.fout() - this.serrationFadeOffset) * (this.serrationSpaceOffset - (float) index * this.serrationLenScl);
        Drawf.tri(b.x + Tmp.__\u003C\u003Ev1.x, b.y + Tmp.__\u003C\u003Ev1.y, this.serrationWidth, length, b.rotation() + 90f);
        Drawf.tri(b.x + Tmp.__\u003C\u003Ev1.x, b.y + Tmp.__\u003C\u003Ev1.y, this.serrationWidth, length, b.rotation() - 90f);
      }
      Drawf.tri(b.x, b.y, this.width * b.fout(), fdata + 50f, b.rotation());
      Drawf.tri(b.x, b.y, this.width * b.fout(), 10f, b.rotation() + 180f);
      Draw.reset();
    }
  }
}
