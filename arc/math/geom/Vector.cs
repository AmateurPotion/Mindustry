// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Vector
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math.geom
{
  [Signature("<T::Larc/math/geom/Vector<TT;>;>Ljava/lang/Object;")]
  public interface Vector
  {
    [Signature("(TT;)TT;")]
    Vector set(Vector v);

    [Signature("(F)TT;")]
    Vector scl(float f);

    [Signature("(TT;)TT;")]
    Vector add(Vector v);

    [Signature("()TT;")]
    Vector cpy();

    [Signature("(TT;)F")]
    float dst2(Vector v);

    [Signature("(TT;)F")]
    float dst(Vector v);

    [Signature("(TT;)TT;")]
    Vector sub(Vector v);

    [Signature("(TT;)TT;")]
    Vector scl(Vector v);

    float len();

    float len2();

    [Signature("(F)TT;")]
    Vector limit(float f);

    [Signature("(F)TT;")]
    Vector limit2(float f);

    [Signature("(F)TT;")]
    Vector setLength(float f);

    [Signature("(F)TT;")]
    Vector setLength2(float f);

    [Signature("(FF)TT;")]
    Vector clamp(float f1, float f2);

    [Signature("()TT;")]
    Vector nor();

    [Signature("(TT;)F")]
    float dot(Vector v);

    [Signature("(TT;)TT;")]
    Vector div(Vector v);

    [Signature("(TT;F)TT;")]
    Vector lerp(Vector v, float f);

    [Signature("(TT;FLarc/math/Interp;)TT;")]
    Vector interpolate(Vector v, float f, Interp i);

    [Signature("()TT;")]
    Vector setToRandomDirection();

    bool isUnit();

    bool isUnit(float f);

    bool isZero();

    bool isZero(float f);

    [Signature("(TT;F)Z")]
    bool isOnLine(Vector v, float f);

    [Signature("(TT;)Z")]
    bool isOnLine(Vector v);

    [Signature("(TT;F)Z")]
    bool isCollinear(Vector v, float f);

    [Signature("(TT;)Z")]
    bool isCollinear(Vector v);

    [Signature("(TT;F)Z")]
    bool isCollinearOpposite(Vector v, float f);

    [Signature("(TT;)Z")]
    bool isCollinearOpposite(Vector v);

    [Signature("(TT;)Z")]
    bool isPerpendicular(Vector v);

    [Signature("(TT;F)Z")]
    bool isPerpendicular(Vector v, float f);

    [Signature("(TT;)Z")]
    bool hasSameDirection(Vector v);

    [Signature("(TT;)Z")]
    bool hasOppositeDirection(Vector v);

    [Signature("(TT;F)Z")]
    bool epsilonEquals(Vector v, float f);

    [Signature("(TT;F)TT;")]
    Vector mulAdd(Vector v, float f);

    [Signature("(TT;TT;)TT;")]
    Vector mulAdd(Vector v1, Vector v2);

    [Signature("()TT;")]
    Vector setZero();

    [Modifiers]
    [Signature("(TT;)TT;")]
    Vector plus(Vector other);

    [LineNumberTable(238)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Vector \u003Cdefault\u003Eplus([In] Vector obj0, [In] Vector obj1) => obj0.add(obj1);

    [Modifiers]
    [Signature("(TT;)TT;")]
    Vector minus(Vector other);

    [LineNumberTable(242)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Vector \u003Cdefault\u003Eminus([In] Vector obj0, [In] Vector obj1) => obj0.sub(obj1);

    [Modifiers]
    [Signature("()TT;")]
    Vector unaryMinus();

    [LineNumberTable(246)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Vector \u003Cdefault\u003EunaryMinus([In] Vector obj0) => obj0.scl(-1f);

    [Modifiers]
    [Signature("(TT;)TT;")]
    Vector times(Vector other);

    [LineNumberTable(250)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Vector \u003Cdefault\u003Etimes([In] Vector obj0, [In] Vector obj1) => obj0.scl(obj1);

    [HideFromJava]
    static class __DefaultMethods
    {
      public static Vector plus([In] Vector obj0, [In] Vector obj1)
      {
        Vector vector = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(vector, ToString);
        return Vector.\u003Cdefault\u003Eplus(vector, obj1);
      }

      public static Vector minus([In] Vector obj0, [In] Vector obj1)
      {
        Vector vector = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(vector, ToString);
        return Vector.\u003Cdefault\u003Eminus(vector, obj1);
      }

      public static Vector unaryMinus([In] Vector obj0)
      {
        Vector vector = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(vector, ToString);
        return Vector.\u003Cdefault\u003EunaryMinus(vector);
      }

      public static Vector times([In] Vector obj0, [In] Vector obj1)
      {
        Vector vector = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(vector, ToString);
        return Vector.\u003Cdefault\u003Etimes(vector, obj1);
      }
    }
  }
}
