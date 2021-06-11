// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Posc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using mindustry.world;
using mindustry.world.blocks.environment;

namespace mindustry.gen
{
  [Implements(new string[] {"arc.math.geom.Position", "mindustry.gen.Entityc"})]
  public interface Posc : Position, Entityc
  {
    void set(Position p);

    new float getX();

    new float getY();

    void set(float f1, float f2);

    Tile tileOn();

    bool onSolid();

    int tileX();

    int tileY();

    float x();

    float y();

    void trns(float f1, float f2);

    Floor floorOn();

    void trns(Position p);

    Block blockOn();

    void x(float f);

    void y(float f);
  }
}
