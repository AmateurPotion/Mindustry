// Decompiled with JetBrains decompiler
// Type: arc.util.Timekeeper
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.util
{
  public class Timekeeper : Object
  {
    [Modifiers]
    private long intervalms;
    private long time;

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool get() => Time.timeSinceMillis(this.time) > this.intervalms;

    [LineNumberTable(new byte[] {159, 158, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset() => this.time = Time.millis();

    [LineNumberTable(new byte[] {159, 149, 104, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Timekeeper(float seconds)
    {
      Timekeeper timekeeper = this;
      this.intervalms = (long) ByteCodeHelper.f2i(seconds * 1000f);
    }
  }
}
