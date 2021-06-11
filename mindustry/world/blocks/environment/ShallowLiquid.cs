// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.environment.ShallowLiquid
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.environment
{
  public class ShallowLiquid : Floor
  {
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Floor liquidBase;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Floor floorBase;
    public float liquidOpacity;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 161, 108, 140, 103, 113, 113, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Block liquid, Block floor)
    {
      this.liquidBase = liquid.asFloor();
      this.floorBase = floor.asFloor();
      this.isLiquid = true;
      this.variants = this.floorBase.variants;
      this.status = this.liquidBase.status;
      this.liquidDrop = this.liquidBase.liquidDrop;
      this.cacheLayer = this.liquidBase.cacheLayer;
    }

    [LineNumberTable(new byte[] {159, 157, 233, 61, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ShallowLiquid(string name)
      : base(name)
    {
      ShallowLiquid shallowLiquid = this;
      this.liquidOpacity = 0.35f;
    }

    [HideFromJava]
    static ShallowLiquid() => Floor.__\u003Cclinit\u003E();
  }
}
