// Decompiled with JetBrains decompiler
// Type: mindustry.gen.WeatherStatec
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using mindustry.type;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Drawc", "mindustry.gen.Posc", "mindustry.gen.Syncc", "mindustry.gen.Entityc"})]
  public interface WeatherStatec : Drawc, Posc, Position, Entityc, Syncc
  {
    void init(Weather w);

    new void update();

    new void draw();

    Weather weather();

    void weather(Weather w);

    float intensity();

    void intensity(float f);

    float opacity();

    void opacity(float f);

    float life();

    void life(float f);

    float effectTimer();

    void effectTimer(float f);

    Vec2 windVector();

    void windVector(Vec2 v);
  }
}
