// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.PlanetDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.graphics.gl;
using arc.input;
using arc.math;
using arc.math.geom;
using arc.scene;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.graphics.g3d;
using mindustry.input;
using mindustry.io.legacy;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.storage;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  [Implements(new string[] {"mindustry.graphics.g3d.PlanetRenderer$PlanetInterfaceRenderer"})]
  public class PlanetDialog : BaseDialog, PlanetRenderer.PlanetInterfaceRenderer
  {
    public static bool debugSelect;
    public static float sectorShowDuration;
    internal FrameBuffer __\u003C\u003Ebuffer;
    internal PlanetRenderer __\u003C\u003Eplanets;
    internal LaunchLoadoutDialog __\u003C\u003Eloadouts;
    public float zoom;
    public float selectAlpha;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Sector selected;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Sector hovered;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Sector launchSector;
    public PlanetDialog.Mode mode;
    public bool launching;
    [Signature("Larc/func/Cons<Lmindustry/type/Sector;>;")]
    public Cons listener;
    [Signature("Larc/struct/Seq<Lmindustry/type/Sector;>;")]
    public Seq newPresets;
    public float presetShow;
    public bool showed;
    public Table sectorTop;
    public Label hoverLabel;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {11, 242, 46, 110, 112, 139, 150, 139, 144, 107, 107, 135, 107, 255, 1, 69, 135, 241, 78, 112, 140, 134, 145, 241, 90, 209, 237, 82, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PlanetDialog()
      : base("", Styles.fullDialog)
    {
      PlanetDialog planetDialog = this;
      this.__\u003C\u003Ebuffer = new FrameBuffer(2, 2, true);
      this.__\u003C\u003Eplanets = Vars.renderer.planets;
      this.__\u003C\u003Eloadouts = new LaunchLoadoutDialog();
      this.zoom = 1f;
      this.selectAlpha = 1f;
      this.mode = PlanetDialog.Mode.__\u003C\u003Elook;
      this.listener = (Cons) new PlanetDialog.__\u003C\u003EAnon0();
      this.newPresets = new Seq();
      this.presetShow = 0.0f;
      this.showed = false;
      this.sectorTop = new Table();
      object obj = (object) "";
      CharSequence text;
      text.__\u003Cref\u003E = (__Null) obj;
      this.hoverLabel = new Label(text);
      this.shouldPause = true;
      this.keyDown((Cons) new PlanetDialog.__\u003C\u003EAnon1(this));
      this.hoverLabel.setStyle(Styles.outlineLabel);
      this.hoverLabel.setAlignment(1);
      this.rebuildButtons();
      this.onResize((Runnable) new PlanetDialog.__\u003C\u003EAnon2(this));
      this.dragged((Floatc2) new PlanetDialog.__\u003C\u003EAnon3(this));
      this.scrolled((Floatc) new PlanetDialog.__\u003C\u003EAnon4(this));
      this.addCaptureListener((EventListener) new PlanetDialog.\u0031(this));
      this.shown((Runnable) new PlanetDialog.__\u003C\u003EAnon5(this));
    }

    [LineNumberTable(new byte[] {90, 108, 111, 194, 127, 3, 244, 72, 102, 107, 125, 135, 107, 112, 107, 112, 107, 135, 172, 127, 8, 127, 16, 113, 113, 139, 133, 109, 187, 107, 134, 114, 182})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Dialog show()
    {
      if (Vars.net.client())
      {
        Vars.ui.showInfo("@map.multiplayer");
        return (Dialog) this;
      }
      if (Core.settings.has("unlocks") && !Core.settings.has("junction-unlocked"))
        Core.app.post((Runnable) new PlanetDialog.__\u003C\u003EAnon6());
      this.rebuildButtons();
      this.mode = PlanetDialog.Mode.__\u003C\u003Elook;
      PlanetDialog planetDialog1 = this;
      PlanetDialog planetDialog2 = this;
      this.launchSector = (Sector) null;
      this.hovered = (Sector) null;
      this.selected = (Sector) null;
      this.launching = false;
      this.zoom = 1f;
      this.__\u003C\u003Eplanets.zoom = 1f;
      this.selectAlpha = 0.0f;
      this.launchSector = Vars.state.getSector();
      this.presetShow = 0.0f;
      this.showed = false;
      this.newPresets.clear();
      Iterator iterator = Vars.content.sectors().iterator();
      while (iterator.hasNext())
      {
        SectorPreset sectorPreset = (SectorPreset) iterator.next();
        if (sectorPreset.unlocked() && !sectorPreset.alwaysUnlocked && (!sectorPreset.sector.info.shown && !sectorPreset.sector.hasBase()))
        {
          this.newPresets.add((object) sectorPreset.sector);
          sectorPreset.sector.info.shown = true;
          sectorPreset.sector.saveInfo();
        }
      }
      if (this.newPresets.any())
        this.newPresets.add((object) this.__\u003C\u003Eplanets.planet.getLastSector());
      this.newPresets.reverse();
      this.updateSelected();
      if (this.__\u003C\u003Eplanets.planet.getLastSector() != null)
        this.lookAt(this.__\u003C\u003Eplanets.planet.getLastSector());
      return base.show();
    }

    [LineNumberTable(new byte[] {160, 79, 139, 140, 108, 127, 2, 102, 136, 102, 113, 124, 113, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void rebuildButtons()
    {
      this.__\u003C\u003Ebuttons.clearChildren();
      this.__\u003C\u003Ebuttons.bottom();
      if (Core.graphics.isPortrait())
      {
        this.__\u003C\u003Ebuttons.add((Element) this.sectorTop).colspan(2).fillX().row();
        this.addBack();
        this.addTech();
      }
      else
      {
        this.addBack();
        this.__\u003C\u003Ebuttons.add().growX();
        this.__\u003C\u003Ebuttons.add((Element) this.sectorTop).minWidth(230f);
        this.__\u003C\u003Ebuttons.add().growX();
        this.addTech();
      }
    }

    [LineNumberTable(new byte[] {162, 21, 103, 135, 99, 102, 161, 114, 102, 140, 242, 112, 133, 159, 15, 159, 17, 100, 241, 74, 103, 104, 191, 49, 107, 127, 46, 135, 127, 26, 127, 36, 127, 1, 127, 40, 63, 40, 157, 103, 101, 127, 0, 126, 105, 112, 126, 167, 122, 246, 70, 175, 135, 104, 191, 22, 127, 35, 97, 121, 111, 111, 112, 251, 59, 229, 69, 191, 12, 102, 137, 243, 81, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void updateSelected()
    {
      Sector selected = this.selected;
      Table sectorTop = this.sectorTop;
      if (selected == null)
      {
        sectorTop.clear();
      }
      else
      {
        float x = sectorTop.getX(1);
        float y = sectorTop.getY(1);
        sectorTop.clear();
        sectorTop.background(Styles.black6);
        sectorTop.table((Cons) new PlanetDialog.__\u003C\u003EAnon17(this, selected)).row();
        sectorTop.image().color(Pal.accent).fillX().height(3f).pad(3f).row();
        int num1 = selected.preset == null || !selected.preset.locked() || (selected.hasBase() || selected.preset.node() == null) ? 0 : 1;
        CharSequence charSequence;
        if (num1 != 0)
          sectorTop.table((Cons) new PlanetDialog.__\u003C\u003EAnon18(selected)).row();
        else if (!selected.hasBase())
        {
          Table table = sectorTop;
          object obj = (object) new StringBuilder().append(Core.bundle.get("sectors.threat")).append(" [accent]").append(selected.displayThreat()).toString();
          charSequence.__\u003Cref\u003E = (__Null) obj;
          CharSequence text = charSequence;
          table.add(text).row();
        }
        if (selected.isAttacked())
        {
          Table table1 = sectorTop;
          object obj1 = (object) Core.bundle.format("sectors.underattack", (object) Integer.valueOf(ByteCodeHelper.f2i(selected.info.damage * 100f)));
          charSequence.__\u003Cref\u003E = (__Null) obj1;
          CharSequence text1 = charSequence;
          table1.add(text1);
          sectorTop.row();
          if (selected.info.wavesSurvived >= 0 && selected.info.wavesSurvived - selected.info.wavesPassed >= 0 && !selected.isBeingPlayed())
          {
            int num2 = selected.info.attack || selected.info.winWave <= 1 ? -1 : selected.info.winWave - (selected.info.wave + selected.info.wavesPassed);
            int num3 = selected.info.wavesSurvived - selected.info.wavesPassed >= 39 ? 1 : 0;
            Table table2 = sectorTop;
            object obj2 = (object) Core.bundle.format("sectors.survives", (object) new StringBuilder().append(Math.min(selected.info.wavesSurvived - selected.info.wavesPassed, num2 > 0 ? num2 : 200)).append(num3 == 0 ? "" : "+").append(num2 >= 0 ? new StringBuilder().append("/").append(num2).toString() : "").toString());
            charSequence.__\u003Cref\u003E = (__Null) obj2;
            CharSequence text2 = charSequence;
            table2.add(text2);
            sectorTop.row();
          }
        }
        else if (selected.hasBase() && selected.near().contains((Boolf) new PlanetDialog.__\u003C\u003EAnon19()))
        {
          Table table = sectorTop;
          object obj = (object) "@sectors.vulnerable";
          charSequence.__\u003Cref\u003E = (__Null) obj;
          CharSequence text = charSequence;
          table.add(text);
          sectorTop.row();
        }
        else if (!selected.hasBase() && selected.hasEnemyBase())
        {
          Table table = sectorTop;
          object obj = (object) "@sectors.enemybase";
          charSequence.__\u003Cref\u003E = (__Null) obj;
          CharSequence text = charSequence;
          table.add(text);
          sectorTop.row();
        }
        if (selected.save != null && selected.info.resources.any())
          sectorTop.table((Cons) new PlanetDialog.__\u003C\u003EAnon20(selected)).padLeft(10f).fillX().row();
        sectorTop.row();
        if (selected.hasBase())
          sectorTop.button("@stats", (Drawable) Icon.info, Styles.transt, (Runnable) new PlanetDialog.__\u003C\u003EAnon21(this, selected)).height(40f).fillX().row();
        if (selected.hasBase() && object.ReferenceEquals((object) this.mode, (object) PlanetDialog.Mode.__\u003C\u003Elook) || this.canSelect(selected) || (selected.preset != null && selected.preset.alwaysUnlocked || PlanetDialog.debugSelect))
          sectorTop.button(!object.ReferenceEquals((object) this.mode, (object) PlanetDialog.Mode.__\u003C\u003Eselect) ? (!selected.isBeingPlayed() ? (!selected.hasBase() ? (num1 == 0 ? "@sectors.launch" : "@locked") : "@sectors.go") : "@sectors.resume") : "@sectors.select", num1 == 0 ? (Drawable) Icon.play : (Drawable) Icon.@lock, (Runnable) new PlanetDialog.__\u003C\u003EAnon22(this)).growX().height(54f).minWidth(170f).padTop(4f).disabled(num1 != 0);
        sectorTop.pack();
        sectorTop.setPosition(x, y, 1);
        sectorTop.update((Runnable) new PlanetDialog.__\u003C\u003EAnon23(this, sectorTop));
        sectorTop.act(0.0f);
      }
    }

    [LineNumberTable(new byte[] {160, 137, 127, 30})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void lookAt([In] Sector obj0) => this.__\u003C\u003Eplanets.__\u003C\u003EcamPos.set(Tmp.__\u003C\u003Ev33.set(obj0.__\u003C\u003Etile.v).rotate(Vec3.__\u003C\u003EY, -obj0.__\u003C\u003Eplanet.getRotation()));

    [LineNumberTable(new byte[] {160, 97, 127, 32})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addBack() => this.__\u003C\u003Ebuttons.button("@back", (Drawable) Icon.left, (Runnable) new PlanetDialog.__\u003C\u003EAnon7(this)).size(200f, 54f).pad(2f).bottom();

    [LineNumberTable(new byte[] {160, 101, 127, 31})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addTech() => this.__\u003C\u003Ebuttons.button("@techtree", (Drawable) Icon.tree, (Runnable) new PlanetDialog.__\u003C\u003EAnon8()).size(200f, 54f).pad(2f).bottom();

    [LineNumberTable(new byte[] {160, 141, 121, 138, 104, 108, 191, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool canSelect([In] Sector obj0)
    {
      if (object.ReferenceEquals((object) this.mode, (object) PlanetDialog.Mode.__\u003C\u003Eselect))
        return obj0.hasBase();
      if (obj0.hasBase())
        return true;
      if (obj0.preset != null)
      {
        TechTree.TechNode techNode = obj0.preset.node();
        return techNode == null || techNode.parent == null || techNode.parent.content.unlocked();
      }
      return obj0.hasBase() || obj0.near().contains((Boolf) new PlanetDialog.__\u003C\u003EAnon9());
    }

    [LineNumberTable(new byte[] {160, 153, 159, 0, 144, 98, 156, 123, 107, 101, 127, 7, 202})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Sector findLauncher([In] Sector obj0)
    {
      Sector sector1 = this.launchSector == null || !this.launchSector.hasBase() ? (Sector) null : this.launchSector;
      if (obj0.near().contains((object) sector1))
        return sector1;
      Sector sector2 = sector1;
      if (sector2 == null || obj0.preset == null && !obj0.near().contains((object) sector1))
      {
        sector2 = (Sector) obj0.near().find((Boolf) new PlanetDialog.__\u003C\u003EAnon9());
        if (sector2 == null && obj0.preset != null)
        {
          if (sector1 != null)
            return sector1;
          sector2 = (Sector) this.__\u003C\u003Eplanets.planet.sectors.min((Floatf) new PlanetDialog.__\u003C\u003EAnon10(obj0));
          if (!sector2.hasBase())
            sector2 = (Sector) null;
        }
      }
      return sector2;
    }

    [LineNumberTable(new byte[] {161, 129, 114, 127, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lookAt(Sector sector, float alpha)
    {
      float len = this.__\u003C\u003Eplanets.__\u003C\u003EcamPos.len();
      this.__\u003C\u003Eplanets.__\u003C\u003EcamPos.slerp(Tmp.__\u003C\u003Ev31.set(sector.__\u003C\u003Etile.v).rotate(Vec3.__\u003C\u003EY, -sector.__\u003C\u003Eplanet.getRotation()).setLength(len), alpha);
    }

    [LineNumberTable(286)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool showing() => this.newPresets.any();

    [LineNumberTable(new byte[] {161, 194, 145, 247, 160, 76, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void showStats([In] Sector obj0)
    {
      BaseDialog.__\u003Cclinit\u003E();
      BaseDialog baseDialog = new BaseDialog(obj0.name());
      baseDialog.__\u003C\u003Econt.pane((Cons) new PlanetDialog.__\u003C\u003EAnon16(obj0));
      baseDialog.addCloseButton();
      baseDialog.show();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] Sector obj0)
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {16, 127, 23, 150, 110, 104, 103, 136, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241([In] KeyCode obj0)
    {
      if (!object.ReferenceEquals((object) obj0, (object) KeyCode.__\u003C\u003Eescape) && !object.ReferenceEquals((object) obj0, (object) KeyCode.__\u003C\u003Eback) && !object.ReferenceEquals((object) obj0, (object) Core.keybinds.get((KeyBinds.KeyBind) Binding.__\u003C\u003Eplanet_map).key))
        return;
      if (this.showing() && this.newPresets.size > 1)
        this.newPresets.truncate(1);
      else if (this.selected != null)
      {
        this.selected = (Sector) null;
        this.updateSelected();
      }
      else
        Core.app.post((Runnable) new PlanetDialog.__\u003C\u003EAnon7(this));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {38, 142, 104, 172, 140, 109, 108, 167, 158, 191, 1, 103, 155, 127, 30})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242([In] float obj0, [In] float obj1)
    {
      if (Core.input.getTouches() > 1)
        return;
      if (this.showing())
        this.newPresets.clear();
      Vec3 camPos = this.__\u003C\u003Eplanets.__\u003C\u003EcamPos;
      float num1 = camPos.angle(Vec3.__\u003C\u003EY);
      float num2 = 9f;
      float num3 = 10f;
      float min = 1f;
      float num4 = 1f - Math.abs(num1 - 90f) / 90f;
      camPos.rotate(this.__\u003C\u003Eplanets.cam.__\u003C\u003Eup, obj0 / num2 * num4);
      float num5 = obj1 / num3;
      float degrees = Mathf.clamp(num1 + num5, min, 180f - min) - num1;
      camPos.rotate(Tmp.__\u003C\u003Ev31.set(this.__\u003C\u003Eplanets.cam.__\u003C\u003Eup).rotate(this.__\u003C\u003Eplanets.cam.__\u003C\u003Edirection, 90f), degrees);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {63, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00243([In] float obj0) => this.zoom = Mathf.clamp(this.zoom + obj0 / 10f, 0.5f, 2f);

    [LineNumberTable(new byte[] {161, 29, 123, 107, 143, 134, 140, 255, 70, 160, 67, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setup()
    {
      PlanetRenderer planets = this.__\u003C\u003Eplanets;
      float num1 = 1f;
      PlanetRenderer planetRenderer = planets;
      double num2 = (double) num1;
      planetRenderer.zoom = num1;
      this.zoom = (float) num2;
      this.selectAlpha = 1f;
      Vars.ui.minimapfrag.hide();
      this.clearChildren();
      this.margin(0.0f);
      Element[] elementArray = new Element[5]
      {
        (Element) new PlanetDialog.\u0032(this),
        null,
        null,
        null,
        null
      };
      Table.__\u003Cclinit\u003E();
      elementArray[1] = (Element) new Table((Cons) new PlanetDialog.__\u003C\u003EAnon13(this));
      elementArray[2] = (Element) this.__\u003C\u003Ebuttons;
      Table.__\u003Cclinit\u003E();
      elementArray[3] = (Element) new Table((Cons) new PlanetDialog.__\u003C\u003EAnon14(this));
      Table.__\u003Cclinit\u003E();
      elementArray[4] = (Element) new Table((Cons) new PlanetDialog.__\u003C\u003EAnon15());
      this.stack(elementArray).grow();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {98, 223, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024show\u00246() => Vars.ui.showCustomConfirm("@research", "@research.legacy", "@research.load", "@research.discard", (Runnable) new PlanetDialog.__\u003C\u003EAnon39(), (Runnable) new PlanetDialog.__\u003C\u003EAnon40());

    [Modifiers]
    [LineNumberTable(215)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024addTech\u00247() => Vars.ui.research.show();

    [Modifiers]
    [LineNumberTable(277)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024findLauncher\u00248([In] Sector obj0, [In] Sector obj1) => !obj1.hasBase() ? float.MaxValue : obj1.__\u003C\u003Etile.v.dst2(obj0.__\u003C\u003Etile.v);

    [Modifiers]
    [LineNumberTable(new byte[] {161, 2, 108, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024renderProjections\u00249([In] Color obj0, [In] TextureRegion obj1, [In] float obj2)
    {
      Draw.color(obj0, this.selectAlpha);
      Draw.rect(obj1, 0.0f, 0.0f, obj2, obj2 * (float) obj1.height / (float) obj1.width);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 13, 159, 20, 159, 45, 99, 191, 7, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024renderProjections\u002410([In] float obj0)
    {
      Draw.color(!this.hovered.isAttacked() ? Color.__\u003C\u003Ewhite : Pal.remove, Pal.accent, Mathf.absin(5f, 1f));
      TextureRegion region = !this.hovered.locked() || this.canSelect(this.hovered) ? (!this.hovered.isAttacked() ? this.hovered.icon() : Fonts.getLargeIcon("warning")) : Fonts.getLargeIcon("lock");
      if (region != null)
        Draw.rect(region, 0.0f, 0.0f, obj0, obj0 * (float) region.height / (float) region.width);
      Draw.reset();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 72, 107, 103, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002412([In] Table obj0)
    {
      obj0.touchable = Touchable.__\u003C\u003Edisabled;
      obj0.top();
      obj0.label((Prov) new PlanetDialog.__\u003C\u003EAnon38(this)).style((Style) Styles.outlineLabel).color(Pal.accent);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 79, 103, 124, 247, 82})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002417([In] Table obj0)
    {
      obj0.right();
      if (Vars.content.planets().count((Boolf) new PlanetDialog.__\u003C\u003EAnon34()) <= 1)
        return;
      obj0.table(Styles.black6, (Cons) new PlanetDialog.__\u003C\u003EAnon35(this));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 102, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002418([In] Table obj0) => obj0.top();

    [Modifiers]
    [LineNumberTable(new byte[] {161, 197, 237, 88, 145, 159, 57, 117, 191, 69, 112, 191, 52, 122, 127, 6, 214, 207, 182, 150, 167, 145, 127, 6, 241, 78, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showStats\u002424([In] Sector obj0, [In] Table obj1)
    {
      Cons2 cons2 = (Cons2) new PlanetDialog.__\u003C\u003EAnon29(obj0, obj1);
      obj1.defaults().padBottom(5f);
      Table table1 = obj1;
      object obj2 = (object) new StringBuilder().append(Core.bundle.get("sectors.time")).append(" [accent]").append(obj0.save.getPlayTime()).toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text1 = charSequence;
      table1.add(text1).left().row();
      if (obj0.info.waves && obj0.hasBase())
      {
        Table table2 = obj1;
        object obj3 = (object) new StringBuilder().append(Core.bundle.get("sectors.wave")).append(" [accent]").append(obj0.info.wave + obj0.info.wavesPassed).toString();
        charSequence.__\u003Cref\u003E = (__Null) obj3;
        CharSequence text2 = charSequence;
        table2.add(text2).left().row();
      }
      if (obj0.isAttacked() || !obj0.hasBase())
      {
        Table table2 = obj1;
        object obj3 = (object) new StringBuilder().append(Core.bundle.get("sectors.threat")).append(" [accent]").append(obj0.displayThreat()).toString();
        charSequence.__\u003Cref\u003E = (__Null) obj3;
        CharSequence text2 = charSequence;
        table2.add(text2).left().row();
      }
      if (obj0.save != null && obj0.info.resources.any())
      {
        Table table2 = obj1;
        object obj3 = (object) "@sectors.resources";
        charSequence.__\u003Cref\u003E = (__Null) obj3;
        CharSequence text2 = charSequence;
        table2.add(text2).left().row();
        obj1.table((Cons) new PlanetDialog.__\u003C\u003EAnon30(obj0)).padLeft(10f).left().row();
      }
      cons2.get((object) obj0.info.production, (object) "@sectors.production");
      cons2.get((object) obj0.info.export, (object) "@sectors.export");
      ItemSeq itemSeq = obj0.items();
      if (!obj0.hasBase() || itemSeq.total <= 0)
        return;
      Table table3 = obj1;
      object obj4 = (object) "@sectors.stored";
      charSequence.__\u003Cref\u003E = (__Null) obj4;
      CharSequence text3 = charSequence;
      table3.add(text3).left().row();
      obj1.table((Cons) new PlanetDialog.__\u003C\u003EAnon31(itemSeq)).left().row();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 34, 127, 33, 104, 140, 255, 2, 69, 176, 159, 21, 255, 8, 96, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024updateSelected\u002428([In] Sector obj0, [In] Table obj1)
    {
      Table table = obj1;
      object obj = (object) new StringBuilder().append("[accent]").append(obj0.name()).toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).padLeft(3f);
      if (obj0.preset == null)
      {
        obj1.add().growX();
        obj1.button((Drawable) Icon.pencilSmall, Styles.clearPartiali, (Runnable) new PlanetDialog.__\u003C\u003EAnon26(this, obj0)).size(40f).padLeft(4f);
      }
      TextureRegionDrawable textureRegionDrawable = (TextureRegionDrawable) Icon.__\u003C\u003Eicons.get((object) new StringBuilder().append(obj0.info.icon).append("Small").toString());
      obj1.button((Drawable) (textureRegionDrawable ?? Icon.noneSmall), Styles.clearPartiali, (Runnable) new PlanetDialog.__\u003C\u003EAnon27(this, obj0)).size(40f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 89, 127, 8, 103, 127, 14, 138, 127, 38, 127, 26, 103, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024updateSelected\u002429([In] Sector obj0, [In] Table obj1)
    {
      Table table1 = obj1;
      object obj2 = (object) "@complete";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text1 = charSequence;
      table1.add(text1).colspan(2).left();
      obj1.row();
      Iterator iterator = obj0.preset.node().objectives.iterator();
      while (iterator.hasNext())
      {
        Objectives.Objective objective = (Objectives.Objective) iterator.next();
        if (!objective.complete())
        {
          Table table2 = obj1;
          object obj3 = (object) new StringBuilder().append("> ").append(objective.display()).toString();
          charSequence.__\u003Cref\u003E = (__Null) obj3;
          CharSequence text2 = charSequence;
          table2.add(text2).color(Color.__\u003C\u003ElightGray).left();
          obj1.image(!objective.complete() ? (Drawable) Icon.cancel : (Drawable) Icon.ok, !objective.complete() ? Color.__\u003C\u003Escarlet : Color.__\u003C\u003ElightGray).padLeft(3f);
          obj1.row();
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 124, 127, 7, 127, 6, 101, 127, 13, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024updateSelected\u002430([In] Sector obj0, [In] Table obj1)
    {
      Table table = obj1;
      object obj = (object) "@sectors.resources";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).padRight(4f);
      Iterator iterator = obj0.info.resources.iterator();
      while (iterator.hasNext())
      {
        UnlockableContent unlockableContent = (UnlockableContent) iterator.next();
        if (unlockableContent != null)
          obj1.image(unlockableContent.icon(Cicon.__\u003C\u003Esmall)).padRight(3f).size((float) Cicon.__\u003C\u003Esmall.__\u003C\u003Esize);
      }
    }

    [Modifiers]
    [LineNumberTable(761)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024updateSelected\u002431([In] Sector obj0) => this.showStats(obj0);

    [LineNumberTable(new byte[] {162, 171, 137, 135, 136, 102, 161, 125, 161, 162, 159, 25, 223, 7, 226, 61, 97, 102, 223, 20, 127, 1, 98, 105, 132, 138, 144, 159, 32, 253, 75, 116, 142, 171, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void playSelected()
    {
      if (this.selected == null)
        return;
      Sector selected = this.selected;
      if (selected.isBeingPlayed())
      {
        this.hide();
      }
      else
      {
        if (selected.preset != null && selected.preset.locked() && !selected.hasBase())
          return;
        int num = 1;
        if (Vars.control.saves.getCurrent() != null && Vars.state.isGame())
        {
          if (!object.ReferenceEquals((object) this.mode, (object) PlanetDialog.Mode.__\u003C\u003Eselect))
          {
            Exception exception;
            try
            {
              Vars.control.saves.getCurrent().save();
              goto label_11;
            }
            catch (Exception ex)
            {
              exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            Exception exc = exception;
            Throwable.instancehelper_printStackTrace(exc);
            Vars.ui.showException(new StringBuilder().append("[accent]").append(Core.bundle.get("savefail")).toString(), exc);
          }
        }
label_11:
        if (object.ReferenceEquals((object) this.mode, (object) PlanetDialog.Mode.__\u003C\u003Elook) && !selected.hasBase())
        {
          num = 0;
          Sector launcher = this.findLauncher(selected);
          if (launcher == null)
          {
            Vars.universe.clearLoadoutInfo();
            Vars.control.playSector(selected);
          }
          else
          {
            Block bestCoreType = launcher.info.bestCoreType;
            CoreBlock coreBlock;
            this.__\u003C\u003Eloadouts.show(!(bestCoreType is CoreBlock) || !object.ReferenceEquals((object) (coreBlock = (CoreBlock) bestCoreType), (object) (CoreBlock) bestCoreType) ? (CoreBlock) Blocks.coreShard : coreBlock, launcher, (Runnable) new PlanetDialog.__\u003C\u003EAnon24(this, launcher, selected));
          }
        }
        else if (object.ReferenceEquals((object) this.mode, (object) PlanetDialog.Mode.__\u003C\u003Eselect))
          this.listener.get((object) selected);
        else
          Vars.control.playSector(selected);
        if (num == 0)
          return;
        this.hide();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 151, 107, 104, 191, 13, 127, 39, 124, 126, 111, 103, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024updateSelected\u002432([In] Table obj0)
    {
      if (this.selected == null)
        return;
      if (this.launching)
      {
        obj0.__\u003C\u003Ecolor.sub(0.0f, 0.0f, 0.0f, 0.05f * Time.delta);
      }
      else
      {
        Tmp.__\u003C\u003Ev31.set(this.selected.__\u003C\u003Etile.v).rotate(Vec3.__\u003C\u003EY, -this.__\u003C\u003Eplanets.planet.getRotation()).scl(-1f).nor();
        float num = this.__\u003C\u003Eplanets.cam.__\u003C\u003Edirection.dot(Tmp.__\u003C\u003Ev31);
        obj0.__\u003C\u003Ecolor.a = Math.max(num, 0.0f) * 2f;
        if ((double) (num * 2f) > -0.100000001490116)
          return;
        this.selected = (Sector) null;
        this.updateSelected();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 209, 117, 144, 103, 139, 111, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024playSelected\u002434([In] Sector obj0, [In] Sector obj1)
    {
      obj0.removeItems(Vars.universe.getLastLoadout().requirements());
      obj0.removeItems(Vars.universe.getLaunchResources());
      this.launching = true;
      this.zoom = 0.5f;
      Vars.ui.hudfrag.showLaunchDirect();
      Time.runTask(140f, (Runnable) new PlanetDialog.__\u003C\u003EAnon25(obj0, obj1));
    }

    [Modifiers]
    [LineNumberTable(842)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024playSelected\u002433([In] Sector obj0, [In] Sector obj1) => Vars.control.playSector(obj0, obj1);

    [Modifiers]
    [LineNumberTable(new byte[] {162, 39, 223, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024updateSelected\u002426([In] Sector obj0) => Vars.ui.showTextInput("@sectors.rename", "@name", 20, obj0.name(), (Cons) new PlanetDialog.__\u003C\u003EAnon28(this, obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {162, 49, 236, 94, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024updateSelected\u002427([In] Sector obj0) => new PlanetDialog.\u0033(this, "", obj0).show();

    [Modifiers]
    [LineNumberTable(new byte[] {162, 40, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024updateSelected\u002425([In] Sector obj0, [In] string obj1)
    {
      obj0.setName(obj1);
      this.updateSelected();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 198, 139, 136, 139, 243, 75, 109, 127, 2, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showStats\u002420(
      [In] Sector obj0,
      [In] Table obj1,
      [In] ObjectMap obj2,
      [In] string obj3)
    {
      Table table1 = new Table().left();
      float productionScale = obj0.getProductionScale();
      int[] numArray = new int[1]{ 0 };
      obj2.each((Cons2) new PlanetDialog.__\u003C\u003EAnon33(productionScale, table1, numArray));
      if (!table1.getChildren().any())
        return;
      Table table2 = obj1;
      object obj = (object) obj3;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table2.add(text).left().row();
      obj1.add((Element) table1).padLeft(10f).left().row();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 236, 127, 6, 127, 13, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showStats\u002421([In] Sector obj0, [In] Table obj1)
    {
      Iterator iterator = obj0.info.resources.iterator();
      while (iterator.hasNext())
      {
        UnlockableContent unlockableContent = (UnlockableContent) iterator.next();
        obj1.image(unlockableContent.icon(Cicon.__\u003C\u003Esmall)).padRight(3f).size((float) Cicon.__\u003C\u003Esmall.__\u003C\u003Esize);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 255, 135, 246, 74, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showStats\u002423([In] ItemSeq obj0, [In] Table obj1)
    {
      obj1.left();
      obj1.table((Cons) new PlanetDialog.__\u003C\u003EAnon32(obj0)).padLeft(10f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 3, 98, 126, 127, 2, 127, 19, 114, 135, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showStats\u002422([In] ItemSeq obj0, [In] Table obj1)
    {
      int num1 = 0;
      Iterator iterator = obj0.iterator();
      while (iterator.hasNext())
      {
        ItemStack itemStack = (ItemStack) iterator.next();
        obj1.image(itemStack.item.icon(Cicon.__\u003C\u003Esmall)).padRight(3f);
        Table table = obj1;
        object obj = (object) UI.formatAmount(Math.max(itemStack.amount, 0));
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table.add(text).color(Color.__\u003C\u003ElightGray);
        ++num1;
        int num2 = num1;
        int num3 = 4;
        if ((num3 != -1 ? num2 % num3 : 0) == 0)
          obj1.row();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 205, 120, 103, 124, 127, 63, 127, 8, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showStats\u002419(
      [In] float obj0,
      [In] Table obj1,
      [In] int[] obj2,
      [In] Item obj3,
      [In] SectorInfo.ExportStat obj4)
    {
      int number = ByteCodeHelper.f2i(obj4.mean * 60f * obj0);
      if (number <= 1)
        return;
      obj1.image(obj3.icon(Cicon.__\u003C\u003Esmall)).padRight(3f);
      Table table = obj1;
      object obj = (object) new StringBuilder().append(UI.formatAmount(number)).append(" ").append(Core.bundle.get("unit.perminute")).toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).color(Color.__\u003C\u003ElightGray).padRight(3f);
      int[] numArray1 = obj2;
      int index1 = 0;
      int[] numArray2 = numArray1;
      int[] numArray3 = numArray2;
      int num1 = index1;
      int num2 = numArray2[index1] + 1;
      int index2 = num1;
      int[] numArray4 = numArray3;
      int num3 = num2;
      numArray4[index2] = num2;
      int num4 = 3;
      if ((num4 != -1 ? num3 % num4 : 0) != 0)
        return;
      obj1.row();
    }

    [Modifiers]
    [LineNumberTable(450)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024setup\u002413([In] Planet obj0) => obj0.accessible;

    [Modifiers]
    [LineNumberTable(new byte[] {161, 82, 127, 7, 103, 127, 11, 103, 119, 118, 104, 223, 3, 127, 6, 231, 56, 233, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002416([In] Table obj0)
    {
      Table table = obj0;
      object obj = (object) "@planets";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).color(Pal.accent);
      obj0.row();
      obj0.image().growX().height(4f).pad(6f).color(Pal.accent);
      obj0.row();
      for (int index = 0; index < Vars.content.planets().size; ++index)
      {
        Planet planet = (Planet) Vars.content.planets().get(index);
        if (planet.accessible)
        {
          obj0.button(planet.localizedName, Styles.clearTogglet, (Runnable) new PlanetDialog.__\u003C\u003EAnon36(this, planet)).width(200f).height(40f).growX().update((Cons) new PlanetDialog.__\u003C\u003EAnon37(planet));
          obj0.row();
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 90, 103, 103, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002414([In] Planet obj0)
    {
      this.selected = (Sector) null;
      this.launchSector = (Sector) null;
      Vars.renderer.planets.planet = obj0;
    }

    [Modifiers]
    [LineNumberTable(463)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002415([In] Planet obj0, [In] TextButton obj1) => obj1.setChecked(object.ReferenceEquals((object) Vars.renderer.planets.planet, (object) obj0));

    [Modifiers]
    [LineNumberTable(444)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private CharSequence lambda\u0024setup\u002411()
    {
      object obj = !object.ReferenceEquals((object) this.mode, (object) PlanetDialog.Mode.__\u003C\u003Eselect) ? (object) "" : (object) "@sectors.select";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {99, 101, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024show\u00244()
    {
      LegacyIO.readResearch();
      Core.settings.remove("unlocks");
    }

    [Modifiers]
    [LineNumberTable(151)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024show\u00245() => Core.settings.remove("unlocks");

    [LineNumberTable(new byte[] {160, 112, 107, 134, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showOverview()
    {
      BaseDialog baseDialog1 = new BaseDialog("@overview");
      baseDialog1.addCloseButton();
      BaseDialog baseDialog2 = baseDialog1;
      object obj = (object) "@sectors.captured";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      baseDialog2.add(text);
    }

    [Signature("(Lmindustry/type/Sector;Larc/func/Cons<Lmindustry/type/Sector;>;)V")]
    [LineNumberTable(new byte[] {160, 119, 103, 103, 103, 167, 103, 107, 112, 107, 135, 139, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showSelect(Sector sector, Cons listener)
    {
      this.selected = (Sector) null;
      this.hovered = (Sector) null;
      this.launching = false;
      this.listener = listener;
      this.lookAt(sector);
      this.zoom = 1f;
      this.__\u003C\u003Eplanets.zoom = 1f;
      this.selectAlpha = 0.0f;
      this.launchSector = sector;
      this.mode = PlanetDialog.Mode.__\u003C\u003Eselect;
      base.show();
    }

    [LineNumberTable(new byte[] {160, 179, 112, 127, 4, 187, 127, 37, 104, 127, 35, 103, 116, 130, 99, 159, 23, 98, 159, 27, 165, 159, 45, 99, 214, 104, 123, 214, 104, 113, 182, 145, 117, 109, 127, 0, 223, 8, 112, 127, 8, 108, 127, 9, 105, 159, 53, 133, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void renderSectors(Planet planet)
    {
      if ((double) this.selectAlpha > 0.00999999977648258)
      {
        Iterator iterator = planet.sectors.iterator();
        while (iterator.hasNext())
        {
          Sector sector = (Sector) iterator.next();
          if (this.canSelect(sector) || sector.unlocked() || PlanetDialog.debugSelect)
          {
            Color color = !sector.hasBase() ? (sector.preset == null ? (!sector.hasEnemyBase() ? (Color) null : Team.__\u003C\u003Ecrux.__\u003C\u003Ecolor) : (!sector.preset.unlocked() ? Color.__\u003C\u003Egray : Tmp.__\u003C\u003Ec2.set(Team.__\u003C\u003Ederelict.__\u003C\u003Ecolor).lerp(Color.__\u003C\u003Ewhite, Mathf.absin(Time.time, 10f, 1f)))) : Tmp.__\u003C\u003Ec2.set(Team.__\u003C\u003Esharded.__\u003C\u003Ecolor).lerp(Team.__\u003C\u003Ecrux.__\u003C\u003Ecolor, !sector.hasEnemyBase() ? 0.0f : 0.5f);
            if (color != null)
              this.__\u003C\u003Eplanets.drawSelection(sector, Tmp.__\u003C\u003Ec1.set(color).mul(0.8f).a(this.selectAlpha), 0.026f, -1f / 1000f);
          }
          else
            this.__\u003C\u003Eplanets.fill(sector, Tmp.__\u003C\u003Ec1.set(PlanetRenderer.__\u003C\u003EshadowColor).mul(1f, 1f, 1f, this.selectAlpha), -1f / 1000f);
        }
      }
      Sector sector1 = Vars.state.getSector() == null || !Vars.state.getSector().isBeingPlayed() || !object.ReferenceEquals((object) Vars.state.getSector().__\u003C\u003Eplanet, (object) this.__\u003C\u003Eplanets.planet) ? (Sector) null : Vars.state.getSector();
      if (sector1 != null)
        this.__\u003C\u003Eplanets.fill(sector1, PlanetRenderer.__\u003C\u003EhoverColor, -1f / 1000f);
      if (this.hovered != null)
      {
        this.__\u003C\u003Eplanets.fill(this.hovered, PlanetRenderer.__\u003C\u003EhoverColor, -1f / 1000f);
        this.__\u003C\u003Eplanets.drawBorders(this.hovered, PlanetRenderer.__\u003C\u003EborderColor);
      }
      if (this.selected != null)
      {
        this.__\u003C\u003Eplanets.drawSelection(this.selected);
        this.__\u003C\u003Eplanets.drawBorders(this.selected, PlanetRenderer.__\u003C\u003EborderColor);
      }
      this.__\u003C\u003Eplanets.__\u003C\u003Ebatch.flush(4);
      if (this.hovered != null && !this.hovered.hasBase())
      {
        Sector launcher = this.findLauncher(this.hovered);
        if (launcher != null && !object.ReferenceEquals((object) this.hovered, (object) launcher) && this.canSelect(this.hovered))
          this.__\u003C\u003Eplanets.drawArc(planet, launcher.__\u003C\u003Etile.v, this.hovered.__\u003C\u003Etile.v);
      }
      if ((double) this.selectAlpha <= 1.0 / 1000.0)
        return;
      Iterator iterator1 = planet.sectors.iterator();
label_18:
      while (iterator1.hasNext())
      {
        Sector sector2 = (Sector) iterator1.next();
        if (sector2.hasBase())
        {
          Iterator iterator2 = sector2.near().iterator();
          while (true)
          {
            Sector sector3;
            do
            {
              if (iterator2.hasNext())
                sector3 = (Sector) iterator2.next();
              else
                goto label_18;
            }
            while (!sector3.hasEnemyBase());
            this.__\u003C\u003Eplanets.drawArc(planet, sector3.__\u003C\u003Etile.v, sector2.__\u003C\u003Etile.v, Team.__\u003C\u003Ecrux.__\u003C\u003Ecolor.write(Tmp.__\u003C\u003Ec2).a(this.selectAlpha), Color.__\u003C\u003Eclear, 0.24f, 110f, 25);
          }
        }
      }
    }

    [LineNumberTable(new byte[] {160, 243, 134, 127, 4, 113, 135, 119, 127, 1, 108, 127, 43, 99, 159, 9, 100, 252, 70, 133, 133, 104, 253, 77, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void renderProjections(Planet planet)
    {
      float num = 12f;
      Iterator iterator = planet.sectors.iterator();
      while (iterator.hasNext())
      {
        Sector sector = (Sector) iterator.next();
        if (!object.ReferenceEquals((object) sector, (object) this.hovered))
        {
          TextureRegion textureRegion1 = sector.icon();
          TextureRegion textureRegion2 = !sector.isAttacked() ? (sector.hasBase() || sector.preset == null || (!sector.preset.unlocked() || textureRegion1 != null) ? (sector.preset == null || !sector.preset.locked() || (sector.preset.node() == null || sector.preset.node().parent.content.locked()) ? textureRegion1 : Fonts.getLargeIcon("lock")) : Fonts.getLargeIcon("terrain")) : Fonts.getLargeIcon("warning");
          Color color = sector.preset == null || sector.hasBase() ? Team.__\u003C\u003Esharded.__\u003C\u003Ecolor : Team.__\u003C\u003Ederelict.__\u003C\u003Ecolor;
          if (textureRegion2 != null)
            this.__\u003C\u003Eplanets.drawPlane(sector, (Runnable) new PlanetDialog.__\u003C\u003EAnon11(this, color, textureRegion2, num));
        }
      }
      Draw.reset();
      if (this.hovered != null)
        this.__\u003C\u003Eplanets.drawPlane(this.hovered, (Runnable) new PlanetDialog.__\u003C\u003EAnon12(this, num));
      Draw.reset();
    }

    [LineNumberTable(new byte[] {161, 110, 147, 99, 127, 0, 176, 134, 99, 139, 107, 127, 34, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      int num = (double) this.__\u003C\u003Ecolor.a < 0.990000009536743 ? 1 : 0;
      if (num != 0)
      {
        this.__\u003C\u003Ebuffer.resize(Core.graphics.getWidth(), Core.graphics.getHeight());
        this.__\u003C\u003Ebuffer.begin(Color.__\u003C\u003Eclear);
      }
      base.draw();
      if (num == 0)
        return;
      this.__\u003C\u003Ebuffer.end();
      Draw.color(this.__\u003C\u003Ecolor);
      Draw.rect(Draw.wrap((Texture) this.__\u003C\u003Ebuffer.getTexture()), this.width / 2f, this.height / 2f, this.width, -this.height);
      Draw.color();
    }

    [LineNumberTable(new byte[] {161, 135, 136, 117, 108, 107, 144, 127, 71, 159, 17, 113, 107, 108, 110, 159, 23, 191, 7, 107, 98, 172, 112, 177, 107, 145, 147, 108, 139, 127, 4, 103, 191, 15, 109, 108, 103, 203, 114, 159, 14, 178, 127, 8, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void act(float delta)
    {
      base.act(delta);
      if (this.hovered != null && !Vars.mobile)
      {
        this.addChild((Element) this.hoverLabel);
        this.hoverLabel.toFront();
        this.hoverLabel.touchable = Touchable.__\u003C\u003Edisabled;
        Vec3 vec3 = this.__\u003C\u003Eplanets.cam.project(Tmp.__\u003C\u003Ev31.set(this.hovered.__\u003C\u003Etile.v).setLength(1.17f).rotate(Vec3.__\u003C\u003EY, -this.__\u003C\u003Eplanets.planet.getRotation()).add(this.__\u003C\u003Eplanets.planet.position));
        this.hoverLabel.setPosition(vec3.x - Core.scene.marginLeft, vec3.y - Core.scene.marginBottom, 1);
        this.hoverLabel.getText().setLength(0);
        if (this.hovered != null)
        {
          StringBuilder text = this.hoverLabel.getText();
          if (!this.canSelect(this.hovered))
            text.append("[gray]").append('\uE88D').append(" ").append(Core.bundle.get("locked"));
          else
            text.append("[accent][[ [white]").append(this.hovered.name()).append("[accent] ]");
        }
        this.hoverLabel.invalidateHierarchy();
      }
      else
        this.hoverLabel.remove();
      if (this.launching && this.selected != null)
        this.lookAt(this.selected, 0.1f);
      if (this.showing())
      {
        Sector sector = (Sector) this.newPresets.peek();
        this.presetShow += Time.delta;
        this.lookAt(sector, 0.11f);
        this.zoom = 0.75f;
        if ((double) this.presetShow >= 20.0 && !this.showed && this.newPresets.size > 1)
        {
          this.showed = true;
          Vars.ui.announce(new StringBuilder().append("\uE876 [accent]").append(sector.name()).toString(), 2f);
        }
        if ((double) this.presetShow > (double) PlanetDialog.sectorShowDuration)
        {
          this.newPresets.pop();
          this.showed = false;
          this.presetShow = 0.0f;
        }
      }
      if (this.__\u003C\u003Eplanets.planet.isLandable())
      {
        this.hovered = this.__\u003C\u003Eplanets.planet.getSector(this.__\u003C\u003Eplanets.cam.getMouseRay(), 1.17f);
      }
      else
      {
        PlanetDialog planetDialog = this;
        this.selected = (Sector) null;
        this.hovered = (Sector) null;
      }
      this.__\u003C\u003Eplanets.zoom = Mathf.lerpDelta(this.__\u003C\u003Eplanets.zoom, this.zoom, 0.4f);
      this.selectAlpha = Mathf.lerpDelta(this.selectAlpha, (float) Mathf.num((double) this.__\u003C\u003Eplanets.zoom < 1.89999997615814), 0.1f);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static PlanetDialog()
    {
      BaseDialog.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("mindustry.ui.dialogs.PlanetDialog"))
        return;
      PlanetDialog.debugSelect = false;
      PlanetDialog.sectorShowDuration = 144f;
    }

    [Modifiers]
    public FrameBuffer buffer
    {
      [HideFromJava] get => this.__\u003C\u003Ebuffer;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ebuffer = value;
    }

    [Modifiers]
    public PlanetRenderer planets
    {
      [HideFromJava] get => this.__\u003C\u003Eplanets;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eplanets = value;
    }

    [Modifiers]
    public LaunchLoadoutDialog loadouts
    {
      [HideFromJava] get => this.__\u003C\u003Eloadouts;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eloadouts = value;
    }

    [EnclosingMethod(null, "<init>", "()V")]
    [SpecialName]
    internal new class \u0031 : ElementGestureListener
    {
      internal float lastZoom;
      [Modifiers]
      internal PlanetDialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {66, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] PlanetDialog obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        PlanetDialog.\u0031 obj = this;
        this.lastZoom = -1f;
      }

      [LineNumberTable(new byte[] {71, 109, 177, 127, 10})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void zoom([In] InputEvent obj0, [In] float obj1, [In] float obj2)
      {
        if ((double) this.lastZoom < 0.0)
          this.lastZoom = this.this\u00240.zoom;
        this.this\u00240.zoom = Mathf.clamp(obj1 / obj2 * this.lastZoom, 0.5f, 2f);
      }

      [LineNumberTable(new byte[] {80, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchUp(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        this.lastZoom = this.this\u00240.zoom;
      }

      [HideFromJava]
      static \u0031() => ElementGestureListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "setup", "()V")]
    [SpecialName]
    internal new class \u0032 : Element
    {
      [Modifiers]
      internal PlanetDialog this\u00240;

      [LineNumberTable(new byte[] {161, 38, 175, 237, 82})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] PlanetDialog obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        PlanetDialog.\u0032 obj = this;
        this.addListener((EventListener) new PlanetDialog.\u0032.\u0031(this));
      }

      [LineNumberTable(new byte[] {161, 63, 123, 118, 119, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        this.this\u00240.__\u003C\u003Eplanets.orbitAlpha = this.this\u00240.selectAlpha;
        this.this\u00240.__\u003C\u003Eplanets.render((PlanetRenderer.PlanetInterfaceRenderer) this.this\u00240);
        if (!object.ReferenceEquals((object) Core.scene.getDialog(), (object) this.this\u00240))
          return;
        Core.scene.setScrollFocus((Element) this.this\u00240);
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal new class \u0031 : ElementGestureListener
      {
        [Modifiers]
        internal PlanetDialog.\u0032 this\u00241;

        [SpecialName]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public new static void __\u003Cclinit\u003E()
        {
        }

        [LineNumberTable(411)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] PlanetDialog.\u0032 obj0)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
        }

        [LineNumberTable(new byte[] {161, 44, 147, 127, 31, 176, 127, 28, 191, 1, 114, 144})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void tap([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3, [In] KeyCode obj4)
        {
          if (this.this\u00241.this\u00240.showing())
            return;
          if (this.this\u00241.this\u00240.hovered != null && object.ReferenceEquals((object) this.this\u00241.this\u00240.selected, (object) this.this\u00241.this\u00240.hovered) && obj3 == 2)
            this.this\u00241.this\u00240.playSelected();
          if (this.this\u00241.this\u00240.hovered != null && (this.this\u00241.this\u00240.canSelect(this.this\u00241.this\u00240.hovered) || PlanetDialog.debugSelect))
            this.this\u00241.this\u00240.selected = this.this\u00241.this\u00240.hovered;
          if (this.this\u00241.this\u00240.selected == null)
            return;
          this.this\u00241.this\u00240.updateSelected();
        }

        [HideFromJava]
        static \u0031() => ElementGestureListener.__\u003Cclinit\u003E();
      }
    }

    [EnclosingMethod(null, "updateSelected", "()V")]
    [SpecialName]
    internal new class \u0033 : Dialog
    {
      [Modifiers]
      internal Sector val\u0024sector;
      [Modifiers]
      internal PlanetDialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 49, 119, 102, 103, 253, 90, 127, 17})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] PlanetDialog obj0, [In] string obj1, [In] Sector obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024sector = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        PlanetDialog.\u0033 obj = this;
        this.closeOnBack();
        this.setFillParent(true);
        this.__\u003C\u003Econt.pane((Cons) new PlanetDialog.\u0033.__\u003C\u003EAnon0(this, this.val\u0024sector));
        this.__\u003C\u003Ebuttons.button("@back", (Drawable) Icon.left, (Runnable) new PlanetDialog.\u0033.__\u003C\u003EAnon1(this)).size(210f, 64f);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {162, 53, 108, 145, 255, 14, 69, 134, 98, 127, 8, 127, 33, 141, 255, 27, 69, 139, 121, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00242([In] Sector obj0, [In] Table obj1)
      {
        obj1.marginRight(19f);
        obj1.defaults().size(48f);
        obj1.button((Drawable) Icon.none, Styles.clearTogglei, (Runnable) new PlanetDialog.\u0033.__\u003C\u003EAnon2(this, obj0)).@checked(obj0.info.icon == null);
        int num1 = 1;
        ObjectMap.Entries entries = Icon.__\u003C\u003Eicons.entries().iterator();
        while (((Iterator) entries).hasNext())
        {
          ObjectMap.Entry entry = (ObjectMap.Entry) ((Iterator) entries).next();
          if (!String.instancehelper_endsWith((string) entry.key, "Small"))
          {
            string key1 = (string) entry.key;
            object obj = (object) "none";
            CharSequence charSequence1;
            charSequence1.__\u003Cref\u003E = (__Null) obj;
            CharSequence charSequence2 = charSequence1;
            if (!String.instancehelper_contains(key1, charSequence2))
            {
              string key2 = (string) entry.key;
              obj1.button((Drawable) entry.value, Styles.cleari, (Runnable) new PlanetDialog.\u0033.__\u003C\u003EAnon3(this, obj0, key2)).@checked(String.instancehelper_equals((string) entry.key, (object) obj0.info.icon));
              ++num1;
              int num2 = num1;
              int num3 = 8;
              if ((num3 != -1 ? num2 % num3 : 0) == 0)
                obj1.row();
            }
          }
        }
      }

      [Modifiers]
      [LineNumberTable(new byte[] {162, 57, 108, 102, 102, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00240([In] Sector obj0)
      {
        obj0.info.icon = (string) null;
        obj0.saveInfo();
        this.hide();
        this.this\u00240.updateSelected();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {162, 69, 108, 102, 102, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00241([In] Sector obj0, [In] string obj1)
      {
        obj0.info.icon = obj1;
        obj0.saveInfo();
        this.hide();
        this.this\u00240.updateSelected();
      }

      [HideFromJava]
      static \u0033() => Dialog.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly PlanetDialog.\u0033 arg\u00241;
        private readonly Sector arg\u00242;

        internal __\u003C\u003EAnon0([In] PlanetDialog.\u0033 obj0, [In] Sector obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00242(this.arg\u00242, (Table) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Runnable
      {
        private readonly PlanetDialog.\u0033 arg\u00241;

        internal __\u003C\u003EAnon1([In] PlanetDialog.\u0033 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.hide();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Runnable
      {
        private readonly PlanetDialog.\u0033 arg\u00241;
        private readonly Sector arg\u00242;

        internal __\u003C\u003EAnon2([In] PlanetDialog.\u0033 obj0, [In] Sector obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024new\u00240(this.arg\u00242);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Runnable
      {
        private readonly PlanetDialog.\u0033 arg\u00241;
        private readonly Sector arg\u00242;
        private readonly string arg\u00243;

        internal __\u003C\u003EAnon3([In] PlanetDialog.\u0033 obj0, [In] Sector obj1, [In] string obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024new\u00241(this.arg\u00242, this.arg\u00243);
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/ui/dialogs/PlanetDialog$Mode;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Mode : Enum
    {
      [Modifiers]
      internal static PlanetDialog.Mode __\u003C\u003Elook;
      [Modifiers]
      internal static PlanetDialog.Mode __\u003C\u003Eselect;
      [Modifiers]
      private static PlanetDialog.Mode[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(854)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Mode([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(854)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static PlanetDialog.Mode[] values() => (PlanetDialog.Mode[]) PlanetDialog.Mode.\u0024VALUES.Clone();

      [LineNumberTable(854)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static PlanetDialog.Mode valueOf(string name) => (PlanetDialog.Mode) Enum.valueOf((Class) ClassLiteral<PlanetDialog.Mode>.Value, name);

      [LineNumberTable(new byte[] {158, 184, 77, 144, 240, 60})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Mode()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.ui.dialogs.PlanetDialog$Mode"))
          return;
        PlanetDialog.Mode.__\u003C\u003Elook = new PlanetDialog.Mode(nameof (look), 0);
        PlanetDialog.Mode.__\u003C\u003Eselect = new PlanetDialog.Mode(nameof (select), 1);
        PlanetDialog.Mode.\u0024VALUES = new PlanetDialog.Mode[2]
        {
          PlanetDialog.Mode.__\u003C\u003Elook,
          PlanetDialog.Mode.__\u003C\u003Eselect
        };
      }

      [Modifiers]
      public static PlanetDialog.Mode look
      {
        [HideFromJava] get => PlanetDialog.Mode.__\u003C\u003Elook;
      }

      [Modifiers]
      public static PlanetDialog.Mode select
      {
        [HideFromJava] get => PlanetDialog.Mode.__\u003C\u003Eselect;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        look,
        select,
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => PlanetDialog.lambda\u0024new\u00240((Sector) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly PlanetDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] PlanetDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00241((KeyCode) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly PlanetDialog arg\u00241;

      internal __\u003C\u003EAnon2([In] PlanetDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.rebuildButtons();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Floatc2
    {
      private readonly PlanetDialog arg\u00241;

      internal __\u003C\u003EAnon3([In] PlanetDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => this.arg\u00241.lambda\u0024new\u00242(obj0, obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Floatc
    {
      private readonly PlanetDialog arg\u00241;

      internal __\u003C\u003EAnon4([In] PlanetDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024new\u00243(obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly PlanetDialog arg\u00241;

      internal __\u003C\u003EAnon5([In] PlanetDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Runnable
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public void run() => PlanetDialog.lambda\u0024show\u00246();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly PlanetDialog arg\u00241;

      internal __\u003C\u003EAnon7([In] PlanetDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public void run() => PlanetDialog.lambda\u0024addTech\u00247();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Boolf
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public bool get([In] object obj0) => (((Sector) obj0).hasBase() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Floatf
    {
      private readonly Sector arg\u00241;

      internal __\u003C\u003EAnon10([In] Sector obj0) => this.arg\u00241 = obj0;

      public float get([In] object obj0) => PlanetDialog.lambda\u0024findLauncher\u00248(this.arg\u00241, (Sector) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly PlanetDialog arg\u00241;
      private readonly Color arg\u00242;
      private readonly TextureRegion arg\u00243;
      private readonly float arg\u00244;

      internal __\u003C\u003EAnon11([In] PlanetDialog obj0, [In] Color obj1, [In] TextureRegion obj2, [In] float obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void run() => this.arg\u00241.lambda\u0024renderProjections\u00249(this.arg\u00242, this.arg\u00243, this.arg\u00244);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Runnable
    {
      private readonly PlanetDialog arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon12([In] PlanetDialog obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024renderProjections\u002410(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Cons
    {
      private readonly PlanetDialog arg\u00241;

      internal __\u003C\u003EAnon13([In] PlanetDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002412((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Cons
    {
      private readonly PlanetDialog arg\u00241;

      internal __\u003C\u003EAnon14([In] PlanetDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002417((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Cons
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public void get([In] object obj0) => PlanetDialog.lambda\u0024setup\u002418((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Cons
    {
      private readonly Sector arg\u00241;

      internal __\u003C\u003EAnon16([In] Sector obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => PlanetDialog.lambda\u0024showStats\u002424(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Cons
    {
      private readonly PlanetDialog arg\u00241;
      private readonly Sector arg\u00242;

      internal __\u003C\u003EAnon17([In] PlanetDialog obj0, [In] Sector obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024updateSelected\u002428(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Cons
    {
      private readonly Sector arg\u00241;

      internal __\u003C\u003EAnon18([In] Sector obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => PlanetDialog.lambda\u0024updateSelected\u002429(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Boolf
    {
      internal __\u003C\u003EAnon19()
      {
      }

      public bool get([In] object obj0) => (((Sector) obj0).hasEnemyBase() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Cons
    {
      private readonly Sector arg\u00241;

      internal __\u003C\u003EAnon20([In] Sector obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => PlanetDialog.lambda\u0024updateSelected\u002430(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Runnable
    {
      private readonly PlanetDialog arg\u00241;
      private readonly Sector arg\u00242;

      internal __\u003C\u003EAnon21([In] PlanetDialog obj0, [In] Sector obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024updateSelected\u002431(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Runnable
    {
      private readonly PlanetDialog arg\u00241;

      internal __\u003C\u003EAnon22([In] PlanetDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.playSelected();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Runnable
    {
      private readonly PlanetDialog arg\u00241;
      private readonly Table arg\u00242;

      internal __\u003C\u003EAnon23([In] PlanetDialog obj0, [In] Table obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024updateSelected\u002432(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Runnable
    {
      private readonly PlanetDialog arg\u00241;
      private readonly Sector arg\u00242;
      private readonly Sector arg\u00243;

      internal __\u003C\u003EAnon24([In] PlanetDialog obj0, [In] Sector obj1, [In] Sector obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024playSelected\u002434(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Runnable
    {
      private readonly Sector arg\u00241;
      private readonly Sector arg\u00242;

      internal __\u003C\u003EAnon25([In] Sector obj0, [In] Sector obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => PlanetDialog.lambda\u0024playSelected\u002433(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Runnable
    {
      private readonly PlanetDialog arg\u00241;
      private readonly Sector arg\u00242;

      internal __\u003C\u003EAnon26([In] PlanetDialog obj0, [In] Sector obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024updateSelected\u002426(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Runnable
    {
      private readonly PlanetDialog arg\u00241;
      private readonly Sector arg\u00242;

      internal __\u003C\u003EAnon27([In] PlanetDialog obj0, [In] Sector obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024updateSelected\u002427(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Cons
    {
      private readonly PlanetDialog arg\u00241;
      private readonly Sector arg\u00242;

      internal __\u003C\u003EAnon28([In] PlanetDialog obj0, [In] Sector obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024updateSelected\u002425(this.arg\u00242, (string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Cons2
    {
      private readonly Sector arg\u00241;
      private readonly Table arg\u00242;

      internal __\u003C\u003EAnon29([In] Sector obj0, [In] Table obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0, [In] object obj1) => PlanetDialog.lambda\u0024showStats\u002420(this.arg\u00241, this.arg\u00242, (ObjectMap) obj0, (string) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Cons
    {
      private readonly Sector arg\u00241;

      internal __\u003C\u003EAnon30([In] Sector obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => PlanetDialog.lambda\u0024showStats\u002421(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Cons
    {
      private readonly ItemSeq arg\u00241;

      internal __\u003C\u003EAnon31([In] ItemSeq obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => PlanetDialog.lambda\u0024showStats\u002423(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Cons
    {
      private readonly ItemSeq arg\u00241;

      internal __\u003C\u003EAnon32([In] ItemSeq obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => PlanetDialog.lambda\u0024showStats\u002422(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Cons2
    {
      private readonly float arg\u00241;
      private readonly Table arg\u00242;
      private readonly int[] arg\u00243;

      internal __\u003C\u003EAnon33([In] float obj0, [In] Table obj1, [In] int[] obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0, [In] object obj1) => PlanetDialog.lambda\u0024showStats\u002419(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Item) obj0, (SectorInfo.ExportStat) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Boolf
    {
      internal __\u003C\u003EAnon34()
      {
      }

      public bool get([In] object obj0) => (PlanetDialog.lambda\u0024setup\u002413((Planet) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Cons
    {
      private readonly PlanetDialog arg\u00241;

      internal __\u003C\u003EAnon35([In] PlanetDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002416((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : Runnable
    {
      private readonly PlanetDialog arg\u00241;
      private readonly Planet arg\u00242;

      internal __\u003C\u003EAnon36([In] PlanetDialog obj0, [In] Planet obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u002414(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon37 : Cons
    {
      private readonly Planet arg\u00241;

      internal __\u003C\u003EAnon37([In] Planet obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => PlanetDialog.lambda\u0024setup\u002415(this.arg\u00241, (TextButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon38 : Prov
    {
      private readonly PlanetDialog arg\u00241;

      internal __\u003C\u003EAnon38([In] PlanetDialog obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024setup\u002411().__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon39 : Runnable
    {
      internal __\u003C\u003EAnon39()
      {
      }

      public void run() => PlanetDialog.lambda\u0024show\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon40 : Runnable
    {
      internal __\u003C\u003EAnon40()
      {
      }

      public void run() => PlanetDialog.lambda\u0024show\u00245();
    }
  }
}
