// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.OverlayRenderer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.ai.types;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.input;
using mindustry.ui;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics
{
  public class OverlayRenderer : Object
  {
    private const float indicatorLength = 14f;
    private const float spawnerMargin = 88f;
    [Modifiers]
    private static Rect rect;
    private float buildFade;
    private float unitFade;
    private Unit lastSelect;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OverlayRenderer()
    {
    }

    [LineNumberTable(new byte[] {159, 169, 139, 141, 108, 175, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawBottom()
    {
      InputHandler input = Vars.control.input;
      if (Vars.player.dead())
        return;
      if (Vars.player.isBuilder())
        Vars.player.unit().drawBuildPlans();
      input.drawBottom();
    }

    [LineNumberTable(new byte[] {159, 182, 127, 4, 116, 127, 3, 127, 11, 127, 43, 155, 159, 1, 121, 127, 34, 165, 165, 113, 244, 77, 141, 139, 103, 115, 159, 5, 106, 106, 113, 111, 139, 136, 159, 19, 191, 18, 107, 127, 3, 127, 0, 255, 42, 61, 235, 70, 197, 114, 114, 167, 134, 159, 20, 101, 146, 109, 255, 4, 75, 106, 159, 5, 111, 127, 12, 127, 20, 127, 24, 159, 5, 165, 165, 122, 122, 154, 127, 3, 103, 119, 167, 127, 45, 127, 13, 127, 2, 127, 10, 229, 69, 134, 127, 160, 64, 127, 17, 121, 255, 21, 69, 107, 122, 103, 127, 17, 106, 127, 16, 133, 122, 127, 89, 111, 127, 40, 111, 127, 40, 197})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawTop()
    {
      if (!Vars.player.dead() && Vars.ui.hudfrag.shown)
      {
        if (Core.settings.getBool("playerindicators"))
        {
          Iterator iterator = Groups.player.iterator();
          while (iterator.hasNext())
          {
            Player player = (Player) iterator.next();
            if (!object.ReferenceEquals((object) Vars.player, (object) player) && object.ReferenceEquals((object) Vars.player.team(), (object) player.team()) && !OverlayRenderer.rect.setSize(Core.camera.width * 0.9f, Core.camera.height * 0.9f).setCenter(Core.camera.__\u003C\u003Eposition.x, Core.camera.__\u003C\u003Eposition.y).contains(player.x, player.y))
            {
              Tmp.__\u003C\u003Ev1.set((Position) player).sub((Position) Vars.player).setLength(14f);
              Lines.stroke(2f, Vars.player.team().__\u003C\u003Ecolor);
              Lines.lineAngle(Vars.player.x + Tmp.__\u003C\u003Ev1.x, Vars.player.y + Tmp.__\u003C\u003Ev1.y, Tmp.__\u003C\u003Ev1.angle(), 4f);
              Draw.reset();
            }
          }
        }
        if (Core.settings.getBool("indicators"))
          Groups.unit.each((Cons) new OverlayRenderer.__\u003C\u003EAnon0());
      }
      if (Vars.player.dead())
        return;
      InputHandler input = Vars.control.input;
      Unit unit1 = input.selectedUnit();
      if (!Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Econtrol))
        unit1 = (Unit) null;
      this.unitFade = Mathf.lerpDelta(this.unitFade, (float) Mathf.num(unit1 != null), 0.1f);
      if (unit1 != null)
        this.lastSelect = unit1;
      if (unit1 == null)
        unit1 = this.lastSelect;
      if (unit1 != null && unit1.isAI())
      {
        Draw.mixcol(Pal.accent, 1f);
        Draw.alpha(this.unitFade);
        if (unit1 is BlockUnitc)
          Fill.square(unit1.x, unit1.y, (float) (((BlockUnitc) unit1).tile().block.size * 8) / 2f);
        else
          Draw.rect(unit1.type.icon(Cicon.__\u003C\u003Efull), unit1.x(), unit1.y(), unit1.rotation() - 90f);
        for (int index = 0; index < 4; ++index)
        {
          float angle = (float) index * 90f + 45f + (float) (-(double) Time.time % 360.0);
          float len = unit1.hitSize() * 1.5f + this.unitFade * 2.5f;
          Draw.rect("select-arrow", unit1.x + Angles.trnsx(angle, len), unit1.y + Angles.trnsy(angle, len), len / 1.9f, len / 1.9f, angle - 135f);
        }
        Draw.reset();
      }
      if (input.__\u003C\u003Efrag.__\u003C\u003Econfig.isShown())
        input.__\u003C\u003Efrag.__\u003C\u003Econfig.getSelectedTile().drawConfigure();
      input.drawTop();
      this.buildFade = Mathf.lerpDelta(this.buildFade, input.isPlacing() || input.isUsingSchematic() ? 1f : 0.0f, 0.06f);
      Draw.reset();
      Lines.stroke(this.buildFade * 2f);
      if ((double) this.buildFade > 0.00499999988824129)
        Vars.state.teams.eachEnemyCore(Vars.player.team(), (Cons) new OverlayRenderer.__\u003C\u003EAnon1());
      Lines.stroke(2f);
      Draw.color(Color.__\u003C\u003Egray, Color.__\u003C\u003ElightGray, Mathf.absin(Time.time, 8f, 1f));
      if (Vars.state.hasSpawns())
      {
        Iterator iterator = Vars.spawner.getSpawns().iterator();
        while (iterator.hasNext())
        {
          Tile tile = (Tile) iterator.next();
          if (tile.within(Vars.player.x, Vars.player.y, Vars.state.rules.dropZoneRadius + 88f))
          {
            Draw.alpha(Mathf.clamp(1f - (Vars.player.dst((Position) tile) - Vars.state.rules.dropZoneRadius) / 88f));
            Lines.dashCircle(tile.worldx(), tile.worldy(), Vars.state.rules.dropZoneRadius);
          }
        }
      }
      Draw.reset();
      if (input.block == null && !Core.scene.hasMouse())
      {
        Vec2 vec2 = Core.input.mouseWorld(input.getMouseX(), input.getMouseY());
        Building building = Vars.world.buildWorld(vec2.x, vec2.y);
        if (building != null && object.ReferenceEquals((object) building.team, (object) Vars.player.team()))
        {
          building.drawSelect();
          if (!building.enabled && building.block.drawDisabled)
            building.drawDisabled();
          if (Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Erotateplaced) && building.block.rotate && (building.block.quickRotate && building.interactable(Vars.player.team())))
          {
            Vars.control.input.drawArrow(building.block, building.tileX(), building.tileY(), building.rotation, true);
            Draw.color(Pal.accent, 0.3f + Mathf.absin(4f, 0.2f));
            Fill.square(building.x, building.y, (float) (building.block.size * 8) / 2f);
            Draw.color();
          }
        }
      }
      input.drawOverSelect();
      Displayable displayable = Vars.ui.hudfrag.__\u003C\u003Eblockfrag.hover();
      Unit unit2;
      if (displayable is Unit && object.ReferenceEquals((object) (unit2 = (Unit) displayable), (object) (Unit) displayable))
      {
        UnitController unitController = unit2.controller();
        LogicAI logicAi;
        if (unitController is LogicAI && object.ReferenceEquals((object) (logicAi = (LogicAI) unitController), (object) (LogicAI) unitController))
        {
          Building controller = logicAi.controller;
          Building building;
          if (controller is Building && object.ReferenceEquals((object) (building = controller), (object) controller) && building.isValid())
          {
            Drawf.square(building.x, building.y, (float) (building.block.size * 8) / 2f + 2f);
            if (!unit2.within((Position) building, unit2.hitSize * 2f))
              Drawf.arrow(unit2.x, unit2.y, building.x, building.y, unit2.hitSize * 2f, 4f);
          }
        }
      }
      if (!input.isDroppingItem())
        return;
      Vec2 vec2_1 = Core.input.mouseWorld(input.getMouseX(), input.getMouseY());
      float num = 8f;
      Draw.rect(Vars.player.unit().item().icon(Cicon.__\u003C\u003Emedium), vec2_1.x, vec2_1.y, num, num);
      Draw.color(Pal.accent);
      Lines.circle(vec2_1.x, vec2_1.y, 6f + Mathf.absin(Time.time, 5f, 1f));
      Draw.reset();
      Building building1 = Vars.world.buildWorld(vec2_1.x, vec2_1.y);
      if (!input.canDropItem() || building1 == null || (!building1.interactable(Vars.player.team()) || building1.acceptStack(Vars.player.unit().item(), Vars.player.unit().stack.amount, (Teamc) Vars.player.unit()) <= 0) || !Vars.player.within((Position) building1, 220f))
        return;
      Lines.stroke(3f, Pal.gray);
      Lines.square(building1.x, building1.y, (float) (building1.block.size * 8) / 2f + 3f + Mathf.absin(Time.time, 5f, 1f));
      Lines.stroke(1f, Pal.place);
      Lines.square(building1.x, building1.y, (float) (building1.block.size * 8) / 2f + 2f + Mathf.absin(Time.time, 5f, 1f));
      Draw.reset();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {9, 127, 80, 123, 159, 12, 117, 127, 34, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024drawTop\u00240([In] Unit obj0)
    {
      if (obj0.isLocal() || object.ReferenceEquals((object) obj0.team, (object) Vars.player.team()) || OverlayRenderer.rect.setSize(Core.camera.width * 0.9f, Core.camera.height * 0.9f).setCenter(Core.camera.__\u003C\u003Eposition.x, Core.camera.__\u003C\u003Eposition.y).contains(obj0.x, obj0.y))
        return;
      Tmp.__\u003C\u003Ev1.set(obj0.x, obj0.y).sub((Position) Vars.player).setLength(14f);
      Lines.stroke(1f, obj0.team().__\u003C\u003Ecolor);
      Lines.lineAngle(Vars.player.x + Tmp.__\u003C\u003Ev1.x, Vars.player.y + Tmp.__\u003C\u003Ev1.y, Tmp.__\u003C\u003Ev1.angle(), 3f);
      Draw.reset();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {66, 109, 124, 106, 127, 8, 127, 18, 159, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024drawTop\u00241([In] Building obj0)
    {
      if ((double) obj0.dst((Position) Vars.player) >= (double) (Vars.state.rules.enemyCoreBuildRadius * 2.2f))
        return;
      Draw.color(Color.__\u003C\u003EdarkGray);
      Lines.circle(obj0.x, obj0.y - 2f, Vars.state.rules.enemyCoreBuildRadius);
      Draw.color(Pal.accent, obj0.team.__\u003C\u003Ecolor, 0.5f + Mathf.absin(Time.time, 10f, 0.5f));
      Lines.circle(obj0.x, obj0.y, Vars.state.rules.enemyCoreBuildRadius);
    }

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static OverlayRenderer()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.graphics.OverlayRenderer"))
        return;
      OverlayRenderer.rect = new Rect();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => OverlayRenderer.lambda\u0024drawTop\u00240((Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => OverlayRenderer.lambda\u0024drawTop\u00241((Building) obj0);
    }
  }
}
