// Decompiled with JetBrains decompiler
// Type: mindustry.ui.ItemsDisplay
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.math;
using arc.scene;
using arc.scene.actions;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.core;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui
{
  public class ItemsDisplay : Table
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rebuild(ItemSeq items) => this.rebuild(items, (bool[]) null);

    [LineNumberTable(new byte[] {159, 170, 102, 108, 140, 248, 94})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rebuild(ItemSeq items, [Nullable(new object[] {64, "Larc/util/Nullable;"})] bool[] shine)
    {
      this.clear();
      this.top().left();
      this.margin(0.0f);
      this.table((Drawable) Tex.button, (Cons) new ItemsDisplay.__\u003C\u003EAnon0(items, shine));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 175, 127, 1, 108, 135, 252, 80, 134, 191, 29, 127, 5, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u00243([In] ItemSeq obj0, [In] bool[] obj1, [In] Table obj2)
    {
      obj2.margin(10f).marginLeft(12f).marginTop(15f);
      obj2.marginRight(12f);
      obj2.left();
      Collapser.__\u003Cclinit\u003E();
      Collapser collapser1 = new Collapser((Cons) new ItemsDisplay.__\u003C\u003EAnon1(obj0, obj1), false).setDuration(0.3f);
      Table table = obj2;
      TextureRegionDrawable downOpen = Icon.downOpen;
      TextButton.TextButtonStyle clearTogglet = Styles.clearTogglet;
      Collapser collapser2 = collapser1;
      Objects.requireNonNull((object) collapser2);
      Runnable clicked = (Runnable) new ItemsDisplay.__\u003C\u003EAnon2(collapser2);
      table.button("@globalitems", (Drawable) downOpen, clearTogglet, clicked).update((Cons) new ItemsDisplay.__\u003C\u003EAnon3(collapser1)).padBottom(4f).left().fillX().margin(12f).minWidth(200f);
      obj2.row();
      obj2.add((Element) collapser1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {3, 237, 48, 229, 80})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u00241([In] ItemSeq obj0, [In] bool[] obj1, [In] Table obj2) => ((ScrollPane) obj2.pane((Cons) new ItemsDisplay.__\u003C\u003EAnon4(obj0, obj1)).get()).setScrollingDisabled(true, false);

    [Modifiers]
    [LineNumberTable(new byte[] {6, 108, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u00242([In] Collapser obj0, [In] TextButton obj1)
    {
      obj1.setChecked(obj0.isCollapsed());
      ((Image) obj1.getChildren().get(1)).setDrawable(!obj0.isCollapsed() ? (Drawable) Icon.downOpen : (Drawable) Icon.upOpen);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 180, 108, 103, 127, 8, 139, 127, 20, 127, 17, 127, 13, 135, 109, 108, 159, 5, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u00240([In] ItemSeq obj0, [In] bool[] obj1, [In] Table obj2)
    {
      obj2.marginRight(30f);
      obj2.left();
      Iterator iterator = Vars.content.items().iterator();
      while (iterator.hasNext())
      {
        Item obj3 = (Item) iterator.next();
        if (obj0.has(obj3))
        {
          Table table1 = obj2;
          object obj4 = (object) UI.formatAmount(obj0.get(obj3));
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) obj4;
          CharSequence text1 = charSequence;
          Label label = (Label) table1.add(text1).left().get();
          obj2.image(obj3.icon(Cicon.__\u003C\u003Esmall)).size(24f).padLeft(4f).padRight(4f);
          Table table2 = obj2;
          object localizedName = (object) obj3.localizedName;
          charSequence.__\u003Cref\u003E = (__Null) localizedName;
          CharSequence text2 = charSequence;
          table2.add(text2).color(Color.__\u003C\u003ElightGray).left();
          obj2.row();
          if (obj1 != null && obj1[(int) obj3.__\u003C\u003Eid])
          {
            label.setColor(Pal.accent);
            label.actions((Action) Actions.color(Color.__\u003C\u003Ewhite, 0.75f, Interp.fade));
          }
        }
      }
    }

    [LineNumberTable(new byte[] {159, 161, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemsDisplay()
    {
      ItemsDisplay itemsDisplay = this;
      this.rebuild(new ItemSeq());
    }

    [HideFromJava]
    static ItemsDisplay() => Table.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly ItemSeq arg\u00241;
      private readonly bool[] arg\u00242;

      internal __\u003C\u003EAnon0([In] ItemSeq obj0, [In] bool[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => ItemsDisplay.lambda\u0024rebuild\u00243(this.arg\u00241, this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly ItemSeq arg\u00241;
      private readonly bool[] arg\u00242;

      internal __\u003C\u003EAnon1([In] ItemSeq obj0, [In] bool[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => ItemsDisplay.lambda\u0024rebuild\u00241(this.arg\u00241, this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly Collapser arg\u00241;

      internal __\u003C\u003EAnon2([In] Collapser obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.toggle();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly Collapser arg\u00241;

      internal __\u003C\u003EAnon3([In] Collapser obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => ItemsDisplay.lambda\u0024rebuild\u00242(this.arg\u00241, (TextButton) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly ItemSeq arg\u00241;
      private readonly bool[] arg\u00242;

      internal __\u003C\u003EAnon4([In] ItemSeq obj0, [In] bool[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => ItemsDisplay.lambda\u0024rebuild\u00240(this.arg\u00241, this.arg\u00242, (Table) obj0);
    }
  }
}
