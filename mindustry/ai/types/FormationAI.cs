// Decompiled with JetBrains decompiler
// Type: mindustry.ai.types.FormationAI
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using mindustry.ai.formations;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.world;
using mindustry.world.blocks.storage;
using System.Runtime.CompilerServices;

namespace mindustry.ai.types
{
  [Implements(new string[] {"mindustry.ai.formations.FormationMember"})]
  public class FormationAI : AIController, FormationMember
  {
    public Unit leader;
    private Vec3 target;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private Formation formation;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 159, 232, 61, 203, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FormationAI(Unit leader, Formation formation)
    {
      FormationAI formationAi = this;
      this.target = new Vec3();
      this.leader = leader;
      this.formation = formation;
    }

    [LineNumberTable(new byte[] {159, 166, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init() => this.target.set(this.unit.x, this.unit.y, 0.0f);

    [LineNumberTable(new byte[] {159, 172, 117, 107, 161, 114, 191, 69, 151, 159, 4, 114, 127, 6, 109, 188, 159, 2, 116, 159, 59, 127, 1, 127, 12, 150, 145, 127, 61, 127, 16, 159, 35, 171, 98, 204, 127, 8, 107, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void updateUnit()
    {
      if (this.leader == null || this.leader.dead)
      {
        this.unit.resetController();
      }
      else
      {
        if (this.unit.type.canBoost)
          this.unit.elevation = Mathf.approachDelta(this.unit.elevation, !this.unit.onSolid() ? (!this.leader.type.canBoost ? 0.0f : this.leader.elevation) : 1f, this.unit.type.riseSpeed);
        this.unit.controlWeapons(true, this.leader.isShooting);
        this.unit.aim(this.leader.aimX(), this.leader.aimY());
        if (this.unit.type.rotateShooting)
          this.unit.lookAt(this.leader.aimX(), this.leader.aimY());
        else if (this.unit.moving())
          this.unit.lookAt(this.unit.vel.angle());
        Vec2 vec2 = AIController.__\u003C\u003Evec.set(this.target).add(this.leader.vel);
        float num = this.unit.realSpeed() * Time.delta;
        this.unit.approach(Mathf.arrive(this.unit.x, this.unit.y, vec2.x, vec2.y, this.unit.vel, num, 0.0f, num, 1f).scl(1f / Time.delta));
        if (this.unit.canMine() && this.leader.canMine())
        {
          if (this.leader.mineTile != null && this.unit.validMine(this.leader.mineTile))
          {
            this.unit.mineTile(this.leader.mineTile);
            CoreBlock.CoreBuild coreBuild = this.unit.team.core();
            if (coreBuild != null && this.leader.mineTile.drop() != null && (this.unit.within((Position) coreBuild, this.unit.type.range) && !this.unit.acceptsItem(this.leader.mineTile.drop())) && coreBuild.acceptStack(this.unit.stack.item, this.unit.stack.amount, (Teamc) this.unit) > 0)
            {
              Call.transferItemTo(this.unit, this.unit.stack.item, this.unit.stack.amount, this.unit.x, this.unit.y, (Building) coreBuild);
              this.unit.clearItem();
            }
          }
          else
            this.unit.mineTile((Tile) null);
        }
        if (!this.unit.canBuild() || !this.leader.canBuild() || !this.leader.activelyBuilding())
          return;
        this.unit.clearBuilding();
        this.unit.addBuild(this.leader.buildPlan());
      }
    }

    [LineNumberTable(new byte[] {30, 104, 108, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void removed(Unit unit)
    {
      if (this.formation == null)
        return;
      this.formation.removeMember((FormationMember) this);
      unit.resetController();
    }

    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float formationSize() => this.unit.hitSize * 1.1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isBeingControlled(Unit player) => object.ReferenceEquals((object) this.leader, (object) player);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 formationPos() => this.target;

    [HideFromJava]
    static FormationAI() => AIController.__\u003Cclinit\u003E();
  }
}
