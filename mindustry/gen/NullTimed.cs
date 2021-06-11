// Decompiled with JetBrains decompiler
// Type: mindustry.gen.NullTimed
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Timedc"})]
  internal sealed class NullTimed : Object, Timedc, Scaled, Entityc
  {
    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NullTimed()
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
    public int classId() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float fin() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float fin([In] Interp obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float finpow() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float fout() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float fout([In] Interp obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float fout([In] float obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float fslope() => 0.0f;

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
    public float lifetime() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void lifetime([In] float obj0)
    {
    }

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
    public float time() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void time([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void update()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void write([In] Writes obj0)
    {
    }
  }
}
