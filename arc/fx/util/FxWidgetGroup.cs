// Decompiled with JetBrains decompiler
// Type: arc.fx.util.FxWidgetGroup
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.scene;
using arc.scene.ui.layout;
using arc.util.viewport;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace arc.fx.util
{
  public class FxWidgetGroup : WidgetGroup
  {
    [Modifiers]
    private FxProcessor fxProcessor;
    private bool initialized;
    private bool resizePending;
    private bool matchWidgetSize;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {72, 137, 134, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void initialize()
    {
      if (this.initialized)
        return;
      this.performPendingResize();
      this.resizePending = false;
      this.initialized = true;
    }

    [LineNumberTable(new byte[] {81, 137, 139, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void reset()
    {
      if (!this.initialized)
        return;
      this.fxProcessor.dispose();
      this.resizePending = false;
      this.initialized = false;
    }

    [LineNumberTable(new byte[] {90, 233, 70, 188, 99, 136, 136, 109, 207, 108, 113, 112, 176, 141, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void performPendingResize()
    {
      if (!this.resizePending)
        return;
      int width;
      int height;
      if (ByteCodeHelper.f2i(this.getWidth()) == 0 || ByteCodeHelper.f2i(this.getHeight()) == 0)
      {
        width = 16;
        height = 16;
      }
      else if (this.matchWidgetSize)
      {
        width = Mathf.floor(this.getWidth());
        height = Mathf.floor(this.getHeight());
      }
      else
      {
        Viewport viewport = this.getScene().getViewport();
        float num = (float) viewport.getScreenWidth() / viewport.getWorldWidth();
        width = Mathf.floor(this.getWidth() * num);
        height = Mathf.floor(this.getHeight() * num);
      }
      this.fxProcessor.resize(width, height);
      this.resizePending = false;
    }

    [LineNumberTable(new byte[] {36, 140, 131, 135, 131, 167, 102, 133, 99, 167, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void drawChildren()
    {
      int num = this.fxProcessor.isCapturing() ? 1 : 0;
      if (num != 0)
        base.setTransform(true);
      if (num == 0)
        this.clipBegin();
      base.drawChildren();
      Draw.flush();
      if (num != 0)
        base.setTransform(false);
      if (num != 0)
        return;
      this.clipEnd();
    }

    [LineNumberTable(new byte[] {159, 160, 232, 60, 103, 103, 167, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FxWidgetGroup()
    {
      FxWidgetGroup fxWidgetGroup = this;
      this.initialized = false;
      this.resizePending = false;
      this.matchWidgetSize = false;
      this.fxProcessor = new FxProcessor();
      base.setTransform(false);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FxProcessor getFxProcessor() => this.fxProcessor;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isMatchWidgetSize() => this.matchWidgetSize;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMatchWidgetSize(bool matchWidgetSize)
    {
      int num = matchWidgetSize ? 1 : 0;
      if ((this.matchWidgetSize ? 1 : 0) == num)
        return;
      this.matchWidgetSize = num != 0;
      this.resizePending = true;
    }

    [LineNumberTable(new byte[] {159, 186, 135, 99, 136, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setScene(Scene stage)
    {
      base.setScene(stage);
      if (stage != null)
        this.initialize();
      else
        this.reset();
    }

    [LineNumberTable(new byte[] {5, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void sizeChanged()
    {
      base.sizeChanged();
      this.resizePending = true;
    }

    [LineNumberTable(new byte[] {11, 133, 134, 107, 140, 102, 134, 133, 108, 171, 112, 103, 127, 6, 159, 54})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      Draw.flush();
      this.performPendingResize();
      this.fxProcessor.clear();
      this.fxProcessor.begin();
      this.validate();
      this.drawChildren();
      Draw.flush();
      this.fxProcessor.end();
      this.fxProcessor.applyEffects();
      if (!this.fxProcessor.hasResult())
        return;
      Color color = this.__\u003C\u003Ecolor;
      Draw.color(color.r, color.g, color.b, color.a * this.parentAlpha);
      Draw.rect(Draw.wrap((Texture) this.fxProcessor.getResultBuffer().getTexture()), this.x + this.width / 2f, this.y + this.height / 2f, this.width, this.height);
    }

    [Obsolete]
    [LineNumberTable(112)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setCullingArea(Rect cullingArea)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException("VfxWidgetGroup doesn't support culling area.");
    }

    [Obsolete]
    [LineNumberTable(118)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setTransform(bool transform)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException("VfxWidgetGroup doesn't support transform.");
    }

    [HideFromJava]
    static FxWidgetGroup() => WidgetGroup.__\u003Cclinit\u003E();
  }
}
