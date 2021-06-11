// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Hitboxc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math.geom;
using IKVM.Attributes;
using mindustry.entities.comp;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.entities.comp.Sized", "arc.math.geom.QuadTree$QuadTreeObject", "mindustry.gen.Posc", "mindustry.gen.Entityc"})]
  public interface Hitboxc : Sized, QuadTree.QuadTreeObject, Posc, Position, Entityc
  {
    new float hitSize();

    void collision(Hitboxc h, float f1, float f2);

    void hitboxTile(Rect r);

    new void hitbox(Rect r);

    float lastX();

    float lastY();

    bool collides(Hitboxc h);

    [Signature("(Larc/func/Cons<Larc/math/geom/QuadTree;>;)V")]
    void getCollisions(Cons c);

    void updateLastPosition();

    float deltaX();

    float deltaY();

    new void update();

    new void add();

    new void afterRead();

    float deltaLen();

    float deltaAngle();

    void lastX(float f);

    void lastY(float f);

    void deltaX(float f);

    void deltaY(float f);

    void hitSize(float f);
  }
}
