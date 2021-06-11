// Decompiled with JetBrains decompiler
// Type: arc.math.CumulativeDistribution
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace arc.math
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;")]
  public class CumulativeDistribution : Object
  {
    [Signature("Larc/struct/Seq<Larc/math/CumulativeDistribution<TT;>.CumulativeValue;>;")]
    private Seq values;

    [Signature("(F)TT;")]
    [LineNumberTable(new byte[] {21, 98, 112, 100, 104, 115, 106, 102, 106, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object value(float probability)
    {
      int num = this.values.size - 1;
      int index1 = 0;
      while (index1 <= num)
      {
        int index2 = index1 + (num - index1) / 2;
        CumulativeDistribution.CumulativeValue cumulativeValue = ((CumulativeDistribution.CumulativeValue[]) this.values.items)[index2];
        if ((double) probability < (double) cumulativeValue.frequency)
          num = index2 - 1;
        else if ((double) probability > (double) cumulativeValue.frequency)
          index1 = index2 + 1;
        else
          break;
      }
      return ((CumulativeDistribution.CumulativeValue[]) this.values.items)[index1].value;
    }

    [LineNumberTable(new byte[] {159, 161, 104, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CumulativeDistribution()
    {
      CumulativeDistribution cumulativeDistribution = this;
      this.values = new Seq(false, 10, (Class) ClassLiteral<CumulativeDistribution.CumulativeValue>.Value);
    }

    [Signature("(TT;F)V")]
    [LineNumberTable(new byte[] {159, 167, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(object value, float intervalSize) => this.values.add((object) new CumulativeDistribution.CumulativeValue(this, value, 0.0f, intervalSize));

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {159, 172, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(object value) => this.values.add((object) new CumulativeDistribution.CumulativeValue(this, value, 0.0f, 0.0f));

    [LineNumberTable(new byte[] {159, 177, 102, 112, 123, 24, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void generate()
    {
      float num = 0.0f;
      for (int index = 0; index < this.values.size; ++index)
      {
        num += ((CumulativeDistribution.CumulativeValue[]) this.values.items)[index].interval;
        ((CumulativeDistribution.CumulativeValue[]) this.values.items)[index].frequency = num;
      }
    }

    [LineNumberTable(new byte[] {159, 186, 102, 112, 59, 166, 102, 112, 126, 24, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void generateNormalized()
    {
      float num1 = 0.0f;
      for (int index = 0; index < this.values.size; ++index)
        num1 += ((CumulativeDistribution.CumulativeValue[]) this.values.items)[index].interval;
      float num2 = 0.0f;
      for (int index = 0; index < this.values.size; ++index)
      {
        num2 += ((CumulativeDistribution.CumulativeValue[]) this.values.items)[index].interval / num1;
        ((CumulativeDistribution.CumulativeValue[]) this.values.items)[index].frequency = num2;
      }
    }

    [LineNumberTable(new byte[] {7, 116, 144, 120, 254, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void generateUniform()
    {
      float num = 1f / (float) this.values.size;
      for (int index = 0; index < this.values.size; ++index)
      {
        ((CumulativeDistribution.CumulativeValue[]) this.values.items)[index].interval = num;
        ((CumulativeDistribution.CumulativeValue[]) this.values.items)[index].frequency = (float) (index + 1) * num;
      }
    }

    [Signature("()TT;")]
    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object value() => this.value(Mathf.random());

    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => this.values.size;

    [LineNumberTable(98)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getInterval(int index) => ((CumulativeDistribution.CumulativeValue[]) this.values.items)[index].interval;

    [Signature("(I)TT;")]
    [LineNumberTable(103)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getValue(int index) => ((CumulativeDistribution.CumulativeValue[]) this.values.items)[index].value;

    [Signature("(TT;F)V")]
    [LineNumberTable(new byte[] {61, 127, 1, 110, 104, 1, 194})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setInterval(object obj, float intervalSize)
    {
      Iterator iterator = this.values.iterator();
      while (iterator.hasNext())
      {
        CumulativeDistribution.CumulativeValue cumulativeValue = (CumulativeDistribution.CumulativeValue) iterator.next();
        if (object.ReferenceEquals(cumulativeValue.value, obj))
        {
          cumulativeValue.interval = intervalSize;
          break;
        }
      }
    }

    [LineNumberTable(new byte[] {70, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setInterval(int index, float intervalSize) => ((CumulativeDistribution.CumulativeValue[]) this.values.items)[index].interval = intervalSize;

    [LineNumberTable(new byte[] {75, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear() => this.values.clear();

    public class CumulativeValue : Object
    {
      [Signature("TT;")]
      public object value;
      public float frequency;
      public float interval;
      [Modifiers]
      internal CumulativeDistribution this\u00240;

      [Signature("(TT;FF)V")]
      [LineNumberTable(new byte[] {83, 111, 103, 104, 105})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public CumulativeValue(
        CumulativeDistribution _param1,
        object value,
        float frequency,
        float interval)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        CumulativeDistribution.CumulativeValue cumulativeValue = this;
        this.value = value;
        this.frequency = frequency;
        this.interval = interval;
      }
    }
  }
}
