// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.VertexArray
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;

namespace arc.graphics.gl
{
  [Implements(new string[] {"arc.graphics.gl.VertexData"})]
  public class VertexArray : Object, VertexData, Disposable
  {
    [Modifiers]
    internal Mesh mesh;
    [Modifiers]
    internal FloatBuffer buffer;
    [Modifiers]
    internal ByteBuffer byteBuffer;
    internal bool isBound;

    [LineNumberTable(new byte[] {159, 171, 232, 58, 231, 71, 103, 120, 113, 108, 140, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VertexArray(int numVertices, Mesh mesh)
    {
      VertexArray vertexArray = this;
      this.isBound = false;
      this.mesh = mesh;
      this.byteBuffer = Buffers.newUnsafeByteBuffer(this.mesh.__\u003C\u003EvertexSize * numVertices);
      this.buffer = this.byteBuffer.asFloatBuffer();
      ((Buffer) this.buffer).flip();
      ((Buffer) this.byteBuffer).flip();
      this.byteBuffer.asFloatBuffer();
    }

    [LineNumberTable(new byte[] {159, 183, 105, 103, 103, 103, 104, 107, 110, 104, 104, 98, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render(IndexData indices, int primitiveType, int offset, int count)
    {
      if (indices.size() > 0)
      {
        ShortBuffer shortBuffer = indices.buffer();
        int num1 = ((Buffer) shortBuffer).position();
        int num2 = ((Buffer) shortBuffer).limit();
        ((Buffer) shortBuffer).position(offset);
        ((Buffer) shortBuffer).limit(offset + count);
        Gl.drawElements(primitiveType, count, 5123, (Buffer) shortBuffer);
        ((Buffer) shortBuffer).position(num1);
        ((Buffer) shortBuffer).limit(num2);
      }
      else
        Gl.drawArrays(primitiveType, offset, count);
    }

    [LineNumberTable(new byte[] {7, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose() => Buffers.disposeUnsafeByteBuffer(this.byteBuffer);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FloatBuffer buffer() => this.buffer;

    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size()
    {
      int num = ((Buffer) this.buffer).limit() * 4;
      int vertexSize = this.mesh.__\u003C\u003EvertexSize;
      return vertexSize == -1 ? -num : num / vertexSize;
    }

    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int max()
    {
      int num = ((Buffer) this.byteBuffer).capacity();
      int vertexSize = this.mesh.__\u003C\u003EvertexSize;
      return vertexSize == -1 ? -num : num / vertexSize;
    }

    [LineNumberTable(new byte[] {27, 110, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float[] vertices, int offset, int count)
    {
      Buffers.copy(vertices, (Buffer) this.byteBuffer, count, offset);
      ((Buffer) this.buffer).position(0);
      ((Buffer) this.buffer).limit(count);
    }

    [LineNumberTable(new byte[] {34, 108, 111, 111, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(int targetOffset, float[] vertices, int sourceOffset, int count)
    {
      int num = ((Buffer) this.byteBuffer).position();
      ((Buffer) this.byteBuffer).position(targetOffset * 4);
      Buffers.copy(vertices, sourceOffset, count, (Buffer) this.byteBuffer);
      ((Buffer) this.byteBuffer).position(num);
    }

    [LineNumberTable(new byte[] {42, 153, 98, 125, 111, 99, 106, 106, 136, 110, 112, 159, 17, 110, 255, 15, 52, 233, 80, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void bind(Shader shader)
    {
      ((Buffer) this.byteBuffer).limit(((Buffer) this.buffer).limit() * 4);
      int num1 = 0;
      VertexAttribute[] attributes = this.mesh.__\u003C\u003Eattributes;
      int length = attributes.Length;
      for (int index = 0; index < length; ++index)
      {
        VertexAttribute vertexAttribute = attributes[index];
        int attributeLocation = shader.getAttributeLocation(vertexAttribute.__\u003C\u003Ealias);
        int num2 = num1;
        num1 += vertexAttribute.__\u003C\u003Esize;
        if (attributeLocation >= 0)
        {
          shader.enableVertexAttribute(attributeLocation);
          if (vertexAttribute.__\u003C\u003Etype == 5126)
          {
            ((Buffer) this.buffer).position(num2 / 4);
            shader.setVertexAttribute(attributeLocation, vertexAttribute.__\u003C\u003Ecomponents, vertexAttribute.__\u003C\u003Etype, vertexAttribute.__\u003C\u003Enormalized, this.mesh.__\u003C\u003EvertexSize, (Buffer) this.buffer);
          }
          else
          {
            ((Buffer) this.byteBuffer).position(num2);
            shader.setVertexAttribute(attributeLocation, vertexAttribute.__\u003C\u003Ecomponents, vertexAttribute.__\u003C\u003Etype, vertexAttribute.__\u003C\u003Enormalized, this.mesh.__\u003C\u003EvertexSize, (Buffer) this.byteBuffer);
          }
        }
      }
      this.isBound = true;
    }

    [LineNumberTable(new byte[] {66, 121, 44, 198, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unbind(Shader shader)
    {
      VertexAttribute[] attributes = this.mesh.__\u003C\u003Eattributes;
      int length = attributes.Length;
      for (int index = 0; index < length; ++index)
      {
        VertexAttribute vertexAttribute = attributes[index];
        shader.disableVertexAttribute(vertexAttribute.__\u003C\u003Ealias);
      }
      this.isBound = false;
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);
  }
}
