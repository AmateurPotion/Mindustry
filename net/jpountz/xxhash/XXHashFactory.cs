// Decompiled with JetBrains decompiler
// Type: net.jpountz.xxhash.XXHashFactory
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using net.jpountz.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.xxhash
{
  public sealed class XXHashFactory : Object
  {
    private static XXHashFactory NATIVE_INSTANCE;
    private static XXHashFactory JAVA_UNSAFE_INSTANCE;
    private static XXHashFactory JAVA_SAFE_INSTANCE;
    [Modifiers]
    private string impl;
    [Modifiers]
    private XXHash32 hash32;
    [Modifiers]
    private XXHash64 hash64;
    [Modifiers]
    private StreamingXXHash32.Factory streamingHash32Factory;
    [Modifiers]
    private StreamingXXHash64.Factory streamingHash64Factory;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [LineNumberTable(new byte[] {98, 191, 8, 122, 97, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static XXHashFactory fastestInstance()
    {
      if (!Native.isLoaded())
      {
        if (!object.ReferenceEquals((object) ((Class) ClassLiteral<Native>.Value).getClassLoader(XXHashFactory.__\u003CGetCallerID\u003E()), (object) ClassLoader.getSystemClassLoader(XXHashFactory.__\u003CGetCallerID\u003E())))
          return XXHashFactory.fastestJavaInstance();
      }
      XXHashFactory xxHashFactory;
      try
      {
        xxHashFactory = XXHashFactory.nativeInstance();
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        goto label_5;
      }
      return xxHashFactory;
label_5:
      return XXHashFactory.fastestJavaInstance();
    }

    [LineNumberTable(229)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual StreamingXXHash32 newStreamingHash32(int seed) => this.streamingHash32Factory.newStreamingHash(seed);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual XXHash32 hash32() => this.hash32;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 119, 108, 103, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static XXHashFactory safeInstance()
    {
      lock ((object) ClassLiteral<XXHashFactory>.Value)
      {
        if (XXHashFactory.JAVA_SAFE_INSTANCE == null)
          XXHashFactory.JAVA_SAFE_INSTANCE = XXHashFactory.instance("JavaSafe");
        return XXHashFactory.JAVA_SAFE_INSTANCE;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual XXHash64 hash64() => this.hash64;

    [Throws(new string[] {"java.lang.ClassNotFoundException", "java.lang.NoSuchFieldException", "java.lang.SecurityException", "java.lang.IllegalArgumentException", "java.lang.IllegalAccessException"})]
    [LineNumberTable(new byte[] {125, 104, 103, 127, 11, 127, 21, 127, 11, 191, 21, 104, 102, 103, 135, 114, 105, 107, 105, 115, 106, 107, 105, 102, 139, 102, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private XXHashFactory([In] string obj0)
    {
      XXHashFactory xxHashFactory = this;
      this.impl = obj0;
      this.hash32 = (XXHash32) XXHashFactory.classInstance(new StringBuilder().append("net.jpountz.xxhash.XXHash32").append(obj0).toString());
      this.streamingHash32Factory = (StreamingXXHash32.Factory) XXHashFactory.classInstance(new StringBuilder().append("net.jpountz.xxhash.StreamingXXHash32").append(obj0).append("$Factory").toString());
      this.hash64 = (XXHash64) XXHashFactory.classInstance(new StringBuilder().append("net.jpountz.xxhash.XXHash64").append(obj0).toString());
      this.streamingHash64Factory = (StreamingXXHash64.Factory) XXHashFactory.classInstance(new StringBuilder().append("net.jpountz.xxhash.StreamingXXHash64").append(obj0).append("$Factory").toString());
      byte[] barr = new byte[100];
      Random random = new Random();
      random.nextBytes(barr);
      int num1 = random.nextInt();
      int num2 = this.hash32.hash(barr, 0, barr.Length, num1);
      StreamingXXHash32 streamingXxHash32 = this.newStreamingHash32(num1);
      streamingXxHash32.update(barr, 0, barr.Length);
      int num3 = streamingXxHash32.getValue();
      long num4 = this.hash64.hash(barr, 0, barr.Length, (long) num1);
      StreamingXXHash64 streamingXxHash64 = this.newStreamingHash64((long) num1);
      streamingXxHash64.update(barr, 0, barr.Length);
      long num5 = streamingXxHash64.getValue();
      if (num2 != num3)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      if (num4 != num5)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
    }

    [LineNumberTable(new byte[] {159, 189, 127, 2, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static XXHashFactory instance([In] string obj0)
    {
      XXHashFactory xxHashFactory;
      Exception exception1;
      try
      {
        xxHashFactory = new XXHashFactory(obj0);
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
      return xxHashFactory;
label_5:
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new AssertionError((object) exception2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 116, 172, 103, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static XXHashFactory unsafeInstance()
    {
      lock ((object) ClassLiteral<XXHashFactory>.Value)
      {
        if (XXHashFactory.JAVA_UNSAFE_INSTANCE == null)
          XXHashFactory.JAVA_UNSAFE_INSTANCE = XXHashFactory.instance("JavaUnsafe");
        return XXHashFactory.JAVA_UNSAFE_INSTANCE;
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 123, 172, 103, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static XXHashFactory nativeInstance()
    {
      lock ((object) ClassLiteral<XXHashFactory>.Value)
      {
        if (XXHashFactory.NATIVE_INSTANCE == null)
          XXHashFactory.NATIVE_INSTANCE = XXHashFactory.instance("JNI");
        return XXHashFactory.NATIVE_INSTANCE;
      }
    }

    [LineNumberTable(new byte[] {74, 135, 122, 97, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static XXHashFactory fastestJavaInstance()
    {
      if (!Utils.isUnalignedAccessAllowed())
        return XXHashFactory.safeInstance();
      XXHashFactory xxHashFactory;
      try
      {
        xxHashFactory = XXHashFactory.unsafeInstance();
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        goto label_4;
      }
      return xxHashFactory;
label_4:
      return XXHashFactory.safeInstance();
    }

    [Throws(new string[] {"java.lang.NoSuchFieldException", "java.lang.SecurityException", "java.lang.ClassNotFoundException", "java.lang.IllegalArgumentException", "java.lang.IllegalAccessException"})]
    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;)TT;")]
    [LineNumberTable(new byte[] {112, 112, 113, 104, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object classInstance([In] string obj0) => (((Class) ClassLiteral<XXHashFactory>.Value).getClassLoader(XXHashFactory.__\u003CGetCallerID\u003E()) ?? ClassLoader.getSystemClassLoader(XXHashFactory.__\u003CGetCallerID\u003E())).loadClass(obj0).getField("INSTANCE", XXHashFactory.__\u003CGetCallerID\u003E()).get((object) null, XXHashFactory.__\u003CGetCallerID\u003E());

    [LineNumberTable(239)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual StreamingXXHash64 newStreamingHash64(long seed) => this.streamingHash64Factory.newStreamingHash(seed);

    [LineNumberTable(new byte[] {160, 134, 127, 9, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void main(string[] args)
    {
      java.lang.System.@out.println(new StringBuilder().append("Fastest instance is ").append((object) XXHashFactory.fastestInstance()).toString());
      java.lang.System.@out.println(new StringBuilder().append("Fastest Java instance is ").append((object) XXHashFactory.fastestJavaInstance()).toString());
    }

    [LineNumberTable(254)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append(Object.instancehelper_getClass((object) this).getSimpleName()).append(":").append(this.impl).toString();

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (XXHashFactory.__\u003CcallerID\u003E == null)
        XXHashFactory.__\u003CcallerID\u003E = (CallerID) new XXHashFactory.__\u003CCallerID\u003E();
      return XXHashFactory.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
