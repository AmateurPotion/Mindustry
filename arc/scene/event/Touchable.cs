// Decompiled with JetBrains decompiler
// Type: arc.scene.event.Touchable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene.@event;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.@event
{
  [Signature("Ljava/lang/Enum<Larc/scene/event/Touchable;>;")]
  [Modifiers]
  [Serializable]
  public sealed class Touchable : Enum
  {
    [Modifiers]
    internal static Touchable __\u003C\u003Eenabled;
    [Modifiers]
    internal static Touchable __\u003C\u003Edisabled;
    [Modifiers]
    internal static Touchable __\u003C\u003EchildrenOnly;
    [Modifiers]
    private static Touchable[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("()V")]
    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Touchable([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Touchable[] values() => (Touchable[]) Touchable.\u0024VALUES.Clone();

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Touchable valueOf(string name) => (Touchable) Enum.valueOf((Class) ClassLiteral<Touchable>.Value, name);

    [LineNumberTable(new byte[] {159, 140, 109, 144, 240, 69, 240, 55})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Touchable()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.scene.event.Touchable"))
        return;
      Touchable.__\u003C\u003Eenabled = new Touchable(nameof (enabled), 0);
      Touchable.__\u003C\u003Edisabled = new Touchable(nameof (disabled), 1);
      Touchable.__\u003C\u003EchildrenOnly = new Touchable(nameof (childrenOnly), 2);
      Touchable.\u0024VALUES = new Touchable[3]
      {
        Touchable.__\u003C\u003Eenabled,
        Touchable.__\u003C\u003Edisabled,
        Touchable.__\u003C\u003EchildrenOnly
      };
    }

    [Modifiers]
    public static Touchable enabled
    {
      [HideFromJava] get => Touchable.__\u003C\u003Eenabled;
    }

    [Modifiers]
    public static Touchable disabled
    {
      [HideFromJava] get => Touchable.__\u003C\u003Edisabled;
    }

    [Modifiers]
    public static Touchable childrenOnly
    {
      [HideFromJava] get => Touchable.__\u003C\u003EchildrenOnly;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      enabled,
      disabled,
      childrenOnly,
    }
  }
}
