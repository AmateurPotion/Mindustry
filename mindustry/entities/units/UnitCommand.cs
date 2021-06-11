// Decompiled with JetBrains decompiler
// Type: mindustry.entities.units.UnitCommand
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.units
{
  [Signature("Ljava/lang/Enum<Lmindustry/entities/units/UnitCommand;>;")]
  [Modifiers]
  [Serializable]
  public sealed class UnitCommand : Enum
  {
    [Modifiers]
    internal static UnitCommand __\u003C\u003Eattack;
    [Modifiers]
    internal static UnitCommand __\u003C\u003Erally;
    [Modifiers]
    internal static UnitCommand __\u003C\u003Eidle;
    [Modifiers]
    private string localized;
    internal static UnitCommand[] __\u003C\u003Eall;
    [Modifiers]
    private static UnitCommand[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("()V")]
    [LineNumberTable(new byte[] {159, 153, 106, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private UnitCommand([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      UnitCommand unitCommand = this;
      this.localized = Core.bundle.get(new StringBuilder().append("command.").append(this.name()).toString());
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static UnitCommand[] values() => (UnitCommand[]) UnitCommand.\u0024VALUES.Clone();

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static UnitCommand valueOf(string name) => (UnitCommand) Enum.valueOf((Class) ClassLiteral<UnitCommand>.Value, name);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string localized() => this.localized;

    [LineNumberTable(new byte[] {159, 141, 141, 63, 17, 223, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static UnitCommand()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.units.UnitCommand"))
        return;
      UnitCommand.__\u003C\u003Eattack = new UnitCommand(nameof (attack), 0);
      UnitCommand.__\u003C\u003Erally = new UnitCommand(nameof (rally), 1);
      UnitCommand.__\u003C\u003Eidle = new UnitCommand(nameof (idle), 2);
      UnitCommand.\u0024VALUES = new UnitCommand[3]
      {
        UnitCommand.__\u003C\u003Eattack,
        UnitCommand.__\u003C\u003Erally,
        UnitCommand.__\u003C\u003Eidle
      };
      UnitCommand.__\u003C\u003Eall = UnitCommand.values();
    }

    [Modifiers]
    public static UnitCommand attack
    {
      [HideFromJava] get => UnitCommand.__\u003C\u003Eattack;
    }

    [Modifiers]
    public static UnitCommand rally
    {
      [HideFromJava] get => UnitCommand.__\u003C\u003Erally;
    }

    [Modifiers]
    public static UnitCommand idle
    {
      [HideFromJava] get => UnitCommand.__\u003C\u003Eidle;
    }

    [Modifiers]
    public static UnitCommand[] all
    {
      [HideFromJava] get => UnitCommand.__\u003C\u003Eall;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      attack,
      rally,
      idle,
    }
  }
}
