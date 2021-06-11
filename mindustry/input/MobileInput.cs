// Decompiled with JetBrains decompiler
// Type: mindustry.input.MobileInput
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics.g2d;
using arc.input;
using arc.math;
using arc.math.geom;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.core;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using mindustry.world;
using mindustry.world.blocks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.input
{
  [Implements(new string[] {"arc.input.GestureDetector$GestureListener"})]
  public class MobileInput : InputHandler, GestureDetector.GestureListener
  {
    private const float maxPanSpeed = 1.3f;
    internal float __\u003C\u003EedgePan;
    public Vec2 vector;
    public Vec2 movement;
    public Vec2 targetPos;
    public float lastZoom;
    public int lineStartX;
    public int lineStartY;
    public int lastLineX;
    public int lastLineY;
    public float lineScale;
    public float crosshairScale;
    public Teamc lastTarget;
    public float shiftDeltaX;
    public float shiftDeltaY;
    [Signature("Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;")]
    public Seq removals;
    public bool selecting;
    public bool lineMode;
    public bool schematicMode;
    public PlaceMode mode;
    public Block lastBlock;
    public BuildPlan lastPlaced;
    public bool down;
    public bool manualShooting;
    public Teamc target;
    public Position payloadTarget;
    public Unit unitTapped;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 174, 200, 177, 127, 2, 235, 78, 235, 70, 235, 70, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MobileInput()
    {
      MobileInput mobileInput = this;
      this.__\u003C\u003EedgePan = Scl.scl(60f);
      this.vector = new Vec2();
      this.movement = new Vec2();
      this.targetPos = new Vec2();
      this.lastZoom = -1f;
      this.removals = new Seq();
      this.mode = PlaceMode.__\u003C\u003Enone;
      this.down = false;
      this.manualShooting = false;
    }

    [LineNumberTable(new byte[] {86, 112, 153, 127, 4, 135, 133, 104, 121, 191, 22, 121, 191, 20, 115, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual BuildPlan getRequest([In] Tile obj0)
    {
      InputHandler.r2.setSize(8f);
      InputHandler.r2.setCenter(obj0.worldx(), obj0.worldy());
      Iterator iterator = this.selectRequests.iterator();
      while (iterator.hasNext())
      {
        BuildPlan buildPlan = (BuildPlan) iterator.next();
        Tile tile = buildPlan.tile();
        if (tile != null)
        {
          if (!buildPlan.breaking)
          {
            InputHandler.r1.setSize((float) (buildPlan.block.size * 8));
            InputHandler.r1.setCenter(tile.worldx() + buildPlan.block.offset, tile.worldy() + buildPlan.block.offset);
          }
          else
          {
            InputHandler.r1.setSize((float) (tile.block().size * 8));
            InputHandler.r1.setCenter(tile.worldx() + tile.block().offset, tile.worldy() + tile.block().offset);
          }
          if (InputHandler.r2.overlaps(InputHandler.r1))
            return buildPlan;
        }
      }
      return (BuildPlan) null;
    }

    [LineNumberTable(new byte[] {161, 18, 105, 159, 13, 104, 159, 5, 127, 17, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void drawRequest(BuildPlan request)
    {
      if (request.tile() == null)
        return;
      BuildPlan brequest = this.brequest;
      BuildPlan buildPlan1 = request;
      float num1 = Mathf.lerpDelta(request.animScale, 1f, 0.1f);
      BuildPlan buildPlan2 = buildPlan1;
      double num2 = (double) num1;
      buildPlan2.animScale = num1;
      brequest.animScale = (float) num2;
      if (request.breaking)
      {
        this.drawSelected(request.x, request.y, request.tile().block(), Pal.remove);
      }
      else
      {
        request.block.drawPlan(request, this.allRequests(), this.validPlace(request.x, request.y, request.block, request.rotation));
        this.drawSelected(request.x, request.y, request.block, Pal.accent);
      }
    }

    [LineNumberTable(98)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool hasRequest([In] Tile obj0) => this.getRequest(obj0) != null;

    [LineNumberTable(418)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isPlacing() => base.isPlacing() && object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Eplacing);

    [LineNumberTable(new byte[] {161, 58, 108, 127, 32, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void useSchematic(Schematic schem)
    {
      this.selectRequests.clear();
      this.selectRequests.addAll(Vars.schematics.toRequests(schem, World.toTile(Core.camera.__\u003C\u003Eposition.x), World.toTile(Core.camera.__\u003C\u003Eposition.y)));
      this.lastSchematic = schem;
    }

    [LineNumberTable(new byte[] {31, 159, 4, 99, 112, 140, 143, 127, 69, 112, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void checkTargets([In] float obj0, [In] float obj1)
    {
      Unit unit = Units.closestEnemy(Vars.player.team(), obj0, obj1, 20f, (Boolf) new MobileInput.__\u003C\u003EAnon0());
      if (unit != null)
      {
        Vars.player.unit().mineTile = (Tile) null;
        this.target = (Teamc) unit;
      }
      else
      {
        Building building = Vars.world.buildWorld(obj0, obj1);
        if ((building == null || !Vars.player.team().isEnemy(building.team) || object.ReferenceEquals((object) building.team, (object) Team.__\u003C\u003Ederelict)) && (building == null || !Vars.player.unit().type.canHeal || (!object.ReferenceEquals((object) building.team, (object) Vars.player.team()) || !building.damaged())))
          return;
        Vars.player.unit().mineTile = (Tile) null;
        this.target = (Teamc) building;
      }
    }

    [LineNumberTable(new byte[] {109, 110, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void removeRequest([In] BuildPlan obj0)
    {
      this.selectRequests.remove((object) obj0, true);
      if (obj0.breaking)
        return;
      this.removals.add((object) obj0);
    }

    [LineNumberTable(new byte[] {53, 116, 159, 4, 127, 4, 135, 141, 121, 159, 20, 113, 130, 133, 127, 13, 151, 141, 121, 159, 20, 113, 130, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool checkOverlapPlacement([In] int obj0, [In] int obj1, [In] Block obj2)
    {
      InputHandler.r2.setSize((float) (obj2.size * 8));
      InputHandler.r2.setCenter((float) (obj0 * 8) + obj2.offset, (float) (obj1 * 8) + obj2.offset);
      Iterator iterator1 = this.selectRequests.iterator();
      while (iterator1.hasNext())
      {
        BuildPlan buildPlan = (BuildPlan) iterator1.next();
        Tile tile = buildPlan.tile();
        if (tile != null && !buildPlan.breaking)
        {
          InputHandler.r1.setSize((float) (buildPlan.block.size * 8));
          InputHandler.r1.setCenter(tile.worldx() + buildPlan.block.offset, tile.worldy() + buildPlan.block.offset);
          if (InputHandler.r2.overlaps(InputHandler.r1))
            return true;
        }
      }
      Iterator iterator2 = Vars.player.unit().plans().iterator();
      while (iterator2.hasNext())
      {
        BuildPlan buildPlan = (BuildPlan) iterator2.next();
        Tile tile = Vars.world.tile(buildPlan.x, buildPlan.y);
        if (tile != null && !buildPlan.breaking)
        {
          InputHandler.r1.setSize((float) (buildPlan.block.size * 8));
          InputHandler.r1.setCenter(tile.worldx() + buildPlan.block.offset, tile.worldy() + buildPlan.block.offset);
          if (InputHandler.r2.overlaps(InputHandler.r1))
            return true;
        }
      }
      return false;
    }

    [LineNumberTable(new byte[] {162, 221, 134, 103, 132, 108, 103, 127, 38, 127, 2, 246, 69, 127, 5, 167, 118, 135, 105, 120, 127, 12, 119, 159, 18, 100, 138, 173, 127, 22, 114, 135, 125, 150, 107, 159, 21, 110, 159, 21, 172, 169, 167, 127, 4, 159, 16, 116, 108, 191, 8, 135, 103, 112, 112, 119, 151, 159, 15, 99, 142, 127, 3, 109, 255, 22, 69, 191, 9, 104, 114, 127, 42, 107, 107, 127, 88, 159, 20, 107, 127, 12, 120, 231, 71, 158, 144, 113, 113, 146, 218, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void updateMovement(Unit unit)
    {
      Rect r3 = Tmp.__\u003C\u003Er3;
      UnitType type = unit.type;
      if (type == null)
        return;
      int num1 = unit.type.omniMovement ? 1 : 0;
      int num2 = type.canHeal ? 1 : 0;
      int num3 = num2 == 0 || !(this.target is Building) || (!((Building) this.target).isValid() || !object.ReferenceEquals((object) this.target.team(), (object) unit.team)) || (!((Building) this.target).damaged() || !this.target.within((Position) unit, type.range)) ? 0 : 1;
      int num4 = !(unit is Mechc) || !unit.isFlying() ? 0 : 1;
      if (Units.invalidateTarget(this.target, unit, type.range) && num3 == 0 || Vars.state.isEditor())
        this.target = (Teamc) null;
      this.targetPos.set(Core.camera.__\u003C\u003Eposition);
      float num5 = 15f;
      float limit = unit.realSpeed();
      float range = !unit.hasWeapons() ? 0.0f : unit.range();
      float v = !unit.hasWeapons() ? 0.0f : ((Weapon) type.weapons.first()).bullet.speed;
      float num6 = unit.angleTo(unit.aimX(), unit.aimY());
      if ((num1 == 0 || !Vars.player.shooting || (!type.hasWeapons() || !type.faceTarget) || (num4 != 0 || !type.rotateShooting) ? 0 : 1) != 0)
        unit.lookAt(num6);
      else
        unit.lookAt(unit.prefRotation());
      if (this.payloadTarget != null)
      {
        Unit unit1 = unit;
        Payloadc payloadc;
        if (unit1 is Payloadc && object.ReferenceEquals((object) (payloadc = (Payloadc) unit1), (object) (Payloadc) unit1))
        {
          this.targetPos.set(this.payloadTarget);
          num5 = 0.0f;
          if (unit.within(this.payloadTarget, 3f * Time.delta))
          {
            if (this.payloadTarget is Vec2 && payloadc.hasPayload())
            {
              this.tryDropPayload();
            }
            else
            {
              Position payloadTarget1 = this.payloadTarget;
              Building building;
              if (payloadTarget1 is Building && object.ReferenceEquals((object) (building = (Building) payloadTarget1), (object) (Building) payloadTarget1) && payloadc.canPickup(building))
              {
                Call.requestBuildPayload(Vars.player, building);
              }
              else
              {
                Position payloadTarget2 = this.payloadTarget;
                Unit unit2;
                if (payloadTarget2 is Unit && object.ReferenceEquals((object) (unit2 = (Unit) payloadTarget2), (object) (Unit) payloadTarget2) && payloadc.canPickup(unit2))
                  Call.requestUnitPayload(Vars.player, unit2);
              }
            }
            this.payloadTarget = (Position) null;
            goto label_17;
          }
          else
            goto label_17;
        }
      }
      this.payloadTarget = (Position) null;
label_17:
      this.movement.set(this.targetPos).sub((Position) Vars.player).limit(limit);
      this.movement.setAngle(Mathf.slerp(this.movement.angle(), unit.vel.angle(), 0.05f));
      if (Vars.player.within((Position) this.targetPos, num5))
      {
        this.movement.setZero();
        unit.vel.approachDelta(Vec2.__\u003C\u003EZERO, unit.speed() * type.accel / 2f);
      }
      float num7 = 3f;
      unit.hitbox(r3);
      r3.x -= num7;
      r3.y -= num7;
      r3.width += num7 * 2f;
      r3.height += num7 * 2f;
      Vars.player.boosting = Vars.collisions.overlapsTile(r3) || !unit.within((Position) this.targetPos, 85f);
      if (num1 != 0)
      {
        unit.moveAt(this.movement);
      }
      else
      {
        unit.moveAt(Tmp.__\u003C\u003Ev2.trns(unit.rotation, this.movement.len()));
        if (!this.movement.isZero())
          unit.vel.rotateTo(this.movement.angle(), unit.type.rotateSpeed * Math.max(Time.delta, 1f));
      }
      if (!Vars.player.unit().activelyBuilding() && Vars.player.unit().mineTile == null)
      {
        if (this.manualShooting)
        {
          Vars.player.shooting = num4 == 0;
          Unit unit1 = unit;
          Player player1 = Vars.player;
          float num8 = Core.input.mouseWorldX();
          Player player2 = player1;
          double num9 = (double) num8;
          player2.mouseX = num8;
          Player player3 = Vars.player;
          float num10 = Core.input.mouseWorldY();
          Player player4 = player3;
          double num11 = (double) num10;
          player4.mouseY = num10;
          unit1.aim((float) num9, (float) num11);
        }
        else if (this.target == null)
        {
          Vars.player.shooting = false;
          if (Core.settings.getBool("autotarget"))
          {
            Unit unit1 = Vars.player.unit();
            BlockUnitUnit blockUnitUnit;
            if (unit1 is BlockUnitUnit && object.ReferenceEquals((object) (blockUnitUnit = (BlockUnitUnit) unit1), (object) (BlockUnitUnit) unit1))
            {
              Building building = blockUnitUnit.tile();
              ControlBlock controlBlock;
              if (building is ControlBlock && object.ReferenceEquals((object) (controlBlock = (ControlBlock) building), (object) (ControlBlock) building) && !controlBlock.shouldAutoTarget())
                goto label_33;
            }
            this.target = Units.closestTarget(unit.team, unit.x, unit.y, range, (Boolf) new MobileInput.__\u003C\u003EAnon16(), (Boolf) new MobileInput.__\u003C\u003EAnon17());
            if (num2 != 0 && this.target == null)
            {
              this.target = (Teamc) Geometry.findClosest(unit.x, unit.y, (Iterable) Vars.indexer.getDamaged(Team.__\u003C\u003Esharded));
              if (this.target != null && !unit.within((Position) this.target, range))
                this.target = (Teamc) null;
            }
          }
label_33:
          unit.aim(Core.input.mouseWorldX(), Core.input.mouseWorldY());
        }
        else
        {
          Vec2 vec2 = Predict.intercept((Position) unit, (Position) this.target, v);
          Vars.player.mouseX = vec2.x;
          Vars.player.mouseY = vec2.y;
          Vars.player.shooting = num4 == 0;
          unit.aim(Vars.player.mouseX, Vars.player.mouseY);
        }
      }
      unit.controlWeapons(Vars.player.shooting && num4 == 0);
    }

    [LineNumberTable(new byte[] {162, 130, 152, 140, 105, 171, 118, 183, 105, 171, 118, 183, 127, 11, 177, 127, 3, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void autoPan()
    {
      float num1 = (float) Core.input.mouseX();
      float num2 = (float) Core.input.mouseY();
      float x = 0.0f;
      float y = 0.0f;
      if ((double) num1 <= (double) this.__\u003C\u003EedgePan)
        x = -(this.__\u003C\u003EedgePan - num1);
      if ((double) num1 >= (double) ((float) Core.graphics.getWidth() - this.__\u003C\u003EedgePan))
        x = num1 - (float) Core.graphics.getWidth() + this.__\u003C\u003EedgePan;
      if ((double) num2 <= (double) this.__\u003C\u003EedgePan)
        y = -(this.__\u003C\u003EedgePan - num2);
      if ((double) num2 >= (double) ((float) Core.graphics.getHeight() - this.__\u003C\u003EedgePan))
        y = num2 - (float) Core.graphics.getHeight() + this.__\u003C\u003EedgePan;
      this.vector.set(x, y).scl(Core.camera.width / (float) Core.graphics.getWidth());
      this.vector.limit(1.3f);
      Core.camera.__\u003C\u003Eposition.x += this.vector.x;
      Core.camera.__\u003C\u003Eposition.y += this.vector.y;
    }

    [Modifiers]
    [LineNumberTable(81)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024checkTargets\u00240([In] Unit obj0) => !obj0.dead;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 69, 127, 20, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildPlacementUI\u00241()
    {
      this.mode = !object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking) ? PlaceMode.__\u003C\u003Ebreaking : (this.block != null ? PlaceMode.__\u003C\u003Eplacing : PlaceMode.__\u003C\u003Enone);
      this.lastBlock = this.block;
    }

    [Modifiers]
    [LineNumberTable(185)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildPlacementUI\u00242([In] ImageButton obj0) => obj0.setChecked(object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking));

    [Modifiers]
    [LineNumberTable(new byte[] {160, 75, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024buildPlacementUI\u00243() => Core.settings.put("swapdiagonal", (object) Boolean.valueOf(!Core.settings.getBool("swapdiagonal")));

    [Modifiers]
    [LineNumberTable(190)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024buildPlacementUI\u00244([In] ImageButton obj0) => obj0.setChecked(Core.settings.getBool("swapdiagonal"));

    [Modifiers]
    [LineNumberTable(new byte[] {160, 80, 117, 150, 114, 104, 103, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildPlacementUI\u00245()
    {
      if (this.block != null && this.block.rotate)
      {
        this.rotation = Mathf.mod(this.rotation + 1, 4);
      }
      else
      {
        this.schematicMode = !this.schematicMode;
        if (!this.schematicMode)
          return;
        this.block = (Block) null;
        this.mode = PlaceMode.__\u003C\u003Enone;
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 90, 154, 127, 1, 122, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildPlacementUI\u00246([In] ImageButton obj0)
    {
      int num = this.block == null || !this.block.rotate ? 0 : 1;
      obj0.getImage().setRotationOrigin(num != 0 ? (float) (this.rotation * 90) : 0.0f, 1);
      obj0.getStyle().imageUp = num == 0 ? (Drawable) Icon.copy : (Drawable) Icon.right;
      obj0.setChecked(num == 0 && this.schematicMode);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 99, 127, 4, 167, 102, 107, 127, 4, 127, 0, 136, 99, 118, 127, 29, 118, 209, 142, 178, 165, 127, 2, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildPlacementUI\u00248()
    {
      Iterator iterator = this.selectRequests.iterator();
      while (iterator.hasNext())
      {
        BuildPlan buildPlan1 = (BuildPlan) iterator.next();
        Tile tile = buildPlan1.tile();
        if (tile != null)
        {
          if (!buildPlan1.breaking)
          {
            if (this.validPlace(buildPlan1.x, buildPlan1.y, buildPlan1.block, buildPlan1.rotation))
            {
              BuildPlan request = this.getRequest(buildPlan1.x, buildPlan1.y, buildPlan1.block.size, (BuildPlan) null);
              BuildPlan buildPlan2 = buildPlan1.copy();
              if (request == null)
                Vars.player.unit().addBuild(buildPlan2);
              else if (!request.breaking && request.x == buildPlan1.x && (request.y == buildPlan1.y && request.block.size == buildPlan1.block.size))
              {
                Vars.player.unit().plans().remove((object) request);
                Vars.player.unit().addBuild(buildPlan2);
              }
            }
            this.rotation = buildPlan1.rotation;
          }
          else
            this.tryBreakBlock((int) tile.x, (int) tile.y);
        }
      }
      this.removals.addAll(this.selectRequests.select((Boolf) new MobileInput.__\u003C\u003EAnon27()));
      this.selectRequests.clear();
      this.selecting = false;
    }

    [Modifiers]
    [LineNumberTable(242)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024buildPlacementUI\u00249() => !this.selectRequests.isEmpty();

    [Modifiers]
    [LineNumberTable(247)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024buildUI\u002410() => this.lastSchematic != null && !this.selectRequests.isEmpty();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 136, 115, 108, 255, 1, 69, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildUI\u002413([In] Boolp obj0, [In] Table obj1)
    {
      obj1.visible((Boolp) new MobileInput.__\u003C\u003EAnon25(this, obj0));
      obj1.bottom().left();
      obj1.button("@cancel", (Drawable) Icon.cancel, (Runnable) new MobileInput.__\u003C\u003EAnon26(this)).width(155f).height(50f).margin(12f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 147, 104, 108, 251, 79, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildUI\u002420([In] Boolp obj0, [In] Table obj1)
    {
      obj1.visible(obj0);
      obj1.bottom().left();
      obj1.table((Drawable) Tex.pane, (Cons) new MobileInput.__\u003C\u003EAnon18(this)).margin(4f);
    }

    [Modifiers]
    [LineNumberTable(405)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024schemOriginX\u002421([In] BuildPlan obj0) => Tmp.__\u003C\u003Ev1.add(obj0.drawx(), obj0.drawy());

    [Modifiers]
    [LineNumberTable(412)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024schemOriginY\u002422([In] BuildPlan obj0) => Tmp.__\u003C\u003Ev1.add(obj0.drawx(), obj0.drawy());

    [Modifiers]
    [LineNumberTable(527)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024longPress\u002423([In] Payloadc obj0, [In] Vec2 obj1, [In] Unit obj2) => obj2.isAI() && obj2.isGrounded() && (obj0.canPickup(obj2) && obj2.within((Position) obj1, obj2.hitSize + 8f));

    [Modifiers]
    [LineNumberTable(939)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024updateMovement\u002424([In] Unit obj0) => !object.ReferenceEquals((object) obj0.team, (object) Team.__\u003C\u003Ederelict);

    [Modifiers]
    [LineNumberTable(939)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024updateMovement\u002425([In] Building obj0) => !object.ReferenceEquals((object) obj0.team, (object) Team.__\u003C\u003Ederelict);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 150, 145, 134, 127, 9, 184, 103, 120, 120, 103, 152})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildUI\u002419([In] Table obj0)
    {
      obj0.defaults().size(50f);
      ImageButton.ImageButtonStyle clearPartiali = Styles.clearPartiali;
      obj0.button((Drawable) Icon.save, clearPartiali, (Runnable) new MobileInput.__\u003C\u003EAnon19(this)).disabled((Boolf) new MobileInput.__\u003C\u003EAnon20(this));
      obj0.button((Drawable) Icon.cancel, clearPartiali, (Runnable) new MobileInput.__\u003C\u003EAnon21(this));
      obj0.row();
      obj0.button((Drawable) Icon.flipX, clearPartiali, (Runnable) new MobileInput.__\u003C\u003EAnon22(this));
      obj0.button((Drawable) Icon.flipY, clearPartiali, (Runnable) new MobileInput.__\u003C\u003EAnon23(this));
      obj0.row();
      obj0.button((Drawable) Icon.rotate, clearPartiali, (Runnable) new MobileInput.__\u003C\u003EAnon24(this));
    }

    [Modifiers]
    [LineNumberTable(268)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024buildUI\u002414([In] ImageButton obj0) => this.lastSchematic == null || this.lastSchematic.file != null;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 156, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildUI\u002415() => this.selectRequests.clear();

    [Modifiers]
    [LineNumberTable(273)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildUI\u002416() => this.flipRequests(this.selectRequests, true);

    [Modifiers]
    [LineNumberTable(274)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildUI\u002417() => this.flipRequests(this.selectRequests, false);

    [Modifiers]
    [LineNumberTable(276)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildUI\u002418() => this.rotateRequests(this.selectRequests, 1);

    [Modifiers]
    [LineNumberTable(250)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024buildUI\u002411([In] Boolp obj0) => (Vars.player.unit().isBuilding() || this.block != null || (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking) || !this.selectRequests.isEmpty())) && !obj0.get();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 139, 111, 108, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildUI\u002412()
    {
      Vars.player.unit().clearBuilding();
      this.selectRequests.clear();
      this.mode = PlaceMode.__\u003C\u003Enone;
      this.block = (Block) null;
    }

    [Modifiers]
    [LineNumberTable(239)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024buildPlacementUI\u00247([In] BuildPlan obj0) => !obj0.breaking;

    [LineNumberTable(166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isLinePlacing() => object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Eplacing) && this.lineMode && (double) Mathf.dst((float) (this.lineStartX * 8), (float) (this.lineStartY * 8), Core.input.mouseWorld().x, Core.input.mouseWorld().y) >= 24.0;

    [LineNumberTable(170)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isAreaBreaking() => object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking) && this.lineMode && (double) Mathf.dst((float) (this.lineStartX * 8), (float) (this.lineStartY * 8), Core.input.mouseWorld().x, Core.input.mouseWorld().y) >= 16.0;

    [LineNumberTable(new byte[] {160, 64, 127, 7, 103, 159, 1, 191, 7, 176, 159, 5, 166, 255, 7, 74, 230, 73, 255, 7, 94, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void buildPlacementUI(Table table)
    {
      table.image().color(Pal.gray).height(4f).colspan(4).growX();
      table.row();
      table.left().margin(0.0f).defaults().size(48f);
      table.button((Drawable) Icon.hammer, Styles.clearTogglePartiali, (Runnable) new MobileInput.__\u003C\u003EAnon1(this)).update((Cons) new MobileInput.__\u003C\u003EAnon2(this)).name("breakmode");
      table.button((Drawable) Icon.diagonal, Styles.clearTogglePartiali, (Runnable) new MobileInput.__\u003C\u003EAnon3()).update((Cons) new MobileInput.__\u003C\u003EAnon4());
      table.button((Drawable) Icon.right, Styles.clearTogglePartiali, (Runnable) new MobileInput.__\u003C\u003EAnon5(this)).update((Cons) new MobileInput.__\u003C\u003EAnon6(this));
      table.button((Drawable) Icon.ok, Styles.clearPartiali, (Runnable) new MobileInput.__\u003C\u003EAnon7(this)).visible((Boolp) new MobileInput.__\u003C\u003EAnon8(this)).name("confirmplace");
    }

    [LineNumberTable(new byte[] {160, 133, 140, 242, 75, 242, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void buildUI(Group group)
    {
      Boolp boolp = (Boolp) new MobileInput.__\u003C\u003EAnon9(this);
      group.fill((Cons) new MobileInput.__\u003C\u003EAnon10(this, boolp));
      group.fill((Cons) new MobileInput.__\u003C\u003EAnon11(this, boolp));
    }

    [LineNumberTable(new byte[] {160, 170, 170, 127, 4, 135, 133, 156, 104, 159, 0, 147, 133, 101, 170, 107, 114, 147, 159, 1, 117, 116, 127, 0, 159, 2, 127, 64, 255, 1, 58, 235, 72, 120, 114, 213, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawBottom()
    {
      Lines.stroke(1f);
      Iterator iterator = this.removals.iterator();
      while (iterator.hasNext())
      {
        BuildPlan req = (BuildPlan) iterator.next();
        Tile tile = req.tile();
        if (tile != null)
        {
          req.animScale = Mathf.lerpDelta(req.animScale, 0.0f, 0.2f);
          if (req.breaking)
            this.drawSelected(req.x, req.y, tile.block(), Pal.remove);
          else
            req.block.drawPlan(req, this.allRequests(), true);
        }
      }
      Draw.mixcol();
      Draw.color(Pal.accent);
      if (this.lineMode)
      {
        int x2 = this.tileX((float) Core.input.mouseX());
        int y2 = this.tileY((float) Core.input.mouseY());
        if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Eplacing) && this.block != null)
        {
          for (int index = 0; index < this.lineRequests.size; ++index)
          {
            BuildPlan req = (BuildPlan) this.lineRequests.get(index);
            if (index == this.lineRequests.size - 1 && req.block.rotate)
              this.drawArrow(this.block, req.x, req.y, req.rotation);
            req.block.drawPlan(req, this.allRequests(), this.validPlace(req.x, req.y, req.block, req.rotation) && this.getRequest(req.x, req.y, req.block.size, (BuildPlan) null) == null);
            this.drawSelected(req.x, req.y, req.block, Pal.accent);
          }
          this.lineRequests.each((Cons) new MobileInput.__\u003C\u003EAnon12(this));
        }
        else if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking))
          this.drawBreakSelection(this.lineStartX, this.lineStartY, x2, y2);
      }
      Draw.reset();
    }

    [LineNumberTable(new byte[] {160, 217, 114, 159, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawTop()
    {
      if (!object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003EschematicSelect))
        return;
      this.drawSelection(this.lineStartX, this.lineStartY, this.lastLineX, this.lastLineY, 32);
    }

    [LineNumberTable(new byte[] {160, 225, 127, 4, 135, 133, 127, 30, 103, 158, 188, 144, 126, 101, 191, 12, 101, 103, 104, 199, 126, 101, 159, 28, 165, 127, 6, 115, 107, 172, 156, 191, 27, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawOverSelect()
    {
      Iterator iterator = this.selectRequests.iterator();
      while (iterator.hasNext())
      {
        BuildPlan request = (BuildPlan) iterator.next();
        Tile tile = request.tile();
        if (tile != null)
        {
          request.animScale = !request.breaking && this.validPlace((int) tile.x, (int) tile.y, request.block, request.rotation) || request.breaking && this.validBreak((int) tile.x, (int) tile.y) ? Mathf.lerpDelta(request.animScale, 1f, 0.2f) : Mathf.lerpDelta(request.animScale, 0.6f, 0.1f);
          Tmp.__\u003C\u003Ec1.set(Draw.getMixColor());
          if (!request.breaking && object.ReferenceEquals((object) request, (object) this.lastPlaced) && request.block != null)
          {
            Draw.mixcol();
            if (request.block.rotate)
              this.drawArrow(request.block, (int) tile.x, (int) tile.y, request.rotation);
          }
          Draw.reset();
          this.drawRequest(request);
          if (!request.breaking)
            this.drawOverRequest(request);
          if (!request.breaking && object.ReferenceEquals((object) request, (object) this.lastPlaced) && request.block != null)
          {
            Draw.mixcol();
            request.block.drawPlace((int) tile.x, (int) tile.y, this.rotation, this.validPlace((int) tile.x, (int) tile.y, request.block, this.rotation));
          }
        }
      }
      if (this.target != null && !Vars.state.isEditor() && !this.manualShooting)
      {
        if (!object.ReferenceEquals((object) this.target, (object) this.lastTarget))
        {
          this.crosshairScale = 0.0f;
          this.lastTarget = this.target;
        }
        this.crosshairScale = Mathf.lerpDelta(this.crosshairScale, 1f, 0.2f);
        Drawf.target(((Posc) this.target).getX(), ((Posc) this.target).getY(), 7f * Interp.swingIn.apply(this.crosshairScale), Pal.remove);
      }
      Draw.reset();
    }

    [LineNumberTable(new byte[] {161, 34, 107, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int schemOriginX()
    {
      Tmp.__\u003C\u003Ev1.setZero();
      this.selectRequests.each((Cons) new MobileInput.__\u003C\u003EAnon13());
      return World.toTile(Tmp.__\u003C\u003Ev1.scl(1f / (float) this.selectRequests.size).x);
    }

    [LineNumberTable(new byte[] {161, 41, 107, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int schemOriginY()
    {
      Tmp.__\u003C\u003Ev1.setZero();
      this.selectRequests.each((Cons) new MobileInput.__\u003C\u003EAnon14());
      return World.toTile(Tmp.__\u003C\u003Ev1.scl(1f / (float) this.selectRequests.size).y);
    }

    [LineNumberTable(423)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isBreaking() => object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking);

    [LineNumberTable(new byte[] {161, 65, 142, 135, 174, 139, 191, 9, 181, 173, 113, 112, 139, 105, 106, 103, 104, 103, 104, 157, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool touchDown(int screenX, int screenY, int pointer, KeyCode button)
    {
      if (Vars.state.isMenu())
        return false;
      this.down = true;
      if (Vars.player.dead())
        return false;
      Tile tile = this.tileAt((float) screenX, (float) screenY);
      float x = Core.input.mouseWorld((float) screenX, (float) screenY).x;
      float y = Core.input.mouseWorld((float) screenX, (float) screenY).y;
      if (tile == null || Core.scene.hasMouse((float) screenX, (float) screenY))
        return false;
      this.selecting = this.hasRequest(tile);
      if (pointer == 0 && !this.selecting)
      {
        if (this.schematicMode && this.block == null)
        {
          this.mode = PlaceMode.__\u003C\u003EschematicSelect;
          int num1 = this.tileX((float) screenX);
          int num2 = this.tileY((float) screenY);
          this.lineStartX = num1;
          this.lineStartY = num2;
          this.lastLineX = num1;
          this.lastLineY = num2;
        }
        else if (!this.tryTapPlayer(x, y) && Core.settings.getBool("keyboard"))
          Vars.player.shooting = true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {161, 104, 145, 108, 167, 103, 167, 107, 105, 137, 122, 108, 108, 114, 181, 103, 119, 108, 127, 9, 108, 109, 135, 103, 141, 139, 159, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool touchUp(int screenX, int screenY, int pointer, KeyCode button)
    {
      this.lastZoom = Vars.renderer.getScale();
      if (!Core.input.isTouched())
        this.down = false;
      this.manualShooting = false;
      this.selecting = false;
      if (this.lineMode)
      {
        int x2 = this.tileX((float) screenX);
        int y2 = this.tileY((float) screenY);
        if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Eplacing) && this.isPlacing())
        {
          this.flushSelectRequests(this.lineRequests);
          Events.fire((object) new EventType.LineConfirmEvent());
        }
        else if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking))
          this.removeSelection(this.lineStartX, this.lineStartY, x2, y2, true);
        this.lineMode = false;
      }
      else if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003EschematicSelect))
      {
        this.selectRequests.clear();
        this.lastSchematic = Vars.schematics.create(this.lineStartX, this.lineStartY, this.lastLineX, this.lastLineY);
        this.useSchematic(this.lastSchematic);
        if (this.selectRequests.isEmpty())
          this.lastSchematic = (Schematic) null;
        this.schematicMode = false;
        this.mode = PlaceMode.__\u003C\u003Enone;
      }
      else
        this.tryDropItems(this.tileAt((float) screenX, (float) screenY)?.build, Core.input.mouseWorld((float) screenX, (float) screenY).x, Core.input.mouseWorld((float) screenX, (float) screenY).y);
      return false;
    }

    [LineNumberTable(new byte[] {161, 145, 186, 139, 186, 117, 143, 127, 15, 127, 14, 99, 140, 152, 127, 7, 106, 136, 142, 103, 167, 98, 103, 167, 119, 165, 197, 108, 108, 108, 108, 135, 114, 127, 18, 104, 126, 223, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool longPress(float x, float y)
    {
      if (Vars.state.isMenu() || Vars.player.dead())
        return false;
      Tile tile = this.tileAt(x, y);
      if (Core.scene.hasMouse(x, y) || this.schematicMode)
        return false;
      if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Enone))
      {
        Vec2 v = Core.input.mouseWorld(x, y);
        Unit unit1 = Vars.player.unit();
        Payloadc payloadc;
        if (unit1 is Payloadc && object.ReferenceEquals((object) (payloadc = (Payloadc) unit1), (object) (Payloadc) unit1))
        {
          Unit unit2 = Units.closest(Vars.player.team(), v.x, v.y, 8f, (Boolf) new MobileInput.__\u003C\u003EAnon15(payloadc, v));
          if (unit2 != null)
          {
            this.payloadTarget = (Position) unit2;
          }
          else
          {
            Building b = Vars.world.buildWorld(v.x, v.y);
            if (b != null && object.ReferenceEquals((object) b.team, (object) Vars.player.team()) && payloadc.canPickup(b))
              this.payloadTarget = (Position) b;
            else if (payloadc.hasPayload())
            {
              this.payloadTarget = (Position) new Vec2(v);
            }
            else
            {
              this.manualShooting = true;
              this.target = (Teamc) null;
            }
          }
        }
        else
        {
          this.manualShooting = true;
          this.target = (Teamc) null;
        }
        if (!Vars.state.isPaused())
          Fx.__\u003C\u003Eselect.at((Position) v);
      }
      else
      {
        if (tile == null)
          return false;
        this.lineStartX = (int) tile.x;
        this.lineStartY = (int) tile.y;
        this.lastLineX = (int) tile.x;
        this.lastLineY = (int) tile.y;
        this.lineMode = true;
        if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking))
        {
          if (!Vars.state.isPaused())
            Fx.__\u003C\u003EtapBlock.at(tile.worldx(), tile.worldy(), 1f);
        }
        else if (this.block != null)
        {
          this.updateLine(this.lineStartX, this.lineStartY, (int) tile.x, (int) tile.y);
          if (!Vars.state.isPaused())
            Fx.__\u003C\u003EtapBlock.at(tile.worldx() + this.block.offset, tile.worldy() + this.block.offset, (float) this.block.size);
        }
      }
      return false;
    }

    [LineNumberTable(new byte[] {161, 205, 150, 191, 9, 171, 149, 139, 151, 108, 200, 105, 114, 159, 62, 127, 34, 118, 159, 16, 191, 2, 135, 135, 127, 72, 172, 104, 114, 105, 173, 162, 140, 127, 36, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool tap(float x, float y, int count, KeyCode button)
    {
      if (Vars.state.isMenu() || this.lineMode)
        return false;
      float x1 = Core.input.mouseWorld(x, y).x;
      float y1 = Core.input.mouseWorld(x, y).y;
      Tile tile1 = this.tileAt(x, y);
      if (tile1 == null || Core.scene.hasMouse(x, y))
        return false;
      Call.tileTap(Vars.player, tile1);
      Tile tile2 = tile1.build != null ? tile1.build.tile : tile1;
      if (!Vars.player.dead())
        this.checkTargets(x1, y1);
      if (this.hasRequest(tile1))
        this.removeRequest(this.getRequest(tile1));
      else if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Eplacing) && this.isPlacing() && (this.validPlace((int) tile1.x, (int) tile1.y, this.block, this.rotation) && !this.checkOverlapPlacement((int) tile1.x, (int) tile1.y, this.block)))
      {
        Seq selectRequests = this.selectRequests;
        MobileInput mobileInput = this;
        BuildPlan buildPlan1 = new BuildPlan((int) tile1.x, (int) tile1.y, this.rotation, this.block, this.block.nextConfig());
        BuildPlan buildPlan2 = buildPlan1;
        this.lastPlaced = buildPlan1;
        selectRequests.add((object) buildPlan2);
        this.block.onNewPlan(this.lastPlaced);
      }
      else if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking) && this.validBreak((int) tile2.x, (int) tile2.y) && !this.hasRequest(tile2))
      {
        this.selectRequests.add((object) new BuildPlan((int) tile2.x, (int) tile2.y));
      }
      else
      {
        if (count == 2)
        {
          this.payloadTarget = (Position) null;
          if (!Vars.player.dead() && Mathf.within(x1, y1, Vars.player.unit().x, Vars.player.unit().y, Vars.player.unit().hitSize * 0.6f + 8f) && Vars.player.unit().type.commandLimit > 0)
            Call.unitCommand(Vars.player);
          else if (this.unitTapped != null)
            Call.unitControl(Vars.player, this.unitTapped);
          else if (!this.tryBeginMine(tile1))
            this.tileTapped(tile2.build);
          return false;
        }
        this.unitTapped = this.selectedUnit();
        if (!this.tryStopMine() && !this.canTapPlayer(x1, y1) && (!this.tileTapped(tile2.build) && object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Enone)) && !Core.settings.getBool("doubletapmine"))
          this.tryBeginMine(tile1);
      }
      return false;
    }

    [LineNumberTable(new byte[] {162, 8, 134, 108, 108, 108, 107, 103, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void updateState()
    {
      base.updateState();
      if (!Vars.state.isMenu())
        return;
      this.selectRequests.clear();
      this.removals.clear();
      this.mode = PlaceMode.__\u003C\u003Enone;
      this.manualShooting = false;
      this.payloadTarget = (Position) null;
    }

    [LineNumberTable(new byte[] {162, 21, 134, 108, 107, 103, 199, 127, 78, 186, 145, 102, 191, 50, 113, 113, 171, 116, 203, 120, 208, 114, 167, 127, 3, 199, 122, 171, 122, 203, 104, 199, 122, 171, 114, 108, 108, 198, 127, 14, 107, 172, 107, 188, 109, 166, 159, 5, 122, 103, 103, 148, 98, 108, 203, 114, 146, 109, 109, 228, 59, 230, 73, 127, 15, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update()
    {
      base.update();
      if (Vars.player.dead())
      {
        this.mode = PlaceMode.__\u003C\u003Enone;
        this.manualShooting = false;
        this.payloadTarget = (Position) null;
      }
      if ((double) Math.abs(Core.input.axisTap((KeyBinds.KeyBind) Binding.__\u003C\u003Ezoom)) > 0.0 && !Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Erotateplaced) && (Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Ediagonal_placement) || (!Vars.player.isBuilder() || !this.isPlacing() || !this.block.rotate) && this.selectRequests.isEmpty()))
        Vars.renderer.scaleCamera(Core.input.axisTap((KeyBinds.KeyBind) Binding.__\u003C\u003Ezoom));
      if (!Core.settings.getBool("keyboard"))
      {
        float num = 6f;
        Core.camera.__\u003C\u003Eposition.add(Tmp.__\u003C\u003Ev1.setZero().add(Core.input.axis((KeyBinds.KeyBind) Binding.__\u003C\u003Emove_x), Core.input.axis((KeyBinds.KeyBind) Binding.__\u003C\u003Emove_y)).nor().scl(Time.delta * num));
      }
      if (Core.settings.getBool("keyboard"))
      {
        if (Core.input.keyRelease((KeyBinds.KeyBind) Binding.__\u003C\u003Eselect))
          Vars.player.shooting = false;
        if (Vars.player.shooting && !this.canShoot())
          Vars.player.shooting = false;
      }
      if (!Vars.player.dead() && !Vars.state.isPaused())
        this.updateMovement(Vars.player.unit());
      if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Enone))
        this.lineMode = false;
      if (this.lineMode && object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Eplacing) && this.block == null)
        this.lineMode = false;
      if (this.block != null && object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Enone))
        this.mode = PlaceMode.__\u003C\u003Eplacing;
      if (this.block == null && object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Eplacing))
        this.mode = PlaceMode.__\u003C\u003Enone;
      if (this.block != null)
        this.schematicMode = false;
      if (!this.schematicMode && object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003EschematicSelect))
        this.mode = PlaceMode.__\u003C\u003Enone;
      if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003EschematicSelect))
      {
        this.lastLineX = this.rawTileX();
        this.lastLineY = this.rawTileY();
        this.autoPan();
      }
      if (!object.ReferenceEquals((object) this.lastBlock, (object) this.block) && object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking) && this.block != null)
      {
        this.mode = PlaceMode.__\u003C\u003Eplacing;
        this.lastBlock = this.block;
      }
      if (this.lineMode)
      {
        this.lineScale = Mathf.lerpDelta(this.lineScale, 1f, 0.1f);
        if (Core.input.isTouched(0))
          this.autoPan();
        int x2 = this.tileX((float) Core.input.mouseX());
        int y2 = this.tileY((float) Core.input.mouseY());
        if ((this.lastLineX != x2 || this.lastLineY != y2) && this.isPlacing())
        {
          this.lastLineX = x2;
          this.lastLineY = y2;
          this.updateLine(this.lineStartX, this.lineStartY, x2, y2);
        }
      }
      else
      {
        this.lineRequests.clear();
        this.lineScale = 0.0f;
      }
      for (int index = this.removals.size - 1; index >= 0; index += -1)
      {
        if ((double) ((BuildPlan) this.removals.get(index)).animScale <= 9.99999974737875E-05)
        {
          this.removals.remove(index);
          index += -1;
        }
      }
      if (!Vars.player.shooting || !Vars.player.unit().activelyBuilding() && !Vars.player.unit().mining())
        return;
      Vars.player.shooting = false;
    }

    [LineNumberTable(new byte[] {162, 160, 159, 7, 120, 103, 168, 127, 6, 194, 146, 107, 112, 145, 115, 147, 117, 127, 2, 107, 111, 111, 130, 115, 147, 142, 121, 186})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool pan(float x, float y, float deltaX, float deltaY)
    {
      if (Core.scene == null || Core.scene.hasDialog() || Core.settings.getBool("keyboard"))
        return false;
      float num1 = Core.camera.width / (float) Core.graphics.getWidth();
      deltaX *= num1;
      deltaY *= num1;
      if (this.lineMode && !Core.input.isTouched(1) || (this.droppingItem || this.schematicMode) || (!this.down || this.manualShooting))
        return false;
      if (this.selecting)
      {
        this.shiftDeltaX += deltaX;
        this.shiftDeltaY += deltaY;
        int num2 = ByteCodeHelper.f2i(this.shiftDeltaX / 8f);
        int num3 = ByteCodeHelper.f2i(this.shiftDeltaY / 8f);
        if (Math.abs(num2) > 0 || Math.abs(num3) > 0)
        {
          Iterator iterator = this.selectRequests.iterator();
          while (iterator.hasNext())
          {
            BuildPlan buildPlan = (BuildPlan) iterator.next();
            if (!buildPlan.breaking)
            {
              buildPlan.x += num2;
              buildPlan.y += num3;
            }
          }
          this.shiftDeltaX %= 8f;
          this.shiftDeltaY %= 8f;
        }
      }
      else if (!Vars.renderer.isLanding())
      {
        Core.camera.__\u003C\u003Eposition.x -= deltaX;
        Core.camera.__\u003C\u003Eposition.y -= deltaY;
      }
      return false;
    }

    [LineNumberTable(new byte[] {162, 202, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool panStop(float x, float y, int pointer, KeyCode button)
    {
      MobileInput mobileInput = this;
      float num1 = 0.0f;
      double num2 = (double) num1;
      this.shiftDeltaY = num1;
      this.shiftDeltaX = (float) num2;
      return false;
    }

    [LineNumberTable(new byte[] {162, 208, 115, 109, 177, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool zoom(float initialDistance, float distance)
    {
      if (Core.settings.getBool("keyboard"))
        return false;
      if ((double) this.lastZoom < 0.0)
        this.lastZoom = Vars.renderer.getScale();
      Vars.renderer.setScale(distance / initialDistance * this.lastZoom);
      return true;
    }

    [HideFromJava]
    public override bool touchDown([In] float obj0, [In] float obj1, [In] int obj2, [In] KeyCode obj3) => GestureDetector.GestureListener.\u003Cdefault\u003EtouchDown((GestureDetector.GestureListener) this, obj0, obj1, obj2, obj3);

    [HideFromJava]
    public override bool fling([In] float obj0, [In] float obj1, [In] KeyCode obj2) => GestureDetector.GestureListener.\u003Cdefault\u003Efling((GestureDetector.GestureListener) this, obj0, obj1, obj2);

    [HideFromJava]
    public override bool pinch([In] Vec2 obj0, [In] Vec2 obj1, [In] Vec2 obj2, [In] Vec2 obj3) => GestureDetector.GestureListener.\u003Cdefault\u003Epinch((GestureDetector.GestureListener) this, obj0, obj1, obj2, obj3);

    [HideFromJava]
    public override void pinchStop() => GestureDetector.GestureListener.\u003Cdefault\u003EpinchStop((GestureDetector.GestureListener) this);

    [HideFromJava]
    static MobileInput() => InputHandler.__\u003Cclinit\u003E();

    [Modifiers]
    public float edgePan
    {
      [HideFromJava] get => this.__\u003C\u003EedgePan;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EedgePan = value;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (MobileInput.lambda\u0024checkTargets\u00240((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly MobileInput arg\u00241;

      internal __\u003C\u003EAnon1([In] MobileInput obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildPlacementUI\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly MobileInput arg\u00241;

      internal __\u003C\u003EAnon2([In] MobileInput obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildPlacementUI\u00242((ImageButton) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void run() => MobileInput.lambda\u0024buildPlacementUI\u00243();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Cons
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public void get([In] object obj0) => MobileInput.lambda\u0024buildPlacementUI\u00244((ImageButton) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly MobileInput arg\u00241;

      internal __\u003C\u003EAnon5([In] MobileInput obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildPlacementUI\u00245();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly MobileInput arg\u00241;

      internal __\u003C\u003EAnon6([In] MobileInput obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildPlacementUI\u00246((ImageButton) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly MobileInput arg\u00241;

      internal __\u003C\u003EAnon7([In] MobileInput obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildPlacementUI\u00248();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon8 : Boolp
    {
      private readonly MobileInput arg\u00241;

      internal __\u003C\u003EAnon8([In] MobileInput obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024buildPlacementUI\u00249() ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon9 : Boolp
    {
      private readonly MobileInput arg\u00241;

      internal __\u003C\u003EAnon9([In] MobileInput obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024buildUI\u002410() ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon10 : Cons
    {
      private readonly MobileInput arg\u00241;
      private readonly Boolp arg\u00242;

      internal __\u003C\u003EAnon10([In] MobileInput obj0, [In] Boolp obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildUI\u002413(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon11 : Cons
    {
      private readonly MobileInput arg\u00241;
      private readonly Boolp arg\u00242;

      internal __\u003C\u003EAnon11([In] MobileInput obj0, [In] Boolp obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildUI\u002420(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon12 : Cons
    {
      private readonly MobileInput arg\u00241;

      internal __\u003C\u003EAnon12([In] MobileInput obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.drawOverRequest((BuildPlan) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon13 : Cons
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public void get([In] object obj0) => MobileInput.lambda\u0024schemOriginX\u002421((BuildPlan) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon14 : Cons
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public void get([In] object obj0) => MobileInput.lambda\u0024schemOriginY\u002422((BuildPlan) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon15 : Boolf
    {
      private readonly Payloadc arg\u00241;
      private readonly Vec2 arg\u00242;

      internal __\u003C\u003EAnon15([In] Payloadc obj0, [In] Vec2 obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (MobileInput.lambda\u0024longPress\u002423(this.arg\u00241, this.arg\u00242, (Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon16 : Boolf
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public bool get([In] object obj0) => (MobileInput.lambda\u0024updateMovement\u002424((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon17 : Boolf
    {
      internal __\u003C\u003EAnon17()
      {
      }

      public bool get([In] object obj0) => (MobileInput.lambda\u0024updateMovement\u002425((Building) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon18 : Cons
    {
      private readonly MobileInput arg\u00241;

      internal __\u003C\u003EAnon18([In] MobileInput obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildUI\u002419((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon19 : Runnable
    {
      private readonly MobileInput arg\u00241;

      internal __\u003C\u003EAnon19([In] MobileInput obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.showSchematicSave();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon20 : Boolf
    {
      private readonly MobileInput arg\u00241;

      internal __\u003C\u003EAnon20([In] MobileInput obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024buildUI\u002414((ImageButton) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon21 : Runnable
    {
      private readonly MobileInput arg\u00241;

      internal __\u003C\u003EAnon21([In] MobileInput obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildUI\u002415();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon22 : Runnable
    {
      private readonly MobileInput arg\u00241;

      internal __\u003C\u003EAnon22([In] MobileInput obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildUI\u002416();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon23 : Runnable
    {
      private readonly MobileInput arg\u00241;

      internal __\u003C\u003EAnon23([In] MobileInput obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildUI\u002417();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon24 : Runnable
    {
      private readonly MobileInput arg\u00241;

      internal __\u003C\u003EAnon24([In] MobileInput obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildUI\u002418();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon25 : Boolp
    {
      private readonly MobileInput arg\u00241;
      private readonly Boolp arg\u00242;

      internal __\u003C\u003EAnon25([In] MobileInput obj0, [In] Boolp obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get() => (this.arg\u00241.lambda\u0024buildUI\u002411(this.arg\u00242) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon26 : Runnable
    {
      private readonly MobileInput arg\u00241;

      internal __\u003C\u003EAnon26([In] MobileInput obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildUI\u002412();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon27 : Boolf
    {
      internal __\u003C\u003EAnon27()
      {
      }

      public bool get([In] object obj0) => (MobileInput.lambda\u0024buildPlacementUI\u00247((BuildPlan) obj0) ? 1 : 0) != 0;
    }
  }
}
