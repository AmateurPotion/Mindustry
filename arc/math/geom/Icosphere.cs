// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Icosphere
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math.geom
{
  public class Icosphere : Object
  {
    [Modifiers]
    private static float t;
    [Modifiers]
    private static Vec3[] baseVert;
    [Modifiers]
    private static int[][] baseFace;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 157, 134, 116, 63, 1, 198, 119, 62, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static MeshResult create(int level)
    {
      MeshResult meshResult = new MeshResult();
      Vec3[] baseVert = Icosphere.baseVert;
      int length1 = baseVert.Length;
      for (int index = 0; index < length1; ++index)
      {
        Vec3 vec3 = baseVert[index];
        meshResult.vertices.add(vec3.x, vec3.y, vec3.z);
      }
      int[][] baseFace = Icosphere.baseFace;
      int length2 = baseFace.Length;
      for (int index = 0; index < length2; ++index)
      {
        int[] numArray = baseFace[index];
        Icosphere.subdivide(numArray[0], numArray[1], numArray[2], meshResult.vertices, meshResult.indices, level);
      }
      return meshResult;
    }

    [LineNumberTable(new byte[] {159, 171, 100, 143, 119, 123, 123, 106, 106, 146, 120, 124, 124, 109, 106, 149, 120, 124, 124, 109, 106, 149, 113, 113, 113, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void subdivide(
      [In] int obj0,
      [In] int obj1,
      [In] int obj2,
      [In] FloatSeq obj3,
      [In] IntSeq obj4,
      [In] int obj5)
    {
      if (obj5 == 0)
      {
        obj4.add(obj0, obj1, obj2);
      }
      else
      {
        float x1 = obj3.get(3 * obj0) + obj3.get(3 * obj1);
        float y1 = obj3.get(3 * obj0 + 1) + obj3.get(3 * obj1 + 1);
        float z1 = obj3.get(3 * obj0 + 2) + obj3.get(3 * obj1 + 2);
        float num1 = Vec3.len(x1, y1, z1);
        int num2 = obj3.size / 3;
        obj3.add(x1 / num1, y1 / num1, z1 / num1);
        float x2 = obj3.get(3 * obj2) + obj3.get(3 * obj1);
        float y2 = obj3.get(3 * obj2 + 1) + obj3.get(3 * obj1 + 1);
        float z2 = obj3.get(3 * obj2 + 2) + obj3.get(3 * obj1 + 2);
        float num3 = Vec3.len(x2, y2, z2);
        int num4 = obj3.size / 3;
        obj3.add(x2 / num3, y2 / num3, z2 / num3);
        float x3 = obj3.get(3 * obj0) + obj3.get(3 * obj2);
        float y3 = obj3.get(3 * obj0 + 1) + obj3.get(3 * obj2 + 1);
        float z3 = obj3.get(3 * obj0 + 2) + obj3.get(3 * obj2 + 2);
        float num5 = Vec3.len(x3, y3, z3);
        int num6 = obj3.size / 3;
        obj3.add(x3 / num5, y3 / num5, z3 / num5);
        Icosphere.subdivide(obj0, num2, num6, obj3, obj4, obj5 - 1);
        Icosphere.subdivide(num2, obj1, num4, obj3, obj4, obj5 - 1);
        Icosphere.subdivide(num6, num4, obj2, obj3, obj4, obj5 - 1);
        Icosphere.subdivide(num2, num4, num6, obj3, obj4, obj5 - 1);
      }
    }

    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Vec3 v([In] float obj0, [In] float obj1, [In] float obj2) => new Vec3(obj0, obj1, obj2).nor();

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Icosphere()
    {
    }

    [LineNumberTable(new byte[] {159, 141, 173, 126, 127, 160, 202})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Icosphere()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.math.geom.Icosphere"))
        return;
      Icosphere.t = (Mathf.sqrt(5f) - 1f) / 2f;
      Icosphere.baseVert = new Vec3[12]
      {
        Icosphere.v(-1f, -Icosphere.t, 0.0f),
        Icosphere.v(0.0f, 1f, Icosphere.t),
        Icosphere.v(0.0f, 1f, -Icosphere.t),
        Icosphere.v(1f, Icosphere.t, 0.0f),
        Icosphere.v(1f, -Icosphere.t, 0.0f),
        Icosphere.v(0.0f, -1f, -Icosphere.t),
        Icosphere.v(0.0f, -1f, Icosphere.t),
        Icosphere.v(Icosphere.t, 0.0f, 1f),
        Icosphere.v(-Icosphere.t, 0.0f, 1f),
        Icosphere.v(Icosphere.t, 0.0f, -1f),
        Icosphere.v(-Icosphere.t, 0.0f, -1f),
        Icosphere.v(-1f, Icosphere.t, 0.0f)
      };
      Icosphere.baseFace = new int[20][]
      {
        new int[3]{ 3, 7, 1 },
        new int[3]{ 4, 7, 3 },
        new int[3]{ 6, 7, 4 },
        new int[3]{ 8, 7, 6 },
        new int[3]{ 7, 8, 1 },
        new int[3]{ 9, 4, 3 },
        new int[3]{ 2, 9, 3 },
        new int[3]{ 2, 3, 1 },
        new int[3]{ 11, 2, 1 },
        new int[3]{ 10, 2, 11 },
        new int[3]{ 10, 9, 2 },
        new int[3]{ 9, 5, 4 },
        new int[3]{ 6, 4, 5 },
        new int[3]{ 0, 6, 5 },
        new int[3]{ 0, 11, 8 },
        new int[3]{ 11, 1, 8 },
        new int[3]{ 10, 0, 5 },
        new int[3]{ 10, 5, 9 },
        new int[3]{ 0, 8, 6 },
        new int[3]{ 0, 10, 11 }
      };
    }
  }
}
