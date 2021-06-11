// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.HdpiMode
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

namespace arc.graphics.gl
{
  [Signature("Ljava/lang/Enum<Larc/graphics/gl/HdpiMode;>;")]
  [Modifiers]
  [Serializable]
  public sealed class HdpiMode : Enum
  {
    [Modifiers]
    internal static HdpiMode __\u003C\u003Elogical;
    [Modifiers]
    internal static HdpiMode __\u003C\u003Epixels;
    [Modifiers]
    private static HdpiMode[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("()V")]
    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private HdpiMode([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static HdpiMode[] values() => (HdpiMode[]) HdpiMode.\u0024VALUES.Clone();

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static HdpiMode valueOf(string name) => (HdpiMode) Enum.valueOf((Class) ClassLiteral<HdpiMode>.Value, name);

    [LineNumberTable(new byte[] {159, 139, 173, 240, 71, 240, 48})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static HdpiMode()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.gl.HdpiMode"))
        return;
      HdpiMode.__\u003C\u003Elogical = new HdpiMode(nameof (logical), 0);
      HdpiMode.__\u003C\u003Epixels = new HdpiMode(nameof (pixels), 1);
      HdpiMode.\u0024VALUES = new HdpiMode[2]
      {
        HdpiMode.__\u003C\u003Elogical,
        HdpiMode.__\u003C\u003Epixels
      };
    }

    [Modifiers]
    public static HdpiMode logical
    {
      [HideFromJava] get => HdpiMode.__\u003C\u003Elogical;
    }

    [Modifiers]
    public static HdpiMode pixels
    {
      [HideFromJava] get => HdpiMode.__\u003C\u003Epixels;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      logical,
      pixels,
    }
  }
}
