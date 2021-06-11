// Decompiled with JetBrains decompiler
// Type: mindustry.world.consumers.ConsumeType
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

namespace mindustry.world.consumers
{
  [Signature("Ljava/lang/Enum<Lmindustry/world/consumers/ConsumeType;>;")]
  [Modifiers]
  [Serializable]
  public sealed class ConsumeType : Enum
  {
    [Modifiers]
    internal static ConsumeType __\u003C\u003Eitem;
    [Modifiers]
    internal static ConsumeType __\u003C\u003Epower;
    [Modifiers]
    internal static ConsumeType __\u003C\u003Eliquid;
    [Modifiers]
    private static ConsumeType[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("()V")]
    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ConsumeType([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ConsumeType[] values() => (ConsumeType[]) ConsumeType.\u0024VALUES.Clone();

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ConsumeType valueOf(string name) => (ConsumeType) Enum.valueOf((Class) ClassLiteral<ConsumeType>.Value, name);

    [LineNumberTable(new byte[] {159, 141, 77, 112, 112, 240, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ConsumeType()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.consumers.ConsumeType"))
        return;
      ConsumeType.__\u003C\u003Eitem = new ConsumeType(nameof (item), 0);
      ConsumeType.__\u003C\u003Epower = new ConsumeType(nameof (power), 1);
      ConsumeType.__\u003C\u003Eliquid = new ConsumeType(nameof (liquid), 2);
      ConsumeType.\u0024VALUES = new ConsumeType[3]
      {
        ConsumeType.__\u003C\u003Eitem,
        ConsumeType.__\u003C\u003Epower,
        ConsumeType.__\u003C\u003Eliquid
      };
    }

    [Modifiers]
    public static ConsumeType item
    {
      [HideFromJava] get => ConsumeType.__\u003C\u003Eitem;
    }

    [Modifiers]
    public static ConsumeType power
    {
      [HideFromJava] get => ConsumeType.__\u003C\u003Epower;
    }

    [Modifiers]
    public static ConsumeType liquid
    {
      [HideFromJava] get => ConsumeType.__\u003C\u003Eliquid;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      item,
      power,
      liquid,
    }
  }
}
