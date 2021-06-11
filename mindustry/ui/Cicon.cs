// Decompiled with JetBrains decompiler
// Type: mindustry.ui.Cicon
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui
{
  [Signature("Ljava/lang/Enum<Lmindustry/ui/Cicon;>;")]
  [Modifiers]
  [Serializable]
  public sealed class Cicon : Enum
  {
    [Modifiers]
    internal static Cicon __\u003C\u003Efull;
    [Modifiers]
    internal static Cicon __\u003C\u003Etiny;
    [Modifiers]
    internal static Cicon __\u003C\u003Esmall;
    [Modifiers]
    internal static Cicon __\u003C\u003Emedium;
    [Modifiers]
    internal static Cicon __\u003C\u003Elarge;
    [Modifiers]
    internal static Cicon __\u003C\u003Exlarge;
    internal static Cicon[] __\u003C\u003Eall;
    internal static Cicon[] __\u003C\u003Escaled;
    internal int __\u003C\u003Esize;
    [Modifiers]
    private static Cicon[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(I)V")]
    [LineNumberTable(new byte[] {159, 162, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Cicon([In] string obj0, [In] int obj1, [In] int obj2)
      : base(obj0, obj1)
    {
      Cicon cicon = this;
      this.__\u003C\u003Esize = obj2;
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Cicon[] values() => (Cicon[]) Cicon.\u0024VALUES.Clone();

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Cicon valueOf(string name) => (Cicon) Enum.valueOf((Class) ClassLiteral<Cicon>.Value, name);

    [LineNumberTable(new byte[] {159, 140, 77, 113, 114, 114, 114, 114, 242, 57, 255, 28, 73, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Cicon()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.ui.Cicon"))
        return;
      Cicon.__\u003C\u003Efull = new Cicon(nameof (full), 0, 0);
      Cicon.__\u003C\u003Etiny = new Cicon(nameof (tiny), 1, 16);
      Cicon.__\u003C\u003Esmall = new Cicon(nameof (small), 2, 24);
      Cicon.__\u003C\u003Emedium = new Cicon(nameof (medium), 3, 32);
      Cicon.__\u003C\u003Elarge = new Cicon(nameof (large), 4, 40);
      Cicon.__\u003C\u003Exlarge = new Cicon(nameof (xlarge), 5, 48);
      Cicon.\u0024VALUES = new Cicon[6]
      {
        Cicon.__\u003C\u003Efull,
        Cicon.__\u003C\u003Etiny,
        Cicon.__\u003C\u003Esmall,
        Cicon.__\u003C\u003Emedium,
        Cicon.__\u003C\u003Elarge,
        Cicon.__\u003C\u003Exlarge
      };
      Cicon.__\u003C\u003Eall = Cicon.values();
      Cicon.__\u003C\u003Escaled = (Cicon[]) Arrays.copyOfRange((object[]) Cicon.__\u003C\u003Eall, 1, Cicon.__\u003C\u003Eall.Length);
    }

    [Modifiers]
    public static Cicon full
    {
      [HideFromJava] get => Cicon.__\u003C\u003Efull;
    }

    [Modifiers]
    public static Cicon tiny
    {
      [HideFromJava] get => Cicon.__\u003C\u003Etiny;
    }

    [Modifiers]
    public static Cicon small
    {
      [HideFromJava] get => Cicon.__\u003C\u003Esmall;
    }

    [Modifiers]
    public static Cicon medium
    {
      [HideFromJava] get => Cicon.__\u003C\u003Emedium;
    }

    [Modifiers]
    public static Cicon large
    {
      [HideFromJava] get => Cicon.__\u003C\u003Elarge;
    }

    [Modifiers]
    public static Cicon xlarge
    {
      [HideFromJava] get => Cicon.__\u003C\u003Exlarge;
    }

    [Modifiers]
    public static Cicon[] all
    {
      [HideFromJava] get => Cicon.__\u003C\u003Eall;
    }

    [Modifiers]
    public static Cicon[] scaled
    {
      [HideFromJava] get => Cicon.__\u003C\u003Escaled;
    }

    [Modifiers]
    public int size
    {
      [HideFromJava] get => this.__\u003C\u003Esize;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Esize = value;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      full,
      tiny,
      small,
      medium,
      large,
      xlarge,
    }
  }
}
