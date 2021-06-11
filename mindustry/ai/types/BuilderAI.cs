// Decompiled with JetBrains decompiler
// Type: mindustry.ai.types.BuilderAI
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.world;
using mindustry.world.blocks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ai.types
{
  public class BuilderAI : AIController
  {
    public static float buildRadius;
    public static float retreatDst;
    public static float fleeRange;
    public static float retreatDelay;
    internal bool found;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    internal Unit following;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    internal Teamc enemy;
    internal float retreatTimer;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(153)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool shouldShoot() => !this.unit.isBuilding();

    [Modifiers]
    [LineNumberTable(new byte[] {48, 137, 127, 8, 135, 119, 127, 0, 191, 2, 127, 0, 103, 199})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024updateMovement\u00240([In] Unit obj0)
    {
      if (this.found || !obj0.canBuild() || (object.ReferenceEquals((object) obj0, (object) this.unit) || !obj0.activelyBuilding()))
        return;
      BuildPlan buildPlan = obj0.buildPlan();
      Building building = Vars.world.build(buildPlan.x, buildPlan.y);
      ConstructBlock.ConstructBuild constructBuild;
      if (!(building is ConstructBlock.ConstructBuild) || !object.ReferenceEquals((object) (constructBuild = (ConstructBlock.ConstructBuild) building), (object) (ConstructBlock.ConstructBuild) building) || (double) (Math.min(constructBuild.dst((Position) this.unit) - 220f, 0.0f) / this.unit.speed()) >= (double) (constructBuild.buildCost * 0.9f))
        return;
      this.following = obj0;
      this.found = true;
    }

    [LineNumberTable(new byte[] {159, 157, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BuilderAI()
    {
      BuilderAI builderAi = this;
      this.found = false;
    }

    [LineNumberTable(new byte[] {159, 168, 112, 177, 140, 104, 203, 122, 103, 112, 193, 112, 127, 1, 144, 115, 223, 10, 127, 0, 104, 108, 118, 236, 70, 112, 139, 172, 127, 2, 127, 7, 127, 31, 113, 129, 197, 159, 57, 127, 7, 159, 5, 132, 179, 145, 165, 115, 135, 255, 23, 84, 191, 45, 127, 30, 119, 174, 127, 38, 109, 159, 25, 159, 30, 181, 104, 201})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void updateMovement()
    {
      if (this.target != null && this.shouldShoot())
        this.unit.lookAt((Position) this.target);
      this.unit.updateBuilding = true;
      if (this.following != null)
      {
        this.retreatTimer = 0.0f;
        if (!this.following.isValid() || !this.following.activelyBuilding())
        {
          this.following = (Unit) null;
          this.unit.plans.clear();
          return;
        }
        this.unit.plans.clear();
        this.unit.plans.addFirst((object) this.following.buildPlan());
      }
      else if (this.unit.buildPlan() == null)
      {
        if (this.timer.get(3, 40f))
          this.enemy = this.target(this.unit.x, this.unit.y, BuilderAI.fleeRange, true, true);
        BuilderAI builderAi1 = this;
        float num1 = builderAi1.retreatTimer + Time.delta;
        BuilderAI builderAi2 = builderAi1;
        double num2 = (double) num1;
        builderAi2.retreatTimer = num1;
        double retreatDelay = (double) BuilderAI.retreatDelay;
        if (num2 >= retreatDelay && this.enemy != null)
        {
          Building building = this.unit.closestCore();
          if (building != null && !this.unit.within((Position) building, BuilderAI.retreatDst))
            this.moveTo((Position) building, BuilderAI.retreatDst);
        }
      }
      if (this.unit.buildPlan() != null)
      {
        this.retreatTimer = 0.0f;
        BuildPlan other = this.unit.buildPlan();
        if (!other.breaking && this.timer.get(1, 40f))
        {
          Iterator iterator = Groups.player.iterator();
          while (iterator.hasNext())
          {
            Player player = (Player) iterator.next();
            if (player.isBuilder() && player.unit().activelyBuilding() && (player.unit().buildPlan().samePos(other) && player.unit().buildPlan().breaking))
            {
              this.unit.plans.removeFirst();
              return;
            }
          }
        }
        if (other.tile() != null)
        {
          Building build = other.tile().build;
          ConstructBlock.ConstructBuild constructBuild;
          if (build is ConstructBlock.ConstructBuild && object.ReferenceEquals((object) (constructBuild = (ConstructBlock.ConstructBuild) build), (object) (ConstructBlock.ConstructBuild) build) && object.ReferenceEquals((object) constructBuild.cblock, (object) other.block))
            goto label_23;
        }
        if (other.breaking)
        {
          if (Build.validBreak(this.unit.team(), other.x, other.y))
            goto label_23;
        }
        else if (Build.validPlace(other.block, this.unit.team(), other.x, other.y, other.rotation))
          goto label_23;
        int num = 0;
        goto label_25;
label_23:
        num = 1;
label_25:
        if (num != 0)
          this.moveTo((Position) other.tile(), 200f);
        else
          this.unit.plans.removeFirst();
      }
      else
      {
        if (this.timer.get(1, 60f))
        {
          this.found = false;
          Units.nearby(this.unit.team, this.unit.x, this.unit.y, BuilderAI.buildRadius, (Cons) new BuilderAI.__\u003C\u003EAnon0(this));
        }
        float time = (float) ((!this.unit.team.rules().ai ? 2.0 : (double) Mathf.lerp(15f, 2f, this.unit.team.rules().aiTier)) * 60.0);
        if (this.unit.team.data().blocks.isEmpty() || this.following != null || !this.timer.get(2, time))
          return;
        Queue blocks = this.unit.team.data().blocks;
        Teams.BlockPlan blockPlan = (Teams.BlockPlan) blocks.first();
        if (Vars.world.tile((int) blockPlan.__\u003C\u003Ex, (int) blockPlan.__\u003C\u003Ey) != null && (int) Vars.world.tile((int) blockPlan.__\u003C\u003Ex, (int) blockPlan.__\u003C\u003Ey).block().__\u003C\u003Eid == (int) blockPlan.__\u003C\u003Eblock)
          blocks.removeFirst();
        else if (Build.validPlace(Vars.content.block((int) blockPlan.__\u003C\u003Eblock), this.unit.team(), (int) blockPlan.__\u003C\u003Ex, (int) blockPlan.__\u003C\u003Ey, (int) blockPlan.__\u003C\u003Erotation))
        {
          this.unit.addBuild(new BuildPlan((int) blockPlan.__\u003C\u003Ex, (int) blockPlan.__\u003C\u003Ey, (int) blockPlan.__\u003C\u003Erotation, Vars.content.block((int) blockPlan.__\u003C\u003Eblock), blockPlan.__\u003C\u003Econfig));
          blocks.addLast((object) (Teams.BlockPlan) blocks.removeFirst());
        }
        else
        {
          blocks.removeFirst();
          blocks.addLast((object) blockPlan);
        }
      }
    }

    [LineNumberTable(143)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override AIController fallback() => this.unit.type.flying ? (AIController) new FlyingAI() : (AIController) new GroundAI();

    [LineNumberTable(148)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool useFallback() => Vars.state.rules.waves && object.ReferenceEquals((object) this.unit.team, (object) Vars.state.rules.waveTeam) && !this.unit.team.rules().ai;

    [MethodImpl(MethodImplOptions.NoInlining)]
    static BuilderAI()
    {
      AIController.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("mindustry.ai.types.BuilderAI"))
        return;
      BuilderAI.buildRadius = 1500f;
      BuilderAI.retreatDst = 110f;
      BuilderAI.fleeRange = 370f;
      BuilderAI.retreatDelay = 120f;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly BuilderAI arg\u00241;

      internal __\u003C\u003EAnon0([In] BuilderAI obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024updateMovement\u00240((Unit) obj0);
    }
  }
}
