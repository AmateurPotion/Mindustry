// Decompiled with JetBrains decompiler
// Type: mindustry.type.Category
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

namespace mindustry.type
{
  [Signature("Ljava/lang/Enum<Lmindustry/type/Category;>;")]
  [Modifiers]
  [Serializable]
  public sealed class Category : Enum
  {
    [Modifiers]
    internal static Category __\u003C\u003Eturret;
    [Modifiers]
    internal static Category __\u003C\u003Eproduction;
    [Modifiers]
    internal static Category __\u003C\u003Edistribution;
    [Modifiers]
    internal static Category __\u003C\u003Eliquid;
    [Modifiers]
    internal static Category __\u003C\u003Epower;
    [Modifiers]
    internal static Category __\u003C\u003Edefense;
    [Modifiers]
    internal static Category __\u003C\u003Ecrafting;
    [Modifiers]
    internal static Category __\u003C\u003Eunits;
    [Modifiers]
    internal static Category __\u003C\u003Eeffect;
    [Modifiers]
    internal static Category __\u003C\u003Elogic;
    internal static Category[] __\u003C\u003Eall;
    [Modifiers]
    private static Category[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("()V")]
    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Category([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Category[] values() => (Category[]) Category.\u0024VALUES.Clone();

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Category valueOf(string name) => (Category) Enum.valueOf((Class) ClassLiteral<Category>.Value, name);

    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Category prev()
    {
      Category[] all = Category.__\u003C\u003Eall;
      int num = this.ordinal() - 1 + Category.__\u003C\u003Eall.Length;
      int length = Category.__\u003C\u003Eall.Length;
      int index = length != -1 ? num % length : 0;
      return all[index];
    }

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Category next()
    {
      Category[] all = Category.__\u003C\u003Eall;
      int num = this.ordinal() + 1;
      int length = Category.__\u003C\u003Eall.Length;
      int index = length != -1 ? num % length : 0;
      return all[index];
    }

    [LineNumberTable(new byte[] {159, 141, 109, 144, 144, 144, 144, 144, 144, 144, 144, 144, 241, 44, 255, 62, 86})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Category()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.type.Category"))
        return;
      Category.__\u003C\u003Eturret = new Category(nameof (turret), 0);
      Category.__\u003C\u003Eproduction = new Category(nameof (production), 1);
      Category.__\u003C\u003Edistribution = new Category(nameof (distribution), 2);
      Category.__\u003C\u003Eliquid = new Category(nameof (liquid), 3);
      Category.__\u003C\u003Epower = new Category(nameof (power), 4);
      Category.__\u003C\u003Edefense = new Category(nameof (defense), 5);
      Category.__\u003C\u003Ecrafting = new Category(nameof (crafting), 6);
      Category.__\u003C\u003Eunits = new Category(nameof (units), 7);
      Category.__\u003C\u003Eeffect = new Category(nameof (effect), 8);
      Category.__\u003C\u003Elogic = new Category(nameof (logic), 9);
      Category.\u0024VALUES = new Category[10]
      {
        Category.__\u003C\u003Eturret,
        Category.__\u003C\u003Eproduction,
        Category.__\u003C\u003Edistribution,
        Category.__\u003C\u003Eliquid,
        Category.__\u003C\u003Epower,
        Category.__\u003C\u003Edefense,
        Category.__\u003C\u003Ecrafting,
        Category.__\u003C\u003Eunits,
        Category.__\u003C\u003Eeffect,
        Category.__\u003C\u003Elogic
      };
      Category.__\u003C\u003Eall = Category.values();
    }

    [Modifiers]
    public static Category turret
    {
      [HideFromJava] get => Category.__\u003C\u003Eturret;
    }

    [Modifiers]
    public static Category production
    {
      [HideFromJava] get => Category.__\u003C\u003Eproduction;
    }

    [Modifiers]
    public static Category distribution
    {
      [HideFromJava] get => Category.__\u003C\u003Edistribution;
    }

    [Modifiers]
    public static Category liquid
    {
      [HideFromJava] get => Category.__\u003C\u003Eliquid;
    }

    [Modifiers]
    public static Category power
    {
      [HideFromJava] get => Category.__\u003C\u003Epower;
    }

    [Modifiers]
    public static Category defense
    {
      [HideFromJava] get => Category.__\u003C\u003Edefense;
    }

    [Modifiers]
    public static Category crafting
    {
      [HideFromJava] get => Category.__\u003C\u003Ecrafting;
    }

    [Modifiers]
    public static Category units
    {
      [HideFromJava] get => Category.__\u003C\u003Eunits;
    }

    [Modifiers]
    public static Category effect
    {
      [HideFromJava] get => Category.__\u003C\u003Eeffect;
    }

    [Modifiers]
    public static Category logic
    {
      [HideFromJava] get => Category.__\u003C\u003Elogic;
    }

    [Modifiers]
    public static Category[] all
    {
      [HideFromJava] get => Category.__\u003C\u003Eall;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      turret,
      production,
      distribution,
      liquid,
      power,
      defense,
      crafting,
      units,
      effect,
      logic,
    }
  }
}
