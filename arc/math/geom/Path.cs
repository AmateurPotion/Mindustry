// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Path
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;

namespace arc.math.geom
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;")]
  public interface Path
  {
    [Signature("(TT;F)TT;")]
    object derivativeAt(object obj, float f);

    [Signature("(TT;F)TT;")]
    object valueAt(object obj, float f);

    [Signature("(TT;)F")]
    float approximate(object obj);

    [Signature("(TT;)F")]
    float locate(object obj);

    float approxLength(int i);
  }
}
