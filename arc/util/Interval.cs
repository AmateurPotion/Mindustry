// Decompiled with JetBrains decompiler
// Type: arc.util.Interval
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace arc.util
{
  public class Interval : Object
  {
    internal float[] times;

    [LineNumberTable(new byte[] {159, 155, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Interval()
      : this(1)
    {
    }

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool get(float time) => this.get(0, time);

    [LineNumberTable(new byte[] {159, 150, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Interval(int capacity)
    {
      Interval interval = this;
      this.times = new float[capacity];
    }

    [LineNumberTable(new byte[] {159, 163, 159, 32, 106, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool get(int id, float time)
    {
      if (id >= this.times.Length)
      {
        string str = new StringBuilder().append("Out of bounds! Max timer size is ").append(this.times.Length).append("!").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException(str);
      }
      int num = this.check(id, time) ? 1 : 0;
      if (num != 0)
        this.times[id] = Time.time;
      return num != 0;
    }

    [LineNumberTable(new byte[] {159, 175, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset(int id, float time) => this.times[id] = Time.time - time;

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getTime(int id) => Time.time - this.times[id];

    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool check(int id, float time) => (double) (Time.time - this.times[id]) >= (double) time || (double) Time.time < (double) this.times[id];

    [LineNumberTable(new byte[] {159, 179, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear() => Arrays.fill(this.times, 0.0f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] getTimes() => this.times;
  }
}
