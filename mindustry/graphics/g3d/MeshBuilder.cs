// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.g3d.MeshBuilder
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.math.geom;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics.g3d
{
  public class MeshBuilder : Object
  {
    [Modifiers]
    private static Vec3 v1;
    [Modifiers]
    private static Vec3 v2;
    [Modifiers]
    private static Vec3 v3;
    [Modifiers]
    private static Vec3 v4;
    [Modifiers]
    private static float[] floats;
    private static Mesh mesh;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Mesh buildHex(Color color, int divisions, bool lines, float radius)
    {
      int num = lines ? 1 : 0;
      return MeshBuilder.buildHex((HexMesher) new MeshBuilder.\u0031(color), divisions, num != 0, radius, 0.0f);
    }

    [LineNumberTable(new byte[] {159, 131, 130, 135, 145, 155, 137, 121, 63, 22, 200, 127, 3, 153, 102, 151, 106, 108, 155, 107, 235, 59, 237, 72, 127, 5, 127, 5, 159, 5, 102, 255, 5, 69, 121, 45, 232, 32, 235, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Mesh buildHex(
      HexMesher mesher,
      int divisions,
      bool lines,
      float radius,
      float intensity)
    {
      int num1 = lines ? 1 : 0;
      PlanetGrid planetGrid = PlanetGrid.create(divisions);
      MeshBuilder.begin(planetGrid.tiles.Length * 12 * 7);
      PlanetGrid.Ptile[] tiles = planetGrid.tiles;
      int length1 = tiles.Length;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        PlanetGrid.Ptile ptile = tiles[index1];
        PlanetGrid.Corner[] corners = ptile.corners;
        PlanetGrid.Corner[] cornerArray1 = corners;
        int length2 = cornerArray1.Length;
        for (int index2 = 0; index2 < length2; ++index2)
        {
          PlanetGrid.Corner corner = cornerArray1[index2];
          corner.v.setLength((1f + mesher.getHeight(MeshBuilder.v2.set(corner.v)) * intensity) * radius);
        }
        Vec3 vec3 = MeshBuilder.normal(corners[0].v, corners[2].v, corners[4].v);
        Color color = mesher.getColor(MeshBuilder.v2.set(ptile.v));
        if (num1 != 0)
        {
          vec3.set(1f, 1f, 1f);
          for (int index2 = 0; index2 < corners.Length; ++index2)
          {
            Vec3 v1 = corners[index2].v;
            PlanetGrid.Corner[] cornerArray2 = corners;
            int num2 = index2 + 1;
            int length3 = corners.Length;
            int index3 = length3 != -1 ? num2 % length3 : 0;
            Vec3 v2 = cornerArray2[index3].v;
            MeshBuilder.vert(v1, vec3, color);
            MeshBuilder.vert(v2, vec3, color);
          }
        }
        else
        {
          MeshBuilder.verts(corners[0].v, corners[1].v, corners[2].v, vec3, color);
          MeshBuilder.verts(corners[0].v, corners[2].v, corners[3].v, vec3, color);
          MeshBuilder.verts(corners[0].v, corners[3].v, corners[4].v, vec3, color);
          if (corners.Length > 5)
            MeshBuilder.verts(corners[0].v, corners[4].v, corners[5].v, vec3, color);
        }
        PlanetGrid.Corner[] cornerArray3 = corners;
        int length4 = cornerArray3.Length;
        for (int index2 = 0; index2 < length4; ++index2)
          cornerArray3[index2].v.nor();
      }
      return MeshBuilder.end();
    }

    [LineNumberTable(new byte[] {42, 255, 12, 70, 122, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void begin([In] int obj0)
    {
      MeshBuilder.mesh = new Mesh(true, obj0, 0, new VertexAttribute[3]
      {
        VertexAttribute.__\u003C\u003Eposition3,
        VertexAttribute.__\u003C\u003Enormal,
        VertexAttribute.__\u003C\u003Ecolor
      });
      ((Buffer) MeshBuilder.mesh.getVerticesBuffer()).limit(MeshBuilder.mesh.getMaxVertices());
      ((Buffer) MeshBuilder.mesh.getVerticesBuffer()).position(0);
    }

    [LineNumberTable(110)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Vec3 normal([In] Vec3 obj0, [In] Vec3 obj1, [In] Vec3 obj2) => MeshBuilder.v4.set(obj1).sub(obj0).crs(obj2.x - obj0.x, obj2.y - obj0.y, obj2.z - obj0.z).nor();

    [LineNumberTable(new byte[] {64, 105, 105, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void verts([In] Vec3 obj0, [In] Vec3 obj1, [In] Vec3 obj2, [In] Vec3 obj3, [In] Color obj4)
    {
      MeshBuilder.vert(obj0, obj3, obj4);
      MeshBuilder.vert(obj1, obj3, obj4);
      MeshBuilder.vert(obj2, obj3, obj4);
    }

    [LineNumberTable(new byte[] {53, 102, 119, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Mesh end()
    {
      Mesh mesh = MeshBuilder.mesh;
      ((Buffer) mesh.getVerticesBuffer()).limit(((Buffer) mesh.getVerticesBuffer()).position());
      MeshBuilder.mesh = (Mesh) null;
      return mesh;
    }

    [LineNumberTable(new byte[] {159, 155, 150, 103, 115, 127, 13, 127, 15, 159, 15, 255, 20, 59, 233, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Mesh buildIcosphere(int divisions, float radius, Color color)
    {
      MeshBuilder.begin(20 * (2 << 2 * divisions - 1) * 7 * 3);
      MeshResult meshResult = Icosphere.create(divisions);
      for (int index = 0; index < meshResult.indices.size; index += 3)
      {
        MeshBuilder.v1.set(meshResult.vertices.items, meshResult.indices.items[index] * 3).setLength(radius);
        MeshBuilder.v2.set(meshResult.vertices.items, meshResult.indices.items[index + 1] * 3).setLength(radius);
        MeshBuilder.v3.set(meshResult.vertices.items, meshResult.indices.items[index + 2] * 3).setLength(radius);
        MeshBuilder.verts(MeshBuilder.v1, MeshBuilder.v3, MeshBuilder.v2, MeshBuilder.normal(MeshBuilder.v1, MeshBuilder.v2, MeshBuilder.v3).scl(-1f), color);
      }
      return MeshBuilder.end();
    }

    [LineNumberTable(new byte[] {70, 109, 109, 141, 109, 109, 141, 110, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void vert([In] Vec3 obj0, [In] Vec3 obj1, [In] Color obj2)
    {
      MeshBuilder.floats[0] = obj0.x;
      MeshBuilder.floats[1] = obj0.y;
      MeshBuilder.floats[2] = obj0.z;
      MeshBuilder.floats[3] = obj1.x;
      MeshBuilder.floats[4] = obj1.y;
      MeshBuilder.floats[5] = obj1.z;
      MeshBuilder.floats[6] = obj2.toFloatBits();
      MeshBuilder.mesh.getVerticesBuffer().put(MeshBuilder.floats);
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MeshBuilder()
    {
    }

    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Mesh buildIcosphere(int divisions, float radius) => MeshBuilder.buildIcosphere(divisions, radius, Color.__\u003C\u003Ewhite);

    [LineNumberTable(new byte[] {159, 140, 77, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static MeshBuilder()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.graphics.g3d.MeshBuilder"))
        return;
      MeshBuilder.v1 = new Vec3();
      MeshBuilder.v2 = new Vec3();
      MeshBuilder.v3 = new Vec3();
      MeshBuilder.v4 = new Vec3();
      MeshBuilder.floats = new float[7];
    }

    [InnerClass]
    [EnclosingMethod(null, "buildHex", "(Larc.graphics.Color;IZF)Larc.graphics.Mesh;")]
    [SpecialName]
    internal class \u0031 : Object, HexMesher
    {
      [Modifiers]
      internal Color val\u0024color;

      [Signature("()V")]
      [LineNumberTable(32)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Color obj0)
      {
        this.val\u0024color = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float getHeight([In] Vec3 obj0) => 0.0f;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Color getColor([In] Vec3 obj0) => this.val\u0024color;
    }
  }
}
