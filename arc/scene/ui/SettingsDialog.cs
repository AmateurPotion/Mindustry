// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.SettingsDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.scene.ui.layout;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui
{
  public class SettingsDialog : Dialog
  {
    public SettingsDialog.SettingsTable main;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 124, 134, 139, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SettingsDialog()
      : base(Core.bundle.get("settings", "Settings"))
    {
      SettingsDialog settingsDialog = this;
      this.addCloseButton();
      this.main = new SettingsDialog.SettingsTable();
      this.__\u003C\u003Econt.add((Element) this.main);
    }

    [HideFromJava]
    static SettingsDialog() => Dialog.__\u003Cclinit\u003E();

    public class SettingsTable : Table
    {
      [Signature("Larc/struct/Seq<Larc/scene/ui/SettingsDialog$SettingsTable$Setting;>;")]
      protected internal Seq list;
      [Signature("Larc/func/Cons<Larc/scene/ui/SettingsDialog$SettingsTable;>;")]
      protected internal Cons rebuilt;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 174, 232, 61, 203, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SettingsTable()
      {
        SettingsDialog.SettingsTable settingsTable = this;
        this.list = new Seq();
        this.left();
      }

      [LineNumberTable(new byte[] {10, 125, 125, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual SettingsDialog.SettingsTable.SliderSetting sliderPref(
        string name,
        string title,
        int def,
        int min,
        int max,
        int step,
        SettingsDialog.StringProcessor s)
      {
        SettingsDialog.SettingsTable.SliderSetting sliderSetting;
        this.list.add((object) (sliderSetting = new SettingsDialog.SettingsTable.SliderSetting(name, title, def, min, max, step, s)));
        Core.settings.defaults((object) name, (object) Integer.valueOf(def));
        this.rebuild();
        return sliderSetting;
      }

      [LineNumberTable(new byte[] {1, 127, 14})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void screenshakePref() => this.sliderPref("screenshake", Core.bundle.get("setting.screenshake.name", "Screen Shake"), 4, 0, 8, (SettingsDialog.StringProcessor) new SettingsDialog.SettingsTable.__\u003C\u003EAnon0());

      [LineNumberTable(new byte[] {159, 119, 66, 127, 34, 125, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void checkPref(string name, bool def)
      {
        int num = def ? 1 : 0;
        this.list.add((object) new SettingsDialog.SettingsTable.CheckSetting(name, Core.bundle.get(new StringBuilder().append("setting.").append(name).append(".name").toString()), num != 0, (Boolc) null));
        Core.settings.defaults((object) name, (object) Boolean.valueOf(num != 0));
        this.rebuild();
      }

      [LineNumberTable(new byte[] {159, 118, 162, 127, 34, 125, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void checkPref(string name, bool def, Boolc changed)
      {
        int num = def ? 1 : 0;
        this.list.add((object) new SettingsDialog.SettingsTable.CheckSetting(name, Core.bundle.get(new StringBuilder().append("setting.").append(name).append(".name").toString()), num != 0, changed));
        Core.settings.defaults((object) name, (object) Boolean.valueOf(num != 0));
        this.rebuild();
      }

      [LineNumberTable(new byte[] {22, 127, 42, 125, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual SettingsDialog.SettingsTable.SliderSetting sliderPref(
        string name,
        int def,
        int min,
        int max,
        int step,
        SettingsDialog.StringProcessor s)
      {
        SettingsDialog.SettingsTable.SliderSetting sliderSetting;
        this.list.add((object) (sliderSetting = new SettingsDialog.SettingsTable.SliderSetting(name, Core.bundle.get(new StringBuilder().append("setting.").append(name).append(".name").toString()), def, min, max, step, s)));
        Core.settings.defaults((object) name, (object) Integer.valueOf(def));
        this.rebuild();
        return sliderSetting;
      }

      [LineNumberTable(67)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual SettingsDialog.SettingsTable.SliderSetting sliderPref(
        string name,
        int def,
        int min,
        int max,
        SettingsDialog.StringProcessor s)
      {
        return this.sliderPref(name, def, min, max, 1, s);
      }

      [LineNumberTable(new byte[] {55, 134, 127, 1, 103, 130, 255, 11, 70, 154, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void rebuild()
      {
        this.clearChildren();
        Iterator iterator = this.list.iterator();
        while (iterator.hasNext())
          ((SettingsDialog.SettingsTable.Setting) iterator.next()).add(this);
        this.button(Core.bundle.get("settings.reset", "Reset to Defaults"), (Runnable) new SettingsDialog.SettingsTable.__\u003C\u003EAnon1(this)).margin(14f).width(240f).pad(6f);
        if (this.rebuilt == null)
          return;
        this.rebuilt.get((object) this);
      }

      [LineNumberTable(55)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual SettingsDialog.SettingsTable.SliderSetting sliderPref(
        string name,
        string title,
        int def,
        int min,
        int max,
        SettingsDialog.StringProcessor s)
      {
        return this.sliderPref(name, title, def, min, max, 1, s);
      }

      [Modifiers]
      [LineNumberTable(51)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static string lambda\u0024screenshakePref\u00240([In] int obj0) => new StringBuilder().append((float) obj0 / 4f).append("x").toString();

      [Modifiers]
      [LineNumberTable(new byte[] {62, 127, 1, 114, 127, 1, 98, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00241()
      {
        Iterator iterator = this.list.iterator();
        while (iterator.hasNext())
        {
          SettingsDialog.SettingsTable.Setting setting = (SettingsDialog.SettingsTable.Setting) iterator.next();
          if (setting.name != null && setting.title != null)
            Core.settings.put(setting.name, Core.settings.getDefault(setting.name));
        }
        this.rebuild();
      }

      [Signature("(Larc/func/Cons<Larc/scene/ui/SettingsDialog$SettingsTable;>;)V")]
      [LineNumberTable(new byte[] {159, 178, 232, 57, 235, 72, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SettingsTable(Cons rebuilt)
      {
        SettingsDialog.SettingsTable settingsTable = this;
        this.list = new Seq();
        this.rebuilt = rebuilt;
        this.left();
      }

      [Signature("()Larc/struct/Seq<Larc/scene/ui/SettingsDialog$SettingsTable$Setting;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq getSettings() => this.list;

      [LineNumberTable(new byte[] {159, 188, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void pref(SettingsDialog.SettingsTable.Setting setting)
      {
        this.list.add((object) setting);
        this.rebuild();
      }

      [LineNumberTable(new byte[] {159, 123, 162, 116, 125, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void checkPref(string name, string title, bool def)
      {
        int num = def ? 1 : 0;
        this.list.add((object) new SettingsDialog.SettingsTable.CheckSetting(name, title, num != 0, (Boolc) null));
        Core.settings.defaults((object) name, (object) Boolean.valueOf(num != 0));
        this.rebuild();
      }

      [LineNumberTable(new byte[] {159, 121, 98, 117, 125, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void checkPref(string name, string title, bool def, Boolc changed)
      {
        int num = def ? 1 : 0;
        this.list.add((object) new SettingsDialog.SettingsTable.CheckSetting(name, title, num != 0, changed));
        Core.settings.defaults((object) name, (object) Boolean.valueOf(num != 0));
        this.rebuild();
      }

      [HideFromJava]
      static SettingsTable() => Table.__\u003Cclinit\u003E();

      public class CheckSetting : SettingsDialog.SettingsTable.Setting
      {
        internal bool def;
        internal Boolc changed;

        [Modifiers]
        [LineNumberTable(144)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void lambda\u0024add\u00240([In] CheckBox obj0) => obj0.setChecked(Core.settings.getBool(this.name));

        [Modifiers]
        [LineNumberTable(new byte[] {97, 123, 104, 145})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void lambda\u0024add\u00241([In] CheckBox obj0)
        {
          Core.settings.put(this.name, (object) Boolean.valueOf(obj0.isChecked));
          if (this.changed == null)
            return;
          this.changed.get(obj0.isChecked);
        }

        [LineNumberTable(new byte[] {159, 109, 98, 104, 103, 103, 103, 104})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal CheckSetting([In] string obj0, [In] string obj1, [In] bool obj2, [In] Boolc obj3)
        {
          int num = obj2 ? 1 : 0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          SettingsDialog.SettingsTable.CheckSetting checkSetting = this;
          this.name = obj0;
          this.title = obj1;
          this.def = num != 0;
          this.changed = obj3;
        }

        [LineNumberTable(new byte[] {92, 145, 147, 242, 71, 103, 119, 103})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void add(SettingsDialog.SettingsTable table)
        {
          CheckBox.__\u003Cclinit\u003E();
          CheckBox checkBox = new CheckBox(this.title);
          checkBox.update((Runnable) new SettingsDialog.SettingsTable.CheckSetting.__\u003C\u003EAnon0(this, checkBox));
          checkBox.changed((Runnable) new SettingsDialog.SettingsTable.CheckSetting.__\u003C\u003EAnon1(this, checkBox));
          checkBox.left();
          table.add((Element) checkBox).left().padTop(3f);
          table.row();
        }

        [SpecialName]
        private sealed class __\u003C\u003EAnon0 : Runnable
        {
          private readonly SettingsDialog.SettingsTable.CheckSetting arg\u00241;
          private readonly CheckBox arg\u00242;

          internal __\u003C\u003EAnon0(
            [In] SettingsDialog.SettingsTable.CheckSetting obj0,
            [In] CheckBox obj1)
          {
            this.arg\u00241 = obj0;
            this.arg\u00242 = obj1;
          }

          public void run() => this.arg\u00241.lambda\u0024add\u00240(this.arg\u00242);
        }

        [SpecialName]
        private sealed class __\u003C\u003EAnon1 : Runnable
        {
          private readonly SettingsDialog.SettingsTable.CheckSetting arg\u00241;
          private readonly CheckBox arg\u00242;

          internal __\u003C\u003EAnon1(
            [In] SettingsDialog.SettingsTable.CheckSetting obj0,
            [In] CheckBox obj1)
          {
            this.arg\u00241 = obj0;
            this.arg\u00242 = obj1;
          }

          public void run() => this.arg\u00241.lambda\u0024add\u00241(this.arg\u00242);
        }
      }

      public abstract class Setting : Object
      {
        public string name;
        public string title;

        [LineNumberTable(122)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public Setting()
        {
        }

        public abstract void add(SettingsDialog.SettingsTable sdst);
      }

      public class SliderSetting : SettingsDialog.SettingsTable.Setting
      {
        internal int def;
        internal int min;
        internal int max;
        internal int step;
        internal SettingsDialog.StringProcessor sp;
        internal float[] values;

        [LineNumberTable(new byte[] {117, 8, 167, 103, 103, 103, 104, 104, 104, 104})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal SliderSetting(
          [In] string obj0,
          [In] string obj1,
          [In] int obj2,
          [In] int obj3,
          [In] int obj4,
          [In] int obj5,
          [In] SettingsDialog.StringProcessor obj6)
        {
          SettingsDialog.SettingsTable.SliderSetting sliderSetting = this;
          this.values = (float[]) null;
          this.name = obj0;
          this.title = obj1;
          this.def = obj2;
          this.min = obj3;
          this.max = obj4;
          this.step = obj5;
          this.sp = obj6;
        }

        [Modifiers]
        [LineNumberTable(new byte[] {160, 74, 127, 2, 127, 50})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void lambda\u0024add\u00240([In] Slider obj0, [In] Label obj1)
        {
          Core.settings.put(this.name, (object) Integer.valueOf(ByteCodeHelper.f2i(obj0.getValue())));
          Label label = obj1;
          object obj = (object) new StringBuilder().append(this.title).append(": ").append(this.sp.get(ByteCodeHelper.f2i(obj0.getValue()))).toString();
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) obj;
          CharSequence newText = charSequence;
          label.setText(newText);
        }

        [Modifiers]
        [LineNumberTable(new byte[] {160, 81, 113, 127, 9, 114})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void lambda\u0024add\u00241([In] Label obj0, [In] Slider obj1, [In] Table obj2)
        {
          obj2.left().defaults().left();
          obj2.add((Element) obj0).minWidth(obj0.getPrefWidth() / Scl.scl(1f) + 50f);
          obj2.add((Element) obj1).width(180f);
        }

        [LineNumberTable(new byte[] {160, 65, 156, 120, 104, 177, 127, 2, 243, 69, 134, 210, 144, 103})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void add(SettingsDialog.SettingsTable table)
        {
          Slider slider = new Slider((float) this.min, (float) this.max, (float) this.step, false);
          slider.setValue((float) Core.settings.getInt(this.name));
          if (this.values != null)
            slider.setSnapToValues(this.values, 1f);
          Label.__\u003Cclinit\u003E();
          object title = (object) this.title;
          CharSequence text;
          text.__\u003Cref\u003E = (__Null) title;
          Label label = new Label(text);
          slider.changed((Runnable) new SettingsDialog.SettingsTable.SliderSetting.__\u003C\u003EAnon0(this, slider, label));
          slider.change();
          table.table((Cons) new SettingsDialog.SettingsTable.SliderSetting.__\u003C\u003EAnon1(label, slider)).left().padTop(3f);
          table.row();
        }

        [SpecialName]
        private sealed class __\u003C\u003EAnon0 : Runnable
        {
          private readonly SettingsDialog.SettingsTable.SliderSetting arg\u00241;
          private readonly Slider arg\u00242;
          private readonly Label arg\u00243;

          internal __\u003C\u003EAnon0(
            [In] SettingsDialog.SettingsTable.SliderSetting obj0,
            [In] Slider obj1,
            [In] Label obj2)
          {
            this.arg\u00241 = obj0;
            this.arg\u00242 = obj1;
            this.arg\u00243 = obj2;
          }

          public void run() => this.arg\u00241.lambda\u0024add\u00240(this.arg\u00242, this.arg\u00243);
        }

        [SpecialName]
        private sealed class __\u003C\u003EAnon1 : Cons
        {
          private readonly Label arg\u00241;
          private readonly Slider arg\u00242;

          internal __\u003C\u003EAnon1([In] Label obj0, [In] Slider obj1)
          {
            this.arg\u00241 = obj0;
            this.arg\u00242 = obj1;
          }

          public void get([In] object obj0) => SettingsDialog.SettingsTable.SliderSetting.lambda\u0024add\u00241(this.arg\u00241, this.arg\u00242, (Table) obj0);
        }
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : SettingsDialog.StringProcessor
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public string get([In] int obj0) => SettingsDialog.SettingsTable.lambda\u0024screenshakePref\u00240(obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Runnable
      {
        private readonly SettingsDialog.SettingsTable arg\u00241;

        internal __\u003C\u003EAnon1([In] SettingsDialog.SettingsTable obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024rebuild\u00241();
      }
    }

    public interface StringProcessor
    {
      string get(int i);
    }
  }
}
