// Decompiled with JetBrains decompiler
// Type: mindustry.entities.bullet.BombBulletType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.gen;
using System.Runtime.CompilerServices;

namespace mindustry.entities.bullet
{
  public class BombBulletType : BasicBulletType
  {
    [LineNumberTable(new byte[] {159, 150, 115, 104, 104, 103, 103, 107, 107, 107, 103, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BombBulletType(float damage, float radius, string sprite)
      : base(0.7f, 0.0f, sprite)
    {
      BombBulletType bombBulletType = this;
      this.splashDamageRadius = radius;
      this.splashDamage = damage;
      this.collidesTiles = false;
      this.collides = false;
      this.shrinkY = 0.7f;
      this.lifetime = 30f;
      this.drag = 0.05f;
      this.keepVelocity = false;
      this.collidesAir = false;
      this.hitSound = Sounds.explosion;
    }

    [LineNumberTable(new byte[] {159, 164, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BombBulletType(float damage, float radius)
      : this(damage, radius, "shell")
    {
    }

    [LineNumberTable(new byte[] {159, 168, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BombBulletType()
      : this(1f, 1f, "shell")
    {
    }
  }
}
