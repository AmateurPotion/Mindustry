// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.EntityComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  internal abstract class EntityComp : Object
  {
    [NonSerialized]
    private bool added;
    [NonSerialized]
    internal int id;

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isLocal() => object.ReferenceEquals((object) this, (object) Vars.player) || this is Unitc && object.ReferenceEquals((object) ((Unitc) this).controller(), (object) Vars.player);

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void afterRead()
    {
    }

    [LineNumberTable(new byte[] {159, 155, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal EntityComp()
    {
      EntityComp entityComp = this;
      this.id = EntityGroup.nextId();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isAdded() => this.added;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void update()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void remove() => this.added = false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void add() => this.added = true;

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isRemote() => this is Unitc && ((Unitc) this).isPlayer() && !this.isLocal();

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isNull() => false;

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Entityc self() => (Entityc) this;

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object @as() => (object) this;

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [LineNumberTable(new byte[] {2, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object with([In] Cons obj0)
    {
      obj0.get((object) this);
      return (object) this;
    }

    internal abstract int classId();

    internal abstract bool serialize();

    [LineNumberTable(new byte[] {14, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void read([In] Reads obj0) => this.afterRead();

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void write([In] Writes obj0)
    {
    }
  }
}
