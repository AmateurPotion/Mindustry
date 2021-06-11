// Decompiled with JetBrains decompiler
// Type: rhino.StackStyle
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

namespace rhino
{
  [Signature("Ljava/lang/Enum<Lrhino/StackStyle;>;")]
  [Modifiers]
  [Serializable]
  public sealed class StackStyle : Enum
  {
    [Modifiers]
    internal static StackStyle __\u003C\u003ERHINO;
    [Modifiers]
    internal static StackStyle __\u003C\u003EMOZILLA;
    [Modifiers]
    internal static StackStyle __\u003C\u003EV8;
    [Modifiers]
    private static StackStyle[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static StackStyle[] values() => (StackStyle[]) StackStyle.\u0024VALUES.Clone();

    [Signature("()V")]
    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private StackStyle([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static StackStyle valueOf(string name) => (StackStyle) Enum.valueOf((Class) ClassLiteral<StackStyle>.Value, name);

    [LineNumberTable(new byte[] {159, 139, 77, 240, 70, 240, 72, 240, 45})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static StackStyle()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.StackStyle"))
        return;
      StackStyle.__\u003C\u003ERHINO = new StackStyle(nameof (RHINO), 0);
      StackStyle.__\u003C\u003EMOZILLA = new StackStyle(nameof (MOZILLA), 1);
      StackStyle.__\u003C\u003EV8 = new StackStyle(nameof (V8), 2);
      StackStyle.\u0024VALUES = new StackStyle[3]
      {
        StackStyle.__\u003C\u003ERHINO,
        StackStyle.__\u003C\u003EMOZILLA,
        StackStyle.__\u003C\u003EV8
      };
    }

    [Modifiers]
    public static StackStyle RHINO
    {
      [HideFromJava] get => StackStyle.__\u003C\u003ERHINO;
    }

    [Modifiers]
    public static StackStyle MOZILLA
    {
      [HideFromJava] get => StackStyle.__\u003C\u003EMOZILLA;
    }

    [Modifiers]
    public static StackStyle V8
    {
      [HideFromJava] get => StackStyle.__\u003C\u003EV8;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      RHINO,
      MOZILLA,
      V8,
    }
  }
}
