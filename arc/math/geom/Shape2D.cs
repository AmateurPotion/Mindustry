// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Shape2D
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

namespace arc.math.geom
{
  public interface Shape2D
  {
    bool contains(Vec2 v);

    bool contains(float f1, float f2);
  }
}
