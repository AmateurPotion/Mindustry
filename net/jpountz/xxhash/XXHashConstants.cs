// Decompiled with JetBrains decompiler
// Type: net.jpountz.xxhash.XXHashConstants
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.xxhash
{
  [Signature("Ljava/lang/Enum<Lnet/jpountz/xxhash/XXHashConstants;>;")]
  [Modifiers]
  [Serializable]
  internal sealed class XXHashConstants : Enum
  {
    internal const int PRIME1 = -1640531535;
    internal const int PRIME2 = -2048144777;
    internal const int PRIME3 = -1028477379;
    internal const int PRIME4 = 668265263;
    internal const int PRIME5 = 374761393;
    internal const long PRIME64_1 = -7046029288634856825;
    internal const long PRIME64_2 = -4417276706812531889;
    internal const long PRIME64_3 = 1609587929392839161;
    internal const long PRIME64_4 = -8796714831421723037;
    internal const long PRIME64_5 = 2870177450012600261;
    [Modifiers]
    private static XXHashConstants[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static XXHashConstants[] values() => (XXHashConstants[]) XXHashConstants.\u0024VALUES.Clone();

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static XXHashConstants valueOf([In] string obj0) => (XXHashConstants) Enum.valueOf((Class) ClassLiteral<XXHashConstants>.Value, obj0);

    [Signature("()V")]
    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private XXHashConstants([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static XXHashConstants()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.xxhash.XXHashConstants"))
        return;
      XXHashConstants.\u0024VALUES = new XXHashConstants[0];
    }
  }
}
