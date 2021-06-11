// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.g3d.ShaderSphereMesh
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.gl;
using IKVM.Attributes;
using mindustry.type;
using System.Runtime.CompilerServices;

namespace mindustry.graphics.g3d
{
  public class ShaderSphereMesh : PlanetMesh
  {
    [LineNumberTable(new byte[] {159, 151, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ShaderSphereMesh(Planet planet, Shader shader, int divisions)
      : base(planet, MeshBuilder.buildIcosphere(divisions, planet.radius), shader)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void preRender()
    {
    }
  }
}
