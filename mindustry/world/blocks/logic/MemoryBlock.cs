// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.logic.MemoryBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.io;
using IKVM.Attributes;
using mindustry.gen;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.logic
{
  public class MemoryBlock : Block
  {
    public int memoryCapacity;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 233, 61, 200, 103, 103, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MemoryBlock(string name)
      : base(name)
    {
      MemoryBlock memoryBlock = this;
      this.memoryCapacity = 32;
      this.destructible = true;
      this.solid = true;
      this.group = BlockGroup.__\u003C\u003Elogic;
      this.drawDisabled = false;
    }

    [LineNumberTable(new byte[] {159, 163, 134, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003EmemoryCapacity, (float) this.memoryCapacity, StatUnit.__\u003C\u003Enone);
    }

    [HideFromJava]
    static MemoryBlock() => Block.__\u003Cclinit\u003E();

    public class MemoryBuild : Building
    {
      public double[] memory;
      [Modifiers]
      internal MemoryBlock this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 168, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MemoryBuild(MemoryBlock _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        MemoryBlock.MemoryBuild memoryBuild = this;
        this.memory = new double[this.this\u00240.memoryCapacity];
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool canPickup() => false;

      [LineNumberTable(new byte[] {159, 179, 135, 109, 116, 39, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.i(this.memory.Length);
        double[] memory = this.memory;
        int length = memory.Length;
        for (int index = 0; index < length; ++index)
        {
          double d = memory[index];
          write.d(d);
        }
      }

      [LineNumberTable(new byte[] {159, 131, 163, 136, 103, 102, 105, 19, 198})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num1 = (int) (sbyte) revision;
        base.read(read, (byte) num1);
        int num2 = read.i();
        for (int index = 0; index < num2; ++index)
        {
          double num3 = read.d();
          if (index < this.memory.Length)
            this.memory[index] = num3;
        }
      }

      [HideFromJava]
      static MemoryBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
