// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.MultipassVfxFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.fx.util;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public abstract class MultipassVfxFilter : Object, Disposable
  {
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resize(int width, int height)
    {
    }

    [HideFromJava]
    public abstract void dispose();

    public abstract void render(PingPongBuffer ppb);

    public abstract void setParams();

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MultipassVfxFilter()
    {
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);
  }
}
