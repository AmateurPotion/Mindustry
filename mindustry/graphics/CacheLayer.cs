// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.CacheLayer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics;
using arc.graphics.gl;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics
{
  [Signature("Ljava/lang/Enum<Lmindustry/graphics/CacheLayer;>;")]
  [Modifiers]
  [Serializable]
  public class CacheLayer : Enum
  {
    [Modifiers]
    internal static CacheLayer __\u003C\u003Ewater;
    [Modifiers]
    internal static CacheLayer __\u003C\u003Emud;
    [Modifiers]
    internal static CacheLayer __\u003C\u003Etar;
    [Modifiers]
    internal static CacheLayer __\u003C\u003Eslag;
    [Modifiers]
    internal static CacheLayer __\u003C\u003Espace;
    [Modifiers]
    internal static CacheLayer __\u003C\u003Enormal;
    [Modifiers]
    internal static CacheLayer __\u003C\u003Ewalls;
    internal static CacheLayer[] __\u003C\u003Eall;
    [Modifiers]
    private static CacheLayer[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("()V")]
    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private CacheLayer([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static CacheLayer[] values() => (CacheLayer[]) CacheLayer.\u0024VALUES.Clone();

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static CacheLayer valueOf(string name) => (CacheLayer) Enum.valueOf((Class) ClassLiteral<CacheLayer>.Value, name);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void begin()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void end()
    {
    }

    [LineNumberTable(new byte[] {29, 146, 116, 111, 111, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void beginShader()
    {
      if (!Core.settings.getBool("animatedwater"))
        return;
      Vars.renderer.__\u003C\u003Eblocks.__\u003C\u003Efloor.endc();
      Vars.renderer.effectBuffer.begin();
      Core.graphics.clear(Color.__\u003C\u003Eclear);
      Vars.renderer.__\u003C\u003Eblocks.__\u003C\u003Efloor.beginc();
    }

    [LineNumberTable(new byte[] {38, 146, 116, 143, 144, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void endShader([In] Shader obj0)
    {
      if (!Core.settings.getBool("animatedwater"))
        return;
      Vars.renderer.__\u003C\u003Eblocks.__\u003C\u003Efloor.endc();
      Vars.renderer.effectBuffer.end();
      Vars.renderer.effectBuffer.blit(obj0);
      Vars.renderer.__\u003C\u003Eblocks.__\u003C\u003Efloor.beginc();
    }

    [Modifiers]
    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal CacheLayer([In] string obj0, [In] int obj1, [In] CacheLayer.\u0031 obj2)
      : this(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {159, 140, 141, 240, 75, 240, 75, 240, 75, 240, 75, 240, 75, 112, 240, 7, 255, 36, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static CacheLayer()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.graphics.CacheLayer"))
        return;
      CacheLayer.__\u003C\u003Ewater = (CacheLayer) new CacheLayer.\u0031(nameof (water), 0);
      CacheLayer.__\u003C\u003Emud = (CacheLayer) new CacheLayer.\u0032(nameof (mud), 1);
      CacheLayer.__\u003C\u003Etar = (CacheLayer) new CacheLayer.\u0033(nameof (tar), 2);
      CacheLayer.__\u003C\u003Eslag = (CacheLayer) new CacheLayer.\u0034(nameof (slag), 3);
      CacheLayer.__\u003C\u003Espace = (CacheLayer) new CacheLayer.\u0035(nameof (space), 4);
      CacheLayer.__\u003C\u003Enormal = new CacheLayer(nameof (normal), 5);
      CacheLayer.__\u003C\u003Ewalls = new CacheLayer(nameof (walls), 6);
      CacheLayer.\u0024VALUES = new CacheLayer[7]
      {
        CacheLayer.__\u003C\u003Ewater,
        CacheLayer.__\u003C\u003Emud,
        CacheLayer.__\u003C\u003Etar,
        CacheLayer.__\u003C\u003Eslag,
        CacheLayer.__\u003C\u003Espace,
        CacheLayer.__\u003C\u003Enormal,
        CacheLayer.__\u003C\u003Ewalls
      };
      CacheLayer.__\u003C\u003Eall = CacheLayer.values();
    }

    [Modifiers]
    public static CacheLayer water
    {
      [HideFromJava] get => CacheLayer.__\u003C\u003Ewater;
    }

    [Modifiers]
    public static CacheLayer mud
    {
      [HideFromJava] get => CacheLayer.__\u003C\u003Emud;
    }

    [Modifiers]
    public static CacheLayer tar
    {
      [HideFromJava] get => CacheLayer.__\u003C\u003Etar;
    }

    [Modifiers]
    public static CacheLayer slag
    {
      [HideFromJava] get => CacheLayer.__\u003C\u003Eslag;
    }

    [Modifiers]
    public static CacheLayer space
    {
      [HideFromJava] get => CacheLayer.__\u003C\u003Espace;
    }

    [Modifiers]
    public static CacheLayer normal
    {
      [HideFromJava] get => CacheLayer.__\u003C\u003Enormal;
    }

    [Modifiers]
    public static CacheLayer walls
    {
      [HideFromJava] get => CacheLayer.__\u003C\u003Ewalls;
    }

    [Modifiers]
    public static CacheLayer[] all
    {
      [HideFromJava] get => CacheLayer.__\u003C\u003Eall;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      water,
      mud,
      tar,
      slag,
      space,
      normal,
      walls,
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [Serializable]
    [SpecialName]
    internal sealed class \u0031 : CacheLayer
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(10)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] string obj0, [In] int obj1)
        : base(obj0, obj1, (CacheLayer.\u0031) null)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(new byte[] {159, 155, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void begin() => this.beginShader();

      [LineNumberTable(new byte[] {159, 160, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void end() => this.endShader((Shader) Shaders.water);

      [HideFromJava]
      static \u0031() => CacheLayer.__\u003Cclinit\u003E();
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [Serializable]
    [SpecialName]
    internal sealed class \u0032 : CacheLayer
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(21)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] string obj0, [In] int obj1)
        : base(obj0, obj1, (CacheLayer.\u0031) null)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(new byte[] {159, 166, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void begin() => this.beginShader();

      [LineNumberTable(new byte[] {159, 171, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void end() => this.endShader((Shader) Shaders.mud);

      [HideFromJava]
      static \u0032() => CacheLayer.__\u003Cclinit\u003E();
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [Serializable]
    [SpecialName]
    internal sealed class \u0033 : CacheLayer
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(32)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] string obj0, [In] int obj1)
        : base(obj0, obj1, (CacheLayer.\u0031) null)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(new byte[] {159, 177, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void begin() => this.beginShader();

      [LineNumberTable(new byte[] {159, 182, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void end() => this.endShader((Shader) Shaders.tar);

      [HideFromJava]
      static \u0033() => CacheLayer.__\u003Cclinit\u003E();
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [Serializable]
    [SpecialName]
    internal sealed class \u0034 : CacheLayer
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(43)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034([In] string obj0, [In] int obj1)
        : base(obj0, obj1, (CacheLayer.\u0031) null)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(new byte[] {159, 188, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void begin() => this.beginShader();

      [LineNumberTable(new byte[] {1, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void end() => this.endShader((Shader) Shaders.slag);

      [HideFromJava]
      static \u0034() => CacheLayer.__\u003Cclinit\u003E();
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [Serializable]
    [SpecialName]
    internal sealed class \u0035 : CacheLayer
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(54)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035([In] string obj0, [In] int obj1)
        : base(obj0, obj1, (CacheLayer.\u0031) null)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(new byte[] {7, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void begin() => this.beginShader();

      [LineNumberTable(new byte[] {12, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void end() => this.endShader((Shader) Shaders.space);

      [HideFromJava]
      static \u0035() => CacheLayer.__\u003Cclinit\u003E();
    }
  }
}
