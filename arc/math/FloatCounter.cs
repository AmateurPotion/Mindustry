// Decompiled with JetBrains decompiler
// Type: arc.math.FloatCounter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math
{
  public class FloatCounter : Object
  {
    internal WindowedMean __\u003C\u003Emean;
    public int count;
    public float total;
    public float min;
    public float max;
    public float average;
    public float latest;
    public float value;

    [LineNumberTable(new byte[] {159, 172, 104, 115, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FloatCounter(int windowSize)
    {
      FloatCounter floatCounter = this;
      this.__\u003C\u003Emean = windowSize <= 1 ? (WindowedMean) null : new WindowedMean(windowSize);
      this.reset();
    }

    [LineNumberTable(new byte[] {9, 103, 107, 107, 107, 107, 107, 107, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.count = 0;
      this.total = 0.0f;
      this.min = float.MaxValue;
      this.max = float.Epsilon;
      this.average = 0.0f;
      this.latest = 0.0f;
      this.value = 0.0f;
      if (this.__\u003C\u003Emean == null)
        return;
      this.__\u003C\u003Emean.clear();
    }

    [LineNumberTable(new byte[] {159, 182, 104, 112, 110, 149, 104, 109, 148, 140, 117, 122, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(float value)
    {
      this.latest = value;
      this.total += value;
      ++this.count;
      this.average = this.total / (float) this.count;
      if (this.__\u003C\u003Emean != null)
      {
        this.__\u003C\u003Emean.add(value);
        this.value = this.__\u003C\u003Emean.mean();
      }
      else
        this.value = this.latest;
      if (this.__\u003C\u003Emean != null && !this.__\u003C\u003Emean.hasEnoughData())
        return;
      if ((double) this.value < (double) this.min)
        this.min = this.value;
      if ((double) this.value <= (double) this.max)
        return;
      this.max = this.value;
    }

    [Modifiers]
    public WindowedMean mean
    {
      [HideFromJava] get => this.__\u003C\u003Emean;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Emean = value;
    }
  }
}
