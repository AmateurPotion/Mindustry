// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.Label
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math.geom;
using arc.scene.style;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui
{
  public class Label : Element
  {
    internal static Color __\u003C\u003EtempColor;
    internal static GlyphLayout __\u003C\u003EprefSizeLayout;
    internal GlyphLayout __\u003C\u003Elayout;
    internal Vec2 __\u003C\u003EprefSize;
    internal StringBuilder __\u003C\u003Etext;
    protected internal Label.LabelStyle style;
    protected internal FontCache cache;
    protected internal int labelAlign;
    protected internal int lineAlign;
    protected internal bool wrap;
    protected internal float lastPrefHeight;
    protected internal bool prefSizeInvalid;
    protected internal float fontScaleX;
    protected internal float fontScaleY;
    protected internal bool fontScaleChanged;
    protected internal string ellipsis;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Larc/func/Prov<Ljava/lang/CharSequence;>;)V")]
    [LineNumberTable(new byte[] {159, 187, 127, 25, 147, 159, 25, 34, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Label(Prov sup)
    {
      Label.LabelStyle style = new Label.LabelStyle((Label.LabelStyle) Core.scene.getStyle((Class) ClassLiteral<Label.LabelStyle>.Value));
      object obj1 = (object) "";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj1;
      // ISSUE: explicit constructor call
      this.\u002Ector(charSequence, style);
      Label label = this;
      this.update((Runnable) new Label.__\u003C\u003EAnon0(this, sup));
      try
      {
        object obj2 = sup.get();
        CharSequence.Cast(obj2);
        object obj3 = obj2;
        charSequence.__\u003Cref\u003E = (__Null) obj3;
        this.setText(charSequence);
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
      }
    }

    [LineNumberTable(new byte[] {159, 77, 130, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWrap(bool wrap)
    {
      this.wrap = wrap;
      this.invalidateHierarchy();
    }

    [LineNumberTable(new byte[] {159, 129, 138, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Label(CharSequence text)
    {
      object obj1 = (object) text.__\u003Cref\u003E;
      Label.LabelStyle style = (Label.LabelStyle) Core.scene.getStyle((Class) ClassLiteral<Label.LabelStyle>.Value);
      object obj2 = obj1;
      CharSequence text1;
      text1.__\u003Cref\u003E = (__Null) obj2;
      // ISSUE: explicit constructor call
      this.\u002Ector(text1, style);
    }

    [LineNumberTable(new byte[] {160, 188, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFontScale(float fontScale) => this.setFontScale(fontScale, fontScale);

    [LineNumberTable(new byte[] {159, 128, 106, 232, 36, 107, 107, 171, 103, 199, 103, 118, 231, 81, 99, 108, 125, 129, 108, 122, 127, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Label(CharSequence text, Label.LabelStyle style)
    {
      object obj1 = (object) text.__\u003Cref\u003E;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      Label label = this;
      this.__\u003C\u003Elayout = new GlyphLayout();
      this.__\u003C\u003EprefSize = new Vec2();
      this.__\u003C\u003Etext = new StringBuilder();
      this.labelAlign = 8;
      this.lineAlign = 8;
      this.prefSizeInvalid = true;
      this.fontScaleX = 1f;
      this.fontScaleY = 1f;
      this.fontScaleChanged = false;
      if (style == null)
      {
        this.__\u003C\u003Etext.setLength(0);
        StringBuilder text1 = this.__\u003C\u003Etext;
        object obj2 = obj1;
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence2 = charSequence1;
        text1.append(charSequence2);
      }
      else
      {
        this.setStyle(new Label.LabelStyle(style));
        CharSequence newText;
        if (obj1 != null)
        {
          object obj2 = obj1;
          newText.__\u003Cref\u003E = (__Null) obj2;
          this.setText(newText);
        }
        if (obj1 == null)
          return;
        object obj3 = obj1;
        newText.__\u003Cref\u003E = (__Null) obj3;
        if (((CharSequence) ref newText).length() <= 0)
          return;
        this.setSize(this.getPrefWidth(), this.getPrefHeight());
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setEllipsis(bool ellipsis)
    {
      if (ellipsis)
        this.ellipsis = "...";
      else
        this.ellipsis = (string) null;
    }

    [LineNumberTable(new byte[] {160, 166, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAlignment(int alignment) => this.setAlignment(alignment, alignment);

    [LineNumberTable(new byte[] {160, 175, 135, 101, 105, 102, 138, 135, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAlignment(int labelAlign, int lineAlign)
    {
      this.labelAlign = labelAlign;
      this.lineAlign = (lineAlign & 8) == 0 ? ((lineAlign & 16) == 0 ? 1 : 16) : 8;
      this.invalidate();
    }

    [LineNumberTable(new byte[] {159, 115, 106, 127, 60, 121, 127, 20, 98, 151})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setText(CharSequence newText)
    {
      object obj1 = (object) newText.__\u003Cref\u003E;
      CharSequence charSequence;
      if (Core.bundle != null && obj1 != null)
      {
        object obj2 = obj1;
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        if (((CharSequence) ref charSequence).length() > 0)
        {
          object obj3 = obj1;
          int num1 = 0;
          object obj4 = obj3;
          charSequence.__\u003Cref\u003E = (__Null) obj4;
          if (((CharSequence) ref charSequence).charAt(num1) != '$')
          {
            object obj5 = obj1;
            int num2 = 0;
            object obj6 = obj5;
            charSequence.__\u003Cref\u003E = (__Null) obj6;
            if (((CharSequence) ref charSequence).charAt(num2) != '@')
              goto label_5;
          }
          object obj7 = obj1;
          charSequence.__\u003Cref\u003E = (__Null) obj7;
          string str = String.instancehelper_substring(((CharSequence) ref charSequence).toString(), 1);
          I18NBundle bundle = Core.bundle;
          string key = str;
          object obj8 = obj1;
          charSequence.__\u003Cref\u003E = (__Null) obj8;
          string def = ((CharSequence) ref charSequence).toString();
          object obj9 = (object) bundle.get(key, def);
          charSequence.__\u003Cref\u003E = (__Null) obj9;
          this.setTextInternal(charSequence);
          return;
        }
      }
label_5:
      object obj10 = obj1;
      charSequence.__\u003Cref\u003E = (__Null) obj10;
      this.setTextInternal(charSequence);
    }

    [LineNumberTable(new byte[] {27, 115, 120, 103, 113, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStyle(Label.LabelStyle style)
    {
      if (style == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("style cannot be null.");
      }
      if (style.font == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Missing LabelStyle font.");
      }
      this.style = style;
      this.cache = style.font.newFontCache();
      this.invalidateHierarchy();
    }

    [LineNumberTable(new byte[] {160, 113, 110, 110, 110, 108, 108, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefWidth()
    {
      if (this.style == null || this.wrap)
        return 0.0f;
      if (this.prefSizeInvalid)
        this.scaleAndComputePrefSize();
      float x = this.__\u003C\u003EprefSize.x;
      Drawable background = this.style.background;
      if (background != null)
        x += background.getLeftWidth() + background.getRightWidth();
      return x;
    }

    [LineNumberTable(new byte[] {160, 124, 110, 110, 102, 127, 3, 127, 10, 108, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefHeight()
    {
      if (this.style == null)
        return 0.0f;
      if (this.prefSizeInvalid)
        this.scaleAndComputePrefSize();
      float num1 = 1f;
      if (this.fontScaleChanged)
        num1 = this.fontScaleY / this.style.font.getScaleY();
      float num2 = this.__\u003C\u003EprefSize.y - this.style.font.getDescent() * num1 * 2f;
      Drawable background = this.style.background;
      if (background != null)
        num2 += background.getTopHeight() + background.getBottomHeight();
      return num2;
    }

    [LineNumberTable(new byte[] {159, 119, 106, 108, 118, 104, 63, 9, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool textEquals(CharSequence other)
    {
      object obj1 = (object) other.__\u003Cref\u003E;
      int num1 = this.__\u003C\u003Etext.length();
      int num2 = num1;
      object obj2 = obj1;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      int num3 = ((CharSequence) ref charSequence).length();
      if (num2 != num3)
        return false;
      for (int index = 0; index < num1; ++index)
      {
        int num4 = (int) this.__\u003C\u003Etext.charAt(index);
        object obj3 = obj1;
        int num5 = index;
        object obj4 = obj3;
        charSequence.__\u003Cref\u003E = (__Null) obj4;
        int num6 = (int) ((CharSequence) ref charSequence).charAt(num5);
        if (num4 != num6)
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {159, 121, 106, 112, 122, 108, 125, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setTextInternal([In] CharSequence obj0)
    {
      object obj1 = (object) obj0.__\u003Cref\u003E;
      object obj2 = obj1;
      CharSequence.Cast(obj2);
      if (obj2 == null)
        obj1 = (object) "";
      object obj3 = obj1;
      CharSequence other;
      other.__\u003Cref\u003E = (__Null) obj3;
      if (this.textEquals(other))
        return;
      this.__\u003C\u003Etext.setLength(0);
      StringBuilder text = this.__\u003C\u003Etext;
      object obj4 = obj1;
      other.__\u003Cref\u003E = (__Null) obj4;
      CharSequence charSequence = other;
      text.append(charSequence);
      this.invalidateHierarchy();
    }

    [LineNumberTable(new byte[] {86, 103, 102, 118, 104, 127, 22, 127, 30, 101, 127, 75, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void computePrefSize()
    {
      this.prefSizeInvalid = false;
      GlyphLayout prefSizeLayout = Label.__\u003C\u003EprefSizeLayout;
      if (this.wrap && this.ellipsis == null)
      {
        float width = this.getWidth();
        if (this.style.background != null)
          width -= this.style.background.getLeftWidth() + this.style.background.getRightWidth();
        GlyphLayout glyphLayout = prefSizeLayout;
        Font font = this.cache.getFont();
        StringBuilder text = this.__\u003C\u003Etext;
        Color white = Color.__\u003C\u003Ewhite;
        double num1 = (double) width;
        bool flag = true;
        int num2 = 8;
        float num3 = (float) num1;
        Color color1 = white;
        object obj = (object) text;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence str = charSequence;
        Color color2 = color1;
        double num4 = (double) num3;
        int halign = num2;
        int num5 = flag ? 1 : 0;
        glyphLayout.setText(font, str, color2, (float) num4, halign, num5 != 0);
      }
      else
      {
        GlyphLayout glyphLayout = prefSizeLayout;
        Font font = this.cache.getFont();
        StringBuilder text = this.__\u003C\u003Etext;
        int num1 = this.__\u003C\u003Etext.length();
        Color white = Color.__\u003C\u003Ewhite;
        double width = (double) this.width;
        int lineAlign = this.lineAlign;
        int num2 = this.wrap ? 1 : 0;
        string ellipsis = this.ellipsis;
        bool flag = num2 != 0;
        int num3 = lineAlign;
        float num4 = (float) width;
        Color color1 = white;
        int num5 = num1;
        int num6 = 0;
        object obj = (object) text;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence str = charSequence;
        int start = num6;
        int end = num5;
        Color color2 = color1;
        double num7 = (double) num4;
        int halign = num3;
        int num8 = flag ? 1 : 0;
        string truncate = ellipsis;
        glyphLayout.setText(font, str, start, end, color2, (float) num7, halign, num8 != 0, truncate);
      }
      this.__\u003C\u003EprefSize.set(prefSizeLayout.width, prefSizeLayout.height);
    }

    [LineNumberTable(new byte[] {74, 105, 108, 104, 104, 159, 0, 134, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void scaleAndComputePrefSize()
    {
      if (this.cache == null)
        return;
      Font font = this.cache.getFont();
      float scaleX = font.getScaleX();
      float scaleY = font.getScaleY();
      if (this.fontScaleChanged)
        font.getData().setScale(this.fontScaleX, this.fontScaleY);
      this.computePrefSize();
      if (!this.fontScaleChanged)
        return;
      font.getData().setScale(scaleX, scaleY);
    }

    [LineNumberTable(new byte[] {69, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void invalidate()
    {
      base.invalidate();
      this.prefSizeInvalid = true;
    }

    [LineNumberTable(new byte[] {160, 192, 103, 104, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFontScale(float fontScaleX, float fontScaleY)
    {
      this.fontScaleChanged = true;
      this.fontScaleX = fontScaleX;
      this.fontScaleY = fontScaleY;
      this.invalidateHierarchy();
    }

    [Modifiers]
    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] Prov obj0)
    {
      object obj1 = obj0.get();
      CharSequence.Cast(obj1);
      object obj2 = obj1;
      CharSequence newText;
      newText.__\u003Cref\u003E = (__Null) obj2;
      this.setText(newText);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Label.LabelStyle getStyle() => this.style;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual StringBuilder getText() => this.__\u003C\u003Etext;

    [LineNumberTable(new byte[] {99, 105, 108, 104, 104, 159, 0, 117, 99, 105, 106, 104, 198, 114, 109, 110, 100, 106, 106, 120, 184, 136, 153, 127, 61, 105, 137, 106, 107, 142, 181, 100, 173, 106, 127, 6, 121, 106, 127, 6, 153, 147, 154, 127, 61, 145, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void layout()
    {
      if (this.cache == null)
        return;
      Font font1 = this.cache.getFont();
      float scaleX = font1.getScaleX();
      float scaleY = font1.getScaleY();
      if (this.fontScaleChanged)
        font1.getData().setScale(this.fontScaleX, this.fontScaleY);
      int num1 = !this.wrap || this.ellipsis != null ? 0 : 1;
      if (num1 != 0)
      {
        float prefHeight = this.getPrefHeight();
        if ((double) prefHeight != (double) this.lastPrefHeight)
        {
          this.lastPrefHeight = prefHeight;
          this.invalidateHierarchy();
        }
      }
      float width = this.getWidth();
      float height = this.getHeight();
      Drawable background = this.style.background;
      float x = 0.0f;
      float num2 = 0.0f;
      if (background != null)
      {
        x = background.getLeftWidth();
        num2 = background.getBottomHeight();
        width -= background.getLeftWidth() + background.getRightWidth();
        height -= background.getBottomHeight() + background.getTopHeight();
      }
      GlyphLayout layout = this.__\u003C\u003Elayout;
      CharSequence charSequence;
      float num3;
      float num4;
      if (num1 != 0 || this.__\u003C\u003Etext.indexOf("\n") != -1)
      {
        GlyphLayout glyphLayout = layout;
        Font font2 = font1;
        StringBuilder text = this.__\u003C\u003Etext;
        int num5 = this.__\u003C\u003Etext.length();
        Color white = Color.__\u003C\u003Ewhite;
        double num6 = (double) width;
        int lineAlign = this.lineAlign;
        int num7 = num1;
        string ellipsis = this.ellipsis;
        bool flag = num7 != 0;
        int num8 = lineAlign;
        float num9 = (float) num6;
        Color color1 = white;
        int num10 = num5;
        int num11 = 0;
        object obj = (object) text;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence str = charSequence;
        int start = num11;
        int end = num10;
        Color color2 = color1;
        double num12 = (double) num9;
        int halign = num8;
        int num13 = flag ? 1 : 0;
        string truncate = ellipsis;
        glyphLayout.setText(font2, str, start, end, color2, (float) num12, halign, num13 != 0, truncate);
        num3 = layout.width;
        num4 = layout.height;
        if ((this.labelAlign & 8) == 0)
        {
          if ((this.labelAlign & 16) != 0)
            x += width - num3;
          else
            x += (width - num3) / 2f;
        }
      }
      else
      {
        num3 = width;
        num4 = font1.getData().capHeight;
      }
      float y = (this.labelAlign & 2) == 0 ? ((this.labelAlign & 4) == 0 ? num2 + (height - num4) / 2f : num2 + (!this.cache.getFont().isFlipped() ? 0.0f : height - num4) - this.style.font.getDescent()) : num2 + (!this.cache.getFont().isFlipped() ? height - num4 : 0.0f) + this.style.font.getDescent();
      if (!this.cache.getFont().isFlipped())
        y += num4;
      GlyphLayout glyphLayout1 = layout;
      Font font3 = font1;
      StringBuilder text1 = this.__\u003C\u003Etext;
      int num14 = this.__\u003C\u003Etext.length();
      Color white1 = Color.__\u003C\u003Ewhite;
      double num15 = (double) num3;
      int lineAlign1 = this.lineAlign;
      int num16 = num1;
      string ellipsis1 = this.ellipsis;
      bool flag1 = num16 != 0;
      int num17 = lineAlign1;
      float num18 = (float) num15;
      Color color3 = white1;
      int num19 = num14;
      int num20 = 0;
      object obj1 = (object) text1;
      charSequence.__\u003Cref\u003E = (__Null) obj1;
      CharSequence str1 = charSequence;
      int start1 = num20;
      int end1 = num19;
      Color color4 = color3;
      double num21 = (double) num18;
      int halign1 = num17;
      int num22 = flag1 ? 1 : 0;
      string truncate1 = ellipsis1;
      glyphLayout1.setText(font3, str1, start1, end1, color4, (float) num21, halign1, num22 != 0, truncate1);
      this.cache.setText(layout, x, y);
      if (!this.fontScaleChanged)
        return;
      font1.getData().setScale(scaleX, scaleY);
    }

    [LineNumberTable(new byte[] {160, 98, 102, 113, 116, 109, 125, 159, 9, 127, 0, 108, 119, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      this.validate();
      Color tint = Label.__\u003C\u003EtempColor.set(this.__\u003C\u003Ecolor);
      tint.a *= this.parentAlpha;
      if (this.style.background != null)
      {
        Draw.color(tint.r, tint.g, tint.b, tint.a);
        this.style.background.draw(this.x, this.y, this.width, this.height);
      }
      if (this.style.fontColor != null)
        tint.mul(this.style.fontColor);
      this.cache.tint(tint);
      this.cache.setPosition(this.x, this.y);
      this.cache.draw();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GlyphLayout getGlyphLayout() => this.__\u003C\u003Elayout;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLabelAlign() => this.labelAlign;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLineAlign() => this.lineAlign;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFontScaleX() => this.fontScaleX;

    [LineNumberTable(new byte[] {160, 203, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFontScaleX(float fontScaleX) => this.setFontScale(fontScaleX, this.fontScaleY);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFontScaleY() => this.fontScaleY;

    [LineNumberTable(new byte[] {160, 211, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFontScaleY(float fontScaleY) => this.setFontScale(this.fontScaleX, fontScaleY);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setEllipsis(string ellipsis) => this.ellipsis = ellipsis;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FontCache getFontCache() => this.cache;

    [LineNumberTable(353)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toString() => new StringBuilder().append(base.toString()).append(": ").append((object) this.__\u003C\u003Etext).toString();

    [LineNumberTable(new byte[] {159, 136, 141, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Label()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.scene.ui.Label"))
        return;
      Label.__\u003C\u003EtempColor = new Color();
      Label.__\u003C\u003EprefSizeLayout = new GlyphLayout();
    }

    [Modifiers]
    protected internal static Color tempColor
    {
      [HideFromJava] get => Label.__\u003C\u003EtempColor;
    }

    [Modifiers]
    protected internal static GlyphLayout prefSizeLayout
    {
      [HideFromJava] get => Label.__\u003C\u003EprefSizeLayout;
    }

    [Modifiers]
    protected internal GlyphLayout layout
    {
      [HideFromJava] get => this.__\u003C\u003Elayout;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Elayout = value;
    }

    [Modifiers]
    protected internal Vec2 prefSize
    {
      [HideFromJava] get => this.__\u003C\u003EprefSize;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EprefSize = value;
    }

    [Modifiers]
    protected internal StringBuilder text
    {
      [HideFromJava] get => this.__\u003C\u003Etext;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Etext = value;
    }

    public class LabelStyle : Style
    {
      public Font font;
      public Color fontColor;
      public Drawable background;

      [LineNumberTable(new byte[] {161, 0, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LabelStyle(Font font, Color fontColor)
      {
        Label.LabelStyle labelStyle = this;
        this.font = font;
        this.fontColor = fontColor;
      }

      [LineNumberTable(new byte[] {161, 5, 104, 108, 126, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LabelStyle(Label.LabelStyle style)
      {
        Label.LabelStyle labelStyle = this;
        this.font = style.font;
        if (style.fontColor != null)
        {
          Color.__\u003Cclinit\u003E();
          this.fontColor = new Color(style.fontColor);
        }
        this.background = style.background;
      }

      [LineNumberTable(new byte[] {160, 253, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LabelStyle()
      {
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly Label arg\u00241;
      private readonly Prov arg\u00242;

      internal __\u003C\u003EAnon0([In] Label obj0, [In] Prov obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00240(this.arg\u00242);
    }
  }
}
