// Decompiled with JetBrains decompiler
// Type: mindustry.ui.fragments.ScriptConsoleFragment
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.input;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.fragments
{
  public class ScriptConsoleFragment : Table
  {
    private const int messagesShown = 30;
    [Signature("Larc/struct/Seq<Ljava/lang/String;>;")]
    private Seq messages;
    private bool open;
    private bool shown;
    private TextField chatfield;
    private Label fieldlabel;
    private Font font;
    private GlyphLayout layout;
    private float offsetx;
    private float offsety;
    private float fontoffsetx;
    private float chatspace;
    private Color shadowColor;
    private float textspacing;
    [Signature("Larc/struct/Seq<Ljava/lang/String;>;")]
    private Seq history;
    private int historyPos;
    private int scrollPos;
    private Fragment container;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {160, 111, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addMessage(string message) => this.messages.insert(0, (object) message);

    [LineNumberTable(new byte[] {159, 183, 232, 45, 107, 135, 159, 1, 107, 127, 37, 127, 0, 113, 107, 103, 103, 236, 72, 103, 139, 242, 76, 242, 84, 113, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScriptConsoleFragment()
    {
      ScriptConsoleFragment scriptConsoleFragment = this;
      this.messages = new Seq();
      this.open = false;
      object obj = (object) ">";
      CharSequence text;
      text.__\u003Cref\u003E = (__Null) obj;
      this.fieldlabel = new Label(text);
      this.layout = new GlyphLayout();
      this.offsetx = Scl.scl(4f);
      this.offsety = Scl.scl(4f);
      this.fontoffsetx = Scl.scl(2f);
      this.chatspace = Scl.scl(50f);
      this.shadowColor = new Color(0.0f, 0.0f, 0.0f, 0.4f);
      this.textspacing = Scl.scl(10f);
      this.history = new Seq();
      this.historyPos = 0;
      this.scrollPos = 0;
      this.container = (Fragment) new ScriptConsoleFragment.\u0031(this);
      this.setFillParent(true);
      this.font = Fonts.def;
      this.visible((Boolp) new ScriptConsoleFragment.__\u003C\u003EAnon0(this));
      this.update((Runnable) new ScriptConsoleFragment.__\u003C\u003EAnon1(this));
      this.history.insert(0, (object) "");
      this.setup();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fragment container() => this.container;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shown() => this.shown;

    [LineNumberTable(new byte[] {42, 123, 118, 150, 127, 15, 113, 117, 117, 150, 159, 31, 127, 30})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setup()
    {
      this.fieldlabel.setStyle(new Label.LabelStyle(this.fieldlabel.getStyle()));
      this.fieldlabel.getStyle().font = this.font;
      this.fieldlabel.setStyle(this.fieldlabel.getStyle());
      TextField.__\u003Cclinit\u003E();
      this.chatfield = new TextField("", new TextField.TextFieldStyle((TextField.TextFieldStyle) Core.scene.getStyle((Class) ClassLiteral<TextField.TextFieldStyle>.Value)));
      this.chatfield.getStyle().background = (Drawable) null;
      this.chatfield.getStyle().font = Fonts.chat;
      this.chatfield.getStyle().fontColor = Color.__\u003C\u003Ewhite;
      this.chatfield.setStyle(this.chatfield.getStyle());
      this.bottom().left().marginBottom(this.offsety).marginLeft(this.offsetx * 2f).add((Element) this.fieldlabel).padBottom(6f);
      this.add((Element) this.chatfield).padBottom(this.offsety).padLeft(this.offsetx).growX().padRight(this.offsetx).height(28f);
    }

    [LineNumberTable(new byte[] {160, 97, 103, 113, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearChatInput()
    {
      this.historyPos = 0;
      this.history.set(0, (object) "");
      this.chatfield.setText("");
    }

    [LineNumberTable(new byte[] {36, 108, 108, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearMessages()
    {
      this.messages.clear();
      this.history.clear();
      this.history.insert(0, (object) "");
    }

    [LineNumberTable(new byte[] {106, 108, 134, 191, 27, 109, 102, 161, 141, 127, 50, 127, 40})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void sendMessage()
    {
      string text = this.chatfield.getText();
      this.clearChatInput();
      string str1 = text;
      object obj1 = (object) "";
      object obj2 = (object) " ";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj2;
      CharSequence charSequence2 = charSequence1;
      object obj3 = obj1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence charSequence3 = charSequence1;
      if (String.instancehelper_isEmpty(String.instancehelper_replace(str1, charSequence2, charSequence3)))
        return;
      if (String.instancehelper_equals(text, (object) "clear"))
      {
        this.clearMessages();
      }
      else
      {
        this.history.insert(1, (object) text);
        StringBuilder stringBuilder = new StringBuilder().append("[lightgray]> ");
        string str2 = text;
        object obj4 = (object) "[[";
        object obj5 = (object) "[";
        charSequence1.__\u003Cref\u003E = (__Null) obj5;
        CharSequence charSequence4 = charSequence1;
        object obj6 = obj4;
        charSequence1.__\u003Cref\u003E = (__Null) obj6;
        CharSequence charSequence5 = charSequence1;
        string str3 = String.instancehelper_replace(str2, charSequence4, charSequence5);
        this.addMessage(stringBuilder.append(str3).toString());
        string str4 = Vars.mods.getScripts().runConsole(text);
        object obj7 = (object) "[[";
        object obj8 = (object) "[";
        charSequence1.__\u003Cref\u003E = (__Null) obj8;
        CharSequence charSequence6 = charSequence1;
        object obj9 = obj7;
        charSequence1.__\u003Cref\u003E = (__Null) obj9;
        CharSequence charSequence7 = charSequence1;
        this.addMessage(String.instancehelper_replace(str4, charSequence6, charSequence7));
      }
    }

    [LineNumberTable(new byte[] {160, 86, 108, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hide()
    {
      Core.scene.setKeyboardFocus((Element) null);
      this.open = false;
      this.clearChatInput();
    }

    [LineNumberTable(new byte[] {125, 107, 113, 114, 103, 102, 241, 70, 113, 107, 98, 173, 108, 114, 103, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toggle()
    {
      if (!this.open)
      {
        Core.scene.setKeyboardFocus((Element) this.chatfield);
        this.open = !this.open;
        if (Vars.mobile)
          Core.input.getTextInput(new Input.TextInput()
          {
            accepted = (Cons) new ScriptConsoleFragment.__\u003C\u003EAnon2(this),
            canceled = (Runnable) new ScriptConsoleFragment.__\u003C\u003EAnon3(this)
          });
        else
          this.chatfield.fireClick();
      }
      else
      {
        Core.scene.setKeyboardFocus((Element) null);
        this.open = !this.open;
        this.scrollPos = 0;
        this.sendMessage();
      }
    }

    [LineNumberTable(new byte[] {160, 92, 127, 2, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateChat()
    {
      this.chatfield.setText((string) this.history.get(this.historyPos));
      this.chatfield.setCursorPosition(String.instancehelper_length(this.chatfield.getText()));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 188, 127, 41, 114, 119, 134, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024new\u00240()
    {
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Econsole) && (object.ReferenceEquals((object) Core.scene.getKeyboardFocus(), (object) this.chatfield) || Core.scene.getKeyboardFocus() == null) && !Vars.ui.chatfrag.shown())
      {
        this.shown = !this.shown;
        if (this.shown && !this.open && Vars.enableConsole)
          this.toggle();
        this.clearChatInput();
      }
      return this.shown;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {8, 127, 28, 166, 107, 127, 7, 127, 0, 110, 134, 122, 110, 198, 127, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241()
    {
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Echat) && Vars.enableConsole && (object.ReferenceEquals((object) Core.scene.getKeyboardFocus(), (object) this.chatfield) || Core.scene.getKeyboardFocus() == null))
        this.toggle();
      if (this.open)
      {
        if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Echat_history_prev) && this.historyPos < this.history.size - 1)
        {
          if (this.historyPos == 0)
            this.history.set(0, (object) this.chatfield.getText());
          ++this.historyPos;
          this.updateChat();
        }
        if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Echat_history_next) && this.historyPos > 0)
        {
          --this.historyPos;
          this.updateChat();
        }
      }
      this.scrollPos = ByteCodeHelper.f2i(Mathf.clamp((float) this.scrollPos + Core.input.axis((KeyBinds.KeyBind) Binding.__\u003C\u003Echat_scroll), 0.0f, (float) Math.max(0, this.messages.size - 30)));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 67, 108, 102, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024toggle\u00242([In] string obj0)
    {
      this.chatfield.setText(obj0);
      this.sendMessage();
      this.hide();
      Core.input.setOnscreenKeyboardVisible(false);
    }

    [LineNumberTable(new byte[] {59, 102, 155, 139, 104, 191, 41, 134, 135, 113, 145, 107, 147, 127, 0, 159, 11, 127, 49, 119, 156, 112, 159, 71, 104, 113, 159, 5, 177, 127, 34, 107, 147, 240, 44, 235, 87, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      float alpha = 1f;
      float num1 = (float) Core.graphics.getWidth() - this.offsetx * 2f;
      Draw.color(this.shadowColor);
      if (this.open)
        Fill.crect(this.offsetx, this.chatfield.y + Core.scene.marginBottom, this.chatfield.getWidth() + 15f, this.chatfield.getHeight() - 1f);
      base.draw();
      float chatspace = this.chatspace;
      this.chatfield.visible = this.open;
      this.fieldlabel.visible = this.open;
      Draw.color(this.shadowColor);
      Draw.alpha(this.shadowColor.a * alpha);
      float num2 = this.offsety + chatspace + this.getMarginBottom() + Core.scene.marginBottom;
      for (int scrollPos = this.scrollPos; scrollPos < this.messages.size && scrollPos < 30 + this.scrollPos; ++scrollPos)
      {
        GlyphLayout layout = this.layout;
        Font font = this.font;
        object obj1 = this.messages.get(scrollPos);
        CharSequence.Cast(obj1);
        Color white = Color.__\u003C\u003Ewhite;
        double num3 = (double) num1;
        bool flag1 = true;
        int num4 = 12;
        float num5 = (float) num3;
        Color color1 = white;
        object obj2 = obj1;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        CharSequence str1 = charSequence;
        Color color2 = color1;
        double num6 = (double) num5;
        int halign1 = num4;
        int num7 = flag1 ? 1 : 0;
        layout.setText(font, str1, color2, (float) num6, halign1, num7 != 0);
        num2 += this.layout.height + this.textspacing;
        if (scrollPos - this.scrollPos == 0)
          num2 -= this.textspacing + 1f;
        this.font.getCache().clear();
        FontCache cache = this.font.getCache();
        object obj3 = this.messages.get(scrollPos);
        CharSequence.Cast(obj3);
        double num8 = (double) (this.fontoffsetx + this.offsetx);
        double num9 = (double) (this.offsety + num2);
        double num10 = (double) num1;
        bool flag2 = true;
        int num11 = 12;
        float num12 = (float) num10;
        float num13 = (float) num9;
        float num14 = (float) num8;
        object obj4 = obj3;
        charSequence.__\u003Cref\u003E = (__Null) obj4;
        CharSequence str2 = charSequence;
        double num15 = (double) num14;
        double num16 = (double) num13;
        double num17 = (double) num12;
        int halign2 = num11;
        int num18 = flag2 ? 1 : 0;
        cache.addText(str2, (float) num15, (float) num16, (float) num17, halign2, num18 != 0);
        if (!this.open)
        {
          this.font.getCache().setAlphas(alpha);
          Draw.color(0.0f, 0.0f, 0.0f, this.shadowColor.a * alpha);
        }
        else
          this.font.getCache().setAlphas(alpha);
        Fill.crect(this.offsetx, num2 - this.layout.height - 2f, num1 + Scl.scl(4f), this.layout.height + this.textspacing);
        Draw.color(this.shadowColor);
        Draw.alpha(alpha * this.shadowColor.a);
        this.font.getCache().draw();
      }
      Draw.color();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool open() => this.open;

    [HideFromJava]
    static ScriptConsoleFragment() => Table.__\u003Cclinit\u003E();

    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal new class \u0031 : Fragment
    {
      [Modifiers]
      internal ScriptConsoleFragment this\u00240;

      [LineNumberTable(34)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] ScriptConsoleFragment obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 179, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build([In] Group obj0) => Core.scene.add((Element) this.this\u00240);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolp
    {
      private readonly ScriptConsoleFragment arg\u00241;

      internal __\u003C\u003EAnon0([In] ScriptConsoleFragment obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024new\u00240() ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly ScriptConsoleFragment arg\u00241;

      internal __\u003C\u003EAnon1([In] ScriptConsoleFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly ScriptConsoleFragment arg\u00241;

      internal __\u003C\u003EAnon2([In] ScriptConsoleFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024toggle\u00242((string) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly ScriptConsoleFragment arg\u00241;

      internal __\u003C\u003EAnon3([In] ScriptConsoleFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }
  }
}
