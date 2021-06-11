// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.ShieldComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.gen;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Healthc", "mindustry.gen.Posc"})]
  internal abstract class ShieldComp : Object, Healthc, Posc, Position, Entityc
  {
    internal float health;
    internal float hitTime;
    internal float x;
    internal float y;
    internal float healthMultiplier;
    internal bool dead;
    internal float shield;
    internal float armor;
    [NonSerialized]
    internal float shieldAlpha;

    [LineNumberTable(new byte[] {159, 187, 142, 99, 171, 122, 111, 107, 135, 105, 112, 117, 166, 112, 188})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void rawDamage([In] float obj0)
    {
      int num1 = (double) this.shield > 9.99999974737875E-05 ? 1 : 0;
      if (num1 != 0)
        this.shieldAlpha = 1f;
      float num2 = Math.min(Math.max(this.shield, 0.0f), obj0);
      this.shield -= num2;
      this.hitTime = 1f;
      obj0 -= num2;
      if ((double) obj0 <= 0.0)
        return;
      this.health -= obj0;
      if ((double) this.health <= 0.0 && !this.dead)
        this.kill();
      if (num1 == 0 || (double) this.shield > 9.99999974737875E-05)
        return;
      Fx.__\u003C\u003EunitShieldBreak.at(this.x, this.y, 0.0f, (object) this);
    }

    [HideFromJava]
    public abstract void kill();

    [LineNumberTable(new byte[] {159, 153, 232, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal ShieldComp()
    {
      ShieldComp shieldComp = this;
      this.shieldAlpha = 0.0f;
    }

    [LineNumberTable(new byte[] {159, 168, 123, 140, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void damage([In] float obj0)
    {
      obj0 = Math.max(obj0 - this.armor, 0.1f * obj0);
      obj0 /= this.healthMultiplier;
      this.rawDamage(obj0);
    }

    [LineNumberTable(new byte[] {159, 134, 162, 135, 136, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void damagePierce([In] float obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      float hitTime = this.hitTime;
      this.rawDamage(obj0);
      if (num != 0)
        return;
      this.hitTime = hitTime;
    }

    [LineNumberTable(new byte[] {20, 122, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      this.shieldAlpha -= Time.delta / 15f;
      if ((double) this.shieldAlpha >= 0.0)
        return;
      this.shieldAlpha = 0.0f;
    }

    [HideFromJava]
    public abstract float getX();

    [HideFromJava]
    public abstract float getY();

    [HideFromJava]
    public virtual float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

    [HideFromJava]
    public virtual float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

    [HideFromJava]
    public virtual float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

    [HideFromJava]
    public virtual float dst([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float dst2([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst2((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

    [HideFromJava]
    public abstract bool isAdded();

    [HideFromJava]
    public abstract void remove();

    [HideFromJava]
    public abstract void add();

    [HideFromJava]
    public abstract bool isLocal();

    [HideFromJava]
    public abstract bool isRemote();

    [HideFromJava]
    public abstract bool isNull();

    [HideFromJava]
    public abstract Entityc self();

    [HideFromJava]
    public abstract object @as();

    [HideFromJava]
    public abstract object with([In] Cons obj0);

    [HideFromJava]
    public abstract int classId();

    [HideFromJava]
    public abstract bool serialize();

    [HideFromJava]
    public abstract void read([In] Reads obj0);

    [HideFromJava]
    public abstract void write([In] Writes obj0);

    [HideFromJava]
    public abstract void afterRead();

    [HideFromJava]
    public abstract int id();

    [HideFromJava]
    public abstract void id([In] int obj0);

    [HideFromJava]
    public abstract void set([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void set([In] Position obj0);

    [HideFromJava]
    public abstract void trns([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void trns([In] Position obj0);

    [HideFromJava]
    public abstract int tileX();

    [HideFromJava]
    public abstract int tileY();

    [HideFromJava]
    public abstract Floor floorOn();

    [HideFromJava]
    public abstract Block blockOn();

    [HideFromJava]
    public abstract bool onSolid();

    [HideFromJava]
    public abstract Tile tileOn();

    [HideFromJava]
    public abstract float x();

    [HideFromJava]
    public abstract void x([In] float obj0);

    [HideFromJava]
    public abstract float y();

    [HideFromJava]
    public abstract void y([In] float obj0);

    [HideFromJava]
    public abstract bool isValid();

    [HideFromJava]
    public abstract float healthf();

    [HideFromJava]
    public abstract void killed();

    [HideFromJava]
    public abstract void heal();

    [HideFromJava]
    public abstract bool damaged();

    [HideFromJava]
    public abstract void damagePierce([In] float obj0);

    [HideFromJava]
    public abstract void damage([In] float obj0, [In] bool obj1);

    [HideFromJava]
    public abstract void damageContinuous([In] float obj0);

    [HideFromJava]
    public abstract void damageContinuousPierce([In] float obj0);

    [HideFromJava]
    public abstract void clampHealth();

    [HideFromJava]
    public abstract void heal([In] float obj0);

    [HideFromJava]
    public abstract void healFract([In] float obj0);

    [HideFromJava]
    public abstract float health();

    [HideFromJava]
    public abstract void health([In] float obj0);

    [HideFromJava]
    public abstract float hitTime();

    [HideFromJava]
    public abstract void hitTime([In] float obj0);

    [HideFromJava]
    public abstract float maxHealth();

    [HideFromJava]
    public abstract void maxHealth([In] float obj0);

    [HideFromJava]
    public abstract bool dead();

    [HideFromJava]
    public abstract void dead([In] bool obj0);
  }
}
