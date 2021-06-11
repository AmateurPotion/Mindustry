// Decompiled with JetBrains decompiler
// Type: mindustry.entities.bullet.LaserBoltBulletType
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
  public class LaserBoltBulletType : BasicBulletType
  {
    public new float width;
    public new float height;

    [LineNumberTable(new byte[] {159, 153, 236, 61, 246, 69, 107, 107, 107, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LaserBoltBulletType(float speed, float damage)
      : base(speed, damage)
    {
      LaserBoltBulletType laserBoltBulletType = this;
      this.width = 2f;
      this.height = 7f;
      this.smokeEffect = Fx.__\u003C\u003EhitLaser;
      this.hitEffect = Fx.__\u003C\u003EhitLaser;
      this.despawnEffect = Fx.__\u003C\u003EhitLaser;
      this.hittable = false;
      this.reflectable = false;
    }

    [LineNumberTable(new byte[] {159, 163, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LaserBoltBulletType()
      : this(1f, 1f)
    {
    }

    [LineNumberTable(new byte[] {159, 168, 107, 107, 126, 107, 127, 6, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(Bullet b)
    {
      Draw.color(this.backColor);
      Lines.stroke(this.width);
      Lines.lineAngleCenter(b.x, b.y, b.rotation(), this.height);
      Draw.color(this.frontColor);
      Lines.lineAngleCenter(b.x, b.y, b.rotation(), this.height / 2f);
      Draw.reset();
    }
  }
}
