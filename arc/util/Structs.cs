// Decompiled with JetBrains decompiler
// Type: arc.util.Structs
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math;
using IKVM.Attributes;
using java.lang;
using java.util;
using java.util.function;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  public class Structs : Object
  {
    [Signature("<T:Ljava/lang/Object;>([TT;TT;)Z")]
    [LineNumberTable(new byte[] {4, 111, 55, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool contains(object[] array, object value)
    {
      object[] objArray = array;
      int length = objArray.Length;
      for (int index = 0; index < length; ++index)
      {
        object objA = objArray[index];
        if (object.ReferenceEquals(objA, value) || value != null && Object.instancehelper_equals(value, objA))
          return true;
      }
      return false;
    }

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Intf<-TT;>;)Ljava/util/Comparator<TT;>;")]
    [LineNumberTable(118)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Comparator comparingInt(Intf keyExtractor) => (Comparator) new Structs.__\u003C\u003EAnon4(keyExtractor);

    [Signature("<T:Ljava/lang/Object;U:Ljava/lang/Object;>(Larc/func/Func<-TT;+TU;>;Ljava/util/Comparator<-TU;>;)Ljava/util/Comparator<TT;>;")]
    [LineNumberTable(106)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Comparator comparing(Func keyExtractor, Comparator keyComparator) => (Comparator) new Structs.__\u003C\u003EAnon1(keyComparator, keyExtractor);

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Floatf<-TT;>;)Ljava/util/Comparator<TT;>;")]
    [LineNumberTable(114)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Comparator comparingFloat(Floatf keyExtractor) => (Comparator) new Structs.__\u003C\u003EAnon3(keyExtractor);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool inBounds(int x, int y, int width, int height) => x >= 0 && y >= 0 && (x < width && y < height);

    [LineNumberTable(185)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool inBounds(int x, int y, int[][] array) => x >= 0 && y >= 0 && (x < array.Length && y < array[0].Length);

    [Signature("<T:Ljava/lang/Object;>([TT;Larc/func/Boolf<TT;>;)TT;")]
    [LineNumberTable(new byte[] {15, 111, 43, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object find(object[] array, Boolf value)
    {
      object[] objArray = array;
      int length = objArray.Length;
      for (int index = 0; index < length; ++index)
      {
        object obj = objArray[index];
        if (value.get(obj))
          return obj;
      }
      return (object) null;
    }

    [Signature("<T:Ljava/lang/Object;>([TT;Larc/func/Boolf<TT;>;)Z")]
    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool contains(object[] array, Boolf value) => Structs.find(array, value) != null;

    [Signature("<T:Ljava/lang/Object;U::Ljava/lang/Comparable<-TU;>;>(Larc/func/Func<-TT;+TU;>;)Ljava/util/Comparator<TT;>;")]
    [LineNumberTable(110)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Comparator comparing(Func keyExtractor) => (Comparator) new Structs.__\u003C\u003EAnon2(keyExtractor);

    [Signature("<T:Ljava/lang/Object;>(Ljava/util/Comparator<TT;>;Ljava/util/Comparator<TT;>;)Ljava/util/Comparator<TT;>;")]
    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Comparator comps(Comparator first, Comparator second) => (Comparator) new Structs.__\u003C\u003EAnon0(first, second);

    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool eq(object a, object b) => object.ReferenceEquals(a, b) || a != null && Object.instancehelper_equals(a, b);

    [Signature("<T:Ljava/lang/Object;>([TT;)TT;")]
    [LineNumberTable(new byte[] {159, 177, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object random(object[] array) => array.Length == 0 ? (object) null : array[Mathf.random(array.Length - 1)];

    [Signature("<T:Ljava/lang/Object;>(II[[TT;)Z")]
    [LineNumberTable(181)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool inBounds(int x, int y, object[][] array) => x >= 0 && y >= 0 && (x < array.Length && y < array[0].Length);

    [Signature("<T:Ljava/lang/Object;>([TT;)TT;")]
    [LineNumberTable(new byte[] {159, 182, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object select(params object[] array) => array.Length == 0 ? (object) null : array[Mathf.random(array.Length - 1)];

    [Signature("<T:Ljava/lang/Object;>([TT;)[TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object[] arr(params object[] array) => array;

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Boolf<-TT;>;)Ljava/util/Comparator<TT;>;")]
    [LineNumberTable(122)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Comparator comparingBool(Boolf keyExtractor) => (Comparator) new Structs.__\u003C\u003EAnon5(keyExtractor);

    [Signature("<T:Ljava/lang/Object;>([TT;Larc/func/Boolf<TT;>;)I")]
    [LineNumberTable(new byte[] {159, 187, 98, 112, 46, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int count(object[] array, Boolf value)
    {
      int num = 0;
      object[] objArray = array;
      int length = objArray.Length;
      for (int index = 0; index < length; ++index)
      {
        object obj = objArray[index];
        if (value.get(obj))
          ++num;
      }
      return num;
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;[TT;Larc/func/Boolf<TT;>;)[TT;")]
    [LineNumberTable(new byte[] {40, 106, 112, 50, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object[] filter(Class type, object[] array, Boolf value)
    {
      Seq seq = new Seq(true, array.Length, type);
      object[] objArray = array;
      int length = objArray.Length;
      for (int index = 0; index < length; ++index)
      {
        object obj = objArray[index];
        if (value.get(obj))
          seq.add(obj);
      }
      return seq.toArray();
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/util/Iterator<TT;>;Larc/func/Boolf<TT;>;)V")]
    [LineNumberTable(new byte[] {159, 169, 104, 110, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void filter(Iterator it, Boolf removal)
    {
      while (it.hasNext())
      {
        if (removal.get(it.next()))
          it.remove();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {50, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024comps\u00240(
      [In] Comparator obj0,
      [In] Comparator obj1,
      [In] object obj2,
      [In] object obj3)
    {
      int num = obj0.compare(obj2, obj3);
      return num != 0 ? num : obj1.compare(obj2, obj3);
    }

    [Modifiers]
    [LineNumberTable(106)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024comparing\u00241(
      [In] Comparator obj0,
      [In] Func obj1,
      [In] object obj2,
      [In] object obj3)
    {
      return obj0.compare(obj1.get(obj2), obj1.get(obj3));
    }

    [Modifiers]
    [LineNumberTable(110)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024comparing\u00242([In] Func obj0, [In] object obj1, [In] object obj2) => Comparable.__Helper.compareTo((IComparable) obj0.get(obj1), obj0.get(obj2));

    [Modifiers]
    [LineNumberTable(114)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024comparingFloat\u00243([In] Floatf obj0, [In] object obj1, [In] object obj2) => Float.compare(obj0.get(obj1), obj0.get(obj2));

    [Modifiers]
    [LineNumberTable(118)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024comparingInt\u00244([In] Intf obj0, [In] object obj1, [In] object obj2) => Integer.compare(obj0.get(obj1), obj0.get(obj2));

    [Modifiers]
    [LineNumberTable(122)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024comparingBool\u00245([In] Boolf obj0, [In] object obj1, [In] object obj2) => Boolean.compare(obj0.get(obj1), obj0.get(obj2));

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Structs()
    {
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Iterable<TT;>;Larc/func/Boolf<TT;>;)V")]
    [LineNumberTable(new byte[] {159, 164, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void filter(Iterable iterable, Boolf removal) => Structs.filter(iterable.iterator(), removal);

    [Signature("<T:Ljava/lang/Object;>([TT;TT;)I")]
    [LineNumberTable(new byte[] {22, 103, 107, 2, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int indexOf(object[] array, object value)
    {
      for (int index = 0; index < array.Length; ++index)
      {
        if (object.ReferenceEquals(array[index], value))
          return index;
      }
      return -1;
    }

    [Signature("<T:Ljava/lang/Object;>([TT;Larc/func/Boolf<TT;>;)I")]
    [LineNumberTable(new byte[] {31, 103, 107, 2, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int indexOf(object[] array, Boolf value)
    {
      for (int index = 0; index < array.Length; ++index)
      {
        if (value.get(array[index]))
          return index;
      }
      return -1;
    }

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;[TT;)V")]
    [LineNumberTable(new byte[] {76, 111, 39, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void each(Cons cons, params object[] objects)
    {
      object[] objArray = objects;
      int length = objArray.Length;
      for (int index = 0; index < length; ++index)
      {
        object obj = objArray[index];
        cons.get(obj);
      }
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Iterable<TT;>;Larc/func/Cons<TT;>;)V")]
    [LineNumberTable(new byte[] {82, 118, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void forEach(Iterable i, Cons cons)
    {
      Iterator iterator = i.iterator();
      while (iterator.hasNext())
      {
        object obj = iterator.next();
        cons.get(obj);
      }
    }

    [Signature("<T:Ljava/lang/Object;>([TT;Ljava/util/Comparator<TT;>;)TT;")]
    [LineNumberTable(new byte[] {88, 98, 112, 111, 3, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object findMin(object[] arr, Comparator comp)
    {
      object obj1 = (object) null;
      object[] objArray = arr;
      int length = objArray.Length;
      for (int index = 0; index < length; ++index)
      {
        object obj2 = objArray[index];
        if (obj1 == null || comp.compare(obj1, obj2) < 0)
          obj1 = obj2;
      }
      return obj1;
    }

    [Signature("<T:Ljava/lang/Object;>([TT;Larc/func/Floatf<TT;>;)TT;")]
    [LineNumberTable(new byte[] {98, 98, 102, 115, 107, 101, 99, 227, 60, 232, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object findMin(object[] arr, Floatf proc)
    {
      object obj1 = (object) null;
      float num1 = float.MaxValue;
      object[] objArray = arr;
      int length = objArray.Length;
      for (int index = 0; index < length; ++index)
      {
        object obj2 = objArray[index];
        float num2 = proc.get(obj2);
        if ((double) num2 <= (double) num1)
        {
          obj1 = obj2;
          num1 = num2;
        }
      }
      return obj1;
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Iterable<TT;>;Ljava/util/Comparator<TT;>;)TT;")]
    [LineNumberTable(new byte[] {111, 98, 118, 110, 130, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object findMin(Iterable arr, Comparator comp)
    {
      object obj1 = (object) null;
      Iterator iterator = arr.iterator();
      while (iterator.hasNext())
      {
        object obj2 = iterator.next();
        if (obj1 == null || comp.compare(obj1, obj2) < 0)
          obj1 = obj2;
      }
      return obj1;
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Iterable<TT;>;Larc/func/Boolf<TT;>;Ljava/util/Comparator<TT;>;)TT;")]
    [LineNumberTable(new byte[] {121, 98, 118, 119, 130, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object findMin(Iterable arr, Boolf allow, Comparator comp)
    {
      object obj1 = (object) null;
      Iterator iterator = arr.iterator();
      while (iterator.hasNext())
      {
        object obj2 = iterator.next();
        if (allow.get(obj2) && (obj1 == null || comp.compare(obj1, obj2) < 0))
          obj1 = obj2;
      }
      return obj1;
    }

    [LineNumberTable(189)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool inBounds(int x, int y, float[][] array) => x >= 0 && y >= 0 && (x < array.Length && y < array[0].Length);

    [LineNumberTable(193)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool inBounds(int x, int y, bool[][] array) => x >= 0 && y >= 0 && (x < array.Length && y < array[0].Length);

    [Signature("<T:Ljava/lang/Object;>(III[[[TT;)Z")]
    [LineNumberTable(197)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool inBounds(int x, int y, int z, object[][][] array) => x >= 0 && y >= 0 && (z >= 0 && x < array.Length) && (y < array[0].Length && z < array[0][0].Length);

    [LineNumberTable(201)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool inBounds(int x, int y, int z, int[][][] array) => x >= 0 && y >= 0 && (z >= 0 && x < array.Length) && (y < array[0].Length && z < array[0][0].Length);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool inBounds(int x, int y, int z, int size, int padding) => x >= padding && y >= padding && (z >= padding && x < size - padding) && (y < size - padding && z < size - padding);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Comparator
    {
      private readonly Comparator arg\u00241;
      private readonly Comparator arg\u00242;

      internal __\u003C\u003EAnon0([In] Comparator obj0, [In] Comparator obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public int compare([In] object obj0, [In] object obj1) => Structs.lambda\u0024comps\u00240(this.arg\u00241, this.arg\u00242, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public bool equals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

      [SpecialName]
      public Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Comparator
    {
      private readonly Comparator arg\u00241;
      private readonly Func arg\u00242;

      internal __\u003C\u003EAnon1([In] Comparator obj0, [In] Func obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public int compare([In] object obj0, [In] object obj1) => Structs.lambda\u0024comparing\u00241(this.arg\u00241, this.arg\u00242, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public bool equals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

      [SpecialName]
      public Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Comparator
    {
      private readonly Func arg\u00241;

      internal __\u003C\u003EAnon2([In] Func obj0) => this.arg\u00241 = obj0;

      public int compare([In] object obj0, [In] object obj1) => Structs.lambda\u0024comparing\u00242(this.arg\u00241, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public bool equals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

      [SpecialName]
      public Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Comparator
    {
      private readonly Floatf arg\u00241;

      internal __\u003C\u003EAnon3([In] Floatf obj0) => this.arg\u00241 = obj0;

      public int compare([In] object obj0, [In] object obj1) => Structs.lambda\u0024comparingFloat\u00243(this.arg\u00241, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public bool equals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

      [SpecialName]
      public Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Comparator
    {
      private readonly Intf arg\u00241;

      internal __\u003C\u003EAnon4([In] Intf obj0) => this.arg\u00241 = obj0;

      public int compare([In] object obj0, [In] object obj1) => Structs.lambda\u0024comparingInt\u00244(this.arg\u00241, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public bool equals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

      [SpecialName]
      public Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Comparator
    {
      private readonly Boolf arg\u00241;

      internal __\u003C\u003EAnon5([In] Boolf obj0) => this.arg\u00241 = obj0;

      public int compare([In] object obj0, [In] object obj1) => Structs.lambda\u0024comparingBool\u00245(this.arg\u00241, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public bool equals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

      [SpecialName]
      public Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);
    }
  }
}
