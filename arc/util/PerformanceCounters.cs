// Decompiled with JetBrains decompiler
// Type: arc.util.PerformanceCounters
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using java.util;
using java.util.function;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  public class PerformanceCounters : Object
  {
    private const float nano2seconds = 1E-09f;
    [Signature("Larc/struct/Seq<Larc/util/PerformanceCounter;>;")]
    internal Seq __\u003C\u003Ecounters;
    private long lastTick;

    [LineNumberTable(new byte[] {159, 172, 112, 56, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tick(float deltaTime)
    {
      for (int index = 0; index < this.__\u003C\u003Ecounters.size; ++index)
        ((PerformanceCounter) this.__\u003C\u003Ecounters.get(index)).tick(deltaTime);
    }

    [Modifiers]
    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024toString\u00240([In] PerformanceCounter obj0, [In] PerformanceCounter obj1) => -Float.compare(obj0.__\u003C\u003Eload.value, obj1.__\u003C\u003Eload.value);

    [LineNumberTable(new byte[] {159, 148, 136, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PerformanceCounters()
    {
      PerformanceCounters performanceCounters = this;
      this.__\u003C\u003Ecounters = new Seq();
      this.lastTick = 0L;
    }

    [LineNumberTable(new byte[] {159, 154, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual PerformanceCounter add(string name, int windowSize)
    {
      PerformanceCounter performanceCounter = new PerformanceCounter(name, windowSize);
      this.__\u003C\u003Ecounters.add((object) performanceCounter);
      return performanceCounter;
    }

    [LineNumberTable(new byte[] {159, 160, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual PerformanceCounter add(string name)
    {
      PerformanceCounter performanceCounter = new PerformanceCounter(name);
      this.__\u003C\u003Ecounters.add((object) performanceCounter);
      return performanceCounter;
    }

    [LineNumberTable(new byte[] {159, 166, 102, 127, 1, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tick()
    {
      long num = Time.nanos();
      if (this.lastTick > 0L)
        this.tick((float) (num - this.lastTick) * 1E-09f);
      this.lastTick = num;
    }

    [LineNumberTable(new byte[] {159, 178, 118, 102, 103, 112, 120, 28, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      this.__\u003C\u003Ecounters.sort((Comparator) new PerformanceCounters.__\u003C\u003EAnon0());
      StringBuilder sb = new StringBuilder();
      sb.setLength(0);
      for (int index = 0; index < this.__\u003C\u003Ecounters.size; ++index)
      {
        ((PerformanceCounter) this.__\u003C\u003Ecounters.get(index)).toString(sb);
        if (index != this.__\u003C\u003Ecounters.size - 1)
          sb.append("\n");
      }
      return sb.toString();
    }

    [Modifiers]
    public Seq counters
    {
      [HideFromJava] get => this.__\u003C\u003Ecounters;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ecounters = value;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Comparator
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public int compare([In] object obj0, [In] object obj1) => PerformanceCounters.lambda\u0024toString\u00240((PerformanceCounter) obj0, (PerformanceCounter) obj1);

      [SpecialName]
      public Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public bool equals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

      [SpecialName]
      public Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);
    }
  }
}
