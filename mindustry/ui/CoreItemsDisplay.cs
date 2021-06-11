// Decompiled with JetBrains decompiler
// Type: mindustry.ui.CoreItemsDisplay
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.core;
using mindustry.type;
using mindustry.world.blocks.storage;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui
{
  public class CoreItemsDisplay : Table
  {
    [Modifiers]
    [Signature("Larc/struct/ObjectSet<Lmindustry/type/Item;>;")]
    private ObjectSet usedItems;
    private CoreBlock.CoreBuild core;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 167, 102, 108, 140, 242, 72, 130, 127, 8, 110, 156, 159, 3, 114, 167, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void rebuild()
    {
      this.clear();
      this.background(Styles.black6);
      this.margin(4f);
      this.update((Runnable) new CoreItemsDisplay.__\u003C\u003EAnon0(this));
      int num1 = 0;
      Iterator iterator = Vars.content.items().iterator();
      while (iterator.hasNext())
      {
        Item obj = (Item) iterator.next();
        if (this.usedItems.contains((object) obj))
        {
          this.image(obj.icon(Cicon.__\u003C\u003Esmall)).padRight(3f);
          this.label((Prov) new CoreItemsDisplay.__\u003C\u003EAnon1(this, obj)).padRight(3f).left();
          ++num1;
          int num2 = num1;
          int num3 = 4;
          if ((num3 != -1 ? num2 % num3 : 0) == 0)
            this.row();
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 172, 149, 124, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuild\u00241()
    {
      this.core = Vars.player.team().core();
      if (!Vars.content.items().contains((Boolf) new CoreItemsDisplay.__\u003C\u003EAnon2(this)))
        return;
      this.rebuild();
    }

    [Modifiers]
    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private CharSequence lambda\u0024rebuild\u00242([In] Item obj0)
    {
      object obj = this.core != null ? (object) UI.formatAmount(this.core.items.get(obj0)) : (object) "0";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024rebuild\u00240([In] Item obj0) => this.core != null && this.core.items.get(obj0) > 0 && this.usedItems.add((object) obj0);

    [LineNumberTable(new byte[] {159, 158, 232, 61, 203, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CoreItemsDisplay()
    {
      CoreItemsDisplay coreItemsDisplay = this;
      this.usedItems = new ObjectSet();
      this.rebuild();
    }

    [LineNumberTable(new byte[] {159, 163, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resetUsed() => this.usedItems.clear();

    [HideFromJava]
    static CoreItemsDisplay() => Table.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly CoreItemsDisplay arg\u00241;

      internal __\u003C\u003EAnon0([In] CoreItemsDisplay obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024rebuild\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Prov
    {
      private readonly CoreItemsDisplay arg\u00241;
      private readonly Item arg\u00242;

      internal __\u003C\u003EAnon1([In] CoreItemsDisplay obj0, [In] Item obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) this.arg\u00241.lambda\u0024rebuild\u00242(this.arg\u00242).__\u003Cref\u003E;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Boolf
    {
      private readonly CoreItemsDisplay arg\u00241;

      internal __\u003C\u003EAnon2([In] CoreItemsDisplay obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024rebuild\u00240((Item) obj0) ? 1 : 0) != 0;
    }
  }
}
