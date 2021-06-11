// Decompiled with JetBrains decompiler
// Type: mindustry.core.UI
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.assets;
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
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.editor;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.logic;
using mindustry.ui;
using mindustry.ui.dialogs;
using mindustry.ui.fragments;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.core
{
  [Implements(new string[] {"arc.ApplicationListener", "arc.assets.Loadable"})]
  public class UI : Object, ApplicationListener, Loadable
  {
    public static PixmapPacker packer;
    public MenuFragment menufrag;
    public HudFragment hudfrag;
    public ChatFragment chatfrag;
    public ScriptConsoleFragment scriptfrag;
    public MinimapFragment minimapfrag;
    public PlayerListFragment listfrag;
    public LoadingFragment loadfrag;
    public HintsFragment hints;
    public WidgetGroup menuGroup;
    public WidgetGroup hudGroup;
    public AboutDialog about;
    public GameOverDialog restart;
    public CustomGameDialog custom;
    public MapsDialog maps;
    public LoadDialog load;
    public DiscordDialog discord;
    public JoinDialog join;
    public HostDialog host;
    public PausedDialog paused;
    public SettingsMenuDialog settings;
    public ControlsDialog controls;
    public MapEditorDialog editor;
    public LanguageDialog language;
    public BansDialog bans;
    public AdminsDialog admins;
    public TraceDialog traces;
    public DatabaseDialog database;
    public ContentInfoDialog content;
    public PlanetDialog planet;
    public ResearchDialog research;
    public SchematicsDialog schematics;
    public ModsDialog mods;
    public ColorPicker picker;
    public LogicDialog logic;
    public Graphics.Cursor drillCursor;
    public Graphics.Cursor unloadCursor;

    [LineNumberTable(new byte[] {160, 125, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadAnd(Runnable call) => this.loadAnd("@loading", call);

    [LineNumberTable(new byte[] {161, 30, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showException(Exception t) => this.showException("", t);

    [LineNumberTable(new byte[] {26, 102, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UI() => Fonts.loadFonts();

    [LineNumberTable(new byte[] {161, 15, 236, 75, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showErrorMessage(string text) => new UI.\u0036(this, "", text).show();

    [LineNumberTable(new byte[] {160, 236, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showInfo(string info) => this.showInfo(info, (Runnable) new UI.__\u003C\u003EAnon14());

    [LineNumberTable(new byte[] {161, 184, 104, 108, 104, 108, 104, 108, 104, 105, 101, 105, 101, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int roundAmount(int number)
    {
      if (number >= 1000000000)
        return Mathf.round(number, 100000000);
      if (number >= 1000000)
        return Mathf.round(number, 100000);
      if (number >= 10000)
        return Mathf.round(number, 1000);
      if (number >= 1000 || number >= 100)
        return Mathf.round(number, 100);
      return number >= 10 ? Mathf.round(number, 10) : number;
    }

    [LineNumberTable(new byte[] {161, 169, 103, 104, 127, 40, 104, 127, 40, 104, 127, 32, 104, 159, 40})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string formatAmount(int number)
    {
      int num = Math.abs(number);
      if (num >= 1000000000)
        return new StringBuilder().append(Strings.@fixed((float) number / 1E+09f, 1)).append("[gray]").append(Core.bundle.get("unit.billions")).append("[]").toString();
      if (num >= 1000000)
        return new StringBuilder().append(Strings.@fixed((float) number / 1000000f, 1)).append("[gray]").append(Core.bundle.get("unit.millions")).append("[]").toString();
      if (num >= 10000)
        return new StringBuilder().append(number / 1000).append("[gray]").append(Core.bundle.get("unit.thousands")).append("[]").toString();
      return num >= 1000 ? new StringBuilder().append(Strings.@fixed((float) number / 1000f, 1)).append("[gray]").append(Core.bundle.get("unit.thousands")).append("[]").toString() : new StringBuilder().append(number).append("").toString();
    }

    [LineNumberTable(new byte[] {160, 120, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegionDrawable getIcon(string name, string def) => Icon.__\u003C\u003Eicons.containsKey((object) name) ? (TextureRegionDrawable) Icon.__\u003C\u003Eicons.get((object) name) : this.getIcon(def);

    [LineNumberTable(new byte[] {161, 146, 112, 107, 127, 19, 114, 127, 4, 102, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void announce(string text, float duration)
    {
      Table.__\u003Cclinit\u003E();
      Table table1 = new Table(Styles.black3);
      table1.touchable = Touchable.__\u003C\u003Edisabled;
      Table table2 = table1.margin(8f);
      object obj = (object) text;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text1 = charSequence;
      table2.add(text1).style((Style) Styles.outlineLabel).labelAlign(1);
      table1.update((Runnable) new UI.__\u003C\u003EAnon21(table1));
      table1.actions((arc.scene.Action) Actions.fadeOut(duration, (Interp) Interp.pow4In), (arc.scene.Action) Actions.remove());
      table1.pack();
      table1.act(0.1f);
      Core.scene.add((Element) table1);
    }

    [LineNumberTable(new byte[] {161, 34, 107, 237, 83, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showException(string text, Exception exc)
    {
      this.loadfrag.hide();
      new UI.\u0037(this, "", exc, text).show();
    }

    [LineNumberTable(new byte[] {161, 58, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showText(string titleText, string text) => this.showText(titleText, text, 1);

    [LineNumberTable(new byte[] {161, 62, 233, 72, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showText(string titleText, string text, int align) => new UI.\u0038(this, titleText, text, align).show();

    [LineNumberTable(new byte[] {161, 141, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void announce(string text) => this.announce(text, 3f);

    [LineNumberTable(new byte[] {160, 205, 102, 103, 107, 178, 126, 127, 15, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showInfoPopup(
      string info,
      float duration,
      int align,
      int top,
      int left,
      int bottom,
      int right)
    {
      Table table = new Table();
      table.setFillParent(true);
      table.touchable = Touchable.__\u003C\u003Edisabled;
      table.update((Runnable) new UI.__\u003C\u003EAnon11(table));
      table.actions((arc.scene.Action) Actions.delay(duration), (arc.scene.Action) Actions.remove());
      table.align(align).table(Styles.black3, (Cons) new UI.__\u003C\u003EAnon12(info)).pad((float) top, (float) left, (float) bottom, (float) right);
      Core.scene.add((Element) table);
    }

    [LineNumberTable(new byte[] {160, 218, 122, 107, 247, 69, 126, 127, 3, 102, 139, 145, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showLabel(string info, float duration, float worldx, float worldy)
    {
      Table.__\u003Cclinit\u003E();
      Table table1 = new Table(Styles.black3).margin(4f);
      table1.touchable = Touchable.__\u003C\u003Edisabled;
      table1.update((Runnable) new UI.__\u003C\u003EAnon13(table1, worldx, worldy));
      table1.actions((arc.scene.Action) Actions.delay(duration), (arc.scene.Action) Actions.remove());
      Table table2 = table1;
      object obj = (object) info;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table2.add(text).style((Style) Styles.outlineLabel);
      table1.pack();
      table1.act(0.0f);
      Core.scene.__\u003C\u003Eroot.addChildAt(0, (Element) table1);
      ((Element) table1.getChildren().first()).act(0.0f);
    }

    [LineNumberTable(new byte[] {160, 192, 102, 103, 107, 178, 127, 28, 127, 7, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showInfoToast(string info, float duration)
    {
      Table table = new Table();
      table.setFillParent(true);
      table.touchable = Touchable.__\u003C\u003Edisabled;
      table.update((Runnable) new UI.__\u003C\u003EAnon9(table));
      table.actions((arc.scene.Action) Actions.delay(duration * 0.9f), (arc.scene.Action) Actions.fadeOut(duration * 0.1f, Interp.fade), (arc.scene.Action) Actions.remove());
      table.top().table(Styles.black3, (Cons) new UI.__\u003C\u003EAnon10(info)).padTop(10f);
      Core.scene.add((Element) table);
    }

    [LineNumberTable(new byte[] {161, 82, 232, 70, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showSmall(string titleText, string text) => new UI.\u00310(this, titleText, text).show();

    [LineNumberTable(new byte[] {160, 182, 102, 107, 103, 127, 7, 127, 18, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showInfoFade(string info)
    {
      Table table1 = new Table();
      table1.touchable = Touchable.__\u003C\u003Edisabled;
      table1.setFillParent(true);
      table1.actions((arc.scene.Action) Actions.fadeOut(7f, Interp.fade), (arc.scene.Action) Actions.remove());
      Table table2 = table1.top();
      object obj = (object) info;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table2.add(text).style((Style) Styles.outlineLabel).padTop(10f);
      Core.scene.add((Element) table1);
    }

    [LineNumberTable(new byte[] {160, 115, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegionDrawable getIcon(string name) => Icon.__\u003C\u003Eicons.containsKey((object) name) ? (TextureRegionDrawable) Icon.__\u003C\u003Eicons.get((object) name) : (TextureRegionDrawable) Core.atlas.getDrawable("error");

    [LineNumberTable(new byte[] {160, 129, 108, 215})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadAnd(string text, Runnable call)
    {
      this.loadfrag.show(text);
      Time.runTask(7f, (Runnable) new UI.__\u003C\u003EAnon8(this, call));
    }

    [Signature("(Ljava/lang/String;Ljava/lang/String;ILjava/lang/String;Larc/func/Cons<Ljava/lang/String;>;)V")]
    [LineNumberTable(new byte[] {160, 178, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showTextInput(
      string titleText,
      string text,
      int textLength,
      string def,
      Cons confirmed)
    {
      this.showTextInput(titleText, text, textLength, def, false, confirmed);
    }

    [Signature("(Ljava/lang/String;Ljava/lang/String;ILjava/lang/String;ZLarc/func/Cons<Ljava/lang/String;>;)V")]
    [LineNumberTable(new byte[] {159, 80, 163, 103, 249, 72, 239, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showTextInput(
      string titleText,
      string dtext,
      int textLength,
      string def,
      bool inumeric,
      Cons confirmed)
    {
      int num = inumeric ? 1 : 0;
      if (Vars.mobile)
      {
        Core.input.getTextInput((Input.TextInput) new UI.\u0031(this, titleText, def, num != 0, textLength, confirmed));
      }
      else
      {
        UI.\u0032 obj = new UI.\u0032(this, titleText, dtext, num != 0, def, textLength, confirmed);
      }
    }

    [LineNumberTable(new byte[] {160, 240, 237, 72, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showInfo(string info, Runnable listener) => new UI.\u0033(this, "", info, listener).show();

    [LineNumberTable(new byte[] {161, 96, 103, 127, 53, 127, 6, 103, 127, 4, 222, 99, 243, 70, 216, 125, 125, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showConfirm(string title, string text, Boolp hide, Runnable confirmed)
    {
      BaseDialog baseDialog1 = new BaseDialog(title);
      Table cont = baseDialog1.__\u003C\u003Econt;
      object obj = (object) text;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text1 = charSequence;
      ((Label) cont.add(text1).width(!Vars.mobile ? 500f : 400f).wrap().pad(4f).get()).setAlignment(1, 1);
      baseDialog1.__\u003C\u003Ebuttons.defaults().size(200f, 54f).pad(2f);
      baseDialog1.setFillParent(false);
      Table buttons = baseDialog1.__\u003C\u003Ebuttons;
      BaseDialog baseDialog2 = baseDialog1;
      Objects.requireNonNull((object) baseDialog2);
      Runnable listener = (Runnable) new UI.__\u003C\u003EAnon15(baseDialog2);
      buttons.button("@cancel", listener);
      baseDialog1.__\u003C\u003Ebuttons.button("@ok", (Runnable) new UI.__\u003C\u003EAnon16(baseDialog1, confirmed));
      if (hide != null)
        baseDialog1.update((Runnable) new UI.__\u003C\u003EAnon17(hide, baseDialog1));
      baseDialog1.keyDown(KeyCode.__\u003C\u003Eenter, (Runnable) new UI.__\u003C\u003EAnon18(baseDialog1, confirmed));
      BaseDialog baseDialog3 = baseDialog1;
      KeyCode escape = KeyCode.__\u003C\u003Eescape;
      BaseDialog baseDialog4 = baseDialog1;
      Objects.requireNonNull((object) baseDialog4);
      Runnable l1 = (Runnable) new UI.__\u003C\u003EAnon15(baseDialog4);
      baseDialog3.keyDown(escape, l1);
      BaseDialog baseDialog5 = baseDialog1;
      KeyCode back = KeyCode.__\u003C\u003Eback;
      BaseDialog baseDialog6 = baseDialog1;
      Objects.requireNonNull((object) baseDialog6);
      Runnable l2 = (Runnable) new UI.__\u003C\u003EAnon15(baseDialog6);
      baseDialog5.keyDown(back, l2);
      baseDialog1.show();
    }

    [Modifiers]
    [LineNumberTable(91)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadSync\u00240([In] Font obj0) => obj0.setUseIntegerPositions(true);

    [Modifiers]
    [LineNumberTable(107)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static arc.scene.Action lambda\u0024loadSync\u00241() => (arc.scene.Action) Actions.sequence((arc.scene.Action) Actions.alpha(0.0f), (arc.scene.Action) Actions.fadeIn(0.1f));

    [Modifiers]
    [LineNumberTable(108)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static arc.scene.Action lambda\u0024loadSync\u00242() => (arc.scene.Action) Actions.sequence((arc.scene.Action) Actions.fadeOut(0.1f));

    [Modifiers]
    [LineNumberTable(111)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Tooltip lambda\u0024loadSync\u00244([In] string obj0)
    {
      Tooltip.__\u003Cclinit\u003E();
      return new Tooltip((Cons) new UI.__\u003C\u003EAnon24(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {64, 102, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024loadSync\u00246([In] Exception obj0)
    {
      Log.err(obj0);
      Core.app.post((Runnable) new UI.__\u003C\u003EAnon23(this));
    }

    [Modifiers]
    [LineNumberTable(118)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadSync\u00247() => Sounds.press.play();

    [Modifiers]
    [LineNumberTable(196)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024init\u00248() => Vars.state.isMenu();

    [Modifiers]
    [LineNumberTable(199)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024init\u00249() => Vars.state.isGame();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 131, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024loadAnd\u002410([In] Runnable obj0)
    {
      obj0.run();
      this.loadfrag.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 196, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showInfoToast\u002411([In] Table obj0)
    {
      if (!Vars.state.isMenu())
        return;
      obj0.remove();
    }

    [Modifiers]
    [LineNumberTable(313)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showInfoToast\u002412([In] string obj0, [In] Table obj1)
    {
      Table table = obj1.margin(4f);
      object obj = (object) obj0;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).style((Style) Styles.outlineLabel);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 209, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showInfoPopup\u002413([In] Table obj0)
    {
      if (!Vars.state.isMenu())
        return;
      obj0.remove();
    }

    [Modifiers]
    [LineNumberTable(326)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showInfoPopup\u002414([In] string obj0, [In] Table obj1)
    {
      Table table = obj1.margin(4f);
      object obj = (object) obj0;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).style((Style) Styles.outlineLabel);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 221, 115, 111, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showLabel\u002415([In] Table obj0, [In] float obj1, [In] float obj2)
    {
      if (Vars.state.isMenu())
        obj0.remove();
      Vec2 vec2 = Core.camera.project(obj1, obj2);
      obj0.setPosition(vec2.x, vec2.y, 1);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showInfo\u002416()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 102, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showConfirm\u002417([In] BaseDialog obj0, [In] Runnable obj1)
    {
      obj0.hide();
      obj1.run();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 107, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showConfirm\u002418([In] Boolp obj0, [In] BaseDialog obj1)
    {
      if (!obj0.get())
        return;
      obj1.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 113, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showConfirm\u002419([In] BaseDialog obj0, [In] Runnable obj1)
    {
      obj0.hide();
      obj1.run();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 127, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showCustomConfirm\u002420([In] BaseDialog obj0, [In] Runnable obj1)
    {
      obj0.hide();
      obj1.run();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 131, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showCustomConfirm\u002421([In] BaseDialog obj0, [In] Runnable obj1)
    {
      obj0.hide();
      obj1.run();
    }

    [Modifiers]
    [LineNumberTable(519)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024announce\u002422([In] Table obj0) => obj0.setPosition((float) Core.graphics.getWidth() / 2f, (float) Core.graphics.getHeight() / 2f, 1);

    [Modifiers]
    [LineNumberTable(new byte[] {161, 162, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showOkText\u002423([In] BaseDialog obj0, [In] Runnable obj1)
    {
      obj0.hide();
      obj1.run();
    }

    [Modifiers]
    [LineNumberTable(115)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024loadSync\u00245() => this.showErrorMessage("Failed to access local storage.\nSettings will not be saved.");

    [Modifiers]
    [LineNumberTable(111)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadSync\u00243([In] string obj0, [In] Table obj1)
    {
      Table table = obj1.background(Styles.black6).margin(4f);
      object obj = (object) obj0;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadAsync()
    {
    }

    [LineNumberTable(new byte[] {37, 112, 112, 139, 127, 4, 106, 143, 107, 110, 110, 110, 142, 101, 101, 101, 101, 133, 111, 143, 107, 148, 245, 69, 143, 112, 117, 127, 5, 144, 122, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadSync()
    {
      Fonts.outline.getData().markupEnabled = true;
      Fonts.def.getData().markupEnabled = true;
      Fonts.def.setOwnsTexture(false);
      Core.assets.getAll((Class) ClassLiteral<Font>.Value, new Seq()).each((Cons) new UI.__\u003C\u003EAnon0());
      Core.scene = new Scene();
      Core.input.addProcessor((InputProcessor) Core.scene);
      int[] safeInsets = Core.graphics.getSafeInsets();
      Core.scene.marginLeft = (float) safeInsets[0];
      Core.scene.marginRight = (float) safeInsets[1];
      Core.scene.marginTop = (float) safeInsets[2];
      Core.scene.marginBottom = (float) safeInsets[3];
      Tex.load();
      Icon.load();
      Styles.load();
      Tex.loadStyles();
      Fonts.loadContentIcons();
      Dialog.setShowAction((Prov) new UI.__\u003C\u003EAnon1());
      Dialog.setHideAction((Prov) new UI.__\u003C\u003EAnon2());
      Tooltip.Tooltips.getInstance().animations = false;
      Tooltip.Tooltips.getInstance().textProvider = (Func) new UI.__\u003C\u003EAnon3();
      Core.settings.setErrorHandler((Cons) new UI.__\u003C\u003EAnon4(this));
      ClickListener.clicked = (Runnable) new UI.__\u003C\u003EAnon5();
      Colors.put("accent", Pal.accent);
      Colors.put("unlaunched", Color.valueOf("8982ed"));
      Colors.put("highlight", Pal.accent.cpy().lerp(Color.__\u003C\u003Ewhite, 0.3f));
      Colors.put("stat", Pal.stat);
      this.drillCursor = Core.graphics.newCursor("drill", Fonts.cursorScale());
      this.unloadCursor = Core.graphics.newCursor("unload", Fonts.cursorScale());
    }

    [Signature("()Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    [LineNumberTable(131)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getDependencies() => Seq.with((object[]) new AssetDescriptor[4]
    {
      new AssetDescriptor((Class) ClassLiteral<Control>.Value),
      new AssetDescriptor("outline", (Class) ClassLiteral<Font>.Value),
      new AssetDescriptor("default", (Class) ClassLiteral<Font>.Value),
      new AssetDescriptor("chat", (Class) ClassLiteral<Font>.Value)
    });

    [LineNumberTable(new byte[] {86, 143, 138, 106, 138, 127, 3, 127, 3, 104, 204, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (Vars.disableUI || Core.scene == null)
        return;
      Events.fire((object) EventType.Trigger.__\u003C\u003EuiDrawBegin);
      Core.scene.act();
      Core.scene.draw();
      if (Core.input.keyTap(KeyCode.__\u003C\u003EmouseLeft) && Core.scene.getKeyboardFocus() is TextField && !(Core.scene.hit((float) Core.input.mouseX(), (float) Core.input.mouseY(), true) is TextField))
        Core.scene.setKeyboardFocus((Element) null);
      Events.fire((object) EventType.Trigger.__\u003C\u003EuiDrawEnd);
    }

    [LineNumberTable(new byte[] {105, 107, 139, 107, 107, 107, 107, 107, 107, 107, 139, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 139, 139, 108, 112, 118, 108, 112, 150, 112, 144, 113, 113, 118, 113, 113, 118, 108, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void init()
    {
      this.menuGroup = new WidgetGroup();
      this.hudGroup = new WidgetGroup();
      this.menufrag = new MenuFragment();
      this.hudfrag = new HudFragment();
      this.hints = new HintsFragment();
      this.chatfrag = new ChatFragment();
      this.minimapfrag = new MinimapFragment();
      this.listfrag = new PlayerListFragment();
      this.loadfrag = new LoadingFragment();
      this.scriptfrag = new ScriptConsoleFragment();
      this.picker = new ColorPicker();
      this.editor = new MapEditorDialog();
      this.controls = new ControlsDialog();
      this.restart = new GameOverDialog();
      this.join = new JoinDialog();
      this.discord = new DiscordDialog();
      this.load = new LoadDialog();
      this.custom = new CustomGameDialog();
      this.language = new LanguageDialog();
      this.database = new DatabaseDialog();
      this.settings = new SettingsMenuDialog();
      this.host = new HostDialog();
      this.paused = new PausedDialog();
      this.about = new AboutDialog();
      this.bans = new BansDialog();
      this.admins = new AdminsDialog();
      this.traces = new TraceDialog();
      this.maps = new MapsDialog();
      this.content = new ContentInfoDialog();
      this.planet = new PlanetDialog();
      this.research = new ResearchDialog();
      this.mods = new ModsDialog();
      this.schematics = new SchematicsDialog();
      this.logic = new LogicDialog();
      Group root = Core.scene.__\u003C\u003Eroot;
      this.menuGroup.setFillParent(true);
      this.menuGroup.touchable = Touchable.__\u003C\u003EchildrenOnly;
      this.menuGroup.visible((Boolp) new UI.__\u003C\u003EAnon6());
      this.hudGroup.setFillParent(true);
      this.hudGroup.touchable = Touchable.__\u003C\u003EchildrenOnly;
      this.hudGroup.visible((Boolp) new UI.__\u003C\u003EAnon7());
      Core.scene.add((Element) this.menuGroup);
      Core.scene.add((Element) this.hudGroup);
      this.hudfrag.build((Group) this.hudGroup);
      this.menufrag.build((Group) this.menuGroup);
      this.chatfrag.container().build((Group) this.hudGroup);
      this.minimapfrag.build((Group) this.hudGroup);
      this.listfrag.build((Group) this.hudGroup);
      this.scriptfrag.container().build((Group) this.hudGroup);
      this.loadfrag.build(root);
      new FadeInFragment().build(root);
    }

    [LineNumberTable(new byte[] {160, 102, 136, 107, 110, 110, 110, 142, 108, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resize(int width, int height)
    {
      if (Core.scene == null)
        return;
      int[] safeInsets = Core.graphics.getSafeInsets();
      Core.scene.marginLeft = (float) safeInsets[0];
      Core.scene.marginRight = (float) safeInsets[1];
      Core.scene.marginTop = (float) safeInsets[2];
      Core.scene.marginBottom = (float) safeInsets[3];
      Core.scene.resize(width, height);
      Events.fire((object) new EventType.ResizeEvent());
    }

    [Signature("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Larc/func/Cons<Ljava/lang/String;>;)V")]
    [LineNumberTable(new byte[] {160, 174, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showTextInput(string title, string text, string def, Cons confirmed) => this.showTextInput(title, text, 32, def, confirmed);

    [LineNumberTable(new byte[] {160, 252, 237, 70, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showInfoOnHidden(string info, Runnable listener) => new UI.\u0034(this, "", info, listener).show();

    [LineNumberTable(new byte[] {161, 6, 236, 69, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showStartupInfo(string info) => new UI.\u0035(this, "", info).show();

    [LineNumberTable(new byte[] {161, 74, 200, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showInfoText(string titleText, string text) => new UI.\u0039(this, titleText, text).show();

    [LineNumberTable(new byte[] {161, 92, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showConfirm(string title, string text, Runnable confirmed) => this.showConfirm(title, text, (Boolp) null, confirmed);

    [LineNumberTable(new byte[] {161, 122, 103, 127, 53, 127, 6, 103, 219, 218, 125, 125, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showCustomConfirm(
      string title,
      string text,
      string yes,
      string no,
      Runnable confirmed,
      Runnable denied)
    {
      BaseDialog baseDialog1 = new BaseDialog(title);
      Table cont = baseDialog1.__\u003C\u003Econt;
      object obj = (object) text;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text1 = charSequence;
      ((Label) cont.add(text1).width(!Vars.mobile ? 500f : 400f).wrap().pad(4f).get()).setAlignment(1, 1);
      baseDialog1.__\u003C\u003Ebuttons.defaults().size(200f, 54f).pad(2f);
      baseDialog1.setFillParent(false);
      baseDialog1.__\u003C\u003Ebuttons.button(no, (Runnable) new UI.__\u003C\u003EAnon19(baseDialog1, denied));
      baseDialog1.__\u003C\u003Ebuttons.button(yes, (Runnable) new UI.__\u003C\u003EAnon20(baseDialog1, confirmed));
      BaseDialog baseDialog2 = baseDialog1;
      KeyCode escape = KeyCode.__\u003C\u003Eescape;
      BaseDialog baseDialog3 = baseDialog1;
      Objects.requireNonNull((object) baseDialog3);
      Runnable l1 = (Runnable) new UI.__\u003C\u003EAnon15(baseDialog3);
      baseDialog2.keyDown(escape, l1);
      BaseDialog baseDialog4 = baseDialog1;
      KeyCode back = KeyCode.__\u003C\u003Eback;
      BaseDialog baseDialog5 = baseDialog1;
      Objects.requireNonNull((object) baseDialog5);
      Runnable l2 = (Runnable) new UI.__\u003C\u003EAnon15(baseDialog5);
      baseDialog4.keyDown(back, l2);
      baseDialog1.show();
    }

    [LineNumberTable(new byte[] {161, 157, 103, 127, 39, 127, 6, 103, 221, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showOkText(string title, string text, Runnable confirmed)
    {
      BaseDialog baseDialog = new BaseDialog(title);
      Table cont = baseDialog.__\u003C\u003Econt;
      object obj = (object) text;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text1 = charSequence;
      ((Label) cont.add(text1).width(500f).wrap().pad(4f).get()).setAlignment(1, 1);
      baseDialog.__\u003C\u003Ebuttons.defaults().size(200f, 54f).pad(2f);
      baseDialog.setFillParent(false);
      baseDialog.__\u003C\u003Ebuttons.button("@ok", (Runnable) new UI.__\u003C\u003EAnon22(baseDialog, confirmed));
      baseDialog.show();
    }

    [HideFromJava]
    public virtual void pause() => ApplicationListener.\u003Cdefault\u003Epause((ApplicationListener) this);

    [HideFromJava]
    public virtual void resume() => ApplicationListener.\u003Cdefault\u003Eresume((ApplicationListener) this);

    [HideFromJava]
    public virtual void dispose() => ApplicationListener.\u003Cdefault\u003Edispose((ApplicationListener) this);

    [HideFromJava]
    public virtual void exit() => ApplicationListener.\u003Cdefault\u003Eexit((ApplicationListener) this);

    [HideFromJava]
    public virtual void fileDropped([In] Fi obj0) => ApplicationListener.\u003Cdefault\u003EfileDropped((ApplicationListener) this, obj0);

    [HideFromJava]
    public virtual string getName() => Loadable.\u003Cdefault\u003EgetName((Loadable) this);

    [EnclosingMethod(null, "showTextInput", "(Ljava.lang.String;Ljava.lang.String;ILjava.lang.String;ZLarc.func.Cons;)V")]
    [SpecialName]
    internal class \u0031 : Input.TextInput
    {
      [Modifiers]
      internal string val\u0024titleText;
      [Modifiers]
      internal string val\u0024def;
      [Modifiers]
      internal bool val\u0024inumeric;
      [Modifiers]
      internal int val\u0024textLength;
      [Modifiers]
      internal Cons val\u0024confirmed;
      [Modifiers]
      internal UI this\u00240;

      [LineNumberTable(new byte[] {159, 79, 67, 127, 21, 127, 23, 108, 108, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] UI obj0, [In] string obj1, [In] string obj2, [In] bool obj3, [In] int obj4, [In] Cons obj5)
      {
        int num = obj3 ? 1 : 0;
        this.this\u00240 = obj0;
        this.val\u0024titleText = obj1;
        this.val\u0024def = obj2;
        this.val\u0024inumeric = num != 0;
        this.val\u0024textLength = obj4;
        this.val\u0024confirmed = obj5;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        UI.\u0031 obj = this;
        this.title = !String.instancehelper_startsWith(this.val\u0024titleText, "@") ? this.val\u0024titleText : Core.bundle.get(String.instancehelper_substring(this.val\u0024titleText, 1));
        this.text = this.val\u0024def;
        this.numeric = this.val\u0024inumeric;
        this.maxLength = this.val\u0024textLength;
        this.accepted = this.val\u0024confirmed;
      }
    }

    [EnclosingMethod(null, "showSmall", "(Ljava.lang.String;Ljava.lang.String;)V")]
    [SpecialName]
    internal class \u00310 : Dialog
    {
      [Modifiers]
      internal string val\u0024text;
      [Modifiers]
      internal UI this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 82, 119, 127, 13, 108, 127, 16, 127, 22, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00310([In] UI obj0, [In] string obj1, [In] string obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024text = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UI.\u00310 obj = this;
        Table table = this.__\u003C\u003Econt.margin(10f);
        object valText = (object) this.val\u0024text;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) valText;
        CharSequence text = charSequence;
        table.add(text);
        this.__\u003C\u003EtitleTable.row();
        this.__\u003C\u003EtitleTable.image().color(Pal.accent).height(3f).growX().pad(2f);
        this.__\u003C\u003Ebuttons.button("@ok", (Runnable) new UI.\u00310.__\u003C\u003EAnon0(this)).size(110f, 50f).pad(4f);
        this.closeOnBack();
      }

      [HideFromJava]
      static \u00310() => Dialog.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly UI.\u00310 arg\u00241;

        internal __\u003C\u003EAnon0([In] UI.\u00310 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.hide();
      }
    }

    [EnclosingMethod(null, "showTextInput", "(Ljava.lang.String;Ljava.lang.String;ILjava.lang.String;ZLarc.func.Cons;)V")]
    [SpecialName]
    internal class \u0032 : Dialog
    {
      [Modifiers]
      internal string val\u0024dtext;
      [Modifiers]
      internal bool val\u0024inumeric;
      [Modifiers]
      internal string val\u0024def;
      [Modifiers]
      internal int val\u0024textLength;
      [Modifiers]
      internal Cons val\u0024confirmed;
      [Modifiers]
      internal UI this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 77, 67, 127, 23, 127, 23, 123, 127, 23, 123, 127, 6, 124, 191, 16, 102, 254, 71, 118, 118, 103, 109, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032(
        [In] UI obj0,
        [In] string obj1,
        [In] string obj2,
        [In] bool obj3,
        [In] string obj4,
        [In] int obj5,
        [In] Cons obj6)
      {
        int num = obj3 ? 1 : 0;
        this.this\u00240 = obj0;
        this.val\u0024dtext = obj2;
        this.val\u0024inumeric = num != 0;
        this.val\u0024def = obj4;
        this.val\u0024textLength = obj5;
        this.val\u0024confirmed = obj6;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UI.\u0032 obj = this;
        Table table = this.__\u003C\u003Econt.margin(30f);
        object valDtext = (object) this.val\u0024dtext;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) valDtext;
        CharSequence text = charSequence;
        table.add(text).padRight(6f);
        TextField.TextFieldFilter textFieldFilter = !this.val\u0024inumeric ? (TextField.TextFieldFilter) new UI.\u0032.__\u003C\u003EAnon0() : TextField.TextFieldFilter.digitsOnly;
        TextField textField = (TextField) this.__\u003C\u003Econt.field(this.val\u0024def, (Cons) new UI.\u0032.__\u003C\u003EAnon1()).size(330f, 50f).get();
        textField.setFilter((TextField.TextFieldFilter) new UI.\u0032.__\u003C\u003EAnon2(textField, this.val\u0024textLength, textFieldFilter));
        this.__\u003C\u003Ebuttons.defaults().size(120f, 54f).pad(4f);
        this.__\u003C\u003Ebuttons.button("@cancel", (Runnable) new UI.\u0032.__\u003C\u003EAnon3(this));
        this.__\u003C\u003Ebuttons.button("@ok", (Runnable) new UI.\u0032.__\u003C\u003EAnon4(this, this.val\u0024confirmed, textField)).disabled((Boolf) new UI.\u0032.__\u003C\u003EAnon5(textField));
        this.keyDown(KeyCode.__\u003C\u003Eenter, (Runnable) new UI.\u0032.__\u003C\u003EAnon6(this, textField, this.val\u0024confirmed));
        this.keyDown(KeyCode.__\u003C\u003Eescape, (Runnable) new UI.\u0032.__\u003C\u003EAnon3(this));
        this.keyDown(KeyCode.__\u003C\u003Eback, (Runnable) new UI.\u0032.__\u003C\u003EAnon3(this));
        this.show();
        Core.scene.setKeyboardFocus((Element) textField);
        textField.setCursorPosition(String.instancehelper_length(this.val\u0024def));
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024new\u00240([In] TextField obj0, [In] char obj1) => true;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024new\u00241([In] string obj0)
      {
      }

      [Modifiers]
      [LineNumberTable(264)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024new\u00242(
        [In] TextField obj0,
        [In] int obj1,
        [In] TextField.TextFieldFilter obj2,
        [In] TextField obj3,
        [In] char obj4)
      {
        int num = (int) obj4;
        return String.instancehelper_length(obj0.getText()) < obj1 && obj2.acceptChar(obj3, (char) num);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {160, 154, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00243([In] Cons obj0, [In] TextField obj1)
      {
        obj0.get((object) obj1.getText());
        this.hide();
      }

      [Modifiers]
      [LineNumberTable(270)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024new\u00244([In] TextField obj0, [In] TextButton obj1) => String.instancehelper_isEmpty(obj0.getText());

      [Modifiers]
      [LineNumberTable(new byte[] {160, 158, 103, 104, 103, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00245([In] TextField obj0, [In] Cons obj1)
      {
        string text = obj0.getText();
        if (String.instancehelper_isEmpty(text))
          return;
        obj1.get((object) text);
        this.hide();
      }

      [HideFromJava]
      static \u0032() => Dialog.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : TextField.TextFieldFilter
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public bool acceptChar([In] TextField obj0, [In] char obj1) => (UI.\u0032.lambda\u0024new\u00240(obj0, obj1) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public void get([In] object obj0) => UI.\u0032.lambda\u0024new\u00241((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : TextField.TextFieldFilter
      {
        private readonly TextField arg\u00241;
        private readonly int arg\u00242;
        private readonly TextField.TextFieldFilter arg\u00243;

        internal __\u003C\u003EAnon2([In] TextField obj0, [In] int obj1, [In] TextField.TextFieldFilter obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public bool acceptChar([In] TextField obj0, [In] char obj1) => (UI.\u0032.lambda\u0024new\u00242(this.arg\u00241, this.arg\u00242, this.arg\u00243, obj0, obj1) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Runnable
      {
        private readonly UI.\u0032 arg\u00241;

        internal __\u003C\u003EAnon3([In] UI.\u0032 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.hide();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Runnable
      {
        private readonly UI.\u0032 arg\u00241;
        private readonly Cons arg\u00242;
        private readonly TextField arg\u00243;

        internal __\u003C\u003EAnon4([In] UI.\u0032 obj0, [In] Cons obj1, [In] TextField obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024new\u00243(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon5 : Boolf
      {
        private readonly TextField arg\u00241;

        internal __\u003C\u003EAnon5([In] TextField obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (UI.\u0032.lambda\u0024new\u00244(this.arg\u00241, (TextButton) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon6 : Runnable
      {
        private readonly UI.\u0032 arg\u00241;
        private readonly TextField arg\u00242;
        private readonly Cons arg\u00243;

        internal __\u003C\u003EAnon6([In] UI.\u0032 obj0, [In] TextField obj1, [In] Cons obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024new\u00245(this.arg\u00242, this.arg\u00243);
      }
    }

    [EnclosingMethod(null, "showInfo", "(Ljava.lang.String;Ljava.lang.Runnable;)V")]
    [SpecialName]
    internal class \u0033 : Dialog
    {
      [Modifiers]
      internal string val\u0024info;
      [Modifiers]
      internal Runnable val\u0024listener;
      [Modifiers]
      internal UI this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 240, 127, 0, 114, 127, 44, 191, 12, 112, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] UI obj0, [In] string obj1, [In] string obj2, [In] Runnable obj3)
      {
        this.this\u00240 = obj0;
        this.val\u0024info = obj2;
        this.val\u0024listener = obj3;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UI.\u0033 obj = this;
        this.getCell((Element) this.__\u003C\u003Econt).growX();
        Table table = this.__\u003C\u003Econt.margin(15f);
        object valInfo = (object) this.val\u0024info;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) valInfo;
        CharSequence text = charSequence;
        ((Label) table.add(text).width(400f).wrap().get()).setAlignment(1, 1);
        this.__\u003C\u003Ebuttons.button("@ok", (Runnable) new UI.\u0033.__\u003C\u003EAnon0(this, this.val\u0024listener)).size(110f, 50f).pad(4f);
        this.closeOnBack();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {160, 244, 102, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00240([In] Runnable obj0)
      {
        this.hide();
        obj0.run();
      }

      [HideFromJava]
      static \u0033() => Dialog.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly UI.\u0033 arg\u00241;
        private readonly Runnable arg\u00242;

        internal __\u003C\u003EAnon0([In] UI.\u0033 obj0, [In] Runnable obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024new\u00240(this.arg\u00242);
      }
    }

    [EnclosingMethod(null, "showInfoOnHidden", "(Ljava.lang.String;Ljava.lang.Runnable;)V")]
    [SpecialName]
    internal class \u0034 : Dialog
    {
      [Modifiers]
      internal string val\u0024info;
      [Modifiers]
      internal Runnable val\u0024listener;
      [Modifiers]
      internal UI this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 252, 127, 0, 114, 127, 44, 127, 22, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034([In] UI obj0, [In] string obj1, [In] string obj2, [In] Runnable obj3)
      {
        this.this\u00240 = obj0;
        this.val\u0024info = obj2;
        this.val\u0024listener = obj3;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UI.\u0034 obj = this;
        this.getCell((Element) this.__\u003C\u003Econt).growX();
        Table table = this.__\u003C\u003Econt.margin(15f);
        object valInfo = (object) this.val\u0024info;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) valInfo;
        CharSequence text = charSequence;
        ((Label) table.add(text).width(400f).wrap().get()).setAlignment(1, 1);
        this.__\u003C\u003Ebuttons.button("@ok", (Runnable) new UI.\u0034.__\u003C\u003EAnon0(this)).size(110f, 50f).pad(4f);
        this.hidden(this.val\u0024listener);
        this.closeOnBack();
      }

      [HideFromJava]
      static \u0034() => Dialog.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly UI.\u0034 arg\u00241;

        internal __\u003C\u003EAnon0([In] UI.\u0034 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.hide();
      }
    }

    [EnclosingMethod(null, "showStartupInfo", "(Ljava.lang.String;)V")]
    [SpecialName]
    internal class \u0035 : Dialog
    {
      [Modifiers]
      internal string val\u0024info;
      [Modifiers]
      internal UI this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 6, 119, 114, 127, 43, 127, 22, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035([In] UI obj0, [In] string obj1, [In] string obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024info = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UI.\u0035 obj = this;
        this.getCell((Element) this.__\u003C\u003Econt).growX();
        Table table = this.__\u003C\u003Econt.margin(15f);
        object valInfo = (object) this.val\u0024info;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) valInfo;
        CharSequence text = charSequence;
        ((Label) table.add(text).width(400f).wrap().get()).setAlignment(8);
        this.__\u003C\u003Ebuttons.button("@ok", (Runnable) new UI.\u0035.__\u003C\u003EAnon0(this)).size(110f, 50f).pad(4f);
        this.closeOnBack();
      }

      [HideFromJava]
      static \u0035() => Dialog.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly UI.\u0035 arg\u00241;

        internal __\u003C\u003EAnon0([In] UI.\u0035 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.hide();
      }
    }

    [EnclosingMethod(null, "showErrorMessage", "(Ljava.lang.String;)V")]
    [SpecialName]
    internal class \u0036 : Dialog
    {
      [Modifiers]
      internal string val\u0024text;
      [Modifiers]
      internal UI this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 15, 119, 103, 113, 127, 2, 108, 127, 21, 108, 127, 38, 108, 127, 22, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0036([In] UI obj0, [In] string obj1, [In] string obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024text = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UI.\u0036 obj3 = this;
        this.setFillParent(true);
        this.__\u003C\u003Econt.margin(15f);
        Table cont1 = this.__\u003C\u003Econt;
        object obj4 = (object) "@error.title";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj4;
        CharSequence text1 = charSequence;
        cont1.add(text1);
        this.__\u003C\u003Econt.row();
        this.__\u003C\u003Econt.image().width(300f).pad(2f).height(4f).color(Color.__\u003C\u003Escarlet);
        this.__\u003C\u003Econt.row();
        Table cont2 = this.__\u003C\u003Econt;
        object valText = (object) this.val\u0024text;
        charSequence.__\u003Cref\u003E = (__Null) valText;
        CharSequence text2 = charSequence;
        ((Label) cont2.add(text2).pad(2f).growX().wrap().get()).setAlignment(1);
        this.__\u003C\u003Econt.row();
        this.__\u003C\u003Econt.button("@ok", (Runnable) new UI.\u0036.__\u003C\u003EAnon0(this)).size(120f, 50f).pad(4f);
        this.closeOnBack();
      }

      [HideFromJava]
      static \u0036() => Dialog.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly UI.\u0036 arg\u00241;

        internal __\u003C\u003EAnon0([In] UI.\u0036 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.hide();
      }
    }

    [EnclosingMethod(null, "showException", "(Ljava.lang.String;Ljava.lang.Throwable;)V")]
    [SpecialName]
    internal class \u0037 : Dialog
    {
      [Modifiers]
      internal Exception val\u0024exc;
      [Modifiers]
      internal string val\u0024text;
      [Modifiers]
      internal UI this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 35, 127, 0, 140, 103, 113, 127, 8, 108, 127, 27, 108, 127, 160, 83, 140, 157, 127, 52, 127, 22, 108, 126, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0037([In] UI obj0, [In] string obj1, [In] Exception obj2, [In] string obj3)
      {
        this.this\u00240 = obj0;
        this.val\u0024exc = obj2;
        this.val\u0024text = obj3;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UI.\u0037 obj4 = this;
        string finalMessage = Strings.getFinalMessage(this.val\u0024exc);
        this.setFillParent(true);
        this.__\u003C\u003Econt.margin(15f);
        Table cont1 = this.__\u003C\u003Econt;
        object obj5 = (object) "@error.title";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj5;
        CharSequence text1 = charSequence;
        cont1.add(text1).colspan(2);
        this.__\u003C\u003Econt.row();
        this.__\u003C\u003Econt.image().width(300f).pad(2f).colspan(2).height(4f).color(Color.__\u003C\u003Escarlet);
        this.__\u003C\u003Econt.row();
        Table cont2 = this.__\u003C\u003Econt;
        object obj6 = (object) new StringBuilder().append(!String.instancehelper_startsWith(this.val\u0024text, "@") ? this.val\u0024text : Core.bundle.get(String.instancehelper_substring(this.val\u0024text, 1))).append(finalMessage != null ? new StringBuilder().append("\n[lightgray](").append(finalMessage).append(")").toString() : "").toString();
        charSequence.__\u003Cref\u003E = (__Null) obj6;
        CharSequence text2 = charSequence;
        ((Label) cont2.add(text2).colspan(2).wrap().growX().center().get()).setAlignment(1);
        this.__\u003C\u003Econt.row();
        Collapser.__\u003Cclinit\u003E();
        Collapser collapser1 = new Collapser((Cons) new UI.\u0037.__\u003C\u003EAnon0(this.val\u0024exc), true);
        Table cont3 = this.__\u003C\u003Econt;
        TextButton.TextButtonStyle togglet = Styles.togglet;
        Collapser collapser2 = collapser1;
        Objects.requireNonNull((object) collapser2);
        Runnable listener = (Runnable) new UI.\u0037.__\u003C\u003EAnon1(collapser2);
        cont3.button("@details", togglet, listener).size(180f, 50f).@checked((Boolf) new UI.\u0037.__\u003C\u003EAnon2(collapser1)).fillX().right();
        this.__\u003C\u003Econt.button("@ok", (Runnable) new UI.\u0037.__\u003C\u003EAnon3(this)).size(110f, 50f).fillX().left();
        this.__\u003C\u003Econt.row();
        this.__\u003C\u003Econt.add((Element) collapser1).colspan(2).pad(2f);
        this.closeOnBack();
      }

      [Modifiers]
      [LineNumberTable(417)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024new\u00241([In] Exception obj0, [In] Table obj1) => obj1.pane((Cons) new UI.\u0037.__\u003C\u003EAnon4(obj0));

      [Modifiers]
      [LineNumberTable(419)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024new\u00242([In] Collapser obj0, [In] TextButton obj1) => !obj0.isCollapsed();

      [Modifiers]
      [LineNumberTable(417)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024new\u00240([In] Exception obj0, [In] Table obj1)
      {
        Table table = obj1.margin(14f);
        object obj = (object) Strings.neatError(obj0);
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table.add(text).color(Color.__\u003C\u003ElightGray).left();
      }

      [HideFromJava]
      static \u0037() => Dialog.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly Exception arg\u00241;

        internal __\u003C\u003EAnon0([In] Exception obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => UI.\u0037.lambda\u0024new\u00241(this.arg\u00241, (Table) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Runnable
      {
        private readonly Collapser arg\u00241;

        internal __\u003C\u003EAnon1([In] Collapser obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.toggle();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Boolf
      {
        private readonly Collapser arg\u00241;

        internal __\u003C\u003EAnon2([In] Collapser obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (UI.\u0037.lambda\u0024new\u00242(this.arg\u00241, (TextButton) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Runnable
      {
        private readonly UI.\u0037 arg\u00241;

        internal __\u003C\u003EAnon3([In] UI.\u0037 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.hide();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Cons
      {
        private readonly Exception arg\u00241;

        internal __\u003C\u003EAnon4([In] Exception obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => UI.\u0037.lambda\u0024new\u00240(this.arg\u00241, (Table) obj0);
      }
    }

    [EnclosingMethod(null, "showText", "(Ljava.lang.String;Ljava.lang.String;I)V")]
    [SpecialName]
    internal class \u0038 : Dialog
    {
      [Modifiers]
      internal string val\u0024text;
      [Modifiers]
      internal int val\u0024align;
      [Modifiers]
      internal UI this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 62, 127, 0, 108, 127, 27, 108, 127, 44, 108, 127, 22, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0038([In] UI obj0, [In] string obj1, [In] string obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        this.val\u0024text = obj2;
        this.val\u0024align = obj3;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UI.\u0038 obj = this;
        this.__\u003C\u003Econt.row();
        this.__\u003C\u003Econt.image().width(400f).pad(2f).colspan(2).height(4f).color(Pal.accent);
        this.__\u003C\u003Econt.row();
        Table cont = this.__\u003C\u003Econt;
        object valText = (object) this.val\u0024text;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) valText;
        CharSequence text = charSequence;
        ((Label) cont.add(text).width(400f).wrap().get()).setAlignment(this.val\u0024align, this.val\u0024align);
        this.__\u003C\u003Econt.row();
        this.__\u003C\u003Ebuttons.button("@ok", (Runnable) new UI.\u0038.__\u003C\u003EAnon0(this)).size(110f, 50f).pad(4f);
        this.closeOnBack();
      }

      [HideFromJava]
      static \u0038() => Dialog.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly UI.\u0038 arg\u00241;

        internal __\u003C\u003EAnon0([In] UI.\u0038 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.hide();
      }
    }

    [EnclosingMethod(null, "showInfoText", "(Ljava.lang.String;Ljava.lang.String;)V")]
    [SpecialName]
    internal class \u0039 : Dialog
    {
      [Modifiers]
      internal string val\u0024text;
      [Modifiers]
      internal UI this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 74, 119, 127, 49, 127, 22, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0039([In] UI obj0, [In] string obj1, [In] string obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024text = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        UI.\u0039 obj = this;
        Table table = this.__\u003C\u003Econt.margin(15f);
        object valText = (object) this.val\u0024text;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) valText;
        CharSequence text = charSequence;
        ((Label) table.add(text).width(400f).wrap().left().get()).setAlignment(8, 8);
        this.__\u003C\u003Ebuttons.button("@ok", (Runnable) new UI.\u0039.__\u003C\u003EAnon0(this)).size(110f, 50f).pad(4f);
        this.closeOnBack();
      }

      [HideFromJava]
      static \u0039() => Dialog.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly UI.\u0039 arg\u00241;

        internal __\u003C\u003EAnon0([In] UI.\u0039 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.hide();
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => UI.lambda\u0024loadSync\u00240((Font) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Prov
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object get() => (object) UI.lambda\u0024loadSync\u00241();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) UI.lambda\u0024loadSync\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Func
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public object get([In] object obj0) => (object) UI.lambda\u0024loadSync\u00244((string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly UI arg\u00241;

      internal __\u003C\u003EAnon4([In] UI obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024loadSync\u00246((Exception) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Runnable
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void run() => UI.lambda\u0024loadSync\u00247();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Boolp
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public bool get() => (UI.lambda\u0024init\u00248() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Boolp
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public bool get() => (UI.lambda\u0024init\u00249() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly UI arg\u00241;
      private readonly Runnable arg\u00242;

      internal __\u003C\u003EAnon8([In] UI obj0, [In] Runnable obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024loadAnd\u002410(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly Table arg\u00241;

      internal __\u003C\u003EAnon9([In] Table obj0) => this.arg\u00241 = obj0;

      public void run() => UI.lambda\u0024showInfoToast\u002411(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon10([In] string obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => UI.lambda\u0024showInfoToast\u002412(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly Table arg\u00241;

      internal __\u003C\u003EAnon11([In] Table obj0) => this.arg\u00241 = obj0;

      public void run() => UI.lambda\u0024showInfoPopup\u002413(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Cons
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon12([In] string obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => UI.lambda\u0024showInfoPopup\u002414(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly Table arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;

      internal __\u003C\u003EAnon13([In] Table obj0, [In] float obj1, [In] float obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => UI.lambda\u0024showLabel\u002415(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public void run() => UI.lambda\u0024showInfo\u002416();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Runnable
    {
      private readonly BaseDialog arg\u00241;

      internal __\u003C\u003EAnon15([In] BaseDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly BaseDialog arg\u00241;
      private readonly Runnable arg\u00242;

      internal __\u003C\u003EAnon16([In] BaseDialog obj0, [In] Runnable obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => UI.lambda\u0024showConfirm\u002417(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Runnable
    {
      private readonly Boolp arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon17([In] Boolp obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => UI.lambda\u0024showConfirm\u002418(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Runnable
    {
      private readonly BaseDialog arg\u00241;
      private readonly Runnable arg\u00242;

      internal __\u003C\u003EAnon18([In] BaseDialog obj0, [In] Runnable obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => UI.lambda\u0024showConfirm\u002419(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Runnable
    {
      private readonly BaseDialog arg\u00241;
      private readonly Runnable arg\u00242;

      internal __\u003C\u003EAnon19([In] BaseDialog obj0, [In] Runnable obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => UI.lambda\u0024showCustomConfirm\u002420(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Runnable
    {
      private readonly BaseDialog arg\u00241;
      private readonly Runnable arg\u00242;

      internal __\u003C\u003EAnon20([In] BaseDialog obj0, [In] Runnable obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => UI.lambda\u0024showCustomConfirm\u002421(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Runnable
    {
      private readonly Table arg\u00241;

      internal __\u003C\u003EAnon21([In] Table obj0) => this.arg\u00241 = obj0;

      public void run() => UI.lambda\u0024announce\u002422(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Runnable
    {
      private readonly BaseDialog arg\u00241;
      private readonly Runnable arg\u00242;

      internal __\u003C\u003EAnon22([In] BaseDialog obj0, [In] Runnable obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => UI.lambda\u0024showOkText\u002423(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Runnable
    {
      private readonly UI arg\u00241;

      internal __\u003C\u003EAnon23([In] UI obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024loadSync\u00245();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Cons
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon24([In] string obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => UI.lambda\u0024loadSync\u00243(this.arg\u00241, (Table) obj0);
    }
  }
}
