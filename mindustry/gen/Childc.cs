// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Childc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using arc.util;
using IKVM.Attributes;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Posc", "mindustry.gen.Entityc"})]
  public interface Childc : Posc, Position, Entityc
  {
    new void add();

    new void update();

    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    Posc parent();

    void parent([Nullable(new object[] {64, "Larc/util/Nullable;"})] Posc p);

    float offsetX();

    void offsetX(float f);

    float offsetY();

    void offsetY(float f);
  }
}
