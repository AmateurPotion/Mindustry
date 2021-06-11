// Decompiled with JetBrains decompiler
// Type: net.jpountz.xxhash.AbstractStreamingXXHash64Java
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.xxhash
{
  internal abstract class AbstractStreamingXXHash64Java : StreamingXXHash64
  {
    internal int memSize;
    internal long v1;
    internal long v2;
    internal long v3;
    internal long v4;
    internal long totalLen;
    [Modifiers]
    internal byte[] memory;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void reset()
    {
      this.v1 = this.seed + -7046029288634856825L + -4417276706812531889L;
      this.v2 = this.seed + -4417276706812531889L;
      this.v3 = this.seed + 0L;
      this.v4 = this.seed - -7046029288634856825L;
      this.totalLen = 0L;
      this.memSize = 0;
    }

    [LineNumberTable(new byte[] {159, 170, 105, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal AbstractStreamingXXHash64Java([In] long obj0)
      : base(obj0)
    {
      AbstractStreamingXXHash64Java streamingXxHash64Java = this;
      this.memory = new byte[32];
      this.reset();
    }
  }
}
