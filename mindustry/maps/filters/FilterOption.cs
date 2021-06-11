// Decompiled with JetBrains decompiler
// Type: mindustry.maps.filters.FilterOption
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.ctype;
using mindustry.gen;
using mindustry.ui;
using mindustry.ui.dialogs;
using mindustry.world;
using mindustry.world.blocks.environment;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.filters
{
  public abstract class FilterOption : Object
  {
    [Signature("Larc/func/Boolf<Lmindustry/world/Block;>;")]
    internal static Boolf __\u003C\u003EfloorsOnly;
    [Signature("Larc/func/Boolf<Lmindustry/world/Block;>;")]
    internal static Boolf __\u003C\u003EwallsOnly;
    [Signature("Larc/func/Boolf<Lmindustry/world/Block;>;")]
    internal static Boolf __\u003C\u003EfloorsOptional;
    [Signature("Larc/func/Boolf<Lmindustry/world/Block;>;")]
    internal static Boolf __\u003C\u003EwallsOptional;
    [Signature("Larc/func/Boolf<Lmindustry/world/Block;>;")]
    internal static Boolf __\u003C\u003EwallsOresOptional;
    [Signature("Larc/func/Boolf<Lmindustry/world/Block;>;")]
    internal static Boolf __\u003C\u003EoresOnly;
    [Signature("Larc/func/Boolf<Lmindustry/world/Block;>;")]
    internal static Boolf __\u003C\u003EoresFloorsOptional;
    [Signature("Larc/func/Boolf<Lmindustry/world/Block;>;")]
    internal static Boolf __\u003C\u003EanyOptional;
    public Runnable changed;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    public abstract void build(Table t);

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00248()
    {
    }

    [Modifiers]
    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00240([In] Block obj0) => obj0 is Floor && !(obj0 is OverlayFloor) && (!Vars.headless && Core.atlas.isFound(obj0.icon(Cicon.__\u003C\u003Efull)));

    [Modifiers]
    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00241([In] Block obj0) => !obj0.synthetic() && !(obj0 is Floor) && (!Vars.headless && Core.atlas.isFound(obj0.icon(Cicon.__\u003C\u003Efull))) && obj0.inEditor;

    [Modifiers]
    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00242([In] Block obj0) => object.ReferenceEquals((object) obj0, (object) Blocks.air) || obj0 is Floor && !(obj0 is OverlayFloor) && (!Vars.headless && Core.atlas.isFound(obj0.icon(Cicon.__\u003C\u003Efull)));

    [Modifiers]
    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00243([In] Block obj0) => (object.ReferenceEquals((object) obj0, (object) Blocks.air) || !obj0.synthetic() && !(obj0 is Floor) && (!Vars.headless && Core.atlas.isFound(obj0.icon(Cicon.__\u003C\u003Efull)))) && obj0.inEditor;

    [Modifiers]
    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00244([In] Block obj0) => object.ReferenceEquals((object) obj0, (object) Blocks.air) || (!obj0.synthetic() && !(obj0 is Floor) || obj0 is OverlayFloor) && (!Vars.headless && Core.atlas.isFound(obj0.icon(Cicon.__\u003C\u003Efull)) && obj0.inEditor);

    [Modifiers]
    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00245([In] Block obj0) => obj0 is OverlayFloor && !Vars.headless && Core.atlas.isFound(obj0.icon(Cicon.__\u003C\u003Efull));

    [Modifiers]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00246([In] Block obj0) => obj0 is Floor && !Vars.headless && Core.atlas.isFound(obj0.icon(Cicon.__\u003C\u003Efull));

    [Modifiers]
    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00247([In] Block obj0) => (FilterOption.__\u003C\u003EfloorsOnly.get((object) obj0) || FilterOption.__\u003C\u003EwallsOnly.get((object) obj0) || (FilterOption.__\u003C\u003EoresOnly.get((object) obj0) || object.ReferenceEquals((object) obj0, (object) Blocks.air))) && obj0.inEditor;

    [LineNumberTable(new byte[] {159, 161, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FilterOption()
    {
      FilterOption filterOption = this;
      this.changed = (Runnable) new FilterOption.__\u003C\u003EAnon0();
    }

    [LineNumberTable(new byte[] {159, 137, 77, 111, 111, 111, 111, 111, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static FilterOption()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.maps.filters.FilterOption"))
        return;
      FilterOption.__\u003C\u003EfloorsOnly = (Boolf) new FilterOption.__\u003C\u003EAnon1();
      FilterOption.__\u003C\u003EwallsOnly = (Boolf) new FilterOption.__\u003C\u003EAnon2();
      FilterOption.__\u003C\u003EfloorsOptional = (Boolf) new FilterOption.__\u003C\u003EAnon3();
      FilterOption.__\u003C\u003EwallsOptional = (Boolf) new FilterOption.__\u003C\u003EAnon4();
      FilterOption.__\u003C\u003EwallsOresOptional = (Boolf) new FilterOption.__\u003C\u003EAnon5();
      FilterOption.__\u003C\u003EoresOnly = (Boolf) new FilterOption.__\u003C\u003EAnon6();
      FilterOption.__\u003C\u003EoresFloorsOptional = (Boolf) new FilterOption.__\u003C\u003EAnon7();
      FilterOption.__\u003C\u003EanyOptional = (Boolf) new FilterOption.__\u003C\u003EAnon8();
    }

    [Modifiers]
    public static Boolf floorsOnly
    {
      [HideFromJava] get => FilterOption.__\u003C\u003EfloorsOnly;
    }

    [Modifiers]
    public static Boolf wallsOnly
    {
      [HideFromJava] get => FilterOption.__\u003C\u003EwallsOnly;
    }

    [Modifiers]
    public static Boolf floorsOptional
    {
      [HideFromJava] get => FilterOption.__\u003C\u003EfloorsOptional;
    }

    [Modifiers]
    public static Boolf wallsOptional
    {
      [HideFromJava] get => FilterOption.__\u003C\u003EwallsOptional;
    }

    [Modifiers]
    public static Boolf wallsOresOptional
    {
      [HideFromJava] get => FilterOption.__\u003C\u003EwallsOresOptional;
    }

    [Modifiers]
    public static Boolf oresOnly
    {
      [HideFromJava] get => FilterOption.__\u003C\u003EoresOnly;
    }

    [Modifiers]
    public static Boolf oresFloorsOptional
    {
      [HideFromJava] get => FilterOption.__\u003C\u003EoresFloorsOptional;
    }

    [Modifiers]
    public static Boolf anyOptional
    {
      [HideFromJava] get => FilterOption.__\u003C\u003EanyOptional;
    }

    internal class BlockOption : FilterOption
    {
      [Modifiers]
      internal string name;
      [Modifiers]
      [Signature("Larc/func/Prov<Lmindustry/world/Block;>;")]
      internal Prov supplier;
      [Modifiers]
      [Signature("Larc/func/Cons<Lmindustry/world/Block;>;")]
      internal Cons consumer;
      [Modifiers]
      [Signature("Larc/func/Boolf<Lmindustry/world/Block;>;")]
      internal Boolf filter;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Signature("(Ljava/lang/String;Larc/func/Prov<Lmindustry/world/Block;>;Larc/func/Cons<Lmindustry/world/Block;>;Larc/func/Boolf<Lmindustry/world/Block;>;)V")]
      [LineNumberTable(new byte[] {33, 104, 103, 103, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal BlockOption([In] string obj0, [In] Prov obj1, [In] Cons obj2, [In] Boolf obj3)
      {
        FilterOption.BlockOption blockOption = this;
        this.name = obj0;
        this.supplier = obj1;
        this.consumer = obj2;
        this.filter = obj3;
      }

      [Modifiers]
      [LineNumberTable(new byte[] {42, 127, 22, 38})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00241([In] Button obj0) => obj0.image(((UnlockableContent) this.supplier.get()).icon(Cicon.__\u003C\u003Esmall)).update((Cons) new FilterOption.BlockOption.__\u003C\u003EAnon3(this)).size(24f);

      [Modifiers]
      [LineNumberTable(new byte[] {44, 107, 103, 98, 127, 8, 144, 255, 65, 69, 127, 0, 133, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00243()
      {
        BaseDialog baseDialog = new BaseDialog("");
        baseDialog.setFillParent(false);
        int num1 = 0;
        Iterator iterator = Vars.content.blocks().iterator();
        while (iterator.hasNext())
        {
          Block block = (Block) iterator.next();
          if (this.filter.get((object) block))
          {
            baseDialog.__\u003C\u003Econt.image(!object.ReferenceEquals((object) block, (object) Blocks.air) ? block.icon(Cicon.__\u003C\u003Emedium) : Icon.none.getRegion()).size(32f).pad(3f).get().clicked((Runnable) new FilterOption.BlockOption.__\u003C\u003EAnon2(this, block, baseDialog));
            ++num1;
            int num2 = num1;
            int num3 = 10;
            if ((num3 != -1 ? num2 % num3 : 0) == 0)
              baseDialog.__\u003C\u003Econt.row();
          }
        }
        baseDialog.show();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {51, 108, 102, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00242([In] Block obj0, [In] BaseDialog obj1)
      {
        this.consumer.get((object) obj0);
        obj1.hide();
        this.changed.run();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {42, 107, 63, 35})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00240([In] Image obj0) => ((TextureRegionDrawable) obj0.getDrawable()).setRegion(!object.ReferenceEquals(this.supplier.get(), (object) Blocks.air) ? ((UnlockableContent) this.supplier.get()).icon(Cicon.__\u003C\u003Esmall) : Icon.none.getRegion());

      [LineNumberTable(new byte[] {42, 255, 2, 81, 144, 127, 23})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build([In] Table obj0)
      {
        obj0.button((Cons) new FilterOption.BlockOption.__\u003C\u003EAnon0(this), (Runnable) new FilterOption.BlockOption.__\u003C\u003EAnon1(this)).pad(4f).margin(12f);
        Table table = obj0;
        object obj = (object) new StringBuilder().append("@filter.option.").append(this.name).toString();
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table.add(text);
      }

      [HideFromJava]
      static BlockOption() => FilterOption.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly FilterOption.BlockOption arg\u00241;

        internal __\u003C\u003EAnon0([In] FilterOption.BlockOption obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00241((Button) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Runnable
      {
        private readonly FilterOption.BlockOption arg\u00241;

        internal __\u003C\u003EAnon1([In] FilterOption.BlockOption obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024build\u00243();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Runnable
      {
        private readonly FilterOption.BlockOption arg\u00241;
        private readonly Block arg\u00242;
        private readonly BaseDialog arg\u00243;

        internal __\u003C\u003EAnon2([In] FilterOption.BlockOption obj0, [In] Block obj1, [In] BaseDialog obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024build\u00242(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Cons
      {
        private readonly FilterOption.BlockOption arg\u00241;

        internal __\u003C\u003EAnon3([In] FilterOption.BlockOption obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00240((Image) obj0);
      }
    }

    internal class SliderOption : FilterOption
    {
      [Modifiers]
      internal string name;
      [Modifiers]
      internal Floatp getter;
      [Modifiers]
      internal Floatc setter;
      [Modifiers]
      internal float min;
      [Modifiers]
      internal float max;
      [Modifiers]
      internal float step;
      internal bool display;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 184, 126})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal SliderOption([In] string obj0, [In] Floatp obj1, [In] Floatc obj2, [In] float obj3, [In] float obj4)
        : this(obj0, obj1, obj2, obj3, obj4, (obj4 - obj3) / 200f)
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FilterOption.SliderOption display()
      {
        this.display = true;
        return this;
      }

      [LineNumberTable(new byte[] {159, 187, 104, 103, 103, 103, 105, 105, 105})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal SliderOption(
        [In] string obj0,
        [In] Floatp obj1,
        [In] Floatc obj2,
        [In] float obj3,
        [In] float obj4,
        [In] float obj5)
      {
        FilterOption.SliderOption sliderOption = this;
        this.name = obj0;
        this.getter = obj1;
        this.setter = obj2;
        this.min = obj3;
        this.max = obj4;
        this.step = obj5;
      }

      [Modifiers]
      [LineNumberTable(64)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private CharSequence lambda\u0024build\u00240()
      {
        object obj = (object) new StringBuilder().append(Core.bundle.get(new StringBuilder().append("filter.option.").append(this.name).toString())).append(": ").append(ByteCodeHelper.f2i(this.getter.get())).toString();
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }

      [LineNumberTable(new byte[] {11, 104, 159, 25, 146, 103, 127, 15, 115, 103, 142, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build([In] Table obj0)
      {
        if (!this.display)
        {
          Table table = obj0;
          object obj = (object) new StringBuilder().append("@filter.option.").append(this.name).toString();
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) obj;
          CharSequence text = charSequence;
          table.add(text);
        }
        else
          obj0.label((Prov) new FilterOption.SliderOption.__\u003C\u003EAnon0(this));
        obj0.row();
        Slider slider = (Slider) obj0.slider(this.min, this.max, this.step, this.setter).growX().get();
        slider.setValue(this.getter.get());
        if (Vars.updateEditorOnChange)
          slider.changed(this.changed);
        else
          slider.released(this.changed);
      }

      [HideFromJava]
      static SliderOption() => FilterOption.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Prov
      {
        private readonly FilterOption.SliderOption arg\u00241;

        internal __\u003C\u003EAnon0([In] FilterOption.SliderOption obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024build\u00240().__\u003Cref\u003E;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void run() => FilterOption.lambda\u0024new\u00248();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get([In] object obj0) => (FilterOption.lambda\u0024static\u00240((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool get([In] object obj0) => (FilterOption.lambda\u0024static\u00241((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolf
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public bool get([In] object obj0) => (FilterOption.lambda\u0024static\u00242((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Boolf
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public bool get([In] object obj0) => (FilterOption.lambda\u0024static\u00243((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Boolf
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public bool get([In] object obj0) => (FilterOption.lambda\u0024static\u00244((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Boolf
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public bool get([In] object obj0) => (FilterOption.lambda\u0024static\u00245((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Boolf
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public bool get([In] object obj0) => (FilterOption.lambda\u0024static\u00246((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Boolf
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public bool get([In] object obj0) => (FilterOption.lambda\u0024static\u00247((Block) obj0) ? 1 : 0) != 0;
    }
  }
}
