// Decompiled with JetBrains decompiler
// Type: mindustry.ctype.ContentType
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

namespace mindustry.ctype
{
  [Signature("Ljava/lang/Enum<Lmindustry/ctype/ContentType;>;")]
  [Modifiers]
  [Serializable]
  public sealed class ContentType : Enum
  {
    [Modifiers]
    internal static ContentType __\u003C\u003Eitem;
    [Modifiers]
    internal static ContentType __\u003C\u003Eblock;
    [Modifiers]
    internal static ContentType __\u003C\u003Emech_UNUSED;
    [Modifiers]
    internal static ContentType __\u003C\u003Ebullet;
    [Modifiers]
    internal static ContentType __\u003C\u003Eliquid;
    [Modifiers]
    internal static ContentType __\u003C\u003Estatus;
    [Modifiers]
    internal static ContentType __\u003C\u003Eunit;
    [Modifiers]
    internal static ContentType __\u003C\u003Eweather;
    [Modifiers]
    internal static ContentType __\u003C\u003Eeffect_UNUSED;
    [Modifiers]
    internal static ContentType __\u003C\u003Esector;
    [Modifiers]
    internal static ContentType __\u003C\u003Eloadout_UNUSED;
    [Modifiers]
    internal static ContentType __\u003C\u003Etypeid_UNUSED;
    [Modifiers]
    internal static ContentType __\u003C\u003Eerror;
    [Modifiers]
    internal static ContentType __\u003C\u003Eplanet;
    [Modifiers]
    internal static ContentType __\u003C\u003Eammo;
    internal static ContentType[] __\u003C\u003Eall;
    [Modifiers]
    private static ContentType[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("()V")]
    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ContentType([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ContentType[] values() => (ContentType[]) ContentType.\u0024VALUES.Clone();

    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ContentType valueOf(string name) => (ContentType) Enum.valueOf((Class) ClassLiteral<ContentType>.Value, name);

    [LineNumberTable(new byte[] {159, 141, 109, 112, 112, 112, 112, 112, 112, 112, 112, 112, 113, 113, 113, 113, 113, 241, 49, 255, 107, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ContentType()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.ctype.ContentType"))
        return;
      ContentType.__\u003C\u003Eitem = new ContentType(nameof (item), 0);
      ContentType.__\u003C\u003Eblock = new ContentType(nameof (block), 1);
      ContentType.__\u003C\u003Emech_UNUSED = new ContentType(nameof (mech_UNUSED), 2);
      ContentType.__\u003C\u003Ebullet = new ContentType(nameof (bullet), 3);
      ContentType.__\u003C\u003Eliquid = new ContentType(nameof (liquid), 4);
      ContentType.__\u003C\u003Estatus = new ContentType(nameof (status), 5);
      ContentType.__\u003C\u003Eunit = new ContentType(nameof (unit), 6);
      ContentType.__\u003C\u003Eweather = new ContentType(nameof (weather), 7);
      ContentType.__\u003C\u003Eeffect_UNUSED = new ContentType(nameof (effect_UNUSED), 8);
      ContentType.__\u003C\u003Esector = new ContentType(nameof (sector), 9);
      ContentType.__\u003C\u003Eloadout_UNUSED = new ContentType(nameof (loadout_UNUSED), 10);
      ContentType.__\u003C\u003Etypeid_UNUSED = new ContentType(nameof (typeid_UNUSED), 11);
      ContentType.__\u003C\u003Eerror = new ContentType(nameof (error), 12);
      ContentType.__\u003C\u003Eplanet = new ContentType(nameof (planet), 13);
      ContentType.__\u003C\u003Eammo = new ContentType(nameof (ammo), 14);
      ContentType.\u0024VALUES = new ContentType[15]
      {
        ContentType.__\u003C\u003Eitem,
        ContentType.__\u003C\u003Eblock,
        ContentType.__\u003C\u003Emech_UNUSED,
        ContentType.__\u003C\u003Ebullet,
        ContentType.__\u003C\u003Eliquid,
        ContentType.__\u003C\u003Estatus,
        ContentType.__\u003C\u003Eunit,
        ContentType.__\u003C\u003Eweather,
        ContentType.__\u003C\u003Eeffect_UNUSED,
        ContentType.__\u003C\u003Esector,
        ContentType.__\u003C\u003Eloadout_UNUSED,
        ContentType.__\u003C\u003Etypeid_UNUSED,
        ContentType.__\u003C\u003Eerror,
        ContentType.__\u003C\u003Eplanet,
        ContentType.__\u003C\u003Eammo
      };
      ContentType.__\u003C\u003Eall = ContentType.values();
    }

    [Modifiers]
    public static ContentType item
    {
      [HideFromJava] get => ContentType.__\u003C\u003Eitem;
    }

    [Modifiers]
    public static ContentType block
    {
      [HideFromJava] get => ContentType.__\u003C\u003Eblock;
    }

    [Modifiers]
    public static ContentType mech_UNUSED
    {
      [HideFromJava] get => ContentType.__\u003C\u003Emech_UNUSED;
    }

    [Modifiers]
    public static ContentType bullet
    {
      [HideFromJava] get => ContentType.__\u003C\u003Ebullet;
    }

    [Modifiers]
    public static ContentType liquid
    {
      [HideFromJava] get => ContentType.__\u003C\u003Eliquid;
    }

    [Modifiers]
    public static ContentType status
    {
      [HideFromJava] get => ContentType.__\u003C\u003Estatus;
    }

    [Modifiers]
    public static ContentType unit
    {
      [HideFromJava] get => ContentType.__\u003C\u003Eunit;
    }

    [Modifiers]
    public static ContentType weather
    {
      [HideFromJava] get => ContentType.__\u003C\u003Eweather;
    }

    [Modifiers]
    public static ContentType effect_UNUSED
    {
      [HideFromJava] get => ContentType.__\u003C\u003Eeffect_UNUSED;
    }

    [Modifiers]
    public static ContentType sector
    {
      [HideFromJava] get => ContentType.__\u003C\u003Esector;
    }

    [Modifiers]
    public static ContentType loadout_UNUSED
    {
      [HideFromJava] get => ContentType.__\u003C\u003Eloadout_UNUSED;
    }

    [Modifiers]
    public static ContentType typeid_UNUSED
    {
      [HideFromJava] get => ContentType.__\u003C\u003Etypeid_UNUSED;
    }

    [Modifiers]
    public static ContentType error
    {
      [HideFromJava] get => ContentType.__\u003C\u003Eerror;
    }

    [Modifiers]
    public static ContentType planet
    {
      [HideFromJava] get => ContentType.__\u003C\u003Eplanet;
    }

    [Modifiers]
    public static ContentType ammo
    {
      [HideFromJava] get => ContentType.__\u003C\u003Eammo;
    }

    [Modifiers]
    public static ContentType[] all
    {
      [HideFromJava] get => ContentType.__\u003C\u003Eall;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      item,
      block,
      mech_UNUSED,
      bullet,
      liquid,
      status,
      unit,
      weather,
      effect_UNUSED,
      sector,
      loadout_UNUSED,
      typeid_UNUSED,
      error,
      planet,
      ammo,
    }
  }
}
