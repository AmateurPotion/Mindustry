// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.InverseKinematics
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.graphics
{
  public class InverseKinematics : Object
  {
    [Modifiers]
    private static Vec2[] mat1;
    [Modifiers]
    private static Vec2[] mat2;
    [Modifiers]
    private static Vec2 temp;
    [Modifiers]
    private static Vec2 temp2;
    [Modifiers]
    private static Vec2 at1;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 140, 162, 127, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool solve(float lengthA, float lengthB, Vec2 end, bool side, Vec2 result)
    {
      int num = side ? 1 : 0;
      InverseKinematics.at1.set(end).rotate(num == 0 ? -1f : 1f).setLength(lengthA + lengthB).add(end.x / 2f, end.y / 2f);
      return InverseKinematics.solve(lengthA, lengthB, end, InverseKinematics.at1, result);
    }

    [LineNumberTable(new byte[] {159, 158, 115, 127, 17, 127, 6, 127, 6, 127, 5, 105, 127, 16, 126, 159, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool solve(float lengthA, float lengthB, Vec2 end, Vec2 attractor, Vec2 result)
    {
      Vec2 v1 = InverseKinematics.mat2[0].set(end).nor();
      InverseKinematics.mat2[1].set(attractor).sub(InverseKinematics.temp2.set(v1).scl(attractor.dot(v1))).nor();
      InverseKinematics.mat1[0].set(InverseKinematics.mat2[0].x, InverseKinematics.mat2[1].x);
      InverseKinematics.mat1[1].set(InverseKinematics.mat2[0].y, InverseKinematics.mat2[1].y);
      result.set(InverseKinematics.mat2[0].dot(end), InverseKinematics.mat2[1].dot(end));
      float num = result.len();
      float x = Math.max(0.0f, Math.min(lengthA, (num + (lengthA * lengthA - lengthB * lengthB) / num) / 2f));
      Vec2 v2 = InverseKinematics.temp.set(x, Mathf.sqrt(lengthA * lengthA - x * x));
      result.set(InverseKinematics.mat1[0].dot(v2), InverseKinematics.mat1[1].dot(v2));
      return (double) x > 0.0 && (double) x < (double) lengthA;
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public InverseKinematics()
    {
    }

    [LineNumberTable(new byte[] {159, 141, 173, 127, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static InverseKinematics()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.graphics.InverseKinematics"))
        return;
      InverseKinematics.mat1 = new Vec2[2]
      {
        new Vec2(),
        new Vec2()
      };
      InverseKinematics.mat2 = new Vec2[2]
      {
        new Vec2(),
        new Vec2()
      };
      InverseKinematics.temp = new Vec2();
      InverseKinematics.temp2 = new Vec2();
      InverseKinematics.at1 = new Vec2();
    }
  }
}
