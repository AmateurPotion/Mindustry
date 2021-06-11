// Decompiled with JetBrains decompiler
// Type: rhino.NativeArray
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using ikvm.lang;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using java.util;
using java.util.function;
using java.util.stream;
using rhino.regexp;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [Implements(new string[] {"java.util.List"})]
  public class NativeArray : IdScriptableObject, List, Collection, Iterable, IEnumerable
  {
    [Modifiers]
    private static object ARRAY_TAG;
    [Modifiers]
    private static Long NEGATIVE_ONE;
    private const int Id_length = 1;
    private const int MAX_INSTANCE_ID = 1;
    [Modifiers]
    [Signature("Ljava/util/Comparator<Ljava/lang/Object;>;")]
    private static Comparator STRING_COMPARATOR;
    [Modifiers]
    [Signature("Ljava/util/Comparator<Ljava/lang/Object;>;")]
    private static Comparator DEFAULT_COMPARATOR;
    private const int Id_constructor = 1;
    private const int Id_toString = 2;
    private const int Id_toLocaleString = 3;
    private const int Id_toSource = 4;
    private const int Id_join = 5;
    private const int Id_reverse = 6;
    private const int Id_sort = 7;
    private const int Id_push = 8;
    private const int Id_pop = 9;
    private const int Id_shift = 10;
    private const int Id_unshift = 11;
    private const int Id_splice = 12;
    private const int Id_concat = 13;
    private const int Id_slice = 14;
    private const int Id_indexOf = 15;
    private const int Id_lastIndexOf = 16;
    private const int Id_every = 17;
    private const int Id_filter = 18;
    private const int Id_forEach = 19;
    private const int Id_map = 20;
    private const int Id_some = 21;
    private const int Id_find = 22;
    private const int Id_findIndex = 23;
    private const int Id_reduce = 24;
    private const int Id_reduceRight = 25;
    private const int Id_fill = 26;
    private const int Id_keys = 27;
    private const int Id_values = 28;
    private const int Id_entries = 29;
    private const int Id_includes = 30;
    private const int Id_copyWithin = 31;
    private const int SymbolId_iterator = 32;
    private const int MAX_PROTOTYPE_ID = 32;
    private const int ConstructorId_join = -5;
    private const int ConstructorId_reverse = -6;
    private const int ConstructorId_sort = -7;
    private const int ConstructorId_push = -8;
    private const int ConstructorId_pop = -9;
    private const int ConstructorId_shift = -10;
    private const int ConstructorId_unshift = -11;
    private const int ConstructorId_splice = -12;
    private const int ConstructorId_concat = -13;
    private const int ConstructorId_slice = -14;
    private const int ConstructorId_indexOf = -15;
    private const int ConstructorId_lastIndexOf = -16;
    private const int ConstructorId_every = -17;
    private const int ConstructorId_filter = -18;
    private const int ConstructorId_forEach = -19;
    private const int ConstructorId_map = -20;
    private const int ConstructorId_some = -21;
    private const int ConstructorId_find = -22;
    private const int ConstructorId_findIndex = -23;
    private const int ConstructorId_reduce = -24;
    private const int ConstructorId_reduceRight = -25;
    private const int ConstructorId_isArray = -26;
    private const int ConstructorId_of = -27;
    private const int ConstructorId_from = -28;
    private long length;
    private int lengthAttr;
    private object[] dense;
    private bool denseOnly;
    private static int maximumInitialCapacity;
    private const int DEFAULT_INITIAL_CAPACITY = 10;
    private const double GROW_FACTOR = 1.5;
    private const int MAX_PRE_GROW_SIZE = 1431655764;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 185, 232, 170, 16, 231, 149, 241, 114, 104, 99, 101, 99, 108, 144, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeArray(long lengthArg)
    {
      NativeArray nativeArray = this;
      this.lengthAttr = 6;
      this.denseOnly = lengthArg <= (long) NativeArray.maximumInitialCapacity;
      if (this.denseOnly)
      {
        int length = (int) lengthArg;
        if (length < 10)
          length = 10;
        this.dense = new object[length];
        Arrays.fill(this.dense, Scriptable.NOT_FOUND);
      }
      this.length = lengthArg;
    }

    [LineNumberTable(new byte[] {5, 232, 170, 4, 231, 149, 253, 103, 103, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeArray(object[] array)
    {
      NativeArray nativeArray = this;
      this.lengthAttr = 6;
      this.denseOnly = true;
      this.dense = array;
      this.length = (long) array.Length;
    }

    [LineNumberTable(2135)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(int index) => this.get((long) index);

    [LineNumberTable(new byte[] {162, 218, 106, 161, 105, 103, 101, 107, 177, 107, 137, 121, 103, 97, 159, 3, 103, 103, 129, 167, 140, 147, 103, 108, 102, 137, 105, 105, 101, 104, 98, 110, 102, 232, 53, 235, 78, 130, 109, 40, 233, 69, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setLength([In] object obj0)
    {
      if ((this.lengthAttr & 1) != 0)
        return;
      double number = ScriptRuntime.toNumber(obj0);
      long uint32 = ScriptRuntime.toUint32(number);
      if ((double) uint32 != number)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", ScriptRuntime.getMessage0("msg.arraylength.bad")));
      if (this.denseOnly)
      {
        if (uint32 < this.length)
        {
          Arrays.fill(this.dense, (int) uint32, this.dense.Length, Scriptable.NOT_FOUND);
          this.length = uint32;
          return;
        }
        if (uint32 < 1431655764L && (double) uint32 < (double) this.length * 1.5 && this.ensureCapacity((int) uint32))
        {
          this.length = uint32;
          return;
        }
        this.denseOnly = false;
      }
      if (uint32 < this.length)
      {
        if (this.length - uint32 > 4096L)
        {
          foreach (object id in this.getIds())
          {
            if (id is string)
            {
              string name = (string) id;
              if (NativeArray.toArrayIndex(name) >= uint32)
                this.delete(name);
            }
            else
            {
              int index = ((Integer) id).intValue();
              if ((long) index >= uint32)
                this.delete(index);
            }
          }
        }
        else
        {
          for (long index = uint32; index < this.length; ++index)
            NativeArray.deleteElem((Scriptable) this, index);
        }
      }
      this.length = uint32;
    }

    [LineNumberTable(new byte[] {167, 157, 104, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool js_isArray([In] object obj0) => obj0 is Scriptable && String.instancehelper_equals("Array", (object) ((Scriptable) obj0).getClassName());

    [LineNumberTable(new byte[] {162, 175, 103, 134, 103, 44, 166, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object js_of([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3)
    {
      Scriptable array = NativeArray.callConstructorOrCreateArray(obj0, obj1, obj2, (long) obj3.Length, true);
      for (int index = 0; index < obj3.Length; ++index)
        NativeArray.defineElem(obj0, array, (long) index, obj3[index]);
      NativeArray.setLengthProperty(obj0, array, (long) obj3.Length);
      return (object) array;
    }

    [LineNumberTable(new byte[] {162, 120, 112, 102, 112, 102, 109, 131, 99, 104, 144, 104, 101, 201, 109, 126, 106, 106, 108, 109, 100, 110, 123, 99, 159, 2, 108, 103, 110, 95, 33, 255, 42, 56, 238, 72, 127, 27, 107, 195, 106, 109, 106, 106, 110, 99, 159, 2, 236, 58, 236, 74, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object js_from([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3)
    {
      Scriptable scriptable = ScriptRuntime.toObject(obj1, obj3.Length < 1 ? Undefined.__\u003C\u003Einstance : obj3[0]);
      object obj4 = obj3.Length < 2 ? Undefined.__\u003C\u003Einstance : obj3[1];
      Scriptable s2 = Undefined.__\u003C\u003ESCRIPTABLE_UNDEFINED;
      int num1 = Undefined.isUndefined(obj4) ? 0 : 1;
      Function function = (Function) null;
      if (num1 != 0)
      {
        function = obj4 is Function ? (Function) obj4 : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.map.function.not"));
        if (obj3.Length >= 3)
          s2 = ScriptableObject.ensureScriptable(obj3[2]);
      }
      object property = ScriptableObject.getProperty(scriptable, (Symbol) SymbolKey.__\u003C\u003EITERATOR);
      if (!(scriptable is NativeArray) && !object.ReferenceEquals(property, Scriptable.NOT_FOUND) && !Undefined.isUndefined(property))
      {
        object target = ScriptRuntime.callIterator((object) scriptable, obj0, obj1);
        if (!Undefined.isUndefined(target))
        {
          Scriptable array = NativeArray.callConstructorOrCreateArray(obj0, obj1, obj2, 0L, false);
          long num2 = 0;
          IteratorLikeIterable iteratorLikeIterable = new IteratorLikeIterable(obj0, obj1, target);
          Exception exception1 = (Exception) null;
          Exception exception2;
          // ISSUE: fault handler
          try
          {
            IteratorLikeIterable.Itr itr = iteratorLikeIterable.iterator();
            while (((Iterator) itr).hasNext())
            {
              object obj5 = ((Iterator) itr).next();
              if (num1 != 0)
                obj5 = function.call(obj0, obj1, s2, new object[2]
                {
                  obj5,
                  (object) Long.valueOf(num2)
                });
              NativeArray.defineElem(obj0, array, num2, obj5);
              ++num2;
            }
            goto label_22;
          }
          catch (Exception ex)
          {
            exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
          __fault
          {
            if (iteratorLikeIterable != null)
            {
              if (exception1 != null)
              {
                Exception exception3;
                try
                {
                  iteratorLikeIterable.close();
                  goto label_20;
                }
                catch (Exception ex)
                {
                  exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                }
                Exception exception4 = exception3;
                Throwable.instancehelper_addSuppressed(exception1, exception4);
              }
              else
                iteratorLikeIterable.close();
            }
label_20:;
          }
          Exception exception5 = exception2;
          Exception exception6;
          // ISSUE: fault handler
          try
          {
            Exception exception3 = exception5;
            exception6 = exception3;
            throw Throwable.__\u003Cunmap\u003E(exception3);
          }
          __fault
          {
            if (iteratorLikeIterable != null)
            {
              if (exception6 != null)
              {
                Exception exception3;
                try
                {
                  iteratorLikeIterable.close();
                  goto label_35;
                }
                catch (Exception ex)
                {
                  exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                }
                Exception exception4 = exception3;
                Throwable.instancehelper_addSuppressed(exception6, exception4);
              }
              else
                iteratorLikeIterable.close();
            }
label_35:;
          }
label_22:
          if (iteratorLikeIterable != null)
          {
            if (null != null)
            {
              Exception exception3;
              try
              {
                iteratorLikeIterable.close();
                goto label_36;
              }
              catch (Exception ex)
              {
                exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
              }
              Throwable.instancehelper_addSuppressed((Exception) null, exception3);
            }
            else
              iteratorLikeIterable.close();
          }
label_36:
          NativeArray.setLengthProperty(obj0, array, num2);
          return (object) array;
        }
      }
      long lengthProperty = NativeArray.getLengthProperty(obj0, scriptable, false);
      Scriptable array1 = NativeArray.callConstructorOrCreateArray(obj0, obj1, obj2, lengthProperty, true);
      for (long index = 0; index < lengthProperty; ++index)
      {
        object objA = NativeArray.getRawElem(scriptable, index);
        if (!object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
        {
          if (num1 != 0)
            objA = function.call(obj0, obj1, s2, new object[2]
            {
              objA,
              (object) Long.valueOf(index)
            });
          NativeArray.defineElem(obj0, array1, index, objA);
        }
      }
      NativeArray.setLengthProperty(obj0, array1, lengthProperty);
      return (object) array1;
    }

    [LineNumberTable(new byte[] {162, 72, 100, 232, 69, 106, 135, 100, 109, 135, 103, 112, 107, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object jsConstructor([In] Context obj0, [In] Scriptable obj1, [In] object[] obj2)
    {
      if (obj2.Length == 0)
        return (object) new NativeArray(0L);
      if (obj0.getLanguageVersion() == 120)
        return (object) new NativeArray(obj2);
      object val = obj2[0];
      if (obj2.Length > 1 || !(val is Number))
        return (object) new NativeArray(obj2);
      long uint32 = ScriptRuntime.toUint32(val);
      return (double) uint32 == ((Number) val).doubleValue() ? (object) new NativeArray(uint32) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", ScriptRuntime.getMessage0("msg.arraylength.bad")));
    }

    [LineNumberTable(new byte[] {158, 148, 101, 233, 69, 137, 236, 69, 99, 106, 137, 167, 99, 164, 104, 99, 99, 143, 99, 238, 70, 135, 173, 100, 114, 108, 112, 106, 159, 5, 99, 133, 131, 99, 147, 105, 177, 163, 144, 104, 178, 239, 38, 236, 96, 176, 100, 135, 227, 61, 100, 201, 131, 106, 143, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string toStringHelper(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] bool obj3,
      [In] bool obj4)
    {
      int num1 = obj3 ? 1 : 0;
      int num2 = obj4 ? 1 : 0;
      Scriptable scriptable = ScriptRuntime.toObject(obj0, obj1, (object) obj2);
      long lengthProperty = NativeArray.getLengthProperty(obj0, scriptable, false);
      StringBuilder stringBuilder = new StringBuilder(256);
      string str;
      if (num1 != 0)
      {
        stringBuilder.append('[');
        str = ", ";
      }
      else
        str = ",";
      int num3 = 0;
      long num4 = 0;
      int num5;
      int num6;
      if (obj0.iterating == null)
      {
        num5 = 1;
        num6 = 0;
        obj0.iterating = new ObjToIntMap(31);
      }
      else
      {
        num5 = 0;
        num6 = obj0.iterating.has((object) scriptable) ? 1 : 0;
      }
      // ISSUE: fault handler
      try
      {
        if (num6 == 0)
        {
          obj0.iterating.put((object) scriptable, 0);
          int num7 = num1 == 0 || obj0.getLanguageVersion() < 150 ? 1 : 0;
          for (num4 = 0L; num4 < lengthProperty; ++num4)
          {
            if (num4 > 0L)
              stringBuilder.append(str);
            object obj = NativeArray.getRawElem(scriptable, num4);
            if (object.ReferenceEquals(obj, Scriptable.NOT_FOUND) || num7 != 0 && (obj == null || object.ReferenceEquals(obj, Undefined.__\u003C\u003Einstance)))
            {
              num3 = 0;
            }
            else
            {
              num3 = 1;
              if (num1 != 0)
                stringBuilder.append(ScriptRuntime.uneval(obj0, obj1, obj));
              else if (obj is string)
              {
                stringBuilder.append((string) obj);
              }
              else
              {
                if (num2 != 0)
                {
                  Callable propFunctionAndThis = ScriptRuntime.getPropFunctionAndThis(obj, "toLocaleString", obj0, obj1);
                  Scriptable s2 = ScriptRuntime.lastStoredScriptable(obj0);
                  obj = propFunctionAndThis.call(obj0, obj1, s2, ScriptRuntime.__\u003C\u003EemptyArgs);
                }
                stringBuilder.append(ScriptRuntime.toString(obj));
              }
            }
          }
          obj0.iterating.remove((object) scriptable);
        }
      }
      __fault
      {
        if (num5 != 0)
          obj0.iterating = (ObjToIntMap) null;
      }
      if (num5 != 0)
        obj0.iterating = (ObjToIntMap) null;
      if (num1 != 0)
      {
        if (num3 == 0 && num4 > 0L)
          stringBuilder.append(", ]");
        else
          stringBuilder.append(']');
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {163, 216, 137, 105, 99, 101, 102, 37, 203, 158, 102, 107, 104, 108, 103, 107, 100, 137, 108, 108, 159, 1, 239, 56, 235, 76, 168, 99, 134, 104, 99, 104, 108, 114, 105, 108, 231, 59, 232, 72, 111, 105, 104, 100, 137, 103, 132, 234, 57, 232, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string js_join([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3)
    {
      Scriptable scriptable = ScriptRuntime.toObject(obj0, obj1, (object) obj2);
      long lengthProperty = NativeArray.getLengthProperty(obj0, scriptable, false);
      int length = (int) lengthProperty;
      if (lengthProperty != (long) length)
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.arraylength.too.big", (object) String.valueOf(lengthProperty)));
      string str1 = obj3.Length < 1 || object.ReferenceEquals(obj3[0], Undefined.__\u003C\u003Einstance) ? "," : ScriptRuntime.toString(obj3[0]);
      if (scriptable is NativeArray)
      {
        NativeArray nativeArray = (NativeArray) scriptable;
        if (nativeArray.denseOnly)
        {
          StringBuilder stringBuilder = new StringBuilder();
          for (int index = 0; index < length; ++index)
          {
            if (index != 0)
              stringBuilder.append(str1);
            if (index < nativeArray.dense.Length)
            {
              object obj = nativeArray.dense[index];
              if (obj != null && !object.ReferenceEquals(obj, Undefined.__\u003C\u003Einstance) && !object.ReferenceEquals(obj, Scriptable.NOT_FOUND))
                stringBuilder.append(ScriptRuntime.toString(obj));
            }
          }
          return stringBuilder.toString();
        }
      }
      if (length == 0)
        return "";
      string[] strArray = new string[length];
      int num = 0;
      for (int index = 0; index != length; ++index)
      {
        object elem = NativeArray.getElem(obj0, scriptable, (long) index);
        if (elem != null && !object.ReferenceEquals(elem, Undefined.__\u003C\u003Einstance))
        {
          string str2 = ScriptRuntime.toString(elem);
          num += String.instancehelper_length(str2);
          strArray[index] = str2;
        }
      }
      StringBuilder stringBuilder1 = new StringBuilder(num + (length - 1) * String.instancehelper_length(str1));
      for (int index = 0; index != length; ++index)
      {
        if (index != 0)
          stringBuilder1.append(str1);
        string str2 = strArray[index];
        if (str2 != null)
          stringBuilder1.append(str2);
      }
      return stringBuilder1.toString();
    }

    [LineNumberTable(new byte[] {164, 23, 137, 107, 103, 107, 112, 106, 112, 234, 61, 234, 69, 162, 138, 103, 106, 106, 106, 106, 107, 235, 59, 233, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Scriptable js_reverse(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] object[] obj3)
    {
      Scriptable scriptable = ScriptRuntime.toObject(obj0, obj1, (object) obj2);
      if (scriptable is NativeArray)
      {
        NativeArray nativeArray = (NativeArray) scriptable;
        if (nativeArray.denseOnly)
        {
          int index1 = 0;
          for (int index2 = (int) nativeArray.length - 1; index1 < index2; index2 += -1)
          {
            object obj = nativeArray.dense[index1];
            nativeArray.dense[index1] = nativeArray.dense[index2];
            nativeArray.dense[index2] = obj;
            ++index1;
          }
          return scriptable;
        }
      }
      long lengthProperty = NativeArray.getLengthProperty(obj0, scriptable, false);
      long num1 = lengthProperty / 2L;
      for (long index = 0; index < num1; ++index)
      {
        long num2 = lengthProperty - index - 1L;
        object rawElem1 = NativeArray.getRawElem(scriptable, index);
        object rawElem2 = NativeArray.getRawElem(scriptable, num2);
        NativeArray.setRawElem(obj0, scriptable, index, rawElem2);
        NativeArray.setRawElem(obj0, scriptable, num2, rawElem1);
      }
      return scriptable;
    }

    [LineNumberTable(new byte[] {164, 54, 169, 116, 100, 102, 103, 103, 246, 80, 98, 167, 106, 101, 103, 103, 37, 235, 69, 105, 105, 46, 200, 191, 2, 105, 47, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Scriptable js_sort(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] object[] obj3)
    {
      Scriptable scriptable1 = ScriptRuntime.toObject(obj0, obj1, (object) obj2);
      object obj4;
      if (obj3.Length > 0 && !object.ReferenceEquals(Undefined.__\u003C\u003Einstance, obj3[0]))
      {
        Callable valueFunctionAndThis = ScriptRuntime.getValueFunctionAndThis(obj3[0], obj0);
        Scriptable scriptable2 = ScriptRuntime.lastStoredScriptable(obj0);
        obj4 = (object) new NativeArray.ElementComparator((Comparator) new NativeArray.__\u003C\u003EAnon0(new object[2], valueFunctionAndThis, obj0, obj1, scriptable2));
      }
      else
        obj4 = (object) NativeArray.DEFAULT_COMPARATOR;
      long lengthProperty = NativeArray.getLengthProperty(obj0, scriptable1, false);
      int length = (int) lengthProperty;
      object[] objArray = lengthProperty == (long) length ? new object[length] : throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.arraylength.too.big", (object) String.valueOf(lengthProperty)));
      for (int index = 0; index != length; ++index)
        objArray[index] = NativeArray.getRawElem(scriptable1, (long) index);
      Sorting sorting = Sorting.get();
      object[] a = objArray;
      object obj5 = obj4;
      Comparator cmp;
      if (obj5 != null)
        cmp = obj5 is Comparator comparator2 ? comparator2 : throw new IncompatibleClassChangeError();
      else
        cmp = (Comparator) null;
      sorting.hybridSort(a, cmp);
      for (int index = 0; index < length; ++index)
        NativeArray.setRawElem(obj0, scriptable1, (long) index, objArray[index]);
      return scriptable1;
    }

    [LineNumberTable(new byte[] {164, 107, 137, 107, 103, 118, 103, 103, 63, 2, 166, 173, 106, 105, 49, 200, 104, 235, 70, 138, 210})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object js_push([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3)
    {
      Scriptable scriptable = ScriptRuntime.toObject(obj0, obj1, (object) obj2);
      if (scriptable is NativeArray)
      {
        NativeArray nativeArray1 = (NativeArray) scriptable;
        if (nativeArray1.denseOnly && nativeArray1.ensureCapacity((int) nativeArray1.length + obj3.Length))
        {
          for (int index1 = 0; index1 < obj3.Length; ++index1)
          {
            object[] dense = nativeArray1.dense;
            NativeArray nativeArray2 = nativeArray1;
            long length = nativeArray2.length;
            NativeArray nativeArray3 = nativeArray2;
            long num = length;
            nativeArray3.length = length + 1L;
            int index2 = (int) num;
            object obj = obj3[index1];
            dense[index2] = obj;
          }
          return (object) ScriptRuntime.wrapNumber((double) nativeArray1.length);
        }
      }
      long lengthProperty = NativeArray.getLengthProperty(obj0, scriptable, false);
      for (int index = 0; index < obj3.Length; ++index)
        NativeArray.setElem(obj0, scriptable, lengthProperty + (long) index, obj3[index]);
      long num1 = lengthProperty + (long) obj3.Length;
      object obj4 = NativeArray.setLengthProperty(obj0, scriptable, num1);
      if (obj0.getLanguageVersion() != 120)
        return obj4;
      return obj3.Length == 0 ? Undefined.__\u003C\u003Einstance : obj3[obj3.Length - 1];
    }

    [LineNumberTable(new byte[] {164, 142, 169, 104, 103, 114, 111, 111, 115, 162, 105, 101, 165, 201, 137, 198, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object js_pop([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3)
    {
      Scriptable scriptable = ScriptRuntime.toObject(obj0, obj1, (object) obj2);
      if (scriptable is NativeArray)
      {
        NativeArray nativeArray = (NativeArray) scriptable;
        if (nativeArray.denseOnly && nativeArray.length > 0L)
        {
          --nativeArray.length;
          object obj = nativeArray.dense[(int) nativeArray.length];
          nativeArray.dense[(int) nativeArray.length] = Scriptable.NOT_FOUND;
          return obj;
        }
      }
      long lengthProperty = NativeArray.getLengthProperty(obj0, scriptable, false);
      object obj4;
      if (lengthProperty > 0L)
      {
        --lengthProperty;
        obj4 = NativeArray.getElem(obj0, scriptable, lengthProperty);
        NativeArray.deleteElem(scriptable, lengthProperty);
      }
      else
        obj4 = Undefined.__\u003C\u003Einstance;
      NativeArray.setLengthProperty(obj0, scriptable, lengthProperty);
      return obj4;
    }

    [LineNumberTable(new byte[] {164, 175, 137, 107, 103, 120, 111, 105, 122, 115, 214, 105, 104, 100, 165, 235, 70, 101, 105, 106, 14, 233, 71, 103, 98, 135, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object js_shift([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3)
    {
      Scriptable scriptable = ScriptRuntime.toObject(obj0, obj1, (object) obj2);
      if (scriptable is NativeArray)
      {
        NativeArray nativeArray = (NativeArray) scriptable;
        if (nativeArray.denseOnly && nativeArray.length > 0L)
        {
          --nativeArray.length;
          object objA = nativeArray.dense[0];
          ByteCodeHelper.arraycopy((object) nativeArray.dense, 1, (object) nativeArray.dense, 0, (int) nativeArray.length);
          nativeArray.dense[(int) nativeArray.length] = Scriptable.NOT_FOUND;
          return object.ReferenceEquals(objA, Scriptable.NOT_FOUND) ? Undefined.__\u003C\u003Einstance : objA;
        }
      }
      long lengthProperty = NativeArray.getLengthProperty(obj0, scriptable, false);
      object obj;
      if (lengthProperty > 0L)
      {
        long num = 0;
        --lengthProperty;
        obj = NativeArray.getElem(obj0, scriptable, num);
        if (lengthProperty > 0L)
        {
          for (long index = 1; index <= lengthProperty; ++index)
          {
            object rawElem = NativeArray.getRawElem(scriptable, index);
            NativeArray.setRawElem(obj0, scriptable, index - 1L, rawElem);
          }
        }
        NativeArray.deleteElem(scriptable, lengthProperty);
      }
      else
        obj = Undefined.__\u003C\u003Einstance;
      NativeArray.setLengthProperty(obj0, scriptable, lengthProperty);
      return obj;
    }

    [LineNumberTable(new byte[] {164, 217, 137, 107, 103, 115, 103, 155, 112, 112, 173, 105, 131, 136, 101, 108, 106, 14, 233, 71, 105, 46, 232, 69, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object js_unshift(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] object[] obj3)
    {
      Scriptable scriptable = ScriptRuntime.toObject(obj0, obj1, (object) obj2);
      if (scriptable is NativeArray)
      {
        NativeArray nativeArray = (NativeArray) scriptable;
        if (nativeArray.denseOnly && nativeArray.ensureCapacity((int) nativeArray.length + obj3.Length))
        {
          ByteCodeHelper.arraycopy((object) nativeArray.dense, 0, (object) nativeArray.dense, obj3.Length, (int) nativeArray.length);
          ByteCodeHelper.arraycopy((object) obj3, 0, (object) nativeArray.dense, 0, obj3.Length);
          nativeArray.length += (long) obj3.Length;
          return (object) ScriptRuntime.wrapNumber((double) nativeArray.length);
        }
      }
      long lengthProperty = NativeArray.getLengthProperty(obj0, scriptable, false);
      int length = obj3.Length;
      if (obj3.Length > 0)
      {
        if (lengthProperty > 0L)
        {
          for (long index = lengthProperty - 1L; index >= 0L; --index)
          {
            object rawElem = NativeArray.getRawElem(scriptable, index);
            NativeArray.setRawElem(obj0, scriptable, index + (long) length, rawElem);
          }
        }
        for (int index = 0; index < obj3.Length; ++index)
          NativeArray.setElem(obj0, scriptable, (long) index, obj3[index]);
      }
      long num = lengthProperty + (long) obj3.Length;
      return NativeArray.setLengthProperty(obj0, scriptable, num);
    }

    [LineNumberTable(new byte[] {164, 254, 137, 98, 98, 104, 103, 199, 104, 99, 99, 105, 170, 114, 196, 101, 137, 108, 105, 102, 106, 137, 137, 164, 199, 105, 103, 233, 76, 144, 99, 104, 105, 115, 107, 101, 106, 106, 106, 110, 239, 61, 233, 71, 110, 100, 162, 138, 137, 234, 69, 103, 125, 106, 159, 1, 100, 145, 102, 185, 107, 163, 102, 109, 106, 14, 206, 105, 106, 106, 14, 233, 72, 112, 40, 233, 70, 102, 104, 52, 232, 69, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object js_splice([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3)
    {
      Scriptable scriptable1 = ScriptRuntime.toObject(obj0, obj1, (object) obj2);
      NativeArray nativeArray = (NativeArray) null;
      int num1 = 0;
      if (scriptable1 is NativeArray)
      {
        nativeArray = (NativeArray) scriptable1;
        num1 = nativeArray.denseOnly ? 1 : 0;
      }
      obj1 = ScriptableObject.getTopLevelScope(obj1);
      int length1 = obj3.Length;
      if (length1 == 0)
        return (object) obj0.newArray(obj1, 0);
      long lengthProperty = NativeArray.getLengthProperty(obj0, scriptable1, false);
      long sliceIndex = NativeArray.toSliceIndex(ScriptRuntime.toInteger(obj3[0]), lengthProperty);
      int num2 = length1 - 1;
      long num3;
      if (obj3.Length == 1)
      {
        num3 = lengthProperty - sliceIndex;
      }
      else
      {
        double integer = ScriptRuntime.toInteger(obj3[1]);
        num3 = integer >= 0.0 ? (integer <= (double) (lengthProperty - sliceIndex) ? ByteCodeHelper.d2l(integer) : lengthProperty - sliceIndex) : 0L;
        num2 += -1;
      }
      long num4 = sliceIndex + num3;
      object obj;
      switch (num3)
      {
        case 0:
          obj = obj0.getLanguageVersion() != 120 ? (object) obj0.newArray(obj1, 0) : Undefined.__\u003C\u003Einstance;
          break;
        case 1:
          if (obj0.getLanguageVersion() == 120)
          {
            obj = NativeArray.getElem(obj0, scriptable1, sliceIndex);
            break;
          }
          goto default;
        default:
          if (num1 != 0)
          {
            int length2 = (int) (num4 - sliceIndex);
            object[] elements = new object[length2];
            ByteCodeHelper.arraycopy((object) nativeArray.dense, (int) sliceIndex, (object) elements, 0, length2);
            obj = (object) obj0.newArray(obj1, elements);
            break;
          }
          Scriptable scriptable2 = obj0.newArray(obj1, 0);
          for (long index = sliceIndex; index != num4; ++index)
          {
            object rawElem = NativeArray.getRawElem(scriptable1, index);
            if (!object.ReferenceEquals(rawElem, Scriptable.NOT_FOUND))
              NativeArray.setElem(obj0, scriptable2, index - sliceIndex, rawElem);
          }
          NativeArray.setLengthProperty(obj0, scriptable2, num4 - sliceIndex);
          obj = (object) scriptable2;
          break;
      }
      long num5 = (long) num2 - num3;
      if (num1 != 0 && lengthProperty + num5 < (long) int.MaxValue && nativeArray.ensureCapacity((int) (lengthProperty + num5)))
      {
        ByteCodeHelper.arraycopy((object) nativeArray.dense, (int) num4, (object) nativeArray.dense, (int) (sliceIndex + (long) num2), (int) (lengthProperty - num4));
        if (num2 > 0)
          ByteCodeHelper.arraycopy((object) obj3, 2, (object) nativeArray.dense, (int) sliceIndex, num2);
        if (num5 < 0L)
          Arrays.fill(nativeArray.dense, (int) (lengthProperty + num5), (int) lengthProperty, Scriptable.NOT_FOUND);
        nativeArray.length = lengthProperty + num5;
        return obj;
      }
      if (num5 > 0L)
      {
        for (long index = lengthProperty - 1L; index >= num4; --index)
        {
          object rawElem = NativeArray.getRawElem(scriptable1, index);
          NativeArray.setRawElem(obj0, scriptable1, index + num5, rawElem);
        }
      }
      else if (num5 < 0L)
      {
        for (long index = num4; index < lengthProperty; ++index)
        {
          object rawElem = NativeArray.getRawElem(scriptable1, index);
          NativeArray.setRawElem(obj0, scriptable1, index + num5, rawElem);
        }
        for (long index = lengthProperty - 1L; index >= lengthProperty + num5; --index)
          NativeArray.deleteElem(scriptable1, index);
      }
      int num6 = obj3.Length - num2;
      for (int index = 0; index < num2; ++index)
        NativeArray.setElem(obj0, scriptable1, sliceIndex + (long) index, obj3[index + num6]);
      NativeArray.setLengthProperty(obj0, scriptable1, lengthProperty + num5);
      return obj;
    }

    [LineNumberTable(new byte[] {165, 202, 169, 104, 137, 108, 117, 44, 200, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Scriptable js_concat(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] object[] obj3)
    {
      Scriptable scriptable1 = ScriptRuntime.toObject(obj0, obj1, (object) obj2);
      obj1 = ScriptableObject.getTopLevelScope(obj1);
      Scriptable scriptable2 = obj0.newArray(obj1, 0);
      long num = NativeArray.doConcat(obj0, obj1, scriptable2, (object) scriptable1, 0L);
      object[] objArray = obj3;
      int length = objArray.Length;
      for (int index = 0; index < length; ++index)
      {
        object obj = objArray[index];
        num = NativeArray.doConcat(obj0, obj1, scriptable2, obj, num);
      }
      NativeArray.setLengthProperty(obj0, scriptable2, num);
      return scriptable2;
    }

    [LineNumberTable(new byte[] {165, 218, 137, 105, 169, 101, 99, 133, 113, 118, 133, 210, 105, 106, 110, 237, 61, 233, 70, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Scriptable js_slice(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] object[] obj3)
    {
      Scriptable scriptable1 = ScriptRuntime.toObject(obj0, obj1, (object) obj2);
      Scriptable scriptable2 = obj0.newArray(obj1, 0);
      long lengthProperty = NativeArray.getLengthProperty(obj0, scriptable1, false);
      long num1;
      long num2;
      if (obj3.Length == 0)
      {
        num1 = 0L;
        num2 = lengthProperty;
      }
      else
      {
        num1 = NativeArray.toSliceIndex(ScriptRuntime.toInteger(obj3[0]), lengthProperty);
        num2 = obj3.Length == 1 || object.ReferenceEquals(obj3[1], Undefined.__\u003C\u003Einstance) ? lengthProperty : NativeArray.toSliceIndex(ScriptRuntime.toInteger(obj3[1]), lengthProperty);
      }
      for (long index = num1; index < num2; ++index)
      {
        object rawElem = NativeArray.getRawElem(scriptable1, index);
        if (!object.ReferenceEquals(rawElem, Scriptable.NOT_FOUND))
          NativeArray.defineElem(obj0, scriptable2, index - num1, rawElem);
      }
      NativeArray.setLengthProperty(obj0, scriptable2, Math.max(0L, num2 - num1));
      return scriptable2;
    }

    [LineNumberTable(new byte[] {166, 8, 144, 105, 233, 76, 133, 133, 111, 101, 100, 101, 131, 141, 107, 104, 108, 105, 109, 108, 114, 139, 113, 103, 233, 57, 235, 74, 166, 104, 106, 120, 232, 61, 233, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object js_indexOf(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] object[] obj3)
    {
      object y = obj3.Length <= 0 ? Undefined.__\u003C\u003Einstance : obj3[0];
      Scriptable scriptable = ScriptRuntime.toObject(obj0, obj1, (object) obj2);
      long lengthProperty = NativeArray.getLengthProperty(obj0, scriptable, false);
      long num;
      if (obj3.Length < 2)
      {
        num = 0L;
      }
      else
      {
        num = ByteCodeHelper.d2l(ScriptRuntime.toInteger(obj3[1]));
        if (num < 0L)
        {
          num += lengthProperty;
          if (num < 0L)
            num = 0L;
        }
        if (num > lengthProperty - 1L)
          return (object) NativeArray.NEGATIVE_ONE;
      }
      if (scriptable is NativeArray)
      {
        NativeArray nativeArray = (NativeArray) scriptable;
        if (nativeArray.denseOnly)
        {
          Scriptable prototype = nativeArray.getPrototype();
          for (int index = (int) num; (long) index < lengthProperty; ++index)
          {
            object property = nativeArray.dense[index];
            if (object.ReferenceEquals(property, Scriptable.NOT_FOUND) && prototype != null)
              property = ScriptableObject.getProperty(prototype, index);
            if (!object.ReferenceEquals(property, Scriptable.NOT_FOUND) && ScriptRuntime.shallowEq(property, y))
              return (object) Long.valueOf((long) index);
          }
          return (object) NativeArray.NEGATIVE_ONE;
        }
      }
      for (long index = num; index < lengthProperty; ++index)
      {
        object rawElem = NativeArray.getRawElem(scriptable, index);
        if (!object.ReferenceEquals(rawElem, Scriptable.NOT_FOUND) && ScriptRuntime.shallowEq(rawElem, y))
          return (object) Long.valueOf(index);
      }
      return (object) NativeArray.NEGATIVE_ONE;
    }

    [LineNumberTable(new byte[] {166, 62, 144, 105, 233, 77, 133, 135, 111, 100, 103, 101, 100, 139, 107, 104, 108, 105, 108, 108, 114, 139, 113, 103, 233, 57, 235, 74, 166, 105, 106, 120, 232, 61, 233, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object js_lastIndexOf(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] object[] obj3)
    {
      object y = obj3.Length <= 0 ? Undefined.__\u003C\u003Einstance : obj3[0];
      Scriptable scriptable = ScriptRuntime.toObject(obj0, obj1, (object) obj2);
      long lengthProperty = NativeArray.getLengthProperty(obj0, scriptable, false);
      long num;
      if (obj3.Length < 2)
      {
        num = lengthProperty - 1L;
      }
      else
      {
        num = ByteCodeHelper.d2l(ScriptRuntime.toInteger(obj3[1]));
        if (num >= lengthProperty)
          num = lengthProperty - 1L;
        else if (num < 0L)
          num += lengthProperty;
        if (num < 0L)
          return (object) NativeArray.NEGATIVE_ONE;
      }
      if (scriptable is NativeArray)
      {
        NativeArray nativeArray = (NativeArray) scriptable;
        if (nativeArray.denseOnly)
        {
          Scriptable prototype = nativeArray.getPrototype();
          for (int index = (int) num; index >= 0; index += -1)
          {
            object property = nativeArray.dense[index];
            if (object.ReferenceEquals(property, Scriptable.NOT_FOUND) && prototype != null)
              property = ScriptableObject.getProperty(prototype, index);
            if (!object.ReferenceEquals(property, Scriptable.NOT_FOUND) && ScriptRuntime.shallowEq(property, y))
              return (object) Long.valueOf((long) index);
          }
          return (object) NativeArray.NEGATIVE_ONE;
        }
      }
      for (long index = num; index >= 0L; --index)
      {
        object rawElem = NativeArray.getRawElem(scriptable, index);
        if (!object.ReferenceEquals(rawElem, Scriptable.NOT_FOUND) && ScriptRuntime.shallowEq(rawElem, y))
          return (object) Long.valueOf(index);
      }
      return (object) NativeArray.NEGATIVE_ONE;
    }

    [LineNumberTable(new byte[] {166, 119, 144, 105, 123, 171, 101, 133, 111, 101, 100, 101, 131, 141, 107, 104, 108, 105, 109, 108, 114, 139, 110, 135, 106, 230, 55, 235, 76, 166, 100, 105, 110, 135, 106, 230, 58, 231, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Boolean js_includes(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] object[] obj3)
    {
      object y = obj3.Length <= 0 ? Undefined.__\u003C\u003Einstance : obj3[0];
      Scriptable scriptable = ScriptRuntime.toObject(obj0, obj1, (object) obj2);
      long length = ScriptRuntime.toLength(new object[1]
      {
        ScriptableObject.getProperty(obj2, "length")
      }, 0);
      if (length == 0L)
        return (Boolean) Boolean.FALSE;
      long num;
      if (obj3.Length < 2)
      {
        num = 0L;
      }
      else
      {
        num = ByteCodeHelper.d2l(ScriptRuntime.toInteger(obj3[1]));
        if (num < 0L)
        {
          num += length;
          if (num < 0L)
            num = 0L;
        }
        if (num > length - 1L)
          return (Boolean) Boolean.FALSE;
      }
      if (scriptable is NativeArray)
      {
        NativeArray nativeArray = (NativeArray) scriptable;
        if (nativeArray.denseOnly)
        {
          Scriptable prototype = nativeArray.getPrototype();
          for (int index = (int) num; (long) index < length; ++index)
          {
            object obj = nativeArray.dense[index];
            if (object.ReferenceEquals(obj, Scriptable.NOT_FOUND) && prototype != null)
              obj = ScriptableObject.getProperty(prototype, index);
            if (object.ReferenceEquals(obj, Scriptable.NOT_FOUND))
              obj = Undefined.__\u003C\u003Einstance;
            if (ScriptRuntime.sameZero(obj, y))
              return (Boolean) Boolean.TRUE;
          }
          return (Boolean) Boolean.FALSE;
        }
      }
      for (; num < length; ++num)
      {
        object obj = NativeArray.getRawElem(scriptable, num);
        if (object.ReferenceEquals(obj, Scriptable.NOT_FOUND))
          obj = Undefined.__\u003C\u003Einstance;
        if (ScriptRuntime.sameZero(obj, y))
          return (Boolean) Boolean.TRUE;
      }
      return (Boolean) Boolean.FALSE;
    }

    [LineNumberTable(new byte[] {166, 169, 105, 137, 99, 101, 175, 101, 141, 168, 99, 111, 176, 102, 143, 170, 113, 105, 43, 201})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object js_fill([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3)
    {
      Scriptable scriptable = ScriptRuntime.toObject(obj0, obj1, (object) obj2);
      long lengthProperty = NativeArray.getLengthProperty(obj0, scriptable, false);
      long num1 = 0;
      if (obj3.Length >= 2)
        num1 = ByteCodeHelper.d2l(ScriptRuntime.toInteger(obj3[1]));
      long num2 = num1 >= 0L ? Math.min(num1, lengthProperty) : Math.max(lengthProperty + num1, 0L);
      long num3 = lengthProperty;
      if (obj3.Length >= 3 && !Undefined.isUndefined(obj3[2]))
        num3 = ByteCodeHelper.d2l(ScriptRuntime.toInteger(obj3[2]));
      long num4 = num3 >= 0L ? Math.min(num3, lengthProperty) : Math.max(lengthProperty + num3, 0L);
      object obj = obj3.Length <= 0 ? Undefined.__\u003C\u003Einstance : obj3[0];
      for (long index = num2; index < num4; ++index)
        NativeArray.setRawElem(obj0, obj2, index, obj);
      return (object) obj2;
    }

    [LineNumberTable(new byte[] {166, 203, 105, 137, 112, 141, 101, 142, 169, 113, 143, 102, 143, 170, 99, 111, 176, 102, 143, 170, 112, 99, 111, 99, 106, 234, 69, 117, 104, 105, 102, 118, 104, 232, 61, 233, 70, 194, 105, 106, 119, 138, 171, 104, 232, 55, 236, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object js_copyWithin(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] object[] obj3)
    {
      Scriptable scriptable = ScriptRuntime.toObject(obj0, obj1, (object) obj2);
      long lengthProperty = NativeArray.getLengthProperty(obj0, scriptable, false);
      long num1 = ByteCodeHelper.d2l(ScriptRuntime.toInteger(obj3.Length < 1 ? Undefined.__\u003C\u003Einstance : obj3[0]));
      long num2 = num1 >= 0L ? Math.min(num1, lengthProperty) : Math.max(lengthProperty + num1, 0L);
      long num3 = ByteCodeHelper.d2l(ScriptRuntime.toInteger(obj3.Length < 2 ? Undefined.__\u003C\u003Einstance : obj3[1]));
      long num4 = num3 >= 0L ? Math.min(num3, lengthProperty) : Math.max(lengthProperty + num3, 0L);
      long num5 = lengthProperty;
      if (obj3.Length >= 3 && !Undefined.isUndefined(obj3[2]))
        num5 = ByteCodeHelper.d2l(ScriptRuntime.toInteger(obj3[2]));
      long num6 = Math.min((num5 >= 0L ? Math.min(num5, lengthProperty) : Math.max(lengthProperty + num5, 0L)) - num4, lengthProperty - num2);
      int num7 = 1;
      if (num4 < num2 && num2 < num4 + num6)
      {
        num7 = -1;
        num4 = num4 + num6 - 1L;
        num2 = num2 + num6 - 1L;
      }
      if (scriptable is NativeArray && num6 <= (long) int.MaxValue)
      {
        NativeArray nativeArray = (NativeArray) scriptable;
        if (nativeArray.denseOnly)
        {
          for (; num6 > 0L; --num6)
          {
            nativeArray.dense[(int) num2] = nativeArray.dense[(int) num4];
            num4 += (long) num7;
            num2 += (long) num7;
          }
          return (object) obj2;
        }
      }
      for (; num6 > 0L; --num6)
      {
        object rawElem = NativeArray.getRawElem(scriptable, num4);
        if (object.ReferenceEquals(rawElem, Scriptable.NOT_FOUND) || Undefined.isUndefined(rawElem))
          NativeArray.deleteElem(scriptable, num2);
        else
          NativeArray.setElem(obj0, scriptable, num2, rawElem);
        num4 += (long) num7;
        num2 += (long) num7;
      }
      return (object) obj2;
    }

    [LineNumberTable(new byte[] {167, 22, 233, 70, 108, 147, 109, 114, 107, 140, 245, 70, 172, 104, 137, 124, 134, 173, 99, 106, 108, 139, 100, 108, 104, 106, 110, 109, 231, 69, 102, 107, 101, 112, 159, 11, 108, 166, 108, 182, 130, 108, 130, 105, 166, 105, 163, 105, 233, 26, 236, 106, 159, 8, 166, 131, 134, 175})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object iterativeMethod(
      [In] Context obj0,
      [In] IdFunctionObject obj1,
      [In] Scriptable obj2,
      [In] Scriptable obj3,
      [In] object[] obj4)
    {
      Scriptable val1 = ScriptRuntime.toObject(obj0, obj2, (object) obj3);
      int num1 = Math.abs(obj1.methodId());
      if (22 == num1 || 23 == num1)
        val1 = ScriptRuntimeES6.requireObjectCoercible(obj0, val1, obj1);
      long lengthProperty = NativeArray.getLengthProperty(obj0, val1, num1 == 20);
      object obj = obj4.Length <= 0 ? Undefined.__\u003C\u003Einstance : obj4[0];
      if (obj == null || !(obj is Function))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(obj));
      Function function = obj0.getLanguageVersion() < 200 || !(obj is NativeRegExp) ? (Function) obj : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(obj));
      Scriptable topLevelScope = ScriptableObject.getTopLevelScope((Scriptable) function);
      Scriptable s2 = obj4.Length < 2 || obj4[1] == null || object.ReferenceEquals(obj4[1], Undefined.__\u003C\u003Einstance) ? topLevelScope : ScriptRuntime.toObject(obj0, obj2, obj4[1]);
      Scriptable scriptable = (Scriptable) null;
      if (num1 == 18 || num1 == 20)
      {
        int length = num1 != 20 ? 0 : (int) lengthProperty;
        scriptable = obj0.newArray(obj2, length);
      }
      long num2 = 0;
      for (long index = 0; index < lengthProperty; ++index)
      {
        object[] objarr = new object[3];
        object objA = NativeArray.getRawElem(val1, index);
        if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
        {
          if (num1 == 22 || num1 == 23)
            objA = Undefined.__\u003C\u003Einstance;
          else
            continue;
        }
        objarr[0] = objA;
        objarr[1] = (object) Long.valueOf(index);
        objarr[2] = (object) val1;
        object val2 = function.call(obj0, topLevelScope, s2, objarr);
        switch (num1)
        {
          case 17:
            if (!ScriptRuntime.toBoolean(val2))
              return (object) Boolean.FALSE;
            continue;
          case 18:
            if (ScriptRuntime.toBoolean(val2))
            {
              NativeArray.defineElem(obj0, scriptable, num2++, objarr[0]);
              continue;
            }
            continue;
          case 20:
            NativeArray.defineElem(obj0, scriptable, index, val2);
            continue;
          case 21:
            if (ScriptRuntime.toBoolean(val2))
              return (object) Boolean.TRUE;
            continue;
          case 22:
            if (ScriptRuntime.toBoolean(val2))
              return objA;
            continue;
          case 23:
            if (ScriptRuntime.toBoolean(val2))
              return (object) ScriptRuntime.wrapNumber((double) index);
            continue;
          default:
            continue;
        }
      }
      switch (num1)
      {
        case 17:
          return (object) Boolean.TRUE;
        case 18:
        case 20:
          return (object) scriptable;
        case 21:
          return (object) Boolean.FALSE;
        case 23:
          return (object) ScriptRuntime.wrapNumber(-1.0);
        default:
          return Undefined.__\u003C\u003Einstance;
      }
    }

    [LineNumberTable(new byte[] {167, 123, 137, 105, 114, 107, 140, 103, 136, 103, 115, 108, 113, 106, 110, 130, 142, 134, 127, 1, 239, 53, 236, 78, 142, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object reduceMethod(
      [In] Context obj0,
      [In] int obj1,
      [In] Scriptable obj2,
      [In] Scriptable obj3,
      [In] object[] obj4)
    {
      Scriptable scriptable = ScriptRuntime.toObject(obj0, obj2, (object) obj3);
      long lengthProperty = NativeArray.getLengthProperty(obj0, scriptable, false);
      object obj = obj4.Length <= 0 ? Undefined.__\u003C\u003Einstance : obj4[0];
      Function function = obj != null && obj is Function ? (Function) obj : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(obj));
      Scriptable topLevelScope = ScriptableObject.getTopLevelScope((Scriptable) function);
      int num1 = obj1 == 24 ? 1 : 0;
      object objA = obj4.Length <= 1 ? Scriptable.NOT_FOUND : obj4[1];
      for (long index = 0; index < lengthProperty; ++index)
      {
        long num2 = num1 == 0 ? lengthProperty - 1L - index : index;
        object rawElem = NativeArray.getRawElem(scriptable, num2);
        if (!object.ReferenceEquals(rawElem, Scriptable.NOT_FOUND))
        {
          if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
          {
            objA = rawElem;
          }
          else
          {
            object[] objarr = new object[4]
            {
              objA,
              rawElem,
              (object) Long.valueOf(num2),
              (object) scriptable
            };
            objA = function.call(obj0, topLevelScope, topLevelScope, objarr);
          }
        }
      }
      return !object.ReferenceEquals(objA, Scriptable.NOT_FOUND) ? objA : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.empty.array.reduce"));
    }

    [LineNumberTable(new byte[] {161, 119, 173, 110, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long toArrayIndex([In] string obj0)
    {
      long arrayIndex = NativeArray.toArrayIndex(ScriptRuntime.toNumber(obj0));
      return String.instancehelper_equals(Long.toString(arrayIndex), (object) obj0) ? arrayIndex : -1L;
    }

    [LineNumberTable(new byte[] {161, 129, 105, 104, 111, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long toArrayIndex([In] double obj0)
    {
      if (!Double.isNaN(obj0))
      {
        long uint32 = ScriptRuntime.toUint32(obj0);
        if ((double) uint32 == obj0 && uint32 != (long) uint.MaxValue)
          return uint32;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {161, 108, 104, 108, 104, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long toArrayIndex([In] object obj0)
    {
      switch (obj0)
      {
        case string _:
          return NativeArray.toArrayIndex((string) obj0);
        case Number _:
          return NativeArray.toArrayIndex(((Number) obj0).doubleValue());
        default:
          return -1;
      }
    }

    [LineNumberTable(new byte[] {161, 157, 106, 104, 103, 130, 127, 1, 103, 117, 148, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool ensureCapacity([In] int obj0)
    {
      if (obj0 > this.dense.Length)
      {
        if (obj0 > 1431655764)
        {
          this.denseOnly = false;
          return false;
        }
        obj0 = Math.max(obj0, ByteCodeHelper.d2i((double) this.dense.Length * 1.5));
        object[] objArray = new object[obj0];
        ByteCodeHelper.arraycopy((object) this.dense, 0, (object) objArray, 0, this.dense.Length);
        Arrays.fill(objArray, this.dense.Length, objArray.Length, Scriptable.NOT_FOUND);
        this.dense = objArray;
      }
      return true;
    }

    [LineNumberTable(new byte[] {161, 139, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int toDenseIndex([In] object obj0)
    {
      long arrayIndex = NativeArray.toArrayIndex(obj0);
      return 0L <= arrayIndex && arrayIndex < (long) int.MaxValue ? (int) arrayIndex : -1;
    }

    [LineNumberTable(new byte[] {162, 14, 103, 106, 102, 127, 2, 109, 114, 114, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ScriptableObject defaultIndexPropertyDescriptor([In] object obj0)
    {
      object obj1 = (object) this.getParentScope();
      if ((Scriptable) obj1 == null)
        obj1 = (object) this;
      NativeObject nativeObject1 = new NativeObject();
      NativeObject nativeObject2 = nativeObject1;
      object obj2 = obj1;
      TopLevel.Builtins builtins = TopLevel.Builtins.__\u003C\u003EObject;
      Scriptable scope;
      if (obj2 != null)
        scope = obj2 is Scriptable scriptable2 ? scriptable2 : throw new IncompatibleClassChangeError();
      else
        scope = (Scriptable) null;
      TopLevel.Builtins type = builtins;
      ScriptRuntime.setBuiltinProtoAndParent((ScriptableObject) nativeObject2, scope, type);
      nativeObject1.defineProperty("value", obj0, 0);
      nativeObject1.defineProperty("writable", (object) Boolean.valueOf(true), 0);
      nativeObject1.defineProperty("enumerable", (object) Boolean.valueOf(true), 0);
      nativeObject1.defineProperty("configurable", (object) Boolean.valueOf(true), 0);
      return (ScriptableObject) nativeObject1;
    }

    [LineNumberTable(new byte[] {161, 174, 127, 22, 106, 114, 97, 106, 105, 106, 107, 97, 127, 4, 103, 105, 107, 129, 167, 105, 147, 138, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void put(int index, Scriptable start, object value)
    {
      if (object.ReferenceEquals((object) start, (object) this) && !this.isSealed() && (this.dense != null && 0 <= index) && (this.denseOnly || !this.isGetterOrSetter((string) null, index, true)))
      {
        if (!this.isExtensible() && this.length <= (long) index)
          return;
        if (index < this.dense.Length)
        {
          this.dense[index] = value;
          if (this.length > (long) index)
            return;
          this.length = (long) index + 1L;
          return;
        }
        if (this.denseOnly && (double) index < (double) this.dense.Length * 1.5 && this.ensureCapacity(index + 1))
        {
          this.dense[index] = value;
          this.length = (long) index + 1L;
          return;
        }
        this.denseOnly = false;
      }
      base.put(index, start, value);
      if (!object.ReferenceEquals((object) start, (object) this) || (this.lengthAttr & 1) != 0 || this.length > (long) index)
        return;
      this.length = (long) index + 1L;
    }

    [LineNumberTable(new byte[] {158, 218, 99, 130, 139, 113, 110, 255, 2, 71, 226, 58, 98, 115, 232, 71, 131, 182})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Scriptable callConstructorOrCreateArray(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] long obj3,
      [In] bool obj4)
    {
      int num = obj4 ? 1 : 0;
      Scriptable scriptable = (Scriptable) null;
      if (obj2 is Function)
      {
        EcmaError ecmaError1;
        try
        {
          object[] objArray;
          if (num != 0 || obj3 > 0L)
            objArray = new object[1]
            {
              (object) Long.valueOf(obj3)
            };
          else
            objArray = ScriptRuntime.__\u003C\u003EemptyArgs;
          object[] objarr = objArray;
          scriptable = ((Function) obj2).construct(obj0, obj1, objarr);
          goto label_8;
        }
        catch (EcmaError ex)
        {
          ecmaError1 = (EcmaError) ByteCodeHelper.MapException<EcmaError>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        EcmaError ecmaError2 = ecmaError1;
        if (!String.instancehelper_equals("TypeError", (object) ecmaError2.getName()))
          throw Throwable.__\u003Cunmap\u003E((Exception) ecmaError2);
      }
label_8:
      if (scriptable == null)
        scriptable = obj0.newArray(obj1, obj3 <= (long) int.MaxValue ? (int) obj3 : 0);
      return scriptable;
    }

    [LineNumberTable(new byte[] {163, 88, 105, 103, 105, 98, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void defineElem([In] Context obj0, [In] Scriptable obj1, [In] long obj2, [In] object obj3)
    {
      if (obj2 > (long) int.MaxValue)
      {
        string str = Long.toString(obj2);
        obj1.put(str, obj1, obj3);
      }
      else
        obj1.put((int) obj2, obj1, obj3);
    }

    [LineNumberTable(new byte[] {163, 54, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object setLengthProperty([In] Context obj0, [In] Scriptable obj1, [In] long obj2)
    {
      Number number = ScriptRuntime.wrapNumber((double) obj2);
      ScriptableObject.putProperty(obj1, "length", (object) number);
      return (object) number;
    }

    [LineNumberTable(new byte[] {158, 172, 162, 104, 141, 104, 172, 108, 141, 163, 105, 108, 99, 107, 145, 135, 104, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static long getLengthProperty([In] Context obj0, [In] Scriptable obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      switch (obj1)
      {
        case NativeString _:
          return (long) ((NativeString) obj1).getLength();
        case NativeArray _:
          return ((NativeArray) obj1).getLength();
        default:
          object property = ScriptableObject.getProperty(obj1, "length");
          if (object.ReferenceEquals(property, Scriptable.NOT_FOUND))
            return 0;
          double number = ScriptRuntime.toNumber(property);
          if (number > 9.00719925474099E+15)
          {
            if (num != 0)
              throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", ScriptRuntime.getMessage0("msg.arraylength.bad")));
            return (long) int.MaxValue;
          }
          return number < 0.0 ? 0L : ScriptRuntime.toUint32(property);
      }
    }

    [LineNumberTable(new byte[] {163, 80, 105, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object getRawElem([In] Scriptable obj0, [In] long obj1) => obj1 > (long) int.MaxValue ? ScriptableObject.getProperty(obj0, Long.toString(obj1)) : ScriptableObject.getProperty(obj0, (int) obj1);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getLength() => this.length;

    [LineNumberTable(new byte[] {161, 204, 119, 122, 143, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void delete(int index)
    {
      if (this.dense != null && 0 <= index && (index < this.dense.Length && !this.isSealed()) && (this.denseOnly || !this.isGetterOrSetter((string) null, index, true)))
        this.dense[index] = Scriptable.NOT_FOUND;
      else
        base.delete(index);
    }

    [LineNumberTable(new byte[] {163, 65, 99, 101, 137, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void deleteElem([In] Scriptable obj0, [In] long obj1)
    {
      int i = (int) obj1;
      if ((long) i == obj1)
        obj0.delete(i);
      else
        obj0.delete(Long.toString(obj1));
    }

    [LineNumberTable(new byte[] {163, 98, 105, 103, 104, 98, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void setElem([In] Context obj0, [In] Scriptable obj1, [In] long obj2, [In] object obj3)
    {
      if (obj2 > (long) int.MaxValue)
      {
        string name = Long.toString(obj2);
        ScriptableObject.putProperty(obj1, name, obj3);
      }
      else
        ScriptableObject.putProperty(obj1, (int) obj2, obj3);
    }

    [LineNumberTable(new byte[] {163, 74, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object getElem([In] Context obj0, [In] Scriptable obj1, [In] long obj2)
    {
      object rawElem = NativeArray.getRawElem(obj1, obj2);
      return !object.ReferenceEquals(rawElem, Scriptable.NOT_FOUND) ? rawElem : Undefined.__\u003C\u003Einstance;
    }

    [LineNumberTable(new byte[] {163, 109, 109, 137, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void setRawElem([In] Context obj0, [In] Scriptable obj1, [In] long obj2, [In] object obj3)
    {
      if (object.ReferenceEquals(obj3, Scriptable.NOT_FOUND))
        NativeArray.deleteElem(obj1, obj2);
      else
        NativeArray.setElem(obj0, obj1, obj2, obj3);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long toSliceIndex([In] double obj0, [In] long obj1) => obj0 >= 0.0 ? (obj0 <= (double) obj1 ? ByteCodeHelper.d2l(obj0) : obj1) : (obj0 + (double) obj1 >= 0.0 ? ByteCodeHelper.d2l(obj0 + (double) obj1) : 0L);

    [LineNumberTable(new byte[] {165, 130, 104, 107, 102, 181, 199, 173, 109, 106, 226, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isConcatSpreadable([In] Context obj0, [In] Scriptable obj1, [In] object obj2)
    {
      if (obj2 is Scriptable)
      {
        object property = ScriptableObject.getProperty((Scriptable) obj2, (Symbol) SymbolKey.__\u003C\u003EIS_CONCAT_SPREADABLE);
        if (!object.ReferenceEquals(property, Scriptable.NOT_FOUND) && !Undefined.isUndefined(property))
          return ScriptRuntime.toBoolean(property);
      }
      if (obj0.getLanguageVersion() < 200)
      {
        Function existingCtor = ScriptRuntime.getExistingCtor(obj0, obj1, "Array");
        if (ScriptRuntime.instanceOf(obj2, (object) existingCtor, obj0))
          return true;
      }
      return NativeArray.js_isArray(obj2);
    }

    [LineNumberTable(new byte[] {165, 157, 105, 164, 113, 103, 112, 103, 136, 105, 118, 226, 73, 99, 105, 106, 110, 235, 61, 240, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long concatSpreadArg([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] long obj3)
    {
      long lengthProperty = NativeArray.getLengthProperty(obj0, obj2, false);
      long num1 = lengthProperty + obj3;
      if (num1 <= (long) int.MaxValue && obj1 is NativeArray)
      {
        NativeArray nativeArray1 = (NativeArray) obj1;
        if (nativeArray1.denseOnly && obj2 is NativeArray)
        {
          NativeArray nativeArray2 = (NativeArray) obj2;
          if (nativeArray2.denseOnly)
          {
            nativeArray1.ensureCapacity((int) num1);
            ByteCodeHelper.arraycopy((object) nativeArray2.dense, 0, (object) nativeArray1.dense, (int) obj3, (int) lengthProperty);
            return num1;
          }
        }
      }
      long num2 = obj3;
      long num3 = 0;
      while (num3 < lengthProperty)
      {
        object rawElem = NativeArray.getRawElem(obj2, num3);
        if (!object.ReferenceEquals(rawElem, Scriptable.NOT_FOUND))
          NativeArray.defineElem(obj0, obj1, num2, rawElem);
        ++num3;
        ++num2;
      }
      return num1;
    }

    [LineNumberTable(new byte[] {165, 190, 106, 144, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long doConcat(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] object obj3,
      [In] long obj4)
    {
      if (NativeArray.isConcatSpreadable(obj0, obj1, obj3))
        return NativeArray.concatSpreadArg(obj0, obj2, (Scriptable) obj3, obj4);
      NativeArray.defineElem(obj0, obj2, obj4, obj3);
      return obj4 + 1L;
    }

    [LineNumberTable(new byte[] {167, 234, 103, 105, 139, 99, 99, 102, 105, 2, 232, 70, 102, 111, 2, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int indexOf(object o)
    {
      long length = this.length;
      if (length > (long) int.MaxValue)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      int num = (int) length;
      if (o == null)
      {
        for (int index = 0; index < num; ++index)
        {
          if (this.get(index) == null)
            return index;
        }
      }
      else
      {
        for (int index = 0; index < num; ++index)
        {
          if (Object.instancehelper_equals(o, this.get(index)))
            return index;
        }
      }
      return -1;
    }

    [LineNumberTable(new byte[] {167, 177, 103, 105, 139, 99, 137, 123, 102, 42, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] toArray(object[] a)
    {
      long length = this.length;
      if (length > (long) int.MaxValue)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      int num = (int) length;
      object[] objArray = a.Length < num ? (object[]) Array.newInstance(Object.instancehelper_getClass((object) a).getComponentType(), num) : a;
      for (int index = 0; index < num; ++index)
        objArray[index] = this.get(index);
      return objArray;
    }

    [LineNumberTable(2073)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(object o) => this.indexOf(o) > -1;

    [LineNumberTable(new byte[] {167, 214, 110, 139, 104, 122, 98, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(long index)
    {
      if (index < 0L || index >= this.length)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException();
      }
      object rawElem = NativeArray.getRawElem((Scriptable) this, index);
      if (object.ReferenceEquals(rawElem, Scriptable.NOT_FOUND) || object.ReferenceEquals(rawElem, Undefined.__\u003C\u003Einstance))
        return (object) null;
      return rawElem is Wrapper ? ((Wrapper) rawElem).unwrap() : rawElem;
    }

    [LineNumberTable(new byte[] {168, 34, 103, 105, 139, 131, 104, 191, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ListIterator listIterator(int start)
    {
      long length = this.length;
      if (length > (long) int.MaxValue)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      int num = (int) length;
      if (start < 0 || start > num)
      {
        string str = new StringBuilder().append("Index: ").append(start).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      return (ListIterator) new NativeArray.\u0031(this, start, num);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {164, 65, 101, 101, 140, 105, 108, 100, 98, 100, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024js_sort\u00240(
      [In] object[] obj0,
      [In] Callable obj1,
      [In] Context obj2,
      [In] Scriptable obj3,
      [In] Scriptable obj4,
      [In] object obj5,
      [In] object obj6)
    {
      obj0[0] = obj5;
      obj0[1] = obj6;
      int num = Double.compare(ScriptRuntime.toNumber(obj1.call(obj2, obj3, obj4, obj0)), 0.0);
      if (num < 0)
        return -1;
      return num > 0 ? 1 : 0;
    }

    [LineNumberTable(new byte[] {159, 135, 162, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      new NativeArray(0L).exportAsJSClass(32, obj0, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int getMaximumInitialCapacity() => NativeArray.maximumInitialCapacity;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void setMaximumInitialCapacity([In] int obj0) => NativeArray.maximumInitialCapacity = obj0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Array";

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int getMaxInstanceId() => 1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setInstanceIdAttributes(int id, int attr)
    {
      if (id != 1)
        return;
      this.lengthAttr = attr;
    }

    [LineNumberTable(new byte[] {34, 109, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findInstanceIdInfo(string s) => String.instancehelper_equals(s, (object) "length") ? IdScriptableObject.instanceIdInfo(this.lengthAttr, 1) : base.findInstanceIdInfo(s);

    [LineNumberTable(new byte[] {42, 100, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override string getInstanceIdName(int id) => id == 1 ? "length" : base.getInstanceIdName(id);

    [LineNumberTable(new byte[] {50, 100, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object getInstanceIdValue(int id) => id == 1 ? (object) ScriptRuntime.wrapNumber((double) this.length) : base.getInstanceIdValue(id);

    [LineNumberTable(new byte[] {58, 100, 103, 129, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setInstanceIdValue(int id, object value)
    {
      if (id == 1)
        this.setLength(value);
      else
        base.setInstanceIdValue(id, value);
    }

    [LineNumberTable(new byte[] {67, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void fillConstructorProperties(IdFunctionObject ctor)
    {
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -5, "join", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -6, "reverse", 0);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -7, "sort", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -8, "push", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -9, "pop", 0);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -10, "shift", 0);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -11, "unshift", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -12, "splice", 2);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -13, "concat", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -14, "slice", 2);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -15, "indexOf", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -16, "lastIndexOf", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -17, "every", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -18, "filter", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -19, "forEach", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -20, "map", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -21, "some", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -22, "find", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -23, "findIndex", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -24, "reduce", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -25, "reduceRight", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -26, "isArray", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -27, "of", 0);
      this.addIdFunctionProperty((Scriptable) ctor, NativeArray.ARRAY_TAG, -28, "from", 1);
      base.fillConstructorProperties(ctor);
    }

    [LineNumberTable(new byte[] {120, 101, 120, 161, 130, 159, 106, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 177, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      if (id == 32)
      {
        this.initPrototypeMethod(NativeArray.ARRAY_TAG, id, (Symbol) SymbolKey.__\u003C\u003EITERATOR, "[Symbol.iterator]", 0);
      }
      else
      {
        int arity;
        string propertyName;
        switch (id - 1)
        {
          case 0:
            arity = 1;
            propertyName = "constructor";
            break;
          case 1:
            arity = 0;
            propertyName = "toString";
            break;
          case 2:
            arity = 0;
            propertyName = "toLocaleString";
            break;
          case 3:
            arity = 0;
            propertyName = "toSource";
            break;
          case 4:
            arity = 1;
            propertyName = "join";
            break;
          case 5:
            arity = 0;
            propertyName = "reverse";
            break;
          case 6:
            arity = 1;
            propertyName = "sort";
            break;
          case 7:
            arity = 1;
            propertyName = "push";
            break;
          case 8:
            arity = 0;
            propertyName = "pop";
            break;
          case 9:
            arity = 0;
            propertyName = "shift";
            break;
          case 10:
            arity = 1;
            propertyName = "unshift";
            break;
          case 11:
            arity = 2;
            propertyName = "splice";
            break;
          case 12:
            arity = 1;
            propertyName = "concat";
            break;
          case 13:
            arity = 2;
            propertyName = "slice";
            break;
          case 14:
            arity = 1;
            propertyName = "indexOf";
            break;
          case 15:
            arity = 1;
            propertyName = "lastIndexOf";
            break;
          case 16:
            arity = 1;
            propertyName = "every";
            break;
          case 17:
            arity = 1;
            propertyName = "filter";
            break;
          case 18:
            arity = 1;
            propertyName = "forEach";
            break;
          case 19:
            arity = 1;
            propertyName = "map";
            break;
          case 20:
            arity = 1;
            propertyName = "some";
            break;
          case 21:
            arity = 1;
            propertyName = "find";
            break;
          case 22:
            arity = 1;
            propertyName = "findIndex";
            break;
          case 23:
            arity = 1;
            propertyName = "reduce";
            break;
          case 24:
            arity = 1;
            propertyName = "reduceRight";
            break;
          case 25:
            arity = 1;
            propertyName = "fill";
            break;
          case 26:
            arity = 0;
            propertyName = "keys";
            break;
          case 27:
            arity = 0;
            propertyName = "values";
            break;
          case 28:
            arity = 0;
            propertyName = "entries";
            break;
          case 29:
            arity = 1;
            propertyName = "includes";
            break;
          case 30:
            arity = 2;
            propertyName = "copyWithin";
            break;
          default:
            string str = String.valueOf(id);
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str);
        }
        this.initPrototypeMethod(NativeArray.ARRAY_TAG, id, propertyName, (string) null, arity);
      }
    }

    [LineNumberTable(new byte[] {160, 198, 109, 142, 167, 255, 160, 163, 91, 102, 109, 107, 113, 131, 99, 197, 187, 204, 204, 105, 131, 139, 202, 102, 38, 198, 172, 172, 172, 172, 172, 172, 172, 172, 172, 172, 172, 173, 172, 172, 172, 172, 236, 73, 173, 173, 107, 179, 107, 211, 107, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag(NativeArray.ARRAY_TAG))
        return base.execIdCall(f, cx, scope, thisObj, args);
      int num = f.methodId();
      while (true)
      {
        switch (num)
        {
          case -28:
            goto label_11;
          case -27:
            goto label_10;
          case -26:
            goto label_9;
          case -25:
          case -24:
          case -23:
          case -22:
          case -21:
          case -20:
          case -19:
          case -18:
          case -17:
          case -16:
          case -15:
          case -14:
          case -13:
          case -12:
          case -11:
          case -10:
          case -9:
          case -8:
          case -7:
          case -6:
          case -5:
            if (args.Length > 0)
            {
              thisObj = ScriptRuntime.toObject(cx, scope, args[0]);
              object[] objArray = new object[args.Length - 1];
              if (objArray.Length >= 0)
                ByteCodeHelper.arraycopy((object) args, 1, (object) objArray, 0, objArray.Length);
              args = objArray;
            }
            num = -num;
            continue;
          case 1:
            goto label_12;
          case 2:
            goto label_15;
          case 3:
            goto label_16;
          case 4:
            goto label_17;
          case 5:
            goto label_18;
          case 6:
            goto label_19;
          case 7:
            goto label_20;
          case 8:
            goto label_21;
          case 9:
            goto label_22;
          case 10:
            goto label_23;
          case 11:
            goto label_24;
          case 12:
            goto label_25;
          case 13:
            goto label_26;
          case 14:
            goto label_27;
          case 15:
            goto label_28;
          case 16:
            goto label_29;
          case 17:
          case 18:
          case 19:
          case 20:
          case 21:
          case 22:
          case 23:
            goto label_33;
          case 24:
          case 25:
            goto label_34;
          case 26:
            goto label_31;
          case 27:
            goto label_35;
          case 28:
          case 32:
            goto label_37;
          case 29:
            goto label_36;
          case 30:
            goto label_30;
          case 31:
            goto label_32;
          default:
            goto label_38;
        }
      }
label_9:
      return (object) Boolean.valueOf(args.Length > 0 && NativeArray.js_isArray(args[0]));
label_10:
      return NativeArray.js_of(cx, scope, thisObj, args);
label_11:
      return NativeArray.js_from(cx, scope, thisObj, args);
label_12:
      return (thisObj != null ? 0 : 1) == 0 ? (object) f.construct(cx, scope, args) : NativeArray.jsConstructor(cx, scope, args);
label_15:
      return (object) NativeArray.toStringHelper(cx, scope, thisObj, cx.hasFeature(4), false);
label_16:
      return (object) NativeArray.toStringHelper(cx, scope, thisObj, false, true);
label_17:
      return (object) NativeArray.toStringHelper(cx, scope, thisObj, true, false);
label_18:
      return (object) NativeArray.js_join(cx, scope, thisObj, args);
label_19:
      return (object) NativeArray.js_reverse(cx, scope, thisObj, args);
label_20:
      return (object) NativeArray.js_sort(cx, scope, thisObj, args);
label_21:
      return NativeArray.js_push(cx, scope, thisObj, args);
label_22:
      return NativeArray.js_pop(cx, scope, thisObj, args);
label_23:
      return NativeArray.js_shift(cx, scope, thisObj, args);
label_24:
      return NativeArray.js_unshift(cx, scope, thisObj, args);
label_25:
      return NativeArray.js_splice(cx, scope, thisObj, args);
label_26:
      return (object) NativeArray.js_concat(cx, scope, thisObj, args);
label_27:
      return (object) this.js_slice(cx, scope, thisObj, args);
label_28:
      return NativeArray.js_indexOf(cx, scope, thisObj, args);
label_29:
      return NativeArray.js_lastIndexOf(cx, scope, thisObj, args);
label_30:
      return (object) NativeArray.js_includes(cx, scope, thisObj, args);
label_31:
      return NativeArray.js_fill(cx, scope, thisObj, args);
label_32:
      return NativeArray.js_copyWithin(cx, scope, thisObj, args);
label_33:
      return NativeArray.iterativeMethod(cx, f, scope, thisObj, args);
label_34:
      return NativeArray.reduceMethod(cx, num, scope, thisObj, args);
label_35:
      thisObj = ScriptRuntime.toObject(cx, scope, (object) thisObj);
      NativeArrayIterator.__\u003Cclinit\u003E();
      return (object) new NativeArrayIterator(scope, thisObj, NativeArrayIterator.ARRAY_ITERATOR_TYPE.__\u003C\u003EKEYS);
label_36:
      thisObj = ScriptRuntime.toObject(cx, scope, (object) thisObj);
      NativeArrayIterator.__\u003Cclinit\u003E();
      return (object) new NativeArrayIterator(scope, thisObj, NativeArrayIterator.ARRAY_ITERATOR_TYPE.__\u003C\u003EENTRIES);
label_37:
      thisObj = ScriptRuntime.toObject(cx, scope, (object) thisObj);
      NativeArrayIterator.__\u003Cclinit\u003E();
      return (object) new NativeArrayIterator(scope, thisObj, NativeArrayIterator.ARRAY_ITERATOR_TYPE.__\u003C\u003EVALUES);
label_38:
      string str = new StringBuilder().append("Array.prototype has no method: ").append(f.getFunctionName()).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str);
    }

    [LineNumberTable(new byte[] {161, 91, 115, 105, 118, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object get(int index, Scriptable start)
    {
      if (!this.denseOnly && this.isGetterOrSetter((string) null, index, false))
        return base.get(index, start);
      return this.dense != null && 0 <= index && index < this.dense.Length ? this.dense[index] : base.get(index, start);
    }

    [LineNumberTable(new byte[] {161, 100, 115, 105, 118, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool has(int index, Scriptable start)
    {
      if (!this.denseOnly && this.isGetterOrSetter((string) null, index, false))
        return base.has(index, start);
      if (this.dense == null || 0 > index || index >= this.dense.Length)
        return base.has(index, start);
      return !object.ReferenceEquals(this.dense[index], Scriptable.NOT_FOUND);
    }

    [LineNumberTable(new byte[] {161, 145, 105, 137, 103, 105, 106, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void put(string id, Scriptable start, object value)
    {
      base.put(id, start, value);
      if (!object.ReferenceEquals((object) start, (object) this))
        return;
      long arrayIndex = NativeArray.toArrayIndex(id);
      if (arrayIndex < this.length)
        return;
      this.length = arrayIndex + 1L;
      this.denseOnly = false;
    }

    [LineNumberTable(new byte[] {158, 252, 68, 105, 104, 130, 104, 104, 102, 132, 99, 130, 100, 139, 99, 136, 117, 108, 230, 60, 232, 71, 133, 108, 109, 132, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object[] getIds(bool nonEnumerable, bool getSymbols)
    {
      object[] ids = base.getIds(nonEnumerable, getSymbols);
      if (this.dense == null)
        return ids;
      int num = this.dense.Length;
      long length1 = this.length;
      if ((long) num > length1)
        num = (int) length1;
      if (num == 0)
        return ids;
      int length2 = ids.Length;
      object[] objArray1 = new object[num + length2];
      int index1 = 0;
      for (int index2 = 0; index2 != num; ++index2)
      {
        if (!object.ReferenceEquals(this.dense[index2], Scriptable.NOT_FOUND))
        {
          objArray1[index1] = (object) Integer.valueOf(index2);
          ++index1;
        }
      }
      if (index1 != num)
      {
        object[] objArray2 = new object[index1 + length2];
        ByteCodeHelper.arraycopy((object) objArray1, 0, (object) objArray2, 0, index1);
        objArray1 = objArray2;
      }
      ByteCodeHelper.arraycopy((object) ids, 0, (object) objArray1, index1, length2);
      return objArray1;
    }

    [Signature("()Ljava/util/List<Ljava/lang/Integer;>;")]
    [LineNumberTable(new byte[] {161, 248, 103, 109, 115, 105, 123, 238, 61, 232, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getIndexIds()
    {
      object[] ids = this.getIds();
      ArrayList.__\u003Cclinit\u003E();
      ArrayList arrayList = new ArrayList(ids.Length);
      object[] objArray = ids;
      int length = objArray.Length;
      for (int index = 0; index < length; ++index)
      {
        object val = objArray[index];
        int int32 = ScriptRuntime.toInt32(val);
        if (int32 >= 0 && String.instancehelper_equals(ScriptRuntime.toString((double) int32), (object) ScriptRuntime.toString(val)))
          ((List) arrayList).add((object) Integer.valueOf(int32));
      }
      return (List) arrayList;
    }

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {162, 5, 109, 102, 106, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object getDefaultValue(Class hint) => object.ReferenceEquals((object) hint, (object) ScriptRuntime.__\u003C\u003ENumberClass) && Context.getContext().getLanguageVersion() == 120 ? (object) Long.valueOf(this.length) : base.getDefaultValue(hint);

    [LineNumberTable(new byte[] {162, 27, 159, 11, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getAttributes(int index) => this.dense != null && index >= 0 && (index < this.dense.Length && !object.ReferenceEquals(this.dense[index], Scriptable.NOT_FOUND)) ? 0 : base.getAttributes(index);

    [LineNumberTable(new byte[] {162, 36, 104, 103, 127, 3, 105, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override ScriptableObject getOwnPropertyDescriptor(
      Context cx,
      object id)
    {
      if (this.dense != null)
      {
        int denseIndex = NativeArray.toDenseIndex(id);
        if (0 <= denseIndex && denseIndex < this.dense.Length && !object.ReferenceEquals(this.dense[denseIndex], Scriptable.NOT_FOUND))
          return this.defaultIndexPropertyDescriptor(this.dense[denseIndex]);
      }
      return base.getOwnPropertyDescriptor(cx, id);
    }

    [LineNumberTable(new byte[] {158, 229, 67, 104, 103, 103, 103, 103, 111, 11, 230, 70, 103, 105, 138, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void defineOwnProperty(
      Context cx,
      object id,
      ScriptableObject desc,
      bool checkValid)
    {
      int num = checkValid ? 1 : 0;
      if (this.dense != null)
      {
        object[] dense = this.dense;
        this.dense = (object[]) null;
        this.denseOnly = false;
        for (int index = 0; index < dense.Length; ++index)
        {
          if (!object.ReferenceEquals(dense[index], Scriptable.NOT_FOUND))
            this.put(index, (Scriptable) this, dense[index]);
        }
      }
      long arrayIndex = NativeArray.toArrayIndex(id);
      if (arrayIndex >= this.length)
        this.length = arrayIndex + 1L;
      base.defineOwnProperty(cx, id, desc, num != 0);
    }

    [Obsolete]
    [LineNumberTable(819)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long jsGet_length() => this.getLength();

    [LineNumberTable(new byte[] {158, 190, 66, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setDenseOnly([In] bool obj0)
    {
      int num = obj0 ? 1 : 0;
      if (num != 0 && !this.denseOnly)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      this.denseOnly = num != 0;
    }

    [LineNumberTable(2078)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] toArray() => this.toArray(ScriptRuntime.__\u003C\u003EemptyArgs);

    [LineNumberTable(new byte[] {167, 193, 118, 105, 34, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsAll(Collection c)
    {
      Iterator iterator = c.iterator();
      while (iterator.hasNext())
      {
        if (!this.contains(iterator.next()))
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {167, 201, 103, 105, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int size()
    {
      long length = this.length;
      if (length > (long) int.MaxValue)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      return (int) length;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isEmpty() => this.length == 0L;

    [LineNumberTable(new byte[] {168, 1, 103, 105, 139, 99, 99, 104, 105, 2, 232, 70, 104, 111, 2, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int lastIndexOf(object o)
    {
      long length = this.length;
      if (length > (long) int.MaxValue)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      int num = (int) length;
      if (o == null)
      {
        for (int index = num - 1; index >= 0; index += -1)
        {
          if (this.get(index) == null)
            return index;
        }
      }
      else
      {
        for (int index = num - 1; index >= 0; index += -1)
        {
          if (Object.instancehelper_equals(o, this.get(index)))
            return index;
        }
      }
      return -1;
    }

    [LineNumberTable(2186)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator() => (Iterator) this.listIterator(0);

    [LineNumberTable(2191)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ListIterator listIterator() => this.listIterator(0);

    [LineNumberTable(2265)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool add(object o)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(2270)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool remove(object o)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(2275)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addAll(Collection c)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(2280)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeAll(Collection c)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(2285)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool retainAll(Collection c)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(2290)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(2295)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(int index, object element)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(2300)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addAll(int index, Collection c)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(2305)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object set(int index, object element)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(2310)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object remove(int index)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(2315)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List subList(int fromIndex, int toIndex)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(new byte[] {168, 158, 109, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(Symbol k) => SymbolKey.__\u003C\u003EITERATOR.equals((object) k) ? 32 : 0;

    [LineNumberTable(new byte[] {168, 228, 98, 162, 159, 35, 104, 101, 124, 99, 133, 104, 124, 99, 229, 69, 159, 57, 102, 98, 133, 102, 99, 133, 102, 99, 133, 102, 99, 133, 102, 98, 133, 102, 98, 133, 102, 99, 133, 133, 104, 101, 102, 104, 101, 102, 104, 104, 102, 200, 159, 19, 102, 99, 133, 102, 99, 133, 102, 99, 133, 102, 99, 133, 102, 99, 133, 133, 159, 19, 102, 99, 133, 102, 99, 133, 102, 99, 133, 102, 98, 133, 102, 99, 133, 133, 104, 101, 102, 104, 101, 102, 103, 104, 102, 199, 102, 99, 133, 102, 99, 130, 104, 101, 102, 100, 101, 102, 101, 101, 102, 197, 102, 162, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 3:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'm':
              if (String.instancehelper_charAt(s, 2) == 'p' && String.instancehelper_charAt(s, 1) == 'a')
              {
                num = 20;
                break;
              }
              goto label_41;
            case 'p':
              if (String.instancehelper_charAt(s, 2) == 'p' && String.instancehelper_charAt(s, 1) == 'o')
              {
                num = 9;
                break;
              }
              goto label_41;
            default:
              goto label_41;
          }
          break;
        case 4:
          switch (String.instancehelper_charAt(s, 2))
          {
            case 'i':
              str = "join";
              num = 5;
              goto label_41;
            case 'l':
              str = "fill";
              num = 26;
              goto label_41;
            case 'm':
              str = "some";
              num = 21;
              goto label_41;
            case 'n':
              str = "find";
              num = 22;
              goto label_41;
            case 'r':
              str = "sort";
              num = 7;
              goto label_41;
            case 's':
              str = "push";
              num = 8;
              goto label_41;
            case 'y':
              str = "keys";
              num = 27;
              goto label_41;
            default:
              goto label_41;
          }
        case 5:
          switch (String.instancehelper_charAt(s, 1))
          {
            case 'h':
              str = "shift";
              num = 10;
              goto label_41;
            case 'l':
              str = "slice";
              num = 14;
              goto label_41;
            case 'v':
              str = "every";
              num = 17;
              goto label_41;
            default:
              goto label_41;
          }
        case 6:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'c':
              str = "concat";
              num = 13;
              goto label_41;
            case 'f':
              str = "filter";
              num = 18;
              goto label_41;
            case 'r':
              str = "reduce";
              num = 24;
              goto label_41;
            case 's':
              str = "splice";
              num = 12;
              goto label_41;
            case 'v':
              str = "values";
              num = 28;
              goto label_41;
            default:
              goto label_41;
          }
        case 7:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'e':
              str = "entries";
              num = 29;
              goto label_41;
            case 'f':
              str = "forEach";
              num = 19;
              goto label_41;
            case 'i':
              str = "indexOf";
              num = 15;
              goto label_41;
            case 'r':
              str = "reverse";
              num = 6;
              goto label_41;
            case 'u':
              str = "unshift";
              num = 11;
              goto label_41;
            default:
              goto label_41;
          }
        case 8:
          switch (String.instancehelper_charAt(s, 3))
          {
            case 'l':
              str = "includes";
              num = 30;
              goto label_41;
            case 'o':
              str = "toSource";
              num = 4;
              goto label_41;
            case 't':
              str = "toString";
              num = 2;
              goto label_41;
            default:
              goto label_41;
          }
        case 9:
          str = "findIndex";
          num = 23;
          goto default;
        case 10:
          str = "copyWithin";
          num = 31;
          goto default;
        case 11:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'c':
              str = "constructor";
              num = 1;
              goto label_41;
            case 'l':
              str = "lastIndexOf";
              num = 16;
              goto label_41;
            case 'r':
              str = "reduceRight";
              num = 25;
              goto label_41;
            default:
              goto label_41;
          }
        case 14:
          str = "toLocaleString";
          num = 3;
          goto default;
        default:
label_41:
          if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
          {
            num = 0;
            break;
          }
          break;
      }
      return num;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Comparator access\u0024000() => NativeArray.STRING_COMPARATOR;

    [LineNumberTable(new byte[] {159, 136, 178, 106, 236, 168, 252, 106, 234, 161, 50})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeArray()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeArray"))
        return;
      NativeArray.ARRAY_TAG = (object) "Array";
      NativeArray.NEGATIVE_ONE = Long.valueOf(-1L);
      NativeArray.STRING_COMPARATOR = (Comparator) new NativeArray.StringLikeComparator();
      NativeArray.DEFAULT_COMPARATOR = (Comparator) new NativeArray.ElementComparator();
      NativeArray.maximumInitialCapacity = 10000;
    }

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => List.\u003Cdefault\u003Espliterator((List) this);

    [HideFromJava]
    public virtual bool removeIf([In] Predicate obj0) => Collection.\u003Cdefault\u003EremoveIf((Collection) this, obj0);

    [HideFromJava]
    public virtual Stream stream() => Collection.\u003Cdefault\u003Estream((Collection) this);

    [HideFromJava]
    public virtual Stream parallelStream() => Collection.\u003Cdefault\u003EparallelStream((Collection) this);

    [HideFromJava]
    public virtual void replaceAll([In] UnaryOperator obj0) => List.\u003Cdefault\u003EreplaceAll((List) this, obj0);

    [HideFromJava]
    public virtual void sort([In] Comparator obj0) => List.\u003Cdefault\u003Esort((List) this, obj0);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    bool List.__\u003Coverridestub\u003Ejava\u002Eutil\u002EList\u003A\u003Aequals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

    int List.__\u003Coverridestub\u003Ejava\u002Eutil\u002EList\u003A\u003AhashCode() => Object.instancehelper_hashCode((object) this);

    bool Collection.__\u003Coverridestub\u003Ejava\u002Eutil\u002ECollection\u003A\u003Aequals(
      [In] object obj0)
    {
      return Object.instancehelper_equals((object) this, obj0);
    }

    int Collection.__\u003Coverridestub\u003Ejava\u002Eutil\u002ECollection\u003A\u003AhashCode() => Object.instancehelper_hashCode((object) this);

    [EnclosingMethod(null, "listIterator", "(I)Ljava.util.ListIterator;")]
    [Implements(new string[] {"java.util.ListIterator"})]
    [SpecialName]
    internal class \u0031 : Object, ListIterator, Iterator
    {
      internal int cursor;
      [Modifiers]
      internal int val\u0024start;
      [Modifiers]
      internal int val\u0024len;
      [Modifiers]
      internal NativeArray this\u00240;

      [LineNumberTable(new byte[] {168, 44, 157})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] NativeArray obj0, [In] int obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024start = obj1;
        this.val\u0024len = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        NativeArray.\u0031 obj = this;
        this.cursor = this.val\u0024start;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasNext() => this.cursor < this.val\u0024len;

      [LineNumberTable(new byte[] {168, 55, 110, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object next()
      {
        if (this.cursor == this.val\u0024len)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new NoSuchElementException();
        }
        NativeArray this0 = this.this\u00240;
        NativeArray.\u0031 obj1 = this;
        int cursor = obj1.cursor;
        NativeArray.\u0031 obj2 = obj1;
        int index = cursor;
        obj2.cursor = cursor + 1;
        return this0.get(index);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasPrevious() => this.cursor > 0;

      [LineNumberTable(new byte[] {168, 68, 104, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object previous()
      {
        if (this.cursor == 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new NoSuchElementException();
        }
        NativeArray this0 = this.this\u00240;
        NativeArray.\u0031 obj1 = this;
        int num = obj1.cursor - 1;
        NativeArray.\u0031 obj2 = obj1;
        int index = num;
        obj2.cursor = num;
        return this0.get(index);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int nextIndex() => this.cursor;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int previousIndex() => this.cursor - 1;

      [LineNumberTable(2248)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove()
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException();
      }

      [LineNumberTable(2253)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void add([In] object obj0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException();
      }

      [LineNumberTable(2258)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void set([In] object obj0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException();
      }

      [HideFromJava]
      public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);
    }

    [Signature("Ljava/lang/Object;Ljava/util/Comparator<Ljava/lang/Object;>;")]
    public sealed class ElementComparator : Object, Comparator
    {
      [Modifiers]
      [Signature("Ljava/util/Comparator<Ljava/lang/Object;>;")]
      private Comparator child;

      [Signature("(Ljava/util/Comparator<Ljava/lang/Object;>;)V")]
      [LineNumberTable(new byte[] {168, 189, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ElementComparator(Comparator c)
      {
        NativeArray.ElementComparator elementComparator = this;
        this.child = c;
      }

      [LineNumberTable(new byte[] {168, 185, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ElementComparator()
      {
        NativeArray.ElementComparator elementComparator = this;
        this.child = NativeArray.access\u0024000();
      }

      [LineNumberTable(new byte[] {168, 197, 109, 109, 130, 109, 130, 98, 109, 178, 109, 130, 109, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int compare(object x, object y)
      {
        if (object.ReferenceEquals(x, Undefined.__\u003C\u003Einstance))
        {
          if (object.ReferenceEquals(y, Undefined.__\u003C\u003Einstance))
            return 0;
          return object.ReferenceEquals(y, Scriptable.NOT_FOUND) ? -1 : 1;
        }
        return object.ReferenceEquals(x, Scriptable.NOT_FOUND) ? (object.ReferenceEquals(y, Scriptable.NOT_FOUND) ? 0 : 1) : (object.ReferenceEquals(y, Scriptable.NOT_FOUND) || object.ReferenceEquals(y, Undefined.__\u003C\u003Einstance) ? -1 : this.child.compare(x, y));
      }

      [HideFromJava]
      public virtual Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [HideFromJava]
      public virtual Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [HideFromJava]
      public virtual Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [HideFromJava]
      public virtual Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [HideFromJava]
      public virtual Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [HideFromJava]
      public virtual Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [HideFromJava]
      public virtual Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);

      bool Comparator.__\u003Coverridestub\u003Ejava\u002Eutil\u002EComparator\u003A\u003Aequals(
        [In] object obj0)
      {
        return Object.instancehelper_equals((object) this, obj0);
      }
    }

    [Signature("Ljava/lang/Object;Ljava/util/Comparator<Ljava/lang/Object;>;")]
    public sealed class StringLikeComparator : Object, Comparator
    {
      [LineNumberTable(2331)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public StringLikeComparator()
      {
      }

      [LineNumberTable(new byte[] {168, 174, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int compare(object x, object y) => String.instancehelper_compareTo(ScriptRuntime.toString(x), ScriptRuntime.toString(y));

      [HideFromJava]
      public virtual Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [HideFromJava]
      public virtual Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [HideFromJava]
      public virtual Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [HideFromJava]
      public virtual Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [HideFromJava]
      public virtual Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [HideFromJava]
      public virtual Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [HideFromJava]
      public virtual Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);

      bool Comparator.__\u003Coverridestub\u003Ejava\u002Eutil\u002EComparator\u003A\u003Aequals(
        [In] object obj0)
      {
        return Object.instancehelper_equals((object) this, obj0);
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Comparator
    {
      private readonly object[] arg\u00241;
      private readonly Callable arg\u00242;
      private readonly Context arg\u00243;
      private readonly Scriptable arg\u00244;
      private readonly Scriptable arg\u00245;

      internal __\u003C\u003EAnon0(
        [In] object[] obj0,
        [In] Callable obj1,
        [In] Context obj2,
        [In] Scriptable obj3,
        [In] Scriptable obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public int compare([In] object obj0, [In] object obj1) => NativeArray.lambda\u0024js_sort\u00240(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, obj0, obj1);

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
