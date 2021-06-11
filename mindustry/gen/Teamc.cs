// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Teamc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using mindustry.game;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Posc", "mindustry.gen.Entityc"})]
  public interface Teamc : Posc, Position, Entityc
  {
    Team team();

    Building closestCore();

    Building closestEnemyCore();

    bool cheating();

    Building core();

    void team(Team t);
  }
}
