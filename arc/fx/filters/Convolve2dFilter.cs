// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.Convolve2dFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.fx.util;
using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.fx.filters
{
  public sealed class Convolve2dFilter : MultipassVfxFilter
  {
    internal int __\u003C\u003Eradius;
    internal int __\u003C\u003Elength;
    internal float[] __\u003C\u003Eweights;
    internal float[] __\u003C\u003EoffsetsHor;
    internal float[] __\u003C\u003EoffsetsVert;
    public Convolve1dFilter hor;
    public Convolve1dFilter vert;

    [LineNumberTable(new byte[] {159, 158, 104, 103, 139, 113, 156, 113, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Convolve2dFilter(int radius)
    {
      Convolve2dFilter convolve2dFilter = this;
      this.__\u003C\u003Eradius = radius;
      this.__\u003C\u003Elength = radius * 2 + 1;
      this.hor = new Convolve1dFilter(this.__\u003C\u003Elength);
      this.vert = new Convolve1dFilter(this.__\u003C\u003Elength, this.hor.weights);
      this.__\u003C\u003Eweights = this.hor.weights;
      this.__\u003C\u003EoffsetsHor = this.hor.offsets;
      this.__\u003C\u003EoffsetsVert = this.vert.offsets;
    }

    [LineNumberTable(new byte[] {159, 172, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose()
    {
      this.hor.dispose();
      this.vert.dispose();
    }

    [LineNumberTable(new byte[] {159, 178, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.hor.rebind();
      this.vert.rebind();
    }

    [LineNumberTable(new byte[] {159, 184, 114, 106, 133, 134, 114, 106, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void render(PingPongBuffer buffer)
    {
      this.hor.setInput(buffer.getSrcTexture()).setOutput(buffer.getDstBuffer()).render();
      buffer.swap();
      this.vert.setInput(buffer.getSrcTexture()).setOutput(buffer.getDstBuffer()).render();
    }

    [Modifiers]
    public int radius
    {
      [HideFromJava] get => this.__\u003C\u003Eradius;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eradius = value;
    }

    [Modifiers]
    public int length
    {
      [HideFromJava] get => this.__\u003C\u003Elength;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Elength = value;
    }

    [Modifiers]
    public float[] weights
    {
      [HideFromJava] get => this.__\u003C\u003Eweights;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eweights = value;
    }

    [Modifiers]
    public float[] offsetsHor
    {
      [HideFromJava] get => this.__\u003C\u003EoffsetsHor;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EoffsetsHor = value;
    }

    [Modifiers]
    public float[] offsetsVert
    {
      [HideFromJava] get => this.__\u003C\u003EoffsetsVert;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EoffsetsVert = value;
    }
  }
}
