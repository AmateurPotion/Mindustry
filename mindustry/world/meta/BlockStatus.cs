// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.BlockStatus
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.graphics;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.meta
{
  [Signature("Ljava/lang/Enum<Lmindustry/world/meta/BlockStatus;>;")]
  [Modifiers]
  [Serializable]
  public sealed class BlockStatus : Enum
  {
    [Modifiers]
    internal static BlockStatus __\u003C\u003Eactive;
    [Modifiers]
    internal static BlockStatus __\u003C\u003EnoOutput;
    [Modifiers]
    internal static BlockStatus __\u003C\u003EnoInput;
    internal Color __\u003C\u003Ecolor;
    [Modifiers]
    private static BlockStatus[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Larc/graphics/Color;)V")]
    [LineNumberTable(new byte[] {159, 155, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private BlockStatus([In] string obj0, [In] int obj1, [In] Color obj2)
      : base(obj0, obj1)
    {
      BlockStatus blockStatus = this;
      this.__\u003C\u003Ecolor = obj2;
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static BlockStatus[] values() => (BlockStatus[]) BlockStatus.\u0024VALUES.Clone();

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static BlockStatus valueOf(string name) => (BlockStatus) Enum.valueOf((Class) ClassLiteral<BlockStatus>.Value, name);

    [LineNumberTable(new byte[] {159, 141, 173, 122, 117, 245, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static BlockStatus()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.meta.BlockStatus"))
        return;
      BlockStatus.__\u003C\u003Eactive = new BlockStatus(nameof (active), 0, Color.valueOf("5ce677"));
      BlockStatus.__\u003C\u003EnoOutput = new BlockStatus(nameof (noOutput), 1, Color.__\u003C\u003Eorange);
      BlockStatus.__\u003C\u003EnoInput = new BlockStatus(nameof (noInput), 2, Pal.remove);
      BlockStatus.\u0024VALUES = new BlockStatus[3]
      {
        BlockStatus.__\u003C\u003Eactive,
        BlockStatus.__\u003C\u003EnoOutput,
        BlockStatus.__\u003C\u003EnoInput
      };
    }

    [Modifiers]
    public static BlockStatus active
    {
      [HideFromJava] get => BlockStatus.__\u003C\u003Eactive;
    }

    [Modifiers]
    public static BlockStatus noOutput
    {
      [HideFromJava] get => BlockStatus.__\u003C\u003EnoOutput;
    }

    [Modifiers]
    public static BlockStatus noInput
    {
      [HideFromJava] get => BlockStatus.__\u003C\u003EnoInput;
    }

    [Modifiers]
    public Color color
    {
      [HideFromJava] get => this.__\u003C\u003Ecolor;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ecolor = value;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      active,
      noOutput,
      noInput,
    }
  }
}
