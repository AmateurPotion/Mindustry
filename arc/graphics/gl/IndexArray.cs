// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.IndexArray
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
  public class IndexArray : Object, IndexData, Disposable
  {
    [Modifiers]
    internal ShortBuffer buffer;
    [Modifiers]
    internal ByteBuffer byteBuffer;
    [Modifiers]
    private bool empty;

    [LineNumberTable(new byte[] {159, 161, 104, 109, 104, 163, 110, 113, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IndexArray(int maxIndices)
    {
      IndexArray indexArray = this;
      this.empty = maxIndices == 0;
      if (this.empty)
        maxIndices = 1;
      this.byteBuffer = Buffers.newUnsafeByteBuffer(maxIndices * 2);
      this.buffer = this.byteBuffer.asShortBuffer();
      ((Buffer) this.buffer).flip();
      ((Buffer) this.byteBuffer).flip();
    }

    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => this.empty ? 0 : ((Buffer) this.buffer).limit();

    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int max() => this.empty ? 0 : ((Buffer) this.buffer).capacity();

    [LineNumberTable(new byte[] {8, 108, 111, 108, 109, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(short[] indices, int offset, int count)
    {
      ((Buffer) this.buffer).clear();
      this.buffer.put(indices, offset, count);
      ((Buffer) this.buffer).flip();
      ((Buffer) this.byteBuffer).position(0);
      ((Buffer) this.byteBuffer).limit(count << 1);
    }

    [LineNumberTable(new byte[] {17, 103, 108, 114, 109, 108, 104, 109, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(ShortBuffer indices)
    {
      int num = ((Buffer) indices).position();
      ((Buffer) this.buffer).clear();
      ((Buffer) this.buffer).limit(((Buffer) indices).remaining());
      this.buffer.put(indices);
      ((Buffer) this.buffer).flip();
      ((Buffer) indices).position(num);
      ((Buffer) this.byteBuffer).position(0);
      ((Buffer) this.byteBuffer).limit(((Buffer) this.buffer).limit() << 1);
    }

    [LineNumberTable(new byte[] {29, 108, 111, 111, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(int targetOffset, short[] indices, int offset, int count)
    {
      int num = ((Buffer) this.byteBuffer).position();
      ((Buffer) this.byteBuffer).position(targetOffset * 2);
      Buffers.copy(indices, offset, (Buffer) this.byteBuffer, count);
      ((Buffer) this.byteBuffer).position(num);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ShortBuffer buffer() => this.buffer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void bind()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unbind()
    {
    }

    [LineNumberTable(new byte[] {60, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose() => Buffers.disposeUnsafeByteBuffer(this.byteBuffer);

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);
  }
}
