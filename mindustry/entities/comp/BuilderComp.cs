// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.BuilderComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.storage;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Posc", "mindustry.gen.Statusc", "mindustry.gen.Teamc", "mindustry.gen.Rotc"})]
  internal abstract class BuilderComp : 
    Object,
    Posc,
    Position,
    Entityc,
    Statusc,
    Flyingc,
    Healthc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Velc,
    Teamc,
    Rotc
  {
    [Modifiers]
    internal static Vec2[] vecs;
    internal float x;
    internal float y;
    internal float rotation;
    internal float buildSpeedMultiplier;
    internal UnitType type;
    internal Team team;
    [Signature("Larc/struct/Queue<Lmindustry/entities/units/BuildPlan;>;")]
    internal Queue plans;
    internal bool updateBuilding;
    [NonSerialized]
    private BuildPlan lastActive;
    [NonSerialized]
    private int lastSize;
    [NonSerialized]
    private float buildAlpha;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {160, 120, 104, 127, 24, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool activelyBuilding() => (!this.isBuilding() || Vars.state.isEditor() || this.within((Position) this.buildPlan(), !Vars.state.rules.infiniteResources ? 220f : float.MaxValue)) && (this.isBuilding() && this.updateBuilding);

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canBuild() => (double) this.type.buildSpeed > 0.0 && (double) this.buildSpeedMultiplier > 0.0;

    [HideFromJava]
    public abstract Team team();

    [HideFromJava]
    public abstract Building core();

    [LineNumberTable(245)]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual BuildPlan buildPlan() => this.plans.size == 0 ? (BuildPlan) null : (BuildPlan) this.plans.first();

    [HideFromJava]
    public virtual bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

    [LineNumberTable(new byte[] {160, 65, 159, 31})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool shouldSkip(BuildPlan _param1, [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] Building _param2) => !Vars.state.rules.infiniteResources && !this.team.rules().infiniteResources && (!_param1.breaking && _param2 != null) && !_param1.isRotation(this.team) && (_param1.stuck && !_param2.items.has(_param1.block.requirements) || Structs.contains((object[]) _param1.block.requirements, (Boolf) new BuilderComp.__\u003C\u003EAnon3(_param2)) && !_param1.initialized);

    [HideFromJava]
    public abstract Entityc self();

    [LineNumberTable(new byte[] {107, 107, 104, 146, 127, 21, 63, 0, 197})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void drawPlan([In] BuildPlan obj0, [In] float obj1)
    {
      obj0.animScale = 1f;
      if (obj0.breaking)
        Vars.control.input.drawBreaking(obj0);
      else
        obj0.block.drawPlan(obj0, Vars.control.input.allRequests(), Build.validPlace(obj0.block, this.team, obj0.x, obj0.y, obj0.rotation) || Vars.control.input.requestMatches(obj0), obj1);
    }

    [LineNumberTable(new byte[] {118, 104, 101, 127, 7, 103, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void drawPlanTop([In] BuildPlan obj0, [In] float obj1)
    {
      if (obj0.breaking)
        return;
      Draw.reset();
      Draw.mixcol(Color.__\u003C\u003Ewhite, 0.24f + Mathf.absin(Time.globalTime, 6f, 0.28f));
      Draw.alpha(obj1);
      obj0.block.drawRequestConfigTop(obj0, (Eachable) this.plans);
    }

    [LineNumberTable(new byte[] {159, 90, 98, 137, 98, 127, 1, 124, 98, 130, 98, 99, 141, 120, 127, 15, 141, 99, 142, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addBuild([In] BuildPlan obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      if (!this.canBuild())
        return;
      BuildPlan buildPlan1 = (BuildPlan) null;
      Iterator iterator = this.plans.iterator();
      while (iterator.hasNext())
      {
        BuildPlan buildPlan2 = (BuildPlan) iterator.next();
        if (buildPlan2.x == obj0.x && buildPlan2.y == obj0.y)
        {
          buildPlan1 = buildPlan2;
          break;
        }
      }
      if (buildPlan1 != null)
        this.plans.remove((object) buildPlan1);
      Tile tile = Vars.world.tile(obj0.x, obj0.y);
      if (tile != null)
      {
        Building build = tile.build;
        ConstructBlock.ConstructBuild constructBuild;
        if (build is ConstructBlock.ConstructBuild && object.ReferenceEquals((object) (constructBuild = (ConstructBlock.ConstructBuild) build), (object) (ConstructBlock.ConstructBuild) build))
          obj0.progress = constructBuild.progress;
      }
      if (num != 0)
        this.plans.addLast((object) obj0);
      else
        this.plans.addFirst((object) obj0);
    }

    [LineNumberTable(194)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isBuilding() => this.plans.size != 0;

    [HideFromJava]
    public abstract bool isLocal();

    [HideFromJava]
    public virtual float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

    [HideFromJava]
    public virtual bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

    [Modifiers]
    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024update\u00240([In] Building obj0, [In] ItemStack obj1) => obj0 != null && !obj0.items.has(obj1.item);

    [Modifiers]
    [LineNumberTable(118)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u00241([In] Tile obj0, [In] BuildPlan obj1) => Events.fire((object) new EventType.BuildSelectEvent(obj0, this.team, (Unit) this.self(), obj1.breaking));

    [Modifiers]
    [LineNumberTable(140)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024drawBuildPlans\u00242([In] BuildPlan obj0) => (double) obj0.progress > 0.00999999977648258 || object.ReferenceEquals((object) this.buildPlan(), (object) obj0) && obj0.initialized && (this.within((float) (obj0.x * 8), (float) (obj0.y * 8), 220f) || Vars.state.isEditor());

    [Modifiers]
    [LineNumberTable(181)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024shouldSkip\u00243([In] Building obj0, [In] ItemStack obj1) => !obj0.items.has(obj1.item) && Mathf.round((float) obj1.amount * Vars.state.rules.buildCostMultiplier) > 0;

    [Modifiers]
    [LineNumberTable(186)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024removeBuild\u00244(
      [In] bool obj0,
      [In] int obj1,
      [In] int obj2,
      [In] BuildPlan obj3)
    {
      int num = obj0 ? 1 : 0;
      return (obj3.breaking ? 1 : 0) == num && obj3.x == obj1 && obj3.y == obj2;
    }

    [Modifiers]
    [LineNumberTable(286)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024draw\u00245([In] float obj0, [In] Vec2 obj1) => -Angles.angleDist(this.angleTo((Position) obj1), obj0);

    [LineNumberTable(new byte[] {159, 171, 232, 71, 108, 199})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal BuilderComp()
    {
      BuilderComp builderComp = this;
      this.plans = new Queue(1);
      this.updateBuilding = true;
      this.buildAlpha = 0.0f;
    }

    [LineNumberTable(new byte[] {159, 191, 135, 117, 167, 191, 12, 145, 126, 159, 9, 108, 107, 108, 120, 127, 73, 134, 133, 168, 169, 110, 131, 127, 19, 108, 109, 200, 104, 137, 104, 107, 155, 140, 127, 14, 127, 37, 159, 24, 100, 159, 21, 136, 127, 19, 159, 10, 108, 129, 127, 59, 108, 161, 119, 121, 200, 127, 18, 193, 105, 159, 50, 191, 55, 122, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (!Vars.headless)
      {
        if (this.lastActive != null && (double) this.buildAlpha <= 0.00999999977648258)
          this.lastActive = (BuildPlan) null;
        this.buildAlpha = Mathf.lerpDelta(this.buildAlpha, !this.activelyBuilding() ? 0.0f : 1f, 0.15f);
      }
      if (!this.updateBuilding || !this.canBuild())
        return;
      float num1 = !Vars.state.rules.infiniteResources ? 220f : float.MaxValue;
      int num2 = Vars.state.rules.infiniteResources || this.team().rules().infiniteResources ? 1 : 0;
      Iterator iterator = this.plans.iterator();
      while (iterator.hasNext())
      {
        BuildPlan buildPlan = (BuildPlan) iterator.next();
        Tile tile = Vars.world.tile(buildPlan.x, buildPlan.y);
        if (tile == null || buildPlan.breaking && object.ReferenceEquals((object) tile.block(), (object) Blocks.air) || !buildPlan.breaking && (tile.build != null && tile.build.rotation == buildPlan.rotation || !buildPlan.block.rotate) && object.ReferenceEquals((object) tile.block(), (object) buildPlan.block))
          iterator.remove();
      }
      Building core = this.core();
      if (this.buildPlan() == null)
        return;
      if (this.plans.size > 1)
      {
        BuildPlan buildPlan;
        for (int index = 0; (!this.within((Position) (buildPlan = this.buildPlan()).tile(), num1) || this.shouldSkip(buildPlan, core)) && index < this.plans.size; ++index)
        {
          this.plans.removeFirst();
          this.plans.addLast((object) buildPlan);
        }
      }
      BuildPlan buildPlan1 = this.buildPlan();
      Tile tile1 = buildPlan1.tile();
      this.lastActive = buildPlan1;
      this.buildAlpha = 1f;
      if (buildPlan1.breaking)
        this.lastSize = tile1.block().size;
      if (!this.within((Position) tile1, num1))
        return;
      Building build1 = tile1.build;
      ConstructBlock.ConstructBuild constructBuild1;
      if (!(build1 is ConstructBlock.ConstructBuild) || !object.ReferenceEquals((object) (constructBuild1 = (ConstructBlock.ConstructBuild) build1), (object) (ConstructBlock.ConstructBuild) build1))
      {
        if (!buildPlan1.initialized && !buildPlan1.breaking && Build.validPlace(buildPlan1.block, this.team, buildPlan1.x, buildPlan1.y, buildPlan1.rotation))
        {
          if ((num2 != 0 || buildPlan1.isRotation(this.team) || !Structs.contains((object[]) buildPlan1.block.requirements, (Boolf) new BuilderComp.__\u003C\u003EAnon0(core)) ? 1 : 0) != 0)
            Call.beginPlace((Unit) this.self(), buildPlan1.block, this.team, buildPlan1.x, buildPlan1.y, buildPlan1.rotation);
          else
            buildPlan1.stuck = true;
        }
        else if (!buildPlan1.initialized && buildPlan1.breaking && Build.validBreak(this.team, buildPlan1.x, buildPlan1.y))
        {
          Call.beginBreak((Unit) this.self(), this.team, buildPlan1.x, buildPlan1.y);
        }
        else
        {
          this.plans.removeFirst();
          return;
        }
      }
      else if (!object.ReferenceEquals((object) tile1.team(), (object) this.team) && !object.ReferenceEquals((object) tile1.team(), (object) Team.__\u003C\u003Ederelict) || !buildPlan1.breaking && (!object.ReferenceEquals((object) constructBuild1.cblock, (object) buildPlan1.block) || !object.ReferenceEquals((object) constructBuild1.tile, (object) buildPlan1.tile())))
      {
        this.plans.removeFirst();
        return;
      }
      if (tile1.build is ConstructBlock.ConstructBuild && !buildPlan1.initialized)
      {
        Core.app.post((Runnable) new BuilderComp.__\u003C\u003EAnon1(this, tile1, buildPlan1));
        buildPlan1.initialized = true;
      }
      if (core == null && num2 == 0)
        return;
      Building build2 = tile1.build;
      ConstructBlock.ConstructBuild constructBuild2;
      if (!(build2 is ConstructBlock.ConstructBuild) || !object.ReferenceEquals((object) (constructBuild2 = (ConstructBlock.ConstructBuild) build2), (object) (ConstructBlock.ConstructBuild) build2))
        return;
      if (buildPlan1.breaking)
        constructBuild2.deconstruct((Unit) this.self(), core, 1f / constructBuild2.buildCost * Time.delta * this.type.buildSpeed * this.buildSpeedMultiplier * Vars.state.rules.buildSpeedMultiplier);
      else
        constructBuild2.construct((Unit) this.self(), core, 1f / constructBuild2.buildCost * Time.delta * this.type.buildSpeed * this.buildSpeedMultiplier * Vars.state.rules.buildSpeedMultiplier, buildPlan1.config);
      buildPlan1.stuck = Mathf.equal(buildPlan1.progress, constructBuild2.progress);
      buildPlan1.progress = constructBuild2.progress;
    }

    [LineNumberTable(new byte[] {90, 140, 105, 127, 1, 107, 99, 142, 140, 226, 56, 233, 75, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void drawBuildPlans()
    {
      Boolf boolf = (Boolf) new BuilderComp.__\u003C\u003EAnon2(this);
      for (int index = 0; index < 2; ++index)
      {
        Iterator iterator = this.plans.iterator();
        while (iterator.hasNext())
        {
          BuildPlan buildPlan = (BuildPlan) iterator.next();
          if (!boolf.get((object) buildPlan))
          {
            if (index == 0)
              this.drawPlan(buildPlan, 1f);
            else
              this.drawPlanTop(buildPlan, 1f);
          }
        }
      }
      Draw.reset();
    }

    [LineNumberTable(new byte[] {159, 96, 130, 121, 100, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void removeBuild([In] int obj0, [In] int obj1, [In] bool obj2)
    {
      int index = this.plans.indexOf((Boolf) new BuilderComp.__\u003C\u003EAnon4(obj2, obj0, obj1));
      if (index == -1)
        return;
      this.plans.removeIndex(index);
    }

    [LineNumberTable(new byte[] {160, 85, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void clearBuilding() => this.plans.clear();

    [LineNumberTable(new byte[] {160, 90, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addBuild([In] BuildPlan obj0) => this.addBuild(obj0, true);

    [LineNumberTable(new byte[] {160, 135, 103, 140, 138, 114, 119, 140, 127, 10, 193, 123, 106, 108, 108, 170, 127, 14, 146, 126, 127, 5, 120, 152, 110, 141, 121, 121, 121, 153, 156, 157, 124, 114, 156, 138, 139, 112, 191, 0, 111, 127, 1, 113, 147, 179, 109, 173, 159, 19, 101, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      int num1 = this.activelyBuilding() ? 1 : 0;
      if (num1 == 0 && this.lastActive == null)
        return;
      Draw.z(115f);
      BuildPlan buildPlan = num1 == 0 ? this.lastActive : this.buildPlan();
      Tile tile = Vars.world.tile(buildPlan.x, buildPlan.y);
      CoreBlock.CoreBuild coreBuild = this.team.core();
      if (tile == null || !this.within((Position) buildPlan, !Vars.state.rules.infiniteResources ? 220f : float.MaxValue))
        return;
      if (coreBuild != null && num1 != 0 && (!this.isLocal() && !(tile.block() is ConstructBlock)))
      {
        Draw.z(84f);
        this.drawPlan(buildPlan, 0.5f);
        this.drawPlanTop(buildPlan, 0.5f);
        Draw.z(115f);
      }
      int num2 = !buildPlan.breaking ? buildPlan.block.size : (num1 == 0 ? this.lastSize : tile.block().size);
      float num3 = buildPlan.drawx();
      float num4 = buildPlan.drawy();
      Lines.stroke(1f, !buildPlan.breaking ? Pal.accent : Pal.remove);
      float len = this.type.buildBeamOffset + Mathf.absin(Time.time, 3f, 0.6f);
      float num5 = this.x + Angles.trnsx(this.rotation, len);
      float num6 = this.y + Angles.trnsy(this.rotation, len);
      float num7 = (float) (8 * num2) / 2f;
      float num8 = this.angleTo(num3, num4);
      BuilderComp.vecs[0].set(num3 - num7, num4 - num7);
      BuilderComp.vecs[1].set(num3 + num7, num4 - num7);
      BuilderComp.vecs[2].set(num3 - num7, num4 + num7);
      BuilderComp.vecs[3].set(num3 + num7, num4 + num7);
      Arrays.sort((object[]) BuilderComp.vecs, Structs.comparingFloat((Floatf) new BuilderComp.__\u003C\u003EAnon5(this, num8)));
      Vec2 closest = (Vec2) Geometry.findClosest(this.x, this.y, (Position[]) BuilderComp.vecs);
      float x1 = BuilderComp.vecs[0].x;
      float y1 = BuilderComp.vecs[0].y;
      float x2 = closest.x;
      float y2 = closest.y;
      float x3 = BuilderComp.vecs[1].x;
      float y3 = BuilderComp.vecs[1].y;
      Draw.z(122f);
      Draw.alpha(this.buildAlpha);
      if (num1 == 0 && !(tile.build is ConstructBlock.ConstructBuild))
        Fill.square(buildPlan.drawx(), buildPlan.drawy(), (float) (num2 * 8) / 2f);
      if (Vars.renderer.animateShields)
      {
        if (!object.ReferenceEquals((object) closest, (object) BuilderComp.vecs[0]) && !object.ReferenceEquals((object) closest, (object) BuilderComp.vecs[1]))
        {
          Fill.tri(num5, num6, x1, y1, x2, y2);
          Fill.tri(num5, num6, x3, y3, x2, y2);
        }
        else
          Fill.tri(num5, num6, x1, y1, x3, y3);
      }
      else
      {
        Lines.line(num5, num6, x1, y1);
        Lines.line(num5, num6, x3, y3);
      }
      Fill.square(num5, num6, 1.8f + Mathf.absin(Time.time, 2.2f, 1.1f), this.rotation + 45f);
      Draw.reset();
      Draw.z(115f);
    }

    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static BuilderComp()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.comp.BuilderComp"))
        return;
      BuilderComp.vecs = new Vec2[4]
      {
        new Vec2(),
        new Vec2(),
        new Vec2(),
        new Vec2()
      };
    }

    [HideFromJava]
    public abstract float getX();

    [HideFromJava]
    public abstract float getY();

    [HideFromJava]
    public virtual float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

    [HideFromJava]
    public virtual float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

    [HideFromJava]
    public virtual float dst([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float dst2([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst2((Position) this, obj0, obj1);

    [HideFromJava]
    public abstract bool isAdded();

    [HideFromJava]
    public abstract void remove();

    [HideFromJava]
    public abstract void add();

    [HideFromJava]
    public abstract bool isRemote();

    [HideFromJava]
    public abstract bool isNull();

    [HideFromJava]
    public abstract object @as();

    [HideFromJava]
    public abstract object with([In] Cons obj0);

    [HideFromJava]
    public abstract int classId();

    [HideFromJava]
    public abstract bool serialize();

    [HideFromJava]
    public abstract void read([In] Reads obj0);

    [HideFromJava]
    public abstract void write([In] Writes obj0);

    [HideFromJava]
    public abstract void afterRead();

    [HideFromJava]
    public abstract int id();

    [HideFromJava]
    public abstract void id([In] int obj0);

    [HideFromJava]
    public abstract void set([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void set([In] Position obj0);

    [HideFromJava]
    public abstract void trns([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void trns([In] Position obj0);

    [HideFromJava]
    public abstract int tileX();

    [HideFromJava]
    public abstract int tileY();

    [HideFromJava]
    public abstract Floor floorOn();

    [HideFromJava]
    public abstract Block blockOn();

    [HideFromJava]
    public abstract bool onSolid();

    [HideFromJava]
    public abstract Tile tileOn();

    [HideFromJava]
    public abstract float x();

    [HideFromJava]
    public abstract void x([In] float obj0);

    [HideFromJava]
    public abstract float y();

    [HideFromJava]
    public abstract void y([In] float obj0);

    [HideFromJava]
    public abstract bool isValid();

    [HideFromJava]
    public abstract float healthf();

    [HideFromJava]
    public abstract void killed();

    [HideFromJava]
    public abstract void kill();

    [HideFromJava]
    public abstract void heal();

    [HideFromJava]
    public abstract bool damaged();

    [HideFromJava]
    public abstract void damagePierce([In] float obj0, [In] bool obj1);

    [HideFromJava]
    public abstract void damagePierce([In] float obj0);

    [HideFromJava]
    public abstract void damage([In] float obj0);

    [HideFromJava]
    public abstract void damage([In] float obj0, [In] bool obj1);

    [HideFromJava]
    public abstract void damageContinuous([In] float obj0);

    [HideFromJava]
    public abstract void damageContinuousPierce([In] float obj0);

    [HideFromJava]
    public abstract void clampHealth();

    [HideFromJava]
    public abstract void heal([In] float obj0);

    [HideFromJava]
    public abstract void healFract([In] float obj0);

    [HideFromJava]
    public abstract float health();

    [HideFromJava]
    public abstract void health([In] float obj0);

    [HideFromJava]
    public abstract float hitTime();

    [HideFromJava]
    public abstract void hitTime([In] float obj0);

    [HideFromJava]
    public abstract float maxHealth();

    [HideFromJava]
    public abstract void maxHealth([In] float obj0);

    [HideFromJava]
    public abstract bool dead();

    [HideFromJava]
    public abstract void dead([In] bool obj0);

    [HideFromJava]
    public abstract float hitSize();

    [HideFromJava]
    public abstract void hitbox([In] Rect obj0);

    [HideFromJava]
    public abstract void getCollisions([In] Cons obj0);

    [HideFromJava]
    public abstract void updateLastPosition();

    [HideFromJava]
    public abstract void collision([In] Hitboxc obj0, [In] float obj1, [In] float obj2);

    [HideFromJava]
    public abstract float deltaLen();

    [HideFromJava]
    public abstract float deltaAngle();

    [HideFromJava]
    public abstract bool collides([In] Hitboxc obj0);

    [HideFromJava]
    public abstract void hitboxTile([In] Rect obj0);

    [HideFromJava]
    public abstract float lastX();

    [HideFromJava]
    public abstract void lastX([In] float obj0);

    [HideFromJava]
    public abstract float lastY();

    [HideFromJava]
    public abstract void lastY([In] float obj0);

    [HideFromJava]
    public abstract float deltaX();

    [HideFromJava]
    public abstract void deltaX([In] float obj0);

    [HideFromJava]
    public abstract float deltaY();

    [HideFromJava]
    public abstract void deltaY([In] float obj0);

    [HideFromJava]
    public abstract void hitSize([In] float obj0);

    [HideFromJava]
    public abstract EntityCollisions.SolidPred solidity();

    [HideFromJava]
    public abstract bool canPass([In] int obj0, [In] int obj1);

    [HideFromJava]
    public abstract bool canPassOn();

    [HideFromJava]
    public abstract bool moving();

    [HideFromJava]
    public abstract void move([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract Vec2 vel();

    [HideFromJava]
    public abstract float drag();

    [HideFromJava]
    public abstract void drag([In] float obj0);

    [HideFromJava]
    public abstract bool checkTarget([In] bool obj0, [In] bool obj1);

    [HideFromJava]
    public abstract bool isGrounded();

    [HideFromJava]
    public abstract bool isFlying();

    [HideFromJava]
    public abstract bool canDrown();

    [HideFromJava]
    public abstract void landed();

    [HideFromJava]
    public abstract void wobble();

    [HideFromJava]
    public abstract void moveAt([In] Vec2 obj0, [In] float obj1);

    [HideFromJava]
    public abstract float floorSpeedMultiplier();

    [HideFromJava]
    public abstract float elevation();

    [HideFromJava]
    public abstract void elevation([In] float obj0);

    [HideFromJava]
    public abstract bool hovering();

    [HideFromJava]
    public abstract void hovering([In] bool obj0);

    [HideFromJava]
    public abstract float drownTime();

    [HideFromJava]
    public abstract void drownTime([In] float obj0);

    [HideFromJava]
    public abstract float splashTimer();

    [HideFromJava]
    public abstract void splashTimer([In] float obj0);

    [HideFromJava]
    public abstract void apply([In] StatusEffect obj0);

    [HideFromJava]
    public abstract void apply([In] StatusEffect obj0, [In] float obj1);

    [HideFromJava]
    public abstract void clearStatuses();

    [HideFromJava]
    public abstract void unapply([In] StatusEffect obj0);

    [HideFromJava]
    public abstract bool isBoss();

    [HideFromJava]
    public abstract bool isImmune([In] StatusEffect obj0);

    [HideFromJava]
    public abstract Color statusColor();

    [HideFromJava]
    public abstract bool hasEffect([In] StatusEffect obj0);

    [HideFromJava]
    public abstract float speedMultiplier();

    [HideFromJava]
    public abstract float damageMultiplier();

    [HideFromJava]
    public abstract float healthMultiplier();

    [HideFromJava]
    public abstract float reloadMultiplier();

    [HideFromJava]
    public abstract float buildSpeedMultiplier();

    [HideFromJava]
    public abstract float dragMultiplier();

    [HideFromJava]
    public abstract bool disarmed();

    [HideFromJava]
    public abstract bool cheating();

    [HideFromJava]
    public abstract Building closestCore();

    [HideFromJava]
    public abstract Building closestEnemyCore();

    [HideFromJava]
    public abstract void team([In] Team obj0);

    [HideFromJava]
    public abstract float rotation();

    [HideFromJava]
    public abstract void rotation([In] float obj0);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon0([In] Building obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (BuilderComp.lambda\u0024update\u00240(this.arg\u00241, (ItemStack) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly BuilderComp arg\u00241;
      private readonly Tile arg\u00242;
      private readonly BuildPlan arg\u00243;

      internal __\u003C\u003EAnon1([In] BuilderComp obj0, [In] Tile obj1, [In] BuildPlan obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024update\u00241(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      private readonly BuilderComp arg\u00241;

      internal __\u003C\u003EAnon2([In] BuilderComp obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024drawBuildPlans\u00242((BuildPlan) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolf
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon3([In] Building obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (BuilderComp.lambda\u0024shouldSkip\u00243(this.arg\u00241, (ItemStack) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Boolf
    {
      private readonly bool arg\u00241;
      private readonly int arg\u00242;
      private readonly int arg\u00243;

      internal __\u003C\u003EAnon4([In] bool obj0, [In] int obj1, [In] int obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public bool get([In] object obj0) => (BuilderComp.lambda\u0024removeBuild\u00244(this.arg\u00241, this.arg\u00242, this.arg\u00243, (BuildPlan) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Floatf
    {
      private readonly BuilderComp arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon5([In] BuilderComp obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get([In] object obj0) => this.arg\u00241.lambda\u0024draw\u00245(this.arg\u00242, (Vec2) obj0);
    }
  }
}
