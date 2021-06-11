// Decompiled with JetBrains decompiler
// Type: mindustry.logic.Controllable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using mindustry.game;

namespace mindustry.logic
{
  public interface Controllable
  {
    void control(LAccess la, double d1, double d2, double d3, double d4);

    void control(LAccess la, object obj, double d1, double d2, double d3);

    Team team();
  }
}
