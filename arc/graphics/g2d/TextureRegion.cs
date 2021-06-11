// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.TextureRegion
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.graphics.g2d
{
  public class TextureRegion : Object
  {
    public Texture texture;
    public float u;
    public float v;
    public float u2;
    public float v2;
    public int width;
    public int height;

    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool found() => Core.atlas != null && !object.ReferenceEquals((object) Core.atlas.error, (object) this);

    [LineNumberTable(new byte[] {160, 136, 106, 103, 103, 103, 135, 109, 141, 99, 127, 16, 105, 99, 105, 55, 12, 236, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion[][] split(int tileWidth, int tileHeight)
    {
      if (this.texture == null)
        return (TextureRegion[][]) null;
      int x1 = this.getX();
      int y = this.getY();
      int width = this.width;
      int height = this.height;
      int num1 = width;
      int num2 = tileWidth;
      int num3 = num2 != -1 ? num1 / num2 : -num1;
      int num4 = height;
      int num5 = tileHeight;
      int num6 = num5 != -1 ? num4 / num5 : -num4;
      int num7 = x1;
      int num8 = num3;
      int num9 = num6;
      int[] numArray = new int[2];
      int num10 = num9;
      numArray[1] = num10;
      int num11 = num8;
      numArray[0] = num11;
      // ISSUE: type reference
      TextureRegion[][] textureRegionArray = (TextureRegion[][]) ByteCodeHelper.multianewarray(__typeref (TextureRegion[][]), numArray);
      int index1 = 0;
      while (index1 < num6)
      {
        int x2 = num7;
        int index2 = 0;
        while (index2 < num3)
        {
          textureRegionArray[index2][index1] = new TextureRegion(this.texture, x2, y, tileWidth, tileHeight);
          ++index2;
          x2 += tileWidth;
        }
        ++index1;
        y += tileHeight;
      }
      return textureRegionArray;
    }

    [LineNumberTable(new byte[] {82, 108, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(TextureRegion region)
    {
      this.texture = region.texture;
      this.set(region.u, region.v, region.u2, region.v2);
    }

    [LineNumberTable(new byte[] {160, 71, 104, 159, 1, 158})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWidth(int width)
    {
      if (this.isFlipX())
        this.setU(this.u2 + (float) width / (float) this.texture.width);
      else
        this.setU2(this.u + (float) width / (float) this.texture.width);
    }

    [LineNumberTable(169)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getX() => Math.round(this.u * (float) this.texture.width);

    [LineNumberTable(new byte[] {123, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setX(int x) => this.setU((float) x / (float) this.texture.width);

    [LineNumberTable(177)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getY() => Math.round(this.v * (float) this.texture.height);

    [LineNumberTable(new byte[] {160, 67, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setY(int y) => this.setV((float) y / (float) this.texture.height);

    [LineNumberTable(new byte[] {160, 79, 104, 159, 1, 158})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setHeight(int height)
    {
      if (this.isFlipY())
        this.setV(this.v2 + (float) height / (float) this.texture.height);
      else
        this.setV2(this.v + (float) height / (float) this.texture.height);
    }

    [LineNumberTable(new byte[] {60, 120, 123, 188, 114, 106, 103, 103, 106, 103, 168, 104, 104, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float u, float v, float u2, float v2)
    {
      int width = this.texture.width;
      int height = this.texture.height;
      this.width = Math.round(Math.abs(u2 - u) * (float) width);
      this.height = Math.round(Math.abs(v2 - v) * (float) height);
      if (this.width == 1 && this.height == 1)
      {
        float num1 = 0.25f / (float) width;
        u += num1;
        u2 -= num1;
        float num2 = 0.25f / (float) height;
        v += num2;
        v2 -= num2;
      }
      this.u = u;
      this.v = v;
      this.u2 = u2;
      this.v2 = v2;
    }

    [LineNumberTable(new byte[] {160, 114, 105, 125, 119, 157, 105, 125, 119, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void scroll(float xAmount, float yAmount)
    {
      if ((double) xAmount != 0.0)
      {
        float num = (this.u2 - this.u) * (float) this.texture.width;
        this.u = (this.u + xAmount) % 1f;
        this.u2 = this.u + num / (float) this.texture.width;
      }
      if ((double) yAmount == 0.0)
        return;
      float num1 = (this.v2 - this.v) * (float) this.texture.height;
      this.v = (this.v + yAmount) % 1f;
      this.v2 = this.v + num1 / (float) this.texture.height;
    }

    [LineNumberTable(new byte[] {159, 168, 104, 115, 103, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureRegion(Texture texture)
    {
      TextureRegion textureRegion = this;
      if (texture == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("texture cannot be null.");
      }
      this.texture = texture;
      this.set(0, 0, texture.width, texture.height);
    }

    [LineNumberTable(new byte[] {94, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Texture texture, int x, int y, int width, int height)
    {
      this.texture = texture;
      this.set(x, y, width, height);
    }

    [LineNumberTable(new byte[] {43, 103, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Texture texture)
    {
      this.texture = texture;
      this.set(0, 0, texture.width, texture.height);
    }

    [LineNumberTable(new byte[] {159, 164, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureRegion()
    {
    }

    [LineNumberTable(new byte[] {52, 116, 116, 127, 0, 108, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(int x, int y, int width, int height)
    {
      float num1 = 1f / (float) this.texture.width;
      float num2 = 1f / (float) this.texture.height;
      this.set((float) x * num1, (float) y * num2, (float) (x + width) * num1, (float) (y + height) * num2);
      this.width = Math.abs(width);
      this.height = Math.abs(height);
    }

    [LineNumberTable(new byte[] {0, 104, 103, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureRegion(Texture texture, float u, float v, float u2, float v2)
    {
      TextureRegion textureRegion = this;
      this.texture = texture;
      this.set(u, v, u2, v2);
    }

    [LineNumberTable(new byte[] {109, 104, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setU2(float u2)
    {
      this.u2 = u2;
      this.width = Math.round(Math.abs(u2 - this.u) * (float) this.texture.width);
    }

    [LineNumberTable(new byte[] {114, 104, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setV2(float v2)
    {
      this.v2 = v2;
      this.height = Math.round(Math.abs(v2 - this.v) * (float) this.texture.height);
    }

    [LineNumberTable(new byte[] {15, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureRegion(TextureRegion region, int x, int y, int width, int height)
    {
      TextureRegion textureRegion = this;
      this.set(region, x, y, width, height);
    }

    [LineNumberTable(new byte[] {88, 108, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(TextureRegion region, int x, int y, int width, int height)
    {
      this.texture = region.texture;
      this.set(region.getX() + x, region.getY() + y, width, height);
    }

    [LineNumberTable(new byte[] {99, 104, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setU(float u)
    {
      this.u = u;
      this.width = Math.round(Math.abs(this.u2 - u) * (float) this.texture.width);
    }

    [LineNumberTable(new byte[] {104, 104, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setV(float v)
    {
      this.v = v;
      this.height = Math.round(Math.abs(this.v2 - v) * (float) this.texture.height);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isFlipX() => (double) this.u > (double) this.u2;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isFlipY() => (double) this.v > (double) this.v2;

    [LineNumberTable(new byte[] {159, 187, 104, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureRegion(Texture texture, int x, int y, int width, int height)
    {
      TextureRegion textureRegion = this;
      this.texture = texture;
      this.set(x, y, width, height);
    }

    [LineNumberTable(new byte[] {159, 178, 104, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureRegion(Texture texture, int width, int height)
    {
      TextureRegion textureRegion = this;
      this.texture = texture;
      this.set(0, 0, width, height);
    }

    [LineNumberTable(new byte[] {6, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureRegion(TextureRegion region)
    {
      TextureRegion textureRegion = this;
      this.set(region);
    }

    [LineNumberTable(new byte[] {29, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TextureRegion[][] split(
      Texture texture,
      int tileWidth,
      int tileHeight)
    {
      return new TextureRegion(texture).split(tileWidth, tileHeight);
    }

    [LineNumberTable(84)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureAtlas.AtlasRegion asAtlas() => (TextureAtlas.AtlasRegion) this;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void flip(bool x, bool y)
    {
      int num1 = x ? 1 : 0;
      int num2 = y ? 1 : 0;
      if (num1 != 0)
      {
        float u = this.u;
        this.u = this.u2;
        this.u2 = u;
      }
      if (num2 == 0)
        return;
      float v = this.v;
      this.v = this.v2;
      this.v2 = v;
    }

    [LineNumberTable(273)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("TextureRegion{texture=").append((object) this.texture).append(", width=").append(this.width).append(", height=").append(this.height).append('}').toString();
  }
}
