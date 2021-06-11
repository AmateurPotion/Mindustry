// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.g3d.PlanetMesh
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.gl;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics.g3d
{
  public abstract class PlanetMesh : Object, Disposable
  {
    internal Mesh __\u003C\u003Emesh;
    internal Planet __\u003C\u003Eplanet;
    internal Shader __\u003C\u003Eshader;

    [LineNumberTable(new byte[] {159, 177, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose() => this.__\u003C\u003Emesh.dispose();

    [LineNumberTable(new byte[] {159, 167, 102, 107, 118, 118, 107, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render(Mat3D projection, Mat3D transform)
    {
      this.preRender();
      this.__\u003C\u003Eshader.bind();
      this.__\u003C\u003Eshader.setUniformMatrix4("u_proj", projection.__\u003C\u003Eval);
      this.__\u003C\u003Eshader.setUniformMatrix4("u_trans", transform.__\u003C\u003Eval);
      this.__\u003C\u003Eshader.apply();
      this.__\u003C\u003Emesh.render(this.__\u003C\u003Eshader, 4);
    }

    public abstract void preRender();

    [LineNumberTable(new byte[] {159, 157, 104, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PlanetMesh(Planet planet, Mesh mesh, Shader shader)
    {
      PlanetMesh planetMesh = this;
      this.__\u003C\u003Eplanet = planet;
      this.__\u003C\u003Emesh = mesh;
      this.__\u003C\u003Eshader = shader;
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [Modifiers]
    protected internal Mesh mesh
    {
      [HideFromJava] get => this.__\u003C\u003Emesh;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Emesh = value;
    }

    [Modifiers]
    protected internal Planet planet
    {
      [HideFromJava] get => this.__\u003C\u003Eplanet;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eplanet = value;
    }

    [Modifiers]
    protected internal Shader shader
    {
      [HideFromJava] get => this.__\u003C\u003Eshader;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eshader = value;
    }
  }
}
