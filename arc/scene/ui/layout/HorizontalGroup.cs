// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.layout.HorizontalGroup
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
  public class HorizontalGroup : WidgetGroup
  {
    private float prefWidth;
    private float prefHeight;
    private float lastPrefHeight;
    private bool sizeInvalid;
    private FloatSeq rowSizes;
    private int align;
    private int rowAlign;
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

    [LineNumberTable(new byte[] {159, 184, 103, 103, 103, 107, 107, 107, 104, 141, 107, 103, 111, 127, 19, 102, 104, 101, 98, 131, 104, 175, 100, 106, 140, 106, 170, 119, 118, 104, 104, 120, 113, 104, 103, 103, 132, 104, 236, 40, 236, 90, 104, 104, 120, 113, 120, 101, 127, 3, 107, 111, 100, 118, 156, 118, 250, 57, 235, 75, 124, 104, 114, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void computeSize()
    {
      this.sizeInvalid = false;
      SnapshotSeq children = this.getChildren();
      int num1 = children.size;
      this.prefHeight = 0.0f;
      if (this.wrap)
      {
        this.prefWidth = 0.0f;
        if (this.rowSizes == null)
          this.rowSizes = new FloatSeq();
        else
          this.rowSizes.clear();
        FloatSeq rowSizes = this.rowSizes;
        float space = this.space;
        float wrapSpace = this.wrapSpace;
        float num2 = this.padLeft + this.padRight;
        float num3 = this.getWidth() - num2;
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
          float num10 = num8 + ((double) num4 <= 0.0 ? 0.0f : space);
          if ((double) (num4 + num10) > (double) num3 && (double) num4 > 0.0)
          {
            rowSizes.add(num4);
            rowSizes.add(num6);
            this.prefWidth = Math.max(this.prefWidth, num4 + num2);
            if ((double) num5 > 0.0)
              num5 += wrapSpace;
            num5 += num6;
            num6 = 0.0f;
            num4 = 0.0f;
            num10 = num8;
          }
          num4 += num10;
          num6 = Math.max(num6, num9);
        }
        rowSizes.add(num4);
        rowSizes.add(num6);
        this.prefWidth = Math.max(this.prefWidth, num4 + num2);
        if ((double) num5 > 0.0)
          num5 += wrapSpace;
        this.prefHeight = Math.max(this.prefHeight, num5 + num6);
      }
      else
      {
        this.prefWidth = this.padLeft + this.padRight + this.space * (float) (num1 - 1);
        for (int index = 0; index < num1; ++index)
        {
          Element element = (Element) children.get(index);
          if (element != null)
          {
            this.prefWidth += element.getPrefWidth();
            this.prefHeight = Math.max(this.prefHeight, element.getPrefHeight());
          }
          else
          {
            this.prefWidth += element.getWidth();
            this.prefHeight = Math.max(this.prefHeight, element.getHeight());
          }
        }
      }
      this.prefHeight += this.padTop + this.padBottom;
      if (!this.round)
        return;
      this.prefWidth = (float) Math.round(this.prefWidth);
      this.prefHeight = (float) Math.round(this.prefHeight);
    }

    [LineNumberTable(new byte[] {160, 65, 104, 105, 103, 166, 103, 103, 119, 120, 159, 11, 101, 114, 101, 151, 102, 114, 101, 151, 108, 135, 104, 104, 111, 104, 102, 99, 131, 108, 176, 106, 170, 113, 100, 102, 118, 101, 123, 110, 109, 104, 166, 145, 114, 106, 147, 100, 101, 110, 101, 147, 99, 159, 10, 111, 139, 231, 26, 236, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void layoutWrapped()
    {
      float prefHeight = this.getPrefHeight();
      if ((double) prefHeight != (double) this.lastPrefHeight)
      {
        this.lastPrefHeight = prefHeight;
        this.invalidateHierarchy();
      }
      int align = this.align;
      int num1 = this.round ? 1 : 0;
      float space = this.space;
      float fill = this.fill;
      float wrapSpace = this.wrapSpace;
      float num2 = this.prefWidth - this.padLeft - this.padRight;
      float num3 = prefHeight - this.padTop;
      float width = this.getWidth();
      float padLeft = this.padLeft;
      float x = 0.0f;
      float num4 = 0.0f;
      if ((align & 2) != 0)
        num3 += this.getHeight() - prefHeight;
      else if ((align & 4) == 0)
        num3 += (this.getHeight() - prefHeight) / 2f;
      if ((align & 16) != 0)
        padLeft += width - this.prefWidth;
      else if ((align & 8) == 0)
        padLeft += (width - this.prefWidth) / 2f;
      float num5 = width - this.padRight;
      int rowAlign = this.rowAlign;
      FloatSeq rowSizes = this.rowSizes;
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
        float prefWidth = element.getPrefWidth();
        float num8 = element.getPrefHeight();
        if ((double) (x + prefWidth) > (double) num5 || index2 == 0)
        {
          x = padLeft;
          if ((rowAlign & 16) != 0)
            x += num2 - rowSizes.get(index2);
          else if ((rowAlign & 8) == 0)
            x += (num2 - rowSizes.get(index2)) / 2f;
          num4 = rowSizes.get(index2 + 1);
          if (index2 > 0)
            num3 -= wrapSpace;
          num3 -= num4;
          index2 += 2;
        }
        if ((double) fill > 0.0)
          num8 = num4 * fill;
        float height = Math.max(num8, element.getMinHeight());
        float maxHeight = element.getMaxHeight();
        if ((double) maxHeight > 0.0 && (double) height > (double) maxHeight)
          height = maxHeight;
        float y = num3;
        if ((rowAlign & 2) != 0)
          y += num4 - height;
        else if ((rowAlign & 4) == 0)
          y += (num4 - height) / 2f;
        if (num1 != 0)
          element.setBounds((float) Math.round(x), (float) Math.round(y), (float) Math.round(prefWidth), (float) Math.round(height));
        else
          element.setBounds(x, y, prefWidth, height);
        x += prefWidth + space;
        element.validate();
      }
    }

    [LineNumberTable(new byte[] {160, 149, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefHeight()
    {
      if (this.sizeInvalid)
        this.computeSize();
      return this.prefHeight;
    }

    [LineNumberTable(new byte[] {159, 173, 232, 57, 167, 103, 199, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public HorizontalGroup()
    {
      HorizontalGroup horizontalGroup = this;
      this.sizeInvalid = true;
      this.align = 8;
      this.round = true;
      this.touchable = Touchable.__\u003C\u003EchildrenOnly;
    }

    [LineNumberTable(new byte[] {159, 179, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void invalidate()
    {
      base.invalidate();
      this.sizeInvalid = true;
    }

    [LineNumberTable(new byte[] {64, 142, 104, 102, 161, 103, 103, 118, 159, 13, 102, 119, 101, 188, 101, 101, 101, 151, 159, 3, 135, 104, 111, 104, 102, 99, 131, 105, 176, 106, 170, 145, 114, 106, 147, 100, 101, 110, 101, 147, 99, 159, 10, 111, 139, 231, 38, 236, 92})]
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
        float padBottom = this.padBottom;
        float fill = this.fill;
        float num2 = (!this.expand ? this.prefHeight : this.getHeight()) - this.padTop - padBottom;
        float padLeft = this.padLeft;
        if ((align & 16) != 0)
          padLeft += this.getWidth() - this.prefWidth;
        else if ((align & 8) == 0)
          padLeft += (this.getWidth() - this.prefWidth) / 2f;
        float num3 = (align & 4) == 0 ? ((align & 2) == 0 ? padBottom + (this.getHeight() - padBottom - this.padTop - num2) / 2f : this.getHeight() - this.padTop - num2) : padBottom;
        int rowAlign = this.rowAlign;
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
          float prefWidth = element.getPrefWidth();
          float num6 = element.getPrefHeight();
          if ((double) fill > 0.0)
            num6 = num2 * fill;
          float height = Math.max(num6, element.getMinHeight());
          float maxHeight = element.getMaxHeight();
          if ((double) maxHeight > 0.0 && (double) height > (double) maxHeight)
            height = maxHeight;
          float y = num3;
          if ((rowAlign & 2) != 0)
            y += num2 - height;
          else if ((rowAlign & 4) == 0)
            y += (num2 - height) / 2f;
          if (num1 != 0)
            element.setBounds((float) Math.round(padLeft), (float) Math.round(y), (float) Math.round(prefWidth), (float) Math.round(height));
          else
            element.setBounds(padLeft, y, prefWidth, height);
          padLeft += prefWidth + space;
          element.validate();
        }
      }
    }

    [LineNumberTable(new byte[] {160, 142, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefWidth()
    {
      if (this.wrap)
        return 0.0f;
      if (this.sizeInvalid)
        this.computeSize();
      return this.prefWidth;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRound(bool round) => this.round = round;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup reverse()
    {
      this.reverse = true;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup reverse(bool reverse)
    {
      this.reverse = reverse;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getReverse() => this.reverse;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup space(float space)
    {
      this.space = space;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getSpace() => this.space;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup wrapSpace(float wrapSpace)
    {
      this.wrapSpace = wrapSpace;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getWrapSpace() => this.wrapSpace;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup pad(float pad)
    {
      this.padTop = pad;
      this.padLeft = pad;
      this.padBottom = pad;
      this.padRight = pad;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup pad(
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
    public virtual HorizontalGroup padTop(float padTop)
    {
      this.padTop = padTop;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup padLeft(float padLeft)
    {
      this.padLeft = padLeft;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup padBottom(float padBottom)
    {
      this.padBottom = padBottom;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup padRight(float padRight)
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
    public virtual HorizontalGroup align(int align)
    {
      this.align = align;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup center()
    {
      this.align = 1;
      return this;
    }

    [LineNumberTable(new byte[] {161, 8, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup top()
    {
      this.align |= 2;
      this.align &= -5;
      return this;
    }

    [LineNumberTable(new byte[] {161, 15, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup left()
    {
      this.align |= 8;
      this.align &= -17;
      return this;
    }

    [LineNumberTable(new byte[] {161, 22, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup bottom()
    {
      this.align |= 4;
      this.align &= -3;
      return this;
    }

    [LineNumberTable(new byte[] {161, 29, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup right()
    {
      this.align |= 16;
      this.align &= -9;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getAlign() => this.align;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup fill()
    {
      this.fill = 1f;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup fill(float fill)
    {
      this.fill = fill;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFill() => this.fill;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup expand()
    {
      this.expand = true;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup expand(bool expand)
    {
      this.expand = expand;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getExpand() => this.expand;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup grow()
    {
      this.expand = true;
      this.fill = 1f;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup wrap()
    {
      this.wrap = true;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup wrap(bool wrap)
    {
      this.wrap = wrap;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getWrap() => this.wrap;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup rowAlign(int row)
    {
      this.rowAlign = row;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup rowCenter()
    {
      this.rowAlign = 1;
      return this;
    }

    [LineNumberTable(new byte[] {161, 115, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup rowTop()
    {
      this.rowAlign |= 2;
      this.rowAlign &= -5;
      return this;
    }

    [LineNumberTable(new byte[] {161, 122, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual HorizontalGroup rowBottom()
    {
      this.rowAlign |= 4;
      this.rowAlign &= -3;
      return this;
    }

    [HideFromJava]
    static HorizontalGroup() => WidgetGroup.__\u003Cclinit\u003E();
  }
}
