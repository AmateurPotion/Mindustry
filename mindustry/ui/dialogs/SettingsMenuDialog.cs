// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.SettingsMenuDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.files;
using arc.func;
using arc.graphics;
using arc.input;
using arc.scene;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using java.util.zip;
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.input;
using mindustry.type;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class SettingsMenuDialog : SettingsDialog
  {
    public SettingsDialog.SettingsTable graphics;
    public SettingsDialog.SettingsTable game;
    public SettingsDialog.SettingsTable sound;
    private Table prefs;
    private Table menu;
    private BaseDialog dataDialog;
    private bool wasPaused;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 186, 104, 241, 72, 241, 74, 103, 108, 108, 159, 30, 107, 108, 140, 149, 107, 107, 139, 107, 108, 145, 134, 107, 146, 112, 139, 255, 2, 160, 135, 113, 238, 82, 135, 103, 114, 103, 146, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SettingsMenuDialog()
    {
      SettingsMenuDialog settingsMenuDialog = this;
      this.hidden((Runnable) new SettingsMenuDialog.__\u003C\u003EAnon0(this));
      this.shown((Runnable) new SettingsMenuDialog.__\u003C\u003EAnon1(this));
      this.setFillParent(true);
      this.__\u003C\u003Etitle.setAlignment(1);
      this.__\u003C\u003EtitleTable.row();
      this.__\u003C\u003EtitleTable.add((Element) new Image()).growX().height(3f).pad(4f).get().setColor(Pal.accent);
      this.__\u003C\u003Econt.clearChildren();
      this.__\u003C\u003Econt.remove();
      this.__\u003C\u003Ebuttons.remove();
      Table.__\u003Cclinit\u003E();
      this.menu = new Table((Drawable) Tex.button);
      this.game = new SettingsDialog.SettingsTable();
      this.graphics = new SettingsDialog.SettingsTable();
      this.sound = new SettingsDialog.SettingsTable();
      this.prefs = new Table();
      this.prefs.top();
      this.prefs.margin(14f);
      this.rebuildMenu();
      this.prefs.clearChildren();
      this.prefs.add((Element) this.menu);
      this.dataDialog = new BaseDialog("@settings.data");
      this.dataDialog.addCloseButton();
      this.dataDialog.__\u003C\u003Econt.table((Drawable) Tex.button, (Cons) new SettingsMenuDialog.__\u003C\u003EAnon2(this));
      ScrollPane.__\u003Cclinit\u003E();
      ScrollPane scrollPane = new ScrollPane((Element) this.prefs);
      scrollPane.addCaptureListener((EventListener) new SettingsMenuDialog.\u0031(this, scrollPane));
      scrollPane.setFadeScrollBars(false);
      this.row();
      this.add((Element) scrollPane).grow().top();
      this.row();
      this.add((Element) this.__\u003C\u003Ebuttons).fillX();
      this.addSettings();
    }

    [LineNumberTable(new byte[] {160, 156, 139, 134, 123, 125, 108, 125, 108, 125, 108, 127, 14, 120, 108, 191, 14, 108, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void rebuildMenu()
    {
      this.menu.clearChildren();
      TextButton.TextButtonStyle cleart = Styles.cleart;
      this.menu.defaults().size(300f, 60f);
      this.menu.button("@settings.game", cleart, (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon3(this));
      this.menu.row();
      this.menu.button("@settings.graphics", cleart, (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon4(this));
      this.menu.row();
      this.menu.button("@settings.sound", cleart, (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon5(this));
      this.menu.row();
      Table menu1 = this.menu;
      TextButton.TextButtonStyle style1 = cleart;
      LanguageDialog language = Vars.ui.language;
      Objects.requireNonNull((object) language);
      Runnable listener1 = (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon6(language);
      menu1.button("@settings.language", style1, listener1);
      if (!Vars.mobile || Core.settings.getBool("keyboard"))
      {
        this.menu.row();
        Table menu2 = this.menu;
        TextButton.TextButtonStyle style2 = cleart;
        ControlsDialog controls = Vars.ui.controls;
        Objects.requireNonNull((object) controls);
        Runnable listener2 = (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon7(controls);
        menu2.button("@settings.controls", style2, listener2);
      }
      this.menu.row();
      this.menu.button("@settings.data", cleart, (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon8(this));
    }

    [LineNumberTable(new byte[] {160, 178, 127, 22, 127, 22, 159, 22, 107, 103, 113, 123, 113, 239, 76, 159, 7, 103, 177, 113, 113, 113, 113, 145, 103, 113, 177, 145, 103, 177, 103, 255, 1, 69, 127, 2, 251, 70, 255, 7, 70, 127, 9, 127, 2, 255, 2, 70, 159, 2, 106, 123, 251, 72, 155, 121, 113, 180, 113, 150, 103, 251, 72, 113, 202, 113, 123, 113, 113, 113, 103, 145, 123, 113, 113, 113, 113, 113, 113, 113, 103, 219, 251, 69, 251, 70, 255, 6, 71, 113, 127, 5, 103, 106, 162, 103, 181, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addSettings()
    {
      this.sound.sliderPref("musicvol", Core.bundle.get("setting.musicvol.name", "Music Volume"), 100, 0, 100, 1, (SettingsDialog.StringProcessor) new SettingsMenuDialog.__\u003C\u003EAnon9());
      this.sound.sliderPref("sfxvol", Core.bundle.get("setting.sfxvol.name", "SFX Volume"), 100, 0, 100, 1, (SettingsDialog.StringProcessor) new SettingsMenuDialog.__\u003C\u003EAnon10());
      this.sound.sliderPref("ambientvol", Core.bundle.get("setting.ambientvol.name", "Ambient Volume"), 100, 0, 100, 1, (SettingsDialog.StringProcessor) new SettingsMenuDialog.__\u003C\u003EAnon11());
      this.game.screenshakePref();
      if (Vars.mobile)
      {
        this.game.checkPref("autotarget", true);
        this.game.checkPref("keyboard", false, (Boolc) new SettingsMenuDialog.__\u003C\u003EAnon12());
        if (Core.settings.getBool("keyboard"))
          Vars.control.setInput((InputHandler) new DesktopInput());
      }
      this.game.sliderPref("saveinterval", 60, 10, 600, 10, (SettingsDialog.StringProcessor) new SettingsMenuDialog.__\u003C\u003EAnon13());
      if (!Vars.mobile)
        this.game.checkPref("crashreport", true);
      this.game.checkPref("savecreate", true);
      this.game.checkPref("blockreplace", true);
      this.game.checkPref("conveyorpathfinding", true);
      this.game.checkPref("hints", true);
      this.game.checkPref("logichints", true);
      if (!Vars.mobile)
      {
        this.game.checkPref("backgroundpause", true);
        this.game.checkPref("buildautopause", false);
      }
      this.game.checkPref("doubletapmine", false);
      if (!Vars.ios)
        this.game.checkPref("modcrashdisable", true);
      if (Vars.steam)
      {
        this.game.sliderPref("playerlimit", 16, 2, 32, (SettingsDialog.StringProcessor) new SettingsMenuDialog.__\u003C\u003EAnon14());
        string modifier = mindustry.core.Version.modifier;
        object obj = (object) "beta";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        if (!String.instancehelper_contains(modifier, charSequence2))
          this.game.checkPref("publichost", false, (Boolc) new SettingsMenuDialog.__\u003C\u003EAnon15());
      }
      this.graphics.sliderPref("uiscale", 100, 25, 300, 25, (SettingsDialog.StringProcessor) new SettingsMenuDialog.__\u003C\u003EAnon16());
      this.graphics.sliderPref("fpscap", 240, 15, 245, 5, (SettingsDialog.StringProcessor) new SettingsMenuDialog.__\u003C\u003EAnon17());
      this.graphics.sliderPref("chatopacity", 100, 0, 100, 5, (SettingsDialog.StringProcessor) new SettingsMenuDialog.__\u003C\u003EAnon18());
      this.graphics.sliderPref("lasersopacity", 100, 0, 100, 5, (SettingsDialog.StringProcessor) new SettingsMenuDialog.__\u003C\u003EAnon19());
      this.graphics.sliderPref("bridgeopacity", 100, 0, 100, 5, (SettingsDialog.StringProcessor) new SettingsMenuDialog.__\u003C\u003EAnon20());
      if (!Vars.mobile)
      {
        this.graphics.checkPref("vsync", true, (Boolc) new SettingsMenuDialog.__\u003C\u003EAnon21());
        this.graphics.checkPref("fullscreen", false, (Boolc) new SettingsMenuDialog.__\u003C\u003EAnon22());
        this.graphics.checkPref("borderlesswindow", false, (Boolc) new SettingsMenuDialog.__\u003C\u003EAnon23());
        Core.graphics.setVSync(Core.settings.getBool("vsync"));
        if (Core.settings.getBool("fullscreen"))
          Core.app.post((Runnable) new SettingsMenuDialog.__\u003C\u003EAnon24());
        if (Core.settings.getBool("borderlesswindow"))
          Core.app.post((Runnable) new SettingsMenuDialog.__\u003C\u003EAnon25());
      }
      else if (!Vars.ios)
      {
        this.graphics.checkPref("landscape", false, (Boolc) new SettingsMenuDialog.__\u003C\u003EAnon26());
        if (Core.settings.getBool("landscape"))
          Vars.platform.beginForceLandscape();
      }
      this.graphics.checkPref("effects", true);
      this.graphics.checkPref("atmosphere", !Vars.mobile);
      this.graphics.checkPref("destroyedblocks", true);
      this.graphics.checkPref("blockstatus", false);
      this.graphics.checkPref("playerchat", true);
      if (!Vars.mobile)
        this.graphics.checkPref("coreitems", true);
      this.graphics.checkPref("minimap", !Vars.mobile);
      this.graphics.checkPref("smoothcamera", true);
      this.graphics.checkPref("position", false);
      this.graphics.checkPref("fps", false);
      this.graphics.checkPref("playerindicators", true);
      this.graphics.checkPref("indicators", true);
      this.graphics.checkPref("showweather", true);
      this.graphics.checkPref("animatedwater", true);
      if (Shaders.shield != null)
        this.graphics.checkPref("animatedshields", !Vars.mobile);
      this.graphics.checkPref("bloom", true, (Boolc) new SettingsMenuDialog.__\u003C\u003EAnon27());
      this.graphics.checkPref("pixelate", false, (Boolc) new SettingsMenuDialog.__\u003C\u003EAnon28());
      this.graphics.checkPref("linear", !Vars.mobile, (Boolc) new SettingsMenuDialog.__\u003C\u003EAnon29());
      if (Core.settings.getBool("linear"))
      {
        ObjectSet.ObjectSetIterator objectSetIterator = Core.atlas.getTextures().iterator();
        while (((Iterator) objectSetIterator).hasNext())
        {
          Texture texture = (Texture) ((Iterator) objectSetIterator).next();
          Texture.TextureFilter linear = Texture.TextureFilter.__\u003C\u003Elinear;
          texture.setFilter(linear, linear);
        }
      }
      if (!Vars.mobile)
        Core.settings.put("swapdiagonal", (object) Boolean.valueOf(false));
      this.graphics.checkPref("flow", true);
    }

    [LineNumberTable(new byte[] {161, 141, 102, 107, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void back()
    {
      this.rebuildMenu();
      this.prefs.clearChildren();
      this.prefs.add((Element) this.menu);
    }

    [LineNumberTable(new byte[] {161, 147, 107, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visible([In] int obj0)
    {
      this.prefs.clearChildren();
      this.prefs.add((Element) new Table[3]
      {
        (Table) this.game,
        (Table) this.graphics,
        (Table) this.sound
      }[obj0]);
    }

    [LineNumberTable(new byte[] {160, 141, 149, 102, 127, 12, 63, 15, 200, 104, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string getLogs()
    {
      Fi fi1 = Core.settings.getDataDirectory().child("last_log.txt");
      StringBuilder stringBuilder = new StringBuilder();
      Fi[] fiArray = Core.settings.getDataDirectory().child("crashes").list();
      int length = fiArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Fi fi2 = fiArray[index];
        stringBuilder.append(fi2.name()).append("\n\n").append(fi2.readString()).append("\n");
      }
      if (fi1.exists())
        stringBuilder.append("\nlast log:\n").append(fi1.readString());
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {161, 116, 112, 103, 135, 107, 114, 208, 171, 139, 113, 167, 138, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void importData(Fi file)
    {
      Fi fi = Core.files.local("zipdata.zip");
      file.copyTo(fi);
      ZipFi zipFi = new ZipFi(fi);
      Fi dataDirectory = Core.settings.getDataDirectory();
      if (!zipFi.child("settings.bin").exists())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Not valid save data.");
      }
      Vars.saveDirectory.deleteDirectory();
      Vars.tmpDirectory.deleteDirectory();
      zipFi.walk((Cons) new SettingsMenuDialog.__\u003C\u003EAnon30(dataDirectory));
      fi.delete();
      Core.settings.clear();
      Core.settings.load();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 83, 102, 112, 113, 113, 113, 113, 113, 176, 127, 1, 104, 125, 138, 130, 119, 127, 3, 116, 159, 7, 124, 110, 105, 142, 103, 115, 255, 10, 52, 255, 75, 76, 237, 52, 255, 23, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void exportData(Fi file)
    {
      Seq seq = new Seq();
      seq.add((object) Core.settings.getSettingsFile());
      seq.addAll((object[]) Vars.customMapDirectory.list());
      seq.addAll((object[]) Vars.saveDirectory.list());
      seq.addAll((object[]) Vars.screenshotDirectory.list());
      seq.addAll((object[]) Vars.modDirectory.list());
      seq.addAll((object[]) Vars.schematicDirectory.list());
      string str1 = Core.settings.getDataDirectory().path();
      Iterator iterator1 = seq.copy().iterator();
label_1:
      while (iterator1.hasNext())
      {
        Fi fi = ((Fi) iterator1.next()).parent();
        while (true)
        {
          if (!seq.contains((object) fi) && !fi.equals((object) Core.settings.getDataDirectory()))
            seq.add((object) fi);
          else
            goto label_1;
        }
      }
      OutputStream outputStream = file.write(false, 2048);
      ZipOutputStream zipOutputStream;
      Exception exception1;
      Exception exception2;
      try
      {
        zipOutputStream = new ZipOutputStream(outputStream);
        try
        {
          Iterator iterator2 = seq.iterator();
          while (iterator2.hasNext())
          {
            Fi fi = (Fi) iterator2.next();
            string str2 = String.instancehelper_substring(fi.path(), String.instancehelper_length(str1));
            if (fi.isDirectory())
              str2 = new StringBuilder().append(str2).append("/").toString();
            string str3 = !String.instancehelper_startsWith(str2, "/") ? str2 : String.instancehelper_substring(str2, 1);
            zipOutputStream.putNextEntry(new ZipEntry(str3));
            if (!fi.isDirectory())
              Streams.copy(fi.read(), (OutputStream) zipOutputStream);
            zipOutputStream.closeEntry();
          }
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_17;
        }
        zipOutputStream.close();
        goto label_31;
      }
      catch (Exception ex)
      {
        exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_18;
      }
label_17:
      Exception exception3 = exception1;
      Exception exception4;
      Exception exception5;
      Exception exception6;
      try
      {
        exception4 = exception3;
        try
        {
          zipOutputStream.close();
          goto label_28;
        }
        catch (Exception ex)
        {
          exception5 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (Exception ex)
      {
        exception6 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_24;
      }
      Exception exception7 = exception5;
      Exception exception8;
      try
      {
        Exception exception9 = exception7;
        Throwable.instancehelper_addSuppressed(exception4, exception9);
        goto label_28;
      }
      catch (Exception ex)
      {
        exception8 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception10 = exception8;
      goto label_33;
label_24:
      exception10 = exception6;
      goto label_33;
label_28:
      Exception exception11;
      try
      {
        throw Throwable.__\u003Cunmap\u003E(exception4);
      }
      catch (Exception ex)
      {
        exception11 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      exception10 = exception11;
      goto label_33;
label_18:
      exception10 = exception2;
      goto label_33;
label_31:
      outputStream?.close();
      return;
label_33:
      Exception exception12 = exception10;
      if (outputStream != null)
      {
        Exception exception9;
        try
        {
          outputStream.close();
          goto label_38;
        }
        catch (Exception ex)
        {
          exception9 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Exception exception13 = exception9;
        Throwable.instancehelper_addSuppressed(exception12, exception13);
      }
label_38:
      throw Throwable.__\u003Cunmap\u003E(exception12);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 188, 107, 108, 116, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240()
    {
      Sounds.back.play();
      if (!Vars.state.isGame() || this.wasPaused && !Vars.net.active())
        return;
      Vars.state.set(GameState.State.__\u003C\u003Eplaying);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {4, 102, 108, 117, 175, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241()
    {
      this.back();
      if (Vars.state.isGame())
      {
        this.wasPaused = Vars.state.@is(GameState.State.__\u003C\u003Epaused);
        Vars.state.set(GameState.State.__\u003C\u003Epaused);
      }
      this.rebuildMenu();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {41, 123, 134, 255, 1, 79, 134, 135, 223, 1, 134, 135, 255, 1, 77, 134, 135, 255, 1, 82, 134, 135, 255, 2, 84, 134, 135, 255, 2, 78, 134, 103, 103, 191, 7, 135, 255, 2, 79, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002420([In] Table obj0)
    {
      obj0.defaults().size(280f, 60f).left();
      TextButton.TextButtonStyle cleart = Styles.cleart;
      obj0.button("@settings.cleardata", (Drawable) Icon.trash, cleart, (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon33()).marginLeft(4f);
      obj0.row();
      obj0.button("@settings.clearsaves", (Drawable) Icon.trash, cleart, (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon34()).marginLeft(4f);
      obj0.row();
      obj0.button("@settings.clearresearch", (Drawable) Icon.trash, cleart, (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon35()).marginLeft(4f);
      obj0.row();
      obj0.button("@settings.clearcampaignsaves", (Drawable) Icon.trash, cleart, (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon36()).marginLeft(4f);
      obj0.row();
      obj0.button("@data.export", (Drawable) Icon.upload, cleart, (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon37(this)).marginLeft(4f);
      obj0.row();
      obj0.button("@data.import", (Drawable) Icon.download, cleart, (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon38(this)).marginLeft(4f);
      if (!Vars.mobile)
      {
        obj0.row();
        obj0.button("@data.openfolder", (Drawable) Icon.folder, cleart, (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon39()).marginLeft(4f);
      }
      obj0.row();
      obj0.button("@crash.export", (Drawable) Icon.upload, cleart, (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon40(this)).marginLeft(4f);
    }

    [Modifiers]
    [LineNumberTable(275)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildMenu\u002421() => this.visible(0);

    [Modifiers]
    [LineNumberTable(277)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildMenu\u002422() => this.visible(1);

    [Modifiers]
    [LineNumberTable(279)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildMenu\u002423() => this.visible(2);

    [Modifiers]
    [LineNumberTable(288)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildMenu\u002424() => this.dataDialog.show();

    [Modifiers]
    [LineNumberTable(292)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024addSettings\u002425([In] int obj0) => new StringBuilder().append(obj0).append("%").toString();

    [Modifiers]
    [LineNumberTable(293)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024addSettings\u002426([In] int obj0) => new StringBuilder().append(obj0).append("%").toString();

    [Modifiers]
    [LineNumberTable(294)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024addSettings\u002427([In] int obj0) => new StringBuilder().append(obj0).append("%").toString();

    [Modifiers]
    [LineNumberTable(299)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024addSettings\u002428([In] bool obj0)
    {
      int num = obj0 ? 1 : 0;
      Vars.control.setInput(num == 0 ? (InputHandler) new MobileInput() : (InputHandler) new DesktopInput());
    }

    [Modifiers]
    [LineNumberTable(313)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024addSettings\u002429([In] int obj0) => Core.bundle.format("setting.seconds", (object) Integer.valueOf(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {160, 224, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024addSettings\u002430([In] int obj0)
    {
      Vars.platform.updateLobby();
      return new StringBuilder().append(obj0).append("").toString();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 230, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024addSettings\u002431([In] bool obj0) => Vars.platform.updateLobby();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 236, 108, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024addSettings\u002432([In] int obj0)
    {
      if (Vars.ui.settings != null)
        Core.settings.put("uiscalechanged", (object) Boolean.valueOf(true));
      return new StringBuilder().append(obj0).append("%").toString();
    }

    [Modifiers]
    [LineNumberTable(355)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024addSettings\u002433([In] int obj0)
    {
      if (obj0 > 240)
        return Core.bundle.get("setting.fpscap.none");
      return Core.bundle.format("setting.fpscap.text", (object) Integer.valueOf(obj0));
    }

    [Modifiers]
    [LineNumberTable(356)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024addSettings\u002434([In] int obj0) => new StringBuilder().append(obj0).append("%").toString();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 244, 108, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024addSettings\u002435([In] int obj0)
    {
      if (Vars.ui.settings != null)
        Core.settings.put("preferredlaseropacity", (object) Integer.valueOf(obj0));
      return new StringBuilder().append(obj0).append("%").toString();
    }

    [Modifiers]
    [LineNumberTable(363)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024addSettings\u002436([In] int obj0) => new StringBuilder().append(obj0).append("%").toString();

    [Modifiers]
    [LineNumberTable(366)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024addSettings\u002437([In] bool obj0)
    {
      int num = obj0 ? 1 : 0;
      Core.graphics.setVSync(num != 0);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 50, 66, 99, 151, 159, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024addSettings\u002438([In] bool obj0)
    {
      if (obj0)
        Core.graphics.setFullscreenMode(Core.graphics.getDisplayMode());
      else
        Core.graphics.setWindowedMode(Core.graphics.getWidth(), Core.graphics.getHeight());
    }

    [Modifiers]
    [LineNumberTable(375)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024addSettings\u002439([In] bool obj0)
    {
      int num = obj0 ? 1 : 0;
      Core.graphics.setUndecorated(num != 0);
    }

    [Modifiers]
    [LineNumberTable(379)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024addSettings\u002440() => Core.graphics.setFullscreenMode(Core.graphics.getDisplayMode());

    [Modifiers]
    [LineNumberTable(383)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024addSettings\u002441() => Core.graphics.setUndecorated(true);

    [Modifiers]
    [LineNumberTable(new byte[] {159, 46, 162, 99, 140, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024addSettings\u002442([In] bool obj0)
    {
      if (obj0)
        Vars.platform.beginForceLandscape();
      else
        Vars.platform.endForceLandscape();
    }

    [Modifiers]
    [LineNumberTable(420)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024addSettings\u002443([In] bool obj0)
    {
      int num = obj0 ? 1 : 0;
      Vars.renderer.toggleBloom(num != 0);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 36, 130, 99, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024addSettings\u002444([In] bool obj0)
    {
      if (!obj0)
        return;
      Events.fire((object) EventType.Trigger.__\u003C\u003EenablePixelation);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 34, 66, 127, 5, 112, 104, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024addSettings\u002445([In] bool obj0)
    {
      int num = obj0 ? 1 : 0;
      ObjectSet.ObjectSetIterator objectSetIterator = Core.atlas.getTextures().iterator();
      while (((Iterator) objectSetIterator).hasNext())
      {
        Texture texture = (Texture) ((Iterator) objectSetIterator).next();
        Texture.TextureFilter textureFilter = num == 0 ? Texture.TextureFilter.__\u003C\u003Enearest : Texture.TextureFilter.__\u003C\u003Elinear;
        texture.setFilter(textureFilter, textureFilter);
      }
    }

    [Modifiers]
    [LineNumberTable(501)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024importData\u002446([In] Fi obj0, [In] Fi obj1) => obj1.copyTo(obj0.child(obj1.path()));

    [Modifiers]
    [LineNumberTable(new byte[] {161, 154, 125, 136, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addCloseButton\u002447()
    {
      if (!object.ReferenceEquals(this.prefs.getChildren().first(), (object) this.menu))
        this.back();
      else
        this.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 162, 122, 125, 136, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addCloseButton\u002448([In] KeyCode obj0)
    {
      if (!object.ReferenceEquals((object) obj0, (object) KeyCode.__\u003C\u003Eescape) && !object.ReferenceEquals((object) obj0, (object) KeyCode.__\u003C\u003Eback))
        return;
      if (!object.ReferenceEquals(this.prefs.getChildren().first(), (object) this.menu))
        this.back();
      else
        this.hide();
    }

    [Modifiers]
    [LineNumberTable(94)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00243() => Vars.ui.showConfirm("@confirm", "@settings.clearall.confirm", (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon50());

    [Modifiers]
    [LineNumberTable(new byte[] {64, 190})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00245() => Vars.ui.showConfirm("@confirm", "@settings.clearsaves.confirm", (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon49());

    [Modifiers]
    [LineNumberTable(new byte[] {72, 254, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00248() => Vars.ui.showConfirm("@confirm", "@settings.clearresearch.confirm", (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon47());

    [Modifiers]
    [LineNumberTable(new byte[] {89, 254, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u002410() => Vars.ui.showConfirm("@confirm", "@settings.clearcampaignsaves.confirm", (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon46());

    [Modifiers]
    [LineNumberTable(new byte[] {111, 103, 144, 190, 2, 97, 139, 107, 98, 251, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002412()
    {
      if (Vars.ios)
      {
        Fi file = Core.files.local("mindustry-data-export.zip");
        Exception exception1;
        try
        {
          this.exportData(file);
          goto label_7;
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
        Vars.ui.showException((Exception) exception2);
label_7:
        Vars.platform.shareFile(file);
      }
      else
        Vars.platform.showFileChooser(false, "zip", (Cons) new SettingsMenuDialog.__\u003C\u003EAnon45(this));
    }

    [Modifiers]
    [LineNumberTable(184)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002415() => Vars.ui.showConfirm("@confirm", "@data.import.confirm", (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon43(this));

    [Modifiers]
    [LineNumberTable(202)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u002416() => Core.app.openFolder(Core.settings.getDataDirectory().absolutePath());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 94, 127, 24, 145, 103, 112, 108, 107, 98, 251, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002419()
    {
      if (Core.settings.getDataDirectory().child("crashes").list().Length == 0 && !Core.settings.getDataDirectory().child("last_log.txt").exists())
        Vars.ui.showInfo("@crash.none");
      else if (Vars.ios)
      {
        Fi file = Vars.tmpDirectory.child("logs.txt");
        file.writeString(this.getLogs());
        Vars.platform.shareFile(file);
      }
      else
        Vars.platform.showFileChooser(false, "txt", (Cons) new SettingsMenuDialog.__\u003C\u003EAnon41(this));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 103, 108, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002418([In] Fi obj0)
    {
      obj0.writeString(this.getLogs());
      Core.app.post((Runnable) new SettingsMenuDialog.__\u003C\u003EAnon42());
    }

    [Modifiers]
    [LineNumberTable(218)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u002417() => Vars.ui.showInfo("@crash.exported");

    [Modifiers]
    [LineNumberTable(184)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002414() => Vars.platform.showFileChooser(true, "zip", (Cons) new SettingsMenuDialog.__\u003C\u003EAnon44(this));

    [Modifiers]
    [LineNumberTable(new byte[] {160, 72, 103, 255, 7, 74, 229, 55, 97, 239, 72, 226, 57, 97, 102, 127, 11, 141, 175})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002413([In] Fi obj0)
    {
      Exception exception1;
      try
      {
        try
        {
          this.importData(obj0);
          Core.app.exit();
          return;
        }
        catch (IllegalArgumentException ex)
        {
        }
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_6;
        }
      }
      Vars.ui.showErrorMessage("@data.invalid");
      return;
label_6:
      Exception exception2 = exception1;
      Throwable.instancehelper_printStackTrace((Exception) exception2);
      if (Throwable.instancehelper_getMessage((Exception) exception2) != null)
      {
        string message = Throwable.instancehelper_getMessage((Exception) exception2);
        object obj = (object) "too short";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        if (String.instancehelper_contains(message, charSequence2))
        {
          Vars.ui.showErrorMessage("@data.invalid");
          return;
        }
      }
      Vars.ui.showException((Exception) exception2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {122, 103, 223, 7, 226, 61, 97, 102, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002411([In] Fi obj0)
    {
      Exception exception1;
      try
      {
        this.exportData(obj0);
        Vars.ui.showInfo("@data.exported");
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
      Throwable.instancehelper_printStackTrace((Exception) exception2);
      Vars.ui.showException((Exception) exception2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {90, 127, 8, 127, 1, 102, 104, 107, 135, 98, 133, 127, 16, 105, 135, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00249()
    {
      Iterator iterator1 = Vars.content.planets().iterator();
label_1:
      while (iterator1.hasNext())
      {
        Iterator iterator2 = ((Planet) iterator1.next()).sectors.iterator();
        while (true)
        {
          Sector sector;
          do
          {
            if (iterator2.hasNext())
            {
              sector = (Sector) iterator2.next();
              sector.clearInfo();
            }
            else
              goto label_1;
          }
          while (sector.save == null);
          sector.save.delete();
          sector.save = (Saves.SaveSlot) null;
        }
      }
      Iterator iterator3 = Vars.control.saves.getSaveSlots().copy().iterator();
      while (iterator3.hasNext())
      {
        Saves.SaveSlot saveSlot = (Saves.SaveSlot) iterator3.next();
        if (saveSlot.isSector())
          saveSlot.delete();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {73, 106, 127, 0, 102, 98, 244, 69, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00247()
    {
      Vars.universe.clearLoadoutInfo();
      Iterator iterator = TechTree.all.iterator();
      while (iterator.hasNext())
        ((TechTree.TechNode) iterator.next()).reset();
      Vars.content.each((Cons) new SettingsMenuDialog.__\u003C\u003EAnon48());
      Core.settings.remove("unlocks");
    }

    [Modifiers]
    [LineNumberTable(new byte[] {78, 127, 0, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00246([In] Content obj0)
    {
      Content content = obj0;
      UnlockableContent unlockableContent;
      if (!(content is UnlockableContent) || !object.ReferenceEquals((object) (unlockableContent = (UnlockableContent) content), (object) (UnlockableContent) content))
        return;
      unlockableContent.clearUnlock();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {65, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00244() => Vars.control.saves.deleteAll();

    [Modifiers]
    [LineNumberTable(new byte[] {45, 102, 127, 8, 127, 27, 148, 101, 106, 139, 127, 2, 40, 200, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00242()
    {
      ObjectMap map = new ObjectMap();
      Iterator iterator = Core.settings.keys().iterator();
      while (iterator.hasNext())
      {
        string name = (string) iterator.next();
        string str1 = name;
        object obj1 = (object) "usid";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj1;
        CharSequence charSequence2 = charSequence1;
        if (!String.instancehelper_contains(str1, charSequence2))
        {
          string str2 = name;
          object obj2 = (object) "uuid";
          charSequence1.__\u003Cref\u003E = (__Null) obj2;
          CharSequence charSequence3 = charSequence1;
          if (!String.instancehelper_contains(str2, charSequence3))
            continue;
        }
        map.put((object) name, Core.settings.get(name, (object) null));
      }
      Core.settings.clear();
      Core.settings.putAll(map);
      Fi[] fiArray = Vars.dataDirectory.list();
      int length = fiArray.Length;
      for (int index = 0; index < length; ++index)
        fiArray[index].deleteDirectory();
      Core.app.exit();
    }

    [LineNumberTable(new byte[] {161, 153, 255, 11, 70, 134, 241, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void addCloseButton()
    {
      this.__\u003C\u003Ebuttons.button("@back", (Drawable) Icon.left, (Runnable) new SettingsMenuDialog.__\u003C\u003EAnon31(this)).size(210f, 64f);
      this.keyDown((Cons) new SettingsMenuDialog.__\u003C\u003EAnon32(this));
    }

    [HideFromJava]
    static SettingsMenuDialog() => SettingsDialog.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "<init>", "()V")]
    [SpecialName]
    internal new class \u0031 : InputListener
    {
      [Modifiers]
      internal ScrollPane val\u0024pane;
      [Modifiers]
      internal SettingsMenuDialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(226)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] SettingsMenuDialog obj0, [In] ScrollPane obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024pane = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {160, 115, 113, 104, 108, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool touchDown(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        if (!(this.val\u0024pane.hit(obj1, obj2, true) is Slider))
          return base.touchDown(obj0, obj1, obj2, obj3, obj4);
        this.val\u0024pane.setFlickScroll(false);
        return true;
      }

      [LineNumberTable(new byte[] {160, 126, 108, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchUp(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        this.val\u0024pane.setFlickScroll(true);
        base.touchUp(obj0, obj1, obj2, obj3, obj4);
      }

      [HideFromJava]
      static \u0031() => InputListener.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon2([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u002420((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon3([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024rebuildMenu\u002421();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon4([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024rebuildMenu\u002422();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon5([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024rebuildMenu\u002423();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly LanguageDialog arg\u00241;

      internal __\u003C\u003EAnon6([In] LanguageDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly ControlsDialog arg\u00241;

      internal __\u003C\u003EAnon7([In] ControlsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon8([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024rebuildMenu\u002424();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : SettingsDialog.StringProcessor
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public string get([In] int obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002425(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : SettingsDialog.StringProcessor
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public string get([In] int obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002426(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : SettingsDialog.StringProcessor
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public string get([In] int obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002427(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Boolc
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public void get([In] bool obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002428(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : SettingsDialog.StringProcessor
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public string get([In] int obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002429(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : SettingsDialog.StringProcessor
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public string get([In] int obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002430(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Boolc
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public void get([In] bool obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002431(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : SettingsDialog.StringProcessor
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public string get([In] int obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002432(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : SettingsDialog.StringProcessor
    {
      internal __\u003C\u003EAnon17()
      {
      }

      public string get([In] int obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002433(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : SettingsDialog.StringProcessor
    {
      internal __\u003C\u003EAnon18()
      {
      }

      public string get([In] int obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002434(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : SettingsDialog.StringProcessor
    {
      internal __\u003C\u003EAnon19()
      {
      }

      public string get([In] int obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002435(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : SettingsDialog.StringProcessor
    {
      internal __\u003C\u003EAnon20()
      {
      }

      public string get([In] int obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002436(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Boolc
    {
      internal __\u003C\u003EAnon21()
      {
      }

      public void get([In] bool obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002437(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Boolc
    {
      internal __\u003C\u003EAnon22()
      {
      }

      public void get([In] bool obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002438(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Boolc
    {
      internal __\u003C\u003EAnon23()
      {
      }

      public void get([In] bool obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002439(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Runnable
    {
      internal __\u003C\u003EAnon24()
      {
      }

      public void run() => SettingsMenuDialog.lambda\u0024addSettings\u002440();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Runnable
    {
      internal __\u003C\u003EAnon25()
      {
      }

      public void run() => SettingsMenuDialog.lambda\u0024addSettings\u002441();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Boolc
    {
      internal __\u003C\u003EAnon26()
      {
      }

      public void get([In] bool obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002442(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Boolc
    {
      internal __\u003C\u003EAnon27()
      {
      }

      public void get([In] bool obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002443(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Boolc
    {
      internal __\u003C\u003EAnon28()
      {
      }

      public void get([In] bool obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002444(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Boolc
    {
      internal __\u003C\u003EAnon29()
      {
      }

      public void get([In] bool obj0) => SettingsMenuDialog.lambda\u0024addSettings\u002445(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Cons
    {
      private readonly Fi arg\u00241;

      internal __\u003C\u003EAnon30([In] Fi obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => SettingsMenuDialog.lambda\u0024importData\u002446(this.arg\u00241, (Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Runnable
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon31([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024addCloseButton\u002447();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Cons
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon32([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024addCloseButton\u002448((KeyCode) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Runnable
    {
      internal __\u003C\u003EAnon33()
      {
      }

      public void run() => SettingsMenuDialog.lambda\u0024new\u00243();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Runnable
    {
      internal __\u003C\u003EAnon34()
      {
      }

      public void run() => SettingsMenuDialog.lambda\u0024new\u00245();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Runnable
    {
      internal __\u003C\u003EAnon35()
      {
      }

      public void run() => SettingsMenuDialog.lambda\u0024new\u00248();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : Runnable
    {
      internal __\u003C\u003EAnon36()
      {
      }

      public void run() => SettingsMenuDialog.lambda\u0024new\u002410();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon37 : Runnable
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon37([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002412();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon38 : Runnable
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon38([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002415();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon39 : Runnable
    {
      internal __\u003C\u003EAnon39()
      {
      }

      public void run() => SettingsMenuDialog.lambda\u0024new\u002416();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon40 : Runnable
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon40([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002419();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon41 : Cons
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon41([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u002418((Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon42 : Runnable
    {
      internal __\u003C\u003EAnon42()
      {
      }

      public void run() => SettingsMenuDialog.lambda\u0024new\u002417();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon43 : Runnable
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon43([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002414();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon44 : Cons
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon44([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u002413((Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon45 : Cons
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon45([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u002411((Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon46 : Runnable
    {
      internal __\u003C\u003EAnon46()
      {
      }

      public void run() => SettingsMenuDialog.lambda\u0024new\u00249();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon47 : Runnable
    {
      internal __\u003C\u003EAnon47()
      {
      }

      public void run() => SettingsMenuDialog.lambda\u0024new\u00247();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon48 : Cons
    {
      internal __\u003C\u003EAnon48()
      {
      }

      public void get([In] object obj0) => SettingsMenuDialog.lambda\u0024new\u00246((Content) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon49 : Runnable
    {
      internal __\u003C\u003EAnon49()
      {
      }

      public void run() => SettingsMenuDialog.lambda\u0024new\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon50 : Runnable
    {
      internal __\u003C\u003EAnon50()
      {
      }

      public void run() => SettingsMenuDialog.lambda\u0024new\u00242();
    }
  }
}
