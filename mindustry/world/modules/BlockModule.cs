// Decompiled with JetBrains decompiler
// Type: mindustry.world.modules.BlockModule
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.io;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.world.modules
{
  public abstract class BlockModule : Object
  {
    [LineNumberTable(new byte[] {159, 156, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Reads read) => this.read(read, false);

    public abstract void write(Writes w);

    [LineNumberTable(new byte[] {159, 152, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Reads read, bool legacy) => this.read(read);

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BlockModule()
    {
    }
  }
}
