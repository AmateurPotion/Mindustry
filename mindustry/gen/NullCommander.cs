// Decompiled with JetBrains decompiler
// Type: mindustry.gen.NullCommander
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math.geom;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.ai.formations;
using mindustry.entities.units;
using mindustry.world;
using mindustry.world.blocks.environment;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Commanderc"})]
  internal sealed class NullCommander : Object, Commanderc, Posc, Position, Entityc
  {
    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NullCommander()
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
    public void clearCommand()
    {
    }

    [Signature("(Lmindustry/ai/formations/Formation;Larc/struct/Seq<Lmindustry/gen/Unit;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void command([In] Formation obj0, [In] Seq obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void commandNearby([In] FormationPattern obj0)
    {
    }

    [Signature("(Lmindustry/ai/formations/FormationPattern;Larc/func/Boolf<Lmindustry/gen/Unit;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void commandNearby([In] FormationPattern obj0, [In] Boolf obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void controller([In] UnitController obj0)
    {
    }

    [Signature("()Larc/struct/Seq<Lmindustry/gen/Unit;>;")]
    [LineNumberTable(98)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Seq controlling() => new Seq(10);

    [Signature("(Larc/struct/Seq<Lmindustry/gen/Unit;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void controlling([In] Seq obj0)
    {
    }

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
    public Formation formation() => (Formation) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void formation([In] Formation obj0)
    {
    }

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
    public bool isCommanding() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isLocal() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isNull() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isRemote() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void killed()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float minFormationSpeed() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void minFormationSpeed([In] float obj0)
    {
    }

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
