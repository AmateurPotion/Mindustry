// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.AboutDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class AboutDialog : BaseDialog
  {
    [Signature("Larc/struct/Seq<Ljava/lang/String;>;")]
    internal Seq contributors;
    [Signature("Larc/struct/ObjectSet<Ljava/lang/String;>;")]
    internal static ObjectSet bannedItems;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 164, 237, 60, 235, 70, 241, 69, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AboutDialog()
      : base("@about.button")
    {
      AboutDialog aboutDialog = this;
      this.contributors = new Seq();
      this.shown((Runnable) new AboutDialog.__\u003C\u003EAnon0(this));
      this.shown((Runnable) new AboutDialog.__\u003C\u003EAnon1(this));
      this.onResize((Runnable) new AboutDialog.__\u003C\u003EAnon1(this));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 167, 127, 15, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240()
    {
      this.contributors = Seq.with((object[]) String.instancehelper_split(Core.files.@internal("contributors").readString("UTF-8"), "\n"));
      Core.app.post((Runnable) new AboutDialog.__\u003C\u003EAnon1(this));
    }

    [LineNumberTable(new byte[] {159, 176, 107, 139, 121, 153, 102, 135, 127, 0, 127, 9, 165, 113, 109, 212, 134, 188, 134, 217, 134, 255, 2, 71, 134, 254, 31, 235, 100, 145, 146, 134, 159, 12, 108, 127, 10, 109, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setup()
    {
      this.__\u003C\u003Econt.clear();
      this.__\u003C\u003Ebuttons.clear();
      float height = !Core.graphics.isPortrait() ? 80f : 90f;
      float width = !Core.graphics.isPortrait() ? 600f : 330f;
      Table table1 = new Table();
      ScrollPane scrollPane = new ScrollPane((Element) table1);
      Links.LinkEntry[] links = Links.getLinks();
      int length = links.Length;
      for (int index = 0; index < length; ++index)
      {
        Links.LinkEntry linkEntry = links[index];
        if (!Vars.ios && !OS.isMac && !Vars.steam || !AboutDialog.bannedItems.contains((object) linkEntry.__\u003C\u003Ename))
        {
          Table.__\u003Cclinit\u003E();
          Table table2 = new Table((Drawable) Tex.underline);
          table2.margin(0.0f);
          table2.table((Cons) new AboutDialog.__\u003C\u003EAnon2(height, linkEntry)).expandY();
          table2.table((Cons) new AboutDialog.__\u003C\u003EAnon3(linkEntry)).size(height - 5f, height);
          table2.table((Cons) new AboutDialog.__\u003C\u003EAnon4(linkEntry, width)).padLeft(8f);
          table2.button((Drawable) Icon.link, (Runnable) new AboutDialog.__\u003C\u003EAnon5(linkEntry)).size(height - 5f, height);
          table1.add((Element) table2).size(width, height).padTop(5f).row();
        }
      }
      this.shown((Runnable) new AboutDialog.__\u003C\u003EAnon6(scrollPane));
      this.__\u003C\u003Econt.add((Element) scrollPane).growX();
      this.addCloseButton();
      this.__\u003C\u003Ebuttons.button("@credits", (Runnable) new AboutDialog.__\u003C\u003EAnon7(this)).size(200f, 64f);
      if (!Core.graphics.isPortrait())
        return;
      Iterator iterator = this.__\u003C\u003Ebuttons.getCells().iterator();
      while (iterator.hasNext())
        ((Cell) iterator.next()).width(140f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {1, 127, 11, 103, 127, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00241([In] float obj0, [In] Links.LinkEntry obj1, [In] Table obj2)
    {
      obj2.image().height(obj0 - 5f).width(40f).color(obj1.__\u003C\u003Ecolor);
      obj2.row();
      obj2.image().height(5f).width(40f).color(obj1.__\u003C\u003Ecolor.cpy().mul(0.8f, 0.8f, 0.8f, 1f));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {7, 108, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00242([In] Links.LinkEntry obj0, [In] Table obj1)
    {
      obj1.background((Drawable) Tex.buttonEdge3);
      obj1.image(obj0.__\u003C\u003Eicon);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {12, 127, 33, 103, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00243([In] Links.LinkEntry obj0, [In] float obj1, [In] Table obj2)
    {
      Table table = obj2;
      object obj = (object) new StringBuilder().append("[accent]").append(obj0.__\u003C\u003Etitle).toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).growX().left();
      obj2.row();
      obj2.labelWrap(obj0.__\u003C\u003Edescription).width(obj1 - 100f).color(Color.__\u003C\u003ElightGray).growX();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {18, 156, 114, 111, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00244([In] Links.LinkEntry obj0)
    {
      if (String.instancehelper_equals(obj0.__\u003C\u003Ename, (object) "wiki"))
        Events.fire((object) EventType.Trigger.__\u003C\u003EopenWiki);
      if (Core.app.openURI(obj0.__\u003C\u003Elink))
        return;
      Vars.ui.showErrorMessage("@linkfail");
      Core.app.setClipboardText(obj0.__\u003C\u003Elink);
    }

    [Modifiers]
    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00246([In] ScrollPane obj0) => Time.run(1f, (Runnable) new AboutDialog.__\u003C\u003EAnon8(obj0));

    [LineNumberTable(new byte[] {46, 107, 102, 127, 27, 108, 112, 127, 16, 108, 127, 2, 108, 242, 75, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showCredits()
    {
      BaseDialog baseDialog = new BaseDialog("@credits");
      baseDialog.addCloseButton();
      Table cont1 = baseDialog.__\u003C\u003Econt;
      object obj1 = (object) "@credits.text";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj1;
      CharSequence text1 = charSequence;
      ((Label) cont1.add(text1).fillX().wrap().get()).setAlignment(1);
      baseDialog.__\u003C\u003Econt.row();
      if (!this.contributors.isEmpty())
      {
        baseDialog.__\u003C\u003Econt.image().color(Pal.accent).fillX().height(3f).pad(3f);
        baseDialog.__\u003C\u003Econt.row();
        Table cont2 = baseDialog.__\u003C\u003Econt;
        object obj2 = (object) "@contributors";
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        CharSequence text2 = charSequence;
        cont2.add(text2);
        baseDialog.__\u003C\u003Econt.row();
        baseDialog.__\u003C\u003Econt.pane((Element) new AboutDialog.\u0031(this));
      }
      baseDialog.show();
    }

    [Modifiers]
    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00245([In] ScrollPane obj0) => Core.scene.setScrollFocus((Element) obj0);

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static AboutDialog()
    {
      BaseDialog.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("mindustry.ui.dialogs.AboutDialog"))
        return;
      AboutDialog.bannedItems = ObjectSet.with((object[]) new string[4]
      {
        "google-play",
        "itch.io",
        "dev-builds",
        "f-droid"
      });
    }

    [EnclosingMethod(null, "showCredits", "()V")]
    [SpecialName]
    internal new class \u0031 : Table
    {
      [Modifiers]
      internal AboutDialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {55, 111, 98, 103, 127, 9, 127, 55, 114, 135, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] AboutDialog obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        AboutDialog.\u0031 obj1 = this;
        int num1 = 0;
        this.left();
        Iterator iterator = this.this\u00240.contributors.iterator();
        while (iterator.hasNext())
        {
          string str = (string) iterator.next();
          object obj2 = (object) new StringBuilder().append("[lightgray]").append(str).toString();
          CharSequence text;
          text.__\u003Cref\u003E = (__Null) obj2;
          this.add(text).left().pad(3f).padLeft(6f).padRight(6f);
          ++num1;
          int num2 = num1;
          int num3 = 3;
          if ((num3 != -1 ? num2 % num3 : 0) == 0)
            this.row();
        }
      }

      [HideFromJava]
      static \u0031() => Table.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly AboutDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] AboutDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly AboutDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] AboutDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly float arg\u00241;
      private readonly Links.LinkEntry arg\u00242;

      internal __\u003C\u003EAnon2([In] float obj0, [In] Links.LinkEntry obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => AboutDialog.lambda\u0024setup\u00241(this.arg\u00241, this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly Links.LinkEntry arg\u00241;

      internal __\u003C\u003EAnon3([In] Links.LinkEntry obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => AboutDialog.lambda\u0024setup\u00242(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly Links.LinkEntry arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon4([In] Links.LinkEntry obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => AboutDialog.lambda\u0024setup\u00243(this.arg\u00241, this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly Links.LinkEntry arg\u00241;

      internal __\u003C\u003EAnon5([In] Links.LinkEntry obj0) => this.arg\u00241 = obj0;

      public void run() => AboutDialog.lambda\u0024setup\u00244(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly ScrollPane arg\u00241;

      internal __\u003C\u003EAnon6([In] ScrollPane obj0) => this.arg\u00241 = obj0;

      public void run() => AboutDialog.lambda\u0024setup\u00246(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly AboutDialog arg\u00241;

      internal __\u003C\u003EAnon7([In] AboutDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.showCredits();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly ScrollPane arg\u00241;

      internal __\u003C\u003EAnon8([In] ScrollPane obj0) => this.arg\u00241 = obj0;

      public void run() => AboutDialog.lambda\u0024setup\u00245(this.arg\u00241);
    }
  }
}
