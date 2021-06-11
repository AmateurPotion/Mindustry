// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.FisheyeDistortionFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public class FisheyeDistortionFilter : FxFilter
  {
    [LineNumberTable(new byte[] {159, 155, 107, 111, 5, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FisheyeDistortionFilter()
      : base(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath("shaders/fisheye.frag")))
    {
    }
  }
}
