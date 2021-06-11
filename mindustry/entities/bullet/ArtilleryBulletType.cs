// Decompiled with JetBrains decompiler
// Type: mindustry.entities.bullet.ArtilleryBulletType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using IKVM.Attributes;
using mindustry.content;
using mindustry.gen;
using System.Runtime.CompilerServices;

namespace mindustry.entities.bullet
{
  public class ArtilleryBulletType : BasicBulletType
  {
    public float trailMult;
    public float trailSize;

    [LineNumberTable(new byte[] {159, 154, 237, 61, 214, 103, 103, 103, 103, 107, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArtilleryBulletType(float speed, float damage, string bulletSprite)
      : base(speed, damage, bulletSprite)
    {
      ArtilleryBulletType artilleryBulletType = this;
      this.trailMult = 1f;
      this.trailSize = 4f;
      this.collidesTiles = false;
      this.collides = false;
      this.collidesAir = false;
      this.scaleVelocity = true;
      this.hitShake = 1f;
      this.hitSound = Sounds.explosion;
      this.shootEffect = Fx.__\u003C\u003EshootBig;
      this.trailEffect = Fx.__\u003C\u003EartilleryTrail;
    }

    [LineNumberTable(new byte[] {159, 166, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArtilleryBulletType(float speed, float damage)
      : this(speed, damage, "shell")
    {
    }

    [LineNumberTable(new byte[] {159, 170, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArtilleryBulletType()
      : this(1f, 1f, "shell")
    {
    }

    [LineNumberTable(new byte[] {159, 175, 135, 127, 7, 159, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Bullet b)
    {
      base.update(b);
      if (!b.timer(0, (3f + b.fslope() * 2f) * this.trailMult))
        return;
      this.trailEffect.at(b.x, b.y, b.fslope() * this.trailSize, this.backColor);
    }

    [LineNumberTable(new byte[] {159, 184, 102, 149, 159, 8, 107, 127, 19, 107, 127, 19, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(Bullet b)
    {
      float num1 = 0.7f;
      float num2 = num1 + b.fslope() * (1f - num1);
      float num3 = this.height * (1f - this.shrinkY + this.shrinkY * b.fout());
      Draw.color(this.backColor);
      Draw.rect(this.backRegion, b.x, b.y, this.width * num2, num3 * num2, b.rotation() - 90f);
      Draw.color(this.frontColor);
      Draw.rect(this.frontRegion, b.x, b.y, this.width * num2, num3 * num2, b.rotation() - 90f);
      Draw.color();
    }
  }
}
