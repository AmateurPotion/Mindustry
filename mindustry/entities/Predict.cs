// Decompiled with JetBrains decompiler
// Type: mindustry.entities.Predict
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.gen;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities
{
  public class Predict : Object
  {
    private static Vec2 vec;
    private static Vec2 vresult;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {5, 108, 127, 0, 107, 139, 127, 0, 107, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 intercept(Position src, Position dst, float v)
    {
      float dstvx = 0.0f;
      float dstvy = 0.0f;
      Position position1 = dst;
      Hitboxc hitboxc1;
      if (position1 is Hitboxc && object.ReferenceEquals((object) (hitboxc1 = (Hitboxc) position1), (object) (Hitboxc) position1))
      {
        dstvx += hitboxc1.deltaX();
        dstvy += hitboxc1.deltaY();
      }
      Position position2 = src;
      Hitboxc hitboxc2;
      if (position2 is Hitboxc && object.ReferenceEquals((object) (hitboxc2 = (Hitboxc) position2), (object) (Hitboxc) position2))
      {
        dstvx -= hitboxc2.deltaX();
        dstvy -= hitboxc2.deltaY();
      }
      return Predict.intercept(src.getX(), src.getY(), dst.getX(), dst.getY(), dstvx, dstvy, v);
    }

    [LineNumberTable(new byte[] {25, 98, 116, 116, 159, 18, 187, 118, 104, 104, 107, 191, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Vec2 quad([In] float obj0, [In] float obj1, [In] float obj2)
    {
      Vec2 vec2 = (Vec2) null;
      if ((double) Math.abs(obj0) < 1E-06)
      {
        if ((double) Math.abs(obj1) < 1E-06)
          vec2 = (double) Math.abs(obj2) >= 1E-06 ? (Vec2) null : Predict.vec.set(0.0f, 0.0f);
        else
          Predict.vec.set(-obj2 / obj1, -obj2 / obj1);
      }
      else
      {
        float x = obj1 * obj1 - 4f * obj0 * obj2;
        if ((double) x >= 0.0)
        {
          float num = Mathf.sqrt(x);
          obj0 = 2f * obj0;
          vec2 = Predict.vec.set((-obj1 - num) / obj0, (-obj1 + num) / obj0);
        }
      }
      return vec2;
    }

    [LineNumberTable(new byte[] {159, 169, 108, 108, 103, 167, 125, 118, 172, 171, 112, 103, 114, 108, 117, 105, 222})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 intercept(
      float srcx,
      float srcy,
      float dstx,
      float dsty,
      float dstvx,
      float dstvy,
      float v)
    {
      dstvx /= Time.delta;
      dstvy /= Time.delta;
      float num1 = dstx - srcx;
      float num2 = dsty - srcy;
      Vec2 vec2_1 = Predict.quad(dstvx * dstvx + dstvy * dstvy - v * v, 2f * (dstvx * num1 + dstvy * num2), num1 * num1 + num2 * num2);
      Vec2 vec2_2 = Predict.vresult.set(dstx, dsty);
      if (vec2_1 != null)
      {
        float x = vec2_1.x;
        float y = vec2_1.y;
        float num3 = Math.min(x, y);
        if ((double) num3 < 0.0)
          num3 = Math.max(x, y);
        if ((double) num3 > 0.0)
          vec2_2.set(dstx + dstvx * num3, dsty + dstvy * num3);
      }
      return vec2_2;
    }

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Predict()
    {
    }

    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 intercept(Hitboxc src, Hitboxc dst, float v) => Predict.intercept(((Posc) src).getX(), ((Posc) src).getY(), ((Posc) dst).getX(), ((Posc) dst).getY(), dst.deltaX() - src.deltaX() / (2f * Time.delta), dst.deltaY() - src.deltaX() / (2f * Time.delta), v);

    [LineNumberTable(new byte[] {159, 139, 77, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Predict()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.Predict"))
        return;
      Predict.vec = new Vec2();
      Predict.vresult = new Vec2();
    }
  }
}
