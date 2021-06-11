// Decompiled with JetBrains decompiler
// Type: mindustry.world.Tiles
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using ikvm.lang;
using java.lang;
using java.util;
using java.util.function;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world
{
  [Signature("Ljava/lang/Object;Ljava/lang/Iterable<Lmindustry/world/Tile;>;")]
  [Implements(new string[] {"java.lang.Iterable"})]
  public class Tiles : Object, Iterable, IEnumerable
  {
    internal int __\u003C\u003Ewidth;
    internal int __\u003C\u003Eheight;
    [Modifiers]
    internal Tile[] array;

    [LineNumberTable(new byte[] {5, 127, 80})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile getn(int x, int y)
    {
      if (x < 0 || x >= this.__\u003C\u003Ewidth || (y < 0 || y >= this.__\u003C\u003Eheight))
      {
        string str = new StringBuilder().append(x).append(", ").append(y).append(" out of bounds: width=").append(this.__\u003C\u003Ewidth).append(", height=").append(this.__\u003C\u003Eheight).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return this.array[y * this.__\u003C\u003Ewidth + x];
    }

    [LineNumberTable(new byte[] {11, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile getc(int x, int y)
    {
      x = Mathf.clamp(x, 0, this.__\u003C\u003Ewidth - 1);
      y = Mathf.clamp(y, 0, this.__\u003C\u003Eheight - 1);
      return this.array[y * this.__\u003C\u003Ewidth + x];
    }

    [Signature("()Ljava/util/Iterator<Lmindustry/world/Tile;>;")]
    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator() => (Iterator) new Tiles.TileIterator(this);

    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile geti(int idx) => this.array[idx];

    [LineNumberTable(new byte[] {159, 181, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(int x, int y, Tile tile) => this.array[y * this.__\u003C\u003Ewidth + x] = tile;

    [LineNumberTable(new byte[] {159, 158, 104, 110, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Tiles(int width, int height)
    {
      Tiles tiles = this;
      this.array = new Tile[width * height];
      this.__\u003C\u003Ewidth = width;
      this.__\u003C\u003Eheight = height;
    }

    [LineNumberTable(50)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile get(int x, int y) => x < 0 || x >= this.__\u003C\u003Ewidth || (y < 0 || y >= this.__\u003C\u003Eheight) ? (Tile) null : this.array[y * this.__\u003C\u003Ewidth + x];

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool @in(int x, int y) => x >= 0 && x < this.__\u003C\u003Ewidth && (y >= 0 && y < this.__\u003C\u003Eheight);

    [LineNumberTable(73)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile getp(int pos) => this.get((int) Point2.x(pos), (int) Point2.y(pos));

    [LineNumberTable(new byte[] {159, 165, 107, 107, 40, 38, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void each(Intc2 cons)
    {
      for (int i1 = 0; i1 < this.__\u003C\u003Ewidth; ++i1)
      {
        for (int i2 = 0; i2 < this.__\u003C\u003Eheight; ++i2)
          cons.get(i1, i2);
      }
    }

    [LineNumberTable(new byte[] {159, 174, 108, 63, 20, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void fill()
    {
      for (int index1 = 0; index1 < this.array.Length; ++index1)
      {
        Tile[] array = this.array;
        int index2 = index1;
        Tile.__\u003Cclinit\u003E();
        int num1 = index1;
        int width1 = this.__\u003C\u003Ewidth;
        int x = width1 != -1 ? num1 % width1 : 0;
        int num2 = index1;
        int width2 = this.__\u003C\u003Ewidth;
        int y = width2 != -1 ? num2 / width2 : -num2;
        Tile tile = new Tile(x, y);
        array[index2] = tile;
      }
    }

    [Signature("(Larc/func/Cons<Lmindustry/world/Tile;>;)V")]
    [LineNumberTable(new byte[] {27, 116, 39, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void eachTile(Cons cons)
    {
      Tile[] array = this.array;
      int length = array.Length;
      for (int index = 0; index < length; ++index)
      {
        Tile tile = array[index];
        cons.get((object) tile);
      }
    }

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    [Modifiers]
    public int width
    {
      [HideFromJava] get => this.__\u003C\u003Ewidth;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ewidth = value;
    }

    [Modifiers]
    public int height
    {
      [HideFromJava] get => this.__\u003C\u003Eheight;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eheight = value;
    }

    [InnerClass]
    [Signature("Ljava/lang/Object;Ljava/util/Iterator<Lmindustry/world/Tile;>;")]
    internal class TileIterator : Object, Iterator
    {
      internal int index;
      [Modifiers]
      internal Tiles this\u00240;

      [LineNumberTable(101)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Tile next()
      {
        Tile[] array = this.this\u00240.array;
        Tiles.TileIterator tileIterator1 = this;
        int index1 = tileIterator1.index;
        Tiles.TileIterator tileIterator2 = tileIterator1;
        int index2 = index1;
        tileIterator2.index = index1 + 1;
        return array[index2];
      }

      [LineNumberTable(new byte[] {41, 15, 167})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal TileIterator([In] Tiles obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Tiles.TileIterator tileIterator = this;
        this.index = 0;
      }

      [LineNumberTable(96)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasNext() => this.index < this.this\u00240.array.Length;

      [Modifiers]
      [LineNumberTable(88)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object next() => (object) this.next();

      [HideFromJava]
      public virtual void remove() => Iterator.\u003Cdefault\u003Eremove((Iterator) this);

      [HideFromJava]
      public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);
    }
  }
}
