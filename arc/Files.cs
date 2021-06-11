// Decompiled with JetBrains decompiler
// Type: arc.Files
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc
{
  public interface Files
  {
    [Modifiers]
    Fi local(string path);

    [LineNumberTable(43)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Fi \u003Cdefault\u003Elocal([In] Files obj0, [In] string obj1) => obj0.get(obj1, Files.FileType.__\u003C\u003Elocal);

    [Modifiers]
    Fi absolute(string path);

    [LineNumberTable(38)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Fi \u003Cdefault\u003Eabsolute([In] Files obj0, [In] string obj1) => obj0.get(obj1, Files.FileType.__\u003C\u003Eabsolute);

    [Modifiers]
    Fi @internal(string path);

    [LineNumberTable(28)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Fi \u003Cdefault\u003Einternal([In] Files obj0, [In] string obj1) => obj0.get(obj1, Files.FileType.__\u003C\u003Einternal);

    string getExternalStoragePath();

    Fi get(string str, Files.FileType fft);

    [Modifiers]
    string getCachePath();

    [LineNumberTable(53)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static string \u003Cdefault\u003EgetCachePath([In] Files obj0) => obj0.local("cache").absolutePath();

    [Modifiers]
    Fi classpath(string path);

    [LineNumberTable(23)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Fi \u003Cdefault\u003Eclasspath([In] Files obj0, [In] string obj1) => obj0.get(obj1, Files.FileType.__\u003C\u003Eclasspath);

    [Modifiers]
    Fi external(string path);

    [LineNumberTable(33)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Fi \u003Cdefault\u003Eexternal([In] Files obj0, [In] string obj1) => obj0.get(obj1, Files.FileType.__\u003C\u003Eexternal);

    [Modifiers]
    Fi cache(string path);

    [LineNumberTable(48)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Fi \u003Cdefault\u003Ecache([In] Files obj0, [In] string obj1) => obj0.get(obj0.getCachePath(), Files.FileType.__\u003C\u003Eabsolute).child(obj1);

    bool isExternalStorageAvailable();

    string getLocalStoragePath();

    bool isLocalStorageAvailable();

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/Files$FileType;>;")]
    [Modifiers]
    [Serializable]
    sealed class FileType : Enum
    {
      [Modifiers]
      internal static Files.FileType __\u003C\u003Eclasspath;
      [Modifiers]
      internal static Files.FileType __\u003C\u003Einternal;
      [Modifiers]
      internal static Files.FileType __\u003C\u003Eexternal;
      [Modifiers]
      internal static Files.FileType __\u003C\u003Eabsolute;
      [Modifiers]
      internal static Files.FileType __\u003C\u003Elocal;
      [Modifiers]
      private static Files.FileType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(82)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private FileType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(82)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Files.FileType[] values() => (Files.FileType[]) Files.FileType.\u0024VALUES.Clone();

      [LineNumberTable(82)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Files.FileType valueOf(string name) => (Files.FileType) Enum.valueOf((Class) ClassLiteral<Files.FileType>.Value, name);

      [LineNumberTable(new byte[] {159, 120, 77, 240, 71, 176, 240, 70, 176, 240, 39})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static FileType()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.Files$FileType"))
          return;
        Files.FileType.__\u003C\u003Eclasspath = new Files.FileType(nameof (classpath), 0);
        Files.FileType.__\u003C\u003Einternal = new Files.FileType(nameof (@internal), 1);
        Files.FileType.__\u003C\u003Eexternal = new Files.FileType(nameof (external), 2);
        Files.FileType.__\u003C\u003Eabsolute = new Files.FileType(nameof (absolute), 3);
        Files.FileType.__\u003C\u003Elocal = new Files.FileType(nameof (local), 4);
        Files.FileType.\u0024VALUES = new Files.FileType[5]
        {
          Files.FileType.__\u003C\u003Eclasspath,
          Files.FileType.__\u003C\u003Einternal,
          Files.FileType.__\u003C\u003Eexternal,
          Files.FileType.__\u003C\u003Eabsolute,
          Files.FileType.__\u003C\u003Elocal
        };
      }

      [Modifiers]
      public static Files.FileType classpath
      {
        [HideFromJava] get => Files.FileType.__\u003C\u003Eclasspath;
      }

      [Modifiers]
      public static Files.FileType @internal
      {
        [HideFromJava] get => Files.FileType.__\u003C\u003Einternal;
      }

      [Modifiers]
      public static Files.FileType external
      {
        [HideFromJava] get => Files.FileType.__\u003C\u003Eexternal;
      }

      [Modifiers]
      public static Files.FileType absolute
      {
        [HideFromJava] get => Files.FileType.__\u003C\u003Eabsolute;
      }

      [Modifiers]
      public static Files.FileType local
      {
        [HideFromJava] get => Files.FileType.__\u003C\u003Elocal;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        classpath,
        @internal,
        external,
        absolute,
        local,
      }
    }

    [HideFromJava]
    static class __DefaultMethods
    {
      public static Fi classpath([In] Files obj0, [In] string obj1)
      {
        Files files = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(files, ToString);
        return Files.\u003Cdefault\u003Eclasspath(files, obj1);
      }

      public static Fi @internal([In] Files obj0, [In] string obj1)
      {
        Files files = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(files, ToString);
        return Files.\u003Cdefault\u003Einternal(files, obj1);
      }

      public static Fi external([In] Files obj0, [In] string obj1)
      {
        Files files = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(files, ToString);
        return Files.\u003Cdefault\u003Eexternal(files, obj1);
      }

      public static Fi absolute([In] Files obj0, [In] string obj1)
      {
        Files files = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(files, ToString);
        return Files.\u003Cdefault\u003Eabsolute(files, obj1);
      }

      public static Fi local([In] Files obj0, [In] string obj1)
      {
        Files files = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(files, ToString);
        return Files.\u003Cdefault\u003Elocal(files, obj1);
      }

      public static Fi cache([In] Files obj0, [In] string obj1)
      {
        Files files = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(files, ToString);
        return Files.\u003Cdefault\u003Ecache(files, obj1);
      }

      public static string getCachePath([In] Files obj0)
      {
        Files files = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(files, ToString);
        return Files.\u003Cdefault\u003EgetCachePath(files);
      }
    }
  }
}
