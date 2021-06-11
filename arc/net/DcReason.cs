// Decompiled with JetBrains decompiler
// Type: arc.net.DcReason
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

namespace arc.net
{
  [Signature("Ljava/lang/Enum<Larc/net/DcReason;>;")]
  [Modifiers]
  [Serializable]
  public sealed class DcReason : Enum
  {
    [Modifiers]
    internal static DcReason __\u003C\u003Etimeout;
    [Modifiers]
    internal static DcReason __\u003C\u003Eclosed;
    [Modifiers]
    internal static DcReason __\u003C\u003Eerror;
    [Modifiers]
    private static DcReason[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("()V")]
    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private DcReason([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static DcReason[] values() => (DcReason[]) DcReason.\u0024VALUES.Clone();

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static DcReason valueOf(string name) => (DcReason) Enum.valueOf((Class) ClassLiteral<DcReason>.Value, name);

    [LineNumberTable(new byte[] {159, 141, 77, 63, 17})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static DcReason()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.net.DcReason"))
        return;
      DcReason.__\u003C\u003Etimeout = new DcReason(nameof (timeout), 0);
      DcReason.__\u003C\u003Eclosed = new DcReason(nameof (closed), 1);
      DcReason.__\u003C\u003Eerror = new DcReason(nameof (error), 2);
      DcReason.\u0024VALUES = new DcReason[3]
      {
        DcReason.__\u003C\u003Etimeout,
        DcReason.__\u003C\u003Eclosed,
        DcReason.__\u003C\u003Eerror
      };
    }

    [Modifiers]
    public static DcReason timeout
    {
      [HideFromJava] get => DcReason.__\u003C\u003Etimeout;
    }

    [Modifiers]
    public static DcReason closed
    {
      [HideFromJava] get => DcReason.__\u003C\u003Eclosed;
    }

    [Modifiers]
    public static DcReason error
    {
      [HideFromJava] get => DcReason.__\u003C\u003Eerror;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      timeout,
      closed,
      error,
    }
  }
}
