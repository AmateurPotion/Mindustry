// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.Attributes
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.serialization;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks
{
  public class Attributes : Object, Json.JsonSerializable
  {
    [Modifiers]
    private float[] arr;

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float get(Attribute attr) => this.arr[attr.ordinal()];

    [LineNumberTable(new byte[] {159, 151, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Attributes()
    {
      mindustry.world.blocks.Attributes attributes = this;
      this.arr = new float[Attribute.__\u003C\u003Eall.Length];
    }

    [LineNumberTable(new byte[] {159, 163, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Attribute attr, float value) => this.arr[attr.ordinal()] = value;

    [LineNumberTable(new byte[] {159, 155, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear() => Arrays.fill(this.arr, 0.0f);

    [LineNumberTable(new byte[] {159, 173, 108, 61, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(mindustry.world.blocks.Attributes other, float scl)
    {
      for (int index1 = 0; index1 < this.arr.Length; ++index1)
      {
        float[] arr = this.arr;
        int index2 = index1;
        float[] numArray = arr;
        numArray[index2] = numArray[index2] + other.arr[index1] * scl;
      }
    }

    [LineNumberTable(new byte[] {159, 167, 108, 57, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(mindustry.world.blocks.Attributes other)
    {
      for (int index1 = 0; index1 < this.arr.Length; ++index1)
      {
        float[] arr = this.arr;
        int index2 = index1;
        float[] numArray = arr;
        numArray[index2] = numArray[index2] + other.arr[index1];
      }
    }

    [LineNumberTable(new byte[] {159, 180, 115, 116, 30, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Json json)
    {
      Attribute[] all = Attribute.__\u003C\u003Eall;
      int length = all.Length;
      for (int index = 0; index < length; ++index)
      {
        Attribute attribute = all[index];
        if ((double) this.arr[attribute.ordinal()] != 0.0)
          json.writeValue(attribute.name(), (object) Float.valueOf(this.arr[attribute.ordinal()]));
      }
    }

    [LineNumberTable(new byte[] {159, 189, 115, 63, 0, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Json json, JsonValue data)
    {
      Attribute[] all = Attribute.__\u003C\u003Eall;
      int length = all.Length;
      for (int index = 0; index < length; ++index)
      {
        Attribute attribute = all[index];
        this.arr[attribute.ordinal()] = data.getFloat(attribute.name(), 0.0f);
      }
    }
  }
}
