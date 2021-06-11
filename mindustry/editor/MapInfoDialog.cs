// Decompiled with JetBrains decompiler
// Type: mindustry.editor.MapInfoDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.scene.ui;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using mindustry.core;
using mindustry.game;
using mindustry.io;
using mindustry.ui;
using mindustry.ui.dialogs;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.editor
{
  public class MapInfoDialog : BaseDialog
  {
    [Modifiers]
    private MapEditor editor;
    [Modifiers]
    private WaveInfoDialog waveInfo;
    [Modifiers]
    private MapGenerateDialog generate;
    [Modifiers]
    private CustomRulesDialog ruleInfo;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 161, 237, 61, 203, 103, 108, 141, 134, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MapInfoDialog(MapEditor editor)
      : base("@editor.mapinfo")
    {
      MapInfoDialog mapInfoDialog = this;
      this.ruleInfo = new CustomRulesDialog();
      this.editor = editor;
      this.waveInfo = new WaveInfoDialog(editor);
      this.generate = new MapGenerateDialog(editor, false);
      this.addCloseButton();
      this.shown((Runnable) new MapInfoDialog.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {159, 172, 139, 140, 248, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setup()
    {
      this.__\u003C\u003Econt.clear();
      this.__\u003C\u003Econt.pane((Cons) new MapInfoDialog.__\u003C\u003EAnon1(this, (ObjectMap) this.editor.tags));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 177, 127, 12, 145, 159, 17, 119, 139, 103, 159, 12, 159, 22, 154, 103, 159, 12, 191, 32, 120, 140, 103, 127, 12, 182, 144, 103, 127, 12, 182, 144, 103, 127, 12, 214, 144, 102, 102, 135, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00248([In] ObjectMap obj0, [In] Table obj1)
    {
      Table table1 = obj1;
      object obj2 = (object) "@editor.mapname";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text1 = charSequence;
      table1.add(text1).padRight(8f).left();
      obj1.defaults().padTop(15f);
      TextField textField1 = (TextField) obj1.field((string) obj0.get((object) "name", (object) ""), (Cons) new MapInfoDialog.__\u003C\u003EAnon2(obj0)).size(400f, 55f).addInputDialog(50).get();
      textField1.setMessageText("@unknown");
      obj1.row();
      Table table2 = obj1;
      object obj3 = (object) "@editor.description";
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence text2 = charSequence;
      table2.add(text2).padRight(8f).left();
      TextArea textArea = (TextArea) obj1.area((string) obj0.get((object) "description", (object) ""), Styles.areaField, (Cons) new MapInfoDialog.__\u003C\u003EAnon3(obj0)).size(400f, 140f).addInputDialog(1000).get();
      obj1.row();
      Table table3 = obj1;
      object obj4 = (object) "@editor.author";
      charSequence.__\u003Cref\u003E = (__Null) obj4;
      CharSequence text3 = charSequence;
      table3.add(text3).padRight(8f).left();
      TextField textField2 = (TextField) obj1.field((string) obj0.get((object) "author", (object) Core.settings.getString("mapAuthor", "")), (Cons) new MapInfoDialog.__\u003C\u003EAnon4(obj0)).size(400f, 55f).addInputDialog(50).get();
      textField2.setMessageText("@unknown");
      obj1.row();
      Table table4 = obj1;
      object obj5 = (object) "@editor.rules";
      charSequence.__\u003Cref\u003E = (__Null) obj5;
      CharSequence text4 = charSequence;
      table4.add(text4).padRight(8f).left();
      obj1.button("@edit", (Runnable) new MapInfoDialog.__\u003C\u003EAnon5(this)).left().width(200f);
      obj1.row();
      Table table5 = obj1;
      object obj6 = (object) "@editor.waves";
      charSequence.__\u003Cref\u003E = (__Null) obj6;
      CharSequence text5 = charSequence;
      table5.add(text5).padRight(8f).left();
      obj1.button("@edit", (Runnable) new MapInfoDialog.__\u003C\u003EAnon6(this)).left().width(200f);
      obj1.row();
      Table table6 = obj1;
      object obj7 = (object) "@editor.generation";
      charSequence.__\u003Cref\u003E = (__Null) obj7;
      CharSequence text6 = charSequence;
      table6.add(text6).padRight(8f).left();
      obj1.button("@edit", (Runnable) new MapInfoDialog.__\u003C\u003EAnon7(this)).left().width(200f);
      textField1.change();
      textArea.change();
      textField2.change();
      obj1.margin(16f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 181, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00240([In] ObjectMap obj0, [In] string obj1) => obj0.put((object) "name", (object) obj1);

    [Modifiers]
    [LineNumberTable(new byte[] {159, 189, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00241([In] ObjectMap obj0, [In] string obj1) => obj0.put((object) "description", (object) obj1);

    [Modifiers]
    [LineNumberTable(new byte[] {4, 109, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00242([In] ObjectMap obj0, [In] string obj1)
    {
      obj0.put((object) "author", (object) obj1);
      Core.settings.put("mapAuthor", (object) obj1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {12, 127, 0, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00244()
    {
      this.ruleInfo.show(Vars.state.rules, (Prov) new MapInfoDialog.__\u003C\u003EAnon9());
      this.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {19, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00245()
    {
      this.waveInfo.show();
      this.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {26, 159, 32, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00247()
    {
      this.generate.show(Vars.maps.readFilters((string) this.editor.tags.get((object) "genfilters", (object) "")), (Cons) new MapInfoDialog.__\u003C\u003EAnon8(this));
      this.hide();
    }

    [Modifiers]
    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00246([In] Seq obj0) => this.editor.tags.put((object) "genfilters", (object) JsonIO.write((object) obj0));

    [Modifiers]
    [LineNumberTable(62)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Rules lambda\u0024setup\u00243()
    {
      GameState state = Vars.state;
      Rules rules1 = new Rules();
      GameState gameState = state;
      Rules rules2 = rules1;
      gameState.rules = rules1;
      return rules2;
    }

    [HideFromJava]
    static MapInfoDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly MapInfoDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] MapInfoDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly MapInfoDialog arg\u00241;
      private readonly ObjectMap arg\u00242;

      internal __\u003C\u003EAnon1([In] MapInfoDialog obj0, [In] ObjectMap obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u00248(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly ObjectMap arg\u00241;

      internal __\u003C\u003EAnon2([In] ObjectMap obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => MapInfoDialog.lambda\u0024setup\u00240(this.arg\u00241, (string) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly ObjectMap arg\u00241;

      internal __\u003C\u003EAnon3([In] ObjectMap obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => MapInfoDialog.lambda\u0024setup\u00241(this.arg\u00241, (string) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly ObjectMap arg\u00241;

      internal __\u003C\u003EAnon4([In] ObjectMap obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => MapInfoDialog.lambda\u0024setup\u00242(this.arg\u00241, (string) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly MapInfoDialog arg\u00241;

      internal __\u003C\u003EAnon5([In] MapInfoDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setup\u00244();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly MapInfoDialog arg\u00241;

      internal __\u003C\u003EAnon6([In] MapInfoDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setup\u00245();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly MapInfoDialog arg\u00241;

      internal __\u003C\u003EAnon7([In] MapInfoDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setup\u00247();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      private readonly MapInfoDialog arg\u00241;

      internal __\u003C\u003EAnon8([In] MapInfoDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u00246((Seq) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Prov
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public object get() => (object) MapInfoDialog.lambda\u0024setup\u00243();
    }
  }
}
