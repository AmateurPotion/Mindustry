// Decompiled with JetBrains decompiler
// Type: arc.math.geom.BSpline
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.math.geom
{
  [Signature("<T::Larc/math/geom/Vector<TT;>;>Ljava/lang/Object;Larc/math/geom/Path<TT;>;")]
  public class BSpline : Object, Path
  {
    private const float d6 = 0.1666667f;
    [Signature("[TT;")]
    public Vector[] controlPoints;
    [Signature("Larc/struct/Seq<TT;>;")]
    public Seq knots;
    public int degree;
    public bool continuous;
    public int spanCount;
    [Signature("TT;")]
    private Vector tmp;
    [Signature("TT;")]
    private Vector tmp2;
    [Signature("TT;")]
    private Vector tmp3;

    [Signature("([TT;IZ)Larc/math/geom/BSpline;")]
    [LineNumberTable(new byte[] {159, 96, 98, 118, 118, 118, 103, 103, 103, 113, 104, 147, 108, 146, 107, 63, 31, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BSpline set(Vector[] controlPoints, int degree, bool continuous)
    {
      int num = continuous ? 1 : 0;
      if (this.tmp == null)
        this.tmp = controlPoints[0].cpy();
      if (this.tmp2 == null)
        this.tmp2 = controlPoints[0].cpy();
      if (this.tmp3 == null)
        this.tmp3 = controlPoints[0].cpy();
      this.controlPoints = controlPoints;
      this.degree = degree;
      this.continuous = num != 0;
      this.spanCount = num == 0 ? controlPoints.Length - degree : controlPoints.Length;
      if (this.knots == null)
      {
        this.knots = new Seq(this.spanCount);
      }
      else
      {
        this.knots.clear();
        this.knots.ensureCapacity(this.spanCount);
      }
      for (int index = 0; index < this.spanCount; ++index)
        this.knots.add((object) BSpline.calculate(controlPoints[0].cpy(), num == 0 ? ByteCodeHelper.f2i((float) index + 0.5f * (float) degree) : index, 0.0f, controlPoints, degree, num != 0, this.tmp));
      return this;
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;IF[TT;ZTT;)TT;")]
    [LineNumberTable(new byte[] {159, 124, 67, 99, 106, 103, 103, 127, 17, 127, 27, 105, 127, 48, 127, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector cubic(
      Vector @out,
      int i,
      float u,
      Vector[] points,
      bool continuous,
      Vector tmp)
    {
      int num1 = continuous ? 1 : 0;
      int length = points.Length;
      float num2 = 1f - u;
      float num3 = u * u;
      float num4 = num3 * u;
      @out.set(points[i]).scl((3f * num4 - 6f * num3 + 4f) * 0.1666667f);
      if (num1 != 0 || i > 0)
      {
        Vector vector1 = @out;
        Vector vector2 = tmp;
        Vector[] vectorArray = points;
        int num5 = length + i - 1;
        int num6 = length;
        int index = num6 != -1 ? num5 % num6 : 0;
        Vector v1 = vectorArray[index];
        Vector v2 = vector2.set(v1).scl(num2 * num2 * num2 * 0.1666667f);
        vector1.add(v2);
      }
      if (num1 != 0 || i < length - 1)
      {
        Vector vector1 = @out;
        Vector vector2 = tmp;
        Vector[] vectorArray = points;
        int num5 = i + 1;
        int num6 = length;
        int index = num6 != -1 ? num5 % num6 : 0;
        Vector v1 = vectorArray[index];
        Vector v2 = vector2.set(v1).scl((-3f * num4 + 3f * num3 + 3f * u + 1f) * 0.1666667f);
        vector1.add(v2);
      }
      if (num1 != 0 || i < length - 2)
      {
        Vector vector1 = @out;
        Vector vector2 = tmp;
        Vector[] vectorArray = points;
        int num5 = i + 2;
        int num6 = length;
        int index = num6 != -1 ? num5 % num6 : 0;
        Vector v1 = vectorArray[index];
        Vector v2 = vector2.set(v1).scl(num4 * 0.1666667f);
        vector1.add(v2);
      }
      return @out;
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;IF[TT;IZTT;)TT;")]
    [LineNumberTable(new byte[] {159, 103, 131, 101, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector calculate(
      Vector @out,
      int i,
      float u,
      Vector[] points,
      int degree,
      bool continuous,
      Vector tmp)
    {
      int num = continuous ? 1 : 0;
      return degree == 3 ? BSpline.cubic(@out, i, u, points, num != 0, tmp) : @out;
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;IF[TT;IZTT;)TT;")]
    [LineNumberTable(new byte[] {159, 98, 99, 140, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector derivative(
      Vector @out,
      int i,
      float u,
      Vector[] points,
      int degree,
      bool continuous,
      Vector tmp)
    {
      int num = continuous ? 1 : 0;
      return degree == 3 ? BSpline.cubic_derivative(@out, i, u, points, num != 0, tmp) : @out;
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;IF[TT;ZTT;)TT;")]
    [LineNumberTable(new byte[] {159, 118, 67, 99, 106, 103, 102, 127, 3, 127, 24, 127, 32, 127, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector cubic_derivative(
      Vector @out,
      int i,
      float u,
      Vector[] points,
      bool continuous,
      Vector tmp)
    {
      int num1 = continuous ? 1 : 0;
      int length = points.Length;
      float num2 = 1f - u;
      float num3 = u * u;
      double num4 = (double) (num3 * u);
      @out.set(points[i]).scl(1.5f * num3 - 2f * u);
      if (num1 != 0 || i > 0)
      {
        Vector vector1 = @out;
        Vector vector2 = tmp;
        Vector[] vectorArray = points;
        int num5 = length + i - 1;
        int num6 = length;
        int index = num6 != -1 ? num5 % num6 : 0;
        Vector v1 = vectorArray[index];
        Vector v2 = vector2.set(v1).scl(-0.5f * num2 * num2);
        vector1.add(v2);
      }
      if (num1 != 0 || i < length - 1)
      {
        Vector vector1 = @out;
        Vector vector2 = tmp;
        Vector[] vectorArray = points;
        int num5 = i + 1;
        int num6 = length;
        int index = num6 != -1 ? num5 % num6 : 0;
        Vector v1 = vectorArray[index];
        Vector v2 = vector2.set(v1).scl(-1.5f * num3 + u + 0.5f);
        vector1.add(v2);
      }
      if (num1 != 0 || i < length - 2)
      {
        Vector vector1 = @out;
        Vector vector2 = tmp;
        Vector[] vectorArray = points;
        int num5 = i + 2;
        int num6 = length;
        int index = num6 != -1 ? num5 % num6 : 0;
        Vector v1 = vectorArray[index];
        Vector v2 = vector2.set(v1).scl(0.5f * num3);
        vector1.add(v2);
      }
      return @out;
    }

    [Signature("(TT;IF)TT;")]
    [LineNumberTable(215)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector valueAt(Vector @out, int span, float u) => BSpline.calculate(@out, !this.continuous ? span + ByteCodeHelper.f2i((float) this.degree * 0.5f) : span, u, this.controlPoints, this.degree, this.continuous, this.tmp);

    [Signature("(TT;IF)TT;")]
    [LineNumberTable(229)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector derivativeAt(Vector @out, int span, float u) => BSpline.derivative(@out, !this.continuous ? span + ByteCodeHelper.f2i((float) this.degree * 0.5f) : span, u, this.controlPoints, this.degree, this.continuous, this.tmp);

    [Signature("(TT;II)I")]
    [LineNumberTable(new byte[] {160, 125, 100, 108, 114, 121, 102, 116, 122, 101, 99, 226, 59, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int nearest(Vector @in, int start, int count)
    {
      while (start < 0)
        start += this.spanCount;
      int num1 = start;
      int spanCount1 = this.spanCount;
      int index1 = spanCount1 != -1 ? num1 % spanCount1 : 0;
      float num2 = @in.dst2((Vector) this.knots.get(index1));
      for (int index2 = 1; index2 < count; ++index2)
      {
        int num3 = start + index2;
        int spanCount2 = this.spanCount;
        int index3 = spanCount2 != -1 ? num3 % spanCount2 : 0;
        float num4 = @in.dst2((Vector) this.knots.get(index3));
        if ((double) num4 < (double) num2)
        {
          num2 = num4;
          index1 = index3;
        }
      }
      return index1;
    }

    [Signature("(TT;)I")]
    [LineNumberTable(234)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int nearest(Vector @in) => this.nearest(@in, 0, this.spanCount);

    [Signature("(TT;I)F")]
    [LineNumberTable(new byte[] {160, 150, 98, 114, 127, 3, 127, 5, 106, 138, 102, 99, 99, 133, 99, 99, 99, 146, 108, 108, 108, 108, 119, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float approximate(Vector @in, int near)
    {
      int index1 = near;
      Vector vector1 = (Vector) this.knots.get(index1);
      Vector v1 = (Vector) this.knots.get(index1 <= 0 ? this.spanCount - 1 : index1 - 1);
      Seq knots = this.knots;
      int num1 = index1 + 1;
      int spanCount = this.spanCount;
      int index2 = spanCount != -1 ? num1 % spanCount : 0;
      Vector v2 = (Vector) knots.get(index2);
      float num2 = @in.dst2(v1);
      Vector v3;
      Vector v4;
      Vector vector2;
      if ((double) @in.dst2(v2) < (double) num2)
      {
        v3 = vector1;
        v4 = v2;
        vector2 = @in;
      }
      else
      {
        v3 = v1;
        v4 = vector1;
        vector2 = @in;
        index1 = index1 <= 0 ? this.spanCount - 1 : index1 - 1;
      }
      float num3 = v3.dst2(v4);
      float num4 = vector2.dst2(v4);
      float num5 = vector2.dst2(v3);
      float num6 = (float) Math.sqrt((double) num3);
      float num7 = (num4 + num3 - num5) / (2f * num6);
      float num8 = Mathf.clamp((num6 - num7) / num6, 0.0f, 1f);
      return ((float) index1 + num8) / (float) this.spanCount;
    }

    [Signature("(TT;)F")]
    [LineNumberTable(256)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float approximate(Vector v) => this.approximate(v, this.nearest(v));

    [Signature("(TT;F)TT;")]
    [LineNumberTable(new byte[] {160, 92, 103, 103, 117, 102})]
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
    [LineNumberTable(293)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float locate(Vector v) => this.approximate(v);

    [Signature("(TT;F)TT;")]
    [LineNumberTable(new byte[] {160, 106, 103, 103, 117, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector derivativeAt(Vector @out, float t)
    {
      int spanCount = this.spanCount;
      float num = t * (float) spanCount;
      int span = (double) t < 1.0 ? ByteCodeHelper.f2i(num) : spanCount - 1;
      float u = num - (float) span;
      return this.derivativeAt(@out, span, u);
    }

    [LineNumberTable(new byte[] {159, 160, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BSpline()
    {
    }

    [Signature("([TT;IZ)V")]
    [LineNumberTable(new byte[] {159, 137, 66, 104, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BSpline(Vector[] controlPoints, int degree, bool continuous)
    {
      int num = continuous ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      BSpline bspline = this;
      this.set(controlPoints, degree, num != 0);
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;F[TT;ZTT;)TT;")]
    [LineNumberTable(new byte[] {159, 134, 162, 108, 103, 117, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector cubic(
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
      return BSpline.cubic(@out, i, u, points, num1 != 0, tmp);
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;F[TT;ZTT;)TT;")]
    [LineNumberTable(new byte[] {159, 129, 98, 108, 103, 117, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector cubic_derivative(
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
      return BSpline.cubic(@out, i, u, points, num1 != 0, tmp);
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;F[TT;IZTT;)TT;")]
    [LineNumberTable(new byte[] {159, 113, 163, 108, 103, 117, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector calculate(
      Vector @out,
      float t,
      Vector[] points,
      int degree,
      bool continuous,
      Vector tmp)
    {
      int num1 = continuous ? 1 : 0;
      int num2 = num1 == 0 ? points.Length - degree : points.Length;
      float num3 = t * (float) num2;
      int i = (double) t < 1.0 ? ByteCodeHelper.f2i(num3) : num2 - 1;
      float u = num3 - (float) i;
      return BSpline.calculate(@out, i, u, points, degree, num1 != 0, tmp);
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;F[TT;IZTT;)TT;")]
    [LineNumberTable(new byte[] {159, 108, 131, 108, 103, 117, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector derivative(
      Vector @out,
      float t,
      Vector[] points,
      int degree,
      bool continuous,
      Vector tmp)
    {
      int num1 = continuous ? 1 : 0;
      int num2 = num1 == 0 ? points.Length - degree : points.Length;
      float num3 = t * (float) num2;
      int i = (double) t < 1.0 ? ByteCodeHelper.f2i(num3) : num2 - 1;
      float u = num3 - (float) i;
      return BSpline.derivative(@out, i, u, points, degree, num1 != 0, tmp);
    }

    [Signature("(TT;II)F")]
    [LineNumberTable(260)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float approximate(Vector @in, int start, int count) => this.approximate(@in, this.nearest(@in, start, count));

    [LineNumberTable(new byte[] {160, 184, 102, 102, 114, 122, 250, 61, 230, 69})]
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
    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float locate(object obj) => this.locate((Vector) obj);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float approximate(object obj) => this.approximate((Vector) obj);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object valueAt(object obj, float f) => (object) this.valueAt((Vector) obj, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object derivativeAt(object obj, float f) => (object) this.derivativeAt((Vector) obj, f);
  }
}
