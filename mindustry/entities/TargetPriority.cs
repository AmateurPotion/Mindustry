// Decompiled with JetBrains decompiler
// Type: mindustry.entities.TargetPriority
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

namespace mindustry.entities
{
  [Signature("Ljava/lang/Enum<Lmindustry/entities/TargetPriority;>;")]
  [Modifiers]
  [Serializable]
  public sealed class TargetPriority : Enum
  {
    [Modifiers]
    internal static TargetPriority __\u003C\u003Ebase;
    [Modifiers]
    internal static TargetPriority __\u003C\u003Eturret;
    [Modifiers]
    internal static TargetPriority __\u003C\u003Ecore;
    [Modifiers]
    private static TargetPriority[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("()V")]
    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private TargetPriority([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TargetPriority[] values() => (TargetPriority[]) TargetPriority.\u0024VALUES.Clone();

    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TargetPriority valueOf(string name) => (TargetPriority) Enum.valueOf((Class) ClassLiteral<TargetPriority>.Value, name);

    [LineNumberTable(new byte[] {159, 141, 109, 112, 112, 240, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static TargetPriority()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.TargetPriority"))
        return;
      TargetPriority.__\u003C\u003Ebase = new TargetPriority(nameof (@base), 0);
      TargetPriority.__\u003C\u003Eturret = new TargetPriority(nameof (turret), 1);
      TargetPriority.__\u003C\u003Ecore = new TargetPriority(nameof (core), 2);
      TargetPriority.\u0024VALUES = new TargetPriority[3]
      {
        TargetPriority.__\u003C\u003Ebase,
        TargetPriority.__\u003C\u003Eturret,
        TargetPriority.__\u003C\u003Ecore
      };
    }

    [Modifiers]
    public static TargetPriority @base
    {
      [HideFromJava] get => TargetPriority.__\u003C\u003Ebase;
    }

    [Modifiers]
    public static TargetPriority turret
    {
      [HideFromJava] get => TargetPriority.__\u003C\u003Eturret;
    }

    [Modifiers]
    public static TargetPriority core
    {
      [HideFromJava] get => TargetPriority.__\u003C\u003Ecore;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      @base,
      turret,
      core,
    }
  }
}
