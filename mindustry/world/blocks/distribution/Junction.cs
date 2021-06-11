// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.distribution.Junction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using mindustry.gen;
using mindustry.type;
using mindustry.world.meta;
using System;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.distribution
{
  public class Junction : Block
  {
    public float speed;
    public int capacity;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 159, 233, 60, 107, 199, 103, 103, 107, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Junction(string name)
      : base(name)
    {
      Junction junction = this;
      this.speed = 26f;
      this.capacity = 6;
      this.update = true;
      this.solid = true;
      this.group = BlockGroup.__\u003C\u003Etransportation;
      this.unloadable = false;
      this.noUpdateDisabled = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => true;

    [HideFromJava]
    static Junction() => Block.__\u003Cclinit\u003E();

    public class JunctionBuild : Building
    {
      public DirectionalItemBuffer buffer;
      [Modifiers]
      internal Junction this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 172, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public JunctionBuild(Junction _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Junction.JunctionBuild junctionBuild = this;
        this.buffer = new DirectionalItemBuffer(this.this\u00240.capacity);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int acceptStack(Item item, int amount, Teamc source) => 0;

      [LineNumberTable(new byte[] {159, 183, 105, 115, 127, 19, 112, 136, 159, 9, 114, 169, 127, 16, 162, 105, 127, 17, 252, 46, 233, 86})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        for (int rotation = 0; rotation < 4; ++rotation)
        {
          if (this.buffer.__\u003C\u003Eindexes[rotation] > 0)
          {
            if (this.buffer.__\u003C\u003Eindexes[rotation] > this.this\u00240.capacity)
              this.buffer.__\u003C\u003Eindexes[rotation] = this.this\u00240.capacity;
            long bufferitem = this.buffer.__\u003C\u003Ebuffers[rotation][0];
            float num = BufferItem.time(bufferitem);
            if ((double) Time.time >= (double) (num + this.this\u00240.speed / this.timeScale) || (double) Time.time < (double) num)
            {
              Item obj = Vars.content.item((int) (sbyte) BufferItem.item(bufferitem));
              Building building = this.nearby(rotation);
              if (obj != null && building != null && (building.acceptItem((Building) this, obj) && object.ReferenceEquals((object) building.team, (object) this.team)))
              {
                building.handleItem((Building) this, obj);
                ByteCodeHelper.arraycopy_primitive_8((Array) this.buffer.__\u003C\u003Ebuffers[rotation], 1, (Array) this.buffer.__\u003C\u003Ebuffers[rotation], 0, this.buffer.__\u003C\u003Eindexes[rotation] - 1);
                int[] indexes = this.buffer.__\u003C\u003Eindexes;
                int index = rotation;
                int[] numArray = indexes;
                numArray[index] = numArray[index] - 1;
              }
            }
          }
        }
      }

      [LineNumberTable(new byte[] {17, 110, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleItem(Building source, Item item) => this.buffer.accept((int) (sbyte) source.relativeTo(this.tile), item);

      [LineNumberTable(new byte[] {23, 142, 116, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item)
      {
        int num = (int) (sbyte) source.relativeTo(this.tile);
        if (num == -1 || !this.buffer.accepts(num))
          return false;
        Building building = this.nearby(num);
        return building != null && object.ReferenceEquals((object) building.team, (object) this.team);
      }

      [LineNumberTable(new byte[] {32, 103, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        this.buffer.write(write);
      }

      [LineNumberTable(new byte[] {159, 120, 67, 104, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.buffer.read(read);
      }

      [HideFromJava]
      static JunctionBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
