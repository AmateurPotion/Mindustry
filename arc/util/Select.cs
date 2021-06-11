// Decompiled with JetBrains decompiler
// Type: arc.util.Select
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
  public class Select : Object
  {
    private static Select instance;
    private QuickSelect quickSelect;

    [LineNumberTable(new byte[] {159, 167, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Select instance()
    {
      if (Select.instance == null)
        Select.instance = new Select();
      return Select.instance;
    }

    [Signature("<T:Ljava/lang/Object;>([TT;Ljava/util/Comparator<TT;>;II)TT;")]
    [LineNumberTable(new byte[] {159, 172, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object select(object[] items, Comparator comp, int kthLowest, int size)
    {
      int index = this.selectIndex(items, comp, kthLowest, size);
      return items[index];
    }

    [Signature("<T:Ljava/lang/Object;>([TT;Ljava/util/Comparator<TT;>;II)I")]
    [LineNumberTable(new byte[] {159, 178, 101, 112, 101, 223, 23, 132, 109, 133, 173, 115, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int selectIndex(object[] items, Comparator comp, int kthLowest, int size)
    {
      if (size < 1)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("cannot select from empty array (size < 1)");
      }
      if (kthLowest > size)
      {
        string message = new StringBuilder().append("Kth rank is larger than size. k: ").append(kthLowest).append(", size: ").append(size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      int num;
      if (kthLowest == 1)
        num = this.fastMin(items, comp, size);
      else if (kthLowest == size)
      {
        num = this.fastMax(items, comp, size);
      }
      else
      {
        if (this.quickSelect == null)
          this.quickSelect = new QuickSelect();
        num = this.quickSelect.select(items, comp, kthLowest, size);
      }
      return num;
    }

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Select()
    {
    }

    [Signature("<T:Ljava/lang/Object;>([TT;Ljava/util/Comparator<TT;>;I)I")]
    [LineNumberTable(new byte[] {9, 98, 102, 109, 100, 226, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int fastMin([In] object[] obj0, [In] Comparator obj1, [In] int obj2)
    {
      int index1 = 0;
      for (int index2 = 1; index2 < obj2; ++index2)
      {
        if (obj1.compare(obj0[index2], obj0[index1]) < 0)
          index1 = index2;
      }
      return index1;
    }

    [Signature("<T:Ljava/lang/Object;>([TT;Ljava/util/Comparator<TT;>;I)I")]
    [LineNumberTable(new byte[] {21, 98, 102, 109, 100, 226, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int fastMax([In] object[] obj0, [In] Comparator obj1, [In] int obj2)
    {
      int index1 = 0;
      for (int index2 = 1; index2 < obj2; ++index2)
      {
        if (obj1.compare(obj0[index2], obj0[index1]) > 0)
          index1 = index2;
      }
      return index1;
    }
  }
}
