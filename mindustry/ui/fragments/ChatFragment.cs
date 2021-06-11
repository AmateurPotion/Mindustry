// Decompiled with JetBrains decompiler
// Type: mindustry.ui.fragments.ChatFragment
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
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.gen;
using mindustry.input;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.fragments
{
  public class ChatFragment : Table
  {
    private const int messagesShown = 10;
    [Signature("Larc/struct/Seq<Lmindustry/ui/fragments/ChatFragment$ChatMessage;>;")]
    private Seq messages;
    private float fadetime;
    private bool shown;
    private TextField chatfield;
    private Label fieldlabel;
    private ChatFragment.ChatMode mode;
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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shown() => this.shown;

    [LineNumberTable(new byte[] {160, 104, 108, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hide()
    {
      Core.scene.setKeyboardFocus((Element) null);
      this.shown = false;
      this.clearChatInput();
    }

    [LineNumberTable(new byte[] {160, 146, 103, 147, 115, 158, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addMessage(string message, string sender)
    {
      if (sender == null && message == null)
        return;
      this.messages.insert(0, (object) new ChatFragment.ChatMessage(message, sender));
      ++this.fadetime;
      this.fadetime = Math.min(this.fadetime, 10f) + 1f;
      if (this.scrollPos <= 0)
        return;
      ++this.scrollPos;
    }

    [LineNumberTable(new byte[] {47, 108, 108, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearMessages()
    {
      this.messages.clear();
      this.history.clear();
      this.history.insert(0, (object) "");
    }

    [LineNumberTable(new byte[] {159, 190, 232, 42, 139, 135, 127, 1, 139, 107, 127, 37, 127, 0, 113, 107, 103, 103, 236, 74, 103, 139, 242, 76, 242, 87, 113, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ChatFragment()
    {
      ChatFragment chatFragment = this;
      this.messages = new Seq();
      this.shown = false;
      object obj = (object) ">";
      CharSequence text;
      text.__\u003Cref\u003E = (__Null) obj;
      this.fieldlabel = new Label(text);
      this.mode = ChatFragment.ChatMode.normal;
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
      this.container = (Fragment) new ChatFragment.\u0031(this);
      this.setFillParent(true);
      this.font = Fonts.def;
      this.visible((Boolp) new ChatFragment.__\u003C\u003EAnon0(this));
      this.update((Runnable) new ChatFragment.__\u003C\u003EAnon1(this));
      this.history.insert(0, (object) "");
      this.setup();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fragment container() => this.container;

    [LineNumberTable(new byte[] {53, 123, 118, 150, 127, 15, 112, 113, 117, 117, 150, 159, 31, 159, 30, 103, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setup()
    {
      this.fieldlabel.setStyle(new Label.LabelStyle(this.fieldlabel.getStyle()));
      this.fieldlabel.getStyle().font = this.font;
      this.fieldlabel.setStyle(this.fieldlabel.getStyle());
      TextField.__\u003Cclinit\u003E();
      this.chatfield = new TextField("", new TextField.TextFieldStyle((TextField.TextFieldStyle) Core.scene.getStyle((Class) ClassLiteral<TextField.TextFieldStyle>.Value)));
      this.chatfield.setMaxLength(150);
      this.chatfield.getStyle().background = (Drawable) null;
      this.chatfield.getStyle().font = Fonts.chat;
      this.chatfield.getStyle().fontColor = Color.__\u003C\u003Ewhite;
      this.chatfield.setStyle(this.chatfield.getStyle());
      this.bottom().left().marginBottom(this.offsety).marginLeft(this.offsetx * 2f).add((Element) this.fieldlabel).padBottom(6f);
      this.add((Element) this.chatfield).padBottom(this.offsety).padLeft(this.offsetx).growX().padRight(this.offsetx).height(28f);
      if (!Vars.mobile)
        return;
      this.marginBottom(105f);
      this.marginRight(240f);
    }

    [LineNumberTable(new byte[] {160, 131, 103, 113, 118, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearChatInput()
    {
      this.historyPos = 0;
      this.history.set(0, (object) "");
      this.chatfield.setText(this.mode.normalizedPrefix());
      this.updateCursor();
    }

    [LineNumberTable(new byte[] {160, 138, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateCursor() => this.chatfield.setCursorPosition(String.instancehelper_length(this.chatfield.getText()));

    [LineNumberTable(new byte[] {127, 113, 134, 137, 141, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void sendMessage()
    {
      string message = String.instancehelper_trim(this.chatfield.getText());
      this.clearChatInput();
      if (String.instancehelper_isEmpty(message))
        return;
      this.history.insert(1, (object) message);
      Call.sendChatMessage(message);
    }

    [LineNumberTable(new byte[] {160, 75, 107, 113, 103, 103, 102, 107, 241, 70, 113, 107, 98, 205, 246, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toggle()
    {
      if (!this.shown)
      {
        Core.scene.setKeyboardFocus((Element) this.chatfield);
        this.shown = true;
        if (Vars.mobile)
          Core.input.getTextInput(new Input.TextInput()
          {
            maxLength = 150,
            accepted = (Cons) new ChatFragment.__\u003C\u003EAnon2(this),
            canceled = (Runnable) new ChatFragment.__\u003C\u003EAnon3(this)
          });
        else
          this.chatfield.fireClick();
      }
      else
        Time.runTask(2f, (Runnable) new ChatFragment.__\u003C\u003EAnon4(this));
    }

    [LineNumberTable(new byte[] {160, 110, 127, 33, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateChat()
    {
      this.chatfield.setText(new StringBuilder().append(this.mode.normalizedPrefix()).append((string) this.history.get(this.historyPos)).toString());
      this.updateCursor();
    }

    [LineNumberTable(new byte[] {160, 115, 167, 113, 141, 120, 159, 40, 182, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void nextMode()
    {
      ChatFragment.ChatMode mode = this.mode;
      do
      {
        this.mode = this.mode.next();
      }
      while (!this.mode.isValid());
      if (String.instancehelper_startsWith(this.chatfield.getText(), mode.normalizedPrefix()))
        this.chatfield.setText(new StringBuilder().append(this.mode.normalizedPrefix()).append(String.instancehelper_substring(this.chatfield.getText(), String.instancehelper_length(mode.normalizedPrefix()))).toString());
      else
        this.chatfield.setText(this.mode.normalizedPrefix());
      this.updateCursor();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {4, 122, 134, 104, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024new\u00240()
    {
      if (!Vars.net.active() && this.messages.size > 0)
      {
        this.clearMessages();
        if (this.shown)
          this.hide();
      }
      return Vars.net.active() && Vars.ui.hudfrag.shown;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {17, 127, 67, 166, 107, 127, 7, 127, 0, 110, 134, 122, 110, 134, 113, 134, 159, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241()
    {
      if (Vars.net.active() && Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Echat) && (object.ReferenceEquals((object) Core.scene.getKeyboardFocus(), (object) this.chatfield) || Core.scene.getKeyboardFocus() == null || Vars.ui.minimapfrag.shown()) && !Vars.ui.scriptfrag.shown())
        this.toggle();
      if (!this.shown)
        return;
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
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Echat_mode))
        this.nextMode();
      this.scrollPos = ByteCodeHelper.f2i(Mathf.clamp((float) this.scrollPos + Core.input.axis((KeyBinds.KeyBind) Binding.__\u003C\u003Echat_scroll), 0.0f, (float) Math.max(0, this.messages.size - 10)));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 82, 108, 102, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024toggle\u00242([In] string obj0)
    {
      this.chatfield.setText(obj0);
      this.sendMessage();
      this.hide();
      Core.input.setOnscreenKeyboardVisible(false);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 95, 108, 103, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024toggle\u00243()
    {
      Core.scene.setKeyboardFocus((Element) null);
      this.shown = false;
      this.scrollPos = 0;
      this.sendMessage();
    }

    [LineNumberTable(new byte[] {76, 120, 159, 5, 139, 104, 191, 41, 134, 135, 113, 145, 107, 147, 127, 0, 159, 33, 127, 52, 119, 156, 112, 159, 74, 127, 16, 126, 159, 18, 177, 127, 34, 107, 147, 240, 44, 235, 87, 133, 117, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      float alpha = (float) Core.settings.getInt("chatopacity") / 100f;
      float num1 = Math.min((float) Core.graphics.getWidth() / 1.5f, Scl.scl(700f));
      Draw.color(this.shadowColor);
      if (this.shown)
        Fill.crect(this.offsetx, this.chatfield.y + Core.scene.marginBottom, this.chatfield.getWidth() + 15f, this.chatfield.getHeight() - 1f);
      base.draw();
      float chatspace = this.chatspace;
      this.chatfield.visible = this.shown;
      this.fieldlabel.visible = this.shown;
      Draw.color(this.shadowColor);
      Draw.alpha(this.shadowColor.a * alpha);
      float num2 = this.offsety + chatspace + this.getMarginBottom() + Core.scene.marginBottom;
      for (int scrollPos = this.scrollPos; scrollPos < this.messages.size && scrollPos < 10 + this.scrollPos && ((double) scrollPos < (double) this.fadetime || this.shown); ++scrollPos)
      {
        GlyphLayout layout = this.layout;
        Font font = this.font;
        string formattedMessage1 = ((ChatFragment.ChatMessage) this.messages.get(scrollPos)).formattedMessage;
        Color white = Color.__\u003C\u003Ewhite;
        double num3 = (double) num1;
        bool flag1 = true;
        int num4 = 12;
        float num5 = (float) num3;
        Color color1 = white;
        object obj1 = (object) formattedMessage1;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj1;
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
        string formattedMessage2 = ((ChatFragment.ChatMessage) this.messages.get(scrollPos)).formattedMessage;
        double num8 = (double) (this.fontoffsetx + this.offsetx);
        double num9 = (double) (this.offsety + num2);
        double num10 = (double) num1;
        bool flag2 = true;
        int num11 = 12;
        float num12 = (float) num10;
        float num13 = (float) num9;
        float num14 = (float) num8;
        object obj2 = (object) formattedMessage2;
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        CharSequence str2 = charSequence;
        double num15 = (double) num14;
        double num16 = (double) num13;
        double num17 = (double) num12;
        int halign2 = num11;
        int num18 = flag2 ? 1 : 0;
        cache.addText(str2, (float) num15, (float) num16, (float) num17, halign2, num18 != 0);
        if (!this.shown && (double) (this.fadetime - (float) scrollPos) < 1.0 && (double) (this.fadetime - (float) scrollPos) >= 0.0)
        {
          this.font.getCache().setAlphas((this.fadetime - (float) scrollPos) * alpha);
          Draw.color(0.0f, 0.0f, 0.0f, this.shadowColor.a * (this.fadetime - (float) scrollPos) * alpha);
        }
        else
          this.font.getCache().setAlphas(alpha);
        Fill.crect(this.offsetx, num2 - this.layout.height - 2f, num1 + Scl.scl(4f), this.layout.height + this.textspacing);
        Draw.color(this.shadowColor);
        Draw.alpha(alpha * this.shadowColor.a);
        this.font.getCache().draw();
      }
      Draw.color();
      if ((double) this.fadetime <= 0.0 || this.shown)
        return;
      this.fadetime -= Time.delta / 180f;
    }

    [HideFromJava]
    static ChatFragment() => Table.__\u003Cclinit\u003E();

    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal new class \u0031 : Fragment
    {
      [Modifiers]
      internal ChatFragment this\u00240;

      [LineNumberTable(40)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] ChatFragment obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 185, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build([In] Group obj0) => Core.scene.add((Element) this.this\u00240);
    }

    [InnerClass]
    internal class ChatMessage : Object
    {
      [Modifiers]
      public string sender;
      [Modifiers]
      public string message;
      [Modifiers]
      public string formattedMessage;

      [LineNumberTable(new byte[] {160, 160, 104, 103, 103, 99, 147, 159, 17})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ChatMessage([In] string obj0, [In] string obj1)
      {
        ChatFragment.ChatMessage chatMessage = this;
        this.message = obj0;
        this.sender = obj1;
        if (obj1 == null)
          this.formattedMessage = obj0 != null ? obj0 : "";
        else
          this.formattedMessage = new StringBuilder().append("[coral][[").append(obj1).append("[coral]]:[white] ").append(obj0).toString();
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/ui/fragments/ChatFragment$ChatMode;>;")]
    [Modifiers]
    [Serializable]
    internal sealed class ChatMode : Enum
    {
      [Modifiers]
      public static ChatFragment.ChatMode normal;
      [Modifiers]
      public static ChatFragment.ChatMode team;
      [Modifiers]
      public static ChatFragment.ChatMode admin;
      public string prefix;
      public Boolp valid;
      [Modifiers]
      public static ChatFragment.ChatMode[] all;
      [Modifiers]
      private static ChatFragment.ChatMode[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(310)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string normalizedPrefix() => String.instancehelper_isEmpty(this.prefix) ? "" : new StringBuilder().append(this.prefix).append(" ").toString();

      [LineNumberTable(306)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual ChatFragment.ChatMode next()
      {
        ChatFragment.ChatMode[] all = ChatFragment.ChatMode.all;
        int num = this.ordinal() + 1;
        int length = ChatFragment.ChatMode.all.Length;
        int index = length != -1 ? num % length : 0;
        return all[index];
      }

      [LineNumberTable(314)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isValid() => this.valid.get();

      [Signature("(Ljava/lang/String;)V")]
      [LineNumberTable(new byte[] {160, 181, 106, 103, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ChatMode([In] string obj0, [In] int obj1, [In] string obj2)
        : base(obj0, obj1)
      {
        ChatFragment.ChatMode chatMode = this;
        this.prefix = obj2;
        this.valid = (Boolp) new ChatFragment.ChatMode.__\u003C\u003EAnon0();
        GC.KeepAlive((object) this);
      }

      [Signature("(Ljava/lang/String;Larc/func/Boolp;)V")]
      [LineNumberTable(new byte[] {160, 186, 106, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ChatMode([In] string obj0, [In] int obj1, [In] string obj2, [In] Boolp obj3)
        : base(obj0, obj1)
      {
        ChatFragment.ChatMode chatMode = this;
        this.prefix = obj2;
        this.valid = obj3;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(285)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static ChatFragment.ChatMode[] values() => (ChatFragment.ChatMode[]) ChatFragment.ChatMode.\u0024VALUES.Clone();

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024new\u00240() => true;

      [LineNumberTable(285)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static ChatFragment.ChatMode valueOf([In] string obj0) => (ChatFragment.ChatMode) Enum.valueOf((Class) ClassLiteral<ChatFragment.ChatMode>.Value, obj0);

      [LineNumberTable(new byte[] {159, 71, 141, 117, 117, 255, 12, 61, 255, 4, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ChatMode()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.ui.fragments.ChatFragment$ChatMode"))
          return;
        ChatFragment.ChatMode.normal = new ChatFragment.ChatMode(nameof (normal), 0, "");
        ChatFragment.ChatMode.team = new ChatFragment.ChatMode(nameof (team), 1, "/t");
        Player player = Vars.player;
        Objects.requireNonNull((object) player);
        ChatFragment.ChatMode.admin = new ChatFragment.ChatMode(nameof (admin), 2, "/a", (Boolp) new ChatFragment.ChatMode.__\u003C\u003EAnon1(player));
        ChatFragment.ChatMode.\u0024VALUES = new ChatFragment.ChatMode[3]
        {
          ChatFragment.ChatMode.normal,
          ChatFragment.ChatMode.team,
          ChatFragment.ChatMode.admin
        };
        ChatFragment.ChatMode.all = ChatFragment.ChatMode.values();
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Boolp
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public bool get() => (ChatFragment.ChatMode.lambda\u0024new\u00240() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : Boolp
      {
        private readonly Player arg\u00241;

        internal __\u003C\u003EAnon1([In] Player obj0) => this.arg\u00241 = obj0;

        public bool get() => (this.arg\u00241.admin() ? 1 : 0) != 0;
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolp
    {
      private readonly ChatFragment arg\u00241;

      internal __\u003C\u003EAnon0([In] ChatFragment obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024new\u00240() ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly ChatFragment arg\u00241;

      internal __\u003C\u003EAnon1([In] ChatFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly ChatFragment arg\u00241;

      internal __\u003C\u003EAnon2([In] ChatFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024toggle\u00242((string) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly ChatFragment arg\u00241;

      internal __\u003C\u003EAnon3([In] ChatFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly ChatFragment arg\u00241;

      internal __\u003C\u003EAnon4([In] ChatFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024toggle\u00243();
    }
  }
}
