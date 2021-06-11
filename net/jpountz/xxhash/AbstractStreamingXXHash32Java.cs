// Decompiled with JetBrains decompiler
// Type: net.jpountz.xxhash.AbstractStreamingXXHash32Java
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.xxhash
{
  internal abstract class AbstractStreamingXXHash32Java : StreamingXXHash32
  {
    internal int v1;
    internal int v2;
    internal int v3;
    internal int v4;
    internal int memSize;
    internal long totalLen;
    [Modifiers]
    internal byte[] memory;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void reset()
    {
      this.v1 = this.seed - 1640531535 - 2048144777;
      this.v2 = this.seed - 2048144777;
      this.v3 = this.seed + 0;
      this.v4 = this.seed - -1640531535;
      this.totalLen = 0L;
      this.memSize = 0;
    }

    [LineNumberTable(new byte[] {159, 169, 105, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal AbstractStreamingXXHash32Java([In] int obj0)
      : base(obj0)
    {
      AbstractStreamingXXHash32Java streamingXxHash32Java = this;
      this.memory = new byte[16];
      this.reset();
    }
  }
}
