// Decompiled with JetBrains decompiler
// Type: com.sun.jna.NativeMappedConverter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.@ref;
using java.util;
using System;
using System.Runtime.CompilerServices;

namespace com.sun.jna
{
  [Implements(new string[] {"com.sun.jna.TypeConverter"})]
  public class NativeMappedConverter : Object, TypeConverter, FromNativeConverter, ToNativeConverter
  {
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/Class<*>;Ljava/lang/ref/Reference<Lcom/sun/jna/NativeMappedConverter;>;>;")]
    private static Map converters;
    [Modifiers]
    [Signature("Ljava/lang/Class<*>;")]
    private Class type;
    [Modifiers]
    [Signature("Ljava/lang/Class<*>;")]
    private Class nativeType;
    [Modifiers]
    private NativeMapped instance;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Ljava/lang/Class<*>;)Lcom/sun/jna/NativeMappedConverter;")]
    [LineNumberTable(new byte[] {159, 182, 108, 113, 114, 99, 103, 146, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static NativeMappedConverter getInstance(Class cls)
    {
      NativeMappedConverter nativeMappedConverter1;
      lock (NativeMappedConverter.converters)
      {
        Reference reference = (Reference) NativeMappedConverter.converters.get((object) cls);
        NativeMappedConverter nativeMappedConverter2 = reference == null ? (NativeMappedConverter) null : (NativeMappedConverter) reference.get();
        if (nativeMappedConverter2 == null)
        {
          nativeMappedConverter2 = new NativeMappedConverter(cls);
          NativeMappedConverter.converters.put((object) cls, (object) new SoftReference((object) nativeMappedConverter2));
        }
        nativeMappedConverter1 = nativeMappedConverter2;
      }
      return nativeMappedConverter1;
    }

    [Signature("()Ljava/lang/Class<*>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Class nativeType() => this.nativeType;

    [LineNumberTable(new byte[] {11, 127, 24, 97, 159, 18, 109, 98, 159, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual NativeMapped defaultValue()
    {
      NativeMapped nativeMapped;
      InstantiationException instantiationException1;
      IllegalAccessException illegalAccessException1;
      try
      {
        try
        {
          nativeMapped = (NativeMapped) this.type.newInstance(NativeMappedConverter.__\u003CGetCallerID\u003E());
        }
        catch (InstantiationException ex)
        {
          instantiationException1 = (InstantiationException) ByteCodeHelper.MapException<InstantiationException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_4;
        }
      }
      catch (IllegalAccessException ex)
      {
        illegalAccessException1 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_5;
      }
      return nativeMapped;
label_4:
      InstantiationException instantiationException2 = instantiationException1;
      string str1 = new StringBuilder().append("Can't create an instance of ").append((object) this.type).append(", requires a no-arg constructor: ").append((object) instantiationException2).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str1);
label_5:
      IllegalAccessException illegalAccessException2 = illegalAccessException1;
      string str2 = new StringBuilder().append("Not allowed to create an instance of ").append((object) this.type).append(", requires a public, no-arg constructor: ").append((object) illegalAccessException2).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str2);
    }

    [LineNumberTable(new byte[] {34, 99, 114, 130, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object toNative(object value, ToNativeContext context)
    {
      if (value == null)
      {
        if (((Class) ClassLiteral<Pointer>.Value).isAssignableFrom(this.nativeType))
          return (object) null;
        value = (object) this.defaultValue();
      }
      return ((NativeMapped) value).toNative();
    }

    [Signature("(Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {1, 104, 109, 127, 10, 103, 108, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeMappedConverter(Class type)
    {
      NativeMappedConverter nativeMappedConverter = this;
      if (!((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(type))
      {
        string str = new StringBuilder().append("Type must derive from ").append((object) ClassLiteral<NativeMapped>.Value).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.type = type;
      this.instance = this.defaultValue();
      this.nativeType = this.instance.nativeType();
    }

    [LineNumberTable(74)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object fromNative(object nativeValue, FromNativeContext context) => this.instance.fromNative(nativeValue, context);

    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeMappedConverter()
    {
      if (ByteCodeHelper.isAlreadyInited("com.sun.jna.NativeMappedConverter"))
        return;
      NativeMappedConverter.converters = (Map) new WeakHashMap();
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (NativeMappedConverter.__\u003CcallerID\u003E == null)
        NativeMappedConverter.__\u003CcallerID\u003E = (CallerID) new NativeMappedConverter.__\u003CCallerID\u003E();
      return NativeMappedConverter.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
