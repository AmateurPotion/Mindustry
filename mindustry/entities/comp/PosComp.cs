// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.PosComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.core;
using mindustry.world;
using mindustry.world.blocks.environment;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  internal abstract class PosComp : Object, Position
  {
    internal float x;
    internal float y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void set([In] float obj0, [In] float obj1)
    {
      this.x = obj0;
      this.y = obj1;
    }

    [LineNumberTable(new byte[] {159, 169, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void trns([In] float obj0, [In] float obj1) => this.set(this.x + obj0, this.y + obj1);

    [LineNumberTable(60)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Tile tileOn() => Vars.world.tileWorld(this.x, this.y);

    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal PosComp()
    {
    }

    [LineNumberTable(new byte[] {159, 165, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void set([In] Position obj0) => this.set(obj0.getX(), obj0.getY());

    [LineNumberTable(new byte[] {159, 173, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void trns([In] Position obj0) => this.trns(obj0.getX(), obj0.getY());

    [LineNumberTable(35)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int tileX() => World.toTile(this.x);

    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int tileY() => World.toTile(this.y);

    [LineNumberTable(new byte[] {159, 186, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Floor floorOn()
    {
      Tile tile = this.tileOn();
      return tile == null || !object.ReferenceEquals((object) tile.block(), (object) Blocks.air) ? (Floor) Blocks.air : tile.floor();
    }

    [LineNumberTable(new byte[] {159, 191, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Block blockOn()
    {
      Tile tile = this.tileOn();
      return tile == null ? Blocks.air : tile.block();
    }

    [LineNumberTable(new byte[] {4, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool onSolid()
    {
      Tile tile = this.tileOn();
      return tile == null || tile.solid();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

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
  }
}
