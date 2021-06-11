// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4Factory
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using java.util;
using net.jpountz.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.lz4
{
  public sealed class LZ4Factory : Object
  {
    private static LZ4Factory NATIVE_INSTANCE;
    private static LZ4Factory JAVA_UNSAFE_INSTANCE;
    private static LZ4Factory JAVA_SAFE_INSTANCE;
    [Modifiers]
    private string impl;
    [Modifiers]
    private LZ4Compressor fastCompressor;
    [Modifiers]
    private LZ4Compressor highCompressor;
    [Modifiers]
    private LZ4FastDecompressor fastDecompressor;
    [Modifiers]
    private LZ4SafeDecompressor safeDecompressor;
    [Modifiers]
    private LZ4Compressor[] highCompressors;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [LineNumberTable(new byte[] {104, 191, 8, 122, 97, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4Factory fastestInstance()
    {
      if (!Native.isLoaded())
      {
        if (!object.ReferenceEquals((object) ((Class) ClassLiteral<Native>.Value).getClassLoader(LZ4Factory.__\u003CGetCallerID\u003E()), (object) ClassLoader.getSystemClassLoader(LZ4Factory.__\u003CGetCallerID\u003E())))
          return LZ4Factory.fastestJavaInstance();
      }
      LZ4Factory lz4Factory;
      try
      {
        lz4Factory = LZ4Factory.nativeInstance();
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        goto label_5;
      }
      return lz4Factory;
label_5:
      return LZ4Factory.fastestJavaInstance();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LZ4FastDecompressor fastDecompressor() => this.fastDecompressor;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LZ4Compressor fastCompressor() => this.fastCompressor;

    [Throws(new string[] {"java.lang.ClassNotFoundException", "java.lang.NoSuchFieldException", "java.lang.SecurityException", "java.lang.IllegalArgumentException", "java.lang.IllegalAccessException", "java.lang.NoSuchMethodException", "java.lang.InstantiationException", "java.lang.reflect.InvocationTargetException"})]
    [LineNumberTable(new byte[] {160, 68, 8, 173, 103, 127, 21, 127, 21, 127, 21, 127, 21, 127, 5, 111, 103, 103, 31, 8, 230, 70, 127, 88, 127, 31, 107, 105, 114, 105, 116, 106, 139, 104, 117, 112, 139, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private LZ4Factory([In] string obj0)
    {
      LZ4Factory lz4Factory = this;
      this.highCompressors = new LZ4Compressor[18];
      this.impl = obj0;
      this.fastCompressor = (LZ4Compressor) LZ4Factory.classInstance(new StringBuilder().append("net.jpountz.lz4.LZ4").append(obj0).append("Compressor").toString());
      this.highCompressor = (LZ4Compressor) LZ4Factory.classInstance(new StringBuilder().append("net.jpountz.lz4.LZ4HC").append(obj0).append("Compressor").toString());
      this.fastDecompressor = (LZ4FastDecompressor) LZ4Factory.classInstance(new StringBuilder().append("net.jpountz.lz4.LZ4").append(obj0).append("FastDecompressor").toString());
      this.safeDecompressor = (LZ4SafeDecompressor) LZ4Factory.classInstance(new StringBuilder().append("net.jpountz.lz4.LZ4").append(obj0).append("SafeDecompressor").toString());
      Constructor declaredConstructor = Object.instancehelper_getClass((object) this.highCompressor).getDeclaredConstructor(new Class[1]
      {
        (Class) Integer.TYPE
      }, LZ4Factory.__\u003CGetCallerID\u003E());
      this.highCompressors[9] = this.highCompressor;
      for (int index = 1; index <= 17; ++index)
      {
        if (index != 9)
          this.highCompressors[index] = (LZ4Compressor) declaredConstructor.newInstance(new object[1]
          {
            (object) Integer.valueOf(index)
          }, LZ4Factory.__\u003CGetCallerID\u003E());
      }
      byte[] barr1 = new byte[20]
      {
        (byte) 97,
        (byte) 98,
        (byte) 99,
        (byte) 100,
        (byte) 32,
        (byte) 32,
        (byte) 32,
        (byte) 32,
        (byte) 32,
        (byte) 32,
        (byte) 97,
        (byte) 98,
        (byte) 99,
        (byte) 100,
        (byte) 101,
        (byte) 102,
        (byte) 103,
        (byte) 104,
        (byte) 105,
        (byte) 106
      };
      Iterator iterator = Arrays.asList((object[]) new LZ4Compressor[2]
      {
        this.fastCompressor,
        this.highCompressor
      }).iterator();
      while (iterator.hasNext())
      {
        LZ4Compressor lz4Compressor = (LZ4Compressor) iterator.next();
        int i4 = lz4Compressor.maxCompressedLength(barr1.Length);
        byte[] numArray1 = new byte[i4];
        int srcLen = lz4Compressor.compress(barr1, 0, barr1.Length, numArray1, 0, i4);
        byte[] numArray2 = new byte[barr1.Length];
        this.fastDecompressor.decompress(numArray1, 0, numArray2, 0, barr1.Length);
        if (!Arrays.equals(barr1, numArray2))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
        }
        Arrays.fill(numArray2, (byte) 0);
        if (this.safeDecompressor.decompress(numArray1, 0, srcLen, numArray2, 0) != barr1.Length || !Arrays.equals(barr1, numArray2))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
        }
      }
    }

    [LineNumberTable(new byte[] {1, 127, 2, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static LZ4Factory instance([In] string obj0)
    {
      LZ4Factory lz4Factory;
      Exception exception1;
      try
      {
        lz4Factory = new LZ4Factory(obj0);
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
      return lz4Factory;
label_5:
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new AssertionError((object) exception2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 114, 108, 103, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4Factory unsafeInstance()
    {
      lock ((object) ClassLiteral<LZ4Factory>.Value)
      {
        if (LZ4Factory.JAVA_UNSAFE_INSTANCE == null)
          LZ4Factory.JAVA_UNSAFE_INSTANCE = LZ4Factory.instance("JavaUnsafe");
        return LZ4Factory.JAVA_UNSAFE_INSTANCE;
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 118, 108, 103, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4Factory safeInstance()
    {
      lock ((object) ClassLiteral<LZ4Factory>.Value)
      {
        if (LZ4Factory.JAVA_SAFE_INSTANCE == null)
          LZ4Factory.JAVA_SAFE_INSTANCE = LZ4Factory.instance("JavaSafe");
        return LZ4Factory.JAVA_SAFE_INSTANCE;
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 122, 172, 103, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4Factory nativeInstance()
    {
      lock ((object) ClassLiteral<LZ4Factory>.Value)
      {
        if (LZ4Factory.NATIVE_INSTANCE == null)
          LZ4Factory.NATIVE_INSTANCE = LZ4Factory.instance("JNI");
        return LZ4Factory.NATIVE_INSTANCE;
      }
    }

    [LineNumberTable(new byte[] {80, 135, 122, 97, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4Factory fastestJavaInstance()
    {
      if (!Utils.isUnalignedAccessAllowed())
        return LZ4Factory.safeInstance();
      LZ4Factory lz4Factory;
      try
      {
        lz4Factory = LZ4Factory.unsafeInstance();
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        goto label_4;
      }
      return lz4Factory;
label_4:
      return LZ4Factory.safeInstance();
    }

    [Throws(new string[] {"java.lang.NoSuchFieldException", "java.lang.SecurityException", "java.lang.ClassNotFoundException", "java.lang.IllegalArgumentException", "java.lang.IllegalAccessException"})]
    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;)TT;")]
    [LineNumberTable(new byte[] {118, 112, 113, 104, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object classInstance([In] string obj0) => (((Class) ClassLiteral<LZ4Factory>.Value).getClassLoader(LZ4Factory.__\u003CGetCallerID\u003E()) ?? ClassLoader.getSystemClassLoader(LZ4Factory.__\u003CGetCallerID\u003E())).loadClass(obj0).getField("INSTANCE", LZ4Factory.__\u003CGetCallerID\u003E()).get((object) null, LZ4Factory.__\u003CGetCallerID\u003E());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LZ4SafeDecompressor safeDecompressor() => this.safeDecompressor;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LZ4Compressor highCompressor() => this.highCompressor;

    [LineNumberTable(new byte[] {160, 136, 101, 102, 100, 132})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LZ4Compressor highCompressor(int compressionLevel)
    {
      if (compressionLevel > 17)
        compressionLevel = 17;
      else if (compressionLevel < 1)
        compressionLevel = 9;
      return this.highCompressors[compressionLevel];
    }

    [Obsolete]
    [LineNumberTable(283)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LZ4UnknownSizeDecompressor unknownSizeDecompressor() => (LZ4UnknownSizeDecompressor) this.safeDecompressor();

    [Obsolete]
    [LineNumberTable(293)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LZ4Decompressor decompressor() => (LZ4Decompressor) this.fastDecompressor();

    [LineNumberTable(new byte[] {160, 188, 127, 9, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void main(string[] args)
    {
      java.lang.System.@out.println(new StringBuilder().append("Fastest instance is ").append((object) LZ4Factory.fastestInstance()).toString());
      java.lang.System.@out.println(new StringBuilder().append("Fastest Java instance is ").append((object) LZ4Factory.fastestJavaInstance()).toString());
    }

    [LineNumberTable(308)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append(Object.instancehelper_getClass((object) this).getSimpleName()).append(":").append(this.impl).toString();

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (LZ4Factory.__\u003CcallerID\u003E == null)
        LZ4Factory.__\u003CcallerID\u003E = (CallerID) new LZ4Factory.__\u003CCallerID\u003E();
      return LZ4Factory.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
