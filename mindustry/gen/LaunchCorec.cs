// Decompiled with JetBrains decompiler
// Type: mindustry.gen.LaunchCorec
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using mindustry.world;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Drawc", "mindustry.gen.Posc", "mindustry.gen.Entityc", "mindustry.gen.Timedc"})]
  public interface LaunchCorec : Drawc, Posc, Position, Entityc, Timedc, Scaled
  {
    new void draw();

    float cx();

    float cy();

    new void update();

    Interval @in();

    void @in(Interval i);

    Block block();

    void block(Block b);
  }
}
