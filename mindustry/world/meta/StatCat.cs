// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.StatCat
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

namespace mindustry.world.meta
{
  [Signature("Ljava/lang/Enum<Lmindustry/world/meta/StatCat;>;")]
  [Modifiers]
  [Serializable]
  public sealed class StatCat : Enum
  {
    [Modifiers]
    internal static StatCat __\u003C\u003Egeneral;
    [Modifiers]
    internal static StatCat __\u003C\u003Epower;
    [Modifiers]
    internal static StatCat __\u003C\u003Eliquids;
    [Modifiers]
    internal static StatCat __\u003C\u003Eitems;
    [Modifiers]
    internal static StatCat __\u003C\u003Ecrafting;
    [Modifiers]
    internal static StatCat __\u003C\u003Efunction;
    [Modifiers]
    internal static StatCat __\u003C\u003Eoptional;
    [Modifiers]
    private static StatCat[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("()V")]
    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private StatCat([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static StatCat[] values() => (StatCat[]) StatCat.\u0024VALUES.Clone();

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static StatCat valueOf(string name) => (StatCat) Enum.valueOf((Class) ClassLiteral<StatCat>.Value, name);

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string localized() => Core.bundle.get(new StringBuilder().append("category.").append(this.name()).toString());

    [LineNumberTable(new byte[] {159, 141, 173, 112, 112, 112, 112, 112, 112, 240, 57})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static StatCat()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.meta.StatCat"))
        return;
      StatCat.__\u003C\u003Egeneral = new StatCat(nameof (general), 0);
      StatCat.__\u003C\u003Epower = new StatCat(nameof (power), 1);
      StatCat.__\u003C\u003Eliquids = new StatCat(nameof (liquids), 2);
      StatCat.__\u003C\u003Eitems = new StatCat(nameof (items), 3);
      StatCat.__\u003C\u003Ecrafting = new StatCat(nameof (crafting), 4);
      StatCat.__\u003C\u003Efunction = new StatCat(nameof (function), 5);
      StatCat.__\u003C\u003Eoptional = new StatCat(nameof (optional), 6);
      StatCat.\u0024VALUES = new StatCat[7]
      {
        StatCat.__\u003C\u003Egeneral,
        StatCat.__\u003C\u003Epower,
        StatCat.__\u003C\u003Eliquids,
        StatCat.__\u003C\u003Eitems,
        StatCat.__\u003C\u003Ecrafting,
        StatCat.__\u003C\u003Efunction,
        StatCat.__\u003C\u003Eoptional
      };
    }

    [Modifiers]
    public static StatCat general
    {
      [HideFromJava] get => StatCat.__\u003C\u003Egeneral;
    }

    [Modifiers]
    public static StatCat power
    {
      [HideFromJava] get => StatCat.__\u003C\u003Epower;
    }

    [Modifiers]
    public static StatCat liquids
    {
      [HideFromJava] get => StatCat.__\u003C\u003Eliquids;
    }

    [Modifiers]
    public static StatCat items
    {
      [HideFromJava] get => StatCat.__\u003C\u003Eitems;
    }

    [Modifiers]
    public static StatCat crafting
    {
      [HideFromJava] get => StatCat.__\u003C\u003Ecrafting;
    }

    [Modifiers]
    public static StatCat function
    {
      [HideFromJava] get => StatCat.__\u003C\u003Efunction;
    }

    [Modifiers]
    public static StatCat optional
    {
      [HideFromJava] get => StatCat.__\u003C\u003Eoptional;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      general,
      power,
      liquids,
      items,
      crafting,
      function,
      optional,
    }
  }
}
