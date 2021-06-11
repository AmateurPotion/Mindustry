// Decompiled with JetBrains decompiler
// Type: mindustry.world.consumers.ConsumeItemFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.scene;
using arc.scene.ui.layout;
using IKVM.Attributes;
using mindustry.gen;
using mindustry.type;
using mindustry.ui;
using mindustry.world.meta;
using mindustry.world.meta.values;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.consumers
{
  public class ConsumeItemFilter : Consume
  {
    [Signature("Larc/func/Boolf<Lmindustry/type/Item;>;")]
    internal Boolf __\u003C\u003Efilter;

    [Signature("(Larc/func/Boolf<Lmindustry/type/Item;>;)V")]
    [LineNumberTable(new byte[] {159, 159, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConsumeItemFilter(Boolf item)
    {
      ConsumeItemFilter consumeItemFilter = this;
      this.__\u003C\u003Efilter = item;
    }

    [Modifiers]
    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024applyItemFilter\u00240([In] Bits obj0, [In] Item obj1) => obj0.set((int) obj1.__\u003C\u003Eid);

    [Modifiers]
    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u00241([In] Item obj0) => this.__\u003C\u003Efilter.get((object) obj0) && obj0.unlockedNow();

    [Modifiers]
    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u00243([In] MultiReqImage obj0, [In] Building obj1, [In] Item obj2)
    {
      MultiReqImage multiReqImage = obj0;
      ReqImage.__\u003Cclinit\u003E();
      ItemImage.__\u003Cclinit\u003E();
      ReqImage display = new ReqImage((Element) new ItemImage(obj2.icon(Cicon.__\u003C\u003Emedium), 1), (Boolp) new ConsumeItemFilter.__\u003C\u003EAnon3(obj1, obj2));
      multiReqImage.add(display);
    }

    [Modifiers]
    [LineNumberTable(35)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024build\u00242([In] Building obj0, [In] Item obj1) => obj0.items != null && obj0.items.has(obj1);

    [LineNumberTable(new byte[] {159, 165, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void applyItemFilter(Bits arr) => Vars.content.items().each(this.__\u003C\u003Efilter, (Cons) new ConsumeItemFilter.__\u003C\u003EAnon0(arr));

    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ConsumeType type() => ConsumeType.__\u003C\u003Eitem;

    [LineNumberTable(new byte[] {159, 175, 102, 191, 7, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void build(Building tile, Table table)
    {
      MultiReqImage multiReqImage = new MultiReqImage();
      Vars.content.items().each((Boolf) new ConsumeItemFilter.__\u003C\u003EAnon1(this), (Cons) new ConsumeItemFilter.__\u003C\u003EAnon2(multiReqImage, tile));
      table.add((Element) multiReqImage).size(32f);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getIcon() => "icon-item";

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Building entity)
    {
    }

    [LineNumberTable(new byte[] {2, 116, 108, 127, 5, 109, 226, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void trigger(Building entity)
    {
      for (int id = 0; id < Vars.content.items().size; ++id)
      {
        Item obj = Vars.content.item(id);
        if (entity.items != null && entity.items.has(obj) && this.__\u003C\u003Efilter.get((object) obj))
        {
          entity.items.remove(obj, 1);
          break;
        }
      }
    }

    [LineNumberTable(new byte[] {13, 116, 108, 127, 5, 226, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool valid(Building entity)
    {
      for (int id = 0; id < Vars.content.items().size; ++id)
      {
        Item obj = Vars.content.item(id);
        if (entity.items != null && entity.items.has(obj) && this.__\u003C\u003Efilter.get((object) obj))
          return true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {24, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void display(Stats stats) => stats.add(!this.booster ? Stat.__\u003C\u003Einput : Stat.__\u003C\u003Ebooster, (StatValue) new ItemFilterValue(this.__\u003C\u003Efilter));

    [Modifiers]
    public Boolf filter
    {
      [HideFromJava] get => this.__\u003C\u003Efilter;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Efilter = value;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly Bits arg\u00241;

      internal __\u003C\u003EAnon0([In] Bits obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => ConsumeItemFilter.lambda\u0024applyItemFilter\u00240(this.arg\u00241, (Item) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      private readonly ConsumeItemFilter arg\u00241;

      internal __\u003C\u003EAnon1([In] ConsumeItemFilter obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024build\u00241((Item) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly MultiReqImage arg\u00241;
      private readonly Building arg\u00242;

      internal __\u003C\u003EAnon2([In] MultiReqImage obj0, [In] Building obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => ConsumeItemFilter.lambda\u0024build\u00243(this.arg\u00241, this.arg\u00242, (Item) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolp
    {
      private readonly Building arg\u00241;
      private readonly Item arg\u00242;

      internal __\u003C\u003EAnon3([In] Building obj0, [In] Item obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get() => (ConsumeItemFilter.lambda\u0024build\u00242(this.arg\u00241, this.arg\u00242) ? 1 : 0) != 0;
    }
  }
}
