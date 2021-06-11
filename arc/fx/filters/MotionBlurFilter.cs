// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.MotionBlurFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.fx.util;
using arc.graphics;
using arc.graphics.gl;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.fx.filters
{
  public class MotionBlurFilter : FxFilter
  {
    [Modifiers]
    private CopyFilter copyFilter;
    [Modifiers]
    private FxBufferQueue localBuffer;
    public float blurOpacity;
    public Texture lastFrameTex;

    [LineNumberTable(new byte[] {1, 102, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void rebind()
    {
      base.rebind();
      this.copyFilter.rebind();
      this.localBuffer.rebind();
    }

    [LineNumberTable(new byte[] {159, 164, 107, 127, 20, 5, 236, 60, 235, 72, 139, 166, 159, 5, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MotionBlurFilter(MotionBlurFilter.BlurFunction blurFunction)
      : base(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath(new StringBuilder().append("shaders/").append(blurFunction.fragmentShaderName).append(".frag").toString())))
    {
      MotionBlurFilter motionBlurFilter = this;
      this.blurOpacity = 0.9f;
      this.copyFilter = new CopyFilter();
      this.localBuffer = new FxBufferQueue(Pixmap.Format.__\u003C\u003Ergba8888, !object.ReferenceEquals((object) Core.app.getType(), (object) Application.ApplicationType.__\u003C\u003Eweb) ? 1 : 2);
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 180, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void resize(int width, int height)
    {
      this.copyFilter.resize(width, height);
      this.localBuffer.resize(width, height);
    }

    [LineNumberTable(new byte[] {159, 186, 102, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose()
    {
      base.dispose();
      this.copyFilter.dispose();
      this.localBuffer.dispose();
    }

    [LineNumberTable(new byte[] {8, 113, 104, 145, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      if (this.lastFrameTex != null)
        this.__\u003C\u003Eshader.setUniformi("u_texture1", 1);
      this.__\u003C\u003Eshader.setUniformf("u_blurOpacity", this.blurOpacity);
    }

    [LineNumberTable(new byte[] {17, 108, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void onBeforeRender()
    {
      this.inputTexture.bind(0);
      if (this.lastFrameTex == null)
        return;
      this.lastFrameTex.bind(1);
    }

    [LineNumberTable(new byte[] {25, 108, 114, 113, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void render(FrameBuffer src, FrameBuffer dst)
    {
      FrameBuffer next = this.localBuffer.changeToNext();
      this.setInput(src).setOutput(next).render();
      this.lastFrameTex = (Texture) next.getTexture();
      this.copyFilter.setInput(next).setOutput(dst).render();
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/fx/filters/MotionBlurFilter$BlurFunction;>;")]
    [Modifiers]
    [Serializable]
    public sealed class BlurFunction : Enum
    {
      [Modifiers]
      internal static MotionBlurFilter.BlurFunction __\u003C\u003EMAX;
      [Modifiers]
      internal static MotionBlurFilter.BlurFunction __\u003C\u003EMIX;
      [Modifiers]
      internal string fragmentShaderName;
      [Modifiers]
      private static MotionBlurFilter.BlurFunction[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("(Ljava/lang/String;)V")]
      [LineNumberTable(new byte[] {38, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private BlurFunction([In] string obj0, [In] int obj1, [In] string obj2)
        : base(obj0, obj1)
      {
        MotionBlurFilter.BlurFunction blurFunction = this;
        this.fragmentShaderName = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(82)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static MotionBlurFilter.BlurFunction[] values() => (MotionBlurFilter.BlurFunction[]) MotionBlurFilter.BlurFunction.\u0024VALUES.Clone();

      [LineNumberTable(82)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static MotionBlurFilter.BlurFunction valueOf(string name) => (MotionBlurFilter.BlurFunction) Enum.valueOf((Class) ClassLiteral<MotionBlurFilter.BlurFunction>.Value, name);

      [LineNumberTable(new byte[] {159, 122, 173, 117, 21})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static BlurFunction()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.fx.filters.MotionBlurFilter$BlurFunction"))
          return;
        MotionBlurFilter.BlurFunction.__\u003C\u003EMAX = new MotionBlurFilter.BlurFunction(nameof (MAX), 0, "motionblur-max");
        MotionBlurFilter.BlurFunction.__\u003C\u003EMIX = new MotionBlurFilter.BlurFunction(nameof (MIX), 1, "motionblur-mix");
        MotionBlurFilter.BlurFunction.\u0024VALUES = new MotionBlurFilter.BlurFunction[2]
        {
          MotionBlurFilter.BlurFunction.__\u003C\u003EMAX,
          MotionBlurFilter.BlurFunction.__\u003C\u003EMIX
        };
      }

      [Modifiers]
      public static MotionBlurFilter.BlurFunction MAX
      {
        [HideFromJava] get => MotionBlurFilter.BlurFunction.__\u003C\u003EMAX;
      }

      [Modifiers]
      public static MotionBlurFilter.BlurFunction MIX
      {
        [HideFromJava] get => MotionBlurFilter.BlurFunction.__\u003C\u003EMIX;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        MAX,
        MIX,
      }
    }
  }
}
