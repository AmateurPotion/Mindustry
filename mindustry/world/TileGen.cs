// Decompiled with JetBrains decompiler
// Type: mindustry.world.TileGen
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using mindustry.content;
using System.Runtime.CompilerServices;

namespace mindustry.world
{
  public class TileGen : Object
  {
    public Block floor;
    public Block block;
    public Block overlay;

    [LineNumberTable(new byte[] {159, 147, 232, 70, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TileGen()
    {
      TileGen tileGen = this;
      this.reset();
    }

    [LineNumberTable(new byte[] {159, 157, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.floor = Blocks.stone;
      this.block = Blocks.air;
      this.overlay = Blocks.air;
    }
  }
}
