// Decompiled with JetBrains decompiler
// Type: mindustry.entities.bullet.MissileBulletType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;

namespace mindustry.entities.bullet
{
  public class MissileBulletType : BasicBulletType
  {
    [LineNumberTable(new byte[] {159, 151, 109, 107, 107, 107, 107, 107, 107, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MissileBulletType(float speed, float damage, string bulletSprite)
      : base(speed, damage, bulletSprite)
    {
      MissileBulletType missileBulletType = this;
      this.backColor = Pal.missileYellowBack;
      this.frontColor = Pal.missileYellow;
      this.homingPower = 0.08f;
      this.shrinkY = 0.0f;
      this.width = 8f;
      this.height = 8f;
      this.hitSound = Sounds.explosion;
      this.trailChance = 0.2f;
      this.lifetime = 52f;
    }

    [LineNumberTable(new byte[] {159, 164, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MissileBulletType(float speed, float damage)
      : this(speed, damage, "missile")
    {
    }

    [LineNumberTable(new byte[] {159, 168, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MissileBulletType()
      : this(1f, 1f, "missile")
    {
    }
  }
}
