// Decompiled with JetBrains decompiler
// Type: mindustry.ai.types.RepairAI
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.world.blocks;
using System.Runtime.CompilerServices;

namespace mindustry.ai.types
{
  public class RepairAI : AIController
  {
    public static float retreatDst;
    public static float fleeRange;
    public static float retreatDelay;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    internal Teamc avoid;
    internal float retreatTimer;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RepairAI()
    {
    }

    [LineNumberTable(new byte[] {159, 159, 109, 130, 127, 4, 113, 162, 108, 106, 172, 107, 127, 71, 191, 4, 209, 112, 115, 191, 10, 159, 2, 104, 108, 118, 140, 162, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void updateMovement()
    {
      if (this.target is Building)
      {
        int num = 0;
        if (this.target.within((Position) this.unit, this.unit.type.range))
        {
          this.unit.aim((Position) this.target);
          num = 1;
        }
        this.unit.controlWeapons(num != 0);
      }
      else if (this.target == null)
        this.unit.controlWeapons(false);
      if (this.target != null)
      {
        if (!this.target.within((Position) this.unit, this.unit.type.range * 0.65f))
        {
          Teamc target = this.target;
          Building building;
          if (target is Building && object.ReferenceEquals((object) (building = (Building) target), (object) (Building) target) && object.ReferenceEquals((object) building.team, (object) this.unit.team))
            this.moveTo((Position) this.target, this.unit.type.range * 0.65f);
        }
        this.unit.lookAt((Position) this.target);
      }
      if (!(this.target is Building))
      {
        if (this.timer.get(3, 40f))
          this.avoid = this.target(this.unit.x, this.unit.y, RepairAI.fleeRange, true, true);
        RepairAI repairAi1 = this;
        float num1 = repairAi1.retreatTimer + Time.delta;
        RepairAI repairAi2 = repairAi1;
        double num2 = (double) num1;
        repairAi2.retreatTimer = num1;
        double retreatDelay = (double) RepairAI.retreatDelay;
        if (num2 < retreatDelay || this.avoid == null)
          return;
        Building building = this.unit.closestCore();
        if (building == null || this.unit.within((Position) building, RepairAI.retreatDst))
          return;
        this.moveTo((Position) building, RepairAI.retreatDst);
      }
      else
        this.retreatTimer = 0.0f;
    }

    [LineNumberTable(new byte[] {10, 159, 8, 138, 99, 136, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void updateTargeting()
    {
      Building building = Units.findDamagedTile(this.unit.team, this.unit.x, this.unit.y);
      if (building is ConstructBlock.ConstructBuild)
        building = (Building) null;
      if (building == null)
        base.updateTargeting();
      else
        this.target = (Teamc) building;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static RepairAI()
    {
      AIController.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("mindustry.ai.types.RepairAI"))
        return;
      RepairAI.retreatDst = 160f;
      RepairAI.fleeRange = 310f;
      RepairAI.retreatDelay = 180f;
    }
  }
}
