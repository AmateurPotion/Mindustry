// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.MapsDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.files;
using arc.func;
using arc.graphics;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.io;
using mindustry.maps;
using mindustry.type;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class MapsDialog : BaseDialog
  {
    private BaseDialog dialog;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 164, 141, 140, 134, 113, 241, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MapsDialog()
      : base("@maps")
    {
      MapsDialog mapsDialog = this;
      this.__\u003C\u003Ebuttons.remove();
      this.addCloseListener();
      this.shown((Runnable) new MapsDialog.__\u003C\u003EAnon0(this));
      this.onResize((Runnable) new MapsDialog.__\u003C\u003EAnon1(this));
    }

    [LineNumberTable(new byte[] {159, 180, 139, 108, 127, 23, 142, 191, 17, 255, 11, 79, 134, 255, 11, 109, 166, 139, 102, 140, 103, 135, 127, 5, 134, 99, 159, 12, 111, 167, 127, 26, 103, 109, 127, 35, 104, 127, 2, 104, 127, 46, 104, 159, 105, 102, 133, 113, 190, 119, 108, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setup()
    {
      this.__\u003C\u003Ebuttons.clearChildren();
      if (Core.graphics.isPortrait())
      {
        this.__\u003C\u003Ebuttons.button("@back", (Drawable) Icon.left, (Runnable) new MapsDialog.__\u003C\u003EAnon2(this)).size(420f, 64f).colspan(2);
        this.__\u003C\u003Ebuttons.row();
      }
      else
        this.__\u003C\u003Ebuttons.button("@back", (Drawable) Icon.left, (Runnable) new MapsDialog.__\u003C\u003EAnon2(this)).size(210f, 64f);
      this.__\u003C\u003Ebuttons.button("@editor.newmap", (Drawable) Icon.add, (Runnable) new MapsDialog.__\u003C\u003EAnon3(this)).size(210f, 64f);
      this.__\u003C\u003Ebuttons.button("@editor.importmap", (Drawable) Icon.upload, (Runnable) new MapsDialog.__\u003C\u003EAnon4(this)).size(210f, 64f);
      this.__\u003C\u003Econt.clear();
      Table table1 = new Table();
      table1.marginRight(24f);
      ScrollPane scrollPane = new ScrollPane((Element) table1);
      scrollPane.setFadeScrollBars(false);
      int num1 = Math.max(ByteCodeHelper.f2i((float) Core.graphics.getWidth() / Scl.scl(230f)), 1);
      float width = 200f;
      int num2 = 0;
      Iterator iterator = Vars.maps.all().iterator();
      CharSequence charSequence;
      while (iterator.hasNext())
      {
        Map map = (Map) iterator.next();
        int num3 = num2;
        int num4 = num1;
        if ((num4 != -1 ? num3 % num4 : 0) == 0)
          table1.row();
        TextButton textButton1 = (TextButton) table1.button("", Styles.cleart, (Runnable) new MapsDialog.__\u003C\u003EAnon5(this, map)).width(width).pad(8f).get();
        textButton1.clearChildren();
        textButton1.margin(9f);
        TextButton textButton2 = textButton1;
        object obj1 = (object) map.name();
        charSequence.__\u003Cref\u003E = (__Null) obj1;
        CharSequence text1 = charSequence;
        ((Label) textButton2.add(text1).width(width - 18f).center().get()).setEllipsis(true);
        textButton1.row();
        textButton1.image().growX().pad(4f).color(Pal.gray);
        textButton1.row();
        textButton1.stack((Element) new Image(map.safeTexture()).setScaling(Scaling.__\u003C\u003Efit), (Element) new BorderImage(map.safeTexture()).setScaling(Scaling.__\u003C\u003Efit)).size(width - 20f);
        textButton1.row();
        TextButton textButton3 = textButton1;
        object obj2 = !map.__\u003C\u003Ecustom ? (!map.workshop ? (map.mod == null ? (object) "@builtin" : (object) new StringBuilder().append("[lightgray]").append(map.mod.__\u003C\u003Emeta.displayName()).toString()) : (object) "@workshop") : (object) "@custom";
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        CharSequence text2 = charSequence;
        textButton3.add(text2).color(Color.__\u003C\u003Egray).padTop(3f);
        ++num2;
      }
      if (Vars.maps.all().size == 0)
      {
        Table table2 = table1;
        object obj = (object) "@maps.none";
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table2.add(text);
      }
      this.__\u003C\u003Econt.add((Element) this.__\u003C\u003Ebuttons).growX();
      this.__\u003C\u003Econt.row();
      this.__\u003C\u003Econt.add((Element) scrollPane).uniformX();
    }

    [LineNumberTable(new byte[] {104, 112, 139, 121, 140, 159, 36, 247, 89, 140, 135, 252, 73, 154, 255, 41, 74, 159, 20, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void showMapInfo([In] Map obj0)
    {
      this.dialog = new BaseDialog("@editor.mapinfo");
      this.dialog.addCloseButton();
      float num = !Core.graphics.isPortrait() ? 300f : 160f;
      Table cont = this.dialog.__\u003C\u003Econt;
      cont.stack((Element) new Image(obj0.safeTexture()).setScaling(Scaling.__\u003C\u003Efit), (Element) new BorderImage(obj0.safeTexture()).setScaling(Scaling.__\u003C\u003Efit)).size(num);
      cont.table(Styles.black, (Cons) new MapsDialog.__\u003C\u003EAnon6(obj0)).height(num).width(num);
      cont.row();
      cont.button("@editor.openin", (Drawable) Icon.export, (Runnable) new MapsDialog.__\u003C\u003EAnon7(this, obj0)).fillX().height(54f).marginLeft(10f);
      cont.button(!obj0.workshop || !Vars.steam ? "@delete" : "@view.workshop", !obj0.workshop || !Vars.steam ? (Drawable) Icon.trash : (Drawable) Icon.link, (Runnable) new MapsDialog.__\u003C\u003EAnon8(this, obj0)).fillX().height(54f).marginLeft(10f).disabled(!obj0.workshop && !obj0.__\u003C\u003Ecustom);
      this.dialog.show();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 172, 104, 139, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240()
    {
      if (this.dialog != null)
        this.dialog.hide();
      this.setup();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 190, 255, 5, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00244() => Vars.ui.showTextInput("@editor.newmap", "@editor.mapname", "", (Cons) new MapsDialog.__\u003C\u003EAnon17(this));

    [Modifiers]
    [LineNumberTable(new byte[] {15, 251, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002412() => Vars.platform.showFileChooser(true, "msav", (Cons) new MapsDialog.__\u003C\u003EAnon10(this));

    [Modifiers]
    [LineNumberTable(130)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002413([In] Map obj0) => this.showMapInfo(obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {113, 103, 102, 140, 103, 141, 103, 150, 127, 27, 103, 127, 18, 103, 127, 17, 103, 127, 66, 135, 127, 5, 127, 22, 103, 159, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showMapInfo\u002414([In] Map obj0, [In] Table obj1)
    {
      obj1.top();
      Table table1 = new Table();
      table1.margin(6f);
      ScrollPane scrollPane = new ScrollPane((Element) table1);
      obj1.add((Element) scrollPane).grow();
      table1.top();
      table1.defaults().padTop(10f).left();
      Table table2 = table1;
      object obj2 = (object) "@editor.mapname";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text1 = charSequence;
      table2.add(text1).padRight(10f).color(Color.__\u003C\u003Egray).padTop(0.0f);
      table1.row();
      Table table3 = table1;
      object obj3 = (object) obj0.name();
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence text2 = charSequence;
      table3.add(text2).growX().wrap().padTop(2f);
      table1.row();
      Table table4 = table1;
      object obj4 = (object) "@editor.author";
      charSequence.__\u003Cref\u003E = (__Null) obj4;
      CharSequence text3 = charSequence;
      table4.add(text3).padRight(10f).color(Color.__\u003C\u003Egray);
      table1.row();
      Table table5 = table1;
      object obj5 = obj0.__\u003C\u003Ecustom || !String.instancehelper_isEmpty((string) obj0.__\u003C\u003Etags.get((object) "author", (object) "")) ? (object) obj0.author() : (object) "Anuke";
      charSequence.__\u003Cref\u003E = (__Null) obj5;
      CharSequence text4 = charSequence;
      table5.add(text4).growX().wrap().padTop(2f);
      table1.row();
      if (String.instancehelper_isEmpty((string) obj0.__\u003C\u003Etags.get((object) "description", (object) "")))
        return;
      Table table6 = table1;
      object obj6 = (object) "@editor.description";
      charSequence.__\u003Cref\u003E = (__Null) obj6;
      CharSequence text5 = charSequence;
      table6.add(text5).padRight(10f).color(Color.__\u003C\u003Egray).top();
      table1.row();
      Table table7 = table1;
      object obj7 = (object) obj0.description();
      charSequence.__\u003Cref\u003E = (__Null) obj7;
      CharSequence text6 = charSequence;
      table7.add(text6).growX().wrap().padTop(2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 79, 117, 107, 221, 226, 61, 97, 102, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showMapInfo\u002415([In] Map obj0)
    {
      Exception exception;
      try
      {
        Vars.ui.editor.beginEditMap(obj0.__\u003C\u003Efile);
        this.dialog.hide();
        this.hide();
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
      Throwable.instancehelper_printStackTrace((Exception) exception);
      Vars.ui.showErrorMessage("@error.mapnotfound");
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 89, 111, 141, 255, 26, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showMapInfo\u002417([In] Map obj0)
    {
      if (obj0.workshop && Vars.steam)
        Vars.platform.viewListing((Publishable) obj0);
      else
        Vars.ui.showConfirm("@confirm", Core.bundle.format("map.delete", (object) obj0.name()), (Runnable) new MapsDialog.__\u003C\u003EAnon9(this, obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 93, 107, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showMapInfo\u002416([In] Map obj0)
    {
      Vars.maps.removeMap(obj0);
      this.dialog.hide();
      this.setup();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {16, 246, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002411([In] Fi obj0) => Vars.ui.loadAnd((Runnable) new MapsDialog.__\u003C\u003EAnon11(this, obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {17, 246, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002410([In] Fi obj0) => Vars.maps.tryCatchMapError((UnsafeRunnable) new MapsDialog.__\u003C\u003EAnon12(this, obj0));

    [Throws(new string[] {"java.lang.Throwable"})]
    [Modifiers]
    [LineNumberTable(new byte[] {18, 104, 111, 161, 168, 255, 1, 72, 99, 111, 161, 159, 1, 107, 127, 6, 99, 255, 29, 72, 112, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00249([In] Fi obj0)
    {
      if (MapIO.isImage(obj0))
      {
        Vars.ui.showErrorMessage("@editor.errorimage");
      }
      else
      {
        Map map1 = MapIO.createMap(obj0, true);
        string str = (string) map1.__\u003C\u003Etags.get((object) "name", (Prov) new MapsDialog.__\u003C\u003EAnon13());
        if (str == null)
        {
          Vars.ui.showErrorMessage("@editor.errorname");
        }
        else
        {
          Map map2 = (Map) Vars.maps.all().find((Boolf) new MapsDialog.__\u003C\u003EAnon14(str));
          if (map2 != null && !map2.__\u003C\u003Ecustom)
            Vars.ui.showInfo(Core.bundle.format("editor.import.exists", (object) str));
          else if (map2 != null)
          {
            Vars.ui.showConfirm("@confirm", Core.bundle.format("editor.overwrite.confirm", (object) map1.name()), (Runnable) new MapsDialog.__\u003C\u003EAnon15(this, map2, map1));
          }
          else
          {
            Vars.maps.importMap(map1.__\u003C\u003Efile);
            this.setup();
          }
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {27, 102, 98, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setup\u00245()
    {
      string str = "unknown";
      int num1 = 0;
      Maps maps;
      string name;
      do
      {
        maps = Vars.maps;
        StringBuilder stringBuilder = new StringBuilder().append(str);
        int num2 = num1;
        ++num1;
        name = stringBuilder.append(num2).toString();
      }
      while (maps.byName(name) != null);
      return new StringBuilder().append(str).append(num1).toString();
    }

    [Modifiers]
    [LineNumberTable(89)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024setup\u00246([In] string obj0, [In] Map obj1) => String.instancehelper_equals(obj1.name(), (object) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {45, 247, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00248([In] Map obj0, [In] Map obj1) => Vars.maps.tryCatchMapError((UnsafeRunnable) new MapsDialog.__\u003C\u003EAnon16(this, obj0, obj1));

    [Throws(new string[] {"java.lang.Throwable"})]
    [Modifiers]
    [LineNumberTable(new byte[] {46, 107, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00247([In] Map obj0, [In] Map obj1)
    {
      Vars.maps.removeMap(obj0);
      Vars.maps.importMap(obj1.__\u003C\u003Efile);
      this.setup();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 191, 237, 71, 109, 145, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00243([In] string obj0)
    {
      Runnable runnable = (Runnable) new MapsDialog.__\u003C\u003EAnon18(this, obj0);
      if (Vars.maps.byName(obj0) != null)
        Vars.ui.showErrorMessage("@editor.exists");
      else
        runnable.run();
    }

    [Modifiers]
    [LineNumberTable(49)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00242([In] string obj0) => Vars.ui.loadAnd((Runnable) new MapsDialog.__\u003C\u003EAnon19(this, obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {0, 102, 112, 127, 1, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00241([In] string obj0)
    {
      this.hide();
      Vars.ui.editor.show();
      Vars.ui.editor.__\u003C\u003Eeditor.tags.put((object) "name", (object) obj0);
      Events.fire((object) new EventType.MapMakeEvent());
    }

    [HideFromJava]
    static MapsDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly MapsDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] MapsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly MapsDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] MapsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly MapsDialog arg\u00241;

      internal __\u003C\u003EAnon2([In] MapsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly MapsDialog arg\u00241;

      internal __\u003C\u003EAnon3([In] MapsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setup\u00244();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly MapsDialog arg\u00241;

      internal __\u003C\u003EAnon4([In] MapsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setup\u002412();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly MapsDialog arg\u00241;
      private readonly Map arg\u00242;

      internal __\u003C\u003EAnon5([In] MapsDialog obj0, [In] Map obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u002413(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly Map arg\u00241;

      internal __\u003C\u003EAnon6([In] Map obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => MapsDialog.lambda\u0024showMapInfo\u002414(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly MapsDialog arg\u00241;
      private readonly Map arg\u00242;

      internal __\u003C\u003EAnon7([In] MapsDialog obj0, [In] Map obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024showMapInfo\u002415(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly MapsDialog arg\u00241;
      private readonly Map arg\u00242;

      internal __\u003C\u003EAnon8([In] MapsDialog obj0, [In] Map obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024showMapInfo\u002417(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly MapsDialog arg\u00241;
      private readonly Map arg\u00242;

      internal __\u003C\u003EAnon9([In] MapsDialog obj0, [In] Map obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024showMapInfo\u002416(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      private readonly MapsDialog arg\u00241;

      internal __\u003C\u003EAnon10([In] MapsDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002411((Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly MapsDialog arg\u00241;
      private readonly Fi arg\u00242;

      internal __\u003C\u003EAnon11([In] MapsDialog obj0, [In] Fi obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u002410(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : UnsafeRunnable
    {
      private readonly MapsDialog arg\u00241;
      private readonly Fi arg\u00242;

      internal __\u003C\u003EAnon12([In] MapsDialog obj0, [In] Fi obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00249(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Prov
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public object get() => (object) MapsDialog.lambda\u0024setup\u00245();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon14([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (MapsDialog.lambda\u0024setup\u00246(this.arg\u00241, (Map) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Runnable
    {
      private readonly MapsDialog arg\u00241;
      private readonly Map arg\u00242;
      private readonly Map arg\u00243;

      internal __\u003C\u003EAnon15([In] MapsDialog obj0, [In] Map obj1, [In] Map obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00248(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : UnsafeRunnable
    {
      private readonly MapsDialog arg\u00241;
      private readonly Map arg\u00242;
      private readonly Map arg\u00243;

      internal __\u003C\u003EAnon16([In] MapsDialog obj0, [In] Map obj1, [In] Map obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00247(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Cons
    {
      private readonly MapsDialog arg\u00241;

      internal __\u003C\u003EAnon17([In] MapsDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u00243((string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Runnable
    {
      private readonly MapsDialog arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon18([In] MapsDialog obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00242(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Runnable
    {
      private readonly MapsDialog arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon19([In] MapsDialog obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00241(this.arg\u00242);
    }
  }
}
