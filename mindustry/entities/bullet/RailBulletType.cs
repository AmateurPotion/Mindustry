// Decompiled with JetBrains decompiler
// Type: mindustry.entities.bullet.RailBulletType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.gen;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.bullet
{
  public class RailBulletType : BulletType
  {
    public Effect pierceEffect;
    public Effect updateEffect;
    public float pierceDamageFactor;
    public float length;
    public float updateEffectSeg;

    [LineNumberTable(new byte[] {159, 177, 150, 109, 122, 161, 109, 159, 1, 217, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void handle([In] Bullet obj0, [In] Posc obj1, [In] float obj2)
    {
      float num = Math.max(obj2 * this.pierceDamageFactor, 0.0f);
      if ((double) obj0.damage <= 0.0)
      {
        obj0.fdata = Math.min(obj0.fdata, obj0.dst((Position) obj1));
      }
      else
      {
        if ((double) obj0.damage > 0.0)
        {
          this.pierceEffect.at(obj1.getX(), obj1.getY(), obj0.rotation());
          this.hitEffect.at(obj1.getX(), obj1.getY());
        }
        obj0.damage -= Math.min(obj0.damage, num);
      }
    }

    [LineNumberTable(new byte[] {159, 160, 232, 56, 150, 139, 139, 171, 103, 103, 103, 107, 107, 103, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RailBulletType()
    {
      RailBulletType railBulletType = this;
      this.pierceEffect = Fx.__\u003C\u003EhitBulletSmall;
      this.updateEffect = Fx.__\u003C\u003Enone;
      this.pierceDamageFactor = 1f;
      this.length = 100f;
      this.updateEffectSeg = 20f;
      this.pierceBuilding = true;
      this.pierce = true;
      this.reflectable = false;
      this.hitEffect = Fx.__\u003C\u003Enone;
      this.despawnEffect = Fx.__\u003C\u003Enone;
      this.collides = false;
      this.lifetime = 1f;
      this.speed = 0.01f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float range() => this.length;

    [LineNumberTable(new byte[] {4, 135, 108, 127, 19, 135, 118, 106, 63, 21, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init(Bullet b)
    {
      base.init(b);
      b.fdata = this.length;
      Damage.collideLine(b, b.team, b.type.hitEffect, b.x, b.y, b.rotation(), this.length, false, false);
      float fdata = b.fdata;
      Vec2 vec2 = Tmp.__\u003C\u003Ev1.set(b.vel).nor();
      for (float num = 0.0f; (double) num <= (double) fdata; num += this.updateEffectSeg)
        this.updateEffect.at(b.x + vec2.x * num, b.y + vec2.y * num, b.rotation());
    }

    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool testCollision(Bullet bullet, Building tile) => !object.ReferenceEquals((object) bullet.team, (object) tile.team);

    [LineNumberTable(new byte[] {23, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void hitEntity(Bullet b, Hitboxc entity, float initialHealth) => this.handle(b, (Posc) entity, initialHealth);

    [LineNumberTable(new byte[] {28, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void hitTile(Bullet b, Building build, float initialHealth, bool direct) => this.handle(b, (Posc) build, initialHealth);
  }
}
