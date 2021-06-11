// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.IndexBufferObjectSubData
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
  [Implements(new string[] {"arc.graphics.gl.IndexData"})]
  public class IndexBufferObjectSubData : Object, IndexData, Disposable
  {
    [Modifiers]
    internal ShortBuffer buffer;
    [Modifiers]
    internal ByteBuffer byteBuffer;
    [Modifiers]
    internal bool isDirect;
    [Modifiers]
    internal int usage;
    internal int bufferHandle;
    internal bool isDirty;
    internal bool isBound;

    [LineNumberTable(new byte[] {159, 133, 130, 232, 56, 103, 231, 72, 110, 135, 117, 113, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IndexBufferObjectSubData(bool isStatic, int maxIndices)
    {
      int num = isStatic ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      IndexBufferObjectSubData bufferObjectSubData = this;
      this.isDirty = true;
      this.isBound = false;
      this.byteBuffer = Buffers.newByteBuffer(maxIndices * 2);
      this.isDirect = true;
      this.usage = num == 0 ? 35048 : 35044;
      this.buffer = this.byteBuffer.asShortBuffer();
      ((Buffer) this.buffer).flip();
      ((Buffer) this.byteBuffer).flip();
      this.bufferHandle = this.createBufferObject();
    }

    [LineNumberTable(new byte[] {15, 102, 107, 124, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int createBufferObject()
    {
      int buffer = Gl.genBuffer();
      Gl.bindBuffer(34963, buffer);
      Gl.bufferData(34963, ((Buffer) this.byteBuffer).capacity(), (Buffer) null, this.usage);
      Gl.bindBuffer(34963, 0);
      return buffer;
    }

    [LineNumberTable(new byte[] {3, 232, 41, 103, 231, 87, 110, 135, 107, 113, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IndexBufferObjectSubData(int maxIndices)
    {
      IndexBufferObjectSubData bufferObjectSubData = this;
      this.isDirty = true;
      this.isBound = false;
      this.byteBuffer = Buffers.newByteBuffer(maxIndices * 2);
      this.isDirect = true;
      this.usage = 35044;
      this.buffer = this.byteBuffer.asShortBuffer();
      ((Buffer) this.buffer).flip();
      ((Buffer) this.byteBuffer).flip();
      this.bufferHandle = this.createBufferObject();
    }

    [LineNumberTable(74)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => ((Buffer) this.buffer).limit();

    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int max() => ((Buffer) this.buffer).capacity();

    [LineNumberTable(new byte[] {46, 103, 108, 111, 108, 109, 143, 104, 124, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(short[] indices, int offset, int count)
    {
      this.isDirty = true;
      ((Buffer) this.buffer).clear();
      this.buffer.put(indices, offset, count);
      ((Buffer) this.buffer).flip();
      ((Buffer) this.byteBuffer).position(0);
      ((Buffer) this.byteBuffer).limit(count << 1);
      if (!this.isBound)
        return;
      Gl.bufferSubData(34963, 0, ((Buffer) this.byteBuffer).limit(), (Buffer) this.byteBuffer);
      this.isDirty = false;
    }

    [LineNumberTable(new byte[] {60, 103, 103, 108, 109, 108, 104, 109, 153, 104, 124, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(ShortBuffer indices)
    {
      int num = ((Buffer) indices).position();
      this.isDirty = true;
      ((Buffer) this.buffer).clear();
      this.buffer.put(indices);
      ((Buffer) this.buffer).flip();
      ((Buffer) indices).position(num);
      ((Buffer) this.byteBuffer).position(0);
      ((Buffer) this.byteBuffer).limit(((Buffer) this.buffer).limit() << 1);
      if (!this.isBound)
        return;
      Gl.bufferSubData(34963, 0, ((Buffer) this.byteBuffer).limit(), (Buffer) this.byteBuffer);
      this.isDirty = false;
    }

    [LineNumberTable(new byte[] {77, 103, 108, 111, 111, 109, 141, 104, 124, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(int targetOffset, short[] indices, int offset, int count)
    {
      this.isDirty = true;
      int num = ((Buffer) this.byteBuffer).position();
      ((Buffer) this.byteBuffer).position(targetOffset * 2);
      Buffers.copy(indices, offset, (Buffer) this.byteBuffer, count);
      ((Buffer) this.byteBuffer).position(num);
      ((Buffer) this.buffer).position(0);
      if (!this.isBound)
        return;
      Gl.bufferSubData(34963, 0, ((Buffer) this.byteBuffer).limit(), (Buffer) this.byteBuffer);
      this.isDirty = false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ShortBuffer buffer()
    {
      this.isDirty = true;
      return this.buffer;
    }

    [LineNumberTable(new byte[] {105, 104, 144, 112, 104, 121, 124, 135, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void bind()
    {
      if (this.bufferHandle == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("IndexBufferObject cannot be used after it has been disposed.");
      }
      Gl.bindBuffer(34963, this.bufferHandle);
      if (this.isDirty)
      {
        ((Buffer) this.byteBuffer).limit(((Buffer) this.buffer).limit() * 2);
        Gl.bufferSubData(34963, 0, ((Buffer) this.byteBuffer).limit(), (Buffer) this.byteBuffer);
        this.isDirty = false;
      }
      this.isBound = true;
    }

    [LineNumberTable(new byte[] {119, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unbind()
    {
      Gl.bindBuffer(34963, 0);
      this.isBound = false;
    }

    [LineNumberTable(new byte[] {125, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      Gl.bindBuffer(34963, 0);
      Gl.deleteBuffer(this.bufferHandle);
      this.bufferHandle = 0;
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);
  }
}
