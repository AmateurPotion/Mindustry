// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.Attribute
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
  [Signature("Ljava/lang/Enum<Lmindustry/world/meta/Attribute;>;")]
  [Modifiers]
  [Serializable]
  public sealed class Attribute : Enum
  {
    [Modifiers]
    internal static Attribute __\u003C\u003Eheat;
    [Modifiers]
    internal static Attribute __\u003C\u003Espores;
    [Modifiers]
    internal static Attribute __\u003C\u003Ewater;
    [Modifiers]
    internal static Attribute __\u003C\u003Eoil;
    [Modifiers]
    internal static Attribute __\u003C\u003Elight;
    internal static Attribute[] __\u003C\u003Eall;
    [Modifiers]
    private static Attribute[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 163, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float env() => Vars.state == null ? 0.0f : Vars.state.envAttrs.get(this);

    [Signature("()V")]
    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Attribute([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Attribute[] values() => (Attribute[]) Attribute.\u0024VALUES.Clone();

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Attribute valueOf(string name) => (Attribute) Enum.valueOf((Class) ClassLiteral<Attribute>.Value, name);

    [LineNumberTable(new byte[] {159, 141, 173, 144, 144, 144, 144, 240, 54, 255, 20, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Attribute()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.meta.Attribute"))
        return;
      Attribute.__\u003C\u003Eheat = new Attribute(nameof (heat), 0);
      Attribute.__\u003C\u003Espores = new Attribute(nameof (spores), 1);
      Attribute.__\u003C\u003Ewater = new Attribute(nameof (water), 2);
      Attribute.__\u003C\u003Eoil = new Attribute(nameof (oil), 3);
      Attribute.__\u003C\u003Elight = new Attribute(nameof (light), 4);
      Attribute.\u0024VALUES = new Attribute[5]
      {
        Attribute.__\u003C\u003Eheat,
        Attribute.__\u003C\u003Espores,
        Attribute.__\u003C\u003Ewater,
        Attribute.__\u003C\u003Eoil,
        Attribute.__\u003C\u003Elight
      };
      Attribute.__\u003C\u003Eall = Attribute.values();
    }

    [Modifiers]
    public static Attribute heat
    {
      [HideFromJava] get => Attribute.__\u003C\u003Eheat;
    }

    [Modifiers]
    public static Attribute spores
    {
      [HideFromJava] get => Attribute.__\u003C\u003Espores;
    }

    [Modifiers]
    public static Attribute water
    {
      [HideFromJava] get => Attribute.__\u003C\u003Ewater;
    }

    [Modifiers]
    public static Attribute oil
    {
      [HideFromJava] get => Attribute.__\u003C\u003Eoil;
    }

    [Modifiers]
    public static Attribute light
    {
      [HideFromJava] get => Attribute.__\u003C\u003Elight;
    }

    [Modifiers]
    public static Attribute[] all
    {
      [HideFromJava] get => Attribute.__\u003C\u003Eall;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      heat,
      spores,
      water,
      oil,
      light,
    }
  }
}
