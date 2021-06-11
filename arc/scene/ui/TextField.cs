// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.TextField
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.input;
using arc.math;
using arc.math.geom;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.utils;
using arc.util;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui
{
  [Implements(new string[] {"arc.scene.utils.Disableable"})]
  public class TextField : Element, Disableable
  {
    protected internal const char BACKSPACE = '\b';
    protected internal const char TAB = '\t';
    protected internal const char DELETE = '\u007F';
    protected internal const char BULLET = '\u0095';
    [Modifiers]
    private static Vec2 tmp1;
    [Modifiers]
    private static Vec2 tmp2;
    [Modifiers]
    private static Vec2 tmp3;
    public static float keyRepeatInitialTime;
    public static float keyRepeatTime;
    internal GlyphLayout __\u003C\u003Elayout;
    internal FloatSeq __\u003C\u003EglyphPositions;
    protected internal string text;
    protected internal int cursor;
    protected internal int selectionStart;
    protected internal bool hasSelection;
    protected internal bool writeEnters;
    protected internal CharSequence displayText;
    protected internal float fontOffset;
    protected internal float textHeight;
    protected internal float textOffset;
    internal TextField.TextFieldStyle style;
    internal InputListener inputListener;
    internal TextField.TextFieldListener listener;
    internal TextField.TextFieldValidator validator;
    internal TextField.TextFieldFilter filter;
    internal TextField.OnscreenKeyboard keyboard;
    internal bool focusTraversal;
    internal bool onlyFontChars;
    internal bool disabled;
    internal string undoText;
    internal long lastChangeTime;
    internal bool passwordMode;
    internal float renderOffset;
    internal bool cursorOn;
    internal long lastBlink;
    internal TextField.KeyRepeatTask keyRepeatTask;
    internal bool programmaticChangeEvents;
    private string messageText;
    private int textHAlign;
    private float selectionX;
    private float selectionWidth;
    private StringBuilder passwordBuffer;
    private char passwordCharacter;
    private int visibleTextStart;
    private int visibleTextEnd;
    private int maxLength;
    private float blinkTime;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFilter(TextField.TextFieldFilter filter) => this.filter = filter;

    [LineNumberTable(new byte[] {160, 103, 115, 103, 127, 8, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStyle(TextField.TextFieldStyle style)
    {
      if (style == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("style cannot be null.");
      }
      this.style = style;
      this.textHeight = style.font.getCapHeight() - style.font.getDescent() * 2f;
      this.invalidateHierarchy();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getText() => this.text;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMaxLength(int maxLength) => this.maxLength = maxLength;

    [LineNumberTable(new byte[] {162, 95, 116, 102, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCursorPosition(int cursorPosition)
    {
      if (cursorPosition < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("cursorPosition must be >= 0");
      }
      this.clearSelection();
      this.cursor = Math.min(cursorPosition, String.instancehelper_length(this.text));
    }

    [LineNumberTable(new byte[] {161, 248, 127, 24, 153, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMessageText(string messageText)
    {
      if (messageText != null && (String.instancehelper_startsWith(messageText, "$") || String.instancehelper_startsWith(messageText, "@")) && (Core.bundle != null && Core.bundle.has(String.instancehelper_substring(messageText, 1))))
        this.messageText = Core.bundle.get(String.instancehelper_substring(messageText, 1));
      else
        this.messageText = messageText;
    }

    [LineNumberTable(new byte[] {162, 15, 106, 143, 102, 103, 107, 104, 118, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setText(string str)
    {
      if (str == null)
        str = "";
      if (String.instancehelper_equals(str, (object) this.text))
        return;
      this.clearSelection();
      string text = this.text;
      this.text = "";
      this.paste(str, false);
      if (this.programmaticChangeEvents)
        this.changeText(text, this.text);
      this.cursor = 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDisabled(bool disabled) => this.disabled = disabled;

    [LineNumberTable(new byte[] {38, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextField()
      : this("")
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOnlyFontChars(bool onlyFontChars) => this.onlyFontChars = onlyFontChars;

    [LineNumberTable(new byte[] {115, 141, 241, 82})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addInputDialog()
    {
      if (!Core.app.isMobile())
        return;
      this.tapped((Runnable) new TextField.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {42, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextField(string text)
      : this(text, (TextField.TextFieldStyle) Core.scene.getStyle((Class) ClassLiteral<TextField.TextFieldStyle>.Value))
    {
    }

    [LineNumberTable(new byte[] {160, 82, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearText() => this.setText("");

    [LineNumberTable(new byte[] {45, 232, 24, 107, 235, 76, 107, 110, 203, 135, 172, 167, 139, 103, 235, 75, 103, 102, 103, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextField(string text, TextField.TextFieldStyle style)
    {
      TextField textField = this;
      this.__\u003C\u003Elayout = new GlyphLayout();
      this.__\u003C\u003EglyphPositions = new FloatSeq();
      this.keyboard = (TextField.OnscreenKeyboard) new TextField.DefaultOnscreenKeyboard();
      this.focusTraversal = true;
      this.onlyFontChars = true;
      this.undoText = "";
      this.cursorOn = true;
      this.keyRepeatTask = new TextField.KeyRepeatTask(this);
      this.textHAlign = 8;
      this.passwordCharacter = '\u0095';
      this.maxLength = 0;
      this.blinkTime = 0.32f;
      this.setStyle(style);
      this.initialize();
      this.setText(text);
      this.setSize(this.getPrefWidth(), this.getPrefHeight());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextField.TextFieldStyle getStyle() => this.style;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearSelection() => this.hasSelection = false;

    [LineNumberTable(156)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int[] wordUnderCursor([In] float obj0) => this.wordUnderCursor(this.letterUnderCursor(obj0));

    [LineNumberTable(new byte[] {162, 62, 116, 116, 115, 115, 100, 102, 129, 100, 98, 99, 163, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSelection(int selectionStart, int selectionEnd)
    {
      if (selectionStart < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("selectionStart must be >= 0");
      }
      if (selectionEnd < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("selectionEnd must be >= 0");
      }
      selectionStart = Math.min(String.instancehelper_length(this.text), selectionStart);
      selectionEnd = Math.min(String.instancehelper_length(this.text), selectionEnd);
      if (selectionEnd == selectionStart)
      {
        this.clearSelection();
      }
      else
      {
        if (selectionEnd < selectionStart)
        {
          int num = selectionEnd;
          selectionEnd = selectionStart;
          selectionStart = num;
        }
        this.hasSelection = true;
        this.selectionStart = selectionStart;
        this.cursor = selectionEnd;
      }
    }

    [LineNumberTable(new byte[] {162, 82, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void selectAll() => this.setSelection(0, String.instancehelper_length(this.text));

    [LineNumberTable(new byte[] {63, 127, 32, 103, 122, 108, 108, 102, 103, 116, 228, 61, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int letterUnderCursor(float x)
    {
      x -= this.textOffset + this.fontOffset - this.style.font.getData().cursorX - this.__\u003C\u003EglyphPositions.get(this.visibleTextStart);
      if (this.getBackgroundDrawable() != null)
        x -= this.style.background.getLeftWidth();
      int size = this.__\u003C\u003EglyphPositions.size;
      float[] items = this.__\u003C\u003EglyphPositions.items;
      for (int index = 1; index < size; ++index)
      {
        if ((double) items[index] > (double) x)
          return (double) (items[index] - x) <= (double) (x - items[index - 1]) ? index : index - 1;
      }
      return size - 1;
    }

    [LineNumberTable(new byte[] {159, 25, 130, 100, 102, 108, 125, 113, 116, 117, 106, 104, 110, 104, 116, 154, 233, 55, 235, 75, 136, 117, 99, 159, 25, 127, 16, 102, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void paste(string content, bool fireChangeEvent)
    {
      int num1 = fireChangeEvent ? 1 : 0;
      if (content == null)
        return;
      StringBuilder stringBuilder = new StringBuilder();
      int num2 = String.instancehelper_length(this.text);
      if (this.hasSelection)
        num2 -= Math.abs(this.cursor - this.selectionStart);
      Font.FontData data = this.style.font.getData();
      int num3 = 0;
      for (int index = String.instancehelper_length(content); num3 < index && this.withinMaxLength(num2 + stringBuilder.length()); ++num3)
      {
        int num4 = (int) String.instancehelper_charAt(content, num3);
        if (num4 != 13 && (this.writeEnters && num4 == 10 || num4 != 10 && (!this.onlyFontChars || data.hasGlyph((char) num4)) && (this.filter == null || this.filter.acceptChar(this, (char) num4))))
          stringBuilder.append((char) num4);
      }
      content = stringBuilder.toString();
      if (this.hasSelection)
        this.cursor = this.delete(num1 != 0);
      if (num1 != 0)
      {
        string text1 = this.text;
        int cursor = this.cursor;
        string str1 = content;
        string text2 = this.text;
        object obj = (object) str1;
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        string str2 = text2;
        string str3 = this.insert(cursor, charSequence2, str2);
        this.changeText(text1, str3);
      }
      else
      {
        int cursor = this.cursor;
        string str1 = content;
        string text = this.text;
        object obj = (object) str1;
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        string str2 = text;
        this.text = this.insert(cursor, charSequence2, str2);
      }
      this.updateDisplayText();
      this.cursor += String.instancehelper_length(content);
    }

    [LineNumberTable(new byte[] {161, 78, 112, 159, 24})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void copy()
    {
      if (!this.hasSelection || this.passwordMode)
        return;
      Core.app.setClipboardText(String.instancehelper_substring(this.text, Math.min(this.cursor, this.selectionStart), Math.max(this.cursor, this.selectionStart)));
    }

    [LineNumberTable(new byte[] {159, 27, 130, 112, 102, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void cut([In] bool obj0)
    {
      int num = obj0 ? 1 : 0;
      if (!this.hasSelection || this.passwordMode)
        return;
      this.copy();
      this.cursor = this.delete(num != 0);
      this.updateDisplayText();
    }

    [LineNumberTable(new byte[] {161, 19, 108, 103, 103, 135, 103, 104, 106, 24, 200, 137, 124, 122, 110, 142, 114, 50, 168, 159, 1, 154, 127, 14, 107, 103, 118, 119, 105, 110, 114, 109, 16, 200, 98, 107, 141, 124, 159, 3, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void updateDisplayText()
    {
      Font font1 = this.style.font;
      Font.FontData data = font1.getData();
      string text = this.text;
      int num1 = String.instancehelper_length(text);
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < num1; ++index)
      {
        int num2 = (int) String.instancehelper_charAt(text, index);
        stringBuilder.append(!data.hasGlyph((char) num2) ? ' ' : (char) num2);
      }
      string str1 = stringBuilder.toString();
      if (this.passwordMode && data.hasGlyph(this.passwordCharacter))
      {
        if (this.passwordBuffer == null)
          this.passwordBuffer = new StringBuilder(String.instancehelper_length(str1));
        if (this.passwordBuffer.length() > num1)
        {
          this.passwordBuffer.setLength(num1);
        }
        else
        {
          for (int index = this.passwordBuffer.length(); index < num1; ++index)
            this.passwordBuffer.append(this.passwordCharacter);
        }
        object passwordBuffer = (object) this.passwordBuffer;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) passwordBuffer;
        this.displayText = charSequence;
      }
      else
      {
        object obj = (object) str1;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        this.displayText = charSequence;
      }
      GlyphLayout layout = this.__\u003C\u003Elayout;
      Font font2 = font1;
      object obj1 = (object) this.displayText.__\u003Cref\u003E;
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj1;
      CharSequence str2 = charSequence1;
      layout.setText(font2, str2);
      this.__\u003C\u003EglyphPositions.clear();
      float num3 = 0.0f;
      if (this.__\u003C\u003Elayout.__\u003C\u003Eruns.size > 0)
      {
        FloatSeq xAdvances = ((GlyphLayout.GlyphRun) this.__\u003C\u003Elayout.__\u003C\u003Eruns.first()).xAdvances;
        this.fontOffset = xAdvances.first();
        int index = 1;
        for (int size = xAdvances.size; index < size; ++index)
        {
          this.__\u003C\u003EglyphPositions.add(num3);
          num3 += xAdvances.get(index);
        }
      }
      else
        this.fontOffset = 0.0f;
      this.__\u003C\u003EglyphPositions.add(num3);
      this.visibleTextStart = Math.min(this.visibleTextStart, this.__\u003C\u003EglyphPositions.size);
      this.visibleTextEnd = Mathf.clamp(this.visibleTextEnd, this.visibleTextStart, this.__\u003C\u003EglyphPositions.size);
      if (this.selectionStart <= String.instancehelper_length(str1))
        return;
      this.selectionStart = num1;
    }

    [LineNumberTable(new byte[] {158, 197, 100, 114, 104, 127, 31, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void moveCursor(bool forward, bool jump)
    {
      int num1 = forward ? 1 : 0;
      int num2 = jump ? 1 : 0;
      int num3 = num1 == 0 ? 0 : String.instancehelper_length(this.text);
      int offset = num1 == 0 ? -1 : 0;
      do
      {
        if (num1 != 0)
        {
          TextField textField1 = this;
          int num4 = textField1.cursor + 1;
          TextField textField2 = textField1;
          int num5 = num4;
          textField2.cursor = num4;
          int num6 = num3;
          if (num5 >= num6)
            goto label_6;
        }
        else
        {
          TextField textField1 = this;
          int num4 = textField1.cursor - 1;
          TextField textField2 = textField1;
          int num5 = num4;
          textField2.cursor = num4;
          int num6 = num3;
          if (num5 <= num6)
            goto label_3;
        }
      }
      while (num2 != 0 && this.continueCursor(this.cursor, offset));
      goto label_7;
label_6:
      return;
label_3:
      return;
label_7:;
    }

    [LineNumberTable(new byte[] {159, 12, 130, 103, 100, 130, 127, 3, 121, 99, 99, 151, 117, 158, 99, 107, 130, 107, 98, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void next(bool up)
    {
      int num = up ? 1 : 0;
      Scene scene = this.getScene();
      if (scene == null)
        return;
      TextField textField = this;
      while (true)
      {
        textField.parent.localToStageCoordinates(TextField.tmp1.set(this.x, this.y));
        TextField nextTextField = textField.findNextTextField(scene.getElements(), (TextField) null, TextField.tmp2, TextField.tmp1, num != 0);
        if (nextTextField == null)
        {
          if (num != 0)
            TextField.tmp1.set(float.Epsilon, float.Epsilon);
          else
            TextField.tmp1.set(float.MaxValue, float.MaxValue);
          nextTextField = textField.findNextTextField(this.getScene().getElements(), (TextField) null, TextField.tmp2, TextField.tmp1, num != 0);
        }
        if (nextTextField != null)
        {
          if (!scene.setKeyboardFocus((Element) nextTextField))
            textField = nextTextField;
          else
            goto label_12;
        }
        else
          break;
      }
      Core.input.setOnscreenKeyboardVisible(false);
      return;
label_12:;
    }

    [LineNumberTable(new byte[] {159, 17, 162, 103, 103, 104, 105, 127, 3, 127, 16, 99, 145, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int delete([In] bool obj0)
    {
      int num1 = obj0 ? 1 : 0;
      int selectionStart = this.selectionStart;
      int cursor = this.cursor;
      int num2 = Math.min(selectionStart, cursor);
      int num3 = Math.max(selectionStart, cursor);
      string str = new StringBuilder().append(num2 <= 0 ? "" : String.instancehelper_substring(this.text, 0, num2)).append(num3 >= String.instancehelper_length(this.text) ? "" : String.instancehelper_substring(this.text, num3)).toString();
      if (num1 != 0)
        this.changeText(this.text, str);
      else
        this.text = str;
      this.clearSelection();
      return num2;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool withinMaxLength([In] int obj0) => this.maxLength <= 0 || obj0 < this.maxLength;

    [LineNumberTable(new byte[] {159, 18, 138, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string insert([In] int obj0, [In] CharSequence obj1, [In] string obj2)
    {
      object obj3 = (object) obj1.__\u003Cref\u003E;
      if (String.instancehelper_length(obj2) != 0)
        return new StringBuilder().append(String.instancehelper_substring(obj2, 0, obj0)).append(obj3).append(String.instancehelper_substring(obj2, obj0)).toString();
      object obj4 = obj3;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj4;
      return ((CharSequence) ref charSequence).toString();
    }

    [LineNumberTable(new byte[] {162, 31, 107, 103, 122, 104, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool changeText([In] string obj0, [In] string obj1)
    {
      if (String.instancehelper_equals(obj1, (object) obj0))
        return false;
      this.text = obj1;
      ChangeListener.ChangeEvent changeEvent = (ChangeListener.ChangeEvent) Pools.obtain((Class) ClassLiteral<ChangeListener.ChangeEvent>.Value, (Prov) new TextField.__\u003C\u003EAnon3());
      int num = this.fire((SceneEvent) changeEvent) ? 1 : 0;
      this.text = num == 0 ? obj1 : obj0;
      Pools.free((object) changeEvent);
      return num == 0;
    }

    [LineNumberTable(new byte[] {53, 120, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void initialize()
    {
      TextField textField = this;
      InputListener inputListener1 = this.createInputListener();
      InputListener inputListener2 = inputListener1;
      this.inputListener = inputListener1;
      this.addListener((EventListener) inputListener2);
      this.addListener((EventListener) new IbeamCursorListener());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefWidth() => 150f;

    [LineNumberTable(new byte[] {162, 116, 108, 109, 127, 13, 153, 109, 108, 57, 135, 153, 109, 108, 57, 135, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefHeight()
    {
      float num1 = 0.0f;
      float num2 = 0.0f;
      if (this.style.background != null)
      {
        num1 = Math.max(num1, this.style.background.getBottomHeight() + this.style.background.getTopHeight());
        num2 = Math.max(num2, this.style.background.getMinHeight());
      }
      if (this.style.focusedBackground != null)
      {
        num1 = Math.max(num1, this.style.focusedBackground.getBottomHeight() + this.style.focusedBackground.getTopHeight());
        num2 = Math.max(num2, this.style.focusedBackground.getMinHeight());
      }
      if (this.style.disabledBackground != null)
      {
        num1 = Math.max(num1, this.style.disabledBackground.getBottomHeight() + this.style.disabledBackground.getTopHeight());
        num2 = Math.max(num2, this.style.disabledBackground.getMinHeight());
      }
      return Math.max(num1 + this.textHeight, num2);
    }

    [LineNumberTable(108)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual InputListener createInputListener() => (InputListener) new TextField.TextFieldClickListener(this);

    [LineNumberTable(new byte[] {160, 174, 103, 118, 127, 3, 127, 3, 31, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Drawable getBackgroundDrawable()
    {
      Scene scene = this.getScene();
      int num = scene == null || !object.ReferenceEquals((object) scene.getKeyboardFocus(), (object) this) ? 0 : 1;
      if (this.disabled && this.style.disabledBackground != null)
        return this.style.disabledBackground;
      if (!this.isValid() && this.style.invalidBackground != null)
        return this.style.invalidBackground;
      return num != 0 && this.style.focusedBackground != null ? this.style.focusedBackground : this.style.background;
    }

    [LineNumberTable(129)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool isWordCharacter(char c) => Character.isLetterOrDigit(c);

    [LineNumberTable(new byte[] {83, 103, 107, 105, 103, 135, 100, 111, 98, 226, 61, 230, 70, 104, 111, 100, 226, 61, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int[] wordUnderCursor(int at)
    {
      string text = this.text;
      int num1 = String.instancehelper_length(text);
      int num2 = 0;
      int num3 = at;
      if (at >= String.instancehelper_length(text))
      {
        num2 = String.instancehelper_length(text);
        num1 = 0;
      }
      else
      {
        for (; num3 < num1; ++num3)
        {
          if (!this.isWordCharacter(String.instancehelper_charAt(text, num3)))
          {
            num1 = num3;
            break;
          }
        }
        for (int index = at - 1; index > -1; index += -1)
        {
          if (!this.isWordCharacter(String.instancehelper_charAt(text, index)))
          {
            num2 = index + 1;
            break;
          }
        }
      }
      return new int[2]{ num2, num1 };
    }

    [LineNumberTable(357)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isValid() => this.validator == null || this.validator.valid(this.text);

    [LineNumberTable(new byte[] {160, 247, 104, 119, 99, 104, 123, 98, 140, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float getTextY(Font font, Drawable background)
    {
      float height = this.getHeight();
      float num1 = this.textHeight / 2f + font.getDescent();
      float num2;
      if (background != null)
      {
        float bottomHeight = background.getBottomHeight();
        num2 = num1 + (height - background.getTopHeight() - bottomHeight) / 2f + bottomHeight;
      }
      else
        num2 = num1 + height / 2f;
      if (font.usesIntegerPositions())
        num2 = (float) ByteCodeHelper.f2i(num2);
      return num2;
    }

    [LineNumberTable(new byte[] {160, 110, 104, 103, 151, 108, 172, 118, 122, 105, 146, 114, 105, 212, 103, 113, 106, 102, 107, 228, 61, 232, 69, 180, 103, 103, 104, 109, 110, 102, 226, 60, 232, 73, 127, 13, 117, 106, 49, 144, 148, 106, 117, 159, 6, 176, 107, 115, 115, 125, 127, 0, 104, 159, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void calculateOffsets()
    {
      float width = this.getWidth();
      Drawable backgroundDrawable = this.getBackgroundDrawable();
      if (backgroundDrawable != null)
        width -= backgroundDrawable.getLeftWidth() + backgroundDrawable.getRightWidth();
      int size = this.__\u003C\u003EglyphPositions.size;
      float[] items = this.__\u003C\u003EglyphPositions.items;
      this.cursor = Mathf.clamp(this.cursor, 0, items.Length - 1);
      float num1 = items[Math.max(0, this.cursor - 1)] + this.renderOffset;
      if ((double) num1 <= 0.0)
      {
        this.renderOffset -= num1;
      }
      else
      {
        int index = Math.min(size - 1, this.cursor + 1);
        float num2 = items[index] - width;
        if (-(double) this.renderOffset < (double) num2)
          this.renderOffset = -num2;
      }
      float num3 = 0.0f;
      float num4 = items[Mathf.clamp(size - 1, 0, items.Length - 1)];
      for (int index = size - 2; index >= 0; index += -1)
      {
        float num2 = items[index];
        if ((double) (num4 - num2) <= (double) width)
          num3 = num2;
        else
          break;
      }
      if (-(double) this.renderOffset > (double) num3)
        this.renderOffset = -num3;
      this.visibleTextStart = 0;
      float num5 = 0.0f;
      for (int index = 0; index < size; ++index)
      {
        if ((double) items[index] >= -(double) this.renderOffset)
        {
          this.visibleTextStart = Math.max(0, index);
          num5 = items[index];
          break;
        }
      }
      object obj = (object) this.displayText.__\u003Cref\u003E;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      int num6 = Math.min(((CharSequence) ref charSequence).length(), items.Length - 1);
      this.visibleTextEnd = Math.min(num6, this.cursor + 1);
      while (this.visibleTextEnd <= num6 && (double) items[this.visibleTextEnd] <= (double) (num5 + width))
        ++this.visibleTextEnd;
      this.visibleTextEnd = Math.max(0, this.visibleTextEnd - 1);
      if ((this.textHAlign & 8) == 0)
      {
        this.textOffset = width - (items[this.visibleTextEnd] - num5);
        if ((this.textHAlign & 1) != 0)
          this.textOffset = (float) Math.round(this.textOffset * 0.5f);
      }
      else
        this.textOffset = num5 + this.renderOffset;
      if (!this.hasSelection)
        return;
      int index1 = Math.min(this.cursor, this.selectionStart);
      int index2 = Math.max(this.cursor, this.selectionStart);
      float num7 = Math.max(items[index1] - items[this.visibleTextStart], -this.textOffset);
      float num8 = Math.min(items[index2] - items[this.visibleTextStart], width - this.textOffset);
      this.selectionX = num7;
      this.selectionWidth = num8 - num7 - this.style.font.getData().cursorX;
    }

    [LineNumberTable(new byte[] {161, 5, 127, 33})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void drawSelection(Drawable selection, Font font, float x, float y) => selection.draw(x + this.textOffset + this.selectionX + this.fontOffset, y - this.textHeight - font.getDescent(), this.selectionWidth, this.textHeight);

    [LineNumberTable(new byte[] {161, 9, 127, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void drawText(Font font, float x, float y)
    {
      Font font1 = font;
      // ISSUE: variable of the null type
      __Null local = this.displayText.__\u003Cref\u003E;
      double num1 = (double) (x + this.textOffset);
      double num2 = (double) y;
      int visibleTextStart = this.visibleTextStart;
      int visibleTextEnd = this.visibleTextEnd;
      bool flag = false;
      int num3 = 8;
      float num4 = 0.0f;
      int num5 = visibleTextEnd;
      int num6 = visibleTextStart;
      float num7 = (float) num2;
      float num8 = (float) num1;
      object obj = (object) local;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence str = charSequence;
      double num9 = (double) num8;
      double num10 = (double) num7;
      int start = num6;
      int end = num5;
      double num11 = (double) num4;
      int halign = num3;
      int num12 = flag ? 1 : 0;
      font1.draw(str, (float) num9, (float) num10, start, end, (float) num11, halign, num12 != 0);
    }

    [LineNumberTable(new byte[] {161, 65, 108, 103, 129, 102, 120, 114, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void blink()
    {
      if (!Core.graphics.isContinuousRendering())
      {
        this.cursorOn = true;
      }
      else
      {
        long num = Time.nanos();
        if ((double) ((float) (num - this.lastBlink) / 1E+09f) <= (double) this.blinkTime)
          return;
        this.cursorOn = !this.cursorOn;
        this.lastBlink = num;
      }
    }

    [LineNumberTable(new byte[] {161, 13, 119, 127, 30, 21, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void drawCursor(Drawable cursorPatch, Font font, float x, float y) => cursorPatch.draw(x + this.textOffset + this.__\u003C\u003EglyphPositions.get(this.cursor) - this.__\u003C\u003EglyphPositions.get(this.visibleTextStart) + this.fontOffset + font.getData().cursorX, y - this.textHeight - font.getDescent(), cursorPatch.getMinWidth(), this.textHeight);

    [Signature("(Larc/struct/Seq<Larc/scene/Element;>;Larc/scene/ui/TextField;Larc/math/geom/Vec2;Larc/math/geom/Vec2;Z)Larc/scene/ui/TextField;")]
    [LineNumberTable(new byte[] {159, 6, 99, 112, 109, 121, 107, 104, 122, 127, 4, 127, 25, 159, 25, 104, 169, 106, 248, 49, 233, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private TextField findNextTextField(
      [In] Seq obj0,
      [In] TextField obj1,
      [In] Vec2 obj2,
      [In] Vec2 obj3,
      [In] bool obj4)
    {
      int num = obj4 ? 1 : 0;
      int index = 0;
      for (int size = obj0.size; index < size; ++index)
      {
        Element element = (Element) obj0.get(index);
        if (!object.ReferenceEquals((object) element, (object) this) && element.visible)
        {
          switch (element)
          {
            case TextField _:
              TextField textField = (TextField) element;
              if (!textField.isDisabled() && textField.focusTraversal)
              {
                Vec2 stageCoordinates = element.parent.localToStageCoordinates(TextField.tmp3.set(element.x, element.y));
                if ((((double) stageCoordinates.y < (double) obj3.y || (double) stageCoordinates.y == (double) obj3.y && (double) stageCoordinates.x > (double) obj3.x ? 1 : 0) ^ num) != 0 && (obj1 == null || (((double) stageCoordinates.y > (double) obj2.y || (double) stageCoordinates.y == (double) obj2.y && (double) stageCoordinates.x < (double) obj2.x ? 1 : 0) ^ num) != 0))
                {
                  obj1 = (TextField) element;
                  obj2.set(stageCoordinates);
                  continue;
                }
                continue;
              }
              continue;
            case Group _:
              obj1 = this.findNextTextField((Seq) ((Group) element).getChildren(), obj1, obj2, obj3, num != 0);
              continue;
            default:
              continue;
          }
        }
      }
      return obj1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDisabled() => this.disabled;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTextFieldListener(TextField.TextFieldListener listener) => this.listener = listener;

    [LineNumberTable(new byte[] {162, 187, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool continueCursor(int index, int offset) => this.isWordCharacter(String.instancehelper_charAt(this.text, index + offset));

    [LineNumberTable(new byte[] {162, 1, 138, 102, 113, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void appendText(string str)
    {
      if (str == null)
        str = "";
      this.clearSelection();
      this.cursor = String.instancehelper_length(this.text);
      this.paste(str, this.programmaticChangeEvents);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {118, 102, 108, 117, 241, 70, 241, 70, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addInputDialog\u00242()
    {
      Input.TextInput input = new Input.TextInput();
      input.text = this.getText();
      if (this.maxLength > 0)
        input.maxLength = this.maxLength;
      input.accepted = (Cons) new TextField.__\u003C\u003EAnon4(this);
      input.canceled = (Runnable) new TextField.__\u003C\u003EAnon5(this);
      Core.input.getTextInput(input);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {158, 254, 68, 100, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024typed\u00243(
      [In] char obj0,
      [In] Runnable obj1,
      [In] TextField obj2,
      [In] char obj3)
    {
      if ((int) obj3 != (int) obj0)
        return;
      obj1.run();
    }

    [Modifiers]
    [LineNumberTable(583)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024typed\u00244([In] Cons obj0, [In] TextField obj1, [In] char obj2)
    {
      int num = (int) obj2;
      obj0.get((object) Character.valueOf((char) num));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {122, 102, 103, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addInputDialog\u00240([In] string obj0)
    {
      this.clearText();
      this.appendText(obj0);
      this.change();
      Core.input.setOnscreenKeyboardVisible(false);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 64, 104, 140, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addInputDialog\u00241()
    {
      if (this.hasKeyboard())
        Core.scene.setKeyboardFocus((Element) null);
      Core.input.setOnscreenKeyboardVisible(false);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getMaxLength() => this.maxLength;

    [LineNumberTable(new byte[] {160, 183, 103, 118, 142, 108, 127, 3, 127, 10, 109, 109, 136, 104, 104, 104, 105, 137, 127, 10, 110, 100, 111, 106, 170, 108, 134, 111, 181, 120, 127, 7, 113, 157, 109, 191, 59, 191, 6, 159, 83, 130, 127, 16, 151, 107, 102, 108, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      Scene scene = this.getScene();
      int num1 = scene == null || !object.ReferenceEquals((object) scene.getKeyboardFocus(), (object) this) ? 0 : 1;
      if (num1 == 0)
        this.keyRepeatTask.cancel();
      Font font1 = this.style.font;
      Color color1 = !this.disabled || this.style.disabledFontColor == null ? (num1 == 0 || this.style.focusedFontColor == null ? this.style.fontColor : this.style.focusedFontColor) : this.style.disabledFontColor;
      Drawable selection = this.style.selection;
      Drawable cursor = this.style.cursor;
      Drawable backgroundDrawable = this.getBackgroundDrawable();
      Color color2 = this.__\u003C\u003Ecolor;
      float x = this.x;
      float y = this.y;
      float width = this.getWidth();
      float height = this.getHeight();
      Draw.color(color2.r, color2.g, color2.b, color2.a * this.parentAlpha);
      float num2 = 0.0f;
      float num3 = 0.0f;
      if (backgroundDrawable != null)
      {
        backgroundDrawable.draw(x, y, width, height);
        num2 = backgroundDrawable.getLeftWidth();
        num3 = backgroundDrawable.getRightWidth();
      }
      float textY = this.getTextY(font1, backgroundDrawable);
      this.calculateOffsets();
      if (num1 != 0 && this.hasSelection && selection != null)
        this.drawSelection(selection, font1, x + num2, y + textY);
      float num4 = !font1.isFlipped() ? 0.0f : -this.textHeight;
      object obj1 = (object) this.displayText.__\u003Cref\u003E;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj1;
      if (((CharSequence) ref charSequence).length() == 0)
      {
        if (num1 == 0 && this.messageText != null)
        {
          Font font2 = this.style.messageFont == null ? font1 : this.style.messageFont;
          if (this.style.messageFontColor != null)
            font2.setColor(this.style.messageFontColor.r, this.style.messageFontColor.g, this.style.messageFontColor.b, this.style.messageFontColor.a * color2.a * this.parentAlpha);
          else
            font2.setColor(0.7f, 0.7f, 0.7f, color2.a * this.parentAlpha);
          Font font3 = font2;
          string messageText = this.messageText;
          double num5 = (double) (x + num2);
          double num6 = (double) (y + textY + num4);
          int num7 = String.instancehelper_length(this.messageText);
          double num8 = (double) (width - num2 - num3);
          int textHalign = this.textHAlign;
          string str1 = "...";
          bool flag = false;
          int num9 = textHalign;
          float num10 = (float) num8;
          int num11 = num7;
          int num12 = 0;
          float num13 = (float) num6;
          float num14 = (float) num5;
          object obj2 = (object) messageText;
          charSequence.__\u003Cref\u003E = (__Null) obj2;
          CharSequence str2 = charSequence;
          double num15 = (double) num14;
          double num16 = (double) num13;
          int start = num12;
          int end = num11;
          double num17 = (double) num10;
          int halign = num9;
          int num18 = flag ? 1 : 0;
          string truncate = str1;
          font3.draw(str2, (float) num15, (float) num16, start, end, (float) num17, halign, num18 != 0, truncate);
        }
      }
      else
      {
        font1.setColor(color1.r, color1.g, color1.b, color1.a * color2.a * this.parentAlpha);
        this.drawText(font1, x + num2, y + textY + num4);
      }
      if (num1 == 0 || this.disabled)
        return;
      this.blink();
      if (!this.cursorOn || cursor == null)
        return;
      this.drawCursor(cursor, font1, x + num2, y + textY);
    }

    [LineNumberTable(new byte[] {161, 88, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cut() => this.cut(this.programmaticChangeEvents);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual InputListener getDefaultInputListener() => this.inputListener;

    [LineNumberTable(new byte[] {158, 255, 162, 242, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void typed(char ch, Runnable run) => this.setTextFieldListener((TextField.TextFieldListener) new TextField.__\u003C\u003EAnon1(ch, run));

    [Signature("(Larc/func/Cons<Ljava/lang/Character;>;)V")]
    [LineNumberTable(new byte[] {161, 213, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void typed(Cons cons) => this.setTextFieldListener((TextField.TextFieldListener) new TextField.__\u003C\u003EAnon2(cons));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextField.TextFieldFilter getFilter() => this.filter;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValidator(TextField.TextFieldValidator validator) => this.validator = validator;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextField.TextFieldValidator getValidator() => this.validator;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFocusTraversal(bool focusTraversal) => this.focusTraversal = focusTraversal;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getMessageText() => this.messageText;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getProgrammaticChangeEvents() => this.programmaticChangeEvents;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setProgrammaticChangeEvents(bool programmaticChangeEvents) => this.programmaticChangeEvents = programmaticChangeEvents;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getSelectionStart() => this.selectionStart;

    [LineNumberTable(683)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getSelection() => this.hasSelection ? String.instancehelper_substring(this.text, Math.min(this.selectionStart, this.cursor), Math.max(this.selectionStart, this.cursor)) : "";

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getCursorPosition() => this.cursor;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextField.OnscreenKeyboard getOnscreenKeyboard() => this.keyboard;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOnscreenKeyboard(TextField.OnscreenKeyboard keyboard) => this.keyboard = keyboard;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAlignment(int alignment) => this.textHAlign = alignment;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPasswordMode() => this.passwordMode;

    [LineNumberTable(new byte[] {158, 204, 98, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPasswordMode(bool passwordMode)
    {
      this.passwordMode = passwordMode;
      this.updateDisplayText();
    }

    [LineNumberTable(new byte[] {158, 202, 130, 103, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPasswordCharacter(char passwordCharacter)
    {
      this.passwordCharacter = passwordCharacter;
      if (!this.passwordMode)
        return;
      this.updateDisplayText();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBlinkTime(float blinkTime) => this.blinkTime = blinkTime;

    [LineNumberTable(new byte[] {159, 130, 109, 106, 106, 138, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static TextField()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.scene.ui.TextField"))
        return;
      TextField.tmp1 = new Vec2();
      TextField.tmp2 = new Vec2();
      TextField.tmp3 = new Vec2();
      TextField.keyRepeatInitialTime = 0.4f;
      TextField.keyRepeatTime = 0.1f;
    }

    [Modifiers]
    protected internal GlyphLayout layout
    {
      [HideFromJava] get => this.__\u003C\u003Elayout;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Elayout = value;
    }

    [Modifiers]
    protected internal FloatSeq glyphPositions
    {
      [HideFromJava] get => this.__\u003C\u003EglyphPositions;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EglyphPositions = value;
    }

    public class DefaultOnscreenKeyboard : Object, TextField.OnscreenKeyboard
    {
      [LineNumberTable(853)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DefaultOnscreenKeyboard()
      {
      }

      [LineNumberTable(new byte[] {158, 184, 66, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void show(bool visible)
      {
        int num = visible ? 1 : 0;
        Core.input.setOnscreenKeyboardVisible(num != 0);
      }
    }

    internal class KeyRepeatTask : Timer.Task
    {
      internal KeyCode keycode;
      [Modifiers]
      internal TextField this\u00240;

      [LineNumberTable(895)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal KeyRepeatTask([In] TextField obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {163, 18, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void run() => this.this\u00240.inputListener.keyDown((InputEvent) null, this.keycode);
    }

    public interface OnscreenKeyboard
    {
      void show(bool b);
    }

    public class TextFieldClickListener : ClickListener
    {
      [Modifiers]
      internal TextField this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 62, 109, 108, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void setCursorPosition(float x, float y)
      {
        this.this\u00240.lastBlink = 0L;
        this.this\u00240.cursorOn = false;
        this.this\u00240.cursor = this.this\u00240.letterUnderCursor(x);
      }

      [LineNumberTable(new byte[] {163, 68, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void goHome(bool jump) => this.this\u00240.cursor = 0;

      [LineNumberTable(new byte[] {163, 72, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void goEnd(bool jump) => this.this\u00240.cursor = String.instancehelper_length(this.this\u00240.text);

      [LineNumberTable(new byte[] {163, 178, 127, 11, 113, 112, 155})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void scheduleKeyRepeatTask(KeyCode keycode)
      {
        if (this.this\u00240.keyRepeatTask.isScheduled() && object.ReferenceEquals((object) this.this\u00240.keyRepeatTask.keycode, (object) keycode))
          return;
        this.this\u00240.keyRepeatTask.keycode = keycode;
        this.this\u00240.keyRepeatTask.cancel();
        Timer.schedule((Timer.Task) this.this\u00240.keyRepeatTask, TextField.keyRepeatInitialTime, TextField.keyRepeatTime);
      }

      [LineNumberTable(1075)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual bool checkFocusTraverse(char character)
      {
        int num = (int) character;
        if (this.this\u00240.focusTraversal)
        {
          switch (num)
          {
            case 9:
              return true;
            case 10:
            case 13:
              if (!Core.app.isMobile())
                break;
              goto case 9;
          }
        }
        return false;
      }

      [LineNumberTable(905)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TextFieldClickListener(TextField _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {163, 26, 114, 110, 100, 110, 145, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void clicked(InputEvent @event, float x, float y)
      {
        int tapCount = this.getTapCount();
        int num1 = 4;
        int num2 = num1 != -1 ? tapCount % num1 : 0;
        if (num2 == 0)
          this.this\u00240.clearSelection();
        if (num2 == 2)
        {
          int[] numArray = this.this\u00240.wordUnderCursor(x);
          this.this\u00240.setSelection(numArray[0], numArray[1]);
        }
        if (num2 != 3)
          return;
        this.this\u00240.selectAll();
      }

      [LineNumberTable(new byte[] {163, 37, 115, 116, 111, 106, 118, 108, 112, 113, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool touchDown(
        InputEvent @event,
        float x,
        float y,
        int pointer,
        KeyCode button)
      {
        if (!base.touchDown(@event, x, y, pointer, button) || pointer == 0 && !object.ReferenceEquals((object) button, (object) KeyCode.__\u003C\u003EmouseLeft))
          return false;
        if (this.this\u00240.disabled)
          return true;
        this.setCursorPosition(x, y);
        this.this\u00240.selectionStart = this.this\u00240.cursor;
        this.this\u00240.getScene()?.setKeyboardFocus((Element) this.this\u00240);
        this.this\u00240.keyboard.show(true);
        this.this\u00240.hasSelection = true;
        return true;
      }

      [LineNumberTable(new byte[] {163, 51, 109, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchDragged(InputEvent @event, float x, float y, int pointer)
      {
        base.touchDragged(@event, x, y, pointer);
        this.setCursorPosition(x, y);
      }

      [LineNumberTable(new byte[] {163, 57, 127, 5, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchUp(
        InputEvent @event,
        float x,
        float y,
        int pointer,
        KeyCode button)
      {
        if (this.this\u00240.selectionStart == this.this\u00240.cursor)
          this.this\u00240.hasSelection = false;
        base.touchUp(@event, x, y, pointer, button);
      }

      [LineNumberTable(new byte[] {163, 77, 143, 109, 140, 108, 152, 98, 125, 149, 102, 109, 118, 130, 122, 107, 130, 109, 108, 130, 109, 107, 130, 109, 109, 118, 109, 107, 194, 111, 127, 4, 185, 173, 109, 109, 98, 130, 109, 109, 98, 130, 109, 103, 130, 112, 231, 69, 109, 109, 140, 165, 109, 109, 107, 130, 109, 109, 107, 130, 109, 103, 139, 109, 103, 171, 159, 13, 99, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool keyDown(InputEvent @event, KeyCode keycode)
      {
        if (this.this\u00240.disabled)
          return false;
        this.this\u00240.lastBlink = 0L;
        this.this\u00240.cursorOn = false;
        Scene scene = this.this\u00240.getScene();
        if (scene == null || !object.ReferenceEquals((object) scene.getKeyboardFocus(), (object) this.this\u00240))
          return false;
        int num1 = 0;
        int num2 = !Core.input.ctrl() || Core.input.alt() ? 0 : 1;
        int num3 = num2 == 0 || this.this\u00240.passwordMode ? 0 : 1;
        if (num2 != 0)
        {
          if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Ev))
          {
            this.this\u00240.paste(Core.app.getClipboardText(), true);
            num1 = 1;
          }
          if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Ec) || object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Einsert))
          {
            this.this\u00240.copy();
            return true;
          }
          if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Ex))
          {
            this.this\u00240.cut(true);
            return true;
          }
          if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Ea))
          {
            this.this\u00240.selectAll();
            return true;
          }
          if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Ez))
          {
            string text = this.this\u00240.text;
            this.this\u00240.setText(this.this\u00240.undoText);
            this.this\u00240.undoText = text;
            this.this\u00240.updateDisplayText();
            return true;
          }
        }
        if (Core.input.shift())
        {
          if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Einsert))
            this.this\u00240.paste(Core.app.getClipboardText(), true);
          if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003EforwardDel))
            this.this\u00240.cut(true);
          int cursor = this.this\u00240.cursor;
          if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Eleft))
          {
            this.this\u00240.moveCursor(false, num3 != 0);
            num1 = 1;
          }
          else if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Eright))
          {
            this.this\u00240.moveCursor(true, num3 != 0);
            num1 = 1;
          }
          else if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Ehome))
            this.goHome(num3 != 0);
          else if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Eend))
            this.goEnd(num3 != 0);
          else
            goto label_38;
          if (!this.this\u00240.hasSelection)
          {
            this.this\u00240.selectionStart = cursor;
            this.this\u00240.hasSelection = true;
          }
        }
        else
        {
          if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Eleft))
          {
            this.this\u00240.moveCursor(false, num3 != 0);
            this.this\u00240.clearSelection();
            num1 = 1;
          }
          if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Eright))
          {
            this.this\u00240.moveCursor(true, num3 != 0);
            this.this\u00240.clearSelection();
            num1 = 1;
          }
          if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Ehome))
          {
            this.goHome(num3 != 0);
            this.this\u00240.clearSelection();
          }
          if (object.ReferenceEquals((object) keycode, (object) KeyCode.__\u003C\u003Eend))
          {
            this.goEnd(num3 != 0);
            this.this\u00240.clearSelection();
          }
        }
label_38:
        this.this\u00240.cursor = Mathf.clamp(this.this\u00240.cursor, 0, String.instancehelper_length(this.this\u00240.text));
        if (num1 != 0)
          this.scheduleKeyRepeatTask(keycode);
        return true;
      }

      [LineNumberTable(new byte[] {163, 187, 111, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool keyUp(InputEvent @event, KeyCode keycode)
      {
        if (this.this\u00240.disabled)
          return false;
        this.this\u00240.keyRepeatTask.cancel();
        return true;
      }

      [LineNumberTable(new byte[] {158, 128, 66, 175, 255, 3, 69, 130, 167, 108, 152, 154, 105, 154, 102, 101, 112, 127, 34, 108, 107, 109, 109, 109, 156, 119, 127, 75, 144, 127, 1, 191, 57, 142, 127, 9, 127, 0, 115, 159, 55, 122, 103, 127, 4, 109, 98, 109, 171, 127, 5})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool keyTyped(InputEvent @event, char character)
      {
        int num1 = (int) character;
        if (this.this\u00240.disabled)
          return false;
        switch (num1)
        {
          case 8:
          case 9:
          case 10:
          case 13:
            Scene scene = this.this\u00240.getScene();
            if (scene == null || !object.ReferenceEquals((object) scene.getKeyboardFocus(), (object) this.this\u00240))
              return false;
            if (OS.isMac && Core.input.keyDown(KeyCode.__\u003C\u003Esym))
              return true;
            if (this.checkFocusTraverse((char) num1))
            {
              this.this\u00240.next(Core.input.shift());
            }
            else
            {
              int num2 = num1 == (int) sbyte.MaxValue ? 1 : 0;
              int num3 = num1 == 8 ? 1 : 0;
              int num4 = num1 == 10 || num1 == 13 ? 1 : 0;
              int num5 = num4 == 0 ? (!this.this\u00240.onlyFontChars || this.this\u00240.style.font.getData().hasGlyph((char) num1) ? 1 : 0) : (this.this\u00240.writeEnters ? 1 : 0);
              int num6 = num3 != 0 || num2 != 0 ? 1 : 0;
              if (num5 != 0 || num6 != 0)
              {
                string text1 = this.this\u00240.text;
                int cursor1 = this.this\u00240.cursor;
                if (this.this\u00240.hasSelection)
                {
                  this.this\u00240.cursor = this.this\u00240.delete(false);
                }
                else
                {
                  if (num3 != 0 && this.this\u00240.cursor > 0)
                  {
                    TextField this0_1 = this.this\u00240;
                    StringBuilder stringBuilder = new StringBuilder().append(String.instancehelper_substring(this.this\u00240.text, 0, this.this\u00240.cursor - 1));
                    string text2 = this.this\u00240.text;
                    TextField this0_2 = this.this\u00240;
                    int cursor2 = this0_2.cursor;
                    TextField textField = this0_2;
                    int num7 = cursor2;
                    textField.cursor = cursor2 - 1;
                    string str1 = String.instancehelper_substring(text2, num7);
                    string str2 = stringBuilder.append(str1).toString();
                    this0_1.text = str2;
                    this.this\u00240.renderOffset = 0.0f;
                  }
                  if (num2 != 0 && this.this\u00240.cursor < String.instancehelper_length(this.this\u00240.text))
                    this.this\u00240.text = new StringBuilder().append(String.instancehelper_substring(this.this\u00240.text, 0, this.this\u00240.cursor)).append(String.instancehelper_substring(this.this\u00240.text, this.this\u00240.cursor + 1)).toString();
                }
                if (num5 != 0 && num6 == 0)
                {
                  if (this.this\u00240.filter != null && !this.this\u00240.filter.acceptChar(this.this\u00240, (char) num1) || !this.this\u00240.withinMaxLength(String.instancehelper_length(this.this\u00240.text)))
                    return true;
                  string str1 = num4 == 0 ? String.valueOf((char) num1) : "\n";
                  TextField this0_1 = this.this\u00240;
                  TextField this0_2 = this.this\u00240;
                  TextField this0_3 = this.this\u00240;
                  int cursor2 = this0_3.cursor;
                  TextField textField = this0_3;
                  int num7 = cursor2;
                  textField.cursor = cursor2 + 1;
                  string str2 = str1;
                  string text2 = this.this\u00240.text;
                  object obj = (object) str2;
                  CharSequence charSequence1;
                  charSequence1.__\u003Cref\u003E = (__Null) obj;
                  CharSequence charSequence2 = charSequence1;
                  string str3 = text2;
                  string str4 = this0_2.insert(num7, charSequence2, str3);
                  this0_1.text = str4;
                }
                if (this.this\u00240.changeText(text1, this.this\u00240.text))
                {
                  long num7 = java.lang.System.currentTimeMillis();
                  if (num7 - 750L > this.this\u00240.lastChangeTime)
                    this.this\u00240.undoText = text1;
                  this.this\u00240.lastChangeTime = num7;
                }
                else
                  this.this\u00240.cursor = cursor1;
                this.this\u00240.updateDisplayText();
              }
            }
            if (this.this\u00240.listener != null)
              this.this\u00240.listener.keyTyped(this.this\u00240, (char) num1);
            return true;
          default:
            if (num1 < 32)
              return false;
            goto case 8;
        }
      }

      [HideFromJava]
      static TextFieldClickListener() => ClickListener.__\u003Cclinit\u003E();
    }

    public interface TextFieldFilter
    {
      static readonly TextField.TextFieldFilter digitsOnly;
      static readonly TextField.TextFieldFilter floatsOnly;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static void __\u003Cclinit\u003E()
      {
      }

      bool acceptChar(TextField tf, char ch);

      [LineNumberTable(new byte[] {158, 191, 141, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static TextFieldFilter()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.scene.ui.TextField$TextFieldFilter"))
          return;
        TextField.TextFieldFilter.digitsOnly = (TextField.TextFieldFilter) new TextField.TextFieldFilter.__\u003C\u003EAnon0();
        TextField.TextFieldFilter.floatsOnly = (TextField.TextFieldFilter) new TextField.TextFieldFilter.__\u003C\u003EAnon1();
      }

      private static class __\u003C\u003EPIM
      {
        [Modifiers]
        [LineNumberTable(830)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static bool lambda\u0024static\u00240([In] TextField obj0, [In] char obj1) => Character.isDigit(obj1);

        [Modifiers]
        [LineNumberTable(831)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static bool lambda\u0024static\u00241([In] TextField obj0, [In] char obj1)
        {
          int num = (int) obj1;
          if (!Character.isDigit((char) num))
          {
            string text = obj0.getText();
            object obj = (object) ".";
            CharSequence charSequence1;
            charSequence1.__\u003Cref\u003E = (__Null) obj;
            CharSequence charSequence2 = charSequence1;
            if (String.instancehelper_contains(text, charSequence2) || num != 46)
              return false;
          }
          return true;
        }
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : TextField.TextFieldFilter
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public bool acceptChar([In] TextField obj0, [In] char obj1) => (TextField.TextFieldFilter.__\u003C\u003EPIM.lambda\u0024static\u00240(obj0, obj1) ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : TextField.TextFieldFilter
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public bool acceptChar([In] TextField obj0, [In] char obj1) => (TextField.TextFieldFilter.__\u003C\u003EPIM.lambda\u0024static\u00241(obj0, obj1) ? 1 : 0) != 0;
      }

      [HideFromJava]
      static class __Fields
      {
        public static readonly TextField.TextFieldFilter digitsOnly = TextField.TextFieldFilter.digitsOnly;
        public static readonly TextField.TextFieldFilter floatsOnly = TextField.TextFieldFilter.floatsOnly;
      }
    }

    public interface TextFieldListener
    {
      void keyTyped(TextField tf, char ch);
    }

    public class TextFieldStyle : Style
    {
      public Font font;
      public Color fontColor;
      public Color focusedFontColor;
      public Color disabledFontColor;
      public Drawable background;
      public Drawable focusedBackground;
      public Drawable disabledBackground;
      public Drawable invalidBackground;
      public Drawable cursor;
      public Drawable selection;
      public Font messageFont;
      public Color messageFontColor;

      [LineNumberTable(new byte[] {162, 251, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TextFieldStyle()
      {
      }

      [LineNumberTable(new byte[] {162, 254, 104, 108, 126, 108, 108, 108, 108, 108, 126, 126, 126, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TextFieldStyle(TextField.TextFieldStyle style)
      {
        TextField.TextFieldStyle textFieldStyle = this;
        this.messageFont = style.messageFont;
        if (style.messageFontColor != null)
        {
          Color.__\u003Cclinit\u003E();
          this.messageFontColor = new Color(style.messageFontColor);
        }
        this.background = style.background;
        this.focusedBackground = style.focusedBackground;
        this.disabledBackground = style.disabledBackground;
        this.cursor = style.cursor;
        this.font = style.font;
        if (style.fontColor != null)
        {
          Color.__\u003Cclinit\u003E();
          this.fontColor = new Color(style.fontColor);
        }
        if (style.focusedFontColor != null)
        {
          Color.__\u003Cclinit\u003E();
          this.focusedFontColor = new Color(style.focusedFontColor);
        }
        if (style.disabledFontColor != null)
        {
          Color.__\u003Cclinit\u003E();
          this.disabledFontColor = new Color(style.disabledFontColor);
        }
        this.selection = style.selection;
      }
    }

    public interface TextFieldValidator
    {
      bool valid(string str);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly TextField arg\u00241;

      internal __\u003C\u003EAnon0([In] TextField obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024addInputDialog\u00242();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : TextField.TextFieldListener
    {
      private readonly char arg\u00241;
      private readonly Runnable arg\u00242;

      internal __\u003C\u003EAnon1([In] char obj0, [In] Runnable obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void keyTyped([In] TextField obj0, [In] char obj1) => TextField.lambda\u0024typed\u00243(this.arg\u00241, this.arg\u00242, obj0, obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : TextField.TextFieldListener
    {
      private readonly Cons arg\u00241;

      internal __\u003C\u003EAnon2([In] Cons obj0) => this.arg\u00241 = obj0;

      public void keyTyped([In] TextField obj0, [In] char obj1) => TextField.lambda\u0024typed\u00244(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Prov
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public object get() => (object) new ChangeListener.ChangeEvent();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly TextField arg\u00241;

      internal __\u003C\u003EAnon4([In] TextField obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024addInputDialog\u00240((string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly TextField arg\u00241;

      internal __\u003C\u003EAnon5([In] TextField obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024addInputDialog\u00241();
    }
  }
}
