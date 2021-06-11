// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Healthc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Posc", "mindustry.gen.Entityc"})]
  public interface Healthc : Posc, Position, Entityc
  {
    bool isValid();

    bool dead();

    void kill();

    void damageContinuousPierce(float f);

    void heal(float f);

    void damagePierce(float f);

    void heal();

    float hitTime();

    float healthf();

    float health();

    void damage(float f);

    void killed();

    bool damaged();

    new void update();

    void damagePierce(float f, bool b);

    void damage(float f, bool b);

    void damageContinuous(float f);

    void clampHealth();

    void healFract(float f);

    void health(float f);

    void hitTime(float f);

    float maxHealth();

    void maxHealth(float f);

    void dead(bool b);
  }
}
