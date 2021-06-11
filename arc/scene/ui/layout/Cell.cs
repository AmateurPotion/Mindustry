// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.layout.Cell
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.utils;
using arc.util;
using arc.util.pooling;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui.layout
{
  [Signature("<T:Larc/scene/Element;>Ljava/lang/Object;Larc/util/pooling/Pool$Poolable;")]
  public class Cell : Object, Pool.Poolable
  {
    private static bool dset;
    private static Cell defaults;
    internal const float unset = float.NegativeInfinity;
    internal float minWidth;
    internal float minHeight;
    internal float maxWidth;
    internal float maxHeight;
    internal float padTop;
    internal float padLeft;
    internal float padBottom;
    internal float padRight;
    internal float fillX;
    internal float fillY;
    internal int align;
    internal int expandX;
    internal int expandY;
    internal int colspan;
    internal bool uniformX;
    internal bool uniformY;
    internal Element element;
    internal float elementX;
    internal float elementY;
    internal float elementWidth;
    internal float elementHeight;
    internal bool endRow;
    internal int column;
    internal int row;
    internal int cellAboveIndex;
    internal float computedPadTop;
    internal float computedPadLeft;
    internal float computedPadBottom;
    internal float computedPadRight;
    private Table table;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLayout(Table table) => this.table = table;

    [Signature("(Larc/scene/ui/layout/Cell;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {162, 34, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell set(Cell cell)
    {
      this.minWidth = cell.minWidth;
      this.minHeight = cell.minHeight;
      this.maxWidth = cell.maxWidth;
      this.maxHeight = cell.maxHeight;
      this.padTop = cell.padTop;
      this.padLeft = cell.padLeft;
      this.padBottom = cell.padBottom;
      this.padRight = cell.padRight;
      this.fillX = cell.fillX;
      this.fillY = cell.fillY;
      this.align = cell.align;
      this.expandX = cell.expandX;
      this.expandY = cell.expandY;
      this.colspan = cell.colspan;
      this.uniformX = cell.uniformX;
      this.uniformY = cell.uniformY;
      return this;
    }

    [Signature("(Larc/func/Cons<TT;>;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {115, 103, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell update(Cons updater)
    {
      Element element = this.get();
      element.update((Runnable) new Cell.__\u003C\u003EAnon0(updater, element));
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {98, 127, 17})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell size(float size)
    {
      Cell cell1 = this;
      Cell cell2 = this;
      Cell cell3 = this;
      float num1 = this.scl(size);
      double num2 = (double) num1;
      this.maxHeight = num1;
      float num3 = (float) num2;
      double num4 = (double) num3;
      this.maxWidth = num3;
      float num5 = (float) num4;
      double num6 = (double) num5;
      this.minHeight = num5;
      this.minWidth = (float) num6;
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {161, 52, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell padTop(float padTop)
    {
      this.padTop = this.scl(padTop);
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {161, 57, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell padLeft(float padLeft)
    {
      this.padLeft = this.scl(padLeft);
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {161, 67, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell padRight(float padRight)
    {
      this.padRight = this.scl(padRight);
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 134, 109, 115, 109, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell wrap()
    {
      if (this.get() is Label)
        ((Label) this.get()).setWrap(true);
      else if (this.get() is TextButton)
        ((TextButton) this.get()).getLabel().setWrap(true);
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell growX()
    {
      this.expandX = 1;
      this.fillX = 1f;
      return this;
    }

    [LineNumberTable(new byte[] {162, 24, 103, 103, 103, 135, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.element = (Element) null;
      this.table = (Table) null;
      this.endRow = false;
      this.cellAboveIndex = -1;
      Cell cell = Cell.defaults();
      if (cell == null)
        return;
      this.set(cell);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void clear()
    {
      this.minWidth = float.NegativeInfinity;
      this.minHeight = float.NegativeInfinity;
      this.maxWidth = float.NegativeInfinity;
      this.maxHeight = float.NegativeInfinity;
      this.padTop = 0.0f;
      this.padLeft = 0.0f;
      this.padBottom = 0.0f;
      this.padRight = 0.0f;
      this.fillX = 0.0f;
      this.fillY = 0.0f;
      this.align = 0;
      this.expandX = 0;
      this.expandY = 0;
      this.colspan = 1;
      this.uniformX = false;
      this.uniformY = false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBounds(float x, float y, float width, float height)
    {
      this.elementX = x;
      this.elementY = y;
      this.elementWidth = width;
      this.elementHeight = height;
    }

    [LineNumberTable(118)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float prefWidth() => this.element == null ? 0.0f : this.element.getPrefWidth();

    [LineNumberTable(122)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float prefHeight() => this.element == null ? 0.0f : this.element.getPrefHeight();

    [LineNumberTable(134)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float minWidth()
    {
      if ((double) this.minWidth != double.NegativeInfinity)
        return this.minWidth;
      return this.element == null ? 0.0f : this.element.getMinWidth();
    }

    [LineNumberTable(138)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float minHeight()
    {
      if ((double) this.minHeight != double.NegativeInfinity)
        return this.minHeight;
      return this.element == null ? 0.0f : this.element.getMinHeight();
    }

    [LineNumberTable(126)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float maxWidth()
    {
      if ((double) this.maxWidth != double.NegativeInfinity)
        return this.maxWidth;
      return this.element == null ? 0.0f : this.element.getMaxWidth();
    }

    [LineNumberTable(130)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float maxHeight()
    {
      if ((double) this.maxHeight != double.NegativeInfinity)
        return this.maxHeight;
      return this.element == null ? 0.0f : this.element.getMaxHeight();
    }

    [LineNumberTable(new byte[] {159, 187, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Cell()
    {
      Cell cell = this;
      this.reset();
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell expandX()
    {
      this.expandX = 1;
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell fillX()
    {
      this.fillX = 1f;
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {161, 5, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell minWidth(float minWidth)
    {
      this.minWidth = this.scl(minWidth);
      return this;
    }

    [LineNumberTable(new byte[] {161, 246, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void row() => this.table.row();

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {161, 39, 127, 17})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell pad(float pad)
    {
      Cell cell1 = this;
      Cell cell2 = this;
      Cell cell3 = this;
      float num1 = this.scl(pad);
      double num2 = (double) num1;
      this.padRight = num1;
      float num3 = (float) num2;
      double num4 = (double) num3;
      this.padBottom = num3;
      float num5 = (float) num4;
      double num6 = (double) num5;
      this.padLeft = num5;
      this.padTop = (float) num6;
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell expand()
    {
      this.expandX = 1;
      this.expandY = 1;
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell fill()
    {
      this.fillX = 1f;
      this.fillY = 1f;
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 243, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell height(float height)
    {
      Cell cell = this;
      float num1 = this.scl(height);
      double num2 = (double) num1;
      this.maxHeight = num1;
      this.minHeight = (float) num2;
      return this;
    }

    [Signature("(FF)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {104, 122, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell size(float width, float height)
    {
      Cell cell1 = this;
      float num1 = this.scl(width);
      double num2 = (double) num1;
      this.maxWidth = num1;
      this.minWidth = (float) num2;
      Cell cell2 = this;
      float num3 = this.scl(height);
      double num4 = (double) num3;
      this.maxHeight = num3;
      this.minHeight = (float) num4;
      return this;
    }

    [Signature("()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element get() => this.element;

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 224, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell width(float width)
    {
      Cell cell = this;
      float num1 = this.scl(width);
      double num2 = (double) num1;
      this.maxWidth = num1;
      this.minWidth = (float) num2;
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell right()
    {
      this.align = (this.align | 16) & -9;
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell left()
    {
      this.align = (this.align | 8) & -17;
      return this;
    }

    [Signature("(Larc/graphics/Color;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 183, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell color(Color color)
    {
      this.get().setColor(color);
      return this;
    }

    [Signature("(Larc/util/Scaling;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 95, 109, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell scaling(Scaling scaling)
    {
      if (this.element is Image)
        ((Image) this.element).setScaling(scaling);
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell center()
    {
      this.align = 1;
      return this;
    }

    [Signature("(Larc/scene/style/Style;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 230, 101, 109, 120, 109, 120, 109, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell style(Style style)
    {
      if (style == null)
        return this;
      if (this.element is Label)
        ((Label) this.element).setStyle((Label.LabelStyle) style);
      else if (this.element is Button)
        ((Button) this.element).setStyle((Button.ButtonStyle) style);
      else if (this.element is ScrollPane)
        ((ScrollPane) this.element).setStyle((ScrollPane.ScrollPaneStyle) style);
      return this;
    }

    [Signature("(FFFF)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {161, 44, 111, 111, 111, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell pad(float top, float left, float bottom, float right)
    {
      this.padTop = this.scl(top);
      this.padLeft = this.scl(left);
      this.padBottom = this.scl(bottom);
      this.padRight = this.scl(right);
      return this;
    }

    [Signature("(I)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(264)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell labelAlign(int label) => this.labelAlign(label, label);

    [Signature("(Larc/func/Boolf<TT;>;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {121, 109, 103, 124, 111, 103, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell disabled(Boolf vis)
    {
      if (this.element is Button)
      {
        Element element = this.get();
        ((Button) this.element).setDisabled((Boolp) new Cell.__\u003C\u003EAnon1(vis, element));
      }
      else if (this.element is Disableable)
      {
        Element element = this.get();
        this.element.update((Runnable) new Cell.__\u003C\u003EAnon2(this, vis, element));
      }
      return this;
    }

    [Signature("(I)Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell colspan(int colspan)
    {
      this.colspan = colspan;
      return this;
    }

    [Signature("(Larc/func/Boolf<TT;>;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 168, 103, 104, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell @checked(Boolf toggle)
    {
      Element element = this.get();
      if (element is Button)
        element.update((Runnable) new Cell.__\u003C\u003EAnon3(element, toggle));
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {161, 62, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell padBottom(float padBottom)
    {
      this.padBottom = this.scl(padBottom);
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 188, 109, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell margin(float margin)
    {
      if (this.get() is Table)
        ((Table) this.get()).margin(margin);
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell grow()
    {
      this.expandX = 1;
      this.expandY = 1;
      this.fillX = 1f;
      this.fillY = 1f;
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell expandY()
    {
      this.expandY = 1;
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell top()
    {
      this.align = (this.align | 2) & -5;
      return this;
    }

    [Signature("(Ljava/lang/String;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {92, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell tooltip(string text)
    {
      this.element.addListener((EventListener) Tooltip.Tooltips.getInstance().create(text));
      return this;
    }

    [Signature("(Ljava/lang/String;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {110, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell name(string name)
    {
      this.get().name = name;
      return this;
    }

    [Signature("(I)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 110, 109, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell maxTextLength(int length)
    {
      if (this.element is TextField)
        ((TextField) this.element).setMaxLength(length);
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell growY()
    {
      this.expandY = 1;
      this.fillY = 1f;
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell fillY()
    {
      this.fillY = 1f;
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell uniformX()
    {
      this.uniformX = true;
      return this;
    }

    [Signature("(I)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 126, 109, 113, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell addInputDialog(int maxLength)
    {
      if (this.element is TextField)
      {
        ((TextField) this.element).setMaxLength(maxLength);
        ((TextField) this.element).addInputDialog();
      }
      return this;
    }

    [Signature("(Larc/scene/ui/TextField$TextFieldValidator;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 102, 109, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell valid(TextField.TextFieldValidator val)
    {
      if (this.element is TextField)
        ((TextField) this.element).setValidator(val);
      return this;
    }

    [Signature("<N:Larc/scene/ui/Button;>(Larc/scene/ui/ButtonGroup<TN;>;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 154, 109, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell group(ButtonGroup group)
    {
      if (this.get() is Button)
        group.add((Button) this.get());
      return this;
    }

    [Signature("(Larc/func/Boolp;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 85, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell visible(Boolp prov)
    {
      this.get().visible(prov);
      return this;
    }

    [Signature("<A:Larc/scene/Element;>(TA;)Larc/scene/ui/layout/Cell<TA;>;")]
    [LineNumberTable(new byte[] {33, 110, 116, 103, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell setElement(Element newElement)
    {
      if (!object.ReferenceEquals((object) this.element, (object) newElement))
      {
        if (this.element != null)
          this.element.remove();
        this.element = newElement;
        if (newElement != null)
          this.table.addChild(newElement);
      }
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 118, 109, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell addInputDialog()
    {
      if (this.element is TextField)
        ((TextField) this.element).addInputDialog();
      return this;
    }

    [Signature("(Larc/func/Cons<Larc/scene/ui/layout/Cell<TT;>;>;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {53, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell self(Cons c)
    {
      c.get((object) this);
      return this;
    }

    [Signature("(Z)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {159, 74, 162, 109, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell @checked(bool toggle)
    {
      int num = toggle ? 1 : 0;
      if (this.get() is Button)
        ((Button) this.get()).setChecked(num != 0);
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 209, 109, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell marginLeft(float margin)
    {
      if (this.get() is Table)
        ((Table) this.get()).marginLeft(margin);
      return this;
    }

    [Signature("(II)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 143, 109, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell labelAlign(int label, int line)
    {
      if (this.get() is Label)
        ((Label) this.get()).setAlignment(label, line);
      return this;
    }

    [Signature("(Z)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {159, 97, 130, 109, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell disabled(bool disabled)
    {
      int num = disabled ? 1 : 0;
      if (this.get() is Disableable)
        ((Disableable) this.get()).setDisabled(num != 0);
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell uniform()
    {
      this.uniformX = true;
      this.uniformY = true;
      return this;
    }

    [Signature("(I)Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell align(int align)
    {
      this.align = align;
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell bottom()
    {
      this.align = (this.align | 4) & -3;
      return this;
    }

    [Signature("(Larc/func/Cons<TT;>;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {48, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell with(Cons c)
    {
      c.get((object) this.element);
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {161, 28, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell maxWidth(float maxWidth)
    {
      this.maxWidth = this.scl(maxWidth);
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {161, 16, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell maxSize(float size)
    {
      Cell cell = this;
      float num1 = this.scl(size);
      double num2 = (double) num1;
      this.maxHeight = num1;
      this.maxWidth = (float) num2;
      return this;
    }

    [Signature("(Z)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {159, 91, 66, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell visible(bool visible)
    {
      int num = visible ? 1 : 0;
      this.get().visible = num != 0;
      return this;
    }

    [Signature("(Larc/scene/event/Touchable;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 75, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell touchable(Touchable touchable)
    {
      this.get().touchable = touchable;
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {161, 33, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell maxHeight(float maxHeight)
    {
      this.maxHeight = this.scl(maxHeight);
      return this;
    }

    [Signature("(Larc/func/Prov<Larc/scene/event/Touchable;>;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 80, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell touchable(Prov touchable)
    {
      this.get().touchable(touchable);
      return this;
    }

    [LineNumberTable(644)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual float scl([In] float obj0) => Scl.scl(obj0);

    [LineNumberTable(new byte[] {4, 106, 102, 106, 111, 111, 111, 111, 111, 111, 111, 111, 111, 111, 107, 107, 107, 107, 107, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Cell defaults()
    {
      if (!Cell.dset)
      {
        Cell.dset = true;
        Cell.defaults = new Cell();
        Cell.defaults.minWidth = float.NegativeInfinity;
        Cell.defaults.minHeight = float.NegativeInfinity;
        Cell.defaults.maxWidth = float.NegativeInfinity;
        Cell.defaults.maxHeight = float.NegativeInfinity;
        Cell.defaults.padTop = 0.0f;
        Cell.defaults.padLeft = 0.0f;
        Cell.defaults.padBottom = 0.0f;
        Cell.defaults.padRight = 0.0f;
        Cell.defaults.fillX = 0.0f;
        Cell.defaults.fillY = 0.0f;
        Cell.defaults.align = 0;
        Cell.defaults.expandX = 0;
        Cell.defaults.expandY = 0;
        Cell.defaults.colspan = 1;
        Cell.defaults.uniformX = false;
        Cell.defaults.uniformY = false;
      }
      return Cell.defaults;
    }

    [Modifiers]
    [LineNumberTable(166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024update\u00240([In] Cons obj0, [In] Element obj1) => obj0.get((object) obj1);

    [Modifiers]
    [LineNumberTable(173)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024disabled\u00241([In] Boolf obj0, [In] Element obj1) => obj0.get((object) obj1);

    [Modifiers]
    [LineNumberTable(176)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024disabled\u00242([In] Boolf obj0, [In] Element obj1) => ((Disableable) this.element).setDisabled(obj0.get((object) obj1));

    [Modifiers]
    [LineNumberTable(284)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024checked\u00243([In] Element obj0, [In] Boolf obj1) => ((Button) obj0).setChecked(obj1.get((object) obj0));

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {43, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell clearElement()
    {
      this.setElement((Element) null);
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasElement() => this.element != null;

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 176, 109, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell fontScale(float scale)
    {
      if (this.element is Label)
        ((Label) this.element).setFontScale(scale);
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 195, 109, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell marginTop(float margin)
    {
      if (this.get() is Table)
        ((Table) this.get()).marginTop(margin);
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 202, 109, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell marginBottom(float margin)
    {
      if (this.get() is Table)
        ((Table) this.get()).marginBottom(margin);
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 216, 109, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell marginRight(float margin)
    {
      if (this.get() is Table)
        ((Table) this.get()).marginRight(margin);
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 249, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell minSize(float size)
    {
      Cell cell = this;
      float num1 = this.scl(size);
      double num2 = (double) num1;
      this.minHeight = num1;
      this.minWidth = (float) num2;
      return this;
    }

    [Signature("(FF)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 255, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell minSize(float width, float height)
    {
      this.minWidth = this.scl(width);
      this.minHeight = this.scl(height);
      return this;
    }

    [Signature("(F)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {161, 10, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell minHeight(float minHeight)
    {
      this.minHeight = this.scl(minHeight);
      return this;
    }

    [Signature("(FF)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {161, 22, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell maxSize(float width, float height)
    {
      this.maxWidth = this.scl(width);
      this.maxHeight = this.scl(height);
      return this;
    }

    [Signature("(FF)Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell fill(float x, float y)
    {
      this.fillX = x;
      this.fillY = y;
      return this;
    }

    [Signature("(ZZ)Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell fill(bool x, bool y)
    {
      int num1 = x ? 1 : 0;
      int num2 = y ? 1 : 0;
      this.fillX = num1 == 0 ? 0.0f : 1f;
      this.fillY = num2 == 0 ? 0.0f : 1f;
      return this;
    }

    [Signature("(Z)Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell fill(bool fill)
    {
      int num = fill ? 1 : 0;
      this.fillX = num == 0 ? 0.0f : 1f;
      this.fillY = num == 0 ? 0.0f : 1f;
      return this;
    }

    [Signature("(II)Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell expand(int x, int y)
    {
      this.expandX = x;
      this.expandY = y;
      return this;
    }

    [Signature("(ZZ)Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell expand(bool x, bool y)
    {
      int num1 = x ? 1 : 0;
      int num2 = y ? 1 : 0;
      this.expandX = num1 == 0 ? 0 : 1;
      this.expandY = num2 == 0 ? 0 : 1;
      return this;
    }

    [Signature("()Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell uniformY()
    {
      this.uniformY = true;
      return this;
    }

    [Signature("(ZZ)Larc/scene/ui/layout/Cell<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell uniform(bool x, bool y)
    {
      int num1 = x ? 1 : 0;
      int num2 = y ? 1 : 0;
      this.uniformX = num1 != 0;
      this.uniformY = num2 != 0;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEndRow() => this.endRow;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table getTable() => this.table;

    [LineNumberTable(680)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.element != null ? this.element.toString() : base.toString();

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly Cons arg\u00241;
      private readonly Element arg\u00242;

      internal __\u003C\u003EAnon0([In] Cons obj0, [In] Element obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => Cell.lambda\u0024update\u00240(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolp
    {
      private readonly Boolf arg\u00241;
      private readonly Element arg\u00242;

      internal __\u003C\u003EAnon1([In] Boolf obj0, [In] Element obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get() => (Cell.lambda\u0024disabled\u00241(this.arg\u00241, this.arg\u00242) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly Cell arg\u00241;
      private readonly Boolf arg\u00242;
      private readonly Element arg\u00243;

      internal __\u003C\u003EAnon2([In] Cell obj0, [In] Boolf obj1, [In] Element obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024disabled\u00242(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly Element arg\u00241;
      private readonly Boolf arg\u00242;

      internal __\u003C\u003EAnon3([In] Element obj0, [In] Boolf obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => Cell.lambda\u0024checked\u00243(this.arg\u00241, this.arg\u00242);
    }
  }
}
