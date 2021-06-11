// Decompiled with JetBrains decompiler
// Type: mindustry.entities.bullet.MassDriverBolt
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.gen;
using mindustry.graphics;
using mindustry.world.blocks.distribution;
using System.Runtime.CompilerServices;

namespace mindustry.entities.bullet
{
  public class MassDriverBolt : BulletType
  {
    [LineNumberTable(new byte[] {159, 158, 114, 103, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MassDriverBolt()
      : base(1f, 50f)
    {
      MassDriverBolt massDriverBolt = this;
      this.collidesTiles = false;
      this.lifetime = 1f;
      this.despawnEffect = Fx.__\u003C\u003Esmeltsmoke;
      this.hitEffect = Fx.__\u003C\u003EhitBulletBig;
    }

    [LineNumberTable(new byte[] {32, 135, 159, 6, 108, 111, 100, 118, 255, 9, 60, 233, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void despawned(Bullet b)
    {
      base.despawned(b);
      object obj = b.data();
      MassDriver.DriverBulletData driverBulletData;
      if (!(obj is MassDriver.DriverBulletData) || !object.ReferenceEquals((object) (driverBulletData = (MassDriver.DriverBulletData) obj), (object) (MassDriver.DriverBulletData) obj))
        return;
      for (int id = 0; id < driverBulletData.items.Length; ++id)
      {
        if (Mathf.random(0, driverBulletData.items[id]) > 0)
        {
          float rotation = b.rotation() + Mathf.range(100f);
          Fx.__\u003C\u003EdropItem.at(b.x, b.y, rotation, Color.__\u003C\u003Ewhite, (object) Vars.content.item(id));
        }
      }
    }

    [LineNumberTable(new byte[] {159, 167, 140, 106, 159, 7, 106, 159, 7, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(Bullet b)
    {
      float w = 11f;
      float h = 13f;
      Draw.color(Pal.bulletYellowBack);
      Draw.rect("shell-back", b.x, b.y, w, h, b.rotation() + 90f);
      Draw.color(Pal.bulletYellow);
      Draw.rect("shell", b.x, b.y, w, h, b.rotation() + 90f);
      Draw.reset();
    }

    [LineNumberTable(new byte[] {159, 181, 127, 5, 103, 161, 166, 109, 161, 115, 111, 143, 163, 104, 111, 180, 112, 131, 255, 19, 69, 123, 163, 100, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Bullet b)
    {
      object obj = b.data();
      MassDriver.DriverBulletData data;
      if (!(obj is MassDriver.DriverBulletData) || !object.ReferenceEquals((object) (data = (MassDriver.DriverBulletData) obj), (object) (MassDriver.DriverBulletData) obj))
      {
        this.hit(b);
      }
      else
      {
        float len = 7f;
        if (data.to.dead())
          return;
        float num1 = data.from.dst((Position) data.to);
        float num2 = b.dst((Position) data.from);
        float num3 = b.dst((Position) data.to);
        int num4 = 0;
        if ((double) num2 > (double) num1)
        {
          float a = b.angleTo((Position) data.to);
          float num5 = data.to.angleTo((Position) data.from);
          if (Angles.near(a, num5, 2f))
          {
            num4 = 1;
            b.set(data.to.x + Angles.trnsx(num5, len), data.to.y + Angles.trnsy(num5, len));
          }
        }
        if ((double) Math.abs(num2 + num3 - num1) < 4.0 && (double) num3 <= (double) len)
          num4 = 1;
        if (num4 == 0)
          return;
        data.to.handlePayload(b, data);
      }
    }

    [LineNumberTable(new byte[] {47, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void hit(Bullet b, float hitx, float hity)
    {
      base.hit(b, hitx, hity);
      this.despawned(b);
    }
  }
}
