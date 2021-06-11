// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.ItemsComp
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
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Posc"})]
  internal abstract class ItemsComp : Object, Posc, Position, Entityc
  {
    internal ItemStack stack;
    [NonSerialized]
    internal float itemTime;

    internal abstract int itemCapacity();

    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool hasItem() => this.stack.amount > 0;

    [LineNumberTable(new byte[] {159, 184, 127, 15, 108, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addItem([In] Item obj0, [In] int obj1)
    {
      this.stack.amount = !object.ReferenceEquals((object) this.stack.item, (object) obj0) ? obj1 : this.stack.amount + obj1;
      this.stack.item = obj0;
      this.stack.amount = Mathf.clamp(this.stack.amount, 0, this.itemCapacity());
    }

    [LineNumberTable(new byte[] {159, 151, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal ItemsComp()
    {
      ItemsComp itemsComp = this;
      this.stack = new ItemStack();
    }

    [LineNumberTable(new byte[] {159, 159, 127, 3, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      this.stack.amount = Mathf.clamp(this.stack.amount, 0, this.itemCapacity());
      this.itemTime = Mathf.lerpDelta(this.itemTime, (float) Mathf.num(this.hasItem()), 0.05f);
    }

    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Item item() => this.stack.item;

    [LineNumberTable(new byte[] {159, 168, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void clearItem() => this.stack.amount = 0;

    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool acceptsItem([In] Item obj0) => !this.hasItem() || object.ReferenceEquals((object) obj0, (object) this.stack.item) && this.stack.amount + 1 <= this.itemCapacity();

    [LineNumberTable(new byte[] {159, 180, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addItem([In] Item obj0) => this.addItem(obj0, 1);

    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int maxAccepted([In] Item obj0) => !object.ReferenceEquals((object) this.stack.item, (object) obj0) && this.stack.amount > 0 ? 0 : this.itemCapacity() - this.stack.amount;

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
  }
}
