// Decompiled with JetBrains decompiler
// Type: mindustry.gen.EffectStatec
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using mindustry.entities;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Rotc", "mindustry.gen.Drawc", "mindustry.gen.Childc", "mindustry.gen.Posc", "mindustry.gen.Entityc", "mindustry.gen.Timedc"})]
  public interface EffectStatec : Rotc, Entityc, Drawc, Posc, Position, Childc, Timedc, Scaled
  {
    new void draw();

    new float clipSize();

    Color color();

    void color(Color c);

    Effect effect();

    void effect(Effect e);

    object data();

    void data(object obj);
  }
}
