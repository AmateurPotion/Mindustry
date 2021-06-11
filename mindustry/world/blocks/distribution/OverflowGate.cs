// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.distribution.OverflowGate
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using mindustry.gen;
using mindustry.type;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.distribution
{
  public class OverflowGate : Block
  {
    public float speed;
    public bool invert;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 233, 60, 107, 199, 103, 103, 103, 107, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OverflowGate(string name)
      : base(name)
    {
      OverflowGate overflowGate = this;
      this.speed = 1f;
      this.invert = false;
      this.hasItems = true;
      this.solid = true;
      this.update = true;
      this.group = BlockGroup.__\u003C\u003Etransportation;
      this.instantTransfer = true;
      this.unloadable = false;
      this.canOverdrive = false;
      this.itemCapacity = 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => true;

    [HideFromJava]
    static OverflowGate() => Block.__\u003Cclinit\u003E();

    public class OverflowGateBuild : Building
    {
      [Modifiers]
      internal OverflowGate this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 130, 98, 110, 102, 149, 108, 127, 23, 149, 107, 113, 113, 127, 27, 159, 27, 104, 173, 104, 101, 104, 133, 104, 99, 140, 99, 234, 69})]
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Building getTileTarget(Item item, Building src, bool flip)
      {
        int num1 = flip ? 1 : 0;
        int edge = (int) (sbyte) this.relativeToEdge(src.tile);
        if (edge == -1)
          return (Building) null;
        int num2 = edge + 2;
        int num3 = 4;
        Building building1 = this.nearby(num3 != -1 ? num2 % num3 : 0);
        int num4 = src.block.instantTransfer ? 1 : 0;
        int num5 = building1 == null || !object.ReferenceEquals((object) building1.team, (object) this.team) || num4 != 0 && building1.block.instantTransfer || !building1.acceptItem((Building) this, item) ? 0 : 1;
        int num6 = this.this\u00240.invert == this.enabled ? 1 : 0;
        if (num5 == 0 || num6 != 0)
        {
          Building building2 = this.nearby(Mathf.mod(edge - 1, 4));
          Building building3 = this.nearby(Mathf.mod(edge + 1, 4));
          int num7 = building2 == null || num4 != 0 && building2.block.instantTransfer || (!object.ReferenceEquals((object) building2.team, (object) this.team) || !building2.acceptItem((Building) this, item)) ? 0 : 1;
          int num8 = building3 == null || num4 != 0 && building3.block.instantTransfer || (!object.ReferenceEquals((object) building3.team, (object) this.team) || !building3.acceptItem((Building) this, item)) ? 0 : 1;
          if (num7 == 0 && num8 == 0)
            return num6 != 0 && num5 != 0 ? building1 : (Building) null;
          if (num7 != 0 && num8 == 0)
            building1 = building2;
          else if (num8 != 0 && num7 == 0)
            building1 = building3;
          else if (this.rotation == 0)
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
        return building1;
      }

      [LineNumberTable(32)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public OverflowGateBuild(OverflowGate _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 178, 138})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item)
      {
        Building tileTarget = this.getTileTarget(item, source, false);
        return tileTarget != null && tileTarget.acceptItem((Building) this, item) && object.ReferenceEquals((object) tileTarget.team, (object) this.team);
      }

      [LineNumberTable(new byte[] {159, 185, 138, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleItem(Building source, Item item) => this.getTileTarget(item, source, true)?.handleItem((Building) this, item);

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override byte version() => 4;

      [LineNumberTable(new byte[] {159, 119, 67, 136, 100, 111, 100, 167, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        switch (num)
        {
          case 1:
            new DirectionalItemBuffer(25).read(read);
            break;
          case 3:
            read.i();
            break;
        }
        this.items.clear();
      }

      [HideFromJava]
      static OverflowGateBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
