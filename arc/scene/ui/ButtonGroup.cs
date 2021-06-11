// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.ButtonGroup
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.scene.ui
{
  [Signature("<T:Larc/scene/ui/Button;>Ljava/lang/Object;")]
  public class ButtonGroup : Object
  {
    [Modifiers]
    [Signature("Larc/struct/Seq<TT;>;")]
    private Seq buttons;
    [Signature("Larc/struct/Seq<TT;>;")]
    private Seq checkedButtons;
    private int minCheckCount;
    private int maxCheckCount;
    private bool uncheckLast;
    [Signature("TT;")]
    private Button lastChecked;

    [LineNumberTable(new byte[] {159, 161, 232, 58, 107, 108, 103, 199, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ButtonGroup()
    {
      ButtonGroup buttonGroup = this;
      this.buttons = new Seq();
      this.checkedButtons = new Seq(1);
      this.maxCheckCount = 1;
      this.uncheckLast = true;
      this.minCheckCount = 1;
    }

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {159, 172, 115, 103, 127, 1, 103, 103, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Button button)
    {
      if (button == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("button cannot be null.");
      }
      button.buttonGroup = (ButtonGroup) null;
      int num = button.isChecked() || this.buttons.size < this.minCheckCount ? 1 : 0;
      button.setChecked(false);
      button.buttonGroup = this;
      this.buttons.add((object) button);
      button.setChecked(num != 0);
    }

    [Signature("(TT;Z)Z")]
    [LineNumberTable(new byte[] {159, 125, 98, 139, 131, 117, 176, 124, 104, 103, 103, 108, 103, 98, 130, 108, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool canCheck(Button button, bool newState)
    {
      int num = newState ? 1 : 0;
      if ((button.isChecked ? 1 : 0) == num)
        return false;
      if (num == 0)
      {
        if (this.checkedButtons.size <= this.minCheckCount)
          return false;
        this.checkedButtons.remove((object) button, true);
      }
      else
      {
        if (this.maxCheckCount != -1 && this.checkedButtons.size >= this.maxCheckCount)
        {
          if (!this.uncheckLast)
            return false;
          int minCheckCount = this.minCheckCount;
          this.minCheckCount = 0;
          this.lastChecked.setChecked(false);
          this.minCheckCount = minCheckCount;
        }
        this.checkedButtons.add((object) button);
        this.lastChecked = button;
      }
      return true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMinCheckCount(int minCheckCount) => this.minCheckCount = minCheckCount;

    [Signature("([TT;)V")]
    [LineNumberTable(new byte[] {159, 182, 115, 105, 41, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(params Button[] buttons)
    {
      if (buttons == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("buttons cannot be null.");
      }
      int index = 0;
      for (int length = buttons.Length; index < length; ++index)
        this.add(buttons[index]);
    }

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {159, 188, 115, 103, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(Button button)
    {
      if (button == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("button cannot be null.");
      }
      button.buttonGroup = (ButtonGroup) null;
      this.buttons.remove((object) button, true);
      this.checkedButtons.remove((object) button, true);
    }

    [Signature("([TT;)V")]
    [LineNumberTable(new byte[] {159, 165, 232, 54, 107, 108, 103, 231, 72, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ButtonGroup(params Button[] buttons)
    {
      ButtonGroup buttonGroup = this;
      this.buttons = new Seq();
      this.checkedButtons = new Seq(1);
      this.maxCheckCount = 1;
      this.uncheckLast = true;
      this.minCheckCount = 0;
      this.add(buttons);
      this.minCheckCount = 1;
    }

    [Signature("([TT;)V")]
    [LineNumberTable(new byte[] {3, 115, 105, 41, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(params Button[] buttons)
    {
      if (buttons == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("buttons cannot be null.");
      }
      int index = 0;
      for (int length = buttons.Length; index < length; ++index)
        this.remove(buttons[index]);
    }

    [LineNumberTable(new byte[] {9, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      this.buttons.clear();
      this.checkedButtons.clear();
    }

    [LineNumberTable(new byte[] {45, 103, 103, 114, 114, 7, 198, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void uncheckAll()
    {
      int minCheckCount = this.minCheckCount;
      this.minCheckCount = 0;
      int index = 0;
      for (int size = this.buttons.size; index < size; ++index)
        ((Button) this.buttons.get(index)).setChecked(false);
      this.minCheckCount = minCheckCount;
    }

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {56, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Button getChecked() => this.checkedButtons.size > 0 ? (Button) this.checkedButtons.get(0) : (Button) null;

    [LineNumberTable(new byte[] {62, 115, 117, 114, 127, 22, 103, 225, 60, 233, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setChecked(string text)
    {
      if (text == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("text cannot be null.");
      }
      int index = 0;
      for (int size = this.buttons.size; index < size; ++index)
      {
        Button button = (Button) this.buttons.get(index);
        if (button is TextButton)
        {
          string str = text;
          object obj = (object) ((TextButton) button).getText().__\u003Cref\u003E;
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj;
          CharSequence charSequence2 = charSequence1;
          if (String.instancehelper_contentEquals(str, charSequence2))
          {
            button.setChecked(true);
            break;
          }
        }
      }
    }

    [LineNumberTable(new byte[] {74, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getCheckedIndex() => this.checkedButtons.size > 0 ? this.buttons.indexOf((object) (Button) this.checkedButtons.get(0), true) : -1;

    [Signature("()Larc/struct/Seq<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getAllChecked() => this.checkedButtons;

    [Signature("()Larc/struct/Seq<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getButtons() => this.buttons;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMaxCheckCount(int maxCheckCount)
    {
      if (maxCheckCount == 0)
        maxCheckCount = -1;
      this.maxCheckCount = maxCheckCount;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUncheckLast(bool uncheckLast) => this.uncheckLast = uncheckLast;
  }
}
