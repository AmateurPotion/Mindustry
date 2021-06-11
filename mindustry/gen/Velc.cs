// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Velc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using mindustry.entities;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Posc", "mindustry.gen.Entityc"})]
  public interface Velc : Posc, Position, Entityc
  {
    Vec2 vel();

    bool moving();

    void move(float f1, float f2);

    new void update();

    EntityCollisions.SolidPred solidity();

    bool canPass(int i1, int i2);

    bool canPassOn();

    float drag();

    void drag(float f);
  }
}
