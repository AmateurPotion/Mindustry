// Decompiled with JetBrains decompiler
// Type: mindustry.input.DesktopInput
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
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
using mindustry.core;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.input
{
  public class DesktopInput : InputHandler
  {
    public Vec2 movement;
    public Graphics.Cursor cursorType;
    public int selectX;
    public int selectY;
    public int schemX;
    public int schemY;
    public int lastLineX;
    public int lastLineY;
    public int schematicX;
    public int schematicY;
    public PlaceMode mode;
    public float selectScale;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public BuildPlan sreq;
    public bool deleting;
    public bool shouldShoot;
    public bool panning;
    public float panScale;
    public float panSpeed;
    public float panBoostSpeed;
    public long selectMillis;
    public Tile prevSelected;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 171, 104, 139, 139, 252, 74, 149, 159, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DesktopInput()
    {
      DesktopInput desktopInput = this;
      this.movement = new Vec2();
      this.cursorType = (Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Earrow;
      this.selectX = -1;
      this.selectY = -1;
      this.schemX = -1;
      this.schemY = -1;
      this.deleting = false;
      this.shouldShoot = false;
      this.panning = false;
      this.panScale = 0.005f;
      this.panSpeed = 4.5f;
      this.panBoostSpeed = 11f;
      this.selectMillis = 0L;
    }

    [LineNumberTable(new byte[] {161, 249, 140, 104, 113, 113, 150, 121, 113, 191, 20, 116, 159, 33, 100, 138, 173, 99, 142, 127, 3, 109, 223, 22, 127, 50, 155, 127, 13, 113, 177, 104, 113, 166, 113, 230, 69, 127, 0, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void updateMovement(Unit unit)
    {
      int num1 = unit.type.omniMovement ? 1 : 0;
      float num2 = unit.realSpeed();
      float x = Core.input.axis((KeyBinds.KeyBind) Binding.__\u003C\u003Emove_x);
      float y = Core.input.axis((KeyBinds.KeyBind) Binding.__\u003C\u003Emove_y);
      int num3 = !(unit is Mechc) || !unit.isFlying() ? 0 : 1;
      this.movement.set(x, y).nor().scl(num2);
      if (Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Emouse_move))
        this.movement.add(Core.input.mouseWorld().sub((Position) Vars.player).scl(0.04f * num2)).limit(num2);
      float num4 = Angles.mouseAngle(unit.x, unit.y);
      if ((num1 == 0 || !Vars.player.shooting || (!unit.type.hasWeapons() || !unit.type.faceTarget) || (num3 != 0 || !unit.type.rotateShooting) ? 0 : 1) != 0)
        unit.lookAt(num4);
      else
        unit.lookAt(unit.prefRotation());
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
      unit.aim(!unit.type.faceTarget ? (Position) Tmp.__\u003C\u003Ev1.trns(unit.rotation, Core.input.mouseWorld().dst((Position) unit)).add(unit.x, unit.y) : (Position) Core.input.mouseWorld());
      unit.controlWeapons(true, Vars.player.shooting && num3 == 0);
      Vars.player.boosting = Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Eboost) && !this.movement.isZero();
      Vars.player.mouseX = unit.aimX();
      Vars.player.mouseY = unit.aimY();
      if (unit is Payloadc)
      {
        if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003EpickupCargo))
          this.tryPickupPayload();
        if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003EdropCargo))
          this.tryDropPayload();
      }
      if (!Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Ecommand) || unit.type.commandLimit <= 0)
        return;
      Call.unitCommand(Vars.player);
    }

    [LineNumberTable(new byte[] {161, 11, 146, 125, 114, 114, 191, 12, 127, 11, 103, 167, 109, 149, 249, 69, 111, 175, 121, 176, 113, 175, 127, 16, 103, 168, 125, 113, 145, 208, 121, 103, 172, 127, 40, 127, 0, 108, 109, 135, 103, 167, 109, 113, 173, 113, 205, 107, 127, 10, 117, 117, 121, 185, 122, 172, 113, 114, 135, 104, 203, 127, 13, 114, 103, 167, 127, 4, 138, 113, 112, 109, 113, 104, 103, 103, 103, 103, 107, 119, 127, 9, 109, 109, 108, 134, 127, 60, 127, 50, 146, 108, 144, 107, 103, 126, 103, 112, 126, 108, 108, 159, 10, 103, 107, 119, 119, 103, 168, 127, 20, 106, 109, 151, 98, 167, 127, 1, 127, 41, 127, 29, 169, 167, 127, 21, 127, 0, 103, 167, 159, 6, 122, 108, 108, 108, 114, 127, 12, 104, 108, 167, 103, 135, 159, 17, 104, 127, 21, 156, 167, 171, 113, 191, 10, 113, 113, 159, 8, 127, 4, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void pollInput()
    {
      if (Core.scene.getKeyboardFocus() is TextField)
        return;
      Tile tile1 = this.tileAt((float) Core.input.mouseX(), (float) Core.input.mouseY());
      int num1 = this.tileX((float) Core.input.mouseX());
      int num2 = this.tileY((float) Core.input.mouseY());
      int tile2 = World.toTile(Core.input.mouseWorld().x);
      int tile3 = World.toTile(Core.input.mouseWorld().y);
      if (Core.settings.getBool("buildautopause") && this.isBuilding && !Vars.player.unit().isBuilding())
      {
        this.isBuilding = false;
        this.buildWasAutoPaused = true;
      }
      if (!this.selectRequests.isEmpty())
      {
        int num3 = tile2 - this.schematicX;
        int num4 = tile3 - this.schematicY;
        this.selectRequests.each((Cons) new DesktopInput.__\u003C\u003EAnon10(num3, num4));
        this.schematicX += num3;
        this.schematicY += num4;
      }
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Edeselect) && !this.isPlacing())
        Vars.player.unit().mineTile = (Tile) null;
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Eclear_building))
        Vars.player.unit().clearBuilding();
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Eschematic_select) && !Core.scene.hasKeyboard() && !object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking))
      {
        this.schemX = tile2;
        this.schemY = tile3;
      }
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Eschematic_menu) && !Core.scene.hasKeyboard())
      {
        if (Vars.ui.schematics.isShown())
          Vars.ui.schematics.hide();
        else
          Vars.ui.schematics.show();
      }
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Eclear_building) || this.isPlacing())
      {
        this.lastSchematic = (Schematic) null;
        this.selectRequests.clear();
      }
      if (Core.input.keyRelease((KeyBinds.KeyBind) Binding.__\u003C\u003Eschematic_select) && !Core.scene.hasKeyboard() && (this.selectX == -1 && this.selectY == -1) && (this.schemX != -1 && this.schemY != -1))
      {
        this.lastSchematic = Vars.schematics.create(this.schemX, this.schemY, tile2, tile3);
        this.useSchematic(this.lastSchematic);
        if (this.selectRequests.isEmpty())
          this.lastSchematic = (Schematic) null;
        this.schemX = -1;
        this.schemY = -1;
      }
      if (!this.selectRequests.isEmpty())
      {
        if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Eschematic_flip_x))
          this.flipRequests(this.selectRequests, true);
        if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Eschematic_flip_y))
          this.flipRequests(this.selectRequests, false);
      }
      if (this.sreq != null)
      {
        int num3 = this.sreq.block.size + 2;
        int num4 = 2;
        float num5 = (float) ((num4 != -1 ? num3 % num4 : 0) * 8) / 2f;
        float num6 = Core.input.mouseWorld().x + num5;
        float num7 = Core.input.mouseWorld().y + num5;
        this.sreq.x = ByteCodeHelper.f2i(num6 / 8f);
        this.sreq.y = ByteCodeHelper.f2i(num7 / 8f);
      }
      if (this.block == null || !object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Eplacing))
        this.lineRequests.clear();
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Epause_building))
      {
        this.isBuilding = !this.isBuilding;
        this.buildWasAutoPaused = false;
        if (this.isBuilding)
          Vars.player.shooting = false;
      }
      if ((num1 != this.lastLineX || num2 != this.lastLineY) && (this.isPlacing() && object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Eplacing)))
      {
        this.updateLine(this.selectX, this.selectY);
        this.lastLineX = num1;
        this.lastLineY = num2;
      }
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Eselect) && !Core.scene.hasMouse())
      {
        BuildPlan request = this.getRequest(num1, num2);
        if (Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Ebreak_block))
          this.mode = PlaceMode.__\u003C\u003Enone;
        else if (!this.selectRequests.isEmpty())
          this.flushRequests(this.selectRequests);
        else if (this.isPlacing())
        {
          this.selectX = num1;
          this.selectY = num2;
          this.lastLineX = num1;
          this.lastLineY = num2;
          this.mode = PlaceMode.__\u003C\u003Eplacing;
          this.updateLine(this.selectX, this.selectY);
        }
        else if (request != null && !request.breaking && (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Enone) && !request.initialized))
          this.sreq = request;
        else if (request != null && request.breaking)
          this.deleting = true;
        else if (tile1 != null)
        {
          if (!this.tryTapPlayer(Core.input.mouseWorld().x, Core.input.mouseWorld().y) && !this.tileTapped(tile1.build) && (!Vars.player.unit().activelyBuilding() && !this.droppingItem) && !this.tryStopMine(tile1) && (Core.settings.getBool("doubletapmine") && (!object.ReferenceEquals((object) tile1, (object) this.prevSelected) || Time.timeSinceMillis(this.selectMillis) >= 500L) || !this.tryBeginMine(tile1)) && !Core.scene.hasKeyboard())
            Vars.player.shooting = this.shouldShoot;
        }
        else if (!Core.scene.hasKeyboard())
          Vars.player.shooting = this.shouldShoot;
        this.selectMillis = Time.millis();
        this.prevSelected = tile1;
      }
      else if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Edeselect) && this.isPlacing())
      {
        this.block = (Block) null;
        this.mode = PlaceMode.__\u003C\u003Enone;
      }
      else if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Edeselect) && !this.selectRequests.isEmpty())
      {
        this.selectRequests.clear();
        this.lastSchematic = (Schematic) null;
      }
      else if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Ebreak_block) && !Core.scene.hasMouse() && Vars.player.isBuilder())
      {
        this.deleting = false;
        this.mode = PlaceMode.__\u003C\u003Ebreaking;
        this.selectX = this.tileX((float) Core.input.mouseX());
        this.selectY = this.tileY((float) Core.input.mouseY());
        this.schemX = tile2;
        this.schemY = tile3;
      }
      if (Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Eselect) && object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Enone) && (!this.isPlacing() && this.deleting))
      {
        BuildPlan request = this.getRequest(num1, num2);
        if (request != null && request.breaking)
          Vars.player.unit().plans().remove((object) request);
      }
      else
        this.deleting = false;
      if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Eplacing) && this.block != null)
      {
        if (!this.overrideLineRotation && !Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Ediagonal_placement) && (this.selectX != num1 || this.selectY != num2) && ByteCodeHelper.f2i(Core.input.axisTap((KeyBinds.KeyBind) Binding.__\u003C\u003Erotate)) != 0)
        {
          int num3 = ByteCodeHelper.f2i((Angles.angle((float) this.selectX, (float) this.selectY, (float) num1, (float) num2) + 45f) / 90f);
          int num4 = 4;
          this.rotation = num4 != -1 ? num3 % num4 : 0;
          this.overrideLineRotation = true;
        }
      }
      else
        this.overrideLineRotation = false;
      if (Core.input.keyRelease((KeyBinds.KeyBind) Binding.__\u003C\u003Ebreak_block) && Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Eschematic_select) && object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking))
      {
        this.lastSchematic = Vars.schematics.create(this.schemX, this.schemY, tile2, tile3);
        this.schemX = -1;
        this.schemY = -1;
      }
      if (Core.input.keyRelease((KeyBinds.KeyBind) Binding.__\u003C\u003Ebreak_block) || Core.input.keyRelease((KeyBinds.KeyBind) Binding.__\u003C\u003Eselect))
      {
        if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Eplacing) && this.block != null)
        {
          this.flushRequests(this.lineRequests);
          this.lineRequests.clear();
          Events.fire((object) new EventType.LineConfirmEvent());
        }
        else if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking))
        {
          this.removeSelection(this.selectX, this.selectY, num1, num2, Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Eschematic_select) ? 32 : 100);
          if (this.lastSchematic != null)
          {
            this.useSchematic(this.lastSchematic);
            this.lastSchematic = (Schematic) null;
          }
        }
        this.selectX = -1;
        this.selectY = -1;
        this.tryDropItems(tile1?.build, Core.input.mouseWorld().x, Core.input.mouseWorld().y);
        if (this.sreq != null)
        {
          if (this.getRequest(this.sreq.x, this.sreq.y, this.sreq.block.size, this.sreq) != null)
            Vars.player.unit().plans().remove((object) this.sreq, true);
          this.sreq = (BuildPlan) null;
        }
        this.mode = PlaceMode.__\u003C\u003Enone;
      }
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Etoggle_block_status))
        Core.settings.put("blockstatus", (object) Boolean.valueOf(!Core.settings.getBool("blockstatus")));
      if (!Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Etoggle_power_lines))
        return;
      if (Core.settings.getInt("lasersopacity") == 0)
      {
        Core.settings.put("lasersopacity", (object) Integer.valueOf(Core.settings.getInt("preferredlaseropacity", 100)));
      }
      else
      {
        Core.settings.put("preferredlaseropacity", (object) Integer.valueOf(Core.settings.getInt("lasersopacity")));
        Core.settings.put("lasersopacity", (object) Integer.valueOf(0));
      }
    }

    [LineNumberTable(597)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getMouseX() => (float) Core.input.mouseX();

    [LineNumberTable(602)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getMouseY() => (float) Core.input.mouseY();

    [LineNumberTable(new byte[] {160, 229, 103, 115, 147, 108, 127, 4, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void useSchematic(Schematic schem)
    {
      this.block = (Block) null;
      this.schematicX = this.tileX(this.getMouseX());
      this.schematicY = this.tileY(this.getMouseY());
      this.selectRequests.clear();
      this.selectRequests.addAll(Vars.schematics.toRequests(schem, this.schematicX, this.schematicY));
      this.mode = PlaceMode.__\u003C\u003Enone;
    }

    [LineNumberTable(new byte[] {3, 127, 37, 63, 26})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool showHint() => Vars.ui.hudfrag.shown && Core.settings.getBool("hints") && this.selectRequests.isEmpty() && (!this.isBuilding && !Core.settings.getBool("buildautopause") || Vars.player.unit().isBuilding() || !Vars.player.dead() && !Vars.player.unit().spawnedByCore());

    [Modifiers]
    [LineNumberTable(new byte[] {11, 112, 115, 103, 251, 82, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildUI\u00243([In] Table obj0)
    {
      obj0.__\u003C\u003Ecolor.a = 0.0f;
      obj0.visible((Boolp) new DesktopInput.__\u003C\u003EAnon18(this, obj0));
      obj0.bottom();
      obj0.table(Styles.black6, (Cons) new DesktopInput.__\u003C\u003EAnon19(this)).margin(10f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {37, 114, 103, 251, 73, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildUI\u002410([In] Table obj0)
    {
      obj0.visible((Boolp) new DesktopInput.__\u003C\u003EAnon11(this));
      obj0.bottom();
      obj0.table(Styles.black6, (Cons) new DesktopInput.__\u003C\u003EAnon12(this)).margin(6f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {97, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024drawBottom\u002411([In] BuildPlan obj0)
    {
      obj0.animScale = 1f;
      this.drawRequest(obj0);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 250, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024buildPlacementUI\u002412() => Vars.ui.schematics.show();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 254, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024buildPlacementUI\u002413() => Vars.ui.database.show();

    [Modifiers]
    [LineNumberTable(new byte[] {161, 2, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024buildPlacementUI\u002414() => Vars.ui.research.show();

    [Modifiers]
    [LineNumberTable(373)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024buildPlacementUI\u002415() => Vars.state.isCampaign();

    [Modifiers]
    [LineNumberTable(new byte[] {161, 6, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024buildPlacementUI\u002416() => Vars.ui.planet.show();

    [Modifiers]
    [LineNumberTable(377)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024buildPlacementUI\u002417() => Vars.state.isCampaign();

    [Modifiers]
    [LineNumberTable(new byte[] {161, 28, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024pollInput\u002418([In] int obj0, [In] int obj1, [In] BuildPlan obj2)
    {
      obj2.x += obj0;
      obj2.y += obj1;
    }

    [Modifiers]
    [LineNumberTable(87)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024buildUI\u00244() => Vars.ui.hudfrag.shown && this.lastSchematic != null && !this.selectRequests.isEmpty();

    [Modifiers]
    [LineNumberTable(new byte[] {40, 108, 149, 117, 103, 178})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildUI\u00249([In] Table obj0)
    {
      obj0.defaults().left();
      obj0.label((Prov) new DesktopInput.__\u003C\u003EAnon13()).style((Style) Styles.outlineLabel).visible((Boolp) new DesktopInput.__\u003C\u003EAnon14());
      obj0.row();
      obj0.table((Cons) new DesktopInput.__\u003C\u003EAnon15(this));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {41, 124, 124, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024buildUI\u00245()
    {
      object obj = (object) Core.bundle.format("schematic.flip", (object) Core.keybinds.get((KeyBinds.KeyBind) Binding.__\u003C\u003Eschematic_flip_x).key.toString(), (object) Core.keybinds.get((KeyBinds.KeyBind) Binding.__\u003C\u003Eschematic_flip_y).key.toString());
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024buildUI\u00246() => Core.settings.getBool("hints");

    [Modifiers]
    [LineNumberTable(new byte[] {46, 127, 34})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildUI\u00248([In] Table obj0) => obj0.button("@schematic.add", (Drawable) Icon.save, (Runnable) new DesktopInput.__\u003C\u003EAnon16(this)).colspan(2).size(250f, 50f).disabled((Boolf) new DesktopInput.__\u003C\u003EAnon17(this));

    [Modifiers]
    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024buildUI\u00247([In] TextButton obj0) => this.lastSchematic == null || this.lastSchematic.file != null;

    [Modifiers]
    [LineNumberTable(62)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024buildUI\u00240([In] Table obj0)
    {
      Color color1 = obj0.__\u003C\u003Ecolor;
      float num1 = Mathf.lerpDelta(obj0.__\u003C\u003Ecolor.a, (float) Mathf.num(this.showHint()), 0.15f);
      Color color2 = color1;
      double num2 = (double) num1;
      color2.a = num1;
      return num2 > 1.0 / 1000.0;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {15, 102, 108, 247, 78, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildUI\u00242([In] Table obj0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      obj0.defaults().left();
      obj0.label((Prov) new DesktopInput.__\u003C\u003EAnon20(this, stringBuilder)).style((Style) Styles.outlineLabel);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {18, 122, 103, 127, 11, 127, 30, 116, 127, 44, 127, 33, 159, 29, 125, 159, 50})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private CharSequence lambda\u0024buildUI\u00241([In] StringBuilder obj0)
    {
      if (!this.showHint())
      {
        object obj = (object) obj0;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }
      obj0.setLength(0);
      if (!this.isBuilding && !Core.settings.getBool("buildautopause") && !Vars.player.unit().isBuilding())
        obj0.append(Core.bundle.format("enablebuilding", (object) Core.keybinds.get((KeyBinds.KeyBind) Binding.__\u003C\u003Epause_building).key.toString()));
      else if (Vars.player.unit().isBuilding())
        obj0.append(Core.bundle.format(!this.isBuilding ? "resumebuilding" : "pausebuilding", (object) Core.keybinds.get((KeyBinds.KeyBind) Binding.__\u003C\u003Epause_building).key.toString())).append("\n").append(Core.bundle.format("cancelbuilding", (object) Core.keybinds.get((KeyBinds.KeyBind) Binding.__\u003C\u003Eclear_building).key.toString())).append("\n").append(Core.bundle.format("selectschematic", (object) Core.keybinds.get((KeyBinds.KeyBind) Binding.__\u003C\u003Eschematic_select).key.toString()));
      if (!Vars.player.dead() && !Vars.player.unit().spawnedByCore())
        obj0.append(obj0.length() == 0 ? "" : "\n").append(Core.bundle.format("respawn", (object) Core.keybinds.get((KeyBinds.KeyBind) Binding.__\u003C\u003Erespawn).key.toString()));
      object obj1 = (object) obj0;
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj1;
      return charSequence1;
    }

    [LineNumberTable(new byte[] {10, 241, 90, 241, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void buildUI(Group group)
    {
      group.fill((Cons) new DesktopInput.__\u003C\u003EAnon0(this));
      group.fill((Cons) new DesktopInput.__\u003C\u003EAnon1(this));
    }

    [LineNumberTable(new byte[] {54, 106, 114, 178, 114, 191, 12, 127, 16, 182, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawTop()
    {
      Lines.stroke(1f);
      int x2 = this.tileX((float) Core.input.mouseX());
      int y2 = this.tileY((float) Core.input.mouseY());
      if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking))
        this.drawBreakSelection(this.selectX, this.selectY, x2, y2, Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Eschematic_select) ? 32 : 100);
      if (Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Eschematic_select) && !Core.scene.hasKeyboard() && !object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking))
        this.drawSelection(this.schemX, this.schemY, x2, y2, 32);
      Draw.reset();
    }

    [LineNumberTable(new byte[] {72, 114, 178, 107, 127, 26, 114, 191, 20, 157, 223, 72, 122, 105, 99, 255, 19, 69, 246, 69, 150, 143, 127, 1, 115, 115, 126, 159, 2, 247, 59, 233, 71, 123, 107, 109, 148, 101, 117, 116, 148, 112, 127, 27, 122, 118, 119, 108, 229, 69, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawBottom()
    {
      int x = this.tileX((float) Core.input.mouseX());
      int y = this.tileY((float) Core.input.mouseY());
      if (this.sreq != null)
      {
        int num = this.validPlace(this.sreq.x, this.sreq.y, this.sreq.block, this.sreq.rotation, this.sreq) ? 1 : 0;
        if (this.sreq.block.rotate)
          this.drawArrow(this.sreq.block, this.sreq.x, this.sreq.y, this.sreq.rotation, num != 0);
        this.sreq.block.drawPlan(this.sreq, this.allRequests(), num != 0);
        this.drawSelected(this.sreq.x, this.sreq.y, this.sreq.block, this.getRequest(this.sreq.x, this.sreq.y, this.sreq.block.size, this.sreq) == null ? Pal.accent : Pal.remove);
      }
      if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Enone) && !this.isPlacing())
      {
        BuildPlan request = this.getRequest(x, y);
        if (request != null)
          this.drawSelected(request.x, request.y, !request.breaking ? request.block : request.tile().block(), Pal.accent);
      }
      this.selectRequests.each((Cons) new DesktopInput.__\u003C\u003EAnon2(this));
      this.selectRequests.each((Cons) new DesktopInput.__\u003C\u003EAnon3(this));
      if (Vars.player.isBuilder())
      {
        if (object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Eplacing) && this.block != null)
        {
          for (int index = 0; index < this.lineRequests.size; ++index)
          {
            BuildPlan buildPlan = (BuildPlan) this.lineRequests.get(index);
            if (index == this.lineRequests.size - 1 && buildPlan.block.rotate)
              this.drawArrow(this.block, buildPlan.x, buildPlan.y, buildPlan.rotation);
            this.drawRequest((BuildPlan) this.lineRequests.get(index));
          }
          this.lineRequests.each((Cons) new DesktopInput.__\u003C\u003EAnon3(this));
        }
        else if (this.isPlacing())
        {
          if (this.block.rotate)
            this.drawArrow(this.block, x, y, this.rotation);
          Draw.color();
          int num = this.validPlace(x, y, this.block, this.rotation) ? 1 : 0;
          this.drawRequest(x, y, this.block, this.rotation);
          this.block.drawPlace(x, y, this.rotation, num != 0);
          if (this.block.saveConfig)
          {
            Draw.mixcol(num != 0 ? Color.__\u003C\u003Ewhite : Pal.breakInvalid, (num != 0 ? 0.24f : 0.4f) + Mathf.absin(Time.globalTime, 6f, 0.28f));
            this.brequest.set(x, y, this.rotation, this.block);
            this.brequest.config = this.block.lastConfig;
            this.block.drawRequestConfig(this.brequest, this.allRequests());
            this.brequest.config = (object) null;
            Draw.reset();
          }
        }
      }
      Draw.reset();
    }

    [LineNumberTable(new byte[] {160, 75, 134, 127, 74, 175, 98, 159, 8, 127, 10, 98, 167, 127, 56, 199, 127, 40, 113, 162, 127, 45, 116, 191, 19, 102, 127, 50, 191, 50, 150, 108, 127, 3, 103, 99, 107, 231, 69, 127, 10, 144, 127, 15, 106, 199, 113, 171, 127, 19, 127, 1, 127, 13, 191, 13, 185, 127, 60, 127, 39, 186, 125, 127, 2, 99, 203, 108, 107, 161, 166, 122, 171, 116, 171, 116, 107, 158, 171, 127, 21, 159, 9, 104, 191, 19, 122, 116, 126, 223, 2, 157, 102, 104, 177, 127, 2, 171, 113, 176, 127, 7, 171, 127, 7, 176, 127, 84, 223, 8, 108, 176, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update()
    {
      base.update();
      if (Vars.net.active() && Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Eplayer_list) && (Core.scene.getKeyboardFocus() == null || Core.scene.getKeyboardFocus().isDescendantOf((Element) Vars.ui.listfrag.content) || Core.scene.getKeyboardFocus().isDescendantOf(Vars.ui.minimapfrag.elem)))
        Vars.ui.listfrag.toggle();
      int num = 0;
      float scalar = (Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Eboost) ? this.panBoostSpeed : this.panSpeed) * Time.delta;
      if (Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Epan) && !Core.scene.hasField() && !Core.scene.hasDialog())
      {
        num = 1;
        this.panning = true;
      }
      if (((double) Math.abs(Core.input.axis((KeyBinds.KeyBind) Binding.__\u003C\u003Emove_x)) > 0.0 || (double) Math.abs(Core.input.axis((KeyBinds.KeyBind) Binding.__\u003C\u003Emove_y)) > 0.0 || Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Emouse_move)) && !Core.scene.hasField())
        this.panning = false;
      if ((Vars.player.dead() || Vars.state.isPaused()) && (!Vars.ui.chatfrag.shown() && !Core.scene.hasField()) && !Core.scene.hasDialog())
      {
        if (Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Emouse_move))
          num = 1;
        Core.camera.__\u003C\u003Eposition.add(Tmp.__\u003C\u003Ev1.setZero().add(Core.input.axis((KeyBinds.KeyBind) Binding.__\u003C\u003Emove_x), Core.input.axis((KeyBinds.KeyBind) Binding.__\u003C\u003Emove_y)).nor().scl(scalar));
      }
      else if (!Vars.player.dead() && !this.panning)
        Core.camera.__\u003C\u003Eposition.lerpDelta((Position) Vars.player, !Core.settings.getBool("smoothcamera") ? 1f : 0.08f);
      if (num != 0)
      {
        Core.camera.__\u003C\u003Eposition.x += Mathf.clamp(((float) Core.input.mouseX() - (float) Core.graphics.getWidth() / 2f) * this.panScale, -1f, 1f) * scalar;
        Core.camera.__\u003C\u003Eposition.y += Mathf.clamp(((float) Core.input.mouseY() - (float) Core.graphics.getHeight() / 2f) * this.panScale, -1f, 1f) * scalar;
      }
      this.shouldShoot = !Core.scene.hasMouse();
      if (!Core.scene.hasMouse() && Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Econtrol) && Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Eselect))
      {
        Unit unit = this.selectedUnit();
        if (unit != null)
        {
          Call.unitControl(Vars.player, unit);
          this.shouldShoot = false;
        }
      }
      if (!Vars.player.dead() && !Vars.state.isPaused() && !(Core.scene.getKeyboardFocus() is TextField))
      {
        this.updateMovement(Vars.player.unit());
        if (Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Erespawn) && !Vars.player.unit().spawnedByCore() && !Core.scene.hasField())
        {
          Call.unitClear(Vars.player);
          this.controlledType = (UnitType) null;
        }
      }
      if (Core.input.keyRelease((KeyBinds.KeyBind) Binding.__\u003C\u003Eselect))
        Vars.player.shooting = false;
      if (Vars.state.isGame() && !Core.scene.hasDialog() && !(Core.scene.getKeyboardFocus() is TextField))
      {
        if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Eminimap))
          Vars.ui.minimapfrag.toggle();
        if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Eplanet_map) && Vars.state.isCampaign())
          Vars.ui.planet.toggle();
        if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Eresearch) && Vars.state.isCampaign())
          Vars.ui.research.toggle();
      }
      if (Vars.state.isMenu() || Core.scene.hasDialog())
        return;
      if ((!Core.scene.hasScroll() || Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Ediagonal_placement)) && (!Vars.ui.chatfrag.shown() && (double) Math.abs(Core.input.axisTap((KeyBinds.KeyBind) Binding.__\u003C\u003Ezoom)) > 0.0) && !Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Erotateplaced) && (Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Ediagonal_placement) || (!Vars.player.isBuilder() || !this.isPlacing() || !this.block.rotate) && this.selectRequests.isEmpty()))
        Vars.renderer.scaleCamera(Core.input.axisTap((KeyBinds.KeyBind) Binding.__\u003C\u003Ezoom));
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Eselect) && !Core.scene.hasMouse())
      {
        Tile tile = Vars.world.tileWorld(Core.input.mouseWorldX(), Core.input.mouseWorldY());
        if (tile != null)
          Call.tileTap(Vars.player, tile);
      }
      if (Vars.player.dead())
      {
        this.cursorType = (Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Earrow;
      }
      else
      {
        this.pollInput();
        if (!this.isPlacing() && object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Eplacing))
          this.mode = PlaceMode.__\u003C\u003Enone;
        if (Vars.player.shooting && !this.canShoot())
          Vars.player.shooting = false;
        if (this.isPlacing() && Vars.player.isBuilder())
        {
          this.cursorType = (Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Ehand;
          this.selectScale = Mathf.lerpDelta(this.selectScale, 1f, 0.2f);
        }
        else
          this.selectScale = 0.0f;
        if (!Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Ediagonal_placement) && Math.abs(ByteCodeHelper.f2i(Core.input.axisTap((KeyBinds.KeyBind) Binding.__\u003C\u003Erotate))) > 0)
        {
          this.rotation = Mathf.mod(this.rotation + ByteCodeHelper.f2i(Core.input.axisTap((KeyBinds.KeyBind) Binding.__\u003C\u003Erotate)), 4);
          if (this.sreq != null)
            this.sreq.rotation = Mathf.mod(this.sreq.rotation + ByteCodeHelper.f2i(Core.input.axisTap((KeyBinds.KeyBind) Binding.__\u003C\u003Erotate)), 4);
          if (this.isPlacing() && object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Eplacing))
            this.updateLine(this.selectX, this.selectY);
          else if (!this.selectRequests.isEmpty() && !Vars.ui.chatfrag.shown())
            this.rotateRequests(this.selectRequests, Mathf.sign(Core.input.axisTap((KeyBinds.KeyBind) Binding.__\u003C\u003Erotate)));
        }
        Tile tile = this.tileAt((float) Core.input.mouseX(), (float) Core.input.mouseY());
        if (tile != null)
        {
          if (tile.build != null)
            this.cursorType = tile.build.getCursor();
          if (this.isPlacing() && Vars.player.isBuilder() || !this.selectRequests.isEmpty())
            this.cursorType = (Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Ehand;
          if (!this.isPlacing() && this.canMine(tile))
            this.cursorType = Vars.ui.drillCursor;
          if (this.getRequest((int) tile.x, (int) tile.y) != null && object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Enone))
            this.cursorType = (Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Ehand;
          if (this.canTapPlayer(Core.input.mouseWorld().x, Core.input.mouseWorld().y))
            this.cursorType = Vars.ui.unloadCursor;
          if (tile.build != null && tile.interactable(Vars.player.team()) && (!this.isPlacing() && (double) Math.abs(Core.input.axisTap((KeyBinds.KeyBind) Binding.__\u003C\u003Erotate)) > 0.0) && (Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Erotateplaced) && tile.block().rotate && tile.block().quickRotate))
            Call.rotateBlock(Vars.player, tile.build, (double) Core.input.axisTap((KeyBinds.KeyBind) Binding.__\u003C\u003Erotate) > 0.0);
        }
        if (!Core.scene.hasMouse())
          Core.graphics.cursor(this.cursorType);
        this.cursorType = (Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Earrow;
      }
    }

    [LineNumberTable(354)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isBreaking() => object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking);

    [LineNumberTable(new byte[] {160, 245, 127, 7, 103, 159, 6, 159, 0, 134, 159, 0, 134, 159, 5, 144, 159, 5, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void buildPlacementUI(Table table)
    {
      table.image().color(Pal.gray).height(4f).colspan(4).growX();
      table.row();
      table.left().margin(0.0f).defaults().size(48f).left();
      table.button((Drawable) Icon.paste, Styles.clearPartiali, (Runnable) new DesktopInput.__\u003C\u003EAnon4()).tooltip("@schematics");
      table.button((Drawable) Icon.book, Styles.clearPartiali, (Runnable) new DesktopInput.__\u003C\u003EAnon5()).tooltip("@database");
      table.button((Drawable) Icon.tree, Styles.clearPartiali, (Runnable) new DesktopInput.__\u003C\u003EAnon6()).visible((Boolp) new DesktopInput.__\u003C\u003EAnon7()).tooltip("@research");
      table.button((Drawable) Icon.map, Styles.clearPartiali, (Runnable) new DesktopInput.__\u003C\u003EAnon8()).visible((Boolp) new DesktopInput.__\u003C\u003EAnon9()).tooltip("@planetmap");
    }

    [LineNumberTable(592)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool selectedBlock() => this.isPlacing() && !object.ReferenceEquals((object) this.mode, (object) PlaceMode.__\u003C\u003Ebreaking);

    [LineNumberTable(new byte[] {161, 237, 134, 108, 103, 107, 103, 103, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void updateState()
    {
      base.updateState();
      if (!Vars.state.isMenu())
        return;
      this.droppingItem = false;
      this.mode = PlaceMode.__\u003C\u003Enone;
      this.block = (Block) null;
      this.sreq = (BuildPlan) null;
      this.selectRequests.clear();
    }

    [HideFromJava]
    static DesktopInput() => InputHandler.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly DesktopInput arg\u00241;

      internal __\u003C\u003EAnon0([In] DesktopInput obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildUI\u00243((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly DesktopInput arg\u00241;

      internal __\u003C\u003EAnon1([In] DesktopInput obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildUI\u002410((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly DesktopInput arg\u00241;

      internal __\u003C\u003EAnon2([In] DesktopInput obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024drawBottom\u002411((BuildPlan) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly DesktopInput arg\u00241;

      internal __\u003C\u003EAnon3([In] DesktopInput obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.drawOverRequest((BuildPlan) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public void run() => DesktopInput.lambda\u0024buildPlacementUI\u002412();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void run() => DesktopInput.lambda\u0024buildPlacementUI\u002413();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Runnable
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public void run() => DesktopInput.lambda\u0024buildPlacementUI\u002414();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Boolp
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public bool get() => (DesktopInput.lambda\u0024buildPlacementUI\u002415() ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon8 : Runnable
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public void run() => DesktopInput.lambda\u0024buildPlacementUI\u002416();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon9 : Boolp
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public bool get() => (DesktopInput.lambda\u0024buildPlacementUI\u002417() ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon10 : Cons
    {
      private readonly int arg\u00241;
      private readonly int arg\u00242;

      internal __\u003C\u003EAnon10([In] int obj0, [In] int obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => DesktopInput.lambda\u0024pollInput\u002418(this.arg\u00241, this.arg\u00242, (BuildPlan) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon11 : Boolp
    {
      private readonly DesktopInput arg\u00241;

      internal __\u003C\u003EAnon11([In] DesktopInput obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024buildUI\u00244() ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon12 : Cons
    {
      private readonly DesktopInput arg\u00241;

      internal __\u003C\u003EAnon12([In] DesktopInput obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildUI\u00249((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon13 : Prov
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public object get() => (object) DesktopInput.lambda\u0024buildUI\u00245().__\u003Cref\u003E;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon14 : Boolp
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public bool get() => (DesktopInput.lambda\u0024buildUI\u00246() ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon15 : Cons
    {
      private readonly DesktopInput arg\u00241;

      internal __\u003C\u003EAnon15([In] DesktopInput obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildUI\u00248((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly DesktopInput arg\u00241;

      internal __\u003C\u003EAnon16([In] DesktopInput obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.showSchematicSave();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon17 : Boolf
    {
      private readonly DesktopInput arg\u00241;

      internal __\u003C\u003EAnon17([In] DesktopInput obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024buildUI\u00247((TextButton) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon18 : Boolp
    {
      private readonly DesktopInput arg\u00241;
      private readonly Table arg\u00242;

      internal __\u003C\u003EAnon18([In] DesktopInput obj0, [In] Table obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get() => (this.arg\u00241.lambda\u0024buildUI\u00240(this.arg\u00242) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon19 : Cons
    {
      private readonly DesktopInput arg\u00241;

      internal __\u003C\u003EAnon19([In] DesktopInput obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildUI\u00242((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon20 : Prov
    {
      private readonly DesktopInput arg\u00241;
      private readonly StringBuilder arg\u00242;

      internal __\u003C\u003EAnon20([In] DesktopInput obj0, [In] StringBuilder obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) this.arg\u00241.lambda\u0024buildUI\u00241(this.arg\u00242).__\u003Cref\u003E;
    }
  }
}
