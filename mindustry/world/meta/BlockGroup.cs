// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.BlockGroup
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

namespace mindustry.world.meta
{
  [Signature("Ljava/lang/Enum<Lmindustry/world/meta/BlockGroup;>;")]
  [Modifiers]
  [Serializable]
  public sealed class BlockGroup : Enum
  {
    [Modifiers]
    internal static BlockGroup __\u003C\u003Enone;
    [Modifiers]
    internal static BlockGroup __\u003C\u003Ewalls;
    [Modifiers]
    internal static BlockGroup __\u003C\u003Eprojectors;
    [Modifiers]
    internal static BlockGroup __\u003C\u003Eturrets;
    [Modifiers]
    internal static BlockGroup __\u003C\u003Etransportation;
    [Modifiers]
    internal static BlockGroup __\u003C\u003Epower;
    [Modifiers]
    internal static BlockGroup __\u003C\u003Eliquids;
    [Modifiers]
    internal static BlockGroup __\u003C\u003Edrills;
    [Modifiers]
    internal static BlockGroup __\u003C\u003Eunits;
    [Modifiers]
    internal static BlockGroup __\u003C\u003Elogic;
    internal bool __\u003C\u003EanyReplace;
    [Modifiers]
    private static BlockGroup[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Z)V")]
    [LineNumberTable(new byte[] {159, 140, 98, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private BlockGroup([In] string obj0, [In] int obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(obj0, obj1);
      BlockGroup blockGroup = this;
      this.__\u003C\u003EanyReplace = num != 0;
      GC.KeepAlive((object) this);
    }

    [Signature("()V")]
    [LineNumberTable(new byte[] {159, 156, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private BlockGroup([In] string obj0, [In] int obj1)
      : this(obj0, obj1, false)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static BlockGroup[] values() => (BlockGroup[]) BlockGroup.\u0024VALUES.Clone();

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static BlockGroup valueOf(string name) => (BlockGroup) Enum.valueOf((Class) ClassLiteral<BlockGroup>.Value, name);

    [LineNumberTable(new byte[] {159, 141, 77, 63, 160, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static BlockGroup()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.meta.BlockGroup"))
        return;
      BlockGroup.__\u003C\u003Enone = new BlockGroup(nameof (none), 0);
      BlockGroup.__\u003C\u003Ewalls = new BlockGroup(nameof (walls), 1, true);
      BlockGroup.__\u003C\u003Eprojectors = new BlockGroup(nameof (projectors), 2, true);
      BlockGroup.__\u003C\u003Eturrets = new BlockGroup(nameof (turrets), 3, true);
      BlockGroup.__\u003C\u003Etransportation = new BlockGroup(nameof (transportation), 4, true);
      BlockGroup.__\u003C\u003Epower = new BlockGroup(nameof (power), 5);
      BlockGroup.__\u003C\u003Eliquids = new BlockGroup(nameof (liquids), 6, true);
      BlockGroup.__\u003C\u003Edrills = new BlockGroup(nameof (drills), 7);
      BlockGroup.__\u003C\u003Eunits = new BlockGroup(nameof (units), 8);
      BlockGroup.__\u003C\u003Elogic = new BlockGroup(nameof (logic), 9, true);
      BlockGroup.\u0024VALUES = new BlockGroup[10]
      {
        BlockGroup.__\u003C\u003Enone,
        BlockGroup.__\u003C\u003Ewalls,
        BlockGroup.__\u003C\u003Eprojectors,
        BlockGroup.__\u003C\u003Eturrets,
        BlockGroup.__\u003C\u003Etransportation,
        BlockGroup.__\u003C\u003Epower,
        BlockGroup.__\u003C\u003Eliquids,
        BlockGroup.__\u003C\u003Edrills,
        BlockGroup.__\u003C\u003Eunits,
        BlockGroup.__\u003C\u003Elogic
      };
    }

    [Modifiers]
    public static BlockGroup none
    {
      [HideFromJava] get => BlockGroup.__\u003C\u003Enone;
    }

    [Modifiers]
    public static BlockGroup walls
    {
      [HideFromJava] get => BlockGroup.__\u003C\u003Ewalls;
    }

    [Modifiers]
    public static BlockGroup projectors
    {
      [HideFromJava] get => BlockGroup.__\u003C\u003Eprojectors;
    }

    [Modifiers]
    public static BlockGroup turrets
    {
      [HideFromJava] get => BlockGroup.__\u003C\u003Eturrets;
    }

    [Modifiers]
    public static BlockGroup transportation
    {
      [HideFromJava] get => BlockGroup.__\u003C\u003Etransportation;
    }

    [Modifiers]
    public static BlockGroup power
    {
      [HideFromJava] get => BlockGroup.__\u003C\u003Epower;
    }

    [Modifiers]
    public static BlockGroup liquids
    {
      [HideFromJava] get => BlockGroup.__\u003C\u003Eliquids;
    }

    [Modifiers]
    public static BlockGroup drills
    {
      [HideFromJava] get => BlockGroup.__\u003C\u003Edrills;
    }

    [Modifiers]
    public static BlockGroup units
    {
      [HideFromJava] get => BlockGroup.__\u003C\u003Eunits;
    }

    [Modifiers]
    public static BlockGroup logic
    {
      [HideFromJava] get => BlockGroup.__\u003C\u003Elogic;
    }

    [Modifiers]
    public bool anyReplace
    {
      [HideFromJava] get => this.__\u003C\u003EanyReplace;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EanyReplace = value;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      none,
      walls,
      projectors,
      turrets,
      transportation,
      power,
      liquids,
      drills,
      units,
      logic,
    }
  }
}
