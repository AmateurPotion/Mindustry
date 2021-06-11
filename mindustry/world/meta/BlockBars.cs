// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.BlockBars
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.world.meta
{
  public class BlockBars : Object
  {
    [Signature("Larc/struct/OrderedMap<Ljava/lang/String;Larc/func/Func<Lmindustry/gen/Building;Lmindustry/ui/Bar;>;>;")]
    private OrderedMap bars;

    [LineNumberTable(new byte[] {159, 150, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BlockBars()
    {
      BlockBars blockBars = this;
      this.bars = new OrderedMap();
    }

    [Signature("<T:Lmindustry/gen/Building;>(Ljava/lang/String;Larc/func/Func<TT;Lmindustry/ui/Bar;>;)V")]
    [LineNumberTable(new byte[] {159, 154, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(string name, Func sup) => this.bars.put((object) name, (object) sup);

    [LineNumberTable(new byte[] {159, 158, 110, 127, 37, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(string name)
    {
      if (!this.bars.containsKey((object) name))
      {
        string str = new StringBuilder().append("No bar with name '").append(name).append("' found; current bars: ").append((object) this.bars.keys().toSeq()).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException(str);
      }
      this.bars.remove((object) name);
    }

    [Signature("()Ljava/lang/Iterable<Larc/func/Func<Lmindustry/gen/Building;Lmindustry/ui/Bar;>;>;")]
    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterable list() => (Iterable) this.bars.values();
  }
}
