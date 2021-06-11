// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.HitboxComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math;
using arc.math.geom;
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
  [Implements(new string[] {"mindustry.gen.Posc", "mindustry.entities.comp.Sized", "arc.math.geom.QuadTree$QuadTreeObject"})]
  internal abstract class HitboxComp : 
    Object,
    Posc,
    Position,
    Entityc,
    Sized,
    QuadTree.QuadTreeObject
  {
    internal float x;
    internal float y;
    [NonSerialized]
    internal float lastX;
    [NonSerialized]
    internal float lastY;
    [NonSerialized]
    internal float deltaX;
    [NonSerialized]
    internal float deltaY;
    [NonSerialized]
    internal float hitSize;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void updateLastPosition()
    {
      this.deltaX = this.x - this.lastX;
      this.deltaY = this.y - this.lastY;
      this.lastX = this.x;
      this.lastY = this.y;
    }

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal HitboxComp()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
    }

    [LineNumberTable(new byte[] {159, 165, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add() => this.updateLastPosition();

    [LineNumberTable(new byte[] {159, 170, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterRead() => this.updateLastPosition();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float hitSize() => this.hitSize;

    [Signature("(Larc/func/Cons<Larc/math/geom/QuadTree;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void getCollisions([In] Cons obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void collision([In] Hitboxc obj0, [In] float obj1, [In] float obj2)
    {
    }

    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual float deltaLen() => Mathf.len(this.deltaX, this.deltaY);

    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual float deltaAngle() => Mathf.angle(this.deltaX, this.deltaY);

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool collides([In] Hitboxc obj0) => true;

    [LineNumberTable(new byte[] {15, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hitbox([In] Rect obj0) => obj0.setCentered(this.x, this.y, this.hitSize, this.hitSize);

    [LineNumberTable(new byte[] {20, 121, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hitboxTile([In] Rect obj0)
    {
      float num = Math.min(this.hitSize * 0.66f, 7.9f);
      obj0.setCentered(this.x, this.y, num, num);
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
  }
}
