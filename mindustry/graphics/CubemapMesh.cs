// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.CubemapMesh
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics;
using arc.graphics.gl;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;

namespace mindustry.graphics
{
  public class CubemapMesh : Object, Disposable
  {
    [Modifiers]
    private static float[] vertices;
    [Modifiers]
    private Mesh mesh;
    [Modifiers]
    private Shader shader;
    private Cubemap map;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {9, 104, 103, 112, 127, 2, 119, 157, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CubemapMesh(Cubemap map)
    {
      CubemapMesh cubemapMesh = this;
      this.map = map;
      this.map.setFilter(Texture.TextureFilter.__\u003C\u003Elinear);
      this.mesh = new Mesh(true, CubemapMesh.vertices.Length, 0, new VertexAttribute[1]
      {
        VertexAttribute.__\u003C\u003Eposition3
      });
      ((Buffer) this.mesh.getVerticesBuffer()).limit(CubemapMesh.vertices.Length);
      this.mesh.getVerticesBuffer().put(CubemapMesh.vertices, 0, CubemapMesh.vertices.Length);
      Shader.__\u003Cclinit\u003E();
      this.shader = new Shader(Core.files.@internal("shaders/cubemap.vert"), Core.files.@internal("shaders/cubemap.frag"));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCubemap(Cubemap map) => this.map = map;

    [LineNumberTable(new byte[] {24, 107, 107, 113, 118, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render(Mat3D projection)
    {
      this.map.bind();
      this.shader.bind();
      this.shader.setUniformi("u_cubemap", 0);
      this.shader.setUniformMatrix4("u_proj", projection.__\u003C\u003Eval);
      this.mesh.render(this.shader, 4);
    }

    [LineNumberTable(new byte[] {33, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      this.mesh.dispose();
      this.map.dispose();
    }

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static CubemapMesh()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.graphics.CubemapMesh"))
        return;
      CubemapMesh.vertices = new float[108]
      {
        -1f,
        1f,
        -1f,
        -1f,
        -1f,
        -1f,
        1f,
        -1f,
        -1f,
        1f,
        -1f,
        -1f,
        1f,
        1f,
        -1f,
        -1f,
        1f,
        -1f,
        -1f,
        -1f,
        1f,
        -1f,
        -1f,
        -1f,
        -1f,
        1f,
        -1f,
        -1f,
        1f,
        -1f,
        -1f,
        1f,
        1f,
        -1f,
        -1f,
        1f,
        1f,
        -1f,
        -1f,
        1f,
        -1f,
        1f,
        1f,
        1f,
        1f,
        1f,
        1f,
        1f,
        1f,
        1f,
        -1f,
        1f,
        -1f,
        -1f,
        -1f,
        -1f,
        1f,
        -1f,
        1f,
        1f,
        1f,
        1f,
        1f,
        1f,
        1f,
        1f,
        1f,
        -1f,
        1f,
        -1f,
        -1f,
        1f,
        -1f,
        1f,
        -1f,
        1f,
        1f,
        -1f,
        1f,
        1f,
        1f,
        1f,
        1f,
        1f,
        -1f,
        1f,
        1f,
        -1f,
        1f,
        -1f,
        -1f,
        -1f,
        -1f,
        -1f,
        -1f,
        1f,
        1f,
        -1f,
        -1f,
        1f,
        -1f,
        -1f,
        -1f,
        -1f,
        1f,
        1f,
        -1f,
        1f
      };
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);
  }
}
