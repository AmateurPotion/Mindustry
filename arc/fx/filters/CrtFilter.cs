// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.CrtFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.fx.filters
{
  public class CrtFilter : FxFilter
  {
    internal Vec2 __\u003C\u003EviewportSize;
    public CrtFilter.SizeSource sizeSource;

    [LineNumberTable(new byte[] {159, 160, 107, 111, 191, 24, 239, 59, 236, 55, 107, 235, 78, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CrtFilter(CrtFilter.LineStyle lineStyle, float brightnessMin, float brightnessMax)
      : base(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath("shaders/crt.frag"), new StringBuilder().append("#define SL_BRIGHTNESS_MIN ").append(brightnessMin).append("\n#define SL_BRIGHTNESS_MAX ").append(brightnessMax).append("\n#define LINE_TYPE ").append(lineStyle.ordinal()).toString()))
    {
      CrtFilter crtFilter = this;
      this.__\u003C\u003EviewportSize = new Vec2();
      this.sizeSource = CrtFilter.SizeSource.__\u003C\u003EVIEWPORT;
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 155, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CrtFilter()
      : this(CrtFilter.LineStyle.__\u003C\u003EHORIZONTAL_HARD, 1.3f, 0.5f)
    {
    }

    [LineNumberTable(new byte[] {159, 171, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void resize(int width, int height)
    {
      this.__\u003C\u003EviewportSize.set((float) width, (float) height);
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 177, 113, 127, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformf("u_resolution", !object.ReferenceEquals((object) this.sizeSource, (object) CrtFilter.SizeSource.__\u003C\u003ESCREEN) ? this.__\u003C\u003EviewportSize : Tmp.__\u003C\u003Ev1.set((float) Core.graphics.getWidth(), (float) Core.graphics.getHeight()));
    }

    [Modifiers]
    public Vec2 viewportSize
    {
      [HideFromJava] get => this.__\u003C\u003EviewportSize;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EviewportSize = value;
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/fx/filters/CrtFilter$LineStyle;>;")]
    [Modifiers]
    [Serializable]
    public sealed class LineStyle : Enum
    {
      [Modifiers]
      internal static CrtFilter.LineStyle __\u003C\u003ECROSSLINE_HARD;
      [Modifiers]
      internal static CrtFilter.LineStyle __\u003C\u003EVERTICAL_HARD;
      [Modifiers]
      internal static CrtFilter.LineStyle __\u003C\u003EHORIZONTAL_HARD;
      [Modifiers]
      internal static CrtFilter.LineStyle __\u003C\u003EVERTICAL_SMOOTH;
      [Modifiers]
      internal static CrtFilter.LineStyle __\u003C\u003EHORIZONTAL_SMOOTH;
      [Modifiers]
      private static CrtFilter.LineStyle[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(47)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private LineStyle([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(47)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static CrtFilter.LineStyle[] values() => (CrtFilter.LineStyle[]) CrtFilter.LineStyle.\u0024VALUES.Clone();

      [LineNumberTable(47)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static CrtFilter.LineStyle valueOf(string name) => (CrtFilter.LineStyle) Enum.valueOf((Class) ClassLiteral<CrtFilter.LineStyle>.Value, name);

      [LineNumberTable(new byte[] {159, 130, 77, 112, 112, 112, 112, 240, 59})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static LineStyle()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.fx.filters.CrtFilter$LineStyle"))
          return;
        CrtFilter.LineStyle.__\u003C\u003ECROSSLINE_HARD = new CrtFilter.LineStyle(nameof (CROSSLINE_HARD), 0);
        CrtFilter.LineStyle.__\u003C\u003EVERTICAL_HARD = new CrtFilter.LineStyle(nameof (VERTICAL_HARD), 1);
        CrtFilter.LineStyle.__\u003C\u003EHORIZONTAL_HARD = new CrtFilter.LineStyle(nameof (HORIZONTAL_HARD), 2);
        CrtFilter.LineStyle.__\u003C\u003EVERTICAL_SMOOTH = new CrtFilter.LineStyle(nameof (VERTICAL_SMOOTH), 3);
        CrtFilter.LineStyle.__\u003C\u003EHORIZONTAL_SMOOTH = new CrtFilter.LineStyle(nameof (HORIZONTAL_SMOOTH), 4);
        CrtFilter.LineStyle.\u0024VALUES = new CrtFilter.LineStyle[5]
        {
          CrtFilter.LineStyle.__\u003C\u003ECROSSLINE_HARD,
          CrtFilter.LineStyle.__\u003C\u003EVERTICAL_HARD,
          CrtFilter.LineStyle.__\u003C\u003EHORIZONTAL_HARD,
          CrtFilter.LineStyle.__\u003C\u003EVERTICAL_SMOOTH,
          CrtFilter.LineStyle.__\u003C\u003EHORIZONTAL_SMOOTH
        };
      }

      [Modifiers]
      public static CrtFilter.LineStyle CROSSLINE_HARD
      {
        [HideFromJava] get => CrtFilter.LineStyle.__\u003C\u003ECROSSLINE_HARD;
      }

      [Modifiers]
      public static CrtFilter.LineStyle VERTICAL_HARD
      {
        [HideFromJava] get => CrtFilter.LineStyle.__\u003C\u003EVERTICAL_HARD;
      }

      [Modifiers]
      public static CrtFilter.LineStyle HORIZONTAL_HARD
      {
        [HideFromJava] get => CrtFilter.LineStyle.__\u003C\u003EHORIZONTAL_HARD;
      }

      [Modifiers]
      public static CrtFilter.LineStyle VERTICAL_SMOOTH
      {
        [HideFromJava] get => CrtFilter.LineStyle.__\u003C\u003EVERTICAL_SMOOTH;
      }

      [Modifiers]
      public static CrtFilter.LineStyle HORIZONTAL_SMOOTH
      {
        [HideFromJava] get => CrtFilter.LineStyle.__\u003C\u003EHORIZONTAL_SMOOTH;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        CROSSLINE_HARD,
        VERTICAL_HARD,
        HORIZONTAL_HARD,
        VERTICAL_SMOOTH,
        HORIZONTAL_SMOOTH,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/fx/filters/CrtFilter$SizeSource;>;")]
    [Modifiers]
    [Serializable]
    public sealed class SizeSource : Enum
    {
      [Modifiers]
      internal static CrtFilter.SizeSource __\u003C\u003EVIEWPORT;
      [Modifiers]
      internal static CrtFilter.SizeSource __\u003C\u003ESCREEN;
      [Modifiers]
      private static CrtFilter.SizeSource[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(40)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private SizeSource([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(40)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static CrtFilter.SizeSource[] values() => (CrtFilter.SizeSource[]) CrtFilter.SizeSource.\u0024VALUES.Clone();

      [LineNumberTable(40)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static CrtFilter.SizeSource valueOf(string name) => (CrtFilter.SizeSource) Enum.valueOf((Class) ClassLiteral<CrtFilter.SizeSource>.Value, name);

      [LineNumberTable(new byte[] {159, 132, 141, 144, 240, 60})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static SizeSource()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.fx.filters.CrtFilter$SizeSource"))
          return;
        CrtFilter.SizeSource.__\u003C\u003EVIEWPORT = new CrtFilter.SizeSource(nameof (VIEWPORT), 0);
        CrtFilter.SizeSource.__\u003C\u003ESCREEN = new CrtFilter.SizeSource(nameof (SCREEN), 1);
        CrtFilter.SizeSource.\u0024VALUES = new CrtFilter.SizeSource[2]
        {
          CrtFilter.SizeSource.__\u003C\u003EVIEWPORT,
          CrtFilter.SizeSource.__\u003C\u003ESCREEN
        };
      }

      [Modifiers]
      public static CrtFilter.SizeSource VIEWPORT
      {
        [HideFromJava] get => CrtFilter.SizeSource.__\u003C\u003EVIEWPORT;
      }

      [Modifiers]
      public static CrtFilter.SizeSource SCREEN
      {
        [HideFromJava] get => CrtFilter.SizeSource.__\u003C\u003ESCREEN;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        VIEWPORT,
        SCREEN,
      }
    }
  }
}
