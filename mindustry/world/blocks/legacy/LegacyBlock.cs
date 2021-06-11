// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.legacy.LegacyBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.legacy
{
  public class LegacyBlock : Block
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 151, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LegacyBlock(string name)
      : base(name)
    {
    }

    [LineNumberTable(new byte[] {159, 156, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeSelf(Tile tile) => tile.remove();

    [HideFromJava]
    static LegacyBlock() => Block.__\u003Cclinit\u003E();
  }
}
