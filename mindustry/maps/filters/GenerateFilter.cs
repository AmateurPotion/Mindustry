// Decompiled with JetBrains decompiler
// Type: mindustry.maps.filters.GenerateFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.math;
using arc.scene.ui;
using arc.util;
using arc.util.noise;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.gen;
using mindustry.world;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.filters
{
  public abstract class GenerateFilter : Object
  {
    [NonSerialized]
    protected internal float o;
    [NonSerialized]
    protected internal long seed;
    [NonSerialized]
    protected internal GenerateFilter.GenerateInput @in;

    [LineNumberTable(new byte[] {37, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void randomize() => this.seed = (long) Mathf.random(99999999);

    [LineNumberTable(new byte[] {159, 162, 135, 139, 147, 117, 136, 127, 5, 134, 255, 10, 58, 233, 74, 117, 104, 132, 159, 23, 109, 159, 12, 118, 232, 54, 233, 77, 101, 127, 3, 127, 10, 134, 114, 159, 25, 123, 141, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void apply(Tiles tiles, GenerateFilter.GenerateInput @in)
    {
      this.@in = @in;
      if (this.isBuffered())
      {
        long[] numArray = new long[tiles.__\u003C\u003Ewidth * tiles.__\u003C\u003Eheight];
        for (int idx = 0; idx < tiles.__\u003C\u003Ewidth * tiles.__\u003C\u003Eheight; ++idx)
        {
          Tile tile = tiles.geti(idx);
          @in.apply((int) tile.x, (int) tile.y, tile.block(), (Block) tile.floor(), (Block) tile.overlay());
          this.apply();
          numArray[idx] = PackTile.get(@in.block.__\u003C\u003Eid, @in.floor.__\u003C\u003Eid, @in.overlay.__\u003C\u003Eid);
        }
        for (int idx = 0; idx < tiles.__\u003C\u003Ewidth * tiles.__\u003C\u003Eheight; ++idx)
        {
          Tile tile = tiles.geti(idx);
          long packtile = numArray[idx];
          Block type = Vars.content.block((int) PackTile.block(packtile));
          Block block1 = Vars.content.block((int) PackTile.floor(packtile));
          Block block2 = Vars.content.block((int) PackTile.overlay(packtile));
          tile.setFloor(block1.asFloor());
          tile.setOverlay(block1.asFloor().hasSurface() || !block2.asFloor().needsSurface ? block2 : Blocks.air);
          if (!tile.block().synthetic() && !type.synthetic())
            tile.setBlock(type);
        }
      }
      else
      {
        Iterator iterator = tiles.iterator();
        while (iterator.hasNext())
        {
          Tile tile = (Tile) iterator.next();
          @in.apply((int) tile.x, (int) tile.y, tile.block(), (Block) tile.floor(), (Block) tile.overlay());
          this.apply();
          tile.setFloor(@in.floor.asFloor());
          tile.setOverlay(@in.floor.asFloor().hasSurface() || !@in.overlay.asFloor().needsSurface ? @in.overlay : Blocks.air);
          if (!tile.block().synthetic() && !@in.block.synthetic())
            tile.setBlock(@in.block);
        }
      }
    }

    [LineNumberTable(new byte[] {15, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void apply(GenerateFilter.GenerateInput @in)
    {
      this.@in = @in;
      this.apply();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPost() => false;

    [LineNumberTable(new byte[] {30, 103, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string name()
    {
      Class superclass = Object.instancehelper_getClass((object) this);
      if (superclass.isAnonymousClass())
        superclass = superclass.getSuperclass();
      I18NBundle bundle = Core.bundle;
      StringBuilder stringBuilder = new StringBuilder().append("filter.");
      string lowerCase = String.instancehelper_toLowerCase(superclass.getSimpleName());
      object obj1 = (object) "";
      object obj2 = (object) "filter";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj2;
      CharSequence charSequence2 = charSequence1;
      object obj3 = obj1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence charSequence3 = charSequence1;
      string str = String.instancehelper_replace(lowerCase, charSequence2, charSequence3);
      string key = stringBuilder.append(str).toString();
      string simpleName = superclass.getSimpleName();
      object obj4 = (object) "";
      object obj5 = (object) "Filter";
      charSequence1.__\u003Cref\u003E = (__Null) obj5;
      CharSequence charSequence4 = charSequence1;
      object obj6 = obj4;
      charSequence1.__\u003Cref\u003E = (__Null) obj6;
      CharSequence charSequence5 = charSequence1;
      string def = String.instancehelper_replace(simpleName, charSequence4, charSequence5);
      return bundle.get(key, def);
    }

    public abstract FilterOption[] options();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(Image image)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isBuffered() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void apply()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GenerateFilter()
    {
      GenerateFilter generateFilter = this;
      this.o = (float) (Math.random() * 10000000.0);
    }

    [LineNumberTable(103)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float noise(float x, float y, float scl, float mag) => (float) this.@in.noise.octaveNoise2D(1.0, 0.0, (double) (1f / scl), (double) (x + this.o), (double) (y + this.o)) * mag;

    [LineNumberTable(107)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float noise(
      float x,
      float y,
      float scl,
      float mag,
      float octaves,
      float persistence)
    {
      return (float) this.@in.noise.octaveNoise2D((double) octaves, (double) persistence, (double) (1f / scl), (double) (x + this.o), (double) (y + this.o)) * mag;
    }

    [LineNumberTable(111)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float rnoise(float x, float y, float scl, float mag) => this.@in.pnoise.getValue((double) ByteCodeHelper.f2i(x + this.o), (double) ByteCodeHelper.f2i(y + this.o), 1f / scl) * mag;

    [LineNumberTable(115)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float chance() => Mathf.randomSeed(Pack.longInt(this.@in.x, this.@in.y + (int) this.seed));

    public class GenerateInput : Object
    {
      public int x;
      public int y;
      public int width;
      public int height;
      public Block floor;
      public Block block;
      public Block overlay;
      internal Simplex noise;
      internal RidgedPerlin pnoise;
      internal GenerateFilter.GenerateInput.TileProvider buffer;

      [LineNumberTable(new byte[] {69, 232, 72, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public GenerateInput()
      {
        GenerateFilter.GenerateInput generateInput = this;
        this.noise = new Simplex();
        this.pnoise = new RidgedPerlin(0, 1);
      }

      [LineNumberTable(new byte[] {90, 104, 103, 103, 113, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void begin(
        GenerateFilter filter,
        int width,
        int height,
        GenerateFilter.GenerateInput.TileProvider buffer)
      {
        this.buffer = buffer;
        this.width = width;
        this.height = height;
        this.noise.setSeed(filter.seed);
        this.pnoise.setSeed((int) (filter.seed + 1L));
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void apply(int x, int y, Block block, Block floor, Block overlay)
      {
        this.floor = floor;
        this.block = block;
        this.overlay = overlay;
        this.x = x;
        this.y = y;
      }

      [LineNumberTable(148)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual Tile tile([In] float obj0, [In] float obj1) => this.buffer.get(Mathf.clamp(ByteCodeHelper.f2i(obj0), 0, this.width - 1), Mathf.clamp(ByteCodeHelper.f2i(obj1), 0, this.height - 1));

      public interface TileProvider
      {
        Tile get(int i1, int i2);
      }
    }

    internal class PackTileStruct : Object
    {
      internal short block;
      internal short floor;
      internal short overlay;
      [Modifiers]
      internal GenerateFilter this\u00240;

      [LineNumberTable(157)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal PackTileStruct([In] GenerateFilter obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }
    }
  }
}
