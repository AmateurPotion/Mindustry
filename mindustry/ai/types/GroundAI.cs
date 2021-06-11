// Decompiled with JetBrains decompiler
// Type: mindustry.ai.types.GroundAI
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.ai.types
{
  public class GroundAI : AIController
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GroundAI()
    {
    }

    [LineNumberTable(new byte[] {159, 162, 140, 127, 31, 103, 108, 126, 9, 230, 71, 127, 29, 130, 127, 19, 103, 191, 10, 170, 114, 159, 4, 118, 199, 127, 0, 191, 18, 127, 18, 114, 159, 35, 109, 188})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void updateMovement()
    {
      Building building = this.unit.closestEnemyCore();
      if (building != null && this.unit.within((Position) building, this.unit.range() / 1.1f + (float) (building.block.size * 8) / 2f))
      {
        this.target = (Teamc) building;
        for (int index = 0; index < this.targets.Length; ++index)
        {
          if (this.unit.mounts[index].__\u003C\u003Eweapon.bullet.collidesGround)
            this.targets[index] = (Teamc) building;
        }
      }
      if ((building == null || !this.unit.within((Position) building, this.unit.range() * 0.5f)) && object.ReferenceEquals((object) this.command(), (object) UnitCommand.__\u003C\u003Eattack))
      {
        int num = 1;
        if (Vars.state.rules.waves && object.ReferenceEquals((object) this.unit.team, (object) Vars.state.rules.defaultTeam))
        {
          Tile closestSpawner = this.getClosestSpawner();
          if (closestSpawner != null && this.unit.within((Position) closestSpawner, Vars.state.rules.dropZoneRadius + 120f))
            num = 0;
        }
        if (num != 0)
          this.pathfind(0);
      }
      if (object.ReferenceEquals((object) this.command(), (object) UnitCommand.__\u003C\u003Erally))
      {
        Teamc teamc = this.targetFlag(this.unit.x, this.unit.y, BlockFlag.__\u003C\u003Erally, false);
        if (teamc != null && !this.unit.within((Position) teamc, 70f))
          this.pathfind(1);
      }
      if (this.unit.type.canBoost && !this.unit.onSolid())
        this.unit.elevation = Mathf.approachDelta(this.unit.elevation, 0.0f, this.unit.type.riseSpeed);
      if (!Units.invalidateTarget(this.target, this.unit, this.unit.range()) && this.unit.type.rotateShooting)
      {
        if (!this.unit.type.hasWeapons())
          return;
        this.unit.lookAt((Position) Predict.intercept((Position) this.unit, (Position) this.target, ((Weapon) this.unit.type.weapons.first()).bullet.speed));
      }
      else
      {
        if (!this.unit.moving())
          return;
        this.unit.lookAt(this.unit.vel().angle());
      }
    }

    [HideFromJava]
    static GroundAI() => AIController.__\u003Cclinit\u003E();
  }
}
