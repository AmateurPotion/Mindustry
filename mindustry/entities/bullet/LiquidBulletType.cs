// Decompiled with JetBrains decompiler
// Type: mindustry.entities.bullet.LiquidBulletType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using mindustry.content;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using System.Runtime.CompilerServices;

namespace mindustry.entities.bullet
{
  public class LiquidBulletType : BulletType
  {
    public Liquid liquid;
    public float puddleSize;
    public float orbSize;

    [LineNumberTable(new byte[] {159, 163, 242, 60, 107, 235, 69, 99, 103, 108, 108, 177, 107, 107, 107, 107, 107, 107, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LiquidBulletType([Nullable(new object[] {64, "Larc/util/Nullable;"})] Liquid liquid)
      : base(3.5f, 0.0f)
    {
      LiquidBulletType liquidBulletType = this;
      this.puddleSize = 6f;
      this.orbSize = 3f;
      if (liquid != null)
      {
        this.liquid = liquid;
        this.status = liquid.effect;
        this.lightColor = liquid.lightColor;
        this.lightOpacity = liquid.lightColor.a;
      }
      this.ammoMultiplier = 1f;
      this.lifetime = 34f;
      this.statusDuration = 120f;
      this.despawnEffect = Fx.__\u003C\u003Enone;
      this.hitEffect = Fx.__\u003C\u003EhitLiquid;
      this.smokeEffect = Fx.__\u003C\u003Enone;
      this.shootEffect = Fx.__\u003C\u003Enone;
      this.drag = 1f / 1000f;
      this.knockback = 0.55f;
    }

    [LineNumberTable(new byte[] {159, 184, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LiquidBulletType()
      : this((Liquid) null)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float range() => this.speed * this.lifetime / 2f;

    [LineNumberTable(new byte[] {2, 135, 109, 119, 118, 107, 102, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Bullet b)
    {
      base.update(b);
      if (!this.liquid.canExtinguish())
        return;
      Tile tile = Vars.world.tileWorld(b.x, b.y);
      if (tile == null || !Fires.has((int) tile.x, (int) tile.y))
        return;
      Fires.extinguish(tile, 100f);
      b.remove();
      this.hit(b);
    }

    [LineNumberTable(new byte[] {16, 159, 4, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(Bullet b)
    {
      Draw.color(this.liquid.color, Color.__\u003C\u003Ewhite, b.fout() / 100f);
      Fill.circle(b.x, b.y, this.orbSize);
    }

    [LineNumberTable(new byte[] {23, 167, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void despawned(Bullet b)
    {
      base.despawned(b);
      this.hitEffect.at(b.x, b.y, b.rotation(), this.liquid.color);
    }

    [LineNumberTable(new byte[] {31, 122, 159, 0, 127, 11, 117, 116, 116, 63, 13, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void hit(Bullet b, float hitx, float hity)
    {
      this.hitEffect.at(hitx, hity, this.liquid.color);
      Puddles.deposit(Vars.world.tileWorld(hitx, hity), this.liquid, this.puddleSize);
      if ((double) this.liquid.temperature > 0.5 || (double) this.liquid.flammability >= 0.300000011920929)
        return;
      float intensity = 400f * this.puddleSize / 6f;
      Fires.extinguish(Vars.world.tileWorld(hitx, hity), intensity);
      Point2[] d4 = Geometry.__\u003C\u003Ed4;
      int length = d4.Length;
      for (int index = 0; index < length; ++index)
      {
        Point2 point2 = d4[index];
        Fires.extinguish(Vars.world.tileWorld(hitx + (float) (point2.x * 8), hity + (float) (point2.y * 8)), intensity);
      }
    }
  }
}
