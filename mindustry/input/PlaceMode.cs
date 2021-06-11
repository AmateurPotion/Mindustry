// Decompiled with JetBrains decompiler
// Type: mindustry.input.PlaceMode
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

namespace mindustry.input
{
  [Signature("Ljava/lang/Enum<Lmindustry/input/PlaceMode;>;")]
  [Modifiers]
  [Serializable]
  public sealed class PlaceMode : Enum
  {
    [Modifiers]
    internal static PlaceMode __\u003C\u003Enone;
    [Modifiers]
    internal static PlaceMode __\u003C\u003Ebreaking;
    [Modifiers]
    internal static PlaceMode __\u003C\u003Eplacing;
    [Modifiers]
    internal static PlaceMode __\u003C\u003EschematicSelect;
    [Modifiers]
    private static PlaceMode[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("()V")]
    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private PlaceMode([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static PlaceMode[] values() => (PlaceMode[]) PlaceMode.\u0024VALUES.Clone();

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static PlaceMode valueOf(string name) => (PlaceMode) Enum.valueOf((Class) ClassLiteral<PlaceMode>.Value, name);

    [LineNumberTable(new byte[] {159, 141, 77, 63, 33})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static PlaceMode()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.input.PlaceMode"))
        return;
      PlaceMode.__\u003C\u003Enone = new PlaceMode(nameof (none), 0);
      PlaceMode.__\u003C\u003Ebreaking = new PlaceMode(nameof (breaking), 1);
      PlaceMode.__\u003C\u003Eplacing = new PlaceMode(nameof (placing), 2);
      PlaceMode.__\u003C\u003EschematicSelect = new PlaceMode(nameof (schematicSelect), 3);
      PlaceMode.\u0024VALUES = new PlaceMode[4]
      {
        PlaceMode.__\u003C\u003Enone,
        PlaceMode.__\u003C\u003Ebreaking,
        PlaceMode.__\u003C\u003Eplacing,
        PlaceMode.__\u003C\u003EschematicSelect
      };
    }

    [Modifiers]
    public static PlaceMode none
    {
      [HideFromJava] get => PlaceMode.__\u003C\u003Enone;
    }

    [Modifiers]
    public static PlaceMode breaking
    {
      [HideFromJava] get => PlaceMode.__\u003C\u003Ebreaking;
    }

    [Modifiers]
    public static PlaceMode placing
    {
      [HideFromJava] get => PlaceMode.__\u003C\u003Eplacing;
    }

    [Modifiers]
    public static PlaceMode schematicSelect
    {
      [HideFromJava] get => PlaceMode.__\u003C\u003EschematicSelect;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      none,
      breaking,
      placing,
      schematicSelect,
    }
  }
}
