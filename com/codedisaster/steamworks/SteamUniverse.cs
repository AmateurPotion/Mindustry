// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamUniverse
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

namespace com.codedisaster.steamworks
{
  [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamUniverse;>;")]
  [Modifiers]
  [Serializable]
  public sealed class SteamUniverse : Enum
  {
    [Modifiers]
    internal static SteamUniverse __\u003C\u003EInvalid;
    [Modifiers]
    internal static SteamUniverse __\u003C\u003EPublic;
    [Modifiers]
    internal static SteamUniverse __\u003C\u003EBeta;
    [Modifiers]
    internal static SteamUniverse __\u003C\u003EInternal;
    [Modifiers]
    internal static SteamUniverse __\u003C\u003EDev;
    [Modifiers]
    private int value;
    [Modifiers]
    private static SteamUniverse[] values;
    [Modifiers]
    private static SteamUniverse[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(I)V")]
    [LineNumberTable(new byte[] {159, 155, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private SteamUniverse([In] string obj0, [In] int obj1, [In] int obj2)
      : base(obj0, obj1)
    {
      SteamUniverse steamUniverse = this;
      this.value = obj2;
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SteamUniverse[] values() => (SteamUniverse[]) SteamUniverse.\u0024VALUES.Clone();

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SteamUniverse valueOf(string name) => (SteamUniverse) Enum.valueOf((Class) ClassLiteral<SteamUniverse>.Value, name);

    [LineNumberTable(new byte[] {159, 160, 115, 105, 2, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static SteamUniverse byValue([In] int obj0)
    {
      SteamUniverse[] values = SteamUniverse.values;
      int length = values.Length;
      for (int index = 0; index < length; ++index)
      {
        SteamUniverse steamUniverse = values[index];
        if (steamUniverse.value == obj0)
          return steamUniverse;
      }
      return SteamUniverse.__\u003C\u003EInvalid;
    }

    [LineNumberTable(new byte[] {159, 141, 77, 113, 113, 113, 113, 241, 59, 255, 20, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SteamUniverse()
    {
      if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamUniverse"))
        return;
      SteamUniverse.__\u003C\u003EInvalid = new SteamUniverse(nameof (Invalid), 0, 0);
      SteamUniverse.__\u003C\u003EPublic = new SteamUniverse(nameof (Public), 1, 1);
      SteamUniverse.__\u003C\u003EBeta = new SteamUniverse(nameof (Beta), 2, 2);
      SteamUniverse.__\u003C\u003EInternal = new SteamUniverse(nameof (Internal), 3, 3);
      SteamUniverse.__\u003C\u003EDev = new SteamUniverse(nameof (Dev), 4, 4);
      SteamUniverse.\u0024VALUES = new SteamUniverse[5]
      {
        SteamUniverse.__\u003C\u003EInvalid,
        SteamUniverse.__\u003C\u003EPublic,
        SteamUniverse.__\u003C\u003EBeta,
        SteamUniverse.__\u003C\u003EInternal,
        SteamUniverse.__\u003C\u003EDev
      };
      SteamUniverse.values = SteamUniverse.values();
    }

    [Modifiers]
    public static SteamUniverse Invalid
    {
      [HideFromJava] get => SteamUniverse.__\u003C\u003EInvalid;
    }

    [Modifiers]
    public static SteamUniverse Public
    {
      [HideFromJava] get => SteamUniverse.__\u003C\u003EPublic;
    }

    [Modifiers]
    public static SteamUniverse Beta
    {
      [HideFromJava] get => SteamUniverse.__\u003C\u003EBeta;
    }

    [Modifiers]
    public static SteamUniverse Internal
    {
      [HideFromJava] get => SteamUniverse.__\u003C\u003EInternal;
    }

    [Modifiers]
    public static SteamUniverse Dev
    {
      [HideFromJava] get => SteamUniverse.__\u003C\u003EDev;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      Invalid,
      Public,
      Beta,
      Internal,
      Dev,
    }
  }
}
