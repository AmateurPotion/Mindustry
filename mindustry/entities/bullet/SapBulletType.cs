// Decompiled with JetBrains decompiler
// Type: mindustry.entities.bullet.SapBulletType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics;
using arc.graphics.g2d;
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
  public class SapBulletType : BulletType
  {
    public float length;
    public float sapStrength;
    public Color color;
    public float width;

    [LineNumberTable(new byte[] {159, 161, 232, 59, 107, 107, 112, 171, 107, 107, 103, 103, 107, 103, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SapBulletType()
    {
      SapBulletType sapBulletType = this;
      this.length = 100f;
      this.sapStrength = 0.5f;
      this.color = Color.__\u003C\u003Ewhite.cpy();
      this.width = 0.4f;
      this.speed = 0.0001f;
      this.despawnEffect = Fx.__\u003C\u003Enone;
      this.pierce = true;
      this.collides = false;
      this.hitSize = 0.0f;
      this.hittable = false;
      this.hitEffect = Fx.__\u003C\u003EhitLiquid;
      this.status = StatusEffects.sapped;
      this.statusDuration = 180f;
    }

    [LineNumberTable(new byte[] {159, 175, 127, 11, 153, 107, 127, 44, 40, 165, 133, 159, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(Bullet b)
    {
      object data = b.data;
      Position v;
      if (!(data is Position) || !object.ReferenceEquals((object) (v = (Position) data), (object) (Position) data))
        return;
      Tmp.__\u003C\u003Ev1.set(v).lerp((Position) b, b.fin());
      Draw.color(this.color);
      Drawf.laser(b.team, (TextureRegion) Core.atlas.find("laser"), (TextureRegion) Core.atlas.find("laser-end"), b.x, b.y, Tmp.__\u003C\u003Ev1.x, Tmp.__\u003C\u003Ev1.y, this.width * b.fout());
      Draw.reset();
      Drawf.light(b.team, b.x, b.y, Tmp.__\u003C\u003Ev1.x, Tmp.__\u003C\u003Ev1.y, 15f * b.fout(), this.lightColor, 0.6f);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawLight(Bullet b)
    {
    }

    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float range() => Math.max(this.length, this.maxRange);

    [LineNumberTable(new byte[] {8, 135, 127, 1, 135, 99, 159, 0, 127, 5, 207, 127, 5, 120, 125, 127, 5, 106, 105, 183, 159, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init(Bullet b)
    {
      base.init(b);
      Healthc healthc1 = Damage.linecast(b, b.x, b.y, b.rotation(), this.length);
      b.data = (object) healthc1;
      if (healthc1 != null)
      {
        float num = Math.max(Math.min(healthc1.health(), this.damage), 0.0f);
        Entityc owner = b.owner;
        Healthc healthc2;
        if (owner is Healthc && object.ReferenceEquals((object) (healthc2 = (Healthc) owner), (object) (Healthc) owner))
          healthc2.heal(num * this.sapStrength);
      }
      Healthc healthc3 = healthc1;
      Hitboxc other;
      if (healthc3 is Hitboxc && object.ReferenceEquals((object) (other = (Hitboxc) healthc3), (object) (Hitboxc) healthc3))
      {
        other.collision((Hitboxc) b, other.x(), other.y());
        b.collision(other, other.x(), other.y());
      }
      else
      {
        Healthc healthc2 = healthc1;
        Building building;
        if (healthc2 is Building && object.ReferenceEquals((object) (building = (Building) healthc2), (object) (Building) healthc2))
        {
          if (!building.collide(b))
            return;
          building.collision(b);
          this.hit(b, building.x, building.y);
        }
        else
          b.data = (object) new Vec2().trns(b.rotation(), this.length).add(b.x, b.y);
      }
    }
  }
}
