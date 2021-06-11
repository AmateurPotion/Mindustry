// Decompiled with JetBrains decompiler
// Type: mindustry.ui.IconSize
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

namespace mindustry.ui
{
  [Signature("Ljava/lang/Enum<Lmindustry/ui/IconSize;>;")]
  [Modifiers]
  [Serializable]
  public sealed class IconSize : Enum
  {
    [Modifiers]
    internal static IconSize __\u003C\u003Edef;
    [Modifiers]
    internal static IconSize __\u003C\u003Esmall;
    [Modifiers]
    internal static IconSize __\u003C\u003Esmaller;
    [Modifiers]
    internal static IconSize __\u003C\u003Etiny;
    internal int __\u003C\u003Esize;
    [Modifiers]
    private static IconSize[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(I)V")]
    [LineNumberTable(new byte[] {159, 153, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private IconSize([In] string obj0, [In] int obj1, [In] int obj2)
      : base(obj0, obj1)
    {
      IconSize iconSize = this;
      this.__\u003C\u003Esize = obj2;
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static IconSize[] values() => (IconSize[]) IconSize.\u0024VALUES.Clone();

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static IconSize valueOf(string name) => (IconSize) Enum.valueOf((Class) ClassLiteral<IconSize>.Value, name);

    [LineNumberTable(new byte[] {159, 141, 77, 114, 114, 114, 242, 60})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static IconSize()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.ui.IconSize"))
        return;
      IconSize.__\u003C\u003Edef = new IconSize(nameof (def), 0, 48);
      IconSize.__\u003C\u003Esmall = new IconSize(nameof (small), 1, 32);
      IconSize.__\u003C\u003Esmaller = new IconSize(nameof (smaller), 2, 30);
      IconSize.__\u003C\u003Etiny = new IconSize(nameof (tiny), 3, 16);
      IconSize.\u0024VALUES = new IconSize[4]
      {
        IconSize.__\u003C\u003Edef,
        IconSize.__\u003C\u003Esmall,
        IconSize.__\u003C\u003Esmaller,
        IconSize.__\u003C\u003Etiny
      };
    }

    [Modifiers]
    public static IconSize def
    {
      [HideFromJava] get => IconSize.__\u003C\u003Edef;
    }

    [Modifiers]
    public static IconSize small
    {
      [HideFromJava] get => IconSize.__\u003C\u003Esmall;
    }

    [Modifiers]
    public static IconSize smaller
    {
      [HideFromJava] get => IconSize.__\u003C\u003Esmaller;
    }

    [Modifiers]
    public static IconSize tiny
    {
      [HideFromJava] get => IconSize.__\u003C\u003Etiny;
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
      def,
      small,
      smaller,
      tiny,
    }
  }
}
