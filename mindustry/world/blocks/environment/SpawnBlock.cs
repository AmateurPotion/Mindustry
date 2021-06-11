// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.environment.SpawnBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.environment
{
  public class SpawnBlock : OverlayFloor
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 150, 105, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SpawnBlock(string name)
      : base(name)
    {
      SpawnBlock spawnBlock = this;
      this.variants = 0;
      this.needsSurface = false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawBase(Tile tile)
    {
    }

    [HideFromJava]
    static SpawnBlock() => OverlayFloor.__\u003Cclinit\u003E();
  }
}
