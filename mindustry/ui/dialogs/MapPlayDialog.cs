// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.MapPlayDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.game;
using mindustry.gen;
using mindustry.maps;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class MapPlayDialog : BaseDialog
  {
    internal CustomRulesDialog dialog;
    internal Rules rules;
    internal Gamemode selectedGamemode;
    internal Map lastMap;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 163, 237, 58, 139, 235, 69, 135, 241, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MapPlayDialog()
      : base("")
    {
      MapPlayDialog mapPlayDialog = this;
      this.dialog = new CustomRulesDialog();
      this.selectedGamemode = Gamemode.__\u003C\u003Esurvival;
      this.setFillParent(false);
      this.onResize((Runnable) new MapPlayDialog.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {159, 176, 103, 127, 2, 171, 110, 127, 1, 104, 203, 146, 102, 127, 3, 103, 130, 135, 127, 0, 142, 191, 15, 127, 9, 251, 57, 235, 73, 105, 159, 17, 109, 108, 127, 23, 108, 159, 53, 109, 108, 191, 2, 107, 134, 223, 12, 134, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show(Map map)
    {
      this.lastMap = map;
      Label title = this.__\u003C\u003Etitle;
      object obj1 = (object) map.name();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj1;
      CharSequence newText = charSequence;
      title.setText(newText);
      this.__\u003C\u003Econt.clearChildren();
      if (!this.selectedGamemode.valid(map))
      {
        this.selectedGamemode = (Gamemode) Structs.find((object[]) Gamemode.__\u003C\u003Eall, (Boolf) new MapPlayDialog.__\u003C\u003EAnon1(map));
        if (this.selectedGamemode == null)
          this.selectedGamemode = Gamemode.__\u003C\u003Esurvival;
      }
      this.rules = map.applyRules(this.selectedGamemode);
      Table table1 = new Table();
      Table table2 = table1;
      object obj2 = (object) "@level.mode";
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text = charSequence;
      table2.add(text).colspan(4);
      table1.row();
      int num1 = 0;
      Table table3 = new Table();
      Gamemode[] gamemodeArray = Gamemode.values();
      int length = gamemodeArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Gamemode gamemode = gamemodeArray[index];
        if (!gamemode.__\u003C\u003Ehidden)
        {
          table3.button(gamemode.toString(), Styles.togglet, (Runnable) new MapPlayDialog.__\u003C\u003EAnon2(this, gamemode, map)).update((Cons) new MapPlayDialog.__\u003C\u003EAnon3(this, gamemode)).size(140f, 54f).disabled(!gamemode.valid(map));
          int num2 = num1;
          ++num1;
          int num3 = 2;
          if ((num3 != -1 ? num2 % num3 : 0) == 1)
            table3.row();
        }
      }
      table1.add((Element) table3);
      table1.button("?", (Runnable) new MapPlayDialog.__\u003C\u003EAnon4(this)).width(50f).fillY().padLeft(18f);
      this.__\u003C\u003Econt.add((Element) table1);
      this.__\u003C\u003Econt.row();
      this.__\u003C\u003Econt.button("@customize", (Drawable) Icon.settings, (Runnable) new MapPlayDialog.__\u003C\u003EAnon5(this, map)).height(50f).width(230f);
      this.__\u003C\u003Econt.row();
      ((Image) this.__\u003C\u003Econt.add((Element) new BorderImage(map.safeTexture(), 3f)).size(!Vars.mobile || Core.graphics.isPortrait() ? 250f : 150f).get()).setScaling(Scaling.__\u003C\u003Efit);
      if (Gamemode.__\u003C\u003Esurvival.valid(map))
      {
        this.__\u003C\u003Econt.row();
        this.__\u003C\u003Econt.label((Prov) new MapPlayDialog.__\u003C\u003EAnon6(map)).pad(3f);
      }
      this.__\u003C\u003Ebuttons.clearChildren();
      this.addCloseButton();
      this.__\u003C\u003Ebuttons.button("@play", (Drawable) Icon.play, (Runnable) new MapPlayDialog.__\u003C\u003EAnon7(this, map)).size(210f, 64f);
      this.show();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 167, 104, 103, 108, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240()
    {
      if (this.lastMap == null)
        return;
      Rules rules = this.rules;
      this.show(this.lastMap);
      this.rules = rules;
    }

    [Modifiers]
    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024show\u00241([In] Map obj0, [In] Gamemode obj1) => obj1.valid(obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {9, 103, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024show\u00242([In] Gamemode obj0, [In] Map obj1)
    {
      this.selectedGamemode = obj0;
      this.rules = obj1.applyRules(obj0);
    }

    [Modifiers]
    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024show\u00243([In] Gamemode obj0, [In] TextButton obj1) => obj1.setChecked(object.ReferenceEquals((object) this.selectedGamemode, (object) obj0));

    [LineNumberTable(new byte[] {41, 122, 103, 102, 113, 103, 103, 103, 124, 107, 127, 40, 231, 61, 235, 70, 109, 127, 29, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void displayGameModeHelp()
    {
      BaseDialog.__\u003Cclinit\u003E();
      BaseDialog baseDialog1 = new BaseDialog(Core.bundle.get("mode.help.title"));
      baseDialog1.setFillParent(false);
      Table table = new Table();
      table.defaults().pad(1f);
      ScrollPane scrollPane = new ScrollPane((Element) table);
      scrollPane.setFadeScrollBars(false);
      table.row();
      Gamemode[] gamemodeArray = Gamemode.values();
      int length = gamemodeArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Gamemode gamemode = gamemodeArray[index];
        if (!gamemode.__\u003C\u003Ehidden)
        {
          table.labelWrap(new StringBuilder().append("[accent]").append(gamemode.toString()).append(":[] [lightgray]").append(gamemode.description()).toString()).width(400f);
          table.row();
        }
      }
      baseDialog1.__\u003C\u003Econt.add((Element) scrollPane);
      Table buttons = baseDialog1.__\u003C\u003Ebuttons;
      BaseDialog baseDialog2 = baseDialog1;
      Objects.requireNonNull((object) baseDialog2);
      Runnable listener = (Runnable) new MapPlayDialog.__\u003C\u003EAnon8(baseDialog2);
      buttons.button("@ok", listener).size(110f, 50f).pad(10f);
      baseDialog1.show();
    }

    [Modifiers]
    [LineNumberTable(69)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024show\u00245([In] Map obj0) => this.dialog.show(this.rules, (Prov) new MapPlayDialog.__\u003C\u003EAnon9(this, obj0));

    [Modifiers]
    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024show\u00246([In] Map obj0)
    {
      object obj = (object) Core.bundle.format("level.highscore", (object) Integer.valueOf(obj0.getHightScore()));
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {32, 113, 102, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024show\u00247([In] Map obj0)
    {
      Vars.control.playMap(obj0, this.rules);
      this.hide();
      Vars.ui.custom.hide();
    }

    [Modifiers]
    [LineNumberTable(69)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Rules lambda\u0024show\u00244([In] Map obj0)
    {
      MapPlayDialog mapPlayDialog = this;
      Rules rules1 = obj0.applyRules(this.selectedGamemode);
      Rules rules2 = rules1;
      this.rules = rules1;
      return rules2;
    }

    [HideFromJava]
    static MapPlayDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly MapPlayDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] MapPlayDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Boolf
    {
      private readonly Map arg\u00241;

      internal __\u003C\u003EAnon1([In] Map obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (MapPlayDialog.lambda\u0024show\u00241(this.arg\u00241, (Gamemode) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly MapPlayDialog arg\u00241;
      private readonly Gamemode arg\u00242;
      private readonly Map arg\u00243;

      internal __\u003C\u003EAnon2([In] MapPlayDialog obj0, [In] Gamemode obj1, [In] Map obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024show\u00242(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly MapPlayDialog arg\u00241;
      private readonly Gamemode arg\u00242;

      internal __\u003C\u003EAnon3([In] MapPlayDialog obj0, [In] Gamemode obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024show\u00243(this.arg\u00242, (TextButton) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly MapPlayDialog arg\u00241;

      internal __\u003C\u003EAnon4([In] MapPlayDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.displayGameModeHelp();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly MapPlayDialog arg\u00241;
      private readonly Map arg\u00242;

      internal __\u003C\u003EAnon5([In] MapPlayDialog obj0, [In] Map obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024show\u00245(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Prov
    {
      private readonly Map arg\u00241;

      internal __\u003C\u003EAnon6([In] Map obj0) => this.arg\u00241 = obj0;

      public object get() => (object) MapPlayDialog.lambda\u0024show\u00246(this.arg\u00241).__\u003Cref\u003E;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly MapPlayDialog arg\u00241;
      private readonly Map arg\u00242;

      internal __\u003C\u003EAnon7([In] MapPlayDialog obj0, [In] Map obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024show\u00247(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly BaseDialog arg\u00241;

      internal __\u003C\u003EAnon8([In] BaseDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Prov
    {
      private readonly MapPlayDialog arg\u00241;
      private readonly Map arg\u00242;

      internal __\u003C\u003EAnon9([In] MapPlayDialog obj0, [In] Map obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) this.arg\u00241.lambda\u0024show\u00244(this.arg\u00242);
    }
  }
}
