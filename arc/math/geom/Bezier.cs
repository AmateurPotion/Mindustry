// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Bezier
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.math.geom
{
  [Signature("<T::Larc/math/geom/Vector<TT;>;>Ljava/lang/Object;Larc/math/geom/Path<TT;>;")]
  public class Bezier : Object, Path
  {
    [Signature("Larc/struct/Seq<TT;>;")]
    public Seq points;
    [Signature("TT;")]
    private Vector tmp;
    [Signature("TT;")]
    private Vector tmp2;
    [Signature("TT;")]
    private Vector tmp3;

    [Signature("(Larc/struct/Seq<TT;>;)Larc/math/geom/Bezier;")]
    [LineNumberTable(149)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Bezier set(Seq points) => this.set(points, 0, points.size);

    [Signature("(TT;F)TT;")]
    [LineNumberTable(new byte[] {115, 108, 100, 127, 23, 100, 127, 37, 127, 56})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector valueAt(Vector @out, float t)
    {
      switch (this.points.size)
      {
        case 2:
          Bezier.linear(@out, t, (Vector) this.points.get(0), (Vector) this.points.get(1), this.tmp);
          break;
        case 3:
          Bezier.quadratic(@out, t, (Vector) this.points.get(0), (Vector) this.points.get(1), (Vector) this.points.get(2), this.tmp);
          break;
        case 4:
          Bezier.cubic(@out, t, (Vector) this.points.get(0), (Vector) this.points.get(1), (Vector) this.points.get(2), (Vector) this.points.get(3), this.tmp);
          break;
      }
      return @out;
    }

    [Signature("([TT;)Larc/math/geom/Bezier;")]
    [LineNumberTable(134)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Bezier set(params Vector[] points) => this.set(points, 0, points.Length);

    [Signature("([TT;II)Larc/math/geom/Bezier;")]
    [LineNumberTable(new byte[] {88, 104, 112, 118, 118, 118, 108, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Bezier set(Vector[] points, int offset, int length)
    {
      if (length < 2 || length > 4)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Only first, second and third degree Bezier curves are supported.");
      }
      if (this.tmp == null)
        this.tmp = points[0].cpy();
      if (this.tmp2 == null)
        this.tmp2 = points[0].cpy();
      if (this.tmp3 == null)
        this.tmp3 = points[0].cpy();
      this.points.clear();
      this.points.addAll((object[]) points, offset, length);
      return this;
    }

    [Signature("(Larc/struct/Seq<TT;>;II)Larc/math/geom/Bezier;")]
    [LineNumberTable(new byte[] {103, 104, 112, 127, 0, 127, 0, 127, 0, 108, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Bezier set(Seq points, int offset, int length)
    {
      if (length < 2 || length > 4)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Only first, second and third degree Bezier curves are supported.");
      }
      if (this.tmp == null)
        this.tmp = ((Vector) points.get(0)).cpy();
      if (this.tmp2 == null)
        this.tmp2 = ((Vector) points.get(0)).cpy();
      if (this.tmp3 == null)
        this.tmp3 = ((Vector) points.get(0)).cpy();
      this.points.clear();
      this.points.addAll(points, offset, length);
      return this;
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;FTT;TT;TT;)TT;")]
    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector linear(Vector @out, float t, Vector p0, Vector p1, Vector tmp) => @out.set(p0).scl(1f - t).add(tmp.set(p1).scl(t));

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;FTT;TT;TT;TT;)TT;")]
    [LineNumberTable(new byte[] {21, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector quadratic(
      Vector @out,
      float t,
      Vector p0,
      Vector p1,
      Vector p2,
      Vector tmp)
    {
      float num = 1f - t;
      return @out.set(p0).scl(num * num).add(tmp.set(p1).scl(2f * num * t)).add(tmp.set(p2).scl(t * t));
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;FTT;TT;TT;TT;TT;)TT;")]
    [LineNumberTable(new byte[] {56, 106, 101, 103, 127, 49, 52})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector cubic(
      Vector @out,
      float t,
      Vector p0,
      Vector p1,
      Vector p2,
      Vector p3,
      Vector tmp)
    {
      float num1 = 1f - t;
      float num2 = num1 * num1;
      float num3 = t * t;
      return @out.set(p0).scl(num2 * num1).add(tmp.set(p1).scl(3f * num2 * t)).add(tmp.set(p2).scl(3f * num1 * num3)).add(tmp.set(p3).scl(num3 * t));
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;FTT;TT;TT;)TT;")]
    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector linearDerivative(
      Vector @out,
      float t,
      Vector p0,
      Vector p1,
      Vector tmp)
    {
      return @out.set(p1).sub(p0);
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;FTT;TT;TT;TT;)TT;")]
    [LineNumberTable(new byte[] {38, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector quadraticDerivative(
      Vector @out,
      float t,
      Vector p0,
      Vector p1,
      Vector p2,
      Vector tmp)
    {
      double num = (double) (1f - t);
      return @out.set(p1).sub(p0).scl(2f).scl(1f - t).add(tmp.set(p2).sub(p1).scl(t).scl(2f));
    }

    [Signature("<T::Larc/math/geom/Vector<TT;>;>(TT;FTT;TT;TT;TT;TT;)TT;")]
    [LineNumberTable(new byte[] {77, 106, 101, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vector cubicDerivative(
      Vector @out,
      float t,
      Vector p0,
      Vector p1,
      Vector p2,
      Vector p3,
      Vector tmp)
    {
      float num1 = 1f - t;
      float num2 = num1 * num1;
      float num3 = t * t;
      return @out.set(p1).sub(p0).scl(num2 * 3f).add(tmp.set(p2).sub(p1).scl(num1 * t * 6f)).add(tmp.set(p3).sub(p2).scl(num3 * 3f));
    }

    [Signature("(TT;)F")]
    [LineNumberTable(new byte[] {160, 74, 114, 126, 105, 105, 106, 107, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float approximate(Vector v)
    {
      Vector v1 = (Vector) this.points.get(0);
      Vector v2 = (Vector) this.points.get(this.points.size - 1);
      float num1 = v1.dst2(v2);
      float num2 = v.dst2(v2);
      float num3 = v.dst2(v1);
      float num4 = (float) Math.sqrt((double) num1);
      float num5 = (num2 + num1 - num3) / (2f * num4);
      return Mathf.clamp((num4 - num5) / num4, 0.0f, 1f);
    }

    [Signature("(TT;)F")]
    [LineNumberTable(201)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float locate(Vector v) => this.approximate(v);

    [Signature("(TT;F)TT;")]
    [LineNumberTable(new byte[] {126, 108, 100, 127, 23, 100, 127, 37, 127, 56})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector derivativeAt(Vector @out, float t)
    {
      switch (this.points.size)
      {
        case 2:
          Bezier.linearDerivative(@out, t, (Vector) this.points.get(0), (Vector) this.points.get(1), this.tmp);
          break;
        case 3:
          Bezier.quadraticDerivative(@out, t, (Vector) this.points.get(0), (Vector) this.points.get(1), (Vector) this.points.get(2), this.tmp);
          break;
        case 4:
          Bezier.cubicDerivative(@out, t, (Vector) this.points.get(0), (Vector) this.points.get(1), (Vector) this.points.get(2), (Vector) this.points.get(3), this.tmp);
          break;
      }
      return @out;
    }

    [LineNumberTable(new byte[] {159, 159, 232, 59, 235, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Bezier()
    {
      Bezier bezier = this;
      this.points = new Seq();
    }

    [Signature("([TT;)V")]
    [LineNumberTable(new byte[] {159, 162, 232, 56, 235, 73, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Bezier(params Vector[] points)
    {
      Bezier bezier = this;
      this.points = new Seq();
      this.set(points);
    }

    [Signature("([TT;II)V")]
    [LineNumberTable(new byte[] {159, 166, 232, 52, 235, 77, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Bezier(Vector[] points, int offset, int length)
    {
      Bezier bezier = this;
      this.points = new Seq();
      this.set(points, offset, length);
    }

    [Signature("(Larc/struct/Seq<TT;>;II)V")]
    [LineNumberTable(new byte[] {159, 169, 232, 49, 235, 80, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Bezier(Seq points, int offset, int length)
    {
      Bezier bezier = this;
      this.points = new Seq();
      this.set(points, offset, length);
    }

    [LineNumberTable(new byte[] {160, 92, 102, 102, 114, 122, 250, 61, 230, 69})]
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
    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float locate(object obj) => this.locate((Vector) obj);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float approximate(object obj) => this.approximate((Vector) obj);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object valueAt(object obj, float f) => (object) this.valueAt((Vector) obj, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object derivativeAt(object obj, float f) => (object) this.derivativeAt((Vector) obj, f);
  }
}
