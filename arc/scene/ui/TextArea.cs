// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.TextArea
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics.g2d;
using arc.input;
using arc.scene.@event;
using arc.scene.style;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui
{
  public class TextArea : TextField
  {
    internal IntSeq linesBreak;
    internal int cursorLine;
    internal int firstLineShowing;
    internal float moveOffset;
    private string lastText;
    private int linesShowing;
    private float prefRows;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 175, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextArea(string text)
      : base(text)
    {
    }

    [LineNumberTable(new byte[] {159, 179, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextArea(string text, TextField.TextFieldStyle style)
      : base(text, style)
    {
    }

    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLines() => this.linesBreak.size / 2 + (!this.newLineAtEnd() ? 0 : 1);

    [LineNumberTable(new byte[] {82, 109, 164, 159, 50, 127, 38, 112, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void updateCurrentLine()
    {
      int currentLineIndex = this.calculateCurrentLineIndex(this.cursor);
      int num1 = currentLineIndex / 2;
      int num2 = currentLineIndex;
      int num3 = 2;
      if ((num3 != -1 ? num2 % num3 : 0) != 0 && currentLineIndex + 1 < this.linesBreak.size && (this.cursor == this.linesBreak.items[currentLineIndex] && this.linesBreak.items[currentLineIndex + 1] == this.linesBreak.items[currentLineIndex]) || num1 >= this.linesBreak.size / 2 && String.instancehelper_length(this.text) != 0 && (String.instancehelper_charAt(this.text, String.instancehelper_length(this.text) - 1) != '\r' && String.instancehelper_charAt(this.text, String.instancehelper_length(this.text) - 1) != '\n'))
        return;
      this.cursorLine = num1;
    }

    [LineNumberTable(new byte[] {54, 100, 103, 103, 112, 105, 105, 113, 114, 139, 103, 113, 109, 125, 159, 25, 103, 127, 28, 127, 31, 127, 16, 147, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void moveCursorLine(int line)
    {
      if (line < 0)
      {
        this.cursorLine = 0;
        this.cursor = 0;
        this.moveOffset = -1f;
      }
      else if (line >= this.getLines())
      {
        int num = this.getLines() - 1;
        this.cursor = String.instancehelper_length(this.text);
        if (line > this.getLines() || num == this.cursorLine)
          this.moveOffset = -1f;
        this.cursorLine = num;
      }
      else
      {
        if (line == this.cursorLine)
          return;
        if ((double) this.moveOffset < 0.0)
          this.moveOffset = this.linesBreak.size > this.cursorLine * 2 ? this.__\u003C\u003EglyphPositions.get(this.cursor) - this.__\u003C\u003EglyphPositions.get(this.linesBreak.get(this.cursorLine * 2)) : 0.0f;
        this.cursorLine = line;
        TextArea textArea;
        for (this.cursor = this.cursorLine * 2 < this.linesBreak.size ? this.linesBreak.get(this.cursorLine * 2) : String.instancehelper_length(this.text); this.cursor < String.instancehelper_length(this.text) && this.cursor <= this.linesBreak.get(this.cursorLine * 2 + 1) - 1 && (double) (this.__\u003C\u003EglyphPositions.get(this.cursor) - this.__\u003C\u003EglyphPositions.get(this.linesBreak.get(this.cursorLine * 2))) < (double) this.moveOffset; ++textArea.cursor)
          textArea = this;
        this.showCursor();
      }
    }

    [LineNumberTable(new byte[] {97, 102, 110, 115, 127, 6, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void showCursor()
    {
      this.updateCurrentLine();
      if (this.cursorLine == this.firstLineShowing)
        return;
      int num = this.cursorLine < this.firstLineShowing ? -1 : 1;
      while (this.firstLineShowing > this.cursorLine || this.firstLineShowing + this.linesShowing - 1 < this.cursorLine)
        this.firstLineShowing += num;
    }

    [LineNumberTable(new byte[] {48, 121, 63, 17})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool newLineAtEnd() => String.instancehelper_length(this.text) != 0 && (String.instancehelper_charAt(this.text, String.instancehelper_length(this.text) - 1) == '\r' || String.instancehelper_charAt(this.text, String.instancehelper_length(this.text) - 1) == '\n');

    [LineNumberTable(new byte[] {108, 98, 126, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int calculateCurrentLineIndex([In] int obj0)
    {
      int index = 0;
      while (index < this.linesBreak.size && obj0 > this.linesBreak.items[index])
        ++index;
      return index;
    }

    [LineNumberTable(new byte[] {160, 194, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override bool continueCursor(int index, int offset)
    {
      int currentLineIndex = this.calculateCurrentLineIndex(index + offset);
      return base.continueCursor(index, offset) && (currentLineIndex < 0 || currentLineIndex >= this.linesBreak.size - 2 || (this.linesBreak.items[currentLineIndex + 1] != index || this.linesBreak.items[currentLineIndex + 1] == this.linesBreak.items[currentLineIndex + 2]));
    }

    [LineNumberTable(new byte[] {159, 184, 102, 103, 107, 103, 103, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initialize()
    {
      base.initialize();
      this.writeEnters = true;
      this.linesBreak = new IntSeq();
      this.cursorLine = 0;
      this.firstLineShowing = 0;
      this.moveOffset = -1f;
      this.linesShowing = 0;
    }

    [LineNumberTable(new byte[] {3, 113, 117, 140, 108, 117, 105, 119, 98, 100, 41, 134, 122, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int letterUnderCursor(float x)
    {
      if (this.linesBreak.size <= 0)
        return 0;
      if (this.cursorLine * 2 >= this.linesBreak.size)
        return String.instancehelper_length(this.text);
      float[] items = this.__\u003C\u003EglyphPositions.items;
      int index1 = this.linesBreak.items[this.cursorLine * 2];
      x += items[index1];
      int num = this.linesBreak.items[this.cursorLine * 2 + 1];
      int index2 = index1;
      while (index2 < num && (double) items[index2] <= (double) x)
        ++index2;
      return index2 - 1 >= 0 && (double) (items[index2] - x) <= (double) (x - items[index2 - 1]) ? index2 : Math.max(0, index2 - 1);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPrefRows(float prefRows) => this.prefRows = prefRows;

    [LineNumberTable(new byte[] {29, 109, 136, 111, 109, 127, 19, 38, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefHeight()
    {
      if ((double) this.prefRows <= 0.0)
        return base.getPrefHeight();
      float num = this.textHeight * this.prefRows;
      if (this.style.background != null)
        num = Math.max(num + this.style.background.getBottomHeight() + this.style.background.getTopHeight(), this.style.background.getMinHeight());
      return num;
    }

    [LineNumberTable(new byte[] {119, 167, 108, 108, 127, 5, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void sizeChanged()
    {
      this.lastText = (string) null;
      Font font = this.style.font;
      Drawable background = this.style.background;
      this.linesShowing = ByteCodeHelper.d2i(Math.floor((double) ((this.getHeight() - (background != null ? background.getBottomHeight() + background.getTopHeight() : 0.0f)) / font.getLineHeight())));
    }

    [LineNumberTable(new byte[] {160, 66, 104, 99, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override float getTextY(Font font, Drawable background)
    {
      float num = this.getHeight();
      if (background != null)
        num = (float) ByteCodeHelper.f2i(num - background.getTopHeight());
      return num;
    }

    [LineNumberTable(new byte[] {160, 75, 105, 102, 114, 114, 159, 9, 110, 144, 191, 15, 116, 150, 127, 11, 159, 1, 127, 10, 38, 197, 107, 100, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void drawSelection(
      Drawable selection,
      Font font,
      float x,
      float y)
    {
      int index1 = this.firstLineShowing * 2;
      float num1 = 0.0f;
      int num2 = Math.min(this.cursor, this.selectionStart);
      int num3 = Math.max(this.cursor, this.selectionStart);
      for (; index1 + 1 < this.linesBreak.size && index1 < (this.firstLineShowing + this.linesShowing) * 2; index1 += 2)
      {
        int num4 = this.linesBreak.get(index1);
        int num5 = this.linesBreak.get(index1 + 1);
        if ((num2 >= num4 || num2 >= num5 || (num3 >= num4 || num3 >= num5)) && (num2 <= num4 || num2 <= num5 || (num3 <= num4 || num3 <= num5)))
        {
          int index2 = Math.max(this.linesBreak.get(index1), num2);
          int index3 = Math.min(this.linesBreak.get(index1 + 1), num3);
          float num6 = this.__\u003C\u003EglyphPositions.get(index2) - this.__\u003C\u003EglyphPositions.get(this.linesBreak.get(index1));
          float f3 = this.__\u003C\u003EglyphPositions.get(index3) - this.__\u003C\u003EglyphPositions.get(index2);
          selection.draw(x + num6 + this.fontOffset, y - this.textHeight - font.getDescent() - num1, f3, font.getLineHeight());
        }
        num1 += font.getLineHeight();
      }
    }

    [LineNumberTable(new byte[] {160, 104, 102, 127, 16, 127, 76, 11, 201})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void drawText(Font font, float x, float y)
    {
      float num1 = 0.0f;
      for (int index = this.firstLineShowing * 2; index < (this.firstLineShowing + this.linesShowing) * 2 && index < this.linesBreak.size; index += 2)
      {
        Font font1 = font;
        // ISSUE: variable of the null type
        __Null local = this.displayText.__\u003Cref\u003E;
        double num2 = (double) x;
        double num3 = (double) (y + num1);
        int num4 = this.linesBreak.items[index];
        int num5 = this.linesBreak.items[index + 1];
        bool flag = false;
        int num6 = 8;
        float num7 = 0.0f;
        int num8 = num5;
        int num9 = num4;
        float num10 = (float) num3;
        float num11 = (float) num2;
        object obj = (object) local;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence str = charSequence;
        double num12 = (double) num11;
        double num13 = (double) num10;
        int start = num9;
        int end = num8;
        double num14 = (double) num7;
        int halign = num6;
        int num15 = flag ? 1 : 0;
        font1.draw(str, (float) num12, (float) num13, start, end, (float) num14, halign, num15 != 0);
        num1 -= font.getLineHeight();
      }
    }

    [LineNumberTable(new byte[] {160, 113, 127, 16, 127, 22, 127, 0, 127, 19, 6, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void drawCursor(Drawable cursorPatch, Font font, float x, float y)
    {
      float num = this.cursor >= this.__\u003C\u003EglyphPositions.size || this.cursorLine * 2 >= this.linesBreak.size ? 0.0f : this.__\u003C\u003EglyphPositions.get(this.cursor) - this.__\u003C\u003EglyphPositions.get(this.linesBreak.items[this.cursorLine * 2]);
      cursorPatch.draw(x + num + this.fontOffset + font.getData().cursorX, y - font.getDescent() / 2f - (float) (this.cursorLine - this.firstLineShowing + 1) * font.getLineHeight(), cursorPatch.getMinWidth(), font.getLineHeight());
    }

    [LineNumberTable(new byte[] {160, 122, 102, 118, 108, 108, 103, 127, 28, 107, 98, 130, 123, 117, 111, 108, 108, 109, 138, 113, 127, 20, 106, 100, 133, 108, 110, 100, 226, 48, 235, 84, 135, 110, 108, 150, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void calculateOffsets()
    {
      base.calculateOffsets();
      if (String.instancehelper_equals(this.text, (object) this.lastText))
        return;
      this.lastText = this.text;
      Font font1 = this.style.font;
      float num1 = this.getWidth() - (this.style.background == null ? 0.0f : this.style.background.getLeftWidth() + this.style.background.getRightWidth());
      this.linesBreak.clear();
      int num2 = 0;
      int num3 = 0;
      GlyphLayout glyphLayout1 = (GlyphLayout) Pools.obtain((Class) ClassLiteral<GlyphLayout>.Value, (Prov) new TextArea.__\u003C\u003EAnon0());
      for (int index = 0; index < String.instancehelper_length(this.text); ++index)
      {
        switch (String.instancehelper_charAt(this.text, index))
        {
          case '\n':
          case '\r':
            this.linesBreak.add(num2);
            this.linesBreak.add(index);
            num2 = index + 1;
            break;
          default:
            num3 = !this.continueCursor(index, 0) ? index : num3;
            GlyphLayout glyphLayout2 = glyphLayout1;
            Font font2 = font1;
            object obj = (object) String.instancehelper_subSequence(this.text, num2, index + 1).__\u003Cref\u003E;
            CharSequence charSequence;
            charSequence.__\u003Cref\u003E = (__Null) obj;
            CharSequence str = charSequence;
            glyphLayout2.setText(font2, str);
            if ((double) glyphLayout1.width > (double) num1)
            {
              if (num2 >= num3)
                num3 = index - 1;
              this.linesBreak.add(num2);
              this.linesBreak.add(num3 + 1);
              num2 = ++num3;
              break;
            }
            break;
        }
      }
      Pools.free((object) glyphLayout1);
      if (num2 < String.instancehelper_length(this.text))
      {
        this.linesBreak.add(num2);
        this.linesBreak.add(String.instancehelper_length(this.text));
      }
      this.showCursor();
    }

    [LineNumberTable(279)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override InputListener createInputListener() => (InputListener) new TextArea.TextAreaListener(this);

    [LineNumberTable(new byte[] {160, 170, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setSelection(int selectionStart, int selectionEnd)
    {
      base.setSelection(selectionStart, selectionEnd);
      this.updateCurrentLine();
    }

    [LineNumberTable(new byte[] {159, 70, 132, 104, 107, 159, 36, 110, 99, 136, 136, 136, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void moveCursor(bool forward, bool jump)
    {
      int num1 = forward ? 1 : 0;
      int num2 = jump ? 1 : 0;
      int num3 = num1 == 0 ? -1 : 1;
      int index = this.cursorLine * 2 + num3;
      if (index >= 0 && index + 1 < this.linesBreak.size && (this.linesBreak.items[index] == this.cursor && this.linesBreak.items[index + 1] == this.cursor))
      {
        this.cursorLine += num3;
        if (num2 != 0)
          base.moveCursor(num1 != 0, num2 != 0);
        this.showCursor();
      }
      else
        base.moveCursor(num1 != 0, num2 != 0);
      this.updateCurrentLine();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getCursorLine() => this.cursorLine;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFirstLineShowing() => this.firstLineShowing;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLinesShowing() => this.linesShowing;

    [LineNumberTable(326)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getCursorX() => this.textOffset + this.fontOffset + this.style.font.getData().cursorX;

    [LineNumberTable(new byte[] {160, 216, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getCursorY()
    {
      Font font = this.style.font;
      return -((float) (-(double) font.getDescent() / 2.0) - (float) (this.cursorLine - this.firstLineShowing + 1) * font.getLineHeight());
    }

    [HideFromJava]
    static TextArea() => TextField.__\u003Cclinit\u003E();

    public class TextAreaListener : TextField.TextFieldClickListener
    {
      [Modifiers]
      internal TextArea this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(335)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TextAreaListener(TextArea _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((TextField) _param1);
      }

      [LineNumberTable(new byte[] {160, 225, 144, 113, 145, 141, 99, 107, 141, 111, 99, 173, 127, 18, 159, 15, 106, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override void setCursorPosition(float x, float y)
      {
        this.this\u00240.moveOffset = -1f;
        Drawable background = this.this\u00240.style.background;
        Font font = this.this\u00240.style.font;
        float height = this.this\u00240.getHeight();
        if (background != null)
        {
          height -= background.getTopHeight();
          x -= background.getLeftWidth();
        }
        x = Math.max(0.0f, x);
        if (background != null)
          y -= background.getTopHeight();
        this.this\u00240.cursorLine = ByteCodeHelper.d2i(Math.floor((double) ((height - y) / font.getLineHeight()))) + this.this\u00240.firstLineShowing;
        this.this\u00240.cursorLine = Math.max(0, Math.min(this.this\u00240.cursorLine, this.this\u00240.getLines() - 1));
        base.setCursorPosition(x, y);
        this.this\u00240.updateCurrentLine();
      }

      [LineNumberTable(364)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override bool checkFocusTraverse(char character)
      {
        int num = (int) character;
        return this.this\u00240.focusTraversal && num == 9;
      }

      [LineNumberTable(new byte[] {160, 255, 105, 108, 124, 98, 127, 8, 109, 99, 109, 118, 174, 139, 120, 135, 109, 99, 109, 118, 174, 139, 120, 164, 144, 99, 135, 107, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool keyDown(InputEvent @event, KeyCode keycode)
      {
        int num1 = base.keyDown(@event, keycode) ? 1 : 0;
        Scene scene = this.this\u00240.getScene();
        if (scene == null || !object.ReferenceEquals((object) scene.getKeyboardFocus(), (object) this.this\u00240))
          return num1 != 0;
        int num2 = 0;
        int num3 = Core.input.keyDown(KeyCode.__\u003C\u003EshiftLeft) || Core.input.keyDown(KeyCode.__\u003C\u003EshiftRight) ? 1 : 0;
        if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Edown))
        {
          if (num3 != 0)
          {
            if (!this.this\u00240.hasSelection)
            {
              this.this\u00240.selectionStart = this.this\u00240.cursor;
              this.this\u00240.hasSelection = true;
            }
          }
          else
            this.this\u00240.clearSelection();
          this.this\u00240.moveCursorLine(this.this\u00240.cursorLine + 1);
          num2 = 1;
        }
        else if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Eup))
        {
          if (num3 != 0)
          {
            if (!this.this\u00240.hasSelection)
            {
              this.this\u00240.selectionStart = this.this\u00240.cursor;
              this.this\u00240.hasSelection = true;
            }
          }
          else
            this.this\u00240.clearSelection();
          this.this\u00240.moveCursorLine(this.this\u00240.cursorLine - 1);
          num2 = 1;
        }
        else
          this.this\u00240.moveOffset = -1f;
        if (num2 != 0)
          this.scheduleKeyRepeatTask(keycode);
        this.this\u00240.showCursor();
        return true;
      }

      [LineNumberTable(new byte[] {159, 39, 66, 105, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool keyTyped(InputEvent @event, char character)
      {
        int num1 = (int) character;
        int num2 = base.keyTyped(@event, (char) num1) ? 1 : 0;
        this.this\u00240.showCursor();
        return num2 != 0;
      }

      [LineNumberTable(new byte[] {159, 38, 162, 99, 110, 127, 0, 159, 9})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override void goHome(bool jump)
      {
        if (jump)
        {
          this.this\u00240.cursor = 0;
        }
        else
        {
          if (this.this\u00240.cursorLine * 2 >= this.this\u00240.linesBreak.size)
            return;
          this.this\u00240.cursor = this.this\u00240.linesBreak.get(this.this\u00240.cursorLine * 2);
        }
      }

      [LineNumberTable(new byte[] {159, 35, 66, 123, 125, 127, 2, 159, 11})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override void goEnd(bool jump)
      {
        if (jump || this.this\u00240.cursorLine >= this.this\u00240.getLines())
        {
          this.this\u00240.cursor = String.instancehelper_length(this.this\u00240.text);
        }
        else
        {
          if (this.this\u00240.cursorLine * 2 + 1 >= this.this\u00240.linesBreak.size)
            return;
          this.this\u00240.cursor = this.this\u00240.linesBreak.get(this.this\u00240.cursorLine * 2 + 1);
        }
      }

      [HideFromJava]
      static TextAreaListener() => TextField.TextFieldClickListener.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new GlyphLayout();
    }
  }
}
