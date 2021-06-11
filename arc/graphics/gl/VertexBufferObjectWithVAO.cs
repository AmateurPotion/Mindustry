// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.VertexBufferObjectWithVAO
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.gl
{
  [Implements(new string[] {"arc.graphics.gl.VertexData"})]
  public class VertexBufferObjectWithVAO : Object, VertexData, Disposable
  {
    [Modifiers]
    internal static IntBuffer tmpHandle;
    [Modifiers]
    internal Mesh mesh;
    [Modifiers]
    internal FloatBuffer buffer;
    [Modifiers]
    internal ByteBuffer byteBuffer;
    [Modifiers]
    internal bool isStatic;
    [Modifiers]
    internal int usage;
    internal int bufferHandle;
    internal bool isDirty;
    internal bool isBound;
    internal int vaoHandle;
    internal IntSeq cachedLocations;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 130, 98, 232, 54, 103, 103, 103, 235, 72, 103, 135, 120, 113, 108, 108, 107, 117, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VertexBufferObjectWithVAO(bool isStatic, int numVertices, Mesh mesh)
    {
      int num = isStatic ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      VertexBufferObjectWithVAO bufferObjectWithVao = this;
      this.isDirty = false;
      this.isBound = false;
      this.vaoHandle = -1;
      this.cachedLocations = new IntSeq();
      this.isStatic = num != 0;
      this.mesh = mesh;
      this.byteBuffer = Buffers.newUnsafeByteBuffer(this.mesh.__\u003C\u003EvertexSize * numVertices);
      this.buffer = this.byteBuffer.asFloatBuffer();
      ((Buffer) this.buffer).flip();
      ((Buffer) this.byteBuffer).flip();
      this.bufferHandle = Gl.genBuffer();
      this.usage = num == 0 ? 35040 : 35044;
      this.createVAO();
    }

    [LineNumberTable(new byte[] {160, 79, 107, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void createVAO()
    {
      ((Buffer) VertexBufferObjectWithVAO.tmpHandle).clear();
      Core.gl30.glGenVertexArrays(1, VertexBufferObjectWithVAO.tmpHandle);
      this.vaoHandle = VertexBufferObjectWithVAO.tmpHandle.get();
    }

    [LineNumberTable(new byte[] {29, 104, 127, 2, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void bufferChanged()
    {
      if (!this.isBound)
        return;
      Gl.bufferData(34962, ((Buffer) this.byteBuffer).limit(), (Buffer) this.byteBuffer, this.usage);
      this.isDirty = false;
    }

    [LineNumberTable(new byte[] {68, 146, 99, 116, 110, 109, 240, 61, 230, 71, 102, 112, 103, 139, 98, 118, 112, 120, 99, 138, 111, 101, 162, 104, 255, 11, 52, 235, 79})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void bindAttributes([In] Shader obj0)
    {
      int num1 = this.cachedLocations.size == 0 ? 0 : 1;
      if (num1 != 0)
      {
        for (int index = 0; num1 != 0 && index < this.mesh.__\u003C\u003Eattributes.Length; ++index)
        {
          VertexAttribute attribute = this.mesh.__\u003C\u003Eattributes[index];
          num1 = obj0.getAttributeLocation(attribute.__\u003C\u003Ealias) == this.cachedLocations.get(index) ? 1 : 0;
        }
      }
      if (num1 != 0)
        return;
      Gl.bindBuffer(34962, this.bufferHandle);
      this.unbindAttributes(obj0);
      this.cachedLocations.clear();
      int num2 = 0;
      for (int index = 0; index < this.mesh.__\u003C\u003Eattributes.Length; ++index)
      {
        VertexAttribute attribute = this.mesh.__\u003C\u003Eattributes[index];
        this.cachedLocations.add(obj0.getAttributeLocation(attribute.__\u003C\u003Ealias));
        int offset = num2;
        num2 += attribute.__\u003C\u003Esize;
        int location = this.cachedLocations.get(index);
        if (location >= 0)
        {
          obj0.enableVertexAttribute(location);
          obj0.setVertexAttribute(location, attribute.__\u003C\u003Ecomponents, attribute.__\u003C\u003Etype, attribute.__\u003C\u003Enormalized, this.mesh.__\u003C\u003EvertexSize, offset);
        }
      }
    }

    [LineNumberTable(new byte[] {116, 104, 117, 121, 127, 7, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void bindData()
    {
      if (!this.isDirty)
        return;
      Core.gl.glBindBuffer(34962, this.bufferHandle);
      ((Buffer) this.byteBuffer).limit(((Buffer) this.buffer).limit() * 4);
      Core.gl.glBufferData(34962, ((Buffer) this.byteBuffer).limit(), (Buffer) this.byteBuffer, this.usage);
      this.isDirty = false;
    }

    [LineNumberTable(new byte[] {102, 109, 161, 113, 109, 100, 130, 231, 59, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void unbindAttributes([In] Shader obj0)
    {
      if (this.cachedLocations.size == 0)
        return;
      for (int index = 0; index < this.mesh.__\u003C\u003Eattributes.Length; ++index)
      {
        int location = this.cachedLocations.get(index);
        if (location >= 0)
          obj0.disableVertexAttribute(location);
      }
    }

    [LineNumberTable(new byte[] {160, 85, 105, 107, 113, 107, 112, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void deleteVAO()
    {
      if (this.vaoHandle == -1)
        return;
      ((Buffer) VertexBufferObjectWithVAO.tmpHandle).clear();
      VertexBufferObjectWithVAO.tmpHandle.put(this.vaoHandle);
      ((Buffer) VertexBufferObjectWithVAO.tmpHandle).flip();
      Core.gl30.glDeleteVertexArrays(1, VertexBufferObjectWithVAO.tmpHandle);
      this.vaoHandle = -1;
    }

    [LineNumberTable(64)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size()
    {
      int num = ((Buffer) this.buffer).limit() * 4;
      int vertexSize = this.mesh.__\u003C\u003EvertexSize;
      return vertexSize == -1 ? -num : num / vertexSize;
    }

    [LineNumberTable(69)]
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
      this.isDirty = true;
      return this.buffer;
    }

    [LineNumberTable(new byte[] {37, 103, 110, 109, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float[] vertices, int offset, int count)
    {
      this.isDirty = true;
      Buffers.copy(vertices, (Buffer) this.byteBuffer, count, offset);
      ((Buffer) this.buffer).position(0);
      ((Buffer) this.buffer).limit(count);
      this.bufferChanged();
    }

    [LineNumberTable(new byte[] {46, 103, 108, 111, 111, 109, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(int targetOffset, float[] vertices, int sourceOffset, int count)
    {
      this.isDirty = true;
      int num = ((Buffer) this.byteBuffer).position();
      ((Buffer) this.byteBuffer).position(targetOffset * 4);
      Buffers.copy(vertices, sourceOffset, count, (Buffer) this.byteBuffer);
      ((Buffer) this.byteBuffer).position(num);
      ((Buffer) this.buffer).position(0);
      this.bufferChanged();
    }

    [LineNumberTable(new byte[] {57, 144, 167, 134, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void bind(Shader shader)
    {
      Core.gl30.glBindVertexArray(this.vaoHandle);
      this.bindAttributes(shader);
      this.bindData();
      this.isBound = true;
    }

    [LineNumberTable(new byte[] {126, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unbind(Shader shader)
    {
      Core.gl30.glBindVertexArray(0);
      this.isBound = false;
    }

    [LineNumberTable(new byte[] {160, 71, 112, 112, 103, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      Core.gl.glBindBuffer(34962, 0);
      Core.gl.glDeleteBuffer(this.bufferHandle);
      this.bufferHandle = 0;
      Buffers.disposeUnsafeByteBuffer(this.byteBuffer);
      this.deleteVAO();
    }

    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static VertexBufferObjectWithVAO()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.gl.VertexBufferObjectWithVAO"))
        return;
      VertexBufferObjectWithVAO.tmpHandle = Buffers.newIntBuffer(1);
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [HideFromJava]
    public virtual void render([In] IndexData obj0, [In] int obj1, [In] int obj2, [In] int obj3) => VertexData.\u003Cdefault\u003Erender((VertexData) this, obj0, obj1, obj2, obj3);
  }
}
