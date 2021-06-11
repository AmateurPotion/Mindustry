// Decompiled with JetBrains decompiler
// Type: com.sun.jna.Memory
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.@ref;
using java.nio;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  public class Memory : Pointer
  {
    [Modifiers]
    [Signature("Ljava/util/Map<Lcom/sun/jna/Memory;Ljava/lang/ref/Reference<Lcom/sun/jna/Memory;>;>;")]
    private static Map allocatedMemory;
    [Modifiers]
    private static WeakMemoryHolder buffers;
    protected internal long size;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long size() => this.size;

    [LineNumberTable(new byte[] {160, 73, 143, 108, 43, 130, 98})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    protected internal virtual void dispose()
    {
      try
      {
        Memory.free(this.peer);
      }
      finally
      {
        Memory.allocatedMemory.remove((object) this);
        this.peer = 0L;
      }
    }

    [LineNumberTable(721)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static long malloc(long size) => Native.malloc(size);

    [LineNumberTable(new byte[] {94, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Pointer share(long offset, long sz)
    {
      this.boundsCheck(offset, sz);
      return (Pointer) new Memory.SharedMemory(this, offset, sz);
    }

    [LineNumberTable(new byte[] {160, 100, 101, 159, 6, 107, 159, 19, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void boundsCheck(long off, long sz)
    {
      if (off < 0L)
      {
        string str = new StringBuilder().append("Invalid offset: ").append(off).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      if (off + sz > this.size)
      {
        string str = new StringBuilder().append("Bounds exceeds available space : size=").append(this.size).append(", offset=").append(off + sz).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
    }

    [LineNumberTable(new byte[] {162, 89, 105, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static void free(long p)
    {
      if (p == 0L)
        return;
      Native.free(p);
    }

    [LineNumberTable(new byte[] {15, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void purge() => Memory.buffers.clean();

    [LineNumberTable(new byte[] {21, 112, 123, 102, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void disposeAll()
    {
      Iterator iterator = ((Collection) new LinkedList((Collection) Memory.allocatedMemory.keySet())).iterator();
      while (iterator.hasNext())
        ((Memory) iterator.next()).dispose();
    }

    [LineNumberTable(new byte[] {58, 104, 103, 101, 150, 108, 106, 159, 22, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Memory(long size)
    {
      Memory memory = this;
      this.size = size;
      if (size <= 0L)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        IllegalArgumentException argumentException = new IllegalArgumentException("Allocation size must be greater than zero");
        GC.KeepAlive((object) this);
        throw argumentException;
      }
      this.peer = Memory.malloc(size);
      if (this.peer == 0L)
      {
        string str = new StringBuilder().append("Cannot allocate ").append(size).append(" bytes").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        OutOfMemoryError outOfMemoryError = new OutOfMemoryError(str);
        GC.KeepAlive((object) this);
        throw outOfMemoryError;
      }
      Memory.allocatedMemory.put((object) this, (object) new WeakReference((object) this));
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {71, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Memory() => GC.KeepAlive((object) this);

    [LineNumberTable(132)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Pointer share(long offset) => this.share(offset, this.size() - offset);

    [LineNumberTable(new byte[] {107, 100, 159, 6, 106, 108, 137, 112, 111, 112, 101, 144, 149, 226, 52, 233, 79})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Memory align(int byteBoundary)
    {
      if (byteBoundary <= 0)
      {
        string str = new StringBuilder().append("Byte boundary must be positive: ").append(byteBoundary).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      for (int index = 0; index < 32; ++index)
      {
        if (byteBoundary == 1 << index)
        {
          long num1 = (long) byteBoundary - 1L ^ -1L;
          if ((this.peer & num1) == this.peer)
            return this;
          long num2 = this.peer + (long) byteBoundary - 1L & num1;
          long sz = this.peer + this.size - num2;
          if (sz <= 0L)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException("Insufficient memory to align to the requested boundary");
          }
          return (Memory) this.share(num2 - this.peer, sz);
        }
      }
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException("Byte boundary must be a power of two");
    }

    [LineNumberTable(new byte[] {160, 67, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void finalize() => this.dispose();

    [HideFromJava]
    ~Memory()
    {
      if (ByteCodeHelper.SkipFinalizer())
        return;
      try
      {
        this.finalize();
      }
      catch
      {
      }
    }

    [LineNumberTable(new byte[] {160, 82, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear() => this.clear(this.size);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool valid() => this.peer != 0L;

    [LineNumberTable(new byte[] {160, 124, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void read(long bOff, byte[] buf, int index, int length)
    {
      this.boundsCheck(bOff, (long) length * 1L);
      base.read(bOff, buf, index, length);
    }

    [LineNumberTable(new byte[] {160, 138, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void read(long bOff, short[] buf, int index, int length)
    {
      this.boundsCheck(bOff, (long) length * 2L);
      base.read(bOff, buf, index, length);
    }

    [LineNumberTable(new byte[] {160, 152, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void read(long bOff, char[] buf, int index, int length)
    {
      this.boundsCheck(bOff, (long) length * 2L);
      base.read(bOff, buf, index, length);
    }

    [LineNumberTable(new byte[] {160, 166, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void read(long bOff, int[] buf, int index, int length)
    {
      this.boundsCheck(bOff, (long) length * 4L);
      base.read(bOff, buf, index, length);
    }

    [LineNumberTable(new byte[] {160, 180, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void read(long bOff, long[] buf, int index, int length)
    {
      this.boundsCheck(bOff, (long) length * 8L);
      base.read(bOff, buf, index, length);
    }

    [LineNumberTable(new byte[] {160, 194, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void read(long bOff, float[] buf, int index, int length)
    {
      this.boundsCheck(bOff, (long) length * 4L);
      base.read(bOff, buf, index, length);
    }

    [LineNumberTable(new byte[] {160, 208, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void read(long bOff, double[] buf, int index, int length)
    {
      this.boundsCheck(bOff, (long) length * 8L);
      base.read(bOff, buf, index, length);
    }

    [LineNumberTable(new byte[] {160, 226, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void write(long bOff, byte[] buf, int index, int length)
    {
      this.boundsCheck(bOff, (long) length * 1L);
      base.write(bOff, buf, index, length);
    }

    [LineNumberTable(new byte[] {160, 240, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void write(long bOff, short[] buf, int index, int length)
    {
      this.boundsCheck(bOff, (long) length * 2L);
      base.write(bOff, buf, index, length);
    }

    [LineNumberTable(new byte[] {160, 254, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void write(long bOff, char[] buf, int index, int length)
    {
      this.boundsCheck(bOff, (long) length * 2L);
      base.write(bOff, buf, index, length);
    }

    [LineNumberTable(new byte[] {161, 12, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void write(long bOff, int[] buf, int index, int length)
    {
      this.boundsCheck(bOff, (long) length * 4L);
      base.write(bOff, buf, index, length);
    }

    [LineNumberTable(new byte[] {161, 26, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void write(long bOff, long[] buf, int index, int length)
    {
      this.boundsCheck(bOff, (long) length * 8L);
      base.write(bOff, buf, index, length);
    }

    [LineNumberTable(new byte[] {161, 40, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void write(long bOff, float[] buf, int index, int length)
    {
      this.boundsCheck(bOff, (long) length * 4L);
      base.write(bOff, buf, index, length);
    }

    [LineNumberTable(new byte[] {161, 54, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void write(long bOff, double[] buf, int index, int length)
    {
      this.boundsCheck(bOff, (long) length * 8L);
      base.write(bOff, buf, index, length);
    }

    [LineNumberTable(new byte[] {161, 72, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override byte getByte(long offset)
    {
      this.boundsCheck(offset, 1L);
      return base.getByte(offset);
    }

    [LineNumberTable(new byte[] {161, 86, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override char getChar(long offset)
    {
      this.boundsCheck(offset, 1L);
      return base.getChar(offset);
    }

    [LineNumberTable(new byte[] {161, 100, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override short getShort(long offset)
    {
      this.boundsCheck(offset, 2L);
      return base.getShort(offset);
    }

    [LineNumberTable(new byte[] {161, 114, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getInt(long offset)
    {
      this.boundsCheck(offset, 4L);
      return base.getInt(offset);
    }

    [LineNumberTable(new byte[] {161, 128, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override long getLong(long offset)
    {
      this.boundsCheck(offset, 8L);
      return base.getLong(offset);
    }

    [LineNumberTable(new byte[] {161, 142, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getFloat(long offset)
    {
      this.boundsCheck(offset, 4L);
      return base.getFloat(offset);
    }

    [LineNumberTable(new byte[] {161, 156, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override double getDouble(long offset)
    {
      this.boundsCheck(offset, 8L);
      return base.getDouble(offset);
    }

    [LineNumberTable(new byte[] {161, 170, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Pointer getPointer(long offset)
    {
      this.boundsCheck(offset, (long) Pointer.__\u003C\u003ESIZE);
      return base.getPointer(offset);
    }

    [LineNumberTable(new byte[] {161, 188, 104, 169, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ByteBuffer getByteBuffer(long offset, long length)
    {
      this.boundsCheck(offset, length);
      ByteBuffer byteBuffer = base.getByteBuffer(offset, length);
      Memory.buffers.put((object) byteBuffer, this);
      return byteBuffer;
    }

    [LineNumberTable(new byte[] {161, 199, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getString(long offset, string encoding)
    {
      this.boundsCheck(offset, 0L);
      return base.getString(offset, encoding);
    }

    [LineNumberTable(new byte[] {161, 206, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getWideString(long offset)
    {
      this.boundsCheck(offset, 0L);
      return base.getWideString(offset);
    }

    [LineNumberTable(new byte[] {158, 250, 131, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setByte(long offset, byte value)
    {
      int num = (int) (sbyte) value;
      this.boundsCheck(offset, 1L);
      base.setByte(offset, (byte) num);
    }

    [LineNumberTable(new byte[] {158, 246, 66, 109, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setChar(long offset, char value)
    {
      int num = (int) value;
      this.boundsCheck(offset, (long) Native.__\u003C\u003EWCHAR_SIZE);
      base.setChar(offset, (char) num);
    }

    [LineNumberTable(new byte[] {158, 243, 130, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setShort(long offset, short value)
    {
      int num = (int) value;
      this.boundsCheck(offset, 2L);
      base.setShort(offset, (short) num);
    }

    [LineNumberTable(new byte[] {162, 10, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setInt(long offset, int value)
    {
      this.boundsCheck(offset, 4L);
      base.setInt(offset, value);
    }

    [LineNumberTable(new byte[] {162, 24, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setLong(long offset, long value)
    {
      this.boundsCheck(offset, 8L);
      base.setLong(offset, value);
    }

    [LineNumberTable(new byte[] {162, 38, 105, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setFloat(long offset, float value)
    {
      this.boundsCheck(offset, 4L);
      base.setFloat(offset, value);
    }

    [LineNumberTable(new byte[] {162, 52, 105, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setDouble(long offset, double value)
    {
      this.boundsCheck(offset, 8L);
      base.setDouble(offset, value);
    }

    [LineNumberTable(new byte[] {162, 66, 109, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setPointer(long offset, Pointer value)
    {
      this.boundsCheck(offset, (long) Pointer.__\u003C\u003ESIZE);
      base.setPointer(offset, value);
    }

    [LineNumberTable(new byte[] {162, 72, 115, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setString(long offset, string value, string encoding)
    {
      this.boundsCheck(offset, (long) Native.getBytes(value, encoding).Length + 1L);
      base.setString(offset, value, encoding);
    }

    [LineNumberTable(new byte[] {162, 78, 120, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setWideString(long offset, string value)
    {
      this.boundsCheck(offset, ((long) String.instancehelper_length(value) + 1L) * (long) Native.__\u003C\u003EWCHAR_SIZE);
      base.setWideString(offset, value);
    }

    [LineNumberTable(710)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toString() => new StringBuilder().append("allocated@0x").append(Long.toHexString(this.peer)).append(" (").append(this.size).append(" bytes)").toString();

    [LineNumberTable(726)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string dump() => this.dump(0L, (int) this.size());

    [LineNumberTable(new byte[] {159, 128, 82, 101, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Memory()
    {
      Pointer.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("com.sun.jna.Memory"))
        return;
      Memory.allocatedMemory = Collections.synchronizedMap((Map) new WeakHashMap());
      Memory.buffers = new WeakMemoryHolder();
    }

    [InnerClass]
    internal class SharedMemory : Memory
    {
      [Modifiers]
      internal Memory this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {33, 111, 103, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SharedMemory([In] Memory obj0, [In] long obj1, [In] long obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Memory.SharedMemory sharedMemory = this;
        this.size = obj2;
        this.peer = obj0.peer + obj1;
        GC.KeepAlive((object) this);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override void dispose() => this.peer = 0L;

      [LineNumberTable(new byte[] {45, 127, 1})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override void boundsCheck([In] long obj0, [In] long obj1) => this.this\u00240.boundsCheck(this.peer - this.this\u00240.peer + obj0, obj1);

      [LineNumberTable(99)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override string toString() => new StringBuilder().append(base.toString()).append(" (shared from ").append(this.this\u00240.toString()).append(")").toString();

      [HideFromJava]
      static SharedMemory() => Memory.__\u003Cclinit\u003E();
    }
  }
}
