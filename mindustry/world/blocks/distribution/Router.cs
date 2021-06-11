// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.distribution.Router
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using mindustry.content;
using mindustry.gen;
using mindustry.type;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.distribution
{
  public class Router : Block
  {
    public float speed;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 233, 61, 203, 103, 103, 103, 103, 107, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Router(string name)
      : base(name)
    {
      Router router = this;
      this.speed = 8f;
      this.solid = true;
      this.update = true;
      this.hasItems = true;
      this.itemCapacity = 1;
      this.group = BlockGroup.__\u003C\u003Etransportation;
      this.unloadable = false;
      this.noUpdateDisabled = true;
    }

    [HideFromJava]
    static Router() => Block.__\u003Cclinit\u003E();

    [Implements(new string[] {"mindustry.world.blocks.ControlBlock"})]
    public class RouterBuild : Building, ControlBlock
    {
      public Item lastItem;
      public Tile lastInput;
      public float time;
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public BlockUnitc unit;
      [Modifiers]
      internal Router this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 118, 130, 118, 113, 127, 25, 113, 151, 159, 26, 109, 104, 109, 194, 162, 103, 115, 127, 11, 127, 8, 127, 4, 107, 227, 59, 233, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Building getTileTarget(Item item, Tile from, bool set)
      {
        int num1 = set ? 1 : 0;
        if (this.unit != null && this.isControlled())
        {
          this.unit.health(this.health);
          this.unit.ammo((float) this.unit.type().ammoCapacity * (this.items.total() <= 0 ? 0.0f : 1f));
          this.unit.team(this.team);
          this.unit.set(this.x, this.y);
          int rotation = Mathf.mod(ByteCodeHelper.f2i((this.angleTo(this.unit.aimX(), this.unit.aimY()) + 45f) / 90f), 4);
          if (this.unit.isShooting())
          {
            Building building = this.nearby(rotation);
            if (building != null && building.acceptItem((Building) this, item))
              return building;
          }
          return (Building) null;
        }
        int rotation1 = this.rotation;
        for (int index1 = 0; index1 < this.proximity.size; ++index1)
        {
          Seq proximity = this.proximity;
          int num2 = index1 + rotation1;
          int size1 = this.proximity.size;
          int index2 = size1 != -1 ? num2 % size1 : 0;
          Building building = (Building) proximity.get(index2);
          if (num1 != 0)
          {
            int num3 = this.rotation + 1;
            int size2 = this.proximity.size;
            this.rotation = size2 != -1 ? (int) (sbyte) (num3 % size2) : 0;
          }
          if ((!object.ReferenceEquals((object) building.tile, (object) from) || !object.ReferenceEquals((object) from.block(), (object) Blocks.overflowGate)) && building.acceptItem((Building) this, item))
            return building;
        }
        return (Building) null;
      }

      [HideFromJava]
      public virtual bool isControlled() => ControlBlock.\u003Cdefault\u003EisControlled((ControlBlock) this);

      [LineNumberTable(26)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public RouterBuild(Router _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 176, 104, 123, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Unit unit()
      {
        if (this.unit == null)
        {
          this.unit = (BlockUnitc) UnitTypes.block.create(this.team);
          this.unit.tile((Building) this);
        }
        return (Unit) this.unit;
      }

      [LineNumberTable(43)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool canControl() => this.this\u00240.size == 1;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool shouldAutoTarget() => false;

      [LineNumberTable(new byte[] {3, 117, 177, 107, 127, 10, 148, 127, 11, 116, 109, 114, 167})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (this.lastItem == null && this.items.any())
          this.lastItem = this.items.first();
        if (this.lastItem == null)
          return;
        this.time += 1f / this.this\u00240.speed * this.delta();
        Building tileTarget = this.getTileTarget(this.lastItem, this.lastInput, false);
        if (tileTarget == null || (double) this.time < 1.0 && (tileTarget.block is Router || tileTarget.block.instantTransfer))
          return;
        this.getTileTarget(this.lastItem, this.lastInput, true);
        tileTarget.handleItem((Building) this, this.lastItem);
        this.items.remove(this.lastItem, 1);
        this.lastItem = (Item) null;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int acceptStack(Item item, int amount, Teamc source) => 0;

      [LineNumberTable(77)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => object.ReferenceEquals((object) this.team, (object) source.team) && this.lastItem == null && this.items.total() == 0;

      [LineNumberTable(new byte[] {32, 109, 103, 107, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleItem(Building source, Item item)
      {
        this.items.add(item, 1);
        this.lastItem = item;
        this.time = 0.0f;
        this.lastInput = source.tile();
      }

      [LineNumberTable(new byte[] {40, 105, 113, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int removeStack(Item item, int amount)
      {
        int num = base.removeStack(item, amount);
        if (num != 0 && object.ReferenceEquals((object) item, (object) this.lastItem))
          this.lastItem = (Item) null;
        return num;
      }

      [HideFromJava]
      static RouterBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
