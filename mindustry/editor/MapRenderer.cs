// Decompiled with JetBrains decompiler
// Type: mindustry.editor.MapRenderer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.game;
using mindustry.graphics;
using mindustry.world;
using mindustry.world.blocks.environment;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.editor
{
  public class MapRenderer : Object, Disposable
  {
    private const int chunkSize = 64;
    private IndexedRenderer[][] chunks;
    private IntSet updates;
    private IntSet delayedUpdates;
    private MapEditor editor;
    private int width;
    private int height;
    private Texture texture;

    [LineNumberTable(new byte[] {34, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updatePoint(int x, int y) => this.updates.add(x + y * this.width);

    [LineNumberTable(new byte[] {159, 167, 232, 58, 107, 235, 70, 103, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MapRenderer(MapEditor editor)
    {
      MapRenderer mapRenderer = this;
      this.updates = new IntSet();
      this.delayedUpdates = new IntSet();
      this.editor = editor;
      this.texture = Core.atlas.find("clear-editor").texture;
    }

    [LineNumberTable(new byte[] {159, 173, 107, 107, 104, 108, 110, 47, 38, 230, 71, 159, 50, 108, 110, 52, 38, 230, 69, 103, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resize(int width, int height)
    {
      this.updates.clear();
      this.delayedUpdates.clear();
      if (this.chunks != null)
      {
        for (int index1 = 0; index1 < this.chunks.Length; ++index1)
        {
          for (int index2 = 0; index2 < this.chunks[0].Length; ++index2)
            this.chunks[index1][index2].dispose();
        }
      }
      int num1 = ByteCodeHelper.d2i(Math.ceil((double) ((float) width / 64f)));
      int num2 = ByteCodeHelper.d2i(Math.ceil((double) ((float) height / 64f)));
      int[] numArray = new int[2];
      int num3 = num2;
      numArray[1] = num3;
      int num4 = num1;
      numArray[0] = num4;
      // ISSUE: type reference
      this.chunks = (IndexedRenderer[][]) ByteCodeHelper.multianewarray(__typeref (IndexedRenderer[][]), numArray);
      for (int index1 = 0; index1 < this.chunks.Length; ++index1)
      {
        for (int index2 = 0; index2 < this.chunks[0].Length; ++index2)
          this.chunks[index1][index2] = new IndexedRenderer(8192);
      }
      this.width = width;
      this.height = height;
      this.updateAll();
    }

    [LineNumberTable(new byte[] {38, 107, 107, 40, 38, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateAll()
    {
      for (int index1 = 0; index1 < this.width; ++index1)
      {
        for (int index2 = 0; index2 < this.height; ++index2)
          this.render(index1, index2);
      }
    }

    [LineNumberTable(new byte[] {105, 104, 129, 108, 110, 108, 15, 38, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      if (this.chunks == null)
        return;
      for (int index1 = 0; index1 < this.chunks.Length; ++index1)
      {
        for (int index2 = 0; index2 < this.chunks[0].Length; ++index2)
        {
          if (this.chunks[index1][index2] != null)
            this.chunks[index1][index2].dispose();
        }
      }
    }

    [LineNumberTable(new byte[] {46, 106, 107, 147, 104, 104, 200, 127, 1, 127, 7, 136, 125, 159, 18, 159, 3, 223, 40, 255, 5, 60, 229, 69, 98, 157, 188, 158, 118, 109, 118, 127, 5, 127, 14, 127, 0, 127, 2, 123, 159, 8, 177, 127, 3, 127, 1, 103, 103, 103, 167, 126, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void render([In] int obj0, [In] int obj1)
    {
      IndexedRenderer indexedRenderer = this.chunks[obj0 / 64][obj1 / 64];
      Tile tile = this.editor.tiles().getn(obj0, obj1);
      Team team = tile.team();
      Floor floor = tile.floor();
      Block block = tile.block();
      int num1 = obj0;
      int num2 = 64;
      int num3 = num2 != -1 ? num1 % num2 : 0;
      int num4 = obj1;
      int num5 = 64;
      int num6 = (num5 != -1 ? num4 % num5 : 0) * 64;
      int index1 = num3 + num6;
      int num7 = obj0;
      int num8 = 64;
      int num9 = num8 != -1 ? num7 % num8 : 0;
      int num10 = obj1;
      int num11 = 64;
      int num12 = (num11 != -1 ? num10 % num11 : 0) * 64;
      int index2 = num9 + num12 + 4096;
      int num13 = tile.isCenter() ? 1 : 0;
      if (!object.ReferenceEquals((object) block, (object) Blocks.air) && block.synthetic())
      {
        TextureRegion region = !Core.atlas.isFound(block.editorIcon()) || num13 == 0 ? (TextureRegion) Core.atlas.find("clear-editor") : block.editorIcon();
        float w = (float) region.width * Draw.scl;
        float h = (float) region.height * Draw.scl;
        indexedRenderer.draw(index1, region, (float) (obj0 * 8) + block.offset + (8f - w) / 2f, (float) (obj1 * 8) + block.offset + (8f - h) / 2f, w, h, tile.build == null || !block.rotate ? 0.0f : tile.build.rotdeg());
      }
      else
      {
        TextureRegion editorVariantRegion = floor.editorVariantRegions()[Mathf.randomSeed((long) index1, 0, floor.editorVariantRegions().Length - 1)];
        indexedRenderer.draw(index1, editorVariantRegion, (float) (obj0 * 8), (float) (obj1 * 8), 8f, 8f);
      }
      float num14 = (float) (-(block.size / 3) * 8);
      float num15 = (float) (-(block.size / 3) * 8);
      TextureRegion region1;
      if ((block.update || block.destructible) && num13 != 0)
      {
        indexedRenderer.setColor(team.__\u003C\u003Ecolor);
        region1 = (TextureRegion) Core.atlas.find("block-border-editor");
      }
      else if (!block.synthetic() && !object.ReferenceEquals((object) block, (object) Blocks.air) && num13 != 0)
      {
        region1 = Core.atlas.isFound(block.editorIcon()) ? block.editorIcon() : (TextureRegion) Core.atlas.find("clear-editor");
        num14 = 4f - (float) region1.width / 2f * Draw.scl;
        num15 = 4f - (float) region1.height / 2f * Draw.scl;
      }
      else
        region1 = !object.ReferenceEquals((object) block, (object) Blocks.air) || tile.overlay().isAir() ? (TextureRegion) Core.atlas.find("clear-editor") : tile.overlay().editorVariantRegions()[Mathf.randomSeed((long) index1, 0, tile.overlay().editorVariantRegions().Length - 1)];
      float w1 = (float) region1.width * Draw.scl;
      float h1 = (float) region1.height * Draw.scl;
      if (!block.synthetic() && !object.ReferenceEquals((object) block, (object) Blocks.air) && !block.isMultiblock())
      {
        num14 = 0.0f;
        num15 = 0.0f;
        w1 = 8f;
        h1 = 8f;
      }
      indexedRenderer.draw(index2, region1, (float) (obj0 * 8) + num14, (float) (obj1 * 8) + num15, w1, h1);
      indexedRenderer.setColor(Color.__\u003C\u003Ewhite);
    }

    [Modifiers]
    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024draw\u00240([In] int obj0)
    {
      int num1 = obj0;
      int width1 = this.width;
      int num2 = width1 != -1 ? num1 % width1 : 0;
      int num3 = obj0;
      int width2 = this.width;
      int num4 = width2 != -1 ? num3 / width2 : -num3;
      this.render(num2, num4);
    }

    [LineNumberTable(new byte[] {4, 133, 118, 139, 113, 171, 104, 161, 111, 113, 139, 99, 162, 127, 17, 139, 236, 54, 41, 233, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(float tx, float ty, float tw, float th)
    {
      Draw.flush();
      this.updates.each((Intc) new MapRenderer.__\u003C\u003EAnon0(this));
      this.updates.clear();
      this.updates.addAll(this.delayedUpdates);
      this.delayedUpdates.clear();
      if (this.chunks == null)
        return;
      for (int index1 = 0; index1 < this.chunks.Length; ++index1)
      {
        for (int index2 = 0; index2 < this.chunks[0].Length; ++index2)
        {
          IndexedRenderer indexedRenderer = this.chunks[index1][index2];
          if (indexedRenderer != null)
          {
            indexedRenderer.getTransformMatrix().setToTranslation(tx, ty).scale(tw / (float) (this.width * 8), th / (float) (this.height * 8));
            indexedRenderer.setProjectionMatrix(Draw.proj());
            indexedRenderer.render(this.texture);
          }
        }
      }
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Intc
    {
      private readonly MapRenderer arg\u00241;

      internal __\u003C\u003EAnon0([In] MapRenderer obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0) => this.arg\u00241.lambda\u0024draw\u00240(obj0);
    }
  }
}
