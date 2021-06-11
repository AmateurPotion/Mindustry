// Decompiled with JetBrains decompiler
// Type: mindustry.entities.bullet.LightningBulletType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.math;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;

namespace mindustry.entities.bullet
{
  public class LightningBulletType : BulletType
  {
    public new Color lightningColor;
    public new int lightningLength;
    public new int lightningLengthRand;

    [LineNumberTable(new byte[] {159, 157, 242, 60, 107, 239, 69, 107, 107, 107, 103, 135, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LightningBulletType()
      : base(0.0001f, 1f)
    {
      LightningBulletType lightningBulletType = this;
      this.lightningColor = Pal.lancerLaser;
      this.lightningLength = 25;
      this.lightningLengthRand = 0;
      this.lifetime = 1f;
      this.despawnEffect = Fx.__\u003C\u003Enone;
      this.hitEffect = Fx.__\u003C\u003EhitLancer;
      this.keepVelocity = false;
      this.hittable = false;
      this.status = StatusEffects.shocked;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float range() => ((float) this.lightningLength + (float) this.lightningLengthRand / 2f) * 6f;

    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float estimateDPS() => base.estimateDPS() * Math.max((float) this.lightningLength / 10f, 1f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(Bullet b)
    {
    }

    [LineNumberTable(new byte[] {159, 184, 127, 24})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init(Bullet b) => Lightning.create(b, this.lightningColor, this.damage, b.x, b.y, b.rotation(), this.lightningLength + Mathf.random(this.lightningLengthRand));
  }
}
