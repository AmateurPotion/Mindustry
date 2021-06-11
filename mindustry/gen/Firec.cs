// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Firec
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using mindustry.world;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Syncc", "mindustry.gen.Posc", "mindustry.gen.Entityc", "mindustry.gen.Timedc"})]
  public interface Firec : Syncc, Entityc, Posc, Position, Timedc, Scaled
  {
    new void update();

    new void remove();

    new void afterRead();

    new void afterSync();

    Tile tile();

    void tile(Tile t);
  }
}
