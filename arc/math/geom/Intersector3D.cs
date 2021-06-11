// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Intersector3D
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math.geom
{
  public class Intersector3D : Object
  {
    [Modifiers]
    private static Vec3 v0;
    [Modifiers]
    private static Vec3 v1;
    [Modifiers]
    private static Vec3 v2;
    [Modifiers]
    private static Plane p;
    [Modifiers]
    private static Vec3 i;
    internal static Vec3 best;
    internal static Vec3 tmp;
    internal static Vec3 tmp1;
    internal static Vec3 tmp2;
    internal static Vec3 tmp3;
    internal static Vec3 intersection;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {73, 127, 39, 104, 98, 159, 58, 103, 102, 99, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectRaySphere(Ray ray, Vec3 center, float radius, Vec3 intersection)
    {
      float num1 = ray.__\u003C\u003Edirection.dot(center.x - ray.__\u003C\u003Eorigin.x, center.y - ray.__\u003C\u003Eorigin.y, center.z - ray.__\u003C\u003Eorigin.z);
      if ((double) num1 < 0.0)
        return false;
      float num2 = center.dst2(ray.__\u003C\u003Eorigin.x + ray.__\u003C\u003Edirection.x * num1, ray.__\u003C\u003Eorigin.y + ray.__\u003C\u003Edirection.y * num1, ray.__\u003C\u003Eorigin.z + ray.__\u003C\u003Edirection.z * num1);
      float num3 = radius * radius;
      if ((double) num2 > (double) num3)
        return false;
      intersection?.set(ray.__\u003C\u003Edirection).scl(num1 - (float) Math.sqrt((double) (num3 - num2))).add(ray.__\u003C\u003Eorigin);
      return true;
    }

    [LineNumberTable(new byte[] {160, 152, 115, 115, 147, 127, 7, 127, 8, 101, 99, 99, 164, 127, 8, 127, 8, 102, 100, 100, 164, 127, 8, 127, 8, 102, 100, 100, 164, 115, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectRayBoundsFast(Ray ray, Vec3 center, Vec3 dimensions)
    {
      float num1 = 1f / ray.__\u003C\u003Edirection.x;
      float num2 = 1f / ray.__\u003C\u003Edirection.y;
      float num3 = 1f / ray.__\u003C\u003Edirection.z;
      float num4 = (center.x - dimensions.x * 0.5f - ray.__\u003C\u003Eorigin.x) * num1;
      float num5 = (center.x + dimensions.x * 0.5f - ray.__\u003C\u003Eorigin.x) * num1;
      if ((double) num4 > (double) num5)
      {
        float num6 = num4;
        num4 = num5;
        num5 = num6;
      }
      float num7 = (center.y - dimensions.y * 0.5f - ray.__\u003C\u003Eorigin.y) * num2;
      float num8 = (center.y + dimensions.y * 0.5f - ray.__\u003C\u003Eorigin.y) * num2;
      if ((double) num7 > (double) num8)
      {
        float num6 = num7;
        num7 = num8;
        num8 = num6;
      }
      float num9 = (center.z - dimensions.z * 0.5f - ray.__\u003C\u003Eorigin.z) * num3;
      float num10 = (center.z + dimensions.z * 0.5f - ray.__\u003C\u003Eorigin.z) * num3;
      if ((double) num9 > (double) num10)
      {
        float num6 = num9;
        num9 = num10;
        num10 = num6;
      }
      float num11 = Math.max(Math.max(num4, num7), num9);
      float num12 = Math.min(Math.min(num5, num8), num10);
      return (double) num12 >= 0.0 && (double) num12 >= (double) num11;
    }

    [LineNumberTable(new byte[] {26, 114, 146, 119, 105, 104, 109, 127, 13, 114, 130, 162, 137, 120, 110, 148, 106, 115, 152, 110, 139, 100, 105, 144, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectRayTriangle(
      Ray ray,
      Vec3 t1,
      Vec3 t2,
      Vec3 t3,
      Vec3 intersection)
    {
      Vec3 vector1 = Intersector3D.v0.set(t2).sub(t1);
      Vec3 vector2 = Intersector3D.v1.set(t3).sub(t1);
      Vec3 vector3 = Intersector3D.v2.set(ray.__\u003C\u003Edirection).crs(vector2);
      float num1 = vector1.dot(vector3);
      if (Mathf.zero(num1))
      {
        Intersector3D.p.set(t1, t2, t3);
        if (!object.ReferenceEquals((object) Intersector3D.p.testPoint(ray.__\u003C\u003Eorigin), (object) Plane.PlaneSide.__\u003C\u003EonPlane) || !Intersector.isInTriangle(ray.__\u003C\u003Eorigin, t1, t2, t3))
          return false;
        intersection?.set(ray.__\u003C\u003Eorigin);
        return true;
      }
      float num2 = 1f / num1;
      Vec3 vec3 = Intersector3D.i.set(ray.__\u003C\u003Eorigin).sub(t1);
      float num3 = vec3.dot(vector3) * num2;
      if ((double) num3 < 0.0 || (double) num3 > 1.0)
        return false;
      Vec3 vector4 = vec3.crs(vector1);
      float num4 = ray.__\u003C\u003Edirection.dot(vector4) * num2;
      if ((double) num4 < 0.0 || (double) (num3 + num4) > 1.0)
        return false;
      float distance = vector2.dot(vector4) * num2;
      if ((double) distance < 0.0)
        return false;
      if (intersection != null)
      {
        if ((double) distance <= 9.99999997475243E-07)
          intersection.set(ray.__\u003C\u003Eorigin);
        else
          ray.getEndPoint(intersection, distance);
      }
      return true;
    }

    [LineNumberTable(new byte[] {161, 173, 159, 9, 111, 113, 113, 102, 102, 102, 241, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void splitEdge(
      [In] float[] obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] Plane obj4,
      [In] float[] obj5,
      [In] int obj6)
    {
      float num1 = Intersector3D.intersectLinePlane(obj0[obj1], obj0[obj1 + 1], obj0[obj1 + 2], obj0[obj2], obj0[obj2 + 1], obj0[obj2 + 2], obj4, Intersector3D.intersection);
      obj5[obj6] = Intersector3D.intersection.x;
      obj5[obj6 + 1] = Intersector3D.intersection.y;
      obj5[obj6 + 2] = Intersector3D.intersection.z;
      for (int index = 3; index < obj3; ++index)
      {
        float num2 = obj0[obj1 + index];
        float num3 = obj0[obj2 + index];
        obj5[obj6 + index] = num2 + num1 * (num3 - num2);
      }
    }

    [LineNumberTable(new byte[] {1, 126, 113, 111, 104, 125, 121, 98, 116, 109, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float intersectLinePlane(
      float x,
      float y,
      float z,
      float x2,
      float y2,
      float z2,
      Plane plane,
      Vec3 intersection)
    {
      Vec3 vec3_1 = Intersector3D.tmp.set(x2, y2, z2).sub(x, y, z);
      Vec3 vec3_2 = Intersector3D.tmp2.set(x, y, z);
      float num = vec3_1.dot(plane.getNormal());
      if ((double) num != 0.0)
      {
        float scalar = -(vec3_2.dot(plane.getNormal()) + plane.getD()) / num;
        intersection?.set(vec3_2).add(vec3_1.scl(scalar));
        return scalar;
      }
      if (!object.ReferenceEquals((object) plane.testPoint(vec3_2), (object) Plane.PlaneSide.__\u003C\u003EonPlane))
        return -1f;
      intersection?.set(vec3_2);
      return 0.0f;
    }

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Intersector3D()
    {
    }

    [LineNumberTable(new byte[] {159, 172, 115, 104, 127, 1, 138, 127, 12, 98, 120, 112, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectRayPlane(Ray ray, Plane plane, Vec3 intersection)
    {
      float num = ray.__\u003C\u003Edirection.dot(plane.getNormal());
      if ((double) num != 0.0)
      {
        float scalar = -(ray.__\u003C\u003Eorigin.dot(plane.getNormal()) + plane.getD()) / num;
        if ((double) scalar < 0.0)
          return false;
        intersection?.set(ray.__\u003C\u003Eorigin).add(Intersector3D.v0.set(ray.__\u003C\u003Edirection).scl(scalar));
        return true;
      }
      if (!object.ReferenceEquals((object) plane.testPoint(ray.__\u003C\u003Eorigin), (object) Plane.PlaneSide.__\u003C\u003EonPlane))
        return false;
      intersection?.set(ray.__\u003C\u003Eorigin);
      return true;
    }

    [LineNumberTable(new byte[] {104, 110, 112, 130, 102, 162, 127, 17, 127, 7, 107, 127, 3, 127, 68, 98, 226, 69, 127, 17, 127, 7, 107, 127, 3, 127, 68, 98, 226, 69, 127, 17, 127, 7, 107, 127, 3, 127, 68, 98, 226, 69, 127, 17, 127, 7, 107, 127, 3, 127, 68, 98, 226, 69, 127, 17, 127, 7, 107, 127, 3, 127, 68, 98, 226, 69, 127, 17, 127, 7, 107, 127, 3, 127, 68, 98, 194, 108, 126, 115, 115, 115, 145, 115, 115, 115, 145, 115, 115, 115, 177})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectRayBounds(Ray ray, BoundingBox box, Vec3 intersection)
    {
      if (box.contains(ray.__\u003C\u003Eorigin))
      {
        intersection?.set(ray.__\u003C\u003Eorigin);
        return true;
      }
      float scalar1 = 0.0f;
      int num = 0;
      if ((double) ray.__\u003C\u003Eorigin.x <= (double) box.__\u003C\u003Emin.x && (double) ray.__\u003C\u003Edirection.x > 0.0)
      {
        float scalar2 = (box.__\u003C\u003Emin.x - ray.__\u003C\u003Eorigin.x) / ray.__\u003C\u003Edirection.x;
        if ((double) scalar2 >= 0.0)
        {
          Intersector3D.v2.set(ray.__\u003C\u003Edirection).scl(scalar2).add(ray.__\u003C\u003Eorigin);
          if ((double) Intersector3D.v2.y >= (double) box.__\u003C\u003Emin.y && (double) Intersector3D.v2.y <= (double) box.__\u003C\u003Emax.y && ((double) Intersector3D.v2.z >= (double) box.__\u003C\u003Emin.z && (double) Intersector3D.v2.z <= (double) box.__\u003C\u003Emax.z) && (num == 0 || (double) scalar2 < (double) scalar1))
          {
            num = 1;
            scalar1 = scalar2;
          }
        }
      }
      if ((double) ray.__\u003C\u003Eorigin.x >= (double) box.__\u003C\u003Emax.x && (double) ray.__\u003C\u003Edirection.x < 0.0)
      {
        float scalar2 = (box.__\u003C\u003Emax.x - ray.__\u003C\u003Eorigin.x) / ray.__\u003C\u003Edirection.x;
        if ((double) scalar2 >= 0.0)
        {
          Intersector3D.v2.set(ray.__\u003C\u003Edirection).scl(scalar2).add(ray.__\u003C\u003Eorigin);
          if ((double) Intersector3D.v2.y >= (double) box.__\u003C\u003Emin.y && (double) Intersector3D.v2.y <= (double) box.__\u003C\u003Emax.y && ((double) Intersector3D.v2.z >= (double) box.__\u003C\u003Emin.z && (double) Intersector3D.v2.z <= (double) box.__\u003C\u003Emax.z) && (num == 0 || (double) scalar2 < (double) scalar1))
          {
            num = 1;
            scalar1 = scalar2;
          }
        }
      }
      if ((double) ray.__\u003C\u003Eorigin.y <= (double) box.__\u003C\u003Emin.y && (double) ray.__\u003C\u003Edirection.y > 0.0)
      {
        float scalar2 = (box.__\u003C\u003Emin.y - ray.__\u003C\u003Eorigin.y) / ray.__\u003C\u003Edirection.y;
        if ((double) scalar2 >= 0.0)
        {
          Intersector3D.v2.set(ray.__\u003C\u003Edirection).scl(scalar2).add(ray.__\u003C\u003Eorigin);
          if ((double) Intersector3D.v2.x >= (double) box.__\u003C\u003Emin.x && (double) Intersector3D.v2.x <= (double) box.__\u003C\u003Emax.x && ((double) Intersector3D.v2.z >= (double) box.__\u003C\u003Emin.z && (double) Intersector3D.v2.z <= (double) box.__\u003C\u003Emax.z) && (num == 0 || (double) scalar2 < (double) scalar1))
          {
            num = 1;
            scalar1 = scalar2;
          }
        }
      }
      if ((double) ray.__\u003C\u003Eorigin.y >= (double) box.__\u003C\u003Emax.y && (double) ray.__\u003C\u003Edirection.y < 0.0)
      {
        float scalar2 = (box.__\u003C\u003Emax.y - ray.__\u003C\u003Eorigin.y) / ray.__\u003C\u003Edirection.y;
        if ((double) scalar2 >= 0.0)
        {
          Intersector3D.v2.set(ray.__\u003C\u003Edirection).scl(scalar2).add(ray.__\u003C\u003Eorigin);
          if ((double) Intersector3D.v2.x >= (double) box.__\u003C\u003Emin.x && (double) Intersector3D.v2.x <= (double) box.__\u003C\u003Emax.x && ((double) Intersector3D.v2.z >= (double) box.__\u003C\u003Emin.z && (double) Intersector3D.v2.z <= (double) box.__\u003C\u003Emax.z) && (num == 0 || (double) scalar2 < (double) scalar1))
          {
            num = 1;
            scalar1 = scalar2;
          }
        }
      }
      if ((double) ray.__\u003C\u003Eorigin.z <= (double) box.__\u003C\u003Emin.z && (double) ray.__\u003C\u003Edirection.z > 0.0)
      {
        float scalar2 = (box.__\u003C\u003Emin.z - ray.__\u003C\u003Eorigin.z) / ray.__\u003C\u003Edirection.z;
        if ((double) scalar2 >= 0.0)
        {
          Intersector3D.v2.set(ray.__\u003C\u003Edirection).scl(scalar2).add(ray.__\u003C\u003Eorigin);
          if ((double) Intersector3D.v2.x >= (double) box.__\u003C\u003Emin.x && (double) Intersector3D.v2.x <= (double) box.__\u003C\u003Emax.x && ((double) Intersector3D.v2.y >= (double) box.__\u003C\u003Emin.y && (double) Intersector3D.v2.y <= (double) box.__\u003C\u003Emax.y) && (num == 0 || (double) scalar2 < (double) scalar1))
          {
            num = 1;
            scalar1 = scalar2;
          }
        }
      }
      if ((double) ray.__\u003C\u003Eorigin.z >= (double) box.__\u003C\u003Emax.z && (double) ray.__\u003C\u003Edirection.z < 0.0)
      {
        float scalar2 = (box.__\u003C\u003Emax.z - ray.__\u003C\u003Eorigin.z) / ray.__\u003C\u003Edirection.z;
        if ((double) scalar2 >= 0.0)
        {
          Intersector3D.v2.set(ray.__\u003C\u003Edirection).scl(scalar2).add(ray.__\u003C\u003Eorigin);
          if ((double) Intersector3D.v2.x >= (double) box.__\u003C\u003Emin.x && (double) Intersector3D.v2.x <= (double) box.__\u003C\u003Emax.x && ((double) Intersector3D.v2.y >= (double) box.__\u003C\u003Emin.y && (double) Intersector3D.v2.y <= (double) box.__\u003C\u003Emax.y) && (num == 0 || (double) scalar2 < (double) scalar1))
          {
            num = 1;
            scalar1 = scalar2;
          }
        }
      }
      if (num != 0 && intersection != null)
      {
        intersection.set(ray.__\u003C\u003Edirection).scl(scalar1).add(ray.__\u003C\u003Eorigin);
        if ((double) intersection.x < (double) box.__\u003C\u003Emin.x)
          intersection.x = box.__\u003C\u003Emin.x;
        else if ((double) intersection.x > (double) box.__\u003C\u003Emax.x)
          intersection.x = box.__\u003C\u003Emax.x;
        if ((double) intersection.y < (double) box.__\u003C\u003Emin.y)
          intersection.y = box.__\u003C\u003Emin.y;
        else if ((double) intersection.y > (double) box.__\u003C\u003Emax.y)
          intersection.y = box.__\u003C\u003Emax.y;
        if ((double) intersection.z < (double) box.__\u003C\u003Emin.z)
          intersection.z = box.__\u003C\u003Emin.z;
        else if ((double) intersection.z > (double) box.__\u003C\u003Emax.z)
          intersection.z = box.__\u003C\u003Emax.z;
      }
      return num != 0;
    }

    [LineNumberTable(255)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectRayBoundsFast(Ray ray, BoundingBox box) => Intersector3D.intersectRayBoundsFast(ray, box.getCenter(Intersector3D.tmp1), box.getDimensions(Intersector3D.tmp2));

    [LineNumberTable(new byte[] {160, 187, 114, 110, 106, 123, 146, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectSegmentPlane(Vec3 start, Vec3 end, Plane plane, Vec3 intersection)
    {
      Vec3 vec3 = Intersector3D.v0.set(end).sub(start);
      float num = vec3.dot(plane.getNormal());
      if ((double) num == 0.0)
        return false;
      float scalar = -(start.dot(plane.getNormal()) + plane.getD()) / num;
      if ((double) scalar < 0.0 || (double) scalar > 1.0)
        return false;
      intersection.set(start).add(vec3.scl(scalar));
      return true;
    }

    [LineNumberTable(new byte[] {160, 205, 102, 130, 159, 2, 108, 127, 13, 121, 10, 198, 99, 115, 101, 99, 112, 226, 54, 234, 79, 99, 130, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectRayTriangles(Ray ray, float[] triangles, Vec3 intersection)
    {
      float num1 = float.MaxValue;
      int num2 = 0;
      int num3 = triangles.Length / 3;
      int num4 = 3;
      if ((num4 != -1 ? num3 % num4 : 0) != 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("triangle list size is not a multiple of 3");
      }
      for (int index = 0; index < triangles.Length - 6; index += 9)
      {
        if (Intersector3D.intersectRayTriangle(ray, Intersector3D.tmp1.set(triangles[index], triangles[index + 1], triangles[index + 2]), Intersector3D.tmp2.set(triangles[index + 3], triangles[index + 4], triangles[index + 5]), Intersector3D.tmp3.set(triangles[index + 6], triangles[index + 7], triangles[index + 8]), Intersector3D.tmp))
        {
          float num5 = ray.__\u003C\u003Eorigin.dst2(Intersector3D.tmp);
          if ((double) num5 < (double) num1)
          {
            num1 = num5;
            Intersector3D.best.set(Intersector3D.tmp);
            num2 = 1;
          }
        }
      }
      if (num2 == 0)
        return false;
      intersection?.set(Intersector3D.best);
      return true;
    }

    [LineNumberTable(new byte[] {160, 244, 102, 130, 159, 0, 106, 102, 105, 137, 127, 14, 122, 10, 199, 100, 115, 101, 99, 112, 226, 50, 233, 83, 99, 130, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectRayTriangles(
      Ray ray,
      float[] vertices,
      short[] indices,
      int vertexSize,
      Vec3 intersection)
    {
      float num1 = float.MaxValue;
      int num2 = 0;
      int length = indices.Length;
      int num3 = 3;
      if ((num3 != -1 ? length % num3 : 0) != 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("triangle list size is not a multiple of 3");
      }
      for (int index1 = 0; index1 < indices.Length; index1 += 3)
      {
        int index2 = (int) indices[index1] * vertexSize;
        int index3 = (int) indices[index1 + 1] * vertexSize;
        int index4 = (int) indices[index1 + 2] * vertexSize;
        if (Intersector3D.intersectRayTriangle(ray, Intersector3D.tmp1.set(vertices[index2], vertices[index2 + 1], vertices[index2 + 2]), Intersector3D.tmp2.set(vertices[index3], vertices[index3 + 1], vertices[index3 + 2]), Intersector3D.tmp3.set(vertices[index4], vertices[index4 + 1], vertices[index4 + 2]), Intersector3D.tmp))
        {
          float num4 = ray.__\u003C\u003Eorigin.dst2(Intersector3D.tmp);
          if ((double) num4 < (double) num1)
          {
            num1 = num4;
            Intersector3D.best.set(Intersector3D.tmp);
            num2 = 1;
          }
        }
      }
      if (num2 == 0)
        return false;
      intersection?.set(Intersector3D.best);
      return true;
    }

    [Signature("(Larc/math/geom/Ray;Ljava/util/List<Larc/math/geom/Vec3;>;Larc/math/geom/Vec3;)Z")]
    [LineNumberTable(new byte[] {161, 28, 102, 130, 159, 4, 112, 159, 21, 99, 115, 101, 99, 112, 226, 56, 233, 77, 99, 130, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectRayTriangles(Ray ray, List triangles, Vec3 intersection)
    {
      float num1 = float.MaxValue;
      int num2 = 0;
      int num3 = triangles.size();
      int num4 = 3;
      if ((num4 != -1 ? num3 % num4 : 0) != 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("triangle list size is not a multiple of 3");
      }
      for (int index = 0; index < triangles.size() - 2; index += 3)
      {
        if (Intersector3D.intersectRayTriangle(ray, (Vec3) triangles.get(index), (Vec3) triangles.get(index + 1), (Vec3) triangles.get(index + 2), Intersector3D.tmp))
        {
          float num5 = ray.__\u003C\u003Eorigin.dst2(Intersector3D.tmp);
          if ((double) num5 < (double) num1)
          {
            num1 = num5;
            Intersector3D.best.set(Intersector3D.tmp);
            num2 = 1;
          }
        }
      }
      if (num2 == 0)
        return false;
      intersection?.set(Intersector3D.best);
      return true;
    }

    [LineNumberTable(new byte[] {161, 74, 101, 127, 1, 127, 5, 191, 11, 166, 104, 103, 99, 103, 146, 103, 144, 193, 103, 125, 243, 69, 173, 99, 99, 132, 179, 106, 174, 114, 176, 202, 99, 101, 132, 179, 106, 174, 114, 176, 202, 101, 99, 132, 179, 106, 174, 114, 176, 202, 105, 122, 152, 122, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void splitTriangle(
      float[] triangle,
      Plane plane,
      Intersector3D.SplitTriangle split)
    {
      int index = triangle.Length / 3;
      int num1 = !object.ReferenceEquals((object) plane.testPoint(triangle[0], triangle[1], triangle[2]), (object) Plane.PlaneSide.__\u003C\u003Eback) ? 0 : 1;
      int num2 = !object.ReferenceEquals((object) plane.testPoint(triangle[index], triangle[1 + index], triangle[2 + index]), (object) Plane.PlaneSide.__\u003C\u003Eback) ? 0 : 1;
      int num3 = !object.ReferenceEquals((object) plane.testPoint(triangle[index * 2], triangle[1 + index * 2], triangle[2 + index * 2]), (object) Plane.PlaneSide.__\u003C\u003Eback) ? 0 : 1;
      split.reset();
      if (num1 == num2 && num2 == num3)
      {
        split.total = 1;
        if (num1 != 0)
        {
          split.numBack = 1;
          ByteCodeHelper.arraycopy_primitive_4((Array) triangle, 0, (Array) split.back, 0, triangle.Length);
        }
        else
        {
          split.numFront = 1;
          ByteCodeHelper.arraycopy_primitive_4((Array) triangle, 0, (Array) split.front, 0, triangle.Length);
        }
      }
      else
      {
        split.total = 3;
        split.numFront = (num1 == 0 ? 1 : 0) + (num2 == 0 ? 1 : 0) + (num3 == 0 ? 1 : 0);
        split.numBack = split.total - split.numFront;
        split.setSide(num1 == 0);
        int num4 = 0;
        int num5 = index;
        if (num1 != num2)
        {
          Intersector3D.splitEdge(triangle, num4, num5, index, plane, split.edgeSplit, 0);
          split.add(triangle, num4, index);
          split.add(split.edgeSplit, 0, index);
          split.setSide(!split.getSide());
          split.add(split.edgeSplit, 0, index);
        }
        else
          split.add(triangle, num4, index);
        int num6 = index;
        int num7 = index + index;
        if (num2 != num3)
        {
          Intersector3D.splitEdge(triangle, num6, num7, index, plane, split.edgeSplit, 0);
          split.add(triangle, num6, index);
          split.add(split.edgeSplit, 0, index);
          split.setSide(!split.getSide());
          split.add(split.edgeSplit, 0, index);
        }
        else
          split.add(triangle, num6, index);
        int num8 = index + index;
        int num9 = 0;
        if (num3 != num1)
        {
          Intersector3D.splitEdge(triangle, num8, num9, index, plane, split.edgeSplit, 0);
          split.add(triangle, num8, index);
          split.add(split.edgeSplit, 0, index);
          split.setSide(!split.getSide());
          split.add(split.edgeSplit, 0, index);
        }
        else
          split.add(triangle, num8, index);
        if (split.numFront == 2)
        {
          ByteCodeHelper.arraycopy_primitive_4((Array) split.front, index * 2, (Array) split.front, index * 3, index * 2);
          ByteCodeHelper.arraycopy_primitive_4((Array) split.front, 0, (Array) split.front, index * 5, index);
        }
        else
        {
          ByteCodeHelper.arraycopy_primitive_4((Array) split.back, index * 2, (Array) split.back, index * 3, index * 2);
          ByteCodeHelper.arraycopy_primitive_4((Array) split.back, 0, (Array) split.back, index * 5, index);
        }
      }
    }

    [LineNumberTable(new byte[] {159, 140, 109, 106, 106, 106, 116, 106, 106, 106, 106, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Intersector3D()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.math.geom.Intersector3D"))
        return;
      Intersector3D.v0 = new Vec3();
      Intersector3D.v1 = new Vec3();
      Intersector3D.v2 = new Vec3();
      Intersector3D.p = new Plane(new Vec3(), 0.0f);
      Intersector3D.i = new Vec3();
      Intersector3D.best = new Vec3();
      Intersector3D.tmp = new Vec3();
      Intersector3D.tmp1 = new Vec3();
      Intersector3D.tmp2 = new Vec3();
      Intersector3D.tmp3 = new Vec3();
      Intersector3D.intersection = new Vec3();
    }

    public class SplitTriangle : Object
    {
      public float[] front;
      public float[] back;
      public int numFront;
      public int numBack;
      public int total;
      internal float[] edgeSplit;
      internal bool frontCurrent;
      internal int frontOffset;
      internal int backOffset;

      [LineNumberTable(new byte[] {161, 201, 232, 56, 103, 103, 231, 71, 112, 112, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SplitTriangle(int numAttributes)
      {
        Intersector3D.SplitTriangle splitTriangle = this;
        this.frontCurrent = false;
        this.frontOffset = 0;
        this.backOffset = 0;
        this.front = new float[numAttributes * 3 * 2];
        this.back = new float[numAttributes * 3 * 2];
        this.edgeSplit = new float[numAttributes];
      }

      [LineNumberTable(579)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => new StringBuilder().append("SplitTriangle [front=").append(Arrays.toString(this.front)).append(", back=").append(Arrays.toString(this.back)).append(", numFront=").append(this.numFront).append(", numBack=").append(this.numBack).append(", total=").append(this.total).append("]").toString();

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual bool getSide() => this.frontCurrent;

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void setSide([In] bool obj0) => this.frontCurrent = obj0;

      [LineNumberTable(new byte[] {161, 222, 104, 116, 144, 116, 142})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void add([In] float[] obj0, [In] int obj1, [In] int obj2)
      {
        if (this.frontCurrent)
        {
          ByteCodeHelper.arraycopy_primitive_4((Array) obj0, obj1, (Array) this.front, this.frontOffset, obj2);
          this.frontOffset += obj2;
        }
        else
        {
          ByteCodeHelper.arraycopy_primitive_4((Array) obj0, obj1, (Array) this.back, this.backOffset, obj2);
          this.backOffset += obj2;
        }
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void reset()
      {
        this.frontCurrent = false;
        this.frontOffset = 0;
        this.backOffset = 0;
        this.numFront = 0;
        this.numBack = 0;
        this.total = 0;
      }
    }
  }
}
