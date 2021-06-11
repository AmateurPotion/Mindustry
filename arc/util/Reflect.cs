// Decompiled with JetBrains decompiler
// Type: arc.util.Reflect
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  public class Reflect : Object
  {
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [Signature("(Ljava/lang/Class<*>;)Z")]
    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isWrapper(Class type) => object.ReferenceEquals((object) type, (object) ClassLiteral<Byte>.Value) || object.ReferenceEquals((object) type, (object) ClassLiteral<Short>.Value) || (object.ReferenceEquals((object) type, (object) ClassLiteral<Integer>.Value) || object.ReferenceEquals((object) type, (object) ClassLiteral<Long>.Value)) || (object.ReferenceEquals((object) type, (object) ClassLiteral<Character>.Value) || object.ReferenceEquals((object) type, (object) ClassLiteral<Boolean>.Value) || (object.ReferenceEquals((object) type, (object) ClassLiteral<Float>.Value) || object.ReferenceEquals((object) type, (object) ClassLiteral<Double>.Value)));

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/reflect/Field;)TT;")]
    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object get(Field field) => Reflect.get((object) null, field);

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Object;Ljava/lang/reflect/Field;)TT;")]
    [LineNumberTable(new byte[] {159, 178, 127, 8, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object get(object @object, Field field)
    {
      object obj;
      Exception exception1;
      try
      {
        obj = field.get(@object, Reflect.__\u003CGetCallerID\u003E());
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_5;
        }
      }
      return obj;
label_5:
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) exception2);
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<*>;Ljava/lang/Object;Ljava/lang/String;)TT;")]
    [LineNumberTable(new byte[] {159, 186, 109, 103, 127, 8, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object get(Class type, object @object, string name)
    {
      object obj;
      Exception exception1;
      try
      {
        Field declaredField = type.getDeclaredField(name, Reflect.__\u003CGetCallerID\u003E());
        ((AccessibleObject) declaredField).setAccessible(true);
        obj = declaredField.get(@object, Reflect.__\u003CGetCallerID\u003E());
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_5;
        }
      }
      return obj;
label_5:
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) exception2);
    }

    [Signature("(Ljava/lang/Class<*>;Ljava/lang/Object;Ljava/lang/String;Ljava/lang/Object;)V")]
    [LineNumberTable(new byte[] {12, 109, 103, 191, 5, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void set(Class type, object @object, string name, object value)
    {
      Exception exception1;
      try
      {
        Field declaredField = type.getDeclaredField(name, Reflect.__\u003CGetCallerID\u003E());
        ((AccessibleObject) declaredField).setAccessible(true);
        declaredField.set(@object, value, Reflect.__\u003CGetCallerID\u003E());
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) exception2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 162, 127, 13, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object lambda\u0024cons\u00240([In] Constructor obj0)
    {
      object obj;
      Exception exception1;
      try
      {
        obj = obj0.newInstance(new object[0], Reflect.__\u003CGetCallerID\u003E());
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_5;
        }
      }
      return obj;
label_5:
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) exception2);
    }

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Reflect()
    {
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;)Larc/func/Prov<TT;>;")]
    [LineNumberTable(new byte[] {159, 158, 114, 103, 255, 7, 71, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Prov cons(Class type)
    {
      Prov prov;
      Exception exception1;
      try
      {
        Constructor declaredConstructor = type.getDeclaredConstructor(new Class[0], Reflect.__\u003CGetCallerID\u003E());
        ((AccessibleObject) declaredConstructor).setAccessible(true);
        prov = (Prov) new Reflect.__\u003C\u003EAnon1(declaredConstructor);
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_5;
        }
      }
      return prov;
label_5:
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) exception2);
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Object;Ljava/lang/String;)TT;")]
    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object get(object @object, string name) => Reflect.get(Object.instancehelper_getClass(@object), @object, name);

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<*>;Ljava/lang/String;)TT;")]
    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object get(Class type, string name) => Reflect.get(type, (object) null, name);

    [LineNumberTable(new byte[] {21, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void set(object @object, string name, object value) => Reflect.set(Object.instancehelper_getClass(@object), @object, name, value);

    [Signature("(Ljava/lang/Class<*>;Ljava/lang/String;Ljava/lang/Object;)V")]
    [LineNumberTable(new byte[] {25, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void set(Class type, string name, object value) => Reflect.set(type, (object) null, name, value);

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;)TT;")]
    [LineNumberTable(new byte[] {30, 108, 127, 29, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object make(string type)
    {
      object obj;
      Exception exception1;
      try
      {
        obj = Class.forName(type, Reflect.__\u003CGetCallerID\u003E()).getDeclaredConstructor(new Class[0], Reflect.__\u003CGetCallerID\u003E()).newInstance(new object[0], Reflect.__\u003CGetCallerID\u003E());
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_5;
        }
      }
      return obj;
label_5:
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) exception2);
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (Reflect.__\u003CcallerID\u003E == null)
        Reflect.__\u003CcallerID\u003E = (CallerID) new Reflect.__\u003CCallerID\u003E();
      return Reflect.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Prov
    {
      private readonly Constructor arg\u00241;

      internal __\u003C\u003EAnon1([In] Constructor obj0) => this.arg\u00241 = obj0;

      public object get() => Reflect.lambda\u0024cons\u00240(this.arg\u00241);
    }
  }
}
