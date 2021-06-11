// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.ScreenQuad
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.gl;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g2d
{
  public class ScreenQuad : Object, Disposable
  {
    internal Mesh __\u003C\u003Emesh;

    [LineNumberTable(new byte[] {159, 152, 104, 127, 5, 127, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScreenQuad()
    {
      ScreenQuad screenQuad = this;
      this.__\u003C\u003Emesh = new Mesh(true, 4, 0, new VertexAttribute[2]
      {
        VertexAttribute.__\u003C\u003Eposition,
        VertexAttribute.__\u003C\u003EtexCoords
      });
      this.__\u003C\u003Emesh.setVertices(new float[16]
      {
        -1f,
        -1f,
        0.0f,
        0.0f,
        1f,
        -1f,
        1f,
        0.0f,
        1f,
        1f,
        1f,
        1f,
        -1f,
        1f,
        0.0f,
        1f
      });
    }

    [LineNumberTable(new byte[] {159, 158, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render(Shader shader) => this.__\u003C\u003Emesh.render(shader, 6, 0, 4);

    [LineNumberTable(new byte[] {159, 163, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose() => this.__\u003C\u003Emesh.dispose();

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [Modifiers]
    public Mesh mesh
    {
      [HideFromJava] get => this.__\u003C\u003Emesh;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Emesh = value;
    }
  }
}
