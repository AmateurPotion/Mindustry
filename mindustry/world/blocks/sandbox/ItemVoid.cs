// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.sandbox.ItemVoid
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.gen;
using mindustry.type;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.sandbox
{
  public class ItemVoid : Block
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 153, 105, 107, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemVoid(string name)
      : base(name)
    {
      ItemVoid itemVoid1 = this;
      this.group = BlockGroup.__\u003C\u003Etransportation;
      ItemVoid itemVoid2 = this;
      ItemVoid itemVoid3 = this;
      int num1 = 1;
      int num2 = num1;
      this.acceptsItems = num1 != 0;
      int num3 = num2;
      int num4 = num3;
      this.solid = num3 != 0;
      this.update = num4 != 0;
    }

    [HideFromJava]
    static ItemVoid() => Block.__\u003Cclinit\u003E();

    public class ItemVoidBuild : Building
    {
      [Modifiers]
      internal ItemVoid this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(16)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ItemVoidBuild(ItemVoid _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleItem(Building source, Item item)
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => this.enabled;

      [HideFromJava]
      static ItemVoidBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
