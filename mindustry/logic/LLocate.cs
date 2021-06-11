// Decompiled with JetBrains decompiler
// Type: mindustry.logic.LLocate
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

namespace mindustry.logic
{
  [Signature("Ljava/lang/Enum<Lmindustry/logic/LLocate;>;")]
  [Modifiers]
  [Serializable]
  public sealed class LLocate : Enum
  {
    [Modifiers]
    internal static LLocate __\u003C\u003Eore;
    [Modifiers]
    internal static LLocate __\u003C\u003Ebuilding;
    [Modifiers]
    internal static LLocate __\u003C\u003Espawn;
    [Modifiers]
    internal static LLocate __\u003C\u003Edamaged;
    internal static LLocate[] __\u003C\u003Eall;
    [Modifiers]
    private static LLocate[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LLocate valueOf(string name) => (LLocate) Enum.valueOf((Class) ClassLiteral<LLocate>.Value, name);

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LLocate[] values() => (LLocate[]) LLocate.\u0024VALUES.Clone();

    [Signature("()V")]
    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private LLocate([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {159, 141, 77, 112, 112, 112, 240, 60, 255, 12, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LLocate()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.logic.LLocate"))
        return;
      LLocate.__\u003C\u003Eore = new LLocate(nameof (ore), 0);
      LLocate.__\u003C\u003Ebuilding = new LLocate(nameof (building), 1);
      LLocate.__\u003C\u003Espawn = new LLocate(nameof (spawn), 2);
      LLocate.__\u003C\u003Edamaged = new LLocate(nameof (damaged), 3);
      LLocate.\u0024VALUES = new LLocate[4]
      {
        LLocate.__\u003C\u003Eore,
        LLocate.__\u003C\u003Ebuilding,
        LLocate.__\u003C\u003Espawn,
        LLocate.__\u003C\u003Edamaged
      };
      LLocate.__\u003C\u003Eall = LLocate.values();
    }

    [Modifiers]
    public static LLocate ore
    {
      [HideFromJava] get => LLocate.__\u003C\u003Eore;
    }

    [Modifiers]
    public static LLocate building
    {
      [HideFromJava] get => LLocate.__\u003C\u003Ebuilding;
    }

    [Modifiers]
    public static LLocate spawn
    {
      [HideFromJava] get => LLocate.__\u003C\u003Espawn;
    }

    [Modifiers]
    public static LLocate damaged
    {
      [HideFromJava] get => LLocate.__\u003C\u003Edamaged;
    }

    [Modifiers]
    public static LLocate[] all
    {
      [HideFromJava] get => LLocate.__\u003C\u003Eall;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      ore,
      building,
      spawn,
      damaged,
    }
  }
}
