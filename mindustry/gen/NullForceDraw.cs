// Decompiled with JetBrains decompiler
// Type: mindustry.gen.NullForceDraw
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math.geom;
using arc.util.io;
using IKVM.Attributes;
using mindustry.world;
using mindustry.world.blocks.defense;
using mindustry.world.blocks.environment;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.ForceDrawc"})]
  internal sealed class NullForceDraw : ForceDraw, ForceDrawc, Drawc, Posc, Position, Entityc
  {
    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NullForceDraw()
    {
    }

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed object @as() => (object) null;

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Entityc self() => (Entityc) null;

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed object with([In] Cons obj0) => (object) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void add()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void afterRead()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float angleTo([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float angleTo([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Block blockOn() => (Block) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed ForceProjector.ForceBuild build() => (ForceProjector.ForceBuild) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void build([In] ForceProjector.ForceBuild obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int classId() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float clipSize() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void draw()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dst([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dst([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dst2([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dst2([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Floor floorOn() => (Floor) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float getX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float getY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int id() => -1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void id([In] int obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isAdded() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isLocal() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isNull() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isRemote() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool onSolid() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void read([In] Reads obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void remove()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool serialize() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void set([In] Position obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void set([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Tile tileOn() => (Tile) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int tileX() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int tileY() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void trns([In] Position obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void trns([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void update()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool within([In] Position obj0, [In] float obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool within([In] float obj0, [In] float obj1, [In] float obj2) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void write([In] Writes obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float x() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void x([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float y() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void y([In] float obj0)
    {
    }
  }
}
