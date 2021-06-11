// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.IndexBufferObject
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
  public class IndexBufferObject : Object, IndexData, Disposable
  {
    [Modifiers]
    internal ShortBuffer buffer;
    [Modifiers]
    internal ByteBuffer byteBuffer;
    [Modifiers]
    internal bool isDirect;
    [Modifiers]
    internal int usage;
    [Modifiers]
    internal bool empty;
    internal int bufferHandle;
    internal bool dirty;
    internal bool bound;

    [LineNumberTable(new byte[] {159, 129, 98, 232, 48, 103, 231, 81, 109, 104, 163, 110, 135, 113, 108, 108, 107, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IndexBufferObject(bool isStatic, int maxIndices)
    {
      int num = isStatic ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      IndexBufferObject indexBufferObject = this;
      this.dirty = true;
      this.bound = false;
      this.empty = maxIndices == 0;
      if (this.empty)
        maxIndices = 1;
      this.byteBuffer = Buffers.newUnsafeByteBuffer(maxIndices * 2);
      this.isDirect = true;
      this.buffer = this.byteBuffer.asShortBuffer();
      ((Buffer) this.buffer).flip();
      ((Buffer) this.byteBuffer).flip();
      this.bufferHandle = Gl.genBuffer();
      this.usage = num == 0 ? 35048 : 35044;
    }

    [LineNumberTable(new byte[] {159, 187, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IndexBufferObject(int maxIndices)
      : this(true, maxIndices)
    {
    }

    [LineNumberTable(73)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => this.empty ? 0 : ((Buffer) this.buffer).limit();

    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int max() => this.empty ? 0 : ((Buffer) this.buffer).capacity();

    [LineNumberTable(new byte[] {47, 103, 108, 111, 108, 109, 143, 104, 127, 2, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(short[] indices, int offset, int count)
    {
      this.dirty = true;
      ((Buffer) this.buffer).clear();
      this.buffer.put(indices, offset, count);
      ((Buffer) this.buffer).flip();
      ((Buffer) this.byteBuffer).position(0);
      ((Buffer) this.byteBuffer).limit(count << 1);
      if (!this.bound)
        return;
      Gl.bufferData(34963, ((Buffer) this.byteBuffer).limit(), (Buffer) this.byteBuffer, this.usage);
      this.dirty = false;
    }

    [LineNumberTable(new byte[] {62, 103, 103, 108, 109, 108, 104, 109, 153, 104, 127, 2, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(ShortBuffer indices)
    {
      this.dirty = true;
      int num = ((Buffer) indices).position();
      ((Buffer) this.buffer).clear();
      this.buffer.put(indices);
      ((Buffer) this.buffer).flip();
      ((Buffer) indices).position(num);
      ((Buffer) this.byteBuffer).position(0);
      ((Buffer) this.byteBuffer).limit(((Buffer) this.buffer).limit() << 1);
      if (!this.bound)
        return;
      Gl.bufferData(34963, ((Buffer) this.byteBuffer).limit(), (Buffer) this.byteBuffer, this.usage);
      this.dirty = false;
    }

    [LineNumberTable(new byte[] {79, 103, 108, 111, 111, 109, 141, 104, 127, 2, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(int targetOffset, short[] indices, int offset, int count)
    {
      this.dirty = true;
      int num = ((Buffer) this.byteBuffer).position();
      ((Buffer) this.byteBuffer).position(targetOffset * 2);
      Buffers.copy(indices, offset, (Buffer) this.byteBuffer, count);
      ((Buffer) this.byteBuffer).position(num);
      ((Buffer) this.buffer).position(0);
      if (!this.bound)
        return;
      Gl.bufferData(34963, ((Buffer) this.byteBuffer).limit(), (Buffer) this.byteBuffer, this.usage);
      this.dirty = false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ShortBuffer buffer()
    {
      this.dirty = true;
      return this.buffer;
    }

    [LineNumberTable(new byte[] {108, 152, 112, 104, 121, 127, 2, 135, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void bind()
    {
      if (this.bufferHandle == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("No buffer allocated!");
      }
      Gl.bindBuffer(34963, this.bufferHandle);
      if (this.dirty)
      {
        ((Buffer) this.byteBuffer).limit(((Buffer) this.buffer).limit() * 2);
        Gl.bufferData(34963, ((Buffer) this.byteBuffer).limit(), (Buffer) this.byteBuffer, this.usage);
        this.dirty = false;
      }
      this.bound = true;
    }

    [LineNumberTable(new byte[] {122, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unbind()
    {
      Gl.bindBuffer(34963, 0);
      this.bound = false;
    }

    [LineNumberTable(new byte[] {160, 65, 107, 107, 135, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      Gl.bindBuffer(34963, 0);
      Gl.deleteBuffer(this.bufferHandle);
      this.bufferHandle = 0;
      Buffers.disposeUnsafeByteBuffer(this.byteBuffer);
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);
  }
}
