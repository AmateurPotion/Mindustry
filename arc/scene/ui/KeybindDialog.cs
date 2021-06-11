// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.KeybindDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.input;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui.layout;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui
{
  public class KeybindDialog : Dialog
  {
    protected internal KeybindDialog.KeybindDialogStyle style;
    protected internal KeyBinds.Section section;
    protected internal KeyBinds.KeyBind rebindKey;
    protected internal bool rebindAxis;
    protected internal bool rebindMin;
    protected internal KeyCode minKey;
    protected internal Dialog rebindDialog;
    [Signature("Larc/struct/ObjectIntMap<Larc/KeyBinds$Section;>;")]
    protected internal ObjectIntMap sectionControls;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 182, 139, 139, 102, 102, 103, 103, 137, 123, 111, 159, 5, 127, 0, 110, 188, 136, 127, 45, 111, 135, 149, 104, 179, 135, 158, 136, 140, 135, 255, 5, 71, 154, 158, 159, 33, 255, 5, 72, 159, 4, 144, 104, 114, 104, 120, 181, 136, 131, 127, 5, 127, 0, 127, 99, 127, 42, 169, 144, 125, 159, 99, 105, 159, 52, 103, 104, 127, 67, 191, 4, 223, 16, 139, 127, 73, 122, 127, 33, 154, 223, 16, 134, 191, 16, 102, 232, 22, 235, 109, 149, 191, 8, 149, 232, 159, 137, 235, 160, 122, 140, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setup()
    {
      this.__\u003C\u003Econt.clear();
      KeyBinds.Section[] sections = Core.keybinds.getSections();
      Stack stack = new Stack();
      ButtonGroup buttonGroup = new ButtonGroup();
      ScrollPane scrollPane = new ScrollPane((Element) stack);
      scrollPane.setFadeScrollBars(false);
      this.section = sections[0];
      KeyBinds.Section[] sectionArray = sections;
      int length1 = sectionArray.Length;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        KeyBinds.Section section = sectionArray[index1];
        if (!this.sectionControls.containsKey((object) section))
          this.sectionControls.put((object) section, Core.input.getDevices().indexOf((object) section.device, true));
        if (this.sectionControls.get((object) section, 0) >= Core.input.getDevices().size)
        {
          this.sectionControls.put((object) section, 0);
          section.device = (InputDevice) Core.input.getDevices().get(0);
        }
        if (sections.Length != 1)
        {
          TextButton.__\u003Cclinit\u003E();
          TextButton textButton = new TextButton(Core.bundle.get(new StringBuilder().append("section.").append(section.__\u003C\u003Ename).append(".name").toString(), Strings.capitalize(section.__\u003C\u003Ename)));
          if (Object.instancehelper_equals((object) section, (object) this.section))
            textButton.toggle();
          textButton.clicked((Runnable) new KeybindDialog.__\u003C\u003EAnon0(this, section));
          buttonGroup.add((Button) textButton);
          this.__\u003C\u003Econt.add((Element) textButton).fill();
        }
        Table table1 = new Table();
        object obj1 = (object) "Keyboard";
        CharSequence text1;
        text1.__\u003Cref\u003E = (__Null) obj1;
        Label label1 = new Label(text1);
        label1.setAlignment(1);
        Seq devices = Core.input.getDevices();
        Table table2 = new Table();
        table2.button("<", (Runnable) new KeybindDialog.__\u003C\u003EAnon1(this, section, devices)).disabled(this.sectionControls.get((object) section, 0) - 1 < 0).size(40f);
        table2.add((Element) label1).minWidth(label1.getMinWidth() + 60f);
        Label label2 = label1;
        object obj2 = (object) ((InputDevice) Core.input.getDevices().get(this.sectionControls.get((object) section, 0))).name();
        text1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence newText = text1;
        label2.setText(newText);
        table2.button(">", (Runnable) new KeybindDialog.__\u003C\u003EAnon2(this, section, devices)).disabled(this.sectionControls.get((object) section, 0) + 1 >= devices.size).size(40f);
        table1.add((Element) table2).colspan(4);
        table1.row();
        table1.add().height(10f);
        table1.row();
        if (object.ReferenceEquals((object) section.device.type(), (object) InputDevice.DeviceType.__\u003C\u003Econtroller))
          table1.table((Cons) new KeybindDialog.__\u003C\u003EAnon3(this, section));
        table1.row();
        string str1 = (string) null;
        KeyBinds.KeyBind[] keybinds = Core.keybinds.getKeybinds();
        int length2 = keybinds.Length;
        for (int index2 = 0; index2 < length2; ++index2)
        {
          KeyBinds.KeyBind def = keybinds[index2];
          if (!object.ReferenceEquals((object) str1, (object) def.category()) && def.category() != null)
          {
            Table table3 = table1;
            object obj3 = (object) Core.bundle.get(new StringBuilder().append("category.").append(def.category()).append(".name").toString(), Strings.capitalize(def.category()));
            text1.__\u003Cref\u003E = (__Null) obj3;
            CharSequence text2 = text1;
            table3.add(text2).color(Color.__\u003C\u003Egray).colspan(4).pad(10f).padBottom(4f).row();
            table1.image().color(Color.__\u003C\u003Egray).fillX().height(3f).pad(6f).colspan(4).padTop(0.0f).padBottom(10f).row();
            str1 = def.category();
          }
          KeyBinds.Axis axis = Core.keybinds.get(section, def);
          if (def.defaultValue(section.device.type()) is KeyBinds.Axis)
          {
            Table table3 = table1;
            string str2 = Core.bundle.get(new StringBuilder().append("keybind.").append(def.name()).append(".name").toString(), Strings.capitalize(def.name()));
            Color keyNameColor = this.style.keyNameColor;
            object obj3 = (object) str2;
            text1.__\u003Cref\u003E = (__Null) obj3;
            CharSequence text2 = text1;
            Color color1 = keyNameColor;
            table3.add(text2, color1).left().padRight(40f).padLeft(8f);
            if (axis.key != null)
            {
              Table table4 = table1;
              string str3 = axis.key.toString();
              Color keyColor = this.style.keyColor;
              object obj4 = (object) str3;
              text1.__\u003Cref\u003E = (__Null) obj4;
              CharSequence text3 = text1;
              Color color2 = keyColor;
              table4.add(text3, color2).left().minWidth(90f).padRight(20f);
            }
            else
            {
              Table table4 = new Table();
              table4.left();
              table4.labelWrap(new StringBuilder().append(axis.min.toString()).append(" [red]/[] ").append(axis.max.toString()).toString()).color(this.style.keyColor).width(140f).padRight(5f);
              table1.add((Element) table4).left().minWidth(90f).padRight(20f);
            }
            table1.button(Core.bundle.get("settings.rebind", "Rebind"), (Runnable) new KeybindDialog.__\u003C\u003EAnon4(this, section, def)).width(130f);
          }
          else
          {
            Table table3 = table1;
            string str2 = Core.bundle.get(new StringBuilder().append("keybind.").append(def.name()).append(".name").toString(), Strings.capitalize(def.name()));
            Color keyNameColor = this.style.keyNameColor;
            object obj3 = (object) str2;
            text1.__\u003Cref\u003E = (__Null) obj3;
            CharSequence text2 = text1;
            Color color1 = keyNameColor;
            table3.add(text2, color1).left().padRight(40f).padLeft(8f);
            Table table4 = table1;
            string str3 = Core.keybinds.get(section, def).key.toString();
            Color keyColor = this.style.keyColor;
            object obj4 = (object) str3;
            text1.__\u003Cref\u003E = (__Null) obj4;
            CharSequence text3 = text1;
            Color color2 = keyColor;
            table4.add(text3, color2).left().minWidth(90f).padRight(20f);
            table1.button(Core.bundle.get("settings.rebind", "Rebind"), (Runnable) new KeybindDialog.__\u003C\u003EAnon5(this, section, def)).width(130f);
          }
          table1.button(Core.bundle.get("settings.resetKey", "Reset"), (Runnable) new KeybindDialog.__\u003C\u003EAnon6(this, section, def)).width(130f);
          table1.row();
        }
        table1.visible((Boolp) new KeybindDialog.__\u003C\u003EAnon7(this, section));
        table1.button(Core.bundle.get("settings.reset", "Reset to Defaults"), (Runnable) new KeybindDialog.__\u003C\u003EAnon8(this)).colspan(4).padTop(4f).fill();
        stack.add((Element) table1);
      }
      this.__\u003C\u003Econt.row();
      this.__\u003C\u003Econt.add((Element) scrollPane).growX().colspan(sections.Length);
    }

    [LineNumberTable(new byte[] {160, 89, 159, 35, 135, 159, 6, 119, 150, 244, 90, 108, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void openDialog([In] KeyBinds.Section obj0, [In] KeyBinds.KeyBind obj1)
    {
      Dialog.__\u003Cclinit\u003E();
      this.rebindDialog = new Dialog(!this.rebindAxis ? Core.bundle.get("keybind.press", "Press a key...") : Core.bundle.get("keybind.press.axis", "Press an axis or key..."));
      this.rebindKey = obj1;
      ((Cell) this.rebindDialog.__\u003C\u003EtitleTable.getCells().first()).pad(4f);
      if (object.ReferenceEquals((object) obj0.device.type(), (object) InputDevice.DeviceType.__\u003C\u003Ekeyboard))
      {
        this.rebindDialog.keyDown((Cons) new KeybindDialog.__\u003C\u003EAnon10(this));
        this.rebindDialog.addListener((EventListener) new KeybindDialog.\u0031(this, obj0, obj1));
      }
      this.rebindDialog.show();
      Time.runTask(1f, (Runnable) new KeybindDialog.__\u003C\u003EAnon11(this));
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00240([In] KeyBinds.Section obj0) => this.section = obj0;

    [Modifiers]
    [LineNumberTable(new byte[] {32, 110, 102, 111, 116, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00241([In] KeyBinds.Section obj0, [In] Seq obj1)
    {
      int num = this.sectionControls.get((object) obj0, 0);
      if (num - 1 < 0)
        return;
      this.sectionControls.put((object) obj0, num - 1);
      obj0.device = (InputDevice) obj1.get(num - 1);
      this.setup();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {45, 142, 107, 111, 116, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00242([In] KeyBinds.Section obj0, [In] Seq obj1)
    {
      int num = this.sectionControls.get((object) obj0, 0);
      if (num + 1 >= obj1.size)
        return;
      this.sectionControls.put((object) obj0, num + 1);
      obj0.device = (InputDevice) obj1.get(num + 1);
      this.setup();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {60, 127, 27, 52, 117, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00243([In] KeyBinds.Section obj0, [In] Table obj1)
    {
      Table table = obj1;
      object obj = (object) new StringBuilder().append("Controller Type: [#").append(String.instancehelper_toUpperCase(this.style.controllerColor.toString())).append("]").append(Strings.capitalize(obj0.device.name())).toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).left();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {89, 103, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00244([In] KeyBinds.Section obj0, [In] KeyBinds.KeyBind obj1)
    {
      this.rebindAxis = true;
      this.rebindMin = true;
      this.openDialog(obj0, obj1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {100, 103, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00245([In] KeyBinds.Section obj0, [In] KeyBinds.KeyBind obj1)
    {
      this.rebindAxis = false;
      this.rebindMin = false;
      this.openDialog(obj0, obj1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {106, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00246([In] KeyBinds.Section obj0, [In] KeyBinds.KeyBind obj1)
    {
      Core.keybinds.resetToDefault(obj0, obj1);
      this.setup();
    }

    [Modifiers]
    [LineNumberTable(162)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setup\u00247([In] KeyBinds.Section obj0) => Object.instancehelper_equals((object) this.section, (object) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {115, 106, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00248()
    {
      Core.keybinds.resetToDefaults();
      this.setup();
    }

    [Modifiers]
    [LineNumberTable(210)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024openDialog\u00249([In] KeyCode obj0) => this.setup();

    [Modifiers]
    [LineNumberTable(239)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024openDialog\u002410() => this.getScene().setScrollFocus((Element) this.rebindDialog);

    [LineNumberTable(new byte[] {159, 170, 252, 56, 103, 103, 103, 135, 203, 122, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public KeybindDialog()
      : base(Core.bundle.get("keybind.title", "Rebind Keys"))
    {
      KeybindDialog keybindDialog = this;
      this.rebindKey = (KeyBinds.KeyBind) null;
      this.rebindAxis = false;
      this.rebindMin = true;
      this.minKey = (KeyCode) null;
      this.sectionControls = new ObjectIntMap();
      this.style = (KeybindDialog.KeybindDialogStyle) Core.scene.getStyle((Class) ClassLiteral<KeybindDialog.KeybindDialogStyle>.Value);
      this.setup();
      this.addCloseButton();
    }

    [LineNumberTable(new byte[] {159, 177, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStyle(KeybindDialog.KeybindDialogStyle style)
    {
      this.style = style;
      this.setup();
    }

    [LineNumberTable(new byte[] {160, 65, 105, 107, 154, 99, 115, 191, 48, 191, 24, 123, 103, 103, 143, 103, 103, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void rebind([In] KeyBinds.Section obj0, [In] KeyBinds.KeyBind obj1, [In] KeyCode obj2)
    {
      if (this.rebindKey == null)
        return;
      this.rebindDialog.hide();
      int num = obj1.defaultValue(obj0.device.type()) is KeyBinds.Axis ? 1 : 0;
      if (num != 0)
      {
        if (obj2.__\u003C\u003Eaxis || !this.rebindMin)
          ((OrderedMap) obj0.binds.get((object) obj0.device.type(), (Prov) new KeybindDialog.__\u003C\u003EAnon9())).put((object) this.rebindKey, !obj2.__\u003C\u003Eaxis ? (object) new KeyBinds.Axis(this.minKey, obj2) : (object) new KeyBinds.Axis(obj2));
      }
      else
        ((OrderedMap) obj0.binds.get((object) obj0.device.type(), (Prov) new KeybindDialog.__\u003C\u003EAnon9())).put((object) this.rebindKey, (object) new KeyBinds.Axis(obj2));
      if (this.rebindAxis && num != 0 && (this.rebindMin && !obj2.__\u003C\u003Eaxis))
      {
        this.rebindMin = false;
        this.minKey = obj2;
        this.openDialog(obj0, this.rebindKey);
      }
      else
      {
        this.rebindKey = (KeyBinds.KeyBind) null;
        this.rebindAxis = false;
        this.setup();
      }
    }

    [HideFromJava]
    static KeybindDialog() => Dialog.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "openDialog", "(Larc.KeyBinds$Section;Larc.KeyBinds$KeyBind;)V")]
    [SpecialName]
    internal new class \u0031 : InputListener
    {
      [Modifiers]
      internal KeyBinds.Section val\u0024section;
      [Modifiers]
      internal KeyBinds.KeyBind val\u0024name;
      [Modifiers]
      internal KeybindDialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(212)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] KeybindDialog obj0, [In] KeyBinds.Section obj1, [In] KeyBinds.KeyBind obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024section = obj1;
        this.val\u0024name = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {160, 101, 110, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool touchDown(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        if (Core.app.isAndroid())
          return false;
        this.this\u00240.rebind(this.val\u0024section, this.val\u0024name, obj4);
        return false;
      }

      [LineNumberTable(new byte[] {160, 108, 112, 111, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool keyDown([In] InputEvent obj0, [In] KeyCode obj1)
      {
        this.this\u00240.rebindDialog.hide();
        if (object.ReferenceEquals((object) obj1, (object) KeyCode.__\u003C\u003Eescape))
          return false;
        this.this\u00240.rebind(this.val\u0024section, this.val\u0024name, obj1);
        return false;
      }

      [LineNumberTable(new byte[] {160, 116, 111, 112, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool scrolled(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] float obj3,
        [In] float obj4)
      {
        if (!this.this\u00240.rebindAxis)
          return false;
        this.this\u00240.rebindDialog.hide();
        this.this\u00240.rebind(this.val\u0024section, this.val\u0024name, KeyCode.__\u003C\u003Escroll);
        return false;
      }

      [HideFromJava]
      static \u0031() => InputListener.__\u003Cclinit\u003E();
    }

    public class KeybindDialogStyle : Style
    {
      public Color keyColor;
      public Color keyNameColor;
      public Color controllerColor;

      [LineNumberTable(new byte[] {160, 128, 104, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public KeybindDialogStyle()
      {
        KeybindDialog.KeybindDialogStyle keybindDialogStyle = this;
        this.keyColor = Color.__\u003C\u003Ewhite;
        this.keyNameColor = Color.__\u003C\u003Ewhite;
        this.controllerColor = Color.__\u003C\u003Ewhite;
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly KeybindDialog arg\u00241;
      private readonly KeyBinds.Section arg\u00242;

      internal __\u003C\u003EAnon0([In] KeybindDialog obj0, [In] KeyBinds.Section obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00240(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly KeybindDialog arg\u00241;
      private readonly KeyBinds.Section arg\u00242;
      private readonly Seq arg\u00243;

      internal __\u003C\u003EAnon1([In] KeybindDialog obj0, [In] KeyBinds.Section obj1, [In] Seq obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00241(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly KeybindDialog arg\u00241;
      private readonly KeyBinds.Section arg\u00242;
      private readonly Seq arg\u00243;

      internal __\u003C\u003EAnon2([In] KeybindDialog obj0, [In] KeyBinds.Section obj1, [In] Seq obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00242(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly KeybindDialog arg\u00241;
      private readonly KeyBinds.Section arg\u00242;

      internal __\u003C\u003EAnon3([In] KeybindDialog obj0, [In] KeyBinds.Section obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u00243(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly KeybindDialog arg\u00241;
      private readonly KeyBinds.Section arg\u00242;
      private readonly KeyBinds.KeyBind arg\u00243;

      internal __\u003C\u003EAnon4(
        [In] KeybindDialog obj0,
        [In] KeyBinds.Section obj1,
        [In] KeyBinds.KeyBind obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00244(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly KeybindDialog arg\u00241;
      private readonly KeyBinds.Section arg\u00242;
      private readonly KeyBinds.KeyBind arg\u00243;

      internal __\u003C\u003EAnon5(
        [In] KeybindDialog obj0,
        [In] KeyBinds.Section obj1,
        [In] KeyBinds.KeyBind obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00245(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly KeybindDialog arg\u00241;
      private readonly KeyBinds.Section arg\u00242;
      private readonly KeyBinds.KeyBind arg\u00243;

      internal __\u003C\u003EAnon6(
        [In] KeybindDialog obj0,
        [In] KeyBinds.Section obj1,
        [In] KeyBinds.KeyBind obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00246(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Boolp
    {
      private readonly KeybindDialog arg\u00241;
      private readonly KeyBinds.Section arg\u00242;

      internal __\u003C\u003EAnon7([In] KeybindDialog obj0, [In] KeyBinds.Section obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get() => (this.arg\u00241.lambda\u0024setup\u00247(this.arg\u00242) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly KeybindDialog arg\u00241;

      internal __\u003C\u003EAnon8([In] KeybindDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setup\u00248();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Prov
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public object get() => (object) new OrderedMap();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      private readonly KeybindDialog arg\u00241;

      internal __\u003C\u003EAnon10([In] KeybindDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024openDialog\u00249((KeyCode) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly KeybindDialog arg\u00241;

      internal __\u003C\u003EAnon11([In] KeybindDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024openDialog\u002410();
    }
  }
}
