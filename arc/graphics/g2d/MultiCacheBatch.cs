// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.MultiCacheBatch
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.graphics.gl;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.util;
using System.Runtime.CompilerServices;

namespace arc.graphics.g2d
{
  public class MultiCacheBatch : Batch
  {
    private const int maxSpritesPerCache = 102000;
    [Signature("Larc/struct/Seq<Larc/graphics/g2d/SpriteCache;>;")]
    internal Seq caches;
    internal new Shader shader;
    internal int currentid;
    internal int maxCacheSize;
    internal int offset;
    internal bool recaching;

    [LineNumberTable(new byte[] {82, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginDraw()
    {
      this.currentid = 0;
      this.currentCache().begin();
    }

    [LineNumberTable(new byte[] {87, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void endDraw()
    {
      this.currentCache().end();
      this.currentid = -1;
    }

    [LineNumberTable(new byte[] {14, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setProjection(Mat projection)
    {
      this.currentid = 0;
      this.currentCache().setProjectionMatrix(projection);
    }

    [LineNumberTable(new byte[] {92, 142, 105, 103, 102, 103, 113, 139, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawCache(int id)
    {
      int cacheID = (int) Pack.leftShort(id);
      int num = (int) Pack.rightShort(id);
      if (this.currentid != num)
      {
        SpriteCache spriteCache = this.currentCache();
        spriteCache.end();
        this.currentid = num;
        this.currentCache().setProjectionMatrix(spriteCache.getProjectionMatrix());
        this.currentCache().begin();
      }
      this.currentCache().draw(cacheID);
    }

    [LineNumberTable(new byte[] {30, 146, 123, 127, 13, 146, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginCache()
    {
      this.currentid = this.offset / 102000;
      if (this.currentid < (this.offset + this.maxCacheSize) / 102000)
      {
        MultiCacheBatch multiCacheBatch = this;
        int offset1 = multiCacheBatch.offset;
        int maxCacheSize1 = this.maxCacheSize;
        int offset2 = this.offset;
        int maxCacheSize2 = this.maxCacheSize;
        int num1 = maxCacheSize2 != -1 ? offset2 % maxCacheSize2 : 0;
        int num2 = maxCacheSize1 - num1 + 2;
        multiCacheBatch.offset = offset1 + num2;
        this.currentid = this.offset / 102000;
      }
      this.currentCache().beginCache();
      this.recaching = false;
    }

    [LineNumberTable(new byte[] {23, 110, 119, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginCache(int id)
    {
      int cacheID = (int) Pack.leftShort(id);
      int index = (int) Pack.rightShort(id);
      ((SpriteCache) this.caches.get(index)).beginCache(cacheID);
      this.currentid = index;
      this.recaching = true;
    }

    [LineNumberTable(new byte[] {42, 121, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int endCache()
    {
      int num = Pack.shortInt((short) this.currentCache().endCache(), (short) this.currentid);
      this.currentid = -1;
      this.recaching = false;
      return num;
    }

    [LineNumberTable(new byte[] {73, 102, 127, 1, 102, 130, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose()
    {
      base.dispose();
      Iterator iterator = this.caches.iterator();
      while (iterator.hasNext())
        ((SpriteCache) iterator.next()).dispose();
      this.shader.dispose();
    }

    [LineNumberTable(new byte[] {159, 162, 232, 56, 107, 107, 199, 167, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MultiCacheBatch(int maxCacheSize)
    {
      MultiCacheBatch multiCacheBatch = this;
      this.caches = new Seq();
      this.shader = SpriteCache.createDefaultShader();
      this.currentid = -1;
      this.recaching = false;
      this.maxCacheSize = maxCacheSize;
    }

    [LineNumberTable(new byte[] {159, 167, 126, 110, 159, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual SpriteCache currentCache()
    {
      int index = this.currentid != -1 ? this.currentid : this.offset / 102000;
      if (index >= this.caches.size)
      {
        Seq caches = this.caches;
        SpriteCache.__\u003Cclinit\u003E();
        SpriteCache spriteCache = new SpriteCache(102000, 16, this.shader, false);
        caches.add((object) spriteCache);
      }
      return (SpriteCache) this.caches.get(index);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void flush()
    {
    }

    [LineNumberTable(new byte[] {159, 181, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setColor(Color tint) => this.currentCache().setColor(tint);

    [LineNumberTable(new byte[] {159, 186, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setColor(float r, float g, float b, float a) => this.currentCache().setColor(r, g, b, a);

    [LineNumberTable(new byte[] {159, 191, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setPackedColor(float color) => this.currentCache().setPackedColor(color);

    [LineNumberTable(54)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Color getColor() => this.currentCache().getColor();

    [LineNumberTable(59)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPackedColor() => this.currentCache().getPackedColor();

    [LineNumberTable(new byte[] {19, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reserve(int amount) => this.offset += this.currentCache().reserve(amount);

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void draw(
      Texture texture,
      float[] spriteVertices,
      int offset,
      int count)
    {
    }

    [LineNumberTable(new byte[] {55, 127, 10, 104, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void draw(
      TextureRegion region,
      float x,
      float y,
      float originX,
      float originY,
      float width,
      float height,
      float rotation)
    {
      this.currentCache().add(region, x, y, originX, originY, width, height, 1f, 1f, rotation);
      if (this.recaching)
        return;
      ++this.offset;
    }

    [LineNumberTable(new byte[] {159, 114, 98, 140, 110, 108, 110, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setShader(Shader shader, bool apply)
    {
      int num1 = apply ? 1 : 0;
      int num2 = this.currentCache().isDrawing() ? 1 : 0;
      if (num2 != 0)
        this.currentCache().end();
      this.currentCache().setShader(shader);
      if (num2 != 0)
        this.currentCache().begin();
      if (num1 == 0 || shader == null)
        return;
      shader.apply();
    }
  }
}
