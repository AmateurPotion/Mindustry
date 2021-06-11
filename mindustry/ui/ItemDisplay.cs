// Decompiled with JetBrains decompiler
// Type: mindustry.ui.ItemDisplay
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui
{
  public class ItemDisplay : Table
  {
    internal Item __\u003C\u003Eitem;
    internal int __\u003C\u003Eamount;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemDisplay(Item item, int amount)
      : this(item, amount, true)
    {
    }

    [LineNumberTable(new byte[] {159, 139, 162, 104, 120, 159, 25, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemDisplay(Item item, int amount, bool showName)
    {
      int num = showName ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      ItemDisplay itemDisplay = this;
      ItemImage.__\u003Cclinit\u003E();
      this.add((Element) new ItemImage(new ItemStack(item, amount)));
      if (num != 0)
      {
        object localizedName = (object) item.localizedName;
        CharSequence text;
        text.__\u003Cref\u003E = (__Null) localizedName;
        this.add(text).padLeft(4 + amount <= 99 ? 0.0f : 4f);
      }
      this.__\u003C\u003Eitem = item;
      this.__\u003C\u003Eamount = amount;
    }

    [LineNumberTable(new byte[] {159, 154, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemDisplay(Item item)
      : this(item, 0)
    {
    }

    [HideFromJava]
    static ItemDisplay() => Table.__\u003Cclinit\u003E();

    [Modifiers]
    public Item item
    {
      [HideFromJava] get => this.__\u003C\u003Eitem;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eitem = value;
    }

    [Modifiers]
    public int amount
    {
      [HideFromJava] get => this.__\u003C\u003Eamount;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eamount = value;
    }
  }
}
