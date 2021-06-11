// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.SchematicsDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.files;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.input;
using arc.math;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.core;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.input;
using mindustry.type;
using mindustry.world.blocks.storage;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class SchematicsDialog : BaseDialog
  {
    private SchematicsDialog.SchematicInfoDialog info;
    private Schematic firstSchematic;
    private string search;
    private TextField searchField;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 174, 237, 58, 139, 235, 69, 159, 4, 103, 102, 127, 2, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SchematicsDialog()
      : base("@schematics")
    {
      SchematicsDialog schematicsDialog = this;
      this.info = new SchematicsDialog.SchematicInfoDialog();
      this.search = "";
      Core.assets.load("sprites/schematic-background.png", (Class) ClassLiteral<Texture>.Value).loaded = (Cons) new SchematicsDialog.__\u003C\u003EAnon0();
      this.shouldPause = true;
      this.addCloseButton();
      this.__\u003C\u003Ebuttons.button("@schematic.import", (Drawable) Icon.download, (Runnable) new SchematicsDialog.__\u003C\u003EAnon1(this));
      this.shown((Runnable) new SchematicsDialog.__\u003C\u003EAnon2(this));
      this.onResize((Runnable) new SchematicsDialog.__\u003C\u003EAnon2(this));
    }

    [LineNumberTable(new byte[] {160, 82, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showInfo(Schematic schematic) => this.info.show(schematic);

    [LineNumberTable(new byte[] {160, 172, 135, 108, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Dialog show()
    {
      base.show();
      if (Core.app.isDesktop())
        this.focusSearchField();
      return (Dialog) this;
    }

    [LineNumberTable(new byte[] {160, 165, 137, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void focusSearchField()
    {
      if (this.searchField == null)
        return;
      Core.scene.setKeyboardFocus((Element) this.searchField);
    }

    [LineNumberTable(new byte[] {159, 185, 107, 139, 108, 139, 247, 71, 144, 140, 247, 160, 132, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setup()
    {
      this.search = "";
      Runnable[] runnableArray = new Runnable[1]
      {
        (Runnable) null
      };
      this.__\u003C\u003Econt.top();
      this.__\u003C\u003Econt.clear();
      this.__\u003C\u003Econt.table((Cons) new SchematicsDialog.__\u003C\u003EAnon3(this, runnableArray)).fillX().padBottom(4f);
      this.__\u003C\u003Econt.row();
      ((ScrollPane) this.__\u003C\u003Econt.pane((Cons) new SchematicsDialog.__\u003C\u003EAnon4(this, runnableArray)).get()).setScrollingDisabled(true, false);
    }

    [LineNumberTable(new byte[] {160, 135, 107, 248, 88, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showExport(Schematic s)
    {
      BaseDialog baseDialog = new BaseDialog("@editor.export");
      baseDialog.__\u003C\u003Econt.pane((Cons) new SchematicsDialog.__\u003C\u003EAnon6(s, baseDialog));
      baseDialog.addCloseButton();
      baseDialog.show();
    }

    [Modifiers]
    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] object obj0) => ((GLTexture) obj0).setWrap(Texture.TextureWrap.__\u003C\u003Erepeat);

    [LineNumberTable(new byte[] {160, 86, 107, 248, 107, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showImport()
    {
      BaseDialog baseDialog = new BaseDialog("@editor.export");
      baseDialog.__\u003C\u003Econt.pane((Cons) new SchematicsDialog.__\u003C\u003EAnon5(this, baseDialog));
      baseDialog.addCloseButton();
      baseDialog.show();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {0, 103, 108, 185, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00242([In] Runnable[] obj0, [In] Table obj1)
    {
      obj1.left();
      obj1.image((Drawable) Icon.zoom);
      this.searchField = (TextField) obj1.field(this.search, (Cons) new SchematicsDialog.__\u003C\u003EAnon31(this, obj0)).growX().get();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {11, 103, 140, 242, 75, 240, 160, 116, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002416([In] Runnable[] obj0, [In] Table obj1)
    {
      obj1.top();
      obj1.margin(20f);
      obj1.update((Runnable) new SchematicsDialog.__\u003C\u003EAnon18(this));
      obj0[0] = (Runnable) new SchematicsDialog.__\u003C\u003EAnon19(this, obj1, obj0);
      obj0[0].run();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 88, 108, 248, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showImport\u002423([In] BaseDialog obj0, [In] Table obj1)
    {
      obj1.margin(10f);
      obj1.table((Drawable) Tex.button, (Cons) new SchematicsDialog.__\u003C\u003EAnon12(this, obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 137, 108, 248, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showExport\u002429([In] Schematic obj0, [In] BaseDialog obj1, [In] Table obj2)
    {
      obj2.margin(10f);
      obj2.table((Drawable) Tex.button, (Cons) new SchematicsDialog.__\u003C\u003EAnon7(obj0, obj1));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 139, 102, 123, 111, 127, 2, 102, 103, 134, 223, 3, 102, 103, 191, 3, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showExport\u002428([In] Schematic obj0, [In] BaseDialog obj1, [In] Table obj2)
    {
      TextButton.TextButtonStyle cleart = Styles.cleart;
      obj2.defaults().size(280f, 60f).left();
      if (Vars.steam && !obj0.hasSteamID())
      {
        obj2.button("@schematic.shareworkshop", (Drawable) Icon.book, cleart, (Runnable) new SchematicsDialog.__\u003C\u003EAnon8(obj0)).marginLeft(12f);
        obj2.row();
        obj1.hide();
      }
      obj2.button("@schematic.copy", (Drawable) Icon.copy, cleart, (Runnable) new SchematicsDialog.__\u003C\u003EAnon9(obj1, obj0)).marginLeft(12f);
      obj2.row();
      obj2.button("@schematic.exportfile", (Drawable) Icon.export, cleart, (Runnable) new SchematicsDialog.__\u003C\u003EAnon10(obj1, obj0)).marginLeft(12f);
    }

    [Modifiers]
    [LineNumberTable(257)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showExport\u002424([In] Schematic obj0) => Vars.platform.publish((Publishable) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 148, 102, 111, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showExport\u002425([In] BaseDialog obj0, [In] Schematic obj1)
    {
      obj0.hide();
      Vars.ui.showInfoFade("@copied");
      Core.app.setClipboardText(Vars.schematics.writeBase64(obj1));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 154, 102, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showExport\u002427([In] BaseDialog obj0, [In] Schematic obj1)
    {
      obj0.hide();
      Vars.platform.export(obj1.name(), "msch", (Platform.FileWriter) new SchematicsDialog.__\u003C\u003EAnon11(obj1));
    }

    [Throws(new string[] {"java.lang.Throwable"})]
    [Modifiers]
    [LineNumberTable(269)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showExport\u002426([In] Schematic obj0, [In] Fi obj1) => Schematics.write(obj0, obj1);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 90, 102, 123, 103, 255, 3, 76, 117, 103, 255, 3, 76, 102, 103, 103, 191, 2, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showImport\u002422([In] BaseDialog obj0, [In] Table obj1)
    {
      TextButton.TextButtonStyle cleart = Styles.cleart;
      obj1.defaults().size(280f, 60f).left();
      obj1.row();
      obj1.button("@schematic.copy.import", (Drawable) Icon.copy, cleart, (Runnable) new SchematicsDialog.__\u003C\u003EAnon13(this, obj0)).marginLeft(12f).disabled((Boolf) new SchematicsDialog.__\u003C\u003EAnon14());
      obj1.row();
      obj1.button("@schematic.importfile", (Drawable) Icon.download, cleart, (Runnable) new SchematicsDialog.__\u003C\u003EAnon15(this, obj0)).marginLeft(12f);
      obj1.row();
      if (!Vars.steam)
        return;
      obj1.button("@schematic.browseworkshop", (Drawable) Icon.book, cleart, (Runnable) new SchematicsDialog.__\u003C\u003EAnon16(obj0)).marginLeft(12f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 94, 134, 112, 102, 107, 102, 111, 185, 2, 97, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showImport\u002417([In] BaseDialog obj0)
    {
      obj0.hide();
      Exception exception;
      try
      {
        Schematic schematic = Schematics.readBase64(Core.app.getClipboardText());
        schematic.removeSteamID();
        Vars.schematics.add(schematic);
        this.setup();
        Vars.ui.showInfoFade("@schematic.saved");
        this.showInfo(schematic);
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
    [LineNumberTable(219)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024showImport\u002418([In] TextButton obj0) => Core.app.getClipboardText() == null || !String.instancehelper_startsWith(Core.app.getClipboardText(), "bXNjaA");

    [Modifiers]
    [LineNumberTable(221)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showImport\u002420([In] BaseDialog obj0) => Vars.platform.showFileChooser(true, "msch", (Cons) new SchematicsDialog.__\u003C\u003EAnon17(this, obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {160, 123, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showImport\u002421([In] BaseDialog obj0)
    {
      obj0.hide();
      Vars.platform.openWorkshop();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 108, 166, 103, 102, 107, 102, 190, 2, 97, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showImport\u002419([In] BaseDialog obj0, [In] Fi obj1)
    {
      obj0.hide();
      Exception exception1;
      try
      {
        Schematic schematic = Schematics.read(obj1);
        schematic.removeSteamID();
        Vars.schematics.add(schematic);
        this.setup();
        this.showInfo(schematic);
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
      Vars.ui.showException((Exception) exception2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {15, 127, 17, 113, 145, 117, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00243()
    {
      if (!Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Echat) || !object.ReferenceEquals((object) Core.scene.getKeyboardFocus(), (object) this.searchField) || this.firstSchematic == null)
        return;
      if (!Vars.state.rules.schematicsAllowed)
      {
        Vars.ui.showInfo("@schematic.disabled");
      }
      else
      {
        Vars.control.input.useSchematic(this.firstSchematic);
        this.hide();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {26, 159, 5, 102, 98, 102, 151, 135, 127, 12, 127, 33, 144, 108, 255, 12, 160, 87, 154, 147, 114, 135, 133, 104, 158})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002415([In] Table obj0, [In] Runnable[] obj1)
    {
      int num1 = Math.max(ByteCodeHelper.f2i((float) Core.graphics.getWidth() / Scl.scl(230f)), 1);
      obj0.clear();
      int num2 = 0;
      string str1 = "[`~!@#$%^&*()-_=+{}|;:'\",<.>/?]";
      string str2 = String.instancehelper_replaceAll(String.instancehelper_toLowerCase(this.search), str1, " ");
      this.firstSchematic = (Schematic) null;
      Iterator iterator = Vars.schematics.all().iterator();
      CharSequence charSequence1;
      while (iterator.hasNext())
      {
        Schematic schematic = (Schematic) iterator.next();
        if (!String.instancehelper_isEmpty(this.search))
        {
          string str3 = String.instancehelper_replaceAll(String.instancehelper_toLowerCase(schematic.name()), str1, " ");
          object obj = (object) str2;
          charSequence1.__\u003Cref\u003E = (__Null) obj;
          CharSequence charSequence2 = charSequence1;
          if (!String.instancehelper_contains(str3, charSequence2))
            continue;
        }
        if (this.firstSchematic == null)
          this.firstSchematic = schematic;
        Button[] buttonArray = new Button[1]
        {
          (Button) null
        };
        buttonArray[0] = (Button) obj0.button((Cons) new SchematicsDialog.__\u003C\u003EAnon20(this, schematic, obj1), (Runnable) new SchematicsDialog.__\u003C\u003EAnon21(this, buttonArray, schematic)).pad(4f).style((Style) Styles.cleari).get();
        buttonArray[0].getStyle().up = (Drawable) Tex.pane;
        ++num2;
        int num3 = num2;
        int num4 = num1;
        if ((num4 != -1 ? num3 % num4 : 0) == 0)
          obj0.row();
      }
      if (this.firstSchematic != null)
        return;
      Table table = obj0;
      object obj2 = (object) "@none";
      charSequence1.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text = charSequence1;
      table.add(text);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {41, 103, 108, 243, 126, 112, 103, 255, 29, 71, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002413([In] Schematic obj0, [In] Runnable[] obj1, [In] Button obj2)
    {
      obj2.top();
      obj2.margin(0.0f);
      obj2.table((Cons) new SchematicsDialog.__\u003C\u003EAnon22(this, obj0, obj1)).growX().height(50f);
      obj2.row();
      Button button = obj2;
      Element[] elementArray = new Element[2]
      {
        (Element) new SchematicsDialog.SchematicImage(obj0).setScaling(Scaling.__\u003C\u003Efit),
        null
      };
      Table.__\u003Cclinit\u003E();
      elementArray[1] = (Element) new Table((Cons) new SchematicsDialog.__\u003C\u003EAnon23(obj0));
      button.stack(elementArray).size(200f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {116, 107, 108, 137, 113, 145, 112, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002414([In] Button[] obj0, [In] Schematic obj1)
    {
      if (obj0[0].childrenPressed())
        return;
      if (Vars.state.isMenu())
        this.showInfo(obj1);
      else if (!Vars.state.rules.schematicsAllowed)
      {
        Vars.ui.showInfo("@schematic.disabled");
      }
      else
      {
        Vars.control.input.useSchematic(obj1);
        this.hide();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {44, 103, 145, 134, 217, 217, 250, 97, 104, 154, 249, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002410([In] Schematic obj0, [In] Runnable[] obj1, [In] Table obj2)
    {
      obj2.left();
      obj2.defaults().size(50f);
      ImageButton.ImageButtonStyle clearPartiali = Styles.clearPartiali;
      obj2.button((Drawable) Icon.info, clearPartiali, (Runnable) new SchematicsDialog.__\u003C\u003EAnon25(this, obj0));
      obj2.button((Drawable) Icon.upload, clearPartiali, (Runnable) new SchematicsDialog.__\u003C\u003EAnon26(this, obj0));
      obj2.button((Drawable) Icon.pencil, clearPartiali, (Runnable) new SchematicsDialog.__\u003C\u003EAnon27(this, obj0, obj1));
      if (obj0.hasSteamID())
        obj2.button((Drawable) Icon.link, clearPartiali, (Runnable) new SchematicsDialog.__\u003C\u003EAnon28(obj0));
      else
        obj2.button((Drawable) Icon.trash, clearPartiali, (Runnable) new SchematicsDialog.__\u003C\u003EAnon29(obj0, obj1));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {108, 103, 214, 127, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002412([In] Schematic obj0, [In] Table obj1)
    {
      obj1.top();
      obj1.table(Styles.black3, (Cons) new SchematicsDialog.__\u003C\u003EAnon24(obj0)).growX().margin(1f).pad(4f).maxWidth(Scl.scl(192f)).padBottom(0.0f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {110, 127, 48, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002411([In] Schematic obj0, [In] Table obj1)
    {
      Table table = obj1;
      object obj = (object) obj0.name();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      Label label = (Label) table.add(text).style((Style) Styles.outlineLabel).color(Color.__\u003C\u003Ewhite).top().growX().maxWidth(192f).get();
      label.setEllipsis(true);
      label.setAlignment(1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {50, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00244([In] Schematic obj0) => this.showInfo(obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {54, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00245([In] Schematic obj0) => this.showExport(obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {58, 238, 94})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00246([In] Schematic obj0, [In] Runnable[] obj1)
    {
      SchematicsDialog.\u0031 obj = new SchematicsDialog.\u0031(this, "@schematic.rename", obj0, obj1);
    }

    [Modifiers]
    [LineNumberTable(141)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00247([In] Schematic obj0) => Vars.platform.viewListing((Publishable) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {94, 104, 159, 21, 255, 1, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00249([In] Schematic obj0, [In] Runnable[] obj1)
    {
      if (obj0.mod != null)
        Vars.ui.showInfo(Core.bundle.format("mod.item.remove", (object) obj0.mod.__\u003C\u003Emeta.displayName()));
      else
        Vars.ui.showConfirm("@confirm", "@schematic.delete.confirm", (Runnable) new SchematicsDialog.__\u003C\u003EAnon30(obj0, obj1));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {98, 107, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00248([In] Schematic obj0, [In] Runnable[] obj1)
    {
      Vars.schematics.remove(obj0);
      obj1[0].run();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {3, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00241([In] Runnable[] obj0, [In] string obj1)
    {
      this.search = obj1;
      obj0[0].run();
    }

    [HideFromJava]
    static SchematicsDialog() => BaseDialog.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "setup", "()V")]
    [SpecialName]
    internal new class \u0031 : Dialog
    {
      [Modifiers]
      internal Schematic val\u0024s;
      [Modifiers]
      internal Runnable[] val\u0024rebuildPane;
      [Modifiers]
      internal SchematicsDialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024new\u00240([In] string obj0)
      {
      }

      [Modifiers]
      [LineNumberTable(new byte[] {68, 119, 119, 102, 102, 105})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00241(
        [In] Schematic obj0,
        [In] TextField obj1,
        [In] TextField obj2,
        [In] Runnable[] obj3)
      {
        obj0.tags.put((object) "name", (object) obj1.getText());
        obj0.tags.put((object) "description", (object) obj2.getText());
        obj0.save();
        this.hide();
        obj3[0].run();
      }

      [Modifiers]
      [LineNumberTable(126)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024new\u00242([In] TextField obj0, [In] TextButton obj1) => String.instancehelper_isEmpty(obj0.getText());

      [Modifiers]
      [LineNumberTable(new byte[] {80, 127, 0, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024new\u00243([In] TextField obj0, [In] TextField obj1, [In] Runnable obj2)
      {
        if (String.instancehelper_isEmpty(obj0.getText()) || object.ReferenceEquals((object) Core.scene.getKeyboardFocus(), (object) obj1))
          return;
        obj2.run();
      }

      [LineNumberTable(new byte[] {58, 127, 0, 127, 22, 159, 23, 140, 127, 22, 159, 38, 252, 72, 127, 6, 127, 4, 156, 250, 69, 118, 118, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] SchematicsDialog obj0, [In] string obj1, [In] Schematic obj2, [In] Runnable[] obj3)
      {
        this.this\u00240 = obj0;
        this.val\u0024s = obj2;
        this.val\u0024rebuildPane = obj3;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        SchematicsDialog.\u0031 obj4 = this;
        Table table1 = this.__\u003C\u003Econt.margin(30f);
        object obj5 = (object) "@name";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj5;
        CharSequence text1 = charSequence;
        table1.add(text1).padRight(6f);
        TextField textField1 = (TextField) this.__\u003C\u003Econt.field(this.val\u0024s.name(), (Cons) null).size(400f, 55f).addInputDialog().get();
        this.__\u003C\u003Econt.row();
        Table table2 = this.__\u003C\u003Econt.margin(30f);
        object obj6 = (object) "@editor.description";
        charSequence.__\u003Cref\u003E = (__Null) obj6;
        CharSequence text2 = charSequence;
        table2.add(text2).padRight(6f);
        TextField textField2 = (TextField) this.__\u003C\u003Econt.area(this.val\u0024s.description(), Styles.areaField, (Cons) new SchematicsDialog.\u0031.__\u003C\u003EAnon0()).size(400f, 140f).addInputDialog().get();
        Runnable listener = (Runnable) new SchematicsDialog.\u0031.__\u003C\u003EAnon1(this, this.val\u0024s, textField1, textField2, this.val\u0024rebuildPane);
        this.__\u003C\u003Ebuttons.defaults().size(120f, 54f).pad(4f);
        this.__\u003C\u003Ebuttons.button("@ok", listener).disabled((Boolf) new SchematicsDialog.\u0031.__\u003C\u003EAnon2(textField1));
        this.__\u003C\u003Ebuttons.button("@cancel", (Runnable) new SchematicsDialog.\u0031.__\u003C\u003EAnon3(this));
        this.keyDown(KeyCode.__\u003C\u003Eenter, (Runnable) new SchematicsDialog.\u0031.__\u003C\u003EAnon4(textField1, textField2, listener));
        this.keyDown(KeyCode.__\u003C\u003Eescape, (Runnable) new SchematicsDialog.\u0031.__\u003C\u003EAnon3(this));
        this.keyDown(KeyCode.__\u003C\u003Eback, (Runnable) new SchematicsDialog.\u0031.__\u003C\u003EAnon3(this));
        this.show();
      }

      [HideFromJava]
      static \u0031() => Dialog.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public void get([In] object obj0) => SchematicsDialog.\u0031.lambda\u0024new\u00240((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Runnable
      {
        private readonly SchematicsDialog.\u0031 arg\u00241;
        private readonly Schematic arg\u00242;
        private readonly TextField arg\u00243;
        private readonly TextField arg\u00244;
        private readonly Runnable[] arg\u00245;

        internal __\u003C\u003EAnon1(
          [In] SchematicsDialog.\u0031 obj0,
          [In] Schematic obj1,
          [In] TextField obj2,
          [In] TextField obj3,
          [In] Runnable[] obj4)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
          this.arg\u00244 = obj3;
          this.arg\u00245 = obj4;
        }

        public void run() => this.arg\u00241.lambda\u0024new\u00241(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Boolf
      {
        private readonly TextField arg\u00241;

        internal __\u003C\u003EAnon2([In] TextField obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (SchematicsDialog.\u0031.lambda\u0024new\u00242(this.arg\u00241, (TextButton) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Runnable
      {
        private readonly SchematicsDialog.\u0031 arg\u00241;

        internal __\u003C\u003EAnon3([In] SchematicsDialog.\u0031 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.hide();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Runnable
      {
        private readonly TextField arg\u00241;
        private readonly TextField arg\u00242;
        private readonly Runnable arg\u00243;

        internal __\u003C\u003EAnon4([In] TextField obj0, [In] TextField obj1, [In] Runnable obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => SchematicsDialog.\u0031.lambda\u0024new\u00243(this.arg\u00241, this.arg\u00242, this.arg\u00243);
      }
    }

    public class SchematicImage : Image
    {
      public float scaling;
      public float thickness;
      public Color borderColor;
      private Schematic schematic;
      internal bool set;

      [LineNumberTable(new byte[] {160, 190, 237, 56, 107, 107, 235, 71, 108, 135, 109, 102, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SchematicImage(Schematic s)
        : base((Drawable) Tex.clear)
      {
        SchematicsDialog.SchematicImage schematicImage = this;
        this.scaling = 16f;
        this.thickness = 4f;
        this.borderColor = Pal.gray;
        this.setScaling(Scaling.__\u003C\u003Efit);
        this.schematic = s;
        if (!Vars.schematics.hasPreview(s))
          return;
        this.setPreview();
        this.set = true;
      }

      [LineNumberTable(new byte[] {160, 235, 123, 103, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void setPreview()
      {
        this.setDrawable((Drawable) new TextureRegionDrawable(new TextureRegion(Vars.schematics.getPreview(this.schematic))));
        this.setScaling(Scaling.__\u003C\u003Efit);
      }

      [LineNumberTable(new byte[] {160, 202, 127, 3, 140, 103, 104, 117, 167, 122, 103, 112, 112, 104, 104, 101, 107, 159, 29, 99, 136, 191, 52, 117, 107, 113, 125, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        int num1 = !(this.parent.parent is Button) || !((Button) this.parent.parent).isOver() ? 0 : 1;
        int num2 = this.set ? 1 : 0;
        if (!this.set)
        {
          Core.app.post((Runnable) new SchematicsDialog.SchematicImage.__\u003C\u003EAnon0(this));
          this.set = true;
        }
        TextureRegion region = Draw.wrap((Texture) Core.assets.get("sprites/schematic-background.png", (Class) ClassLiteral<Texture>.Value));
        float u2 = this.width / this.scaling;
        float v2 = this.height / this.scaling;
        region.setU2(u2);
        region.setV2(v2);
        Draw.color();
        Draw.alpha(this.parentAlpha);
        Draw.rect(region, this.x + this.width / 2f, this.y + this.height / 2f, this.width, this.height);
        if (num2 != 0)
          base.draw();
        else
          Draw.rect(Icon.refresh.getRegion(), this.x + this.width / 2f, this.y + this.height / 2f, this.width / 4f, this.height / 4f);
        Draw.color(num1 == 0 ? this.borderColor : Pal.accent);
        Draw.alpha(this.parentAlpha);
        Lines.stroke(Scl.scl(this.thickness));
        Lines.rect(this.x, this.y, this.width, this.height);
        Draw.reset();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly SchematicsDialog.SchematicImage arg\u00241;

        internal __\u003C\u003EAnon0([In] SchematicsDialog.SchematicImage obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.setPreview();
      }
    }

    public class SchematicInfoDialog : BaseDialog
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 244, 109, 103, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal SchematicInfoDialog()
        : base("")
      {
        SchematicsDialog.SchematicInfoDialog schematicInfoDialog = this;
        this.setFillParent(true);
        this.addCloseButton();
      }

      [LineNumberTable(new byte[] {160, 250, 107, 159, 57, 127, 75, 108, 124, 140, 103, 247, 79, 108, 127, 0, 113, 249, 82, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void show(Schematic schem)
      {
        this.__\u003C\u003Econt.clear();
        Label title = this.__\u003C\u003Etitle;
        object obj1 = (object) new StringBuilder().append("[[").append(Core.bundle.get("schematic")).append("] ").append(schem.name()).toString();
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj1;
        CharSequence newText = charSequence;
        title.setText(newText);
        Table cont = this.__\u003C\u003Econt;
        object obj2 = (object) Core.bundle.format("schematic.info", (object) Integer.valueOf(schem.width), (object) Integer.valueOf(schem.height), (object) Integer.valueOf(schem.__\u003C\u003Etiles.size));
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        CharSequence text = charSequence;
        cont.add(text).color(Color.__\u003C\u003ElightGray);
        this.__\u003C\u003Econt.row();
        this.__\u003C\u003Econt.add((Element) new SchematicsDialog.SchematicImage(schem)).maxSize(800f);
        this.__\u003C\u003Econt.row();
        this.__\u003C\u003Econt.table((Cons) new SchematicsDialog.SchematicInfoDialog.__\u003C\u003EAnon0(schem.requirements()));
        this.__\u003C\u003Econt.row();
        float num1 = schem.powerConsumption() * 60f;
        float num2 = schem.powerProduction() * 60f;
        if (!Mathf.zero(num1) || !Mathf.zero(num2))
          this.__\u003C\u003Econt.table((Cons) new SchematicsDialog.SchematicInfoDialog.__\u003C\u003EAnon1(num2, num1));
        this.show();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 4, 98, 126, 124, 214, 149, 114, 135, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024show\u00241([In] ItemSeq obj0, [In] Table obj1)
      {
        int num1 = 0;
        Iterator iterator = obj0.iterator();
        while (iterator.hasNext())
        {
          ItemStack itemStack = (ItemStack) iterator.next();
          obj1.image(itemStack.item.icon(Cicon.__\u003C\u003Esmall)).left();
          obj1.label((Prov) new SchematicsDialog.SchematicInfoDialog.__\u003C\u003EAnon2(itemStack)).padLeft(2f).left().padRight(4f);
          ++num1;
          int num2 = num1;
          int num3 = 4;
          if ((num3 != -1 ? num2 % num3 : 0) == 0)
            obj1.row();
        }
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 23, 108, 127, 1, 159, 40, 105, 209, 105, 127, 1, 159, 40})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024show\u00242([In] float obj0, [In] float obj1, [In] Table obj2)
      {
        CharSequence charSequence;
        if (!Mathf.zero(obj0))
        {
          obj2.image((Drawable) Icon.powerSmall).color(Pal.powerLight).padRight(3f);
          Table table = obj2;
          object obj = (object) new StringBuilder().append("+").append(Strings.autoFixed(obj0, 2)).toString();
          charSequence.__\u003Cref\u003E = (__Null) obj;
          CharSequence text = charSequence;
          table.add(text).color(Pal.powerLight).left();
          if (!Mathf.zero(obj1))
            obj2.add().width(15f);
        }
        if (Mathf.zero(obj1))
          return;
        obj2.image((Drawable) Icon.powerSmall).color(Pal.remove).padRight(3f);
        Table table1 = obj2;
        object obj3 = (object) new StringBuilder().append("-").append(Strings.autoFixed(obj1, 2)).toString();
        charSequence.__\u003Cref\u003E = (__Null) obj3;
        CharSequence text1 = charSequence;
        table1.add(text1).color(Pal.remove).left();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 8, 107, 127, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static CharSequence lambda\u0024show\u00240([In] ItemStack obj0)
      {
        CoreBlock.CoreBuild coreBuild = Vars.player.core();
        if (coreBuild == null || Vars.state.rules.infiniteResources || coreBuild.items.has(obj0.item, obj0.amount))
        {
          object obj = (object) new StringBuilder().append("[lightgray]").append(obj0.amount).append("").toString();
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) obj;
          return charSequence;
        }
        object obj1 = (object) new StringBuilder().append(!coreBuild.items.has(obj0.item, obj0.amount) ? "[scarlet]" : "[lightgray]").append(Math.min(coreBuild.items.get(obj0.item), obj0.amount)).append("[lightgray]/").append(obj0.amount).toString();
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj1;
        return charSequence1;
      }

      [HideFromJava]
      static SchematicInfoDialog() => BaseDialog.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly ItemSeq arg\u00241;

        internal __\u003C\u003EAnon0([In] ItemSeq obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => SchematicsDialog.SchematicInfoDialog.lambda\u0024show\u00241(this.arg\u00241, (Table) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly float arg\u00241;
        private readonly float arg\u00242;

        internal __\u003C\u003EAnon1([In] float obj0, [In] float obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => SchematicsDialog.SchematicInfoDialog.lambda\u0024show\u00242(this.arg\u00241, this.arg\u00242, (Table) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Prov
      {
        private readonly ItemStack arg\u00241;

        internal __\u003C\u003EAnon2([In] ItemStack obj0) => this.arg\u00241 = obj0;

        public object get() => (object) SchematicsDialog.SchematicInfoDialog.lambda\u0024show\u00240(this.arg\u00241).__\u003Cref\u003E;
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => SchematicsDialog.lambda\u0024new\u00240(obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly SchematicsDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] SchematicsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.showImport();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly SchematicsDialog arg\u00241;

      internal __\u003C\u003EAnon2([In] SchematicsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly SchematicsDialog arg\u00241;
      private readonly Runnable[] arg\u00242;

      internal __\u003C\u003EAnon3([In] SchematicsDialog obj0, [In] Runnable[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u00242(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly SchematicsDialog arg\u00241;
      private readonly Runnable[] arg\u00242;

      internal __\u003C\u003EAnon4([In] SchematicsDialog obj0, [In] Runnable[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002416(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly SchematicsDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon5([In] SchematicsDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024showImport\u002423(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly Schematic arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon6([In] Schematic obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => SchematicsDialog.lambda\u0024showExport\u002429(this.arg\u00241, this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly Schematic arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon7([In] Schematic obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => SchematicsDialog.lambda\u0024showExport\u002428(this.arg\u00241, this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly Schematic arg\u00241;

      internal __\u003C\u003EAnon8([In] Schematic obj0) => this.arg\u00241 = obj0;

      public void run() => SchematicsDialog.lambda\u0024showExport\u002424(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly BaseDialog arg\u00241;
      private readonly Schematic arg\u00242;

      internal __\u003C\u003EAnon9([In] BaseDialog obj0, [In] Schematic obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => SchematicsDialog.lambda\u0024showExport\u002425(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Runnable
    {
      private readonly BaseDialog arg\u00241;
      private readonly Schematic arg\u00242;

      internal __\u003C\u003EAnon10([In] BaseDialog obj0, [In] Schematic obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => SchematicsDialog.lambda\u0024showExport\u002427(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Platform.FileWriter
    {
      private readonly Schematic arg\u00241;

      internal __\u003C\u003EAnon11([In] Schematic obj0) => this.arg\u00241 = obj0;

      public void write([In] Fi obj0) => SchematicsDialog.lambda\u0024showExport\u002426(this.arg\u00241, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Cons
    {
      private readonly SchematicsDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon12([In] SchematicsDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024showImport\u002422(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly SchematicsDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon13([In] SchematicsDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024showImport\u002417(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Boolf
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public bool get([In] object obj0) => (SchematicsDialog.lambda\u0024showImport\u002418((TextButton) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Runnable
    {
      private readonly SchematicsDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon15([In] SchematicsDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024showImport\u002420(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly BaseDialog arg\u00241;

      internal __\u003C\u003EAnon16([In] BaseDialog obj0) => this.arg\u00241 = obj0;

      public void run() => SchematicsDialog.lambda\u0024showImport\u002421(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Cons
    {
      private readonly SchematicsDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon17([In] SchematicsDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024showImport\u002419(this.arg\u00242, (Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Runnable
    {
      private readonly SchematicsDialog arg\u00241;

      internal __\u003C\u003EAnon18([In] SchematicsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setup\u00243();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Runnable
    {
      private readonly SchematicsDialog arg\u00241;
      private readonly Table arg\u00242;
      private readonly Runnable[] arg\u00243;

      internal __\u003C\u003EAnon19([In] SchematicsDialog obj0, [In] Table obj1, [In] Runnable[] obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u002415(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Cons
    {
      private readonly SchematicsDialog arg\u00241;
      private readonly Schematic arg\u00242;
      private readonly Runnable[] arg\u00243;

      internal __\u003C\u003EAnon20([In] SchematicsDialog obj0, [In] Schematic obj1, [In] Runnable[] obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002413(this.arg\u00242, this.arg\u00243, (Button) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Runnable
    {
      private readonly SchematicsDialog arg\u00241;
      private readonly Button[] arg\u00242;
      private readonly Schematic arg\u00243;

      internal __\u003C\u003EAnon21([In] SchematicsDialog obj0, [In] Button[] obj1, [In] Schematic obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u002414(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Cons
    {
      private readonly SchematicsDialog arg\u00241;
      private readonly Schematic arg\u00242;
      private readonly Runnable[] arg\u00243;

      internal __\u003C\u003EAnon22([In] SchematicsDialog obj0, [In] Schematic obj1, [In] Runnable[] obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002410(this.arg\u00242, this.arg\u00243, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Cons
    {
      private readonly Schematic arg\u00241;

      internal __\u003C\u003EAnon23([In] Schematic obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => SchematicsDialog.lambda\u0024setup\u002412(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Cons
    {
      private readonly Schematic arg\u00241;

      internal __\u003C\u003EAnon24([In] Schematic obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => SchematicsDialog.lambda\u0024setup\u002411(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Runnable
    {
      private readonly SchematicsDialog arg\u00241;
      private readonly Schematic arg\u00242;

      internal __\u003C\u003EAnon25([In] SchematicsDialog obj0, [In] Schematic obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00244(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Runnable
    {
      private readonly SchematicsDialog arg\u00241;
      private readonly Schematic arg\u00242;

      internal __\u003C\u003EAnon26([In] SchematicsDialog obj0, [In] Schematic obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00245(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Runnable
    {
      private readonly SchematicsDialog arg\u00241;
      private readonly Schematic arg\u00242;
      private readonly Runnable[] arg\u00243;

      internal __\u003C\u003EAnon27([In] SchematicsDialog obj0, [In] Schematic obj1, [In] Runnable[] obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00246(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Runnable
    {
      private readonly Schematic arg\u00241;

      internal __\u003C\u003EAnon28([In] Schematic obj0) => this.arg\u00241 = obj0;

      public void run() => SchematicsDialog.lambda\u0024setup\u00247(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Runnable
    {
      private readonly Schematic arg\u00241;
      private readonly Runnable[] arg\u00242;

      internal __\u003C\u003EAnon29([In] Schematic obj0, [In] Runnable[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => SchematicsDialog.lambda\u0024setup\u00249(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Runnable
    {
      private readonly Schematic arg\u00241;
      private readonly Runnable[] arg\u00242;

      internal __\u003C\u003EAnon30([In] Schematic obj0, [In] Runnable[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => SchematicsDialog.lambda\u0024setup\u00248(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Cons
    {
      private readonly SchematicsDialog arg\u00241;
      private readonly Runnable[] arg\u00242;

      internal __\u003C\u003EAnon31([In] SchematicsDialog obj0, [In] Runnable[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u00241(this.arg\u00242, (string) obj0);
    }
  }
}
