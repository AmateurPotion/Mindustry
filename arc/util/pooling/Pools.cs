// Decompiled with JetBrains decompiler
// Type: arc.util.pooling.Pools
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util.pooling
{
  public class Pools : Object
  {
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Class;Larc/util/pooling/Pool;>;")]
    private static ObjectMap typePools;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Larc/func/Prov<TT;>;)TT;")]
    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object obtain(Class type, Prov supplier)
    {
      lock ((object) ClassLiteral<Pools>.Value)
        return Pools.get(type, supplier).obtain();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 128, 76, 115, 118, 101, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void free(object @object)
    {
      lock ((object) ClassLiteral<Pools>.Value)
      {
        if (@object == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("Object cannot be null.");
        }
        ((Pool) Pools.typePools.get((object) Object.instancehelper_getClass(@object)))?.free(@object);
      }
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Larc/func/Prov<TT;>;)Larc/util/pooling/Pool<TT;>;")]
    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pool get(Class type, Prov supplier) => Pools.get(type, supplier, 5000);

    [LineNumberTable(new byte[] {17, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void freeAll(Seq objects) => Pools.freeAll(objects, false);

    [LineNumberTable(new byte[] {159, 124, 162, 115, 98, 109, 105, 102, 99, 119, 133, 104, 229, 56, 233, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void freeAll(Seq objects, bool samePool)
    {
      int num = samePool ? 1 : 0;
      if (objects == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Objects cannot be null.");
      }
      Pool pool = (Pool) null;
      int index = 0;
      for (int size = objects.size; index < size; ++index)
      {
        object @object = objects.get(index);
        if (@object != null)
        {
          if (pool == null)
          {
            pool = (Pool) Pools.typePools.get((object) Object.instancehelper_getClass(@object));
            if (pool == null)
              continue;
          }
          pool.free(@object);
          if (num == 0)
            pool = (Pool) null;
        }
      }
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Larc/func/Prov<TT;>;I)Larc/util/pooling/Pool<TT;>;")]
    [LineNumberTable(new byte[] {159, 165, 113, 99, 233, 70, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pool get(Class type, Prov supplier, int max)
    {
      Pool pool = (Pool) Pools.typePools.get((object) type);
      if (pool == null)
      {
        pool = (Pool) new Pools.\u0031(4, max, supplier);
        Pools.typePools.put((object) type, (object) (Pools.\u0031) pool);
      }
      return pool;
    }

    [LineNumberTable(new byte[] {159, 157, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Pools()
    {
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Larc/util/pooling/Pool<TT;>;)V")]
    [LineNumberTable(new byte[] {159, 188, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void set(Class type, Pool pool) => Pools.typePools.put((object) type, (object) pool);

    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Pools()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.pooling.Pools"))
        return;
      Pools.typePools = new ObjectMap();
    }

    [InnerClass]
    [Signature("Larc/util/pooling/Pool<TT;>;")]
    [EnclosingMethod(null, "get", "(Ljava.lang.Class;Larc.func.Prov;I)Larc.util.pooling.Pool;")]
    [SpecialName]
    internal class \u0031 : Pool
    {
      [Modifiers]
      internal Prov val\u0024supplier;

      [LineNumberTable(25)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] int obj0, [In] int obj1, [In] Prov obj2)
      {
        this.val\u0024supplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj0, obj1);
      }

      [Signature("()TT;")]
      [LineNumberTable(28)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override object newObject() => this.val\u0024supplier.get();
    }
  }
}
