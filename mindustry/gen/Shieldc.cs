// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Shieldc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Healthc", "mindustry.gen.Posc", "mindustry.gen.Entityc"})]
  public interface Shieldc : Healthc, Posc, Position, Entityc
  {
    float shieldAlpha();

    new void damage(float f);

    new void damagePierce(float f, bool b);

    new void update();

    float shield();

    void shield(float f);

    float armor();

    void armor(float f);

    void shieldAlpha(float f);
  }
}
