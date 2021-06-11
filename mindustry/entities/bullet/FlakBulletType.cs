// Decompiled with JetBrains decompiler
// Type: mindustry.entities.bullet.FlakBulletType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
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
  public class FlakBulletType : BasicBulletType
  {
    public float explodeRange;

    [LineNumberTable(new byte[] {159, 154, 241, 61, 203, 107, 107, 107, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FlakBulletType(float speed, float damage)
      : base(speed, damage, "shell")
    {
      FlakBulletType flakBulletType = this;
      this.explodeRange = 30f;
      this.splashDamage = 15f;
      this.splashDamageRadius = 34f;
      this.hitEffect = Fx.__\u003C\u003EflakExplosionBig;
      this.width = 8f;
      this.height = 10f;
      this.collidesGround = false;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 174, 159, 3, 112, 108, 245, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u00241([In] Bullet obj0, [In] Unit obj1)
    {
      if (obj0.data() is Float || !obj1.checkTarget(this.collidesAir, this.collidesGround) || (double) obj1.dst((Position) obj0) >= (double) this.explodeRange)
        return;
      obj0.data((object) Integer.valueOf(0));
      Time.run(5f, (Runnable) new FlakBulletType.__\u003C\u003EAnon1(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 179, 109, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024update\u00240([In] Bullet obj0)
    {
      if (!(obj0.data() is Integer))
        return;
      obj0.time(obj0.lifetime());
    }

    [LineNumberTable(new byte[] {159, 164, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FlakBulletType()
      : this(1f, 1f)
    {
    }

    [LineNumberTable(new byte[] {159, 169, 103, 142, 110, 255, 32, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Bullet b)
    {
      base.update(b);
      if (b.data() is Integer || !b.timer(2, 6f))
        return;
      Units.nearbyEnemies(b.team, Tmp.__\u003C\u003Er1.setSize(this.explodeRange * 2f).setCenter(b.x, b.y), (Cons) new FlakBulletType.__\u003C\u003EAnon0(this, b));
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly FlakBulletType arg\u00241;
      private readonly Bullet arg\u00242;

      internal __\u003C\u003EAnon0([In] FlakBulletType obj0, [In] Bullet obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024update\u00241(this.arg\u00242, (Unit) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly Bullet arg\u00241;

      internal __\u003C\u003EAnon1([In] Bullet obj0) => this.arg\u00241 = obj0;

      public void run() => FlakBulletType.lambda\u0024update\u00240(this.arg\u00241);
    }
  }
}
