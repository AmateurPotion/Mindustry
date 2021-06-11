// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.g3d.HexMesh
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.gl;
using arc.math.geom;
using IKVM.Attributes;
using mindustry.type;
using System.Runtime.CompilerServices;

namespace mindustry.graphics.g3d
{
  public class HexMesh : PlanetMesh
  {
    [LineNumberTable(new byte[] {159, 153, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public HexMesh(Planet planet, int divisions)
      : base(planet, MeshBuilder.buildHex((HexMesher) planet.generator, divisions, false, planet.radius, 0.2f), (Shader) Shaders.planet)
    {
    }

    [LineNumberTable(new byte[] {159, 157, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public HexMesh(Planet planet, HexMesher mesher, int divisions, Shader shader)
      : base(planet, MeshBuilder.buildHex(mesher, divisions, false, planet.radius, 0.2f), shader)
    {
    }

    [LineNumberTable(new byte[] {159, 162, 127, 44, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void preRender()
    {
      Shaders.planet.lightDir.set(this.__\u003C\u003Eplanet.solarSystem.position).sub(this.__\u003C\u003Eplanet.position).rotate(Vec3.__\u003C\u003EY, this.__\u003C\u003Eplanet.getRotation()).nor();
      Shaders.planet.ambientColor.set(this.__\u003C\u003Eplanet.solarSystem.lightColor);
    }
  }
}
