// Decompiled with JetBrains decompiler
// Type: arc.audio.AudioSource
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.audio
{
  public abstract class AudioSource : Object, Disposable
  {
    protected internal long handle;

    [LineNumberTable(new byte[] {159, 153, 107, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFilter(int index, [Nullable(new object[] {64, "Larc/util/Nullable;"})] AudioFilter filter)
    {
      if (this.handle == 0L)
        return;
      Soloud.sourceFilter(this.handle, index, filter != null ? filter.handle : 0L);
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AudioSource()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFilter([Nullable(new object[] {64, "Larc/util/Nullable;"})] AudioFilter filter) => this.setFilter(0, filter);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);
  }
}
