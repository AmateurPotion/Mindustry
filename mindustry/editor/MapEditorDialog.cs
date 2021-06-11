// Decompiled with JetBrains decompiler
// Type: mindustry.editor.MapEditorDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.files;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.input;
using arc.math;
using arc.math.geom;
using arc.scene;
using arc.scene.@event;
using arc.scene.actions;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.function;
using mindustry.content;
using mindustry.core;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.io;
using mindustry.maps;
using mindustry.type;
using mindustry.ui;
using mindustry.ui.dialogs;
using mindustry.world;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.storage;
using mindustry.world.meta;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.editor
{
  [Implements(new string[] {"arc.util.Disposable"})]
  public class MapEditorDialog : Dialog, Disposable
  {
    internal MapEditor __\u003C\u003Eeditor;
    private MapView view;
    private MapInfoDialog infoDialog;
    private MapLoadDialog loadDialog;
    private MapResizeDialog resizeDialog;
    private MapGenerateDialog generateDialog;
    private ScrollPane pane;
    private BaseDialog menu;
    private Table blockSelection;
    private Rules lastSavedRules;
    private bool saved;
    private bool shownWithMap;
    [Signature("Larc/struct/Seq<Lmindustry/world/Block;>;")]
    private Seq blocksOut;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {2, 237, 59, 103, 103, 235, 69, 140, 107, 113, 118, 151, 112, 139, 134, 253, 126, 145, 103, 255, 11, 92, 255, 16, 69, 177, 159, 56, 145, 191, 26, 134, 255, 2, 72, 251, 73, 135, 102, 140, 242, 74, 241, 81, 241, 70, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MapEditorDialog()
      : base("")
    {
      MapEditorDialog mapEditorDialog = this;
      this.saved = false;
      this.shownWithMap = false;
      this.blocksOut = new Seq();
      this.background(Styles.black);
      this.__\u003C\u003Eeditor = new MapEditor();
      this.view = new MapView(this.__\u003C\u003Eeditor);
      MapInfoDialog.__\u003Cclinit\u003E();
      this.infoDialog = new MapInfoDialog(this.__\u003C\u003Eeditor);
      MapGenerateDialog.__\u003Cclinit\u003E();
      this.generateDialog = new MapGenerateDialog(this.__\u003C\u003Eeditor, true);
      this.menu = new BaseDialog("@menu");
      this.menu.addCloseButton();
      float num = 180f;
      this.menu.__\u003C\u003Econt.table((Cons) new MapEditorDialog.__\u003C\u003EAnon0(this, num));
      this.menu.__\u003C\u003Econt.row();
      if (Vars.steam)
      {
        this.menu.__\u003C\u003Econt.button("@editor.publish.workshop", (Drawable) Icon.link, (Runnable) new MapEditorDialog.__\u003C\u003EAnon1(this)).padTop(-3f).size(num * 2f + 10f, 60f).update((Cons) new MapEditorDialog.__\u003C\u003EAnon2(this));
        this.menu.__\u003C\u003Econt.row();
      }
      this.menu.__\u003C\u003Econt.button("@editor.ingame", (Drawable) Icon.right, (Runnable) new MapEditorDialog.__\u003C\u003EAnon3(this)).padTop(Vars.steam ? 1f : -3f).size(num * 2f + 10f, 60f);
      this.menu.__\u003C\u003Econt.row();
      this.menu.__\u003C\u003Econt.button("@quit", (Drawable) Icon.exit, (Runnable) new MapEditorDialog.__\u003C\u003EAnon4(this)).size(num * 2f + 10f, 60f);
      MapResizeDialog.__\u003Cclinit\u003E();
      this.resizeDialog = new MapResizeDialog(this.__\u003C\u003Eeditor, (Intc2) new MapEditorDialog.__\u003C\u003EAnon5(this));
      MapLoadDialog.__\u003Cclinit\u003E();
      this.loadDialog = new MapLoadDialog((Cons) new MapEditorDialog.__\u003C\u003EAnon6(this));
      this.setFillParent(true);
      this.clearChildren();
      this.margin(0.0f);
      this.update((Runnable) new MapEditorDialog.__\u003C\u003EAnon7(this));
      this.shown((Runnable) new MapEditorDialog.__\u003C\u003EAnon8(this));
      this.hidden((Runnable) new MapEditorDialog.__\u003C\u003EAnon9(this));
      this.shown((Runnable) new MapEditorDialog.__\u003C\u003EAnon10(this));
    }

    [LineNumberTable(357)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Dialog show() => this.show(Core.scene, (arc.scene.Action) Actions.sequence((arc.scene.Action) Actions.alpha(1f)));

    [LineNumberTable(new byte[] {160, 195, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void handleSaveBuiltin(Map map) => Vars.ui.showErrorMessage("@editor.save.overwrite");

    [LineNumberTable(new byte[] {160, 163, 112, 112, 127, 6, 127, 6, 118, 150, 138, 130, 104, 108, 150, 127, 1, 107, 137, 118, 207, 107, 103, 112})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Map save()
    {
      int num = Vars.state.rules.editor ? 1 : 0;
      Vars.state.rules.editor = false;
      string str = String.instancehelper_trim((string) this.__\u003C\u003Eeditor.tags.get((object) "name", (object) ""));
      this.__\u003C\u003Eeditor.tags.put((object) "rules", (object) JsonIO.write((object) Vars.state.rules));
      this.__\u003C\u003Eeditor.tags.remove((object) "width");
      this.__\u003C\u003Eeditor.tags.remove((object) "height");
      Vars.player.clearUnit();
      Map map1 = (Map) null;
      if (String.instancehelper_isEmpty(str))
      {
        this.infoDialog.show();
        Core.app.post((Runnable) new MapEditorDialog.__\u003C\u003EAnon12());
      }
      else
      {
        Map map2 = (Map) Vars.maps.all().find((Boolf) new MapEditorDialog.__\u003C\u003EAnon13(str));
        if (map2 != null && !map2.__\u003C\u003Ecustom)
        {
          this.handleSaveBuiltin(map2);
        }
        else
        {
          map1 = Vars.maps.saveMap((ObjectMap) this.__\u003C\u003Eeditor.tags);
          Vars.ui.showInfoFade("@editor.saved");
        }
      }
      this.menu.hide();
      this.saved = true;
      Vars.state.rules.editor = num != 0;
      return map1;
    }

    [LineNumberTable(new byte[] {162, 74, 139, 108, 118, 246, 74, 130, 127, 4, 140, 159, 9, 127, 18, 133, 118, 114, 116, 108, 118, 159, 4, 143, 114, 140, 133, 99, 159, 34})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void rebuildBlockSelection([In] string obj0)
    {
      this.blockSelection.clear();
      this.blocksOut.clear();
      this.blocksOut.addAll(Vars.content.blocks());
      this.blocksOut.sort((Comparator) new MapEditorDialog.__\u003C\u003EAnon22());
      int num1 = 0;
      Iterator iterator = this.blocksOut.iterator();
      CharSequence charSequence1;
      while (iterator.hasNext())
      {
        Block block = (Block) iterator.next();
        TextureRegion region = block.icon(Cicon.__\u003C\u003Emedium);
        if (Core.atlas.isFound(region) && block.inEditor && !object.ReferenceEquals((object) block.buildVisibility, (object) BuildVisibility.__\u003C\u003EdebugOnly))
        {
          if (!String.instancehelper_isEmpty(obj0))
          {
            string lowerCase1 = String.instancehelper_toLowerCase(block.localizedName);
            object lowerCase2 = (object) String.instancehelper_toLowerCase(obj0);
            charSequence1.__\u003Cref\u003E = (__Null) lowerCase2;
            CharSequence charSequence2 = charSequence1;
            if (!String.instancehelper_contains(lowerCase1, charSequence2))
              continue;
          }
          ImageButton.__\u003Cclinit\u003E();
          ImageButton imageButton = new ImageButton((Drawable) Tex.whiteui, Styles.clearTogglei);
          imageButton.getStyle().imageUp = (Drawable) new TextureRegionDrawable(region);
          imageButton.clicked((Runnable) new MapEditorDialog.__\u003C\u003EAnon23(this, block));
          imageButton.resizeImage(32f);
          imageButton.update((Runnable) new MapEditorDialog.__\u003C\u003EAnon24(this, imageButton, block));
          this.blockSelection.add((Element) imageButton).size(50f).tooltip(block.localizedName);
          if (num1 == 0)
            this.__\u003C\u003Eeditor.drawBlock = block;
          ++num1;
          int num2 = num1;
          int num3 = 4;
          if ((num3 != -1 ? num2 % num3 : 0) == 0)
            this.blockSelection.row();
        }
      }
      if (num1 != 0)
        return;
      Table blockSelection = this.blockSelection;
      object obj = (object) "@none";
      charSequence1.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence1;
      blockSelection.add(text).color(Color.__\u003C\u003ElightGray).padLeft(80f).padTop(10f);
    }

    [LineNumberTable(new byte[] {160, 248, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void hide() => this.hide((arc.scene.Action) Actions.sequence((arc.scene.Action) Actions.alpha(0.0f)));

    [LineNumberTable(new byte[] {161, 229, 140, 118, 127, 1, 17, 232, 70, 116, 115, 109, 226, 61, 230, 72, 113, 109, 204, 113, 190, 113, 222, 111, 113, 203, 180, 115, 115, 111, 124, 108, 178, 127, 7, 108, 242, 55, 41, 233, 79, 171, 113, 171, 113, 167, 113, 188})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void doInput()
    {
      if (Core.input.ctrl())
      {
        for (int index = 0; index < this.view.getTool().__\u003C\u003EaltModes.Length; ++index)
        {
          if (index + 1 < KeyCode.__\u003C\u003Enumbers.Length && Core.input.keyTap(KeyCode.__\u003C\u003Enumbers[index + 1]))
            this.view.getTool().mode = index;
        }
      }
      else
      {
        EditorTool[] all = EditorTool.__\u003C\u003Eall;
        int length = all.Length;
        for (int index = 0; index < length; ++index)
        {
          EditorTool tool = all[index];
          if (Core.input.keyTap(tool.key))
          {
            this.view.setTool(tool);
            break;
          }
        }
      }
      if (Core.input.keyTap(KeyCode.__\u003C\u003Eescape) && !this.menu.isShown())
        this.menu.show();
      if (Core.input.keyTap(KeyCode.__\u003C\u003Er))
        this.__\u003C\u003Eeditor.rotation = Mathf.mod(this.__\u003C\u003Eeditor.rotation + 1, 4);
      if (Core.input.keyTap(KeyCode.__\u003C\u003Ee))
        this.__\u003C\u003Eeditor.rotation = Mathf.mod(this.__\u003C\u003Eeditor.rotation - 1, 4);
      if (!Core.input.ctrl())
        return;
      if (Core.input.keyTap(KeyCode.__\u003C\u003Ez))
        this.__\u003C\u003Eeditor.undo();
      if (Core.input.keyTap(KeyCode.__\u003C\u003Et))
      {
        for (int x = 0; x < this.__\u003C\u003Eeditor.width(); ++x)
        {
          for (int y = 0; y < this.__\u003C\u003Eeditor.height(); ++y)
          {
            Tile tile = this.__\u003C\u003Eeditor.tile(x, y);
            if (tile.block().breakable && tile.block() is Boulder)
            {
              tile.setBlock(Blocks.air);
              this.__\u003C\u003Eeditor.renderer.updatePoint(x, y);
            }
            if (!object.ReferenceEquals((object) tile.overlay(), (object) Blocks.air) && !object.ReferenceEquals((object) tile.overlay(), (object) Blocks.spawn))
            {
              tile.setOverlay(Blocks.air);
              this.__\u003C\u003Eeditor.renderer.updatePoint(x, y);
            }
          }
        }
        this.__\u003C\u003Eeditor.flushOp();
      }
      if (Core.input.keyTap(KeyCode.__\u003C\u003Ey))
        this.__\u003C\u003Eeditor.redo();
      if (Core.input.keyTap(KeyCode.__\u003C\u003Es))
        this.save();
      if (!Core.input.keyTap(KeyCode.__\u003C\u003Eg))
        return;
      this.view.setGrid(!this.view.isGrid());
    }

    [LineNumberTable(new byte[] {162, 46, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void tryExit() => Vars.ui.showConfirm("@confirm", "@editor.unsaved", (Runnable) new MapEditorDialog.__\u003C\u003EAnon18(this));

    [LineNumberTable(new byte[] {160, 206, 135, 134, 159, 22, 106, 105, 108, 108, 140, 218, 155, 103, 116, 212, 154, 136, 236, 42, 233, 89, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void createDialog(string _param1, params object[] _param2)
    {
      BaseDialog baseDialog = new BaseDialog(_param1);
      float height = 90f;
      baseDialog.__\u003C\u003Econt.defaults().size(360f, height).padBottom(5f).padRight(5f).padLeft(5f);
      for (int index = 0; index < _param2.Length; index += 4)
      {
        string text = (string) _param2[index];
        string str = (string) _param2[index + 1];
        Drawable name = (Drawable) _param2[index + 2];
        Runnable runnable = (Runnable) _param2[index + 3];
        TextButton textButton = (TextButton) baseDialog.__\u003C\u003Econt.button(text, (Runnable) new MapEditorDialog.__\u003C\u003EAnon14(this, runnable, baseDialog)).left().margin(0.0f).get();
        textButton.clearChildren();
        textButton.image(name).padLeft(10f);
        textButton.table((Cons) new MapEditorDialog.__\u003C\u003EAnon15(text, str)).growX().pad(10f).padLeft(5f);
        textButton.row();
        baseDialog.__\u003C\u003Econt.row();
      }
      baseDialog.addCloseButton();
      baseDialog.show();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {17, 159, 18, 156, 252, 69, 135, 252, 69, 252, 69, 135, 252, 91, 252, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002416([In] float obj0, [In] Table obj1)
    {
      obj1.defaults().size(obj0, 60f).padBottom(5f).padRight(5f).padLeft(5f);
      obj1.button("@editor.savemap", (Drawable) Icon.save, (Runnable) new MapEditorDialog.__\u003C\u003EAnon65(this));
      obj1.button("@editor.mapinfo", (Drawable) Icon.pencil, (Runnable) new MapEditorDialog.__\u003C\u003EAnon66(this));
      obj1.row();
      obj1.button("@editor.generate", (Drawable) Icon.terrain, (Runnable) new MapEditorDialog.__\u003C\u003EAnon67(this));
      obj1.button("@editor.resize", (Drawable) Icon.resize, (Runnable) new MapEditorDialog.__\u003C\u003EAnon68(this));
      obj1.row();
      obj1.button("@editor.import", (Drawable) Icon.download, (Runnable) new MapEditorDialog.__\u003C\u003EAnon69(this));
      obj1.button("@editor.export", (Drawable) Icon.upload, (Runnable) new MapEditorDialog.__\u003C\u003EAnon70(this));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {82, 159, 1, 127, 3, 127, 5, 161, 135, 122, 107, 161, 132, 127, 3, 111, 161, 119, 111, 161, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002419()
    {
      Map map1 = (Map) Vars.maps.all().find((Boolf) new MapEditorDialog.__\u003C\u003EAnon63(this));
      if (this.__\u003C\u003Eeditor.tags.containsKey((object) "steamid") && map1 != null && !map1.__\u003C\u003Ecustom)
      {
        Vars.platform.viewListingID((string) this.__\u003C\u003Eeditor.tags.get((object) "steamid"));
      }
      else
      {
        Map map2 = this.save();
        if (this.__\u003C\u003Eeditor.tags.containsKey((object) "steamid") && map2 != null)
        {
          Vars.platform.viewListing((Publishable) map2);
        }
        else
        {
          if (map2 == null)
            return;
          if (String.instancehelper_length((string) map2.__\u003C\u003Etags.get((object) "description", (object) "")) < 4)
            Vars.ui.showErrorMessage("@editor.nodescription");
          else if (!Structs.contains((object[]) Gamemode.__\u003C\u003Eall, (Boolf) new MapEditorDialog.__\u003C\u003EAnon64(map2)))
            Vars.ui.showErrorMessage("@map.nospawn");
          else
            Vars.platform.publish((Publishable) map2);
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {110, 120, 127, 26, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002420([In] TextButton obj0) => obj0.setText(!this.__\u003C\u003Eeditor.tags.containsKey((object) "steamid") ? "@editor.publish.workshop" : (!String.instancehelper_equals((string) this.__\u003C\u003Eeditor.tags.get((object) "author", (object) ""), (object) Vars.steamPlayerName) ? "@view.workshop" : "@workshop.listing"));

    [LineNumberTable(new byte[] {160, 131, 107, 245, 92})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void playtest()
    {
      this.menu.hide();
      Vars.ui.loadAnd((Runnable) new MapEditorDialog.__\u003C\u003EAnon11(this));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {122, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002421()
    {
      this.tryExit();
      this.menu.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {127, 124, 215})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002423([In] int obj0, [In] int obj1)
    {
      if (this.__\u003C\u003Eeditor.width() == obj0 && this.__\u003C\u003Eeditor.height() == obj1)
        return;
      Vars.ui.loadAnd((Runnable) new MapEditorDialog.__\u003C\u003EAnon62(this, obj0, obj1));
    }

    [Modifiers]
    [LineNumberTable(184)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002425([In] Map obj0) => Vars.ui.loadAnd((Runnable) new MapEditorDialog.__\u003C\u003EAnon61(this, obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {160, 85, 127, 4, 161, 121, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002426()
    {
      if (Core.scene.getKeyboardFocus() is Dialog && !object.ReferenceEquals((object) Core.scene.getKeyboardFocus(), (object) this) || (Core.scene == null || !object.ReferenceEquals((object) Core.scene.getKeyboardFocus(), (object) this)))
        return;
      this.doInput();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 96, 103, 123, 107, 113, 136, 106, 111, 149, 135, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002427()
    {
      this.saved = true;
      if (!Core.settings.getBool("landscape"))
        Vars.platform.beginForceLandscape();
      this.__\u003C\u003Eeditor.clearOp();
      Core.scene.setScrollFocus((Element) this.view);
      if (!this.shownWithMap)
      {
        Vars.logic.reset();
        Vars.state.rules = new Rules();
        this.__\u003C\u003Eeditor.beginEdit(200, 200);
      }
      this.shownWithMap = false;
      Platform platform = Vars.platform;
      Objects.requireNonNull((object) platform);
      Time.runTask(10f, (Runnable) new MapEditorDialog.__\u003C\u003EAnon60(platform));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 112, 107, 106, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002428()
    {
      this.__\u003C\u003Eeditor.clearOp();
      Vars.platform.updateRPC();
      if (Core.settings.getBool("landscape"))
        return;
      Vars.platform.endForceLandscape();
    }

    [LineNumberTable(new byte[] {161, 30, 134, 102, 242, 160, 191, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void build()
    {
      float num = 58f;
      this.clearChildren();
      this.table((Cons) new MapEditorDialog.__\u003C\u003EAnon17(this, num)).grow();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 133, 112, 134, 111, 106, 127, 0, 112, 159, 12, 123, 235, 61, 239, 69, 106, 127, 19, 106, 106, 106, 106, 138, 113, 127, 19, 127, 10, 103, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024playtest\u002429()
    {
      this.lastSavedRules = Vars.state.rules;
      this.hide();
      Vars.state.teams = new Teams();
      Vars.player.reset();
      Vars.state.rules = Gamemode.__\u003C\u003Eeditor.apply(this.lastSavedRules.copy());
      Vars.state.rules.sector = (Sector) null;
      Vars.state.map = new Map(StringMap.of(new object[6]
      {
        (object) "name",
        (object) "Editor Playtesting",
        (object) "width",
        (object) Integer.valueOf(this.__\u003C\u003Eeditor.width()),
        (object) "height",
        (object) Integer.valueOf(this.__\u003C\u003Eeditor.height())
      }));
      Vars.world.endMapLoad();
      Vars.player.set((float) (Vars.world.width() * 8) / 2f, (float) (Vars.world.height() * 8) / 2f);
      Vars.player.clearUnit();
      Groups.unit.clear();
      Groups.build.clear();
      Groups.weather.clear();
      Vars.logic.play();
      if (Vars.player.team().core() != null)
        return;
      Vars.player.set((float) (Vars.world.width() * 8) / 2f, (float) (Vars.world.height() * 8) / 2f);
      Unit unit = UnitTypes.alpha.spawn(Vars.player.team(), Vars.player.x, Vars.player.y);
      unit.spawnedByCore = true;
      Vars.player.unit(unit);
    }

    [Modifiers]
    [LineNumberTable(290)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024save\u002430() => Vars.ui.showErrorMessage("@editor.save.noname");

    [Modifiers]
    [LineNumberTable(292)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024save\u002431([In] string obj0, [In] Map obj1) => String.instancehelper_equals(obj1.name(), (object) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 219, 102, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024createDialog\u002432([In] Runnable obj0, [In] BaseDialog obj1)
    {
      obj0.run();
      obj1.hide();
      this.menu.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 227, 127, 3, 103, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024createDialog\u002433([In] string obj0, [In] string obj1, [In] Table obj2)
    {
      Table table1 = obj2;
      object obj3 = (object) obj0;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence text1 = charSequence;
      table1.add(text1).growX().wrap();
      obj2.row();
      Table table2 = obj2;
      object obj4 = (object) obj1;
      charSequence.__\u003Cref\u003E = (__Null) obj4;
      CharSequence text2 = charSequence;
      table2.add(text2).color(Color.__\u003C\u003Egray).growX().wrap();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 3, 103, 114, 222, 226, 61, 97, 102, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024beginEditMap\u002434([In] Fi obj0)
    {
      Exception exception1;
      try
      {
        this.shownWithMap = true;
        this.__\u003C\u003Eeditor.beginEdit(MapIO.createMap(obj0, true));
        this.show();
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      Exception exception2 = exception1;
      Log.err((Exception) exception2);
      Vars.ui.showException("@editor.errorload", (Exception) exception2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 34, 135, 248, 160, 181, 176, 151, 156})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002462([In] float obj0, [In] Table obj1)
    {
      obj1.left();
      obj1.table((Cons) new MapEditorDialog.__\u003C\u003EAnon27(this, obj0)).margin(0.0f).left().growY();
      obj1.table((Cons) new MapEditorDialog.__\u003C\u003EAnon28(this)).grow();
      obj1.table((Cons) new MapEditorDialog.__\u003C\u003EAnon29(this)).right().growY();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 55, 109, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addBlockSelection\u002463()
    {
      if (!this.pane.hasScroll())
        return;
      Core.scene.setScrollFocus((Element) this.view);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 61, 118, 123, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addBlockSelection\u002464([In] Table obj0)
    {
      obj0.image((Drawable) Icon.zoom).padRight(8f);
      ((TextField) obj0.field("", (Cons) new MapEditorDialog.__\u003C\u003EAnon26(this)).name("editor/search").maxTextLength(40).get()).setMessageText("@players.search");
    }

    [Modifiers]
    [LineNumberTable(692)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addBlockSelection\u002466([In] Table obj0) => obj0.labelWrap((Prov) new MapEditorDialog.__\u003C\u003EAnon25(this)).width(200f).center();

    [Modifiers]
    [LineNumberTable(new byte[] {162, 79, 121, 101, 114, 101, 120, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024rebuildBlockSelection\u002467([In] Block obj0, [In] Block obj1)
    {
      int num1 = -Boolean.compare(obj0 is CoreBlock, obj1 is CoreBlock);
      if (num1 != 0)
        return num1;
      int num2 = Boolean.compare(obj0.synthetic(), obj1.synthetic());
      if (num2 != 0)
        return num2;
      int num3 = Boolean.compare(obj0 is OverlayFloor, obj1 is OverlayFloor);
      return num3 != 0 ? num3 : Integer.compare((int) obj0.__\u003C\u003Eid, (int) obj1.__\u003C\u003Eid);
    }

    [Modifiers]
    [LineNumberTable(726)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildBlockSelection\u002468([In] Block obj0) => this.__\u003C\u003Eeditor.drawBlock = obj0;

    [Modifiers]
    [LineNumberTable(728)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildBlockSelection\u002469([In] ImageButton obj0, [In] Block obj1) => obj0.setChecked(object.ReferenceEquals((object) this.__\u003C\u003Eeditor.drawBlock, (object) obj1));

    [Modifiers]
    [LineNumberTable(692)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private CharSequence lambda\u0024addBlockSelection\u002465()
    {
      object localizedName = (object) this.__\u003C\u003Eeditor.drawBlock.localizedName;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) localizedName;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 37, 135, 139, 102, 139, 239, 160, 76, 144, 159, 9, 159, 8, 139, 135, 127, 20, 159, 20, 139, 135, 114, 146, 116, 116, 149, 107, 107, 139, 135, 107, 139, 127, 8, 250, 69, 135, 118, 159, 16, 135, 135, 131, 127, 0, 118, 109, 109, 115, 117, 119, 105, 137, 253, 54, 235, 77, 151, 135, 253, 77, 144, 135, 103, 145, 171, 103, 135, 145, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002460([In] float obj0, [In] Table obj1)
    {
      obj1.top();
      Table table1 = new Table().top();
      Cons cons = (Cons) new MapEditorDialog.__\u003C\u003EAnon30(this, new Table[1]
      {
        (Table) null
      }, new ButtonGroup(), table1);
      table1.defaults().size(obj0, obj0);
      Table table2 = table1;
      TextureRegionDrawable menu1 = Icon.menu;
      ImageButton.ImageButtonStyle cleari1 = Styles.cleari;
      BaseDialog menu2 = this.menu;
      Objects.requireNonNull((object) menu2);
      Runnable listener1 = (Runnable) new MapEditorDialog.__\u003C\u003EAnon31(menu2);
      table2.button((Drawable) menu1, cleari1, listener1);
      ImageButton imageButton1 = (ImageButton) table1.button((Drawable) Icon.grid, Styles.clearTogglei, (Runnable) new MapEditorDialog.__\u003C\u003EAnon32(this)).get();
      cons.get((object) EditorTool.__\u003C\u003Ezoom);
      table1.row();
      Table table3 = table1;
      TextureRegionDrawable undo = Icon.undo;
      ImageButton.ImageButtonStyle cleari2 = Styles.cleari;
      MapEditor editor1 = this.__\u003C\u003Eeditor;
      Objects.requireNonNull((object) editor1);
      Runnable listener2 = (Runnable) new MapEditorDialog.__\u003C\u003EAnon33(editor1);
      ImageButton imageButton2 = (ImageButton) table3.button((Drawable) undo, cleari2, listener2).get();
      Table table4 = table1;
      TextureRegionDrawable redo = Icon.redo;
      ImageButton.ImageButtonStyle cleari3 = Styles.cleari;
      MapEditor editor2 = this.__\u003C\u003Eeditor;
      Objects.requireNonNull((object) editor2);
      Runnable listener3 = (Runnable) new MapEditorDialog.__\u003C\u003EAnon34(editor2);
      ImageButton imageButton3 = (ImageButton) table4.button((Drawable) redo, cleari3, listener3).get();
      cons.get((object) EditorTool.__\u003C\u003Epick);
      table1.row();
      imageButton2.setDisabled((Boolp) new MapEditorDialog.__\u003C\u003EAnon35(this));
      imageButton3.setDisabled((Boolp) new MapEditorDialog.__\u003C\u003EAnon36(this));
      imageButton2.update((Runnable) new MapEditorDialog.__\u003C\u003EAnon37(imageButton2));
      imageButton3.update((Runnable) new MapEditorDialog.__\u003C\u003EAnon38(imageButton3));
      imageButton1.update((Runnable) new MapEditorDialog.__\u003C\u003EAnon39(this, imageButton1));
      cons.get((object) EditorTool.__\u003C\u003Eline);
      cons.get((object) EditorTool.__\u003C\u003Epencil);
      cons.get((object) EditorTool.__\u003C\u003Eeraser);
      table1.row();
      cons.get((object) EditorTool.__\u003C\u003Efill);
      cons.get((object) EditorTool.__\u003C\u003Espray);
      ImageButton imageButton4 = (ImageButton) table1.button((Drawable) Icon.right, Styles.cleari, (Runnable) new MapEditorDialog.__\u003C\u003EAnon40(this)).get();
      imageButton4.getImage().update((Runnable) new MapEditorDialog.__\u003C\u003EAnon41(this, imageButton4));
      table1.row();
      table1.table((Drawable) Tex.underline, (Cons) new MapEditorDialog.__\u003C\u003EAnon42()).colspan(3).height(40f).width(obj0 * 3f + 3f).padBottom(3f);
      table1.row();
      ButtonGroup buttonGroup = new ButtonGroup();
      int num1 = 0;
      Team[] baseTeams = Team.__\u003C\u003EbaseTeams;
      int length = baseTeams.Length;
      for (int index = 0; index < length; ++index)
      {
        Team team = baseTeams[index];
        ImageButton.__\u003Cclinit\u003E();
        ImageButton imageButton5 = new ImageButton((Drawable) Tex.whiteui, Styles.clearTogglePartiali);
        imageButton5.margin(4f);
        imageButton5.getImageCell().grow();
        imageButton5.getStyle().imageUpColor = team.__\u003C\u003Ecolor;
        imageButton5.clicked((Runnable) new MapEditorDialog.__\u003C\u003EAnon43(this, team));
        imageButton5.update((Runnable) new MapEditorDialog.__\u003C\u003EAnon44(this, imageButton5, team));
        buttonGroup.add((Button) imageButton5);
        table1.add((Element) imageButton5);
        int num2 = num1;
        ++num1;
        int num3 = 3;
        if ((num3 != -1 ? num2 % num3 : 0) == 2)
          table1.row();
      }
      obj1.add((Element) table1).top().padBottom(-6f);
      obj1.row();
      obj1.table((Drawable) Tex.underline, (Cons) new MapEditorDialog.__\u003C\u003EAnon45(this, obj0)).padTop(5f).growX().top();
      obj1.row();
      if (!Vars.mobile)
        obj1.table((Cons) new MapEditorDialog.__\u003C\u003EAnon46(this)).growX().top();
      if (!Vars.experimental)
        return;
      obj1.row();
      obj1.table((Cons) new MapEditorDialog.__\u003C\u003EAnon47(this)).growX().top();
    }

    [Modifiers]
    [LineNumberTable(590)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002461([In] Table obj0) => obj0.add((Element) this.view).grow();

    [LineNumberTable(new byte[] {162, 50, 107, 118, 108, 109, 246, 70, 214, 102, 103, 124, 103, 156, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addBlockSelection([In] Table obj0)
    {
      this.blockSelection = new Table();
      ScrollPane.__\u003Cclinit\u003E();
      this.pane = new ScrollPane((Element) this.blockSelection);
      this.pane.setFadeScrollBars(false);
      this.pane.setOverscroll(true, false);
      this.pane.exited((Runnable) new MapEditorDialog.__\u003C\u003EAnon19(this));
      obj0.table((Cons) new MapEditorDialog.__\u003C\u003EAnon20(this)).pad(-2f);
      obj0.row();
      obj0.table((Drawable) Tex.underline, (Cons) new MapEditorDialog.__\u003C\u003EAnon21(this)).growX();
      obj0.row();
      obj0.add((Element) this.pane).expandY().top().left();
      this.rebuildBlockSelection("");
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 46, 127, 2, 245, 70, 117, 135, 107, 255, 1, 118, 123, 107, 116, 106, 139, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002444(
      [In] Table[] obj0,
      [In] ButtonGroup obj1,
      [In] Table obj2,
      [In] EditorTool obj3)
    {
      ImageButton.__\u003Cclinit\u003E();
      ImageButton imageButton = new ImageButton((Drawable) Vars.ui.getIcon(obj3.name()), Styles.clearTogglei);
      imageButton.clicked((Runnable) new MapEditorDialog.__\u003C\u003EAnon51(this, obj3, obj0));
      imageButton.update((Runnable) new MapEditorDialog.__\u003C\u003EAnon52(this, imageButton, obj3));
      obj1.add((Button) imageButton);
      if (obj3.__\u003C\u003EaltModes.Length > 0)
        imageButton.clicked((Cons) new MapEditorDialog.__\u003C\u003EAnon53(), (Cons) new MapEditorDialog.__\u003C\u003EAnon54(this, obj0, obj3, imageButton));
      object obj = (object) "";
      CharSequence text;
      text.__\u003Cref\u003E = (__Null) obj;
      Label label = new Label(text);
      label.setColor(Pal.remove);
      label.update((Runnable) new MapEditorDialog.__\u003C\u003EAnon55(label, obj3));
      label.setAlignment(20, 20);
      label.touchable = Touchable.__\u003C\u003Edisabled;
      obj2.stack((Element) imageButton, (Element) label);
    }

    [Modifiers]
    [LineNumberTable(494)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002445() => this.view.setGrid(!this.view.isGrid());

    [Modifiers]
    [LineNumberTable(507)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u002446() => !this.__\u003C\u003Eeditor.canUndo();

    [Modifiers]
    [LineNumberTable(508)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u002447() => !this.__\u003C\u003Eeditor.canRedo();

    [Modifiers]
    [LineNumberTable(510)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002448([In] ImageButton obj0) => obj0.getImage().setColor(!obj0.isDisabled() ? Color.__\u003C\u003Ewhite : Color.__\u003C\u003Egray);

    [Modifiers]
    [LineNumberTable(511)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002449([In] ImageButton obj0) => obj0.getImage().setColor(!obj0.isDisabled() ? Color.__\u003C\u003Ewhite : Color.__\u003C\u003Egray);

    [Modifiers]
    [LineNumberTable(512)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002450([In] ImageButton obj0) => obj0.setChecked(this.view.isGrid());

    [Modifiers]
    [LineNumberTable(523)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002451()
    {
      MapEditor editor = this.__\u003C\u003Eeditor;
      int num1 = this.__\u003C\u003Eeditor.rotation + 1;
      int num2 = 4;
      int num3 = num2 != -1 ? num1 % num2 : 0;
      editor.rotation = num3;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 155, 122, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002452([In] ImageButton obj0)
    {
      obj0.getImage().setRotation((float) (this.__\u003C\u003Eeditor.rotation * 90));
      obj0.getImage().setOrigin(1);
    }

    [Modifiers]
    [LineNumberTable(531)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002453([In] Table obj0)
    {
      Table table = obj0;
      object obj = (object) "@editor.teams";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text);
    }

    [Modifiers]
    [LineNumberTable(545)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002454([In] Team obj0) => this.__\u003C\u003Eeditor.drawTeam = obj0;

    [Modifiers]
    [LineNumberTable(546)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002455([In] ImageButton obj0, [In] Team obj1) => obj0.setChecked(object.ReferenceEquals((object) this.__\u003C\u003Eeditor.drawTeam, (object) obj1));

    [Modifiers]
    [LineNumberTable(new byte[] {161, 188, 122, 113, 107, 116, 9, 230, 70, 103, 124, 103, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002457([In] float obj0, [In] Table obj1)
    {
      Slider slider = new Slider(0.0f, (float) (MapEditor.__\u003C\u003EbrushSizes.Length - 1), 1f, false);
      slider.moved((Floatc) new MapEditorDialog.__\u003C\u003EAnon50(this));
      for (int index = 0; index < MapEditor.__\u003C\u003EbrushSizes.Length; ++index)
      {
        if (MapEditor.__\u003C\u003EbrushSizes[index] == this.__\u003C\u003Eeditor.brushSize)
          slider.setValue((float) index);
      }
      obj1.top();
      Table table = obj1;
      object obj = (object) "@editor.brush";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text);
      obj1.row();
      obj1.add((Element) slider).width(obj0 * 3f - 20f).padTop(4f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 206, 127, 29})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002458([In] Table obj0)
    {
      Table table = obj0;
      TextureRegionDrawable move = Icon.move;
      TextButton.TextButtonStyle cleart = Styles.cleart;
      MapView view = this.view;
      Objects.requireNonNull((object) view);
      Runnable clicked = (Runnable) new MapEditorDialog.__\u003C\u003EAnon49(view);
      table.button("@editor.center", (Drawable) move, cleart, clicked).growX().margin(9f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 214, 127, 29})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002459([In] Table obj0)
    {
      Table table = obj0;
      TextureRegionDrawable terrain = Icon.terrain;
      TextButton.TextButtonStyle cleart = Styles.cleart;
      MapEditor editor = this.__\u003C\u003Eeditor;
      Objects.requireNonNull((object) editor);
      Runnable clicked = (Runnable) new MapEditorDialog.__\u003C\u003EAnon48(editor);
      table.button("Cliffs", (Drawable) terrain, cleart, clicked).growX().margin(9f);
    }

    [Modifiers]
    [LineNumberTable(559)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002456([In] float obj0) => this.__\u003C\u003Eeditor.brushSize = MapEditor.__\u003C\u003EbrushSizes[ByteCodeHelper.f2i(obj0)];

    [Modifiers]
    [LineNumberTable(new byte[] {161, 48, 108, 101, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002435([In] EditorTool obj0, [In] Table[] obj1)
    {
      this.view.setTool(obj0);
      if (obj1[0] == null)
        return;
      obj1[0].remove();
    }

    [Modifiers]
    [LineNumberTable(423)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002436([In] ImageButton obj0, [In] EditorTool obj1) => obj0.setChecked(object.ReferenceEquals((object) this.view.getTool(), (object) obj1));

    [Modifiers]
    [LineNumberTable(new byte[] {161, 58, 135, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002437([In] ClickListener obj0)
    {
      if (Vars.mobile)
        return;
      obj0.setButton(KeyCode.__\u003C\u003EmouseRight);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 64, 113, 161, 101, 169, 112, 150, 108, 98, 137, 255, 11, 74, 102, 231, 49, 230, 82, 245, 73, 102, 145, 103, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002442(
      [In] Table[] obj0,
      [In] EditorTool obj1,
      [In] ImageButton obj2,
      [In] ClickListener obj3)
    {
      if (Vars.mobile && obj3.getTapCount() < 2)
        return;
      if (obj0[0] != null)
        obj0[0].remove();
      Table.__\u003Cclinit\u003E();
      Table table = new Table(Styles.black9);
      table.defaults().size(300f, 70f);
      for (int index = 0; index < obj1.__\u003C\u003EaltModes.Length; ++index)
      {
        int num = index;
        string altMode = obj1.__\u003C\u003EaltModes[index];
        table.button((Cons) new MapEditorDialog.__\u003C\u003EAnon56(altMode), (Runnable) new MapEditorDialog.__\u003C\u003EAnon57(obj1, num, table)).update((Cons) new MapEditorDialog.__\u003C\u003EAnon58(obj1, num));
        table.row();
      }
      table.update((Runnable) new MapEditorDialog.__\u003C\u003EAnon59(this, obj2, table, obj0));
      table.pack();
      table.act(Core.graphics.getDeltaTime());
      this.addChild((Element) table);
      obj0[0] = table;
    }

    [Modifiers]
    [LineNumberTable(483)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002443([In] Label obj0, [In] EditorTool obj1)
    {
      Label label = obj0;
      object obj = obj1.mode != -1 ? (object) new StringBuilder().append("M").append(obj1.mode + 1).append(" ").toString() : (object) "";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence newText = charSequence;
      label.setText(newText);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 80, 103, 108, 107, 127, 33, 103, 127, 53})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002438([In] string obj0, [In] Button obj1)
    {
      obj1.left();
      obj1.marginLeft(6f);
      obj1.setStyle((Button.ButtonStyle) Styles.clearTogglet);
      Button button1 = obj1;
      object obj2 = (object) Core.bundle.get(new StringBuilder().append("toolmode.").append(obj0).toString());
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text1 = charSequence;
      button1.add(text1).left();
      obj1.row();
      Button button2 = obj1;
      object obj3 = (object) Core.bundle.get(new StringBuilder().append("toolmode.").append(obj0).append(".description").toString());
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence text2 = charSequence;
      button2.add(text2).color(Color.__\u003C\u003ElightGray).left();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 87, 115, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002439([In] EditorTool obj0, [In] int obj1, [In] Table obj2)
    {
      obj0.mode = obj0.mode != obj1 ? obj1 : -1;
      obj2.remove();
    }

    [Modifiers]
    [LineNumberTable(459)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002440([In] EditorTool obj0, [In] int obj1, [In] Button obj2) => obj2.setChecked(obj0.mode == obj1);

    [Modifiers]
    [LineNumberTable(new byte[] {161, 94, 113, 116, 104, 103, 132})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002441([In] ImageButton obj0, [In] Table obj1, [In] Table[] obj2)
    {
      Vec2 stageCoordinates = obj0.localToStageCoordinates(Tmp.__\u003C\u003Ev1.setZero());
      obj1.setPosition(stageCoordinates.x, stageCoordinates.y, 10);
      if (this.isShown())
        return;
      obj1.remove();
      obj2[0] = (Table) null;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 72, 223, 4, 226, 61, 97, 112, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002424([In] Map obj0)
    {
      Exception exception1;
      try
      {
        this.__\u003C\u003Eeditor.beginEdit(obj0);
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      Exception exception2 = exception1;
      Vars.ui.showException("@editor.errorload", (Exception) exception2);
      Log.err((Exception) exception2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 65, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002422([In] int obj0, [In] int obj1) => this.__\u003C\u003Eeditor.resize(obj0, obj1);

    [Modifiers]
    [LineNumberTable(132)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024new\u002417([In] Map obj0) => String.instancehelper_equals(obj0.name(), (object) String.instancehelper_trim((string) this.__\u003C\u003Eeditor.tags.get((object) "name", (object) "")));

    [Modifiers]
    [LineNumberTable(153)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u002418([In] Map obj0, [In] Gamemode obj1) => obj1.valid(obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {22, 108, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240()
    {
      this.infoDialog.show();
      this.menu.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {29, 127, 3, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241()
    {
      MapGenerateDialog generateDialog1 = this.generateDialog;
      MapGenerateDialog generateDialog2 = this.generateDialog;
      Objects.requireNonNull((object) generateDialog2);
      Cons applier = (Cons) new MapEditorDialog.__\u003C\u003EAnon83(generateDialog2);
      generateDialog1.show(applier);
      this.menu.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {34, 108, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242()
    {
      this.resizeDialog.show();
      this.menu.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {40, 127, 15, 63, 65})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002410()
    {
      object[] objArray = new object[12];
      objArray[0] = (object) "@editor.importmap";
      objArray[1] = (object) "@editor.importmap.description";
      objArray[2] = (object) Icon.download;
      MapLoadDialog loadDialog = this.loadDialog;
      Objects.requireNonNull((object) loadDialog);
      objArray[3] = (object) (Runnable) new MapEditorDialog.__\u003C\u003EAnon75(loadDialog);
      objArray[4] = (object) "@editor.importfile";
      objArray[5] = (object) "@editor.importfile.description";
      objArray[6] = (object) Icon.file;
      objArray[7] = (object) (Runnable) new MapEditorDialog.__\u003C\u003EAnon76(this);
      objArray[8] = (object) "@editor.importimage";
      objArray[9] = (object) "@editor.importimage.description";
      objArray[10] = (object) Icon.fileImage;
      objArray[11] = (object) (Runnable) new MapEditorDialog.__\u003C\u003EAnon77(this);
      this.createDialog("@editor.import", objArray);
    }

    [Modifiers]
    [LineNumberTable(117)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002415() => this.createDialog("@editor.export", (object) "@editor.exportfile", (object) "@editor.exportfile.description", (object) Icon.file, (object) (Runnable) new MapEditorDialog.__\u003C\u003EAnon71(this), (object) "@editor.exportimage", (object) "@editor.exportimage.description", (object) Icon.fileImage, (object) (Runnable) new MapEditorDialog.__\u003C\u003EAnon72(this));

    [Modifiers]
    [LineNumberTable(119)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002412() => Vars.platform.export((string) this.__\u003C\u003Eeditor.tags.get((object) "name", (object) "unknown"), "msav", (Platform.FileWriter) new MapEditorDialog.__\u003C\u003EAnon74(this));

    [Modifiers]
    [LineNumberTable(121)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002414() => Vars.platform.export((string) this.__\u003C\u003Eeditor.tags.get((object) "name", (object) "unknown"), "png", (Platform.FileWriter) new MapEditorDialog.__\u003C\u003EAnon73(this));

    [Throws(new string[] {"java.lang.Throwable"})]
    [Modifiers]
    [LineNumberTable(new byte[] {72, 113, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002413([In] Fi obj0)
    {
      Pixmap pixmap = MapIO.writeImage(this.__\u003C\u003Eeditor.tiles());
      obj0.writePNG(pixmap);
      pixmap.dispose();
    }

    [Throws(new string[] {"java.lang.Throwable"})]
    [Modifiers]
    [LineNumberTable(119)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002411([In] Fi obj0) => MapIO.writeMap(obj0, this.__\u003C\u003Eeditor.createMap(obj0));

    [Modifiers]
    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00246() => Vars.platform.showFileChooser(true, "msav", (Cons) new MapEditorDialog.__\u003C\u003EAnon80(this));

    [Modifiers]
    [LineNumberTable(104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00249() => Vars.platform.showFileChooser(true, "png", (Cons) new MapEditorDialog.__\u003C\u003EAnon78(this));

    [Modifiers]
    [LineNumberTable(105)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00248([In] Fi obj0) => Vars.ui.loadAnd((Runnable) new MapEditorDialog.__\u003C\u003EAnon79(this, obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {57, 103, 108, 221, 226, 61, 97, 112, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00247([In] Fi obj0)
    {
      Exception exception1;
      try
      {
        Pixmap pixmap = new Pixmap(obj0);
        this.__\u003C\u003Eeditor.beginEdit(pixmap);
        pixmap.dispose();
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      Exception exception2 = exception1;
      Vars.ui.showException("@editor.errorload", (Exception) exception2);
      Log.err((Exception) exception2);
    }

    [Modifiers]
    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00245([In] Fi obj0) => Vars.ui.loadAnd((Runnable) new MapEditorDialog.__\u003C\u003EAnon81(this, obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {44, 246, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00244([In] Fi obj0) => Vars.maps.tryCatchMapError((UnsafeRunnable) new MapEditorDialog.__\u003C\u003EAnon82(this, obj0));

    [Throws(new string[] {"java.lang.Throwable"})]
    [Modifiers]
    [LineNumberTable(new byte[] {45, 104, 145, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00243([In] Fi obj0)
    {
      if (MapIO.isImage(obj0))
        Vars.ui.showInfo("@editor.errorimage");
      else
        this.__\u003C\u003Eeditor.beginEdit(MapIO.createMap(obj0, true));
    }

    [LineNumberTable(new byte[] {160, 121, 111, 103, 103, 127, 0, 103, 103, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resumeEditing()
    {
      Vars.state.set(GameState.State.__\u003C\u003Emenu);
      this.shownWithMap = true;
      this.show();
      Vars.state.rules = this.lastSavedRules != null ? this.lastSavedRules : new Rules();
      this.lastSavedRules = (Rules) null;
      this.saved = false;
      this.__\u003C\u003Eeditor.renderer.updateAll();
    }

    [LineNumberTable(new byte[] {160, 253, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose() => this.__\u003C\u003Eeditor.renderer.dispose();

    [LineNumberTable(new byte[] {161, 1, 246, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginEditMap(Fi file) => Vars.ui.loadAnd((Runnable) new MapEditorDialog.__\u003C\u003EAnon16(this, file));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual MapView getView() => this.view;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual MapGenerateDialog getGenerateDialog() => this.generateDialog;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resetSaved() => this.saved = false;

    [LineNumberTable(396)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasPane() => object.ReferenceEquals((object) Core.scene.getScrollFocus(), (object) this.pane) || !object.ReferenceEquals((object) Core.scene.getKeyboardFocus(), (object) this);

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [HideFromJava]
    static MapEditorDialog() => Dialog.__\u003Cclinit\u003E();

    [Modifiers]
    public MapEditor editor
    {
      [HideFromJava] get => this.__\u003C\u003Eeditor;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eeditor = value;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon0([In] MapEditorDialog obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u002416(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002419();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon2([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u002420((TextButton) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon3([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.playtest();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon4([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002421();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Intc2
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon5([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024new\u002423(obj0, obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon6([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u002425((Map) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon7([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002426();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon8([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002427();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon9([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002428();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon10([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.build();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon11([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024playtest\u002429();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Runnable
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public void run() => MapEditorDialog.lambda\u0024save\u002430();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon13([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (MapEditorDialog.lambda\u0024save\u002431(this.arg\u00241, (Map) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly Runnable arg\u00242;
      private readonly BaseDialog arg\u00243;

      internal __\u003C\u003EAnon14([In] MapEditorDialog obj0, [In] Runnable obj1, [In] BaseDialog obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024createDialog\u002432(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Cons
    {
      private readonly string arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon15([In] string obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => MapEditorDialog.lambda\u0024createDialog\u002433(this.arg\u00241, this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly Fi arg\u00242;

      internal __\u003C\u003EAnon16([In] MapEditorDialog obj0, [In] Fi obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024beginEditMap\u002434(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Cons
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon17([In] MapEditorDialog obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002462(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon18([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon19([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024addBlockSelection\u002463();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Cons
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon20([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024addBlockSelection\u002464((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Cons
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon21([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024addBlockSelection\u002466((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Comparator
    {
      internal __\u003C\u003EAnon22()
      {
      }

      public int compare([In] object obj0, [In] object obj1) => MapEditorDialog.lambda\u0024rebuildBlockSelection\u002467((Block) obj0, (Block) obj1);

      [SpecialName]
      public Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public bool equals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

      [SpecialName]
      public Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly Block arg\u00242;

      internal __\u003C\u003EAnon23([In] MapEditorDialog obj0, [In] Block obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024rebuildBlockSelection\u002468(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly ImageButton arg\u00242;
      private readonly Block arg\u00243;

      internal __\u003C\u003EAnon24([In] MapEditorDialog obj0, [In] ImageButton obj1, [In] Block obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024rebuildBlockSelection\u002469(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Prov
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon25([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024addBlockSelection\u002465().__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Cons
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon26([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.rebuildBlockSelection((string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Cons
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon27([In] MapEditorDialog obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002460(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Cons
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon28([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002461((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Cons
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon29([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.addBlockSelection((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Cons
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly Table[] arg\u00242;
      private readonly ButtonGroup arg\u00243;
      private readonly Table arg\u00244;

      internal __\u003C\u003EAnon30(
        [In] MapEditorDialog obj0,
        [In] Table[] obj1,
        [In] ButtonGroup obj2,
        [In] Table obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002444(this.arg\u00242, this.arg\u00243, this.arg\u00244, (EditorTool) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Runnable
    {
      private readonly BaseDialog arg\u00241;

      internal __\u003C\u003EAnon31([In] BaseDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon32([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024build\u002445();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Runnable
    {
      private readonly MapEditor arg\u00241;

      internal __\u003C\u003EAnon33([In] MapEditor obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.undo();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Runnable
    {
      private readonly MapEditor arg\u00241;

      internal __\u003C\u003EAnon34([In] MapEditor obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.redo();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Boolp
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon35([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024build\u002446() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : Boolp
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon36([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024build\u002447() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon37 : Runnable
    {
      private readonly ImageButton arg\u00241;

      internal __\u003C\u003EAnon37([In] ImageButton obj0) => this.arg\u00241 = obj0;

      public void run() => MapEditorDialog.lambda\u0024build\u002448(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon38 : Runnable
    {
      private readonly ImageButton arg\u00241;

      internal __\u003C\u003EAnon38([In] ImageButton obj0) => this.arg\u00241 = obj0;

      public void run() => MapEditorDialog.lambda\u0024build\u002449(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon39 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly ImageButton arg\u00242;

      internal __\u003C\u003EAnon39([In] MapEditorDialog obj0, [In] ImageButton obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024build\u002450(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon40 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon40([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024build\u002451();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon41 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly ImageButton arg\u00242;

      internal __\u003C\u003EAnon41([In] MapEditorDialog obj0, [In] ImageButton obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024build\u002452(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon42 : Cons
    {
      internal __\u003C\u003EAnon42()
      {
      }

      public void get([In] object obj0) => MapEditorDialog.lambda\u0024build\u002453((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon43 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly Team arg\u00242;

      internal __\u003C\u003EAnon43([In] MapEditorDialog obj0, [In] Team obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024build\u002454(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon44 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly ImageButton arg\u00242;
      private readonly Team arg\u00243;

      internal __\u003C\u003EAnon44([In] MapEditorDialog obj0, [In] ImageButton obj1, [In] Team obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024build\u002455(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon45 : Cons
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon45([In] MapEditorDialog obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002457(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon46 : Cons
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon46([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002458((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon47 : Cons
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon47([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002459((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon48 : Runnable
    {
      private readonly MapEditor arg\u00241;

      internal __\u003C\u003EAnon48([In] MapEditor obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.addCliffs();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon49 : Runnable
    {
      private readonly MapView arg\u00241;

      internal __\u003C\u003EAnon49([In] MapView obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.center();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon50 : Floatc
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon50([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024build\u002456(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon51 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly EditorTool arg\u00242;
      private readonly Table[] arg\u00243;

      internal __\u003C\u003EAnon51([In] MapEditorDialog obj0, [In] EditorTool obj1, [In] Table[] obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024build\u002435(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon52 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly ImageButton arg\u00242;
      private readonly EditorTool arg\u00243;

      internal __\u003C\u003EAnon52([In] MapEditorDialog obj0, [In] ImageButton obj1, [In] EditorTool obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024build\u002436(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon53 : Cons
    {
      internal __\u003C\u003EAnon53()
      {
      }

      public void get([In] object obj0) => MapEditorDialog.lambda\u0024build\u002437((ClickListener) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon54 : Cons
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly Table[] arg\u00242;
      private readonly EditorTool arg\u00243;
      private readonly ImageButton arg\u00244;

      internal __\u003C\u003EAnon54(
        [In] MapEditorDialog obj0,
        [In] Table[] obj1,
        [In] EditorTool obj2,
        [In] ImageButton obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002442(this.arg\u00242, this.arg\u00243, this.arg\u00244, (ClickListener) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon55 : Runnable
    {
      private readonly Label arg\u00241;
      private readonly EditorTool arg\u00242;

      internal __\u003C\u003EAnon55([In] Label obj0, [In] EditorTool obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => MapEditorDialog.lambda\u0024build\u002443(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon56 : Cons
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon56([In] string obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => MapEditorDialog.lambda\u0024build\u002438(this.arg\u00241, (Button) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon57 : Runnable
    {
      private readonly EditorTool arg\u00241;
      private readonly int arg\u00242;
      private readonly Table arg\u00243;

      internal __\u003C\u003EAnon57([In] EditorTool obj0, [In] int obj1, [In] Table obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => MapEditorDialog.lambda\u0024build\u002439(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon58 : Cons
    {
      private readonly EditorTool arg\u00241;
      private readonly int arg\u00242;

      internal __\u003C\u003EAnon58([In] EditorTool obj0, [In] int obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => MapEditorDialog.lambda\u0024build\u002440(this.arg\u00241, this.arg\u00242, (Button) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon59 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly ImageButton arg\u00242;
      private readonly Table arg\u00243;
      private readonly Table[] arg\u00244;

      internal __\u003C\u003EAnon59(
        [In] MapEditorDialog obj0,
        [In] ImageButton obj1,
        [In] Table obj2,
        [In] Table[] obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void run() => this.arg\u00241.lambda\u0024build\u002441(this.arg\u00242, this.arg\u00243, this.arg\u00244);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon60 : Runnable
    {
      private readonly Platform arg\u00241;

      internal __\u003C\u003EAnon60([In] Platform obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.updateRPC();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon61 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly Map arg\u00242;

      internal __\u003C\u003EAnon61([In] MapEditorDialog obj0, [In] Map obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u002424(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon62 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly int arg\u00242;
      private readonly int arg\u00243;

      internal __\u003C\u003EAnon62([In] MapEditorDialog obj0, [In] int obj1, [In] int obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u002422(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon63 : Boolf
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon63([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024new\u002417((Map) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon64 : Boolf
    {
      private readonly Map arg\u00241;

      internal __\u003C\u003EAnon64([In] Map obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (MapEditorDialog.lambda\u0024new\u002418(this.arg\u00241, (Gamemode) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon65 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon65([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.save();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon66 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon66([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon67 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon67([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00241();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon68 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon68([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon69 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon69([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002410();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon70 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon70([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002415();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon71 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon71([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002412();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon72 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon72([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002414();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon73 : Platform.FileWriter
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon73([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void write([In] Fi obj0) => this.arg\u00241.lambda\u0024new\u002413(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon74 : Platform.FileWriter
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon74([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void write([In] Fi obj0) => this.arg\u00241.lambda\u0024new\u002411(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon75 : Runnable
    {
      private readonly MapLoadDialog arg\u00241;

      internal __\u003C\u003EAnon75([In] MapLoadDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon76 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon76([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00246();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon77 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon77([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00249();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon78 : Cons
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon78([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00248((Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon79 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly Fi arg\u00242;

      internal __\u003C\u003EAnon79([In] MapEditorDialog obj0, [In] Fi obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00247(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon80 : Cons
    {
      private readonly MapEditorDialog arg\u00241;

      internal __\u003C\u003EAnon80([In] MapEditorDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00245((Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon81 : Runnable
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly Fi arg\u00242;

      internal __\u003C\u003EAnon81([In] MapEditorDialog obj0, [In] Fi obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00244(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon82 : UnsafeRunnable
    {
      private readonly MapEditorDialog arg\u00241;
      private readonly Fi arg\u00242;

      internal __\u003C\u003EAnon82([In] MapEditorDialog obj0, [In] Fi obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00243(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon83 : Cons
    {
      private readonly MapGenerateDialog arg\u00241;

      internal __\u003C\u003EAnon83([In] MapGenerateDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.applyToEditor((Seq) obj0);
    }
  }
}
