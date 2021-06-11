// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Statusc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.math.geom;
using IKVM.Attributes;
using mindustry.entities.comp;
using mindustry.type;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Flyingc", "mindustry.gen.Healthc", "mindustry.gen.Posc", "mindustry.gen.Hitboxc", "mindustry.gen.Entityc", "mindustry.gen.Velc"})]
  public interface Statusc : 
    Flyingc,
    Healthc,
    Posc,
    Position,
    Entityc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Velc
  {
    bool isBoss();

    void apply(StatusEffect se, float f);

    void apply(StatusEffect se);

    void clearStatuses();

    void unapply(StatusEffect se);

    bool isImmune(StatusEffect se);

    Color statusColor();

    new void update();

    void draw();

    bool hasEffect(StatusEffect se);

    float speedMultiplier();

    float damageMultiplier();

    float healthMultiplier();

    float reloadMultiplier();

    float buildSpeedMultiplier();

    float dragMultiplier();

    bool disarmed();
  }
}
