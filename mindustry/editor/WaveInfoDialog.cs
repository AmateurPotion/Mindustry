// Decompiled with JetBrains decompiler
// Type: mindustry.editor.WaveInfoDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.math;
using arc.scene;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.io;
using mindustry.type;
using mindustry.ui;
using mindustry.ui.dialogs;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.editor
{
  public class WaveInfoDialog : BaseDialog
  {
    private int displayed;
    [Signature("Larc/struct/Seq<Lmindustry/game/SpawnGroup;>;")]
    internal Seq groups;
    private Table table;
    private int start;
    private UnitType lastType;
    private float updateTimer;
    private float updatePeriod;
    private WaveGraph graph;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 176, 237, 54, 104, 171, 103, 107, 107, 235, 69, 113, 145, 134, 113, 134, 255, 6, 92, 134, 150, 255, 12, 69, 255, 12, 70, 255, 12, 69, 255, 12, 70, 103, 223, 6, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WaveInfoDialog(MapEditor editor)
      : base("@waves.title")
    {
      WaveInfoDialog waveInfoDialog = this;
      this.displayed = 20;
      this.groups = new Seq();
      this.start = 0;
      this.lastType = UnitTypes.dagger;
      this.updatePeriod = 1f;
      this.graph = new WaveGraph();
      this.shown((Runnable) new WaveInfoDialog.__\u003C\u003EAnon0(this));
      this.hidden((Runnable) new WaveInfoDialog.__\u003C\u003EAnon1(this));
      this.addCloseListener();
      this.onResize((Runnable) new WaveInfoDialog.__\u003C\u003EAnon0(this));
      this.addCloseButton();
      this.__\u003C\u003Ebuttons.button("@waves.edit", (Runnable) new WaveInfoDialog.__\u003C\u003EAnon2(this)).size(270f, 64f);
      this.__\u003C\u003Ebuttons.defaults().width(60f);
      this.__\u003C\u003Ebuttons.button("<", (Runnable) new WaveInfoDialog.__\u003C\u003EAnon3()).update((Cons) new WaveInfoDialog.__\u003C\u003EAnon4(this));
      this.__\u003C\u003Ebuttons.button(">", (Runnable) new WaveInfoDialog.__\u003C\u003EAnon5()).update((Cons) new WaveInfoDialog.__\u003C\u003EAnon6(this));
      this.__\u003C\u003Ebuttons.button("-", (Runnable) new WaveInfoDialog.__\u003C\u003EAnon7()).update((Cons) new WaveInfoDialog.__\u003C\u003EAnon8(this));
      this.__\u003C\u003Ebuttons.button("+", (Runnable) new WaveInfoDialog.__\u003C\u003EAnon9()).update((Cons) new WaveInfoDialog.__\u003C\u003EAnon10(this));
      if (!Vars.experimental)
        return;
      this.__\u003C\u003Ebuttons.button("Random", (Drawable) Icon.refresh, (Runnable) new WaveInfoDialog.__\u003C\u003EAnon11(this)).width(200f);
    }

    [LineNumberTable(new byte[] {160, 167, 113, 113, 120, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void updateWaves()
    {
      this.graph.groups = this.groups;
      this.graph.from = this.start;
      this.graph.to = this.start + this.displayed;
      this.graph.rebuild();
    }

    [LineNumberTable(new byte[] {102, 107, 108, 145, 136, 127, 1, 255, 2, 160, 87, 144, 108, 132, 191, 2, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void buildGroups()
    {
      this.table.clear();
      this.table.top();
      this.table.margin(10f);
      if (this.groups != null)
      {
        Iterator iterator = this.groups.iterator();
        while (iterator.hasNext())
        {
          SpawnGroup spawnGroup = (SpawnGroup) iterator.next();
          this.table.table((Drawable) Tex.button, (Cons) new WaveInfoDialog.__\u003C\u003EAnon13(this, spawnGroup)).width(340f).pad(8f);
          this.table.row();
        }
      }
      else
      {
        Table table = this.table;
        object obj = (object) "@editor.default";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table.add(text);
      }
      this.updateWaves();
    }

    [LineNumberTable(new byte[] {160, 144, 107, 103, 249, 81, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void showUpdate([In] SpawnGroup obj0)
    {
      BaseDialog baseDialog = new BaseDialog("");
      baseDialog.setFillParent(true);
      baseDialog.__\u003C\u003Econt.pane((Cons) new WaveInfoDialog.__\u003C\u003EAnon14(this, obj0, baseDialog));
      baseDialog.show();
    }

    [LineNumberTable(new byte[] {58, 115, 110, 110, 112, 107, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void view([In] int obj0)
    {
      this.updateTimer += Time.delta;
      if ((double) this.updateTimer < (double) this.updatePeriod)
        return;
      this.displayed += obj0;
      if (this.displayed < 5)
        this.displayed = 5;
      this.updateTimer = 0.0f;
      this.updateWaves();
    }

    [LineNumberTable(new byte[] {68, 115, 110, 110, 112, 107, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void shift([In] int obj0)
    {
      this.updateTimer += Time.delta;
      if ((double) this.updateTimer < (double) this.updatePeriod)
        return;
      this.start += obj0;
      if (this.start < 0)
        this.start = 0;
      this.updateTimer = 0.0f;
      this.updateWaves();
    }

    [LineNumberTable(new byte[] {78, 159, 34, 107, 255, 50, 77, 139, 159, 2, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setup()
    {
      this.groups = (Seq) JsonIO.copy(!Vars.state.rules.spawns.isEmpty() ? (object) Vars.state.rules.spawns : (object) Vars.waves.get());
      this.__\u003C\u003Econt.clear();
      Table cont1 = this.__\u003C\u003Econt;
      Element[] elementArray = new Element[2];
      Table.__\u003Cclinit\u003E();
      elementArray[0] = (Element) new Table((Drawable) Tex.clear, (Cons) new WaveInfoDialog.__\u003C\u003EAnon12(this));
      object obj = (object) "@waves.none";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      elementArray[1] = (Element) new WaveInfoDialog.\u0031(this, charSequence);
      cont1.stack(elementArray).width(390f).growY();
      Table cont2 = this.__\u003C\u003Econt;
      WaveInfoDialog waveInfoDialog = this;
      WaveGraph waveGraph1 = new WaveGraph();
      WaveGraph waveGraph2 = waveGraph1;
      this.graph = waveGraph1;
      cont2.add((Element) waveGraph2).grow();
      this.buildGroups();
    }

    [Modifiers]
    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240() => Vars.state.rules.spawns = this.groups;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 187, 107, 102, 103, 123, 223, 8, 102, 108, 255, 7, 73, 102, 108, 253, 69, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00247()
    {
      BaseDialog baseDialog = new BaseDialog("@waves.edit");
      baseDialog.addCloseButton();
      baseDialog.setFillParent(false);
      baseDialog.__\u003C\u003Econt.defaults().size(210f, 64f);
      baseDialog.__\u003C\u003Econt.button("@waves.copy", (Runnable) new WaveInfoDialog.__\u003C\u003EAnon35(this, baseDialog)).disabled((Boolf) new WaveInfoDialog.__\u003C\u003EAnon36(this));
      baseDialog.__\u003C\u003Econt.row();
      baseDialog.__\u003C\u003Econt.button("@waves.load", (Runnable) new WaveInfoDialog.__\u003C\u003EAnon37(this, baseDialog)).disabled((Boolf) new WaveInfoDialog.__\u003C\u003EAnon38());
      baseDialog.__\u003C\u003Econt.row();
      baseDialog.__\u003C\u003Econt.button("@settings.reset", (Runnable) new WaveInfoDialog.__\u003C\u003EAnon39(this, baseDialog));
      baseDialog.show();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00248()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {27, 109, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00249([In] TextButton obj0)
    {
      if (!obj0.getClickListener().isPressed())
        return;
      this.shift(-1);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u002410()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {32, 109, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002411([In] TextButton obj0)
    {
      if (!obj0.getClickListener().isPressed())
        return;
      this.shift(1);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u002412()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {38, 109, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002413([In] TextButton obj0)
    {
      if (!obj0.getClickListener().isPressed())
        return;
      this.view(-1);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u002414()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {43, 109, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002415([In] TextButton obj0)
    {
      if (!obj0.getClickListener().isPressed())
        return;
      this.view(1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {50, 108, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002416()
    {
      this.groups.clear();
      this.groups = Waves.generate(0.1f);
      this.updateWaves();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {82, 127, 23, 103, 214, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002419([In] Table obj0)
    {
      ((ScrollPane) obj0.pane((Cons) new WaveInfoDialog.__\u003C\u003EAnon33(this)).growX().growY().padRight(8f).get()).setScrollingDisabled(true, false);
      obj0.row();
      obj0.button("@add", (Runnable) new WaveInfoDialog.__\u003C\u003EAnon34(this)).growX().height(70f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {110, 127, 16, 255, 5, 77, 154, 103, 243, 82, 103, 243, 75, 103, 243, 81, 103, 243, 82, 103, 127, 28})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildGroups\u002436([In] SpawnGroup obj0, [In] Table obj1)
    {
      obj1.margin(0.0f).defaults().pad(3f).padLeft(5f).growX().left();
      obj1.button((Cons) new WaveInfoDialog.__\u003C\u003EAnon17(this, obj0, obj1), (Runnable) new WaveInfoDialog.__\u003C\u003EAnon18(this, obj0)).height(46f).pad(-6f).padBottom(0.0f);
      obj1.row();
      obj1.table((Cons) new WaveInfoDialog.__\u003C\u003EAnon19(this, obj0));
      obj1.row();
      obj1.table((Cons) new WaveInfoDialog.__\u003C\u003EAnon20(this, obj0));
      obj1.row();
      obj1.table((Cons) new WaveInfoDialog.__\u003C\u003EAnon21(this, obj0));
      obj1.row();
      obj1.table((Cons) new WaveInfoDialog.__\u003C\u003EAnon22(this, obj0));
      obj1.row();
      obj1.check("@waves.guardian", (Boolc) new WaveInfoDialog.__\u003C\u003EAnon23(obj0)).padTop(4f).update((Cons) new WaveInfoDialog.__\u003C\u003EAnon24(obj0)).padBottom(8f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 147, 98, 127, 8, 106, 255, 5, 73, 117, 121, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showUpdate\u002439([In] SpawnGroup obj0, [In] BaseDialog obj1, [In] Table obj2)
    {
      int num1 = 0;
      Iterator iterator = Vars.content.units().iterator();
      while (iterator.hasNext())
      {
        UnitType unitType = (UnitType) iterator.next();
        if (!unitType.isHidden())
        {
          obj2.button((Cons) new WaveInfoDialog.__\u003C\u003EAnon15(unitType), (Runnable) new WaveInfoDialog.__\u003C\u003EAnon16(this, unitType, obj0, obj1)).pad(2f).margin(12f).fillX();
          ++num1;
          int num2 = num1;
          int num3 = 3;
          if ((num3 != -1 ? num2 % num3 : 0) == 0)
            obj2.row();
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 151, 103, 127, 17, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showUpdate\u002437([In] UnitType obj0, [In] Button obj1)
    {
      obj1.left();
      obj1.image(obj0.icon(Cicon.__\u003C\u003Emedium)).size(32f).scaling(Scaling.__\u003C\u003Efit).padRight(2f);
      Button button = obj1;
      object localizedName = (object) obj0.localizedName;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) localizedName;
      CharSequence text = charSequence;
      button.add(text);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 155, 103, 103, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showUpdate\u002438([In] UnitType obj0, [In] SpawnGroup obj1, [In] BaseDialog obj2)
    {
      this.lastType = obj0;
      obj1.type = obj0;
      obj2.hide();
      this.buildGroups();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {112, 103, 127, 22, 159, 13, 140, 253, 69, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildGroups\u002421([In] SpawnGroup obj0, [In] Table obj1, [In] Button obj2)
    {
      obj2.left();
      obj2.image(obj0.type.icon(Cicon.__\u003C\u003Emedium)).size(32f).padRight(3f).scaling(Scaling.__\u003C\u003Efit);
      Button button = obj2;
      object localizedName = (object) obj0.type.localizedName;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) localizedName;
      CharSequence text = charSequence;
      button.add(text).color(Pal.accent);
      obj2.add().growX();
      obj2.button((Drawable) Icon.cancel, (Runnable) new WaveInfoDialog.__\u003C\u003EAnon32(this, obj0, obj1)).pad(-6f).size(46f).padRight(-12f);
    }

    [Modifiers]
    [LineNumberTable(174)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildGroups\u002422([In] SpawnGroup obj0) => this.showUpdate(obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 64, 255, 30, 69, 102, 127, 17, 255, 50, 72, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildGroups\u002425([In] SpawnGroup obj0, [In] Table obj1)
    {
      obj1.field(new StringBuilder().append("").append(obj0.begin + 1).toString(), TextField.TextFieldFilter.digitsOnly, (Cons) new WaveInfoDialog.__\u003C\u003EAnon30(this, obj0)).width(100f);
      Table table = obj1;
      object obj = (object) "@waves.to";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).padLeft(4f).padRight(4f);
      ((TextField) obj1.field(obj0.end != int.MaxValue ? new StringBuilder().append(obj0.end + 1).append("").toString() : "", TextField.TextFieldFilter.digitsOnly, (Cons) new WaveInfoDialog.__\u003C\u003EAnon31(this, obj0)).width(100f).get()).setMessageText("∞");
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 83, 127, 7, 255, 28, 69, 102, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildGroups\u002427([In] SpawnGroup obj0, [In] Table obj1)
    {
      Table table1 = obj1;
      object obj2 = (object) "@waves.every";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text1 = charSequence;
      table1.add(text1).padRight(4f);
      obj1.field(new StringBuilder().append(obj0.spacing).append("").toString(), TextField.TextFieldFilter.digitsOnly, (Cons) new WaveInfoDialog.__\u003C\u003EAnon29(this, obj0)).width(100f);
      Table table2 = obj1;
      object obj3 = (object) "@waves.waves";
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence text2 = charSequence;
      table2.add(text2).padLeft(4f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 95, 255, 28, 69, 134, 124, 255, 47, 69, 102, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildGroups\u002430([In] SpawnGroup obj0, [In] Table obj1)
    {
      obj1.field(new StringBuilder().append(obj0.unitAmount).append("").toString(), TextField.TextFieldFilter.digitsOnly, (Cons) new WaveInfoDialog.__\u003C\u003EAnon27(this, obj0)).width(80f);
      Table table1 = obj1;
      object obj2 = (object) " + ";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text1 = charSequence;
      table1.add(text1);
      obj1.field(Strings.@fixed(Math.max(!Mathf.zero(obj0.unitScaling) ? 1f / obj0.unitScaling : 0.0f, 0.0f), 2), TextField.TextFieldFilter.floatsOnly, (Cons) new WaveInfoDialog.__\u003C\u003EAnon28(this, obj0)).width(80f);
      Table table2 = obj1;
      object obj3 = (object) "@waves.perspawn";
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence text2 = charSequence;
      table2.add(text2).padLeft(4f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 113, 255, 33, 69, 134, 124, 255, 33, 69, 102, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildGroups\u002433([In] SpawnGroup obj0, [In] Table obj1)
    {
      obj1.field(new StringBuilder().append(ByteCodeHelper.f2i(obj0.shields)).append("").toString(), TextField.TextFieldFilter.digitsOnly, (Cons) new WaveInfoDialog.__\u003C\u003EAnon25(this, obj0)).width(80f);
      Table table1 = obj1;
      object obj2 = (object) " + ";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text1 = charSequence;
      table1.add(text1);
      obj1.field(new StringBuilder().append(ByteCodeHelper.f2i(obj0.shieldScaling)).append("").toString(), TextField.TextFieldFilter.digitsOnly, (Cons) new WaveInfoDialog.__\u003C\u003EAnon26(this, obj0)).width(80f);
      Table table2 = obj1;
      object obj3 = (object) "@waves.shields";
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence text2 = charSequence;
      table2.add(text2).padLeft(4f);
    }

    [Modifiers]
    [LineNumberTable(245)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024buildGroups\u002434([In] SpawnGroup obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      obj0.effect = num == 0 ? (StatusEffect) null : StatusEffects.boss;
    }

    [Modifiers]
    [LineNumberTable(245)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024buildGroups\u002435([In] SpawnGroup obj0, [In] CheckBox obj1) => obj1.setChecked(object.ReferenceEquals((object) obj0.effect, (object) StatusEffects.boss));

    [Modifiers]
    [LineNumberTable(new byte[] {160, 114, 104, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildGroups\u002431([In] SpawnGroup obj0, [In] string obj1)
    {
      if (!Strings.canParsePositiveInt(obj1))
        return;
      obj0.shields = (float) Strings.parseInt(obj1);
      this.updateWaves();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 122, 104, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildGroups\u002432([In] SpawnGroup obj0, [In] string obj1)
    {
      if (!Strings.canParsePositiveInt(obj1))
        return;
      obj0.shieldScaling = (float) Strings.parseInt(obj1);
      this.updateWaves();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 96, 104, 108, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildGroups\u002428([In] SpawnGroup obj0, [In] string obj1)
    {
      if (!Strings.canParsePositiveInt(obj1))
        return;
      obj0.unitAmount = Strings.parseInt(obj1);
      this.updateWaves();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 104, 104, 116, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildGroups\u002429([In] SpawnGroup obj0, [In] string obj1)
    {
      if (!Strings.canParsePositiveFloat(obj1))
        return;
      obj0.unitScaling = 1f / Strings.parseFloat(obj1);
      this.updateWaves();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 85, 113, 108, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildGroups\u002426([In] SpawnGroup obj0, [In] string obj1)
    {
      if (!Strings.canParsePositiveInt(obj1) || Strings.parseInt(obj1) <= 0)
        return;
      obj0.spacing = Strings.parseInt(obj1);
      this.updateWaves();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 65, 104, 110, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildGroups\u002423([In] SpawnGroup obj0, [In] string obj1)
    {
      if (!Strings.canParsePositiveInt(obj1))
        return;
      obj0.begin = Strings.parseInt(obj1) - 1;
      this.updateWaves();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 72, 104, 110, 104, 104, 107, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildGroups\u002424([In] SpawnGroup obj0, [In] string obj1)
    {
      if (Strings.canParsePositiveInt(obj1))
      {
        obj0.end = Strings.parseInt(obj1) - 1;
        this.updateWaves();
      }
      else
      {
        if (!String.instancehelper_isEmpty(obj1))
          return;
        obj0.end = int.MaxValue;
        this.updateWaves();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {119, 109, 119, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024buildGroups\u002420([In] SpawnGroup obj0, [In] Table obj1)
    {
      this.groups.remove((object) obj0);
      this.table.getCell((Element) obj1).pad(0.0f);
      obj1.remove();
      this.updateWaves();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002417([In] Table obj0) => this.table = obj0;

    [Modifiers]
    [LineNumberTable(new byte[] {85, 115, 118, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002418()
    {
      if (this.groups == null)
        this.groups = new Seq();
      this.groups.add((object) new SpawnGroup(this.lastType));
      this.buildGroups();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {0, 111, 122, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241([In] BaseDialog obj0)
    {
      Vars.ui.showInfoFade("@waves.copied");
      Core.app.setClipboardText(Vars.maps.writeWaves(this.groups));
      obj0.hide();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024new\u00242([In] TextButton obj0) => this.groups == null;

    [Modifiers]
    [LineNumberTable(new byte[] {7, 122, 221, 226, 61, 97, 102, 143, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00243([In] BaseDialog obj0)
    {
      Exception exception;
      try
      {
        this.groups = Vars.maps.readWaves(Core.app.getClipboardText());
        this.buildGroups();
        goto label_5;
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
      Vars.ui.showErrorMessage("@waves.invalid");
label_5:
      obj0.hide();
    }

    [Modifiers]
    [LineNumberTable(64)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00244([In] TextButton obj0) => Core.app.getClipboardText() == null || String.instancehelper_isEmpty(Core.app.getClipboardText());

    [Modifiers]
    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00246([In] BaseDialog obj0) => Vars.ui.showConfirm("@confirm", "@settings.clear.confirm", (Runnable) new WaveInfoDialog.__\u003C\u003EAnon40(this, obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {17, 122, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00245([In] BaseDialog obj0)
    {
      this.groups = (Seq) JsonIO.copy((object) Vars.waves.get());
      this.buildGroups();
      obj0.hide();
    }

    [HideFromJava]
    static WaveInfoDialog() => BaseDialog.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "setup", "()V")]
    [SpecialName]
    internal new class \u0031 : Label
    {
      [Modifiers]
      internal WaveInfoDialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(140)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024new\u00240() => this.this\u00240.groups.isEmpty();

      [LineNumberTable(new byte[] {159, 108, 170, 127, 2, 114, 107, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] WaveInfoDialog obj0, [In] CharSequence obj1)
      {
        object obj2 = (object) obj1.__\u003Cref\u003E;
        this.this\u00240 = obj0;
        object obj3 = obj2;
        CharSequence text;
        text.__\u003Cref\u003E = (__Null) obj3;
        // ISSUE: explicit constructor call
        base.\u002Ector(text);
        WaveInfoDialog.\u0031 obj4 = this;
        this.visible((Boolp) new WaveInfoDialog.\u0031.__\u003C\u003EAnon0(this));
        this.touchable = Touchable.__\u003C\u003Edisabled;
        this.setWrap(true);
        this.setAlignment(1, 1);
      }

      [HideFromJava]
      static \u0031() => Label.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Boolp
      {
        private readonly WaveInfoDialog.\u0031 arg\u00241;

        internal __\u003C\u003EAnon0([In] WaveInfoDialog.\u0031 obj0) => this.arg\u00241 = obj0;

        public bool get() => (this.arg\u00241.lambda\u0024new\u00240() ? 1 : 0) != 0;
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly WaveInfoDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] WaveInfoDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly WaveInfoDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] WaveInfoDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly WaveInfoDialog arg\u00241;

      internal __\u003C\u003EAnon2([In] WaveInfoDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00247();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void run() => WaveInfoDialog.lambda\u0024new\u00248();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;

      internal __\u003C\u003EAnon4([In] WaveInfoDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00249((TextButton) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void run() => WaveInfoDialog.lambda\u0024new\u002410();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;

      internal __\u003C\u003EAnon6([In] WaveInfoDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u002411((TextButton) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public void run() => WaveInfoDialog.lambda\u0024new\u002412();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;

      internal __\u003C\u003EAnon8([In] WaveInfoDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u002413((TextButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public void run() => WaveInfoDialog.lambda\u0024new\u002414();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;

      internal __\u003C\u003EAnon10([In] WaveInfoDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u002415((TextButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly WaveInfoDialog arg\u00241;

      internal __\u003C\u003EAnon11([In] WaveInfoDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002416();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;

      internal __\u003C\u003EAnon12([In] WaveInfoDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002419((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly SpawnGroup arg\u00242;

      internal __\u003C\u003EAnon13([In] WaveInfoDialog obj0, [In] SpawnGroup obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildGroups\u002436(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly SpawnGroup arg\u00242;
      private readonly BaseDialog arg\u00243;

      internal __\u003C\u003EAnon14([In] WaveInfoDialog obj0, [In] SpawnGroup obj1, [In] BaseDialog obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024showUpdate\u002439(this.arg\u00242, this.arg\u00243, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Cons
    {
      private readonly UnitType arg\u00241;

      internal __\u003C\u003EAnon15([In] UnitType obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => WaveInfoDialog.lambda\u0024showUpdate\u002437(this.arg\u00241, (Button) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly UnitType arg\u00242;
      private readonly SpawnGroup arg\u00243;
      private readonly BaseDialog arg\u00244;

      internal __\u003C\u003EAnon16(
        [In] WaveInfoDialog obj0,
        [In] UnitType obj1,
        [In] SpawnGroup obj2,
        [In] BaseDialog obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void run() => this.arg\u00241.lambda\u0024showUpdate\u002438(this.arg\u00242, this.arg\u00243, this.arg\u00244);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly SpawnGroup arg\u00242;
      private readonly Table arg\u00243;

      internal __\u003C\u003EAnon17([In] WaveInfoDialog obj0, [In] SpawnGroup obj1, [In] Table obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildGroups\u002421(this.arg\u00242, this.arg\u00243, (Button) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Runnable
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly SpawnGroup arg\u00242;

      internal __\u003C\u003EAnon18([In] WaveInfoDialog obj0, [In] SpawnGroup obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024buildGroups\u002422(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly SpawnGroup arg\u00242;

      internal __\u003C\u003EAnon19([In] WaveInfoDialog obj0, [In] SpawnGroup obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildGroups\u002425(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly SpawnGroup arg\u00242;

      internal __\u003C\u003EAnon20([In] WaveInfoDialog obj0, [In] SpawnGroup obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildGroups\u002427(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly SpawnGroup arg\u00242;

      internal __\u003C\u003EAnon21([In] WaveInfoDialog obj0, [In] SpawnGroup obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildGroups\u002430(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly SpawnGroup arg\u00242;

      internal __\u003C\u003EAnon22([In] WaveInfoDialog obj0, [In] SpawnGroup obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildGroups\u002433(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Boolc
    {
      private readonly SpawnGroup arg\u00241;

      internal __\u003C\u003EAnon23([In] SpawnGroup obj0) => this.arg\u00241 = obj0;

      public void get([In] bool obj0) => WaveInfoDialog.lambda\u0024buildGroups\u002434(this.arg\u00241, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Cons
    {
      private readonly SpawnGroup arg\u00241;

      internal __\u003C\u003EAnon24([In] SpawnGroup obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => WaveInfoDialog.lambda\u0024buildGroups\u002435(this.arg\u00241, (CheckBox) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly SpawnGroup arg\u00242;

      internal __\u003C\u003EAnon25([In] WaveInfoDialog obj0, [In] SpawnGroup obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildGroups\u002431(this.arg\u00242, (string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly SpawnGroup arg\u00242;

      internal __\u003C\u003EAnon26([In] WaveInfoDialog obj0, [In] SpawnGroup obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildGroups\u002432(this.arg\u00242, (string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly SpawnGroup arg\u00242;

      internal __\u003C\u003EAnon27([In] WaveInfoDialog obj0, [In] SpawnGroup obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildGroups\u002428(this.arg\u00242, (string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly SpawnGroup arg\u00242;

      internal __\u003C\u003EAnon28([In] WaveInfoDialog obj0, [In] SpawnGroup obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildGroups\u002429(this.arg\u00242, (string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly SpawnGroup arg\u00242;

      internal __\u003C\u003EAnon29([In] WaveInfoDialog obj0, [In] SpawnGroup obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildGroups\u002426(this.arg\u00242, (string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly SpawnGroup arg\u00242;

      internal __\u003C\u003EAnon30([In] WaveInfoDialog obj0, [In] SpawnGroup obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildGroups\u002423(this.arg\u00242, (string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly SpawnGroup arg\u00242;

      internal __\u003C\u003EAnon31([In] WaveInfoDialog obj0, [In] SpawnGroup obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildGroups\u002424(this.arg\u00242, (string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Runnable
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly SpawnGroup arg\u00242;
      private readonly Table arg\u00243;

      internal __\u003C\u003EAnon32([In] WaveInfoDialog obj0, [In] SpawnGroup obj1, [In] Table obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024buildGroups\u002420(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Cons
    {
      private readonly WaveInfoDialog arg\u00241;

      internal __\u003C\u003EAnon33([In] WaveInfoDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002417((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Runnable
    {
      private readonly WaveInfoDialog arg\u00241;

      internal __\u003C\u003EAnon34([In] WaveInfoDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setup\u002418();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Runnable
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon35([In] WaveInfoDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00241(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : Boolf
    {
      private readonly WaveInfoDialog arg\u00241;

      internal __\u003C\u003EAnon36([In] WaveInfoDialog obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024new\u00242((TextButton) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon37 : Runnable
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon37([In] WaveInfoDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00243(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon38 : Boolf
    {
      internal __\u003C\u003EAnon38()
      {
      }

      public bool get([In] object obj0) => (WaveInfoDialog.lambda\u0024new\u00244((TextButton) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon39 : Runnable
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon39([In] WaveInfoDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00246(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon40 : Runnable
    {
      private readonly WaveInfoDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon40([In] WaveInfoDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00245(this.arg\u00242);
    }
  }
}
