// Decompiled with JetBrains decompiler
// Type: mindustry.ui.ItemImage
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics.g2d;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using mindustry.core;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui
{
  public class ItemImage : Stack
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 174, 136, 251, 69, 104, 251, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemImage(ItemStack stack)
    {
      ItemImage itemImage = this;
      Table.__\u003Cclinit\u003E();
      this.add((Element) new Table((Cons) new ItemImage.__\u003C\u003EAnon2(stack)));
      if (stack.amount == 0)
        return;
      Table.__\u003Cclinit\u003E();
      this.add((Element) new Table((Cons) new ItemImage.__\u003C\u003EAnon3(stack)));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 156, 103, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] TextureRegion obj0, [In] Table obj1)
    {
      obj1.left();
      obj1.add((Element) new Image(obj0)).size(32f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 161, 108, 127, 34, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00241([In] int obj0, [In] Table obj1)
    {
      obj1.left().bottom();
      Table table = obj1;
      object obj = obj0 <= 1000 ? (object) new StringBuilder().append(obj0).append("").toString() : (object) UI.formatAmount(obj0);
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text);
      obj1.pack();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 177, 103, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00242([In] ItemStack obj0, [In] Table obj1)
    {
      obj1.left();
      obj1.add((Element) new Image(obj0.item.icon(Cicon.__\u003C\u003Emedium))).size(32f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 183, 108, 127, 59, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00243([In] ItemStack obj0, [In] Table obj1)
    {
      obj1.left().bottom();
      Table table = obj1;
      object obj = obj0.amount <= 1000 ? (object) new StringBuilder().append(obj0.amount).append("").toString() : (object) UI.formatAmount(obj0.amount);
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).style((Style) Styles.outlineLabel);
      obj1.pack();
    }

    [LineNumberTable(new byte[] {159, 153, 136, 251, 69, 251, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemImage(TextureRegion region, int amount)
    {
      ItemImage itemImage = this;
      Table.__\u003Cclinit\u003E();
      this.add((Element) new Table((Cons) new ItemImage.__\u003C\u003EAnon0(region)));
      Table.__\u003Cclinit\u003E();
      this.add((Element) new Table((Cons) new ItemImage.__\u003C\u003EAnon1(amount)));
    }

    [LineNumberTable(new byte[] {159, 167, 104, 144, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemImage(TextureRegion region)
    {
      ItemImage itemImage = this;
      Table table = new Table().left().bottom();
      this.add((Element) new Image(region));
      this.add((Element) table);
    }

    [HideFromJava]
    static ItemImage() => Stack.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly TextureRegion arg\u00241;

      internal __\u003C\u003EAnon0([In] TextureRegion obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => ItemImage.lambda\u0024new\u00240(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly int arg\u00241;

      internal __\u003C\u003EAnon1([In] int obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => ItemImage.lambda\u0024new\u00241(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly ItemStack arg\u00241;

      internal __\u003C\u003EAnon2([In] ItemStack obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => ItemImage.lambda\u0024new\u00242(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly ItemStack arg\u00241;

      internal __\u003C\u003EAnon3([In] ItemStack obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => ItemImage.lambda\u0024new\u00243(this.arg\u00241, (Table) obj0);
    }
  }
}
