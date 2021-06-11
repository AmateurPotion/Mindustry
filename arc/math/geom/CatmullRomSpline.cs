// Decompiled with JetBrains decompiler
// Type: arc.math.geom.CatmullRomSpline
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.math.geom
{
  [Signature("<T::Larc/math/geom/Vector<TT;>;>Ljava/lang/Object;Larc/math/geom/Path<TT;>;")]
  public class CatmullRomSpline : Object, Path
  {
    [Signature("[TT;")]
    public Vector[] controlPoints;
    public bool continuous;
    public int spanCount;
    [Signature("TT;")]
    private Vector tmp;
    [Signature("TT;")]
    private Vector tmp2;
    [Signature("TT;")]
    private Vector tmp3;

    [Signature("([TT;Z)Larc/math/geom/CatmullRomSpline;")]
    [LineNumberTable(new byte[] {159, 117, 162, 118, 118, 118, 103, 103, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CatmullRomSpline set(Vector[] controlPoints, bool continuous)
    {
      int num = continuous ? 1 : 0;
      if (this.tmp == null)
        this.tmp = controlPoints[0].cpy();
      if (this.tmp2 == null)
        this.tmp2 = controlPoints[0].cpy();
      if (this.tmp3 == null)
        this.tmp3 = controlPoints[0].cpy();
      this.controlPoints = controlPoints;
      this.continuous = num != 0;
      this.spanCount = num == 0 ? controlPoints.Length - 3 : controlPoints.Length;
      return this;
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;IF[TT;ZTT;)TT;")]
    [LineNumberTable(new byte[] {159, 130, 99, 99, 103, 102, 127, 9, 127, 35, 127, 42, 127, 31})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector calculate(
      Vector @out,
      int i,
      float u,
      Vector[] points,
      bool continuous,
      Vector tmp)
    {
      int num1 = continuous ? 1 : 0;
      int length = points.Length;
      float num2 = u * u;
      float num3 = num2 * u;
      @out.set(points[i]).scl(1.5f * num3 - 2.5f * num2 + 1f);
      if (num1 != 0 || i > 0)
      {
        Vector vector1 = @out;
        Vector vector2 = tmp;
        Vector[] vectorArray = points;
        int num4 = length + i - 1;
        int num5 = length;
        int index = num5 != -1 ? num4 % num5 : 0;
        Vector v1 = vectorArray[index];
        Vector v2 = vector2.set(v1).scl(-0.5f * num3 + num2 - 0.5f * u);
        vector1.add(v2);
      }
      if (num1 != 0 || i < length - 1)
      {
        Vector vector1 = @out;
        Vector vector2 = tmp;
        Vector[] vectorArray = points;
        int num4 = i + 1;
        int num5 = length;
        int index = num5 != -1 ? num4 % num5 : 0;
        Vector v1 = vectorArray[index];
        Vector v2 = vector2.set(v1).scl(-1.5f * num3 + 2f * num2 + 0.5f * u);
        vector1.add(v2);
      }
      if (num1 != 0 || i < length - 2)
      {
        Vector vector1 = @out;
        Vector vector2 = tmp;
        Vector[] vectorArray = points;
        int num4 = i + 2;
        int num5 = length;
        int index = num5 != -1 ? num4 % num5 : 0;
        Vector v1 = vectorArray[index];
        Vector v2 = vector2.set(v1).scl(0.5f * num3 - 0.5f * num2);
        vector1.add(v2);
      }
      return @out;
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;IF[TT;ZTT;)TT;")]
    [LineNumberTable(new byte[] {159, 119, 67, 99, 135, 127, 4, 127, 39, 127, 39, 127, 26})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector derivative(
      Vector @out,
      int i,
      float u,
      Vector[] points,
      bool continuous,
      Vector tmp)
    {
      int num1 = continuous ? 1 : 0;
      int length = points.Length;
      float num2 = u * u;
      @out.set(points[i]).scl((float) (-(double) u * 5.0) + num2 * 4.5f);
      if (num1 != 0 || i > 0)
      {
        Vector vector1 = @out;
        Vector vector2 = tmp;
        Vector[] vectorArray = points;
        int num3 = length + i - 1;
        int num4 = length;
        int index = num4 != -1 ? num3 % num4 : 0;
        Vector v1 = vectorArray[index];
        Vector v2 = vector2.set(v1).scl(u * 2f - 0.5f - num2 * 1.5f);
        vector1.add(v2);
      }
      if (num1 != 0 || i < length - 1)
      {
        Vector vector1 = @out;
        Vector vector2 = tmp;
        Vector[] vectorArray = points;
        int num3 = i + 1;
        int num4 = length;
        int index = num4 != -1 ? num3 % num4 : 0;
        Vector v1 = vectorArray[index];
        Vector v2 = vector2.set(v1).scl(0.5f + u * 4f - num2 * 4.5f);
        vector1.add(v2);
      }
      if (num1 != 0 || i < length - 2)
      {
        Vector vector1 = @out;
        Vector vector2 = tmp;
        Vector[] vectorArray = points;
        int num3 = i + 2;
        int num4 = length;
        int index = num4 != -1 ? num3 % num4 : 0;
        Vector v1 = vectorArray[index];
        Vector v2 = vector2.set(v1).scl(-u + num2 * 1.5f);
        vector1.add(v2);
      }
      return @out;
    }

    [Signature("(TT;IF)TT;")]
    [LineNumberTable(123)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector valueAt(Vector @out, int span, float u) => CatmullRomSpline.calculate(@out, !this.continuous ? span + 1 : span, u, this.controlPoints, this.continuous, this.tmp);

    [Signature("(TT;IF)TT;")]
    [LineNumberTable(137)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector derivativeAt(Vector @out, int span, float u) => CatmullRomSpline.derivative(@out, !this.continuous ? span + 1 : span, u, this.controlPoints, this.continuous, this.tmp);

    [Signature("(TT;II)I")]
    [LineNumberTable(new byte[] {97, 100, 108, 114, 112, 102, 116, 113, 101, 99, 226, 59, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int nearest(Vector @in, int start, int count)
    {
      while (start < 0)
        start += this.spanCount;
      int num1 = start;
      int spanCount1 = this.spanCount;
      int index1 = spanCount1 != -1 ? num1 % spanCount1 : 0;
      float num2 = @in.dst2(this.controlPoints[index1]);
      for (int index2 = 1; index2 < count; ++index2)
      {
        int num3 = start + index2;
        int spanCount2 = this.spanCount;
        int index3 = spanCount2 != -1 ? num3 % spanCount2 : 0;
        float num4 = @in.dst2(this.controlPoints[index3]);
        if ((double) num4 < (double) num2)
        {
          num2 = num4;
          index1 = index3;
        }
      }
      return index1;
    }

    [Signature("(TT;)I")]
    [LineNumberTable(142)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int nearest(Vector @in) => this.nearest(@in, 0, this.spanCount);

    [Signature("(TT;I)F")]
    [LineNumberTable(new byte[] {122, 98, 105, 121, 123, 106, 138, 102, 99, 99, 133, 99, 99, 99, 146, 108, 108, 108, 108, 119, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float approximate(Vector @in, int near)
    {
      int index1 = near;
      Vector controlPoint1 = this.controlPoints[index1];
      Vector controlPoint2 = this.controlPoints[index1 <= 0 ? this.spanCount - 1 : index1 - 1];
      Vector[] controlPoints = this.controlPoints;
      int num1 = index1 + 1;
      int spanCount = this.spanCount;
      int index2 = spanCount != -1 ? num1 % spanCount : 0;
      Vector v1 = controlPoints[index2];
      float num2 = @in.dst2(controlPoint2);
      Vector v2;
      Vector v3;
      Vector vector;
      if ((double) @in.dst2(v1) < (double) num2)
      {
        v2 = controlPoint1;
        v3 = v1;
        vector = @in;
      }
      else
      {
        v2 = controlPoint2;
        v3 = controlPoint1;
        vector = @in;
        index1 = index1 <= 0 ? this.spanCount - 1 : index1 - 1;
      }
      float num3 = v2.dst2(v3);
      float num4 = vector.dst2(v3);
      float num5 = vector.dst2(v2);
      float num6 = (float) Math.sqrt((double) num3);
      float num7 = (num4 + num3 - num5) / (2f * num6);
      float num8 = Mathf.clamp((num6 - num7) / num6, 0.0f, 1f);
      return ((float) index1 + num8) / (float) this.spanCount;
    }

    [Signature("(TT;)F")]
    [LineNumberTable(164)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float approximate(Vector v) => this.approximate(v, this.nearest(v));

    [Signature("(TT;F)TT;")]
    [LineNumberTable(new byte[] {64, 103, 103, 117, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector valueAt(Vector @out, float t)
    {
      int spanCount = this.spanCount;
      float num = t * (float) spanCount;
      int span = (double) t < 1.0 ? ByteCodeHelper.f2i(num) : spanCount - 1;
      float u = num - (float) span;
      return this.valueAt(@out, span, u);
    }

    [Signature("(TT;)F")]
    [LineNumberTable(200)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float locate(Vector v) => this.approximate(v);

    [Signature("(TT;F)TT;")]
    [LineNumberTable(new byte[] {78, 103, 103, 117, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector derivativeAt(Vector @out, float t)
    {
      int spanCount = this.spanCount;
      float num = t * (float) spanCount;
      int span = (double) t < 1.0 ? ByteCodeHelper.f2i(num) : spanCount - 1;
      float u = num - (float) span;
      return this.derivativeAt(@out, span, u);
    }

    [LineNumberTable(new byte[] {159, 155, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CatmullRomSpline()
    {
    }

    [Signature("([TT;Z)V")]
    [LineNumberTable(new byte[] {159, 139, 162, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CatmullRomSpline(Vector[] controlPoints, bool continuous)
    {
      int num = continuous ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      CatmullRomSpline catmullRomSpline = this;
      this.set(controlPoints, num != 0);
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;F[TT;ZTT;)TT;")]
    [LineNumberTable(new byte[] {159, 135, 130, 108, 103, 117, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector calculate(
      Vector @out,
      float t,
      Vector[] points,
      bool continuous,
      Vector tmp)
    {
      int num1 = continuous ? 1 : 0;
      int num2 = num1 == 0 ? points.Length - 3 : points.Length;
      float num3 = t * (float) num2;
      int i = (double) t < 1.0 ? ByteCodeHelper.f2i(num3) : num2 - 1;
      float u = num3 - (float) i;
      return CatmullRomSpline.calculate(@out, i, u, points, num1 != 0, tmp);
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;F[TT;ZTT;)TT;")]
    [LineNumberTable(new byte[] {159, 125, 130, 108, 103, 117, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector derivative(
      Vector @out,
      float t,
      Vector[] points,
      bool continuous,
      Vector tmp)
    {
      int num1 = continuous ? 1 : 0;
      int num2 = num1 == 0 ? points.Length - 3 : points.Length;
      float num3 = t * (float) num2;
      int i = (double) t < 1.0 ? ByteCodeHelper.f2i(num3) : num2 - 1;
      float u = num3 - (float) i;
      return CatmullRomSpline.derivative(@out, i, u, points, num1 != 0, tmp);
    }

    [Signature("(TT;II)F")]
    [LineNumberTable(168)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float approximate(Vector @in, int start, int count) => this.approximate(@in, this.nearest(@in, start, count));

    [LineNumberTable(new byte[] {160, 91, 102, 102, 114, 122, 250, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float approxLength(int samples)
    {
      float num = 0.0f;
      for (int index = 0; index < samples; ++index)
      {
        this.tmp2.set(this.tmp3);
        this.valueAt(this.tmp3, (float) index / ((float) samples - 1f));
        if (index > 0)
          num += this.tmp2.dst(this.tmp3);
      }
      return num;
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float locate(object obj) => this.locate((Vector) obj);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float approximate(object obj) => this.approximate((Vector) obj);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object valueAt(object obj, float f) => (object) this.valueAt((Vector) obj, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object derivativeAt(object obj, float f) => (object) this.derivativeAt((Vector) obj, f);
  }
}
