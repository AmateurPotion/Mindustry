// Decompiled with JetBrains decompiler
// Type: arc.util.Time
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace arc.util
{
  public class Time : Object
  {
    public const float toSeconds = 60f;
    public const float toMinutes = 3600f;
    public const float toHours = 216000f;
    public static float delta;
    public static float time;
    public static float globalTime;
    public const long nanosPerMilli = 1000000;
    private static double timeRaw;
    private static double globalTimeRaw;
    [Signature("Larc/struct/Seq<Larc/util/Time$DelayRun;>;")]
    private static Seq runs;
    [Signature("Larc/struct/Seq<Larc/util/Time$DelayRun;>;")]
    private static Seq removal;
    private static LongSeq marks;
    private static Floatp deltaimpl;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(107)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long millis() => java.lang.System.currentTimeMillis();

    [LineNumberTable(new byte[] {46, 102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setDeltaProvider(Floatp impl)
    {
      Time.deltaimpl = impl;
      Time.delta = impl.get();
    }

    [LineNumberTable(143)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long timeSinceMillis(long prevTime) => Time.millis() - prevTime;

    [LineNumberTable(134)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long timeSinceNanos(long prevTime) => Time.nanos() - prevTime;

    [LineNumberTable(102)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long nanos() => java.lang.System.nanoTime();

    [LineNumberTable(new byte[] {159, 172, 122, 103, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void run(float delay, Runnable r)
    {
      Time.DelayRun delayRun = (Time.DelayRun) Pools.obtain((Class) ClassLiteral<Time.DelayRun>.Value, (Prov) new Time.__\u003C\u003EAnon0());
      delayRun.finish = r;
      delayRun.delay = delay;
      Time.runs.add((object) delayRun);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long millisToNanos(long millis) => millis * 1000000L;

    [LineNumberTable(new byte[] {18, 115, 139, 120, 171, 107, 139, 127, 0, 147, 109, 107, 107, 134, 130, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void update()
    {
      Time.timeRaw += (double) Time.delta;
      Time.removal.clear();
      if (Double.isInfinite(Time.timeRaw) || Double.isNaN(Time.timeRaw))
        Time.timeRaw = 0.0;
      Time.time = (float) Time.timeRaw;
      Time.globalTime = (float) Time.globalTimeRaw;
      Iterator iterator = Time.runs.iterator();
      while (iterator.hasNext())
      {
        Time.DelayRun delayRun = (Time.DelayRun) iterator.next();
        delayRun.delay -= Time.delta;
        if ((double) delayRun.delay <= 0.0)
        {
          delayRun.finish.run();
          Time.removal.add((object) delayRun);
          Pools.free((object) delayRun);
        }
      }
      Time.runs.removeAll(Time.removal);
    }

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Timer.Task runTask(float delay, Runnable r) => Timer.schedule(r, delay / 60f);

    [LineNumberTable(new byte[] {42, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void clear() => Time.runs.clear();

    [LineNumberTable(new byte[] {159, 184, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void mark() => Time.marks.add(Time.nanos());

    [LineNumberTable(new byte[] {159, 189, 108, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float elapsed() => Time.marks.size == 0 ? -1f : (float) Time.timeSinceNanos(Time.marks.pop()) / 1000000f;

    [LineNumberTable(new byte[] {5, 127, 1, 144, 120, 171, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void updateGlobal()
    {
      Time.globalTimeRaw += (double) (Core.graphics.getDeltaTime() * 60f);
      Time.delta = Time.deltaimpl.get();
      if (Double.isInfinite(Time.timeRaw) || Double.isNaN(Time.timeRaw))
        Time.timeRaw = 0.0;
      Time.time = (float) Time.timeRaw;
      Time.globalTime = (float) Time.globalTimeRaw;
    }

    [Modifiers]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024static\u00240() => Math.min(Core.graphics.getDeltaTime() * 60f, 3f);

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Time()
    {
    }

    [LineNumberTable(116)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long nanosToMillis(long nanos) => nanos / 1000000L;

    [LineNumberTable(new byte[] {159, 139, 173, 234, 72, 106, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Time()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.Time"))
        return;
      Time.delta = 1f;
      Time.runs = new Seq();
      Time.removal = new Seq();
      Time.marks = new LongSeq();
      Time.deltaimpl = (Floatp) new Time.__\u003C\u003EAnon1();
    }

    public class DelayRun : Object, Pool.Poolable
    {
      internal float delay;
      internal Runnable finish;

      [LineNumberTable(146)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DelayRun()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void reset()
      {
        this.delay = 0.0f;
        this.finish = (Runnable) null;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new Time.DelayRun();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatp
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public float get() => Time.lambda\u0024static\u00240();
    }
  }
}
