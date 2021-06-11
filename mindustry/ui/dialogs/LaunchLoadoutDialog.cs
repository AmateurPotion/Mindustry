// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.LaunchLoadoutDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.storage;
using mindustry.world.modules;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class LaunchLoadoutDialog : BaseDialog
  {
    internal LoadoutDialog loadout;
    internal ItemSeq total;
    internal Schematic selected;
    internal bool valid;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 188, 177, 107, 103, 139, 107, 127, 8, 127, 7, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024show\u00240([In] ItemSeq obj0)
    {
      int itemCapacity = this.selected.findCore().itemCapacity;
      ItemSeq launchResources1 = Vars.universe.getLaunchResources();
      launchResources1.min(itemCapacity);
      Vars.universe.updateLaunchResources(launchResources1);
      this.total.clear();
      ItemSeq itemSeq = this.selected.requirements();
      ItemSeq total1 = this.total;
      Objects.requireNonNull((object) total1);
      ItemModule.ItemConsumer cons1 = (ItemModule.ItemConsumer) new LaunchLoadoutDialog.__\u003C\u003EAnon16(total1);
      itemSeq.each(cons1);
      ItemSeq launchResources2 = Vars.universe.getLaunchResources();
      ItemSeq total2 = this.total;
      Objects.requireNonNull((object) total2);
      ItemModule.ItemConsumer cons2 = (ItemModule.ItemConsumer) new LaunchLoadoutDialog.__\u003C\u003EAnon16(total2);
      launchResources2.each(cons2);
      this.valid = obj0.has(this.total);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {10, 102, 130, 108, 139, 127, 5, 127, 14, 158, 159, 35, 97, 122, 31, 36, 156, 149, 114, 135, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024show\u00241([In] ItemSeq obj0, [In] Table obj1)
    {
      obj1.clearChildren();
      int num1 = 0;
      ItemSeq itemSeq = this.selected.requirements();
      ItemSeq launchResources = Vars.universe.getLaunchResources();
      Iterator iterator = this.total.iterator();
      while (iterator.hasNext())
      {
        ItemStack itemStack = (ItemStack) iterator.next();
        obj1.image(itemStack.item.icon(Cicon.__\u003C\u003Esmall)).left().size((float) Cicon.__\u003C\u003Esmall.__\u003C\u003Esize);
        int num2 = itemSeq.get(itemStack.item);
        int num3 = launchResources.get(itemStack.item);
        string str = new StringBuilder().append(num3 + num2).append("[gray] (").append(num3).append(" + ").append(num2).append(")").toString();
        Table table = obj1;
        object obj = !obj0.has(itemStack.item, itemStack.amount) ? (object) new StringBuilder().append("[scarlet]").append(Math.min(obj0.get(itemStack.item), itemStack.amount)).append("[lightgray]/").append(str).toString() : (object) str;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table.add(text).padLeft(2f).left().padRight(4f);
        ++num1;
        int num4 = num1;
        int num5 = 4;
        if ((num5 != -1 ? num4 % num5 : 0) == 0)
          obj1.row();
      }
    }

    [Modifiers]
    [LineNumberTable(84)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024show\u00242([In] Cons obj0, [In] Table obj1) => obj0.get((object) obj1);

    [Modifiers]
    [LineNumberTable(new byte[] {37, 107, 135, 103, 159, 3, 255, 49, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024show\u00245([In] ItemSeq obj0, [In] Runnable obj1, [In] Runnable obj2)
    {
      Seq seq1 = Vars.universe.getLaunchResources().toSeq();
      ItemSeq itemSeq1 = obj0.copy();
      ItemSeq itemSeq2 = this.selected.requirements();
      ItemSeq itemSeq3 = itemSeq1;
      Objects.requireNonNull((object) itemSeq3);
      ItemModule.ItemConsumer cons = (ItemModule.ItemConsumer) new LaunchLoadoutDialog.__\u003C\u003EAnon11(itemSeq3);
      itemSeq2.each(cons);
      LoadoutDialog loadout = this.loadout;
      int itemCapacity = this.selected.findCore().itemCapacity;
      ItemSeq total = itemSeq1;
      Seq stacks = seq1;
      Boolf validator = (Boolf) new LaunchLoadoutDialog.__\u003C\u003EAnon12();
      Seq seq2 = seq1;
      Objects.requireNonNull((object) seq2);
      Runnable reseter = (Runnable) new LaunchLoadoutDialog.__\u003C\u003EAnon13(seq2);
      Runnable updater = (Runnable) new LaunchLoadoutDialog.__\u003C\u003EAnon14();
      Runnable hider = (Runnable) new LaunchLoadoutDialog.__\u003C\u003EAnon15(seq1, obj1, obj2);
      loadout.show(itemCapacity, total, stacks, validator, reseter, updater, hider);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {51, 113, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024show\u00246([In] CoreBlock obj0, [In] Runnable obj1)
    {
      Vars.universe.updateLoadout(obj0, this.selected);
      obj1.run();
      this.hide();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024show\u00247([In] TextButton obj0) => !this.valid;

    [Modifiers]
    [LineNumberTable(new byte[] {64, 130, 127, 8, 123, 159, 10, 223, 10, 159, 19, 115, 136, 133, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024show\u002410(
      [In] CoreBlock obj0,
      [In] Runnable obj1,
      [In] Runnable obj2,
      [In] ButtonGroup obj3,
      [In] int obj4,
      [In] Table obj5)
    {
      int num1 = 0;
      ObjectMap.Entries entries = Vars.schematics.getLoadouts().iterator();
label_1:
      while (((Iterator) entries).hasNext())
      {
        ObjectMap.Entry entry = (ObjectMap.Entry) ((Iterator) entries).next();
        if (((Block) entry.key).size <= obj0.size)
        {
          Iterator iterator = ((Seq) entry.value).iterator();
          while (true)
          {
            int num2;
            int num3;
            do
            {
              if (iterator.hasNext())
              {
                Schematic schematic = (Schematic) iterator.next();
                obj5.button((Cons) new LaunchLoadoutDialog.__\u003C\u003EAnon9(schematic), (Button.ButtonStyle) Styles.togglet, (Runnable) new LaunchLoadoutDialog.__\u003C\u003EAnon10(this, schematic, obj1, obj2)).group(obj3).pad(4f).@checked(object.ReferenceEquals((object) schematic, (object) this.selected)).size(200f);
                ++num1;
                num2 = num1;
                num3 = obj4;
              }
              else
                goto label_1;
            }
            while ((num3 != -1 ? num2 % num3 : 0) != 0);
            obj5.row();
          }
        }
      }
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024show\u002411() => !this.valid;

    [Modifiers]
    [LineNumberTable(120)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024show\u00248([In] Schematic obj0, [In] Button obj1) => obj1.add((Element) new SchematicsDialog.SchematicImage(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {71, 103, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024show\u00249([In] Schematic obj0, [In] Runnable obj1, [In] Runnable obj2)
    {
      this.selected = obj0;
      obj1.run();
      obj2.run();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024show\u00243()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {44, 112, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024show\u00244([In] Seq obj0, [In] Runnable obj1, [In] Runnable obj2)
    {
      Vars.universe.updateLaunchResources(new ItemSeq(obj0));
      obj1.run();
      obj2.run();
    }

    [LineNumberTable(new byte[] {159, 172, 237, 55, 139, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LaunchLoadoutDialog()
      : base("@configure")
    {
      LaunchLoadoutDialog launchLoadoutDialog = this;
      this.loadout = new LoadoutDialog();
      this.total = new ItemSeq();
    }

    [LineNumberTable(new byte[] {159, 176, 107, 139, 123, 159, 2, 134, 167, 237, 78, 237, 87, 134, 142, 255, 10, 76, 134, 223, 14, 134, 127, 6, 103, 113, 159, 23, 159, 33, 254, 85, 150, 108, 109, 108, 159, 20, 102, 135, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show(CoreBlock core, Sector sector, Runnable confirm)
    {
      this.__\u003C\u003Econt.clear();
      this.__\u003C\u003Ebuttons.clear();
      this.__\u003C\u003Ebuttons.defaults().size(160f, 64f);
      this.__\u003C\u003Ebuttons.button("@back", (Drawable) Icon.left, (Runnable) new LaunchLoadoutDialog.__\u003C\u003EAnon0(this));
      this.addCloseListener();
      ItemSeq itemSeq = sector.items();
      Runnable runnable1 = (Runnable) new LaunchLoadoutDialog.__\u003C\u003EAnon1(this, itemSeq);
      Cons cons = (Cons) new LaunchLoadoutDialog.__\u003C\u003EAnon2(this, itemSeq);
      Table table = new Table();
      Runnable runnable2 = (Runnable) new LaunchLoadoutDialog.__\u003C\u003EAnon3(cons, table);
      this.__\u003C\u003Ebuttons.button("@resources", (Drawable) Icon.terrain, (Runnable) new LaunchLoadoutDialog.__\u003C\u003EAnon4(this, itemSeq, runnable1, runnable2)).width(204f);
      this.__\u003C\u003Ebuttons.button("@launch.text", (Drawable) Icon.ok, (Runnable) new LaunchLoadoutDialog.__\u003C\u003EAnon5(this, core, confirm)).disabled((Boolf) new LaunchLoadoutDialog.__\u003C\u003EAnon6(this));
      int num = Math.max(ByteCodeHelper.f2i((float) Core.graphics.getWidth() / Scl.scl(230f)), 1);
      ButtonGroup buttonGroup = new ButtonGroup();
      this.selected = Vars.universe.getLoadout(core);
      if (this.selected == null)
        this.selected = (Schematic) ((Seq) Vars.schematics.getLoadouts().get((object) (CoreBlock) Blocks.coreShard)).first();
      Table cont1 = this.__\u003C\u003Econt;
      object obj1 = (object) Core.bundle.format("launch.from", (object) sector.name());
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj1;
      CharSequence text1 = charSequence;
      cont1.add(text1).row();
      ((ScrollPane) this.__\u003C\u003Econt.pane((Cons) new LaunchLoadoutDialog.__\u003C\u003EAnon7(this, core, runnable1, runnable2, buttonGroup, num)).growX().get()).setScrollingDisabled(true, false);
      this.__\u003C\u003Econt.row();
      this.__\u003C\u003Econt.pane((Element) table);
      this.__\u003C\u003Econt.row();
      Table cont2 = this.__\u003C\u003Econt;
      object obj2 = (object) "@sector.missingresources";
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text2 = charSequence;
      cont2.add(text2).visible((Boolp) new LaunchLoadoutDialog.__\u003C\u003EAnon8(this));
      runnable1.run();
      runnable2.run();
      this.show();
    }

    [HideFromJava]
    static LaunchLoadoutDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly LaunchLoadoutDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] LaunchLoadoutDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly LaunchLoadoutDialog arg\u00241;
      private readonly ItemSeq arg\u00242;

      internal __\u003C\u003EAnon1([In] LaunchLoadoutDialog obj0, [In] ItemSeq obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024show\u00240(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly LaunchLoadoutDialog arg\u00241;
      private readonly ItemSeq arg\u00242;

      internal __\u003C\u003EAnon2([In] LaunchLoadoutDialog obj0, [In] ItemSeq obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024show\u00241(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly Cons arg\u00241;
      private readonly Table arg\u00242;

      internal __\u003C\u003EAnon3([In] Cons obj0, [In] Table obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => LaunchLoadoutDialog.lambda\u0024show\u00242(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly LaunchLoadoutDialog arg\u00241;
      private readonly ItemSeq arg\u00242;
      private readonly Runnable arg\u00243;
      private readonly Runnable arg\u00244;

      internal __\u003C\u003EAnon4(
        [In] LaunchLoadoutDialog obj0,
        [In] ItemSeq obj1,
        [In] Runnable obj2,
        [In] Runnable obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void run() => this.arg\u00241.lambda\u0024show\u00245(this.arg\u00242, this.arg\u00243, this.arg\u00244);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly LaunchLoadoutDialog arg\u00241;
      private readonly CoreBlock arg\u00242;
      private readonly Runnable arg\u00243;

      internal __\u003C\u003EAnon5([In] LaunchLoadoutDialog obj0, [In] CoreBlock obj1, [In] Runnable obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024show\u00246(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Boolf
    {
      private readonly LaunchLoadoutDialog arg\u00241;

      internal __\u003C\u003EAnon6([In] LaunchLoadoutDialog obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024show\u00247((TextButton) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly LaunchLoadoutDialog arg\u00241;
      private readonly CoreBlock arg\u00242;
      private readonly Runnable arg\u00243;
      private readonly Runnable arg\u00244;
      private readonly ButtonGroup arg\u00245;
      private readonly int arg\u00246;

      internal __\u003C\u003EAnon7(
        [In] LaunchLoadoutDialog obj0,
        [In] CoreBlock obj1,
        [In] Runnable obj2,
        [In] Runnable obj3,
        [In] ButtonGroup obj4,
        [In] int obj5)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024show\u002410(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Boolp
    {
      private readonly LaunchLoadoutDialog arg\u00241;

      internal __\u003C\u003EAnon8([In] LaunchLoadoutDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024show\u002411() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      private readonly Schematic arg\u00241;

      internal __\u003C\u003EAnon9([In] Schematic obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => LaunchLoadoutDialog.lambda\u0024show\u00248(this.arg\u00241, (Button) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Runnable
    {
      private readonly LaunchLoadoutDialog arg\u00241;
      private readonly Schematic arg\u00242;
      private readonly Runnable arg\u00243;
      private readonly Runnable arg\u00244;

      internal __\u003C\u003EAnon10(
        [In] LaunchLoadoutDialog obj0,
        [In] Schematic obj1,
        [In] Runnable obj2,
        [In] Runnable obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void run() => this.arg\u00241.lambda\u0024show\u00249(this.arg\u00242, this.arg\u00243, this.arg\u00244);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : ItemModule.ItemConsumer
    {
      private readonly ItemSeq arg\u00241;

      internal __\u003C\u003EAnon11([In] ItemSeq obj0) => this.arg\u00241 = obj0;

      public void accept([In] Item obj0, [In] int obj1) => this.arg\u00241.remove(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Boolf
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public bool get([In] object obj0) => (((UnlockableContent) obj0).unlocked() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly Seq arg\u00241;

      internal __\u003C\u003EAnon13([In] Seq obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.clear();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public void run() => LaunchLoadoutDialog.lambda\u0024show\u00243();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Runnable
    {
      private readonly Seq arg\u00241;
      private readonly Runnable arg\u00242;
      private readonly Runnable arg\u00243;

      internal __\u003C\u003EAnon15([In] Seq obj0, [In] Runnable obj1, [In] Runnable obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => LaunchLoadoutDialog.lambda\u0024show\u00244(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : ItemModule.ItemConsumer
    {
      private readonly ItemSeq arg\u00241;

      internal __\u003C\u003EAnon16([In] ItemSeq obj0) => this.arg\u00241 = obj0;

      public void accept([In] Item obj0, [In] int obj1) => this.arg\u00241.add(obj0, obj1);
    }
  }
}
