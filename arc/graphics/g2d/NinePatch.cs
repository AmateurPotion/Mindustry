// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.NinePatch
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g2d
{
  public class NinePatch : Object
  {
    public const int TOP_LEFT = 0;
    public const int TOP_CENTER = 1;
    public const int TOP_RIGHT = 2;
    public const int MIDDLE_LEFT = 3;
    public const int MIDDLE_CENTER = 4;
    public const int MIDDLE_RIGHT = 5;
    public const int BOTTOM_LEFT = 6;
    public const int BOTTOM_CENTER = 7;
    public const int BOTTOM_RIGHT = 8;
    [Modifiers]
    private static Color tmpDrawColor;
    [Modifiers]
    private Color color;
    private Texture texture;
    private int bottomLeft;
    private int bottomCenter;
    private int bottomRight;
    private int middleLeft;
    private int middleCenter;
    private int middleRight;
    private int topLeft;
    private int topCenter;
    private int topRight;
    private float leftWidth;
    private float rightWidth;
    private float middleWidth;
    private float middleHeight;
    private float topHeight;
    private float bottomHeight;
    private float[] vertices;
    private int idx;
    private float padLeft;
    private float padRight;
    private float padTop;
    private float padBottom;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {17, 232, 34, 149, 117, 117, 149, 144, 255, 13, 87, 115, 107, 141, 104, 101, 114, 114, 148, 100, 114, 100, 110, 100, 144, 101, 117, 100, 113, 100, 211, 102, 102, 102, 102, 100, 100, 164, 103, 102, 102, 102, 100, 100, 164, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NinePatch(TextureRegion region, int left, int right, int top, int bottom)
    {
      NinePatch ninePatch = this;
      Color.__\u003Cclinit\u003E();
      this.color = new Color(Color.__\u003C\u003Ewhite);
      this.bottomLeft = -1;
      this.bottomCenter = -1;
      this.bottomRight = -1;
      this.middleLeft = -1;
      this.middleCenter = -1;
      this.middleRight = -1;
      this.topLeft = -1;
      this.topCenter = -1;
      this.topRight = -1;
      this.vertices = new float[216];
      this.padLeft = -1f;
      this.padRight = -1f;
      this.padTop = -1f;
      this.padBottom = -1f;
      if (region == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("region cannot be null.");
      }
      int width = region.width - left - right;
      int height = region.height - top - bottom;
      TextureRegion[] textureRegionArray = new TextureRegion[9];
      if (top > 0)
      {
        if (left > 0)
          textureRegionArray[0] = new TextureRegion(region, 0, 0, left, top);
        if (width > 0)
          textureRegionArray[1] = new TextureRegion(region, left, 0, width, top);
        if (right > 0)
          textureRegionArray[2] = new TextureRegion(region, left + width, 0, right, top);
      }
      if (height > 0)
      {
        if (left > 0)
          textureRegionArray[3] = new TextureRegion(region, 0, top, left, height);
        if (width > 0)
          textureRegionArray[4] = new TextureRegion(region, left, top, width, height);
        if (right > 0)
          textureRegionArray[5] = new TextureRegion(region, left + width, top, right, height);
      }
      if (bottom > 0)
      {
        if (left > 0)
          textureRegionArray[6] = new TextureRegion(region, 0, top + height, left, bottom);
        if (width > 0)
          textureRegionArray[7] = new TextureRegion(region, left, top + height, width, bottom);
        if (right > 0)
          textureRegionArray[8] = new TextureRegion(region, left + width, top + height, right, bottom);
      }
      if (left == 0 && width == 0)
      {
        textureRegionArray[1] = textureRegionArray[2];
        textureRegionArray[4] = textureRegionArray[5];
        textureRegionArray[7] = textureRegionArray[8];
        textureRegionArray[2] = (TextureRegion) null;
        textureRegionArray[5] = (TextureRegion) null;
        textureRegionArray[8] = (TextureRegion) null;
      }
      if (top == 0 && height == 0)
      {
        textureRegionArray[3] = textureRegionArray[6];
        textureRegionArray[4] = textureRegionArray[7];
        textureRegionArray[5] = textureRegionArray[8];
        textureRegionArray[6] = (TextureRegion) null;
        textureRegionArray[7] = (TextureRegion) null;
        textureRegionArray[8] = (TextureRegion) null;
      }
      this.load(textureRegionArray);
    }

    [LineNumberTable(new byte[] {161, 5, 111, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(float x, float y, float width, float height)
    {
      this.prepareVertices(x, y, width, height);
      Draw.vert(this.texture, this.vertices, 0, this.idx);
    }

    [LineNumberTable(new byte[] {161, 11, 112, 111, 103, 103, 109, 107, 126, 118, 117, 247, 60, 240, 70, 116, 104, 115, 23, 232, 69, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(
      float x,
      float y,
      float originX,
      float originY,
      float width,
      float height,
      float scaleX,
      float scaleY,
      float rotation)
    {
      this.prepareVertices(x, y, width, height);
      float num1 = x + originX;
      float num2 = y + originY;
      int idx = this.idx;
      float[] vertices = this.vertices;
      if ((double) rotation != 0.0)
      {
        for (int index = 0; index < idx; index += 6)
        {
          float num3 = (vertices[index] - num1) * scaleX;
          float num4 = (vertices[index + 1] - num2) * scaleY;
          float num5 = Mathf.cosDeg(rotation);
          float num6 = Mathf.sinDeg(rotation);
          vertices[index] = num5 * num3 - num6 * num4 + num1;
          vertices[index + 1] = num6 * num3 + num5 * num4 + num2;
        }
      }
      else if ((double) scaleX != 1.0 || (double) scaleY != 1.0)
      {
        for (int index = 0; index < idx; index += 6)
        {
          vertices[index] = (vertices[index] - num1) * scaleX + num1;
          vertices[index + 1] = (vertices[index + 1] - num2) * scaleY + num2;
        }
      }
      Draw.vert(this.texture, vertices, 0, idx);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getTotalWidth() => this.leftWidth + this.middleWidth + this.rightWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getTotalHeight() => this.topHeight + this.middleHeight + this.bottomHeight;

    [LineNumberTable(new byte[] {161, 148, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPadTop() => (double) this.padTop == -1.0 ? this.getTopHeight() : this.padTop;

    [LineNumberTable(new byte[] {161, 137, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPadRight() => (double) this.padRight == -1.0 ? this.getRightWidth() : this.padRight;

    [LineNumberTable(new byte[] {161, 159, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPadBottom() => (double) this.padBottom == -1.0 ? this.getBottomHeight() : this.padBottom;

    [LineNumberTable(new byte[] {161, 126, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPadLeft() => (double) this.padLeft == -1.0 ? this.getLeftWidth() : this.padLeft;

    [LineNumberTable(new byte[] {160, 72, 232, 159, 107, 149, 117, 117, 149, 144, 255, 13, 160, 142, 140, 108, 108, 108, 108, 108, 108, 108, 108, 140, 108, 108, 108, 108, 108, 140, 108, 108, 108, 140, 114, 122, 108, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NinePatch(NinePatch ninePatch, Color color)
    {
      NinePatch ninePatch1 = this;
      Color.__\u003Cclinit\u003E();
      this.color = new Color(Color.__\u003C\u003Ewhite);
      this.bottomLeft = -1;
      this.bottomCenter = -1;
      this.bottomRight = -1;
      this.middleLeft = -1;
      this.middleCenter = -1;
      this.middleRight = -1;
      this.topLeft = -1;
      this.topCenter = -1;
      this.topRight = -1;
      this.vertices = new float[216];
      this.padLeft = -1f;
      this.padRight = -1f;
      this.padTop = -1f;
      this.padBottom = -1f;
      this.texture = ninePatch.texture;
      this.bottomLeft = ninePatch.bottomLeft;
      this.bottomCenter = ninePatch.bottomCenter;
      this.bottomRight = ninePatch.bottomRight;
      this.middleLeft = ninePatch.middleLeft;
      this.middleCenter = ninePatch.middleCenter;
      this.middleRight = ninePatch.middleRight;
      this.topLeft = ninePatch.topLeft;
      this.topCenter = ninePatch.topCenter;
      this.topRight = ninePatch.topRight;
      this.leftWidth = ninePatch.leftWidth;
      this.rightWidth = ninePatch.rightWidth;
      this.middleWidth = ninePatch.middleWidth;
      this.middleHeight = ninePatch.middleHeight;
      this.topHeight = ninePatch.topHeight;
      this.bottomHeight = ninePatch.bottomHeight;
      this.padLeft = ninePatch.padLeft;
      this.padTop = ninePatch.padTop;
      this.padBottom = ninePatch.padBottom;
      this.padRight = ninePatch.padRight;
      this.vertices = new float[ninePatch.vertices.Length];
      ByteCodeHelper.arraycopy_primitive_4((Array) ninePatch.vertices, 0, (Array) this.vertices, 0, ninePatch.vertices.Length);
      this.idx = ninePatch.idx;
      this.color.set(color);
    }

    [LineNumberTable(new byte[] {160, 104, 134, 101, 114, 111, 143, 101, 114, 123, 155, 101, 114, 123, 155, 101, 114, 123, 155, 101, 114, 123, 155, 101, 114, 123, 155, 101, 114, 123, 155, 101, 114, 123, 155, 101, 114, 123, 155, 111, 108, 116, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void load([In] TextureRegion[] obj0)
    {
      float whiteFloatBits = Color.__\u003C\u003EwhiteFloatBits;
      if (obj0[6] != null)
      {
        this.bottomLeft = this.add(obj0[6], whiteFloatBits, false, false);
        this.leftWidth = (float) obj0[6].width;
        this.bottomHeight = (float) obj0[6].height;
      }
      if (obj0[7] != null)
      {
        this.bottomCenter = this.add(obj0[7], whiteFloatBits, true, false);
        this.middleWidth = Math.max(this.middleWidth, (float) obj0[7].width);
        this.bottomHeight = Math.max(this.bottomHeight, (float) obj0[7].height);
      }
      if (obj0[8] != null)
      {
        this.bottomRight = this.add(obj0[8], whiteFloatBits, false, false);
        this.rightWidth = Math.max(this.rightWidth, (float) obj0[8].width);
        this.bottomHeight = Math.max(this.bottomHeight, (float) obj0[8].height);
      }
      if (obj0[3] != null)
      {
        this.middleLeft = this.add(obj0[3], whiteFloatBits, false, true);
        this.leftWidth = Math.max(this.leftWidth, (float) obj0[3].width);
        this.middleHeight = Math.max(this.middleHeight, (float) obj0[3].height);
      }
      if (obj0[4] != null)
      {
        this.middleCenter = this.add(obj0[4], whiteFloatBits, true, true);
        this.middleWidth = Math.max(this.middleWidth, (float) obj0[4].width);
        this.middleHeight = Math.max(this.middleHeight, (float) obj0[4].height);
      }
      if (obj0[5] != null)
      {
        this.middleRight = this.add(obj0[5], whiteFloatBits, false, true);
        this.rightWidth = Math.max(this.rightWidth, (float) obj0[5].width);
        this.middleHeight = Math.max(this.middleHeight, (float) obj0[5].height);
      }
      if (obj0[0] != null)
      {
        this.topLeft = this.add(obj0[0], whiteFloatBits, false, false);
        this.leftWidth = Math.max(this.leftWidth, (float) obj0[0].width);
        this.topHeight = Math.max(this.topHeight, (float) obj0[0].height);
      }
      if (obj0[1] != null)
      {
        this.topCenter = this.add(obj0[1], whiteFloatBits, true, false);
        this.middleWidth = Math.max(this.middleWidth, (float) obj0[1].width);
        this.topHeight = Math.max(this.topHeight, (float) obj0[1].height);
      }
      if (obj0[2] != null)
      {
        this.topRight = this.add(obj0[2], whiteFloatBits, false, false);
        this.rightWidth = Math.max(this.rightWidth, (float) obj0[2].width);
        this.topHeight = Math.max(this.topHeight, (float) obj0[2].height);
      }
      if (this.idx >= this.vertices.Length)
        return;
      float[] numArray = new float[this.idx];
      ByteCodeHelper.arraycopy_primitive_4((Array) this.vertices, 0, (Array) numArray, 0, this.idx);
      this.vertices = numArray;
    }

    [LineNumberTable(new byte[] {73, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NinePatch(Texture texture)
      : this(new TextureRegion(texture))
    {
    }

    [LineNumberTable(new byte[] {161, 40, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColor(Color color) => this.color.set(color);

    [LineNumberTable(new byte[] {83, 232, 159, 160, 149, 117, 117, 149, 144, 255, 13, 160, 89, 255, 18, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NinePatch(TextureRegion region)
    {
      NinePatch ninePatch = this;
      Color.__\u003Cclinit\u003E();
      this.color = new Color(Color.__\u003C\u003Ewhite);
      this.bottomLeft = -1;
      this.bottomCenter = -1;
      this.bottomRight = -1;
      this.middleLeft = -1;
      this.middleCenter = -1;
      this.middleRight = -1;
      this.topLeft = -1;
      this.topCenter = -1;
      this.topRight = -1;
      this.vertices = new float[216];
      this.padLeft = -1f;
      this.padRight = -1f;
      this.padTop = -1f;
      this.padBottom = -1f;
      this.load(new TextureRegion[9]
      {
        (TextureRegion) null,
        (TextureRegion) null,
        (TextureRegion) null,
        (TextureRegion) null,
        region,
        (TextureRegion) null,
        (TextureRegion) null,
        (TextureRegion) null,
        (TextureRegion) null
      });
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getLeftWidth() => this.leftWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRightWidth() => this.rightWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getBottomHeight() => this.bottomHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getTopHeight() => this.topHeight;

    [LineNumberTable(new byte[] {159, 74, 101, 104, 110, 115, 144, 103, 103, 104, 232, 69, 127, 15, 99, 117, 102, 136, 99, 117, 102, 200, 104, 135, 109, 108, 108, 141, 109, 109, 110, 142, 110, 110, 110, 142, 110, 110, 109, 110, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int add([In] TextureRegion obj0, [In] float obj1, [In] bool obj2, [In] bool obj3)
    {
      int num1 = obj2 ? 1 : 0;
      int num2 = obj3 ? 1 : 0;
      if (this.texture == null)
        this.texture = obj0.texture;
      else if (!object.ReferenceEquals((object) this.texture, (object) obj0.texture))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("All regions must be from the same texture.");
      }
      float u = obj0.u;
      float v2 = obj0.v2;
      float u2 = obj0.u2;
      float v = obj0.v;
      if (object.ReferenceEquals((object) this.texture.getMagFilter(), (object) Texture.TextureFilter.__\u003C\u003Elinear) || object.ReferenceEquals((object) this.texture.getMinFilter(), (object) Texture.TextureFilter.__\u003C\u003Elinear))
      {
        if (num1 != 0)
        {
          float num3 = 0.5f / (float) this.texture.width;
          u += num3;
          u2 -= num3;
        }
        if (num2 != 0)
        {
          float num3 = 0.5f / (float) this.texture.height;
          v2 -= num3;
          v += num3;
        }
      }
      float[] vertices = this.vertices;
      float clearFloatBits = Color.__\u003C\u003EclearFloatBits;
      vertices[this.idx + 2] = obj1;
      vertices[this.idx + 3] = u;
      vertices[this.idx + 4] = v2;
      vertices[this.idx + 5] = clearFloatBits;
      vertices[this.idx + 8] = obj1;
      vertices[this.idx + 9] = u;
      vertices[this.idx + 10] = v;
      vertices[this.idx + 11] = clearFloatBits;
      vertices[this.idx + 14] = obj1;
      vertices[this.idx + 15] = u2;
      vertices[this.idx + 16] = v;
      vertices[this.idx + 17] = clearFloatBits;
      vertices[this.idx + 20] = obj1;
      vertices[this.idx + 21] = u2;
      vertices[this.idx + 22] = v2;
      vertices[this.idx + 23] = clearFloatBits;
      this.idx += 24;
      return this.idx - 24;
    }

    [LineNumberTable(new byte[] {160, 214, 104, 104, 103, 102, 101, 103, 104, 134, 103, 102, 104, 135, 103, 103, 105, 135, 103, 104, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void set([In] int obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4, [In] float obj5)
    {
      float num1 = obj1 + obj3;
      float num2 = obj2 + obj4;
      float[] vertices = this.vertices;
      float clearFloatBits = Color.__\u003C\u003EclearFloatBits;
      vertices[obj0] = obj1;
      vertices[obj0 + 1] = obj2;
      vertices[obj0 + 2] = obj5;
      vertices[obj0 + 5] = clearFloatBits;
      vertices[obj0 + 6] = obj1;
      vertices[obj0 + 7] = num2;
      vertices[obj0 + 8] = obj5;
      vertices[obj0 + 11] = clearFloatBits;
      vertices[obj0 + 12] = num1;
      vertices[obj0 + 13] = num2;
      vertices[obj0 + 14] = obj5;
      vertices[obj0 + 17] = clearFloatBits;
      vertices[obj0 + 18] = num1;
      vertices[obj0 + 19] = obj2;
      vertices[obj0 + 20] = obj5;
      vertices[obj0 + 23] = clearFloatBits;
    }

    [LineNumberTable(new byte[] {160, 240, 107, 111, 107, 112, 159, 3, 127, 6, 127, 4, 127, 9, 127, 4, 105, 120, 105, 125, 127, 10, 105, 126, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void prepareVertices([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3)
    {
      float num1 = obj0 + this.leftWidth;
      float num2 = obj0 + obj2 - this.rightWidth;
      float num3 = obj1 + this.bottomHeight;
      float num4 = obj1 + obj3 - this.topHeight;
      float floatBits = NinePatch.tmpDrawColor.set(this.color).mul(Draw.getColor()).toFloatBits();
      if (this.bottomLeft != -1)
        this.set(this.bottomLeft, obj0, obj1, num1 - obj0, num3 - obj1, floatBits);
      if (this.bottomCenter != -1)
        this.set(this.bottomCenter, num1, obj1, num2 - num1, num3 - obj1, floatBits);
      if (this.bottomRight != -1)
        this.set(this.bottomRight, num2, obj1, obj0 + obj2 - num2, num3 - obj1, floatBits);
      if (this.middleLeft != -1)
        this.set(this.middleLeft, obj0, num3, num1 - obj0, num4 - num3, floatBits);
      if (this.middleCenter != -1)
        this.set(this.middleCenter, num1, num3, num2 - num1, num4 - num3, floatBits);
      if (this.middleRight != -1)
        this.set(this.middleRight, num2, num3, obj0 + obj2 - num2, num4 - num3, floatBits);
      if (this.topLeft != -1)
        this.set(this.topLeft, obj0, num4, num1 - obj0, obj1 + obj3 - num4, floatBits);
      if (this.topCenter != -1)
        this.set(this.topCenter, num1, num4, num2 - num1, obj1 + obj3 - num4, floatBits);
      if (this.topRight == -1)
        return;
      this.set(this.topRight, num2, num4, obj0 + obj2 - num2, obj1 + obj3 - num4, floatBits);
    }

    [LineNumberTable(new byte[] {6, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NinePatch(Texture texture, int left, int right, int top, int bottom)
      : this(new TextureRegion(texture), left, right, top, bottom)
    {
    }

    [LineNumberTable(new byte[] {67, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NinePatch(Texture texture, Color color)
      : this(texture)
    {
      NinePatch ninePatch = this;
      this.setColor(color);
    }

    [LineNumberTable(new byte[] {78, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NinePatch(TextureRegion region, Color color)
      : this(region)
    {
      NinePatch ninePatch = this;
      this.setColor(color);
    }

    [LineNumberTable(new byte[] {97, 232, 159, 146, 149, 117, 117, 149, 144, 255, 13, 160, 103, 105, 144, 135, 104, 191, 20, 176, 104, 191, 20, 176, 104, 191, 20, 176, 105, 191, 23, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NinePatch(params TextureRegion[] patches)
    {
      NinePatch ninePatch = this;
      Color.__\u003Cclinit\u003E();
      this.color = new Color(Color.__\u003C\u003Ewhite);
      this.bottomLeft = -1;
      this.bottomCenter = -1;
      this.bottomRight = -1;
      this.middleLeft = -1;
      this.middleCenter = -1;
      this.middleRight = -1;
      this.topLeft = -1;
      this.topCenter = -1;
      this.topRight = -1;
      this.vertices = new float[216];
      this.padLeft = -1f;
      this.padRight = -1f;
      this.padTop = -1f;
      this.padBottom = -1f;
      if (patches == null || patches.Length != 9)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("NinePatch needs nine TextureRegions");
      }
      this.load(patches);
      float leftWidth = this.getLeftWidth();
      if (patches[0] != null && (double) patches[0].width != (double) leftWidth || patches[3] != null && (double) patches[3].width != (double) leftWidth || patches[6] != null && (double) patches[6].width != (double) leftWidth)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Left side patches must have the same width");
      }
      float rightWidth = this.getRightWidth();
      if (patches[2] != null && (double) patches[2].width != (double) rightWidth || patches[5] != null && (double) patches[5].width != (double) rightWidth || patches[8] != null && (double) patches[8].width != (double) rightWidth)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Right side patches must have the same width");
      }
      float bottomHeight = this.getBottomHeight();
      if (patches[6] != null && (double) patches[6].height != (double) bottomHeight || patches[7] != null && (double) patches[7].height != (double) bottomHeight || patches[8] != null && (double) patches[8].height != (double) bottomHeight)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Bottom side patches must have the same height");
      }
      float topHeight = this.getTopHeight();
      if (patches[0] != null && (double) patches[0].height != (double) topHeight || patches[1] != null && (double) patches[1].height != (double) topHeight || patches[2] != null && (double) patches[2].height != (double) topHeight)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Top side patches must have the same height");
      }
    }

    [LineNumberTable(new byte[] {160, 69, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NinePatch(NinePatch ninePatch)
      : this(ninePatch, ninePatch.color)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color getColor() => this.color;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLeftWidth(float leftWidth) => this.leftWidth = leftWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRightWidth(float rightWidth) => this.rightWidth = rightWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTopHeight(float topHeight) => this.topHeight = topHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBottomHeight(float bottomHeight) => this.bottomHeight = bottomHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMiddleWidth() => this.middleWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMiddleWidth(float middleWidth) => this.middleWidth = middleWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMiddleHeight() => this.middleHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMiddleHeight(float middleHeight) => this.middleHeight = middleHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPadding(float left, float right, float top, float bottom)
    {
      this.padLeft = left;
      this.padRight = right;
      this.padTop = top;
      this.padBottom = bottom;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPadLeft(float left) => this.padLeft = left;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPadRight(float right) => this.padRight = right;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPadTop(float top) => this.padTop = top;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPadBottom(float bottom) => this.padBottom = bottom;

    [LineNumberTable(new byte[] {161, 170, 112, 112, 112, 112, 112, 112, 125, 125, 125, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void scale(float scaleX, float scaleY)
    {
      this.leftWidth *= scaleX;
      this.rightWidth *= scaleX;
      this.topHeight *= scaleY;
      this.bottomHeight *= scaleY;
      this.middleWidth *= scaleX;
      this.middleHeight *= scaleY;
      if ((double) this.padLeft != -1.0)
        this.padLeft *= scaleX;
      if ((double) this.padRight != -1.0)
        this.padRight *= scaleX;
      if ((double) this.padTop != -1.0)
        this.padTop *= scaleY;
      if ((double) this.padBottom == -1.0)
        return;
      this.padBottom *= scaleY;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Texture getTexture() => this.texture;

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static NinePatch()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.g2d.NinePatch"))
        return;
      NinePatch.tmpDrawColor = new Color();
    }
  }
}
