// Decompiled with JetBrains decompiler
// Type: mindustry.logic.LogicDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.gen;
using mindustry.ui;
using mindustry.ui.dialogs;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.logic
{
  public class LogicDialog : BaseDialog
  {
    public LCanvas canvas;
    [Signature("Larc/func/Cons<Ljava/lang/String;>;")]
    internal Cons consumer;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 162, 237, 61, 240, 69, 134, 107, 135, 134, 123, 159, 12, 255, 6, 90, 134, 255, 12, 86, 134, 156, 135, 156, 145, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LogicDialog()
      : base("logic")
    {
      LogicDialog logicDialog = this;
      this.consumer = (Cons) new LogicDialog.__\u003C\u003EAnon0();
      this.clearChildren();
      this.canvas = new LCanvas();
      this.shouldPause = true;
      this.addCloseListener();
      this.__\u003C\u003Ebuttons.defaults().size(160f, 64f);
      this.__\u003C\u003Ebuttons.button("@back", (Drawable) Icon.left, (Runnable) new LogicDialog.__\u003C\u003EAnon1(this)).name("back");
      this.__\u003C\u003Ebuttons.button("@edit", (Drawable) Icon.edit, (Runnable) new LogicDialog.__\u003C\u003EAnon2(this)).name("edit");
      this.__\u003C\u003Ebuttons.button("@add", (Drawable) Icon.add, (Runnable) new LogicDialog.__\u003C\u003EAnon3(this)).disabled((Boolf) new LogicDialog.__\u003C\u003EAnon4(this));
      this.add((Element) this.canvas).grow().name(nameof (canvas));
      this.row();
      this.add((Element) this.__\u003C\u003Ebuttons).growX().name(nameof (canvas));
      this.hidden((Runnable) new LogicDialog.__\u003C\u003EAnon5(this));
      this.onResize((Runnable) new LogicDialog.__\u003C\u003EAnon6(this));
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] string obj0)
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 175, 107, 248, 86, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00246()
    {
      BaseDialog baseDialog = new BaseDialog("@editor.export");
      baseDialog.__\u003C\u003Econt.pane((Cons) new LogicDialog.__\u003C\u003EAnon11(this, baseDialog));
      baseDialog.addCloseButton();
      baseDialog.show();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {11, 107, 248, 82, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002410()
    {
      BaseDialog baseDialog = new BaseDialog("@add");
      baseDialog.__\u003C\u003Econt.pane((Cons) new LogicDialog.__\u003C\u003EAnon8(this, baseDialog));
      baseDialog.addCloseButton();
      baseDialog.show();
    }

    [Modifiers]
    [LineNumberTable(82)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024new\u002411([In] TextButton obj0) => this.canvas.statements.getChildren().size >= 1000;

    [Modifiers]
    [LineNumberTable(90)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002412() => this.consumer.get((object) this.canvas.save());

    [Modifiers]
    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002413() => this.canvas.rebuild();

    [Modifiers]
    [LineNumberTable(new byte[] {55, 105, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024show\u002414([In] string obj0, [In] Cons obj1, [In] string obj2)
    {
      if (String.instancehelper_equals(obj2, (object) obj0))
        return;
      obj1.get((object) obj2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {13, 108, 98, 127, 3, 108, 146, 108, 109, 140, 191, 6, 118, 121, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00249([In] BaseDialog obj0, [In] Table obj1)
    {
      obj1.background((Drawable) Tex.button);
      int num1 = 0;
      Iterator iterator = LogicIO.allStatements.iterator();
      while (iterator.hasNext())
      {
        Prov prov = (Prov) iterator.next();
        LStatement lstatement = (LStatement) prov.get();
        if (!(lstatement is LStatements.InvalidStatement) && !lstatement.hidden())
        {
          obj1.button(lstatement.name(), new TextButton.TextButtonStyle(Styles.cleart)
          {
            fontColor = lstatement.color(),
            font = Fonts.outline
          }, (Runnable) new LogicDialog.__\u003C\u003EAnon9(this, prov, obj0)).size(140f, 50f).self((Cons) new LogicDialog.__\u003C\u003EAnon10(lstatement));
          ++num1;
          int num2 = num1;
          int num3 = 2;
          if ((num3 != -1 ? num2 % num3 : 0) == 0)
            obj1.row();
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {24, 118, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00247([In] Prov obj0, [In] BaseDialog obj1)
    {
      this.canvas.add((LStatement) obj0.get());
      obj1.hide();
    }

    [Modifiers]
    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00248([In] LStatement obj0, [In] Cell obj1) => LCanvas.tooltip(obj1, new StringBuilder().append("lst.").append(obj0.name()).toString());

    [Modifiers]
    [LineNumberTable(new byte[] {159, 177, 108, 248, 82})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00245([In] BaseDialog obj0, [In] Table obj1)
    {
      obj1.margin(10f);
      obj1.table((Drawable) Tex.button, (Cons) new LogicDialog.__\u003C\u003EAnon12(this, obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 179, 102, 155, 191, 3, 102, 103, 255, 3, 71, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00244([In] BaseDialog obj0, [In] Table obj1)
    {
      TextButton.TextButtonStyle cleart = Styles.cleart;
      obj1.defaults().size(280f, 60f).left();
      obj1.button("@schematic.copy", (Drawable) Icon.copy, cleart, (Runnable) new LogicDialog.__\u003C\u003EAnon13(this, obj0)).marginLeft(12f);
      obj1.row();
      obj1.button("@schematic.copy.import", (Drawable) Icon.download, cleart, (Runnable) new LogicDialog.__\u003C\u003EAnon14(this, obj0)).marginLeft(12f).disabled((Boolf) new LogicDialog.__\u003C\u003EAnon15());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 183, 102, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241([In] BaseDialog obj0)
    {
      obj0.hide();
      Core.app.setClipboardText(this.canvas.save());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 188, 134, 191, 57, 2, 98, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242([In] BaseDialog obj0)
    {
      obj0.hide();
      Exception exception;
      try
      {
        LCanvas canvas = this.canvas;
        string clipboardText = Core.app.getClipboardText();
        object obj1 = (object) "\n";
        object obj2 = (object) "\r\n";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence2 = charSequence1;
        object obj3 = obj1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence3 = charSequence1;
        string asm = String.instancehelper_replace(clipboardText, charSequence2, charSequence3);
        canvas.load(asm);
        return;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception t = exception;
      Vars.ui.showException(t);
    }

    [Modifiers]
    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00243([In] TextButton obj0) => Core.app.getClipboardText() == null;

    [Signature("(Ljava/lang/String;Larc/func/Cons<Ljava/lang/String;>;)V")]
    [LineNumberTable(new byte[] {46, 112, 139, 222, 226, 61, 97, 102, 144, 242, 70, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show(string code, Cons modified)
    {
      this.canvas.statements.clearChildren();
      this.canvas.rebuild();
      Exception th;
      try
      {
        this.canvas.load(code);
        goto label_4;
      }
      catch (Exception ex)
      {
        th = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Log.err(th);
      this.canvas.load("");
label_4:
      this.consumer = (Cons) new LogicDialog.__\u003C\u003EAnon7(code, modified);
      this.show();
    }

    [HideFromJava]
    static LogicDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => LogicDialog.lambda\u0024new\u00240((string) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly LogicDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] LogicDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly LogicDialog arg\u00241;

      internal __\u003C\u003EAnon2([In] LogicDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00246();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly LogicDialog arg\u00241;

      internal __\u003C\u003EAnon3([In] LogicDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002410();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Boolf
    {
      private readonly LogicDialog arg\u00241;

      internal __\u003C\u003EAnon4([In] LogicDialog obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024new\u002411((TextButton) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly LogicDialog arg\u00241;

      internal __\u003C\u003EAnon5([In] LogicDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002412();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly LogicDialog arg\u00241;

      internal __\u003C\u003EAnon6([In] LogicDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u002413();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly string arg\u00241;
      private readonly Cons arg\u00242;

      internal __\u003C\u003EAnon7([In] string obj0, [In] Cons obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => LogicDialog.lambda\u0024show\u002414(this.arg\u00241, this.arg\u00242, (string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      private readonly LogicDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon8([In] LogicDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00249(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly LogicDialog arg\u00241;
      private readonly Prov arg\u00242;
      private readonly BaseDialog arg\u00243;

      internal __\u003C\u003EAnon9([In] LogicDialog obj0, [In] Prov obj1, [In] BaseDialog obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00247(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      private readonly LStatement arg\u00241;

      internal __\u003C\u003EAnon10([In] LStatement obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => LogicDialog.lambda\u0024new\u00248(this.arg\u00241, (Cell) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Cons
    {
      private readonly LogicDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon11([In] LogicDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00245(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Cons
    {
      private readonly LogicDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon12([In] LogicDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00244(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly LogicDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon13([In] LogicDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00241(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      private readonly LogicDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon14([In] LogicDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00242(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Boolf
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public bool get([In] object obj0) => (LogicDialog.lambda\u0024new\u00243((TextButton) obj0) ? 1 : 0) != 0;
    }
  }
}
