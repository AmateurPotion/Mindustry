// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.TimedComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Entityc", "arc.math.Scaled"})]
  internal abstract class TimedComp : Object, Entityc, Scaled
  {
    internal float time;
    internal float lifetime;

    [HideFromJava]
    public abstract void remove();

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal TimedComp()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 159, 0, 110, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      this.time = Math.min(this.time + Time.delta, this.lifetime);
      if ((double) this.time < (double) this.lifetime)
        return;
      this.remove();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float fin() => this.time / this.lifetime;

    [HideFromJava]
    public abstract bool isAdded();

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
    public virtual float fout() => Scaled.\u003Cdefault\u003Efout((Scaled) this);

    [HideFromJava]
    public virtual float fout([In] Interp obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

    [HideFromJava]
    public virtual float fout([In] float obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

    [HideFromJava]
    public virtual float fin([In] Interp obj0) => Scaled.\u003Cdefault\u003Efin((Scaled) this, obj0);

    [HideFromJava]
    public virtual float finpow() => Scaled.\u003Cdefault\u003Efinpow((Scaled) this);

    [HideFromJava]
    public virtual float fslope() => Scaled.\u003Cdefault\u003Efslope((Scaled) this);
  }
}
