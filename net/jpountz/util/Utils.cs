// Decompiled with JetBrains decompiler
// Type: net.jpountz.util.Utils
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.util
{
  [Signature("Ljava/lang/Enum<Lnet/jpountz/util/Utils;>;")]
  [Modifiers]
  [Serializable]
  public sealed class Utils : Enum
  {
    internal static ByteOrder __\u003C\u003ENATIVE_BYTE_ORDER;
    [Modifiers]
    private static bool unalignedAccessAllowed;
    [Modifiers]
    private static Utils[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isUnalignedAccessAllowed() => Utils.unalignedAccessAllowed;

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Utils[] values() => (Utils[]) Utils.\u0024VALUES.Clone();

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Utils valueOf(string name) => (Utils) Enum.valueOf((Class) ClassLiteral<Utils>.Value, name);

    [Signature("()V")]
    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Utils([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {159, 138, 173, 171, 202, 107, 191, 56})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Utils()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.util.Utils"))
        return;
      Utils.\u0024VALUES = new Utils[0];
      Utils.__\u003C\u003ENATIVE_BYTE_ORDER = ByteOrder.nativeOrder();
      string property = java.lang.System.getProperty("os.arch");
      Utils.unalignedAccessAllowed = String.instancehelper_equals(property, (object) "i386") || String.instancehelper_equals(property, (object) "x86") || (String.instancehelper_equals(property, (object) "amd64") || String.instancehelper_equals(property, (object) "x86_64")) || (String.instancehelper_equals(property, (object) "aarch64") || String.instancehelper_equals(property, (object) "ppc64le"));
    }

    [Modifiers]
    public static ByteOrder NATIVE_BYTE_ORDER
    {
      [HideFromJava] get => Utils.__\u003C\u003ENATIVE_BYTE_ORDER;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
    }
  }
}
