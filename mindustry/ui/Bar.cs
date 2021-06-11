// Decompiled with JetBrains decompiler
// Type: mindustry.ui.Bar
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.scene;
using arc.scene.style;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.gen;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui
{
  public class Bar : Element
  {
    private static Rect scissor;
    private Floatp fraction;
    private new string name;
    private float value;
    private float lastValue;
    private float blink;
    private Color blinkColor;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Larc/func/Prov<Ljava/lang/String;>;Larc/func/Prov<Larc/graphics/Color;>;Larc/func/Floatp;)V")]
    [LineNumberTable(new byte[] {159, 172, 232, 52, 139, 235, 75, 135, 191, 20, 2, 97, 150, 244, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Bar(Prov name, Prov color, Floatp fraction)
    {
      Bar bar1 = this;
      this.name = "";
      this.blinkColor = new Color();
      this.fraction = fraction;
      try
      {
        Bar bar2 = this;
        float num1 = Mathf.clamp(fraction.get());
        double num2 = (double) num1;
        this.value = num1;
        this.lastValue = (float) num2;
        goto label_5;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
      }
      Bar bar3 = this;
      float num3 = 0.0f;
      double num4 = (double) num3;
      this.value = num3;
      this.lastValue = (float) num4;
label_5:
      this.update((Runnable) new Bar.__\u003C\u003EAnon0(this, name, color));
    }

    [LineNumberTable(new byte[] {159, 164, 232, 60, 139, 171, 103, 114, 109, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Bar(string name, Color color, Floatp fraction)
    {
      Bar bar1 = this;
      this.name = "";
      this.blinkColor = new Color();
      this.fraction = fraction;
      this.name = Core.bundle.get(name, name);
      this.blinkColor.set(color);
      Bar bar2 = this;
      float num1 = fraction.get();
      double num2 = (double) num1;
      this.value = num1;
      this.lastValue = (float) num2;
      this.setColor(color);
    }

    [LineNumberTable(new byte[] {15, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Bar blink(Color color)
    {
      this.blinkColor.set(color);
      return this;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 181, 113, 119, 191, 7, 2, 97, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] Prov obj0, [In] Prov obj1)
    {
      try
      {
        this.name = (string) obj0.get();
        this.blinkColor.set((Color) obj1.get());
        this.setColor((Color) obj1.get());
        return;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
      }
      this.name = "";
    }

    [Modifiers]
    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024set\u00241([In] Prov obj0) => this.name = (string) obj0.get();

    [LineNumberTable(new byte[] {159, 190, 232, 34, 139, 235, 94})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Bar()
    {
      Bar bar = this;
      this.name = "";
      this.blinkColor = new Color();
    }

    [LineNumberTable(new byte[] {3, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset(float value)
    {
      Bar bar1 = this;
      Bar bar2 = this;
      float num1 = value;
      double num2 = (double) num1;
      this.blink = num1;
      float num3 = (float) num2;
      double num4 = (double) num3;
      this.lastValue = num3;
      this.value = (float) num4;
    }

    [Signature("(Larc/func/Prov<Ljava/lang/String;>;Larc/func/Floatp;Larc/graphics/Color;)V")]
    [LineNumberTable(new byte[] {7, 103, 109, 109, 103, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Prov name, Floatp fraction, Color color)
    {
      this.fraction = fraction;
      this.lastValue = fraction.get();
      this.blinkColor.set(color);
      this.setColor(color);
      this.update((Runnable) new Bar.__\u003C\u003EAnon1(this, name));
    }

    [LineNumberTable(new byte[] {21, 201, 191, 9, 2, 97, 166, 105, 107, 167, 120, 120, 120, 120, 110, 142, 124, 152, 134, 106, 126, 151, 102, 143, 120, 155, 127, 5, 127, 14, 198, 133, 103, 123, 159, 2, 108, 159, 90, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      if (this.fraction == null)
        return;
      float toValue;
      try
      {
        toValue = Mathf.clamp(this.fraction.get());
        goto label_6;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
      }
      toValue = 0.0f;
label_6:
      if ((double) this.lastValue > (double) toValue)
      {
        this.blink = 1f;
        this.lastValue = toValue;
      }
      if (Float.isNaN(this.lastValue))
        this.lastValue = 0.0f;
      if (Float.isInfinite(this.lastValue))
        this.lastValue = 1f;
      if (Float.isNaN(this.value))
        this.value = 0.0f;
      if (Float.isInfinite(this.value))
        this.value = 1f;
      if (Float.isNaN(toValue))
        toValue = 0.0f;
      if (Float.isInfinite(toValue))
        toValue = 1f;
      this.blink = Mathf.lerpDelta(this.blink, 0.0f, 0.2f);
      this.value = Mathf.lerpDelta(this.value, toValue, 0.15f);
      NinePatchDrawable bar = Tex.bar;
      Draw.colorl(0.1f);
      bar.draw(this.x, this.y, this.width, this.height);
      Draw.color(this.__\u003C\u003Ecolor, this.blinkColor, this.blink);
      NinePatchDrawable barTop = Tex.barTop;
      float num1 = this.width * this.value;
      if ((double) num1 > (double) Core.atlas.find("bar-top").width)
        barTop.draw(this.x, this.y, num1, this.height);
      else if (ScissorStack.push(Bar.scissor.set(this.x, this.y, num1, this.height)))
      {
        barTop.draw(this.x, this.y, (float) Core.atlas.find("bar-top").width, this.height);
        ScissorStack.pop();
      }
      Draw.color();
      Font outline = Fonts.outline;
      GlyphLayout glyphLayout1 = (GlyphLayout) Pools.obtain((Class) ClassLiteral<GlyphLayout>.Value, (Prov) new Bar.__\u003C\u003EAnon2());
      GlyphLayout glyphLayout2 = glyphLayout1;
      Font font1 = outline;
      object name1 = (object) this.name;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) name1;
      CharSequence str1 = charSequence;
      glyphLayout2.setText(font1, str1);
      outline.setColor(Color.__\u003C\u003Ewhite);
      Font font2 = outline;
      string name2 = this.name;
      double num2 = (double) (this.x + this.width / 2f - glyphLayout1.width / 2f);
      float num3 = this.y + this.height / 2f + glyphLayout1.height / 2f + 1f;
      float num4 = (float) num2;
      object obj = (object) name2;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence str2 = charSequence;
      double num5 = (double) num4;
      double num6 = (double) num3;
      font2.draw(str2, (float) num5, (float) num6);
      Pools.free((object) glyphLayout1);
    }

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Bar()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.ui.Bar"))
        return;
      Bar.scissor = new Rect();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly Bar arg\u00241;
      private readonly Prov arg\u00242;
      private readonly Prov arg\u00243;

      internal __\u003C\u003EAnon0([In] Bar obj0, [In] Prov obj1, [In] Prov obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00240(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly Bar arg\u00241;
      private readonly Prov arg\u00242;

      internal __\u003C\u003EAnon1([In] Bar obj0, [In] Prov obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024set\u00241(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) new GlyphLayout();
    }
  }
}
