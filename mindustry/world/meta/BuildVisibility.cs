// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.BuildVisibility
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.meta
{
  [Signature("Ljava/lang/Enum<Lmindustry/world/meta/BuildVisibility;>;")]
  [Modifiers]
  [Serializable]
  public sealed class BuildVisibility : Enum
  {
    [Modifiers]
    internal static BuildVisibility __\u003C\u003Ehidden;
    [Modifiers]
    internal static BuildVisibility __\u003C\u003Eshown;
    [Modifiers]
    internal static BuildVisibility __\u003C\u003EdebugOnly;
    [Modifiers]
    internal static BuildVisibility __\u003C\u003EeditorOnly;
    [Modifiers]
    internal static BuildVisibility __\u003C\u003EsandboxOnly;
    [Modifiers]
    internal static BuildVisibility __\u003C\u003EcampaignOnly;
    [Modifiers]
    internal static BuildVisibility __\u003C\u003ElightingOnly;
    [Modifiers]
    internal static BuildVisibility __\u003C\u003EammoOnly;
    [Modifiers]
    private Boolp visible;
    [Modifiers]
    private static BuildVisibility[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool visible() => this.visible.get();

    [Signature("(Larc/func/Boolp;)V")]
    [LineNumberTable(new byte[] {159, 164, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private BuildVisibility([In] string obj0, [In] int obj1, [In] Boolp obj2)
      : base(obj0, obj1)
    {
      BuildVisibility buildVisibility = this;
      this.visible = obj2;
      GC.KeepAlive((object) this);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00240() => false;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00241() => true;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00242() => false;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00243() => false;

    [Modifiers]
    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00244() => Vars.state == null || Vars.state.rules.infiniteResources;

    [Modifiers]
    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00245() => Vars.state == null || Vars.state.isCampaign();

    [Modifiers]
    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00246() => Vars.state == null || Vars.state.rules.lighting || Vars.state.isCampaign();

    [Modifiers]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00247() => Vars.state == null || Vars.state.rules.unitAmmo;

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static BuildVisibility[] values() => (BuildVisibility[]) BuildVisibility.\u0024VALUES.Clone();

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static BuildVisibility valueOf(string name) => (BuildVisibility) Enum.valueOf((Class) ClassLiteral<BuildVisibility>.Value, name);

    [LineNumberTable(new byte[] {159, 141, 173, 122, 122, 122, 122, 122, 122, 122, 250, 56})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static BuildVisibility()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.meta.BuildVisibility"))
        return;
      BuildVisibility.__\u003C\u003Ehidden = new BuildVisibility(nameof (hidden), 0, (Boolp) new BuildVisibility.__\u003C\u003EAnon0());
      BuildVisibility.__\u003C\u003Eshown = new BuildVisibility(nameof (shown), 1, (Boolp) new BuildVisibility.__\u003C\u003EAnon1());
      BuildVisibility.__\u003C\u003EdebugOnly = new BuildVisibility(nameof (debugOnly), 2, (Boolp) new BuildVisibility.__\u003C\u003EAnon2());
      BuildVisibility.__\u003C\u003EeditorOnly = new BuildVisibility(nameof (editorOnly), 3, (Boolp) new BuildVisibility.__\u003C\u003EAnon3());
      BuildVisibility.__\u003C\u003EsandboxOnly = new BuildVisibility(nameof (sandboxOnly), 4, (Boolp) new BuildVisibility.__\u003C\u003EAnon4());
      BuildVisibility.__\u003C\u003EcampaignOnly = new BuildVisibility(nameof (campaignOnly), 5, (Boolp) new BuildVisibility.__\u003C\u003EAnon5());
      BuildVisibility.__\u003C\u003ElightingOnly = new BuildVisibility(nameof (lightingOnly), 6, (Boolp) new BuildVisibility.__\u003C\u003EAnon6());
      BuildVisibility.__\u003C\u003EammoOnly = new BuildVisibility(nameof (ammoOnly), 7, (Boolp) new BuildVisibility.__\u003C\u003EAnon7());
      BuildVisibility.\u0024VALUES = new BuildVisibility[8]
      {
        BuildVisibility.__\u003C\u003Ehidden,
        BuildVisibility.__\u003C\u003Eshown,
        BuildVisibility.__\u003C\u003EdebugOnly,
        BuildVisibility.__\u003C\u003EeditorOnly,
        BuildVisibility.__\u003C\u003EsandboxOnly,
        BuildVisibility.__\u003C\u003EcampaignOnly,
        BuildVisibility.__\u003C\u003ElightingOnly,
        BuildVisibility.__\u003C\u003EammoOnly
      };
    }

    [Modifiers]
    public static BuildVisibility hidden
    {
      [HideFromJava] get => BuildVisibility.__\u003C\u003Ehidden;
    }

    [Modifiers]
    public static BuildVisibility shown
    {
      [HideFromJava] get => BuildVisibility.__\u003C\u003Eshown;
    }

    [Modifiers]
    public static BuildVisibility debugOnly
    {
      [HideFromJava] get => BuildVisibility.__\u003C\u003EdebugOnly;
    }

    [Modifiers]
    public static BuildVisibility editorOnly
    {
      [HideFromJava] get => BuildVisibility.__\u003C\u003EeditorOnly;
    }

    [Modifiers]
    public static BuildVisibility sandboxOnly
    {
      [HideFromJava] get => BuildVisibility.__\u003C\u003EsandboxOnly;
    }

    [Modifiers]
    public static BuildVisibility campaignOnly
    {
      [HideFromJava] get => BuildVisibility.__\u003C\u003EcampaignOnly;
    }

    [Modifiers]
    public static BuildVisibility lightingOnly
    {
      [HideFromJava] get => BuildVisibility.__\u003C\u003ElightingOnly;
    }

    [Modifiers]
    public static BuildVisibility ammoOnly
    {
      [HideFromJava] get => BuildVisibility.__\u003C\u003EammoOnly;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      hidden,
      shown,
      debugOnly,
      editorOnly,
      sandboxOnly,
      campaignOnly,
      lightingOnly,
      ammoOnly,
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolp
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get() => (BuildVisibility.lambda\u0024static\u00240() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolp
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get() => (BuildVisibility.lambda\u0024static\u00241() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolp
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool get() => (BuildVisibility.lambda\u0024static\u00242() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolp
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public bool get() => (BuildVisibility.lambda\u0024static\u00243() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Boolp
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public bool get() => (BuildVisibility.lambda\u0024static\u00244() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Boolp
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public bool get() => (BuildVisibility.lambda\u0024static\u00245() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Boolp
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public bool get() => (BuildVisibility.lambda\u0024static\u00246() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Boolp
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public bool get() => (BuildVisibility.lambda\u0024static\u00247() ? 1 : 0) != 0;
    }
  }
}
