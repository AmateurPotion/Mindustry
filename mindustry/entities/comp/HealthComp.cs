// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.HealthComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Entityc", "mindustry.gen.Posc"})]
  internal abstract class HealthComp : Object, Entityc, Posc, Position
  {
    internal const float hitDuration = 9f;
    internal float health;
    [NonSerialized]
    internal float hitTime;
    [NonSerialized]
    internal float maxHealth;
    [NonSerialized]
    internal bool dead;

    [HideFromJava]
    public abstract bool isAdded();

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void killed()
    {
    }

    [HideFromJava]
    public abstract void remove();

    [LineNumberTable(new byte[] {159, 125, 162, 135, 136, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void damage([In] float obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      float hitTime = this.hitTime;
      this.damage(obj0);
      if (num != 0)
        return;
      this.hitTime = hitTime;
    }

    [LineNumberTable(new byte[] {159, 129, 130, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void damagePierce([In] float obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      this.damage(obj0, num != 0);
    }

    [LineNumberTable(new byte[] {159, 177, 137, 107, 103, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void kill()
    {
      if (this.dead)
        return;
      this.health = 0.0f;
      this.dead = true;
      this.killed();
      this.remove();
    }

    [LineNumberTable(new byte[] {13, 112, 107, 117, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void damage([In] float obj0)
    {
      this.health -= obj0;
      this.hitTime = 1f;
      if ((double) this.health > 0.0 || this.dead)
        return;
      this.kill();
    }

    [LineNumberTable(new byte[] {39, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void clampHealth() => this.health = Mathf.clamp(this.health, 0.0f, this.maxHealth);

    [LineNumberTable(new byte[] {44, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void heal([In] float obj0)
    {
      this.health += obj0;
      this.clampHealth();
    }

    [LineNumberTable(new byte[] {159, 151, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal HealthComp()
    {
      HealthComp healthComp = this;
      this.maxHealth = 1f;
    }

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isValid() => !this.dead && this.isAdded();

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual float healthf() => this.health / this.maxHealth;

    [LineNumberTable(new byte[] {159, 169, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update() => this.hitTime -= Time.delta / 9f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void heal()
    {
      this.dead = false;
      this.health = this.maxHealth;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool damaged() => (double) this.health < (double) (this.maxHealth - 1f / 1000f);

    [LineNumberTable(new byte[] {9, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void damagePierce([In] float obj0) => this.damagePierce(obj0, true);

    [LineNumberTable(new byte[] {31, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void damageContinuous([In] float obj0) => this.damage(obj0 * Time.delta, (double) this.hitTime <= -1.0);

    [LineNumberTable(new byte[] {35, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void damageContinuousPierce([In] float obj0) => this.damagePierce(obj0 * Time.delta, (double) this.hitTime <= -11.0);

    [LineNumberTable(new byte[] {50, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void healFract([In] float obj0) => this.heal(obj0 * this.maxHealth);

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
  }
}
