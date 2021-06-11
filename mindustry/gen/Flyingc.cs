// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Flyingc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using mindustry.entities.comp;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Healthc", "mindustry.gen.Posc", "mindustry.gen.Hitboxc", "mindustry.gen.Entityc", "mindustry.gen.Velc"})]
  public interface Flyingc : 
    Healthc,
    Posc,
    Position,
    Entityc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Velc
  {
    bool isFlying();

    void wobble();

    bool checkTarget(bool b1, bool b2);

    bool isGrounded();

    float drownTime();

    bool canDrown();

    void landed();

    void moveAt(Vec2 v, float f);

    float floorSpeedMultiplier();

    new void update();

    float elevation();

    void elevation(float f);

    bool hovering();

    void hovering(bool b);

    void drownTime(float f);

    float splashTimer();

    void splashTimer(float f);
  }
}
