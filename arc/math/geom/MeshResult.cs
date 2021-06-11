// Decompiled with JetBrains decompiler
// Type: arc.math.geom.MeshResult
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.math.geom
{
  public class MeshResult : Object
  {
    public FloatSeq vertices;
    public IntSeq indices;

    [LineNumberTable(new byte[] {159, 147, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MeshResult()
    {
      MeshResult meshResult = this;
      this.vertices = new FloatSeq();
      this.indices = new IntSeq();
    }
  }
}
