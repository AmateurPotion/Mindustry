// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.VertexBufferObject
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.gl
{
  [Implements(new string[] {"arc.graphics.gl.VertexData"})]
  public class VertexBufferObject : Object, VertexData, Disposable
  {
    internal bool dirty;
    internal bool bound;
    private Mesh mesh;
    private FloatBuffer buffer;
    private ByteBuffer byteBuffer;
    private bool ownsBuffer;
    private int bufferHandle;
    private int usage;

    [LineNumberTable(new byte[] {159, 134, 98, 232, 50, 103, 231, 78, 135, 107, 149, 110, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VertexBufferObject(bool isStatic, int numVertices, Mesh mesh)
    {
      int num = isStatic ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      VertexBufferObject vertexBufferObject = this;
      this.dirty = false;
      this.bound = false;
      this.mesh = mesh;
      this.bufferHandle = Gl.genBuffer();
      this.usage = num == 0 ? 35040 : 35044;
      ByteBuffer byteBuffer = Buffers.newUnsafeByteBuffer(mesh.__\u003C\u003EvertexSize * numVertices);
      ((Buffer) byteBuffer).limit(0);
      this.setBuffer((Buffer) byteBuffer, true);
    }

    [LineNumberTable(new byte[] {159, 126, 66, 120, 112, 107, 104, 142, 112, 135, 108, 119, 113, 109, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setBuffer(Buffer data, bool ownsBuffer)
    {
      int num1 = ownsBuffer ? 1 : 0;
      if (this.bound)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Cannot change attributes while VBO is bound");
      }
      if (this.ownsBuffer && this.byteBuffer != null)
        Buffers.disposeUnsafeByteBuffer(this.byteBuffer);
      if (data is ByteBuffer)
      {
        this.byteBuffer = (ByteBuffer) data;
        this.ownsBuffer = num1 != 0;
        int num2 = ((Buffer) this.byteBuffer).limit();
        ((Buffer) this.byteBuffer).limit(((Buffer) this.byteBuffer).capacity());
        this.buffer = this.byteBuffer.asFloatBuffer();
        ((Buffer) this.byteBuffer).limit(num2);
        ((Buffer) this.buffer).limit(num2 / 4);
      }
      else
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Only ByteBuffer is currently supported");
      }
    }

    [LineNumberTable(new byte[] {31, 136, 127, 2, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void bufferChanged()
    {
      if (!this.bound)
        return;
      Gl.bufferData(34962, ((Buffer) this.byteBuffer).limit(), (Buffer) this.byteBuffer, this.usage);
      this.dirty = false;
    }

    [LineNumberTable(new byte[] {63, 112, 104, 121, 127, 2, 167, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void bind()
    {
      Gl.bindBuffer(34962, this.bufferHandle);
      if (this.dirty)
      {
        ((Buffer) this.byteBuffer).limit(((Buffer) this.buffer).limit() * 4);
        Gl.bufferData(34962, ((Buffer) this.byteBuffer).limit(), (Buffer) this.byteBuffer, this.usage);
        this.dirty = false;
      }
      this.bound = true;
    }

    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size()
    {
      int num = ((Buffer) this.buffer).limit() * 4;
      int vertexSize = this.mesh.__\u003C\u003EvertexSize;
      return vertexSize == -1 ? -num : num / vertexSize;
    }

    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int max()
    {
      int num = ((Buffer) this.byteBuffer).capacity();
      int vertexSize = this.mesh.__\u003C\u003EvertexSize;
      return vertexSize == -1 ? -num : num / vertexSize;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FloatBuffer buffer()
    {
      this.dirty = true;
      return this.buffer;
    }

    [LineNumberTable(new byte[] {40, 103, 110, 109, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float[] vertices, int offset, int count)
    {
      this.dirty = true;
      Buffers.copy(vertices, (Buffer) this.byteBuffer, count, offset);
      ((Buffer) this.buffer).position(0);
      ((Buffer) this.buffer).limit(count);
      this.bufferChanged();
    }

    [LineNumberTable(new byte[] {49, 103, 108, 111, 111, 109, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(int targetOffset, float[] vertices, int sourceOffset, int count)
    {
      this.dirty = true;
      int num = ((Buffer) this.byteBuffer).position();
      ((Buffer) this.byteBuffer).position(targetOffset * 4);
      Buffers.copy(vertices, sourceOffset, count, (Buffer) this.byteBuffer);
      ((Buffer) this.byteBuffer).position(num);
      ((Buffer) this.buffer).position(0);
      this.bufferChanged();
    }

    [LineNumberTable(new byte[] {79, 134, 98, 125, 111, 99, 106, 135, 104, 255, 11, 57, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void bind(Shader shader)
    {
      this.bind();
      int num = 0;
      VertexAttribute[] attributes = this.mesh.__\u003C\u003Eattributes;
      int length = attributes.Length;
      for (int index = 0; index < length; ++index)
      {
        VertexAttribute vertexAttribute = attributes[index];
        int attributeLocation = shader.getAttributeLocation(vertexAttribute.__\u003C\u003Ealias);
        int offset = num;
        num += vertexAttribute.__\u003C\u003Esize;
        if (attributeLocation >= 0)
        {
          shader.enableVertexAttribute(attributeLocation);
          shader.setVertexAttribute(attributeLocation, vertexAttribute.__\u003C\u003Ecomponents, vertexAttribute.__\u003C\u003Etype, vertexAttribute.__\u003C\u003Enormalized, this.mesh.__\u003C\u003EvertexSize, offset);
        }
      }
    }

    [LineNumberTable(new byte[] {95, 121, 44, 166, 107, 103})]
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
      Gl.bindBuffer(34962, 0);
      this.bound = false;
    }

    [LineNumberTable(new byte[] {105, 107, 107, 103, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      Gl.bindBuffer(34962, 0);
      Gl.deleteBuffer(this.bufferHandle);
      this.bufferHandle = 0;
      if (!this.ownsBuffer)
        return;
      Buffers.disposeUnsafeByteBuffer(this.byteBuffer);
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [HideFromJava]
    public virtual void render([In] IndexData obj0, [In] int obj1, [In] int obj2, [In] int obj3) => VertexData.\u003Cdefault\u003Erender((VertexData) this, obj0, obj1, obj2, obj3);
  }
}
