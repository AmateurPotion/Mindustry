// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.Convolve1dFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public sealed class Convolve1dFilter : FxFilter
  {
    public int length;
    public float[] weights;
    public float[] offsets;

    [LineNumberTable(new byte[] {159, 162, 107, 111, 31, 0, 204, 105, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Convolve1dFilter(int length, float[] weights_data, float[] offsets)
      : base(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath("shaders/convolve-1d.frag"), new StringBuilder().append("#define LENGTH ").append(length).toString()))
    {
      Convolve1dFilter convolve1dFilter = this;
      this.setWeights(length, weights_data, offsets);
      this.rebind();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWeights(int length, float[] weights, float[] offsets)
    {
      this.weights = weights;
      this.length = length;
      this.offsets = offsets;
    }

    [LineNumberTable(new byte[] {159, 154, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Convolve1dFilter(int length)
      : this(length, new float[length], new float[length * 2])
    {
    }

    [LineNumberTable(new byte[] {159, 158, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Convolve1dFilter(int length, float[] weights_data)
      : this(length, weights_data, new float[length * 2])
    {
    }

    [LineNumberTable(new byte[] {159, 178, 102, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose()
    {
      base.dispose();
      this.weights = (float[]) null;
      this.offsets = (float[]) null;
      this.length = 0;
    }

    [LineNumberTable(new byte[] {159, 186, 113, 125, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniform1fv("SampleWeights", this.weights, 0, this.length);
      this.__\u003C\u003Eshader.setUniform2fv("SampleOffsets", this.offsets, 0, this.length * 2);
    }
  }
}
