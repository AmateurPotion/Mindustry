// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.SpriteBatch
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.gl;
using arc.math;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g2d
{
  public class SpriteBatch : Batch
  {
    public const int VERTEX_SIZE = 6;
    public const int SPRITE_SIZE = 24;
    internal float[] __\u003C\u003Evertices;
    internal int totalRenderCalls;
    internal int maxSpritesInBatch;

    [LineNumberTable(new byte[] {159, 188, 232, 34, 135, 231, 94, 159, 14, 103, 159, 13, 255, 26, 71, 143, 100, 103, 98, 107, 101, 106, 106, 106, 106, 231, 58, 240, 72, 141, 99, 107, 137, 135, 98, 108, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SpriteBatch(int size, Shader defaultShader)
    {
      SpriteBatch spriteBatch = this;
      this.totalRenderCalls = 0;
      this.maxSpritesInBatch = 0;
      if (size > 8191)
      {
        string str = new StringBuilder().append("Can't have more than 8191 sprites per batch: ").append(size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (size > 0)
      {
        this.__\u003C\u003EprojectionMatrix.setOrtho(0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
        this.mesh = new Mesh(true, false, size * 4, size * 6, new VertexAttribute[4]
        {
          VertexAttribute.__\u003C\u003Eposition,
          VertexAttribute.__\u003C\u003Ecolor,
          VertexAttribute.__\u003C\u003EtexCoords,
          VertexAttribute.__\u003C\u003EmixColor
        });
        this.__\u003C\u003Evertices = new float[size * 24];
        int length = size * 6;
        short[] indices = new short[length];
        int num = 0;
        int index = 0;
        while (index < length)
        {
          indices[index] = (short) num;
          indices[index + 1] = (short) (num + 1);
          indices[index + 2] = (short) (num + 2);
          indices[index + 3] = (short) (num + 2);
          indices[index + 4] = (short) (num + 3);
          indices[index + 5] = (short) num;
          index += 6;
          num = (int) (short) (num + 4);
        }
        this.mesh.setIndices(indices);
        if (defaultShader == null)
        {
          this.shader = SpriteBatch.createShader();
          this.ownsShader = true;
        }
        else
          this.shader = defaultShader;
      }
      else
      {
        this.__\u003C\u003Evertices = new float[0];
        this.shader = (Shader) null;
      }
    }

    [LineNumberTable(258)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Shader createShader() => new Shader("attribute vec4 a_position;\nattribute vec4 a_color;\nattribute vec2 a_texCoord0;\nattribute vec4 a_mix_color;\nuniform mat4 u_projTrans;\nvarying vec4 v_color;\nvarying vec4 v_mix_color;\nvarying vec2 v_texCoords;\n\nvoid main(){\n   v_color = a_color;\n   v_color.a = v_color.a * (255.0/254.0);\n   v_mix_color = a_mix_color;\n   v_mix_color.a *= (255.0/254.0);\n   v_texCoords = a_texCoord0;\n   gl_Position = u_projTrans * a_position;\n}", "\nvarying lowp vec4 v_color;\nvarying lowp vec4 v_mix_color;\nvarying highp vec2 v_texCoords;\nuniform highp sampler2D u_texture;\n\nvoid main(){\n  vec4 c = texture2D(u_texture, v_texCoords);\n  gl_FragColor = v_color * mix(c, vec4(v_mix_color.rgb, c.a), v_mix_color.a);\n}");

    [LineNumberTable(new byte[] {39, 137, 107, 134, 112, 171, 102, 110, 106, 112, 132, 139, 107, 103, 116, 109, 109, 143, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void flush()
    {
      if (this.idx == 0)
        return;
      this.getShader().bind();
      this.setupMatrices();
      if (this.customShader != null && this.apply)
        this.customShader.apply();
      Gl.depthMask(false);
      ++this.totalRenderCalls;
      int num = this.idx / 24;
      if (num > this.maxSpritesInBatch)
        this.maxSpritesInBatch = num;
      int count = num * 6;
      this.blending.apply();
      this.lastTexture.bind();
      Mesh mesh = this.mesh;
      mesh.setVertices(this.__\u003C\u003Evertices, 0, this.idx);
      ((Buffer) mesh.getIndicesBuffer()).position(0);
      ((Buffer) mesh.getIndicesBuffer()).limit(count);
      mesh.render(this.getShader(), 4, 0, count);
      this.idx = 0;
    }

    [LineNumberTable(new byte[] {159, 167, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SpriteBatch()
      : this(4096, (Shader) null)
    {
    }

    [LineNumberTable(new byte[] {159, 175, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SpriteBatch(int size)
      : this(size, (Shader) null)
    {
    }

    [LineNumberTable(new byte[] {69, 104, 98, 110, 137, 105, 99, 102, 162, 137, 116, 110, 102, 101, 101, 102, 105, 111, 110, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void draw(
      Texture texture,
      float[] spriteVertices,
      int offset,
      int count)
    {
      int length = this.__\u003C\u003Evertices.Length;
      int num1 = length;
      if (!object.ReferenceEquals((object) texture, (object) this.lastTexture))
      {
        this.switchTexture(texture);
      }
      else
      {
        num1 -= this.idx;
        if (num1 == 0)
        {
          this.flush();
          num1 = length;
        }
      }
      int num2 = Math.min(num1, count);
      ByteCodeHelper.arraycopy_primitive_4((Array) spriteVertices, offset, (Array) this.__\u003C\u003Evertices, this.idx, num2);
      this.idx += num2;
      for (count -= num2; count > 0; count -= num2)
      {
        offset += num2;
        this.flush();
        num2 = Math.min(length, count);
        ByteCodeHelper.arraycopy_primitive_4((Array) spriteVertices, offset, (Array) this.__\u003C\u003Evertices, 0, num2);
        this.idx += num2;
      }
    }

    [LineNumberTable(new byte[] {98, 103, 110, 105, 111, 166, 103, 103, 143, 141, 104, 105, 102, 102, 106, 170, 107, 139, 115, 116, 115, 116, 115, 116, 108, 140, 104, 104, 104, 136, 104, 136, 101, 103, 103, 103, 103, 135, 103, 103, 103, 104, 104, 136, 104, 104, 104, 104, 104, 136, 104, 104, 104, 104, 104, 104, 101, 104, 105, 104, 104, 104, 136, 104, 136, 101, 103, 103, 103, 103, 135, 103, 103, 103, 104, 104, 136, 103, 104, 104, 104, 104, 136, 103, 104, 104, 104, 104, 136})]
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
      Texture texture = region.texture;
      if (!object.ReferenceEquals((object) texture, (object) this.lastTexture))
        this.switchTexture(texture);
      else if (this.idx == this.__\u003C\u003Evertices.Length)
        this.flush();
      float[] vertices = this.__\u003C\u003Evertices;
      int idx = this.idx;
      this.idx += 24;
      if (!Mathf.zero(rotation))
      {
        float num1 = x + originX;
        float num2 = y + originY;
        float num3 = -originX;
        float num4 = -originY;
        float num5 = width - originX;
        float num6 = height - originY;
        float num7 = Mathf.cosDeg(rotation);
        float num8 = Mathf.sinDeg(rotation);
        float num9 = num7 * num3 - num8 * num4 + num1;
        float num10 = num8 * num3 + num7 * num4 + num2;
        float num11 = num7 * num3 - num8 * num6 + num1;
        float num12 = num8 * num3 + num7 * num6 + num2;
        float num13 = num7 * num5 - num8 * num6 + num1;
        float num14 = num8 * num5 + num7 * num6 + num2;
        float num15 = num9 + (num13 - num11);
        float num16 = num14 - (num12 - num10);
        float u = region.u;
        float v2 = region.v2;
        float u2 = region.u2;
        float v = region.v;
        float colorPacked = this.colorPacked;
        float mixColorPacked = this.mixColorPacked;
        vertices[idx] = num9;
        vertices[idx + 1] = num10;
        vertices[idx + 2] = colorPacked;
        vertices[idx + 3] = u;
        vertices[idx + 4] = v2;
        vertices[idx + 5] = mixColorPacked;
        vertices[idx + 6] = num11;
        vertices[idx + 7] = num12;
        vertices[idx + 8] = colorPacked;
        vertices[idx + 9] = u;
        vertices[idx + 10] = v;
        vertices[idx + 11] = mixColorPacked;
        vertices[idx + 12] = num13;
        vertices[idx + 13] = num14;
        vertices[idx + 14] = colorPacked;
        vertices[idx + 15] = u2;
        vertices[idx + 16] = v;
        vertices[idx + 17] = mixColorPacked;
        vertices[idx + 18] = num15;
        vertices[idx + 19] = num16;
        vertices[idx + 20] = colorPacked;
        vertices[idx + 21] = u2;
        vertices[idx + 22] = v2;
        vertices[idx + 23] = mixColorPacked;
      }
      else
      {
        float num1 = x + width;
        float num2 = y + height;
        float u = region.u;
        float v2 = region.v2;
        float u2 = region.u2;
        float v = region.v;
        float colorPacked = this.colorPacked;
        float mixColorPacked = this.mixColorPacked;
        vertices[idx] = x;
        vertices[idx + 1] = y;
        vertices[idx + 2] = colorPacked;
        vertices[idx + 3] = u;
        vertices[idx + 4] = v2;
        vertices[idx + 5] = mixColorPacked;
        vertices[idx + 6] = x;
        vertices[idx + 7] = num2;
        vertices[idx + 8] = colorPacked;
        vertices[idx + 9] = u;
        vertices[idx + 10] = v;
        vertices[idx + 11] = mixColorPacked;
        vertices[idx + 12] = num1;
        vertices[idx + 13] = num2;
        vertices[idx + 14] = colorPacked;
        vertices[idx + 15] = u2;
        vertices[idx + 16] = v;
        vertices[idx + 17] = mixColorPacked;
        vertices[idx + 18] = num1;
        vertices[idx + 19] = y;
        vertices[idx + 20] = colorPacked;
        vertices[idx + 21] = u2;
        vertices[idx + 22] = v2;
        vertices[idx + 23] = mixColorPacked;
      }
    }

    [Modifiers]
    protected internal float[] vertices
    {
      [HideFromJava] get => this.__\u003C\u003Evertices;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Evertices = value;
    }
  }
}
