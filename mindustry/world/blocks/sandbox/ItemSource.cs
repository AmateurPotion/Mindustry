// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.sandbox.ItemSource
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics.g2d;
using arc.scene.ui.layout;
using arc.util;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.type;
using mindustry.world.meta;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.sandbox
{
  public class ItemSource : Block
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] ItemSource.ItemSourceBuild obj0, [In] Item obj1) => obj0.outputItem = obj1;

    [Modifiers]
    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00241([In] ItemSource.ItemSourceBuild obj0) => obj0.outputItem = (Item) null;

    [LineNumberTable(new byte[] {159, 161, 105, 103, 103, 103, 107, 103, 103, 135, 117, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemSource(string name)
      : base(name)
    {
      ItemSource itemSource = this;
      this.hasItems = true;
      this.update = true;
      this.solid = true;
      this.group = BlockGroup.__\u003C\u003Etransportation;
      this.configurable = true;
      this.saveConfig = true;
      this.noUpdateDisabled = true;
      this.config((Class) ClassLiteral<Item>.Value, (Cons2) new ItemSource.__\u003C\u003EAnon0());
      this.configClear((Cons) new ItemSource.__\u003C\u003EAnon1());
    }

    [LineNumberTable(new byte[] {159, 176, 102, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.remove("items");
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {159, 182, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestConfig(BuildPlan req, Eachable list) => this.drawRequestConfigCenter(req, req.config, "center", true);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => true;

    [HideFromJava]
    static ItemSource() => Block.__\u003Cclinit\u003E();

    public class ItemSourceBuild : Building
    {
      internal Item outputItem;
      [Modifiers]
      internal ItemSource this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Item config() => this.outputItem;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Item lambda\u0024buildConfiguration\u00240() => this.outputItem;

      [LineNumberTable(48)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ItemSourceBuild(ItemSource _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {3, 134, 104, 152, 112, 118, 133})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        if (this.outputItem == null)
        {
          Draw.rect("cross", this.x, this.y);
        }
        else
        {
          Draw.color(this.outputItem.color);
          Draw.rect("center", this.x, this.y);
          Draw.color();
        }
      }

      [LineNumberTable(new byte[] {16, 137, 114, 109, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (this.outputItem == null)
          return;
        this.items.set(this.outputItem, 1);
        this.dump(this.outputItem);
        this.items.set(this.outputItem, 0);
      }

      [LineNumberTable(new byte[] {25, 127, 7})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void buildConfiguration(Table table) => ItemSelection.buildTable(table, Vars.content.items(), (Prov) new ItemSource.ItemSourceBuild.__\u003C\u003EAnon0(this), (Cons) new ItemSource.ItemSourceBuild.__\u003C\u003EAnon1(this));

      [LineNumberTable(new byte[] {30, 105, 102, 103, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool onConfigureTileTapped(Building other)
      {
        if (!object.ReferenceEquals((object) this, (object) other))
          return true;
        this.deselect();
        this.configure((object) null);
        return false;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => false;

      [LineNumberTable(new byte[] {51, 103, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.s(this.outputItem != null ? (int) this.outputItem.__\u003C\u003Eid : -1);
      }

      [LineNumberTable(new byte[] {159, 116, 163, 104, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.outputItem = Vars.content.item((int) read.s());
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(48)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object \u003Cbridge\u003Econfig() => (object) this.config();

      [HideFromJava]
      static ItemSourceBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Prov
      {
        private readonly ItemSource.ItemSourceBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] ItemSource.ItemSourceBuild obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024buildConfiguration\u00240();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly ItemSource.ItemSourceBuild arg\u00241;

        internal __\u003C\u003EAnon1([In] ItemSource.ItemSourceBuild obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.configure((object) (Item) obj0);
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons2
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0, [In] object obj1) => ItemSource.lambda\u0024new\u00240((ItemSource.ItemSourceBuild) obj0, (Item) obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => ItemSource.lambda\u0024new\u00241((ItemSource.ItemSourceBuild) obj0);
    }
  }
}
