// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Puddlec
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using mindustry.type;
using mindustry.world;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Drawc", "mindustry.gen.Posc", "mindustry.gen.Entityc"})]
  public interface Puddlec : Drawc, Posc, Position, Entityc
  {
    float getFlammability();

    new void update();

    new void draw();

    new float clipSize();

    new void remove();

    new void afterRead();

    float accepting();

    void accepting(float f);

    float updateTime();

    void updateTime(float f);

    float lastRipple();

    void lastRipple(float f);

    float amount();

    void amount(float f);

    int generation();

    void generation(int i);

    Tile tile();

    void tile(Tile t);

    Liquid liquid();

    void liquid(Liquid l);
  }
}
