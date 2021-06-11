// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.DiscordDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class DiscordDialog : Dialog
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 141, 134, 145, 139, 253, 79, 144, 155, 124, 187, 251, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DiscordDialog()
      : base("")
    {
      DiscordDialog discordDialog = this;
      float height = 70f;
      this.__\u003C\u003Econt.margin(12f);
      Color color = Color.valueOf("7289da");
      this.__\u003C\u003Econt.table((Cons) new DiscordDialog.__\u003C\u003EAnon0(height, color)).size(440f, height).pad(10f);
      this.__\u003C\u003Ebuttons.defaults().size(150f, 50f);
      this.__\u003C\u003Ebuttons.button("@back", (Runnable) new DiscordDialog.__\u003C\u003EAnon1(this));
      this.__\u003C\u003Ebuttons.button("@copylink", (Runnable) new DiscordDialog.__\u003C\u003EAnon2());
      this.__\u003C\u003Ebuttons.button("@openlink", (Runnable) new DiscordDialog.__\u003C\u003EAnon3());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 165, 150, 211, 134, 178, 139, 127, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00242([In] float obj0, [In] Color obj1, [In] Table obj2)
    {
      obj2.background((Drawable) Tex.button).margin(0.0f);
      obj2.table((Cons) new DiscordDialog.__\u003C\u003EAnon4(obj0, obj1)).expandY();
      obj2.table((Cons) new DiscordDialog.__\u003C\u003EAnon5()).size(obj0).left();
      Table table = obj2;
      object obj = (object) "@discord";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).color(Pal.accent).growX().padLeft(10f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 185, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00243() => Core.app.setClipboardText("https://discord.gg/mindustry");

    [Modifiers]
    [LineNumberTable(new byte[] {159, 188, 113, 111, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00244()
    {
      if (Core.app.openURI("https://discord.gg/mindustry"))
        return;
      Vars.ui.showErrorMessage("@linkfail");
      Core.app.setClipboardText("https://discord.gg/mindustry");
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 168, 127, 6, 103, 127, 32})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] float obj0, [In] Color obj1, [In] Table obj2)
    {
      obj2.image().height(obj0 - 5f).width(40f).color(obj1);
      obj2.row();
      obj2.image().height(5f).width(40f).color(obj1.cpy().mul(0.8f, 0.8f, 0.8f, 1f));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 174, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00241([In] Table obj0)
    {
      obj0.background((Drawable) Tex.button);
      obj0.image((Drawable) Icon.discord);
    }

    [HideFromJava]
    static DiscordDialog() => Dialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly float arg\u00241;
      private readonly Color arg\u00242;

      internal __\u003C\u003EAnon0([In] float obj0, [In] Color obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => DiscordDialog.lambda\u0024new\u00242(this.arg\u00241, this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly DiscordDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] DiscordDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public void run() => DiscordDialog.lambda\u0024new\u00243();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void run() => DiscordDialog.lambda\u0024new\u00244();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly float arg\u00241;
      private readonly Color arg\u00242;

      internal __\u003C\u003EAnon4([In] float obj0, [In] Color obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => DiscordDialog.lambda\u0024new\u00240(this.arg\u00241, this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Cons
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void get([In] object obj0) => DiscordDialog.lambda\u0024new\u00241((Table) obj0);
    }
  }
}
