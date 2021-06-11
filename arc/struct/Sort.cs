// Decompiled with JetBrains decompiler
// Type: arc.struct.Sort
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace arc.@struct
{
  public class Sort : Object
  {
    private static Sort instance;
    private TimSort timSort;
    private ComparableTimSort comparableTimSort;

    [LineNumberTable(new byte[] {159, 176, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Sort instance()
    {
      if (Sort.instance == null)
        Sort.instance = new Sort();
      return Sort.instance;
    }

    [Signature("<T:Ljava/lang/Object;>([TT;II)V")]
    [LineNumberTable(new byte[] {159, 191, 115, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sort(object[] a, int fromIndex, int toIndex)
    {
      if (this.comparableTimSort == null)
        this.comparableTimSort = new ComparableTimSort();
      this.comparableTimSort.doSort(a, fromIndex, toIndex);
    }

    [Signature("<T:Ljava/lang/Object;>([TT;Ljava/util/Comparator<-TT;>;II)V")]
    [LineNumberTable(new byte[] {14, 115, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sort(object[] a, Comparator c, int fromIndex, int toIndex)
    {
      if (this.timSort == null)
        this.timSort = new TimSort();
      this.timSort.doSort(a, c, fromIndex, toIndex);
    }

    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Sort()
    {
    }

    [Signature("<T:Ljava/lang/Object;>(Larc/struct/Seq<TT;>;)V")]
    [LineNumberTable(new byte[] {159, 181, 115, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sort(Seq a)
    {
      if (this.comparableTimSort == null)
        this.comparableTimSort = new ComparableTimSort();
      this.comparableTimSort.doSort(a.items, 0, a.size);
    }

    [Signature("<T:Ljava/lang/Object;>([TT;)V")]
    [LineNumberTable(new byte[] {159, 186, 115, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sort(object[] a)
    {
      if (this.comparableTimSort == null)
        this.comparableTimSort = new ComparableTimSort();
      this.comparableTimSort.doSort(a, 0, a.Length);
    }

    [Signature("<T:Ljava/lang/Object;>(Larc/struct/Seq<TT;>;Ljava/util/Comparator<-TT;>;)V")]
    [LineNumberTable(new byte[] {4, 115, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sort(Seq a, Comparator c)
    {
      if (this.timSort == null)
        this.timSort = new TimSort();
      this.timSort.doSort(a.items, c, 0, a.size);
    }

    [Signature("<T:Ljava/lang/Object;>([TT;Ljava/util/Comparator<-TT;>;)V")]
    [LineNumberTable(new byte[] {9, 115, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sort(object[] a, Comparator c)
    {
      if (this.timSort == null)
        this.timSort = new TimSort();
      this.timSort.doSort(a, c, 0, a.Length);
    }
  }
}
