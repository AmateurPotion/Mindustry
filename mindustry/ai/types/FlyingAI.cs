// Decompiled with JetBrains decompiler
// Type: mindustry.ai.types.FlyingAI
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.ai.types
{
  public class FlyingAI : AIController
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FlyingAI()
    {
    }

    [LineNumberTable(new byte[] {159, 189, 156, 115, 148, 119, 158, 191, 19, 151, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void attack(float circleLength)
    {
      AIController.__\u003C\u003Evec.set((Position) this.target).sub((Position) this.unit);
      if ((double) Angles.angleDist(this.unit.angleTo((Position) this.target), this.unit.rotation()) > 70.0 && (double) AIController.__\u003C\u003Evec.len() < (double) circleLength)
        AIController.__\u003C\u003Evec.setAngle(this.unit.vel().angle());
      else
        AIController.__\u003C\u003Evec.setAngle(Angles.moveToward(this.unit.vel().angle(), AIController.__\u003C\u003Evec.angle(), 6f));
      AIController.__\u003C\u003Evec.setLength(this.unit.speed());
      this.unit.moveAt(AIController.__\u003C\u003Evec);
    }

    [LineNumberTable(new byte[] {159, 156, 127, 11, 114, 127, 4, 147, 203, 127, 45, 191, 3, 114, 159, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void updateMovement()
    {
      if (this.target != null && this.unit.hasWeapons() && object.ReferenceEquals((object) this.command(), (object) UnitCommand.__\u003C\u003Eattack))
      {
        if (!this.unit.type.circleTarget)
        {
          this.moveTo((Position) this.target, this.unit.type.range * 0.8f);
          this.unit.lookAt((Position) this.target);
        }
        else
          this.attack(120f);
      }
      if (this.target == null && object.ReferenceEquals((object) this.command(), (object) UnitCommand.__\u003C\u003Eattack) && (Vars.state.rules.waves && object.ReferenceEquals((object) this.unit.team, (object) Vars.state.rules.defaultTeam)))
        this.moveTo((Position) this.getClosestSpawner(), Vars.state.rules.dropZoneRadius + 120f);
      if (!object.ReferenceEquals((object) this.command(), (object) UnitCommand.__\u003C\u003Erally))
        return;
      this.moveTo((Position) this.targetFlag(this.unit.x, this.unit.y, BlockFlag.__\u003C\u003Erally, false), 60f);
    }

    [LineNumberTable(new byte[] {159, 134, 134, 111, 133, 116, 133, 116, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override Teamc findTarget(
      float x,
      float y,
      float range,
      bool air,
      bool ground)
    {
      int num1 = air ? 1 : 0;
      int num2 = ground ? 1 : 0;
      Teamc teamc = this.target(x, y, range, num1 != 0, num2 != 0);
      if (teamc != null)
        return teamc;
      if (num2 != 0)
        teamc = this.targetFlag(x, y, BlockFlag.__\u003C\u003Egenerator, true);
      if (teamc != null)
        return teamc;
      if (num2 != 0)
        teamc = this.targetFlag(x, y, BlockFlag.__\u003C\u003Ecore, true);
      return teamc ?? (Teamc) null;
    }

    [HideFromJava]
    static FlyingAI() => AIController.__\u003Cclinit\u003E();
  }
}
