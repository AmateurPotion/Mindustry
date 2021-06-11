// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Commanderc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using mindustry.ai.formations;
using mindustry.entities.units;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Posc", "mindustry.gen.Entityc"})]
  public interface Commanderc : Posc, Position, Entityc
  {
    void controller(UnitController uc);

    new void update();

    new void remove();

    void killed();

    void commandNearby(FormationPattern fp);

    [Signature("(Lmindustry/ai/formations/FormationPattern;Larc/func/Boolf<Lmindustry/gen/Unit;>;)V")]
    void commandNearby(FormationPattern fp, Boolf b);

    [Signature("(Lmindustry/ai/formations/Formation;Larc/struct/Seq<Lmindustry/gen/Unit;>;)V")]
    void command(Formation f, Seq s);

    bool isCommanding();

    void clearCommand();

    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    Formation formation();

    void formation([Nullable(new object[] {64, "Larc/util/Nullable;"})] Formation f);

    [Signature("()Larc/struct/Seq<Lmindustry/gen/Unit;>;")]
    Seq controlling();

    [Signature("(Larc/struct/Seq<Lmindustry/gen/Unit;>;)V")]
    void controlling(Seq s);

    float minFormationSpeed();

    void minFormationSpeed(float f);
  }
}
