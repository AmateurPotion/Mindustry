// Decompiled with JetBrains decompiler
// Type: arc.struct.GridMap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.@struct
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;")]
  public class GridMap : Object
  {
    [Signature("Larc/struct/LongMap<TT;>;")]
    protected internal LongMap map;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long getHash([In] int obj0, [In] int obj1) => (long) obj0 << 32 | (long) obj1 & (long) uint.MaxValue;

    [LineNumberTable(new byte[] {159, 148, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GridMap()
    {
      GridMap gridMap = this;
      this.map = new LongMap();
    }

    [Signature("(II)TT;")]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(int x, int y) => this.map.get(GridMap.getHash(x, y));

    [Signature("(IITT;)TT;")]
    [LineNumberTable(new byte[] {159, 160, 104, 110, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(int x, int y, object defaultValue)
    {
      long hash = GridMap.getHash(x, y);
      return !this.map.containsKey(hash) ? defaultValue : this.map.get(hash);
    }

    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsKey(int x, int y) => this.map.containsKey(GridMap.getHash(x, y));

    [Signature("(IITT;)V")]
    [LineNumberTable(new byte[] {159, 172, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(int x, int y, object t) => this.map.put(GridMap.getHash(x, y), t);

    [LineNumberTable(new byte[] {159, 176, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(int x, int y) => this.map.remove(GridMap.getHash(x, y));

    [Signature("()Larc/struct/LongMap$Values<TT;>;")]
    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LongMap.Values values() => this.map.values();

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LongMap.Keys keys() => this.map.keys();

    [LineNumberTable(new byte[] {159, 188, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear() => this.map.clear();

    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => this.map.size;
  }
}
