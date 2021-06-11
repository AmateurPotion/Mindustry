// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.storage.StorageBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.gen;
using mindustry.type;
using mindustry.world.meta;
using mindustry.world.modules;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.storage
{
  public class StorageBlock : Block
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 160, 105, 103, 103, 103, 103, 107, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StorageBlock(string name)
      : base(name)
    {
      StorageBlock storageBlock = this;
      this.hasItems = true;
      this.solid = true;
      this.update = false;
      this.destructible = true;
      this.group = BlockGroup.__\u003C\u003Etransportation;
      this.flags = EnumSet.of((Enum[]) new BlockFlag[1]
      {
        BlockFlag.__\u003C\u003Estorage
      });
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => false;

    [LineNumberTable(new byte[] {159, 175, 112, 104, 104, 102, 191, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void incinerateEffect(Building self, Building source)
    {
      if (!Mathf.chance(0.3))
        return;
      Tile facingEdge1 = Edges.getFacingEdge(source, self);
      Tile facingEdge2 = Edges.getFacingEdge(self, source);
      if (facingEdge1 == null || facingEdge2 == null)
        return;
      Fx.__\u003C\u003EcoreBurn.at((facingEdge1.worldx() + facingEdge2.worldx()) / 2f, (facingEdge1.worldy() + facingEdge2.worldy()) / 2f);
    }

    [HideFromJava]
    static StorageBlock() => Block.__\u003Cclinit\u003E();

    public class StorageBuild : Building
    {
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      protected internal Building linkedCore;
      [Modifiers]
      internal StorageBlock this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(83)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int getMaximumAccepted(Item item) => this.this\u00240.itemCapacity;

      [Modifiers]
      [LineNumberTable(103)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024overwrote\u00240([In] Item obj0, [In] int obj1) => this.items.set(obj0, Math.min(obj1, this.this\u00240.itemCapacity));

      [LineNumberTable(42)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public StorageBuild(StorageBlock _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(47)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item)
      {
        if (this.linkedCore != null)
          return this.linkedCore.acceptItem(source, item);
        return this.items.get(item) < this.getMaximumAccepted(item);
      }

      [LineNumberTable(new byte[] {2, 104, 127, 4, 135, 113, 143, 136})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleItem(Building source, Item item)
      {
        if (this.linkedCore != null)
        {
          if (this.linkedCore.items.get(item) >= ((CoreBlock.CoreBuild) this.linkedCore).storageCapacity)
            StorageBlock.incinerateEffect((Building) this, source);
          ((CoreBlock.CoreBuild) this.linkedCore).noEffect = true;
          this.linkedCore.handleItem(source, item);
        }
        else
          base.handleItem(source, item);
      }

      [LineNumberTable(new byte[] {15, 104, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void itemTaken(Item item)
      {
        if (this.linkedCore == null)
          return;
        this.linkedCore.itemTaken(item);
      }

      [LineNumberTable(new byte[] {22, 137, 127, 17, 188})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int removeStack(Item item, int amount)
      {
        int num = base.removeStack(item, amount);
        if (this.linkedCore != null && object.ReferenceEquals((object) this.team, (object) Vars.state.rules.defaultTeam) && Vars.state.isCampaign())
          Vars.state.rules.sector.info.handleCoreItem(item, -num);
        return num;
      }

      [LineNumberTable(new byte[] {38, 104, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawSelect()
      {
        if (this.linkedCore == null)
          return;
        this.linkedCore.drawSelect();
      }

      [Signature("(Larc/struct/Seq<Lmindustry/gen/Building;>;)V")]
      [LineNumberTable(new byte[] {46, 107, 123, 123, 145, 130, 150})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void overwrote(Seq previous)
      {
        if (this.linkedCore != null)
          return;
        Iterator iterator = previous.iterator();
        while (iterator.hasNext())
        {
          Building building = (Building) iterator.next();
          if (building.items != null && !object.ReferenceEquals((object) building.items, (object) this.items))
            this.items.add(building.items);
        }
        this.items.each((ItemModule.ItemConsumer) new StorageBlock.StorageBuild.__\u003C\u003EAnon0(this));
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool canPickup() => this.linkedCore == null;

      [HideFromJava]
      static StorageBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : ItemModule.ItemConsumer
      {
        private readonly StorageBlock.StorageBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] StorageBlock.StorageBuild obj0) => this.arg\u00241 = obj0;

        public void accept([In] Item obj0, [In] int obj1) => this.arg\u00241.lambda\u0024overwrote\u00240(obj0, obj1);
      }
    }
  }
}
