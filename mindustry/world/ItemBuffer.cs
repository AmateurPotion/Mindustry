// Decompiled with JetBrains decompiler
// Type: mindustry.world.ItemBuffer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.type;
using System;
using System.Runtime.CompilerServices;

namespace mindustry.world
{
  public class ItemBuffer : Object
  {
    private long[] buffer;
    private int index;

    [LineNumberTable(new byte[] {159, 137, 162, 127, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void accept(Item item, short data)
    {
      int num1 = (int) data;
      long[] buffer = this.buffer;
      ItemBuffer itemBuffer1 = this;
      int index1 = itemBuffer1.index;
      ItemBuffer itemBuffer2 = itemBuffer1;
      int index2 = index1;
      itemBuffer2.index = index1 + 1;
      long num2 = Pack.longInt(Float.floatToIntBits(Time.time), Pack.shortInt(item.__\u003C\u003Eid, (short) num1));
      buffer[index2] = num2;
    }

    [LineNumberTable(new byte[] {159, 155, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemBuffer(int capacity)
    {
      ItemBuffer itemBuffer = this;
      this.buffer = new long[capacity];
    }

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool accepts() => this.index < this.buffer.Length;

    [LineNumberTable(new byte[] {159, 169, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void accept(Item item) => this.accept(item, (short) -1);

    [LineNumberTable(new byte[] {159, 173, 105, 105, 142, 116, 182})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Item poll(float speed)
    {
      if (this.index > 0)
      {
        long field = this.buffer[0];
        FloatConverter floatConverter;
        float num = FloatConverter.ToFloat(Pack.leftInt(field), ref floatConverter);
        if ((double) Time.time >= (double) (num + speed) || (double) Time.time < (double) num)
          return Vars.content.item((int) Pack.leftShort(Pack.rightInt(field)));
      }
      return (Item) null;
    }

    [LineNumberTable(new byte[] {159, 185, 123, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      ByteCodeHelper.arraycopy_primitive_8((Array) this.buffer, 1, (Array) this.buffer, 0, this.index - 1);
      --this.index;
    }

    [LineNumberTable(new byte[] {159, 190, 109, 110, 116, 39, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Writes write)
    {
      write.b((int) (sbyte) this.index);
      write.b((int) (sbyte) this.buffer.Length);
      long[] buffer = this.buffer;
      int length = buffer.Length;
      for (int index = 0; index < length; ++index)
      {
        long i = buffer[index];
        write.l(i);
      }
    }

    [LineNumberTable(new byte[] {6, 109, 104, 102, 103, 106, 233, 61, 230, 70, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Reads read)
    {
      this.index = (int) (sbyte) read.b();
      int num1 = (int) (sbyte) read.b();
      for (int index = 0; index < num1; ++index)
      {
        long num2 = read.l();
        if (index < this.buffer.Length)
          this.buffer[index] = num2;
      }
      this.index = Math.min(this.index, num1 - 1);
    }
  }
}
