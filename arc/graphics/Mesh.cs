// Decompiled with JetBrains decompiler
// Type: arc.graphics.Mesh
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.gl;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics
{
  public class Mesh : Object, Disposable
  {
    internal int __\u003C\u003EvertexSize;
    internal VertexAttribute[] __\u003C\u003Eattributes;
    internal VertexData __\u003C\u003Evertices;
    internal IndexData __\u003C\u003Eindices;
    internal bool autoBind;

    [LineNumberTable(new byte[] {159, 130, 162, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Mesh(
      bool isStatic,
      int maxVertices,
      int maxIndices,
      params VertexAttribute[] attributes)
      : this(false, isStatic, maxVertices, maxIndices, attributes)
    {
    }

    [LineNumberTable(312)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FloatBuffer getVerticesBuffer() => this.__\u003C\u003Evertices.buffer();

    [LineNumberTable(new byte[] {160, 146, 127, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render(Shader shader, int primitiveType) => this.render(shader, primitiveType, 0, this.__\u003C\u003Eindices.max() <= 0 ? this.getNumVertices() : this.getNumIndices(), this.autoBind);

    [LineNumberTable(new byte[] {160, 192, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      this.__\u003C\u003Evertices.dispose();
      this.__\u003C\u003Eindices.dispose();
    }

    [LineNumberTable(new byte[] {160, 151, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render(Shader shader, int primitiveType, int offset, int count) => this.render(shader, primitiveType, offset, count, this.autoBind);

    [LineNumberTable(112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mesh updateVertices(int targetOffset, float[] source) => this.updateVertices(targetOffset, source, 0, source.Length);

    [LineNumberTable(new byte[] {38, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mesh setVertices(float[] vertices)
    {
      this.__\u003C\u003Evertices.set(vertices, 0, vertices.Length);
      return this;
    }

    [LineNumberTable(214)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getMaxVertices() => this.__\u003C\u003Evertices.max();

    [LineNumberTable(new byte[] {159, 127, 100, 232, 43, 231, 86, 98, 121, 42, 200, 103, 136, 106, 109, 111, 103, 110, 144, 110, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Mesh(
      bool useVertexArray,
      bool isStatic,
      int maxVertices,
      int maxIndices,
      params VertexAttribute[] attributes)
    {
      int num1 = useVertexArray ? 1 : 0;
      int num2 = isStatic ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      Mesh mesh = this;
      this.autoBind = true;
      int num3 = 0;
      VertexAttribute[] vertexAttributeArray = attributes;
      int length = vertexAttributeArray.Length;
      for (int index = 0; index < length; ++index)
      {
        VertexAttribute vertexAttribute = vertexAttributeArray[index];
        num3 += vertexAttribute.__\u003C\u003Esize;
      }
      this.__\u003C\u003EvertexSize = num3;
      this.__\u003C\u003Eattributes = attributes;
      if (num1 != 0 && Core.gl30 == null)
      {
        this.__\u003C\u003Evertices = (VertexData) new VertexArray(maxVertices, this);
        this.__\u003C\u003Eindices = (IndexData) new IndexArray(maxIndices);
      }
      else if (Core.gl30 != null)
      {
        this.__\u003C\u003Evertices = (VertexData) new VertexBufferObjectWithVAO(num2 != 0, maxVertices, this);
        this.__\u003C\u003Eindices = (IndexData) new IndexBufferObjectSubData(num2 != 0, maxIndices);
      }
      else
      {
        this.__\u003C\u003Evertices = (VertexData) new VertexBufferObject(num2 != 0, maxVertices, this);
        this.__\u003C\u003Eindices = (IndexData) new IndexBufferObject(num2 != 0, maxIndices);
      }
    }

    [LineNumberTable(new byte[] {73, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mesh updateVertices(
      int targetOffset,
      float[] source,
      int sourceOffset,
      int count)
    {
      this.__\u003C\u003Evertices.update(targetOffset, source, sourceOffset, count);
      return this;
    }

    [LineNumberTable(new byte[] {116, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getIndices(short[] indices, int destOffset) => this.getIndices(0, indices, destOffset);

    [LineNumberTable(new byte[] {127, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getIndices(int srcOffset, short[] indices, int destOffset) => this.getIndices(srcOffset, -1, indices, destOffset);

    [LineNumberTable(new byte[] {160, 75, 103, 105, 110, 159, 38, 104, 127, 23, 108, 109, 112, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getIndices(int srcOffset, int count, short[] indices, int destOffset)
    {
      int numIndices = this.getNumIndices();
      if (count < 0)
        count = numIndices - srcOffset;
      if (srcOffset < 0 || srcOffset >= numIndices || srcOffset + count > numIndices)
      {
        string str = new StringBuilder().append("Invalid range specified, offset: ").append(srcOffset).append(", count: ").append(count).append(", max: ").append(numIndices).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (indices.Length - destOffset < count)
      {
        string str = new StringBuilder().append("not enough room in indices array, has ").append(indices.Length).append(" shorts, needs ").append(count).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      int num = ((Buffer) this.getIndicesBuffer()).position();
      ((Buffer) this.getIndicesBuffer()).position(srcOffset);
      this.getIndicesBuffer().get(indices, destOffset, count);
      ((Buffer) this.getIndicesBuffer()).position(num);
    }

    [LineNumberTable(204)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getNumIndices() => this.__\u003C\u003Eindices.size();

    [LineNumberTable(317)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ShortBuffer getIndicesBuffer() => this.__\u003C\u003Eindices.buffer();

    [LineNumberTable(209)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getNumVertices() => this.__\u003C\u003Evertices.size();

    [LineNumberTable(new byte[] {159, 69, 131, 133, 138, 149, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render(
      Shader shader,
      int primitiveType,
      int offset,
      int count,
      bool autoBind)
    {
      int num = autoBind ? 1 : 0;
      if (count == 0)
        return;
      if (num != 0)
        this.bind(shader);
      this.__\u003C\u003Evertices.render(this.__\u003C\u003Eindices, primitiveType, offset, count);
      if (num == 0)
        return;
      this.unbind(shader);
    }

    [LineNumberTable(new byte[] {160, 130, 108, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void bind(Shader shader)
    {
      this.__\u003C\u003Evertices.bind(shader);
      if (this.__\u003C\u003Eindices.size() <= 0)
        return;
      this.__\u003C\u003Eindices.bind();
    }

    [LineNumberTable(new byte[] {160, 140, 108, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unbind(Shader shader)
    {
      this.__\u003C\u003Evertices.unbind(shader);
      if (this.__\u003C\u003Eindices.size() <= 0)
        return;
      this.__\u003C\u003Eindices.unbind();
    }

    [LineNumberTable(new byte[] {51, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mesh setVertices(float[] vertices, int offset, int count)
    {
      this.__\u003C\u003Evertices.set(vertices, offset, count);
      return this;
    }

    [LineNumberTable(new byte[] {83, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mesh setIndices(short[] indices)
    {
      this.__\u003C\u003Eindices.set(indices, 0, indices.Length);
      return this;
    }

    [LineNumberTable(new byte[] {96, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mesh setIndices(short[] indices, int offset, int count)
    {
      this.__\u003C\u003Eindices.set(indices, offset, count);
      return this;
    }

    [LineNumberTable(new byte[] {106, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getIndices(short[] indices) => this.getIndices(indices, 0);

    [LineNumberTable(219)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getMaxIndices() => this.__\u003C\u003Eindices.max();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getVertexSize() => this.__\u003C\u003EvertexSize;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAutoBind(bool autoBind) => this.autoBind = autoBind;

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [Modifiers]
    public int vertexSize
    {
      [HideFromJava] get => this.__\u003C\u003EvertexSize;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EvertexSize = value;
    }

    [Modifiers]
    public VertexAttribute[] attributes
    {
      [HideFromJava] get => this.__\u003C\u003Eattributes;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eattributes = value;
    }

    [Modifiers]
    public VertexData vertices
    {
      [HideFromJava] get => this.__\u003C\u003Evertices;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Evertices = value;
    }

    [Modifiers]
    public IndexData indices
    {
      [HideFromJava] get => this.__\u003C\u003Eindices;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eindices = value;
    }
  }
}
