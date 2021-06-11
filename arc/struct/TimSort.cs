// Decompiled with JetBrains decompiler
// Type: arc.struct.TimSort
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.@struct
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;")]
  internal class TimSort : Object
  {
    private const int MIN_MERGE = 32;
    private const int MIN_GALLOP = 7;
    private const int INITIAL_TMP_STORAGE_LENGTH = 256;
    private const bool DEBUG = false;
    [Modifiers]
    private int[] runBase;
    [Modifiers]
    private int[] runLen;
    [Signature("[TT;")]
    private object[] a;
    [Signature("Ljava/util/Comparator<-TT;>;")]
    private Comparator c;
    private int minGallop;
    [Signature("[TT;")]
    private object[] tmp;
    private int tmpCount;
    private int stackSize;

    [LineNumberTable(new byte[] {44, 232, 50, 231, 76, 167, 112, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal TimSort()
    {
      TimSort timSort = this;
      this.minGallop = 7;
      this.stackSize = 0;
      this.tmp = new object[256];
      this.runBase = new int[40];
      this.runLen = new int[40];
    }

    [Signature("([TT;Ljava/util/Comparator<TT;>;II)V")]
    [LineNumberTable(new byte[] {161, 92, 103, 106, 101, 165, 101, 107, 109, 161, 103, 103, 199, 167, 171, 100, 105, 110, 194, 104, 166, 101, 100, 198, 166, 103, 103, 104, 111, 37, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void doSort([In] object[] obj0, [In] Comparator obj1, [In] int obj2, [In] int obj3)
    {
      this.stackSize = 0;
      TimSort.rangeCheck(obj0.Length, obj2, obj3);
      int num1 = obj3 - obj2;
      if (num1 < 2)
        return;
      if (num1 < 32)
      {
        int num2 = TimSort.countRunAndMakeAscending(obj0, obj2, obj3, obj1);
        TimSort.binarySort(obj0, obj2, obj3, obj2 + num2, obj1);
      }
      else
      {
        this.a = obj0;
        this.c = obj1;
        this.tmpCount = 0;
        int num2 = TimSort.minRunLength(num1);
        do
        {
          int num3 = TimSort.countRunAndMakeAscending(obj0, obj2, obj3, obj1);
          if (num3 < num2)
          {
            int num4 = num1 > num2 ? num2 : num1;
            TimSort.binarySort(obj0, obj2, obj2 + num4, obj2 + num3, obj1);
            num3 = num4;
          }
          this.pushRun(obj2, num3);
          this.mergeCollapse();
          obj2 += num3;
          num1 -= num3;
        }
        while (num1 != 0);
        this.mergeForceCollapse();
        this.a = (object[]) null;
        this.c = (Comparator) null;
        object[] tmp = this.tmp;
        int index = 0;
        for (int tmpCount = this.tmpCount; index < tmpCount; ++index)
          tmp[index] = (object) null;
      }
    }

    [Signature("<T:Ljava/lang/Object;>([TT;IILjava/util/Comparator<-TT;>;)V")]
    [LineNumberTable(new byte[] {85, 99, 104, 161, 105, 100, 165, 101, 106, 108, 225, 69, 104, 167, 171, 101, 106, 112, 196, 105, 166, 102, 101, 198, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void sort([In] object[] obj0, [In] int obj1, [In] int obj2, [In] Comparator obj3)
    {
      if (obj3 == null)
      {
        Arrays.sort(obj0, obj1, obj2);
      }
      else
      {
        TimSort.rangeCheck(obj0.Length, obj1, obj2);
        int num1 = obj2 - obj1;
        if (num1 < 2)
          return;
        if (num1 < 32)
        {
          int num2 = TimSort.countRunAndMakeAscending(obj0, obj1, obj2, obj3);
          TimSort.binarySort(obj0, obj1, obj2, obj1 + num2, obj3);
        }
        else
        {
          TimSort timSort = new TimSort(obj0, obj3);
          int num2 = TimSort.minRunLength(num1);
          do
          {
            int num3 = TimSort.countRunAndMakeAscending(obj0, obj1, obj2, obj3);
            if (num3 < num2)
            {
              int num4 = num1 > num2 ? num2 : num1;
              TimSort.binarySort(obj0, obj1, obj1 + num4, obj1 + num3, obj3);
              num3 = num4;
            }
            timSort.pushRun(obj1, num3);
            timSort.mergeCollapse();
            obj1 += num3;
            num1 -= num3;
          }
          while (num1 != 0);
          timSort.mergeForceCollapse();
        }
      }
    }

    [LineNumberTable(new byte[] {161, 85, 100, 127, 32, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void rangeCheck([In] int obj0, [In] int obj1, [In] int obj2)
    {
      if (obj1 > obj2)
      {
        string str = new StringBuilder().append("fromIndex(").append(obj1).append(") > toIndex(").append(obj2).append(")").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (obj1 < 0)
      {
        int num = obj1;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArrayIndexOutOfBoundsException(num);
      }
      if (obj2 > obj0)
      {
        int num = obj2;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArrayIndexOutOfBoundsException(num);
      }
    }

    [Signature("<T:Ljava/lang/Object;>([TT;IILjava/util/Comparator<-TT;>;)I")]
    [LineNumberTable(new byte[] {160, 144, 100, 166, 115, 117, 102, 138, 117, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int countRunAndMakeAscending(
      [In] object[] obj0,
      [In] int obj1,
      [In] int obj2,
      [In] Comparator obj3)
    {
      int num = obj1 + 1;
      if (num == obj2)
        return 1;
      Comparator comparator = obj3;
      object[] objArray = obj0;
      int index1 = num;
      int index2 = num + 1;
      object obj4 = objArray[index1];
      object obj5 = obj0[obj1];
      if (comparator.compare(obj4, obj5) < 0)
      {
        while (index2 < obj2 && obj3.compare(obj0[index2], obj0[index2 - 1]) < 0)
          ++index2;
        TimSort.reverseRange(obj0, obj1, index2);
      }
      else
      {
        while (index2 < obj2 && obj3.compare(obj0[index2], obj0[index2 - 1]) >= 0)
          ++index2;
      }
      return index2 - obj1;
    }

    [Signature("<T:Ljava/lang/Object;>([TT;IIILjava/util/Comparator<-TT;>;)V")]
    [LineNumberTable(new byte[] {160, 82, 105, 103, 164, 98, 226, 69, 100, 102, 110, 132, 100, 226, 72, 132, 146, 138, 104, 130, 140, 228, 29, 234, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void binarySort([In] object[] obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] Comparator obj4)
    {
      if (obj3 == obj1)
        ++obj3;
      for (; obj3 < obj2; ++obj3)
      {
        object obj = obj0[obj3];
        int index1 = obj1;
        int num1 = obj3;
        while (index1 < num1)
        {
          int index2 = (int) ((uint) (index1 + num1) >> 1);
          if (obj4.compare(obj, obj0[index2]) < 0)
            num1 = index2;
          else
            index1 = index2 + 1;
        }
        int num2 = obj3 - index1;
        switch (num2)
        {
          case 1:
            obj0[index1 + 1] = obj0[index1];
            break;
          case 2:
            obj0[index1 + 2] = obj0[index1 + 1];
            goto case 1;
          default:
            ByteCodeHelper.arraycopy((object) obj0, index1, (object) obj0, index1 + 1, num2);
            break;
        }
        obj0[index1] = obj;
      }
    }

    [Signature("([TT;Ljava/util/Comparator<-TT;>;)V")]
    [LineNumberTable(new byte[] {55, 232, 39, 231, 76, 231, 78, 103, 167, 99, 253, 73, 127, 4, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private TimSort([In] object[] obj0, [In] Comparator obj1)
    {
      TimSort timSort = this;
      this.minGallop = 7;
      this.stackSize = 0;
      this.a = obj0;
      this.c = obj1;
      int length1 = obj0.Length;
      this.tmp = new object[length1 >= 512 ? 256 : (int) ((uint) length1 >> 1)];
      int length2 = length1 >= 120 ? (length1 >= 1542 ? (length1 >= 119151 ? 40 : 19) : 10) : 5;
      this.runBase = new int[length2];
      this.runLen = new int[length2];
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int minRunLength([In] int obj0)
    {
      int num = 0;
      for (; obj0 >= 32; obj0 >>= 1)
        num |= obj0 & 1;
      return obj0 + num;
    }

    [LineNumberTable(new byte[] {161, 149, 110, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void pushRun([In] int obj0, [In] int obj1)
    {
      this.runBase[this.stackSize] = obj0;
      this.runLen[this.stackSize] = obj1;
      ++this.stackSize;
    }

    [LineNumberTable(new byte[] {161, 169, 108, 105, 127, 39, 124, 116, 130, 103, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void mergeCollapse()
    {
      while (this.stackSize > 1)
      {
        int index = this.stackSize - 2;
        if (index >= 1 && this.runLen[index - 1] <= this.runLen[index] + this.runLen[index + 1] || index >= 2 && this.runLen[index - 2] <= this.runLen[index] + this.runLen[index - 1])
        {
          if (this.runLen[index - 1] < this.runLen[index + 1])
            index += -1;
        }
        else if (this.runLen[index] > this.runLen[index + 1])
          break;
        this.mergeAt(index);
      }
    }

    [LineNumberTable(new byte[] {161, 182, 105, 105, 126, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void mergeForceCollapse()
    {
      while (this.stackSize > 1)
      {
        int num = this.stackSize - 2;
        if (num > 0 && this.runLen[num - 1] < this.runLen[num + 1])
          num += -1;
        this.mergeAt(num);
      }
    }

    [LineNumberTable(new byte[] {160, 167, 101, 100, 100, 107, 105, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void reverseRange([In] object[] obj0, [In] int obj1, [In] int obj2)
    {
      obj2 += -1;
      while (obj1 < obj2)
      {
        object obj3 = obj0[obj1];
        object[] objArray1 = obj0;
        int index1 = obj1;
        ++obj1;
        object obj4 = obj0[obj2];
        objArray1[index1] = obj4;
        object[] objArray2 = obj0;
        int index2 = obj2;
        obj2 += -1;
        object obj5 = obj3;
        objArray2[index2] = obj5;
      }
    }

    [LineNumberTable(new byte[] {161, 199, 105, 105, 107, 235, 72, 107, 107, 116, 148, 238, 70, 158, 101, 101, 228, 70, 159, 4, 164, 100, 140, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void mergeAt([In] int obj0)
    {
      int num1 = this.runBase[obj0];
      int num2 = this.runLen[obj0];
      int index = this.runBase[obj0 + 1];
      int num3 = this.runLen[obj0 + 1];
      this.runLen[obj0] = num2 + num3;
      if (obj0 == this.stackSize - 3)
      {
        this.runBase[obj0 + 1] = this.runBase[obj0 + 2];
        this.runLen[obj0 + 1] = this.runLen[obj0 + 2];
      }
      --this.stackSize;
      int num4 = TimSort.gallopRight(this.a[index], this.a, num1, num2, 0, this.c);
      int num5 = num1 + num4;
      int num6 = num2 - num4;
      if (num6 == 0)
        return;
      int num7 = TimSort.gallopLeft(this.a[num5 + num6 - 1], this.a, index, num3, num3 - 1, this.c);
      if (num7 == 0)
        return;
      if (num6 <= num7)
        this.mergeLo(num5, num6, index, num7);
      else
        this.mergeHi(num5, num6, index, num7);
    }

    [Signature("<T:Ljava/lang/Object;>(TT;[TT;IIILjava/util/Comparator<-TT;>;)I")]
    [LineNumberTable(new byte[] {161, 25, 98, 98, 148, 101, 119, 98, 102, 100, 132, 166, 98, 101, 101, 133, 101, 119, 98, 102, 100, 132, 166, 101, 229, 72, 100, 100, 136, 112, 132, 100, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int gallopRight(
      [In] object obj0,
      [In] object[] obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] Comparator obj5)
    {
      int num1 = 1;
      int num2 = 0;
      int num3;
      int num4;
      if (obj5.compare(obj0, obj1[obj2 + obj4]) < 0)
      {
        int num5 = obj4 + 1;
        while (num1 < num5 && obj5.compare(obj0, obj1[obj2 + obj4 - num1]) < 0)
        {
          num2 = num1;
          num1 = (num1 << 1) + 1;
          if (num1 <= 0)
            num1 = num5;
        }
        if (num1 > num5)
          num1 = num5;
        int num6 = num2;
        num3 = obj4 - num1;
        num4 = obj4 - num6;
      }
      else
      {
        int num5 = obj3 - obj4;
        while (num1 < num5 && obj5.compare(obj0, obj1[obj2 + obj4 + num1]) >= 0)
        {
          num2 = num1;
          num1 = (num1 << 1) + 1;
          if (num1 <= 0)
            num1 = num5;
        }
        if (num1 > num5)
          num1 = num5;
        num3 = num2 + obj4;
        num4 = num1 + obj4;
      }
      int num7 = num3 + 1;
      while (num7 < num4)
      {
        int num5 = num7 + (int) ((uint) (num4 - num7) >> 1);
        if (obj5.compare(obj0, obj1[obj2 + num5]) < 0)
          num4 = num5;
        else
          num7 = num5 + 1;
      }
      return num4;
    }

    [Signature("<T:Ljava/lang/Object;>(TT;[TT;IIILjava/util/Comparator<-TT;>;)I")]
    [LineNumberTable(new byte[] {160, 215, 98, 98, 148, 101, 119, 98, 102, 100, 132, 166, 101, 101, 133, 101, 119, 98, 102, 100, 132, 166, 98, 101, 229, 72, 100, 100, 136, 112, 134, 98, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int gallopLeft(
      [In] object obj0,
      [In] object[] obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] Comparator obj5)
    {
      int num1 = 0;
      int num2 = 1;
      int num3;
      int num4;
      if (obj5.compare(obj0, obj1[obj2 + obj4]) > 0)
      {
        int num5 = obj3 - obj4;
        while (num2 < num5 && obj5.compare(obj0, obj1[obj2 + obj4 + num2]) > 0)
        {
          num1 = num2;
          num2 = (num2 << 1) + 1;
          if (num2 <= 0)
            num2 = num5;
        }
        if (num2 > num5)
          num2 = num5;
        num3 = num1 + obj4;
        num4 = num2 + obj4;
      }
      else
      {
        int num5 = obj4 + 1;
        while (num2 < num5 && obj5.compare(obj0, obj1[obj2 + obj4 - num2]) <= 0)
        {
          num1 = num2;
          num2 = (num2 << 1) + 1;
          if (num2 <= 0)
            num2 = num5;
        }
        if (num2 > num5)
          num2 = num5;
        int num6 = num1;
        num3 = obj4 - num2;
        num4 = obj4 - num6;
      }
      int num7 = num3 + 1;
      while (num7 < num4)
      {
        int num5 = num7 + (int) ((uint) (num4 - num7) >> 1);
        if (obj5.compare(obj0, obj1[obj2 + num5]) > 0)
          num7 = num5 + 1;
        else
          num4 = num5;
      }
      return num4;
    }

    [LineNumberTable(new byte[] {162, 2, 103, 104, 138, 98, 98, 163, 113, 106, 107, 129, 100, 108, 106, 161, 104, 168, 99, 227, 71, 112, 113, 102, 99, 143, 113, 102, 99, 142, 236, 72, 112, 100, 108, 103, 101, 102, 100, 133, 113, 143, 113, 100, 108, 103, 101, 103, 134, 113, 107, 102, 118, 104, 102, 101, 144, 132, 108, 108, 99, 208, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void mergeLo([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      object[] a = this.a;
      object[] objArray1 = this.ensureCapacity(obj1);
      ByteCodeHelper.arraycopy((object) a, obj0, (object) objArray1, 0, obj1);
      int index1 = 0;
      int num1 = obj2;
      int num2 = obj0;
      object[] objArray2 = a;
      int index2 = num2;
      int num3 = num2 + 1;
      object[] objArray3 = a;
      int index3 = num1;
      int index4 = num1 + 1;
      object obj4 = objArray3[index3];
      objArray2[index2] = obj4;
      obj3 += -1;
      if (obj3 == 0)
        ByteCodeHelper.arraycopy((object) objArray1, index1, (object) a, num3, obj1);
      else if (obj1 == 1)
      {
        ByteCodeHelper.arraycopy((object) a, index4, (object) a, num3, obj3);
        a[num3 + obj3] = objArray1[index1];
      }
      else
      {
        Comparator c = this.c;
        int num4 = this.minGallop;
        while (true)
        {
          int num5 = 0;
          int num6 = 0;
          do
          {
            if (c.compare(a[index4], objArray1[index1]) < 0)
            {
              object[] objArray4 = a;
              int index5 = num3;
              ++num3;
              object[] objArray5 = a;
              int index6 = index4;
              ++index4;
              object obj5 = objArray5[index6];
              objArray4[index5] = obj5;
              ++num6;
              num5 = 0;
              obj3 += -1;
              if (obj3 == 0)
                goto label_20;
            }
            else
            {
              object[] objArray4 = a;
              int index5 = num3;
              ++num3;
              object[] objArray5 = objArray1;
              int index6 = index1;
              ++index1;
              object obj5 = objArray5[index6];
              objArray4[index5] = obj5;
              ++num5;
              num6 = 0;
              obj1 += -1;
              if (obj1 == 1)
                goto label_20;
            }
          }
          while ((num5 | num6) < num4);
          int num7;
          int num8;
          do
          {
            num7 = TimSort.gallopRight(a[index4], objArray1, index1, obj1, 0, c);
            if (num7 != 0)
            {
              ByteCodeHelper.arraycopy((object) objArray1, index1, (object) a, num3, num7);
              num3 += num7;
              index1 += num7;
              obj1 -= num7;
              if (obj1 <= 1)
                goto label_20;
            }
            object[] objArray4 = a;
            int index5 = num3;
            ++num3;
            object[] objArray5 = a;
            int index6 = index4;
            ++index4;
            object obj5 = objArray5[index6];
            objArray4[index5] = obj5;
            obj3 += -1;
            if (obj3 != 0)
            {
              num8 = TimSort.gallopLeft(objArray1[index1], a, index4, obj3, 0, c);
              if (num8 != 0)
              {
                ByteCodeHelper.arraycopy((object) a, index4, (object) a, num3, num8);
                num3 += num8;
                index4 += num8;
                obj3 -= num8;
                if (obj3 == 0)
                  goto label_20;
              }
              object[] objArray6 = a;
              int index7 = num3;
              ++num3;
              object[] objArray7 = objArray1;
              int index8 = index1;
              ++index1;
              object obj6 = objArray7[index8];
              objArray6[index7] = obj6;
              obj1 += -1;
              if (obj1 != 1)
                num4 += -1;
              else
                goto label_20;
            }
            else
              goto label_20;
          }
          while (num7 >= 7 | num8 >= 7);
          if (num4 < 0)
            num4 = 0;
          num4 += 2;
        }
label_20:
        this.minGallop = num4 >= 1 ? num4 : 1;
        if (obj1 == 1)
        {
          ByteCodeHelper.arraycopy((object) a, index4, (object) a, num3, obj3);
          a[num3 + obj3] = objArray1[index1];
        }
        else
        {
          if (obj1 == 0)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException("Comparison method violates its general contract!");
          }
          ByteCodeHelper.arraycopy((object) objArray1, index1, (object) a, num3, obj1);
        }
      }
    }

    [LineNumberTable(new byte[] {162, 107, 103, 105, 139, 102, 101, 168, 113, 104, 113, 129, 101, 102, 100, 111, 103, 161, 104, 168, 99, 227, 71, 112, 113, 102, 99, 141, 113, 102, 99, 144, 236, 72, 116, 100, 103, 101, 102, 112, 136, 113, 144, 119, 100, 103, 101, 103, 112, 101, 130, 113, 106, 102, 118, 104, 102, 101, 144, 133, 102, 100, 111, 105, 100, 208, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void mergeHi([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      object[] a = this.a;
      object[] objArray1 = this.ensureCapacity(obj3);
      ByteCodeHelper.arraycopy((object) a, obj2, (object) objArray1, 0, obj3);
      int num1 = obj0 + obj1 - 1;
      int index1 = obj3 - 1;
      int num2 = obj2 + obj3 - 1;
      object[] objArray2 = a;
      int index2 = num2;
      int num3 = num2 - 1;
      object[] objArray3 = a;
      int index3 = num1;
      int index4 = num1 - 1;
      object obj4 = objArray3[index3];
      objArray2[index2] = obj4;
      obj1 += -1;
      if (obj1 == 0)
        ByteCodeHelper.arraycopy((object) objArray1, 0, (object) a, num3 - (obj3 - 1), obj3);
      else if (obj3 == 1)
      {
        int index5 = num3 - obj1;
        int num4 = index4 - obj1;
        ByteCodeHelper.arraycopy((object) a, num4 + 1, (object) a, index5 + 1, obj1);
        a[index5] = objArray1[index1];
      }
      else
      {
        Comparator c = this.c;
        int num4 = this.minGallop;
        while (true)
        {
          int num5 = 0;
          int num6 = 0;
          do
          {
            if (c.compare(objArray1[index1], a[index4]) < 0)
            {
              object[] objArray4 = a;
              int index5 = num3;
              num3 += -1;
              object[] objArray5 = a;
              int index6 = index4;
              index4 += -1;
              object obj5 = objArray5[index6];
              objArray4[index5] = obj5;
              ++num5;
              num6 = 0;
              obj1 += -1;
              if (obj1 == 0)
                goto label_20;
            }
            else
            {
              object[] objArray4 = a;
              int index5 = num3;
              num3 += -1;
              object[] objArray5 = objArray1;
              int index6 = index1;
              index1 += -1;
              object obj5 = objArray5[index6];
              objArray4[index5] = obj5;
              ++num6;
              num5 = 0;
              obj3 += -1;
              if (obj3 == 1)
                goto label_20;
            }
          }
          while ((num5 | num6) < num4);
          int num7;
          int num8;
          do
          {
            num7 = obj1 - TimSort.gallopRight(objArray1[index1], a, obj0, obj1, obj1 - 1, c);
            if (num7 != 0)
            {
              num3 -= num7;
              index4 -= num7;
              obj1 -= num7;
              ByteCodeHelper.arraycopy((object) a, index4 + 1, (object) a, num3 + 1, num7);
              if (obj1 == 0)
                goto label_20;
            }
            object[] objArray4 = a;
            int index5 = num3;
            num3 += -1;
            object[] objArray5 = objArray1;
            int index6 = index1;
            index1 += -1;
            object obj5 = objArray5[index6];
            objArray4[index5] = obj5;
            obj3 += -1;
            if (obj3 != 1)
            {
              num8 = obj3 - TimSort.gallopLeft(a[index4], objArray1, 0, obj3, obj3 - 1, c);
              if (num8 != 0)
              {
                num3 -= num8;
                index1 -= num8;
                obj3 -= num8;
                ByteCodeHelper.arraycopy((object) objArray1, index1 + 1, (object) a, num3 + 1, num8);
                if (obj3 <= 1)
                  goto label_20;
              }
              object[] objArray6 = a;
              int index7 = num3;
              num3 += -1;
              object[] objArray7 = a;
              int index8 = index4;
              index4 += -1;
              object obj6 = objArray7[index8];
              objArray6[index7] = obj6;
              obj1 += -1;
              if (obj1 != 0)
                num4 += -1;
              else
                goto label_20;
            }
            else
              goto label_20;
          }
          while (num7 >= 7 | num8 >= 7);
          if (num4 < 0)
            num4 = 0;
          num4 += 2;
        }
label_20:
        this.minGallop = num4 >= 1 ? num4 : 1;
        if (obj3 == 1)
        {
          int index5 = num3 - obj1;
          int num5 = index4 - obj1;
          ByteCodeHelper.arraycopy((object) a, num5 + 1, (object) a, index5 + 1, obj1);
          a[index5] = objArray1[index1];
        }
        else
        {
          if (obj3 == 0)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException("Comparison method violates its general contract!");
          }
          ByteCodeHelper.arraycopy((object) objArray1, 0, (object) a, num3 - (obj3 - 1), obj3);
        }
      }
    }

    [Signature("(I)[TT;")]
    [LineNumberTable(new byte[] {162, 211, 114, 141, 98, 102, 102, 102, 102, 103, 132, 100, 132, 144, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object[] ensureCapacity([In] int obj0)
    {
      this.tmpCount = Math.max(this.tmpCount, obj0);
      if (this.tmp.Length < obj0)
      {
        int num1 = obj0;
        int num2 = num1 | num1 >> 1;
        int num3 = num2 | num2 >> 2;
        int num4 = num3 | num3 >> 4;
        int num5 = num4 | num4 >> 8;
        int num6 = (num5 | num5 >> 16) + 1;
        this.tmp = new object[num6 >= 0 ? Math.min(num6, (int) ((uint) this.a.Length >> 1)) : obj0];
      }
      return this.tmp;
    }

    [Signature("<T:Ljava/lang/Object;>([TT;Ljava/util/Comparator<-TT;>;)V")]
    [LineNumberTable(new byte[] {76, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void sort([In] object[] obj0, [In] Comparator obj1) => TimSort.sort(obj0, 0, obj0.Length, obj1);
  }
}
