// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.values.BlockFilterValue
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
  public class BlockFilterValue : Object, StatValue
  {
    [Signature("Larc/func/Boolf<Lmindustry/world/Block;>;")]
    internal Boolf __\u003C\u003Epred;

    [Signature("(Larc/func/Boolf<Lmindustry/world/Block;>;)V")]
    [LineNumberTable(new byte[] {159, 157, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BlockFilterValue(Boolf pred)
    {
      BlockFilterValue blockFilterValue = this;
      this.__\u003C\u003Epred = pred;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 166, 135, 110, 141, 127, 37, 127, 23, 111, 231, 58, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024display\u00240([In] Seq obj0, [In] Table obj1)
    {
      obj1.left();
      for (int index = 0; index < obj0.size; ++index)
      {
        Block block = (Block) obj0.get(index);
        obj1.image(block.icon(Cicon.__\u003C\u003Esmall)).size(24f).padRight(2f).padLeft(2f).padTop(3f).padBottom(3f);
        Table table = obj1;
        object localizedName = (object) block.localizedName;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) localizedName;
        CharSequence text = charSequence;
        table.add(text).left().padLeft(1f).padRight(4f);
        int num1 = index;
        int num2 = 5;
        if ((num2 != -1 ? num1 % num2 : 0) == 4)
          obj1.row();
      }
    }

    [LineNumberTable(new byte[] {159, 163, 150, 242, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table)
    {
      Seq seq = Vars.content.blocks().select(this.__\u003C\u003Epred);
      table.table((Cons) new BlockFilterValue.__\u003C\u003EAnon0(seq));
    }

    [Modifiers]
    public Boolf pred
    {
      [HideFromJava] get => this.__\u003C\u003Epred;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Epred = value;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly Seq arg\u00241;

      internal __\u003C\u003EAnon0([In] Seq obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => BlockFilterValue.lambda\u0024display\u00240(this.arg\u00241, (Table) obj0);
    }
  }
}
