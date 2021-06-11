// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.logic.MessageBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math.geom;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util.io;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using mindustry.ui;
using mindustry.ui.dialogs;
using mindustry.world.meta;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.logic
{
  public class MessageBlock : Block
  {
    public int maxTextLength;
    public int maxNewlines;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 177, 110, 161, 113, 140, 104, 98, 107, 104, 101, 109, 176, 237, 57, 230, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] MessageBlock.MessageBuild obj0, [In] string obj1)
    {
      if (String.instancehelper_length(obj1) > this.maxTextLength)
        return;
      obj0.message.ensureCapacity(String.instancehelper_length(obj1));
      obj0.message.setLength(0);
      obj1 = String.instancehelper_trim(obj1);
      int num1 = 0;
      for (int index = 0; index < String.instancehelper_length(obj1); ++index)
      {
        int num2 = (int) String.instancehelper_charAt(obj1, index);
        if (num2 == 10)
        {
          int num3 = num1;
          ++num1;
          int maxNewlines = this.maxNewlines;
          if (num3 <= maxNewlines)
            obj0.message.append('\n');
        }
        else
          obj0.message.append((char) num2);
      }
    }

    [LineNumberTable(new byte[] {159, 169, 233, 60, 107, 200, 103, 103, 103, 107, 135, 246, 85})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MessageBlock(string name)
      : base(name)
    {
      MessageBlock messageBlock = this;
      this.maxTextLength = 220;
      this.maxNewlines = 24;
      this.configurable = true;
      this.solid = true;
      this.destructible = true;
      this.group = BlockGroup.__\u003C\u003Elogic;
      this.drawDisabled = false;
      this.config((Class) ClassLiteral<String>.Value, (Cons2) new MessageBlock.__\u003C\u003EAnon0(this));
    }

    [HideFromJava]
    static MessageBlock() => Block.__\u003Cclinit\u003E();

    public class MessageBuild : Building
    {
      public StringBuilder message;
      [Modifiers]
      internal MessageBlock this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(143)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string config() => this.message.toString();

      [Modifiers]
      [LineNumberTable(new byte[] {40, 103, 245, 71, 107, 103, 127, 77, 242, 76, 114, 191, 9, 102, 243, 69, 135, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024buildConfiguration\u00243()
      {
        if (Vars.mobile)
        {
          Core.input.getTextInput((Input.TextInput) new MessageBlock.MessageBuild.\u0031(this));
        }
        else
        {
          BaseDialog baseDialog = new BaseDialog("@editmessage");
          baseDialog.setFillParent(false);
          Table cont = baseDialog.__\u003C\u003Econt;
          TextArea.__\u003Cclinit\u003E();
          string str = this.message.toString();
          object obj1 = (object) "\n";
          object obj2 = (object) "\r";
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj2;
          CharSequence charSequence2 = charSequence1;
          object obj3 = obj1;
          charSequence1.__\u003Cref\u003E = (__Null) obj3;
          CharSequence charSequence3 = charSequence1;
          TextArea textArea1 = new TextArea(String.instancehelper_replace(str, charSequence2, charSequence3));
          TextArea textArea2 = (TextArea) cont.add((Element) textArea1).size(380f, 160f).get();
          textArea2.setFilter((TextField.TextFieldFilter) new MessageBlock.MessageBuild.__\u003C\u003EAnon2(this));
          textArea2.setMaxLength(this.this\u00240.maxTextLength);
          baseDialog.__\u003C\u003Ebuttons.button("@ok", (Runnable) new MessageBlock.MessageBuild.__\u003C\u003EAnon3(this, textArea2, baseDialog)).size(130f, 60f);
          baseDialog.update((Runnable) new MessageBlock.MessageBuild.__\u003C\u003EAnon4(this, baseDialog));
          baseDialog.show();
        }
        this.deselect();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {159, 117, 130, 101, 98, 112, 112, 4, 230, 69, 143})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024buildConfiguration\u00240([In] TextField obj0, [In] char obj1)
      {
        if (obj1 != '\n')
          return true;
        int num = 0;
        for (int index = 0; index < String.instancehelper_length(obj0.getText()); ++index)
        {
          if (String.instancehelper_charAt(obj0.getText(), index) == '\n')
            ++num;
        }
        return num < this.this\u00240.maxNewlines;
      }

      [Modifiers]
      [LineNumberTable(new byte[] {65, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024buildConfiguration\u00241([In] TextArea obj0, [In] BaseDialog obj1)
      {
        this.configure((object) obj0.getText());
        obj1.hide();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {69, 120, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024buildConfiguration\u00242([In] BaseDialog obj0)
      {
        if (object.ReferenceEquals((object) this.tile.block(), (object) this.this\u00240))
          return;
        obj0.hide();
      }

      [LineNumberTable(new byte[] {7, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MessageBuild(MessageBlock _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        MessageBlock.MessageBuild messageBuild = this;
        this.message = new StringBuilder();
      }

      [LineNumberTable(new byte[] {12, 146, 102, 122, 103, 125, 135, 159, 39, 127, 23, 135, 121, 127, 46, 101, 107, 127, 60, 135, 144, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawSelect()
      {
        if (Vars.renderer.__\u003C\u003Epixelator.enabled())
          return;
        Font outline = Fonts.outline;
        GlyphLayout glyphLayout1 = (GlyphLayout) Pools.obtain((Class) ClassLiteral<GlyphLayout>.Value, (Prov) new MessageBlock.MessageBuild.__\u003C\u003EAnon0());
        int num1 = outline.usesIntegerPositions() ? 1 : 0;
        outline.getData().setScale(0.25f / Scl.scl(1f));
        outline.setUseIntegerPositions(false);
        object obj1 = this.message == null || this.message.length() == 0 ? (object) new StringBuilder().append("[lightgray]").append(Core.bundle.get("empty")).toString() : (object) (string) this.message;
        GlyphLayout glyphLayout2 = glyphLayout1;
        Font font1 = outline;
        object obj2 = obj1;
        Color white = Color.__\u003C\u003Ewhite;
        bool flag1 = true;
        int num2 = 8;
        float num3 = 90f;
        Color color1 = white;
        object obj3 = obj2;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj3;
        CharSequence str1 = charSequence;
        Color color2 = color1;
        double num4 = (double) num3;
        int halign1 = num2;
        int num5 = flag1 ? 1 : 0;
        glyphLayout2.setText(font1, str1, color2, (float) num4, halign1, num5 != 0);
        float num6 = 1f;
        Draw.color(0.0f, 0.0f, 0.0f, 0.2f);
        Fill.rect(this.x, this.y - 4f - glyphLayout1.height / 2f - num6, glyphLayout1.width + num6 * 2f, glyphLayout1.height + num6 * 2f);
        Draw.color();
        outline.setColor(Color.__\u003C\u003Ewhite);
        Font font2 = outline;
        object obj4 = obj1;
        double num7 = (double) (this.x - glyphLayout1.width / 2f);
        double num8 = (double) (this.y - 4f - num6);
        bool flag2 = true;
        int num9 = 8;
        float num10 = 90f;
        float num11 = (float) num8;
        float num12 = (float) num7;
        object obj5 = obj4;
        charSequence.__\u003Cref\u003E = (__Null) obj5;
        CharSequence str2 = charSequence;
        double num13 = (double) num12;
        double num14 = (double) num11;
        double num15 = (double) num10;
        int halign2 = num9;
        int num16 = flag2 ? 1 : 0;
        font2.draw(str2, (float) num13, (float) num14, (float) num15, halign2, num16 != 0);
        outline.setUseIntegerPositions(num1 != 0);
        outline.getData().setScale(1f);
        Pools.free((object) glyphLayout1);
      }

      [LineNumberTable(new byte[] {39, 251, 101, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void buildConfiguration(Table table) => table.button((Drawable) Icon.pencil, (Runnable) new MessageBlock.MessageBuild.__\u003C\u003EAnon1(this)).size(40f);

      [LineNumberTable(new byte[] {81, 108, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleString(object value)
      {
        this.message.setLength(0);
        this.message.append(value);
      }

      [LineNumberTable(new byte[] {87, 127, 22, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTableAlign(Table table)
      {
        Vec2 vec2 = Core.input.mouseScreen(this.x, this.y + (float) (this.this\u00240.size * 8) / 2f + 1f);
        table.setPosition(vec2.x, vec2.y, 4);
      }

      [LineNumberTable(new byte[] {98, 103, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.str(this.message.toString());
      }

      [LineNumberTable(new byte[] {159, 104, 131, 104, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.message = new StringBuilder(read.str());
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(57)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object \u003Cbridge\u003Econfig() => (object) this.config();

      [HideFromJava]
      static MessageBuild() => Building.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, "buildConfiguration", "(Larc.scene.ui.layout.Table;)V")]
      [SpecialName]
      internal new class \u0031 : Input.TextInput
      {
        [Modifiers]
        internal MessageBlock.MessageBuild this\u00241;

        [Modifiers]
        [LineNumberTable(95)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void lambda\u0024new\u00240([In] string obj0) => this.this\u00241.configure((object) obj0);

        [LineNumberTable(new byte[] {41, 111, 118, 103, 118, 113})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] MessageBlock.MessageBuild obj0)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          MessageBlock.MessageBuild.\u0031 obj = this;
          this.text = this.this\u00241.message.toString();
          this.multiline = true;
          this.maxLength = this.this\u00241.this\u00240.maxTextLength;
          this.accepted = (Cons) new MessageBlock.MessageBuild.\u0031.__\u003C\u003EAnon0(this);
        }

        [SpecialName]
        private new sealed class __\u003C\u003EAnon0 : Cons
        {
          private readonly MessageBlock.MessageBuild.\u0031 arg\u00241;

          internal __\u003C\u003EAnon0([In] MessageBlock.MessageBuild.\u0031 obj0) => this.arg\u00241 = obj0;

          public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240((string) obj0);
        }
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Prov
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public object get() => (object) new GlyphLayout();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Runnable
      {
        private readonly MessageBlock.MessageBuild arg\u00241;

        internal __\u003C\u003EAnon1([In] MessageBlock.MessageBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024buildConfiguration\u00243();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : TextField.TextFieldFilter
      {
        private readonly MessageBlock.MessageBuild arg\u00241;

        internal __\u003C\u003EAnon2([In] MessageBlock.MessageBuild obj0) => this.arg\u00241 = obj0;

        public bool acceptChar([In] TextField obj0, [In] char obj1) => (this.arg\u00241.lambda\u0024buildConfiguration\u00240(obj0, obj1) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Runnable
      {
        private readonly MessageBlock.MessageBuild arg\u00241;
        private readonly TextArea arg\u00242;
        private readonly BaseDialog arg\u00243;

        internal __\u003C\u003EAnon3(
          [In] MessageBlock.MessageBuild obj0,
          [In] TextArea obj1,
          [In] BaseDialog obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024buildConfiguration\u00241(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Runnable
      {
        private readonly MessageBlock.MessageBuild arg\u00241;
        private readonly BaseDialog arg\u00242;

        internal __\u003C\u003EAnon4([In] MessageBlock.MessageBuild obj0, [In] BaseDialog obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024buildConfiguration\u00242(this.arg\u00242);
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons2
    {
      private readonly MessageBlock arg\u00241;

      internal __\u003C\u003EAnon0([In] MessageBlock obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024new\u00240((MessageBlock.MessageBuild) obj0, (string) obj1);
    }
  }
}
