// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.storage.Unloader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.storage
{
  public class Unloader : Block
  {
    public float speed;
    internal int __\u003C\u003EtimerUnload;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] Unloader.UnloaderBuild obj0, [In] Item obj1) => obj0.sortItem = obj1;

    [Modifiers]
    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00241([In] Unloader.UnloaderBuild obj0) => obj0.sortItem = (Item) null;

    [LineNumberTable(new byte[] {159, 163, 233, 60, 107, 217, 103, 103, 104, 103, 103, 103, 103, 103, 135, 117, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Unloader(string name)
      : base(name)
    {
      Unloader unloader1 = this;
      this.speed = 1f;
      Unloader unloader2 = this;
      int timers = unloader2.timers;
      Unloader unloader3 = unloader2;
      int num = timers;
      unloader3.timers = timers + 1;
      this.__\u003C\u003EtimerUnload = num;
      this.update = true;
      this.solid = true;
      this.health = 70;
      this.hasItems = true;
      this.configurable = true;
      this.saveConfig = true;
      this.itemCapacity = 0;
      this.noUpdateDisabled = true;
      this.unloadable = false;
      this.config((Class) ClassLiteral<Item>.Value, (Cons2) new Unloader.__\u003C\u003EAnon0());
      this.configClear((Cons) new Unloader.__\u003C\u003EAnon1());
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {159, 180, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestConfig(BuildPlan req, Eachable list) => this.drawRequestConfigCenter(req, req.config, "unloader-center");

    [LineNumberTable(new byte[] {159, 185, 102, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.remove("items");
    }

    [HideFromJava]
    static Unloader() => Block.__\u003Cclinit\u003E();

    [Modifiers]
    public int timerUnload
    {
      [HideFromJava] get => this.__\u003C\u003EtimerUnload;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerUnload = value;
    }

    public class UnloaderBuild : Building
    {
      public Item sortItem;
      public Building dumpingTo;
      public int offset;
      public int[] rotations;
      [Modifiers]
      internal Unloader this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Item config() => this.sortItem;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Item lambda\u0024buildConfiguration\u00240() => this.sortItem;

      [LineNumberTable(new byte[] {159, 189, 111, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnloaderBuild(Unloader _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Unloader.UnloaderBuild unloaderBuild = this;
        this.sortItem = (Item) null;
        this.offset = 0;
      }

      [LineNumberTable(new byte[] {5, 127, 10, 124, 182, 115, 126, 146, 127, 43, 159, 10, 167, 191, 5, 105, 141, 104, 176, 105, 104, 251, 42, 233, 91, 110, 110, 191, 2})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (!this.timer(this.this\u00240.__\u003C\u003EtimerUnload, this.this\u00240.speed / this.timeScale))
          return;
        if (this.rotations == null || this.rotations.Length != this.proximity.size)
          this.rotations = new int[this.proximity.size];
        for (int index1 = 0; index1 < this.proximity.size; ++index1)
        {
          int num = this.offset + index1;
          int size = this.proximity.size;
          int index2 = size != -1 ? num % size : 0;
          Building building = (Building) this.proximity.get(index2);
          if (building.interactable(this.team) && building.block.unloadable && (building.canUnload() && building.block.hasItems) && (this.sortItem == null && building.items.total() > 0 || this.sortItem != null && building.items.has(this.sortItem)))
          {
            this.dumpingTo = building;
            Item obj = this.sortItem != null ? this.sortItem : building.items.takeIndex(this.rotations[index2]);
            if (this.put(obj))
            {
              building.items.remove(obj, 1);
              if (this.sortItem == null)
                this.rotations[index2] = (int) obj.__\u003C\u003Eid + 1;
              building.itemTaken(obj);
            }
            else if (this.sortItem == null)
              this.rotations[index2] = building.items.nextIndex(this.rotations[index2]);
          }
        }
        if (this.proximity.size <= 0)
          return;
        ++this.offset;
        Unloader.UnloaderBuild unloaderBuild = this;
        int offset = unloaderBuild.offset;
        int size1 = this.proximity.size;
        unloaderBuild.offset = size1 != -1 ? offset % size1 : 0;
      }

      [LineNumberTable(new byte[] {46, 134, 127, 0, 118, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        Draw.color(this.sortItem != null ? this.sortItem.color : Color.__\u003C\u003Eclear);
        Draw.rect("unloader-center", this.x, this.y);
        Draw.color();
      }

      [LineNumberTable(new byte[] {55, 127, 7})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void buildConfiguration(Table table) => ItemSelection.buildTable(table, Vars.content.items(), (Prov) new Unloader.UnloaderBuild.__\u003C\u003EAnon0(this), (Cons) new Unloader.UnloaderBuild.__\u003C\u003EAnon1(this));

      [LineNumberTable(new byte[] {60, 105, 102, 103, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool onConfigureTileTapped(Building other)
      {
        if (!object.ReferenceEquals((object) this, (object) other))
          return true;
        this.deselect();
        this.configure((object) null);
        return false;
      }

      [LineNumberTable(121)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool canDump(Building to, Item item) => !(to.block is StorageBlock) && !object.ReferenceEquals((object) to, (object) this.dumpingTo);

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override byte version() => 1;

      [LineNumberTable(new byte[] {86, 103, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.s(this.sortItem != null ? (int) this.sortItem.__\u003C\u003Eid : -1);
      }

      [LineNumberTable(new byte[] {159, 107, 131, 104, 116, 127, 3})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        int index = num != 1 ? (int) (sbyte) read.b() : (int) read.s();
        this.sortItem = index != -1 ? (Item) Vars.content.items().get(index) : (Item) null;
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(47)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object \u003Cbridge\u003Econfig() => (object) this.config();

      [HideFromJava]
      static UnloaderBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Prov
      {
        private readonly Unloader.UnloaderBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] Unloader.UnloaderBuild obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024buildConfiguration\u00240();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly Unloader.UnloaderBuild arg\u00241;

        internal __\u003C\u003EAnon1([In] Unloader.UnloaderBuild obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.configure((object) (Item) obj0);
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons2
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0, [In] object obj1) => Unloader.lambda\u0024new\u00240((Unloader.UnloaderBuild) obj0, (Item) obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => Unloader.lambda\u0024new\u00241((Unloader.UnloaderBuild) obj0);
    }
  }
}
