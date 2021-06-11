// Decompiled with JetBrains decompiler
// Type: mindustry.ui.fragments.MenuFragment
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.scene;
using arc.scene.@event;
using arc.scene.actions;
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
using mindustry.ui.dialogs;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.fragments
{
  public class MenuFragment : Fragment
  {
    private Table container;
    private Table submenu;
    private Button currentMenu;
    private MenuRenderer renderer;

    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MenuFragment()
    {
    }

    [LineNumberTable(new byte[] {159, 171, 139, 102, 103, 113, 135, 130, 146, 241, 78, 103, 112, 114, 108, 240, 77, 127, 15, 251, 80})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void build(Group parent)
    {
      this.renderer = new MenuRenderer();
      WidgetGroup widgetGroup1 = new WidgetGroup();
      widgetGroup1.setFillParent(true);
      widgetGroup1.visible((Boolp) new MenuFragment.__\u003C\u003EAnon0());
      parent.addChild((Element) widgetGroup1);
      WidgetGroup widgetGroup2 = widgetGroup1;
      widgetGroup2.fill((Table.DrawRect) new MenuFragment.__\u003C\u003EAnon1(this));
      widgetGroup2.fill((Cons) new MenuFragment.__\u003C\u003EAnon2(this));
      if (Vars.mobile)
      {
        widgetGroup2.fill((Cons) new MenuFragment.__\u003C\u003EAnon3());
        widgetGroup2.fill((Cons) new MenuFragment.__\u003C\u003EAnon4());
      }
      else if (Vars.becontrol.active())
        widgetGroup2.fill((Cons) new MenuFragment.__\u003C\u003EAnon5());
      string str = new StringBuilder().append(Version.build != -1 ? "[#ffffffba]" : "[#fc8140aa]").append(Version.combined()).toString();
      widgetGroup2.fill((Table.DrawRect) new MenuFragment.__\u003C\u003EAnon6(str)).touchable = Touchable.__\u003C\u003Edisabled;
    }

    [LineNumberTable(new byte[] {160, 92, 114, 161, 107, 127, 41})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void fadeOutMenu()
    {
      if (this.submenu.getChildren().isEmpty())
        return;
      this.submenu.clearActions();
      this.submenu.actions((Action) Actions.alpha(1f), (Action) Actions.alpha(0.0f, 0.2f, Interp.fade), (Action) Actions.run((Runnable) new MenuFragment.__\u003C\u003EAnon19(this)));
    }

    [LineNumberTable(new byte[] {160, 86, 107, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void fadeInMenu()
    {
      this.submenu.clearActions();
      this.submenu.actions((Action) Actions.alpha(1f, 0.15f, Interp.fade));
    }

    [LineNumberTable(new byte[] {160, 101, 114, 101, 108, 255, 14, 83, 112, 119, 231, 40, 233, 90})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void buttons(Table _param1, params MenuFragment.Buttoni[] _param2)
    {
      MenuFragment.Buttoni[] buttoniArray = _param2;
      int length = buttoniArray.Length;
      for (int index = 0; index < length; ++index)
      {
        MenuFragment.Buttoni buttoni = buttoniArray[index];
        if (buttoni != null)
        {
          Button[] buttonArray = new Button[1]
          {
            (Button) null
          };
          buttonArray[0] = (Button) _param1.button(buttoni.text, buttoni.icon, Styles.clearToggleMenut, (Runnable) new MenuFragment.__\u003C\u003EAnon20(this, buttonArray, buttoni)).marginLeft(11f).get();
          buttonArray[0].update((Runnable) new MenuFragment.__\u003C\u003EAnon21(this, buttonArray));
          _param1.row();
        }
      }
    }

    [LineNumberTable(new byte[] {160, 78, 108, 136, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void checkPlay([In] Runnable obj0)
    {
      if (!Vars.mods.hasContentErrors())
        obj0.run();
      else
        Vars.ui.showInfo("@mod.noerrorplay");
    }

    [LineNumberTable(new byte[] {99, 107, 159, 2, 102, 134, 108, 127, 4, 249, 84, 139, 249, 72, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void buildDesktop()
    {
      this.container.clear();
      this.container.setSize((float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
      float width = 230f;
      Drawable black6 = Styles.black6;
      this.container.left();
      this.container.add().width((float) Core.graphics.getWidth() / 10f);
      this.container.table(black6, (Cons) new MenuFragment.__\u003C\u003EAnon17(this, width)).width(width).growY();
      this.container.table(black6, (Cons) new MenuFragment.__\u003C\u003EAnon18(this, width)).width(width).growY();
    }

    [LineNumberTable(new byte[] {41, 107, 112, 159, 2, 102, 191, 7, 127, 1, 127, 1, 127, 1, 127, 2, 127, 2, 127, 18, 127, 18, 159, 1, 111, 113, 109, 110, 109, 109, 140, 255, 0, 73, 139, 113, 109, 109, 108, 109, 110, 108, 110, 110, 140, 251, 70, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void buildMobile()
    {
      this.container.clear();
      this.container.name = "buttons";
      this.container.setSize((float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
      float size = 120f;
      this.container.defaults().size(size).pad(5f).padTop(4f);
      MobileButton.__\u003Cclinit\u003E();
      MobileButton mobileButton1 = new MobileButton((Drawable) Icon.play, "@campaign", (Runnable) new MenuFragment.__\u003C\u003EAnon7(this));
      MobileButton.__\u003Cclinit\u003E();
      MobileButton mobileButton2 = new MobileButton((Drawable) Icon.rightOpenOut, "@customgame", (Runnable) new MenuFragment.__\u003C\u003EAnon8(this));
      MobileButton.__\u003Cclinit\u003E();
      MobileButton mobileButton3 = new MobileButton((Drawable) Icon.download, "@loadgame", (Runnable) new MenuFragment.__\u003C\u003EAnon9(this));
      MobileButton.__\u003Cclinit\u003E();
      MobileButton mobileButton4 = new MobileButton((Drawable) Icon.add, "@joingame", (Runnable) new MenuFragment.__\u003C\u003EAnon10(this));
      MobileButton.__\u003Cclinit\u003E();
      MobileButton mobileButton5 = new MobileButton((Drawable) Icon.terrain, "@editor", (Runnable) new MenuFragment.__\u003C\u003EAnon11(this));
      MobileButton.__\u003Cclinit\u003E();
      TextureRegionDrawable settings1 = Icon.settings;
      SettingsMenuDialog settings2 = Vars.ui.settings;
      Objects.requireNonNull((object) settings2);
      Runnable listener1 = (Runnable) new MenuFragment.__\u003C\u003EAnon12(settings2);
      MobileButton mobileButton6 = new MobileButton((Drawable) settings1, "@settings", listener1);
      MobileButton.__\u003Cclinit\u003E();
      TextureRegionDrawable book = Icon.book;
      ModsDialog mods = Vars.ui.mods;
      Objects.requireNonNull((object) mods);
      Runnable listener2 = (Runnable) new MenuFragment.__\u003C\u003EAnon13(mods);
      MobileButton mobileButton7 = new MobileButton((Drawable) book, "@mods", listener2);
      MobileButton.__\u003Cclinit\u003E();
      MobileButton mobileButton8 = new MobileButton((Drawable) Icon.exit, "@quit", (Runnable) new MenuFragment.__\u003C\u003EAnon14());
      if (!Core.graphics.isPortrait())
      {
        this.container.marginTop(60f);
        this.container.add((Element) mobileButton1);
        this.container.add((Element) mobileButton4);
        this.container.add((Element) mobileButton2);
        this.container.add((Element) mobileButton3);
        this.container.row();
        this.container.table((Cons) new MenuFragment.__\u003C\u003EAnon15(this, mobileButton5, mobileButton6, mobileButton7, mobileButton8)).colspan(4);
      }
      else
      {
        this.container.marginTop(0.0f);
        this.container.add((Element) mobileButton1);
        this.container.add((Element) mobileButton3);
        this.container.row();
        this.container.add((Element) mobileButton2);
        this.container.add((Element) mobileButton4);
        this.container.row();
        this.container.add((Element) mobileButton5);
        this.container.add((Element) mobileButton6);
        this.container.row();
        this.container.table((Cons) new MenuFragment.__\u003C\u003EAnon16(this, mobileButton7, mobileButton8)).colspan(2);
      }
    }

    [Modifiers]
    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024build\u00240() => !Vars.ui.editor.isShown();

    [Modifiers]
    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00241([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3) => this.renderer.render();

    [Modifiers]
    [LineNumberTable(new byte[] {159, 183, 103, 139, 103, 102, 151, 102, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00244([In] Table obj0)
    {
      this.container = obj0;
      obj0.name = "menu container";
      if (!Vars.mobile)
      {
        this.buildDesktop();
        Events.on((Class) ClassLiteral<EventType.ResizeEvent>.Value, (Cons) new MenuFragment.__\u003C\u003EAnon40(this));
      }
      else
      {
        this.buildMobile();
        Events.on((Class) ClassLiteral<EventType.ResizeEvent>.Value, (Cons) new MenuFragment.__\u003C\u003EAnon41(this));
      }
    }

    [Modifiers]
    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u00245([In] Table obj0)
    {
      Table table = obj0.bottom().left();
      TextButton.TextButtonStyle infot = Styles.infot;
      AboutDialog about = Vars.ui.about;
      Objects.requireNonNull((object) about);
      Runnable listener = (Runnable) new MenuFragment.__\u003C\u003EAnon29(about);
      table.button("", infot, listener).size(84f, 45f).name("info");
    }

    [Modifiers]
    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u00246([In] Table obj0)
    {
      Table table = obj0.bottom().right();
      TextButton.TextButtonStyle discordt = Styles.discordt;
      DiscordDialog discord = Vars.ui.discord;
      Objects.requireNonNull((object) discord);
      Runnable listener = (Runnable) new MenuFragment.__\u003C\u003EAnon39(discord);
      table.button("", discordt, listener).size(84f, 45f).name("discord");
    }

    [Modifiers]
    [LineNumberTable(new byte[] {8, 255, 15, 72, 255, 0, 56})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002410([In] Table obj0) => obj0.bottom().right().button("@be.check", (Drawable) Icon.refresh, (Runnable) new MenuFragment.__\u003C\u003EAnon36()).size(200f, 60f).name("becheck").update((Cons) new MenuFragment.__\u003C\u003EAnon37());

    [Modifiers]
    [LineNumberTable(new byte[] {23, 112, 127, 5, 108, 127, 11, 150, 112, 159, 32, 101, 142, 111, 127, 27})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002411(
      [In] string obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4)
    {
      TextureAtlas.AtlasRegion atlasRegion = Core.atlas.find("logo");
      float width = (float) Core.graphics.getWidth();
      float num1 = (float) Core.graphics.getHeight() - Core.scene.marginTop;
      float num2 = Scl.scl(1f);
      float w = Math.min((float) atlasRegion.width * num2, (float) Core.graphics.getWidth() - Scl.scl(20f));
      float h = w * (float) atlasRegion.height / (float) atlasRegion.width;
      float x = (float) ByteCodeHelper.f2i(width / 2f);
      float y = (float) ByteCodeHelper.f2i(num1 - 6f - h) + h / 2f - (!Core.graphics.isPortrait() ? 0.0f : Scl.scl(30f));
      Draw.color();
      Draw.rect((TextureRegion) atlasRegion, x, y, w, h);
      Fonts.def.setColor(Color.__\u003C\u003Ewhite);
      Font def = Fonts.def;
      string str1 = obj0;
      double num3 = (double) x;
      double num4 = (double) (y - h / 2f);
      int num5 = 1;
      float num6 = (float) num4;
      float num7 = (float) num3;
      object obj = (object) str1;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence str2 = charSequence;
      double num8 = (double) num7;
      double num9 = (double) num6;
      int halign = num5;
      def.draw(str2, (float) num8, (float) num9, halign);
    }

    [Modifiers]
    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildMobile\u002412()
    {
      PlanetDialog planet = Vars.ui.planet;
      Objects.requireNonNull((object) planet);
      this.checkPlay((Runnable) new MenuFragment.__\u003C\u003EAnon35(planet));
    }

    [Modifiers]
    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildMobile\u002413()
    {
      CustomGameDialog custom = Vars.ui.custom;
      Objects.requireNonNull((object) custom);
      this.checkPlay((Runnable) new MenuFragment.__\u003C\u003EAnon33(custom));
    }

    [Modifiers]
    [LineNumberTable(101)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildMobile\u002414()
    {
      LoadDialog load = Vars.ui.load;
      Objects.requireNonNull((object) load);
      this.checkPlay((Runnable) new MenuFragment.__\u003C\u003EAnon32(load));
    }

    [Modifiers]
    [LineNumberTable(102)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildMobile\u002415()
    {
      JoinDialog join = Vars.ui.join;
      Objects.requireNonNull((object) join);
      this.checkPlay((Runnable) new MenuFragment.__\u003C\u003EAnon34(join));
    }

    [Modifiers]
    [LineNumberTable(103)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildMobile\u002416()
    {
      MapsDialog maps = Vars.ui.maps;
      Objects.requireNonNull((object) maps);
      this.checkPlay((Runnable) new MenuFragment.__\u003C\u003EAnon31(maps));
    }

    [Modifiers]
    [LineNumberTable(106)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024buildMobile\u002417() => Core.app.exit();

    [Modifiers]
    [LineNumberTable(new byte[] {67, 152, 105, 137, 137, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildMobile\u002418(
      [In] MobileButton obj0,
      [In] MobileButton obj1,
      [In] MobileButton obj2,
      [In] MobileButton obj3,
      [In] Table obj4)
    {
      obj4.defaults().set(this.container.defaults());
      obj4.add((Element) obj0);
      obj4.add((Element) obj1);
      obj4.add((Element) obj2);
      if (Vars.ios)
        return;
      obj4.add((Element) obj3);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {89, 151, 136, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildMobile\u002419([In] MobileButton obj0, [In] MobileButton obj1, [In] Table obj2)
    {
      obj2.defaults().set(this.container.defaults());
      obj2.add((Element) obj0);
      if (Vars.ios)
        return;
      obj2.add((Element) obj1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {108, 120, 139, 255, 160, 84, 71, 127, 40, 191, 14, 127, 14, 127, 9, 246, 51, 229, 80})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildDesktop\u002425([In] float obj0, [In] Table obj1)
    {
      obj1.defaults().width(obj0).height(70f);
      obj1.name = "buttons";
      Table table = obj1;
      MenuFragment.Buttoni[] buttoniArray = new MenuFragment.Buttoni[7];
      buttoniArray[0] = new MenuFragment.Buttoni("@play", (Drawable) Icon.play, new MenuFragment.Buttoni[4]
      {
        new MenuFragment.Buttoni("@campaign", (Drawable) Icon.play, (Runnable) new MenuFragment.__\u003C\u003EAnon23(this)),
        new MenuFragment.Buttoni("@joingame", (Drawable) Icon.add, (Runnable) new MenuFragment.__\u003C\u003EAnon24(this)),
        new MenuFragment.Buttoni("@customgame", (Drawable) Icon.terrain, (Runnable) new MenuFragment.__\u003C\u003EAnon25(this)),
        new MenuFragment.Buttoni("@loadgame", (Drawable) Icon.download, (Runnable) new MenuFragment.__\u003C\u003EAnon26(this))
      });
      buttoniArray[1] = new MenuFragment.Buttoni("@editor", (Drawable) Icon.terrain, (Runnable) new MenuFragment.__\u003C\u003EAnon27(this));
      MenuFragment.Buttoni buttoni;
      if (Vars.steam)
      {
        TextureRegionDrawable steam = Icon.steam;
        Platform platform = Vars.platform;
        Objects.requireNonNull((object) platform);
        Runnable runnable = (Runnable) new MenuFragment.__\u003C\u003EAnon28(platform);
        buttoni = new MenuFragment.Buttoni("@workshop", (Drawable) steam, runnable);
      }
      else
        buttoni = (MenuFragment.Buttoni) null;
      buttoniArray[2] = buttoni;
      TextureRegionDrawable book = Icon.book;
      ModsDialog mods = Vars.ui.mods;
      Objects.requireNonNull((object) mods);
      Runnable runnable1 = (Runnable) new MenuFragment.__\u003C\u003EAnon13(mods);
      buttoniArray[3] = new MenuFragment.Buttoni("@mods", (Drawable) book, runnable1);
      TextureRegionDrawable settings1 = Icon.settings;
      SettingsMenuDialog settings2 = Vars.ui.settings;
      Objects.requireNonNull((object) settings2);
      Runnable runnable2 = (Runnable) new MenuFragment.__\u003C\u003EAnon12(settings2);
      buttoniArray[4] = new MenuFragment.Buttoni("@settings", (Drawable) settings1, runnable2);
      TextureRegionDrawable info = Icon.info;
      AboutDialog about = Vars.ui.about;
      Objects.requireNonNull((object) about);
      Runnable runnable3 = (Runnable) new MenuFragment.__\u003C\u003EAnon29(about);
      buttoniArray[5] = new MenuFragment.Buttoni("@about.button", (Drawable) info, runnable3);
      TextureRegionDrawable exit = Icon.exit;
      Application app = Core.app;
      Objects.requireNonNull((object) app);
      Runnable runnable4 = (Runnable) new MenuFragment.__\u003C\u003EAnon30(app);
      buttoniArray[6] = new MenuFragment.Buttoni("@quit", (Drawable) exit, runnable4);
      this.buttons(table, buttoniArray);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 66, 103, 107, 112, 103, 120, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildDesktop\u002427([In] float obj0, [In] Table obj1)
    {
      this.submenu = obj1;
      obj1.name = "submenu";
      obj1.__\u003C\u003Ecolor.a = 0.0f;
      obj1.top();
      obj1.defaults().width(obj0).height(70f);
      obj1.visible((Boolp) new MenuFragment.__\u003C\u003EAnon22(obj1));
    }

    [Modifiers]
    [LineNumberTable(211)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024fadeOutMenu\u002428() => this.submenu.clearChildren();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 105, 112, 103, 139, 107, 105, 107, 134, 127, 47, 108, 148, 103, 102, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buttons\u002429([In] Button[] obj0, [In] MenuFragment.Buttoni obj1)
    {
      if (object.ReferenceEquals((object) this.currentMenu, (object) obj0[0]))
      {
        this.currentMenu = (Button) null;
        this.fadeOutMenu();
      }
      else if (obj1.submenu != null)
      {
        this.currentMenu = obj0[0];
        this.submenu.clearChildren();
        this.fadeInMenu();
        this.submenu.add().height(((float) Core.graphics.getHeight() - Core.scene.marginTop - Core.scene.marginBottom - obj0[0].getY(10)) / Scl.scl(1f));
        this.submenu.row();
        this.buttons(this.submenu, obj1.submenu);
      }
      else
      {
        this.currentMenu = (Button) null;
        this.fadeOutMenu();
        obj1.runnable.run();
      }
    }

    [Modifiers]
    [LineNumberTable(238)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buttons\u002430([In] Button[] obj0) => obj0[0].setChecked(object.ReferenceEquals((object) this.currentMenu, (object) obj0[0]));

    [Modifiers]
    [LineNumberTable(185)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024buildDesktop\u002426([In] Table obj0) => !obj0.getChildren().isEmpty();

    [Modifiers]
    [LineNumberTable(163)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildDesktop\u002420()
    {
      PlanetDialog planet = Vars.ui.planet;
      Objects.requireNonNull((object) planet);
      this.checkPlay((Runnable) new MenuFragment.__\u003C\u003EAnon35(planet));
    }

    [Modifiers]
    [LineNumberTable(164)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildDesktop\u002421()
    {
      JoinDialog join = Vars.ui.join;
      Objects.requireNonNull((object) join);
      this.checkPlay((Runnable) new MenuFragment.__\u003C\u003EAnon34(join));
    }

    [Modifiers]
    [LineNumberTable(165)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildDesktop\u002422()
    {
      CustomGameDialog custom = Vars.ui.custom;
      Objects.requireNonNull((object) custom);
      this.checkPlay((Runnable) new MenuFragment.__\u003C\u003EAnon33(custom));
    }

    [Modifiers]
    [LineNumberTable(166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildDesktop\u002423()
    {
      LoadDialog load = Vars.ui.load;
      Objects.requireNonNull((object) load);
      this.checkPlay((Runnable) new MenuFragment.__\u003C\u003EAnon32(load));
    }

    [Modifiers]
    [LineNumberTable(168)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildDesktop\u002424()
    {
      MapsDialog maps = Vars.ui.maps;
      Objects.requireNonNull((object) maps);
      this.checkPlay((Runnable) new MenuFragment.__\u003C\u003EAnon31(maps));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {9, 111, 244, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u00248()
    {
      Vars.ui.loadfrag.show();
      Vars.becontrol.checkUpdate((Boolc) new MenuFragment.__\u003C\u003EAnon38());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {17, 127, 40})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u00249([In] TextButton obj0) => obj0.getLabel().setColor(!Vars.becontrol.isUpdateAvailable() ? Color.__\u003C\u003Ewhite : Tmp.__\u003C\u003Ec1.set(Color.__\u003C\u003Ewhite).lerp(Pal.accent, Mathf.absin(5f, 1f)));

    [Modifiers]
    [LineNumberTable(new byte[] {159, 127, 98, 111, 99, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u00247([In] bool obj0)
    {
      int num = obj0 ? 1 : 0;
      Vars.ui.loadfrag.hide();
      if (num != 0)
        return;
      Vars.ui.showInfo("@be.noupdates");
    }

    [Modifiers]
    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00242([In] EventType.ResizeEvent obj0) => this.buildDesktop();

    [Modifiers]
    [LineNumberTable(49)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00243([In] EventType.ResizeEvent obj0) => this.buildMobile();

    [InnerClass]
    internal class Buttoni : Object
    {
      [Modifiers]
      internal Drawable icon;
      [Modifiers]
      internal string text;
      [Modifiers]
      internal Runnable runnable;
      [Modifiers]
      internal MenuFragment.Buttoni[] submenu;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024new\u00240()
      {
      }

      [LineNumberTable(new byte[] {160, 135, 104, 103, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Buttoni([In] string obj0, [In] Drawable obj1, [In] Runnable obj2)
      {
        MenuFragment.Buttoni buttoni = this;
        this.icon = obj1;
        this.text = obj0;
        this.runnable = obj2;
        this.submenu = (MenuFragment.Buttoni[]) null;
      }

      [LineNumberTable(new byte[] {160, 142, 104, 103, 103, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Buttoni(string _param1, Drawable _param2, params MenuFragment.Buttoni[] _param3)
      {
        MenuFragment.Buttoni buttoni = this;
        this.icon = _param2;
        this.text = _param1;
        this.runnable = (Runnable) new MenuFragment.Buttoni.__\u003C\u003EAnon0();
        this.submenu = _param3;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Runnable
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public void run() => MenuFragment.Buttoni.lambda\u0024new\u00240();
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolp
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get() => (MenuFragment.lambda\u0024build\u00240() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Table.DrawRect
    {
      private readonly MenuFragment arg\u00241;

      internal __\u003C\u003EAnon1([In] MenuFragment obj0) => this.arg\u00241 = obj0;

      public void draw([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3) => this.arg\u00241.lambda\u0024build\u00241(obj0, obj1, obj2, obj3);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly MenuFragment arg\u00241;

      internal __\u003C\u003EAnon2([In] MenuFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00244((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void get([In] object obj0) => MenuFragment.lambda\u0024build\u00245((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public void get([In] object obj0) => MenuFragment.lambda\u0024build\u00246((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void get([In] object obj0) => MenuFragment.lambda\u0024build\u002410((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Table.DrawRect
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon6([In] string obj0) => this.arg\u00241 = obj0;

      public void draw([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3) => MenuFragment.lambda\u0024build\u002411(this.arg\u00241, obj0, obj1, obj2, obj3);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly MenuFragment arg\u00241;

      internal __\u003C\u003EAnon7([In] MenuFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildMobile\u002412();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly MenuFragment arg\u00241;

      internal __\u003C\u003EAnon8([In] MenuFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildMobile\u002413();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly MenuFragment arg\u00241;

      internal __\u003C\u003EAnon9([In] MenuFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildMobile\u002414();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Runnable
    {
      private readonly MenuFragment arg\u00241;

      internal __\u003C\u003EAnon10([In] MenuFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildMobile\u002415();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly MenuFragment arg\u00241;

      internal __\u003C\u003EAnon11([In] MenuFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildMobile\u002416();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Runnable
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon12([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly ModsDialog arg\u00241;

      internal __\u003C\u003EAnon13([In] ModsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public void run() => MenuFragment.lambda\u0024buildMobile\u002417();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Cons
    {
      private readonly MenuFragment arg\u00241;
      private readonly MobileButton arg\u00242;
      private readonly MobileButton arg\u00243;
      private readonly MobileButton arg\u00244;
      private readonly MobileButton arg\u00245;

      internal __\u003C\u003EAnon15(
        [In] MenuFragment obj0,
        [In] MobileButton obj1,
        [In] MobileButton obj2,
        [In] MobileButton obj3,
        [In] MobileButton obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildMobile\u002418(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Cons
    {
      private readonly MenuFragment arg\u00241;
      private readonly MobileButton arg\u00242;
      private readonly MobileButton arg\u00243;

      internal __\u003C\u003EAnon16([In] MenuFragment obj0, [In] MobileButton obj1, [In] MobileButton obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildMobile\u002419(this.arg\u00242, this.arg\u00243, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Cons
    {
      private readonly MenuFragment arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon17([In] MenuFragment obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildDesktop\u002425(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Cons
    {
      private readonly MenuFragment arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon18([In] MenuFragment obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildDesktop\u002427(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Runnable
    {
      private readonly MenuFragment arg\u00241;

      internal __\u003C\u003EAnon19([In] MenuFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024fadeOutMenu\u002428();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Runnable
    {
      private readonly MenuFragment arg\u00241;
      private readonly Button[] arg\u00242;
      private readonly MenuFragment.Buttoni arg\u00243;

      internal __\u003C\u003EAnon20([In] MenuFragment obj0, [In] Button[] obj1, [In] MenuFragment.Buttoni obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024buttons\u002429(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Runnable
    {
      private readonly MenuFragment arg\u00241;
      private readonly Button[] arg\u00242;

      internal __\u003C\u003EAnon21([In] MenuFragment obj0, [In] Button[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024buttons\u002430(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Boolp
    {
      private readonly Table arg\u00241;

      internal __\u003C\u003EAnon22([In] Table obj0) => this.arg\u00241 = obj0;

      public bool get() => (MenuFragment.lambda\u0024buildDesktop\u002426(this.arg\u00241) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Runnable
    {
      private readonly MenuFragment arg\u00241;

      internal __\u003C\u003EAnon23([In] MenuFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildDesktop\u002420();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Runnable
    {
      private readonly MenuFragment arg\u00241;

      internal __\u003C\u003EAnon24([In] MenuFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildDesktop\u002421();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Runnable
    {
      private readonly MenuFragment arg\u00241;

      internal __\u003C\u003EAnon25([In] MenuFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildDesktop\u002422();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Runnable
    {
      private readonly MenuFragment arg\u00241;

      internal __\u003C\u003EAnon26([In] MenuFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildDesktop\u002423();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Runnable
    {
      private readonly MenuFragment arg\u00241;

      internal __\u003C\u003EAnon27([In] MenuFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024buildDesktop\u002424();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Runnable
    {
      private readonly Platform arg\u00241;

      internal __\u003C\u003EAnon28([In] Platform obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.openWorkshop();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Runnable
    {
      private readonly AboutDialog arg\u00241;

      internal __\u003C\u003EAnon29([In] AboutDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Runnable
    {
      private readonly Application arg\u00241;

      internal __\u003C\u003EAnon30([In] Application obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.exit();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Runnable
    {
      private readonly MapsDialog arg\u00241;

      internal __\u003C\u003EAnon31([In] MapsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Runnable
    {
      private readonly LoadDialog arg\u00241;

      internal __\u003C\u003EAnon32([In] LoadDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Runnable
    {
      private readonly CustomGameDialog arg\u00241;

      internal __\u003C\u003EAnon33([In] CustomGameDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Runnable
    {
      private readonly JoinDialog arg\u00241;

      internal __\u003C\u003EAnon34([In] JoinDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Runnable
    {
      private readonly PlanetDialog arg\u00241;

      internal __\u003C\u003EAnon35([In] PlanetDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : Runnable
    {
      internal __\u003C\u003EAnon36()
      {
      }

      public void run() => MenuFragment.lambda\u0024build\u00248();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon37 : Cons
    {
      internal __\u003C\u003EAnon37()
      {
      }

      public void get([In] object obj0) => MenuFragment.lambda\u0024build\u00249((TextButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon38 : Boolc
    {
      internal __\u003C\u003EAnon38()
      {
      }

      public void get([In] bool obj0) => MenuFragment.lambda\u0024build\u00247(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon39 : Runnable
    {
      private readonly DiscordDialog arg\u00241;

      internal __\u003C\u003EAnon39([In] DiscordDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon40 : Cons
    {
      private readonly MenuFragment arg\u00241;

      internal __\u003C\u003EAnon40([In] MenuFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00242((EventType.ResizeEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon41 : Cons
    {
      private readonly MenuFragment arg\u00241;

      internal __\u003C\u003EAnon41([In] MenuFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00243((EventType.ResizeEvent) obj0);
    }
  }
}
