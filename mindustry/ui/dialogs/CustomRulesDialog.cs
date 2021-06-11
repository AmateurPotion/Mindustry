// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.CustomRulesDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.math;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class CustomRulesDialog : BaseDialog
  {
    internal Rules rules;
    private Table main;
    [Signature("Larc/func/Prov<Lmindustry/game/Rules;>;")]
    private Prov resetter;
    private LoadoutDialog loadoutDialog;
    private BaseDialog banDialog;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 176, 141, 107, 112, 139, 118, 191, 16, 134, 191, 16, 134, 103, 113, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CustomRulesDialog()
      : base("@mode.custom")
    {
      CustomRulesDialog customRulesDialog = this;
      this.loadoutDialog = new LoadoutDialog();
      this.banDialog = new BaseDialog("@bannedblocks");
      this.banDialog.addCloseButton();
      this.banDialog.shown((Runnable) new CustomRulesDialog.__\u003C\u003EAnon0(this));
      this.banDialog.__\u003C\u003Ebuttons.button("@addall", (Drawable) Icon.add, (Runnable) new CustomRulesDialog.__\u003C\u003EAnon1(this)).size(180f, 64f);
      this.banDialog.__\u003C\u003Ebuttons.button("@clear", (Drawable) Icon.trash, (Runnable) new CustomRulesDialog.__\u003C\u003EAnon2(this)).size(180f, 64f);
      this.setFillParent(true);
      this.shown((Runnable) new CustomRulesDialog.__\u003C\u003EAnon3(this));
      this.addCloseButton();
    }

    [Signature("(Lmindustry/game/Rules;Larc/func/Prov<Lmindustry/game/Rules;>;)V")]
    [LineNumberTable(new byte[] {65, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show(Rules rules, Prov resetter)
    {
      this.rules = rules;
      this.resetter = resetter;
      this.show();
    }

    [LineNumberTable(new byte[] {160, 129, 127, 38, 108, 127, 21, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void title([In] string obj0)
    {
      Table main = this.main;
      object obj = (object) obj0;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      main.add(text).color(Pal.accent).padTop(20f).padRight(100f).padBottom(-3f);
      this.main.row();
      this.main.image().color(Pal.accent).height(3f).padRight(100f).padBottom(20f);
      this.main.row();
    }

    [LineNumberTable(new byte[] {160, 120, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void check([In] string obj0, [In] Boolc obj1, [In] Boolp obj2) => this.check(obj0, obj1, obj2, (Boolp) new CustomRulesDialog.__\u003C\u003EAnon73());

    [LineNumberTable(new byte[] {159, 87, 98, 255, 8, 72, 102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void number(
      [In] string obj0,
      [In] bool obj1,
      [In] Floatc obj2,
      [In] Floatp obj3,
      [In] Boolp obj4,
      [In] float obj5,
      [In] float obj6)
    {
      int num = obj1 ? 1 : 0;
      this.main.table((Cons) new CustomRulesDialog.__\u003C\u003EAnon72(obj0, obj4, num != 0, obj3, obj2, obj5, obj6)).padTop(0.0f);
      this.main.row();
    }

    [LineNumberTable(new byte[] {159, 92, 130, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void number([In] string obj0, [In] bool obj1, [In] Floatc obj2, [In] Floatp obj3, [In] Boolp obj4)
    {
      int num = obj1 ? 1 : 0;
      this.number(obj0, num != 0, obj2, obj3, obj4, 0.0f, float.MaxValue);
    }

    [LineNumberTable(new byte[] {160, 84, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void number([In] string obj0, [In] Floatc obj1, [In] Floatp obj2, [In] float obj3, [In] float obj4) => this.number(obj0, false, obj1, obj2, (Boolp) new CustomRulesDialog.__\u003C\u003EAnon70(), obj3, obj4);

    [LineNumberTable(new byte[] {160, 80, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void number([In] string obj0, [In] Floatc obj1, [In] Floatp obj2) => this.number(obj0, false, obj1, obj2, (Boolp) new CustomRulesDialog.__\u003C\u003EAnon69(), 0.0f, float.MaxValue);

    [LineNumberTable(new byte[] {159, 90, 130, 255, 4, 70, 102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void number(
      [In] string obj0,
      [In] bool obj1,
      [In] Intc obj2,
      [In] Intp obj3,
      [In] int obj4,
      [In] int obj5)
    {
      int num = obj1 ? 1 : 0;
      this.main.table((Cons) new CustomRulesDialog.__\u003C\u003EAnon71(obj0, num != 0, obj3, obj2, obj4, obj5)).padTop(0.0f);
      this.main.row();
    }

    [LineNumberTable(new byte[] {160, 124, 127, 36, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void check([In] string obj0, [In] Boolc obj1, [In] Boolp obj2, [In] Boolp obj3)
    {
      ((Table) this.main.check(obj0, obj1).@checked(obj2.get()).update((Cons) new CustomRulesDialog.__\u003C\u003EAnon74(obj3)).padRight(100f).get()).left();
      this.main.row();
    }

    [Signature("(Larc/scene/ui/layout/Table;FLarc/func/Floatc;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextField;>;")]
    [LineNumberTable(new byte[] {160, 136, 127, 4, 111, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Cell field([In] Table obj0, [In] float obj1, [In] Floatc obj2) => obj0.field(Strings.autoFixed(obj1, 2), (Cons) new CustomRulesDialog.__\u003C\u003EAnon75(obj2)).valid((TextField.TextFieldValidator) new CustomRulesDialog.__\u003C\u003EAnon76()).size(90f, 40f).pad(2f).addInputDialog();

    [LineNumberTable(new byte[] {71, 107, 127, 8, 113, 255, 6, 69, 102, 127, 6, 140, 107, 127, 2, 127, 2, 127, 2, 127, 23, 159, 13, 107, 127, 2, 127, 2, 127, 2, 127, 2, 127, 14, 127, 12, 127, 14, 127, 2, 159, 2, 251, 69, 112, 140, 127, 24, 140, 107, 127, 2, 127, 2, 127, 13, 127, 2, 159, 12, 107, 127, 2, 127, 2, 159, 2, 107, 127, 2, 127, 2, 127, 2, 159, 2, 255, 2, 72, 148, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setup()
    {
      this.__\u003C\u003Econt.clear();
      ((ScrollPane) this.__\u003C\u003Econt.pane((Cons) new CustomRulesDialog.__\u003C\u003EAnon6(this)).get()).setScrollingDisabled(true, false);
      this.main.margin(10f);
      this.main.button("@settings.reset", (Runnable) new CustomRulesDialog.__\u003C\u003EAnon7(this)).size(300f, 50f);
      this.main.left().defaults().fillX().left().pad(5f);
      this.main.row();
      this.title("@rules.title.waves");
      this.check("@rules.waves", (Boolc) new CustomRulesDialog.__\u003C\u003EAnon8(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon9(this));
      this.check("@rules.wavetimer", (Boolc) new CustomRulesDialog.__\u003C\u003EAnon10(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon11(this));
      this.check("@rules.waitForWaveToEnd", (Boolc) new CustomRulesDialog.__\u003C\u003EAnon12(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon13(this));
      this.number("@rules.wavespacing", false, (Floatc) new CustomRulesDialog.__\u003C\u003EAnon14(this), (Floatp) new CustomRulesDialog.__\u003C\u003EAnon15(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon16(), 1f, float.MaxValue);
      this.number("@rules.dropzoneradius", false, (Floatc) new CustomRulesDialog.__\u003C\u003EAnon17(this), (Floatp) new CustomRulesDialog.__\u003C\u003EAnon18(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon19());
      this.title("@rules.title.resourcesbuilding");
      this.check("@rules.infiniteresources", (Boolc) new CustomRulesDialog.__\u003C\u003EAnon20(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon21(this));
      this.check("@rules.reactorexplosions", (Boolc) new CustomRulesDialog.__\u003C\u003EAnon22(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon23(this));
      this.check("@rules.schematic", (Boolc) new CustomRulesDialog.__\u003C\u003EAnon24(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon25(this));
      this.check("@rules.coreincinerates", (Boolc) new CustomRulesDialog.__\u003C\u003EAnon26(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon27(this));
      this.number("@rules.buildcostmultiplier", false, (Floatc) new CustomRulesDialog.__\u003C\u003EAnon28(this), (Floatp) new CustomRulesDialog.__\u003C\u003EAnon29(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon30(this));
      this.number("@rules.buildspeedmultiplier", (Floatc) new CustomRulesDialog.__\u003C\u003EAnon31(this), (Floatp) new CustomRulesDialog.__\u003C\u003EAnon32(this), 1f / 1000f, 50f);
      this.number("@rules.deconstructrefundmultiplier", false, (Floatc) new CustomRulesDialog.__\u003C\u003EAnon33(this), (Floatp) new CustomRulesDialog.__\u003C\u003EAnon34(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon35(this));
      this.number("@rules.blockhealthmultiplier", (Floatc) new CustomRulesDialog.__\u003C\u003EAnon36(this), (Floatp) new CustomRulesDialog.__\u003C\u003EAnon37(this));
      this.number("@rules.blockdamagemultiplier", (Floatc) new CustomRulesDialog.__\u003C\u003EAnon38(this), (Floatp) new CustomRulesDialog.__\u003C\u003EAnon39(this));
      this.main.button("@configure", (Runnable) new CustomRulesDialog.__\u003C\u003EAnon40(this)).left().width(300f);
      this.main.row();
      Table main = this.main;
      BaseDialog banDialog = this.banDialog;
      Objects.requireNonNull((object) banDialog);
      Runnable listener = (Runnable) new CustomRulesDialog.__\u003C\u003EAnon41(banDialog);
      main.button("@bannedblocks", listener).left().width(300f);
      this.main.row();
      this.title("@rules.title.unit");
      this.check("@rules.unitammo", (Boolc) new CustomRulesDialog.__\u003C\u003EAnon42(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon43(this));
      this.check("@rules.unitcapvariable", (Boolc) new CustomRulesDialog.__\u003C\u003EAnon44(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon45(this));
      this.number("@rules.unitcap", true, (Intc) new CustomRulesDialog.__\u003C\u003EAnon46(this), (Intp) new CustomRulesDialog.__\u003C\u003EAnon47(this), -999, 999);
      this.number("@rules.unitdamagemultiplier", (Floatc) new CustomRulesDialog.__\u003C\u003EAnon48(this), (Floatp) new CustomRulesDialog.__\u003C\u003EAnon49(this));
      this.number("@rules.unitbuildspeedmultiplier", (Floatc) new CustomRulesDialog.__\u003C\u003EAnon50(this), (Floatp) new CustomRulesDialog.__\u003C\u003EAnon51(this), 1f / 1000f, 50f);
      this.title("@rules.title.enemy");
      this.check("@rules.attack", (Boolc) new CustomRulesDialog.__\u003C\u003EAnon52(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon53(this));
      this.check("@rules.buildai", (Boolc) new CustomRulesDialog.__\u003C\u003EAnon54(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon55(this));
      this.number("@rules.enemycorebuildradius", (Floatc) new CustomRulesDialog.__\u003C\u003EAnon56(this), (Floatp) new CustomRulesDialog.__\u003C\u003EAnon57(this));
      this.title("@rules.title.environment");
      this.check("@rules.explosions", (Boolc) new CustomRulesDialog.__\u003C\u003EAnon58(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon59(this));
      this.check("@rules.fire", (Boolc) new CustomRulesDialog.__\u003C\u003EAnon60(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon61(this));
      this.check("@rules.lighting", (Boolc) new CustomRulesDialog.__\u003C\u003EAnon62(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon63(this));
      this.check("@rules.enemyLights", (Boolc) new CustomRulesDialog.__\u003C\u003EAnon64(this), (Boolp) new CustomRulesDialog.__\u003C\u003EAnon65(this));
      this.main.button((Cons) new CustomRulesDialog.__\u003C\u003EAnon66(this), (Runnable) new CustomRulesDialog.__\u003C\u003EAnon67(this)).left().width(250f).row();
      this.main.button("@rules.weather", (Runnable) new CustomRulesDialog.__\u003C\u003EAnon68(this)).width(250f).left().row();
    }

    [LineNumberTable(new byte[] {7, 127, 32, 112, 251, 93, 112, 113, 255, 16, 85, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void rebuildBanned()
    {
      float pixels = !this.banDialog.__\u003C\u003Econt.getChildren().isEmpty() ? ((ScrollPane) this.banDialog.__\u003C\u003Econt.getChildren().first()).getScrollY() : 0.0f;
      this.banDialog.__\u003C\u003Econt.clear();
      ((ScrollPane) this.banDialog.__\u003C\u003Econt.pane((Cons) new CustomRulesDialog.__\u003C\u003EAnon4(this)).get()).setScrollYForce(pixels);
      this.banDialog.__\u003C\u003Econt.row();
      this.banDialog.__\u003C\u003Econt.button("@add", (Drawable) Icon.add, (Runnable) new CustomRulesDialog.__\u003C\u003EAnon5(this)).size(300f, 64f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 184, 127, 10, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240()
    {
      this.rules.bannedBlocks.addAll(Vars.content.blocks().select((Boolf) new CustomRulesDialog.__\u003C\u003EAnon115()));
      this.rebuildBanned();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 189, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241()
    {
      this.rules.bannedBlocks.clear();
      this.rebuildBanned();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {10, 140, 114, 188, 113, 135, 127, 3, 131, 127, 0, 255, 3, 73, 144, 117, 135, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildBanned\u00244([In] Table obj0)
    {
      obj0.margin(10f);
      if (this.rules.bannedBlocks.isEmpty())
      {
        Table table = obj0;
        object obj = (object) "@empty";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table.add(text);
      }
      Seq seq = Seq.with((Iterable) this.rules.bannedBlocks);
      seq.sort();
      int num1 = !Vars.mobile || !Core.graphics.isPortrait() ? (!Vars.mobile ? 3 : 2) : 1;
      int num2 = 0;
      Iterator iterator = seq.iterator();
      while (iterator.hasNext())
      {
        Block block = (Block) iterator.next();
        obj0.table((Drawable) Tex.underline, (Cons) new CustomRulesDialog.__\u003C\u003EAnon113(this, block)).size(300f, 70f).padRight(5f);
        ++num2;
        int num3 = num2;
        int num4 = num1;
        if ((num4 != -1 ? num3 % num4 : 0) == 0)
          obj0.row();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {41, 107, 248, 81, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildBanned\u00249()
    {
      BaseDialog baseDialog = new BaseDialog("@add");
      baseDialog.__\u003C\u003Econt.pane((Cons) new CustomRulesDialog.__\u003C\u003EAnon109(this, baseDialog));
      baseDialog.addCloseButton();
      baseDialog.show();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002410([In] Table obj0) => this.main = obj0;

    [Modifiers]
    [LineNumberTable(new byte[] {75, 118, 102, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002411()
    {
      this.rules = (Rules) this.resetter.get();
      this.setup();
      this.requestKeyboard();
      this.requestScroll();
    }

    [Modifiers]
    [LineNumberTable(134)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002412([In] bool obj0) => this.rules.waves = obj0;

    [Modifiers]
    [LineNumberTable(134)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002413() => this.rules.waves;

    [Modifiers]
    [LineNumberTable(135)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002414([In] bool obj0) => this.rules.waveTimer = obj0;

    [Modifiers]
    [LineNumberTable(135)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002415() => this.rules.waveTimer;

    [Modifiers]
    [LineNumberTable(136)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002416([In] bool obj0) => this.rules.waitEnemies = obj0;

    [Modifiers]
    [LineNumberTable(136)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002417() => this.rules.waitEnemies;

    [Modifiers]
    [LineNumberTable(137)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002418([In] float obj0) => this.rules.waveSpacing = obj0 * 60f;

    [Modifiers]
    [LineNumberTable(137)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setup\u002419() => this.rules.waveSpacing / 60f;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024setup\u002420() => true;

    [Modifiers]
    [LineNumberTable(138)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002421([In] float obj0) => this.rules.dropZoneRadius = obj0 * 8f;

    [Modifiers]
    [LineNumberTable(138)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setup\u002422() => this.rules.dropZoneRadius / 8f;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024setup\u002423() => true;

    [Modifiers]
    [LineNumberTable(141)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002424([In] bool obj0) => this.rules.infiniteResources = obj0;

    [Modifiers]
    [LineNumberTable(141)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002425() => this.rules.infiniteResources;

    [Modifiers]
    [LineNumberTable(142)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002426([In] bool obj0) => this.rules.reactorExplosions = obj0;

    [Modifiers]
    [LineNumberTable(142)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002427() => this.rules.reactorExplosions;

    [Modifiers]
    [LineNumberTable(143)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002428([In] bool obj0) => this.rules.schematicsAllowed = obj0;

    [Modifiers]
    [LineNumberTable(143)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002429() => this.rules.schematicsAllowed;

    [Modifiers]
    [LineNumberTable(144)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002430([In] bool obj0) => this.rules.coreIncinerates = obj0;

    [Modifiers]
    [LineNumberTable(144)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002431() => this.rules.coreIncinerates;

    [Modifiers]
    [LineNumberTable(145)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002432([In] float obj0) => this.rules.buildCostMultiplier = obj0;

    [Modifiers]
    [LineNumberTable(145)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setup\u002433() => this.rules.buildCostMultiplier;

    [Modifiers]
    [LineNumberTable(145)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002434() => !this.rules.infiniteResources;

    [Modifiers]
    [LineNumberTable(146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002435([In] float obj0) => this.rules.buildSpeedMultiplier = obj0;

    [Modifiers]
    [LineNumberTable(146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setup\u002436() => this.rules.buildSpeedMultiplier;

    [Modifiers]
    [LineNumberTable(147)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002437([In] float obj0) => this.rules.deconstructRefundMultiplier = obj0;

    [Modifiers]
    [LineNumberTable(147)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setup\u002438() => this.rules.deconstructRefundMultiplier;

    [Modifiers]
    [LineNumberTable(147)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002439() => !this.rules.infiniteResources;

    [Modifiers]
    [LineNumberTable(148)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002440([In] float obj0) => this.rules.blockHealthMultiplier = obj0;

    [Modifiers]
    [LineNumberTable(148)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setup\u002441() => this.rules.blockHealthMultiplier;

    [Modifiers]
    [LineNumberTable(149)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002442([In] float obj0) => this.rules.blockDamageMultiplier = obj0;

    [Modifiers]
    [LineNumberTable(149)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setup\u002443() => this.rules.blockDamageMultiplier;

    [Modifiers]
    [LineNumberTable(152)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002448() => this.loadoutDialog.show(Blocks.coreShard.itemCapacity, this.rules.loadout, (Boolf) new CustomRulesDialog.__\u003C\u003EAnon105(), (Runnable) new CustomRulesDialog.__\u003C\u003EAnon106(this), (Runnable) new CustomRulesDialog.__\u003C\u003EAnon107(), (Runnable) new CustomRulesDialog.__\u003C\u003EAnon108());

    [Modifiers]
    [LineNumberTable(163)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002449([In] bool obj0) => this.rules.unitAmmo = obj0;

    [Modifiers]
    [LineNumberTable(163)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002450() => this.rules.unitAmmo;

    [Modifiers]
    [LineNumberTable(164)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002451([In] bool obj0) => this.rules.unitCapVariable = obj0;

    [Modifiers]
    [LineNumberTable(164)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002452() => this.rules.unitCapVariable;

    [Modifiers]
    [LineNumberTable(165)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002453([In] int obj0) => this.rules.unitCap = obj0;

    [Modifiers]
    [LineNumberTable(165)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int lambda\u0024setup\u002454() => this.rules.unitCap;

    [Modifiers]
    [LineNumberTable(166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002455([In] float obj0) => this.rules.unitDamageMultiplier = obj0;

    [Modifiers]
    [LineNumberTable(166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setup\u002456() => this.rules.unitDamageMultiplier;

    [Modifiers]
    [LineNumberTable(167)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002457([In] float obj0) => this.rules.unitBuildSpeedMultiplier = obj0;

    [Modifiers]
    [LineNumberTable(167)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setup\u002458() => this.rules.unitBuildSpeedMultiplier;

    [Modifiers]
    [LineNumberTable(170)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002459([In] bool obj0) => this.rules.attackMode = obj0;

    [Modifiers]
    [LineNumberTable(170)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002460() => this.rules.attackMode;

    [Modifiers]
    [LineNumberTable(171)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002461([In] bool obj0)
    {
      int num1 = obj0 ? 1 : 0;
      Rules.TeamRule teamRule1 = this.rules.teams.get(this.rules.waveTeam);
      Rules.TeamRule teamRule2 = this.rules.teams.get(this.rules.waveTeam);
      int num2 = num1;
      Rules.TeamRule teamRule3 = teamRule2;
      int num3 = num2;
      teamRule3.infiniteResources = num2 != 0;
      teamRule1.ai = num3 != 0;
    }

    [Modifiers]
    [LineNumberTable(171)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002462() => this.rules.teams.get(this.rules.waveTeam).ai;

    [Modifiers]
    [LineNumberTable(172)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002463([In] float obj0) => this.rules.enemyCoreBuildRadius = obj0 * 8f;

    [Modifiers]
    [LineNumberTable(172)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setup\u002464() => Math.min(this.rules.enemyCoreBuildRadius / 8f, 200f);

    [Modifiers]
    [LineNumberTable(175)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002465([In] bool obj0) => this.rules.damageExplosions = obj0;

    [Modifiers]
    [LineNumberTable(175)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002466() => this.rules.damageExplosions;

    [Modifiers]
    [LineNumberTable(176)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002467([In] bool obj0) => this.rules.fire = obj0;

    [Modifiers]
    [LineNumberTable(176)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002468() => this.rules.fire;

    [Modifiers]
    [LineNumberTable(177)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002469([In] bool obj0) => this.rules.lighting = obj0;

    [Modifiers]
    [LineNumberTable(177)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002470() => this.rules.lighting;

    [Modifiers]
    [LineNumberTable(178)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002471([In] bool obj0) => this.rules.enemyLights = obj0;

    [Modifiers]
    [LineNumberTable(178)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u002472() => this.rules.enemyLights;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 67, 103, 219, 122, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002474([In] Button obj0)
    {
      obj0.left();
      obj0.table((Drawable) Tex.pane, (Cons) new CustomRulesDialog.__\u003C\u003EAnon104(this)).margin(4f).size(50f).padRight(10f);
      Button button = obj0;
      object obj = (object) "@rules.ambientlight";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      button.add(text);
    }

    [Modifiers]
    [LineNumberTable(188)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002475()
    {
      ColorPicker picker = Vars.ui.picker;
      Color ambientLight1 = this.rules.ambientLight;
      Color ambientLight2 = this.rules.ambientLight;
      Objects.requireNonNull((object) ambientLight2);
      Cons consumer = (Cons) new CustomRulesDialog.__\u003C\u003EAnon103(ambientLight2);
      picker.show(ambientLight1, consumer);
    }

    [LineNumberTable(new byte[] {160, 142, 107, 139, 247, 160, 70, 134, 134, 255, 7, 82, 166, 241, 76, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void weatherDialog()
    {
      BaseDialog baseDialog = new BaseDialog("@rules.weather");
      Runnable[] runnableArray = new Runnable[1]
      {
        (Runnable) null
      };
      baseDialog.__\u003C\u003Econt.pane((Cons) new CustomRulesDialog.__\u003C\u003EAnon77(this, runnableArray)).grow();
      baseDialog.addCloseButton();
      baseDialog.__\u003C\u003Ebuttons.button("@add", (Drawable) Icon.add, (Runnable) new CustomRulesDialog.__\u003C\u003EAnon78(this, runnableArray)).width(170f);
      baseDialog.hidden((Runnable) new CustomRulesDialog.__\u003C\u003EAnon79(this));
      baseDialog.show();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024number\u002476() => true;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024number\u002477() => true;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 90, 162, 104, 127, 9, 127, 34, 115, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024number\u002480(
      [In] string obj0,
      [In] bool obj1,
      [In] Intp obj2,
      [In] Intc obj3,
      [In] int obj4,
      [In] int obj5,
      [In] Table obj6)
    {
      int num = obj1 ? 1 : 0;
      obj6.left();
      Table table = obj6;
      object obj = (object) obj0;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).left().padRight(5f);
      obj6.field(new StringBuilder().append(num == 0 ? obj2.get() : obj2.get()).append("").toString(), (Cons) new CustomRulesDialog.__\u003C\u003EAnon101(obj3)).padRight(100f).valid((TextField.TextFieldValidator) new CustomRulesDialog.__\u003C\u003EAnon102(obj4, obj5)).width(120f).left().addInputDialog();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 87, 130, 104, 127, 19, 102, 127, 43, 112, 117, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024number\u002485(
      [In] string obj0,
      [In] Boolp obj1,
      [In] bool obj2,
      [In] Floatp obj3,
      [In] Floatc obj4,
      [In] float obj5,
      [In] float obj6,
      [In] Table obj7)
    {
      int num = obj2 ? 1 : 0;
      obj7.left();
      Table table = obj7;
      object obj = (object) obj0;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).left().padRight(5f).update((Cons) new CustomRulesDialog.__\u003C\u003EAnon97(obj1));
      obj7.field(new StringBuilder().append(num == 0 ? obj3.get() : (float) ByteCodeHelper.f2i(obj3.get())).append("").toString(), (Cons) new CustomRulesDialog.__\u003C\u003EAnon98(obj4)).padRight(100f).update((Cons) new CustomRulesDialog.__\u003C\u003EAnon99(obj1)).valid((TextField.TextFieldValidator) new CustomRulesDialog.__\u003C\u003EAnon100(obj5, obj6)).width(120f).left().addInputDialog();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024check\u002486() => true;

    [Modifiers]
    [LineNumberTable(238)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024check\u002487([In] Boolp obj0, [In] CheckBox obj1) => obj1.setDisabled(!obj0.get());

    [Modifiers]
    [LineNumberTable(250)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024field\u002488([In] Floatc obj0, [In] string obj1) => obj0.get(Strings.parseFloat(obj1));

    [Modifiers]
    [LineNumberTable(new byte[] {160, 147, 240, 160, 67, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024weatherDialog\u0024104([In] Runnable[] obj0, [In] Table obj1)
    {
      obj0[0] = (Runnable) new CustomRulesDialog.__\u003C\u003EAnon82(this, obj1, obj0);
      obj0[0].run();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 220, 107, 249, 78, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024weatherDialog\u0024107([In] Runnable[] obj0)
    {
      BaseDialog baseDialog = new BaseDialog("@add");
      baseDialog.__\u003C\u003Econt.pane((Cons) new CustomRulesDialog.__\u003C\u003EAnon80(this, obj0, baseDialog));
      baseDialog.addCloseButton();
      baseDialog.show();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 241, 102, 113, 134, 155, 123, 106, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024weatherDialog\u0024108()
    {
      float num = 0.0f;
      Seq seq = this.rules.weather.copy();
      seq.shuffle();
      Iterator iterator = seq.iterator();
      while (iterator.hasNext())
      {
        Weather.WeatherEntry weatherEntry = (Weather.WeatherEntry) iterator.next();
        weatherEntry.cooldown = num + Mathf.random(weatherEntry.minFrequency, weatherEntry.maxFrequency);
        num += weatherEntry.cooldown;
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 222, 108, 98, 159, 10, 255, 10, 69, 102, 121, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024weatherDialog\u0024106([In] Runnable[] obj0, [In] BaseDialog obj1, [In] Table obj2)
    {
      obj2.background((Drawable) Tex.button);
      int num1 = 0;
      Iterator iterator = Vars.content.getBy(ContentType.__\u003C\u003Eweather).iterator();
      while (iterator.hasNext())
      {
        Weather weather = (Weather) iterator.next();
        obj2.button(weather.localizedName, Styles.cleart, (Runnable) new CustomRulesDialog.__\u003C\u003EAnon81(this, weather, obj0, obj1)).size(140f, 50f);
        ++num1;
        int num2 = num1;
        int num3 = 2;
        if ((num3 != -1 ? num2 % num3 : 0) == 0)
          obj2.row();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 227, 118, 136, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024weatherDialog\u0024105([In] Weather obj0, [In] Runnable[] obj1, [In] BaseDialog obj2)
    {
      this.rules.weather.add((object) new Weather.WeatherEntry(obj0));
      obj1[0].run();
      obj2.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 148, 102, 119, 130, 127, 9, 135, 253, 115, 159, 0, 114, 135, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024weatherDialog\u0024103([In] Table obj0, [In] Runnable[] obj1)
    {
      obj0.clearChildren();
      int num1 = Math.max(1, Core.graphics.getWidth() / 460);
      int num2 = 0;
      Iterator iterator = this.rules.weather.iterator();
      while (iterator.hasNext())
      {
        Weather.WeatherEntry weatherEntry = (Weather.WeatherEntry) iterator.next();
        obj0.top();
        obj0.table((Drawable) Tex.pane, (Cons) new CustomRulesDialog.__\u003C\u003EAnon83(this, weatherEntry, obj1)).width(410f).pad(3f).top().left().fillY();
        ++num2;
        int num3 = num2;
        int num4 = num1;
        if ((num4 != -1 ? num3 % num4 : 0) == 0)
          obj0.row();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 156, 172, 248, 79, 134, 167, 242, 90, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024weatherDialog\u0024102(
      [In] Weather.WeatherEntry obj0,
      [In] Runnable[] obj1,
      [In] Table obj2)
    {
      obj2.margin(0.0f);
      obj2.table((Drawable) Tex.whiteui, (Cons) new CustomRulesDialog.__\u003C\u003EAnon84(this, obj0, obj1)).growX();
      obj2.row();
      obj2.table((Cons) new CustomRulesDialog.__\u003C\u003EAnon85(this, obj0)).grow().left().pad(6f).top();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 160, 139, 108, 159, 18, 140, 102, 145, 218})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024weatherDialog\u002490(
      [In] Weather.WeatherEntry obj0,
      [In] Runnable[] obj1,
      [In] Table obj2)
    {
      obj2.setColor(Pal.gray);
      obj2.top().left();
      Table table = obj2;
      object localizedName = (object) obj0.weather.localizedName;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) localizedName;
      CharSequence text = charSequence;
      table.add(text).left().padLeft(6f);
      obj2.add().growX();
      ImageButton.ImageButtonStyle geni = Styles.geni;
      obj2.defaults().size(42f);
      obj2.button((Drawable) Icon.cancel, geni, (Runnable) new CustomRulesDialog.__\u003C\u003EAnon96(this, obj0, obj1));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 180, 108, 140, 150, 124, 127, 17, 124, 127, 17, 156, 135, 124, 127, 17, 124, 127, 17, 156, 135, 223, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024weatherDialog\u0024101([In] Weather.WeatherEntry obj0, [In] Table obj1)
    {
      obj1.marginLeft(4f);
      obj1.left().top();
      obj1.defaults().padRight(4f).left();
      Table table1 = obj1;
      object obj2 = (object) "@rules.weather.duration";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text1 = charSequence;
      table1.add(text1);
      this.field(obj1, obj0.minDuration / 3600f, (Floatc) new CustomRulesDialog.__\u003C\u003EAnon86(obj0)).disabled((Boolf) new CustomRulesDialog.__\u003C\u003EAnon87(obj0));
      Table table2 = obj1;
      object obj3 = (object) "@waves.to";
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence text2 = charSequence;
      table2.add(text2);
      this.field(obj1, obj0.maxDuration / 3600f, (Floatc) new CustomRulesDialog.__\u003C\u003EAnon88(obj0)).disabled((Boolf) new CustomRulesDialog.__\u003C\u003EAnon89(obj0));
      Table table3 = obj1;
      object obj4 = (object) "@unit.minutes";
      charSequence.__\u003Cref\u003E = (__Null) obj4;
      CharSequence text3 = charSequence;
      table3.add(text3);
      obj1.row();
      Table table4 = obj1;
      object obj5 = (object) "@rules.weather.frequency";
      charSequence.__\u003Cref\u003E = (__Null) obj5;
      CharSequence text4 = charSequence;
      table4.add(text4);
      this.field(obj1, obj0.minFrequency / 3600f, (Floatc) new CustomRulesDialog.__\u003C\u003EAnon90(obj0)).disabled((Boolf) new CustomRulesDialog.__\u003C\u003EAnon91(obj0));
      Table table5 = obj1;
      object obj6 = (object) "@waves.to";
      charSequence.__\u003Cref\u003E = (__Null) obj6;
      CharSequence text5 = charSequence;
      table5.add(text5);
      this.field(obj1, obj0.maxFrequency / 3600f, (Floatc) new CustomRulesDialog.__\u003C\u003EAnon92(obj0)).disabled((Boolf) new CustomRulesDialog.__\u003C\u003EAnon93(obj0));
      Table table6 = obj1;
      object obj7 = (object) "@unit.minutes";
      charSequence.__\u003Cref\u003E = (__Null) obj7;
      CharSequence text6 = charSequence;
      table6.add(text6);
      obj1.row();
      obj1.check("@rules.weather.always", (Boolc) new CustomRulesDialog.__\u003C\u003EAnon94(obj0)).@checked((Boolf) new CustomRulesDialog.__\u003C\u003EAnon95(obj0)).padBottom(4f);
    }

    [Modifiers]
    [LineNumberTable(300)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024weatherDialog\u002491([In] Weather.WeatherEntry obj0, [In] float obj1) => obj0.minDuration = obj1 * 3600f;

    [Modifiers]
    [LineNumberTable(300)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024weatherDialog\u002492([In] Weather.WeatherEntry obj0, [In] TextField obj1) => obj0.always;

    [Modifiers]
    [LineNumberTable(302)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024weatherDialog\u002493([In] Weather.WeatherEntry obj0, [In] float obj1) => obj0.maxDuration = obj1 * 3600f;

    [Modifiers]
    [LineNumberTable(302)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024weatherDialog\u002494([In] Weather.WeatherEntry obj0, [In] TextField obj1) => obj0.always;

    [Modifiers]
    [LineNumberTable(308)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024weatherDialog\u002495([In] Weather.WeatherEntry obj0, [In] float obj1) => obj0.minFrequency = obj1 * 3600f;

    [Modifiers]
    [LineNumberTable(308)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024weatherDialog\u002496([In] Weather.WeatherEntry obj0, [In] TextField obj1) => obj0.always;

    [Modifiers]
    [LineNumberTable(310)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024weatherDialog\u002497([In] Weather.WeatherEntry obj0, [In] float obj1) => obj0.maxFrequency = obj1 * 3600f;

    [Modifiers]
    [LineNumberTable(310)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024weatherDialog\u002498([In] Weather.WeatherEntry obj0, [In] TextField obj1) => obj0.always;

    [Modifiers]
    [LineNumberTable(315)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024weatherDialog\u002499([In] Weather.WeatherEntry obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      obj0.always = num != 0;
    }

    [Modifiers]
    [LineNumberTable(315)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024weatherDialog\u0024100([In] Weather.WeatherEntry obj0, [In] CheckBox obj1) => obj0.always;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 171, 114, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024weatherDialog\u002489([In] Weather.WeatherEntry obj0, [In] Runnable[] obj1)
    {
      this.rules.weather.remove((object) obj0);
      obj1[0].run();
    }

    [Modifiers]
    [LineNumberTable(224)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024number\u002481([In] Boolp obj0, [In] Label obj1) => obj1.setColor(!obj0.get() ? Color.__\u003C\u003Egray : Color.__\u003C\u003Ewhite);

    [Modifiers]
    [LineNumberTable(225)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024number\u002482([In] Floatc obj0, [In] string obj1) => obj0.get(Strings.parseFloat(obj1));

    [Modifiers]
    [LineNumberTable(227)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024number\u002483([In] Boolp obj0, [In] TextField obj1) => obj1.setDisabled(!obj0.get());

    [Modifiers]
    [LineNumberTable(228)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024number\u002484([In] float obj0, [In] float obj1, [In] string obj2) => Strings.canParsePositiveFloat(obj2) && (double) Strings.parseFloat(obj2) >= (double) obj0 && (double) Strings.parseFloat(obj2) <= (double) obj1;

    [Modifiers]
    [LineNumberTable(213)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024number\u002478([In] Intc obj0, [In] string obj1) => obj0.get(Strings.parseInt(obj1));

    [Modifiers]
    [LineNumberTable(215)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024number\u002479([In] int obj0, [In] int obj1, [In] string obj2) => Strings.parseInt(obj2) >= obj0 && Strings.parseInt(obj2) <= obj1;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 69, 159, 8, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002473([In] Table obj0) => obj0.stack((Element) new Image((Drawable) Tex.alphaBg), (Element) new CustomRulesDialog.\u0031(this, (Drawable) Tex.whiteui)).grow();

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024setup\u002444([In] Item obj0) => true;

    [Modifiers]
    [LineNumberTable(154)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002445()
    {
      Seq seq = this.rules.loadout.clear();
      ItemStack.__\u003Cclinit\u003E();
      ItemStack itemStack = new ItemStack(Items.copper, 100);
      seq.add((object) itemStack);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002446()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002447()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {43, 113, 107, 255, 9, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildBanned\u00248([In] BaseDialog obj0, [In] Table obj1)
    {
      obj1.left().margin(14f);
      int[] numArray = new int[1]{ 0 };
      Vars.content.blocks().each((Boolf) new CustomRulesDialog.__\u003C\u003EAnon110(this), (Cons) new CustomRulesDialog.__\u003C\u003EAnon111(this, obj1, obj0, numArray));
    }

    [Modifiers]
    [LineNumberTable(95)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024rebuildBanned\u00245([In] Block obj0) => !this.rules.bannedBlocks.contains((object) obj0) && obj0.canBeBuilt();

    [Modifiers]
    [LineNumberTable(new byte[] {46, 121, 223, 16, 159, 0, 127, 1, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildBanned\u00247(
      [In] Table obj0,
      [In] BaseDialog obj1,
      [In] int[] obj2,
      [In] Block obj3)
    {
      int num1 = !Vars.mobile || !Core.graphics.isPortrait() ? 12 : 4;
      ((ImageButton) obj0.button((Drawable) new TextureRegionDrawable(obj3.icon(Cicon.__\u003C\u003Emedium)), Styles.cleari, (Runnable) new CustomRulesDialog.__\u003C\u003EAnon112(this, obj3, obj1)).size(60f).get()).resizeImage((float) Cicon.__\u003C\u003Emedium.__\u003C\u003Esize);
      int[] numArray1 = obj2;
      int index1 = 0;
      int[] numArray2 = numArray1;
      int[] numArray3 = numArray2;
      int num2 = index1;
      int num3 = numArray2[index1] + 1;
      int index2 = num2;
      int[] numArray4 = numArray3;
      int num4 = num3;
      numArray4[index2] = num3;
      int num5 = num1;
      if ((num5 != -1 ? num4 % num5 : 0) != 0)
        return;
      obj0.row();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {48, 114, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildBanned\u00246([In] Block obj0, [In] BaseDialog obj1)
    {
      this.rules.bannedBlocks.add((object) obj0);
      this.rebuildBanned();
      obj1.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {24, 113, 127, 13, 159, 33, 191, 2, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildBanned\u00243([In] Block obj0, [In] Table obj1)
    {
      obj1.left().margin(4f);
      obj1.image(obj0.icon(Cicon.__\u003C\u003Emedium)).size((float) Cicon.__\u003C\u003Emedium.__\u003C\u003Esize).padRight(3f);
      Table table = obj1;
      object localizedName = (object) obj0.localizedName;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) localizedName;
      CharSequence text = charSequence;
      table.add(text).color(Color.__\u003C\u003ElightGray).padLeft(3f).growX().left().wrap();
      obj1.button((Drawable) Icon.cancel, Styles.clearPartiali, (Runnable) new CustomRulesDialog.__\u003C\u003EAnon114(this, obj0)).size(70f).pad(-4f).padLeft(0.0f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {29, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildBanned\u00242([In] Block obj0)
    {
      this.rules.bannedBlocks.remove((object) obj0);
      this.rebuildBanned();
    }

    [LineNumberTable(new byte[] {160, 92, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void number([In] string obj0, [In] Floatc obj1, [In] Floatp obj2, [In] Boolp obj3) => this.number(obj0, false, obj1, obj2, obj3, 0.0f, float.MaxValue);

    [HideFromJava]
    static CustomRulesDialog() => BaseDialog.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "setup", "()V")]
    [SpecialName]
    internal new class \u0031 : Image
    {
      [Modifiers]
      internal CustomRulesDialog this\u00240;

      [Modifiers]
      [LineNumberTable(184)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00240() => this.setColor(this.this\u00240.rules.ambientLight);

      [LineNumberTable(new byte[] {160, 69, 112, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] CustomRulesDialog obj0, [In] Drawable obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        CustomRulesDialog.\u0031 obj = this;
        this.update((Runnable) new CustomRulesDialog.\u0031.__\u003C\u003EAnon0(this));
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly CustomRulesDialog.\u0031 arg\u00241;

        internal __\u003C\u003EAnon0([In] CustomRulesDialog.\u0031 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024new\u00240();
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.rebuildBanned();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon2([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon3([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon4([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuildBanned\u00244((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon5([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024rebuildBanned\u00249();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon6([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002410((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon7([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setup\u002411();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Boolc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon8([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => this.arg\u00241.lambda\u0024setup\u002412(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon9([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002413() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Boolc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon10([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => this.arg\u00241.lambda\u0024setup\u002414(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon11([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002415() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Boolc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon12([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => this.arg\u00241.lambda\u0024setup\u002416(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon13([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002417() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Floatc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon14([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024setup\u002418(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Floatp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon15([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024setup\u002419();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Boolp
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public bool get() => (CustomRulesDialog.lambda\u0024setup\u002420() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Floatc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon17([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024setup\u002421(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Floatp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon18([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024setup\u002422();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Boolp
    {
      internal __\u003C\u003EAnon19()
      {
      }

      public bool get() => (CustomRulesDialog.lambda\u0024setup\u002423() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Boolc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon20([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => this.arg\u00241.lambda\u0024setup\u002424(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon21([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002425() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Boolc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon22([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => this.arg\u00241.lambda\u0024setup\u002426(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon23([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002427() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Boolc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon24([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => this.arg\u00241.lambda\u0024setup\u002428(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon25([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002429() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Boolc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon26([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => this.arg\u00241.lambda\u0024setup\u002430(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon27([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002431() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Floatc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon28([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024setup\u002432(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Floatp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon29([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024setup\u002433();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon30([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002434() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Floatc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon31([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024setup\u002435(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Floatp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon32([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024setup\u002436();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Floatc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon33([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024setup\u002437(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Floatp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon34([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024setup\u002438();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon35([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002439() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : Floatc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon36([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024setup\u002440(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon37 : Floatp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon37([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024setup\u002441();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon38 : Floatc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon38([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024setup\u002442(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon39 : Floatp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon39([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024setup\u002443();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon40 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon40([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setup\u002448();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon41 : Runnable
    {
      private readonly BaseDialog arg\u00241;

      internal __\u003C\u003EAnon41([In] BaseDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon42 : Boolc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon42([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => this.arg\u00241.lambda\u0024setup\u002449(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon43 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon43([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002450() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon44 : Boolc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon44([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => this.arg\u00241.lambda\u0024setup\u002451(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon45 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon45([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002452() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon46 : Intc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon46([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0) => this.arg\u00241.lambda\u0024setup\u002453(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon47 : Intp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon47([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public int get() => this.arg\u00241.lambda\u0024setup\u002454();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon48 : Floatc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon48([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024setup\u002455(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon49 : Floatp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon49([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024setup\u002456();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon50 : Floatc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon50([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024setup\u002457(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon51 : Floatp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon51([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024setup\u002458();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon52 : Boolc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon52([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => this.arg\u00241.lambda\u0024setup\u002459(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon53 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon53([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002460() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon54 : Boolc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon54([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => this.arg\u00241.lambda\u0024setup\u002461(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon55 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon55([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002462() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon56 : Floatc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon56([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024setup\u002463(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon57 : Floatp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon57([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024setup\u002464();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon58 : Boolc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon58([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => this.arg\u00241.lambda\u0024setup\u002465(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon59 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon59([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002466() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon60 : Boolc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon60([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => this.arg\u00241.lambda\u0024setup\u002467(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon61 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon61([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002468() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon62 : Boolc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon62([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => this.arg\u00241.lambda\u0024setup\u002469(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon63 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon63([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002470() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon64 : Boolc
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon64([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => this.arg\u00241.lambda\u0024setup\u002471(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon65 : Boolp
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon65([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setup\u002472() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon66 : Cons
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon66([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002474((Button) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon67 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon67([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setup\u002475();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon68 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon68([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.weatherDialog();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon69 : Boolp
    {
      internal __\u003C\u003EAnon69()
      {
      }

      public bool get() => (CustomRulesDialog.lambda\u0024number\u002476() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon70 : Boolp
    {
      internal __\u003C\u003EAnon70()
      {
      }

      public bool get() => (CustomRulesDialog.lambda\u0024number\u002477() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon71 : Cons
    {
      private readonly string arg\u00241;
      private readonly bool arg\u00242;
      private readonly Intp arg\u00243;
      private readonly Intc arg\u00244;
      private readonly int arg\u00245;
      private readonly int arg\u00246;

      internal __\u003C\u003EAnon71(
        [In] string obj0,
        [In] bool obj1,
        [In] Intp obj2,
        [In] Intc obj3,
        [In] int obj4,
        [In] int obj5)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
      }

      public void get([In] object obj0) => CustomRulesDialog.lambda\u0024number\u002480(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon72 : Cons
    {
      private readonly string arg\u00241;
      private readonly Boolp arg\u00242;
      private readonly bool arg\u00243;
      private readonly Floatp arg\u00244;
      private readonly Floatc arg\u00245;
      private readonly float arg\u00246;
      private readonly float arg\u00247;

      internal __\u003C\u003EAnon72(
        [In] string obj0,
        [In] Boolp obj1,
        [In] bool obj2,
        [In] Floatp obj3,
        [In] Floatc obj4,
        [In] float obj5,
        [In] float obj6)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
        this.arg\u00247 = obj6;
      }

      public void get([In] object obj0) => CustomRulesDialog.lambda\u0024number\u002485(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon73 : Boolp
    {
      internal __\u003C\u003EAnon73()
      {
      }

      public bool get() => (CustomRulesDialog.lambda\u0024check\u002486() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon74 : Cons
    {
      private readonly Boolp arg\u00241;

      internal __\u003C\u003EAnon74([In] Boolp obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => CustomRulesDialog.lambda\u0024check\u002487(this.arg\u00241, (CheckBox) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon75 : Cons
    {
      private readonly Floatc arg\u00241;

      internal __\u003C\u003EAnon75([In] Floatc obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => CustomRulesDialog.lambda\u0024field\u002488(this.arg\u00241, (string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon76 : TextField.TextFieldValidator
    {
      internal __\u003C\u003EAnon76()
      {
      }

      public bool valid([In] string obj0) => (Strings.canParsePositiveFloat(obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon77 : Cons
    {
      private readonly CustomRulesDialog arg\u00241;
      private readonly Runnable[] arg\u00242;

      internal __\u003C\u003EAnon77([In] CustomRulesDialog obj0, [In] Runnable[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024weatherDialog\u0024104(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon78 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;
      private readonly Runnable[] arg\u00242;

      internal __\u003C\u003EAnon78([In] CustomRulesDialog obj0, [In] Runnable[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024weatherDialog\u0024107(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon79 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon79([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024weatherDialog\u0024108();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon80 : Cons
    {
      private readonly CustomRulesDialog arg\u00241;
      private readonly Runnable[] arg\u00242;
      private readonly BaseDialog arg\u00243;

      internal __\u003C\u003EAnon80([In] CustomRulesDialog obj0, [In] Runnable[] obj1, [In] BaseDialog obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024weatherDialog\u0024106(this.arg\u00242, this.arg\u00243, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon81 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;
      private readonly Weather arg\u00242;
      private readonly Runnable[] arg\u00243;
      private readonly BaseDialog arg\u00244;

      internal __\u003C\u003EAnon81(
        [In] CustomRulesDialog obj0,
        [In] Weather obj1,
        [In] Runnable[] obj2,
        [In] BaseDialog obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void run() => this.arg\u00241.lambda\u0024weatherDialog\u0024105(this.arg\u00242, this.arg\u00243, this.arg\u00244);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon82 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;
      private readonly Table arg\u00242;
      private readonly Runnable[] arg\u00243;

      internal __\u003C\u003EAnon82([In] CustomRulesDialog obj0, [In] Table obj1, [In] Runnable[] obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024weatherDialog\u0024103(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon83 : Cons
    {
      private readonly CustomRulesDialog arg\u00241;
      private readonly Weather.WeatherEntry arg\u00242;
      private readonly Runnable[] arg\u00243;

      internal __\u003C\u003EAnon83(
        [In] CustomRulesDialog obj0,
        [In] Weather.WeatherEntry obj1,
        [In] Runnable[] obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024weatherDialog\u0024102(this.arg\u00242, this.arg\u00243, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon84 : Cons
    {
      private readonly CustomRulesDialog arg\u00241;
      private readonly Weather.WeatherEntry arg\u00242;
      private readonly Runnable[] arg\u00243;

      internal __\u003C\u003EAnon84(
        [In] CustomRulesDialog obj0,
        [In] Weather.WeatherEntry obj1,
        [In] Runnable[] obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024weatherDialog\u002490(this.arg\u00242, this.arg\u00243, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon85 : Cons
    {
      private readonly CustomRulesDialog arg\u00241;
      private readonly Weather.WeatherEntry arg\u00242;

      internal __\u003C\u003EAnon85([In] CustomRulesDialog obj0, [In] Weather.WeatherEntry obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024weatherDialog\u0024101(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon86 : Floatc
    {
      private readonly Weather.WeatherEntry arg\u00241;

      internal __\u003C\u003EAnon86([In] Weather.WeatherEntry obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => CustomRulesDialog.lambda\u0024weatherDialog\u002491(this.arg\u00241, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon87 : Boolf
    {
      private readonly Weather.WeatherEntry arg\u00241;

      internal __\u003C\u003EAnon87([In] Weather.WeatherEntry obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (CustomRulesDialog.lambda\u0024weatherDialog\u002492(this.arg\u00241, (TextField) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon88 : Floatc
    {
      private readonly Weather.WeatherEntry arg\u00241;

      internal __\u003C\u003EAnon88([In] Weather.WeatherEntry obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => CustomRulesDialog.lambda\u0024weatherDialog\u002493(this.arg\u00241, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon89 : Boolf
    {
      private readonly Weather.WeatherEntry arg\u00241;

      internal __\u003C\u003EAnon89([In] Weather.WeatherEntry obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (CustomRulesDialog.lambda\u0024weatherDialog\u002494(this.arg\u00241, (TextField) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon90 : Floatc
    {
      private readonly Weather.WeatherEntry arg\u00241;

      internal __\u003C\u003EAnon90([In] Weather.WeatherEntry obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => CustomRulesDialog.lambda\u0024weatherDialog\u002495(this.arg\u00241, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon91 : Boolf
    {
      private readonly Weather.WeatherEntry arg\u00241;

      internal __\u003C\u003EAnon91([In] Weather.WeatherEntry obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (CustomRulesDialog.lambda\u0024weatherDialog\u002496(this.arg\u00241, (TextField) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon92 : Floatc
    {
      private readonly Weather.WeatherEntry arg\u00241;

      internal __\u003C\u003EAnon92([In] Weather.WeatherEntry obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => CustomRulesDialog.lambda\u0024weatherDialog\u002497(this.arg\u00241, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon93 : Boolf
    {
      private readonly Weather.WeatherEntry arg\u00241;

      internal __\u003C\u003EAnon93([In] Weather.WeatherEntry obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (CustomRulesDialog.lambda\u0024weatherDialog\u002498(this.arg\u00241, (TextField) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon94 : Boolc
    {
      private readonly Weather.WeatherEntry arg\u00241;

      internal __\u003C\u003EAnon94([In] Weather.WeatherEntry obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => CustomRulesDialog.lambda\u0024weatherDialog\u002499(this.arg\u00241, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon95 : Boolf
    {
      private readonly Weather.WeatherEntry arg\u00241;

      internal __\u003C\u003EAnon95([In] Weather.WeatherEntry obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (CustomRulesDialog.lambda\u0024weatherDialog\u0024100(this.arg\u00241, (CheckBox) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon96 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;
      private readonly Weather.WeatherEntry arg\u00242;
      private readonly Runnable[] arg\u00243;

      internal __\u003C\u003EAnon96(
        [In] CustomRulesDialog obj0,
        [In] Weather.WeatherEntry obj1,
        [In] Runnable[] obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024weatherDialog\u002489(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon97 : Cons
    {
      private readonly Boolp arg\u00241;

      internal __\u003C\u003EAnon97([In] Boolp obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => CustomRulesDialog.lambda\u0024number\u002481(this.arg\u00241, (Label) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon98 : Cons
    {
      private readonly Floatc arg\u00241;

      internal __\u003C\u003EAnon98([In] Floatc obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => CustomRulesDialog.lambda\u0024number\u002482(this.arg\u00241, (string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon99 : Cons
    {
      private readonly Boolp arg\u00241;

      internal __\u003C\u003EAnon99([In] Boolp obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => CustomRulesDialog.lambda\u0024number\u002483(this.arg\u00241, (TextField) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon100 : TextField.TextFieldValidator
    {
      private readonly float arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon100([In] float obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool valid([In] string obj0) => (CustomRulesDialog.lambda\u0024number\u002484(this.arg\u00241, this.arg\u00242, obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon101 : Cons
    {
      private readonly Intc arg\u00241;

      internal __\u003C\u003EAnon101([In] Intc obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => CustomRulesDialog.lambda\u0024number\u002478(this.arg\u00241, (string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon102 : TextField.TextFieldValidator
    {
      private readonly int arg\u00241;
      private readonly int arg\u00242;

      internal __\u003C\u003EAnon102([In] int obj0, [In] int obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool valid([In] string obj0) => (CustomRulesDialog.lambda\u0024number\u002479(this.arg\u00241, this.arg\u00242, obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon103 : Cons
    {
      private readonly Color arg\u00241;

      internal __\u003C\u003EAnon103([In] Color obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.set((Color) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon104 : Cons
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon104([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002473((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon105 : Boolf
    {
      internal __\u003C\u003EAnon105()
      {
      }

      public bool get([In] object obj0) => (CustomRulesDialog.lambda\u0024setup\u002444((Item) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon106 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon106([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setup\u002445();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon107 : Runnable
    {
      internal __\u003C\u003EAnon107()
      {
      }

      public void run() => CustomRulesDialog.lambda\u0024setup\u002446();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon108 : Runnable
    {
      internal __\u003C\u003EAnon108()
      {
      }

      public void run() => CustomRulesDialog.lambda\u0024setup\u002447();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon109 : Cons
    {
      private readonly CustomRulesDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon109([In] CustomRulesDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuildBanned\u00248(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon110 : Boolf
    {
      private readonly CustomRulesDialog arg\u00241;

      internal __\u003C\u003EAnon110([In] CustomRulesDialog obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024rebuildBanned\u00245((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon111 : Cons
    {
      private readonly CustomRulesDialog arg\u00241;
      private readonly Table arg\u00242;
      private readonly BaseDialog arg\u00243;
      private readonly int[] arg\u00244;

      internal __\u003C\u003EAnon111(
        [In] CustomRulesDialog obj0,
        [In] Table obj1,
        [In] BaseDialog obj2,
        [In] int[] obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuildBanned\u00247(this.arg\u00242, this.arg\u00243, this.arg\u00244, (Block) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon112 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;
      private readonly Block arg\u00242;
      private readonly BaseDialog arg\u00243;

      internal __\u003C\u003EAnon112([In] CustomRulesDialog obj0, [In] Block obj1, [In] BaseDialog obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024rebuildBanned\u00246(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon113 : Cons
    {
      private readonly CustomRulesDialog arg\u00241;
      private readonly Block arg\u00242;

      internal __\u003C\u003EAnon113([In] CustomRulesDialog obj0, [In] Block obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuildBanned\u00243(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon114 : Runnable
    {
      private readonly CustomRulesDialog arg\u00241;
      private readonly Block arg\u00242;

      internal __\u003C\u003EAnon114([In] CustomRulesDialog obj0, [In] Block obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024rebuildBanned\u00242(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon115 : Boolf
    {
      internal __\u003C\u003EAnon115()
      {
      }

      public bool get([In] object obj0) => (((Block) obj0).canBeBuilt() ? 1 : 0) != 0;
    }
  }
}
