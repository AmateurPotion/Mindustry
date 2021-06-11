// Decompiled with JetBrains decompiler
// Type: mindustry.entities.bullet.PointBulletType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using mindustry.gen;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.bullet
{
  public class PointBulletType : BulletType
  {
    private static float cdist;
    private static Unit result;
    public float trailSpacing;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 174, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024init\u00240([In] float obj0, [In] float obj1, [In] float obj2) => this.trailEffect.at(obj1, obj2, obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {159, 187, 137, 107, 145, 116, 111, 102, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024init\u00241([In] float obj0, [In] float obj1, [In] Unit obj2)
    {
      if (obj2.dead())
        return;
      obj2.hitbox(Tmp.__\u003C\u003Er1);
      if (!Tmp.__\u003C\u003Er1.contains(obj0, obj1))
        return;
      float num = obj2.dst(obj0, obj1) - obj2.hitSize;
      if (PointBulletType.result != null && (double) num >= (double) PointBulletType.cdist)
        return;
      PointBulletType.result = obj2;
      PointBulletType.cdist = num;
    }

    [LineNumberTable(new byte[] {159, 157, 8, 171, 103, 107, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PointBulletType()
    {
      PointBulletType pointBulletType = this;
      this.trailSpacing = 10f;
      this.scaleVelocity = true;
      this.lifetime = 100f;
      this.collides = false;
      this.keepVelocity = false;
      this.backMove = false;
    }

    [LineNumberTable(new byte[] {159, 167, 135, 124, 124, 136, 223, 13, 108, 200, 106, 102, 134, 255, 16, 77, 103, 143, 110, 120, 201, 134, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init(Bullet b)
    {
      base.init(b);
      float num1 = b.x + b.lifetime * b.vel.x;
      float num2 = b.y + b.lifetime * b.vel.y;
      float num3 = b.rotation();
      double num4 = (double) Geometry.iterateLine(0.0f, b.x, b.y, num1, num2, this.trailSpacing, (Floatc2) new PointBulletType.__\u003C\u003EAnon0(this, num3));
      b.time = b.lifetime;
      b.set(num1, num2);
      PointBulletType.cdist = 0.0f;
      PointBulletType.result = (Unit) null;
      float num5 = 1f;
      Units.nearbyEnemies(b.team, num1 - num5, num2 - num5, num5 * 2f, num5 * 2f, (Cons) new PointBulletType.__\u003C\u003EAnon1(num1, num2));
      if (PointBulletType.result != null)
      {
        b.collision((Hitboxc) PointBulletType.result, num1, num2);
      }
      else
      {
        Building building = Vars.world.buildWorld(num1, num2);
        if (building != null && !object.ReferenceEquals((object) building.team, (object) b.team))
          building.collision(b);
      }
      b.remove();
      b.vel.setZero();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static PointBulletType()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.bullet.PointBulletType"))
        return;
      PointBulletType.cdist = 0.0f;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Floatc2
    {
      private readonly PointBulletType arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon0([In] PointBulletType obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] float obj0, [In] float obj1) => this.arg\u00241.lambda\u0024init\u00240(this.arg\u00242, obj0, obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly float arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon1([In] float obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => PointBulletType.lambda\u0024init\u00241(this.arg\u00241, this.arg\u00242, (Unit) obj0);
    }
  }
}
