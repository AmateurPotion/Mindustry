// Decompiled with JetBrains decompiler
// Type: mindustry.input.InputHandler
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.input;
using arc.math;
using arc.math.geom;
using arc.scene;
using arc.scene.@event;
using arc.scene.ui.layout;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.ai.formations;
using mindustry.ai.formations.patterns;
using mindustry.content;
using mindustry.core;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.net;
using mindustry.type;
using mindustry.ui.fragments;
using mindustry.world;
using mindustry.world.blocks;
using mindustry.world.blocks.distribution;
using mindustry.world.blocks.payloads;
using mindustry.world.blocks.storage;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.input
{
  [Implements(new string[] {"arc.input.InputProcessor", "arc.input.GestureDetector$GestureListener"})]
  public abstract class InputHandler : Object, InputProcessor, GestureDetector.GestureListener
  {
    [Modifiers]
    internal static float playerSelectRange;
    internal const int maxLength = 100;
    [Modifiers]
    internal static Rect r1;
    [Modifiers]
    internal static Rect r2;
    internal OverlayFragment __\u003C\u003Efrag;
    public Interval controlInterval;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Block block;
    public bool overrideLineRotation;
    public int rotation;
    public bool droppingItem;
    public Group uiGroup;
    public bool isBuilding;
    public bool buildWasAutoPaused;
    public bool wasShooting;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public UnitType controlledType;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Schematic lastSchematic;
    public GestureDetector detector;
    internal InputHandler.PlaceLine __\u003C\u003Eline;
    public BuildPlan resultreq;
    public BuildPlan brequest;
    [Signature("Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;")]
    public Seq lineRequests;
    [Signature("Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;")]
    public Seq selectRequests;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {163, 163, 107, 107, 103, 117, 99, 166, 104, 144, 104, 108, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      Core.input.removeProcessor((InputProcessor) this);
      this.__\u003C\u003Efrag.remove();
      if (Core.scene != null)
        ((Group) Core.scene.find("inputTable"))?.clear();
      if (this.detector != null)
        Core.input.removeProcessor((InputProcessor) this.detector);
      if (this.uiGroup == null)
        return;
      this.uiGroup.remove();
      this.uiGroup = (Group) null;
    }

    [LineNumberTable(new byte[] {163, 181, 122, 127, 16, 107, 106, 117, 99, 102, 167, 107, 112, 108, 117, 107, 140, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add()
    {
      Core.input.getInputProcessors().remove((Boolf) new InputHandler.__\u003C\u003EAnon29());
      Input input = Core.input;
      InputHandler inputHandler = this;
      GestureDetector gestureDetector1 = new GestureDetector(20f, 0.5f, 0.3f, 0.15f, (GestureDetector.GestureListener) this);
      GestureDetector gestureDetector2 = gestureDetector1;
      this.detector = gestureDetector1;
      input.addProcessor((InputProcessor) gestureDetector2);
      Core.input.addProcessor((InputProcessor) this);
      if (Core.scene == null)
        return;
      Table table = (Table) Core.scene.find("inputTable");
      if (table != null)
      {
        table.clear();
        this.buildPlacementUI(table);
      }
      this.uiGroup = (Group) new WidgetGroup();
      this.uiGroup.touchable = Touchable.__\u003C\u003EchildrenOnly;
      this.uiGroup.setFillParent(true);
      Vars.ui.hudGroup.addChild((Element) this.uiGroup);
      this.uiGroup.toBack();
      this.buildUI(this.uiGroup);
      this.__\u003C\u003Efrag.add();
    }

    [LineNumberTable(new byte[] {161, 132, 108, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateState()
    {
      if (!Vars.state.isMenu())
        return;
      this.controlledType = (UnitType) null;
    }

    [LineNumberTable(new byte[] {161, 47, 153, 108, 181, 127, 48, 191, 20, 144, 108, 181, 119, 159, 16, 131, 127, 0, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      Vars.player.typing = Vars.ui.chatfrag.shown();
      if (Vars.player.isBuilder())
        Vars.player.unit().updateBuilding(this.isBuilding);
      if (Vars.player.shooting && !this.wasShooting && (Vars.player.unit().hasWeapons() && Vars.state.rules.unitAmmo) && (double) Vars.player.unit().ammo <= 0.0)
        ((Weapon) Vars.player.unit().type.weapons.first()).noAmmoSound.at((Position) Vars.player.unit());
      this.wasShooting = Vars.player.shooting;
      if (!Vars.player.dead())
        this.controlledType = Vars.player.unit().type;
      if (this.controlledType == null || !Vars.player.dead())
        return;
      Unit unit = Units.closest(Vars.player.team(), Vars.player.x, Vars.player.y, (Boolf) new InputHandler.__\u003C\u003EAnon17(this));
      if (unit == null || Vars.net.client() && !this.controlInterval.get(0, 70f))
        return;
      Call.unitControl(Vars.player, unit);
    }

    [LineNumberTable(new byte[] {161, 76, 107, 127, 16, 120, 191, 47, 99, 108, 141, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void checkUnit()
    {
      if (this.controlledType == null)
        return;
      Unit unit = Units.closest(Vars.player.team(), Vars.player.x, Vars.player.y, (Boolf) new InputHandler.__\u003C\u003EAnon18(this));
      if (unit == null && object.ReferenceEquals((object) this.controlledType, (object) UnitTypes.block))
      {
        Building building = Vars.world.buildWorld(Vars.player.x, Vars.player.y);
        ControlBlock controlBlock;
        unit = !(building is ControlBlock) || !object.ReferenceEquals((object) (controlBlock = (ControlBlock) building), (object) (ControlBlock) building) || !controlBlock.canControl() ? (Unit) null : controlBlock.unit();
      }
      if (unit == null)
        return;
      if (Vars.net.client())
        Call.unitControl(Vars.player, unit);
      else
        unit.controller((UnitController) Vars.player);
    }

    [LineNumberTable(new byte[] {161, 154, 104, 148, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawBreaking(BuildPlan request)
    {
      if (request.breaking)
        this.drawBreaking(request.x, request.y);
      else
        this.drawSelected(request.x, request.y, request.block, Pal.remove);
    }

    [Signature("()Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;")]
    [LineNumberTable(401)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Eachable allRequests() => (Eachable) new InputHandler.__\u003C\u003EAnon16(this);

    [LineNumberTable(new byte[] {161, 162, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool requestMatches(BuildPlan request)
    {
      Tile tile = Vars.world.tile(request.x, request.y);
      if (tile != null)
      {
        Building build = tile.build;
        ConstructBlock.ConstructBuild constructBuild;
        if (build is ConstructBlock.ConstructBuild && object.ReferenceEquals((object) (constructBuild = (ConstructBlock.ConstructBuild) build), (object) (ConstructBlock.ConstructBuild) build) && object.ReferenceEquals((object) constructBuild.cblock, (object) request.block))
          return true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {51, 100, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void transferItemToUnit(Item item, float x, float y, Itemsc to)
    {
      if (to == null)
        return;
      InputHandler.createItemTransfer(item, 1, x, y, (Position) to, (Runnable) new InputHandler.__\u003C\u003EAnon2(to, item));
    }

    [LineNumberTable(new byte[] {160, 222, 164, 127, 15, 209, 127, 42, 107, 108, 176, 102, 107, 108, 99, 139, 127, 4, 108, 167, 122, 104, 220, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unitControl(Player player, [Nullable(new object[] {64, "Larc/util/Nullable;"})] Unit unit)
    {
      if (player == null)
        return;
      if (Vars.net.server() && !Vars.netServer.__\u003C\u003Eadmins.allowAction(player, Administration.ActionType.__\u003C\u003Econtrol, (Cons) new InputHandler.__\u003C\u003EAnon13(unit)))
      {
        Player player1 = player;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ValidateException(player1, "Player cannot control a unit.");
      }
      Unit unit1 = unit;
      BlockUnitc blockUnitc;
      if (unit1 is BlockUnitc && object.ReferenceEquals((object) (blockUnitc = (BlockUnitc) unit1), (object) (BlockUnitc) unit1))
      {
        Building building = blockUnitc.tile();
        CoreBlock.CoreBuild coreBuild;
        if (building is CoreBlock.CoreBuild && object.ReferenceEquals((object) (coreBuild = (CoreBlock.CoreBuild) building), (object) (CoreBlock.CoreBuild) building))
        {
          Fx.__\u003C\u003Espawn.at((Position) player);
          if (Vars.net.client())
            Vars.control.input.controlledType = (UnitType) null;
          player.clearUnit();
          player.deathTimer = 61f;
          coreBuild.requestSpawn(player);
          goto label_15;
        }
      }
      if (unit == null)
        player.clearUnit();
      else if (unit.isAI() && object.ReferenceEquals((object) unit.team, (object) player.team()) && !unit.dead)
      {
        if (!Vars.net.client())
          player.unit(unit);
        Time.run(Fx.__\u003C\u003EunitSpirit.lifetime, (Runnable) new InputHandler.__\u003C\u003EAnon14(unit));
        if (!player.dead())
          Fx.__\u003C\u003EunitSpirit.at(player.x, player.y, 0.0f, (object) unit);
      }
label_15:
      Events.fire((object) new EventType.UnitControlEvent(player, unit));
    }

    [LineNumberTable(new byte[] {161, 12, 191, 7, 127, 14, 177, 104, 104, 179, 107, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unitCommand(Player player)
    {
      if (player == null || player.dead())
        return;
      Unit unit1 = player.unit();
      Unit unit2;
      if (!(unit1 is Commanderc) || !object.ReferenceEquals((object) (unit2 = unit1), (object) unit1))
        return;
      if (Vars.net.server() && !Vars.netServer.__\u003C\u003Eadmins.allowAction(player, Administration.ActionType.__\u003C\u003Ecommand, (Cons) new InputHandler.__\u003C\u003EAnon15()))
      {
        Player player1 = player;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ValidateException(player1, "Player cannot command a unit.");
      }
      if (unit2.isCommanding())
      {
        unit2.clearCommand();
      }
      else
      {
        if (player.unit().type.commandLimit <= 0)
          return;
        unit2.commandNearby((FormationPattern) new CircleFormation());
        Fx.__\u003C\u003EcommandSend.at((Position) player);
      }
    }

    [LineNumberTable(new byte[] {161, 3, 153, 107, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unitClear(Player player)
    {
      if (player == null || !player.dead() && player.unit().spawnedByCore)
        return;
      Fx.__\u003C\u003Espawn.at((Position) player);
      player.clearUnit();
      player.deathTimer = 61f;
    }

    [LineNumberTable(new byte[] {69, 142, 159, 16, 111, 60, 166, 100, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void transferItemTo(
      [Nullable(new object[] {64, "Larc/util/Nullable;"})] Unit unit,
      Item item,
      int amount,
      float x,
      float y,
      Building build)
    {
      if (build == null || build.items == null)
        return;
      if (unit != null && object.ReferenceEquals((object) unit.item(), (object) item))
        unit.stack.amount = Math.max(unit.stack.amount - amount, 0);
      for (int index = 0; index < Mathf.clamp(amount / 3, 1, 8); ++index)
        Time.run((float) (index * 3), (Runnable) new InputHandler.__\u003C\u003EAnon3(item, amount, x, y, build));
      if (amount <= 0)
        return;
      build.handleStack(item, amount, (Teamc) unit);
    }

    [LineNumberTable(new byte[] {32, 100, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void transferItemEffect(Item item, float x, float y, Itemsc to)
    {
      if (to == null)
        return;
      InputHandler.createItemTransfer(item, 1, x, y, (Position) to, (Runnable) null);
    }

    [LineNumberTable(new byte[] {112, 159, 6, 127, 42, 199, 209, 247, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void transferInventory(Player player, Building build)
    {
      if (player == null || build == null || (!player.within((Position) build, 220f) || build.items == null) || player.dead())
        return;
      if (Vars.net.server() && (player.unit().stack.amount <= 0 || !Units.canInteract(player, build) || !Vars.netServer.__\u003C\u003Eadmins.allowAction(player, Administration.ActionType.__\u003C\u003EdepositItem, build.tile, (Cons) new InputHandler.__\u003C\u003EAnon6(player))))
      {
        Player player1 = player;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ValidateException(player1, "Player cannot transfer an item.");
      }
      player.unit().eachGroup((Cons) new InputHandler.__\u003C\u003EAnon7(build, player));
    }

    [LineNumberTable(new byte[] {160, 215, 132, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void tileTap([Nullable(new object[] {64, "Larc/util/Nullable;"})] Player player, Tile tile)
    {
      if (tile == null)
        return;
      Events.fire((object) new EventType.TapEvent(player, tile));
    }

    [LineNumberTable(new byte[] {160, 204, 100, 127, 23, 120, 123, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void tileConfig([Nullable(new object[] {64, "Larc/util/Nullable;"})] Player player, Building build, [Nullable(new object[] {64, "Larc/util/Nullable;"})] object value)
    {
      if (build == null)
        return;
      if (Vars.net.server() && (!Units.canInteract(player, build) || !Vars.netServer.__\u003C\u003Eadmins.allowAction(player, Administration.ActionType.__\u003C\u003Econfigure, build.tile, (Cons) new InputHandler.__\u003C\u003EAnon11(value))))
      {
        Player player1 = player;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ValidateException(player1, "Player cannot configure a tile.");
      }
      build.configured(player == null || player.dead() ? (Unit) null : player.unit(), value);
      Core.app.post((Runnable) new InputHandler.__\u003C\u003EAnon12(build, player, value));
    }

    [LineNumberTable(new byte[] {38, 135, 117, 132, 104, 111, 59, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void takeItems(Building build, Item item, int amount, Unit to)
    {
      if (to == null || build == null)
        return;
      int num = build.removeStack(item, Math.min(to.maxAccepted(item), amount));
      if (num == 0)
        return;
      to.addItem(item, num);
      for (int index = 0; index < Mathf.clamp(num / 3, 1, 8); ++index)
        Time.run((float) index * 3f, (Runnable) new InputHandler.__\u003C\u003EAnon1(item, build, to));
    }

    [LineNumberTable(new byte[] {57, 108, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setItem(Building build, Item item, int amount)
    {
      if (build == null || build.items == null)
        return;
      build.items.set(item, amount);
    }

    [LineNumberTable(new byte[] {159, 67, 130, 132, 127, 7, 120, 177, 111, 121, 102, 102, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rotateBlock([Nullable(new object[] {64, "Larc/util/Nullable;"})] Player player, Building build, bool direction)
    {
      int num = direction ? 1 : 0;
      if (build == null)
        return;
      if (Vars.net.server() && (!Units.canInteract(player, build) || !Vars.netServer.__\u003C\u003Eadmins.allowAction(player, Administration.ActionType.__\u003C\u003Erotate, build.tile(), (Cons) new InputHandler.__\u003C\u003EAnon10(build, num != 0))))
      {
        Player player1 = player;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ValidateException(player1, "Player cannot rotate a block.");
      }
      if (player != null)
        build.lastAccessed = player.name;
      build.rotation = Mathf.mod(build.rotation + Mathf.sign(num != 0), 4);
      build.updateProximity();
      build.noSleep();
      Fx.__\u003C\u003ErotateBlock.at(build.x, build.y, (float) build.block.size);
    }

    [LineNumberTable(new byte[] {160, 78, 159, 9, 135, 127, 34, 103, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void requestUnitPayload(Player player, Unit target)
    {
      if (player == null)
        return;
      Unit unit1 = player.unit();
      Payloadc payloadc;
      if (!(unit1 is Payloadc) || !object.ReferenceEquals((object) (payloadc = (Payloadc) unit1), (object) (Payloadc) unit1))
        return;
      Unit unit2 = player.unit();
      if (!target.isAI() || !target.isGrounded() || (!payloadc.canPickup(target) || !target.within((Position) unit2, unit2.type.hitSize * 2f + target.type.hitSize * 2f)))
        return;
      Call.pickedUnitPayload(unit2, target);
    }

    [LineNumberTable(new byte[] {90, 159, 12, 127, 7, 216, 209, 249, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void requestItem(Player player, Building build, Item item, int amount)
    {
      if (player == null || build == null || (!build.interactable(player.team()) || !player.within((Position) build, 220f)) || player.dead())
        return;
      if (Vars.net.server() && (!Units.canInteract(player, build) || !Vars.netServer.__\u003C\u003Eadmins.allowAction(player, Administration.ActionType.__\u003C\u003EwithdrawItem, build.tile(), (Cons) new InputHandler.__\u003C\u003EAnon4(item, amount))))
      {
        Player player1 = player;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ValidateException(player1, "Player cannot request items.");
      }
      player.unit().eachGroup((Cons) new InputHandler.__\u003C\u003EAnon5(build, item, player, amount));
    }

    [LineNumberTable(new byte[] {160, 146, 144, 172, 127, 6, 150, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void requestDropPayload(Player player, float x, float y)
    {
      if (player == null || Vars.net.client())
        return;
      Payloadc payloadc = (Payloadc) player.unit();
      Tmp.__\u003C\u003Ev1.set(x, y).sub((Position) payloadc).limit(32f).add((Position) payloadc);
      float x1 = Tmp.__\u003C\u003Ev1.x;
      float y1 = Tmp.__\u003C\u003Ev1.y;
      Call.payloadDropped(player.unit(), x1, y1);
    }

    [LineNumberTable(new byte[] {160, 90, 159, 9, 135, 127, 27, 167, 103, 108, 138, 127, 9, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void requestBuildPayload(Player player, Building build)
    {
      if (player == null)
        return;
      Unit unit1 = player.unit();
      Payloadc payloadc;
      if (!(unit1 is Payloadc) || !object.ReferenceEquals((object) (payloadc = (Payloadc) unit1), (object) (Payloadc) unit1))
        return;
      Unit unit2 = player.unit();
      if (build == null || !object.ReferenceEquals((object) build.team, (object) unit2.team) || !unit2.within((Position) build, (float) (8 * build.block.size) * 1.2f + 40f))
        return;
      Payload payload = build.getPayload();
      if (payload != null && payloadc.canPickupPayload(payload))
      {
        Call.pickedBuildPayload(unit2, build, false);
      }
      else
      {
        if (object.ReferenceEquals((object) build.block.buildVisibility, (object) BuildVisibility.__\u003C\u003Ehidden) || !build.canPickup() || !payloadc.canPickup(build))
          return;
        Call.pickedBuildPayload(unit2, build, true);
      }
    }

    [LineNumberTable(new byte[] {160, 110, 127, 3, 105, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void pickedUnitPayload(Unit unit, Unit target)
    {
      if (target != null)
      {
        Unit unit1 = unit;
        Payloadc payloadc;
        if (unit1 is Payloadc && object.ReferenceEquals((object) (payloadc = (Payloadc) unit1), (object) (Payloadc) unit1))
        {
          payloadc.pickup(target);
          return;
        }
      }
      target?.remove();
    }

    [LineNumberTable(new byte[] {159, 84, 98, 127, 12, 99, 127, 9, 140, 107, 173, 103, 108, 104, 100, 104, 171, 130, 102, 107, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void pickedBuildPayload(Unit unit, Building build, bool onGround)
    {
      int num = onGround ? 1 : 0;
      if (build != null)
      {
        Unit unit1 = unit;
        Payloadc payloadc;
        if (unit1 is Payloadc && object.ReferenceEquals((object) (payloadc = (Payloadc) unit1), (object) (Payloadc) unit1))
        {
          if (num != 0)
          {
            if (!object.ReferenceEquals((object) build.block.buildVisibility, (object) BuildVisibility.__\u003C\u003Ehidden) && build.canPickup() && payloadc.canPickup(build))
            {
              payloadc.pickup(build);
              return;
            }
            Fx.__\u003C\u003EunitPickup.at((Position) build);
            build.tile.remove();
            return;
          }
          Payload payload1 = build.getPayload();
          if (payload1 == null || !payloadc.canPickupPayload(payload1))
            return;
          Payload payload2 = build.takePayload();
          if (payload2 == null)
            return;
          payloadc.addPayload(payload2);
          Fx.__\u003C\u003EunitPickup.at((Position) build);
          return;
        }
      }
      if (build == null || num == 0)
        return;
      Fx.__\u003C\u003EunitPickup.at((Position) build);
      build.tile.remove();
    }

    [LineNumberTable(new byte[] {160, 159, 127, 3, 112, 106, 103, 104, 245, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void payloadDropped(Unit unit, float x, float y)
    {
      Unit unit1 = unit;
      Payloadc payloadc;
      if (!(unit1 is Payloadc) || !object.ReferenceEquals((object) (payloadc = (Payloadc) unit1), (object) (Payloadc) unit1))
        return;
      float f1 = payloadc.x();
      float f2 = payloadc.y();
      payloadc.set(x, y);
      payloadc.dropLastPayload();
      payloadc.set(f1, f2);
      payloadc.controlling().each((Cons) new InputHandler.__\u003C\u003EAnon8());
    }

    [LineNumberTable(new byte[] {160, 174, 132, 127, 0, 177, 215})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void dropItem(Player player, float angle)
    {
      if (player == null)
        return;
      if (Vars.net.server() && player.unit().stack.amount <= 0)
      {
        Player player1 = player;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ValidateException(player1, "Player cannot drop an item.");
      }
      player.unit().eachGroup((Cons) new InputHandler.__\u003C\u003EAnon9(angle));
    }

    [LineNumberTable(new byte[] {63, 108, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void clearItems(Building build)
    {
      if (build == null || build.items == null)
        return;
      build.items.clear();
    }

    [LineNumberTable(new byte[] {159, 96, 162, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void removeQueueBlock(int x, int y, bool breaking)
    {
      int num = breaking ? 1 : 0;
      Vars.player.unit().removeBuild(x, y, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPlacing() => this.block != null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isBreaking() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawBottom()
    {
    }

    [LineNumberTable(new byte[] {163, 145, 127, 30, 99, 107, 112, 118, 194, 127, 10, 127, 31, 167})]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Unit selectedUnit()
    {
      Unit unit = Units.closest(Vars.player.team(), Core.input.mouseWorld().x, Core.input.mouseWorld().y, 40f, (Boolf) new InputHandler.__\u003C\u003EAnon28());
      if (unit != null)
      {
        unit.hitbox(Tmp.__\u003C\u003Er1);
        Tmp.__\u003C\u003Er1.grow(6f);
        if (Tmp.__\u003C\u003Er1.contains(Core.input.mouseWorld()))
          return unit;
      }
      Building building1 = Vars.world.buildWorld(Core.input.mouseWorld().x, Core.input.mouseWorld().y);
      Building building2 = building1;
      ControlBlock controlBlock;
      return building2 is ControlBlock && object.ReferenceEquals((object) (controlBlock = (ControlBlock) building2), (object) (ControlBlock) building2) && (controlBlock.canControl() && object.ReferenceEquals((object) building1.team, (object) Vars.player.team())) ? controlBlock.unit() : (Unit) null;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawTop()
    {
    }

    [LineNumberTable(409)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isUsingSchematic() => !this.selectRequests.isEmpty();

    [LineNumberTable(486)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMouseX() => (float) Core.input.mouseX();

    [LineNumberTable(490)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMouseY() => (float) Core.input.mouseY();

    [LineNumberTable(new byte[] {158, 110, 163, 108, 154, 116, 191, 39, 124, 251, 60, 229, 70, 116, 191, 32, 124, 251, 60, 229, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawArrow(Block block, int x, int y, int rotation, bool valid)
    {
      int num1 = valid ? 1 : 0;
      float num2 = (float) (block.size / 2 * 8);
      int x1 = Geometry.d4(rotation).x;
      int y1 = Geometry.d4(rotation).y;
      Draw.color(num1 != 0 ? Pal.accentBack : Pal.removeBack);
      Draw.rect((TextureRegion) Core.atlas.find("place-arrow"), (float) (x * 8) + block.offset + (float) x1 * num2, (float) (y * 8) + block.offset - 1f + (float) y1 * num2, (float) Core.atlas.find("place-arrow").width * Draw.scl, (float) Core.atlas.find("place-arrow").height * Draw.scl, (float) (rotation * 90 - 90));
      Draw.color(num1 != 0 ? Pal.accent : Pal.remove);
      Draw.rect((TextureRegion) Core.atlas.find("place-arrow"), (float) (x * 8) + block.offset + (float) x1 * num2, (float) (y * 8) + block.offset + (float) y1 * num2, (float) Core.atlas.find("place-arrow").width * Draw.scl, (float) Core.atlas.find("place-arrow").height * Draw.scl, (float) (rotation * 90 - 90));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawOverSelect()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDroppingItem() => this.droppingItem;

    [LineNumberTable(1098)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canDropItem() => this.droppingItem && !this.canTapPlayer(Core.input.mouseWorldX(), Core.input.mouseWorldY());

    [LineNumberTable(new byte[] {82, 120, 100, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void createItemTransfer(
      Item item,
      int amount,
      float x,
      float y,
      Position to,
      Runnable done)
    {
      Fx.__\u003C\u003EitemTransfer.at(x, y, (float) amount, item.color, (object) to);
      if (done == null)
        return;
      Time.run(Fx.__\u003C\u003EitemTransfer.lifetime, done);
    }

    [LineNumberTable(new byte[] {161, 167, 109, 100, 135, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawBreaking(int x, int y)
    {
      Tile tile = Vars.world.tile(x, y);
      if (tile == null)
        return;
      Block block = tile.block();
      this.drawSelected(x, y, block, Pal.remove);
    }

    [LineNumberTable(new byte[] {161, 150, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawSelected(int x, int y, Block block, Color color) => Drawf.selected(x, y, block, color);

    [LineNumberTable(636)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int schemOriginX() => this.rawTileX();

    [LineNumberTable(640)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int schemOriginY() => this.rawTileY();

    [LineNumberTable(987)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int rawTileX() => World.toTile(Core.input.mouseWorld().x);

    [LineNumberTable(991)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int rawTileY() => World.toTile(Core.input.mouseWorld().y);

    [LineNumberTable(new byte[] {162, 24, 121, 111, 121, 135, 237, 81, 127, 10, 107, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual BuildPlan getRequest(
      int x,
      int y,
      int size,
      BuildPlan skip)
    {
      int num1 = size + 1;
      int num2 = 2;
      float num3 = (float) ((num2 != -1 ? num1 % num2 : 0) * 8) / 2f;
      InputHandler.r2.setSize((float) (8 * size));
      InputHandler.r2.setCenter((float) (x * 8) + num3, (float) (y * 8) + num3);
      this.resultreq = (BuildPlan) null;
      Boolf predicate = (Boolf) new InputHandler.__\u003C\u003EAnon23(skip);
      Iterator iterator = Vars.player.unit().plans().iterator();
      while (iterator.hasNext())
      {
        BuildPlan buildPlan = (BuildPlan) iterator.next();
        if (predicate.get((object) buildPlan))
          return buildPlan;
      }
      return (BuildPlan) this.selectRequests.find(predicate);
    }

    [LineNumberTable(1141)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool validBreak(int x, int y) => Build.validBreak(Vars.player.team(), x, y);

    [LineNumberTable(new byte[] {162, 54, 120, 148, 115, 112, 110, 156, 244, 60, 38, 233, 73, 159, 20, 106, 138, 127, 14, 107, 120, 136, 130, 127, 5, 107, 120, 136, 130, 127, 22, 115, 127, 7, 159, 11, 133, 138, 106, 127, 21, 106, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void drawBreakSelection(
      int x1,
      int y1,
      int x2,
      int y2,
      int maxLength)
    {
      Placement.NormalizeDrawResult normalizeDrawResult = Placement.normalizeDrawArea(Blocks.air, x1, y1, x2, y2, false, maxLength, 1f);
      Placement.NormalizeResult normalizeResult = Placement.normalizeArea(x1, y1, x2, y2, this.rotation, false, maxLength);
      for (int x = normalizeResult.x; x <= normalizeResult.x2; ++x)
      {
        for (int y = normalizeResult.y; y <= normalizeResult.y2; ++y)
        {
          Tile tile = Vars.world.tileBuilding(x, y);
          if (tile != null && this.validBreak((int) tile.x, (int) tile.y))
            this.drawBreaking((int) tile.x, (int) tile.y);
        }
      }
      Tmp.__\u003C\u003Er1.set(normalizeDrawResult.x, normalizeDrawResult.y, normalizeDrawResult.x2 - normalizeDrawResult.x, normalizeDrawResult.y2 - normalizeDrawResult.y);
      Draw.color(Pal.remove);
      Lines.stroke(1f);
      Iterator iterator1 = Vars.player.unit().plans().iterator();
      while (iterator1.hasNext())
      {
        BuildPlan request = (BuildPlan) iterator1.next();
        if (!request.breaking && request.bounds(Tmp.__\u003C\u003Er2).overlaps(Tmp.__\u003C\u003Er1))
          this.drawBreaking(request);
      }
      Iterator iterator2 = this.selectRequests.iterator();
      while (iterator2.hasNext())
      {
        BuildPlan request = (BuildPlan) iterator2.next();
        if (!request.breaking && request.bounds(Tmp.__\u003C\u003Er2).overlaps(Tmp.__\u003C\u003Er1))
          this.drawBreaking(request);
      }
      Iterator iterator3 = Vars.player.team().data().blocks.iterator();
      while (iterator3.hasNext())
      {
        Teams.BlockPlan blockPlan = (Teams.BlockPlan) iterator3.next();
        if (Vars.content.block((int) blockPlan.__\u003C\u003Eblock).bounds((int) blockPlan.__\u003C\u003Ex, (int) blockPlan.__\u003C\u003Ey, Tmp.__\u003C\u003Er2).overlaps(Tmp.__\u003C\u003Er1))
          this.drawSelected((int) blockPlan.__\u003C\u003Ex, (int) blockPlan.__\u003C\u003Ey, Vars.content.block((int) blockPlan.__\u003C\u003Eblock), Pal.remove);
      }
      Lines.stroke(2f);
      Draw.color(Pal.removeBack);
      Lines.rect(normalizeDrawResult.x, normalizeDrawResult.y - 1f, normalizeDrawResult.x2 - normalizeDrawResult.x, normalizeDrawResult.y2 - normalizeDrawResult.y);
      Draw.color(Pal.remove);
      Lines.rect(normalizeDrawResult.x, normalizeDrawResult.y, normalizeDrawResult.x2 - normalizeDrawResult.x, normalizeDrawResult.y2 - normalizeDrawResult.y);
    }

    [LineNumberTable(1125)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool validPlace(int x, int y, Block type, int rotation) => this.validPlace(x, y, type, rotation, (BuildPlan) null);

    [LineNumberTable(new byte[] {158, 198, 99, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void removeSelection(int x1, int y1, int x2, int y2, bool flush)
    {
      int num = flush ? 1 : 0;
      this.removeSelection(x1, y1, x2, y2, num != 0, 100);
    }

    [LineNumberTable(new byte[] {158, 197, 131, 116, 122, 122, 111, 144, 144, 134, 99, 108, 127, 16, 254, 53, 41, 233, 82, 159, 30, 118, 105, 110, 127, 2, 135, 130, 109, 105, 110, 127, 2, 135, 162, 127, 6, 105, 110, 115, 127, 7, 135, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void removeSelection(
      int x1,
      int y1,
      int x2,
      int y2,
      bool flush,
      int maxLength)
    {
      int num = flush ? 1 : 0;
      Placement.NormalizeResult normalizeResult = Placement.normalizeArea(x1, y1, x2, y2, this.rotation, false, maxLength);
      for (int index1 = 0; index1 <= Math.abs(normalizeResult.x2 - normalizeResult.x); ++index1)
      {
        for (int index2 = 0; index2 <= Math.abs(normalizeResult.y2 - normalizeResult.y); ++index2)
        {
          int x = x1 + index1 * Mathf.sign((float) (x2 - x1));
          int y = y1 + index2 * Mathf.sign((float) (y2 - y1));
          Tile tile = Vars.world.tileBuilding(x, y);
          if (tile != null)
          {
            if (num == 0)
              this.tryBreakBlock(x, y);
            else if (this.validBreak((int) tile.x, (int) tile.y) && !this.selectRequests.contains((Boolf) new InputHandler.__\u003C\u003EAnon25(tile)))
              this.selectRequests.add((object) new BuildPlan((int) tile.x, (int) tile.y));
          }
        }
      }
      Tmp.__\u003C\u003Er1.set((float) (normalizeResult.x * 8), (float) (normalizeResult.y * 8), (float) ((normalizeResult.x2 - normalizeResult.x) * 8), (float) ((normalizeResult.y2 - normalizeResult.y) * 8));
      Iterator iterator1 = Vars.player.unit().plans().iterator();
      while (iterator1.hasNext())
      {
        BuildPlan buildPlan = (BuildPlan) iterator1.next();
        if (!buildPlan.breaking && buildPlan.bounds(Tmp.__\u003C\u003Er2).overlaps(Tmp.__\u003C\u003Er1))
          iterator1.remove();
      }
      Iterator iterator2 = this.selectRequests.iterator();
      while (iterator2.hasNext())
      {
        BuildPlan buildPlan = (BuildPlan) iterator2.next();
        if (!buildPlan.breaking && buildPlan.bounds(Tmp.__\u003C\u003Er2).overlaps(Tmp.__\u003C\u003Er1))
          iterator2.remove();
      }
      Iterator iterator3 = Vars.state.teams.get(Vars.player.team()).blocks.iterator();
      while (iterator3.hasNext())
      {
        Teams.BlockPlan blockPlan = (Teams.BlockPlan) iterator3.next();
        if (Vars.content.block((int) blockPlan.__\u003C\u003Eblock).bounds((int) blockPlan.__\u003C\u003Ex, (int) blockPlan.__\u003C\u003Ey, Tmp.__\u003C\u003Er2).overlaps(Tmp.__\u003C\u003Er1))
          iterator3.remove();
      }
    }

    [LineNumberTable(new byte[] {163, 237, 106, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tryBreakBlock(int x, int y)
    {
      if (!this.validBreak(x, y))
        return;
      this.breakBlock(x, y);
    }

    [Signature("(IIIILarc/func/Cons<Lmindustry/input/InputHandler$PlaceLine;>;)V")]
    [LineNumberTable(new byte[] {164, 37, 144, 120, 168, 117, 168, 102, 109, 110, 127, 5, 122, 141, 159, 5, 98, 171, 104, 178, 113, 104, 107, 191, 20, 159, 0, 112, 143, 127, 64, 165, 127, 1, 114, 114, 110, 100, 127, 19, 114, 113, 127, 14, 98, 175, 145, 115, 141, 255, 45, 39, 235, 91})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void iterateLine([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] Cons obj4)
    {
      int num1 = Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Ediagonal_placement) ? 1 : 0;
      if (Core.settings.getBool("swapdiagonal") && Vars.mobile)
        num1 = num1 != 0 ? 0 : 1;
      if (this.block != null && this.block.swapDiagonalPlacement)
        num1 = num1 != 0 ? 0 : 1;
      Seq points;
      if (num1 != 0)
      {
        Building building1 = Vars.world.build(obj0, obj1);
        Building building2 = Vars.world.build(obj2, obj3);
        points = this.block == null || !(building1 is ChainedBuilding) || (!(building2 is ChainedBuilding) || !this.block.canReplace(building2.block)) || !this.block.canReplace(building1.block) ? Placement.pathfindLine(this.block != null && this.block.conveyorPlacement, obj0, obj1, obj2, obj3) : Placement.upgradeLine(obj0, obj1, obj2, obj3);
      }
      else
        points = Placement.normalizeLine(obj0, obj1, obj2, obj3);
      if (this.block != null)
        this.block.changePlacementPath(points, this.rotation);
      float num2 = Angles.angle((float) obj0, (float) obj1, (float) obj2, (float) obj3);
      int num3 = this.rotation;
      if (!this.overrideLineRotation || num1 != 0)
      {
        int num4;
        if (obj0 == obj2 && obj1 == obj3)
        {
          num4 = this.rotation;
        }
        else
        {
          int num5 = ByteCodeHelper.f2i((num2 + 45f) / 90f);
          int num6 = 4;
          num4 = num6 != -1 ? num5 % num6 : 0;
        }
        num3 = num4;
      }
      Tmp.__\u003C\u003Er3.set(-1f, -1f, 0.0f, 0.0f);
      for (int index = 0; index < points.size; ++index)
      {
        Point2 point2_1 = (Point2) points.get(index);
        if (this.block == null || !Tmp.__\u003C\u003Er2.setSize((float) (this.block.size * 8)).setCenter((float) (point2_1.x * 8) + this.block.offset, (float) (point2_1.y * 8) + this.block.offset).overlaps(Tmp.__\u003C\u003Er3))
        {
          Point2 point2_2 = index != points.size - 1 ? (Point2) points.get(index + 1) : (Point2) null;
          this.__\u003C\u003Eline.x = point2_1.x;
          this.__\u003C\u003Eline.y = point2_1.y;
          if (!this.overrideLineRotation || num1 != 0)
          {
            if (point2_2 != null)
              this.__\u003C\u003Eline.rotation = (int) (sbyte) Tile.relativeTo(point2_1.x, point2_1.y, point2_2.x, point2_2.y);
            else if (this.block.conveyorPlacement && index > 0)
            {
              Point2 point2_3 = (Point2) points.get(index - 1);
              this.__\u003C\u003Eline.rotation = (int) (sbyte) Tile.relativeTo(point2_3.x, point2_3.y, point2_1.x, point2_1.y);
            }
            else
              this.__\u003C\u003Eline.rotation = num3;
          }
          else
            this.__\u003C\u003Eline.rotation = this.rotation;
          this.__\u003C\u003Eline.last = point2_2 == null;
          obj4.get((object) this.__\u003C\u003Eline);
          Tmp.__\u003C\u003Er3.setSize((float) (this.block.size * 8)).setCenter((float) (point2_1.x * 8) + this.block.offset, (float) (point2_1.y * 8) + this.block.offset);
        }
      }
    }

    [LineNumberTable(new byte[] {163, 113, 114, 104, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int tileX([In] float obj0)
    {
      Vec2 vec2 = Core.input.mouseWorld(obj0, 0.0f);
      if (this.selectedBlock())
        vec2.sub(this.block.offset, this.block.offset);
      return World.toTile(vec2.x);
    }

    [LineNumberTable(new byte[] {163, 121, 114, 104, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int tileY([In] float obj0)
    {
      Vec2 vec2 = Core.input.mouseWorld(0.0f, obj0);
      if (this.selectedBlock())
        vec2.sub(this.block.offset, this.block.offset);
      return World.toTile(vec2.y);
    }

    [LineNumberTable(new byte[] {162, 229, 108, 246, 71, 113, 246, 71, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void updateLine(int x1, int y1, int x2, int y2)
    {
      this.lineRequests.clear();
      this.iterateLine(x1, y1, x2, y2, (Cons) new InputHandler.__\u003C\u003EAnon26(this));
      if (!Core.settings.getBool("blockreplace"))
        return;
      this.lineRequests.each((Cons) new InputHandler.__\u003C\u003EAnon27(this));
      this.block.handlePlacementLine(this.lineRequests);
    }

    [LineNumberTable(943)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool canTapPlayer([In] float obj0, [In] float obj1) => Vars.player.within(obj0, obj1, InputHandler.playerSelectRange) && Vars.player.unit().stack.amount > 0;

    [LineNumberTable(new byte[] {163, 91, 109, 108, 110, 126, 115, 245, 59})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool canMine([In] Tile obj0) => !Core.scene.hasMouse() && obj0.drop() != null && Vars.player.unit().validMine(obj0) && ((!obj0.floor().playerUnmineable || obj0.overlay().itemDrop != null) && (Vars.player.unit().acceptsItem(obj0.drop()) && object.ReferenceEquals((object) obj0.block(), (object) Blocks.air)));

    [LineNumberTable(1011)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool selectedBlock() => this.isPlacing();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void buildPlacementUI(Table table)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void buildUI(Group group)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool onConfigurable() => false;

    [LineNumberTable(new byte[] {164, 7, 109, 119, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void breakBlock(int x, int y)
    {
      Tile tile = Vars.world.tile(x, y);
      if (tile != null && tile.build != null)
        tile = tile.build.tile;
      Vars.player.unit().addBuild(new BuildPlan((int) tile.x, (int) tile.y));
    }

    [LineNumberTable(new byte[] {163, 247, 127, 13, 159, 10, 127, 1, 120, 130, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool validPlace(int x, int y, Block type, int rotation, BuildPlan ignore)
    {
      Iterator iterator = Vars.player.unit().plans().iterator();
      while (iterator.hasNext())
      {
        BuildPlan buildPlan = (BuildPlan) iterator.next();
        if (!object.ReferenceEquals((object) buildPlan, (object) ignore) && !buildPlan.breaking && buildPlan.block.bounds(buildPlan.x, buildPlan.y, Tmp.__\u003C\u003Er1).overlaps(type.bounds(x, y, Tmp.__\u003C\u003Er2)) && (!type.canReplace(buildPlan.block) || !Tmp.__\u003C\u003Er1.equals((object) Tmp.__\u003C\u003Er2)))
          return false;
      }
      return Build.validPlace(type, Vars.player.team(), x, y, rotation);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {22, 127, 41, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00241([In] EventType.UnitDestroyEvent obj0)
    {
      if (obj0.__\u003C\u003Eunit == null || !obj0.__\u003C\u003Eunit.isPlayer() || (!obj0.__\u003C\u003Eunit.getPlayer().isLocal() || !obj0.__\u003C\u003Eunit.type.weapons.contains((Boolf) new InputHandler.__\u003C\u003EAnon35())))
        return;
      Vars.player.shooting = false;
    }

    [Modifiers]
    [LineNumberTable(95)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024takeItems\u00242([In] Item obj0, [In] Building obj1, [In] Unit obj2) => InputHandler.transferItemEffect(obj0, obj1.x, obj1.y, (Itemsc) obj2);

    [Modifiers]
    [LineNumberTable(102)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024transferItemToUnit\u00243([In] Itemsc obj0, [In] Item obj1) => obj0.addItem(obj1);

    [Modifiers]
    [LineNumberTable(124)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024transferItemTo\u00245(
      [In] Item obj0,
      [In] int obj1,
      [In] float obj2,
      [In] float obj3,
      [In] Building obj4)
    {
      InputHandler.createItemTransfer(obj0, obj1, obj2, obj3, (Position) obj4, (Runnable) new InputHandler.__\u003C\u003EAnon34());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {94, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024requestItem\u00246(
      [In] Item obj0,
      [In] int obj1,
      [In] Administration.PlayerAction obj2)
    {
      obj2.item = obj0;
      obj2.itemAmount = obj1;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {102, 145, 111, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024requestItem\u00247(
      [In] Building obj0,
      [In] Item obj1,
      [In] Player obj2,
      [In] int obj3,
      [In] Unit obj4)
    {
      Call.takeItems(obj0, obj1, obj4.maxAccepted(obj1), obj4);
      if (!object.ReferenceEquals((object) obj4, (object) obj2.unit()))
        return;
      Events.fire((object) new EventType.WithdrawEvent(obj0, obj2, obj1, obj3));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {116, 118, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024transferInventory\u00248(
      [In] Player obj0,
      [In] Administration.PlayerAction obj1)
    {
      obj1.itemAmount = obj0.unit().stack.amount;
      obj1.item = obj0.unit().item();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {124, 103, 148, 149, 110, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024transferInventory\u00249([In] Building obj0, [In] Player obj1, [In] Unit obj2)
    {
      Item obj = obj2.item();
      int amount = obj0.acceptStack(obj, obj2.stack.amount, (Teamc) obj2);
      Call.transferItemTo(obj2, obj, amount, obj2.x, obj2.y, obj0);
      if (!object.ReferenceEquals((object) obj2, (object) obj1.unit()))
        return;
      Events.fire((object) new EventType.DepositEvent(obj0, obj1, obj, amount));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 165, 104, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024payloadDropped\u002410([In] Unit obj0)
    {
      if (!(obj0 is Payloadc))
        return;
      Call.payloadDropped(obj0, obj0.x, obj0.y);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 181, 127, 4, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024dropItem\u002411([In] float obj0, [In] Unit obj1)
    {
      Fx.__\u003C\u003EdropItem.at(obj1.x, obj1.y, obj0, Color.__\u003C\u003Ewhite, (object) obj1.item());
      obj1.clearItem();
    }

    [Modifiers]
    [LineNumberTable(305)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rotateBlock\u002412(
      [In] Building obj0,
      [In] bool obj1,
      [In] Administration.PlayerAction obj2)
    {
      int num = obj1 ? 1 : 0;
      obj2.rotation = Mathf.mod(obj0.rotation + Mathf.sign(num != 0), 4);
    }

    [Modifiers]
    [LineNumberTable(320)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024tileConfig\u002413(
      [In] object obj0,
      [In] Administration.PlayerAction obj1)
    {
      obj1.config = obj0;
    }

    [Modifiers]
    [LineNumberTable(322)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024tileConfig\u002414([In] Building obj0, [In] Player obj1, [In] object obj2) => Events.fire((object) new EventType.ConfigEvent(obj0, obj1, obj2));

    [Modifiers]
    [LineNumberTable(339)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024unitControl\u002415([In] Unit obj0, [In] Administration.PlayerAction obj1) => obj1.unit = obj0;

    [Modifiers]
    [LineNumberTable(361)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024unitControl\u002416([In] Unit obj0) => Fx.__\u003C\u003EunitControl.at(obj0.x, obj0.y, 0.0f, (object) obj0);

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024unitCommand\u002417([In] Administration.PlayerAction obj0)
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 32, 127, 19, 127, 10, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024allRequests\u002418([In] Cons obj0)
    {
      Iterator iterator1 = Vars.player.unit().plans().iterator();
      while (iterator1.hasNext())
      {
        BuildPlan buildPlan = (BuildPlan) iterator1.next();
        obj0.get((object) buildPlan);
      }
      Iterator iterator2 = this.selectRequests.iterator();
      while (iterator2.hasNext())
      {
        BuildPlan buildPlan = (BuildPlan) iterator2.next();
        obj0.get((object) buildPlan);
      }
      Iterator iterator3 = this.lineRequests.iterator();
      while (iterator3.hasNext())
      {
        BuildPlan buildPlan = (BuildPlan) iterator3.next();
        obj0.get((object) buildPlan);
      }
    }

    [Modifiers]
    [LineNumberTable(434)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024update\u002419([In] Unit obj0) => !obj0.isPlayer() && object.ReferenceEquals((object) obj0.type, (object) this.controlledType) && !obj0.dead;

    [Modifiers]
    [LineNumberTable(447)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024checkUnit\u002420([In] Unit obj0) => !obj0.isPlayer() && object.ReferenceEquals((object) obj0.type, (object) this.controlledType) && !obj0.dead;

    [Modifiers]
    [LineNumberTable(466)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024tryPickupPayload\u002421([In] Payloadc obj0, [In] Unit obj1, [In] Unit obj2) => obj2.isAI() && obj2.isGrounded() && (obj0.canPickup(obj2) && obj2.within((Position) obj1, obj2.hitSize + obj1.hitSize));

    [Modifiers]
    [LineNumberTable(new byte[] {161, 182, 127, 1, 99, 255, 3, 70, 119, 123, 112, 111, 117, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showSchematicSave\u002424([In] string obj0)
    {
      Schematic schematic = (Schematic) Vars.schematics.all().find((Boolf) new InputHandler.__\u003C\u003EAnon32(obj0));
      if (schematic != null)
      {
        Vars.ui.showConfirm("@confirm", "@schematic.replace", (Runnable) new InputHandler.__\u003C\u003EAnon33(this, schematic));
      }
      else
      {
        this.lastSchematic.tags.put((object) "name", (object) obj0);
        this.lastSchematic.tags.put((object) "description", (object) "");
        Vars.schematics.add(this.lastSchematic);
        Vars.ui.showInfoFade("@schematic.saved");
        Vars.ui.schematics.showInfo(this.lastSchematic);
        Events.fire((object) new EventType.SchematicCreateEvent(this.lastSchematic));
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 204, 241, 79, 127, 19, 98, 100, 99, 132, 98, 131, 123, 123, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rotateRequests\u002426(
      [In] int obj0,
      [In] int obj1,
      [In] int obj2,
      [In] BuildPlan obj3)
    {
      obj3.pointConfig((Cons) new InputHandler.__\u003C\u003EAnon31(obj0));
      float num1 = (float) ((obj3.x - obj1) * 8) + obj3.block.offset;
      float num2 = (float) ((obj3.y - obj2) * 8) + obj3.block.offset;
      float num3 = num1;
      float num4;
      float num5;
      if (obj0 >= 0)
      {
        num4 = -num2;
        num5 = num3;
      }
      else
      {
        num4 = num2;
        num5 = -num3;
      }
      obj3.x = World.toTile(num4 - obj3.block.offset) + obj1;
      obj3.y = World.toTile(num5 - obj3.block.offset) + obj2;
      obj3.rotation = Mathf.mod(obj3.rotation + obj0, 4);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {158, 246, 66, 159, 10, 99, 159, 3, 191, 1, 242, 77, 122, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024flipRequests\u002428([In] bool obj0, [In] int obj1, [In] BuildPlan obj2)
    {
      int num1 = obj0 ? 1 : 0;
      float num2 = -((float) ((num1 == 0 ? obj2.y : obj2.x) * 8 - obj1) + obj2.block.offset) + (float) obj1;
      if (num1 != 0)
        obj2.x = ByteCodeHelper.f2i((num2 - obj2.block.offset) / 8f);
      else
        obj2.y = ByteCodeHelper.f2i((num2 - obj2.block.offset) / 8f);
      obj2.pointConfig((Cons) new InputHandler.__\u003C\u003EAnon30(num1 != 0, obj2));
      int num3 = num1;
      int rotation = obj2.rotation;
      int num4 = 2;
      int num5 = (num4 != -1 ? rotation % num4 : 0) != 0 ? 0 : 1;
      if (num3 != num5)
        return;
      obj2.rotation = Mathf.mod(obj2.rotation + 2, 4);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 30, 107, 135, 133, 104, 121, 159, 22, 121, 191, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024getRequest\u002429([In] BuildPlan obj0, [In] BuildPlan obj1)
    {
      if (object.ReferenceEquals((object) obj1, (object) obj0))
        return false;
      Tile tile = obj1.tile();
      if (tile == null)
        return false;
      if (!obj1.breaking)
      {
        InputHandler.r1.setSize((float) (obj1.block.size * 8));
        InputHandler.r1.setCenter(tile.worldx() + obj1.block.offset, tile.worldy() + obj1.block.offset);
      }
      else
      {
        InputHandler.r1.setSize((float) (tile.block().size * 8));
        InputHandler.r1.setCenter(tile.worldx() + tile.block().offset, tile.worldy() + tile.block().offset);
      }
      return InputHandler.r2.overlaps(InputHandler.r1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 146, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024drawOverRequest\u002430([In] Cons obj0)
    {
      this.selectRequests.each(obj0);
      this.lineRequests.each(obj0);
    }

    [Modifiers]
    [LineNumberTable(818)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024removeSelection\u002431([In] Tile obj0, [In] BuildPlan obj1) => obj1.tile() != null && object.ReferenceEquals((object) obj1.tile(), (object) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {162, 231, 108, 127, 10, 107, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024updateLine\u002432([In] InputHandler.PlaceLine obj0)
    {
      this.rotation = obj0.rotation;
      this.lineRequests.add((object) new BuildPlan(obj0.x, obj0.y, obj0.rotation, this.block, this.block.nextConfig())
      {
        animScale = 1f
      });
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 239, 115, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024updateLine\u002433([In] BuildPlan obj0)
    {
      Block replacement = obj0.block.getReplacement(obj0, this.lineRequests);
      if (!replacement.unlockedNow())
        return;
      obj0.block = replacement;
    }

    [Modifiers]
    [LineNumberTable(1063)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024add\u002434([In] InputProcessor obj0)
    {
      switch (obj0)
      {
        case InputHandler _:
label_2:
          return true;
        case GestureDetector _:
          if (!(((GestureDetector) obj0).getListener() is InputHandler))
            break;
          goto label_2;
      }
      return false;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {158, 244, 98, 118, 115, 99, 113, 137, 113, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024flipRequests\u002427([In] bool obj0, [In] BuildPlan obj1, [In] Point2 obj2)
    {
      int num1 = obj0 ? 1 : 0;
      int num2 = num1 == 0 ? obj1.originalHeight / 2 : obj1.originalWidth / 2;
      int num3 = -(num1 == 0 ? obj2.y : obj2.x);
      if (num1 != 0)
      {
        obj1.originalX = -(obj1.originalX - num2) + num2;
        obj2.x = num3;
      }
      else
      {
        obj1.originalY = -(obj1.originalY - num2) + num2;
        obj2.y = num3;
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 205, 110, 130, 100, 99, 132, 98, 131, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rotateRequests\u002425([In] int obj0, [In] Point2 obj1)
    {
      int x1 = obj1.x;
      int y1 = obj1.y;
      int num = x1;
      int x2;
      int y2;
      if (obj0 >= 0)
      {
        x2 = -y1;
        y2 = num;
      }
      else
      {
        x2 = y1;
        y2 = -num;
      }
      obj1.set(x2, y2);
    }

    [Modifiers]
    [LineNumberTable(552)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024showSchematicSave\u002422([In] string obj0, [In] Schematic obj1) => String.instancehelper_equals(obj1.name(), (object) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {161, 185, 113, 111, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showSchematicSave\u002423([In] Schematic obj0)
    {
      Vars.schematics.overwrite(obj0, this.lastSchematic);
      Vars.ui.showInfoFade("@schematic.saved");
      Vars.ui.schematics.showInfo(obj0);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024transferItemTo\u00244()
    {
    }

    [Modifiers]
    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00240([In] Weapon obj0) => obj0.bullet.killShooter;

    [LineNumberTable(new byte[] {20, 232, 45, 139, 235, 70, 245, 69, 139, 107, 107, 171, 244, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public InputHandler()
    {
      InputHandler inputHandler = this;
      this.__\u003C\u003Efrag = new OverlayFragment();
      this.controlInterval = new Interval();
      this.isBuilding = true;
      this.buildWasAutoPaused = false;
      this.wasShooting = false;
      this.__\u003C\u003Eline = new InputHandler.PlaceLine();
      this.brequest = new BuildPlan();
      this.lineRequests = new Seq();
      this.selectRequests = new Seq();
      Events.on((Class) ClassLiteral<EventType.UnitDestroyEvent>.Value, (Cons) new InputHandler.__\u003C\u003EAnon0());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual OverlayFragment getFrag() => this.__\u003C\u003Efrag;

    [LineNumberTable(new byte[] {161, 93, 107, 159, 1, 127, 29, 99, 141, 153, 118, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tryPickupPayload()
    {
      Unit unit1 = Vars.player.unit();
      Unit unit2 = unit1;
      Payloadc payloadc;
      if (!(unit2 is Payloadc) || !object.ReferenceEquals((object) (payloadc = (Payloadc) unit2), (object) (Payloadc) unit2))
        return;
      Unit target = Units.closest(Vars.player.team(), payloadc.x(), payloadc.y(), unit1.type.hitSize * 2f, (Boolf) new InputHandler.__\u003C\u003EAnon19(payloadc, unit1));
      if (target != null)
      {
        Call.requestUnitPayload(Vars.player, target);
      }
      else
      {
        Building build = Vars.world.buildWorld(payloadc.x(), payloadc.y());
        if (build == null || !object.ReferenceEquals((object) build.team, (object) unit1.team))
          return;
        Call.requestBuildPayload(Vars.player, build);
      }
    }

    [LineNumberTable(new byte[] {161, 109, 107, 137, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tryDropPayload()
    {
      if (!(Vars.player.unit() is Payloadc))
        return;
      Call.requestDropPayload(Vars.player, Vars.player.x, Vars.player.y);
    }

    [LineNumberTable(new byte[] {161, 175, 127, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void useSchematic(Schematic schem) => this.selectRequests.addAll(Vars.schematics.toRequests(schem, Vars.player.tileX(), Vars.player.tileY()));

    [LineNumberTable(new byte[] {161, 179, 137, 255, 5, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void showSchematicSave()
    {
      if (this.lastSchematic == null)
        return;
      Vars.ui.showTextInput("@schematic.add", "@name", "", (Cons) new InputHandler.__\u003C\u003EAnon20(this));
    }

    [Signature("(Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;I)V")]
    [LineNumberTable(new byte[] {161, 201, 142, 243, 93})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rotateRequests(Seq requests, int direction)
    {
      int num1 = this.schemOriginX();
      int num2 = this.schemOriginY();
      requests.each((Cons) new InputHandler.__\u003C\u003EAnon21(direction, num1, num2));
    }

    [Signature("(Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;Z)V")]
    [LineNumberTable(new byte[] {158, 247, 98, 148, 242, 90})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void flipRequests(Seq requests, bool x)
    {
      int num1 = x ? 1 : 0;
      int num2 = (num1 == 0 ? this.schemOriginY() : this.schemOriginX()) * 8;
      requests.each((Cons) new InputHandler.__\u003C\u003EAnon22(num1 != 0, num2));
    }

    [LineNumberTable(645)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual BuildPlan getRequest(int x, int y) => this.getRequest(x, y, 1, (BuildPlan) null);

    [LineNumberTable(new byte[] {162, 101, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void drawBreakSelection(int x1, int y1, int x2, int y2) => this.drawBreakSelection(x1, y1, x2, y2, 100);

    [LineNumberTable(new byte[] {162, 105, 152, 138, 106, 127, 21, 106, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void drawSelection(int x1, int y1, int x2, int y2, int maxLength)
    {
      Placement.NormalizeDrawResult normalizeDrawResult = Placement.normalizeDrawArea(Blocks.air, x1, y1, x2, y2, false, maxLength, 1f);
      Lines.stroke(2f);
      Draw.color(Pal.accentBack);
      Lines.rect(normalizeDrawResult.x, normalizeDrawResult.y - 1f, normalizeDrawResult.x2 - normalizeDrawResult.x, normalizeDrawResult.y2 - normalizeDrawResult.y);
      Draw.color(Pal.accent);
      Lines.rect(normalizeDrawResult.x, normalizeDrawResult.y, normalizeDrawResult.x2 - normalizeDrawResult.x, normalizeDrawResult.y2 - normalizeDrawResult.y);
    }

    [Signature("(Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {162, 116, 126, 127, 15, 127, 0, 99, 118, 127, 29, 109, 177, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void flushSelectRequests(Seq requests)
    {
      Iterator iterator = requests.iterator();
      while (iterator.hasNext())
      {
        BuildPlan buildPlan = (BuildPlan) iterator.next();
        if (buildPlan.block != null && this.validPlace(buildPlan.x, buildPlan.y, buildPlan.block, buildPlan.rotation))
        {
          BuildPlan request = this.getRequest(buildPlan.x, buildPlan.y, buildPlan.block.size, (BuildPlan) null);
          if (request == null)
            this.selectRequests.add((object) buildPlan.copy());
          else if (!request.breaking && request.x == buildPlan.x && (request.y == buildPlan.y && request.block.size == buildPlan.block.size))
          {
            this.selectRequests.remove((object) request);
            this.selectRequests.add((object) buildPlan.copy());
          }
        }
      }
    }

    [Signature("(Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {162, 130, 126, 127, 9, 103, 108, 144, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void flushRequests(Seq requests)
    {
      Iterator iterator = requests.iterator();
      while (iterator.hasNext())
      {
        BuildPlan buildPlan = (BuildPlan) iterator.next();
        if (buildPlan.block != null && this.validPlace(buildPlan.x, buildPlan.y, buildPlan.block, buildPlan.rotation))
        {
          BuildPlan plan = buildPlan.copy();
          buildPlan.block.onNewPlan(plan);
          Vars.player.unit().addBuild(plan);
        }
      }
    }

    [LineNumberTable(new byte[] {162, 140, 159, 0, 101, 127, 27, 106, 215, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void drawOverRequest(BuildPlan request)
    {
      int num = this.validPlace(request.x, request.y, request.block, request.rotation) ? 1 : 0;
      Draw.reset();
      Draw.mixcol(num != 0 ? Color.__\u003C\u003Ewhite : Pal.breakInvalid, (num != 0 ? 0.24f : 0.4f) + Mathf.absin(Time.globalTime, 6f, 0.28f));
      Draw.alpha(1f);
      request.block.drawRequestConfigTop(request, (Eachable) new InputHandler.__\u003C\u003EAnon24(this));
      Draw.reset();
    }

    [LineNumberTable(new byte[] {162, 153, 127, 17})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void drawRequest(BuildPlan request) => request.block.drawPlan(request, this.allRequests(), this.validPlace(request.x, request.y, request.block, request.rotation));

    [LineNumberTable(new byte[] {162, 158, 113, 112, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void drawRequest(int x, int y, Block block, int rotation)
    {
      this.brequest.set(x, y, rotation, block);
      this.brequest.animScale = 1f;
      block.drawPlan(this.brequest, this.allRequests(), this.validPlace(x, y, block, rotation));
    }

    [LineNumberTable(new byte[] {162, 165, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void removeSelection(int x1, int y1, int x2, int y2) => this.removeSelection(x1, y1, x2, y2, false);

    [LineNumberTable(new byte[] {162, 170, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void removeSelection(
      int x1,
      int y1,
      int x2,
      int y2,
      int maxLength)
    {
      this.removeSelection(x1, y1, x2, y2, false, maxLength);
    }

    [LineNumberTable(new byte[] {162, 250, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void updateLine(int x1, int y1) => this.updateLine(x1, y1, this.tileX(this.getMouseX()), this.tileY(this.getMouseY()));

    [LineNumberTable(new byte[] {162, 255, 99, 112, 112, 130, 164, 127, 3, 98, 159, 11, 127, 6, 108, 179, 146, 127, 11, 98, 176, 114, 226, 69, 117, 198, 127, 0, 100, 127, 3, 123, 113, 98, 194, 99, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool tileTapped([Nullable(new object[] {64, "Larc/util/Nullable;"})] Building _param1)
    {
      if (_param1 == null)
      {
        this.__\u003C\u003Efrag.__\u003C\u003Einv.hide();
        this.__\u003C\u003Efrag.__\u003C\u003Econfig.hideConfig();
        return false;
      }
      int num1 = 0;
      int num2 = 0;
      if (_param1.block.configurable && _param1.interactable(Vars.player.team()))
      {
        num1 = 1;
        if (!this.__\u003C\u003Efrag.__\u003C\u003Econfig.isShown() && _param1.shouldShowConfigure(Vars.player) || this.__\u003C\u003Efrag.__\u003C\u003Econfig.isShown() && this.__\u003C\u003Efrag.__\u003C\u003Econfig.getSelectedTile().onConfigureTileTapped(_param1))
        {
          Sounds.click.at((Position) _param1);
          this.__\u003C\u003Efrag.__\u003C\u003Econfig.showConfig(_param1);
        }
      }
      else if (!this.__\u003C\u003Efrag.__\u003C\u003Econfig.hasConfigMouse())
      {
        if (this.__\u003C\u003Efrag.__\u003C\u003Econfig.isShown() && this.__\u003C\u003Efrag.__\u003C\u003Econfig.getSelectedTile().onConfigureTileTapped(_param1))
        {
          num1 = 1;
          this.__\u003C\u003Efrag.__\u003C\u003Econfig.hideConfig();
        }
        if (this.__\u003C\u003Efrag.__\u003C\u003Econfig.isShown())
          num1 = 1;
      }
      if (num1 == 0 && _param1.interactable(Vars.player.team()))
        _param1.tapped();
      if (_param1.interactable(Vars.player.team()) && _param1.block.consumesTap)
        num1 = 1;
      else if (_param1.interactable(Vars.player.team()) && _param1.block.synthetic() && (num1 == 0 && _param1.block.hasItems) && _param1.items.total() > 0)
      {
        this.__\u003C\u003Efrag.__\u003C\u003Einv.showFor(_param1);
        num1 = 1;
        num2 = 1;
      }
      if (num2 == 0)
        this.__\u003C\u003Efrag.__\u003C\u003Einv.hide();
      return num1 != 0;
    }

    [LineNumberTable(new byte[] {163, 53, 108, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool tryTapPlayer([In] float obj0, [In] float obj1)
    {
      if (!this.canTapPlayer(obj0, obj1))
        return false;
      this.droppingItem = true;
      return true;
    }

    [LineNumberTable(new byte[] {163, 66, 105, 112, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool tryBeginMine([In] Tile obj0)
    {
      if (!this.canMine(obj0))
        return false;
      Vars.player.unit().mineTile = obj0;
      return true;
    }

    [LineNumberTable(new byte[] {163, 75, 113, 112, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool tryStopMine()
    {
      if (!Vars.player.unit().mining())
        return false;
      Vars.player.unit().mineTile = (Tile) null;
      return true;
    }

    [LineNumberTable(new byte[] {163, 83, 119, 112, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool tryStopMine([In] Tile obj0)
    {
      if (!object.ReferenceEquals((object) Vars.player.unit().mineTile, (object) obj0))
        return false;
      Vars.player.unit().mineTile = (Tile) null;
      return true;
    }

    [LineNumberTable(983)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Tile tileAt([In] float obj0, [In] float obj1) => Vars.world.tile(this.tileX(obj0), this.tileY(obj1));

    [LineNumberTable(1023)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float mouseAngle(float x, float y) => Core.input.mouseWorld(this.getMouseX(), this.getMouseY()).sub(x, y).angle();

    [LineNumberTable(new byte[] {163, 203, 127, 15, 63, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canShoot() => this.block == null && !this.onConfigurable() && (!this.isDroppingItem() && !Vars.player.unit().activelyBuilding()) && ((!(Vars.player.unit() is Mechc) || !Vars.player.unit().isFlying()) && !Vars.player.unit().mining());

    [LineNumberTable(new byte[] {163, 220, 127, 24, 103, 161, 135, 144, 127, 78, 141, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tryDropItems([Nullable(new object[] {64, "Larc/util/Nullable;"})] Building build, float x, float y)
    {
      if (!this.droppingItem || Vars.player.unit().stack.amount <= 0 || (this.canTapPlayer(x, y) || Vars.state.isPaused()))
      {
        this.droppingItem = false;
      }
      else
      {
        this.droppingItem = false;
        ItemStack stack = Vars.player.unit().stack;
        if (build != null && build.acceptStack(stack.item, stack.amount, (Teamc) Vars.player.unit()) > 0 && (build.interactable(Vars.player.team()) && build.block.hasItems) && (Vars.player.unit().stack().amount > 0 && build.interactable(Vars.player.team())))
          Call.transferInventory(Vars.player, build);
        else
          Call.dropItem(Vars.player.angleTo(x, y));
      }
    }

    [LineNumberTable(new byte[] {164, 13, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawArrow(Block block, int x, int y, int rotation) => this.drawArrow(block, x, y, rotation, this.validPlace(x, y, block, rotation));

    [LineNumberTable(new byte[] {159, 131, 141, 184})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static InputHandler()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.input.InputHandler"))
        return;
      InputHandler.playerSelectRange = !Vars.mobile ? 11f : 17f;
      InputHandler.r1 = new Rect();
      InputHandler.r2 = new Rect();
    }

    [HideFromJava]
    public virtual void connected([In] InputDevice obj0) => InputProcessor.\u003Cdefault\u003Econnected((InputProcessor) this, obj0);

    [HideFromJava]
    public virtual void disconnected([In] InputDevice obj0) => InputProcessor.\u003Cdefault\u003Edisconnected((InputProcessor) this, obj0);

    [HideFromJava]
    public virtual bool keyDown([In] KeyCode obj0) => InputProcessor.\u003Cdefault\u003EkeyDown((InputProcessor) this, obj0);

    [HideFromJava]
    public virtual bool keyUp([In] KeyCode obj0) => InputProcessor.\u003Cdefault\u003EkeyUp((InputProcessor) this, obj0);

    [HideFromJava]
    public virtual bool keyTyped([In] char obj0) => InputProcessor.\u003Cdefault\u003EkeyTyped((InputProcessor) this, obj0);

    [HideFromJava]
    public virtual bool touchDown([In] int obj0, [In] int obj1, [In] int obj2, [In] KeyCode obj3) => InputProcessor.\u003Cdefault\u003EtouchDown((InputProcessor) this, obj0, obj1, obj2, obj3);

    [HideFromJava]
    public virtual bool touchUp([In] int obj0, [In] int obj1, [In] int obj2, [In] KeyCode obj3) => InputProcessor.\u003Cdefault\u003EtouchUp((InputProcessor) this, obj0, obj1, obj2, obj3);

    [HideFromJava]
    public virtual bool touchDragged([In] int obj0, [In] int obj1, [In] int obj2) => InputProcessor.\u003Cdefault\u003EtouchDragged((InputProcessor) this, obj0, obj1, obj2);

    [HideFromJava]
    public virtual bool mouseMoved([In] int obj0, [In] int obj1) => InputProcessor.\u003Cdefault\u003EmouseMoved((InputProcessor) this, obj0, obj1);

    [HideFromJava]
    public virtual bool scrolled([In] float obj0, [In] float obj1) => InputProcessor.\u003Cdefault\u003Escrolled((InputProcessor) this, obj0, obj1);

    [HideFromJava]
    public virtual bool touchDown([In] float obj0, [In] float obj1, [In] int obj2, [In] KeyCode obj3) => GestureDetector.GestureListener.\u003Cdefault\u003EtouchDown((GestureDetector.GestureListener) this, obj0, obj1, obj2, obj3);

    [HideFromJava]
    public virtual bool tap([In] float obj0, [In] float obj1, [In] int obj2, [In] KeyCode obj3) => GestureDetector.GestureListener.\u003Cdefault\u003Etap((GestureDetector.GestureListener) this, obj0, obj1, obj2, obj3);

    [HideFromJava]
    public virtual bool longPress([In] float obj0, [In] float obj1) => GestureDetector.GestureListener.\u003Cdefault\u003ElongPress((GestureDetector.GestureListener) this, obj0, obj1);

    [HideFromJava]
    public virtual bool fling([In] float obj0, [In] float obj1, [In] KeyCode obj2) => GestureDetector.GestureListener.\u003Cdefault\u003Efling((GestureDetector.GestureListener) this, obj0, obj1, obj2);

    [HideFromJava]
    public virtual bool pan([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3) => GestureDetector.GestureListener.\u003Cdefault\u003Epan((GestureDetector.GestureListener) this, obj0, obj1, obj2, obj3);

    [HideFromJava]
    public virtual bool panStop([In] float obj0, [In] float obj1, [In] int obj2, [In] KeyCode obj3) => GestureDetector.GestureListener.\u003Cdefault\u003EpanStop((GestureDetector.GestureListener) this, obj0, obj1, obj2, obj3);

    [HideFromJava]
    public virtual bool zoom([In] float obj0, [In] float obj1) => GestureDetector.GestureListener.\u003Cdefault\u003Ezoom((GestureDetector.GestureListener) this, obj0, obj1);

    [HideFromJava]
    public virtual bool pinch([In] Vec2 obj0, [In] Vec2 obj1, [In] Vec2 obj2, [In] Vec2 obj3) => GestureDetector.GestureListener.\u003Cdefault\u003Epinch((GestureDetector.GestureListener) this, obj0, obj1, obj2, obj3);

    [HideFromJava]
    public virtual void pinchStop() => GestureDetector.GestureListener.\u003Cdefault\u003EpinchStop((GestureDetector.GestureListener) this);

    [Modifiers]
    public OverlayFragment frag
    {
      [HideFromJava] get => this.__\u003C\u003Efrag;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Efrag = value;
    }

    [Modifiers]
    public object line
    {
      [HideFromJava] get => (object) this.__\u003C\u003Eline;
      [HideFromJava] [param: In] set => this.__\u003C\u003Eline = (InputHandler.PlaceLine) value;
    }

    internal class PlaceLine : Object
    {
      public int x;
      public int y;
      public int rotation;
      public bool last;

      [LineNumberTable(1239)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal PlaceLine()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => InputHandler.lambda\u0024new\u00241((EventType.UnitDestroyEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly Item arg\u00241;
      private readonly Building arg\u00242;
      private readonly Unit arg\u00243;

      internal __\u003C\u003EAnon1([In] Item obj0, [In] Building obj1, [In] Unit obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => InputHandler.lambda\u0024takeItems\u00242(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly Itemsc arg\u00241;
      private readonly Item arg\u00242;

      internal __\u003C\u003EAnon2([In] Itemsc obj0, [In] Item obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => InputHandler.lambda\u0024transferItemToUnit\u00243(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly Item arg\u00241;
      private readonly int arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;
      private readonly Building arg\u00245;

      internal __\u003C\u003EAnon3([In] Item obj0, [In] int obj1, [In] float obj2, [In] float obj3, [In] Building obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void run() => InputHandler.lambda\u0024transferItemTo\u00245(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly Item arg\u00241;
      private readonly int arg\u00242;

      internal __\u003C\u003EAnon4([In] Item obj0, [In] int obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => InputHandler.lambda\u0024requestItem\u00246(this.arg\u00241, this.arg\u00242, (Administration.PlayerAction) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly Building arg\u00241;
      private readonly Item arg\u00242;
      private readonly Player arg\u00243;
      private readonly int arg\u00244;

      internal __\u003C\u003EAnon5([In] Building obj0, [In] Item obj1, [In] Player obj2, [In] int obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => InputHandler.lambda\u0024requestItem\u00247(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly Player arg\u00241;

      internal __\u003C\u003EAnon6([In] Player obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => InputHandler.lambda\u0024transferInventory\u00248(this.arg\u00241, (Administration.PlayerAction) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly Building arg\u00241;
      private readonly Player arg\u00242;

      internal __\u003C\u003EAnon7([In] Building obj0, [In] Player obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => InputHandler.lambda\u0024transferInventory\u00249(this.arg\u00241, this.arg\u00242, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public void get([In] object obj0) => InputHandler.lambda\u0024payloadDropped\u002410((Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      private readonly float arg\u00241;

      internal __\u003C\u003EAnon9([In] float obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => InputHandler.lambda\u0024dropItem\u002411(this.arg\u00241, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      private readonly Building arg\u00241;
      private readonly bool arg\u00242;

      internal __\u003C\u003EAnon10([In] Building obj0, [In] bool obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => InputHandler.lambda\u0024rotateBlock\u002412(this.arg\u00241, this.arg\u00242, (Administration.PlayerAction) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Cons
    {
      private readonly object arg\u00241;

      internal __\u003C\u003EAnon11([In] object obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => InputHandler.lambda\u0024tileConfig\u002413(this.arg\u00241, (Administration.PlayerAction) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Runnable
    {
      private readonly Building arg\u00241;
      private readonly Player arg\u00242;
      private readonly object arg\u00243;

      internal __\u003C\u003EAnon12([In] Building obj0, [In] Player obj1, [In] object obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => InputHandler.lambda\u0024tileConfig\u002414(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Cons
    {
      private readonly Unit arg\u00241;

      internal __\u003C\u003EAnon13([In] Unit obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => InputHandler.lambda\u0024unitControl\u002415(this.arg\u00241, (Administration.PlayerAction) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      private readonly Unit arg\u00241;

      internal __\u003C\u003EAnon14([In] Unit obj0) => this.arg\u00241 = obj0;

      public void run() => InputHandler.lambda\u0024unitControl\u002416(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Cons
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public void get([In] object obj0) => InputHandler.lambda\u0024unitCommand\u002417((Administration.PlayerAction) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Eachable
    {
      private readonly InputHandler arg\u00241;

      internal __\u003C\u003EAnon16([In] InputHandler obj0) => this.arg\u00241 = obj0;

      public void each([In] Cons obj0) => this.arg\u00241.lambda\u0024allRequests\u002418(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Boolf
    {
      private readonly InputHandler arg\u00241;

      internal __\u003C\u003EAnon17([In] InputHandler obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024update\u002419((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Boolf
    {
      private readonly InputHandler arg\u00241;

      internal __\u003C\u003EAnon18([In] InputHandler obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024checkUnit\u002420((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Boolf
    {
      private readonly Payloadc arg\u00241;
      private readonly Unit arg\u00242;

      internal __\u003C\u003EAnon19([In] Payloadc obj0, [In] Unit obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (InputHandler.lambda\u0024tryPickupPayload\u002421(this.arg\u00241, this.arg\u00242, (Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Cons
    {
      private readonly InputHandler arg\u00241;

      internal __\u003C\u003EAnon20([In] InputHandler obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024showSchematicSave\u002424((string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Cons
    {
      private readonly int arg\u00241;
      private readonly int arg\u00242;
      private readonly int arg\u00243;

      internal __\u003C\u003EAnon21([In] int obj0, [In] int obj1, [In] int obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => InputHandler.lambda\u0024rotateRequests\u002426(this.arg\u00241, this.arg\u00242, this.arg\u00243, (BuildPlan) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Cons
    {
      private readonly bool arg\u00241;
      private readonly int arg\u00242;

      internal __\u003C\u003EAnon22([In] bool obj0, [In] int obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => InputHandler.lambda\u0024flipRequests\u002428(this.arg\u00241, this.arg\u00242, (BuildPlan) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Boolf
    {
      private readonly BuildPlan arg\u00241;

      internal __\u003C\u003EAnon23([In] BuildPlan obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (InputHandler.lambda\u0024getRequest\u002429(this.arg\u00241, (BuildPlan) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Eachable
    {
      private readonly InputHandler arg\u00241;

      internal __\u003C\u003EAnon24([In] InputHandler obj0) => this.arg\u00241 = obj0;

      public void each([In] Cons obj0) => this.arg\u00241.lambda\u0024drawOverRequest\u002430(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Boolf
    {
      private readonly Tile arg\u00241;

      internal __\u003C\u003EAnon25([In] Tile obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (InputHandler.lambda\u0024removeSelection\u002431(this.arg\u00241, (BuildPlan) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Cons
    {
      private readonly InputHandler arg\u00241;

      internal __\u003C\u003EAnon26([In] InputHandler obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024updateLine\u002432((InputHandler.PlaceLine) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Cons
    {
      private readonly InputHandler arg\u00241;

      internal __\u003C\u003EAnon27([In] InputHandler obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024updateLine\u002433((BuildPlan) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Boolf
    {
      internal __\u003C\u003EAnon28()
      {
      }

      public bool get([In] object obj0) => (((Unitc) obj0).isAI() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Boolf
    {
      internal __\u003C\u003EAnon29()
      {
      }

      public bool get([In] object obj0) => (InputHandler.lambda\u0024add\u002434((InputProcessor) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Cons
    {
      private readonly bool arg\u00241;
      private readonly BuildPlan arg\u00242;

      internal __\u003C\u003EAnon30([In] bool obj0, [In] BuildPlan obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => InputHandler.lambda\u0024flipRequests\u002427(this.arg\u00241, this.arg\u00242, (Point2) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Cons
    {
      private readonly int arg\u00241;

      internal __\u003C\u003EAnon31([In] int obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => InputHandler.lambda\u0024rotateRequests\u002425(this.arg\u00241, (Point2) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon32([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (InputHandler.lambda\u0024showSchematicSave\u002422(this.arg\u00241, (Schematic) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Runnable
    {
      private readonly InputHandler arg\u00241;
      private readonly Schematic arg\u00242;

      internal __\u003C\u003EAnon33([In] InputHandler obj0, [In] Schematic obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024showSchematicSave\u002423(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Runnable
    {
      internal __\u003C\u003EAnon34()
      {
      }

      public void run() => InputHandler.lambda\u0024transferItemTo\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Boolf
    {
      internal __\u003C\u003EAnon35()
      {
      }

      public bool get([In] object obj0) => (InputHandler.lambda\u0024new\u00240((Weapon) obj0) ? 1 : 0) != 0;
    }
  }
}
