// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.SpriteCache
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.graphics.gl;
using arc.math;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g2d
{
  public class SpriteCache : Object, Disposable
  {
    internal const int VERTEX_SIZE = 5;
    [Modifiers]
    private static float[] tempVertices;
    [Modifiers]
    private Mesh mesh;
    [Modifiers]
    private Mat transformMatrix;
    [Modifiers]
    private Mat projectionMatrix;
    [Modifiers]
    private Mat combinedMatrix;
    [Modifiers]
    private Shader shader;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/graphics/Texture;>;")]
    private Seq textures;
    [Modifiers]
    private IntSeq counts;
    [Modifiers]
    private Color color;
    public int renderCalls;
    public int totalRenderCalls;
    private bool drawing;
    [Signature("Larc/struct/Seq<Larc/graphics/g2d/SpriteCache$Cache;>;")]
    private Seq caches;
    private SpriteCache.Cache currentCache;
    private float colorPacked;
    private Shader customShader;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 123, 162, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SpriteCache(int size, bool useIndices)
    {
      int num = useIndices ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(size, 16, SpriteCache.createDefaultShader(), num != 0);
    }

    [LineNumberTable(new byte[] {114, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColor(Color tint)
    {
      this.color.set(tint);
      this.colorPacked = tint.toFloatBits();
    }

    [LineNumberTable(new byte[] {104, 117, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColor(float r, float g, float b, float a)
    {
      this.color.set(r, g, b, a);
      this.colorPacked = this.color.toFloatBits();
    }

    [LineNumberTable(new byte[] {127, 110, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPackedColor(float packedColor)
    {
      this.color.abgr8888(packedColor);
      this.colorPacked = packedColor;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color getColor() => this.color;

    [LineNumberTable(new byte[] {161, 214, 120, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setProjectionMatrix(Mat projection)
    {
      if (this.drawing)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Can't set the matrix within begin/end.");
      }
      this.projectionMatrix.set(projection);
    }

    [LineNumberTable(new byte[] {160, 69, 120, 120, 127, 45, 127, 7, 113, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginCache()
    {
      if (this.drawing)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("end must be called before beginCache");
      }
      if (this.currentCache != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("endCache must be called before begin.");
      }
      ((Buffer) this.mesh.getVerticesBuffer()).position(!this.caches.isEmpty() ? ((SpriteCache.Cache) this.caches.peek()).offset + ((SpriteCache.Cache) this.caches.peek()).maxCount : 0);
      this.currentCache = new SpriteCache.Cache(this.caches.size, ((Buffer) this.mesh.getVerticesBuffer()).position());
      this.caches.add((object) this.currentCache);
      ((Buffer) this.mesh.getVerticesBuffer()).limit(((Buffer) this.mesh.getVerticesBuffer()).capacity());
    }

    [LineNumberTable(new byte[] {160, 91, 120, 103, 120, 139, 103, 113, 123, 113, 114, 52, 203, 105, 255, 37, 69, 145, 127, 1, 109, 57, 166, 127, 1, 109, 52, 166, 109, 105, 127, 0, 183, 103, 108, 171, 108, 178})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int endCache()
    {
      if (this.currentCache == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("beginCache must be called before endCache.");
      }
      SpriteCache.Cache currentCache = this.currentCache;
      int num = ((Buffer) this.mesh.getVerticesBuffer()).position() - currentCache.offset;
      if (currentCache.textures == null)
      {
        currentCache.maxCount = num;
        currentCache.textureCount = this.textures.size;
        currentCache.textures = (Texture[]) this.textures.toArray((Class) ClassLiteral<Texture>.Value);
        currentCache.counts = new int[currentCache.textureCount];
        int index = 0;
        for (int size = this.counts.size; index < size; ++index)
          currentCache.counts[index] = this.counts.get(index);
      }
      else
      {
        if (num > currentCache.maxCount)
        {
          string message = new StringBuilder().append("If a cache is not the last created, it cannot be redefined with more entries than when it was first created: ").append(num).append(" (").append(currentCache.maxCount).append(" max)").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message);
        }
        currentCache.textureCount = this.textures.size;
        if (currentCache.textures.Length < currentCache.textureCount)
          currentCache.textures = new Texture[currentCache.textureCount];
        int index1 = 0;
        for (int textureCount = currentCache.textureCount; index1 < textureCount; ++index1)
          currentCache.textures[index1] = (Texture) this.textures.get(index1);
        if (currentCache.counts.Length < currentCache.textureCount)
          currentCache.counts = new int[currentCache.textureCount];
        int index2 = 0;
        for (int textureCount = currentCache.textureCount; index2 < textureCount; ++index2)
          currentCache.counts[index2] = this.counts.get(index2);
        FloatBuffer verticesBuffer = this.mesh.getVerticesBuffer();
        ((Buffer) verticesBuffer).position(0);
        SpriteCache.Cache cache = (SpriteCache.Cache) this.caches.get(this.caches.size - 1);
        ((Buffer) verticesBuffer).limit(cache.offset + cache.maxCount);
      }
      this.currentCache = (SpriteCache.Cache) null;
      this.textures.clear();
      this.counts.clear();
      if (Core.app.isWeb())
        ((Buffer) this.mesh.getVerticesBuffer()).position(0);
      return currentCache.id;
    }

    [LineNumberTable(new byte[] {160, 171, 120, 127, 6, 159, 55, 115, 113, 110, 120, 108, 142, 141, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Texture texture, float[] vertices, int offset, int length)
    {
      if (this.currentCache == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("beginCache must be called before add.");
      }
      if (((Buffer) this.mesh.getVerticesBuffer()).position() + length >= ((Buffer) this.mesh.getVerticesBuffer()).limit())
      {
        string str = new StringBuilder().append("Out of vertex space! Size: ").append(((Buffer) this.mesh.getVerticesBuffer()).capacity()).append(" Required: ").append(((Buffer) this.mesh.getVerticesBuffer()).position() + length).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException(str);
      }
      int num1 = this.mesh.getNumIndices() <= 0 ? 6 : 4;
      int num2 = length;
      int num3 = num1 * 5;
      int num4 = (num3 != -1 ? num2 / num3 : -num2) * 6;
      int index = this.textures.size - 1;
      if (index < 0 || !object.ReferenceEquals(this.textures.get(index), (object) texture))
      {
        this.textures.add((object) texture);
        this.counts.add(num4);
      }
      else
        this.counts.incr(index, num4);
      this.mesh.getVerticesBuffer().put(vertices, offset, length);
    }

    [LineNumberTable(new byte[] {160, 253, 104, 104, 101, 101, 106, 170, 116, 103, 103, 105, 201, 99, 99, 99, 100, 100, 100, 100, 227, 76, 109, 107, 139, 112, 144, 112, 144, 112, 144, 108, 108, 98, 100, 132, 100, 132, 100, 132, 100, 164, 103, 103, 103, 103, 103, 103, 103, 135, 104, 104, 104, 136, 105, 105, 109, 105, 137, 105, 105, 109, 105, 138, 106, 106, 110, 106, 138, 110, 106, 106, 110, 106, 106, 153, 106, 106, 110, 106, 138, 106, 106, 110, 106, 138, 106, 106, 110, 106, 106, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(
      TextureRegion region,
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
      float num1 = x + originX;
      float num2 = y + originY;
      float num3 = -originX;
      float num4 = -originY;
      float num5 = width - originX;
      float num6 = height - originY;
      if ((double) scaleX != 1.0 || (double) scaleY != 1.0)
      {
        num3 *= scaleX;
        num4 *= scaleY;
        num5 *= scaleX;
        num6 *= scaleY;
      }
      float num7 = num3;
      float num8 = num4;
      float num9 = num3;
      float num10 = num6;
      float num11 = num5;
      float num12 = num6;
      float num13 = num5;
      float num14 = num4;
      float num15;
      float num16;
      float num17;
      float num18;
      float num19;
      float num20;
      float num21;
      float num22;
      if ((double) rotation != 0.0)
      {
        float num23 = Mathf.cosDeg(rotation);
        float num24 = Mathf.sinDeg(rotation);
        num15 = num23 * num7 - num24 * num8;
        num16 = num24 * num7 + num23 * num8;
        num17 = num23 * num9 - num24 * num10;
        num18 = num24 * num9 + num23 * num10;
        num19 = num23 * num11 - num24 * num12;
        num20 = num24 * num11 + num23 * num12;
        num21 = num15 + (num19 - num17);
        num22 = num20 - (num18 - num16);
      }
      else
      {
        num15 = num7;
        num16 = num8;
        num17 = num9;
        num18 = num10;
        num19 = num11;
        num20 = num12;
        num21 = num13;
        num22 = num14;
      }
      float num25 = num15 + num1;
      float num26 = num16 + num2;
      float num27 = num17 + num1;
      float num28 = num18 + num2;
      float num29 = num19 + num1;
      float num30 = num20 + num2;
      float num31 = num21 + num1;
      float num32 = num22 + num2;
      float u = region.u;
      float v2 = region.v2;
      float u2 = region.u2;
      float v = region.v;
      SpriteCache.tempVertices[0] = num25;
      SpriteCache.tempVertices[1] = num26;
      SpriteCache.tempVertices[2] = this.colorPacked;
      SpriteCache.tempVertices[3] = u;
      SpriteCache.tempVertices[4] = v2;
      SpriteCache.tempVertices[5] = num27;
      SpriteCache.tempVertices[6] = num28;
      SpriteCache.tempVertices[7] = this.colorPacked;
      SpriteCache.tempVertices[8] = u;
      SpriteCache.tempVertices[9] = v;
      SpriteCache.tempVertices[10] = num29;
      SpriteCache.tempVertices[11] = num30;
      SpriteCache.tempVertices[12] = this.colorPacked;
      SpriteCache.tempVertices[13] = u2;
      SpriteCache.tempVertices[14] = v;
      if (this.mesh.getNumIndices() > 0)
      {
        SpriteCache.tempVertices[15] = num31;
        SpriteCache.tempVertices[16] = num32;
        SpriteCache.tempVertices[17] = this.colorPacked;
        SpriteCache.tempVertices[18] = u2;
        SpriteCache.tempVertices[19] = v2;
        this.add(region.texture, SpriteCache.tempVertices, 0, 20);
      }
      else
      {
        SpriteCache.tempVertices[15] = num29;
        SpriteCache.tempVertices[16] = num30;
        SpriteCache.tempVertices[17] = this.colorPacked;
        SpriteCache.tempVertices[18] = u2;
        SpriteCache.tempVertices[19] = v;
        SpriteCache.tempVertices[20] = num31;
        SpriteCache.tempVertices[21] = num32;
        SpriteCache.tempVertices[22] = this.colorPacked;
        SpriteCache.tempVertices[23] = u2;
        SpriteCache.tempVertices[24] = v2;
        SpriteCache.tempVertices[25] = num25;
        SpriteCache.tempVertices[26] = num26;
        SpriteCache.tempVertices[27] = this.colorPacked;
        SpriteCache.tempVertices[28] = u;
        SpriteCache.tempVertices[29] = v2;
        this.add(region.texture, SpriteCache.tempVertices, 0, 30);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDrawing() => this.drawing;

    [LineNumberTable(new byte[] {161, 138, 120, 135, 102, 104, 147, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void end()
    {
      if (!this.drawing)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("begin must be called before end.");
      }
      this.drawing = false;
      Gl.depthMask(true);
      if (this.customShader != null)
        this.mesh.unbind(this.customShader);
      else
        this.mesh.unbind(this.shader);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setShader(Shader shader) => this.customShader = shader;

    [LineNumberTable(new byte[] {161, 124, 120, 120, 103, 125, 119, 102, 113, 108, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void begin()
    {
      if (this.drawing)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("end must be called before begin.");
      }
      if (this.currentCache != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("endCache must be called before begin");
      }
      this.renderCalls = 0;
      this.combinedMatrix.set(this.projectionMatrix).mul(this.transformMatrix);
      Shader shader = this.customShader == null ? this.shader : this.customShader;
      shader.bind();
      shader.setUniformMatrix4("u_projectionViewMatrix", this.combinedMatrix);
      shader.setUniformi("u_texture", 0);
      this.mesh.bind(shader);
      this.drawing = true;
    }

    [LineNumberTable(new byte[] {161, 205, 107, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      this.mesh.dispose();
      if (this.shader == null)
        return;
      this.shader.dispose();
    }

    [LineNumberTable(new byte[] {161, 150, 152, 114, 115, 117, 103, 104, 104, 120, 105, 103, 137, 113, 229, 59, 232, 71, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(int cacheID)
    {
      if (!this.drawing)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("SpriteCache.begin must be called before draw.");
      }
      SpriteCache.Cache cache = (SpriteCache.Cache) this.caches.get(cacheID);
      int num1 = this.mesh.getNumIndices() <= 0 ? 6 : 4;
      int offset1 = cache.offset;
      int num2 = num1 * 5;
      int offset2 = (num2 != -1 ? offset1 / num2 : -offset1) * 6;
      Texture[] textures = cache.textures;
      int[] counts = cache.counts;
      int textureCount = cache.textureCount;
      Shader shader = this.customShader == null ? this.shader : this.customShader;
      for (int index = 0; index < textureCount; ++index)
      {
        int count = counts[index];
        textures[index].bind();
        this.mesh.render(shader, 4, offset2, count);
        offset2 += count;
      }
      this.renderCalls += textureCount;
      this.totalRenderCalls += textureCount;
    }

    [LineNumberTable(new byte[] {75, 230, 77, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Shader createDefaultShader() => new Shader("attribute vec4 a_position;\nattribute vec4 a_color;\nattribute vec2 a_texCoord0;\nuniform mat4 u_projectionViewMatrix;\nvarying vec4 v_color;\nvarying vec2 v_texCoords;\n\nvoid main(){\n   v_color = a_color;\n   v_color.a = v_color.a * (255.0/254.0);\n   v_texCoords = a_texCoord0;\n   gl_Position =  u_projectionViewMatrix * a_position;\n}\n", "varying vec4 v_color;\nvarying vec2 v_texCoords;\nuniform sampler2D u_texture;\nvoid main(){\n  gl_FragColor = v_color * texture2D(u_texture, v_texCoords);\n}");

    [LineNumberTable(new byte[] {159, 119, 67, 232, 22, 107, 107, 139, 108, 108, 159, 0, 135, 199, 107, 231, 92, 135, 107, 159, 6, 255, 29, 69, 108, 140, 102, 100, 103, 99, 107, 102, 107, 107, 107, 107, 232, 58, 242, 72, 173, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SpriteCache(int size, int cacheSize, Shader shader, bool useIndices)
    {
      int num1 = useIndices ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      SpriteCache spriteCache = this;
      this.transformMatrix = new Mat();
      this.projectionMatrix = new Mat();
      this.combinedMatrix = new Mat();
      this.textures = new Seq(8);
      this.counts = new IntSeq(8);
      this.color = new Color(1f, 1f, 1f, 1f);
      this.renderCalls = 0;
      this.totalRenderCalls = 0;
      this.colorPacked = Color.__\u003C\u003EwhiteFloatBits;
      this.customShader = (Shader) null;
      this.shader = shader;
      if (num1 != 0 && size > 8191)
      {
        string str = new StringBuilder().append("Can't have more than 8191 sprites per batch: ").append(size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.mesh = new Mesh(true, size * (num1 == 0 ? 6 : 4), num1 == 0 ? 0 : size * 6, new VertexAttribute[3]
      {
        VertexAttribute.__\u003C\u003Eposition,
        VertexAttribute.__\u003C\u003Ecolor,
        VertexAttribute.__\u003C\u003EtexCoords
      });
      this.mesh.setAutoBind(false);
      this.caches = new Seq(cacheSize);
      if (num1 != 0)
      {
        int length = size * 6;
        short[] indices = new short[length];
        int num2 = 0;
        int index = 0;
        while (index < length)
        {
          indices[index] = (short) num2;
          indices[index + 1] = (short) (num2 + 1);
          indices[index + 2] = (short) (num2 + 2);
          indices[index + 3] = (short) (num2 + 2);
          indices[index + 4] = (short) (num2 + 3);
          indices[index + 5] = (short) num2;
          index += 6;
          num2 = (int) (short) (num2 + 4);
        }
        this.mesh.setIndices(indices);
      }
      this.projectionMatrix.setOrtho(0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPackedColor() => this.colorPacked;

    [LineNumberTable(new byte[] {160, 147, 184, 149, 140, 132, 100, 100, 115, 127, 9, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int reserve(int sprites)
    {
      if (this.currentCache == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("beginCache must be called before ensureSize.");
      }
      int num1 = 5 * (this.mesh.getNumIndices() <= 0 ? 6 : 4);
      int maxCount = this.currentCache.maxCount;
      int num2 = sprites * num1 - maxCount;
      if (num2 <= 0)
        return 0;
      this.currentCache.maxCount += num2;
      ((Buffer) this.mesh.getVerticesBuffer()).position(this.currentCache.offset + this.currentCache.maxCount);
      int num3 = num2;
      int num4 = num1;
      return num4 == -1 ? -num3 : num3 / num4;
    }

    [LineNumberTable(new byte[] {160, 82, 120, 120, 119, 113, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginCache(int cacheID)
    {
      if (this.drawing)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("end must be called before beginCache");
      }
      if (this.currentCache != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("endCache must be called before begin.");
      }
      this.currentCache = (SpriteCache.Cache) this.caches.get(cacheID);
      Arrays.fill(this.currentCache.counts, 0);
      ((Buffer) this.mesh.getVerticesBuffer()).position(this.currentCache.offset);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat getProjectionMatrix() => this.projectionMatrix;

    [LineNumberTable(new byte[] {160, 194, 104, 104, 103, 103, 104, 136, 105, 105, 109, 104, 136, 105, 104, 109, 104, 138, 105, 105, 110, 106, 138, 110, 105, 106, 110, 106, 105, 153, 105, 105, 110, 106, 138, 105, 106, 110, 106, 137, 106, 106, 110, 105, 105, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(TextureRegion region, float x, float y, float width, float height)
    {
      float num1 = x + width;
      float num2 = y + height;
      float u = region.u;
      float v2 = region.v2;
      float u2 = region.u2;
      float v = region.v;
      SpriteCache.tempVertices[0] = x;
      SpriteCache.tempVertices[1] = y;
      SpriteCache.tempVertices[2] = this.colorPacked;
      SpriteCache.tempVertices[3] = u;
      SpriteCache.tempVertices[4] = v2;
      SpriteCache.tempVertices[5] = x;
      SpriteCache.tempVertices[6] = num2;
      SpriteCache.tempVertices[7] = this.colorPacked;
      SpriteCache.tempVertices[8] = u;
      SpriteCache.tempVertices[9] = v;
      SpriteCache.tempVertices[10] = num1;
      SpriteCache.tempVertices[11] = num2;
      SpriteCache.tempVertices[12] = this.colorPacked;
      SpriteCache.tempVertices[13] = u2;
      SpriteCache.tempVertices[14] = v;
      if (this.mesh.getNumIndices() > 0)
      {
        SpriteCache.tempVertices[15] = num1;
        SpriteCache.tempVertices[16] = y;
        SpriteCache.tempVertices[17] = this.colorPacked;
        SpriteCache.tempVertices[18] = u2;
        SpriteCache.tempVertices[19] = v2;
        this.add(region.texture, SpriteCache.tempVertices, 0, 20);
      }
      else
      {
        SpriteCache.tempVertices[15] = num1;
        SpriteCache.tempVertices[16] = num2;
        SpriteCache.tempVertices[17] = this.colorPacked;
        SpriteCache.tempVertices[18] = u2;
        SpriteCache.tempVertices[19] = v;
        SpriteCache.tempVertices[20] = num1;
        SpriteCache.tempVertices[21] = y;
        SpriteCache.tempVertices[22] = this.colorPacked;
        SpriteCache.tempVertices[23] = u2;
        SpriteCache.tempVertices[24] = v2;
        SpriteCache.tempVertices[25] = x;
        SpriteCache.tempVertices[26] = y;
        SpriteCache.tempVertices[27] = this.colorPacked;
        SpriteCache.tempVertices[28] = u;
        SpriteCache.tempVertices[29] = v2;
        this.add(region.texture, SpriteCache.tempVertices, 0, 30);
      }
    }

    [LineNumberTable(new byte[] {19, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SpriteCache()
      : this(1000, false)
    {
    }

    [LineNumberTable(new byte[] {159, 122, 162, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SpriteCache(int size, int cacheSize, bool useIndices)
    {
      int num = useIndices ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(size, cacheSize, SpriteCache.createDefaultShader(), num != 0);
    }

    [Signature("()Larc/struct/Seq<Larc/graphics/g2d/SpriteCache$Cache;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getCaches() => this.caches;

    [LineNumberTable(new byte[] {160, 140, 108, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      this.caches.clear();
      ((Buffer) this.mesh.getVerticesBuffer()).clear().flip();
    }

    [LineNumberTable(new byte[] {160, 189, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(TextureRegion region, float x, float y) => this.add(region, x, y, (float) region.width, (float) region.height);

    [LineNumberTable(new byte[] {161, 176, 152, 114, 108, 101, 103, 103, 103, 107, 105, 102, 101, 99, 133, 102, 104, 151, 117, 230, 52, 235, 78, 115, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(int cacheID, int offset, int length)
    {
      if (!this.drawing)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("SpriteCache.begin must be called before draw.");
      }
      SpriteCache.Cache cache = (SpriteCache.Cache) this.caches.get(cacheID);
      offset = offset * 6 + cache.offset;
      length *= 6;
      Texture[] textures = cache.textures;
      int[] counts = cache.counts;
      int textureCount = cache.textureCount;
      for (int index = 0; index < textureCount; ++index)
      {
        textures[index].bind();
        int count = counts[index];
        if (count > length)
        {
          index = textureCount;
          count = length;
        }
        else
          length -= count;
        if (this.customShader != null)
          this.mesh.render(this.customShader, 4, offset, count);
        else
          this.mesh.render(this.shader, 4, offset, count);
        offset += count;
      }
      this.renderCalls += cache.textureCount;
      this.totalRenderCalls += textureCount;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat getTransformMatrix() => this.transformMatrix;

    [LineNumberTable(new byte[] {161, 223, 120, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTransformMatrix(Mat transform)
    {
      if (this.drawing)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Can't set the matrix within begin/end.");
      }
      this.transformMatrix.set(transform);
    }

    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SpriteCache()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.g2d.SpriteCache"))
        return;
      SpriteCache.tempVertices = new float[30];
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [InnerClass]
    internal class Cache : Object
    {
      [Modifiers]
      internal int id;
      [Modifiers]
      internal int offset;
      internal int maxCount;
      internal int textureCount;
      internal Texture[] textures;
      internal int[] counts;

      [LineNumberTable(new byte[] {161, 253, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Cache([In] int obj0, [In] int obj1)
      {
        SpriteCache.Cache cache = this;
        this.id = obj0;
        this.offset = obj1;
      }
    }
  }
}
