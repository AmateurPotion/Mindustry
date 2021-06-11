// Decompiled with JetBrains decompiler
// Type: arc.math.WindowedMean
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;

namespace arc.math
{
  public sealed class WindowedMean : Object
  {
    internal float[] values;
    internal int addedValues;
    internal int lastValue;
    internal float mean;
    internal bool dirty;

    [LineNumberTable(new byte[] {159, 165, 232, 54, 135, 107, 231, 72, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WindowedMean(int windowSize)
    {
      WindowedMean windowedMean = this;
      this.addedValues = 0;
      this.mean = 0.0f;
      this.dirty = true;
      this.values = new float[windowSize];
    }

    [LineNumberTable(new byte[] {2, 103, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void fill(float value)
    {
      this.dirty = true;
      Arrays.fill(this.values, value);
    }

    [LineNumberTable(new byte[] {11, 125, 124, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(float value)
    {
      if (this.addedValues < this.values.Length)
        ++this.addedValues;
      float[] values = this.values;
      WindowedMean windowedMean1 = this;
      int lastValue = windowedMean1.lastValue;
      WindowedMean windowedMean2 = windowedMean1;
      int index = lastValue;
      windowedMean2.lastValue = lastValue + 1;
      double num = (double) value;
      values[index] = (float) num;
      if (this.lastValue > this.values.Length - 1)
        this.lastValue = 0;
      this.dirty = true;
    }

    [LineNumberTable(new byte[] {38, 104, 102, 108, 44, 166, 113, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float rawMean()
    {
      if (this.dirty)
      {
        float num = 0.0f;
        for (int index = 0; index < this.values.Length; ++index)
          num += this.values[index];
        this.mean = num / (float) this.values.Length;
        this.dirty = false;
      }
      return this.mean;
    }

    [LineNumberTable(141)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getWindowSize() => this.values.Length;

    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float get(int index) => this.values[Mathf.mod(index + this.lastValue, this.values.Length)];

    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasEnoughData() => this.addedValues >= this.values.Length;

    [LineNumberTable(new byte[] {23, 104, 104, 102, 108, 44, 166, 113, 135, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float mean()
    {
      if (!this.hasEnoughData())
        return 0.0f;
      if (this.dirty)
      {
        float num = 0.0f;
        for (int index = 0; index < this.values.Length; ++index)
          num += this.values[index];
        this.mean = num / (float) this.values.Length;
        this.dirty = false;
      }
      return this.mean;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.addedValues = 0;
      this.lastValue = 0;
      this.mean = 0.0f;
    }

    [LineNumberTable(new byte[] {159, 186, 103, 103, 108, 45, 134, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      this.addedValues = 0;
      this.lastValue = 0;
      for (int index = 0; index < this.values.Length; ++index)
        this.values[index] = 0.0f;
      this.dirty = true;
    }

    [LineNumberTable(101)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float oldest() => this.addedValues < this.values.Length ? this.values[0] : this.values[this.lastValue];

    [LineNumberTable(106)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float latest() => this.values[this.lastValue - 1 != -1 ? this.lastValue - 1 : this.values.Length - 1];

    [LineNumberTable(new byte[] {61, 142, 104, 102, 108, 60, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float standardDeviation()
    {
      if (!this.hasEnoughData())
        return 0.0f;
      float num1 = this.mean();
      float num2 = 0.0f;
      for (int index = 0; index < this.values.Length; ++index)
        num2 += (this.values[index] - num1) * (this.values[index] - num1);
      return (float) Math.sqrt((double) (num2 / (float) this.values.Length));
    }

    [LineNumberTable(new byte[] {73, 102, 108, 48, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float lowest()
    {
      float num = float.MaxValue;
      for (int index = 0; index < this.values.Length; ++index)
        num = Math.min(num, this.values[index]);
      return num;
    }

    [LineNumberTable(new byte[] {80, 102, 108, 48, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float highest()
    {
      float num = 1.175494E-38f;
      for (int index = 0; index < this.values.Length; ++index)
        num = Math.max(num, this.values[index]);
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getCount() => this.addedValues;

    [LineNumberTable(new byte[] {99, 108, 104, 103, 63, 4, 200, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] getWindowValues()
    {
      float[] numArray1 = new float[this.addedValues];
      if (this.hasEnoughData())
      {
        for (int index1 = 0; index1 < numArray1.Length; ++index1)
        {
          float[] numArray2 = numArray1;
          int index2 = index1;
          float[] values = this.values;
          int num1 = index1 + this.lastValue;
          int length = this.values.Length;
          int index3 = length != -1 ? num1 % length : 0;
          double num2 = (double) values[index3];
          numArray2[index2] = (float) num2;
        }
      }
      else
        ByteCodeHelper.arraycopy_primitive_4((Array) this.values, 0, (Array) numArray1, 0, this.addedValues);
      return numArray1;
    }
  }
}
