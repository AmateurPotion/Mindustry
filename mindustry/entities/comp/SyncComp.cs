// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.SyncComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using java.nio;
using mindustry.gen;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  internal abstract class SyncComp : Object, Entityc
  {
    [NonSerialized]
    internal long lastUpdated;
    [NonSerialized]
    internal long updateSpacing;

    [HideFromJava]
    public abstract bool isLocal();

    [HideFromJava]
    public abstract bool isRemote();

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void interpolate()
    {
    }

    [HideFromJava]
    public abstract int id();

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SyncComp()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void snapSync()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void snapInterpolation()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void readSync([In] Reads obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void writeSync([In] Writes obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void readSyncManual([In] FloatBuffer obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void writeSyncManual([In] FloatBuffer obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void afterSync()
    {
    }

    [LineNumberTable(new byte[] {159, 171, 124, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if ((!Vars.net.client() || this.isLocal()) && !this.isRemote())
        return;
      this.interpolate();
    }

    [LineNumberTable(new byte[] {159, 179, 108, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      if (!Vars.net.client())
        return;
      Vars.netClient.addRemovedEntity(this.id());
    }

    [HideFromJava]
    public abstract bool isAdded();

    [HideFromJava]
    public abstract void add();

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
    public abstract void id([In] int obj0);
  }
}
