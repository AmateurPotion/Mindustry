// Decompiled with JetBrains decompiler
// Type: arc.util.viewport.FillViewport
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.util.viewport
{
  public class FillViewport : ScalingViewport
  {
    [LineNumberTable(new byte[] {159, 157, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FillViewport(float worldWidth, float worldHeight)
      : base(Scaling.__\u003C\u003Efill, worldWidth, worldHeight)
    {
    }

    [LineNumberTable(new byte[] {159, 161, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FillViewport(float worldWidth, float worldHeight, Camera camera)
      : base(Scaling.__\u003C\u003Efill, worldWidth, worldHeight, camera)
    {
    }
  }
}
