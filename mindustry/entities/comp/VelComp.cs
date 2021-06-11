// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.VelComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
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
  [Implements(new string[] {"mindustry.gen.Posc"})]
  internal abstract class VelComp : Object, Posc, Position, Entityc
  {
    internal float x;
    internal float y;
    [Modifiers]
    [NonSerialized]
    internal Vec2 vel;
    [NonSerialized]
    internal float drag;

    [LineNumberTable(new byte[] {159, 191, 135, 99, 156, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void move([In] float obj0, [In] float obj1)
    {
      EntityCollisions.SolidPred solidCheck = this.solidity();
      if (solidCheck != null)
      {
        Vars.collisions.move((Hitboxc) this.self(), obj0, obj1, solidCheck);
      }
      else
      {
        this.x += obj0;
        this.y += obj1;
      }
    }

    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual EntityCollisions.SolidPred solidity() => (EntityCollisions.SolidPred) null;

    [HideFromJava]
    public abstract int tileX();

    [HideFromJava]
    public abstract int tileY();

    [LineNumberTable(new byte[] {159, 177, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool canPass([In] int obj0, [In] int obj1)
    {
      EntityCollisions.SolidPred solidPred = this.solidity();
      return solidPred == null || !solidPred.solid(obj0, obj1);
    }

    [HideFromJava]
    public abstract Entityc self();

    [LineNumberTable(new byte[] {159, 154, 200, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal VelComp()
    {
      VelComp velComp = this;
      this.vel = new Vec2();
      this.drag = 0.0f;
    }

    [LineNumberTable(new byte[] {159, 165, 127, 11, 127, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      this.move(this.vel.x * Time.delta, this.vel.y * Time.delta);
      this.vel.scl(Math.max(1f - this.drag * Time.delta, 0.0f));
    }

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool canPassOn() => this.canPass(this.tileX(), this.tileY());

    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool moving() => !this.vel.isZero(0.01f);

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
