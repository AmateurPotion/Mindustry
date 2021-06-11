// Decompiled with JetBrains decompiler
// Type: mindustry.entities.units.AIController
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.units
{
  public class AIController : Object, UnitController
  {
    internal static Vec2 __\u003C\u003Evec;
    protected internal const int timerTarget = 0;
    protected internal const int timerTarget2 = 1;
    protected internal const int timerTarget3 = 2;
    protected internal const int timerTarget4 = 3;
    protected internal Unit unit;
    protected internal Interval timer;
    protected internal AIController fallback;
    protected internal Teamc target;
    protected internal Teamc[] targets;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool useFallback() => false;

    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual AIController fallback() => (AIController) null;

    [LineNumberTable(new byte[] {160, 112, 143, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unit(Unit unit)
    {
      if (object.ReferenceEquals((object) this.unit, (object) unit))
        return;
      this.unit = unit;
      this.init();
    }

    [LineNumberTable(new byte[] {159, 179, 127, 4, 127, 10, 107, 161, 102, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateUnit()
    {
      if (this.useFallback())
      {
        if (this.fallback == null)
        {
          AIController aiController1 = this;
          AIController aiController2 = this.fallback();
          AIController aiController3 = aiController2;
          this.fallback = aiController2;
          if (aiController3 == null)
            goto label_6;
        }
        if (!object.ReferenceEquals((object) this.fallback.unit, (object) this.unit))
          this.fallback.unit(this.unit);
        this.fallback.updateUnit();
        return;
      }
label_6:
      this.updateVisuals();
      this.updateTargeting();
      this.updateMovement();
    }

    [LineNumberTable(new byte[] {12, 109, 139, 151})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void updateVisuals()
    {
      if (!this.unit.isFlying())
        return;
      this.unit.wobble();
      this.unit.lookAt(this.unit.prefRotation());
    }

    [LineNumberTable(new byte[] {24, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void updateTargeting()
    {
      if (!this.unit.hasWeapons())
        return;
      this.updateWeapons();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void updateMovement()
    {
    }

    [LineNumberTable(new byte[] {47, 159, 13, 115, 135, 99, 191, 47, 110, 167, 140, 111, 110, 136, 127, 5, 159, 5, 114, 147, 99, 191, 24, 127, 2, 201, 131, 109, 159, 15, 127, 2, 109, 173, 104, 136, 116, 100, 113, 241, 29, 233, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void updateWeapons()
    {
      if (this.targets.Length != this.unit.mounts.Length)
        this.targets = new Teamc[this.unit.mounts.Length];
      float angle = this.unit.rotation - 90f;
      int num1 = this.retarget() ? 1 : 0;
      if (num1 != 0)
        this.target = this.findTarget(this.unit.x, this.unit.y, this.unit.range(), this.unit.type.targetAir, this.unit.type.targetGround);
      if (this.invalid(this.target))
        this.target = (Teamc) null;
      this.unit.isShooting = false;
      for (int index = 0; index < this.targets.Length; ++index)
      {
        WeaponMount mount = this.unit.mounts[index];
        Weapon weapon = mount.__\u003C\u003Eweapon;
        float x = this.unit.x + Angles.trnsx(angle, weapon.x, weapon.y);
        float y = this.unit.y + Angles.trnsy(angle, weapon.x, weapon.y);
        if (this.unit.type.singleTarget)
        {
          this.targets[index] = this.target;
        }
        else
        {
          if (num1 != 0)
            this.targets[index] = this.findTarget(x, y, weapon.bullet.range(), weapon.bullet.collidesAir, weapon.bullet.collidesGround);
          if (this.checkTarget(this.targets[index], x, y, weapon.bullet.range()))
            this.targets[index] = (Teamc) null;
        }
        int num2 = 0;
        if (this.targets[index] != null)
        {
          num2 = !this.targets[index].within(x, y, weapon.bullet.range()) || !this.shouldShoot() ? 0 : 1;
          Vec2 vec2 = Predict.intercept((Position) this.unit, (Position) this.targets[index], weapon.bullet.speed);
          mount.aimX = vec2.x;
          mount.aimY = vec2.y;
        }
        mount.shoot = num2 != 0;
        mount.rotate = num2 != 0;
        Unit unit = this.unit;
        unit.isShooting = ((unit.isShooting ? 1 : 0) | num2) != 0;
        if (num2 != 0)
        {
          this.unit.aimX = mount.aimX;
          this.unit.aimY = mount.aimY;
        }
      }
    }

    [LineNumberTable(170)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool retarget() => this.timer.get(0, this.target != null ? 90f : 40f);

    [LineNumberTable(174)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Teamc findTarget(
      float x,
      float y,
      float range,
      bool air,
      bool ground)
    {
      int num1 = air ? 1 : 0;
      int num2 = ground ? 1 : 0;
      return this.target(x, y, range, num1 != 0, num2 != 0);
    }

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool invalid(Teamc target) => Units.invalidateTarget((Posc) target, this.unit.team, this.unit.x, this.unit.y);

    [LineNumberTable(153)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool checkTarget(Teamc target, float x, float y, float range) => Units.invalidateTarget((Posc) target, this.unit.team, x, y, range);

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool shouldShoot() => true;

    [LineNumberTable(166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Teamc target(
      float x,
      float y,
      float range,
      bool air,
      bool ground)
    {
      int num1 = air ? 1 : 0;
      int num2 = ground ? 1 : 0;
      return Units.closestTarget(this.unit.team, x, y, range, (Boolf) new AIController.__\u003C\u003EAnon0(num1 != 0, num2 != 0), (Boolf) new AIController.__\u003C\u003EAnon1(num2 != 0));
    }

    [LineNumberTable(new byte[] {160, 76, 132, 151, 111, 191, 6, 141, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void circle(Position target, float circleLength, float speed)
    {
      if (target == null)
        return;
      AIController.__\u003C\u003Evec.set(target).sub((Position) this.unit);
      if ((double) AIController.__\u003C\u003Evec.len() < (double) circleLength)
        AIController.__\u003C\u003Evec.rotate((circleLength - AIController.__\u003C\u003Evec.len()) / circleLength * 180f);
      AIController.__\u003C\u003Evec.setLength(speed);
      this.unit.moveAt(AIController.__\u003C\u003Evec);
    }

    [LineNumberTable(new byte[] {160, 94, 132, 151, 159, 23, 122, 104, 114, 104, 171, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void moveTo(Position target, float circleLength, float smooth)
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
      this.unit.moveAt(AIController.__\u003C\u003Evec);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void init()
    {
    }

    [Modifiers]
    [LineNumberTable(166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024target\u00240([In] bool obj0, [In] bool obj1, [In] Unit obj2)
    {
      int num1 = obj0 ? 1 : 0;
      int num2 = obj1 ? 1 : 0;
      return obj2.checkTarget(num1 != 0, num2 != 0);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024target\u00241([In] bool obj0, [In] Building obj1) => obj0;

    [LineNumberTable(new byte[] {159, 158, 232, 69, 236, 70, 172, 119, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AIController()
    {
      AIController aiController = this;
      this.timer = new Interval(4);
      this.targets = new Teamc[0];
      this.timer.reset(0, Mathf.random(40f));
      this.timer.reset(1, Mathf.random(60f));
    }

    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual UnitCommand command() => this.unit.team.data().command;

    [LineNumberTable(new byte[] {35, 140, 108, 100, 159, 4, 155, 127, 28})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void pathfind(int pathTarget)
    {
      int costType = this.unit.pathType();
      Tile tile = this.unit.tileOn();
      if (tile == null)
        return;
      Tile targetTile = Vars.pathfinder.getTargetTile(tile, Vars.pathfinder.getField(this.unit.team, costType, pathTarget));
      if (object.ReferenceEquals((object) tile, (object) targetTile) || costType == 2 && !targetTile.floor().isLiquid)
        return;
      this.unit.moveAt(AIController.__\u003C\u003Evec.trns(this.unit.angleTo(targetTile.worldx(), targetTile.worldy()), this.unit.speed()));
    }

    [LineNumberTable(new byte[] {159, 102, 99, 127, 52})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Teamc targetFlag(float x, float y, BlockFlag flag, bool enemy)
    {
      int num1 = enemy ? 1 : 0;
      double num2 = (double) x;
      double num3 = (double) y;
      Object @object = num1 == 0 ? (Object) Vars.indexer.getAllied(this.unit.team, flag) : (Object) Vars.indexer.getEnemy(this.unit.team, flag);
      Iterable list;
      if (@object != null)
        list = @object is Iterable iterable2 ? iterable2 : throw new IncompatibleClassChangeError();
      else
        list = (Iterable) null;
      Tile closest = (Tile) Geometry.findClosest((float) num2, (float) num3, list);
      return closest == null ? (Teamc) null : (Teamc) closest.build;
    }

    [LineNumberTable(182)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Tile getClosestSpawner() => (Tile) Geometry.findClosest(this.unit.x, this.unit.y, (Iterable) Vars.spawner.getSpawns());

    [LineNumberTable(new byte[] {160, 72, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void circle(Position target, float circleLength) => this.circle(target, circleLength, this.unit.speed());

    [LineNumberTable(new byte[] {160, 90, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void moveTo(Position target, float circleLength) => this.moveTo(target, circleLength, 100f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Unit unit() => this.unit;

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static AIController()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.units.AIController"))
        return;
      AIController.__\u003C\u003Evec = new Vec2();
    }

    [HideFromJava]
    public virtual bool isValidController() => UnitController.\u003Cdefault\u003EisValidController((UnitController) this);

    [HideFromJava]
    public virtual void command([In] UnitCommand obj0) => UnitController.\u003Cdefault\u003Ecommand((UnitController) this, obj0);

    [HideFromJava]
    public virtual void removed([In] Unit obj0) => UnitController.\u003Cdefault\u003Eremoved((UnitController) this, obj0);

    [HideFromJava]
    public virtual bool isBeingControlled([In] Unit obj0) => UnitController.\u003Cdefault\u003EisBeingControlled((UnitController) this, obj0);

    [Modifiers]
    protected internal static Vec2 vec
    {
      [HideFromJava] get => AIController.__\u003C\u003Evec;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly bool arg\u00241;
      private readonly bool arg\u00242;

      internal __\u003C\u003EAnon0([In] bool obj0, [In] bool obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (AIController.lambda\u0024target\u00240(this.arg\u00241, this.arg\u00242, (Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      private readonly bool arg\u00241;

      internal __\u003C\u003EAnon1([In] bool obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (AIController.lambda\u0024target\u00241(this.arg\u00241, (Building) obj0) ? 1 : 0) != 0;
    }
  }
}
