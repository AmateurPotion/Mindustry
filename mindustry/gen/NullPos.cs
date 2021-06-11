// Decompiled with JetBrains decompiler
// Type: mindustry.gen.NullPos
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math.geom;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.world;
using mindustry.world.blocks.environment;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Posc"})]
  internal sealed class NullPos : Object, Posc, Position, Entityc
  {
    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NullPos()
    {
    }

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public object @as() => (object) null;

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Entityc self() => (Entityc) null;

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public object with([In] Cons obj0) => (object) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void add()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void afterRead()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float angleTo([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float angleTo([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public Block blockOn() => (Block) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int classId() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float dst([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float dst([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float dst2([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float dst2([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public Floor floorOn() => (Floor) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float getX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float getY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int id() => -1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void id([In] int obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isAdded() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isLocal() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isNull() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isRemote() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool onSolid() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void read([In] Reads obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void remove()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool serialize() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void set([In] Position obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void set([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public Tile tileOn() => (Tile) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int tileX() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int tileY() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void trns([In] Position obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void trns([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void update()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool within([In] Position obj0, [In] float obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool within([In] float obj0, [In] float obj1, [In] float obj2) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void write([In] Writes obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float x() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void x([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float y() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void y([In] float obj0)
    {
    }
  }
}
