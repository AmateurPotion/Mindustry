// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Position
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math.geom
{
  public interface Position
  {
    float getX();

    float getY();

    [Modifiers]
    float angleTo(Position other);

    [LineNumberTable(13)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static float \u003Cdefault\u003EangleTo([In] Position obj0, [In] Position obj1) => Angles.angle(obj0.getX(), obj0.getY(), obj1.getX(), obj1.getY());

    [Modifiers]
    bool within(Position other, float dst);

    [LineNumberTable(41)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003Ewithin([In] Position obj0, [In] Position obj1, [In] float obj2) => obj0.within(obj1.getX(), obj1.getY(), obj2);

    [Modifiers]
    float dst(float x, float y);

    [LineNumberTable(new byte[] {159, 171, 108, 108})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static float \u003Cdefault\u003Edst([In] Position obj0, [In] float obj1, [In] float obj2)
    {
      float num1 = obj0.getX() - obj1;
      float num2 = obj0.getY() - obj2;
      return Mathf.sqrt(num1 * num1 + num2 * num2);
    }

    [Modifiers]
    float angleTo(float x, float y);

    [LineNumberTable(17)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static float \u003Cdefault\u003EangleTo([In] Position obj0, [In] float obj1, [In] float obj2) => Angles.angle(obj0.getX(), obj0.getY(), obj1, obj2);

    [Modifiers]
    bool within(float x, float y, float dst);

    [LineNumberTable(45)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003Ewithin([In] Position obj0, [In] float obj1, [In] float obj2, [In] float obj3) => (double) Mathf.dst2(obj0.getX(), obj0.getY(), obj1, obj2) < (double) (obj3 * obj3);

    [Modifiers]
    float dst(Position other);

    [LineNumberTable(25)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static float \u003Cdefault\u003Edst([In] Position obj0, [In] Position obj1) => obj0.dst(obj1.getX(), obj1.getY());

    [Modifiers]
    float dst2(Position other);

    [LineNumberTable(21)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static float \u003Cdefault\u003Edst2([In] Position obj0, [In] Position obj1) => obj0.dst2(obj1.getX(), obj1.getY());

    [Modifiers]
    float dst2(float x, float y);

    [LineNumberTable(new byte[] {159, 177, 108, 108})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static float \u003Cdefault\u003Edst2([In] Position obj0, [In] float obj1, [In] float obj2)
    {
      float num1 = obj0.getX() - obj1;
      float num2 = obj0.getY() - obj2;
      return num1 * num1 + num2 * num2;
    }

    [HideFromJava]
    static class __DefaultMethods
    {
      public static float angleTo([In] Position obj0, [In] Position obj1)
      {
        Position position = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(position, ToString);
        return Position.\u003Cdefault\u003EangleTo(position, obj1);
      }

      public static float angleTo([In] Position obj0, [In] float obj1, [In] float obj2)
      {
        Position position = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(position, ToString);
        return Position.\u003Cdefault\u003EangleTo(position, obj1, obj2);
      }

      public static float dst2([In] Position obj0, [In] Position obj1)
      {
        Position position = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(position, ToString);
        return Position.\u003Cdefault\u003Edst2(position, obj1);
      }

      public static float dst([In] Position obj0, [In] Position obj1)
      {
        Position position = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(position, ToString);
        return Position.\u003Cdefault\u003Edst(position, obj1);
      }

      public static float dst([In] Position obj0, [In] float obj1, [In] float obj2)
      {
        Position position = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(position, ToString);
        return Position.\u003Cdefault\u003Edst(position, obj1, obj2);
      }

      public static float dst2([In] Position obj0, [In] float obj1, [In] float obj2)
      {
        Position position = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(position, ToString);
        return Position.\u003Cdefault\u003Edst2(position, obj1, obj2);
      }

      public static bool within([In] Position obj0, [In] Position obj1, [In] float obj2)
      {
        Position position = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(position, ToString);
        return Position.\u003Cdefault\u003Ewithin(position, obj1, obj2);
      }

      public static bool within([In] Position obj0, [In] float obj1, [In] float obj2, [In] float obj3)
      {
        Position position = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(position, ToString);
        return Position.\u003Cdefault\u003Ewithin(position, obj1, obj2, obj3);
      }
    }
  }
}
