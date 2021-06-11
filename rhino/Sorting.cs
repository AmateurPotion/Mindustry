// Decompiled with JetBrains decompiler
// Type: rhino.Sorting
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public sealed class Sorting : Object
  {
    private const int SMALLSORT = 16;
    [Modifiers]
    private static Sorting sorting;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Sorting get() => Sorting.sorting;

    [Signature("([Ljava/lang/Object;Ljava/util/Comparator<Ljava/lang/Object;>;)V")]
    [LineNumberTable(new byte[] {159, 184, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hybridSort(object[] a, Comparator cmp) => this.hybridSort(a, 0, a.Length - 1, cmp, this.log2(a.Length) * 2);

    [Signature("([Ljava/lang/Object;IILjava/util/Comparator<Ljava/lang/Object;>;)V")]
    [LineNumberTable(new byte[] {159, 164, 98, 100, 100, 100, 114, 104, 134, 102, 100, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void insertionSort([In] object[] obj0, [In] int obj1, [In] int obj2, [In] Comparator obj3)
    {
      for (int index1 = obj1; index1 <= obj2; ++index1)
      {
        object obj = obj0[index1];
        int index2;
        for (index2 = index1 - 1; index2 >= obj1 && obj3.compare(obj0[index2], obj) > 0; index2 += -1)
          obj0[index2 + 1] = obj0[index2];
        obj0[index2 + 1] = obj;
      }
    }

    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int log2([In] int obj0) => ByteCodeHelper.d2i(Math.log10((double) obj0) / Math.log10(2.0));

    [Signature("([Ljava/lang/Object;IILjava/util/Comparator<Ljava/lang/Object;>;I)V")]
    [LineNumberTable(new byte[] {159, 188, 100, 107, 141, 108, 111, 177})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void hybridSort([In] object[] obj0, [In] int obj1, [In] int obj2, [In] Comparator obj3, [In] int obj4)
    {
      if (obj1 >= obj2)
        return;
      if (obj4 == 0 || obj2 - obj1 <= 16)
      {
        this.insertionSort(obj0, obj1, obj2, obj3);
      }
      else
      {
        int num = this.partition(obj0, obj1, obj2, obj3);
        this.hybridSort(obj0, obj1, num, obj3, obj4 - 1);
        this.hybridSort(obj0, num + 1, obj2, obj3, obj4 - 1);
      }
    }

    [Signature("([Ljava/lang/Object;IILjava/util/Comparator<Ljava/lang/Object;>;)I")]
    [LineNumberTable(new byte[] {14, 108, 100, 102, 132, 98, 164, 114, 100, 162, 114, 100, 162, 100, 130, 174, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int partition([In] object[] obj0, [In] int obj1, [In] int obj2, [In] Comparator obj3)
    {
      int index1 = this.median(obj0, obj1, obj2, obj3);
      object obj4 = obj0[index1];
      obj0[index1] = obj0[obj1];
      obj0[obj1] = obj4;
      int num1 = obj1;
      int num2 = obj2 + 1;
      while (true)
      {
        Comparator comparator1;
        object obj5;
        object obj6;
        do
        {
          comparator1 = obj3;
          object[] objArray = obj0;
          ++num1;
          int index2 = num1;
          obj5 = objArray[index2];
          obj6 = obj4;
        }
        while (comparator1.compare(obj5, obj6) < 0 && num1 != obj2);
        Comparator comparator2;
        object obj7;
        object obj8;
        do
        {
          comparator2 = obj3;
          object[] objArray = obj0;
          num2 += -1;
          int index2 = num2;
          obj7 = objArray[index2];
          obj8 = obj4;
        }
        while (comparator2.compare(obj7, obj8) >= 0 && num2 != obj1);
        if (num1 < num2)
          this.swap(obj0, num1, num2);
        else
          break;
      }
      this.swap(obj0, obj1, num2);
      return num2;
    }

    [Signature("([Ljava/lang/Object;IILjava/util/Comparator<Ljava/lang/Object;>;)I")]
    [LineNumberTable(new byte[] {58, 104, 130, 112, 130, 112, 162, 100, 149, 100, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int median(object[] a, int start, int end, Comparator cmp)
    {
      int index1 = start + (end - start) / 2;
      int index2 = start;
      if (cmp.compare(a[index2], a[index1]) > 0)
        index2 = index1;
      if (cmp.compare(a[index2], a[end]) > 0)
        index2 = end;
      return index2 == start ? (cmp.compare(a[index1], a[end]) < 0 ? index1 : end) : (index2 == index1 ? (cmp.compare(a[start], a[end]) < 0 ? start : end) : (cmp.compare(a[start], a[index1]) < 0 ? start : index1));
    }

    [LineNumberTable(new byte[] {44, 100, 102, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void swap([In] object[] obj0, [In] int obj1, [In] int obj2)
    {
      object obj = obj0[obj1];
      obj0[obj1] = obj0[obj2];
      obj0[obj2] = obj;
    }

    [LineNumberTable(new byte[] {159, 152, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Sorting()
    {
    }

    [Signature("([Ljava/lang/Object;Ljava/util/Comparator<Ljava/lang/Object;>;)V")]
    [LineNumberTable(new byte[] {159, 160, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void insertionSort(object[] a, Comparator cmp) => this.insertionSort(a, 0, a.Length - 1, cmp);

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Sorting()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.Sorting"))
        return;
      Sorting.sorting = new Sorting();
    }
  }
}
