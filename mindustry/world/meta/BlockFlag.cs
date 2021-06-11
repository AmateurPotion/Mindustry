// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.BlockFlag
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
  [Signature("Ljava/lang/Enum<Lmindustry/world/meta/BlockFlag;>;")]
  [Modifiers]
  [Serializable]
  public sealed class BlockFlag : Enum
  {
    [Modifiers]
    internal static BlockFlag __\u003C\u003Ecore;
    [Modifiers]
    internal static BlockFlag __\u003C\u003Estorage;
    [Modifiers]
    internal static BlockFlag __\u003C\u003Egenerator;
    [Modifiers]
    internal static BlockFlag __\u003C\u003Eturret;
    [Modifiers]
    internal static BlockFlag __\u003C\u003Efactory;
    [Modifiers]
    internal static BlockFlag __\u003C\u003Erepair;
    [Modifiers]
    internal static BlockFlag __\u003C\u003Erally;
    [Modifiers]
    internal static BlockFlag __\u003C\u003Ebattery;
    [Modifiers]
    internal static BlockFlag __\u003C\u003Eresupply;
    [Modifiers]
    internal static BlockFlag __\u003C\u003Ereactor;
    [Modifiers]
    internal static BlockFlag __\u003C\u003EunitModifier;
    [Modifiers]
    internal static BlockFlag __\u003C\u003Eextinguisher;
    internal static BlockFlag[] __\u003C\u003Eall;
    internal static BlockFlag[] __\u003C\u003EallLogic;
    [Modifiers]
    private static BlockFlag[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static BlockFlag valueOf(string name) => (BlockFlag) Enum.valueOf((Class) ClassLiteral<BlockFlag>.Value, name);

    [Signature("()V")]
    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private BlockFlag([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static BlockFlag[] values() => (BlockFlag[]) BlockFlag.\u0024VALUES.Clone();

    [LineNumberTable(new byte[] {159, 141, 141, 144, 144, 144, 144, 144, 144, 144, 144, 144, 145, 145, 241, 40, 255, 80, 90, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static BlockFlag()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.meta.BlockFlag"))
        return;
      BlockFlag.__\u003C\u003Ecore = new BlockFlag(nameof (core), 0);
      BlockFlag.__\u003C\u003Estorage = new BlockFlag(nameof (storage), 1);
      BlockFlag.__\u003C\u003Egenerator = new BlockFlag(nameof (generator), 2);
      BlockFlag.__\u003C\u003Eturret = new BlockFlag(nameof (turret), 3);
      BlockFlag.__\u003C\u003Efactory = new BlockFlag(nameof (factory), 4);
      BlockFlag.__\u003C\u003Erepair = new BlockFlag(nameof (repair), 5);
      BlockFlag.__\u003C\u003Erally = new BlockFlag(nameof (rally), 6);
      BlockFlag.__\u003C\u003Ebattery = new BlockFlag(nameof (battery), 7);
      BlockFlag.__\u003C\u003Eresupply = new BlockFlag(nameof (resupply), 8);
      BlockFlag.__\u003C\u003Ereactor = new BlockFlag(nameof (reactor), 9);
      BlockFlag.__\u003C\u003EunitModifier = new BlockFlag(nameof (unitModifier), 10);
      BlockFlag.__\u003C\u003Eextinguisher = new BlockFlag(nameof (extinguisher), 11);
      BlockFlag.\u0024VALUES = new BlockFlag[12]
      {
        BlockFlag.__\u003C\u003Ecore,
        BlockFlag.__\u003C\u003Estorage,
        BlockFlag.__\u003C\u003Egenerator,
        BlockFlag.__\u003C\u003Eturret,
        BlockFlag.__\u003C\u003Efactory,
        BlockFlag.__\u003C\u003Erepair,
        BlockFlag.__\u003C\u003Erally,
        BlockFlag.__\u003C\u003Ebattery,
        BlockFlag.__\u003C\u003Eresupply,
        BlockFlag.__\u003C\u003Ereactor,
        BlockFlag.__\u003C\u003EunitModifier,
        BlockFlag.__\u003C\u003Eextinguisher
      };
      BlockFlag.__\u003C\u003Eall = BlockFlag.values();
      BlockFlag.__\u003C\u003EallLogic = new BlockFlag[10]
      {
        BlockFlag.__\u003C\u003Ecore,
        BlockFlag.__\u003C\u003Estorage,
        BlockFlag.__\u003C\u003Egenerator,
        BlockFlag.__\u003C\u003Eturret,
        BlockFlag.__\u003C\u003Efactory,
        BlockFlag.__\u003C\u003Erepair,
        BlockFlag.__\u003C\u003Erally,
        BlockFlag.__\u003C\u003Ebattery,
        BlockFlag.__\u003C\u003Eresupply,
        BlockFlag.__\u003C\u003Ereactor
      };
    }

    [Modifiers]
    public static BlockFlag core
    {
      [HideFromJava] get => BlockFlag.__\u003C\u003Ecore;
    }

    [Modifiers]
    public static BlockFlag storage
    {
      [HideFromJava] get => BlockFlag.__\u003C\u003Estorage;
    }

    [Modifiers]
    public static BlockFlag generator
    {
      [HideFromJava] get => BlockFlag.__\u003C\u003Egenerator;
    }

    [Modifiers]
    public static BlockFlag turret
    {
      [HideFromJava] get => BlockFlag.__\u003C\u003Eturret;
    }

    [Modifiers]
    public static BlockFlag factory
    {
      [HideFromJava] get => BlockFlag.__\u003C\u003Efactory;
    }

    [Modifiers]
    public static BlockFlag repair
    {
      [HideFromJava] get => BlockFlag.__\u003C\u003Erepair;
    }

    [Modifiers]
    public static BlockFlag rally
    {
      [HideFromJava] get => BlockFlag.__\u003C\u003Erally;
    }

    [Modifiers]
    public static BlockFlag battery
    {
      [HideFromJava] get => BlockFlag.__\u003C\u003Ebattery;
    }

    [Modifiers]
    public static BlockFlag resupply
    {
      [HideFromJava] get => BlockFlag.__\u003C\u003Eresupply;
    }

    [Modifiers]
    public static BlockFlag reactor
    {
      [HideFromJava] get => BlockFlag.__\u003C\u003Ereactor;
    }

    [Modifiers]
    public static BlockFlag unitModifier
    {
      [HideFromJava] get => BlockFlag.__\u003C\u003EunitModifier;
    }

    [Modifiers]
    public static BlockFlag extinguisher
    {
      [HideFromJava] get => BlockFlag.__\u003C\u003Eextinguisher;
    }

    [Modifiers]
    public static BlockFlag[] all
    {
      [HideFromJava] get => BlockFlag.__\u003C\u003Eall;
    }

    [Modifiers]
    public static BlockFlag[] allLogic
    {
      [HideFromJava] get => BlockFlag.__\u003C\u003EallLogic;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      core,
      storage,
      generator,
      turret,
      factory,
      repair,
      rally,
      battery,
      resupply,
      reactor,
      unitModifier,
      extinguisher,
    }
  }
}
