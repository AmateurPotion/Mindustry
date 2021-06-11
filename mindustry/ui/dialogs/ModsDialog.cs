// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.ModsDialog
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
using arc.scene;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using arc.util.io;
using arc.util.serialization;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.text;
using java.util;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.io;
using mindustry.mod;
using mindustry.type;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class ModsDialog : BaseDialog
  {
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Larc/graphics/g2d/TextureRegion;>;")]
    private ObjectMap textureCache;
    private string searchtxt;
    [Signature("Larc/struct/Seq<Lmindustry/mod/ModListing;>;")]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private Seq modList;
    private bool orderDate;
    private BaseDialog currentContent;
    private BaseDialog browser;
    private Table browserTable;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 190, 237, 53, 139, 139, 231, 72, 134, 144, 251, 76, 144, 113, 187, 113, 139, 150, 159, 16, 103, 191, 1, 113, 103, 177, 245, 71, 241, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ModsDialog()
      : base("@mods")
    {
      ModsDialog modsDialog = this;
      this.textureCache = new ObjectMap();
      this.searchtxt = "";
      this.orderDate = false;
      this.addCloseButton();
      this.browser = new BaseDialog("@mods.browser");
      this.browser.__\u003C\u003Econt.table((Cons) new ModsDialog.__\u003C\u003EAnon0(this)).fillX().padBottom(4f);
      this.browser.__\u003C\u003Econt.row();
      ((ScrollPane) this.browser.__\u003C\u003Econt.pane((Cons) new ModsDialog.__\u003C\u003EAnon1(this)).get()).setScrollingDisabled(true, false);
      this.browser.addCloseButton();
      this.browser.onResize((Runnable) new ModsDialog.__\u003C\u003EAnon2(this));
      this.__\u003C\u003Ebuttons.button("@mods.guide", (Drawable) Icon.link, (Runnable) new ModsDialog.__\u003C\u003EAnon3()).size(210f, 64f);
      if (!Vars.mobile)
        this.__\u003C\u003Ebuttons.button("@mods.openfolder", (Drawable) Icon.link, (Runnable) new ModsDialog.__\u003C\u003EAnon4());
      this.shown((Runnable) new ModsDialog.__\u003C\u003EAnon5(this));
      if (Vars.mobile)
        this.onResize((Runnable) new ModsDialog.__\u003C\u003EAnon5(this));
      Events.on((Class) ClassLiteral<EventType.ResizeEvent>.Value, (Cons) new ModsDialog.__\u003C\u003EAnon6(this));
      this.hidden((Runnable) new ModsDialog.__\u003C\u003EAnon7(this));
    }

    [LineNumberTable(new byte[] {161, 24, 159, 0, 107, 159, 2, 159, 10, 243, 160, 95})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void rebuildBrowser()
    {
      ObjectSet objectSet = Vars.mods.list().map((Func) new ModsDialog.__\u003C\u003EAnon23()).asSet();
      this.browserTable.clear();
      Table browserTable = this.browserTable;
      object obj = (object) "@loading";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      browserTable.add(text);
      int num = ByteCodeHelper.f2i(Math.max((float) Core.graphics.getWidth() / Scl.scl(480f), 1f));
      this.getModList((Cons) new ModsDialog.__\u003C\u003EAnon24(this, objectSet, num));
    }

    [Signature("(Larc/func/Cons<Larc/struct/Seq<Lmindustry/mod/ModListing;>;>;)V")]
    [LineNumberTable(new byte[] {63, 104, 255, 9, 95, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void getModList([In] Cons obj0)
    {
      if (this.modList == null)
        Core.net.httpGet("https://raw.githubusercontent.com/Anuken/MindustryMods/master/mods.json", (Cons) new ModsDialog.__\u003C\u003EAnon9(this, obj0), (Cons) new ModsDialog.__\u003C\u003EAnon10(this));
      else
        obj0.get((object) this.modList);
    }

    [LineNumberTable(new byte[] {53, 143, 119, 145, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void modError([In] Exception obj0)
    {
      Vars.ui.loadfrag.hide();
      if (Strings.getCauses(obj0).contains((Boolf) new ModsDialog.__\u003C\u003EAnon8()))
        Vars.ui.showErrorMessage("@feature.unsupported");
      else
        Vars.ui.showException(obj0);
    }

    [LineNumberTable(new byte[] {161, 222, 213})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void showStatus([In] Net.HttpStatus obj0) => Core.app.post((Runnable) new ModsDialog.__\u003C\u003EAnon31(obj0));

    [LineNumberTable(new byte[] {161, 138, 127, 55, 114, 109, 104, 103, 255, 10, 74, 2, 98, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void handleMod([In] string obj0, [In] Net.HttpResponse obj1)
    {
      Exception exception;
      try
      {
        Fi tmpDirectory = Vars.tmpDirectory;
        StringBuilder stringBuilder = new StringBuilder();
        string str1 = obj0;
        object obj2 = (object) "";
        object obj3 = (object) "/";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence2 = charSequence1;
        object obj4 = obj2;
        charSequence1.__\u003Cref\u003E = (__Null) obj4;
        CharSequence charSequence3 = charSequence1;
        string str2 = String.instancehelper_replace(str1, charSequence2, charSequence3);
        string name = stringBuilder.append(str2).append(".zip").toString();
        Fi file = tmpDirectory.child(name);
        Streams.copy(obj1.getResultAsStream(), file.write(false));
        Vars.mods.importMod(file).setRepo(obj0);
        file.delete();
        Core.app.post((Runnable) new ModsDialog.__\u003C\u003EAnon25(this));
        return;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      this.modError(exception);
    }

    [LineNumberTable(new byte[] {161, 213, 114, 130, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool checkError([In] Net.HttpResponse obj0)
    {
      if (object.ReferenceEquals((object) obj0.getStatus(), (object) Net.HttpStatus.__\u003C\u003EOK))
        return true;
      this.showStatus(obj0.getStatus());
      return false;
    }

    [LineNumberTable(new byte[] {161, 188, 255, 38, 86})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void githubImportJavaMod([In] string obj0) => Core.net.httpGet(new StringBuilder().append("https://api.github.com/repos/").append(obj0).append("/releases/latest").toString(), (Cons) new ModsDialog.__\u003C\u003EAnon30(this, obj0), (Cons) new ModsDialog.__\u003C\u003EAnon29(this));

    [Signature("(Ljava/lang/String;Ljava/lang/String;Larc/func/Cons<Larc/Net$HttpStatus;>;)V")]
    [LineNumberTable(new byte[] {161, 229, 255, 45, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void githubImportBranch([In] string obj0, [In] string obj1, [In] Cons obj2) => Core.net.httpGet(new StringBuilder().append("https://api.github.com/repos/").append(obj1).append("/zipball/").append(obj0).toString(), (Cons) new ModsDialog.__\u003C\u003EAnon32(this, obj2, obj1), (Cons) new ModsDialog.__\u003C\u003EAnon29(this));

    [LineNumberTable(new byte[] {100, 102, 148, 107, 127, 15, 127, 49, 140, 247, 125, 134, 140, 113, 108, 255, 22, 160, 83, 235, 159, 173, 234, 160, 83, 107, 98, 191, 6, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setup()
    {
      float num = 110f;
      float width = !Vars.mobile ? 524f : 440f;
      this.__\u003C\u003Econt.clear();
      this.__\u003C\u003Econt.defaults().width(!Vars.mobile ? 560f : 500f).pad(4f);
      Table cont = this.__\u003C\u003Econt;
      object obj = (object) "@mod.reloadrequired";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      Cell cell = cont.add(text);
      Mods mods = Vars.mods;
      Objects.requireNonNull((object) mods);
      Boolp prov = (Boolp) new ModsDialog.__\u003C\u003EAnon11(mods);
      ((Label) cell.visible(prov).center().get()).setAlignment(1);
      this.__\u003C\u003Econt.row();
      this.__\u003C\u003Econt.table((Cons) new ModsDialog.__\u003C\u003EAnon12(this)).width(width);
      this.__\u003C\u003Econt.row();
      if (!Vars.mods.list().isEmpty())
      {
        bool[] flagArray = new bool[1]{ false };
        SearchBar.add(this.__\u003C\u003Econt, Vars.mods.list(), (Func) new ModsDialog.__\u003C\u003EAnon13(), (Cons2) new ModsDialog.__\u003C\u003EAnon14(this, flagArray, num, width), !Vars.mobile || Core.graphics.isPortrait()).margin(10f).top();
      }
      else
        this.__\u003C\u003Econt.table(Styles.black6, (Cons) new ModsDialog.__\u003C\u003EAnon15()).height(80f);
      this.__\u003C\u003Econt.row();
    }

    [LineNumberTable(new byte[] {159, 10, 162, 99, 255, 3, 69, 111, 255, 28, 80})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void githubImportMod([In] string obj0, [In] bool obj1)
    {
      if (obj1)
      {
        Vars.ui.showConfirm("@warning", "@mod.jarwarn", (Runnable) new ModsDialog.__\u003C\u003EAnon27(this, obj0));
      }
      else
      {
        Vars.ui.loadfrag.show();
        Core.net.httpGet(new StringBuilder().append("https://api.github.com/repos/").append(obj0).toString(), (Cons) new ModsDialog.__\u003C\u003EAnon28(this, obj0), (Cons) new ModsDialog.__\u003C\u003EAnon29(this));
      }
    }

    [LineNumberTable(new byte[] {160, 207, 150, 134, 103, 191, 2, 107, 109, 127, 2, 118, 223, 6, 251, 85, 134, 127, 11, 104, 108, 255, 13, 83, 176, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void showMod([In] Mods.LoadedMod obj0)
    {
      BaseDialog.__\u003Cclinit\u003E();
      BaseDialog baseDialog = new BaseDialog(obj0.__\u003C\u003Emeta.displayName());
      baseDialog.addCloseButton();
      if (!Vars.mobile)
        baseDialog.__\u003C\u003Ebuttons.button("@mods.openfolder", (Drawable) Icon.link, (Runnable) new ModsDialog.__\u003C\u003EAnon17(obj0));
      if (obj0.getRepo() != null)
      {
        int num = obj0.hasSteamID() ? 0 : 1;
        baseDialog.__\u003C\u003Ebuttons.button("@mods.github.open", (Drawable) Icon.link, (Runnable) new ModsDialog.__\u003C\u003EAnon18(obj0));
        if (Vars.mobile && num != 0)
          baseDialog.__\u003C\u003Ebuttons.row();
        if (num != 0)
          baseDialog.__\u003C\u003Ebuttons.button("@mods.browser.reinstall", (Drawable) Icon.download, (Runnable) new ModsDialog.__\u003C\u003EAnon19(this, obj0));
      }
      baseDialog.__\u003C\u003Econt.pane((Cons) new ModsDialog.__\u003C\u003EAnon20(obj0)).width(400f);
      Seq seq = Seq.with((object[]) Vars.content.getContentMap()).flatten().select((Boolf) new ModsDialog.__\u003C\u003EAnon21(obj0)).@as();
      if (seq.any())
      {
        baseDialog.__\u003C\u003Econt.row();
        baseDialog.__\u003C\u003Econt.button("@mods.viewcontent", (Drawable) Icon.book, (Runnable) new ModsDialog.__\u003C\u003EAnon22(this, obj0, seq)).size(300f, 50f).pad(4f);
      }
      baseDialog.show();
    }

    [LineNumberTable(new byte[] {161, 129, 105, 125, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string trimText([In] string obj0)
    {
      if (obj0 == null)
        return "";
      string str = obj0;
      object obj = (object) "\n";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj;
      CharSequence charSequence2 = charSequence1;
      return String.instancehelper_contains(str, charSequence2) ? String.instancehelper_substring(obj0, 0, String.instancehelper_indexOf(obj0, "\n")) : obj0;
    }

    [LineNumberTable(new byte[] {160, 203, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void reload() => Vars.ui.showInfoOnHidden("@mods.reloadexit", (Runnable) new ModsDialog.__\u003C\u003EAnon16());

    [Modifiers]
    [LineNumberTable(new byte[] {4, 103, 108, 183, 107, 191, 12, 127, 15, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00245([In] Table obj0)
    {
      obj0.left();
      obj0.image((Drawable) Icon.zoom);
      obj0.field(this.searchtxt, (Cons) new ModsDialog.__\u003C\u003EAnon72(this)).growX().get();
      ImageButton imageButton = (ImageButton) obj0.button((Drawable) Icon.list, Styles.clearPartiali, 32f, (Runnable) new ModsDialog.__\u003C\u003EAnon73(this)).update((Cons) new ModsDialog.__\u003C\u003EAnon74(this)).size(40f).get();
      Tooltip.__\u003Cclinit\u003E();
      Tooltip tooltip = new Tooltip((Cons) new ModsDialog.__\u003C\u003EAnon75(this));
      imageButton.addListener((EventListener) tooltip);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {19, 113, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00246([In] Table obj0)
    {
      obj0.margin(10f).top();
      this.browserTable = obj0;
    }

    [Modifiers]
    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00247() => Core.app.openURI("https://mindustrygame.github.io/wiki/modding/1-modding/");

    [Modifiers]
    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00248() => Core.app.openFolder(Vars.modDirectory.absolutePath());

    [Modifiers]
    [LineNumberTable(new byte[] {38, 104, 107, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00249([In] EventType.ResizeEvent obj0)
    {
      if (this.currentContent == null)
        return;
      this.currentContent.hide();
      this.currentContent = (BaseDialog) null;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {45, 108, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002410()
    {
      if (!Vars.mods.requiresReload())
        return;
      this.reload();
    }

    [Modifiers]
    [LineNumberTable(105)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024modError\u002411([In] Exception obj0)
    {
      if (Throwable.instancehelper_getMessage(obj0) != null)
      {
        string message1 = Throwable.instancehelper_getMessage(obj0);
        object obj1 = (object) "trust anchor";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj1;
        CharSequence charSequence2 = charSequence1;
        if (!String.instancehelper_contains(message1, charSequence2))
        {
          string message2 = Throwable.instancehelper_getMessage(obj0);
          object obj2 = (object) "SSL";
          charSequence1.__\u003Cref\u003E = (__Null) obj2;
          CharSequence charSequence3 = charSequence1;
          if (!String.instancehelper_contains(message2, charSequence3))
          {
            string message3 = Throwable.instancehelper_getMessage(obj0);
            object obj3 = (object) "protocol";
            charSequence1.__\u003Cref\u003E = (__Null) obj3;
            CharSequence charSequence4 = charSequence1;
            if (!String.instancehelper_contains(message3, charSequence4))
              goto label_5;
          }
        }
        return true;
      }
label_5:
      return false;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {65, 103, 135, 248, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024getModList\u002415([In] Cons obj0, [In] Net.HttpResponse obj1)
    {
      string resultAsString = obj1.getResultAsString();
      Net.HttpStatus status = obj1.getStatus();
      Core.app.post((Runnable) new ModsDialog.__\u003C\u003EAnon69(this, status, resultAsString, obj0));
    }

    [Modifiers]
    [LineNumberTable(143)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024getModList\u002417([In] Exception obj0) => Core.app.post((Runnable) new ModsDialog.__\u003C\u003EAnon68(this, obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {109, 159, 1, 102, 134, 253, 116, 134, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002425([In] Table obj0)
    {
      obj0.left().defaults().growX().height(60f).uniformX();
      TextButton.TextButtonStyle clearPartialt = Styles.clearPartialt;
      float margin = 12f;
      obj0.button("@mod.import", (Drawable) Icon.add, clearPartialt, (Runnable) new ModsDialog.__\u003C\u003EAnon60(this)).margin(margin);
      obj0.button("@mods.browser", (Drawable) Icon.menu, clearPartialt, (Runnable) new ModsDialog.__\u003C\u003EAnon61(this)).margin(margin);
    }

    [Modifiers]
    [LineNumberTable(226)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setup\u002426([In] Mods.LoadedMod obj0) => obj0.__\u003C\u003Emeta.displayName();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 114, 127, 1, 100, 104, 127, 12, 168, 255, 13, 160, 71, 117, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002436(
      [In] bool[] obj0,
      [In] float obj1,
      [In] float obj2,
      [In] Table obj3,
      [In] Mods.LoadedMod obj4)
    {
      if (!obj4.enabled() && !obj0[0] && Vars.mods.list().size > 0)
      {
        obj0[0] = true;
        obj3.row();
        obj3.image().growX().height(4f).pad(6f).color(Pal.gray);
        obj3.row();
      }
      obj3.button((Cons) new ModsDialog.__\u003C\u003EAnon51(this, obj4, obj1), (Button.ButtonStyle) Styles.clearPartialt, (Runnable) new ModsDialog.__\u003C\u003EAnon52(this, obj4)).size(obj2, obj1).growX().pad(4f);
      obj3.row();
    }

    [Modifiers]
    [LineNumberTable(310)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002437([In] Table obj0)
    {
      Table table = obj0;
      object obj = (object) "@mods.none";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text);
    }

    [Modifiers]
    [LineNumberTable(317)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024reload\u002438() => Core.app.exit();

    [Modifiers]
    [LineNumberTable(326)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showMod\u002439([In] Mods.LoadedMod obj0) => Core.app.openFolder(obj0.__\u003C\u003Efile.absolutePath());

    [Modifiers]
    [LineNumberTable(331)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showMod\u002440([In] Mods.LoadedMod obj0) => Core.app.openURI(new StringBuilder().append("https://github.com/").append(obj0.getRepo()).toString());

    [Modifiers]
    [LineNumberTable(333)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showMod\u002441([In] Mods.LoadedMod obj0) => this.githubImportMod(obj0.getRepo(), obj0.isJava());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 224, 103, 150, 127, 27, 103, 127, 23, 103, 112, 127, 17, 103, 127, 23, 135, 112, 127, 22, 103, 127, 23, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showMod\u002442([In] Mods.LoadedMod obj0, [In] Table obj1)
    {
      obj1.center();
      obj1.defaults().padTop(10f).left();
      Table table1 = obj1;
      object obj2 = (object) "@editor.name";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text1 = charSequence;
      table1.add(text1).padRight(10f).color(Color.__\u003C\u003Egray).padTop(0.0f);
      obj1.row();
      Table table2 = obj1;
      object obj3 = (object) obj0.__\u003C\u003Emeta.displayName();
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence text2 = charSequence;
      table2.add(text2).growX().wrap().padTop(2f);
      obj1.row();
      if (obj0.__\u003C\u003Emeta.author != null)
      {
        Table table3 = obj1;
        object obj4 = (object) "@editor.author";
        charSequence.__\u003Cref\u003E = (__Null) obj4;
        CharSequence text3 = charSequence;
        table3.add(text3).padRight(10f).color(Color.__\u003C\u003Egray);
        obj1.row();
        Table table4 = obj1;
        object author = (object) obj0.__\u003C\u003Emeta.author;
        charSequence.__\u003Cref\u003E = (__Null) author;
        CharSequence text4 = charSequence;
        table4.add(text4).growX().wrap().padTop(2f);
        obj1.row();
      }
      if (obj0.__\u003C\u003Emeta.description == null)
        return;
      Table table5 = obj1;
      object obj5 = (object) "@editor.description";
      charSequence.__\u003Cref\u003E = (__Null) obj5;
      CharSequence text5 = charSequence;
      table5.add(text5).padRight(10f).color(Color.__\u003C\u003Egray).top();
      obj1.row();
      Table table6 = obj1;
      object description = (object) obj0.__\u003C\u003Emeta.description;
      charSequence.__\u003Cref\u003E = (__Null) description;
      CharSequence text6 = charSequence;
      table6.add(text6).growX().wrap().padTop(2f);
      obj1.row();
    }

    [Modifiers]
    [LineNumberTable(360)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024showMod\u002443([In] Mods.LoadedMod obj0, [In] Content obj1) => object.ReferenceEquals((object) obj1.minfo.mod, (object) obj0) && obj1 is UnlockableContent;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 250, 118, 246, 77, 102, 102, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showMod\u002448([In] Mods.LoadedMod obj0, [In] Seq obj1)
    {
      BaseDialog.__\u003Cclinit\u003E();
      BaseDialog baseDialog = new BaseDialog(obj0.__\u003C\u003Emeta.displayName());
      baseDialog.__\u003C\u003Econt.pane((Cons) new ModsDialog.__\u003C\u003EAnon47(obj1)).grow();
      baseDialog.addCloseButton();
      baseDialog.show();
      this.currentContent = baseDialog;
    }

    [Modifiers]
    [LineNumberTable(394)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024rebuildBrowser\u002449([In] Mods.LoadedMod obj0) => obj0.getRepo();

    [Modifiers]
    [LineNumberTable(new byte[] {161, 32, 107, 130, 98, 104, 103, 177, 126, 159, 67, 135, 255, 17, 160, 75, 159, 14, 126, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildBrowser\u002458([In] ObjectSet obj0, [In] int obj1, [In] Seq obj2)
    {
      this.browserTable.clear();
      int num1 = 0;
      Seq seq = obj2;
      if (!this.orderDate)
      {
        seq = obj2.copy();
        seq.sortComparing((Func) new ModsDialog.__\u003C\u003EAnon38());
      }
      Iterator iterator = seq.iterator();
      while (iterator.hasNext())
      {
        ModListing modListing = (ModListing) iterator.next();
        if (!modListing.hasJava || !Vars.ios)
        {
          if (!String.instancehelper_isEmpty(this.searchtxt))
          {
            string lowerCase1 = String.instancehelper_toLowerCase(modListing.repo);
            object lowerCase2 = (object) String.instancehelper_toLowerCase(this.searchtxt);
            CharSequence charSequence1;
            charSequence1.__\u003Cref\u003E = (__Null) lowerCase2;
            CharSequence charSequence2 = charSequence1;
            if (!String.instancehelper_contains(lowerCase1, charSequence2))
              continue;
          }
          if (!Vars.ios || !modListing.hasScripts)
          {
            float num2 = 64f;
            this.browserTable.button((Cons) new ModsDialog.__\u003C\u003EAnon39(this, modListing, obj0, num2), (Button.ButtonStyle) Styles.clearPartialt, (Runnable) new ModsDialog.__\u003C\u003EAnon40(this, modListing)).width(438f).pad(4f).growX().left().height(num2 + 16f).fillY();
            ++num1;
            int num3 = num1;
            int num4 = obj1;
            if ((num4 != -1 ? num3 % num4 : 0) == 0)
              this.browserTable.row();
          }
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 145, 102, 191, 2, 2, 97, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024handleMod\u002459()
    {
      Exception exception;
      try
      {
        this.setup();
        Vars.ui.loadfrag.hide();
        return;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception t = exception;
      Vars.ui.showException(t);
    }

    [Modifiers]
    [LineNumberTable(527)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024importFail\u002460([In] Exception obj0) => this.modError(obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {161, 163, 111, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024githubImportMod\u002461([In] string obj0)
    {
      Vars.ui.loadfrag.show();
      this.githubImportJavaMod(obj0);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 169, 108, 108, 108, 209, 122, 137, 179})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024githubImportMod\u002462([In] string obj0, [In] Net.HttpResponse obj1)
    {
      if (!this.checkError(obj1))
        return;
      Jval jval = Jval.read(obj1.getResultAsString());
      string str1 = jval.getString("default_branch");
      string str2 = jval.getString("language", "<none>");
      if (String.instancehelper_equals(str2, (object) "Java") || String.instancehelper_equals(str2, (object) "Kotlin"))
        this.githubImportJavaMod(obj0);
      else
        this.githubImportBranch(str1, obj0, (Cons) new ModsDialog.__\u003C\u003EAnon37(this));
    }

    [LineNumberTable(new byte[] {161, 157, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void importFail([In] Exception obj0) => Core.app.post((Runnable) new ModsDialog.__\u003C\u003EAnon26(this, obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {161, 189, 108, 108, 177, 118, 156, 131, 109, 255, 4, 69, 98, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024githubImportJavaMod\u002466([In] string obj0, [In] Net.HttpResponse obj1)
    {
      if (!this.checkError(obj1))
        return;
      Jval.JsonArray jsonArray = Jval.read(obj1.getResultAsString()).get("assets").asArray();
      Jval jval = (Jval) jsonArray.find((Boolf) new ModsDialog.__\u003C\u003EAnon34()) ?? (Jval) jsonArray.find((Boolf) new ModsDialog.__\u003C\u003EAnon35());
      if (jval != null)
      {
        string url = jval.getString("browser_download_url");
        Core.net.httpGet(url, (Cons) new ModsDialog.__\u003C\u003EAnon36(this, obj0), (Cons) new ModsDialog.__\u003C\u003EAnon29(this));
      }
      else
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("No JAR file found in releases. Make sure you have a valid jar file in the mod's latest Github Release.");
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 223, 127, 19, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showStatus\u002467([In] Net.HttpStatus obj0)
    {
      Vars.ui.showErrorMessage(Core.bundle.format("connectfail", (object) Strings.capitalize(String.instancehelper_toLowerCase(obj0.toString()))));
      Vars.ui.loadfrag.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 230, 114, 109, 255, 16, 72, 170, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024githubImportBranch\u002469(
      [In] Cons obj0,
      [In] string obj1,
      [In] Net.HttpResponse obj2)
    {
      if (object.ReferenceEquals((object) obj2.getStatus(), (object) Net.HttpStatus.__\u003C\u003EOK))
      {
        if (obj2.getHeader("Location") != null)
          Core.net.httpGet(obj2.getHeader("Location"), (Cons) new ModsDialog.__\u003C\u003EAnon33(this, obj0, obj1), (Cons) new ModsDialog.__\u003C\u003EAnon29(this));
        else
          this.handleMod(obj1, obj2);
      }
      else
        obj0.get((object) obj2.getStatus());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 233, 114, 142, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024githubImportBranch\u002468(
      [In] Cons obj0,
      [In] string obj1,
      [In] Net.HttpResponse obj2)
    {
      if (!object.ReferenceEquals((object) obj2.getStatus(), (object) Net.HttpStatus.__\u003C\u003EOK))
        obj0.get((object) obj2.getStatus());
      else
        this.handleMod(obj1, obj2);
    }

    [Modifiers]
    [LineNumberTable(564)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024githubImportJavaMod\u002463([In] Jval obj0) => String.instancehelper_startsWith(obj0.getString("name"), "dexed") && String.instancehelper_endsWith(obj0.getString("name"), ".jar");

    [Modifiers]
    [LineNumberTable(565)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024githubImportJavaMod\u002464([In] Jval obj0) => String.instancehelper_endsWith(obj0.getString("name"), ".jar");

    [Modifiers]
    [LineNumberTable(new byte[] {161, 201, 105, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024githubImportJavaMod\u002465([In] string obj0, [In] Net.HttpResponse obj1)
    {
      if (!this.checkError(obj1))
        return;
      this.handleMod(obj0, obj1);
    }

    [Modifiers]
    [LineNumberTable(408)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Integer lambda\u0024rebuildBrowser\u002450([In] ModListing obj0) => Integer.valueOf(-obj0.stars);

    [Modifiers]
    [LineNumberTable(new byte[] {161, 47, 109, 136, 103, 241, 103, 144, 127, 2, 127, 13, 191, 56, 255, 54, 59, 250, 70, 159, 27})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildBrowser\u002451(
      [In] ModListing obj0,
      [In] ObjectSet obj1,
      [In] float obj2,
      [In] Button obj3)
    {
      obj3.margin(0.0f);
      obj3.left();
      string repo = obj0.repo;
      obj3.add((Element) new ModsDialog.\u0032(this, obj1, repo)).size(obj2).pad(8f);
      Button button = obj3;
      StringBuilder stringBuilder1 = new StringBuilder().append("[accent]");
      string name = obj0.name;
      object obj4 = (object) "";
      object obj5 = (object) "\n";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj5;
      CharSequence charSequence2 = charSequence1;
      object obj6 = obj4;
      charSequence1.__\u003Cref\u003E = (__Null) obj6;
      CharSequence charSequence3 = charSequence1;
      string str1 = String.instancehelper_replace(name, charSequence2, charSequence3);
      StringBuilder stringBuilder2 = stringBuilder1.append(str1).append(!obj1.contains((object) obj0.repo) ? "" : new StringBuilder().append("\n[lightgray]").append(Core.bundle.get("mod.installed")).toString()).append("\n[lightgray]\uE809 ").append(obj0.stars);
      string str2;
      if (mindustry.core.Version.isAtLeast(obj0.minGameVersion))
        str2 = "";
      else
        str2 = new StringBuilder().append("\n").append(Core.bundle.format("mod.requiresversion", (object) obj0.minGameVersion)).toString();
      object obj7 = (object) stringBuilder2.append(str2).toString();
      charSequence1.__\u003Cref\u003E = (__Null) obj7;
      CharSequence text = charSequence1;
      button.add(text).width(358f).wrap().grow().pad(4f, 2f, 4f, 6f).top().left().labelAlign(10);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 101, 113, 118, 102, 127, 6, 255, 2, 69, 127, 1, 223, 14, 191, 2, 125, 125, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildBrowser\u002457([In] ModListing obj0)
    {
      BaseDialog.__\u003Cclinit\u003E();
      BaseDialog baseDialog1 = new BaseDialog(obj0.name);
      baseDialog1.__\u003C\u003Econt.pane((Cons) new ModsDialog.__\u003C\u003EAnon41(obj0)).grow();
      baseDialog1.__\u003C\u003Ebuttons.defaults().size(150f, 54f).pad(2f);
      baseDialog1.__\u003C\u003Ebuttons.button("@back", (Drawable) Icon.left, (Runnable) new ModsDialog.__\u003C\u003EAnon42(baseDialog1));
      Mods.LoadedMod loadedMod = (Mods.LoadedMod) Vars.mods.list().find((Boolf) new ModsDialog.__\u003C\u003EAnon43(obj0));
      baseDialog1.__\u003C\u003Ebuttons.button(loadedMod != null ? "@mods.browser.reinstall" : "@mods.browser.add", (Drawable) Icon.download, (Runnable) new ModsDialog.__\u003C\u003EAnon44(this, baseDialog1, obj0));
      baseDialog1.__\u003C\u003Ebuttons.button("@mods.github.open", (Drawable) Icon.link, (Runnable) new ModsDialog.__\u003C\u003EAnon45(obj0));
      BaseDialog baseDialog2 = baseDialog1;
      KeyCode escape = KeyCode.__\u003C\u003Eescape;
      BaseDialog baseDialog3 = baseDialog1;
      Objects.requireNonNull((object) baseDialog3);
      Runnable l1 = (Runnable) new ModsDialog.__\u003C\u003EAnon46(baseDialog3);
      baseDialog2.keyDown(escape, l1);
      BaseDialog baseDialog4 = baseDialog1;
      KeyCode back = KeyCode.__\u003C\u003Eback;
      BaseDialog baseDialog5 = baseDialog1;
      Objects.requireNonNull((object) baseDialog5);
      Runnable l2 = (Runnable) new ModsDialog.__\u003C\u003EAnon46(baseDialog5);
      baseDialog4.keyDown(back, l2);
      baseDialog1.show();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 102, 127, 63, 63, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuildBrowser\u002452([In] ModListing obj0, [In] Table obj1)
    {
      Table table = obj1;
      object obj = (object) new StringBuilder().append(obj0.description).append("\n\n[accent]").append(Core.bundle.get("editor.author")).append("[lightgray] ").append(obj0.author).toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).width(!Vars.mobile ? 500f : 400f).wrap().pad(4f).labelAlign(1, 8);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 106, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuildBrowser\u002453([In] BaseDialog obj0)
    {
      obj0.clear();
      obj0.hide();
    }

    [Modifiers]
    [LineNumberTable(480)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024rebuildBrowser\u002454([In] ModListing obj0, [In] Mods.LoadedMod obj1) => obj0.repo != null && String.instancehelper_equals(obj0.repo, (object) obj1.getRepo());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 112, 102, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildBrowser\u002455([In] BaseDialog obj0, [In] ModListing obj1)
    {
      obj0.hide();
      this.githubImportMod(obj1.repo, obj1.hasJava);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 116, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuildBrowser\u002456([In] ModListing obj0) => Core.app.openURI(new StringBuilder().append("https://github.com/").append(obj0.repo).toString());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 252, 98, 126, 159, 23, 218, 134, 127, 26, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showMod\u002447([In] Seq obj0, [In] Table obj1)
    {
      int num = 0;
      Iterator iterator = obj0.iterator();
      while (iterator.hasNext())
      {
        UnlockableContent unlockableContent = (UnlockableContent) iterator.next();
        obj1.button((Drawable) new TextureRegionDrawable(unlockableContent.icon(Cicon.__\u003C\u003Emedium)), Styles.cleari, (float) Cicon.__\u003C\u003Emedium.__\u003C\u003Esize, (Runnable) new ModsDialog.__\u003C\u003EAnon48(unlockableContent)).size(50f).with((Cons) new ModsDialog.__\u003C\u003EAnon49()).tooltip(unlockableContent.localizedName);
        ++num;
        if ((double) ((float) num % Math.min((float) Core.graphics.getWidth() / Scl.scl(110f), 14f)) == 0.0)
          obj1.row();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 255, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showMod\u002444([In] UnlockableContent obj0) => Vars.ui.content.show(obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {161, 1, 103, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showMod\u002446([In] ImageButton obj0)
    {
      ClickListener clickListener = obj0.getClickListener();
      obj0.update((Runnable) new ModsDialog.__\u003C\u003EAnon50(obj0, clickListener));
    }

    [Modifiers]
    [LineNumberTable(372)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showMod\u002445([In] ImageButton obj0, [In] ClickListener obj1) => obj0.getImage().__\u003C\u003Ecolor.lerp(obj1.isOver() ? Color.__\u003C\u003Ewhite : Color.__\u003C\u003ElightGray, 0.4f * Time.delta);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 122, 108, 140, 113, 245, 103, 144, 242, 88, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002434([In] Mods.LoadedMod obj0, [In] float obj1, [In] Button obj2)
    {
      obj2.top().left();
      obj2.margin(12f);
      obj2.defaults().left().top();
      obj2.table((Cons) new ModsDialog.__\u003C\u003EAnon53(this, obj0, obj1, obj2)).growX().growY().left();
      obj2.table((Cons) new ModsDialog.__\u003C\u003EAnon54(this, obj0)).growX().right().padRight(-8f).padTop(-8f);
    }

    [Modifiers]
    [LineNumberTable(306)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002435([In] Mods.LoadedMod obj0) => this.showMod(obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 127, 136, 247, 71, 159, 5, 244, 88, 139, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002428(
      [In] Mods.LoadedMod obj0,
      [In] float obj1,
      [In] Button obj2,
      [In] Table obj3)
    {
      obj3.left();
      obj3.add((Element) new ModsDialog.\u0031(this, obj0)).size(obj1 - 8f).padTop(-8f).padLeft(-8f).padRight(8f);
      obj3.table((Cons) new ModsDialog.__\u003C\u003EAnon59(this, obj0, obj2)).top().growX();
      obj3.add().growX();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 168, 103, 191, 17, 151, 255, 17, 73, 134, 111, 103, 159, 1, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002433([In] Mods.LoadedMod obj0, [In] Table obj1)
    {
      obj1.right();
      obj1.button(!obj0.enabled() ? (Drawable) Icon.upOpen : (Drawable) Icon.downOpen, Styles.clearPartiali, (Runnable) new ModsDialog.__\u003C\u003EAnon55(this, obj0)).size(50f).disabled(!obj0.isSupported());
      obj1.button(!obj0.hasSteamID() ? (Drawable) Icon.trash : (Drawable) Icon.link, Styles.clearPartiali, (Runnable) new ModsDialog.__\u003C\u003EAnon56(this, obj0)).size(50f);
      if (!Vars.steam || obj0.hasSteamID())
        return;
      obj1.row();
      obj1.button((Drawable) Icon.export, Styles.clearPartiali, (Runnable) new ModsDialog.__\u003C\u003EAnon57(obj0)).size(50f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 170, 119, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002429([In] Mods.LoadedMod obj0)
    {
      Vars.mods.setEnabled(obj0, !obj0.enabled());
      this.setup();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 175, 104, 255, 3, 69, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002431([In] Mods.LoadedMod obj0)
    {
      if (!obj0.hasSteamID())
        Vars.ui.showConfirm("@confirm", "@mod.remove.confirm", (Runnable) new ModsDialog.__\u003C\u003EAnon58(this, obj0));
      else
        Vars.platform.viewListing((Publishable) obj0);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 188, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002432([In] Mods.LoadedMod obj0) => Vars.platform.publish((Publishable) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 177, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002430([In] Mods.LoadedMod obj0)
    {
      Vars.mods.removeMod(obj0);
      this.setup();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 139, 157, 127, 160, 110, 159, 0, 135, 104, 113, 108, 104, 127, 16, 108, 104, 127, 21, 105, 104, 113, 105, 109, 113, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002427([In] Mods.LoadedMod obj0, [In] Button obj1, [In] Table obj2)
    {
      int num = !obj0.isSupported() || obj0.hasUnmetDependencies() || obj0.hasContentErrors() ? 1 : 0;
      Table table = obj2;
      StringBuilder stringBuilder1 = new StringBuilder().append("[accent]");
      object obj3 = (object) obj0.__\u003C\u003Emeta.displayName();
      CharSequence str1;
      str1.__\u003Cref\u003E = (__Null) obj3;
      string str2 = Strings.stripColors(str1);
      StringBuilder stringBuilder2 = stringBuilder1.append(str2).append("\n[lightgray]v");
      object obj4 = (object) this.trimText(obj0.__\u003C\u003Emeta.version);
      str1.__\u003Cref\u003E = (__Null) obj4;
      string str3 = Strings.stripColors(str1);
      object obj5 = (object) stringBuilder2.append(str3).append(obj0.enabled() || num != 0 ? "" : new StringBuilder().append("\n").append(Core.bundle.get("mod.disabled")).append("").toString()).toString();
      str1.__\u003Cref\u003E = (__Null) obj5;
      CharSequence text = str1;
      table.add(text).wrap().top().width(300f).growX().left();
      obj2.row();
      if (obj0.isOutdated())
      {
        obj2.labelWrap("@mod.outdated").growX();
        obj2.row();
      }
      else if (!obj0.isSupported())
      {
        obj2.labelWrap(Core.bundle.format("mod.requiresversion", (object) obj0.__\u003C\u003Emeta.minGameVersion)).growX();
        obj2.row();
      }
      else if (obj0.hasUnmetDependencies())
      {
        obj2.labelWrap(Core.bundle.format("mod.missingdependencies", (object) obj0.missingDependencies.toString(", "))).growX();
        obj1.row();
      }
      else if (obj0.hasContentErrors())
      {
        obj2.labelWrap("@mod.erroredcontent").growX();
        obj2.row();
      }
      else
      {
        if (!obj0.__\u003C\u003Emeta.hidden)
          return;
        obj2.labelWrap("@mod.multiplayer.compatible").growX();
        obj2.row();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {115, 139, 134, 254, 107, 134, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002424()
    {
      BaseDialog baseDialog = new BaseDialog("@mod.import");
      TextButton.TextButtonStyle cleart = Styles.cleart;
      baseDialog.__\u003C\u003Econt.table((Drawable) Tex.button, (Cons) new ModsDialog.__\u003C\u003EAnon62(this, cleart, baseDialog));
      baseDialog.addCloseButton();
      baseDialog.show();
    }

    [LineNumberTable(new byte[] {161, 19, 102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void showModBrowser()
    {
      this.rebuildBrowser();
      this.browser.show();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {120, 118, 140, 255, 3, 85, 134, 135, 255, 3, 76, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002423(
      [In] TextButton.TextButtonStyle obj0,
      [In] BaseDialog obj1,
      [In] Table obj2)
    {
      obj2.defaults().size(300f, 70f);
      obj2.margin(12f);
      obj2.button("@mod.import.file", (Drawable) Icon.file, obj0, (Runnable) new ModsDialog.__\u003C\u003EAnon63(this, obj1)).margin(12f);
      obj2.row();
      obj2.button("@mod.import.github", (Drawable) Icon.github, obj0, (Runnable) new ModsDialog.__\u003C\u003EAnon64(this, obj1)).margin(12f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {124, 134, 255, 12, 82})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002420([In] BaseDialog obj0)
    {
      obj0.hide();
      Vars.platform.showMultiFileChooser((Cons) new ModsDialog.__\u003C\u003EAnon66(this), "zip", "jar");
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 85, 134, 255, 22, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002422([In] BaseDialog obj0)
    {
      obj0.hide();
      Vars.ui.showTextInput("@mod.import.github", "", 64, Core.settings.getString("lastmod", ""), (Cons) new ModsDialog.__\u003C\u003EAnon65(this));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 89, 127, 26, 159, 0, 144, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002421([In] string obj0)
    {
      string str = String.instancehelper_trim(obj0);
      object obj1 = (object) "";
      object obj2 = (object) " ";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj2;
      CharSequence charSequence2 = charSequence1;
      object obj3 = obj1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence charSequence3 = charSequence1;
      obj0 = String.instancehelper_replace(str, charSequence2, charSequence3);
      if (String.instancehelper_startsWith(obj0, "https://github.com/"))
        obj0 = String.instancehelper_substring(obj0, String.instancehelper_length("https://github.com/"));
      Core.settings.put("lastmod", (object) obj0);
      this.githubImportMod(obj0, false);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {127, 237, 75, 109, 151, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002419([In] Fi obj0)
    {
      Runnable confirmed = (Runnable) new ModsDialog.__\u003C\u003EAnon67(this, obj0);
      if (obj0.extEquals("jar"))
        Vars.ui.showConfirm("@warning", "@mod.jarwarn", confirmed);
      else
        confirmed.run();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 65, 108, 216, 226, 61, 97, 107, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002418([In] Fi obj0)
    {
      IOException ioException1;
      try
      {
        Vars.mods.importMod(obj0);
        this.setup();
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Vars.ui.showException((Exception) ioException2);
      Throwable.instancehelper_printStackTrace((Exception) ioException2);
    }

    [Modifiers]
    [LineNumberTable(143)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024getModList\u002416([In] Exception obj0) => this.modError(obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {69, 109, 191, 9, 159, 1, 107, 236, 72, 123, 223, 4, 226, 61, 97, 102, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024getModList\u002414([In] Net.HttpStatus obj0, [In] string obj1, [In] Cons obj2)
    {
      if (!object.ReferenceEquals((object) obj0, (object) Net.HttpStatus.__\u003C\u003EOK))
      {
        Vars.ui.showErrorMessage(Core.bundle.format("connectfail", (object) obj0));
      }
      else
      {
        Exception exception1;
        try
        {
          this.modList = (Seq) JsonIO.__\u003C\u003Ejson.fromJson((Class) ClassLiteral<Seq>.Value, (Class) ClassLiteral<ModListing>.Value, obj1);
          this.modList.sortComparing((Func) new ModsDialog.__\u003C\u003EAnon71((Func) new ModsDialog.__\u003C\u003EAnon70(new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'")))).reverse();
          obj2.get((object) this.modList);
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
    }

    [Modifiers]
    [LineNumberTable(new byte[] {78, 127, 3, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Date lambda\u0024getModList\u002412([In] SimpleDateFormat obj0, [In] string obj1)
    {
      Date date;
      Exception exception1;
      try
      {
        date = ((DateFormat) obj0).parse(obj1);
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
          goto label_5;
        }
      }
      return date;
label_5:
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) exception2);
    }

    [Modifiers]
    [LineNumberTable(134)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Date lambda\u0024getModList\u002413([In] Func obj0, [In] ModListing obj1) => (Date) obj0.get((object) obj1.lastUpdated);

    [Modifiers]
    [LineNumberTable(new byte[] {7, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] string obj0)
    {
      this.searchtxt = obj0;
      this.rebuildBrowser();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {11, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241()
    {
      this.orderDate = !this.orderDate;
      this.rebuildBrowser();
    }

    [Modifiers]
    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242([In] ImageButton obj0) => obj0.getStyle().imageUp = !this.orderDate ? (Drawable) Icon.star : (Drawable) Icon.list;

    [Modifiers]
    [LineNumberTable(64)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00244([In] Table obj0) => obj0.label((Prov) new ModsDialog.__\u003C\u003EAnon76(this)).left();

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private CharSequence lambda\u0024new\u00243()
    {
      object obj = !this.orderDate ? (object) "@mods.browser.sortstars" : (object) "@mods.browser.sortdate";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static ObjectMap access\u0024000([In] ModsDialog obj0) => obj0.textureCache;

    [HideFromJava]
    static ModsDialog() => BaseDialog.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "setup", "()V")]
    [SpecialName]
    internal new class \u0031 : BorderImage
    {
      [Modifiers]
      internal Mods.LoadedMod val\u0024mod;
      [Modifiers]
      internal ModsDialog this\u00240;

      [LineNumberTable(new byte[] {160, 129, 118, 109, 152, 139, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] ModsDialog obj0, [In] Mods.LoadedMod obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024mod = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ModsDialog.\u0031 obj = this;
        if (this.val\u0024mod.iconTexture != null)
          this.setDrawable(new TextureRegion(this.val\u0024mod.iconTexture));
        else
          this.setDrawable((Drawable) Tex.nomap);
        this.border(Pal.accent);
      }
    }

    [EnclosingMethod(null, "rebuildBrowser", "()V")]
    [SpecialName]
    internal new class \u0032 : BorderImage
    {
      internal TextureRegion last;
      [Modifiers]
      internal ObjectSet val\u0024installed;
      [Modifiers]
      internal string val\u0024repo;
      [Modifiers]
      internal ModsDialog this\u00240;

      [LineNumberTable(new byte[] {161, 51, 221, 127, 7, 107, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] ModsDialog obj0, [In] ObjectSet obj1, [In] string obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024installed = obj1;
        this.val\u0024repo = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ModsDialog.\u0032 obj = this;
        this.border(!this.val\u0024installed.contains((object) this.val\u0024repo) ? Color.__\u003C\u003ElightGray : Pal.accent);
        this.setDrawable((Drawable) Tex.nomap);
        this.pad = Scl.scl(4f);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 68, 114, 108, 247, 75})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024draw\u00241([In] string obj0, [In] Net.HttpResponse obj1)
      {
        if (!object.ReferenceEquals((object) obj1.getStatus(), (object) Net.HttpStatus.__\u003C\u003EOK))
          return;
        Pixmap pixmap = new Pixmap(obj1.getResult());
        Core.app.post((Runnable) new ModsDialog.\u0032.__\u003C\u003EAnon2(this, pixmap, obj0));
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024draw\u00242([In] Exception obj0)
      {
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 72, 103, 107, 120, 189, 2, 97, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024draw\u00240([In] Pixmap obj0, [In] string obj1)
      {
        Exception exception;
        try
        {
          Texture texture = new Texture(obj0);
          texture.setFilter(Texture.TextureFilter.__\u003C\u003Elinear);
          ModsDialog.access\u0024000(this.this\u00240).put((object) obj1, (object) new TextureRegion(texture));
          obj0.dispose();
          return;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            exception = (Exception) m0;
        }
        Log.err((Exception) exception);
      }

      [LineNumberTable(new byte[] {161, 62, 166, 123, 127, 13, 255, 86, 81, 125, 111, 104, 136})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        if (!ModsDialog.access\u0024000(this.this\u00240).containsKey((object) this.val\u0024repo))
        {
          ObjectMap objectMap = ModsDialog.access\u0024000(this.this\u00240);
          string valRepo1 = this.val\u0024repo;
          ModsDialog.\u0032 obj1 = this;
          TextureRegion region = Tex.nomap.getRegion();
          TextureRegion textureRegion = region;
          this.last = region;
          objectMap.put((object) valRepo1, (object) textureRegion);
          Net net = Core.net;
          StringBuilder stringBuilder = new StringBuilder().append("https://raw.githubusercontent.com/Anuken/MindustryMods/master/icons/");
          string valRepo2 = this.val\u0024repo;
          object obj2 = (object) "_";
          object obj3 = (object) "/";
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj3;
          CharSequence charSequence2 = charSequence1;
          object obj4 = obj2;
          charSequence1.__\u003Cref\u003E = (__Null) obj4;
          CharSequence charSequence3 = charSequence1;
          string str = String.instancehelper_replace(valRepo2, charSequence2, charSequence3);
          string url = stringBuilder.append(str).toString();
          Cons success = (Cons) new ModsDialog.\u0032.__\u003C\u003EAnon0(this, this.val\u0024repo);
          Cons failure = (Cons) new ModsDialog.\u0032.__\u003C\u003EAnon1();
          net.httpGet(url, success, failure);
        }
        TextureRegion region1 = (TextureRegion) ModsDialog.access\u0024000(this.this\u00240).get((object) this.val\u0024repo);
        if (object.ReferenceEquals((object) this.last, (object) region1))
          return;
        this.last = region1;
        this.setDrawable(region1);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly ModsDialog.\u0032 arg\u00241;
        private readonly string arg\u00242;

        internal __\u003C\u003EAnon0([In] ModsDialog.\u0032 obj0, [In] string obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024draw\u00241(this.arg\u00242, (Net.HttpResponse) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public void get([In] object obj0) => ModsDialog.\u0032.lambda\u0024draw\u00242((Exception) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Runnable
      {
        private readonly ModsDialog.\u0032 arg\u00241;
        private readonly Pixmap arg\u00242;
        private readonly string arg\u00243;

        internal __\u003C\u003EAnon2([In] ModsDialog.\u0032 obj0, [In] Pixmap obj1, [In] string obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024draw\u00240(this.arg\u00242, this.arg\u00243);
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00245((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00246((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon2([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.rebuildBrowser();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void run() => ModsDialog.lambda\u0024new\u00247();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public void run() => ModsDialog.lambda\u0024new\u00248();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon5([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon6([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00249((EventType.ResizeEvent) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon7([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002410();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Boolf
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public bool get([In] object obj0) => (ModsDialog.lambda\u0024modError\u002411((Exception) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      private readonly ModsDialog arg\u00241;
      private readonly Cons arg\u00242;

      internal __\u003C\u003EAnon9([In] ModsDialog obj0, [In] Cons obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024getModList\u002415(this.arg\u00242, (Net.HttpResponse) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon10([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024getModList\u002417((Exception) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Boolp
    {
      private readonly Mods arg\u00241;

      internal __\u003C\u003EAnon11([In] Mods obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.requiresReload() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Cons
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon12([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002425((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Func
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public object get([In] object obj0) => (object) ModsDialog.lambda\u0024setup\u002426((Mods.LoadedMod) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Cons2
    {
      private readonly ModsDialog arg\u00241;
      private readonly bool[] arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;

      internal __\u003C\u003EAnon14([In] ModsDialog obj0, [In] bool[] obj1, [In] float obj2, [In] float obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024setup\u002436(this.arg\u00242, this.arg\u00243, this.arg\u00244, (Table) obj0, (Mods.LoadedMod) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Cons
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public void get([In] object obj0) => ModsDialog.lambda\u0024setup\u002437((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public void run() => ModsDialog.lambda\u0024reload\u002438();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Runnable
    {
      private readonly Mods.LoadedMod arg\u00241;

      internal __\u003C\u003EAnon17([In] Mods.LoadedMod obj0) => this.arg\u00241 = obj0;

      public void run() => ModsDialog.lambda\u0024showMod\u002439(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Runnable
    {
      private readonly Mods.LoadedMod arg\u00241;

      internal __\u003C\u003EAnon18([In] Mods.LoadedMod obj0) => this.arg\u00241 = obj0;

      public void run() => ModsDialog.lambda\u0024showMod\u002440(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Runnable
    {
      private readonly ModsDialog arg\u00241;
      private readonly Mods.LoadedMod arg\u00242;

      internal __\u003C\u003EAnon19([In] ModsDialog obj0, [In] Mods.LoadedMod obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024showMod\u002441(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Cons
    {
      private readonly Mods.LoadedMod arg\u00241;

      internal __\u003C\u003EAnon20([In] Mods.LoadedMod obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => ModsDialog.lambda\u0024showMod\u002442(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Boolf
    {
      private readonly Mods.LoadedMod arg\u00241;

      internal __\u003C\u003EAnon21([In] Mods.LoadedMod obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (ModsDialog.lambda\u0024showMod\u002443(this.arg\u00241, (Content) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Runnable
    {
      private readonly ModsDialog arg\u00241;
      private readonly Mods.LoadedMod arg\u00242;
      private readonly Seq arg\u00243;

      internal __\u003C\u003EAnon22([In] ModsDialog obj0, [In] Mods.LoadedMod obj1, [In] Seq obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024showMod\u002448(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Func
    {
      internal __\u003C\u003EAnon23()
      {
      }

      public object get([In] object obj0) => (object) ModsDialog.lambda\u0024rebuildBrowser\u002449((Mods.LoadedMod) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Cons
    {
      private readonly ModsDialog arg\u00241;
      private readonly ObjectSet arg\u00242;
      private readonly int arg\u00243;

      internal __\u003C\u003EAnon24([In] ModsDialog obj0, [In] ObjectSet obj1, [In] int obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuildBrowser\u002458(this.arg\u00242, this.arg\u00243, (Seq) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Runnable
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon25([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024handleMod\u002459();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Runnable
    {
      private readonly ModsDialog arg\u00241;
      private readonly Exception arg\u00242;

      internal __\u003C\u003EAnon26([In] ModsDialog obj0, [In] Exception obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024importFail\u002460(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Runnable
    {
      private readonly ModsDialog arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon27([In] ModsDialog obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024githubImportMod\u002461(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Cons
    {
      private readonly ModsDialog arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon28([In] ModsDialog obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024githubImportMod\u002462(this.arg\u00242, (Net.HttpResponse) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Cons
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon29([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.importFail((Exception) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Cons
    {
      private readonly ModsDialog arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon30([In] ModsDialog obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024githubImportJavaMod\u002466(this.arg\u00242, (Net.HttpResponse) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Runnable
    {
      private readonly Net.HttpStatus arg\u00241;

      internal __\u003C\u003EAnon31([In] Net.HttpStatus obj0) => this.arg\u00241 = obj0;

      public void run() => ModsDialog.lambda\u0024showStatus\u002467(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Cons
    {
      private readonly ModsDialog arg\u00241;
      private readonly Cons arg\u00242;
      private readonly string arg\u00243;

      internal __\u003C\u003EAnon32([In] ModsDialog obj0, [In] Cons obj1, [In] string obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024githubImportBranch\u002469(this.arg\u00242, this.arg\u00243, (Net.HttpResponse) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Cons
    {
      private readonly ModsDialog arg\u00241;
      private readonly Cons arg\u00242;
      private readonly string arg\u00243;

      internal __\u003C\u003EAnon33([In] ModsDialog obj0, [In] Cons obj1, [In] string obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024githubImportBranch\u002468(this.arg\u00242, this.arg\u00243, (Net.HttpResponse) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Boolf
    {
      internal __\u003C\u003EAnon34()
      {
      }

      public bool get([In] object obj0) => (ModsDialog.lambda\u0024githubImportJavaMod\u002463((Jval) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Boolf
    {
      internal __\u003C\u003EAnon35()
      {
      }

      public bool get([In] object obj0) => (ModsDialog.lambda\u0024githubImportJavaMod\u002464((Jval) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : Cons
    {
      private readonly ModsDialog arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon36([In] ModsDialog obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024githubImportJavaMod\u002465(this.arg\u00242, (Net.HttpResponse) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon37 : Cons
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon37([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.showStatus((Net.HttpStatus) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon38 : Func
    {
      internal __\u003C\u003EAnon38()
      {
      }

      public object get([In] object obj0) => (object) ModsDialog.lambda\u0024rebuildBrowser\u002450((ModListing) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon39 : Cons
    {
      private readonly ModsDialog arg\u00241;
      private readonly ModListing arg\u00242;
      private readonly ObjectSet arg\u00243;
      private readonly float arg\u00244;

      internal __\u003C\u003EAnon39([In] ModsDialog obj0, [In] ModListing obj1, [In] ObjectSet obj2, [In] float obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuildBrowser\u002451(this.arg\u00242, this.arg\u00243, this.arg\u00244, (Button) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon40 : Runnable
    {
      private readonly ModsDialog arg\u00241;
      private readonly ModListing arg\u00242;

      internal __\u003C\u003EAnon40([In] ModsDialog obj0, [In] ModListing obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024rebuildBrowser\u002457(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon41 : Cons
    {
      private readonly ModListing arg\u00241;

      internal __\u003C\u003EAnon41([In] ModListing obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => ModsDialog.lambda\u0024rebuildBrowser\u002452(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon42 : Runnable
    {
      private readonly BaseDialog arg\u00241;

      internal __\u003C\u003EAnon42([In] BaseDialog obj0) => this.arg\u00241 = obj0;

      public void run() => ModsDialog.lambda\u0024rebuildBrowser\u002453(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon43 : Boolf
    {
      private readonly ModListing arg\u00241;

      internal __\u003C\u003EAnon43([In] ModListing obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (ModsDialog.lambda\u0024rebuildBrowser\u002454(this.arg\u00241, (Mods.LoadedMod) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon44 : Runnable
    {
      private readonly ModsDialog arg\u00241;
      private readonly BaseDialog arg\u00242;
      private readonly ModListing arg\u00243;

      internal __\u003C\u003EAnon44([In] ModsDialog obj0, [In] BaseDialog obj1, [In] ModListing obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024rebuildBrowser\u002455(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon45 : Runnable
    {
      private readonly ModListing arg\u00241;

      internal __\u003C\u003EAnon45([In] ModListing obj0) => this.arg\u00241 = obj0;

      public void run() => ModsDialog.lambda\u0024rebuildBrowser\u002456(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon46 : Runnable
    {
      private readonly BaseDialog arg\u00241;

      internal __\u003C\u003EAnon46([In] BaseDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon47 : Cons
    {
      private readonly Seq arg\u00241;

      internal __\u003C\u003EAnon47([In] Seq obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => ModsDialog.lambda\u0024showMod\u002447(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon48 : Runnable
    {
      private readonly UnlockableContent arg\u00241;

      internal __\u003C\u003EAnon48([In] UnlockableContent obj0) => this.arg\u00241 = obj0;

      public void run() => ModsDialog.lambda\u0024showMod\u002444(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon49 : Cons
    {
      internal __\u003C\u003EAnon49()
      {
      }

      public void get([In] object obj0) => ModsDialog.lambda\u0024showMod\u002446((ImageButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon50 : Runnable
    {
      private readonly ImageButton arg\u00241;
      private readonly ClickListener arg\u00242;

      internal __\u003C\u003EAnon50([In] ImageButton obj0, [In] ClickListener obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => ModsDialog.lambda\u0024showMod\u002445(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon51 : Cons
    {
      private readonly ModsDialog arg\u00241;
      private readonly Mods.LoadedMod arg\u00242;
      private readonly float arg\u00243;

      internal __\u003C\u003EAnon51([In] ModsDialog obj0, [In] Mods.LoadedMod obj1, [In] float obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002434(this.arg\u00242, this.arg\u00243, (Button) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon52 : Runnable
    {
      private readonly ModsDialog arg\u00241;
      private readonly Mods.LoadedMod arg\u00242;

      internal __\u003C\u003EAnon52([In] ModsDialog obj0, [In] Mods.LoadedMod obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u002435(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon53 : Cons
    {
      private readonly ModsDialog arg\u00241;
      private readonly Mods.LoadedMod arg\u00242;
      private readonly float arg\u00243;
      private readonly Button arg\u00244;

      internal __\u003C\u003EAnon53([In] ModsDialog obj0, [In] Mods.LoadedMod obj1, [In] float obj2, [In] Button obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002428(this.arg\u00242, this.arg\u00243, this.arg\u00244, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon54 : Cons
    {
      private readonly ModsDialog arg\u00241;
      private readonly Mods.LoadedMod arg\u00242;

      internal __\u003C\u003EAnon54([In] ModsDialog obj0, [In] Mods.LoadedMod obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002433(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon55 : Runnable
    {
      private readonly ModsDialog arg\u00241;
      private readonly Mods.LoadedMod arg\u00242;

      internal __\u003C\u003EAnon55([In] ModsDialog obj0, [In] Mods.LoadedMod obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u002429(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon56 : Runnable
    {
      private readonly ModsDialog arg\u00241;
      private readonly Mods.LoadedMod arg\u00242;

      internal __\u003C\u003EAnon56([In] ModsDialog obj0, [In] Mods.LoadedMod obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u002431(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon57 : Runnable
    {
      private readonly Mods.LoadedMod arg\u00241;

      internal __\u003C\u003EAnon57([In] Mods.LoadedMod obj0) => this.arg\u00241 = obj0;

      public void run() => ModsDialog.lambda\u0024setup\u002432(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon58 : Runnable
    {
      private readonly ModsDialog arg\u00241;
      private readonly Mods.LoadedMod arg\u00242;

      internal __\u003C\u003EAnon58([In] ModsDialog obj0, [In] Mods.LoadedMod obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u002430(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon59 : Cons
    {
      private readonly ModsDialog arg\u00241;
      private readonly Mods.LoadedMod arg\u00242;
      private readonly Button arg\u00243;

      internal __\u003C\u003EAnon59([In] ModsDialog obj0, [In] Mods.LoadedMod obj1, [In] Button obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002427(this.arg\u00242, this.arg\u00243, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon60 : Runnable
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon60([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setup\u002424();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon61 : Runnable
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon61([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.showModBrowser();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon62 : Cons
    {
      private readonly ModsDialog arg\u00241;
      private readonly TextButton.TextButtonStyle arg\u00242;
      private readonly BaseDialog arg\u00243;

      internal __\u003C\u003EAnon62(
        [In] ModsDialog obj0,
        [In] TextButton.TextButtonStyle obj1,
        [In] BaseDialog obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002423(this.arg\u00242, this.arg\u00243, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon63 : Runnable
    {
      private readonly ModsDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon63([In] ModsDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u002420(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon64 : Runnable
    {
      private readonly ModsDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon64([In] ModsDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u002422(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon65 : Cons
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon65([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002421((string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon66 : Cons
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon66([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002419((Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon67 : Runnable
    {
      private readonly ModsDialog arg\u00241;
      private readonly Fi arg\u00242;

      internal __\u003C\u003EAnon67([In] ModsDialog obj0, [In] Fi obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u002418(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon68 : Runnable
    {
      private readonly ModsDialog arg\u00241;
      private readonly Exception arg\u00242;

      internal __\u003C\u003EAnon68([In] ModsDialog obj0, [In] Exception obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024getModList\u002416(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon69 : Runnable
    {
      private readonly ModsDialog arg\u00241;
      private readonly Net.HttpStatus arg\u00242;
      private readonly string arg\u00243;
      private readonly Cons arg\u00244;

      internal __\u003C\u003EAnon69([In] ModsDialog obj0, [In] Net.HttpStatus obj1, [In] string obj2, [In] Cons obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void run() => this.arg\u00241.lambda\u0024getModList\u002414(this.arg\u00242, this.arg\u00243, this.arg\u00244);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon70 : Func
    {
      private readonly SimpleDateFormat arg\u00241;

      internal __\u003C\u003EAnon70([In] SimpleDateFormat obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) ModsDialog.lambda\u0024getModList\u002412(this.arg\u00241, (string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon71 : Func
    {
      private readonly Func arg\u00241;

      internal __\u003C\u003EAnon71([In] Func obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) ModsDialog.lambda\u0024getModList\u002413(this.arg\u00241, (ModListing) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon72 : Cons
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon72([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240((string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon73 : Runnable
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon73([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00241();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon74 : Cons
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon74([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00242((ImageButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon75 : Cons
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon75([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00244((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon76 : Prov
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon76([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024new\u00243().__\u003Cref\u003E;
    }
  }
}
