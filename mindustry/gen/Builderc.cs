// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Builderc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math.geom;
using IKVM.Attributes;
using mindustry.entities.comp;
using mindustry.entities.units;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Rotc", "mindustry.gen.Teamc", "mindustry.gen.Flyingc", "mindustry.gen.Healthc", "mindustry.gen.Posc", "mindustry.gen.Statusc", "mindustry.gen.Hitboxc", "mindustry.gen.Entityc", "mindustry.gen.Velc"})]
  public interface Builderc : 
    Rotc,
    Entityc,
    Teamc,
    Posc,
    Position,
    Flyingc,
    Healthc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Velc,
    Statusc
  {
    bool activelyBuilding();

    BuildPlan buildPlan();

    void addBuild(BuildPlan bp);

    bool isBuilding();

    bool canBuild();

    void clearBuilding();

    [Signature("()Larc/struct/Queue<Lmindustry/entities/units/BuildPlan;>;")]
    Queue plans();

    void updateBuilding(bool b);

    new void update();

    void drawBuildPlans();

    void drawPlan(BuildPlan bp, float f);

    void drawPlanTop(BuildPlan bp, float f);

    bool shouldSkip(BuildPlan bp, Building b);

    void removeBuild(int i1, int i2, bool b);

    void addBuild(BuildPlan bp, bool b);

    new void draw();

    [Signature("(Larc/struct/Queue<Lmindustry/entities/units/BuildPlan;>;)V")]
    void plans(Queue q);

    bool updateBuilding();
  }
}
