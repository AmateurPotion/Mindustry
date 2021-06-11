// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.FloorRenderer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.game;
using mindustry.world;
using mindustry.world.blocks.environment;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics
{
  public class FloorRenderer : Object, Disposable
  {
    [Modifiers]
    private static int chunksize;
    [Modifiers]
    private static int chunkunits;
    private const float pad = 4f;
    private int[][][] cache;
    private MultiCacheBatch cbatch;
    private IntSet drawnLayerSet;
    private IntSet recacheSet;
    private IntSeq drawnLayers;
    [Signature("Larc/struct/ObjectSet<Lmindustry/graphics/CacheLayer;>;")]
    private ObjectSet used;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {53, 142, 108, 104, 103, 114, 130, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void checkChanges()
    {
      if (this.recacheSet.size <= 0)
        return;
      IntSet.IntSetIterator intSetIterator = this.recacheSet.iterator();
      while (intSetIterator.hasNext)
      {
        int pos = intSetIterator.next();
        this.cacheChunk((int) Point2.x(pos), (int) Point2.y(pos));
      }
      this.recacheSet.clear();
    }

    [LineNumberTable(new byte[] {66, 104, 161, 101, 117, 139, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginDraw()
    {
      if (this.cache == null)
        return;
      Draw.flush();
      this.cbatch.setProjection(Core.camera.__\u003C\u003Emat);
      this.cbatch.beginDraw();
      Gl.enable(3042);
    }

    [LineNumberTable(new byte[] {86, 104, 161, 166, 127, 16, 127, 16, 127, 16, 159, 17, 134, 107, 137, 113, 162, 110, 110, 244, 56, 40, 235, 77, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawLayer(CacheLayer layer)
    {
      if (this.cache == null)
        return;
      Camera camera = Core.camera;
      int num1 = ByteCodeHelper.f2i((camera.__\u003C\u003Eposition.x - camera.width / 2f - 4f) / (float) FloorRenderer.chunkunits);
      int num2 = ByteCodeHelper.f2i((camera.__\u003C\u003Eposition.y - camera.height / 2f - 4f) / (float) FloorRenderer.chunkunits);
      int num3 = Mathf.ceil((camera.__\u003C\u003Eposition.x + camera.width / 2f + 4f) / (float) FloorRenderer.chunkunits);
      int num4 = Mathf.ceil((camera.__\u003C\u003Eposition.y + camera.height / 2f + 4f) / (float) FloorRenderer.chunkunits);
      layer.begin();
      for (int x = num1; x <= num3; ++x)
      {
        for (int y = num2; y <= num4; ++y)
        {
          if (Structs.inBounds(x, y, (object[][]) this.cache))
          {
            int[] numArray = this.cache[x][y];
            if (numArray[layer.ordinal()] != -1)
              this.cbatch.drawCache(numArray[layer.ordinal()]);
          }
        }
      }
      layer.end();
    }

    [LineNumberTable(new byte[] {78, 104, 161, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void endDraw()
    {
      if (this.cache == null)
        return;
      this.cbatch.endDraw();
    }

    [LineNumberTable(new byte[] {159, 183, 104, 161, 166, 127, 16, 127, 16, 127, 16, 159, 17, 136, 107, 171, 107, 140, 147, 174, 105, 118, 14, 232, 57, 43, 235, 80, 109, 105, 180, 139, 101, 134, 114, 149, 232, 61, 232, 70, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawFloor()
    {
      if (this.cache == null)
        return;
      Camera camera = Core.camera;
      int num1 = ByteCodeHelper.f2i((camera.__\u003C\u003Eposition.x - camera.width / 2f - 4f) / (float) FloorRenderer.chunkunits);
      int num2 = ByteCodeHelper.f2i((camera.__\u003C\u003Eposition.y - camera.height / 2f - 4f) / (float) FloorRenderer.chunkunits);
      int num3 = Mathf.ceil((camera.__\u003C\u003Eposition.x + camera.width / 2f + 4f) / (float) FloorRenderer.chunkunits);
      int num4 = Mathf.ceil((camera.__\u003C\u003Eposition.y + camera.height / 2f + 4f) / (float) FloorRenderer.chunkunits);
      int length = CacheLayer.__\u003C\u003Eall.Length;
      this.drawnLayers.clear();
      this.drawnLayerSet.clear();
      for (int x = num1; x <= num3; ++x)
      {
        for (int y = num2; y <= num4; ++y)
        {
          if (Structs.inBounds(x, y, (object[][]) this.cache))
          {
            int[] numArray = this.cache[x][y];
            for (int key = 0; key < length; ++key)
            {
              if (numArray[key] != -1 && key != CacheLayer.__\u003C\u003Ewalls.ordinal())
                this.drawnLayerSet.add(key);
            }
          }
        }
      }
      IntSet.IntSetIterator intSetIterator = this.drawnLayerSet.iterator();
      while (intSetIterator.hasNext)
        this.drawnLayers.add(intSetIterator.next());
      this.drawnLayers.sort();
      Draw.flush();
      this.beginDraw();
      for (int index = 0; index < this.drawnLayers.size; ++index)
        this.drawLayer(CacheLayer.__\u003C\u003Eall[this.drawnLayers.get(index)]);
      this.endDraw();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void recacheTile(Tile tile)
    {
    }

    [LineNumberTable(new byte[] {159, 172, 232, 59, 107, 107, 107, 171, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FloorRenderer()
    {
      FloorRenderer floorRenderer = this;
      this.drawnLayerSet = new IntSet();
      this.recacheSet = new IntSet();
      this.drawnLayers = new IntSeq();
      this.used = new ObjectSet();
      Events.on((Class) ClassLiteral<EventType.WorldLoadEvent>.Value, (Cons) new FloorRenderer.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {49, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void endc() => this.cbatch.endDraw();

    [LineNumberTable(new byte[] {45, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginc() => this.cbatch.beginDraw();

    [LineNumberTable(new byte[] {117, 107, 139, 127, 8, 127, 5, 141, 119, 153, 247, 58, 41, 233, 76, 127, 5, 107, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void cacheChunk([In] int obj0, [In] int obj1)
    {
      this.used.clear();
      int[] numArray = this.cache[obj0][obj1];
      for (int x = obj0 * FloorRenderer.chunksize; x < (obj0 + 1) * FloorRenderer.chunksize && x < Vars.world.width(); ++x)
      {
        for (int y = obj1 * FloorRenderer.chunksize; y < (obj1 + 1) * FloorRenderer.chunksize && y < Vars.world.height(); ++y)
        {
          Tile tile = Vars.world.rawTile(x, y);
          if (!object.ReferenceEquals((object) tile.block().cacheLayer, (object) CacheLayer.__\u003C\u003Enormal))
            this.used.add((object) tile.block().cacheLayer);
          else
            this.used.add((object) tile.floor().cacheLayer);
        }
      }
      ObjectSet.ObjectSetIterator objectSetIterator = this.used.iterator();
      while (((Iterator) objectSetIterator).hasNext())
      {
        CacheLayer cacheLayer = (CacheLayer) ((Iterator) objectSetIterator).next();
        this.cacheChunkLayer(obj0, obj1, numArray, cacheLayer);
      }
    }

    [LineNumberTable(new byte[] {160, 74, 102, 171, 108, 141, 180, 119, 119, 173, 99, 133, 168, 127, 21, 113, 127, 45, 106, 126, 234, 49, 41, 233, 85, 102, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void cacheChunkLayer([In] int obj0, [In] int obj1, [In] int[] obj2, [In] CacheLayer obj3)
    {
      Batch batch = Core.batch;
      Core.batch = (Batch) this.cbatch;
      if (obj2[obj3.ordinal()] == -1)
        this.cbatch.beginCache();
      else
        this.cbatch.beginCache(obj2[obj3.ordinal()]);
      for (int x = obj0 * FloorRenderer.chunksize; x < (obj0 + 1) * FloorRenderer.chunksize; ++x)
      {
        for (int y = obj1 * FloorRenderer.chunksize; y < (obj1 + 1) * FloorRenderer.chunksize; ++y)
        {
          Tile tile = Vars.world.tile(x, y);
          if (tile != null)
          {
            Floor floor = tile.floor();
            if (object.ReferenceEquals((object) tile.block().cacheLayer, (object) obj3) && object.ReferenceEquals((object) obj3, (object) CacheLayer.__\u003C\u003Ewalls) && (!tile.isDarkened() || (sbyte) tile.data < (sbyte) 5))
              tile.block().drawBase(tile);
            else if (object.ReferenceEquals((object) floor.cacheLayer, (object) obj3) && (Vars.world.isAccessible((int) tile.x, (int) tile.y) || !object.ReferenceEquals((object) tile.block().cacheLayer, (object) CacheLayer.__\u003C\u003Ewalls) || !tile.block().fillsTile))
              floor.drawBase(tile);
            else if (!object.ReferenceEquals((object) floor.cacheLayer, (object) obj3) && !object.ReferenceEquals((object) obj3, (object) CacheLayer.__\u003C\u003Ewalls))
              floor.drawNonLayer(tile, obj3);
          }
        }
      }
      Core.batch = batch;
      obj2[obj3.ordinal()] = this.cbatch.endCache();
    }

    [LineNumberTable(new byte[] {160, 110, 147, 107, 121, 121, 127, 21, 153, 133, 104, 104, 146, 234, 61, 40, 232, 72, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearTiles()
    {
      if (this.cbatch != null)
        this.cbatch.dispose();
      this.recacheSet.clear();
      int num1 = Mathf.ceil((float) Vars.world.width() / (float) FloorRenderer.chunksize);
      int num2 = Mathf.ceil((float) Vars.world.height() / (float) FloorRenderer.chunksize);
      int num3 = num1;
      int num4 = num2;
      int length = CacheLayer.__\u003C\u003Eall.Length;
      int[] numArray = new int[3];
      int num5 = length;
      numArray[2] = num5;
      int num6 = num4;
      numArray[1] = num6;
      int num7 = num3;
      numArray[0] = num7;
      // ISSUE: type reference
      this.cache = (int[][][]) ByteCodeHelper.multianewarray(__typeref (int[][][]), numArray);
      this.cbatch = new MultiCacheBatch(FloorRenderer.chunksize * FloorRenderer.chunksize * 9);
      Time.mark();
      for (int index1 = 0; index1 < num1; ++index1)
      {
        for (int index2 = 0; index2 < num2; ++index2)
        {
          Arrays.fill(this.cache[index1][index2], -1);
          this.cacheChunk(index1, index2);
        }
      }
      Log.debug("Time to cache: @", (object) Float.valueOf(Time.elapsed()));
    }

    [Modifiers]
    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] EventType.WorldLoadEvent obj0) => this.clearTiles();

    [LineNumberTable(new byte[] {160, 133, 104, 107, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      if (this.cbatch == null)
        return;
      this.cbatch.dispose();
      this.cbatch = (MultiCacheBatch) null;
    }

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static FloorRenderer()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.graphics.FloorRenderer"))
        return;
      FloorRenderer.chunksize = !Vars.mobile ? 32 : 16;
      FloorRenderer.chunkunits = FloorRenderer.chunksize * 8;
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly FloorRenderer arg\u00241;

      internal __\u003C\u003EAnon0([In] FloorRenderer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240((EventType.WorldLoadEvent) obj0);
    }
  }
}
