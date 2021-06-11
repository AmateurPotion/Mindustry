// Decompiled with JetBrains decompiler
// Type: mindustry.world.DirectionalItemBuffer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.gen;
using mindustry.type;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world
{
  public class DirectionalItemBuffer : Object
  {
    internal long[][] __\u003C\u003Ebuffers;
    internal int[] __\u003C\u003Eindexes;

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool accepts(int buffer) => this.__\u003C\u003Eindexes[buffer] < this.__\u003C\u003Ebuffers[buffer].Length;

    [LineNumberTable(new byte[] {159, 157, 104, 127, 10, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DirectionalItemBuffer(int capacity)
    {
      DirectionalItemBuffer directionalItemBuffer = this;
      int num1 = capacity;
      int[] numArray = new int[2];
      int num2 = num1;
      numArray[1] = num2;
      int num3 = 4;
      numArray[0] = num3;
      // ISSUE: type reference
      this.__\u003C\u003Ebuffers = (long[][]) ByteCodeHelper.multianewarray(__typeref (long[][]), numArray);
      this.__\u003C\u003Eindexes = new int[5];
    }

    [LineNumberTable(new byte[] {159, 167, 106, 127, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void accept(int buffer, Item item)
    {
      if (!this.accepts(buffer))
        return;
      long[] buffer1 = this.__\u003C\u003Ebuffers[buffer];
      int[] indexes = this.__\u003C\u003Eindexes;
      int index1 = buffer;
      int[] numArray1 = indexes;
      int[] numArray2 = numArray1;
      int num1 = index1;
      int num2 = numArray1[index1];
      int index2 = num1;
      int[] numArray3 = numArray2;
      int index3 = num2;
      numArray3[index2] = num2 + 1;
      long num3 = BufferItem.get((byte) item.__\u003C\u003Eid, Time.time);
      buffer1[index3] = num3;
    }

    [LineNumberTable(new byte[] {159, 172, 107, 107, 136, 116, 178})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Item poll(int buffer, float speed)
    {
      if (this.__\u003C\u003Eindexes[buffer] > 0)
      {
        long bufferitem = this.__\u003C\u003Ebuffers[buffer][0];
        float num = BufferItem.time(bufferitem);
        if ((double) Time.time >= (double) (num + speed) || (double) Time.time < (double) num)
          return Vars.content.item((int) (sbyte) BufferItem.item(bufferitem));
      }
      return (Item) null;
    }

    [LineNumberTable(new byte[] {159, 184, 127, 2, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(int buffer)
    {
      ByteCodeHelper.arraycopy_primitive_8((Array) this.__\u003C\u003Ebuffers[buffer], 1, (Array) this.__\u003C\u003Ebuffers[buffer], 0, this.__\u003C\u003Eindexes[buffer] - 1);
      int[] indexes = this.__\u003C\u003Eindexes;
      int index = buffer;
      int[] numArray = indexes;
      numArray[index] = numArray[index] - 1;
    }

    [LineNumberTable(new byte[] {159, 189, 105, 110, 111, 119, 40, 230, 61, 233, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Writes write)
    {
      for (int index1 = 0; index1 < 4; ++index1)
      {
        write.b(this.__\u003C\u003Eindexes[index1]);
        write.b(this.__\u003C\u003Ebuffers[index1].Length);
        long[] buffer = this.__\u003C\u003Ebuffers[index1];
        int length = buffer.Length;
        for (int index2 = 0; index2 < length; ++index2)
        {
          long i = buffer[index2];
          write.l(i);
        }
      }
    }

    [LineNumberTable(new byte[] {7, 105, 111, 104, 102, 103, 108, 235, 61, 230, 61, 233, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Reads read)
    {
      for (int index1 = 0; index1 < 4; ++index1)
      {
        this.__\u003C\u003Eindexes[index1] = (int) (sbyte) read.b();
        int num1 = (int) (sbyte) read.b();
        for (int index2 = 0; index2 < num1; ++index2)
        {
          long num2 = read.l();
          if (index2 < this.__\u003C\u003Ebuffers[index1].Length)
            this.__\u003C\u003Ebuffers[index1][index2] = num2;
        }
      }
    }

    [Modifiers]
    public long[][] buffers
    {
      [HideFromJava] get => this.__\u003C\u003Ebuffers;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ebuffers = value;
    }

    [Modifiers]
    public int[] indexes
    {
      [HideFromJava] get => this.__\u003C\u003Eindexes;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eindexes = value;
    }

    internal class BufferItemStruct : Object
    {
      internal byte item;
      internal float time;
      [Modifiers]
      internal DirectionalItemBuffer this\u00240;

      [LineNumberTable(70)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal BufferItemStruct([In] DirectionalItemBuffer obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }
    }
  }
}
