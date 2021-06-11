// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.legacy.LegacyUnitFactory
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.io;
using IKVM.Attributes;
using mindustry.content;
using mindustry.gen;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.legacy
{
  public class LegacyUnitFactory : LegacyBlock
  {
    public Block replacement;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 233, 61, 203, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LegacyUnitFactory(string name)
      : base(name)
    {
      LegacyUnitFactory legacyUnitFactory = this;
      this.replacement = Blocks.air;
      this.update = true;
      this.hasPower = true;
      this.hasItems = true;
      this.solid = false;
    }

    [LineNumberTable(new byte[] {159, 163, 119, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void removeSelf(Tile tile)
    {
      int rotation = tile.build != null ? tile.build.rotation : 0;
      tile.setBlock(this.replacement, tile.team(), rotation);
    }

    [HideFromJava]
    static LegacyUnitFactory() => LegacyBlock.__\u003Cclinit\u003E();

    public class LegacyUnitFactoryBuild : Building
    {
      [Modifiers]
      internal LegacyUnitFactory this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(25)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LegacyUnitFactoryBuild(LegacyUnitFactory _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 135, 99, 136, 136, 131, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num1 = (int) (sbyte) revision;
        base.read(read, (byte) num1);
        double num2 = (double) read.f();
        if (num1 != 0)
          return;
        read.i();
      }

      [HideFromJava]
      static LegacyUnitFactoryBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
