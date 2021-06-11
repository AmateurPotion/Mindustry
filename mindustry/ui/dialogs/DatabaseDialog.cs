// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.DatabaseDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.input;
using arc.math;
using arc.scene;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.ctype;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class DatabaseDialog : BaseDialog
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 165, 141, 103, 102, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DatabaseDialog()
      : base("@database")
    {
      DatabaseDialog databaseDialog = this;
      this.shouldPause = true;
      this.addCloseButton();
      this.shown((Runnable) new DatabaseDialog.__\u003C\u003EAnon0(this));
      this.onResize((Runnable) new DatabaseDialog.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool unlocked([In] UnlockableContent obj0) => !Vars.state.isCampaign() && !Vars.state.isMenu() || obj0.unlocked();

    [LineNumberTable(new byte[] {159, 174, 139, 102, 108, 135, 139, 106, 137, 116, 142, 127, 56, 103, 127, 31, 103, 243, 98, 117, 231, 19, 233, 112, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void rebuild()
    {
      this.__\u003C\u003Econt.clear();
      Table table1 = new Table();
      table1.margin(20f);
      ScrollPane scrollPane = new ScrollPane((Element) table1);
      Seq[] contentMap = Vars.content.getContentMap();
      for (int index = 0; index < contentMap.Length; ++index)
      {
        ContentType contentType = ContentType.__\u003C\u003Eall[index];
        Seq seq = contentMap[index].select((Boolf) new DatabaseDialog.__\u003C\u003EAnon1());
        if (seq.size != 0)
        {
          Table table2 = table1;
          object obj = (object) new StringBuilder().append("@content.").append(contentType.name()).append(".name").toString();
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) obj;
          CharSequence text = charSequence;
          table2.add(text).growX().left().color(Pal.accent);
          table1.row();
          table1.image().growX().pad(5f).padLeft(0.0f).padRight(0.0f).height(3f).color(Pal.accent);
          table1.row();
          table1.table((Cons) new DatabaseDialog.__\u003C\u003EAnon2(this, seq)).growX().left().padBottom(10f);
          table1.row();
        }
      }
      this.__\u003C\u003Econt.add((Element) scrollPane);
    }

    [Modifiers]
    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024rebuild\u00240([In] Content obj0)
    {
      Content content = obj0;
      UnlockableContent unlockableContent;
      return content is UnlockableContent && object.ReferenceEquals((object) (unlockableContent = (UnlockableContent) content), (object) (UnlockableContent) content) && (!unlockableContent.isHidden() || unlockableContent.node() != null);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {1, 135, 121, 130, 110, 141, 127, 23, 125, 103, 106, 112, 109, 182, 105, 243, 72, 189, 114, 231, 39, 233, 92})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuild\u00244([In] Seq obj0, [In] Table obj1)
    {
      obj1.left();
      int num1 = Mathf.clamp((Core.graphics.getWidth() - 30) / 42, 1, 18);
      int num2 = 0;
      for (int index = 0; index < obj0.size; ++index)
      {
        UnlockableContent unlockableContent = (UnlockableContent) obj0.get(index);
        Image image1 = !this.unlocked(unlockableContent) ? new Image((Drawable) Icon.@lock, Pal.gray) : new Image(unlockableContent.icon(Cicon.__\u003C\u003Emedium)).setScaling(Scaling.__\u003C\u003Efit);
        obj1.add((Element) image1).size(32f).pad(3f);
        ClickListener clickListener = new ClickListener();
        image1.addListener((EventListener) clickListener);
        if (!Vars.mobile && this.unlocked(unlockableContent))
        {
          image1.addListener((EventListener) new HandCursorListener());
          image1.update((Runnable) new DatabaseDialog.__\u003C\u003EAnon3(image1, clickListener));
        }
        if (this.unlocked(unlockableContent))
        {
          image1.clicked((Runnable) new DatabaseDialog.__\u003C\u003EAnon4(unlockableContent));
          Image image2 = image1;
          Tooltip.__\u003Cclinit\u003E();
          Tooltip tooltip = new Tooltip((Cons) new DatabaseDialog.__\u003C\u003EAnon5(unlockableContent));
          image2.addListener((EventListener) tooltip);
        }
        ++num2;
        int num3 = num2;
        int num4 = num1;
        if ((num4 != -1 ? num3 % num4 : 0) == 0)
          obj1.row();
      }
    }

    [Modifiers]
    [LineNumberTable(65)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u00241([In] Image obj0, [In] ClickListener obj1) => obj0.__\u003C\u003Ecolor.lerp(obj1.isOver() ? Color.__\u003C\u003Ewhite : Color.__\u003C\u003ElightGray, Mathf.clamp(0.4f * Time.delta));

    [Modifiers]
    [LineNumberTable(new byte[] {20, 126, 127, 16, 145, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u00242([In] UnlockableContent obj0)
    {
      if (Core.input.keyDown(KeyCode.__\u003C\u003EshiftLeft) && Fonts.getUnicode(obj0.__\u003C\u003Ename) != 0)
      {
        Core.app.setClipboardText(new StringBuilder().append((char) Fonts.getUnicode(obj0.__\u003C\u003Ename)).append("").toString());
        Vars.ui.showInfoFade("@copied");
      }
      else
        Vars.ui.content.show(obj0);
    }

    [Modifiers]
    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u00243([In] UnlockableContent obj0, [In] Table obj1)
    {
      Table table = obj1.background((Drawable) Tex.button);
      object localizedName = (object) obj0.localizedName;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) localizedName;
      CharSequence text = charSequence;
      table.add(text);
    }

    [HideFromJava]
    static DatabaseDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly DatabaseDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] DatabaseDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.rebuild();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Boolf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get([In] object obj0) => (DatabaseDialog.lambda\u0024rebuild\u00240((Content) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly DatabaseDialog arg\u00241;
      private readonly Seq arg\u00242;

      internal __\u003C\u003EAnon2([In] DatabaseDialog obj0, [In] Seq obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00244(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly Image arg\u00241;
      private readonly ClickListener arg\u00242;

      internal __\u003C\u003EAnon3([In] Image obj0, [In] ClickListener obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => DatabaseDialog.lambda\u0024rebuild\u00241(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly UnlockableContent arg\u00241;

      internal __\u003C\u003EAnon4([In] UnlockableContent obj0) => this.arg\u00241 = obj0;

      public void run() => DatabaseDialog.lambda\u0024rebuild\u00242(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly UnlockableContent arg\u00241;

      internal __\u003C\u003EAnon5([In] UnlockableContent obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => DatabaseDialog.lambda\u0024rebuild\u00243(this.arg\u00241, (Table) obj0);
    }
  }
}
