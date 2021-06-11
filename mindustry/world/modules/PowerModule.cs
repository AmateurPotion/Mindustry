// Decompiled with JetBrains decompiler
// Type: mindustry.world.modules.PowerModule
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.world.blocks.power;
using System.Runtime.CompilerServices;

namespace mindustry.world.modules
{
  public class PowerModule : BlockModule
  {
    public float status;
    public bool init;
    public PowerGraph graph;
    public IntSeq links;

    [LineNumberTable(new byte[] {159, 149, 232, 70, 139, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PowerModule()
    {
      PowerModule powerModule = this;
      this.status = 0.0f;
      this.graph = new PowerGraph();
      this.links = new IntSeq();
    }

    [LineNumberTable(new byte[] {159, 162, 113, 112, 50, 166, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void write(Writes write)
    {
      write.s(this.links.size);
      for (int index = 0; index < this.links.size; ++index)
        write.i(this.links.get(index));
      write.f(this.status);
    }

    [LineNumberTable(new byte[] {159, 171, 107, 103, 102, 49, 166, 109, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void read(Reads read)
    {
      this.links.clear();
      int num = (int) read.s();
      for (int index = 0; index < num; ++index)
        this.links.add(read.i());
      this.status = read.f();
      if (!Float.isNaN(this.status) && !Float.isInfinite(this.status))
        return;
      this.status = 0.0f;
    }
  }
}
