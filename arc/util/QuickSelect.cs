// Decompiled with JetBrains decompiler
// Type: arc.util.QuickSelect
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;")]
  public class QuickSelect : Object
  {
    [Signature("[TT;")]
    private object[] array;
    [Signature("Ljava/util/Comparator<-TT;>;")]
    private Comparator comp;

    [LineNumberTable(new byte[] {159, 178, 102, 105, 106, 134, 100, 100, 100, 142, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int recursiveSelect([In] int obj0, [In] int obj1, [In] int obj2)
    {
      if (obj0 == obj1)
        return obj0;
      int num1 = this.medianOfThreePivot(obj0, obj1);
      int num2 = this.partition(obj0, obj1, num1);
      int num3 = num2 - obj0 + 1;
      return num3 != obj2 ? (obj2 >= num3 ? this.recursiveSelect(num2 + 1, obj1, obj2 - num3) : this.recursiveSelect(obj0, num2 - 1, obj2)) : num2;
    }

    [LineNumberTable(new byte[] {30, 105, 112, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void swap([In] int obj0, [In] int obj1)
    {
      object obj = this.array[obj0];
      this.array[obj0] = this.array[obj1];
      this.array[obj1] = obj;
    }

    [LineNumberTable(new byte[] {3, 105, 102, 105, 201, 112, 112, 98, 112, 130, 162, 112, 98, 112, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int medianOfThreePivot([In] int obj0, [In] int obj1)
    {
      object obj2 = this.array[obj0];
      int index = (obj0 + obj1) / 2;
      object obj3 = this.array[index];
      object obj4 = this.array[obj1];
      if (this.comp.compare(obj2, obj3) > 0)
      {
        if (this.comp.compare(obj3, obj4) > 0)
          return index;
        return this.comp.compare(obj2, obj4) > 0 ? obj1 : obj0;
      }
      if (this.comp.compare(obj2, obj4) > 0)
        return obj0;
      return this.comp.compare(obj3, obj4) > 0 ? obj1 : index;
    }

    [LineNumberTable(new byte[] {159, 164, 105, 104, 98, 102, 119, 104, 228, 61, 230, 70, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int partition([In] int obj0, [In] int obj1, [In] int obj2)
    {
      object obj = this.array[obj2];
      this.swap(obj1, obj2);
      int num = obj0;
      for (int index = obj0; index < obj1; ++index)
      {
        if (this.comp.compare(this.array[index], obj) < 0)
        {
          this.swap(num, index);
          ++num;
        }
      }
      this.swap(obj1, num);
      return num;
    }

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public QuickSelect()
    {
    }

    [Signature("([TT;Ljava/util/Comparator<TT;>;II)I")]
    [LineNumberTable(new byte[] {159, 158, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int select(object[] items, Comparator comp, int n, int size)
    {
      this.array = items;
      this.comp = comp;
      return this.recursiveSelect(0, size - 1, n);
    }
  }
}
