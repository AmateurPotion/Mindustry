// Decompiled with JetBrains decompiler
// Type: rhino.EqualObjectGraphs
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.function;
using rhino.debug;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [NonNestedInnerClass("rhino.EqualObjectGraphs$Func")]
  internal sealed class EqualObjectGraphs : Object
  {
    [Modifiers]
    [Signature("Ljava/lang/ThreadLocal<Lrhino/EqualObjectGraphs;>;")]
    private static ThreadLocal instance;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/Object;Ljava/lang/Object;>;")]
    private Map knownEquals;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/Object;Ljava/lang/Object;>;")]
    private Map currentlyCompared;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {5, 105, 98, 102, 162, 109, 233, 73, 98, 163, 162, 109, 137, 98, 131, 162, 109, 123, 131, 162, 110, 105, 99, 110, 142, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool equalGraphs([In] object obj0, [In] object obj1)
    {
      if (object.ReferenceEquals(obj0, obj1))
        return true;
      if (obj0 == null || obj1 == null)
        return false;
      object objA1 = this.currentlyCompared.get(obj0);
      if (object.ReferenceEquals(objA1, obj1))
        return true;
      if (objA1 != null)
        return false;
      object objA2 = this.knownEquals.get(obj0);
      if (object.ReferenceEquals(objA2, obj1))
        return true;
      if (objA2 != null)
        return false;
      object objA3 = this.knownEquals.get(obj1);
      if (!EqualObjectGraphs.\u0024assertionsDisabled && object.ReferenceEquals(objA3, obj0))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      if (objA3 != null)
        return false;
      this.currentlyCompared.put(obj0, obj1);
      int num = this.equalGraphsNoMemo(obj0, obj1) ? 1 : 0;
      if (num != 0)
      {
        this.knownEquals.put(obj0, obj1);
        this.knownEquals.put(obj1, obj0);
      }
      this.currentlyCompared.remove(obj0);
      return num != 0;
    }

    [LineNumberTable(new byte[] {159, 169, 232, 69, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal EqualObjectGraphs()
    {
      EqualObjectGraphs equalObjectGraphs = this;
      this.knownEquals = (Map) new IdentityHashMap();
      this.currentlyCompared = (Map) new IdentityHashMap();
    }

    [LineNumberTable(new byte[] {55, 104, 127, 12, 104, 127, 2, 104, 114, 104, 114, 104, 127, 12, 104, 127, 12, 109, 104, 104, 127, 2, 104, 127, 2, 104, 127, 2, 104, 106, 104, 106, 104, 202})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool equalGraphsNoMemo([In] object obj0, [In] object obj1)
    {
      switch (obj0)
      {
        case Wrapper _:
          return obj1 is Wrapper && this.equalGraphs(((Wrapper) obj0).unwrap(), ((Wrapper) obj1).unwrap());
        case Scriptable _:
          return obj1 is Scriptable && this.equalScriptables((Scriptable) obj0, (Scriptable) obj1);
        case ConsString _:
          return String.instancehelper_equals(((ConsString) obj0).toString(), obj1);
        default:
          if (obj1 is ConsString)
            return Object.instancehelper_equals(obj0, (object) ((ConsString) obj1).toString());
          if (obj0 is SymbolKey)
            return obj1 is SymbolKey && this.equalGraphs((object) ((SymbolKey) obj0).getName(), (object) ((SymbolKey) obj1).getName());
          if (obj0 is object[])
            return obj1 is object[] && this.equalObjectArrays((object[]) obj0, (object[]) obj1);
          if (Object.instancehelper_getClass(obj0).isArray())
            return Objects.deepEquals(obj0, obj1);
          switch (obj0)
          {
            case List _:
              return obj1 is List && this.equalLists((List) obj0, (List) obj1);
            case Map _:
              return obj1 is Map && this.equalMaps((Map) obj0, (Map) obj1);
            case Set _:
              return obj1 is Set && this.equalSets((Set) obj0, (Set) obj1);
            case NativeGlobal _:
              return obj1 is NativeGlobal;
            case JavaAdapter _:
              return obj1 is JavaAdapter;
            case NativeJavaTopPackage _:
              return obj1 is NativeJavaTopPackage;
            default:
              return Object.instancehelper_equals(obj0, obj1);
          }
      }
    }

    [LineNumberTable(new byte[] {88, 103, 103, 106, 130, 99, 102, 122, 2, 230, 69, 116, 98, 116, 194, 104, 127, 1, 104, 104, 104, 127, 2, 104, 127, 1, 104, 127, 2, 104, 127, 2, 104, 159, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool equalScriptables([In] Scriptable obj0, [In] Scriptable obj1)
    {
      object[] sortedIds1 = EqualObjectGraphs.getSortedIds(obj0);
      object[] sortedIds2 = EqualObjectGraphs.getSortedIds(obj1);
      if (!this.equalObjectArrays(sortedIds1, sortedIds2))
        return false;
      int length = sortedIds1.Length;
      for (int index = 0; index < length; ++index)
      {
        if (!this.equalGraphs(EqualObjectGraphs.getValue(obj0, sortedIds1[index]), EqualObjectGraphs.getValue(obj1, sortedIds2[index])))
          return false;
      }
      if (!this.equalGraphs((object) obj0.getPrototype(), (object) obj1.getPrototype()) || !this.equalGraphs((object) obj0.getParentScope(), (object) obj1.getParentScope()))
        return false;
      switch (obj0)
      {
        case NativeContinuation _:
          return obj1 is NativeContinuation && NativeContinuation.equalImplementations((NativeContinuation) obj0, (NativeContinuation) obj1);
        case NativeJavaPackage _:
          return Object.instancehelper_equals((object) obj0, (object) obj1);
        case IdFunctionObject _:
          return obj1 is IdFunctionObject && IdFunctionObject.equalObjectGraphs((IdFunctionObject) obj0, (IdFunctionObject) obj1, this);
        case InterpretedFunction _:
          return obj1 is InterpretedFunction && EqualObjectGraphs.equalInterpretedFunctions((InterpretedFunction) obj0, (InterpretedFunction) obj1);
        case ArrowFunction _:
          return obj1 is ArrowFunction && ArrowFunction.equalObjectGraphs((ArrowFunction) obj0, (ArrowFunction) obj1, this);
        case BoundFunction _:
          return obj1 is BoundFunction && BoundFunction.equalObjectGraphs((BoundFunction) obj0, (BoundFunction) obj1, this);
        case NativeSymbol _:
          return obj1 is NativeSymbol && this.equalGraphs((object) ((NativeSymbol) obj0).getKey(), (object) ((NativeSymbol) obj1).getKey());
        default:
          return true;
      }
    }

    [LineNumberTable(new byte[] {125, 102, 130, 103, 110, 2, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool equalObjectArrays([In] object[] obj0, [In] object[] obj1)
    {
      if (obj0.Length != obj1.Length)
        return false;
      for (int index = 0; index < obj0.Length; ++index)
      {
        if (!this.equalGraphs(obj0[index], obj1[index]))
          return false;
      }
      return true;
    }

    [Signature("(Ljava/util/List<*>;Ljava/util/List<*>;)Z")]
    [LineNumberTable(new byte[] {160, 73, 110, 130, 103, 103, 112, 116, 162, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool equalLists([In] List obj0, [In] List obj1)
    {
      if (obj0.size() != obj1.size())
        return false;
      Iterator iterator1 = obj0.iterator();
      Iterator iterator2 = obj1.iterator();
      while (iterator1.hasNext() && iterator2.hasNext())
      {
        if (!this.equalGraphs(iterator1.next(), iterator2.next()))
          return false;
      }
      if (!EqualObjectGraphs.\u0024assertionsDisabled && (iterator1.hasNext() || iterator2.hasNext()))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      return true;
    }

    [Signature("(Ljava/util/Map<**>;Ljava/util/Map<**>;)Z")]
    [LineNumberTable(new byte[] {160, 89, 110, 130, 103, 135, 112, 108, 108, 127, 9, 130, 98, 159, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool equalMaps([In] Map obj0, [In] Map obj1)
    {
      if (obj0.size() != obj1.size())
        return false;
      Iterator iterator1 = EqualObjectGraphs.sortedEntries(obj0);
      Iterator iterator2 = EqualObjectGraphs.sortedEntries(obj1);
      while (iterator1.hasNext() && iterator2.hasNext())
      {
        Map.Entry entry1 = (Map.Entry) iterator1.next();
        Map.Entry entry2 = (Map.Entry) iterator2.next();
        if (!this.equalGraphs(entry1.getKey(), entry2.getKey()) || !this.equalGraphs(entry1.getValue(), entry2.getValue()))
          return false;
      }
      if (!EqualObjectGraphs.\u0024assertionsDisabled && (iterator1.hasNext() || iterator2.hasNext()))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      return true;
    }

    [Signature("(Ljava/util/Set<*>;Ljava/util/Set<*>;)Z")]
    [LineNumberTable(231)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool equalSets([In] Set obj0, [In] Set obj1) => this.equalObjectArrays(EqualObjectGraphs.sortedSet(obj0), EqualObjectGraphs.sortedSet(obj1));

    [LineNumberTable(new byte[] {160, 132, 103, 240, 92})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object[] getSortedIds([In] Scriptable obj0)
    {
      object[] ids = EqualObjectGraphs.getIds(obj0);
      Arrays.sort(ids, (Comparator) new EqualObjectGraphs.__\u003C\u003EAnon0());
      return ids;
    }

    [LineNumberTable(new byte[] {160, 187, 104, 109, 104, 114, 104, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object getValue([In] Scriptable obj0, [In] object obj1)
    {
      switch (obj1)
      {
        case Symbol _:
          return ScriptableObject.getProperty(obj0, (Symbol) obj1);
        case Integer _:
          return ScriptableObject.getProperty(obj0, ((Integer) obj1).intValue());
        case string _:
          return ScriptableObject.getProperty(obj0, (string) obj1);
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ClassCastException();
      }
    }

    [LineNumberTable(241)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool equalInterpretedFunctions(
      [In] InterpretedFunction obj0,
      [In] InterpretedFunction obj1)
    {
      return Objects.equals((object) obj0.getEncodedSource(), (object) obj1.getEncodedSource());
    }

    [Signature("(Ljava/util/Map;)Ljava/util/Iterator<Ljava/util/Map$Entry;>;")]
    [LineNumberTable(new byte[] {160, 112, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Iterator sortedEntries([In] Map obj0)
    {
      object obj = !(obj0 is SortedMap) ? (object) new TreeMap(obj0) : (object) (TreeMap) obj0;
      Map map1;
      if (obj != null)
        map1 = obj is Map map3 ? map3 : throw new IncompatibleClassChangeError();
      else
        map1 = (Map) null;
      return map1.entrySet().iterator();
    }

    [Signature("(Ljava/util/Set<*>;)[Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {160, 121, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object[] sortedSet([In] Set obj0)
    {
      object[] array = obj0.toArray();
      Arrays.sort(array);
      return array;
    }

    [LineNumberTable(new byte[] {160, 176, 136, 110, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object[] getIds([In] Scriptable obj0)
    {
      switch (obj0)
      {
        case ScriptableObject _:
          return ((ScriptableObject) obj0).getIds(true, true);
        case DebuggableObject _:
          return ((DebuggableObject) obj0).getAllIds();
        default:
          return obj0.getIds();
      }
    }

    [LineNumberTable(new byte[] {160, 165, 104, 108, 104, 177})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string getSymbolName([In] Symbol obj0)
    {
      switch (obj0)
      {
        case SymbolKey _:
          return ((SymbolKey) obj0).getName();
        case NativeSymbol _:
          return ((NativeSymbol) obj0).getKey().getName();
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ClassCastException();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 134, 104, 104, 114, 115, 130, 104, 104, 114, 104, 98, 104, 130, 104, 200, 124, 112, 194})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024getSortedIds\u00240([In] object obj0, [In] object obj1)
    {
      switch (obj0)
      {
        case Integer _:
          switch (obj1)
          {
            case Integer _:
              return ((Integer) obj0).compareTo((Integer) obj1);
            case string _:
            case Symbol _:
              return -1;
          }
          break;
        case string _:
          switch (obj1)
          {
            case string _:
              return String.instancehelper_compareTo((string) obj0, (string) obj1);
            case Integer _:
              return 1;
            case Symbol _:
              return -1;
          }
          break;
        case Symbol _:
          switch (obj1)
          {
            case Symbol _:
              return String.instancehelper_compareTo(EqualObjectGraphs.getSymbolName((Symbol) obj0), EqualObjectGraphs.getSymbolName((Symbol) obj1));
            case Integer _:
            case string _:
              return 1;
          }
          break;
      }
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ClassCastException();
    }

    [Signature("<T:Ljava/lang/Object;>(Lrhino/EqualObjectGraphs$Func<Lrhino/EqualObjectGraphs;TT;>;)TT;")]
    [LineNumberTable(new byte[] {159, 179, 112, 99, 102, 139, 140, 107, 35, 2, 226, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object withThreadLocal([In] EqualObjectGraphs\u0024Func obj0)
    {
      EqualObjectGraphs equalObjectGraphs1 = (EqualObjectGraphs) EqualObjectGraphs.instance.get();
      if (equalObjectGraphs1 != null)
        return obj0.apply((object) equalObjectGraphs1);
      EqualObjectGraphs equalObjectGraphs2 = new EqualObjectGraphs();
      EqualObjectGraphs.instance.set((object) equalObjectGraphs2);
      try
      {
        return obj0.apply((object) equalObjectGraphs2);
      }
      finally
      {
        EqualObjectGraphs.instance.set((object) null);
      }
    }

    [LineNumberTable(new byte[] {159, 136, 173, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static EqualObjectGraphs()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.EqualObjectGraphs"))
        return;
      EqualObjectGraphs.\u0024assertionsDisabled = !((Class) ClassLiteral<EqualObjectGraphs>.Value).desiredAssertionStatus();
      EqualObjectGraphs.instance = new ThreadLocal();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Comparator
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public int compare([In] object obj0, [In] object obj1) => EqualObjectGraphs.lambda\u0024getSortedIds\u00240(obj0, obj1);

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
