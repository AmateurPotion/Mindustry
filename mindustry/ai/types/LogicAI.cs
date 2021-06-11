// Decompiled with JetBrains decompiler
// Type: mindustry.ai.types.LogicAI
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.logic;
using mindustry.world;
using mindustry.world.meta;
using System;
using System.Runtime.CompilerServices;

namespace mindustry.ai.types
{
  public class LogicAI : AIController
  {
    public const float transferDelay = 120f;
    public const float logicControlTimeout = 600f;
    public LUnitControl control;
    public float moveX;
    public float moveY;
    public float moveRad;
    public float itemTimer;
    public float payTimer;
    public float controlTimer;
    public float targetTimer;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Building controller;
    public BuildPlan plan;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Object;Ljava/lang/Object;>;")]
    public ObjectMap execCache;
    public LUnitControl aimControl;
    public bool boost;
    public Teamc mainTarget;
    public bool shoot;
    public PosTeam posTarget;
    [Signature("Larc/struct/ObjectSet<Ljava/lang/Object;>;")]
    private ObjectSet radars;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {68, 132, 151, 159, 23, 122, 104, 114, 104, 203, 153, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void moveTo(Position target, float circleLength, float smooth)
    {
      if (target == null)
        return;
      AIController.__\u003C\u003Evec.set(target).sub((Position) this.unit);
      float num = (double) circleLength > 1.0 / 1000.0 ? Mathf.clamp((this.unit.dst(target) - circleLength) / smooth, -1f, 1f) : 1f;
      AIController.__\u003C\u003Evec.setLength(this.unit.realSpeed() * num);
      if ((double) num < -0.5)
        AIController.__\u003C\u003Evec.rotate(180f);
      else if ((double) num < 0.0)
        AIController.__\u003C\u003Evec.setZero();
      if (AIController.__\u003C\u003Evec.isNaN() || AIController.__\u003C\u003Evec.isInfinite())
        return;
      this.unit.approach(AIController.__\u003C\u003Evec);
    }

    [LineNumberTable(new byte[] {159, 158, 232, 70, 139, 171, 171, 171, 235, 73, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LogicAI()
    {
      LogicAI logicAi = this;
      this.control = LUnitControl.__\u003C\u003Eidle;
      this.controlTimer = 600f;
      this.plan = new BuildPlan();
      this.execCache = new ObjectMap();
      this.aimControl = LUnitControl.__\u003C\u003Estop;
      this.posTarget = PosTeam.create();
      this.radars = new ObjectSet();
    }

    [LineNumberTable(new byte[] {159, 190, 127, 1, 159, 1, 109, 149, 107, 203, 127, 3, 149, 107, 161, 159, 14, 63, 7, 197, 63, 15, 197, 140, 127, 29, 130, 127, 19, 103, 191, 10, 170, 114, 159, 4, 118, 231, 46, 226, 87, 203, 127, 5, 223, 33, 104, 121, 124, 159, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void updateMovement()
    {
      if ((double) this.itemTimer >= 0.0)
        this.itemTimer -= Time.delta;
      if ((double) this.payTimer >= 0.0)
        this.payTimer -= Time.delta;
      if ((double) this.targetTimer > 0.0)
      {
        this.targetTimer -= Time.delta;
      }
      else
      {
        this.radars.clear();
        this.targetTimer = 40f;
      }
      if ((double) this.controlTimer > 0.0 && this.controller != null && this.controller.isValid())
      {
        this.controlTimer -= Time.delta;
        switch (LogicAI.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[this.control.ordinal()])
        {
          case 1:
            this.moveTo((Position) Tmp.__\u003C\u003Ev1.set(this.moveX, this.moveY), 1f, 30f);
            break;
          case 2:
            this.moveTo((Position) Tmp.__\u003C\u003Ev1.set(this.moveX, this.moveY), this.moveRad - 7f, 7f);
            break;
          case 3:
            Building building = this.unit.closestEnemyCore();
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
              {
                this.pathfind(1);
                break;
              }
              break;
            }
            break;
          case 4:
            this.unit.clearBuilding();
            break;
        }
        if (this.unit.type.canBoost && !this.unit.type.flying)
          this.unit.elevation = Mathf.approachDelta(this.unit.elevation, (float) Mathf.num(this.boost || this.unit.onSolid()), 0.08f);
        if (!this.shoot)
        {
          this.unit.lookAt(this.unit.prefRotation());
        }
        else
        {
          if (!this.unit.hasWeapons() || this.unit.mounts.Length <= 0)
            return;
          this.unit.lookAt(this.unit.mounts[0].aimX, this.unit.mounts[0].aimY);
        }
      }
      else
        this.unit.resetController();
    }

    [LineNumberTable(113)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool checkTargetTimer(object radar) => this.radars.add(radar);

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override bool checkTarget(Teamc target, float x, float y, float range) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override bool retarget() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override bool invalid(Teamc target) => false;

    [LineNumberTable(155)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override bool shouldShoot() => this.shoot && (!this.unit.type.canBoost || !this.boost);

    [LineNumberTable(new byte[] {111, 127, 3, 104, 104, 225, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override Teamc target(
      float x,
      float y,
      float range,
      bool air,
      bool ground)
    {
      Teamc teamc1;
      switch (LogicAI.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[this.aimControl.ordinal()])
      {
        case 5:
          teamc1 = (Teamc) this.posTarget;
          break;
        case 6:
          teamc1 = this.mainTarget;
          break;
        default:
          teamc1 = (Teamc) null;
          break;
      }
      if (teamc1 == null)
        return (Teamc) null;
      return teamc1 is Teamc teamc2 ? teamc2 : throw new IncompatibleClassChangeError();
    }

    [HideFromJava]
    static LogicAI() => AIController.__\u003Cclinit\u003E();

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(66)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.ai.types.LogicAI$1"))
          return;
        LogicAI.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl = new int[LUnitControl.values().Length];
        try
        {
          LogicAI.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Emove.ordinal()] = 1;
          goto label_6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_6:
        try
        {
          LogicAI.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Eapproach.ordinal()] = 2;
          goto label_10;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_10:
        try
        {
          LogicAI.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Epathfind.ordinal()] = 3;
          goto label_14;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_14:
        try
        {
          LogicAI.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Estop.ordinal()] = 4;
          goto label_18;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_18:
        try
        {
          LogicAI.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Etarget.ordinal()] = 5;
          goto label_22;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_22:
        try
        {
          LogicAI.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Etargetp.ordinal()] = 6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }
  }
}
