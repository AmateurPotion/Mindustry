// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.ItemSelection
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

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
using mindustry.ctype;
using mindustry.gen;
using mindustry.ui;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks
{
  public class ItemSelection : Object
  {
    private static float scrollPos;

    [Signature("<T:Lmindustry/ctype/UnlockableContent;>(Larc/scene/ui/layout/Table;Larc/struct/Seq<TT;>;Larc/func/Prov<TT;>;Larc/func/Cons<TT;>;Z)V")]
    [LineNumberTable(new byte[] {159, 137, 163, 102, 103, 102, 145, 130, 127, 3, 139, 159, 2, 113, 118, 125, 151, 115, 135, 165, 110, 112, 105, 44, 232, 69, 114, 105, 108, 212, 105, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void buildTable(
      Table table,
      Seq items,
      Prov holder,
      Cons consumer,
      bool closeSelect)
    {
      int num1 = closeSelect ? 1 : 0;
      ButtonGroup group = new ButtonGroup();
      group.setMinCheckCount(0);
      Table table1 = new Table();
      table1.defaults().size(40f);
      int num2 = 0;
      Iterator iterator = items.iterator();
      while (iterator.hasNext())
      {
        UnlockableContent unlockableContent = (UnlockableContent) iterator.next();
        if (unlockableContent.unlockedNow())
        {
          ImageButton imageButton = (ImageButton) table1.button((Drawable) Tex.whiteui, Styles.clearToggleTransi, 24f, (Runnable) new ItemSelection.__\u003C\u003EAnon0(num1 != 0)).group(group).get();
          imageButton.changed((Runnable) new ItemSelection.__\u003C\u003EAnon1(consumer, imageButton, unlockableContent));
          imageButton.getStyle().imageUp = (Drawable) new TextureRegionDrawable(unlockableContent.icon(Cicon.__\u003C\u003Esmall));
          imageButton.update((Runnable) new ItemSelection.__\u003C\u003EAnon2(imageButton, holder, unlockableContent));
          int num3 = num2;
          ++num2;
          int num4 = 4;
          if ((num4 != -1 ? num3 % num4 : 0) == 3)
            table1.row();
        }
      }
      int num5 = num2;
      int num6 = 4;
      if ((num6 != -1 ? num5 % num6 : 0) != 0)
      {
        int num3 = num2;
        int num4 = 4;
        int num7 = 4 - (num4 != -1 ? num3 % num4 : 0);
        for (int index = 0; index < num7; ++index)
          table1.image(Styles.black6);
      }
      ScrollPane.__\u003Cclinit\u003E();
      ScrollPane scrollPane = new ScrollPane((Element) table1, Styles.smallPane);
      scrollPane.setScrollingDisabled(true, false);
      scrollPane.setScrollYForce(ItemSelection.scrollPos);
      scrollPane.update((Runnable) new ItemSelection.__\u003C\u003EAnon3(scrollPane));
      scrollPane.setOverscroll(false, false);
      table.add((Element) scrollPane).maxHeight(Scl.scl(200f));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 134, 130, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024buildTable\u00240([In] bool obj0)
    {
      if (!obj0)
        return;
      Vars.control.input.__\u003C\u003Efrag.__\u003C\u003Econfig.hideConfig();
    }

    [Modifiers]
    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024buildTable\u00241(
      [In] Cons obj0,
      [In] ImageButton obj1,
      [In] UnlockableContent obj2)
    {
      obj0.get(!obj1.isChecked() ? (object) (UnlockableContent) null : (object) obj2);
    }

    [Modifiers]
    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024buildTable\u00242(
      [In] ImageButton obj0,
      [In] Prov obj1,
      [In] UnlockableContent obj2)
    {
      obj0.setChecked(object.ReferenceEquals(obj1.get(), (object) obj2));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {7, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024buildTable\u00243([In] ScrollPane obj0) => ItemSelection.scrollPos = obj0.getScrollY();

    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemSelection()
    {
    }

    [Signature("<T:Lmindustry/ctype/UnlockableContent;>(Larc/scene/ui/layout/Table;Larc/struct/Seq<TT;>;Larc/func/Prov<TT;>;Larc/func/Cons<TT;>;)V")]
    [LineNumberTable(new byte[] {159, 160, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void buildTable(Table table, Seq items, Prov holder, Cons consumer) => ItemSelection.buildTable(table, items, holder, consumer, true);

    [MethodImpl(MethodImplOptions.NoInlining)]
    static ItemSelection()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.blocks.ItemSelection"))
        return;
      ItemSelection.scrollPos = 0.0f;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly bool arg\u00241;

      internal __\u003C\u003EAnon0([In] bool obj0) => this.arg\u00241 = obj0;

      public void run() => ItemSelection.lambda\u0024buildTable\u00240(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly Cons arg\u00241;
      private readonly ImageButton arg\u00242;
      private readonly UnlockableContent arg\u00243;

      internal __\u003C\u003EAnon1([In] Cons obj0, [In] ImageButton obj1, [In] UnlockableContent obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => ItemSelection.lambda\u0024buildTable\u00241(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly ImageButton arg\u00241;
      private readonly Prov arg\u00242;
      private readonly UnlockableContent arg\u00243;

      internal __\u003C\u003EAnon2([In] ImageButton obj0, [In] Prov obj1, [In] UnlockableContent obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => ItemSelection.lambda\u0024buildTable\u00242(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly ScrollPane arg\u00241;

      internal __\u003C\u003EAnon3([In] ScrollPane obj0) => this.arg\u00241 = obj0;

      public void run() => ItemSelection.lambda\u0024buildTable\u00243(this.arg\u00241);
    }
  }
}
