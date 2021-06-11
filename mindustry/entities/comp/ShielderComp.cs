// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.ShielderComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math.geom;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.game;
using mindustry.gen;
using mindustry.world;
using mindustry.world.blocks.environment;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Damagec", "mindustry.gen.Teamc", "mindustry.gen.Posc"})]
  internal abstract class ShielderComp : Object, Damagec, Entityc, Teamc, Posc, Position
  {
    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal ShielderComp()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void absorb()
    {
    }

    [HideFromJava]
    public abstract bool isAdded();

    [HideFromJava]
    public abstract void update();

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
    public abstract float damage();

    [HideFromJava]
    public abstract void damage([In] float obj0);

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

    [HideFromJava]
    public abstract bool cheating();

    [HideFromJava]
    public abstract Building core();

    [HideFromJava]
    public abstract Building closestCore();

    [HideFromJava]
    public abstract Building closestEnemyCore();

    [HideFromJava]
    public abstract Team team();

    [HideFromJava]
    public abstract void team([In] Team obj0);
  }
}
