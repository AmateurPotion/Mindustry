// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.TimerComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  internal abstract class TimerComp : Object
  {
    [NonSerialized]
    internal Interval timer;

    [LineNumberTable(new byte[] {159, 149, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal TimerComp()
    {
      TimerComp timerComp = this;
      this.timer = new Interval(6);
    }

    [LineNumberTable(new byte[] {159, 153, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool timer([In] int obj0, [In] float obj1) => !Float.isInfinite(obj1) && this.timer.get(obj0, obj1);
  }
}
