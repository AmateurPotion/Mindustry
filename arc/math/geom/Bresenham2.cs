// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Bresenham2
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.math.geom
{
  public class Bresenham2 : Object
  {
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/math/geom/Point2;>;")]
    private Seq points;
    [Modifiers]
    [Signature("Larc/util/pooling/Pool<Larc/math/geom/Point2;>;")]
    private Pool pool;

    [LineNumberTable(new byte[] {159, 170, 105, 137, 105, 137, 165, 105, 138, 102, 102, 102, 165, 101, 102, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void line(int startX, int startY, int endX, int endY, Intc2 consumer)
    {
      int num1 = Math.abs(endX - startX);
      int num2 = Math.abs(endY - startY);
      int num3 = startX >= endX ? -1 : 1;
      int num4 = startY >= endY ? -1 : 1;
      int num5 = num1 - num2;
      while (true)
      {
        int num6;
        do
        {
          consumer.get(startX, startY);
          if (startX != endX || startY != endY)
          {
            num6 = 2 * num5;
            if (num6 > -num2)
            {
              num5 -= num2;
              startX += num3;
            }
          }
          else
            goto label_2;
        }
        while (num6 >= num1);
        num5 += num1;
        startY += num4;
      }
label_2:;
    }

    [Signature("(IIIILarc/util/pooling/Pool<Larc/math/geom/Point2;>;Larc/struct/Seq<Larc/math/geom/Point2;>;)Larc/struct/Seq<Larc/math/geom/Point2;>;")]
    [LineNumberTable(new byte[] {91, 105, 107, 105, 106, 133, 154, 137, 110, 102, 135, 102, 165, 156})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq lineNoDiagonal(
      int startX,
      int startY,
      int endX,
      int endY,
      Pool pool,
      Seq output)
    {
      int num1 = Math.abs(endX - startX);
      int num2 = -Math.abs(endY - startY);
      int num3 = startX >= endX ? -1 : 1;
      int num4 = startY >= endY ? -1 : 1;
      int num5 = num1 + num2;
      output.add((object) ((Point2) pool.obtain()).set(startX, startY));
      while (startX != endX || startY != endY)
      {
        if (2 * num5 - num2 > num1 - 2 * num5)
        {
          num5 += num2;
          startX += num3;
        }
        else
        {
          num5 += num1;
          startY += num4;
        }
        output.add((object) ((Point2) pool.obtain()).set(startX, startY));
      }
      return output;
    }

    [LineNumberTable(new byte[] {159, 158, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Bresenham2()
    {
      Bresenham2 bresenham2 = this;
      this.points = new Seq();
      this.pool = Pools.get((Class) ClassLiteral<Point2>.Value, (Prov) new Bresenham2.__\u003C\u003EAnon0());
    }

    [Signature("(IIII)Larc/struct/Seq<Larc/math/geom/Point2;>;")]
    [LineNumberTable(new byte[] {22, 113, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq line(int startX, int startY, int endX, int endY)
    {
      this.pool.freeAll(this.points);
      this.points.clear();
      return this.line(startX, startY, endX, endY, this.pool, this.points);
    }

    [Signature("(IIIILarc/util/pooling/Pool<Larc/math/geom/Point2;>;Larc/struct/Seq<Larc/math/geom/Point2;>;)Larc/struct/Seq<Larc/math/geom/Point2;>;")]
    [LineNumberTable(new byte[] {39, 100, 101, 106, 100, 98, 101, 100, 98, 131, 100, 100, 102, 104, 104, 102, 104, 104, 100, 101, 103, 131, 102, 108, 110, 106, 105, 103, 102, 103, 101, 135, 102, 230, 53, 235, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq line(
      int startX,
      int startY,
      int endX,
      int endY,
      Pool pool,
      Seq output)
    {
      int num1 = endX - startX;
      int num2 = endY - startY;
      int num3 = 0;
      int num4 = 0;
      int num5 = 0;
      int num6 = 0;
      if (num1 < 0)
      {
        num3 = -1;
        num5 = -1;
      }
      else if (num1 > 0)
      {
        num3 = 1;
        num5 = 1;
      }
      if (num2 < 0)
        num4 = -1;
      else if (num2 > 0)
        num4 = 1;
      int num7 = Math.abs(num1);
      int num8 = Math.abs(num2);
      if (num7 <= num8)
      {
        num7 = Math.abs(num2);
        num8 = Math.abs(num1);
        if (num2 < 0)
          num6 = -1;
        else if (num2 > 0)
          num6 = 1;
        num5 = 0;
      }
      int num9 = num7 >> 1;
      for (int index = 0; index <= num7; ++index)
      {
        Point2 point2 = (Point2) pool.obtain();
        point2.set(startX, startY);
        output.add((object) point2);
        num9 += num8;
        if (num9 > num7)
        {
          num9 -= num7;
          startX += num3;
          startY += num4;
        }
        else
        {
          startX += num5;
          startY += num6;
        }
      }
      return output;
    }

    [Signature("(Larc/math/geom/Point2;Larc/math/geom/Point2;)Larc/struct/Seq<Larc/math/geom/Point2;>;")]
    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq line(Point2 start, Point2 end) => this.line(start.x, start.y, end.x, end.y);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new Point2();
    }
  }
}
