// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.CacheBatch
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.gl;
using arc.math;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.graphics.g2d
{
  public class CacheBatch : Batch
  {
    internal SpriteCache cache;
    internal float[] tmpVertices;

    [LineNumberTable(new byte[] {159, 158, 232, 58, 237, 71, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CacheBatch(SpriteCache cache)
    {
      CacheBatch cacheBatch = this;
      this.tmpVertices = new float[20];
      this.cache = cache;
    }

    [LineNumberTable(new byte[] {6, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginCache() => this.cache.beginCache();

    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int endCache() => this.cache.endCache();

    [LineNumberTable(new byte[] {2, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setProjection(Mat projection) => this.cache.setProjectionMatrix(projection);

    [LineNumberTable(new byte[] {58, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginDraw() => this.cache.begin();

    [LineNumberTable(new byte[] {66, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawCache(int id) => this.cache.draw(id);

    [LineNumberTable(new byte[] {62, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void endDraw() => this.cache.end();

    [LineNumberTable(new byte[] {53, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose()
    {
      base.dispose();
      this.cache.dispose();
    }

    [LineNumberTable(new byte[] {159, 119, 98, 140, 110, 108, 110, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setShader(Shader shader, bool apply)
    {
      int num1 = apply ? 1 : 0;
      int num2 = this.cache.isDrawing() ? 1 : 0;
      if (num2 != 0)
        this.cache.end();
      this.cache.setShader(shader);
      if (num2 != 0)
        this.cache.begin();
      if (num1 == 0 || shader == null)
        return;
      shader.apply();
    }

    [LineNumberTable(new byte[] {159, 155, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CacheBatch(int size)
      : this(new SpriteCache(size, false))
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void flush()
    {
    }

    [LineNumberTable(new byte[] {159, 169, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setColor(Color tint) => this.cache.setColor(tint);

    [LineNumberTable(new byte[] {159, 174, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setColor(float r, float g, float b, float a) => this.cache.setColor(r, g, b, a);

    [LineNumberTable(new byte[] {159, 179, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setPackedColor(float color) => this.cache.setPackedColor(color);

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Color getColor() => this.cache.getColor();

    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPackedColor() => this.cache.getColor().toFloatBits();

    [LineNumberTable(new byte[] {16, 127, 4, 108, 100, 100, 104, 108, 108, 108, 236, 57, 233, 75, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void draw(
      Texture texture,
      float[] spriteVertices,
      int offset,
      int count)
    {
      float[] vertices = count / 6 * 5 != this.tmpVertices.Length ? new float[count / 6 * 5] : this.tmpVertices;
      for (int index1 = 0; index1 < count / 6; ++index1)
      {
        int num = index1 * 6;
        int index2 = index1 * 5;
        vertices[index2] = spriteVertices[offset + num];
        vertices[index2 + 1] = spriteVertices[offset + num + 1];
        vertices[index2 + 2] = spriteVertices[offset + num + 2];
        vertices[index2 + 3] = spriteVertices[offset + num + 3];
        vertices[index2 + 4] = spriteVertices[offset + num + 4];
      }
      this.cache.add(texture, vertices, 0, vertices.Length);
    }

    [LineNumberTable(new byte[] {33, 127, 10})]
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
      this.cache.add(region, x, y, originX, originY, width, height, 1f, 1f, rotation);
    }

    [LineNumberTable(new byte[] {38, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setShader(Shader shader) => this.setShader(shader, true);
  }
}
