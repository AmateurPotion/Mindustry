// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.LoadoutDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.input;
using arc.scene.style;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.gen;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class LoadoutDialog : BaseDialog
  {
    private Runnable hider;
    private Runnable resetter;
    private Runnable updater;
    [Signature("Larc/struct/Seq<Lmindustry/type/ItemStack;>;")]
    private Seq stacks;
    [Signature("Larc/struct/Seq<Lmindustry/type/ItemStack;>;")]
    private Seq originalStacks;
    [Signature("Larc/func/Boolf<Lmindustry/type/Item;>;")]
    private Boolf validator;
    private Table items;
    private int capacity;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private ItemSeq total;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 170, 237, 56, 107, 107, 240, 71, 135, 241, 70, 156, 113, 241, 72, 159, 17, 159, 17, 255, 11, 69, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LoadoutDialog()
      : base("@configure")
    {
      LoadoutDialog loadoutDialog = this;
      this.stacks = new Seq();
      this.originalStacks = new Seq();
      this.validator = (Boolf) new LoadoutDialog.__\u003C\u003EAnon0();
      this.setFillParent(true);
      this.keyDown((Cons) new LoadoutDialog.__\u003C\u003EAnon1(this));
      this.__\u003C\u003Econt.pane((Cons) new LoadoutDialog.__\u003C\u003EAnon2(this)).left();
      this.shown((Runnable) new LoadoutDialog.__\u003C\u003EAnon3(this));
      this.hidden((Runnable) new LoadoutDialog.__\u003C\u003EAnon4(this));
      this.__\u003C\u003Ebuttons.button("@back", (Drawable) Icon.left, (Runnable) new LoadoutDialog.__\u003C\u003EAnon5(this)).size(210f, 64f);
      this.__\u003C\u003Ebuttons.button("@max", (Drawable) Icon.export, (Runnable) new LoadoutDialog.__\u003C\u003EAnon6(this)).size(210f, 64f);
      this.__\u003C\u003Ebuttons.button("@settings.reset", (Drawable) Icon.refresh, (Runnable) new LoadoutDialog.__\u003C\u003EAnon7(this)).size(210f, 64f);
    }

    [Signature("(ILarc/struct/Seq<Lmindustry/type/ItemStack;>;Larc/func/Boolf<Lmindustry/type/Item;>;Ljava/lang/Runnable;Ljava/lang/Runnable;Ljava/lang/Runnable;)V")]
    [LineNumberTable(new byte[] {17, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show(
      int capacity,
      Seq stacks,
      Boolf validator,
      Runnable reseter,
      Runnable updater,
      Runnable hider)
    {
      this.show(capacity, (ItemSeq) null, stacks, validator, reseter, updater, hider);
    }

    [Signature("(ILmindustry/type/ItemSeq;Larc/struct/Seq<Lmindustry/type/ItemStack;>;Larc/func/Boolf<Lmindustry/type/Item;>;Ljava/lang/Runnable;Ljava/lang/Runnable;Ljava/lang/Runnable;)V")]
    [LineNumberTable(new byte[] {21, 103, 104, 104, 104, 103, 103, 104, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show(
      int capacity,
      ItemSeq total,
      Seq stacks,
      Boolf validator,
      Runnable reseter,
      Runnable updater,
      Runnable hider)
    {
      this.originalStacks = stacks;
      this.validator = validator;
      this.resetter = reseter;
      this.updater = updater;
      this.capacity = capacity;
      this.total = total;
      this.hider = hider;
      this.reseed();
      this.show();
    }

    [LineNumberTable(new byte[] {76, 123, 127, 22, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void reseed()
    {
      this.stacks = this.originalStacks.map((Func) new LoadoutDialog.__\u003C\u003EAnon9());
      this.stacks.addAll(Vars.content.items().select((Boolf) new LoadoutDialog.__\u003C\u003EAnon10(this)).map((Func) new LoadoutDialog.__\u003C\u003EAnon11()));
      this.stacks.sort(Structs.comparingInt((Intf) new LoadoutDialog.__\u003C\u003EAnon12()));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private int step([In] int obj0)
    {
      if (obj0 < 1000)
        return 100;
      if (obj0 < 2000)
        return 200;
      return obj0 < 5000 ? 500 : 1000;
    }

    [LineNumberTable(new byte[] {33, 107, 108, 134, 130, 127, 4, 255, 3, 90, 176, 127, 6, 140, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setup()
    {
      this.items.clearChildren();
      this.items.left();
      float num1 = 40f;
      int num2 = 0;
      Iterator iterator = this.stacks.iterator();
      while (iterator.hasNext())
      {
        ItemStack itemStack = (ItemStack) iterator.next();
        this.items.table((Drawable) Tex.pane, (Cons) new LoadoutDialog.__\u003C\u003EAnon8(this, itemStack, num1)).pad(2f).left().fillX();
        ++num2;
        int num3 = num2;
        int num4 = 2;
        if ((num4 != -1 ? num3 % num4 : 0) == 0 || Vars.mobile && Core.graphics.isPortrait())
          this.items.row();
      }
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00240([In] Item obj0) => true;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 174, 122, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241([In] KeyCode obj0)
    {
      if (!object.ReferenceEquals((object) obj0, (object) KeyCode.__\u003C\u003Eescape) && !object.ReferenceEquals((object) obj0, (object) KeyCode.__\u003C\u003Eback))
        return;
      Core.app.post((Runnable) new LoadoutDialog.__\u003C\u003EAnon5(this));
    }

    [Modifiers]
    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242([In] Table obj0) => this.items = obj0.margin(10f);

    [Modifiers]
    [LineNumberTable(new byte[] {159, 183, 124, 107, 104, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00244()
    {
      this.originalStacks.selectFrom(this.stacks, (Boolf) new LoadoutDialog.__\u003C\u003EAnon19());
      this.updater.run();
      if (this.hider == null)
        return;
      this.hider.run();
    }

    [LineNumberTable(new byte[] {11, 127, 1, 127, 25, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void maxItems()
    {
      Iterator iterator = this.stacks.iterator();
      while (iterator.hasNext())
      {
        ItemStack itemStack = (ItemStack) iterator.next();
        itemStack.amount = this.total != null ? Math.max(Math.min(this.capacity, this.total.get(itemStack.item)), 0) : this.capacity;
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {3, 107, 102, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00245()
    {
      this.resetter.run();
      this.reseed();
      this.updater.run();
      this.setup();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {41, 123, 190, 134, 190, 134, 254, 74, 134, 127, 22, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u002411([In] ItemStack obj0, [In] float obj1, [In] Table obj2)
    {
      obj2.margin(4f).marginRight(8f).left();
      obj2.button("-", Styles.cleart, (Runnable) new LoadoutDialog.__\u003C\u003EAnon14(this, obj0)).size(obj1);
      obj2.button("+", Styles.cleart, (Runnable) new LoadoutDialog.__\u003C\u003EAnon15(this, obj0)).size(obj1);
      obj2.button((Drawable) Icon.pencil, Styles.cleari, (Runnable) new LoadoutDialog.__\u003C\u003EAnon16(this, obj0)).size(obj1);
      obj2.image(obj0.item.icon(Cicon.__\u003C\u003Esmall)).size(24f).padRight(4f).padLeft(4f);
      obj2.label((Prov) new LoadoutDialog.__\u003C\u003EAnon17(obj0)).left().width(90f);
    }

    [Modifiers]
    [LineNumberTable(127)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024reseed\u002413([In] Item obj0) => this.validator.get((object) obj0) && !this.stacks.contains((Boolf) new LoadoutDialog.__\u003C\u003EAnon13(obj0));

    [Modifiers]
    [LineNumberTable(127)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static ItemStack lambda\u0024reseed\u002414([In] Item obj0) => new ItemStack(obj0, 0);

    [Modifiers]
    [LineNumberTable(128)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024reseed\u002415([In] ItemStack obj0) => (int) obj0.item.__\u003C\u003Eid;

    [Modifiers]
    [LineNumberTable(127)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024reseed\u002412([In] Item obj0, [In] ItemStack obj1) => object.ReferenceEquals((object) obj1.item, (object) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {43, 127, 0, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00246([In] ItemStack obj0)
    {
      obj0.amount = Math.max(obj0.amount - this.step(obj0.amount), 0);
      this.updater.run();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {48, 127, 5, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00247([In] ItemStack obj0)
    {
      obj0.amount = Math.min(obj0.amount + this.step(obj0.amount), this.capacity);
      this.updater.run();
    }

    [Modifiers]
    [LineNumberTable(102)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00249([In] ItemStack obj0) => Vars.ui.showTextInput("@configure", obj0.item.localizedName, 10, new StringBuilder().append(obj0.amount).append("").toString(), true, (Cons) new LoadoutDialog.__\u003C\u003EAnon18(this, obj0));

    [Modifiers]
    [LineNumberTable(115)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024setup\u002410([In] ItemStack obj0)
    {
      object obj = (object) new StringBuilder().append(obj0.amount).append("").toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {53, 104, 103, 109, 103, 107, 161, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00248([In] ItemStack obj0, [In] string obj1)
    {
      if (Strings.canParsePositiveInt(obj1))
      {
        int num = Strings.parseInt(obj1);
        if (num >= 0 && num <= this.capacity)
        {
          obj0.amount = num;
          this.updater.run();
          return;
        }
      }
      Vars.ui.showInfo(Core.bundle.format("configure.invalid", (object) Integer.valueOf(this.capacity)));
    }

    [Modifiers]
    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00243([In] ItemStack obj0) => obj0.amount > 0;

    [HideFromJava]
    static LoadoutDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (LoadoutDialog.lambda\u0024new\u00240((Item) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly LoadoutDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] LoadoutDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00241((KeyCode) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly LoadoutDialog arg\u00241;

      internal __\u003C\u003EAnon2([In] LoadoutDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00242((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly LoadoutDialog arg\u00241;

      internal __\u003C\u003EAnon3([In] LoadoutDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly LoadoutDialog arg\u00241;

      internal __\u003C\u003EAnon4([In] LoadoutDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00244();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly LoadoutDialog arg\u00241;

      internal __\u003C\u003EAnon5([In] LoadoutDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly LoadoutDialog arg\u00241;

      internal __\u003C\u003EAnon6([In] LoadoutDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.maxItems();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly LoadoutDialog arg\u00241;

      internal __\u003C\u003EAnon7([In] LoadoutDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00245();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      private readonly LoadoutDialog arg\u00241;
      private readonly ItemStack arg\u00242;
      private readonly float arg\u00243;

      internal __\u003C\u003EAnon8([In] LoadoutDialog obj0, [In] ItemStack obj1, [In] float obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u002411(this.arg\u00242, this.arg\u00243, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Func
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public object get([In] object obj0) => (object) ((ItemStack) obj0).copy();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Boolf
    {
      private readonly LoadoutDialog arg\u00241;

      internal __\u003C\u003EAnon10([In] LoadoutDialog obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024reseed\u002413((Item) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Func
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public object get([In] object obj0) => (object) LoadoutDialog.lambda\u0024reseed\u002414((Item) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Intf
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public int get([In] object obj0) => LoadoutDialog.lambda\u0024reseed\u002415((ItemStack) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Boolf
    {
      private readonly Item arg\u00241;

      internal __\u003C\u003EAnon13([In] Item obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (LoadoutDialog.lambda\u0024reseed\u002412(this.arg\u00241, (ItemStack) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      private readonly LoadoutDialog arg\u00241;
      private readonly ItemStack arg\u00242;

      internal __\u003C\u003EAnon14([In] LoadoutDialog obj0, [In] ItemStack obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00246(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Runnable
    {
      private readonly LoadoutDialog arg\u00241;
      private readonly ItemStack arg\u00242;

      internal __\u003C\u003EAnon15([In] LoadoutDialog obj0, [In] ItemStack obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00247(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly LoadoutDialog arg\u00241;
      private readonly ItemStack arg\u00242;

      internal __\u003C\u003EAnon16([In] LoadoutDialog obj0, [In] ItemStack obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00249(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Prov
    {
      private readonly ItemStack arg\u00241;

      internal __\u003C\u003EAnon17([In] ItemStack obj0) => this.arg\u00241 = obj0;

      public object get() => (object) LoadoutDialog.lambda\u0024setup\u002410(this.arg\u00241).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Cons
    {
      private readonly LoadoutDialog arg\u00241;
      private readonly ItemStack arg\u00242;

      internal __\u003C\u003EAnon18([In] LoadoutDialog obj0, [In] ItemStack obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u00248(this.arg\u00242, (string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Boolf
    {
      internal __\u003C\u003EAnon19()
      {
      }

      public bool get([In] object obj0) => (LoadoutDialog.lambda\u0024new\u00243((ItemStack) obj0) ? 1 : 0) != 0;
    }
  }
}
