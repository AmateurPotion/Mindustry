// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Minerc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using mindustry.type;
using mindustry.world;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Rotc", "mindustry.gen.Drawc", "mindustry.gen.Posc", "mindustry.gen.Teamc", "mindustry.gen.Entityc", "mindustry.gen.Itemsc"})]
  public interface Minerc : Rotc, Entityc, Drawc, Posc, Position, Teamc, Itemsc
  {
    bool canMine();

    bool validMine(Tile t);

    void mineTile([Nullable(new object[] {64, "Larc/util/Nullable;"})] Tile t);

    bool canMine(Item i);

    bool offloadImmediately();

    bool mining();

    bool validMine(Tile t, bool b);

    new void update();

    new void draw();

    float mineTimer();

    void mineTimer(float f);

    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    Tile mineTile();
  }
}
