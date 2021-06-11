// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.defense.turrets.ItemTurret
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.scene;
using arc.scene.ui.layout;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.entities.bullet;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using mindustry.world.consumers;
using mindustry.world.meta;
using mindustry.world.meta.values;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.defense.turrets
{
  public class ItemTurret : Turret
  {
    [Signature("Larc/struct/ObjectMap<Lmindustry/type/Item;Lmindustry/entities/bullet/BulletType;>;")]
    public ObjectMap ammoTypes;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024init\u00240([In] Item obj0) => this.ammoTypes.containsKey((object) obj0);

    [LineNumberTable(new byte[] {159, 167, 233, 61, 203, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemTurret(string name)
      : base(name)
    {
      ItemTurret itemTurret = this;
      this.ammoTypes = new ObjectMap();
      this.hasItems = true;
    }

    [LineNumberTable(new byte[] {159, 173, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void ammo(params object[] objects) => this.ammoTypes = (ObjectMap) OrderedMap.of(objects);

    [LineNumberTable(new byte[] {159, 178, 134, 112, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.remove(Stat.__\u003C\u003EitemCapacity);
      this.stats.add(Stat.__\u003C\u003Eammo, (StatValue) new AmmoListValue(this.ammoTypes));
    }

    [LineNumberTable(new byte[] {159, 186, 253, 86, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      this.__\u003C\u003Econsumes.add((Consume) new ItemTurret.\u0031(this, (Boolf) new ItemTurret.__\u003C\u003EAnon0(this)));
      base.init();
    }

    [HideFromJava]
    static ItemTurret() => Turret.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "init", "()V")]
    [SpecialName]
    internal new class \u0031 : ConsumeItemFilter
    {
      [Modifiers]
      internal ItemTurret this\u00240;

      [LineNumberTable(44)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] ItemTurret obj0, [In] Boolf obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
      }

      [Modifiers]
      [LineNumberTable(48)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024build\u00240([In] Item obj0) => this.__\u003C\u003Efilter.get((object) obj0) && obj0.unlockedNow();

      [Modifiers]
      [LineNumberTable(48)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024build\u00242([In] MultiReqImage obj0, [In] Building obj1, [In] Item obj2)
      {
        MultiReqImage multiReqImage = obj0;
        ReqImage.__\u003Cclinit\u003E();
        ItemImage.__\u003Cclinit\u003E();
        ReqImage display = new ReqImage((Element) new ItemImage(obj2.icon(Cicon.__\u003C\u003Emedium)), (Boolp) new ItemTurret.\u0031.__\u003C\u003EAnon2(obj1, obj2));
        multiReqImage.add(display);
      }

      [Modifiers]
      [LineNumberTable(49)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024build\u00241([In] Building obj0, [In] Item obj1)
      {
        Building building = obj0;
        ItemTurret.ItemTurretBuild itemTurretBuild;
        return building is ItemTurret.ItemTurretBuild && object.ReferenceEquals((object) (itemTurretBuild = (ItemTurret.ItemTurretBuild) building), (object) (ItemTurret.ItemTurretBuild) building) && (!itemTurretBuild.ammo.isEmpty() && object.ReferenceEquals((object) ((ItemTurret.ItemEntry) itemTurretBuild.ammo.peek()).item, (object) obj1));
      }

      [LineNumberTable(new byte[] {159, 189, 102, 191, 7, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build([In] Building obj0, [In] Table obj1)
      {
        MultiReqImage multiReqImage = new MultiReqImage();
        Vars.content.items().each((Boolf) new ItemTurret.\u0031.__\u003C\u003EAnon0(this), (Cons) new ItemTurret.\u0031.__\u003C\u003EAnon1(multiReqImage, obj0));
        obj1.add((Element) multiReqImage).size(32f);
      }

      [LineNumberTable(57)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool valid([In] Building obj0)
      {
        Building building = obj0;
        ItemTurret.ItemTurretBuild itemTurretBuild;
        return building is ItemTurret.ItemTurretBuild && object.ReferenceEquals((object) (itemTurretBuild = (ItemTurret.ItemTurretBuild) building), (object) (ItemTurret.ItemTurretBuild) building) && !itemTurretBuild.ammo.isEmpty();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void display([In] Stats obj0)
      {
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Boolf
      {
        private readonly ItemTurret.\u0031 arg\u00241;

        internal __\u003C\u003EAnon0([In] ItemTurret.\u0031 obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024build\u00240((Item) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly MultiReqImage arg\u00241;
        private readonly Building arg\u00242;

        internal __\u003C\u003EAnon1([In] MultiReqImage obj0, [In] Building obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => ItemTurret.\u0031.lambda\u0024build\u00242(this.arg\u00241, this.arg\u00242, (Item) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Boolp
      {
        private readonly Building arg\u00241;
        private readonly Item arg\u00242;

        internal __\u003C\u003EAnon2([In] Building obj0, [In] Item obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public bool get() => (ItemTurret.\u0031.lambda\u0024build\u00241(this.arg\u00241, this.arg\u00242) ? 1 : 0) != 0;
      }
    }

    internal class ItemEntry : Turret.AmmoEntry
    {
      protected internal Item item;
      [Modifiers]
      internal ItemTurret this\u00240;

      [LineNumberTable(new byte[] {160, 71, 111, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal ItemEntry([In] ItemTurret obj0, [In] Item obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ItemTurret.ItemEntry itemEntry = this;
        this.item = obj1;
        this.amount = obj2;
      }

      [LineNumberTable(192)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override BulletType type() => (BulletType) this.this\u00240.ammoTypes.get((object) this.item);
    }

    public class ItemTurretBuild : Turret.TurretBuild
    {
      [Modifiers]
      internal ItemTurret this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {71, 109, 170, 119, 186, 112, 178, 110, 122, 121, 225, 57, 233, 76, 127, 3})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleItem(Building source, Item item)
      {
        if (object.ReferenceEquals((object) item, (object) Items.pyratite))
          Events.fire((object) EventType.Trigger.__\u003C\u003EflameAmmo);
        BulletType bulletType = (BulletType) this.this\u00240.ammoTypes.get((object) item);
        ItemTurret.ItemTurretBuild itemTurretBuild = this;
        itemTurretBuild.totalAmmo = ByteCodeHelper.f2i((float) itemTurretBuild.totalAmmo + bulletType.ammoMultiplier);
        for (int index = 0; index < this.ammo.size; ++index)
        {
          ItemTurret.ItemEntry itemEntry1 = (ItemTurret.ItemEntry) this.ammo.get(index);
          if (object.ReferenceEquals((object) itemEntry1.item, (object) item))
          {
            ItemTurret.ItemEntry itemEntry2 = itemEntry1;
            itemEntry2.amount = ByteCodeHelper.f2i((float) itemEntry2.amount + bulletType.ammoMultiplier);
            this.ammo.swap(index, this.ammo.size - 1);
            return;
          }
        }
        this.ammo.add((object) new ItemTurret.ItemEntry(this.this\u00240, item, ByteCodeHelper.f2i(bulletType.ammoMultiplier)));
      }

      [Modifiers]
      [LineNumberTable(92)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private float lambda\u0024displayBars\u00240() => (float) this.totalAmmo / (float) this.this\u00240.maxAmmo;

      [LineNumberTable(69)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ItemTurretBuild(ItemTurret _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((Turret) _param1);
      }

      [LineNumberTable(new byte[] {23, 166, 118, 159, 7})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onProximityAdded()
      {
        base.onProximityAdded();
        if (!this.cheating() || this.ammo.size <= 0)
          return;
        this.handleItem((Building) this, (Item) this.this\u00240.ammoTypes.entries().next().key);
      }

      [LineNumberTable(new byte[] {33, 159, 20, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        this.unit.ammo((float) this.unit.type().ammoCapacity * (float) this.totalAmmo / (float) this.this\u00240.maxAmmo);
        base.updateTile();
      }

      [LineNumberTable(new byte[] {40, 135, 127, 12, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void displayBars(Table bars)
      {
        base.displayBars(bars);
        Table table = bars;
        mindustry.ui.Bar.__\u003Cclinit\u003E();
        mindustry.ui.Bar bar = new mindustry.ui.Bar("stat.ammo", Pal.ammo, (Floatp) new ItemTurret.ItemTurretBuild.__\u003C\u003EAnon0(this));
        table.add((Element) bar).growX();
        bars.row();
      }

      [LineNumberTable(new byte[] {48, 151, 133})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int acceptStack(Item item, int amount, Teamc source) => (BulletType) this.this\u00240.ammoTypes.get((object) item) == null ? 0 : Math.min(ByteCodeHelper.f2i((float) (this.this\u00240.maxAmmo - this.totalAmmo) / ((BulletType) this.this\u00240.ammoTypes.get((object) item)).ammoMultiplier), amount);

      [LineNumberTable(new byte[] {57, 102, 40, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleStack(Item item, int amount, Teamc source)
      {
        for (int index = 0; index < amount; ++index)
          this.handleItem((Building) null, item);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int removeStack(Item item, int amount) => 0;

      [LineNumberTable(146)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => this.this\u00240.ammoTypes.get((object) item) != null && (double) ((float) this.totalAmmo + ((BulletType) this.this\u00240.ammoTypes.get((object) item)).ammoMultiplier) <= (double) this.this\u00240.maxAmmo;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override byte version() => 2;

      [LineNumberTable(new byte[] {106, 103, 113, 127, 1, 103, 113, 108, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.b(this.ammo.size);
        Iterator iterator = this.ammo.iterator();
        while (iterator.hasNext())
        {
          ItemTurret.ItemEntry itemEntry = (ItemTurret.ItemEntry) iterator.next();
          write.s((int) itemEntry.item.__\u003C\u003Eid);
          write.s(itemEntry.amount);
        }
      }

      [LineNumberTable(new byte[] {159, 101, 163, 104, 103, 105, 125, 104, 175, 118, 249, 57, 233, 74})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num1 = (int) (sbyte) revision;
        base.read(read, (byte) num1);
        int num2 = read.ub();
        for (int index = 0; index < num2; ++index)
        {
          Item obj = Vars.content.item(num1 >= 2 ? (int) read.s() : read.ub());
          int num3 = (int) read.s();
          this.totalAmmo += num3;
          if (obj != null && this.this\u00240.ammoTypes.containsKey((object) obj))
            this.ammo.add((object) new ItemTurret.ItemEntry(this.this\u00240, obj, num3));
        }
      }

      [HideFromJava]
      static ItemTurretBuild() => Turret.TurretBuild.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Floatp
      {
        private readonly ItemTurret.ItemTurretBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] ItemTurret.ItemTurretBuild obj0) => this.arg\u00241 = obj0;

        public float get() => this.arg\u00241.lambda\u0024displayBars\u00240();
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly ItemTurret arg\u00241;

      internal __\u003C\u003EAnon0([In] ItemTurret obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024init\u00240((Item) obj0) ? 1 : 0) != 0;
    }
  }
}
