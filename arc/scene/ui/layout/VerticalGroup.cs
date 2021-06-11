// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.layout.VerticalGroup
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.scene.@event;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.scene.ui.layout
{
  public class VerticalGroup : WidgetGroup
  {
    private float prefWidth;
    private float prefHeight;
    private float lastPrefWidth;
    private bool sizeInvalid;
    private FloatSeq columnSizes;
    private int align;
    private int columnAlign;
    private bool reverse;
    private bool round;
    private bool wrap;
    private bool expand;
    private float space;
    private float wrapSpace;
    private float fill;
    private float padTop;
    private float padLeft;
    private float padBottom;
    private float padRight;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 182, 103, 103, 103, 107, 107, 107, 104, 141, 107, 103, 111, 127, 19, 102, 104, 101, 98, 131, 104, 175, 100, 106, 140, 106, 170, 119, 118, 104, 104, 120, 113, 104, 103, 103, 132, 104, 236, 40, 236, 90, 104, 104, 120, 113, 120, 101, 127, 3, 107, 111, 100, 122, 152, 122, 246, 57, 235, 75, 124, 104, 114, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void computeSize()
    {
      this.sizeInvalid = false;
      SnapshotSeq children = this.getChildren();
      int num1 = children.size;
      this.prefWidth = 0.0f;
      if (this.wrap)
      {
        this.prefHeight = 0.0f;
        if (this.columnSizes == null)
          this.columnSizes = new FloatSeq();
        else
          this.columnSizes.clear();
        FloatSeq columnSizes = this.columnSizes;
        float space = this.space;
        float wrapSpace = this.wrapSpace;
        float num2 = this.padTop + this.padBottom;
        float num3 = this.getHeight() - num2;
        float num4 = 0.0f;
        float num5 = 0.0f;
        float num6 = 0.0f;
        int index = 0;
        int num7 = 1;
        if (this.reverse)
        {
          index = num1 - 1;
          num1 = -1;
          num7 = -1;
        }
        for (; index != num1; index += num7)
        {
          Element element = (Element) children.get(index);
          float num8;
          float num9;
          if (element != null)
          {
            num8 = element.getPrefWidth();
            num9 = element.getPrefHeight();
          }
          else
          {
            num8 = element.getWidth();
            num9 = element.getHeight();
          }
          float num10 = num9 + ((double) num5 <= 0.0 ? 0.0f : space);
          if ((double) (num5 + num10) > (double) num3 && (double) num5 > 0.0)
          {
            columnSizes.add(num5);
            columnSizes.add(num6);
            this.prefHeight = Math.max(this.prefHeight, num5 + num2);
            if ((double) num4 > 0.0)
              num4 += wrapSpace;
            num4 += num6;
            num6 = 0.0f;
            num5 = 0.0f;
            num10 = num9;
          }
          num5 += num10;
          num6 = Math.max(num6, num8);
        }
        columnSizes.add(num5);
        columnSizes.add(num6);
        this.prefHeight = Math.max(this.prefHeight, num5 + num2);
        if ((double) num4 > 0.0)
          num4 += wrapSpace;
        this.prefWidth = Math.max(this.prefWidth, num4 + num6);
      }
      else
      {
        this.prefHeight = this.padTop + this.padBottom + this.space * (float) (num1 - 1);
        for (int index = 0; index < num1; ++index)
        {
          Element element = (Element) children.get(index);
          if (element != null)
          {
            this.prefWidth = Math.max(this.prefWidth, element.getPrefWidth());
            this.prefHeight += element.getPrefHeight();
          }
          else
          {
            this.prefWidth = Math.max(this.prefWidth, element.getWidth());
            this.prefHeight += element.getHeight();
          }
        }
      }
      this.prefWidth += this.padLeft + this.padRight;
      if (!this.round)
        return;
      this.prefWidth = (float) Math.round(this.prefWidth);
      this.prefHeight = (float) Math.round(this.prefHeight);
    }

    [LineNumberTable(new byte[] {127, 104, 105, 103, 166, 103, 103, 127, 0, 120, 109, 159, 2, 102, 114, 101, 151, 101, 114, 101, 151, 135, 104, 104, 111, 104, 102, 99, 131, 108, 176, 106, 170, 120, 100, 101, 118, 101, 123, 101, 104, 136, 110, 166, 145, 114, 106, 147, 100, 102, 110, 101, 147, 107, 99, 159, 10, 143, 231, 24, 236, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void layoutWrapped()
    {
      float prefWidth = this.getPrefWidth();
      if ((double) prefWidth != (double) this.lastPrefWidth)
      {
        this.lastPrefWidth = prefWidth;
        this.invalidateHierarchy();
      }
      int align = this.align;
      int num1 = this.round ? 1 : 0;
      float space = this.space;
      float padLeft = this.padLeft;
      float fill = this.fill;
      float wrapSpace = this.wrapSpace;
      float num2 = this.prefHeight - this.padTop - this.padBottom;
      float num3 = padLeft;
      float height = this.getHeight();
      float num4 = this.prefHeight - this.padTop + space;
      float y = 0.0f;
      float num5 = 0.0f;
      if ((align & 16) != 0)
        num3 += this.getWidth() - prefWidth;
      else if ((align & 8) == 0)
        num3 += (this.getWidth() - prefWidth) / 2f;
      if ((align & 2) != 0)
        num4 += height - this.prefHeight;
      else if ((align & 4) == 0)
        num4 += (height - this.prefHeight) / 2f;
      int columnAlign = this.columnAlign;
      FloatSeq columnSizes = this.columnSizes;
      SnapshotSeq children = this.getChildren();
      int index1 = 0;
      int num6 = children.size;
      int num7 = 1;
      if (this.reverse)
      {
        index1 = num6 - 1;
        num6 = -1;
        num7 = -1;
      }
      int index2 = 0;
      for (; index1 != num6; index1 += num7)
      {
        Element element = (Element) children.get(index1);
        float num8 = element.getPrefWidth();
        float prefHeight = element.getPrefHeight();
        if ((double) (y - prefHeight - space) < (double) this.padBottom || index2 == 0)
        {
          y = num4;
          if ((columnAlign & 4) != 0)
            y -= num2 - columnSizes.get(index2);
          else if ((columnAlign & 2) == 0)
            y -= (num2 - columnSizes.get(index2)) / 2f;
          if (index2 > 0)
            num3 = num3 + wrapSpace + num5;
          num5 = columnSizes.get(index2 + 1);
          index2 += 2;
        }
        if ((double) fill > 0.0)
          num8 = num5 * fill;
        float width = Math.max(num8, element.getMinWidth());
        float maxWidth = element.getMaxWidth();
        if ((double) maxWidth > 0.0 && (double) width > (double) maxWidth)
          width = maxWidth;
        float x = num3;
        if ((columnAlign & 16) != 0)
          x += num5 - width;
        else if ((columnAlign & 8) == 0)
          x += (num5 - width) / 2f;
        y -= prefHeight + space;
        if (num1 != 0)
          element.setBounds((float) Math.round(x), (float) Math.round(y), (float) Math.round(width), (float) Math.round(prefHeight));
        else
          element.setBounds(x, y, width, prefHeight);
        element.validate();
      }
    }

    [LineNumberTable(new byte[] {160, 142, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefWidth()
    {
      if (this.sizeInvalid)
        this.computeSize();
      return this.prefWidth;
    }

    [LineNumberTable(new byte[] {159, 171, 232, 57, 167, 103, 199, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VerticalGroup()
    {
      VerticalGroup verticalGroup = this;
      this.sizeInvalid = true;
      this.align = 2;
      this.round = true;
      this.touchable = Touchable.__\u003C\u003EchildrenOnly;
    }

    [LineNumberTable(new byte[] {159, 177, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void invalidate()
    {
      base.invalidate();
      this.sizeInvalid = true;
    }

    [LineNumberTable(new byte[] {62, 142, 104, 102, 161, 103, 103, 118, 159, 24, 101, 119, 101, 188, 101, 101, 102, 151, 159, 3, 135, 104, 111, 104, 102, 99, 131, 105, 176, 106, 170, 145, 114, 106, 147, 100, 102, 110, 101, 147, 107, 99, 159, 10, 143, 231, 38, 236, 92})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void layout()
    {
      if (this.sizeInvalid)
        this.computeSize();
      if (this.wrap)
      {
        this.layoutWrapped();
      }
      else
      {
        int num1 = this.round ? 1 : 0;
        int align = this.align;
        float space = this.space;
        float padLeft = this.padLeft;
        float fill = this.fill;
        float num2 = (!this.expand ? this.prefWidth : this.getWidth()) - padLeft - this.padRight;
        float y = this.prefHeight - this.padTop + space;
        if ((align & 2) != 0)
          y += this.getHeight() - this.prefHeight;
        else if ((align & 4) == 0)
          y += (this.getHeight() - this.prefHeight) / 2f;
        float num3 = (align & 8) == 0 ? ((align & 16) == 0 ? padLeft + (this.getWidth() - padLeft - this.padRight - num2) / 2f : this.getWidth() - this.padRight - num2) : padLeft;
        int columnAlign = this.columnAlign;
        SnapshotSeq children = this.getChildren();
        int index = 0;
        int num4 = children.size;
        int num5 = 1;
        if (this.reverse)
        {
          index = num4 - 1;
          num4 = -1;
          num5 = -1;
        }
        for (; index != num4; index += num5)
        {
          Element element = (Element) children.get(index);
          float num6 = element.getPrefWidth();
          float prefHeight = element.getPrefHeight();
          if ((double) fill > 0.0)
            num6 = num2 * fill;
          float width = Math.max(num6, element.getMinWidth());
          float maxWidth = element.getMaxWidth();
          if ((double) maxWidth > 0.0 && (double) width > (double) maxWidth)
            width = maxWidth;
          float x = num3;
          if ((columnAlign & 16) != 0)
            x += num2 - width;
          else if ((columnAlign & 8) == 0)
            x += (num2 - width) / 2f;
          y -= prefHeight + space;
          if (num1 != 0)
            element.setBounds((float) Math.round(x), (float) Math.round(y), (float) Math.round(width), (float) Math.round(prefHeight));
          else
            element.setBounds(x, y, width, prefHeight);
          element.validate();
        }
      }
    }

    [LineNumberTable(new byte[] {160, 148, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefHeight()
    {
      if (this.wrap)
        return 0.0f;
      if (this.sizeInvalid)
        this.computeSize();
      return this.prefHeight;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRound(bool round) => this.round = round;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup reverse()
    {
      this.reverse = true;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup reverse(bool reverse)
    {
      this.reverse = reverse;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getReverse() => this.reverse;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup space(float space)
    {
      this.space = space;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getSpace() => this.space;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup wrapSpace(float wrapSpace)
    {
      this.wrapSpace = wrapSpace;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getWrapSpace() => this.wrapSpace;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup margin(float pad)
    {
      this.padTop = pad;
      this.padLeft = pad;
      this.padBottom = pad;
      this.padRight = pad;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup margin(
      float top,
      float left,
      float bottom,
      float right)
    {
      this.padTop = top;
      this.padLeft = left;
      this.padBottom = bottom;
      this.padRight = right;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup padTop(float padTop)
    {
      this.padTop = padTop;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup padLeft(float padLeft)
    {
      this.padLeft = padLeft;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup padBottom(float padBottom)
    {
      this.padBottom = padBottom;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup padRight(float padRight)
    {
      this.padRight = padRight;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPadTop() => this.padTop;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPadLeft() => this.padLeft;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPadBottom() => this.padBottom;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPadRight() => this.padRight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup align(int align)
    {
      this.align = align;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup center()
    {
      this.align = 1;
      return this;
    }

    [LineNumberTable(new byte[] {161, 8, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup top()
    {
      this.align |= 2;
      this.align &= -5;
      return this;
    }

    [LineNumberTable(new byte[] {161, 15, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup left()
    {
      this.align |= 8;
      this.align &= -17;
      return this;
    }

    [LineNumberTable(new byte[] {161, 22, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup bottom()
    {
      this.align |= 4;
      this.align &= -3;
      return this;
    }

    [LineNumberTable(new byte[] {161, 29, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup right()
    {
      this.align |= 16;
      this.align &= -9;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getAlign() => this.align;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup fill()
    {
      this.fill = 1f;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup fill(float fill)
    {
      this.fill = fill;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFill() => this.fill;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup expand()
    {
      this.expand = true;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup expand(bool expand)
    {
      this.expand = expand;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getExpand() => this.expand;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup grow()
    {
      this.expand = true;
      this.fill = 1f;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup wrap()
    {
      this.wrap = true;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup wrap(bool wrap)
    {
      this.wrap = wrap;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getWrap() => this.wrap;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup columnAlign(int columnAlign)
    {
      this.columnAlign = columnAlign;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup columnCenter()
    {
      this.columnAlign = 1;
      return this;
    }

    [LineNumberTable(new byte[] {161, 115, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup columnLeft()
    {
      this.columnAlign |= 8;
      this.columnAlign &= -17;
      return this;
    }

    [LineNumberTable(new byte[] {161, 122, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual VerticalGroup columnRight()
    {
      this.columnAlign |= 16;
      this.columnAlign &= -9;
      return this;
    }

    [HideFromJava]
    static VerticalGroup() => WidgetGroup.__\u003Cclinit\u003E();
  }
}
