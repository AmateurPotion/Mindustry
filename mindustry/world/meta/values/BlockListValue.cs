// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.values.BlockListValue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using mindustry.ui;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.meta.values
{
  public class BlockListValue : Object, StatValue
  {
    [Signature("Larc/struct/Seq<Lmindustry/world/Block;>;")]
    internal Seq __\u003C\u003Elist;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 162, 135, 115, 146, 127, 37, 127, 23, 111, 231, 58, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00240([In] Table obj0)
    {
      obj0.left();
      for (int index = 0; index < this.__\u003C\u003Elist.size; ++index)
      {
        Block block = (Block) this.__\u003C\u003Elist.get(index);
        obj0.image(block.icon(Cicon.__\u003C\u003Esmall)).size(24f).padRight(2f).padLeft(2f).padTop(3f).padBottom(3f);
        Table table = obj0;
        object localizedName = (object) block.localizedName;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) localizedName;
        CharSequence text = charSequence;
        table.add(text).left().padLeft(1f).padRight(4f);
        int num1 = index;
        int num2 = 5;
        if ((num2 != -1 ? num1 % num2 : 0) == 4)
          obj0.row();
      }
    }

    [Signature("(Larc/struct/Seq<Lmindustry/world/Block;>;)V")]
    [LineNumberTable(new byte[] {159, 154, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BlockListValue(Seq list)
    {
      BlockListValue blockListValue = this;
      this.__\u003C\u003Elist = list;
    }

    [LineNumberTable(new byte[] {159, 161, 242, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table) => table.table((Cons) new BlockListValue.__\u003C\u003EAnon0(this));

    [Modifiers]
    public Seq list
    {
      [HideFromJava] get => this.__\u003C\u003Elist;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Elist = value;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly BlockListValue arg\u00241;

      internal __\u003C\u003EAnon0([In] BlockListValue obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u00240((Table) obj0);
    }
  }
}
