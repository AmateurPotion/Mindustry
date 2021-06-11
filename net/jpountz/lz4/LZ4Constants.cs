// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4Constants
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

namespace net.jpountz.lz4
{
  [Signature("Ljava/lang/Enum<Lnet/jpountz/lz4/LZ4Constants;>;")]
  [Modifiers]
  [Serializable]
  internal sealed class LZ4Constants : Enum
  {
    internal const int DEFAULT_COMPRESSION_LEVEL = 9;
    internal const int MAX_COMPRESSION_LEVEL = 17;
    internal const int MEMORY_USAGE = 14;
    internal const int NOT_COMPRESSIBLE_DETECTION_LEVEL = 6;
    internal const int MIN_MATCH = 4;
    internal const int HASH_LOG = 12;
    internal const int HASH_TABLE_SIZE = 4096;
    [Modifiers]
    internal static int SKIP_STRENGTH;
    internal const int COPY_LENGTH = 8;
    internal const int LAST_LITERALS = 5;
    internal const int MF_LIMIT = 12;
    internal const int MIN_LENGTH = 13;
    internal const int MAX_DISTANCE = 65536;
    internal const int ML_BITS = 4;
    internal const int ML_MASK = 15;
    internal const int RUN_BITS = 4;
    internal const int RUN_MASK = 15;
    internal const int LZ4_64K_LIMIT = 65547;
    internal const int HASH_LOG_64K = 13;
    internal const int HASH_TABLE_SIZE_64K = 8192;
    internal const int HASH_LOG_HC = 15;
    internal const int HASH_TABLE_SIZE_HC = 32768;
    internal const int OPTIMAL_ML = 18;
    [Modifiers]
    private static LZ4Constants[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4Constants[] values() => (LZ4Constants[]) LZ4Constants.\u0024VALUES.Clone();

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4Constants valueOf([In] string obj0) => (LZ4Constants) Enum.valueOf((Class) ClassLiteral<LZ4Constants>.Value, obj0);

    [Signature("()V")]
    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private LZ4Constants([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {159, 138, 141, 235, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LZ4Constants()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4Constants"))
        return;
      LZ4Constants.\u0024VALUES = new LZ4Constants[0];
      LZ4Constants.SKIP_STRENGTH = Math.max(6, 2);
    }
  }
}
