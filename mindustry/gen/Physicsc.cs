// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Physicsc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using mindustry.async;
using mindustry.entities.comp;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Flyingc", "mindustry.gen.Healthc", "mindustry.gen.Posc", "mindustry.gen.Hitboxc", "mindustry.gen.Entityc", "mindustry.gen.Velc"})]
  public interface Physicsc : 
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
    float mass();

    void physref(PhysicsProcess.PhysicRef pppr);

    void impulse(float f1, float f2);

    void impulse(Vec2 v);

    void impulseNet(Vec2 v);

    PhysicsProcess.PhysicRef physref();
  }
}
