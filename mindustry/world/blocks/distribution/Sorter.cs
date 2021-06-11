// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.distribution.Sorter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics.g2d;
using arc.math;
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

namespace mindustry.world.blocks.distribution
{
  public class Sorter : Block
  {
    public bool invert;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] Sorter.SorterBuild obj0, [In] Item obj1) => obj0.sortItem = obj1;

    [Modifiers]
    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00241([In] Sorter.SorterBuild obj0) => obj0.sortItem = (Item) null;

    [LineNumberTable(new byte[] {159, 163, 105, 103, 103, 103, 107, 103, 103, 135, 117, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Sorter(string name)
      : base(name)
    {
      Sorter sorter = this;
      this.update = true;
      this.solid = true;
      this.instantTransfer = true;
      this.group = BlockGroup.__\u003C\u003Etransportation;
      this.configurable = true;
      this.unloadable = false;
      this.saveConfig = true;
      this.config((Class) ClassLiteral<Item>.Value, (Cons2) new Sorter.__\u003C\u003EAnon0());
      this.configClear((Cons) new Sorter.__\u003C\u003EAnon1());
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {159, 178, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestConfig(BuildPlan req, Eachable list) => this.drawRequestConfigCenter(req, req.config, "center", true);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => true;

    [LineNumberTable(new byte[] {159, 188, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int minimapColor(Tile tile)
    {
      Sorter.SorterBuild build = (Sorter.SorterBuild) tile.build;
      return build == null || build.sortItem == null ? 0 : build.sortItem.color.rgba();
    }

    [HideFromJava]
    static Sorter() => Block.__\u003Cclinit\u003E();

    public class SorterBuild : Building
    {
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Item sortItem;
      [Modifiers]
      internal Sorter this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 119, 66, 126, 166, 159, 11, 120, 130, 141, 112, 113, 127, 1, 109, 127, 4, 141, 104, 100, 104, 101, 100, 130, 104, 98, 140, 99, 234, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Building getTileTarget(Item item, Building source, bool flip)
      {
        int num1 = flip ? 1 : 0;
        int rotation = (int) (sbyte) source.relativeTo((int) this.tile.x, (int) this.tile.y);
        if (rotation == -1)
          return (Building) null;
        Building building1;
        if ((!object.ReferenceEquals((object) item, (object) this.sortItem) ? 0 : 1) != (this.this\u00240.invert ? 1 : 0) == this.enabled)
        {
          if (this.isSame(source) && this.isSame(this.nearby(rotation)))
            return (Building) null;
          building1 = this.nearby(rotation);
        }
        else
        {
          Building building2 = this.nearby(Mathf.mod(rotation - 1, 4));
          Building building3 = this.nearby(Mathf.mod(rotation + 1, 4));
          int num2 = building2 == null || building2.block.instantTransfer && source.block.instantTransfer || !building2.acceptItem((Building) this, item) ? 0 : 1;
          int num3 = building3 == null || building3.block.instantTransfer && source.block.instantTransfer || !building3.acceptItem((Building) this, item) ? 0 : 1;
          if (num2 != 0 && num3 == 0)
            building1 = building2;
          else if (num3 != 0 && num2 == 0)
          {
            building1 = building3;
          }
          else
          {
            if (num3 == 0)
              return (Building) null;
            if (this.rotation == 0)
            {
              building1 = building2;
              if (num1 != 0)
                this.rotation = 1;
            }
            else
            {
              building1 = building3;
              if (num1 != 0)
                this.rotation = 0;
            }
          }
        }
        return building1;
      }

      [LineNumberTable(88)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isSame(Building other) => other != null && other.block.instantTransfer;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Item config() => this.sortItem;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Item lambda\u0024buildConfiguration\u00240() => this.sortItem;

      [LineNumberTable(50)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SorterBuild(Sorter _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {5, 136, 103, 149})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void configured(Unit player, object value)
      {
        base.configured(player, value);
        if (Vars.headless)
          return;
        Vars.renderer.__\u003C\u003Eminimap.update(this.tile);
      }

      [LineNumberTable(new byte[] {14, 134, 104, 152, 112, 118, 133})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        if (this.sortItem == null)
        {
          Draw.rect("cross", this.x, this.y);
        }
        else
        {
          Draw.color(this.sortItem.color);
          Draw.rect("center", this.x, this.y);
          Draw.color();
        }
      }

      [LineNumberTable(new byte[] {27, 138})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item)
      {
        Building tileTarget = this.getTileTarget(item, source, false);
        return tileTarget != null && tileTarget.acceptItem((Building) this, item) && object.ReferenceEquals((object) tileTarget.team, (object) this.team);
      }

      [LineNumberTable(new byte[] {34, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleItem(Building source, Item item) => this.getTileTarget(item, source, true).handleItem((Building) this, item);

      [LineNumberTable(new byte[] {82, 127, 7})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void buildConfiguration(Table table) => ItemSelection.buildTable(table, Vars.content.items(), (Prov) new Sorter.SorterBuild.__\u003C\u003EAnon0(this), (Cons) new Sorter.SorterBuild.__\u003C\u003EAnon1(this));

      [LineNumberTable(new byte[] {87, 105, 102, 103, 162})]
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
      public override byte version() => 2;

      [LineNumberTable(new byte[] {108, 103, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.s(this.sortItem != null ? (int) this.sortItem.__\u003C\u003Eid : -1);
      }

      [LineNumberTable(new byte[] {159, 101, 67, 104, 150, 100, 141})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.sortItem = Vars.content.item((int) read.s());
        if (num != 1)
          return;
        new DirectionalItemBuffer(20).read(read);
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(50)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object \u003Cbridge\u003Econfig() => (object) this.config();

      [HideFromJava]
      static SorterBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Prov
      {
        private readonly Sorter.SorterBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] Sorter.SorterBuild obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024buildConfiguration\u00240();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly Sorter.SorterBuild arg\u00241;

        internal __\u003C\u003EAnon1([In] Sorter.SorterBuild obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.configure((object) (Item) obj0);
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons2
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0, [In] object obj1) => Sorter.lambda\u0024new\u00240((Sorter.SorterBuild) obj0, (Item) obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => Sorter.lambda\u0024new\u00241((Sorter.SorterBuild) obj0);
    }
  }
}
