// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.layout.Table
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.utils;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui.layout
{
  public class Table : WidgetGroup
  {
    private static float[] columnWeightedWidth;
    private static float[] rowWeightedHeight;
    [Signature("Larc/util/pooling/Pool<Larc/scene/ui/layout/Cell;>;")]
    private static Pool cellPool;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/scene/ui/layout/Cell;>;")]
    private Seq cells;
    [Modifiers]
    private Cell cellDefaults;
    internal float marginTop;
    internal float marginLeft;
    internal float marginBot;
    internal float marginRight;
    internal int align;
    internal Drawable background;
    internal bool round;
    private int columns;
    private int rows;
    private bool implicitEndRow;
    private Cell rowDefaults;
    private bool sizeInvalid;
    private float[] columnMinWidth;
    private float[] rowMinHeight;
    private float[] columnPrefWidth;
    private float[] rowPrefHeight;
    private float tableMinWidth;
    private float tableMinHeight;
    private float tablePrefWidth;
    private float tablePrefHeight;
    private float[] columnWidth;
    private float[] rowHeight;
    private float[] expandWidth;
    private float[] expandHeight;
    private bool clip;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {5, 232, 44, 172, 127, 13, 135, 231, 69, 231, 74, 140, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Table()
    {
      Table table = this;
      this.cells = new Seq(4);
      this.marginTop = float.NegativeInfinity;
      this.marginLeft = float.NegativeInfinity;
      this.marginBot = float.NegativeInfinity;
      this.marginRight = float.NegativeInfinity;
      this.align = 1;
      this.round = true;
      this.sizeInvalid = true;
      this.cellDefaults = this.obtainCell();
      this.setTransform(false);
      this.touchable = Touchable.__\u003C\u003EchildrenOnly;
    }

    [LineNumberTable(new byte[] {13, 136, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Table(Drawable background)
      : this()
    {
      Table table = this;
      this.background(background);
    }

    [LineNumberTable(new byte[] {29, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Cell obtainCell()
    {
      Cell cell = (Cell) Table.cellPool.obtain();
      cell.setLayout(this);
      return cell;
    }

    [LineNumberTable(new byte[] {80, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table background(Drawable background)
    {
      this.setBackground(background);
      return this;
    }

    [Signature("<T:Larc/scene/Element;>(TT;)Larc/scene/ui/layout/Cell<TT;>;")]
    [LineNumberTable(new byte[] {160, 67, 103, 167, 104, 103, 110, 182, 103, 103, 135, 108, 104, 115, 142, 103, 174, 140, 109, 111, 123, 106, 104, 226, 61, 8, 235, 74, 98, 103, 135, 135, 141, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell add(Element element)
    {
      Cell cell1 = this.obtainCell();
      cell1.element = element;
      if (this.implicitEndRow)
      {
        this.implicitEndRow = false;
        --this.rows;
        ((Cell) this.cells.peek()).endRow = false;
      }
      Seq cells = this.cells;
      int size = cells.size;
      if (size > 0)
      {
        Cell cell2 = (Cell) cells.peek();
        if (!cell2.endRow)
        {
          cell1.column = cell2.column + cell2.colspan;
          cell1.row = cell2.row;
        }
        else
        {
          cell1.column = 0;
          cell1.row = cell2.row + 1;
        }
        if (cell1.row > 0)
        {
          for (int index1 = size - 1; index1 >= 0; index1 += -1)
          {
            Cell cell3 = (Cell) cells.get(index1);
            int column = cell3.column;
            for (int index2 = column + cell3.colspan; column < index2; ++column)
            {
              if (column == cell1.column)
              {
                cell1.cellAboveIndex = index1;
                goto label_16;
              }
            }
          }
        }
      }
      else
      {
        cell1.column = 0;
        cell1.row = 0;
      }
label_16:
      cells.add((object) cell1);
      cell1.set(this.cellDefaults);
      if (element != null)
        this.addChild(element);
      return cell1;
    }

    [LineNumberTable(new byte[] {72, 105, 103, 127, 6, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void drawBackground(float x, float y)
    {
      if (this.background == null)
        return;
      Color color = this.__\u003C\u003Ecolor;
      Draw.color(color.r, color.g, color.b, color.a * this.parentAlpha);
      this.background.draw(x, y, this.width, this.height);
    }

    [LineNumberTable(804)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMarginLeft()
    {
      if ((double) this.marginLeft != double.NegativeInfinity)
        return this.marginLeft;
      return this.background == null ? 0.0f : this.background.getLeftWidth();
    }

    [LineNumberTable(808)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMarginBottom()
    {
      if ((double) this.marginBot != double.NegativeInfinity)
        return this.marginBot;
      return this.background == null ? 0.0f : this.background.getBottomHeight();
    }

    [LineNumberTable(812)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMarginRight()
    {
      if ((double) this.marginRight != double.NegativeInfinity)
        return this.marginRight;
      return this.background == null ? 0.0f : this.background.getRightWidth();
    }

    [LineNumberTable(800)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMarginTop()
    {
      if ((double) this.marginTop != double.NegativeInfinity)
        return this.marginTop;
      return this.background == null ? 0.0f : this.background.getTopHeight();
    }

    [LineNumberTable(new byte[] {90, 111, 127, 1, 103, 127, 5, 120, 104, 116, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBackground(Drawable background)
    {
      if (object.ReferenceEquals((object) this.background, (object) background))
        return;
      float marginTop1 = this.getMarginTop();
      float marginLeft1 = this.getMarginLeft();
      float marginBottom1 = this.getMarginBottom();
      float marginRight1 = this.getMarginRight();
      this.background = background;
      float marginTop2 = this.getMarginTop();
      float marginLeft2 = this.getMarginLeft();
      float marginBottom2 = this.getMarginBottom();
      float marginRight2 = this.getMarginRight();
      if ((double) (marginTop1 + marginBottom1) != (double) (marginTop2 + marginBottom2) || (double) (marginLeft1 + marginRight1) != (double) (marginLeft2 + marginRight2))
      {
        this.invalidateHierarchy();
      }
      else
      {
        if ((double) marginTop1 == (double) marginTop2 && (double) marginLeft1 == (double) marginLeft2 && ((double) marginBottom1 == (double) marginBottom2 && (double) marginRight1 == (double) marginRight2))
          return;
        this.invalidate();
      }
    }

    [LineNumberTable(new byte[] {125, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void invalidate()
    {
      this.sizeInvalid = true;
      base.invalidate();
    }

    [Signature("(Larc/func/Cons<Larc/scene/ui/layout/Table;>;ZLarc/func/Boolp;)Larc/scene/ui/layout/Cell<Larc/scene/ui/layout/Collapser;>;")]
    [LineNumberTable(new byte[] {159, 82, 130, 120, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell collapser(Cons cons, bool animate, Boolp shown)
    {
      int num = animate ? 1 : 0;
      Collapser.__\u003Cclinit\u003E();
      Collapser collapser = new Collapser(cons, !shown.get());
      collapser.setCollapsed(num != 0, (Boolp) new Table.__\u003C\u003EAnon0(shown));
      return this.add((Element) collapser);
    }

    [Signature("(Larc/scene/ui/layout/Table;ZLarc/func/Boolp;)Larc/scene/ui/layout/Cell<Larc/scene/ui/layout/Collapser;>;")]
    [LineNumberTable(new byte[] {159, 80, 66, 120, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell collapser(Table table, bool animate, Boolp shown)
    {
      int num = animate ? 1 : 0;
      Collapser.__\u003Cclinit\u003E();
      Collapser collapser = new Collapser(table, !shown.get());
      collapser.setCollapsed(num != 0, (Boolp) new Table.__\u003C\u003EAnon1(shown));
      return this.add((Element) collapser);
    }

    [Signature("(Larc/scene/style/Drawable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/layout/Table;>;")]
    [LineNumberTable(new byte[] {160, 144, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell table(Drawable background) => this.add((Element) new Table(background));

    [Signature("(Larc/scene/style/Drawable;ILarc/func/Cons<Larc/scene/ui/layout/Table;>;)Larc/scene/ui/layout/Cell<Larc/scene/ui/layout/Table;>;")]
    [LineNumberTable(new byte[] {160, 159, 103, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell table(Drawable background, int align, Cons cons)
    {
      Table table = new Table(background);
      table.align(align);
      cons.get((object) table);
      return this.add((Element) table);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table align(int align)
    {
      this.align = align;
      return this;
    }

    [Signature("(Larc/scene/ui/ScrollPane$ScrollPaneStyle;Larc/func/Cons<Larc/scene/ui/layout/Table;>;)Larc/scene/ui/layout/Cell<Larc/scene/ui/ScrollPane;>;")]
    [LineNumberTable(new byte[] {160, 186, 102, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell pane(ScrollPane.ScrollPaneStyle style, Cons consumer)
    {
      Table table = new Table();
      consumer.get((object) table);
      return this.add((Element) new ScrollPane((Element) table, style));
    }

    [Signature("(Larc/scene/ui/ScrollPane$ScrollPaneStyle;Larc/scene/Element;)Larc/scene/ui/layout/Cell<Larc/scene/ui/ScrollPane;>;")]
    [LineNumberTable(new byte[] {160, 193, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell pane(ScrollPane.ScrollPaneStyle style, Element element) => this.add((Element) new ScrollPane(element, style));

    [LineNumberTable(new byte[] {161, 238, 103, 109, 109, 103, 234, 61, 230, 69, 107, 103, 103, 103, 120, 103, 135, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void clearChildren()
    {
      Seq cells = this.cells;
      for (int index = cells.size - 1; index >= 0; index += -1)
        ((Cell) cells.get(index)).element?.remove();
      Table.cellPool.freeAll(cells);
      cells.clear();
      this.rows = 0;
      this.columns = 0;
      if (this.rowDefaults != null)
        Table.cellPool.free((object) this.rowDefaults);
      this.rowDefaults = (Cell) null;
      this.implicitEndRow = false;
      base.clearChildren();
    }

    [LineNumberTable(new byte[] {162, 15, 110, 110, 134, 103, 120, 108, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table row()
    {
      if (this.cells.size > 0)
      {
        if (!this.implicitEndRow)
          this.endRow();
        this.invalidate();
      }
      this.implicitEndRow = false;
      if (this.rowDefaults != null)
        Table.cellPool.free((object) this.rowDefaults);
      this.rowDefaults = this.obtainCell();
      this.rowDefaults.clear();
      return this;
    }

    [Signature("(Ljava/lang/String;Larc/scene/style/Drawable;FLjava/lang/Runnable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextButton;>;")]
    [LineNumberTable(new byte[] {161, 146, 103, 116, 107, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell button(string text, Drawable image, float imagesize, Runnable clicked)
    {
      TextButton textButton = new TextButton(text);
      textButton.add((Element) new Image(image)).size(imagesize);
      textButton.getCells().reverse();
      textButton.clicked(clicked);
      return this.add((Element) textButton);
    }

    [Signature("()Larc/struct/Seq<Larc/scene/ui/layout/Cell;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getCells() => this.cells;

    [Signature("(FFFFLarc/func/Floatc;)Larc/scene/ui/layout/Cell<Larc/scene/ui/Slider;>;")]
    [LineNumberTable(new byte[] {161, 201, 109, 106, 100, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell slider(
      float min,
      float max,
      float step,
      float defvalue,
      Floatc listener)
    {
      Slider slider = new Slider(min, max, step, false);
      slider.setValue(defvalue);
      if (listener != null)
        slider.moved(listener);
      return this.add((Element) slider);
    }

    [LineNumberTable(new byte[] {158, 249, 162, 108, 104, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool removeChild(Element element, bool unfocus)
    {
      int num = unfocus ? 1 : 0;
      if (!base.removeChild(element, num != 0))
        return false;
      Cell cell = this.getCell(element);
      if (cell != null)
        cell.element = (Element) null;
      return true;
    }

    [Signature("<T:Larc/scene/Element;>(TT;)Larc/scene/ui/layout/Cell;")]
    [LineNumberTable(new byte[] {162, 41, 103, 109, 109, 16, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell getCell(Element actor)
    {
      Seq cells = this.cells;
      int index = 0;
      for (int size = cells.size; index < size; ++index)
      {
        Cell cell = (Cell) cells.get(index);
        if (object.ReferenceEquals((object) cell.element, (object) actor))
          return cell;
      }
      return (Cell) null;
    }

    [LineNumberTable(new byte[] {162, 27, 103, 98, 109, 109, 106, 233, 61, 230, 69, 114, 110, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void endRow()
    {
      Seq cells = this.cells;
      int num = 0;
      for (int index = cells.size - 1; index >= 0; index += -1)
      {
        Cell cell = (Cell) cells.get(index);
        if (!cell.endRow)
          num += cell.colspan;
        else
          break;
      }
      this.columns = Math.max(this.columns, num);
      ++this.rows;
      ((Cell) cells.peek()).endRow = true;
    }

    [LineNumberTable(new byte[] {163, 24, 135, 103, 167, 118, 102, 167, 110, 115, 115, 115, 115, 115, 115, 115, 147, 107, 111, 187, 127, 11, 191, 16, 110, 110, 110, 174, 106, 106, 106, 106, 106, 106, 106, 106, 115, 147, 101, 114, 126, 158, 114, 126, 254, 31, 235, 100, 110, 110, 107, 111, 169, 137, 103, 108, 106, 50, 136, 106, 44, 232, 69, 115, 114, 119, 151, 105, 114, 124, 252, 40, 235, 93, 117, 107, 111, 124, 114, 116, 148, 114, 114, 116, 244, 54, 235, 80, 107, 111, 105, 106, 137, 104, 106, 106, 106, 106, 147, 119, 103, 113, 111, 111, 239, 61, 232, 70, 115, 115, 116, 127, 5, 126, 254, 61, 235, 41, 235, 95, 107, 107, 107, 107, 104, 119, 23, 200, 104, 119, 31, 7, 200, 114, 114, 112, 112, 124, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void computeSize()
    {
      this.sizeInvalid = false;
      Seq cells = this.cells;
      int size = cells.size;
      if (size > 0 && !((Cell) cells.peek()).endRow)
      {
        this.endRow();
        this.implicitEndRow = true;
      }
      int columns = this.columns;
      int rows = this.rows;
      this.columnMinWidth = this.ensureSize(this.columnMinWidth, columns);
      this.rowMinHeight = this.ensureSize(this.rowMinHeight, rows);
      this.columnPrefWidth = this.ensureSize(this.columnPrefWidth, columns);
      this.rowPrefHeight = this.ensureSize(this.rowPrefHeight, rows);
      this.columnWidth = this.ensureSize(this.columnWidth, columns);
      this.rowHeight = this.ensureSize(this.rowHeight, rows);
      this.expandWidth = this.ensureSize(this.expandWidth, columns);
      this.expandHeight = this.ensureSize(this.expandHeight, rows);
      for (int index = 0; index < size; ++index)
      {
        Cell cell = (Cell) cells.get(index);
        int column = cell.column;
        int row = cell.row;
        int colspan = cell.colspan;
        if (cell.expandY != 0 && (double) this.expandHeight[row] == 0.0)
          this.expandHeight[row] = (float) cell.expandY;
        if (colspan == 1 && cell.expandX != 0 && (double) this.expandWidth[column] == 0.0)
          this.expandWidth[column] = (float) cell.expandX;
        cell.computedPadLeft = cell.padLeft;
        cell.computedPadTop = cell.padTop;
        cell.computedPadRight = cell.padRight;
        cell.computedPadBottom = cell.padBottom;
        float num1 = cell.prefWidth();
        float num2 = cell.prefHeight();
        float num3 = cell.minWidth();
        float num4 = cell.minHeight();
        float num5 = cell.maxWidth();
        float num6 = cell.maxHeight();
        if ((double) num1 < (double) num3)
          num1 = num3;
        if ((double) num2 < (double) num4)
          num2 = num4;
        if ((double) num5 > 0.0 && (double) num1 > (double) num5)
          num1 = num5;
        if ((double) num6 > 0.0 && (double) num2 > (double) num6)
          num2 = num6;
        if (colspan == 1)
        {
          float num7 = cell.computedPadLeft + cell.computedPadRight;
          this.columnPrefWidth[column] = Math.max(this.columnPrefWidth[column], num1 + num7);
          this.columnMinWidth[column] = Math.max(this.columnMinWidth[column], num3 + num7);
        }
        float num8 = cell.computedPadTop + cell.computedPadBottom;
        this.rowPrefHeight[row] = Math.max(this.rowPrefHeight[row], num2 + num8);
        this.rowMinHeight[row] = Math.max(this.rowMinHeight[row], num4 + num8);
      }
      float num9 = 0.0f;
      float num10 = 0.0f;
      float num11 = 0.0f;
      float num12 = 0.0f;
      for (int index1 = 0; index1 < size; ++index1)
      {
        Cell cell = (Cell) cells.get(index1);
        int column = cell.column;
        int expandX = cell.expandX;
        if (expandX != 0)
        {
          int num1 = column + cell.colspan;
          for (int index2 = column; index2 < num1; ++index2)
          {
            if ((double) this.expandWidth[index2] != 0.0)
              goto label_29;
          }
          for (int index2 = column; index2 < num1; ++index2)
            this.expandWidth[index2] = (float) expandX;
        }
label_29:
        if (cell.uniformX && cell.colspan == 1)
        {
          float num1 = cell.computedPadLeft + cell.computedPadRight;
          num9 = Math.max(num9, this.columnMinWidth[column] - num1);
          num11 = Math.max(num11, this.columnPrefWidth[column] - num1);
        }
        if (cell.uniformY)
        {
          float num1 = cell.computedPadTop + cell.computedPadBottom;
          num10 = Math.max(num10, this.rowMinHeight[cell.row] - num1);
          num12 = Math.max(num12, this.rowPrefHeight[cell.row] - num1);
        }
      }
      if ((double) num11 > 0.0 || (double) num12 > 0.0)
      {
        for (int index = 0; index < size; ++index)
        {
          Cell cell = (Cell) cells.get(index);
          if ((double) num11 > 0.0 && cell.uniformX && cell.colspan == 1)
          {
            float num1 = cell.computedPadLeft + cell.computedPadRight;
            this.columnMinWidth[cell.column] = num9 + num1;
            this.columnPrefWidth[cell.column] = num11 + num1;
          }
          if ((double) num12 > 0.0 && cell.uniformY)
          {
            float num1 = cell.computedPadTop + cell.computedPadBottom;
            this.rowMinHeight[cell.row] = num10 + num1;
            this.rowPrefHeight[cell.row] = num12 + num1;
          }
        }
      }
      for (int index1 = 0; index1 < size; ++index1)
      {
        Cell cell = (Cell) cells.get(index1);
        int colspan = cell.colspan;
        if (colspan != 1)
        {
          int column = cell.column;
          Element element = cell.element;
          float num1 = cell.minWidth();
          float num2 = cell.prefWidth();
          float num3 = cell.maxWidth();
          if ((double) num2 < (double) num1)
            num2 = num1;
          if ((double) num3 > 0.0 && (double) num2 > (double) num3)
            num2 = num3;
          float num4 = -(cell.computedPadLeft + cell.computedPadRight);
          float num5 = num4;
          float num6 = 0.0f;
          int index2 = column;
          for (int index3 = index2 + colspan; index2 < index3; ++index2)
          {
            num4 += this.columnMinWidth[index2];
            num5 += this.columnPrefWidth[index2];
            num6 += this.expandWidth[index2];
          }
          float num7 = Math.max(0.0f, num1 - num4);
          float num8 = Math.max(0.0f, num2 - num5);
          int index4 = column;
          for (int index3 = index4 + colspan; index4 < index3; ++index4)
          {
            float num13 = (double) num6 != 0.0 ? this.expandWidth[index4] / num6 : 1f / (float) colspan;
            float[] columnMinWidth = this.columnMinWidth;
            int index5 = index4;
            float[] numArray1 = columnMinWidth;
            numArray1[index5] = numArray1[index5] + num7 * num13;
            float[] columnPrefWidth = this.columnPrefWidth;
            int index6 = index4;
            float[] numArray2 = columnPrefWidth;
            numArray2[index6] = numArray2[index6] + num8 * num13;
          }
        }
      }
      this.tableMinWidth = 0.0f;
      this.tableMinHeight = 0.0f;
      this.tablePrefWidth = 0.0f;
      this.tablePrefHeight = 0.0f;
      for (int index = 0; index < columns; ++index)
      {
        this.tableMinWidth += this.columnMinWidth[index];
        this.tablePrefWidth += this.columnPrefWidth[index];
      }
      for (int index = 0; index < rows; ++index)
      {
        this.tableMinHeight += this.rowMinHeight[index];
        this.tablePrefHeight += Math.max(this.rowMinHeight[index], this.rowPrefHeight[index]);
      }
      float num14 = this.getMarginLeft() + this.getMarginRight();
      float num15 = this.getMarginTop() + this.getMarginBottom();
      this.tableMinWidth += num14;
      this.tableMinHeight += num15;
      this.tablePrefWidth = Math.max(this.tablePrefWidth + num14, this.tableMinWidth);
      this.tablePrefHeight = Math.max(this.tablePrefHeight + num15, this.tableMinHeight);
    }

    [LineNumberTable(new byte[] {162, 94, 110, 110, 110, 111, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table margin(float top, float left, float bottom, float right)
    {
      this.marginTop = Scl.scl(top);
      this.marginLeft = Scl.scl(left);
      this.marginBot = Scl.scl(bottom);
      this.marginRight = Scl.scl(right);
      this.sizeInvalid = true;
      return this;
    }

    [LineNumberTable(new byte[] {163, 185, 103, 135, 142, 104, 107, 105, 141, 112, 112, 144, 110, 105, 43, 136, 105, 43, 232, 69, 112, 105, 141, 127, 0, 117, 112, 105, 110, 104, 242, 61, 232, 72, 112, 105, 141, 117, 127, 1, 112, 105, 110, 104, 242, 61, 232, 72, 107, 111, 146, 103, 105, 113, 43, 136, 135, 106, 106, 106, 106, 106, 106, 106, 106, 115, 147, 127, 4, 159, 4, 119, 242, 39, 235, 93, 108, 103, 105, 43, 136, 103, 99, 108, 110, 111, 118, 104, 228, 59, 235, 71, 154, 108, 105, 105, 43, 136, 103, 99, 108, 110, 111, 118, 104, 228, 59, 235, 71, 218, 107, 111, 105, 138, 103, 118, 50, 136, 159, 2, 105, 105, 118, 54, 232, 52, 235, 82, 103, 105, 43, 136, 105, 43, 200, 104, 103, 103, 110, 102, 147, 104, 102, 111, 102, 180, 104, 107, 143, 103, 123, 43, 136, 150, 141, 114, 105, 123, 105, 159, 0, 105, 127, 22, 106, 191, 0, 105, 102, 107, 103, 152, 157, 102, 119, 102, 159, 10, 159, 24, 105, 100, 146, 241, 23, 235, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void layout([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3)
    {
      Seq cells = this.cells;
      int size = cells.size;
      if (this.sizeInvalid)
        this.computeSize();
      float marginLeft = this.getMarginLeft();
      float num1 = marginLeft + this.getMarginRight();
      float marginTop = this.getMarginTop();
      float num2 = marginTop + this.getMarginBottom();
      int columns = this.columns;
      int rows = this.rows;
      float[] expandWidth = this.expandWidth;
      float[] expandHeight = this.expandHeight;
      float[] columnWidth = this.columnWidth;
      float[] rowHeight = this.rowHeight;
      float num3 = 0.0f;
      float num4 = 0.0f;
      for (int index = 0; index < columns; ++index)
        num3 += expandWidth[index];
      for (int index = 0; index < rows; ++index)
        num4 += expandHeight[index];
      float num5 = this.tablePrefWidth - this.tableMinWidth;
      float[] numArray1;
      if ((double) num5 == 0.0)
      {
        numArray1 = this.columnMinWidth;
      }
      else
      {
        float num6 = Math.min(num5, Math.max(0.0f, obj2 - this.tableMinWidth));
        numArray1 = Table.columnWeightedWidth = this.ensureSize(Table.columnWeightedWidth, columns);
        float[] columnMinWidth = this.columnMinWidth;
        float[] columnPrefWidth = this.columnPrefWidth;
        for (int index = 0; index < columns; ++index)
        {
          float num7 = (columnPrefWidth[index] - columnMinWidth[index]) / num5;
          numArray1[index] = columnMinWidth[index] + num6 * num7;
        }
      }
      float num8 = this.tablePrefHeight - this.tableMinHeight;
      float[] numArray2;
      if ((double) num8 == 0.0)
      {
        numArray2 = this.rowMinHeight;
      }
      else
      {
        numArray2 = Table.rowWeightedHeight = this.ensureSize(Table.rowWeightedHeight, rows);
        float num6 = Math.min(num8, Math.max(0.0f, obj3 - this.tableMinHeight));
        float[] rowMinHeight = this.rowMinHeight;
        float[] rowPrefHeight = this.rowPrefHeight;
        for (int index = 0; index < rows; ++index)
        {
          float num7 = (rowPrefHeight[index] - rowMinHeight[index]) / num8;
          numArray2[index] = rowMinHeight[index] + num6 * num7;
        }
      }
      for (int index1 = 0; index1 < size; ++index1)
      {
        Cell cell = (Cell) cells.get(index1);
        int column = cell.column;
        int row = cell.row;
        float num6 = 0.0f;
        int colspan = cell.colspan;
        int index2 = column;
        for (int index3 = index2 + colspan; index2 < index3; ++index2)
          num6 += numArray1[index2];
        float num7 = numArray2[row];
        float num9 = cell.prefWidth();
        float num10 = cell.prefHeight();
        float num11 = cell.minWidth();
        float num12 = cell.minHeight();
        float num13 = cell.maxWidth();
        float num14 = cell.maxHeight();
        if ((double) num9 < (double) num11)
          num9 = num11;
        if ((double) num10 < (double) num12)
          num10 = num12;
        if ((double) num13 > 0.0 && (double) num9 > (double) num13)
          num9 = num13;
        if ((double) num14 > 0.0 && (double) num10 > (double) num14)
          num10 = num14;
        cell.elementWidth = Math.min(num6 - cell.computedPadLeft - cell.computedPadRight, num9);
        cell.elementHeight = Math.min(num7 - cell.computedPadTop - cell.computedPadBottom, num10);
        if (colspan == 1)
          columnWidth[column] = Math.max(columnWidth[column], num6);
        rowHeight[row] = Math.max(rowHeight[row], num7);
      }
      if ((double) num3 > 0.0)
      {
        float num6 = obj2 - num1;
        for (int index = 0; index < columns; ++index)
          num6 -= columnWidth[index];
        float num7 = 0.0f;
        int num9 = 0;
        for (int index1 = 0; index1 < columns; ++index1)
        {
          if ((double) expandWidth[index1] != 0.0)
          {
            float num10 = num6 * expandWidth[index1] / num3;
            float[] numArray3 = columnWidth;
            int index2 = index1;
            float[] numArray4 = numArray3;
            numArray4[index2] = numArray4[index2] + num10;
            num7 += num10;
            num9 = index1;
          }
        }
        float[] numArray5 = columnWidth;
        int index3 = num9;
        float[] numArray6 = numArray5;
        numArray6[index3] = numArray6[index3] + (num6 - num7);
      }
      if ((double) num4 > 0.0)
      {
        float num6 = obj3 - num2;
        for (int index = 0; index < rows; ++index)
          num6 -= rowHeight[index];
        float num7 = 0.0f;
        int num9 = 0;
        for (int index1 = 0; index1 < rows; ++index1)
        {
          if ((double) expandHeight[index1] != 0.0)
          {
            float num10 = num6 * expandHeight[index1] / num4;
            float[] numArray3 = rowHeight;
            int index2 = index1;
            float[] numArray4 = numArray3;
            numArray4[index2] = numArray4[index2] + num10;
            num7 += num10;
            num9 = index1;
          }
        }
        float[] numArray5 = rowHeight;
        int index3 = num9;
        float[] numArray6 = numArray5;
        numArray6[index3] = numArray6[index3] + (num6 - num7);
      }
      for (int index1 = 0; index1 < size; ++index1)
      {
        Cell cell = (Cell) cells.get(index1);
        int colspan = cell.colspan;
        if (colspan != 1)
        {
          float num6 = 0.0f;
          int column1 = cell.column;
          for (int index2 = column1 + colspan; column1 < index2; ++column1)
            num6 += numArray1[column1] - columnWidth[column1];
          float num7 = (num6 - Math.max(0.0f, cell.computedPadLeft + cell.computedPadRight)) / (float) colspan;
          if ((double) num7 > 0.0)
          {
            int column2 = cell.column;
            for (int index2 = column2 + colspan; column2 < index2; ++column2)
            {
              float[] numArray3 = columnWidth;
              int index3 = column2;
              float[] numArray4 = numArray3;
              numArray4[index3] = numArray4[index3] + num7;
            }
          }
        }
      }
      float num15 = num1;
      float num16 = num2;
      for (int index = 0; index < columns; ++index)
        num15 += columnWidth[index];
      for (int index = 0; index < rows; ++index)
        num16 += rowHeight[index];
      int align1 = this.align;
      float num17 = obj0 + marginLeft;
      if ((align1 & 16) != 0)
        num17 += obj2 - num15;
      else if ((align1 & 8) == 0)
        num17 += (obj2 - num15) / 2f;
      float num18 = obj1 + marginTop;
      if ((align1 & 4) != 0)
        num18 += obj3 - num16;
      else if ((align1 & 2) == 0)
        num18 += (obj3 - num16) / 2f;
      float num19 = num17;
      float num20 = num18;
      for (int index1 = 0; index1 < size; ++index1)
      {
        Cell cell = (Cell) cells.get(index1);
        float num6 = 0.0f;
        int column = cell.column;
        for (int index2 = column + cell.colspan; column < index2; ++column)
          num6 += columnWidth[column];
        float num7 = num6 - (cell.computedPadLeft + cell.computedPadRight);
        float num9 = num19 + cell.computedPadLeft;
        float fillX = cell.fillX;
        float fillY = cell.fillY;
        if ((double) fillX > 0.0)
        {
          cell.elementWidth = Math.max(num7 * fillX, cell.minWidth());
          float maxWidth = cell.maxWidth;
          if ((double) maxWidth > 0.0)
            cell.elementWidth = Math.min(cell.elementWidth, maxWidth);
        }
        if ((double) fillY > 0.0)
        {
          cell.elementHeight = Math.max(rowHeight[cell.row] * fillY - cell.computedPadTop - cell.computedPadBottom, cell.minHeight());
          float num10 = cell.maxHeight();
          if ((double) num10 > 0.0)
            cell.elementHeight = Math.min(cell.elementHeight, num10);
        }
        int align2 = cell.align;
        cell.elementX = (align2 & 8) == 0 ? ((align2 & 16) == 0 ? num9 + (num7 - cell.elementWidth) / 2f : num9 + num7 - cell.elementWidth) : num9;
        cell.elementY = (align2 & 2) == 0 ? ((align2 & 4) == 0 ? num20 + (rowHeight[cell.row] - cell.elementHeight + cell.computedPadTop - cell.computedPadBottom) / 2f : num20 + rowHeight[cell.row] - cell.elementHeight - cell.computedPadBottom) : num20 + cell.computedPadTop;
        if (cell.endRow)
        {
          num19 = num17;
          num20 += rowHeight[cell.row];
        }
        else
          num19 = num9 + (num7 + cell.computedPadRight);
      }
    }

    [LineNumberTable(new byte[] {162, 236, 111, 105, 40, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float[] ensureSize([In] float[] obj0, [In] int obj1)
    {
      if (obj0 == null || obj0.Length < obj1)
        return new float[obj1];
      int index = 0;
      for (int length = obj0.Length; index < length; ++index)
        obj0[index] = 0.0f;
      return obj0;
    }

    [Modifiers]
    [LineNumberTable(243)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024collapser\u00240([In] Boolp obj0) => !obj0.get();

    [Modifiers]
    [LineNumberTable(249)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024collapser\u00241([In] Boolp obj0) => !obj0.get();

    [Modifiers]
    [LineNumberTable(new byte[] {161, 1, 123, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024image\u00242([In] Prov obj0, [In] Image obj1)
    {
      ((TextureRegionDrawable) obj1.getDrawable()).setRegion((TextureRegion) obj0.get());
      obj1.layout();
    }

    [Modifiers]
    [LineNumberTable(470)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024area\u00243([In] Cons obj0, [In] TextArea obj1) => obj0.get((object) obj1.getText());

    [Modifiers]
    [LineNumberTable(476)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024area\u00244([In] Cons obj0, [In] TextArea obj1) => obj0.get((object) obj1.getText());

    [Modifiers]
    [LineNumberTable(504)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024buttonRow\u00245([In] TextButton obj0, [In] Image obj1) => obj1.setColor(!obj0.isDisabled() ? Color.__\u003C\u003Ewhite : Color.__\u003C\u003Egray);

    [Modifiers]
    [LineNumberTable(585)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024slider\u00246([In] Floatc obj0, [In] Slider obj1) => obj0.get(obj1.getValue());

    [Signature("(Larc/scene/style/Drawable;Larc/func/Cons<Larc/scene/ui/layout/Table;>;)V")]
    [LineNumberTable(new byte[] {19, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Table(Drawable background, Cons cons)
      : this(background)
    {
      Table table = this;
      cons.get((object) this);
    }

    [Signature("(Larc/func/Cons<Larc/scene/ui/layout/Table;>;)V")]
    [LineNumberTable(new byte[] {24, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Table(Cons cons)
      : this()
    {
      Table table = this;
      cons.get((object) this);
    }

    [LineNumberTable(new byte[] {36, 102, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table fill()
    {
      Table table = new Table();
      table.setFillParent(true);
      this.add((Element) table);
      return table;
    }

    [LineNumberTable(new byte[] {44, 102, 107, 108, 112, 104, 101, 112, 119, 50, 135, 102, 101, 134, 98, 134, 136, 114, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      this.validate();
      if (this.isTransform())
      {
        this.applyTransform(this.computeTransform());
        this.drawBackground(0.0f, 0.0f);
        if (this.clip)
        {
          Draw.flush();
          float marginLeft = this.getMarginLeft();
          float marginBottom = this.getMarginBottom();
          if (this.clipBegin(marginLeft, marginBottom, this.getWidth() - marginLeft - this.getMarginRight(), this.getHeight() - marginBottom - this.getMarginTop()))
          {
            this.drawChildren();
            Draw.flush();
            this.clipEnd();
          }
        }
        else
          this.drawChildren();
        this.resetTransform();
      }
      else
      {
        this.drawBackground(this.x, this.y);
        base.draw();
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Drawable getBackground() => this.background;

    [LineNumberTable(new byte[] {159, 104, 66, 104, 119, 159, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Element hit(float x, float y, bool touchable)
    {
      int num = touchable ? 1 : 0;
      if (this.clip)
      {
        if (num != 0 && object.ReferenceEquals((object) this.touchable, (object) Touchable.__\u003C\u003Edisabled))
          return (Element) null;
        if ((double) x < 0.0 || (double) x >= (double) this.getWidth() || ((double) y < 0.0 || (double) y >= (double) this.getHeight()))
          return (Element) null;
      }
      return base.hit(x, y, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getClip() => this.clip;

    [LineNumberTable(new byte[] {159, 100, 66, 103, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setClip(bool enabled)
    {
      int num = enabled ? 1 : 0;
      this.clip = num != 0;
      this.setTransform(num != 0);
      this.invalidate();
    }

    [LineNumberTable(new byte[] {160, 116, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(params Element[] elements)
    {
      Element[] elementArray = elements;
      int length = elementArray.Length;
      for (int index = 0; index < length; ++index)
        this.add(elementArray[index]);
    }

    [Signature("(Larc/func/Cons<Larc/scene/ui/layout/Table;>;Larc/func/Boolp;)Larc/scene/ui/layout/Cell<Larc/scene/ui/layout/Collapser;>;")]
    [LineNumberTable(234)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell collapser(Cons cons, Boolp shown) => this.collapser(cons, false, shown);

    [Signature("(Larc/scene/ui/layout/Table;Larc/func/Boolp;)Larc/scene/ui/layout/Cell<Larc/scene/ui/layout/Collapser;>;")]
    [LineNumberTable(238)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell collapser(Table table, Boolp shown) => this.collapser(table, false, shown);

    [Signature("()Larc/scene/ui/layout/Cell<Larc/scene/ui/layout/Table;>;")]
    [LineNumberTable(254)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell table() => this.table((Drawable) null);

    [Signature("(Larc/func/Cons<Larc/scene/ui/layout/Table;>;)Larc/scene/ui/layout/Cell<Larc/scene/ui/layout/Table;>;")]
    [LineNumberTable(new byte[] {160, 149, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell table(Cons cons)
    {
      Table table = new Table();
      cons.get((object) table);
      return this.add((Element) table);
    }

    [Signature("(Larc/scene/style/Drawable;Larc/func/Cons<Larc/scene/ui/layout/Table;>;)Larc/scene/ui/layout/Cell<Larc/scene/ui/layout/Table;>;")]
    [LineNumberTable(269)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell table(Drawable background, Cons cons) => this.table(background, 1, cons);

    [Signature("(Larc/func/Prov<Ljava/lang/CharSequence;>;)Larc/scene/ui/layout/Cell<Larc/scene/ui/Label;>;")]
    [LineNumberTable(280)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell label(Prov text) => this.add((Element) new Label(text));

    [Signature("(Larc/func/Prov<Ljava/lang/CharSequence;>;)Larc/scene/ui/layout/Cell<Larc/scene/ui/Label;>;")]
    [LineNumberTable(new byte[] {160, 170, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell labelWrap(Prov text)
    {
      Label label = new Label(text);
      label.setWrap(true);
      return this.add((Element) label);
    }

    [Signature("(Ljava/lang/String;)Larc/scene/ui/layout/Cell<Larc/scene/ui/Label;>;")]
    [LineNumberTable(new byte[] {160, 176, 119, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell labelWrap(string text)
    {
      object obj = (object) text;
      CharSequence text1;
      text1.__\u003Cref\u003E = (__Null) obj;
      Label label = new Label(text1);
      label.setWrap(true);
      return this.add((Element) label);
    }

    [Signature("(Larc/func/Cons<Larc/scene/ui/layout/Table;>;)Larc/scene/ui/layout/Cell<Larc/scene/ui/ScrollPane;>;")]
    [LineNumberTable(296)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell pane(Cons consumer) => this.pane((ScrollPane.ScrollPaneStyle) Core.scene.getStyle((Class) ClassLiteral<ScrollPane.ScrollPaneStyle>.Value), consumer);

    [Signature("(Larc/scene/Element;)Larc/scene/ui/layout/Cell<Larc/scene/ui/ScrollPane;>;")]
    [LineNumberTable(312)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell pane(Element element) => this.pane((ScrollPane.ScrollPaneStyle) Core.scene.getStyle((Class) ClassLiteral<ScrollPane.ScrollPaneStyle>.Value), element);

    [Signature("(Ljava/lang/CharSequence;)Larc/scene/ui/layout/Cell<Larc/scene/ui/Label;>;")]
    [LineNumberTable(317)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell add(CharSequence text)
    {
      object obj = (object) text.__\u003Cref\u003E;
      CharSequence text1;
      text1.__\u003Cref\u003E = (__Null) obj;
      return this.add((Element) new Label(text1));
    }

    [Signature("(Ljava/lang/CharSequence;F)Larc/scene/ui/layout/Cell<Larc/scene/ui/Label;>;")]
    [LineNumberTable(new byte[] {159, 62, 138, 120, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell add(CharSequence text, float scl)
    {
      object obj = (object) text.__\u003Cref\u003E;
      CharSequence text1;
      text1.__\u003Cref\u003E = (__Null) obj;
      Label label = new Label(text1);
      label.setFontScale(scl);
      return this.add((Element) label);
    }

    [Signature("(Ljava/lang/CharSequence;Larc/scene/ui/Label$LabelStyle;F)Larc/scene/ui/layout/Cell<Larc/scene/ui/Label;>;")]
    [LineNumberTable(new byte[] {159, 60, 106, 123, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell add(CharSequence text, Label.LabelStyle labelStyle, float scl)
    {
      object obj1 = (object) text.__\u003Cref\u003E;
      Label.LabelStyle style = labelStyle;
      object obj2 = obj1;
      CharSequence text1;
      text1.__\u003Cref\u003E = (__Null) obj2;
      Label label = new Label(text1, style);
      label.setFontScale(scl);
      return this.add((Element) label);
    }

    [Signature("(Ljava/lang/CharSequence;Larc/graphics/Color;F)Larc/scene/ui/layout/Cell<Larc/scene/ui/Label;>;")]
    [LineNumberTable(new byte[] {159, 59, 170, 120, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell add(CharSequence text, Color color, float scl)
    {
      object obj = (object) text.__\u003Cref\u003E;
      CharSequence text1;
      text1.__\u003Cref\u003E = (__Null) obj;
      Label label = new Label(text1);
      label.setColor(color);
      label.setFontScale(scl);
      return this.add((Element) label);
    }

    [Signature("(Ljava/lang/CharSequence;Larc/scene/ui/Label$LabelStyle;)Larc/scene/ui/layout/Cell<Larc/scene/ui/Label;>;")]
    [LineNumberTable(343)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell add(CharSequence text, Label.LabelStyle labelStyle)
    {
      object obj1 = (object) text.__\u003Cref\u003E;
      Label.LabelStyle style = labelStyle;
      object obj2 = obj1;
      CharSequence text1;
      text1.__\u003Cref\u003E = (__Null) obj2;
      return this.add((Element) new Label(text1, style));
    }

    [Signature("(Ljava/lang/CharSequence;Larc/graphics/Color;)Larc/scene/ui/layout/Cell<Larc/scene/ui/Label;>;")]
    [LineNumberTable(348)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell add(CharSequence text, Color color)
    {
      object obj1 = (object) text.__\u003Cref\u003E;
      Label.__\u003Cclinit\u003E();
      object obj2 = obj1;
      Label.LabelStyle style = new Label.LabelStyle(((Label.LabelStyle) Core.scene.getStyle((Class) ClassLiteral<Label.LabelStyle>.Value)).font, color);
      object obj3 = obj2;
      CharSequence text1;
      text1.__\u003Cref\u003E = (__Null) obj3;
      return this.add((Element) new Label(text1, style));
    }

    [LineNumberTable(353)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell add() => this.add((Element) null);

    [Signature("([Larc/scene/Element;)Larc/scene/ui/layout/Cell<Larc/scene/ui/layout/Stack;>;")]
    [LineNumberTable(new byte[] {160, 247, 102, 99, 105, 41, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell stack(params Element[] elements)
    {
      Stack stack = new Stack();
      if (elements != null)
      {
        int index = 0;
        for (int length = elements.Length; index < length; ++index)
          stack.addChild(elements[index]);
      }
      return this.add((Element) stack);
    }

    [Signature("(Larc/func/Prov<Larc/graphics/g2d/TextureRegion;>;)Larc/scene/ui/layout/Cell<Larc/scene/ui/Image;>;")]
    [LineNumberTable(370)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell image(Prov reg) => this.add((Element) new Image((TextureRegion) reg.get())).update((Cons) new Table.__\u003C\u003EAnon2(reg));

    [Signature("()Larc/scene/ui/layout/Cell<Larc/scene/ui/Image;>;")]
    [LineNumberTable(377)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell image() => this.add((Element) new Image());

    [Signature("(Larc/scene/style/Drawable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/Image;>;")]
    [LineNumberTable(381)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell image(Drawable name) => this.add((Element) new Image(name));

    [Signature("(Larc/scene/style/Drawable;Larc/graphics/Color;)Larc/scene/ui/layout/Cell<Larc/scene/ui/Image;>;")]
    [LineNumberTable(new byte[] {161, 15, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell image(Drawable name, Color color)
    {
      Image image = new Image(name);
      image.setColor(color);
      return this.add((Element) image);
    }

    [Signature("(Larc/graphics/g2d/TextureRegion;)Larc/scene/ui/layout/Cell<Larc/scene/ui/Image;>;")]
    [LineNumberTable(391)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell image(TextureRegion region) => this.add((Element) new Image(region));

    [Signature("(Ljava/lang/String;Larc/func/Boolc;)Larc/scene/ui/layout/Cell<Larc/scene/ui/CheckBox;>;")]
    [LineNumberTable(new byte[] {161, 25, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell check(string text, Boolc listener) => this.add((Element) Elem.newCheck(text, listener));

    [Signature("(Ljava/lang/String;ZLarc/func/Boolc;)Larc/scene/ui/layout/Cell<Larc/scene/ui/CheckBox;>;")]
    [LineNumberTable(new byte[] {159, 42, 66, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell check(string text, bool @checked, Boolc listener)
    {
      int num = @checked ? 1 : 0;
      CheckBox checkBox = Elem.newCheck(text, listener);
      checkBox.setChecked(num != 0);
      return this.add((Element) checkBox);
    }

    [Signature("(Ljava/lang/String;FZLarc/func/Boolc;)Larc/scene/ui/layout/Cell<Larc/scene/ui/CheckBox;>;")]
    [LineNumberTable(new byte[] {159, 41, 130, 105, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell check(string text, float imagesize, bool @checked, Boolc listener)
    {
      int num = @checked ? 1 : 0;
      CheckBox checkBox = Elem.newCheck(text, listener);
      checkBox.getImageCell().size(imagesize);
      checkBox.setChecked(num != 0);
      return this.add((Element) checkBox);
    }

    [Signature("(Larc/func/Cons<Larc/scene/ui/Button;>;Ljava/lang/Runnable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/Button;>;")]
    [LineNumberTable(new byte[] {161, 43, 102, 102, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell button(Cons cons, Runnable listener)
    {
      Button button = new Button();
      button.clearChildren();
      button.clicked(listener);
      cons.get((object) button);
      return this.add((Element) button);
    }

    [Signature("(Larc/func/Cons<Larc/scene/ui/Button;>;Larc/scene/ui/Button$ButtonStyle;Ljava/lang/Runnable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/Button;>;")]
    [LineNumberTable(new byte[] {161, 51, 103, 102, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell button(Cons cons, Button.ButtonStyle style, Runnable listener)
    {
      Button button = new Button(style);
      button.clearChildren();
      button.clicked(listener);
      cons.get((object) button);
      return this.add((Element) button);
    }

    [Signature("(Ljava/lang/String;Ljava/lang/Runnable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextButton;>;")]
    [LineNumberTable(new byte[] {161, 59, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell button(string text, Runnable listener) => this.add((Element) Elem.newButton(text, listener));

    [Signature("(Ljava/lang/String;Larc/scene/ui/TextButton$TextButtonStyle;Ljava/lang/Runnable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextButton;>;")]
    [LineNumberTable(new byte[] {161, 64, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell button(
      string text,
      TextButton.TextButtonStyle style,
      Runnable listener)
    {
      return this.add((Element) Elem.newButton(text, style, listener));
    }

    [Signature("(Larc/scene/style/Drawable;Ljava/lang/Runnable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/ImageButton;>;")]
    [LineNumberTable(new byte[] {161, 69, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell button(Drawable icon, Runnable listener) => this.add((Element) Elem.newImageButton(icon, listener));

    [Signature("(Larc/scene/style/Drawable;FLjava/lang/Runnable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/ImageButton;>;")]
    [LineNumberTable(new byte[] {161, 74, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell button(Drawable icon, float isize, Runnable listener)
    {
      ImageButton imageButton = Elem.newImageButton(icon, listener);
      imageButton.resizeImage(isize);
      return this.add((Element) imageButton);
    }

    [Signature("(Larc/scene/style/Drawable;Larc/scene/ui/ImageButton$ImageButtonStyle;FLjava/lang/Runnable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/ImageButton;>;")]
    [LineNumberTable(new byte[] {161, 80, 104, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell button(
      Drawable icon,
      ImageButton.ImageButtonStyle style,
      float isize,
      Runnable listener)
    {
      ImageButton imageButton = new ImageButton(icon, style);
      imageButton.clicked(listener);
      imageButton.resizeImage(isize);
      return this.add((Element) imageButton);
    }

    [Signature("(Larc/scene/style/Drawable;Larc/scene/ui/ImageButton$ImageButtonStyle;Ljava/lang/Runnable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/ImageButton;>;")]
    [LineNumberTable(new byte[] {161, 87, 104, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell button(
      Drawable icon,
      ImageButton.ImageButtonStyle style,
      Runnable listener)
    {
      ImageButton imageButton = new ImageButton(icon, style);
      imageButton.clicked(listener);
      imageButton.resizeImage(icon.imageSize());
      return this.add((Element) imageButton);
    }

    [Signature("(Ljava/lang/String;Larc/func/Cons<Ljava/lang/String;>;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextField;>;")]
    [LineNumberTable(new byte[] {161, 94, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell field(string text, Cons listener) => this.add((Element) Elem.newField(text, listener));

    [Signature("(Ljava/lang/String;Larc/func/Cons<Ljava/lang/String;>;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextArea;>;")]
    [LineNumberTable(new byte[] {161, 99, 103, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell area(string text, Cons listener)
    {
      TextArea textArea = new TextArea(text);
      textArea.changed((Runnable) new Table.__\u003C\u003EAnon3(listener, textArea));
      return this.add((Element) textArea);
    }

    [Signature("(Ljava/lang/String;Larc/scene/ui/TextField$TextFieldStyle;Larc/func/Cons<Ljava/lang/String;>;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextArea;>;")]
    [LineNumberTable(new byte[] {161, 105, 104, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell area(string text, TextField.TextFieldStyle style, Cons listener)
    {
      TextArea textArea = new TextArea(text, style);
      textArea.changed((Runnable) new Table.__\u003C\u003EAnon4(listener, textArea));
      return this.add((Element) textArea);
    }

    [Signature("(Ljava/lang/String;Larc/scene/ui/TextField$TextFieldFilter;Larc/func/Cons<Ljava/lang/String;>;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextField;>;")]
    [LineNumberTable(new byte[] {161, 111, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell field(string text, TextField.TextFieldFilter filter, Cons listener)
    {
      TextField textField = Elem.newField(text, listener);
      textField.setFilter(filter);
      return this.add((Element) textField);
    }

    [Signature("(Ljava/lang/String;Larc/scene/ui/TextField$TextFieldStyle;Larc/func/Cons<Ljava/lang/String;>;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextField;>;")]
    [LineNumberTable(new byte[] {161, 117, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell field(string text, TextField.TextFieldStyle style, Cons listener)
    {
      TextField textField = Elem.newField(text, listener);
      textField.setStyle(style);
      return this.add((Element) textField);
    }

    [LineNumberTable(493)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell rect(Table.DrawRect draw) => this.add((Element) new Table.\u0031(this, draw));

    [Signature("(Ljava/lang/String;Larc/scene/style/Drawable;Ljava/lang/Runnable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextButton;>;")]
    [LineNumberTable(new byte[] {161, 132, 103, 102, 125, 103, 127, 22, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell buttonRow(string text, Drawable image, Runnable clicked)
    {
      TextButton textButton = new TextButton(text);
      textButton.clearChildren();
      textButton.add((Element) new Image(image)).update((Cons) new Table.__\u003C\u003EAnon5(textButton));
      textButton.row();
      textButton.add((Element) textButton.getLabel()).padTop(4f).padLeft(4f).padRight(4f).wrap().growX();
      textButton.clicked(clicked);
      return this.add((Element) textButton);
    }

    [Signature("(Ljava/lang/String;Larc/scene/style/Drawable;Ljava/lang/Runnable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextButton;>;")]
    [LineNumberTable(512)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell button(string text, Drawable image, Runnable clicked) => this.button(text, image, image.imageSize(), clicked);

    [Signature("(Ljava/lang/String;Larc/scene/style/Drawable;Larc/scene/ui/TextButton$TextButtonStyle;FLjava/lang/Runnable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextButton;>;")]
    [LineNumberTable(new byte[] {161, 154, 104, 117, 107, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell button(
      string text,
      Drawable image,
      TextButton.TextButtonStyle style,
      float imagesize,
      Runnable clicked)
    {
      TextButton textButton = new TextButton(text, style);
      textButton.add((Element) new Image(image)).size(imagesize);
      textButton.getCells().reverse();
      textButton.clicked(clicked);
      return this.add((Element) textButton);
    }

    [Signature("(Ljava/lang/String;Larc/scene/style/Drawable;Larc/scene/ui/TextButton$TextButtonStyle;Ljava/lang/Runnable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextButton;>;")]
    [LineNumberTable(new byte[] {161, 162, 104, 121, 107, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell button(
      string text,
      Drawable image,
      TextButton.TextButtonStyle style,
      Runnable clicked)
    {
      TextButton textButton = new TextButton(text, style);
      textButton.add((Element) new Image(image)).size(image.imageSize());
      textButton.getCells().reverse();
      textButton.clicked(clicked);
      return this.add((Element) textButton);
    }

    [Signature("(Ljava/lang/String;Larc/scene/style/Drawable;FLjava/lang/Runnable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextButton;>;")]
    [LineNumberTable(new byte[] {161, 170, 103, 116, 107, 105, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell buttonCenter(
      string text,
      Drawable image,
      float imagesize,
      Runnable clicked)
    {
      TextButton textButton = new TextButton(text);
      textButton.add((Element) new Image(image)).size(imagesize);
      textButton.getCells().reverse();
      textButton.clicked(clicked);
      textButton.getLabelCell().padLeft(-imagesize);
      return this.add((Element) textButton);
    }

    [Signature("(Ljava/lang/String;Larc/scene/style/Drawable;Ljava/lang/Runnable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextButton;>;")]
    [LineNumberTable(new byte[] {161, 179, 103, 109, 107, 104, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell buttonCenter(string text, Drawable image, Runnable clicked)
    {
      TextButton textButton = new TextButton(text);
      textButton.add((Element) new Image(image));
      textButton.getCells().reverse();
      textButton.clicked(clicked);
      textButton.getLabelCell().padLeft(-image.imageSize());
      return this.add((Element) textButton);
    }

    [Signature("(Ljava/lang/String;Larc/scene/style/Drawable;Larc/scene/ui/TextButton$TextButtonStyle;FLjava/lang/Runnable;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextButton;>;")]
    [LineNumberTable(new byte[] {161, 188, 104, 117, 107, 105, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell buttonCenter(
      string text,
      Drawable image,
      TextButton.TextButtonStyle style,
      float imagesize,
      Runnable clicked)
    {
      TextButton textButton = new TextButton(text, style);
      textButton.add((Element) new Image(image)).size(imagesize);
      textButton.getCells().reverse();
      textButton.clicked(clicked);
      textButton.getLabelCell().padLeft(-imagesize);
      return this.add((Element) textButton);
    }

    [Signature("(FFFLarc/func/Floatc;)Larc/scene/ui/layout/Cell<Larc/scene/ui/Slider;>;")]
    [LineNumberTable(567)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell slider(float min, float max, float step, Floatc listener) => this.slider(min, max, step, 0.0f, listener);

    [Signature("(FFFFZLarc/func/Floatc;)Larc/scene/ui/layout/Cell<Larc/scene/ui/Slider;>;")]
    [LineNumberTable(new byte[] {158, 254, 163, 109, 106, 100, 99, 138, 211})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell slider(
      float min,
      float max,
      float step,
      float defvalue,
      bool onUp,
      Floatc listener)
    {
      int num = onUp ? 1 : 0;
      Slider slider = new Slider(min, max, step, false);
      slider.setValue(defvalue);
      if (listener != null)
      {
        if (num == 0)
          slider.moved(listener);
        else
          slider.released((Runnable) new Table.__\u003C\u003EAnon6(listener, slider));
      }
      return this.add((Element) slider);
    }

    [LineNumberTable(594)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool removeChild(Element element) => this.removeChild(element, true);

    [LineNumberTable(new byte[] {162, 4, 102, 107, 107, 107, 107, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.clearChildren();
      this.marginTop = float.NegativeInfinity;
      this.marginLeft = float.NegativeInfinity;
      this.marginBot = float.NegativeInfinity;
      this.marginRight = float.NegativeInfinity;
      this.align = 1;
      this.cellDefaults.reset();
    }

    [LineNumberTable(new byte[] {162, 56, 110, 103, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefWidth()
    {
      if (this.sizeInvalid)
        this.computeSize();
      float tablePrefWidth = this.tablePrefWidth;
      return this.background != null ? Math.max(tablePrefWidth, this.background.getMinWidth()) : tablePrefWidth;
    }

    [LineNumberTable(new byte[] {162, 64, 110, 103, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefHeight()
    {
      if (this.sizeInvalid)
        this.computeSize();
      float tablePrefHeight = this.tablePrefHeight;
      return this.background != null ? Math.max(tablePrefHeight, this.background.getMinHeight()) : tablePrefHeight;
    }

    [LineNumberTable(new byte[] {162, 72, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getMinWidth()
    {
      if (this.sizeInvalid)
        this.computeSize();
      return this.tableMinWidth;
    }

    [LineNumberTable(new byte[] {162, 78, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getMinHeight()
    {
      if (this.sizeInvalid)
        this.computeSize();
      return this.tableMinHeight;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell defaults() => this.cellDefaults;

    [LineNumberTable(new byte[] {162, 89, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table margin(float pad)
    {
      this.margin(pad, pad, pad, pad);
      return this;
    }

    [LineNumberTable(new byte[] {162, 104, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table marginTop(float padTop)
    {
      this.marginTop = Scl.scl(padTop);
      this.sizeInvalid = true;
      return this;
    }

    [LineNumberTable(new byte[] {162, 111, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table marginLeft(float padLeft)
    {
      this.marginLeft = Scl.scl(padLeft);
      this.sizeInvalid = true;
      return this;
    }

    [LineNumberTable(new byte[] {162, 118, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table marginBottom(float padBottom)
    {
      this.marginBot = Scl.scl(padBottom);
      this.sizeInvalid = true;
      return this;
    }

    [LineNumberTable(new byte[] {162, 125, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table marginRight(float padRight)
    {
      this.marginRight = Scl.scl(padRight);
      this.sizeInvalid = true;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table center()
    {
      this.align = 1;
      return this;
    }

    [LineNumberTable(new byte[] {162, 147, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table top()
    {
      this.align |= 2;
      this.align &= -5;
      return this;
    }

    [LineNumberTable(new byte[] {162, 154, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table left()
    {
      this.align |= 8;
      this.align &= -17;
      return this;
    }

    [LineNumberTable(new byte[] {162, 161, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table bottom()
    {
      this.align |= 4;
      this.align &= -3;
      return this;
    }

    [LineNumberTable(new byte[] {162, 168, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table right()
    {
      this.align |= 16;
      this.align &= -9;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getAlign() => this.align;

    [LineNumberTable(new byte[] {162, 198, 103, 98, 109, 105, 101, 102, 100, 114, 118, 109, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getRow(float y)
    {
      Seq cells = this.cells;
      int num1 = 0;
      y += this.getMarginTop();
      int num2 = 0;
      int size = cells.size;
      switch (size)
      {
        case 0:
          return -1;
        case 1:
          return 0;
        default:
          while (num2 < size)
          {
            Seq seq = cells;
            int index = num2;
            ++num2;
            Cell cell = (Cell) seq.get(index);
            if ((double) (cell.elementY + cell.computedPadTop) >= (double) y)
            {
              if (cell.endRow)
                ++num1;
            }
            else
              break;
          }
          return num1;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRound(bool round) => this.round = round;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getRows() => this.rows;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getColumns() => this.columns;

    [LineNumberTable(853)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRowHeight(int rowIndex) => this.rowHeight[rowIndex];

    [LineNumberTable(858)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getColumnWidth(int columnIndex) => this.columnWidth[columnIndex];

    [LineNumberTable(new byte[] {162, 244, 104, 136, 146, 103, 107, 114, 110, 111, 111, 111, 118, 111, 105, 243, 56, 238, 75, 114, 110, 105, 112, 105, 105, 253, 58, 233, 74, 104, 114, 112, 7, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void layout()
    {
      float width1 = this.getWidth();
      float height1 = this.getHeight();
      this.layout(0.0f, 0.0f, width1, height1);
      Seq cells = this.cells;
      if (this.round)
      {
        int index = 0;
        for (int size = cells.size; index < size; ++index)
        {
          Cell cell = (Cell) cells.get(index);
          float width2 = (float) Math.round(cell.elementWidth);
          float height2 = (float) Math.round(cell.elementHeight);
          float x = (float) Math.round(cell.elementX);
          float y = height1 - (float) Math.round(cell.elementY) - height2;
          cell.setBounds(x, y, width2, height2);
          cell.element?.setBounds(x, y, width2, height2);
        }
      }
      else
      {
        int index = 0;
        for (int size = cells.size; index < size; ++index)
        {
          Cell cell = (Cell) cells.get(index);
          float elementHeight = cell.elementHeight;
          float y = height1 - cell.elementY - elementHeight;
          cell.elementY = y;
          cell.element?.setBounds(cell.elementX, y, cell.elementWidth, elementHeight);
        }
      }
      SnapshotSeq children = this.getChildren();
      int index1 = 0;
      for (int size = children.size; index1 < size; ++index1)
        ((Element) children.get(index1)).validate();
    }

    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Table()
    {
      WidgetGroup.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("arc.scene.ui.layout.Table"))
        return;
      Table.cellPool = Pools.get((Class) ClassLiteral<Cell>.Value, (Prov) new Table.__\u003C\u003EAnon7());
    }

    [EnclosingMethod(null, "rect", "(Larc.scene.ui.layout.Table$DrawRect;)Larc.scene.ui.layout.Cell;")]
    [SpecialName]
    internal new class \u0031 : Element
    {
      [Modifiers]
      internal Table.DrawRect val\u0024draw;
      [Modifiers]
      internal Table this\u00240;

      [LineNumberTable(493)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Table obj0, [In] Table.DrawRect obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024draw = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {161, 126, 127, 6})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw() => this.val\u0024draw.draw(this.x, this.y, this.getWidth(), this.getHeight());
    }

    public interface DrawRect
    {
      void draw(float f1, float f2, float f3, float f4);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolp
    {
      private readonly Boolp arg\u00241;

      internal __\u003C\u003EAnon0([In] Boolp obj0) => this.arg\u00241 = obj0;

      public bool get() => (Table.lambda\u0024collapser\u00240(this.arg\u00241) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Boolp
    {
      private readonly Boolp arg\u00241;

      internal __\u003C\u003EAnon1([In] Boolp obj0) => this.arg\u00241 = obj0;

      public bool get() => (Table.lambda\u0024collapser\u00241(this.arg\u00241) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly Prov arg\u00241;

      internal __\u003C\u003EAnon2([In] Prov obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Table.lambda\u0024image\u00242(this.arg\u00241, (Image) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly Cons arg\u00241;
      private readonly TextArea arg\u00242;

      internal __\u003C\u003EAnon3([In] Cons obj0, [In] TextArea obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => Table.lambda\u0024area\u00243(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly Cons arg\u00241;
      private readonly TextArea arg\u00242;

      internal __\u003C\u003EAnon4([In] Cons obj0, [In] TextArea obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => Table.lambda\u0024area\u00244(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly TextButton arg\u00241;

      internal __\u003C\u003EAnon5([In] TextButton obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Table.lambda\u0024buttonRow\u00245(this.arg\u00241, (Image) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly Floatc arg\u00241;
      private readonly Slider arg\u00242;

      internal __\u003C\u003EAnon6([In] Floatc obj0, [In] Slider obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => Table.lambda\u0024slider\u00246(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Prov
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public object get() => (object) new Cell();
    }
  }
}
